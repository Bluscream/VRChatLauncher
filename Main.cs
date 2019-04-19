using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRChatLauncher.Utils;
using static VRChatLauncher.Utils.Mods;

namespace VRChatLauncher
{
        public partial class Main : Form
    {
        public static string[] args = new string[] { };
        public static List<Mod> mods;
        public static ListView selflog; public static ListView gamelog;
        public LogReader logReader;
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
            selflog = lst_log_launcher; gamelog = lst_log_game;
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
                if (confirmResult == DialogResult.Cancel) tabs_main.SelectTab(0); return;
            }
            if (mods == null)
                mods = GetMods();
            lst_mods.Clear();
            foreach (var mod in mods)
            {
                var broken = string.IsNullOrEmpty(mod.Name);
                var item = new ListViewItem();
                item.Tag = mod;
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

        public void WriteGameLog(string message) {
            if (string.IsNullOrWhiteSpace(message)) return;
            if (lst_log_game.Items.Count > 500) lst_log_game.Items.RemoveAt(0);
            lst_log_game.Items.Add(message);
        }

        public void WriteLauncherLog(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            if (lst_log_launcher.Items.Count > 200) lst_log_launcher.Items.RemoveAt(0);
            lst_log_launcher.Items.Add(message);
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
                case "tab_log_game":
                    if (logReader == null) {
                        logReader = new LogReader();
                        logReader.Init();
                        lst_log_game.Items.Add("Initialized Log Watcher");
                    }
                    break;
                default:
                    break;
            }
        }
        int lastModIndex = 0;
        private void on_mod_selected(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lastModIndex == e.ItemIndex) return;
            lastModIndex = e.ItemIndex;
            Logger.Warn(e.Item.Text);
            Mod mod = (Mod)e.Item.Tag;
            txt_mod_path.Text = mod.File.FullName;
            txt_mod_name.Text = mod.Name;
            txt_mod_version.Text = mod.Version;
            txt_mod_author.Text = mod.Author;
            txt_mod_type.Text = mod.Type.ToString();
            txt_mod_description.Text = mod.Description;
        }

        private void mainForm_loaded(object sender, EventArgs e)
        {
            columnHeader1.Width = -1;
            columnHeader2.Width = -1;
            // Task.Run(() => LogReader.ReadLogs());
        }
    }
}
