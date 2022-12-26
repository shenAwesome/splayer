using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using System.Drawing;
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
            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();

            player.OnOpened += (o, i) => Invoke(new MethodInvoker(delegate () {
                Player_Opened();
            }));
        }

        private void Player_Opened() {
            Text = player.Name;
            subtitleBox.Items.Clear();
            foreach (var subtitle in player.Subtitles) {
                var item = new MaterialListBoxItem(subtitle.Text);
                subtitleBox.Items.Add(item);
            }
            playerBar.Duration = player.Duration;
            ResizeToViedo();
        }

        private void ResizeToViedo() {
            var screenPerc = .9;
            var formOffset = 60;
            var videoPerc = status.ShowSubtitle ? .6 : 1;

            var screen = Screen.FromControl(this);
            var widthMax = screen.Bounds.Width * screenPerc;
            var heightMax = screen.Bounds.Height * screenPerc;
            var videoRatio = (float)player.VideoHeight / player.VideoWidth;
            Debug.WriteLine(player.VideoHeight);
            Debug.WriteLine(player.VideoWidth);
            Debug.WriteLine(videoRatio);

            var formWidth = widthMax;
            var formHeight = widthMax * videoPerc * videoRatio + formOffset;
            if (formHeight > heightMax) {
                formHeight = heightMax;
                formWidth = (int)((formHeight - formOffset) / videoRatio / videoPerc);
            }
            Width = Convert.ToInt32(formWidth);
            Height = Convert.ToInt32(formHeight);
            if (status.ShowSubtitle) bodyPanel.SplitterDistance = (int)(Width * videoPerc);
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
            if (player.player.IsPlaying) {
                if (player.Subtitle != null) {
                    subtitleBox.SelectedIndex = player.Subtitle.Index;
                }
                playerBar.Progress = player.Progress;
            }
            if (!IsUserActing) playBtn.Focus();
            RenderStatus();
        }


        private void Form1_Load(object sender, EventArgs e) {
            //this.FormStyle = FormStyles.ActionBar_None;

        }


        private void test() {

            if (player.IsLoaded) {
                player.player.Pause();
                return;
            }
            var file = @"D:\downloads\Wednesday.S01.COMPLETE.720p.NF.WEBRip.x264-GalaxyTV[TGx]\Wednesday.S01E01.720p.NF.WEBRip.x264-GalaxyTV.mkv";
            player.Open(file);


            //MaterialScrollBar scrollBar = Util.GetField<MaterialScrollBar>(subtitleBox, "_scrollBar");
            //scrollBar.Value = 500;
        }

        private void playerBar_onValueChanged(object sender, int newValue) {
            player.Progress = playerBar.Progress;
        }

        private void playBtn_Click(object sender, EventArgs e) {
            test();
        }

        private void RenderStatus() {
            playBtn.Icon = player.player.IsPlaying ?
                Properties.Resources.pause : Properties.Resources.play;

            bodyPanel.Panel2Collapsed = !status.ShowSubtitle;
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
                return (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - lastMouseDown < 1000;
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
                    lastMouseDown = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                }
            }
            base.WndProc(ref m);
        }

        private void reloadBtn_Click(object sender, EventArgs e) {
            player.Reload();
        }

        private void playBtn_Click_1(object sender, EventArgs e) {
            test();
        }
    }

    class SPlayerStatus {
        public bool ShowSubtitle = true;
    }
}
