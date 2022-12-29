using MaterialSkin.Controls;
using SForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test {


    public partial class Form1 : MaterialForm {
        MyState state;

        public Form1() {
            InitializeComponent();
            state = new MyState();
            state.Setup(this, Render);
        }

        public void Render() {
            label1.Text = state.Name;
        }

        private void Test_OnChange(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e) {


        }

        private void materialButton1_Click(object sender, EventArgs e) {
            state.Name = DateTime.Now.ToString();
        }
    }

    class MyState : State {
        public string Name;
    }

}
