using Newtonsoft.Json;
using System;
using System.Timers;
using System.Windows.Forms;

namespace SForm {


    public class State {
        readonly System.Timers.Timer timer;
        private Control host;
        private Action onStageChanged;

        public State() {
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 100;
            timer.Enabled = true;
        }

        public void Setup(Control host, Action onStageChanged) {
            this.host = host;
            this.onStageChanged = onStageChanged;
        }

        ~State() {
            timer.Enabled = false;
        }

        private string _lastJSON = "";
        private void OnTimedEvent(object source, ElapsedEventArgs e) {
            if (host != null) {
                var newJSON = ToJSON();
                if (newJSON != _lastJSON) {
                    host.Invoke(new MethodInvoker(delegate () {
                        onStageChanged?.Invoke();
                    }));
                    _lastJSON = newJSON;
                }
            }
        }

        public string ToJSON() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
