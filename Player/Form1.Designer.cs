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
            this.bodyPanel = new System.Windows.Forms.SplitContainer();
            this.subtitleBox = new MaterialSkin.Controls.MaterialListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.footerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.playBtn = new MaterialSkin.Controls.MaterialButton();
            this.reloadBtn = new MaterialSkin.Controls.MaterialButton();
            this.prevBtn = new MaterialSkin.Controls.MaterialButton();
            this.nextBtn = new MaterialSkin.Controls.MaterialButton();
            this.openBtn = new MaterialSkin.Controls.MaterialButton();
            this.playerBar = new SForm.PlayerBar();
            this.repeatBtn = new MaterialSkin.Controls.MaterialButton();
            this.toggleSubBtn = new MaterialSkin.Controls.MaterialButton();
            this.menuBtn = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyPanel)).BeginInit();
            this.bodyPanel.Panel1.SuspendLayout();
            this.bodyPanel.Panel2.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoView1.Location = new System.Drawing.Point(0, 0);
            this.videoView1.MediaPlayer = null;
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(459, 414);
            this.videoView1.TabIndex = 0;
            this.videoView1.Text = "videoView1";
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.Color.Black;
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(3, 24);
            this.bodyPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bodyPanel.Name = "bodyPanel";
            // 
            // bodyPanel.Panel1
            // 
            this.bodyPanel.Panel1.BackColor = System.Drawing.Color.Black;
            this.bodyPanel.Panel1.Controls.Add(this.videoView1);
            // 
            // bodyPanel.Panel2
            // 
            this.bodyPanel.Panel2.Controls.Add(this.subtitleBox);
            this.bodyPanel.Size = new System.Drawing.Size(668, 414);
            this.bodyPanel.SplitterDistance = 459;
            this.bodyPanel.TabIndex = 1;
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
            this.subtitleBox.Size = new System.Drawing.Size(205, 414);
            this.subtitleBox.TabIndex = 0;
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
            // footerPanel
            // 
            this.footerPanel.ColumnCount = 9;
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.footerPanel.Controls.Add(this.playBtn, 0, 0);
            this.footerPanel.Controls.Add(this.reloadBtn, 1, 0);
            this.footerPanel.Controls.Add(this.prevBtn, 2, 0);
            this.footerPanel.Controls.Add(this.nextBtn, 3, 0);
            this.footerPanel.Controls.Add(this.openBtn, 4, 0);
            this.footerPanel.Controls.Add(this.playerBar, 5, 0);
            this.footerPanel.Controls.Add(this.repeatBtn, 6, 0);
            this.footerPanel.Controls.Add(this.toggleSubBtn, 7, 0);
            this.footerPanel.Controls.Add(this.menuBtn, 8, 0);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(3, 438);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.RowCount = 1;
            this.footerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.footerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.footerPanel.Size = new System.Drawing.Size(668, 48);
            this.footerPanel.TabIndex = 1;
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
            this.playBtn.TabIndex = 4;
            this.playBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.playBtn.UseAccentColor = false;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click_1);
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
            this.reloadBtn.TabIndex = 5;
            this.reloadBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.reloadBtn.UseAccentColor = false;
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
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
            this.prevBtn.TabIndex = 6;
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
            this.nextBtn.TabIndex = 8;
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
            this.openBtn.TabIndex = 9;
            this.openBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.openBtn.UseAccentColor = false;
            this.openBtn.UseVisualStyleBackColor = true;
            // 
            // playerBar
            // 
            this.playerBar.Depth = 0;
            this.playerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerBar.Duration = ((long)(0));
            this.playerBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.playerBar.Location = new System.Drawing.Point(240, 0);
            this.playerBar.Margin = new System.Windows.Forms.Padding(0);
            this.playerBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.playerBar.Name = "playerBar";
            this.playerBar.Progress = ((long)(0));
            this.playerBar.RangeMax = 10000;
            this.playerBar.ShowText = false;
            this.playerBar.ShowValue = false;
            this.playerBar.Size = new System.Drawing.Size(284, 48);
            this.playerBar.TabIndex = 10;
            this.playerBar.Text = "";
            this.playerBar.Value = 0;
            this.playerBar.onValueChanged += new SForm.MaterialSlider.ValueChanged(this.playerBar_onValueChanged);
            // 
            // repeatBtn
            // 
            this.repeatBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.repeatBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.repeatBtn.Depth = 0;
            this.repeatBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repeatBtn.HighEmphasis = true;
            this.repeatBtn.Icon = global::SPlayer.Properties.Resources.voice;
            this.repeatBtn.Location = new System.Drawing.Point(528, 4);
            this.repeatBtn.Margin = new System.Windows.Forms.Padding(4);
            this.repeatBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.repeatBtn.Name = "repeatBtn";
            this.repeatBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.repeatBtn.Size = new System.Drawing.Size(40, 40);
            this.repeatBtn.TabIndex = 11;
            this.repeatBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.repeatBtn.UseAccentColor = false;
            this.repeatBtn.UseVisualStyleBackColor = true;
            // 
            // toggleSubBtn
            // 
            this.toggleSubBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toggleSubBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.toggleSubBtn.Depth = 0;
            this.toggleSubBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toggleSubBtn.HighEmphasis = true;
            this.toggleSubBtn.Icon = global::SPlayer.Properties.Resources.subtitles;
            this.toggleSubBtn.Location = new System.Drawing.Point(576, 4);
            this.toggleSubBtn.Margin = new System.Windows.Forms.Padding(4);
            this.toggleSubBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.toggleSubBtn.Name = "toggleSubBtn";
            this.toggleSubBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.toggleSubBtn.Size = new System.Drawing.Size(40, 40);
            this.toggleSubBtn.TabIndex = 12;
            this.toggleSubBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.toggleSubBtn.UseAccentColor = false;
            this.toggleSubBtn.UseVisualStyleBackColor = true;
            this.toggleSubBtn.Click += new System.EventHandler(this.toggleSubBtn_Click);
            // 
            // menuBtn
            // 
            this.menuBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menuBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.menuBtn.Depth = 0;
            this.menuBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBtn.HighEmphasis = true;
            this.menuBtn.Icon = global::SPlayer.Properties.Resources.configure;
            this.menuBtn.Location = new System.Drawing.Point(620, 0);
            this.menuBtn.Margin = new System.Windows.Forms.Padding(0);
            this.menuBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.menuBtn.Size = new System.Drawing.Size(48, 48);
            this.menuBtn.TabIndex = 13;
            this.menuBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.menuBtn.UseAccentColor = false;
            this.menuBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(674, 489);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.footerPanel);
            this.DrawerShowIconsWhenHidden = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).EndInit();
            this.bodyPanel.Panel1.ResumeLayout(false);
            this.bodyPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bodyPanel)).EndInit();
            this.bodyPanel.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private System.Windows.Forms.SplitContainer bodyPanel;
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialListBox subtitleBox;
        private TableLayoutPanel footerPanel;
        private MaterialSkin.Controls.MaterialButton menuBtn;
        private MaterialSkin.Controls.MaterialButton toggleSubBtn;
        private MaterialSkin.Controls.MaterialButton repeatBtn;
        private PlayerBar playerBar;
        private MaterialSkin.Controls.MaterialButton openBtn;
        private MaterialSkin.Controls.MaterialButton nextBtn;
        private MaterialSkin.Controls.MaterialButton prevBtn;
        private MaterialSkin.Controls.MaterialButton reloadBtn;
        private MaterialSkin.Controls.MaterialButton playBtn;
    }
}

