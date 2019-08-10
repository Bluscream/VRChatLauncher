using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatLauncher.Utils
{
    public enum ArgType { Unknown, Launcher, Game, VRCTools }
    public struct Constants {
        public const string LauncherPrefix = "vrclauncher.";
        public const string VRCToolsPrefix = "vrctools.";
    }
    public class LauncherArguments {
        public Argument NoSSL = new Argument(ArgType.Launcher) { ValueType = typeof(bool), DefaultValue = false, Name = "nossl", Description = "Instructs the launcher to ignore SSL errors" };
        public Argument KeepOpen = new Argument(ArgType.Launcher) { ValueType = typeof(bool), DefaultValue = false, Name = "keep", Description = "Keeps the launcher open even if another instance of it is already running" };
        public Argument Verbose = new Argument(ArgType.Launcher) { ValueType = typeof(bool), DefaultValue = false, Name = "verbose", Description = "Starts logging Trace messages" };
        public Argument Console = new Argument(ArgType.Launcher) { ValueType = typeof(bool), DefaultValue = false, Name = "console", Description = "Opens a console on startup" };
    }
    public class VRCTArguments {
        public Argument ForceUpdate = new Argument(ArgType.VRCTools) { ValueType = typeof(bool), DefaultValue = false, Name = "forceupdate", Description = "Forces a vrctools update" };
        public Argument NoUpdate = new Argument(ArgType.VRCTools) { ValueType = typeof(bool), DefaultValue = false, Name = "noupdate", Description = "Skips VRCTools and AvatarFav update check (Required to run a modified version of VRCTools)" };
        public Argument EnableNamePlateIcons = new Argument(ArgType.VRCTools) { ValueType = typeof(bool), DefaultValue = false, Name = "enablenameplateicons", Description = "Shows nameplate icons for VRCTools users" };
        public Argument Dev = new Argument(ArgType.VRCTools) { ValueType = typeof(bool), DefaultValue = false, Name = "dev", Description = "Changes VRCMN Server port from  26342 to 26345" };
        public Argument Verbose = new Argument(ArgType.Unknown) { ValueType = typeof(bool), DefaultValue = false, Name = "verbose", Description = "Enables VRCTools Console" };
        public Argument NoModLoader = new Argument(ArgType.Unknown) { ValueType = typeof(bool), DefaultValue = false, Name = "nomodloader", Description = "Disables vrctools mod loading" };
        // public Argument NoTitle = new Argument() { ValueType = typeof(bool), DefaultValue = false, Name = "notitle", Description = "Disables modifying the title of your game window" };
    }
    public class GameArguments {
        public Argument FPS = new Argument(ArgType.Game) { ValueType = typeof(int), DefaultValue = null, Name = "fps", Description = "Sets the max FPS the game will lock on" };
        public Argument NoVR = new Argument(ArgType.Game) { ValueType = typeof(bool), DefaultValue = false, Name = "no-vr", Description = "Sets the game to desktop-mode" };
        public Argument OSC = new Argument(ArgType.Game) { ValueType = typeof(string), Name = "osc", Description = "Set additional arguments for osc" };
        public Argument URL = new Argument(ArgType.Game) { ValueType = typeof(string), Name = "url", Description = "Same as applying a URL without this param" };
        public Argument LogDebugLevels = new Argument(ArgType.Game) { ValueType = typeof(string), Name = "log-debug-levels", Description = "Sets log levels for the game" };
        public Argument ClearPlayerModerations = new Argument(ArgType.Game) { ValueType = typeof(bool), DefaultValue = false, Name = "clear-player-moderations", Description = "Clears all player moderations, be careful with this!" };
        public Argument AutoLoginUsername = new Argument(ArgType.Game) { ValueType = typeof(string), Name = "auto-login-un", Description = "Sets username for auto login" };
        public Argument AutoLoginPassword = new Argument(ArgType.Game) { ValueType = typeof(string), Name = "auto-login-pw", Description = "Sets password for auto login" };
        public Argument AutoLogin2FA = new Argument(ArgType.Game) { ValueType = typeof(string), Name = "auto-login-2fa", Description = "Sets two factor authentication code for auto login" };
        public Argument SpawnRadius = new Argument(ArgType.Game) { ValueType = typeof(string), DefaultValue = null, Name = "spawn-radius", Description = "N/A" };
        public Argument Profile = new Argument(ArgType.Game) { ValueType = typeof(string), DefaultValue = null, Name = "profile", Description = "N/A" };
    }
    /*public class VRCTArgument : Argument {
        public new Constants.ArgType ArgType = Constants.ArgType.VRCTools;
    }
    public class GameArgument : Argument {
        public new Constants.ArgType ArgType = Constants.ArgType.Game;
    }
    public class LauncherArgument : Argument {
        public new Constants.ArgType ArgType = Constants.ArgType.Launcher;
    }*/
    public class Argument
    {
        public ArgType ArgType; // = Constants.ArgType.Unknown;
        public Type ValueType;
        public string Name;
        public string Description;
        public List<object> Values;
        public object Value { get { return Value; } set { Value = Value; IsSet = true; } }
        public object DefaultValue;
        public bool IsSet = false;
        public Argument(ArgType argType) { ArgType = argType; }
    }
    public class Arguments
    {
        public LauncherArguments Launcher;
        public GameArguments Game;
        public VRCTArguments VRCTools;
        public List<IPC.Game.Command> Commands;
        public string String { get { return ""; } }
        public string[] Array { get { return new string[] { }; } }
        public List<string> List { get { return new List<string>(); } }
        public static Arguments FromArgs(List<string> args)
        {
            Logger.Log("Parsing Arguments:", args.ToJson());
            var arguments = new Arguments();
            arguments.Launcher = new LauncherArguments();
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
                        switch (curArg)
                        {
                            case "keep":
                                arguments.Launcher.KeepOpen.Value = true; break;
                            case "nossl":
                                arguments.Launcher.NoSSL.Value = true; break;
                            default:
                                break;
                        }
                        break;
                    case ArgType.Game:
                        break;
                    case ArgType.VRCTools:
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
