using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatLauncher.Utils
{
    class URI
    {
        public static Uri Parse(string url) {
            return new Uri(url);
        }
    }
}
