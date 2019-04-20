﻿using System;
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
using IniParser;
using IniParser.Model;
using VRChatApi;
using VRChatApi.Classes;
using System.IO;

namespace VRChatLauncher
{
        public partial class Main : Form
    {
        public static string[] args = new string[] { };
        public static List<Mod> mods;
        public static List<AvatarResponse> favorite_avatars;public static List<AvatarResponse> personal_avatars;public static List<UserBriefResponse> friends;
        public static List<UserResponse> blocked;public static List<UserResponse> user_requests;public static UserResponse me;
        public static ListView selflog; public static ListView gamelog;
        public LogReader logReader;public bool settingsInitialized = false;
        public IniData config;public VRChatApi.VRChatApi vrcapi;

        public Main(string[] arguments)
        {
            Logger.Trace("START");
            config = Config.Load();
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

        public void SetupMods(bool force = false)
        {
            if (!force && !Setup.Mods.IsModLoaderInstalled())
            {
                var confirmResult = MessageBox.Show("No modloader was found so we will warn you that everything you do beyond this message can lead to bans.\n\nUse mods responsibly!", "No Modloader installed", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (confirmResult != DialogResult.OK) { tabs_main.SelectTab(0); return; }
            }
            if (mods == null || force) {
                mods = GetMods();
                CheckForUpdates(mods);
                if (Setup.Mods.IsVRCModLoaderInstalled()) {
                    Mod VRCModLoader = Updater.VRCModLoader.CheckForUpdate();
                    if (VRCModLoader.Update != null) MessageBox.Show("Update available for VRCModLoader");
                }
            }
                
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

        public void SetupSettings() {
            flow_settings.Controls.Clear();
            foreach (var section in config.Sections)
            {
                var group = new GroupBox();
                group.Text = section.SectionName;
                group.AutoSizeMode = AutoSizeMode.GrowOnly;
                var table = new TableLayoutPanel();
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.00000F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.00000F));
                table.Dock = DockStyle.Fill;
                // table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
                table.AutoSize = true;
                table.ColumnCount = section.Keys.Count;
                group.Controls.Add(table);
                var i = 0;
                foreach (var setting in section.Keys)
                {
                    var label = new Label();
                    label.Text = setting.KeyName + ":";
                    label.AutoSize = true;
                    label.Anchor = (AnchorStyles.Left);
                    label.Dock = DockStyle.Fill;
                    label.TabIndex = 0;
                    table.Controls.Add(label, 0, i);
                    var txt = new TextBox();
                    txt.Text = setting.Value;
                    txt.AutoSize = true;
                    txt.Anchor = (AnchorStyles.Right | AnchorStyles.Left);
                    txt.Dock = DockStyle.Fill;
                    // txt.Anchor = AnchorStyles.Right; 
                    txt.TabIndex = 1;
                    table.Controls.Add(txt, 1, i);
                    i++;
                }
                flow_settings.Controls.Add(group);
                // group.AutoSize = true;
            }
        }
        public async Task<bool> VRCAPILogin(string username, string password)
        {
            Logger.Log("Trying to log in as", username, "...");
            vrcapi = new VRChatApi.VRChatApi(username, password);
            me = await vrcapi.UserApi.Login();
            if (me == null) {
                var confirmResult = MessageBox.Show($"Something went wrong while logging you in as {username}\n\nRetry?", "Failed to log in!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (confirmResult == DialogResult.Retry) return await VRCAPILogin(username, password);
                tabs_main.SelectTab(0); return false;
            }
            Logger.Log("Logged in as", me.username);
            return true;
        }
        public async void SetupVRCApiAsync() {
            var confirmResult = MessageBox.Show("You are not logged in to VRChat.\n\nIn order to use this tab you need to log in through your VRChat account.\n\nDo you want to log in?", "Not logged in!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult != DialogResult.Yes) { tabs_main.SelectTab(0); return; }
            var loginModal = new Setup.VRCAPI.LoginModal();
            loginModal.ShowDialog();
            var username = loginModal.txt_username.Text;var password = loginModal.txt_password.Text;
            // VRChatApi.Logging.LogProvider.SetCurrentLogProvider(new ColoredConsoleLogProvider());
            // ConfigResponse config = await vrcapi.RemoteConfig.Get();
            var logged_in = await VRCAPILogin(username, password);
            if (!logged_in) return;
            config["VRCAPI"]["u"] = Utils.Utils.Base64Encode(username);
            config["VRCAPI"]["p"] = Utils.Utils.Base64Encode(password);
            Config.Save(config);
        }

        private Color ColorFromReleaseStatus(string releaseStatus)
        {
            switch (releaseStatus)
            {
                case "private":
                    return Color.Red;
                case "hidden":
                    return Color.Gray;
                case "public":
                    return Color.Green;
                default:
                    return Color.Orange;
            }
        }

        public async void SetupAvatarsAsync(bool force = false) {
            tree_avatars.Nodes[0].Nodes.Clear();
            tree_avatars.Nodes[1].Nodes.Clear();
            tree_avatars.Nodes[2].Nodes.Clear();
            if (personal_avatars == null || force) {
                if (Utils.Utils.getRipper().Exists) btn_avatar_rip.Visible = true;
                personal_avatars = await vrcapi.AvatarApi.Personal();
                Logger.Debug("Downloaded list of", personal_avatars.Count, "official personal avatars");
            }
            foreach (var avatar in personal_avatars)
            {
                var node = new TreeNode(avatar.name);
                node.Tag = avatar;
                node.ForeColor = ColorFromReleaseStatus(avatar.releaseStatus);
                tree_avatars.Nodes[0].Nodes.Add(node);
            }
            tree_avatars.Nodes[0].Text = $"Personal ({tree_avatars.Nodes[0].Nodes.Count})";

            if (favorite_avatars == null || force) {
                favorite_avatars = await vrcapi.AvatarApi.Favorites();
                Logger.Debug("Downloaded list of", favorite_avatars.Count, "official favorite avatars");
            }
            foreach (var avatar in favorite_avatars)
            {
                var node = new TreeNode(avatar.name);
                node.Tag = avatar;
                node.ForeColor = ColorFromReleaseStatus(avatar.releaseStatus);
                tree_avatars.Nodes[1].Nodes.Add(node);
            }
            tree_avatars.Nodes[1].Text = $"Official ({tree_avatars.Nodes[0].Nodes.Count} / 16)";
        }

        public async void SetupUsersAsync(bool force = false) {
            Logger.Trace("called");
            var onlinenode = tree_users.Nodes[1].Nodes[0];
            var offlinenode = tree_users.Nodes[1].Nodes[1];
            onlinenode.Nodes.Clear();
            offlinenode.Nodes.Clear();
            tree_users.Nodes[2].Nodes.Clear();
            tree_users.Nodes[3].Nodes.Clear();
            if (me != null)  {
                Logger.Warn(me.displayName);
                if (force) me = await vrcapi.UserApi.UpdateInfo(me.id);
                tree_users.Nodes[0].Text = me.displayName;
                tree_users.Nodes[0].Tag = me;
            }
            if (friends == null || force) {
                friends = new List<UserBriefResponse>();
                var offset = 0;
                for (int i = 0; i < 10; i++)
                {
                    var friends_part = await vrcapi.FriendsApi.Get(offset, 100, true);
                    friends.AddRange(friends_part);
                    if (friends_part.Count < 100) break;
                    offset += 100;
                } 
                Logger.Debug("Downloaded list of", friends.Count, "official friends");
            }
            foreach (var friend in friends)
            {
                var node = new TreeNode(friend.displayName);
                node.Tag = friend;
                // node.ForeColor = ColorFromReleaseStatus(avatar.releaseStatus);
                if (friend.location == "offline")
                    tree_users.Nodes[1].Nodes[1].Nodes.Add(node);
                else tree_users.Nodes[1].Nodes[0].Nodes.Add(node);
            }
            tree_users.Nodes[1].Text = $"Friends ({onlinenode.Nodes.Count + offlinenode.Nodes.Count})";
            onlinenode.Text = $"Online ({onlinenode.Nodes.Count})";
            offlinenode.Text = $"Offline ({offlinenode.Nodes.Count})";
            return;
            if (favorite_avatars == null || force) {
                favorite_avatars = await vrcapi.AvatarApi.Favorites();
                Logger.Debug("Downloaded list of", favorite_avatars.Count, "official favorite avatars");
            }
            foreach (var avatar in favorite_avatars)
            {
                var node = new TreeNode(avatar.name);
                node.Tag = avatar;
                node.ForeColor = ColorFromReleaseStatus(avatar.releaseStatus);
                tree_users.Nodes[1].Nodes.Add(node);
            }
            tree_users.Nodes[1].Text = $"Official ({tree_users.Nodes[0].Nodes.Count} / 16)";
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

        private async void tab_changedAsync(object sender, TabControlEventArgs e)
        {
            Logger.Debug(e.Action.ToString(), e.TabPage.Name, e.TabPageIndex.ToString());
            if (new string[] { "tab_users", "tab_avatars", "tab_worlds"}.Contains(e.TabPage.Name))
            {
                if (vrcapi == null)
                {
                    if (config.Sections.ContainsSection("VRCAPI") && config["VRCAPI"].ContainsKey("p") && !string.IsNullOrWhiteSpace(config["VRCAPI"]["p"]))
                    {
                        await VRCAPILogin(Utils.Utils.Base64Decode(config["VRCAPI"]["u"]), Utils.Utils.Base64Decode(config["VRCAPI"]["p"]));
                    }
                    else
                    {
                        SetupVRCApiAsync(); return;
                    }
                }
            }
            switch (e.TabPage.Name)
            {
                case "tab_users":
                    SetupUsersAsync();
                    break;
                case "tab_avatars":
                    SetupAvatarsAsync();
                    break;
                case "tab_settings":
                    if (!settingsInitialized)
                        SetupSettings();
                    break;
                case "tab_mods":
                    if(mods == null)
                        SetupMods();
                    break;
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

        private void mainForm_loaded(object sender, EventArgs e) {
            columnHeader1.Width = -1;
            columnHeader2.Width = -1;
            // Task.Run(() => LogReader.ReadLogs());
        }

        int lastModIndex = 0;
        private void on_mod_selected(object sender, ListViewItemSelectionChangedEventArgs e)
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
        private void avatars_node_selected(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) return;
            AvatarResponse avatar = (AvatarResponse)e.Node.Tag;
            FillAvatar(avatar);
        }
        private void users_node_selected(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) return;
            UserBriefResponse user = (UserBriefResponse)e.Node.Tag;
            FillUser(user);
        }

        private void FillAvatar(AvatarResponse avatar)
        {
            txt_avatar_id.Text = avatar.id;
            txt_avatar_id.Tag = avatar;
            txt_avatar_name.Text = avatar.name;
            txt_avatar_version.Text = avatar.version.ToString();
            txt_avatar_author.Text = $"{avatar.authorName} ({avatar.authorId})";
            txt_avatar_asseturl.Text = avatar.assetUrl;
            txt_avatar_description.Text = avatar.description;
        }

        private void FillUser(UserBriefResponse user)
        {
            txt_users_id.Text = user.id;
            txt_users_id.Tag = user;
            txt_users_displayname.Text = user.displayName;
            txt_users_username.Text = user.username;
            txt_users_status.Text = user.statusDescription;
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            Game.StartGame(args: args);
        }

        private void Btn_config_save_Click(object sender, EventArgs e) {
            Config.Save(config);
        }

        private void Btn_mods_refresh_Click(object sender, EventArgs e) {
            SetupMods(force: true);
        }
        private void Btn_avatars_reload_Click(object sender, EventArgs e)
        {
            SetupAvatarsAsync(force: true);
        }
        private void Btn_users_reload_Click(object sender, EventArgs e)
        {
            SetupUsersAsync(true);
        }

        private async void Btn_avatar_search_ClickAsync(object sender, EventArgs e)
        {
            var avatar = await vrcapi.AvatarApi.GetById(txt_avatar_id.Text);
            FillAvatar(avatar);
        }
        private List<FileInfo> tmpAvatars;
        private void Btn_avatar_rip_Click(object sender, EventArgs e)
        {
            var ripper = Utils.Utils.getRipper();
            if (!ripper.Exists) {
                MessageBox.Show($"{ripper.Name} was not found in\n\n{ripper.Directory}\n\nIf you want to use this feature, place it there.");
                return;
            }
            var avatar = (AvatarResponse)txt_avatar_id.Tag;
            var tmpPath = new DirectoryInfo(Path.GetTempPath());
            Logger.Log("Ripping avatar ", avatar.name, avatar.id.Enclose(), "to", tmpPath.FullName.Quote());
            var file = Utils.Utils.DownloadFile(avatar.assetUrl, tmpPath, avatar.name.Ext("vrca"));
            var proc = Utils.Utils.StartProcess(ripper, file.FullName.Quote());
            proc.Exited += Proc_Exited;
        }
        private void Proc_Exited(object sender, EventArgs e) {
            Logger.Trace("Process has exited", sender, e);
            var file = tmpAvatars.PopAt(0);
            file.Delete();
            Logger.Log("Temp avatar file ", file.Name, "has been deleted");
        }
    }
}
