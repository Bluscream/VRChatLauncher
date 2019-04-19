using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRChatLauncher.Utils;

namespace VRChatLauncher
{
    public partial class Main : Form
    {
        public static string[] args = new string[] { };
        public Main(string[] arguments)
        {
            Logger.Trace("START");
            InitializeComponent();
            // var args = Program.args.Skip(1).ToArray();
            args = arguments;
            var gameInSameDir = Setup.Game.CheckForGame();
            if (!gameInSameDir) SetupGame();
            Setup.URIResponse regKeyCorrect = Setup.URI.CheckURIRegistryKey();
            Logger.Trace("match=", regKeyCorrect.match.ToString());
            if(regKeyCorrect.match != Setup.URIResponse.URIEnum.INSTALLED) SetupURI(regKeyCorrect.expected, regKeyCorrect.key);
            // richTextBox1.Text = "match: "+ regKeyCorrect.match.ToString() + "\n\nexpected: " + regKeyCorrect.expected + "\n\nkey: " + regKeyCorrect.key + "\n\n";
            Logger.Trace("END");
        }

        public void SetupURI(string newVal, string oldVal)
        {
            Logger.Warn("URI Protocol not installed, installation required!", Environment.NewLine, newVal);
            var confirmResult = MessageBox.Show($"We detected that the vrchat:// protocol is not ready for use with this launcher.\n\nHowever it is required to be modified in order to have this launcher catch vrchat:// URLs\n\nKey:\n{Setup.URI.key}\n\nOld Value:\n{oldVal}\n\nNew Value:\n{newVal}\n\nPress OK to install it now!", "URI not installed!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Cancel) return;
            bool success = Setup.URI.InstallURI(newVal);
            if (!success) {
                confirmResult = MessageBox.Show("Failed to install vrchat:// protocol handler. Do you want to restart the launcher as Admin to fix this?", "Error while installing URI protocol handler", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (confirmResult) {
                    case DialogResult.Cancel:
                        Application.Exit(); break;
                    case DialogResult.Yes:
                        Utils.Utils.RestartAsAdmin(); break;
                    default:
                        break;
                }
            }
        }

        public void SetupGame()
        {
            Logger.Warn("Game not found, setup required!");
            var confirmResult = MessageBox.Show("VRChat.exe was not found in the same directory as this launcher.\n\nHowever it needs to be in the same folder to work properly, please select your game to move this launcher next to it and restart.", "Game not found!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Cancel) Application.Exit();
            var gameSelector = new OpenFileDialog();
            gameSelector.Title = "Select the VRChat.exe file";
            gameSelector.InitialDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\VRChat";
            gameSelector.Filter = "VRChat Executable|VRChat.exe|All Executables|*.exe";
            if (gameSelector.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = gameSelector.FileName;
                System.IO.FileInfo File = new System.IO.FileInfo(gameSelector.FileName);
            }
            // ADD LOGIC
        }

        public void SetupMods()
        {
            if (!Setup.Mods.IsModLoaderInstalled())
            {
                var confirmResult = MessageBox.Show("No modloader was found so we will warn you that everything you do beyond this message can lead to bans.\n\nUse mods responsibly!", "No Modloader installed", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (confirmResult == DialogResult.Cancel) tabControl1.SelectTab(0); return;
            }
            var mods = Utils.Mods.GetMods();
            foreach (var mod in mods)
            {
                var broken = string.IsNullOrEmpty(mod.Name);
                var item = new ListViewItem();
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

        private void btn_play_Click(object sender, EventArgs e)
        {
            Game.StartGame(args: args);
        }

        private void tab_changed(object sender, TabControlEventArgs e)
        {
            // Logger.Debug(sender.ToString());
            // Logger.Debug(e.ToString());
            Logger.Debug(e.Action.ToString(), e.TabPage.Name, e.TabPageIndex.ToString());
            switch (e.TabPage.Name)
            {
                case "tab_mods":
                    SetupMods(); break;
                default:
                    break;
            }
        }
    }
}
