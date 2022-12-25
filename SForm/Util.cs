using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SForm {

    public class Util {
        public static void SetField(object obj, string propertyName, object value) {
            var fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic
                );

            foreach (var f in fields) {
                Debug.WriteLine(f.Name);
            }

            var prop = obj.GetType().GetField(propertyName, BindingFlags.NonPublic
                | BindingFlags.Instance);
            prop.SetValue(obj, value);
        }

        public static T GetField<T>(object obj, string propertyName) {
            return (T)obj.GetType()
                          .GetField(propertyName, BindingFlags.Instance | BindingFlags.NonPublic)
                          .GetValue(obj);
        }
    }
}
