using MaterialSkin.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace SForm {

    [Designer(typeof(ControlDesigner))]
    public class SForm : MaterialForm {

        public SForm() {
            this.FormStyle = FormStyles.ActionBar_None;
            this.FormBorderStyle = FormBorderStyle.None;
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
