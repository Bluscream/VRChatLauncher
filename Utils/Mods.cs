using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
                    mod.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(mod.File.Name);
                    try {
                        mod = GetModInfo(mod);
                        // Logger.Trace(mod.FileNameWithoutExtension, "Type:", mod.Type.ToString(), "Name:", mod.Name, "Version:", mod.Version, "Author:", mod.Author);
                        Logger.Debug(mod.ToString());
                    } catch (Exception ex) { Logger.Error("Can't load mod", $"\"{mod.File.Name}\"", $"({ex.Message})", Environment.NewLine, ex.StackTrace); }
                    ret.Add(mod);
                }
            }
            return ret;
        }
        public class Mod  {
            public string FileNameWithoutExtension { get; set; }
            public FileInfo File { get; set; }
            public string Name { get; set; }
            public ModLoaderType Type { get; set; }
            public string Version { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public string UpdateURL { get; set; }
            public override string ToString() {
                return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
            }
        }
        public enum ModLoaderType {
            Unknown,
            VRCModloader,
            VRLoader
        }
        public static List<TypeDefinition> GetTypes(Mod mod)
        {
            var ret = new List<TypeDefinition>(){ };
            ModuleDefinition module = ModuleDefinition.ReadModule(mod.File.FullName);
            ret = module.Types.ToList();
            // Logger.Trace(mod.FileNameWithoutExtension, "Types:", string.Join(", ", ret));
            return ret;
        }
        public static Mod GetModInfo(Mod mod) {
            var types = GetTypes(mod);
            // [ModuleInfo("Freecam/Drone", "1.0", "CJ - Credit to the real Meep <3 Join today | https://discord.gg/xgPdrGP")]
            // [VRCModInfo("Single Instance", "2.1", "Bluscream")]
            foreach (var type in types)
            {
                // Logger.Log("Now checking type", type.ToString());
                CustomAttribute ignoreAttribute;
                if (TryGetCustomAttribute(type, "VRLoader.Attributes.ModuleInfoAttribute", out ignoreAttribute)) 
                {
                    // Logger.Warn("Found VRLoader mod!");
                    mod.Type = ModLoaderType.VRLoader;
                    mod.Name = (string)ignoreAttribute.ConstructorArguments[0].Value;
                    mod.Version = (string)ignoreAttribute.ConstructorArguments[1].Value;
                    mod.Author = (string)ignoreAttribute.ConstructorArguments[2].Value;
                }
                else if (TryGetCustomAttribute(type, "VRCModLoader.VRCModInfoAttribute", out ignoreAttribute))
                {
                    // Logger.Warn("Found VRCModloader mod!");
                    mod.Type = ModLoaderType.VRCModloader;
                    mod.Name = (string)ignoreAttribute.ConstructorArguments[0].Value;
                    mod.Version = (string)ignoreAttribute.ConstructorArguments[1].Value;
                    mod.Author = (string)ignoreAttribute.ConstructorArguments[2].Value;
                }
            }
            return mod;
        }
        public static bool TryGetCustomAttribute(TypeDefinition type, string attributeType, out CustomAttribute result)
        {
            result = null;
            if (!type.HasCustomAttributes) return false;
            foreach (CustomAttribute attribute in type.CustomAttributes) {
                if (attribute.AttributeType.FullName != attributeType)
                    continue;

                result = attribute;
                return true;
            }
            return false;
        }
    }
}