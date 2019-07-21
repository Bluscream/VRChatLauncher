using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatLauncher.Classes {
    class UserCountsEndPoint {
        public string Name { get; set; }
        public string Mod { get; set; }
        public long onlineClients { get; set; }
        public string lastUpdated { get; set; }
    }
    class UserCounts {
        public UserCountsEndPoint[] EndPoints { get; set; }
    }
}
