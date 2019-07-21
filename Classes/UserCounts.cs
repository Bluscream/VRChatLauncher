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
        public long onlineServers { get; set; }
        public string lastUpdated { get; set; }
    }
    class UserCounts {
        public string lastStartTime { get; set; }
        public UserCountsEndPoint[] endpoints { get; set; }
        public string lastStopTime { get; set; }
    }
}
