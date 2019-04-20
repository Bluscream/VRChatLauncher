using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRChatLauncher.Setup.VRCAPI
{
    public partial class LoginModal : Form
    {
        public LoginModal()
        {
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            // Login(txt_username.Text, txt_password.Text);
            this.Close();
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
