using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatLauncher.Utils
{
    class Game
    {
        internal const string gameBinary = "VRChat.exe";
        public static Process StartGame(bool steam = false, string[] args = null)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            // proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
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
