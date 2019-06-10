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
                Utils.Game.StartGame(false, cmd); 
            }
        }
        private static void SendCommand(string cmd) {
            var oldClip = Clipboard.GetText();
            Clipboard.Clear();
            Clipboard.SetText(cmd);
            if (oldClip != null)
            {
                System.Threading.Thread.Sleep(100);
                Clipboard.SetText(oldClip);
            }
        }
        
        /*
         * string instance_pattern = @"^(\d+)~hidden";
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
                if (!splitted_world_instance[1].Contains("~hidden(")) { InstanceID = ulong.Parse(splitted_world_instance[1]); return; }
                Private = true;
                var splitted_instance_tags = splitted_world_instance[1].Split(new string[]{"~hidden("}, 2, StringSplitOptions.None);
                InstanceID = ulong.Parse(splitted_instance_tags[0]);
                var splitted_instance_tags_private = splitted_instance_tags[1].Split(new string[]{")~nonce("}, 2, StringSplitOptions.None);
                CreatorID = splitted_instance_tags_private[0];
                Nonce = splitted_instance_tags_private[1].Remove(")");

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
            UnFavoriteAvatar
        }
        public class Command {
            public const string Game = "vrchat";
            public bool SkipLauncher { get; set; }
            public bool Force { get; set; }
            public WorldInstanceID WorldInstanceId { get; set; }
            public CommandType CommandType { get; set; }
            public string Referrer { get; set; }
            public Command(CommandType type, bool skipLauncher = false, bool force = false, WorldInstanceID worldInstanceID = null, string referrer = null) {
                CommandType = CommandType;  SkipLauncher = skipLauncher; Force = force; WorldInstanceId = worldInstanceID; Referrer = referrer;
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
                return HttpUtility.UrlDecode(_uri.Uri.ToString());
            }
        }
    }
}
