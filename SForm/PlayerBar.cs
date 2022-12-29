using System;
using System.Windows.Forms;

namespace SForm {


    public class PlayerBar : MaterialSlider {

        long _duration;

        public long Duration {
            get {
                return _duration;
            }
            set {
                _duration = value;
                Progress = Progress;
            }
        }

        public long Progress {
            get {
                return Duration * Value / RangeMax;
            }
            set {
                if (Duration > 0) {
                    Value = (int)(RangeMax * value / Duration);
                } else {
                    Value = 0;
                }
                CalculateText();
            }
        }

        public PlayerBar() {
            this.RangeMin = 0;
            this.RangeMax = 10000;
            this.Value = 0;
            this.ShowText = false;
            this.ShowValue = false;
            this.onValueChanged += PlayerBar_onValueChanged;

            this._thumbRadius = 10;
            this._thumbRadiusHoverPressed = 30;
            this._activeTrack = 4;
        }

        private void PlayerBar_onValueChanged(object sender, int newValue) {
            if (Duration == 0) Value = 0;
        }

        private void CalculateText() {
            if (Duration > 0) {
                Text = Format(Progress) + '/' + Format(Duration);
            } else {
                Text = "";
            }
        }

        static string Format(long seconds) {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"hh\:mm\:ss");
        }
    }
}
