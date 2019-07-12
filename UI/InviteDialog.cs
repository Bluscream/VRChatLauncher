using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRChatApi.Classes;
using VRChatLauncher.Utils;

namespace VRChatLauncher.UI
{
    public partial class InviteDialog : Form
    {
        public class InviteDialogResult
        {
            public DialogResult DialogResult;
            public bool Continue;
            public string WorldId;
            public string WorldName;
        }

        public InviteDialogResult Result = new InviteDialogResult();

        public static InviteDialogResult Get(string title = "", List<World> worlds = null)
        {
            var mi = new InviteDialog(title, worlds);
            var diag = mi.ShowDialog();
            /*InviteDialogResult Result = new InviteDialogResult();
            Result.DialogResult = diag;
            Result.Continue = (diag == DialogResult.OK);
            Result.WorldName = mi.txt_name.Text;
            Result.WorldId = mi.box_id.Text;*/
            return mi.Result;
        }

        public List<World> Worlds;

        public class World
        {
            public string Name;
            public string Id;
            public World(string id, string name = "") {
                Id = id;
                if (!string.IsNullOrEmpty(name)) { Name = name.Trim(); }
            }
            public World fromWorldResponse(WorldBriefResponse worldResponse) {
                return new World(worldResponse.id, worldResponse.name);
            }
            public override string ToString() {
                return Name;
            }
        }

        public InviteDialog(string title, List<World> worlds)
        {
            InitializeComponent();
            Text = title;
            Worlds = worlds;
            foreach (var world in worlds) {
                box_id.Items.Add(world);
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
        }

        private void accepted()
        {
            DialogResult = DialogResult.OK;
            Result.DialogResult = DialogResult;
            Result.Continue = true;
            Result.WorldId = txt_name.Text;
            Result.WorldName = box_id.Text;
            Close();
        }

        private void Btn_send_Click(object sender, EventArgs e)
        {
            accepted();
        }

        private bool BoxChanged = false;
        private void Box_id_SelectionChangeCommitted(object sender, EventArgs e) {
            BoxChanged = true;
        }

        private void Box_id_TextChanged(object sender, EventArgs e)
        {
            if (BoxChanged)
            {
                BoxChanged = false;
                var curtext = box_id.Text;
                Logger.Warn(2, curtext);
                var world = Worlds.Find(w => w.Name == curtext);
                Logger.Warn(3, world);
                if (world != null)
                {
                    Logger.Warn("id:", world.Id, "name:", world.Name);
                    Logger.Warn("box_id:", box_id.Text, "txt_name:", txt_name.Text);
                    txt_name.Text = world.Id;
                    Logger.Warn("box_id:", box_id.Text, "txt_name:", txt_name.Text);
                }
            }
        }
    }
}
