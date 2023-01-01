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

        private readonly SPlayer _player = new SPlayer();
        private readonly PlayerState _state = new PlayerState();
        private readonly Timer _timer = new Timer();
        private Keys _lastKey;
        private long _lastKeyTime;

        public Form1() {
            InitializeComponent();
            ApplyTheme();

            _player.Install(videoView1);

            Panel panelDoubleClick = new TransparentPanel {
                Dock = DockStyle.Fill
            };
            panelDoubleClick.MouseDoubleClick += PanelDoubleClick_MouseDoubleClick;
            bodyPanel.Panel1.Controls.Add(panelDoubleClick);
            panelDoubleClick.BringToFront();
            subtitleLabel.BringToFront();

            _timer.Tick += Timer_Tick;
            _timer.Interval = 500;
            _timer.Start();

            _player.OnOpened += (o, i) => Invoke(new MethodInvoker(OnMediaOpened));
            subtitleBox.SelectedIndexChanged += SubtitleBox_SelectedIndexChanged;

            _state.ShowSubtitlePanel = Settings.ShowSubtitlePanel;
            _state.Setup(this, Render);

            Render();
        }


        private string MediaFolder {
            get {
                return Path.GetDirectoryName(_player.MediaPath);
            }
        }


        private Properties.Settings Settings {
            get { return Properties.Settings.Default; }
        }

        public void OpenMedia(string path) {
            if (File.Exists(path)) {
                playerBar.Duration = 0;
                _player.Open(path);
            }
        }

        private static int Clamp(int a, int min, int max) {
            return Math.Min(Math.Max(a, min), max);
        }

        private void bodyPanel_Panel1_Resize(object sender, EventArgs e) {
            Render();
        }

        private void Center() {
            Screen screen = Screen.FromControl(this);
            Rectangle workingArea = screen.WorkingArea;
            Location = new Point() {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - this.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - this.Height) / 2)
            };
        }

        private void Form1_DragDrop(object sender, DragEventArgs e) {
            var path = (e.Data.GetData(DataFormats.FileDrop) as String[])[0];
            OpenMedia(path);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
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
            Settings.ShowSubtitlePanel = _state.ShowSubtitlePanel;
            Settings.Save();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Location = Settings.Location;
            if (Settings.Maximised) {
                WindowState = FormWindowState.Maximized;
            } else if (Settings.Minimised) {
                WindowState = FormWindowState.Minimized;
            }
            Size = Settings.Size;

            if (Location.X == 0 && Location.Y == 0) Center();

            //auto load video
            var MediaPath = Settings.MediaPath;
            _player.Open(MediaPath, Settings.MediaProgress);
        }

        private void Form1_Resize(object sender, EventArgs e) {
            Render();
        }

        private void nextBtn_Click(object sender, EventArgs e) {
            openNext(1);
        }

        private void openBtn_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "Video files (*.mp3;*.mp4;*.mkv;*.avi)|*.mp3;*.mp4;*.mkv;*.avi|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (_player.MediaPath != null) {
                openFileDialog1.InitialDirectory = MediaFolder;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                OpenMedia(openFileDialog1.FileName);
            }
        }

        private void openNext(int offset) {
            var ext = Path.GetExtension(_player.MediaPath);
            string[] filePaths = Directory.GetFiles(MediaFolder, "*" + ext,
                                         SearchOption.TopDirectoryOnly);
            foreach (var p in filePaths) {
                Debug.WriteLine(p);
            }
            var index = Array.IndexOf(filePaths, _player.MediaPath);
            index += offset;
            index = Clamp(index, 0, filePaths.Length - 1);
            OpenMedia(filePaths[index]);
        }

        private void PanelDoubleClick_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (WindowState == FormWindowState.Maximized) {
                WindowState = FormWindowState.Normal;
            } else {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void playBtn_Click(object sender, EventArgs e) {
            if (_player.IsLoaded) {
                _player.player.Pause();
                System.Threading.Thread.Sleep(500);
            }
        }

        private void playBtn_KeyDown(object sender, KeyEventArgs e) {
            var index = subtitleBox.SelectedIndex;
            var dbclick = Now - _lastKeyTime < 500 && e.KeyCode == _lastKey;
            var step = dbclick ? 10 : 1;

            switch (e.KeyCode) {
                case Keys.Up:
                    RepeatSubtitle();
                    break;

                case Keys.Down:
                    _state.ShowSubtitlePanel = !_state.ShowSubtitlePanel;
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

        private void playBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            e.IsInputKey = true;
        }

        private void OnMediaOpened() {
            Text = _player.Name;
            subtitleBox.Items.Clear();
            if (_player.HasSubtitles) {
                var items = new List<MaterialListBoxItem>();
                foreach (var subtitle in _player.Subtitles) {
                    var item = new MaterialListBoxItem(subtitle.Text);
                    items.Add(item);
                }
                items.Add(new MaterialListBoxItem(""));//strange bug 
                subtitleBox.AddItems(items.ToArray());
            }
            //ResizeToViedo();
            Settings.MediaPath = _player.MediaPath;
            Render();
        }

        private void playerBar_onValueChanged(object sender, int newValue) {
            if (playerBar.Duration == 0) return;
            var isPlaying = _player.player.IsPlaying;
            var progress = playerBar.Progress;
            if (isPlaying) _player.player.SetPause(true);
            _player.Progress = progress;
            if (isPlaying) _player.player.SetPause(false);
        }

        private void prevBtn_Click(object sender, EventArgs e) {
            openNext(-1);
        }

        private void reloadBtn_Click(object sender, EventArgs e) {
            playerBar.Duration = 0;
            _player.Reload();
        }

        private void Render() {
            bodyPanel.Panel2Collapsed = !(_state.ShowSubtitlePanel && _player.HasSubtitles);
            SelectButton(toggleSubBtn, _state.ShowSubtitlePanel);

            var label = subtitleLabel;
            var subtitle = _state.Subtitle;
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
            MaterialButton[] btns = { playBtn, prevBtn, nextBtn, reloadBtn, repeatBtn };
            Enable(_player.IsLoaded, btns);
        }

        private void Enable(bool enabled, MaterialButton[] btns) {
            foreach (var btn in btns) {
                btn.Enabled = enabled;
                btn.Icon = btn.Icon;
            }
        }

        private void RenderVideoStatus() {
            playBtn.Icon = _player.player.IsPlaying ?
                Properties.Resources.pause : Properties.Resources.play;

            if (_player.IsPlaying) {
                if (_player.Subtitle != null) {
                    subtitleBox.SelectedIndex = _player.Subtitle.Index;
                    if (!subtitleBox.IsHovered) subtitleBox.ScrollToSelection();

                    if (_state.Subtitle != null) {
                        if (_player.Progress > _state.Subtitle.End.TotalSeconds + 2
                             || _player.Progress < _state.Subtitle.Start.TotalSeconds - 2) {
                            _state.Subtitle = null;
                        }
                    }
                }
                playerBar.Duration = _player.Duration;
                playerBar.Progress = _player.Progress;
                Settings.MediaProgress = _player.Progress;
            }
        }

        private void repeatBtn_Click(object sender, EventArgs e) {
            RepeatSubtitle();
        }

        private void RepeatSubtitle() {
            ToSubtitle(subtitleBox.SelectedIndex);
        }

        private void ResizeToViedo() {
            var showSubtitle = _state.ShowSubtitlePanel && _player.HasSubtitles;

            var screenPerc = .9;
            var formOffset = 60;
            var videoPerc = showSubtitle ? .6 : 1;

            var screen = Screen.FromControl(this);
            var widthMax = screen.Bounds.Width * screenPerc;
            var heightMax = screen.Bounds.Height * screenPerc;
            var videoRatio = (float)_player.VideoHeight / _player.VideoWidth;

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

        private void SelectButton(MaterialButton btn, bool select) {
            btn.Type = select ?
                MaterialButton.MaterialButtonType.Outlined
                : MaterialButton.MaterialButtonType.Text;
        }

        private void SubtitleBox_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem) {
            if (subtitleBox.SelectedIndex < _player.Subtitles.Count) {
                ToSubtitle(subtitleBox.SelectedIndex);
            }
        }

        private void Timer_Tick(object sender, EventArgs e) {
            if (!IsUserActing) playBtn.Focus();
            RenderVideoStatus();
        }

        private void toggleSubBtn_Click(object sender, EventArgs e) {
            _state.ShowSubtitlePanel = !_state.ShowSubtitlePanel;
        }

        private void ToSubtitle(int index) {
            if (!_player.HasSubtitles) return;

            index = Clamp(index, 0, _player.Subtitles.Count - 1);
            var subtitle = _player.Subtitles[index];
            subtitleBox.SelectedIndex = index;
            _state.Subtitle = subtitle;
            _player.player.SetPause(true);
            _player.Progress = (long)subtitle.Start.TotalSeconds;
            System.Threading.Thread.Sleep(200);
            _player.player.SetPause(false);
        }
    }

    internal class PlayerState : State {
        public bool ShowSubtitlePanel = true;
        public Line Subtitle = null;
    }
}