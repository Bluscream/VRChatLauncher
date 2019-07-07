using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            mods = mods.OrderBy(o=>o.Name).ToList();
            foreach (var mod in mods)
            {
                var item = new ListViewItem();
                item.Tag = mod;
                // ImageList imageList = new ImageList();
                // imageList.Images.Add(Properties.Resources.vrctoolspng);
                switch (mod.Type)
                {
                    case ModLoaderType.VRCModloader:
                        item.Text = mod.Name;
                        item.ToolTipText = mod.File.FileNameWithoutExtension();
                        item.ImageIndex = 0;break;
                    case ModLoaderType.VRLoader:
                        item.Text = mod.Name;
                        item.ToolTipText = mod.File.FileNameWithoutExtension();
                        break;
                    case ModLoaderType.Unknown:
                    default:
                        item.Text = mod.File.FileNameWithoutExtension();
                        item.ForeColor = Color.Red;
                        break;
                }
                if(!mod.Enabled) item.ForeColor = Color.Gray;
                lst_mods.Items.Add(item);
            }
            tabs_mods.TabPages[0].Text = $"Installed ({mods.Count})";
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
            if (mod.Error != null) txt_mod_type.Text += $" ({mod.Error})";
            txt_mod_description.Text = mod.Description;
        }

        private void on_btn_mods_refresh_Click(object sender, EventArgs e) {
            SetupMods(force: true);
        }

        private void Menu_mod_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (lst_mods.SelectedItems.Count < 1) { e.Cancel = true; return; }
            var mod = (Mod)lst_mods.SelectedItems[0].Tag;
            if (mod == null) { e.Cancel = true; return; }
            menu_mod.Items[1].Text = mod.Enabled ? "Disable" : "Enable";
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
            SetupMods(true);
        }

        private void DecompileModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mod = (Mod)lst_mods.SelectedItems[0].Tag;
            if (mod == null) return;
            FileInfo file;
            if (string.IsNullOrEmpty(config["Paths"]["Decompiler"]))
            {
                var confirmResult = MessageBox.Show("You don't have set up a decompiler yet, you can select one like dnSpy or ILSpy that supports \"compiler.exe %file%\" if you click on OK", "Decompiler not found!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Cancel) return;
                var fileSelector = new OpenFileDialog();
                fileSelector.Title = "Select the decompiler to use";
                fileSelector.Filter = "dnSpy|dnSpy.exe|ILSpy|ILSpy.exe|All Executables|*.exe";
                if (fileSelector.ShowDialog() == DialogResult.OK)
                {
                    file = new FileInfo(fileSelector.FileName);
                    config["Paths"]["Decompiler"] = file.FullName;
                    Config.Save(config);
                }
            }
            file = new FileInfo(config["Paths"]["Decompiler"]);
            Utils.Utils.StartProcess(file, mod.File.FullName.Quote());
        }

        private void OpenFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mod = (Mod)lst_mods.SelectedItems[0].Tag;
            if (mod == null) return;
            Utils.Utils.ShowFileInExplorer(mod.File);
        }
    }
}
