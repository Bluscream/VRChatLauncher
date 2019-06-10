using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRChatLauncher.UI
{
    public partial class MultilineInput : Form
    {
        private string Value;

        public static string Get(string title = "", string placeholder = "")
        {
            var mi = new MultilineInput(title, placeholder);
            if (mi.ShowDialog() == DialogResult.OK)
                return mi.Value;
            return null;
        }

        public MultilineInput(string title, string placeholder)
        {
            InitializeComponent();
            Text = title;
            txt_input.Text = placeholder;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            accepted();
        }

        private void accepted()
        {
            DialogResult = DialogResult.OK;
            Value = txt_input.Text;
            Close();
        }

        private bool keydowncalled = false;
        private void Txt_input_KeyDown(object sender, KeyEventArgs e)
        {
            keydowncalled = false;
            if (e.KeyData == (Keys.Control | Keys.Enter))
            {
                keydowncalled = true;
            }
        }

        private void Txt_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (keydowncalled == true)
            {
                keydowncalled = false;
                e.Handled = true;
                accepted();
            }
        }
    }
}
