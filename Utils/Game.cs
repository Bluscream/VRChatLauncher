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
        public static Process StartGame(bool steam = false, string[] args = null)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            // proc.UseShellExecute = true;
            var ownPath = Path.GetDirectoryName(Application.ExecutablePath);
            // var gamePath = Path.Combine(ownPath, gameBinary);
            proc.WorkingDirectory = ownPath;
            proc.FileName = gameBinary;
            if (args != null) proc.Arguments += string.Join(" ", args);
            return Process.Start(proc);
        }
        public static bool IsGameAlreadyRunning()
        {
            Process[] pname = Process.GetProcessesByName("VRChat");
            if (pname.Length == 0) return false;
            return true;
        }
    }
}
