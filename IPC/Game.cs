using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using VRChatLauncher.Utils;

namespace VRChatLauncher.IPC
{
    public class Game
    {
        public static void Send(Command command) {
            var cmd = command.ToString();
            Logger.Debug("Sending command to game:", Environment.NewLine, command.ToJson(), Environment.NewLine, cmd);
            if (Utils.Game.IsGameAlreadyRunning()) {
                SendCommand(cmd);
            } else {
                Utils.Game.StartGame(false, string.Join(" ", CleanArgs(Main.args)), cmd);
            }
        }
        private static string[] CleanArgs(string[] args)
        {
            List<string> _args = new List<string>();
            foreach (var arg in args) {
                if (arg.StartsWith("--vrclauncher.")) continue;
                var cmd = new Command(CommandType.Unknown).FromString(arg);
                if (cmd is null) _args.Add(arg);
            }
            return _args.ToArray();
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
        /*
         * string instance_pattern = @"^(\d+)~hidden";
         * wrld_fac11e5f-1c73-4436-8936-a70b80961c5a:92975~friends(usr_ed8143b9-b99c-4a16-9b09-656fcf494b53)~nonce(ADD7430D680EDF2A4CE78CAAD0E0AC0830D587800A93C7E91E6F4BB436C8583B)
        *  string instance_pattern_private = instance_pattern + @"\((usr_[\w\d]{8}-[\w\d]{4}-[\w\d]{4}-[\w\d]{4}-[\w\d]{12})\)~nonce\(([0-9A-Z]{64})\)$";
        */
        public class WorldInstanceID {
            public bool Private { get; }
            public string WorldID { get; }
            public ulong InstanceID { get; set; }
            public string CreatorID { get; }
            public string Nonce { get; }
            public WorldInstanceID(string worldinstanceid) {
                if (string.IsNullOrWhiteSpace(worldinstanceid)) return;
                if (!worldinstanceid.Contains(":")) { WorldID = worldinstanceid; return; }
                var splitted_world_instance = worldinstanceid.Split(new string[]{":"}, 2, StringSplitOptions.None);
                WorldID = splitted_world_instance[0];
                var hidden = splitted_world_instance[1].Contains("~hidden(");var friendsOnly = splitted_world_instance[1].Contains("~friends(");
                if (!hidden && !friendsOnly) { InstanceID = ulong.Parse(splitted_world_instance[1]); return; }
                Private = true;
                var splitted_instance_tags = new string[] { };
                if (hidden) splitted_instance_tags = splitted_world_instance[1].Split("~hidden(", 2);
                else if (friendsOnly) splitted_instance_tags = splitted_world_instance[1].Split("~friends(", 2);
                if (splitted_instance_tags.Length > 0) {
                    InstanceID = ulong.Parse(splitted_instance_tags[0]);
                    var splitted_instance_tags_private = splitted_instance_tags[1].Split(")~nonce(", 2);
                    CreatorID = splitted_instance_tags_private[0];
                    Nonce = splitted_instance_tags_private[1].Remove(")");
                }
            }
            public override string ToString() {
                var sb = new StringBuilder(WorldID);
                if (InstanceID > 0) {
                    sb.Append(":"); sb.Append(InstanceID);
                    if (Private) { sb.Append("~hidden"); sb.Append(CreatorID.Enclose()); sb.Append("~nonce"); sb.Append(Nonce.Enclose()); }
                }
                return sb.ToString();
            }
        }

        public class CommandParameter {
            public string Key { get; }
            public string Value { get; }
            public CommandParameter(string key, string value) {
                Key = key; Value = value;
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
        public class Command {
            public const string Game = "vrchat";
            public bool SkipLauncher { get; set; }
            public bool Force { get; set; }
            public WorldInstanceID WorldInstanceId { get; set; }
            public CommandType CommandType { get; set; }
            public string CommandTypeRaw { get; set; }
            public string Referrer { get; set; }
            public Command(CommandType type, bool skipLauncher = false, bool force = false, WorldInstanceID worldInstanceID = null, string referrer = null) {
                CommandType = type; CommandTypeRaw = type.GetDescription(); SkipLauncher = skipLauncher; Force = force; WorldInstanceId = worldInstanceID; Referrer = referrer;
                Logger.Trace(this.ToJson());
            }
            public Command FromString(string url)
            {
                url = url.ToLower();
                Uri uri;
                try { uri = new Uri(url);
                } catch (UriFormatException) { return null; }
                var query = HttpUtility.ParseQueryString(uri.Query);
                // var cmdtype = uri.Host.ToLower();
                var cmd = new Command(
                    type: Extensions.GetValueFromDescription<CommandType>(uri.Host, true),
                    skipLauncher: (query.AllKeys.Contains("skiplauncher") && query["skiplauncher"] == "true"), // , StringComparer.OrdinalIgnoreCase
                    force: (query.AllKeys.Contains("force") && query["force"] == "true"),
                    worldInstanceID: (query.AllKeys.Contains("id") ? new WorldInstanceID(query["id"]) : null),
                    referrer: (query.AllKeys.Contains("ref") ? query["ref"] : null)
                );
                cmd.CommandTypeRaw = uri.Host;
                Logger.Trace(cmd.ToJson());
                return cmd;
            }
            public override string ToString()
            {
                var _uri = new UriBuilder() { Scheme = Game, Host = CommandType.GetDescription()};
                var query = HttpUtility.ParseQueryString(_uri.Query);
                if (WorldInstanceId != null) { query["id"] = WorldInstanceId.ToString(); }
                if (Referrer != null) { query["ref"] = Referrer; }
                if (SkipLauncher) { query["skiplauncher"] = SkipLauncher.ToString(); }
                if (Force) { query["force"] = Force.ToString(); }
                _uri.Query = query.ToString();
                Logger.Trace(_uri.ToJson());
                Logger.Trace(query.ToJson());
                return HttpUtility.UrlDecode(_uri.Uri.ToString());
            }
        }
    }
}
