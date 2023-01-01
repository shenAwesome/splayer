using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static MaterialSkin.MaterialSkinManager;

namespace SForm {

    public class SForm : MaterialForm {

        static readonly int WM_LBUTTONDOWN = 0x201;

        static readonly int WM_PARENTNOTIFY = 0x210;

        static readonly int WM_RBUTTONDOWN = 0x204;

        private ColorConverter colorConverter = new ColorConverter();

        private long lastMouseDown = 0;

        private List<STheme> themes = new List<STheme>();

        public SForm() {
            FormStyle = FormStyles.ActionBar_None;
            FormBorderStyle = FormBorderStyle.None;

            CreateTheme("blue", "0d47a1", "FFD700");
            CreateTheme("cyan", "80deea", "FFD700");
            CreateTheme("pink", "d81b60", "FFD700");
            CreateTheme("purple", "4a148c", "FFD700");
            CreateTheme("gray", "6d6d6d", "FFD700");
        }

        protected bool IsUserActing {
            get {
                return Now - lastMouseDown < 1000;
            }
        }

        /// <summary>
        ///  Now in millionsec
        /// </summary>
        protected long Now {
            get {
                return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }
        }

        protected void ApplyTheme(int index) {
            var skinManager = Instance;
            skinManager.AddFormToManage(this);
            var theme = themes[index];
            skinManager.Theme = theme.Theme;
            skinManager.ColorScheme = theme.ColorScheme;
        }

        protected void ApplyTheme() {
            ApplyTheme(themes.Count - 1);
        }

        protected void CreateTheme(string name, string primary, string accent) {
            var p = ToColor(primary);
            CreateTheme(name, p, p.Lighten(.2f), p.Darken(.2f), ToColor(accent));
        }

        protected void CreateTheme(string name, Color primary, Color pLight, Color pDark,
                 Color accent) {
            var theme = IsDark(primary) ? Themes.DARK : Themes.LIGHT;
            var textShade = IsDark(primary) ? TextShade.WHITE : TextShade.BLACK;
            themes.Add(new STheme() {
                Name = name, Theme = theme,
                ColorScheme = new ColorScheme(
                  primary, pDark, pLight,
                   accent, textShade
                )
            });
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            var g = e.Graphics;
            var drawFont = SkinManager.getFontByType(MaterialSkin.MaterialSkinManager.fontType.Caption);
            var drawBrush = new SolidBrush(SkinManager.ColorScheme.TextColor);
            g.DrawString(Text, drawFont, drawBrush, 5, 5);
        }

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

        private bool IsDark(Color col) {
            bool isDark = false;
            if (col.R * 0.2126 + col.G * 0.7152 + col.B * 0.0722 < 255 / 2) {
                isDark = true;
            }
            return isDark;
        }

        private Color ToColor(string colorHex) {
            if (!colorHex.StartsWith("#")) colorHex = "#" + colorHex;
            return (Color)colorConverter.ConvertFromString(colorHex);
        }
    }

    class STheme {
        public ColorScheme ColorScheme;
        public string Name;
        public Themes Theme;
    }
}
