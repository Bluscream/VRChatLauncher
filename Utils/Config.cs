using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace VRChatLauncher.Utils
{
    public class Config
    {
        public static IniData DefaultConfig = new IniData();
        private static string DefaultConfigFile = Path.Combine(Utils.getOwnPath().DirectoryName, "Launcher.ini");
        public static IniData Load(string file = null, FileIniDataParser parser = null) {
            if (file == null) file = DefaultConfigFile;
            if (parser == null) parser = new FileIniDataParser();
            if (!File.Exists(file)) {
                Logger.Warn("Config did not exist, creating default...");
                Save(DefaultConfig, parser: parser);
                return DefaultConfig;
            }
            Logger.Debug("Loading config from", file);
            return parser.ReadFile(file);
        }

        public static void Save(IniData config, string file = null, FileIniDataParser parser = null) {
            if (file == null) file = DefaultConfigFile;
            if (parser == null) parser = new FileIniDataParser();
            if (config.Sections.Count < 1) return;
            Logger.Debug("Writing config to", file);
            parser.WriteFile(file, config);
        }
    }
}
