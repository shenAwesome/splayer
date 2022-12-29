using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var form = new Form1();
            if (args.Length == 1) {
                var Settings = Properties.Settings.Default;
                Settings.MediaPath = args[0];
                Settings.MediaProgress = 0;
            }
            Application.Run(form);
        }
    }
}
