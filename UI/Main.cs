﻿using System;
using System.Net;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using VRChatLauncher.Utils;
using IniParser.Model;
using VRChatApi.Classes;
using Humanizer;

namespace VRChatLauncher
{
    public partial class Main : Form
    {
        public static List<string> args = new List<string>();
        public IniData config;public VRChatApi.VRChatApi vrcapi;
        public static TextBox statusBar;public static WebClient webClient;
        public Main(string[] arguments)
        {
            Logger.Trace("START");
            config = Config.Load();
            InitializeComponent();
            // var args = Program.args.Skip(1).ToArray();
            args = arguments.ToList();
            var gameInSameDir = Setup.Game.CheckForGame();
            // if (!gameInSameDir) SetupGame();
            Setup.URIResponse regKeyCorrect = Setup.URI.CheckURIRegistryKey();
            Logger.Trace("match=", regKeyCorrect.match.ToString());
            if(regKeyCorrect.match != Setup.URIResponse.URIEnum.INSTALLED) SetupURI(regKeyCorrect.expected, regKeyCorrect.key);
            // richTextBox1.Text = "match: "+ regKeyCorrect.match.ToString() + "\n\nexpected: " + regKeyCorrect.expected + "\n\nkey: " + regKeyCorrect.key + "\n\n";
            selflog = lst_log_launcher; gamelog = lst_log_game;statusBar = txt_status;
            webClient = new WebClient();
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
                var Game = new FileInfo(gameSelector.FileName);
                var Launcher = Utils.Utils.getOwnPath();
                var newPath = new FileInfo(Path.Combine(Game.DirectoryName, Launcher.Name));
                Launcher.CopyTo(newPath.FullName);
                Utils.Utils.StartProcess(newPath, "--vrclauncher.keep", Launcher.FullName.Quote());
            }
            Utils.Utils.Exit();
        }
        public async Task<bool> VRCAPILogin(string username, string password)
        {
            Logger.Log("Trying to log in as", username, "...");
            vrcapi = new VRChatApi.VRChatApi(username, password);
            me = await vrcapi.UserApi.Login().TimeoutAfter(TimeSpan.FromSeconds(5));
            // var json = await me.Raw.Content.ReadAsStringAsync();
            if (me == null) { //  && me.id == null
                // Check password
                var confirmResult = MessageBox.Show($"Something went wrong while logging you in as {username}\n\nRetry?", "Failed to log in!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (confirmResult == DialogResult.Retry) return await VRCAPILogin(username, password);
                tabs_main.SelectTab(0); return false;
            }
            Logger.Log("Logged in as", me.username);
            var _me = await vrcapi.UserApi.UpdateInfo(me.id);
            // Logger.Trace("_me", _me.ToJson());
            if (_me.id != null) { FillMe(); return true; }
            var json = await _me.Raw.Content.ReadAsStringAsync();
            object temp = null;
            temp = Newtonsoft.Json.JsonConvert.DeserializeObject<UserResponse>(json);
            var userResponse = (UserResponse)temp;
            if (userResponse.id != null) {
                Logger.Trace("userResponse", userResponse.ToJson());
                return true;
            } else {
                temp = Newtonsoft.Json.JsonConvert.DeserializeObject<BanResponse>(json);
                var banResponse = (BanResponse)temp;
                if (banResponse.Reason != null)
                {
                    Logger.Trace("banResponse", banResponse.ToJson());
                    var isIPban = banResponse.Target != me.displayName;
                    Logger.Trace("isIPban", isIPban); // https://stackoverflow.com/questions/3253701/get-public-external-ip-address
                    var confirmResult = MessageBox.Show($"Your account {banResponse.Target} has been banned by VRChat!\n\nExpires: {banResponse.ExpiresAt} ({banResponse.ExpiresIn.Humanize()} remaining.)\n\nReason: {banResponse.Reason.Quote()}\n\nDo you want to log in to another account?", "Account banned!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (confirmResult == DialogResult.Yes) { SetupVRCApiAsync(); }
                    else { if (tabs_main.SelectedTab == tab_users) SetupUsers(); }
                    return false;
                } else {
                    temp = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(json);
                    var response = (Response)temp;
                    if (response.Content != null) {
                        Logger.Trace("response", response.ToJson());
                        MessageBox.Show($"Failed to log in because of {response.Content}", "Failed to log in!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    } else  {
                        Logger.Error("Unable to parse UpdateInfo response:", _me.Raw.ToJson());
                        return false;
                    }
                }
            }
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
        public async void LoginVRCAPI() {
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

        private void tab_changed(object sender, TabControlEventArgs e)
        {
            Logger.Trace(e.Action.ToString(), e.TabPage.Name, e.TabPageIndex.ToString());
            if (new string[] { "tab_users", "tab_avatars", "tab_worlds" }.Contains(e.TabPage.Name))
            {
                LoginVRCAPI();
            }
            switch (e.TabPage.Name)
            {
                case "tab_users":
                    SetupUsers();
                    break;
                case "tab_avatars":
                    SetupAvatarsAsync();
                    break;
                case "tab_worlds":
                    SetupWorldsAsync();
                    break;
                case "tab_settings":
                    if (!settingsInitialized)
                        SetupSettings();
                    break;
                case "tab_mods":
                    if (mods == null)
                        SetupMods();
                    break;
                case "tab_log_game":
                    if (logReader == null)
                    {
                        logReader = new LogReader();
                        logReader.Init();
                        lst_log_game.Items.Add("Initialized Log Watcher");
                    }
                    break;
                default:
                    break;
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            Game.StartGame(args: args.ToArray()); // TODO ENABLE
            Logger.Log("Build Platform:", AssemblyReader.GetBuildStoreID()); // IDK?
        }
        

        private void mainForm_loaded(object sender, EventArgs e) {
            new Thread(LoadNews).Start();
            if (config.Sections.ContainsSection("Window"))
            {
                var state = config["Window"]["State"];var loc = config["Window"]["Location"].Split(':');var size = config["Window"]["Size"].Split(':');
                Logger.Debug("Was", config["Window"]["State"], "Location:", loc.ToJson(false), "Size:", size.ToJson(false));
                switch (state) {
                    case "Maximized":
                        WindowState = FormWindowState.Maximized;
                        break;
                    default:
                        Location = new System.Drawing.Point(int.Parse(loc[0]), int.Parse(loc[1]));
                        Size = new System.Drawing.Size(int.Parse(size[1]), int.Parse(size[0]));
                        break;
                }
            }
            columnHeader1.Width = -1;
            columnHeader2.Width = -1;
            tree_users.Nodes[1].Expand();tree_users.Nodes[3].Expand();
            new Thread(updateUsers).Start();
            // new Thread(sendHeartBeat).Start();
            // Task.Run(() => LogReader.ReadLogs());
            Logger.Trace("MainForm fully loaded");
        }

        private void sendHeartBeat()
        {
            var osinfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Referer",$"https://launcher.vrc/{osinfo.OSFullName}/{osinfo.OSVersion}");
                wc.DownloadString(new Uri("https://github.com/Bluscream/VRChatLauncher/blob/master/stats"));
            }
        }
        private void SetNews(string rtf) {
          if (this.txt_news.InvokeRequired) { 
            GenericCallback d = new GenericCallback(SetNews);
            this.txt_news.Invoke(d, new object[] { rtf });
          } else {
            this.txt_news.Rtf = rtf;
          }
        }
        delegate void GenericCallback(string text);
        private void SetTitle(string text) {
          if (this.InvokeRequired) { 
            GenericCallback d = new GenericCallback(SetTitle);
            this.Invoke(d, new object[] { text });
          } else {
            this.Text = text;
          }
        }
        private void updateUsers() {
            using (var wc = new WebClient())
            {
                var sleep = TimeSpan.FromMinutes(5);
                while (true)
                {
                    var users = wc.DownloadString("https://api.vrchat.cloud/api/1/visits");
                    if (!string.IsNullOrEmpty(users)) { SetTitle($"VRChat Launcher ({users} users playing)"); }
                    Thread.Sleep(sleep);
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.Debug("called");
            if(WindowState == FormWindowState.Normal) {
                config["Window"]["Location"] = Location.X.ToString() + ":" + Location.Y.ToString();
                config["Window"]["Size"] = RestoreBounds.Size.Height.ToString() + ":" + RestoreBounds.Size.Width.ToString();
            }
            config["Window"]["State"] = WindowState.ToString();
            Config.Save(config);
        }
    }
    public class TreeNodeTag
    {
        public NodeType Type { get; set; }
        public string Id { get; set; }
        public object Object { get; set; }
        public UserResponse userResponse { get; set; }
        public UserBriefResponse userBriefResponse { get; set; }
        public WorldResponse worldResponse { get; set; }
        public WorldBriefResponse worldBriefResponse { get; set; }
        public WorldInstanceResponse worldInstanceResponse { get; set; }
        public WorldInstance worldInstance { get; set; }
        public WorldInstanceUserResponse worldInstanceUserResponse { get; set; }
        public PlayerModeratedResponse playerModeratedResponse { get; set; }
        public NotificationResponse notificationResponse { get; set; }
        public AvatarResponse avatarResponse { get; set; }
        public TreeNodeTag(NodeType type, string id = null, params object[] responses) {
            Type = type; Id = id;
            foreach (var response in responses) {
                switch (response) {
                    case UserResponse ur:
                        userResponse = ur;
                        userBriefResponse = ur; break;
                    case UserBriefResponse ubr:
                        userBriefResponse = ubr; break;
                    case WorldResponse wr:
                        worldResponse = wr; break;
                    case WorldBriefResponse wbr:
                        worldBriefResponse = wbr; break;
                    case WorldInstanceResponse wir:
                        worldInstanceResponse = wir; break;
                    case WorldInstance wir:
                        worldInstance = wir; break;
                    case WorldInstanceUserResponse wiur:
                        worldInstanceUserResponse = wiur; break;
                    case PlayerModeratedResponse pmr:
                        playerModeratedResponse = pmr; break;
                    case NotificationResponse nr:
                        notificationResponse = nr; break;
                    case AvatarResponse ar:
                        avatarResponse = ar; break;
                    default:
                        Object = response; break;
                }
            }
        }
    }
    public enum NodeType {
        Me, User, World, Instance, Moderation, Notification, Avatar
    }
}
