using MaterialSkin;
using MaterialSkin.Controls;
using SForm;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SPlayer {
    public partial class Form1 : SForm.SForm {
        readonly SPlayer player = new SPlayer();
        Timer timer = new Timer();

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
        }

        private void Timer_Tick(object sender, EventArgs e) {
            if (player.player.IsPlaying) {
                if (player.Subtitle != null) {
                    subtitleBox.SelectedIndex = player.Subtitle.Index;
                }
                playerBar.Duration = player.Duration;
                playerBar.Progress = player.Progress;
            }
            UpdateBtns();
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
            Text = player.Name;
            subtitleBox.Items.Clear();
            foreach (var subtitle in player.Subtitles) {
                var item = new MaterialListBoxItem(subtitle.Text);
                subtitleBox.Items.Add(item);
            }

            MaterialScrollBar scrollBar = Util.GetField<MaterialScrollBar>(subtitleBox, "_scrollBar");
            scrollBar.Value = 500;
        }

        private void playerBar_onValueChanged(object sender, int newValue) {
            player.Progress = playerBar.Progress;
        }

        private void materialButton1_Click(object sender, EventArgs e) {

        }

        private void playBtn_Click(object sender, EventArgs e) {
            test();
        }

        private void UpdateBtns() {
            if (player.player.IsPlaying) {
                playBtn.Icon = Properties.Resources.pause;
            } else {
                playBtn.Icon = Properties.Resources.play;
            }
        }
    }

}
