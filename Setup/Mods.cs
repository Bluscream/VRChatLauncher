using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatLauncher.Setup
{
    class Mods
    {
        public static bool IsModLoaderInstalled()
        {
            return (IsVRCModLoaderInstalled() || IsVRLoaderInstalled());
        }

        public static bool IsVRCModLoaderInstalled()
        {
            var gamePath = Utils.Utils.getGamePath().DirectoryName;
            var dllPath = Path.Combine(gamePath, "VRChat_Data", "Managed", "VRCModLoader.dll");
            return File.Exists(dllPath);
        }
        public static bool IsVRLoaderInstalled()
        {
            var gamePath = Utils.Utils.getGamePath().DirectoryName;
            var dllPath = Path.Combine(gamePath, "VRLoader.dll");
            return File.Exists(dllPath);
        }
    }
}
