using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VRChatLauncher.Utils
{
    public enum ArgType { Unknown, Launcher, Game, VRCTools }
    public struct Constants {
        public const string LauncherPrefix = "--vrclauncher.";
        public const string VRCToolsPrefix = "--vrctools.";
        public const string GamePrefix = "--";
        public static Regex DashRegex = new Regex(@"^(-+)\w+");
    }
    public class LauncherArguments {
        public Argument IgnoreSSLErrors = new Argument(Constants.LauncherPrefix+"nossl") { ValueType = typeof(bool), DefaultValue = false, Description = "Instructs the launcher to ignore SSL errors" };
        public Argument KeepOpen = new Argument(Constants.LauncherPrefix+"keep") { ValueType = typeof(bool), DefaultValue = false, Description = "Keeps the launcher open even if another instance of it is already running" };
        public Argument Verbose = new Argument(Constants.LauncherPrefix+"verbose") { ValueType = typeof(bool), DefaultValue = false, Description = "Starts logging Trace messages" };
        public Argument Console = new Argument(Constants.LauncherPrefix+"console") { ValueType = typeof(bool), DefaultValue = false, Description = "Opens a console on startup" };
        public Argument Skip = new Argument(Constants.LauncherPrefix+"skiplauncher") { ValueType = typeof(bool), DefaultValue = false, Description = "Skip opening the launcher and start the game directly" };
    }
    public class VRCTArguments {
        public Argument ForceUpdate = new Argument(Constants.VRCToolsPrefix+"forceupdate") { ValueType = typeof(bool), DefaultValue = false, Description = "Forces a vrctools update" };
        public Argument NoUpdate = new Argument(Constants.VRCToolsPrefix+"noupdate") { ValueType = typeof(bool), DefaultValue = false, Description = "Skips VRCTools and AvatarFav update check (Required to run a modified version of VRCTools)" };
        public Argument EnableNamePlateIcons = new Argument(Constants.VRCToolsPrefix+"enablenameplateicons") { ValueType = typeof(bool), DefaultValue = false, Description = "Shows nameplate icons for VRCTools users" };
        public Argument Dev = new Argument(Constants.VRCToolsPrefix+"dev") { ValueType = typeof(bool), DefaultValue = false, Description = "Changes VRCMN Server port from  26342 to 26345" };
        public Argument Verbose = new Argument(Constants.GamePrefix+"verbose") { ValueType = typeof(bool), DefaultValue = false, Description = "Enables VRCTools Console" };
        public Argument NoModLoader = new Argument(Constants.GamePrefix+"nomodloader") { ValueType = typeof(bool), DefaultValue = false, Description = "Disables vrctools mod loading" };
        // public Argument NoTitle = new Argument() { ValueType = typeof(bool), DefaultValue = false, FullName = "notitle", Description = "Disables modifying the title of your game window" };
    }
    public class GameArguments {
        public Argument FPS = new Argument(Constants.GamePrefix+"fps") { ValueType = typeof(int), DefaultValue = null, Description = "Sets the max FPS the game will lock on" };
        public Argument NoVR = new Argument(Constants.GamePrefix+"no-vr") { ValueType = typeof(bool), DefaultValue = false, Description = "Sets the game to desktop-mode" };
        public Argument OSC = new Argument(Constants.GamePrefix+"osc") { ValueType = typeof(string), Description = "Set additional arguments for osc" };
        public Argument URL = new Argument(Constants.GamePrefix+"url") { ValueType = typeof(string), Description = "Same as applying a URL without this param" };
        public Argument LogDebugLevels = new Argument(Constants.GamePrefix+"log-debug-levels") { ValueType = typeof(string), Description = "Sets log levels for the game" };
        public Argument ClearPlayerModerations = new Argument(Constants.GamePrefix+"clear-player-moderations") { ValueType = typeof(bool), DefaultValue = false, Description = "Clears all player moderations, be careful with this!" };
        public Argument AutoLoginUsername = new Argument(Constants.GamePrefix+"auto-login-un") { ValueType = typeof(string), Description = "Sets username for auto login" };
        public Argument AutoLoginPassword = new Argument(Constants.GamePrefix+"auto-login-pw") { ValueType = typeof(string), Description = "Sets password for auto login" };
        public Argument AutoLogin2FA = new Argument(Constants.GamePrefix+"auto-login-2fa") { ValueType = typeof(string), Description = "Sets two factor authentication code for auto login" };
        public Argument SpawnRadius = new Argument(Constants.GamePrefix+"spawn-radius") { ValueType = typeof(string), DefaultValue = null, Description = "N/A" };
        public Argument Profile = new Argument(Constants.GamePrefix+"profile") { ValueType = typeof(string), DefaultValue = null, Description = "N/A" };
    }
    public class Argument
    {
        public ArgType ArgType; // = Constants.ArgType.Unknown;
        public Type ValueType;
        public string Dashes;
        public string Prefix;
        public string FullName;
        public string Name;
        public string Description;
        public List<object> Values;
        public object Value;
        public object DefaultValue;
        public bool IsSet = false;
        public Argument(string fullname) {
            FullName = fullname;
            var split = FullName.Split(".");
            Name = split.PopLast();
            Prefix = string.Join(".", split);
            var has_dashes = Constants.DashRegex.Match(Prefix);
            if (has_dashes.Success && has_dashes.Groups.Count > 0)
                Dashes = Constants.DashRegex.Match(Prefix).Groups[1].Value;
        }
        public void SetValue(object value)
        {
            Value = value;
            IsSet = true;
        }
        public bool IsTrue() {
            return IsSet && ((bool)Value == true || (int)Value == 1 || (string)Value == "true" || (string)Value == "1");
        }
    }
    public class Arguments
    {
        public LauncherArguments Launcher = new LauncherArguments();
        public GameArguments Game = new GameArguments();
        public VRCTArguments VRCTools = new VRCTArguments();
        public List<IPC.Game.Command> Commands;
        public override string ToString()
        {
            return base.ToString();
        }
        public string[] ToArray()
        {
            return new string[] { };
        }
        public List<string> ToList()
        {
            return new List<string>();
        }
        public static Arguments FromArgs(List<string> args)
        {
            Logger.Log("Parsing Arguments:", args.ToJson());
            var arguments = new Arguments();
            // arguments.Game = new GameArguments();
            // arguments.VRCTools = new VRCTArguments();
            // arguments.Commands = new List<IPC.Game.Command>();
            foreach (var arg in args)
            {
                var curArg = arg;
                if (curArg.StartsWith("--")) curArg = curArg.Substring(2);
                if (curArg.StartsWith("-")) curArg = curArg.Substring(1);
                var argType = ArgType.Unknown;
                if (curArg.StartsWith(Constants.LauncherPrefix)) {
                    argType = ArgType.Launcher;
                    curArg = curArg.Substring(Constants.LauncherPrefix.Length);
                    Console.WriteLine($"is launcher arg {curArg}");
                } else if (curArg.StartsWith(Constants.VRCToolsPrefix)) {
                    argType = ArgType.VRCTools;
                    curArg = curArg.Substring(Constants.VRCToolsPrefix.Length);
                }
                var splitarg = curArg.Split('=');
                var isSplitArg = splitarg.Length > 1;
                object argValue;
                if (isSplitArg) argValue = splitarg[1];
                else argValue = true;
                var argBool = isSplitArg ? bool.TryParse(splitarg[1], out bool argBoolValue) : false;
                var argNumber = isSplitArg ? ulong.TryParse(splitarg[1], out ulong argNumberValue) : false;
                switch (argType)
                {
                    case ArgType.Launcher:
                        /* PropertyInfo[] properties = typeof(LauncherArguments).GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            if (property.GetGetMethod())
                            property.SetValue(record, value);
                        }*/ 
                        switch (curArg) {
                            case "keep":
                                arguments.Launcher.KeepOpen.SetValue(true); break;
                            case "nossl":
                                arguments.Launcher.IgnoreSSLErrors.SetValue(true); break;
                            case "console":
                                arguments.Launcher.Console.SetValue(true); break;
                            case "verbose":
                                arguments.Launcher.Verbose.SetValue(true); break;
                            default:
                                break;
                        }
                        break;
                    case ArgType.Game:
                        break;
                    case ArgType.VRCTools:
                        switch (curArg) {
                            case "enablenameplateicons":
                                arguments.VRCTools.EnableNamePlateIcons.SetValue(true); break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            Logger.Log("Parsed Arguments:", arguments.ToJson());
            return arguments;
        }
    }
}
