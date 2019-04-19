using System.IO;
using System.Windows.Forms;
using VRChatLauncher.Utils;

namespace VRChatLauncher.Setup
{
    class Game
    {
        public static bool CheckForGame()
        {
            Logger.Trace("Start");
            var ownPath = Path.GetDirectoryName(Application.ExecutablePath);
            var gamePath = Path.Combine(ownPath, "VRChat.exe");
            Logger.Debug("Checking if", gamePath, "exists...");
            var isExecutablePresent = File.Exists(gamePath);
            return isExecutablePresent;
        }
    }
}
