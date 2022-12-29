using MaterialSkin;
using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static MaterialSkin.MaterialSkinManager;

namespace SForm {

    class STheme {
        public string Name;
        public Themes Theme;
        public ColorScheme ColorScheme;
    }

    public class SForm : MaterialForm {

        public SForm() {
            FormStyle = FormStyles.ActionBar_None;
            FormBorderStyle = FormBorderStyle.None;

            CreateTheme("green", "1b5e20", "4c8c4a", "003300", "FFD700");
            CreateTheme("blue", "0d47a1", "5472d3", "002171", "FFD700");
            CreateTheme("gray", "6d6d6d", "1b1b1b", "000000", "FFD700");
        }

        protected void ApplyTheme() {
            var skinManager = Instance;
            skinManager.AddFormToManage(this);

            var theme = themes[themes.Count - 1];
            skinManager.Theme = theme.Theme;
            skinManager.ColorScheme = theme.ColorScheme;
        }

        private List<STheme> themes = new List<STheme>();

        protected void CreateTheme(string name, string primary, string pLight, string pDark,
                 string accent) {
            var theme = IsDark(ToColor(primary)) ? Themes.DARK : Themes.LIGHT;
            var textShade = IsDark(ToColor(primary)) ? TextShade.WHITE : TextShade.BLACK;
            var colorScheme = new ColorScheme(
                    ToColor(primary), ToColor(pDark), ToColor(pLight),
                    ToColor(accent), textShade
            );

            themes.Add(new STheme() {
                Name = name,
                Theme = theme,
                ColorScheme = colorScheme
            });
        }

        private ColorConverter colorConverter = new ColorConverter();
        private Color ToColor(string colorHex) {
            if (!colorHex.StartsWith("#")) colorHex = "#" + colorHex;
            return (Color)colorConverter.ConvertFromString(colorHex);
        }

        private bool IsDark(Color col) {
            bool isDark = false;
            if (col.R * 0.2126 + col.G * 0.7152 + col.B * 0.0722 < 255 / 2) {
                isDark = true;
            }
            return isDark;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            var g = e.Graphics;
            var drawFont = SkinManager.getFontByType(MaterialSkin.MaterialSkinManager.fontType.Caption);
            var drawBrush = new SolidBrush(SkinManager.ColorScheme.TextColor);
            g.DrawString(Text, drawFont, drawBrush, 5, 5);
        }
    }
}
