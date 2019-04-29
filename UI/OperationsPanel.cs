using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class OperationsPanel : MaterialForm
    {
        MaterialSkinManager skinManager;
        bool running = false;
        public OperationsPanel()
        {
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Btn_startstop_Click(object sender, EventArgs e)
        {
            if (!running) {
                grp_settings.Visible = false;
                progress_operation.Value = 100;
                btn_startstop.Text = "Stop";
            } else {
                grp_settings.Visible = true;
                progress_operation.Value = 0;
                btn_startstop.Text = "Start";
            }
            running = !running;
        }
    }
}
