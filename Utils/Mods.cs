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
    public class Mods
    {
        public static List<Mod> CheckForUpdates(List<Mod> mods)
        {
            for (int i = 0; i < mods.Count; i++)
            {
                mods[i] = CheckForUpdate(mods[i]);
            }
            return mods;
        }
        public static Mod CheckForUpdate(Mod mod)
        {
            var sb = new StringBuilder();
            switch (mod.Name)
            {
                case "VRCTools":
                    var _mod = Updater.VRCTools.CheckForUpdate(mod);
                    if (_mod.Update != null) mod = Updater.VRCTools.Update(_mod);
                    break;
                case "VRCModLoader":
                    var dll = Setup.Mods.VRCModLoaderDLL();
                    _mod = Updater.VRCModLoader.CheckForUpdate();
                    if (_mod.Update != null) mod = Updater.VRCModLoader.Update(_mod);
                    break;
                default: break;
            }
            return mod;
        }
        public static Mod EnableMod(Mod mod)
        {
            if (mod.File.Directory.Name != "Disabled") {
                Logger.Warn("Mod", mod.Name, "is already in folder", mod.File.Directory.Name);
                return mod;
            }
            var newPath = Path.Combine(mod.File.Directory.Parent.FullName, mod.File.Name);
            Logger.Debug("Moving mod", mod.Name, "to", newPath);
            mod.File.MoveTo(newPath);
            mod.File = new FileInfo(newPath);
            mod.Enabled = true;
            return mod;
        }
        public static Mod DisableMod(Mod mod)
        {
            if (mod.File.Directory.Name == "Disabled") {
                Logger.Warn("Mod", mod.Name, "is already in folder", mod.File.Directory.Name);
                return mod;
            }
            var newPath = Path.Combine(mod.File.DirectoryName, "Disabled", mod.File.Name);
            Logger.Debug("Moving mod", mod.Name, "to", newPath);
            mod.File.MoveTo(newPath);
            mod.File = new FileInfo(newPath);
            mod.Enabled = false;
            return mod;
        }
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
                    var mod = GetMod(file);
                    mod.Enabled = true;
                    ret.Add(mod);
                }
                var disabledModPath = Path.Combine(modPath, "Disabled");
                if (!Directory.Exists(disabledModPath)) continue;
                foreach (var file in Directory.GetFiles(disabledModPath, "*.dll", SearchOption.TopDirectoryOnly)) {
                    var mod = GetMod(file);
                    mod.Enabled = false;
                    ret.Add(mod);
                }
            }
            Logger.Log("Loaded", ret.Count.ToString(), "mods from", modPaths.Count.ToString(), "folders");
            return ret;
        }
        public static List<TypeDefinition> GetTypes(Mod mod)
        {
            var ret = new List<TypeDefinition>(){ };
            ModuleDefinition module = ModuleDefinition.ReadModule(mod.File.FullName);
            ret = module.Types.ToList();
            return ret;
        }
        public static Mod GetMod(string file)  {
            var mod = new Mod();
            // mod.Type = ModLoaderType.Unknown;
            mod.File = new FileInfo(file);
            mod.Name = mod.File.FileNameWithoutExtension();
            try {
                mod = GetModInfo(mod);
            } catch (Exception ex) { Logger.Error("Can't load mod", $"\"{mod.File.Name}\"", $"({ex.Message})", Environment.NewLine, ex.StackTrace); }
            return mod;
        }
        public static Mod GetModInfo(Mod mod) {
            var types = GetTypes(mod);
            // [ModuleInfo("Freecam/Drone", "1.0", "CJ - Credit to the real Meep <3 Join today | https://discord.gg/xgPdrGP")]
            // [VRCModInfo("Single Instance", "2.1", "Bluscream")]
            foreach (var type in types)
            {
                CustomAttribute ignoreAttribute;
                if (TryGetCustomAttribute(type, "VRLoader.Attributes.ModuleInfoAttribute", out ignoreAttribute)) 
                {
                    mod.Type = ModLoaderType.VRLoader;
                    mod.Name = (string)ignoreAttribute.ConstructorArguments[0].Value;
                    mod.Version = (string)ignoreAttribute.ConstructorArguments[1].Value;
                    mod.Author = (string)ignoreAttribute.ConstructorArguments[2].Value;
                    return mod;
                }
                else if (TryGetCustomAttribute(type, "VRCModLoader.VRCModInfoAttribute", out ignoreAttribute))
                {
                    mod.Type = ModLoaderType.VRCModloader;
                    mod.Name = (string)ignoreAttribute.ConstructorArguments[0].Value;
                    mod.Version = (string)ignoreAttribute.ConstructorArguments[1].Value;
                    mod.Author = (string)ignoreAttribute.ConstructorArguments[2].Value;
                    return mod;
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

        public class Mod {
            public FileInfo File { get; set; }
            public bool Enabled { get; set; }
            public string Name { get; set; }
            public ModLoaderType Type { get; set; }
            public string Version { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public ModUpdate Update { get; set; }
        }
        public class ModUpdate {
            public string newVersion { get; set; }
            public string hash { get; set; }
            public string downloadURL { get; set; }
            public bool isArchive { get; set; }
        }
        public enum ModLoaderType {
            Unknown,
            VRCModloader,
            VRLoader
        }
    }
}