using System;
using System.Windows.Forms;

namespace SPlayer {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 1) {
                var Settings = Properties.Settings.Default;
                Settings.MediaPath = args[0];
                Settings.MediaProgress = 0;
            }
            Application.Run(new Form1());
        }
    }
}
