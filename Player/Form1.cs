using MaterialSkin;
using MaterialSkin.Controls;
using SForm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SPlayer {
    public partial class Form1 : SForm.SForm {

        readonly SPlayerStatus status = new SPlayerStatus();
        readonly SPlayer player = new SPlayer();
        readonly Timer timer = new Timer();

        public Form1() {
            InitializeComponent();
            ApplyTheme();


            player.Install(videoView1);

            Panel panelDoubleClick = new TransparentPanel {
                Dock = DockStyle.Fill
            };
            panelDoubleClick.MouseDoubleClick += PanelDoubleClick_MouseDoubleClick;
            bodyPanel.Panel1.Controls.Add(panelDoubleClick);
            panelDoubleClick.BringToFront();
            subtitleLabel.BringToFront();

            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();

            player.OnOpened += (o, i) => Invoke(new MethodInvoker(delegate () {
                Player_Opened();
            }));

            subtitleBox.SelectedIndexChanged += SubtitleBox_SelectedIndexChanged;

            status.Setup(this, RenderStatus);
        }

        private void PanelDoubleClick_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (WindowState == FormWindowState.Maximized) {
                WindowState = FormWindowState.Normal;
            } else {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void SubtitleBox_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem) {
            if (subtitleBox.SelectedIndex < player.Subtitles.Count) {
                ToSubtitle(subtitleBox.SelectedIndex);
            }
        }

        private void ToSubtitle(int index) {
            if (player.HasSubtitles) {
                index = Clamp(index, 0, player.Subtitles.Count - 1);
                var subtitle = player.Subtitles[index];
                subtitleBox.SelectedIndex = index;
                status.Subtitle = subtitle;
                player.player.SetPause(true);
                player.Progress = (long)subtitle.Start.TotalSeconds;
                System.Threading.Thread.Sleep(200);
                player.player.SetPause(false);
            }
        }



        private Properties.Settings Settings {
            get {
                return Properties.Settings.Default;
            }
        }

        private void Player_Opened() {
            RenderStatus();
            Text = player.Name;
            subtitleBox.Items.Clear();
            if (player.HasSubtitles) {
                var items = new List<MaterialListBoxItem>();
                foreach (var subtitle in player.Subtitles) {
                    var item = new MaterialListBoxItem(subtitle.Text);
                    items.Add(item);
                }
                items.Add(new MaterialListBoxItem(""));//strange bug

                subtitleBox.AddItems(items.ToArray());
            }

            //ResizeToViedo();
            Settings.MediaPath = player.MediaPath;
        }

        private void ResizeToViedo() {

            var showSubtitle = status.ShowSubtitle && player.HasSubtitles;

            var screenPerc = .9;
            var formOffset = 60;
            var videoPerc = showSubtitle ? .6 : 1;

            var screen = Screen.FromControl(this);
            var widthMax = screen.Bounds.Width * screenPerc;
            var heightMax = screen.Bounds.Height * screenPerc;
            var videoRatio = (float)player.VideoHeight / player.VideoWidth;

            var formWidth = widthMax;
            var formHeight = widthMax * videoPerc * videoRatio + formOffset;
            if (formHeight > heightMax) {
                formHeight = heightMax;
                formWidth = (int)((formHeight - formOffset) / videoRatio / videoPerc);
            }
            Width = Convert.ToInt32(formWidth);
            Height = Convert.ToInt32(formHeight);
            if (showSubtitle) bodyPanel.SplitterDistance = (int)(Width * videoPerc);
            Center();
        }

        private void Center() {
            Screen screen = Screen.FromControl(this);
            Rectangle workingArea = screen.WorkingArea;
            Location = new Point() {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - this.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - this.Height) / 2)
            };
        }

        private void Timer_Tick(object sender, EventArgs e) {
            if (!IsUserActing) playBtn.Focus();
            RenderVideoStatus();
        }


        private void Form1_Load(object sender, EventArgs e) {
            Location = Settings.Location;
            if (Settings.Maximised) {
                WindowState = FormWindowState.Maximized;
            } else if (Settings.Minimised) {
                WindowState = FormWindowState.Minimized;
            }
            Size = Settings.Size;

            if (Location.X == 0 && Location.Y == 0) {
                Center();
            }

            //auto load video
            var MediaPath = Settings.MediaPath;
            player.Open(MediaPath, Settings.MediaProgress);
        }

        private void playerBar_onValueChanged(object sender, int newValue) {
            player.Progress = playerBar.Progress;
        }

        private void playBtn_Click(object sender, EventArgs e) {
            if (player.IsLoaded) {
                player.player.Pause();
                return;
            }
        }

        private void RenderVideoStatus() {

            playBtn.Icon = player.player.IsPlaying ?
                Properties.Resources.pause : Properties.Resources.play;

            if (player.IsPlaying) {
                if (player.Subtitle != null) {
                    subtitleBox.SelectedIndex = player.Subtitle.Index;
                    if (!subtitleBox.IsHovered) subtitleBox.ScrollToSelection();

                    if (status.Subtitle != null) {
                        if (player.Progress > status.Subtitle.Start.TotalSeconds + 5) {
                            status.Subtitle = null;
                        }
                    }
                }
                playerBar.Duration = player.Duration;
                playerBar.Progress = player.Progress;
                Settings.MediaProgress = player.Progress;
            }
        }

        private void RenderStatus() {
            bodyPanel.Panel2Collapsed = !(status.ShowSubtitle && player.HasSubtitles);
            SelectButton(toggleSubBtn, status.ShowSubtitle);

            var label = subtitleLabel;
            var subtitle = status.Subtitle;
            if (subtitle == null) {
                label.Visible = false;
            } else {
                label.MaximumSize = new Size(videoView1.Width - 10, 0);
                label.AutoSize = true;
                label.Font = new Font(label.Font.FontFamily, 20);
                label.Text = subtitle.Text;
                var loc = label.Location;
                loc.X = (videoView1.Width - label.Size.Width) / 2;
                loc.Y = videoView1.Height - label.Size.Height - 2;
                label.Location = loc;
                label.Visible = true;
            }
        }

        private void SelectButton(MaterialButton btn, bool select) {
            btn.Type = select ?
                MaterialButton.MaterialButtonType.Outlined
                : MaterialButton.MaterialButtonType.Text;
        }

        private void toggleSubBtn_Click(object sender, EventArgs e) {
            this.status.ShowSubtitle = !this.status.ShowSubtitle;
        }


        private long lastMouseDown = 0;
        private bool IsUserActing {
            get {
                return Now - lastMouseDown < 1000;
            }
        }

        protected const int WM_PARENTNOTIFY = 0x210;
        protected const int WM_LBUTTONDOWN = 0x201;
        protected const int WM_RBUTTONDOWN = 0x204;

        protected override void WndProc(ref Message m) {
            // This is the message from child controls to their parent when a Win32 event occurs.
            if (m.Msg == WM_PARENTNOTIFY) {
                int wparam = m.WParam.ToInt32();
                if (wparam == WM_LBUTTONDOWN || wparam == WM_RBUTTONDOWN) {
                    lastMouseDown = Now;
                }
            }
            base.WndProc(ref m);
        }

        private void reloadBtn_Click(object sender, EventArgs e) {
            playerBar.Duration = 0;
            player.Reload();
        }

        /// <summary>
        ///  Now in millionsec
        /// </summary>
        private long Now {
            get {
                return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e) {
            var path = (e.Data.GetData(DataFormats.FileDrop) as String[])[0];
            OpenMedia(path);
        }

        public void OpenMedia(string path) {
            if (File.Exists(path)) {
                playerBar.Duration = 0;
                player.Open(path);
            }
        }

        private void openBtn_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "Video files (*.mp3;*.mp4;*.mkv;*.avi)|*.mp3;*.mp4;*.mkv;*.avi|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (player.MediaPath != null) {
                openFileDialog1.InitialDirectory = MediaFolder;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                OpenMedia(openFileDialog1.FileName);
            }
        }

        static int Clamp(int a, int min, int max) {
            return Math.Min(Math.Max(a, min), max);
        }

        private void playBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            e.IsInputKey = true;
        }

        private Keys _lastKey;
        private long _lastKeyTime;

        private void playBtn_KeyDown(object sender, KeyEventArgs e) {
            var index = subtitleBox.SelectedIndex;
            var dbclick = Now - _lastKeyTime < 500 && e.KeyCode == _lastKey;
            var step = dbclick ? 10 : 1;

            switch (e.KeyCode) {
                case Keys.Up:
                    RepeatSubtitle();
                    break;
                case Keys.Down:
                    status.ShowSubtitle = !status.ShowSubtitle;
                    //ullScreen.EnterFullScreenMode(this);
                    break;
                case Keys.Left:
                    ToSubtitle(index - step);
                    break;
                case Keys.Right:
                    ToSubtitle(index + step);
                    break;
            }

            subtitleBox.ScrollToSelection();
            _lastKey = e.KeyCode;
            _lastKeyTime = Now;
        }

        private void repeatBtn_Click(object sender, EventArgs e) {
            RepeatSubtitle();
        }

        private void RepeatSubtitle() {
            ToSubtitle(subtitleBox.SelectedIndex);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (WindowState == FormWindowState.Maximized) {
                Settings.Location = RestoreBounds.Location;
                Settings.Size = RestoreBounds.Size;
                Settings.Maximised = true;
                Settings.Minimised = false;
            } else if (WindowState == FormWindowState.Normal) {
                Settings.Location = Location;
                Settings.Size = Size;
                Settings.Maximised = false;
                Settings.Minimised = false;
            } else {
                Settings.Location = RestoreBounds.Location;
                Settings.Size = RestoreBounds.Size;
                Settings.Maximised = false;
                Settings.Minimised = true;
            }
            Settings.Save();
        }

        private string MediaFolder {
            get {
                return Path.GetDirectoryName(player.MediaPath);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e) {
            openNext(1);
        }

        private void openNext(int offset) {
            var ext = Path.GetExtension(player.MediaPath);
            string[] filePaths = Directory.GetFiles(MediaFolder, "*" + ext,
                                         SearchOption.TopDirectoryOnly);
            foreach (var p in filePaths) {
                Debug.WriteLine(p);
            }
            var index = Array.IndexOf(filePaths, player.MediaPath);
            index += offset;
            index = Clamp(index, 0, filePaths.Length - 1);
            OpenMedia(filePaths[index]);
        }

        private void prevBtn_Click(object sender, EventArgs e) {
            openNext(-1);
        }

        private void bodyPanel_Panel1_Resize(object sender, EventArgs e) {
            this.RenderStatus();
        }

        private void Form1_Resize(object sender, EventArgs e) {
            this.RenderStatus();
        }
    }

    class SPlayerStatus : State {
        public bool ShowSubtitle = true;
        public Line Subtitle = null;
    }


}
