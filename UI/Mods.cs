using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static VRChatLauncher.Utils.Mods;

namespace VRChatLauncher
{
    partial class Main
    {
        public static List<Mod> mods;

        public void SetupMods(bool force = false)
        {
            if (!force && !Setup.Mods.IsModLoaderInstalled())
            {
                var confirmResult = MessageBox.Show("No modloader was found so we will warn you that everything you do beyond this message can lead to bans.\n\nUse mods responsibly!", "No Modloader installed", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (confirmResult != DialogResult.OK) { tabs_main.SelectTab(0); return; }
            }
            if (mods == null || force) {
                mods = GetMods();
                mods.OrderBy(x => x.Name);
                CheckForUpdates(mods);
                if (Setup.Mods.IsVRCModLoaderInstalled()) {
                    Mod VRCModLoader = Updater.VRCModLoader.CheckForUpdate();
                    if (VRCModLoader.Update != null) MessageBox.Show("Update available for VRCModLoader");
                }
            }
                
            lst_mods.Clear();
            foreach (var mod in mods)
            {
                var broken = string.IsNullOrEmpty(mod.Version);
                var item = new ListViewItem();
                item.Tag = mod;
                if(!mod.Enabled) item.BackColor = Color.Gray;
                if (broken) {
                    item.Text = mod.FileNameWithoutExtension;
                    item.ForeColor = Color.Red;
                } else {
                    item.Text = mod.Name;
                    item.ToolTipText = mod.FileNameWithoutExtension;
                }
                lst_mods.Items.Add(item);
            }

        }

        int lastModIndex = 0;
        private void on_list_mods_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lastModIndex == e.ItemIndex) return;
            lastModIndex = e.ItemIndex;
            Mod mod = (Mod)e.Item.Tag;
            txt_mod_path.Text = mod.File.FullName;
            txt_mod_name.Text = mod.Name;
            txt_mod_version.Text = mod.Version;
            txt_mod_author.Text = mod.Author;
            txt_mod_type.Text = mod.Type.ToString();
            txt_mod_description.Text = mod.Description;
        }

        private void on_btn_mods_refresh_Click(object sender, EventArgs e) {
            SetupMods(force: true);
        }
    }
}
