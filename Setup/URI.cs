using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using VRChatLauncher.Utils;

namespace VRChatLauncher.Setup
{
    class URI
    {
        public const string key = @"HKEY_CLASSES_ROOT\VRChat\shell\open\command";
        public static URIResponse CheckURIRegistryKey()
        {
            var ret = new URIResponse(URIResponse.URIEnum.UNKNOWN, "", "");
            ret.key = (string)Registry.GetValue(key, null, null);
            if (ret.key == null) return ret;
            // Logger.Trace("key=", ret.key);
            var ownPath = Path.GetDirectoryName(Application.ExecutablePath);
            var ownFile = Path.GetFullPath(Application.ExecutablePath);
            var steamFile =Path.Combine(ownPath, "launch.bat");
            var expected_steam = $@"""{steamFile}"" ""{ownPath}"" ""%1""";
            // Logger.Trace("expected_steam=", expected_steam);
            if (expected_steam == ret.key) { ret.match = URIResponse.URIEnum.DEFAULT; return ret; }
            ret.expected = $@"""{ownFile}"" ""{ownPath}"" ""%1""";
            // Logger.Trace("expected=", ret.expected);
            if (ret.key != ret.expected) ret.match = URIResponse.URIEnum.WRONG;
            else ret.match = URIResponse.URIEnum.INSTALLED;
            // MessageBox.Show("expected:\n" + ret.expected+ "\n\nkey:\n" + ret.key);
            // "G:\Steam\steamapps\common\VRChat\launch.bat" "G:\Steam\steamapps\common\VRChat" "%1"
            return ret;
        }
        public static bool InstallURI(string val = null)
        {
            if (val is null)
            {
                var ownPath = Path.GetDirectoryName(Application.ExecutablePath);
                var ownFile = Path.GetFullPath(Application.ExecutablePath);
                val = $@"""{ownFile}"" ""{ownPath}"" ""%1""";
            }
            Logger.Debug(val);
            try { Registry.SetValue(key, null, val);
            } catch (Exception) { return false; }
            return true;
        }
    }
    public class URIResponse {
        public URIResponse(URIEnum item1, string item2, string item3) {
            match = item1; expected = item2; key = item3;
        }
        public URIEnum match { get; set; }
        public string expected { get; set; }
        public string key { get; set; }
        public enum URIEnum {
            INSTALLED, DEFAULT, WRONG, UNKNOWN
        }
    }
}
