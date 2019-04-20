using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VRChatLauncher.Utils;

namespace VRChatLauncher.IPC
{
    public class CommandHandler
    {
        public static async Task IsLauncherRunning(string argument)
        {
            foreach (var arg in argument.Split(' ')) {
                if (arg.ToLower().StartsWith("vrchat://")) {
                    var uri = URI.Parse(arg);
                    switch (uri.Host.ToLower()) {
                        case "launch":
                            if (Utils.Game.IsGameAlreadyRunning()) {
                                Logger.Log(uri.ParseQueryString());
                            } else {
                                Utils.Game.StartGame(false, arg); // Todo properly implement
                            }
                            break;
                        default:
                            break;
                    }
                    // var queryDictionary = HttpUtility.ParseQueryString(uri.Query);
                    /*Logger.LogLines(lines: true,
                        uri.ToJson(), // "vrchat://launch/?ref=vrchat.com&id=wrld_9c40ca9d-216d-46d1-baa7-e1117df7d026:89595"
                        uri.AbsoluteUri, // vrchat://launch/?ref=vrchat.com&id=wrld_9c40ca9d-216d-46d1-baa7-e1117df7d026:89595
                        uri.AbsolutePath, // /
                        uri.Authority, // launch
                        uri.DnsSafeHost, // launch
                        uri.Fragment,// 
                        uri.Host, // launch
                        uri.HostNameType, // Dns
                        uri.IdnHost, // launch
                        uri.IsAbsoluteUri, // True
                        uri.IsDefaultPort, // True
                        uri.IsFile, // False
                        uri.IsLoopback, // False
                        uri.IsUnc, // False
                        uri.LocalPath, // /
                        uri.OriginalString, // vrchat://launch/?ref=vrchat.com&id=wrld_9c40ca9d-216d-46d1-baa7-e1117df7d026:89595
                        uri.PathAndQuery, // /?ref=vrchat.com&id=wrld_9c40ca9d-216d-46d1-baa7-e1117df7d026:89595
                        uri.Port, // -1
                        uri.Query, // ?ref=vrchat.com&id=wrld_9c40ca9d-216d-46d1-baa7-e1117df7d026:89595
                        uri.Scheme, // vrchat
                        uri.Segments.ToJson(), // System.String[]
                        uri.UserEscaped, // False
                        uri.UserInfo, // 
                        uri.IsWellFormedOriginalString(), // True
                        uri.ParseQueryString().ToJson(), // { "ref": "vrchat.com", "id": "wrld_9c40ca9d-216d-46d1-baa7-e1117df7d026:89595" }
                        // queryDictionary, // ref=vrchat.com&id=wrld_9c40ca9d-216d-46d1-baa7-e1117df7d026%3a89595
                        // queryDictionary.ToJson() // [  "ref",  "id" ]
                    );*/
                    // Game.SendCommand(arg); // Handle with launcher
                }
            }
        }
    }
}
