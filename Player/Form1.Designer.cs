using SForm;
using System.Windows.Forms;

namespace SPlayer {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.videoView1 = new LibVLCSharp.WinForms.VideoView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.subtitleBox = new MaterialSkin.Controls.MaterialListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.playBtn = new MaterialSkin.Controls.MaterialButton();
            this.reloadBtn = new MaterialSkin.Controls.MaterialButton();
            this.prevBtn = new MaterialSkin.Controls.MaterialButton();
            this.nextBtn = new MaterialSkin.Controls.MaterialButton();
            this.openBtn = new MaterialSkin.Controls.MaterialButton();
            this.foot = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.playerBar = new SForm.PlayerBar();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.repeatBtn = new MaterialSkin.Controls.MaterialButton();
            this.toggleSubBtn = new MaterialSkin.Controls.MaterialButton();
            this.menuBtn = new MaterialSkin.Controls.MaterialButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.foot.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoView1.Location = new System.Drawing.Point(0, 0);
            this.videoView1.MediaPlayer = null;
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(343, 408);
            this.videoView1.TabIndex = 0;
            this.videoView1.Text = "videoView1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel1.Controls.Add(this.videoView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.subtitleBox);
            this.splitContainer1.Size = new System.Drawing.Size(654, 408);
            this.splitContainer1.SplitterDistance = 343;
            this.splitContainer1.TabIndex = 1;
            // 
            // subtitleBox
            // 
            this.subtitleBox.BackColor = System.Drawing.Color.White;
            this.subtitleBox.BorderColor = System.Drawing.Color.LightGray;
            this.subtitleBox.Depth = 0;
            this.subtitleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subtitleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.subtitleBox.Location = new System.Drawing.Point(0, 0);
            this.subtitleBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.subtitleBox.Name = "subtitleBox";
            this.subtitleBox.SelectedIndex = -1;
            this.subtitleBox.SelectedItem = null;
            this.subtitleBox.ShowBorder = false;
            this.subtitleBox.Size = new System.Drawing.Size(307, 408);
            this.subtitleBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Controls.Add(this.playBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.reloadBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.prevBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.nextBtn, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.openBtn, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(240, 48);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // playBtn
            // 
            this.playBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.playBtn.Depth = 0;
            this.playBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playBtn.HighEmphasis = true;
            this.playBtn.Icon = global::SPlayer.Properties.Resources.play;
            this.playBtn.Location = new System.Drawing.Point(4, 6);
            this.playBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.playBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.playBtn.Name = "playBtn";
            this.playBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.playBtn.Size = new System.Drawing.Size(40, 36);
            this.playBtn.TabIndex = 3;
            this.playBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.playBtn.UseAccentColor = false;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // reloadBtn
            // 
            this.reloadBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reloadBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.reloadBtn.Depth = 0;
            this.reloadBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reloadBtn.HighEmphasis = true;
            this.reloadBtn.Icon = global::SPlayer.Properties.Resources.replay;
            this.reloadBtn.Location = new System.Drawing.Point(52, 4);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(4);
            this.reloadBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.reloadBtn.Size = new System.Drawing.Size(40, 40);
            this.reloadBtn.TabIndex = 0;
            this.reloadBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.reloadBtn.UseAccentColor = false;
            this.reloadBtn.UseVisualStyleBackColor = true;
            // 
            // prevBtn
            // 
            this.prevBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.prevBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.prevBtn.Depth = 0;
            this.prevBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prevBtn.HighEmphasis = true;
            this.prevBtn.Icon = global::SPlayer.Properties.Resources.skip_previous;
            this.prevBtn.Location = new System.Drawing.Point(100, 4);
            this.prevBtn.Margin = new System.Windows.Forms.Padding(4);
            this.prevBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.prevBtn.Size = new System.Drawing.Size(40, 40);
            this.prevBtn.TabIndex = 4;
            this.prevBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.prevBtn.UseAccentColor = false;
            this.prevBtn.UseVisualStyleBackColor = true;
            // 
            // nextBtn
            // 
            this.nextBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.nextBtn.Depth = 0;
            this.nextBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextBtn.HighEmphasis = true;
            this.nextBtn.Icon = global::SPlayer.Properties.Resources.skip_next;
            this.nextBtn.Location = new System.Drawing.Point(148, 6);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.nextBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.nextBtn.Size = new System.Drawing.Size(40, 36);
            this.nextBtn.TabIndex = 7;
            this.nextBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.nextBtn.UseAccentColor = false;
            this.nextBtn.UseVisualStyleBackColor = true;
            // 
            // openBtn
            // 
            this.openBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.openBtn.Depth = 0;
            this.openBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openBtn.HighEmphasis = true;
            this.openBtn.Icon = global::SPlayer.Properties.Resources.folder_open;
            this.openBtn.Location = new System.Drawing.Point(196, 4);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4);
            this.openBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.openBtn.Name = "openBtn";
            this.openBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.openBtn.Size = new System.Drawing.Size(40, 40);
            this.openBtn.TabIndex = 5;
            this.openBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.openBtn.UseAccentColor = false;
            this.openBtn.UseVisualStyleBackColor = true;
            // 
            // foot
            // 
            this.foot.Controls.Add(this.panel1);
            this.foot.Controls.Add(this.tableLayoutPanel1);
            this.foot.Controls.Add(this.tableLayoutPanel2);
            this.foot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.foot.Location = new System.Drawing.Point(3, 432);
            this.foot.Margin = new System.Windows.Forms.Padding(3, 100, 3, 3);
            this.foot.Name = "foot";
            this.foot.Size = new System.Drawing.Size(654, 48);
            this.foot.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.playerBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(240, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 48);
            this.panel1.TabIndex = 9;
            // 
            // playerBar
            // 
            this.playerBar.Depth = 0;
            this.playerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerBar.Duration = ((long)(0));
            this.playerBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.playerBar.Location = new System.Drawing.Point(0, 0);
            this.playerBar.Margin = new System.Windows.Forms.Padding(0);
            this.playerBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.playerBar.Name = "playerBar";
            this.playerBar.Progress = ((long)(0));
            this.playerBar.RangeMax = 10000;
            this.playerBar.ShowText = false;
            this.playerBar.ShowValue = false;
            this.playerBar.Size = new System.Drawing.Size(270, 48);
            this.playerBar.TabIndex = 8;
            this.playerBar.Text = "";
            this.playerBar.Value = 0;
            this.playerBar.onValueChanged += new SForm.MaterialSlider.ValueChanged(this.playerBar_onValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.Controls.Add(this.repeatBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.toggleSubBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.menuBtn, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(510, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(144, 48);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // repeatBtn
            // 
            this.repeatBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.repeatBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.repeatBtn.Depth = 0;
            this.repeatBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repeatBtn.HighEmphasis = true;
            this.repeatBtn.Icon = global::SPlayer.Properties.Resources.voice;
            this.repeatBtn.Location = new System.Drawing.Point(4, 4);
            this.repeatBtn.Margin = new System.Windows.Forms.Padding(4);
            this.repeatBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.repeatBtn.Name = "repeatBtn";
            this.repeatBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.repeatBtn.Size = new System.Drawing.Size(40, 40);
            this.repeatBtn.TabIndex = 8;
            this.repeatBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.repeatBtn.UseAccentColor = false;
            this.repeatBtn.UseVisualStyleBackColor = true;
            this.repeatBtn.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // toggleSubBtn
            // 
            this.toggleSubBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toggleSubBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.toggleSubBtn.Depth = 0;
            this.toggleSubBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toggleSubBtn.HighEmphasis = true;
            this.toggleSubBtn.Icon = global::SPlayer.Properties.Resources.subtitles;
            this.toggleSubBtn.Location = new System.Drawing.Point(52, 4);
            this.toggleSubBtn.Margin = new System.Windows.Forms.Padding(4);
            this.toggleSubBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.toggleSubBtn.Name = "toggleSubBtn";
            this.toggleSubBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.toggleSubBtn.Size = new System.Drawing.Size(40, 40);
            this.toggleSubBtn.TabIndex = 10;
            this.toggleSubBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.toggleSubBtn.UseAccentColor = false;
            this.toggleSubBtn.UseVisualStyleBackColor = true;
            // 
            // menuBtn
            // 
            this.menuBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menuBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.menuBtn.Depth = 0;
            this.menuBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBtn.HighEmphasis = true;
            this.menuBtn.Icon = global::SPlayer.Properties.Resources.configure;
            this.menuBtn.Location = new System.Drawing.Point(96, 0);
            this.menuBtn.Margin = new System.Windows.Forms.Padding(0);
            this.menuBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.menuBtn.Size = new System.Drawing.Size(48, 48);
            this.menuBtn.TabIndex = 9;
            this.menuBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.menuBtn.UseAccentColor = false;
            this.menuBtn.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "replay.png");
            this.imageList1.Images.SetKeyName(1, "skip-next.png");
            this.imageList1.Images.SetKeyName(2, "skip-previous.png");
            this.imageList1.Images.SetKeyName(3, "stop.png");
            this.imageList1.Images.SetKeyName(4, "pause.png");
            this.imageList1.Images.SetKeyName(5, "play.png");
            this.imageList1.Images.SetKeyName(6, "folder-open.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(660, 483);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.foot);
            this.DrawerShowIconsWhenHidden = true;
            this.Name = "Form1";
            this.Tag = "";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.foot.ResumeLayout(false);
            this.foot.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MaterialSkin.Controls.MaterialButton reloadBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton openBtn;
        private MaterialSkin.Controls.MaterialButton prevBtn;
        private MaterialSkin.Controls.MaterialButton playBtn;
        private MaterialSkin.Controls.MaterialButton nextBtn;
        private Panel foot;
        private PlayerBar playerBar;
        private ImageList imageList1;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialListBox subtitleBox;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialButton toggleSubBtn;
        private MaterialSkin.Controls.MaterialButton menuBtn;
        private MaterialSkin.Controls.MaterialButton repeatBtn;
    }
}

