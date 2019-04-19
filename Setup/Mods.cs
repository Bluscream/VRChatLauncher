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
        public static FileInfo VRCModLoaderDLL()
        {
            var gamePath = Utils.Utils.getGamePath().DirectoryName;
            var dllPath = Path.Combine(gamePath, "VRChat_Data", "Managed", "VRCModLoader.dll");
            return new FileInfo(dllPath);
        }
        public static bool IsVRCModLoaderInstalled()
        {
            return VRCModLoaderDLL().Exists;
        }

        public static FileInfo VRLoaderDLL()
        {
            var gamePath = Utils.Utils.getGamePath().DirectoryName;
            var dllPath = Path.Combine(gamePath, "VRLoader.dll");
            return new FileInfo(dllPath);
        }
        public static bool IsVRLoaderInstalled()
        {
            return VRLoaderDLL().Exists;
        }
    }
}
