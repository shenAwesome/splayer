using LibVLCSharp.Shared;
using MaterialSkin;
using MaterialSkin.Controls;
using SForm;
using System;
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

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey500,
                Primary.BlueGrey900, Primary.BlueGrey100, Accent.DeepOrange700,
                TextShade.WHITE);

            player.Install(videoView1);

            Panel panelDoubleClick = new TransparentPanel();
            panelDoubleClick.Dock = DockStyle.Fill;
            bodyPanel.Panel1.Controls.Add(panelDoubleClick);
            panelDoubleClick.BringToFront();
            panelDoubleClick.MouseDoubleClick += PanelDoubleClick_MouseDoubleClick;

            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();

            player.OnOpened += (o, i) => Invoke(new MethodInvoker(delegate () {
                Player_Opened();
                //panelDoubleClick.Visible = false;
            }));

            subtitleBox.SelectedIndexChanged += SubtitleBox_SelectedIndexChanged;

            status.Setup(this, RenderStatus);

            Subtitle = null;
        }

        private void PanelDoubleClick_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (WindowState == FormWindowState.Maximized) {
                WindowState = FormWindowState.Normal;
            } else {
                WindowState = FormWindowState.Maximized;
            }
        }

        protected override bool IsInputKey(Keys keyData) {
            switch (keyData) {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
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
                Subtitle = subtitle;
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
                foreach (var subtitle in player.Subtitles) {
                    var item = new MaterialListBoxItem(subtitle.Text);
                    subtitleBox.Items.Add(item);
                }
                subtitleBox.Items.Add(new MaterialListBoxItem(""));//strange bug
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

                    if (Subtitle != null) {
                        if (player.Progress > Subtitle.Start.TotalSeconds + 5) {
                            Subtitle = null;
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

        Keys _lastKey;
        long _lastKeyTime;

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
            var folder = MediaFolder;
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



        Line _subtitle;

        public Line Subtitle {
            get {
                return _subtitle;
            }
            set {
                _subtitle = value;
                if (value == null) {
                    subtitleLabel.Visible = false;
                } else {
                    //var text = player.SubtitleText;
                    subtitleLabel.MaximumSize = new Size(videoView1.Width - 10, 0);
                    subtitleLabel.AutoSize = true;
                    subtitleLabel.Font = new Font(subtitleLabel.Font.FontFamily, 20);
                    subtitleLabel.Text = _subtitle.Text;
                    var loc = subtitleLabel.Location;
                    loc.X = (videoView1.Width - subtitleLabel.Size.Width) / 2;
                    loc.Y = videoView1.Height - subtitleLabel.Size.Height - 2;
                    subtitleLabel.Location = loc;
                    subtitleLabel.Visible = true;
                }
            }
        }
    }

    class SPlayerStatus : State {
        public bool ShowSubtitle = true;
    }


}
