using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRChatLauncher.Utils
{
    class Game
    {
        internal const string gameBinary = "VRChat.exe";
        public static Process StartGame(bool steam = false, params string[] args)
        {
            // var ownPath = Path.GetDirectoryName(Application.ExecutablePath);
            // proc.WorkingDirectory = ownPath;
            return Utils.StartProcess(Utils.getGamePath(), args);
        }
        public static bool IsGameAlreadyRunning()
        {
            Process[] pname = Process.GetProcessesByName("VRChat");
            if (pname.Length == 0) return false;
            return true;
        }
    }
}
