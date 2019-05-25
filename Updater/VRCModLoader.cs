using SocketLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static VRChatLauncher.Utils.Mods;
using VRChatLauncher.Utils;

namespace VRChatLauncher.Updater
{
    public class VRCModLoader
    {
        public static Mod CheckForUpdate() // https://download2.survival-machines.fr/vrcmodloader/VRCModLoaderHashCheck.php?localhash=b9a34bb327390008c235cefe8d8f4ada
        {
            var mod = GetMod(Setup.Mods.VRCModLoaderDLL().FullName);
            using (var socket = new ConnectedSocket("vrchat.survival-machines.fr", 26341))
            {
                var request = new VRCTRequest(Type.GETINSTALLERVERSION, "");
                socket.Send(request.toJSON());
                //var data = socket.Receive();
                //var response = new VRCTResponse(data);
                // Logger.Log("recieved:", data);
            }
            return mod;
        }
        public static Mod Update(Mod mod)
        {
            return mod;
        }
    }
    public class VRCTRequest {
        public string version = "1.1";
        public string uuid;
        public string username;
        public string type;
        public string data;
        public VRCTRequest(string type, string data) {
            this.uuid = "usr_none";
            this.username = "<none>";
            this.type = type;
            this.data = data;
            Logger.Debug(this.toJSON());
        }
        public string toJSON() {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
    public class Type {
        public const string 
            GETINSTALLERVERSION = "GETINSTALLERVERSION",
            GETDOWNLOADDATA = "GETDOWNLOADDATA";
    }

    public class VRCTResponse
    {
        public ReturnCode returncode;
        public string data;
        public VRCTResponse(string json) {
            var obj = JsonConvert.DeserializeObject(json);
        }
        public VRCTResponse(int returncode, string data) {
            this.returncode = (ReturnCode)returncode;
            this.data = data;
        }
        public enum ReturnCode
        {
            ERROR_UNDEFINED = 0,
            SUCCESS = 1,
            ERROR_BAD_VERSION = 2,
            ERROR_UNKNOWN_REQUEST = 3,
            ERROR_INTERNAL_SERVER_ERROR = 4,
            ERROR_NOT_HANDLED = 5,
            AVATAR_ALREADY_IN_FAV = 6,
            WAITING_FOR_UPDATE = 7,
            BANNED_ADDRESS = 8,
            BANNED_ACCOUNT = 9,
        }
    }
}
