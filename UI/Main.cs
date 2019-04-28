using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Net;
using VRChatLauncher.Utils;
using IniParser.Model;
using VRChatApi.Classes;
using Humanizer;
using System.Threading;

namespace VRChatLauncher
{
    public partial class Main : Form
    {
        public static string[] args = new string[] { };
        public IniData config;public VRChatApi.VRChatApi vrcapi;
        public static TextBox statusBar;public static WebClient webClient;
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
                    else { if (tabs_main.SelectedTab == tab_users) SetupUsersAsync(); }
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

        private async void tab_changedAsync(object sender, TabControlEventArgs e)
        {
            Logger.Trace(e.Action.ToString(), e.TabPage.Name, e.TabPageIndex.ToString());
            if (new string[] { "tab_users", "tab_avatars", "tab_worlds"}.Contains(e.TabPage.Name))
            {
                LoginVRCAPI();
            }
            switch (e.TabPage.Name)
            {
                case "tab_users":
                    SetupUsersAsync();
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

        private void btn_play_Click(object sender, EventArgs e)
        {
            Game.StartGame(args: args);
        }
        

        private void mainForm_loaded(object sender, EventArgs e) {
            new Thread(LoadNews).Start();
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
            columnHeader1.Width = -1;
            columnHeader2.Width = -1;
            tree_users.Nodes[1].Expand();tree_users.Nodes[3].Expand();
            new Thread(updateUsers).Start();
            new Thread(sendHeartBeat).Start();
            // Task.Run(() => LogReader.ReadLogs());
            Logger.Trace("MainForm fully loaded");
        }

        private void sendHeartBeat()
        {
            var osinfo = new ComputerInfo();
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Referer",$"https://launcher.vrc/{osinfo.OSFullName}/{osinfo.OSVersion}");
                wc.DownloadString(new Uri("https://github.com/Bluscream/VRChatLauncher/blob/master/stats"));
            }
        }

        private void updateUsers() {
            using (var wc = new WebClient())
            {
                var users = wc.DownloadString("https://api.vrchat.cloud/api/1/visits");
                if (!string.IsNullOrEmpty(users)) { Text = $"VRChat Launcher ({users} users playing)";  }
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
        NodeType Type { get; set; }
        object Object1 { get; set; }
        object Object2 { get; set; }
        public enum NodeType {
            Me,
            User,
            World,
            Instance
        }
    }
}
