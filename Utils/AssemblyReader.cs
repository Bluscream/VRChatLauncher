using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace VRChatLauncher.Utils
{
    class AssemblyReader
    {
        static Dictionary<string, Assembly> assemblies;
        internal static string LoadFromGame(string name)
        {
            if (assemblies == null) assemblies = new Dictionary<string, Assembly>();
            if (assemblies.ContainsKey(name)) { Logger.Trace("Assembly", name, "already loaded");  return name; }
            var file = new FileInfo(Path.Combine(Game.gameAssembliesDir.FullName, name + ".dll"));
            if (file.Exists)
            {
                Logger.Debug("Loading assembly", file.Name.Quote(), "from", file.DirectoryName.Quote());
                try { assemblies.Add(name, Assembly.LoadFile(file.FullName)); return name; }
                catch (Exception ex) { Logger.Error("Can't load assembly", file.FullName, ex.Message.Enclose());}
            }
            return string.Empty;
        }

        public static string GetBuildStoreID()
        {
            var assembly = LoadFromGame("Assembly-CSharp");
            var VRCApplicationSetupInstance = assemblies[assembly].CreateInstance("VRCApplicationSetup");
            var VRCApplicationSetupType = VRCApplicationSetupInstance.GetType();
            var GetBuildStoreIDMethod = VRCApplicationSetupType.GetMethod("GetBuildStoreID", BindingFlags.Static | BindingFlags.Public);
            return (string)GetBuildStoreIDMethod.Invoke(null, null);
        }

        private static void ReadCommandLine()
        {
            var assembly = LoadFromGame("Assembly-CSharp");
            var VRCFlowCommandLineInstance = assemblies[assembly].CreateInstance("VRCFlowCommandLine");
            var VRCFlowCommandLineType = VRCFlowCommandLineInstance.GetType();
            var ReadCommandLineMethod = VRCFlowCommandLineType.GetMethod("ReadCommandLine", BindingFlags.Public);
            ReadCommandLineMethod.Invoke(null, null);
        }
    }
}
