using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using VRChatLauncher.Utils;

namespace VRChatLauncher.IPC
{
    public class Game
    {
        /* private static List<string> CleanArgs(List<string> args)
        {
            args.RemoveAll(item => item.StartsWith("--vrclauncher."));
            // foreach (var arg in args) {
                /*var cmd = Command.FromString(arg);
                if (cmd is null) _args.Add(arg);*
            //}
            return args;
        }*/
        public static void Send(Command command) {
            var cmd = command.ToString();
            Logger.Debug("Sending command to game:", Environment.NewLine, command.ToJson());
            if (Utils.Game.IsGameAlreadyRunning()) {
                SendCommand(cmd);
            } else {
                Utils.Game.StartGame(false, Program.Arguments.ToString(), cmd);
            }
        }
        private static void SendCommand(string cmd) {
            string oldClip = null;
            try {
                oldClip = Clipboard.GetText();
                Clipboard.Clear();
            } catch (System.Runtime.InteropServices.ExternalException) { Logger.Warn("Unable to backup/clear clipboard"); }
            Clipboard.SetText(cmd);
            if (!string.IsNullOrWhiteSpace(oldClip)) {
                System.Threading.Thread.Sleep(100);
                try { Clipboard.SetText(oldClip);
                } catch (System.Runtime.InteropServices.ExternalException) { Logger.Warn("Unable to reset clipboard"); }
            }
        }
        public enum UserLocationType { Unknown, Empty, Offline, Private, Public }
        public class UserLocation
        {
            public UserLocationType Type { get; }
            public WorldInstanceID WorldInstance { get; }
            public UserLocation(string location)
            {
                if (location is null) {
                    Type = UserLocationType.Empty;
                } else if (location.StartsWith("wrld_")) {
                    Type = UserLocationType.Public;
                    WorldInstance = new WorldInstanceID(location);
                } else if (location == "private") {
                    Type = UserLocationType.Private;
                } else if (location == "offline") {
                    Type = UserLocationType.Offline;
                } else if (location == "") {
                    Type = UserLocationType.Empty;
                } else { Type = UserLocationType.Unknown;  }
            }
        }
        public enum InstancePrivacyType { Unknown, Public, FriendsOnly, Hidden }
        private static Regex InstanceTagPattern = new Regex(@"(.*)\((.*)\)", RegexOptions.Compiled);
        public class WorldInstanceID {
            public InstancePrivacyType Type = InstancePrivacyType.Public;
            public string WorldID { get; }
            public ulong InstanceID { get; set; }
            public string CreatorID { get; }
            public string Nonce { get; }
            public WorldInstanceID(string worldinstanceid) {
                if (string.IsNullOrEmpty(worldinstanceid)) return;
                var splitted_world_instance = worldinstanceid.Split(":");
                WorldID = splitted_world_instance[0];
                if (splitted_world_instance.Length < 2) return;
                var splitted_instance = splitted_world_instance[1].Split("~").ToList();
                InstanceID = ulong.Parse(splitted_instance.PopAt(0));
                if (splitted_instance.Count < 1) return;
                foreach (var item in splitted_instance)
                {
                    var match = InstanceTagPattern.Match(item);
                    var key = match.Groups[1].Value.ToLower();var value = match.Groups[2].Value;
                    if (key == "hidden") { Type = InstancePrivacyType.Hidden; CreatorID = value; }
                    else if (key == "friends") { Type = InstancePrivacyType.FriendsOnly; CreatorID = value; }
                    else if (key == "nonce") Nonce = value;
                }
            }
            public override string ToString() {
                var sb = new StringBuilder(WorldID);
                if (InstanceID > 0) {
                    sb.Append(":"); sb.Append(InstanceID);
                    switch (Type)
                    {
                        case InstancePrivacyType.FriendsOnly:
                            sb.Append("~friends"); sb.Append(CreatorID.Enclose());break;
                        case InstancePrivacyType.Hidden:
                            sb.Append("~hidden"); sb.Append(CreatorID.Enclose());break;
                        default:
                            break;
                    }
                    if (!Nonce.IsNullOrEmpty()) { sb.Append("~nonce"); sb.Append(Nonce.Enclose()); }
                }
                return sb.ToString();
            }
        }
        public enum CommandType {
            // [Description("")]
            Unknown,
            [Description("launch")]
            Launch,
            [Description("user/profile")]
            OpenProfile,
            [Description("user/add")]
            AddFriend,
            [Description("user/remove")]
            RemoveFriend,
            [Description("avatar/add")]
            FavoriteAvatar,
            [Description("avatar/remove")]
            UnFavoriteAvatar,
            [Description("avatar/select")]
            SelectAvatar
        }
        public class Command : UriBuilder {
            // vrchat://launch/?id=wrld_496b11e8-25a0
            //public new string Scheme = "vrchat";
            public NameValueCollection Parameters { get; set; }
            public CommandType Type { get { return Extensions.GetValueFromDescription<CommandType>(Host, true); } set { Host = value.GetDescription(); } }
            public bool Force { get { return Parameters.GetBool("force"); } set { Parameters["force"] = value.ToString(); } }
            public bool SkipLauncher { get { return Parameters.GetBool("skiplauncher"); } set { Parameters["skiplauncher"] = value.ToString(); } }
            public string Referrer { get { return Parameters.GetString("ref"); } set { Parameters["ref"] = value; } }
            public WorldInstanceID WorldInstanceID { get { return new WorldInstanceID(Parameters.GetString("id")); } set { Console.WriteLine("Setting WorldInstanceID"); Parameters["id"] = value.ToString(); } }
            public new string Query {
                get {
                    return Parameters.ToQueryString();
                } 
                set {
                    base.Query = value;
                    Parameters = HttpUtility.ParseQueryString(value);
                }
            }
            public Command(CommandType type = CommandType.Launch, NameValueCollection parameters = null, string url = "vrchat://") : base(url) {
                Scheme = "vrchat";
                Type = type;
                if (parameters != null) Parameters = parameters;
                else Parameters = new NameValueCollection();
                Logger.Trace(this.ToJson());
            }
            public static Command FromString(string url) {
                try { return new Command(url: url.ToLower());
                } catch (UriFormatException) { return null; }
            }
            public string ToDecodedString() {
                return HttpUtility.UrlDecode(Uri.ToString());
            }
        }
    }
}
