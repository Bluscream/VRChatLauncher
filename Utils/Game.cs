using System.Diagnostics;
using System.IO;
using System.Linq;

namespace VRChatLauncher.Utils
{
    class Game
    {

        internal const string gameBinary = "VRChat.exe";
        internal static DirectoryInfo gameAssembliesDir = Utils.getGamePath().Directory.Combine("VRChat_Data", "Managed");
        public static Process StartGame(bool steam = false, params string[] args)
        {
            // var ownPath = Path.GetDirectoryName(Application.ExecutablePath);
            // proc.WorkingDirectory = ownPath;
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift)) {
                var argsWindow = new UI.CommandLineArguments(Utils.getGamePath().FullName, args.ToArray());
                var result = argsWindow.ShowDialog();
            }
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
