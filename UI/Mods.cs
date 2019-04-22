using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VRChatLauncher.Utils;
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
                // ImageList imageList = new ImageList();
                // imageList.Images.Add(Properties.Resources.vrctoolspng);
                switch (mod.Type)
                {
                    case ModLoaderType.Unknown:
                        break;
                    case ModLoaderType.VRCModloader:
                        item.ImageIndex = 0;break;
                    case ModLoaderType.VRLoader:
                        break;
                    default:
                        break;
                }
                if (broken) {
                    item.Text = mod.File.FileNameWithoutExtension();
                    item.ForeColor = Color.Red;
                } else {
                    item.Text = mod.Name;
                    item.ToolTipText = mod.File.FileNameWithoutExtension();
                }
                if(!mod.Enabled) item.ForeColor = Color.Gray;
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

        private void Menu_mod_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mod = (Mod)lst_mods.SelectedItems[0].Tag;
            if (mod == null) return;
            menu_mod.Items[0].Text = mod.Enabled ? "Disable" : "Enable";
        }

        private void ToggleModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mod = (Mod)lst_mods.SelectedItems[0].Tag;
            if (mod == null) return;
            Logger.Debug(mod.ToJson());
            if (mod.Enabled)
            {
                var confirmResult = MessageBox.Show($"Mod {mod.Name} will be moved to the Mods/Disabled/ folder, Are you sure?", "Disable mod?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.OK) { return; }
                mod = DisableMod(mod);
                if (mod.Enabled) MessageBox.Show($"Failed to disable mod {mod.Name}, check logs/console!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                mod = EnableMod(mod);
                if (!mod.Enabled) MessageBox.Show($"Failed to enable mod {mod.Name}, check logs/console!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetupMods(true);
        }

        private void DeleteModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mod = (Mod)lst_mods.SelectedItems[0].Tag;
            if (mod == null) return;
            var confirmResult = MessageBox.Show($"Mod {mod.Name} will be deleted, Are you sure?", "Disable mod?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (confirmResult != DialogResult.OK) { return; }
            mod.File.Delete();
        }

        private void DecompileModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mod = (Mod)lst_mods.SelectedItems[0].Tag;
            if (mod == null) return;
            MessageBox.Show($"Not implemented", "tupper is gay", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
