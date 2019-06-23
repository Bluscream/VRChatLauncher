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
    public partial class CommandLineArguments : Form
    {
        public CommandLineArguments(string gamePath, string[] arguments)
        {
            InitializeComponent();
            txt_launch_path.Text = gamePath;
            FillList(arguments);
        }

        private void FillList(string[] args) {
            lst_arguments.Items.Clear();
            foreach (var arg in args) {
                lst_arguments.Items.Add(arg);
            }
        }

        private void Lst_arguments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
