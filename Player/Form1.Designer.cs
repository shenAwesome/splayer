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
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.subtitleBox = new SForm.SListBox();
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.videoView1.Size = new System.Drawing.Size(410, 422);
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
            this.bodyPanel.Panel1.Controls.Add(this.subtitleLabel);
            this.bodyPanel.Panel1.Controls.Add(this.videoView1);
            this.bodyPanel.Panel1.Resize += new System.EventHandler(this.bodyPanel_Panel1_Resize);
            // 
            // bodyPanel.Panel2
            // 
            this.bodyPanel.Panel2.Controls.Add(this.subtitleBox);
            this.bodyPanel.Size = new System.Drawing.Size(599, 422);
            this.bodyPanel.SplitterDistance = 410;
            this.bodyPanel.TabIndex = 1;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.DimGray;
            this.subtitleLabel.Location = new System.Drawing.Point(179, 365);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Padding = new System.Windows.Forms.Padding(5);
            this.subtitleLabel.Size = new System.Drawing.Size(80, 35);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "label1";
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
            this.subtitleBox.Size = new System.Drawing.Size(185, 422);
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
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
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
            this.footerPanel.Location = new System.Drawing.Point(3, 446);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.RowCount = 1;
            this.footerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.footerPanel.Size = new System.Drawing.Size(599, 43);
            this.footerPanel.TabIndex = 1;
            // 
            // playBtn
            // 
            this.playBtn.AutoSize = false;
            this.playBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.playBtn.Depth = 0;
            this.playBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playBtn.HighEmphasis = true;
            this.playBtn.Icon = global::SPlayer.Properties.Resources.play;
            this.playBtn.Location = new System.Drawing.Point(0, 0);
            this.playBtn.Margin = new System.Windows.Forms.Padding(0);
            this.playBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.playBtn.Name = "playBtn";
            this.playBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.playBtn.Size = new System.Drawing.Size(42, 43);
            this.playBtn.TabIndex = 4;
            this.playBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.playBtn.UseAccentColor = false;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            this.playBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playBtn_KeyDown);
            this.playBtn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.playBtn_PreviewKeyDown);
            // 
            // reloadBtn
            // 
            this.reloadBtn.AutoSize = false;
            this.reloadBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reloadBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.reloadBtn.Depth = 0;
            this.reloadBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reloadBtn.HighEmphasis = true;
            this.reloadBtn.Icon = global::SPlayer.Properties.Resources.replay;
            this.reloadBtn.Location = new System.Drawing.Point(42, 0);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(0);
            this.reloadBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.reloadBtn.Size = new System.Drawing.Size(42, 43);
            this.reloadBtn.TabIndex = 5;
            this.reloadBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.reloadBtn.UseAccentColor = false;
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.AutoSize = false;
            this.prevBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.prevBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.prevBtn.Depth = 0;
            this.prevBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prevBtn.HighEmphasis = true;
            this.prevBtn.Icon = global::SPlayer.Properties.Resources.skip_previous;
            this.prevBtn.Location = new System.Drawing.Point(84, 0);
            this.prevBtn.Margin = new System.Windows.Forms.Padding(0);
            this.prevBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.prevBtn.Size = new System.Drawing.Size(42, 43);
            this.prevBtn.TabIndex = 6;
            this.prevBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.prevBtn.UseAccentColor = false;
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.AutoSize = false;
            this.nextBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.nextBtn.Depth = 0;
            this.nextBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextBtn.HighEmphasis = true;
            this.nextBtn.Icon = global::SPlayer.Properties.Resources.skip_next;
            this.nextBtn.Location = new System.Drawing.Point(126, 0);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(0);
            this.nextBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.nextBtn.Size = new System.Drawing.Size(42, 43);
            this.nextBtn.TabIndex = 8;
            this.nextBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.nextBtn.UseAccentColor = false;
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.AutoSize = false;
            this.openBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.openBtn.Depth = 0;
            this.openBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openBtn.HighEmphasis = true;
            this.openBtn.Icon = global::SPlayer.Properties.Resources.folder_open;
            this.openBtn.Location = new System.Drawing.Point(168, 0);
            this.openBtn.Margin = new System.Windows.Forms.Padding(0);
            this.openBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.openBtn.Name = "openBtn";
            this.openBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.openBtn.Size = new System.Drawing.Size(42, 43);
            this.openBtn.TabIndex = 9;
            this.openBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.openBtn.UseAccentColor = false;
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // playerBar
            // 
            this.playerBar.Depth = 0;
            this.playerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerBar.Duration = ((long)(0));
            this.playerBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.playerBar.Location = new System.Drawing.Point(211, 1);
            this.playerBar.Margin = new System.Windows.Forms.Padding(1);
            this.playerBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.playerBar.Name = "playerBar";
            this.playerBar.Progress = ((long)(0));
            this.playerBar.RangeMax = 10000;
            this.playerBar.ShowText = false;
            this.playerBar.ShowValue = false;
            this.playerBar.Size = new System.Drawing.Size(261, 41);
            this.playerBar.TabIndex = 10;
            this.playerBar.Text = "";
            this.playerBar.Value = 0;
            this.playerBar.onValueChanged += new SForm.MaterialSlider.ValueChanged(this.playerBar_onValueChanged);
            // 
            // repeatBtn
            // 
            this.repeatBtn.AutoSize = false;
            this.repeatBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.repeatBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.repeatBtn.Depth = 0;
            this.repeatBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repeatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatBtn.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.repeatBtn.HighEmphasis = true;
            this.repeatBtn.Icon = global::SPlayer.Properties.Resources.replay_line;
            this.repeatBtn.Location = new System.Drawing.Point(473, 0);
            this.repeatBtn.Margin = new System.Windows.Forms.Padding(0);
            this.repeatBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.repeatBtn.Name = "repeatBtn";
            this.repeatBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.repeatBtn.Size = new System.Drawing.Size(42, 43);
            this.repeatBtn.TabIndex = 11;
            this.repeatBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.repeatBtn.UseAccentColor = false;
            this.repeatBtn.UseVisualStyleBackColor = true;
            this.repeatBtn.Click += new System.EventHandler(this.repeatBtn_Click);
            // 
            // toggleSubBtn
            // 
            this.toggleSubBtn.AutoSize = false;
            this.toggleSubBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toggleSubBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.toggleSubBtn.Depth = 0;
            this.toggleSubBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toggleSubBtn.HighEmphasis = true;
            this.toggleSubBtn.Icon = global::SPlayer.Properties.Resources.subtitles;
            this.toggleSubBtn.Location = new System.Drawing.Point(515, 0);
            this.toggleSubBtn.Margin = new System.Windows.Forms.Padding(0);
            this.toggleSubBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.toggleSubBtn.Name = "toggleSubBtn";
            this.toggleSubBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.toggleSubBtn.Size = new System.Drawing.Size(42, 43);
            this.toggleSubBtn.TabIndex = 12;
            this.toggleSubBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.toggleSubBtn.UseAccentColor = false;
            this.toggleSubBtn.UseVisualStyleBackColor = true;
            this.toggleSubBtn.Click += new System.EventHandler(this.toggleSubBtn_Click);
            // 
            // menuBtn
            // 
            this.menuBtn.AutoSize = false;
            this.menuBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menuBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.menuBtn.Depth = 0;
            this.menuBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBtn.HighEmphasis = true;
            this.menuBtn.Icon = global::SPlayer.Properties.Resources.download;
            this.menuBtn.Location = new System.Drawing.Point(557, 0);
            this.menuBtn.Margin = new System.Windows.Forms.Padding(0);
            this.menuBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.menuBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuBtn.Size = new System.Drawing.Size(42, 43);
            this.menuBtn.TabIndex = 13;
            this.menuBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.menuBtn.UseAccentColor = false;
            this.menuBtn.UseVisualStyleBackColor = true;
            this.menuBtn.Click += new System.EventHandler(this.menuBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(605, 492);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.footerPanel);
            this.DrawerShowIconsWhenHidden = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "SPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).EndInit();
            this.bodyPanel.Panel1.ResumeLayout(false);
            this.bodyPanel.Panel1.PerformLayout();
            this.bodyPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bodyPanel)).EndInit();
            this.bodyPanel.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private System.Windows.Forms.SplitContainer bodyPanel;
        private ImageList imageList1;
        private SListBox subtitleBox;
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
        private OpenFileDialog openFileDialog1;
        private Label subtitleLabel;
    }
}

