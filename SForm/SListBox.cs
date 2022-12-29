using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SForm {
    public class SListBox : MaterialListBox {

        public void ScrollToSelection() {
            var start = _itemHeight * SelectedIndex;
            var offset = (Height - _itemHeight) / 2;
            _scrollBar.Value = Math.Max(0, start - offset);
        }

        public bool IsHovered {
            get {
                return _hoveredItem != -1;
            }
        }
    }
}