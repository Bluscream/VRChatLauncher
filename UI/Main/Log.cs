using System.Windows.Forms;
using VRChatLauncher.Utils;

namespace VRChatLauncher
{
    partial class Main
    {
        public static ListView selflog;
        public static ListView gamelog;
        public LogReader logReader;

        public void WriteGameLog(string message) {
            if (string.IsNullOrWhiteSpace(message)) return;
            if (lst_log_game.Items.Count > 500) lst_log_game.Items.RemoveAt(0);
            lst_log_game.Items.Add(message);
        }

        public void WriteLauncherLog(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            if (lst_log_launcher.Items.Count > 200) lst_log_launcher.Items.RemoveAt(0);
            lst_log_launcher.Items.Add(message);
        }
    }
}
