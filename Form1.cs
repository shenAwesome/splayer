using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPlayer {
    public partial class Form1 : Form {

        LibVLC LibVLC = new LibVLC();

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            var player = new MediaPlayer(LibVLC);
            videoView1.MediaPlayer = player;
            var file = @"D:\downloads\communication.mp4";
            var media = new Media(LibVLC, new Uri(file));
            player.Play(media);
            media.Dispose();
        }


        private async Task run() {

        }

        private void button3_Click(object sender, EventArgs e) {
            run();
        }
    }
}
