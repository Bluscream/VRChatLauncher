using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRChatLauncher.IPC
{
    public class Game
    {
        public static void SendCommand(string command) {
            Clipboard.SetText(command);
        }
    }
}
