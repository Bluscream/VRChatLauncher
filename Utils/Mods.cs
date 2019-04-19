using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatLauncher.Utils
{
    class Mods
    {
        public static List<Mod> GetMods()
        {
            var ret = new List<Mod> { };
            var gamePath = Utils.getGamePath();
            var modPaths = new List<string>() {
                Path.Combine(gamePath.DirectoryName, "Mods"),
                Path.Combine(gamePath.DirectoryName, "Modules"),
                Path.Combine(gamePath.DirectoryName, "Plugins")
            };
            foreach (var modPath in modPaths)
            {
                if (!Directory.Exists(modPath)) continue;
                foreach (var file in Directory.GetFiles(modPath)) {
                    var mod = new Mod();
                    mod.File = new FileInfo(file);
                    try {

                    } catch { }
                    ret.Add(mod);
                }
            }
            return ret;
        }
        public class Mod  {
            public FileInfo File { get; set; }
            public string Name { get; set; }
            public ModLoaderType Type { get; set; }
            public string Version { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public string UpdateURL { get; set; }
        }
        public enum ModLoaderType {
            VRCModloader,
            VRLoader
        }
    }
}
