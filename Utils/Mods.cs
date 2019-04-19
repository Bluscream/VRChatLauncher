using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
                Path.Combine(gamePath.DirectoryName, "Plugins"),
                Path.Combine(gamePath.DirectoryName, "VRChat_Data", "Managed", "VRLoader", "Modules")
            };
            foreach (var modPath in modPaths)
            {
                if (!Directory.Exists(modPath)) continue;
                foreach (var file in Directory.GetFiles(modPath, "*.dll", SearchOption.TopDirectoryOnly)) {
                    var mod = new Mod();
                    mod.File = new FileInfo(file);
                    try {
                        try
                        {
                            var assembly = Assembly.LoadFile(file);
                            foreach (Type type in assembly.GetTypes())
                            {
                                foreach (PropertyInfo property in type.GetProperties())
                                {
                                    Logger.Log(property.Name + " - " + property.PropertyType);
                                }
                            }

                            foreach (Type type in assembly.GetTypes())
                            {
                                foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                                {
                                    Logger.Log(field.Name + " - " + field.FieldType);
                                }
                            } 
                        } catch (ReflectionTypeLoadException ex) {
                            StringBuilder sb = new StringBuilder();
                            foreach (Exception exSub in ex.LoaderExceptions)
                            {
                                sb.AppendLine(exSub.Message);
                                FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                                if (exFileNotFound != null)
                                {
                                    if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                                    {
                                        sb.AppendLine("Fusion Log:");
                                        sb.AppendLine(exFileNotFound.FusionLog);
                                    }
                                }
                                sb.AppendLine();
                            }
                            string errorMessage = sb.ToString();
                            Logger.Error(errorMessage);
                        }
                    } catch (Exception ex) { Logger.Error("Can't load mod", $"\"{mod.File.Name}\"", $"({ex.Message})", Environment.NewLine, ex.StackTrace); }
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
