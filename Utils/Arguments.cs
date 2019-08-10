using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public Argument IgnoreSSLErrors = new LauncherArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "nossl", Description = "Instructs the launcher to ignore SSL errors" };
        public Argument KeepOpen = new LauncherArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "keep", Description = "Keeps the launcher open even if another instance of it is already running" };
        public Argument Verbose = new LauncherArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "verbose", Description = "Starts logging Trace messages" };
        public Argument Console = new LauncherArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "console", Description = "Opens a console on startup" };
        public Argument Skip = new LauncherArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "skiplauncher", Description = "Skip opening the launcher and start the game directly" };
    }
    public class VRCTArguments {
        public Argument ForceUpdate = new VRCTArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "forceupdate", Description = "Forces a vrctools update" };
        public Argument NoUpdate = new VRCTArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "noupdate", Description = "Skips VRCTools and AvatarFav update check (Required to run a modified version of VRCTools)" };
        public Argument EnableNamePlateIcons = new VRCTArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "enablenameplateicons", Description = "Shows nameplate icons for VRCTools users" };
        public Argument Dev = new VRCTArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "dev", Description = "Changes VRCMN Server port from  26342 to 26345" };
        public Argument Verbose = new Argument() { ValueType = typeof(bool), DefaultValue = false, Name = "verbose", Description = "Enables VRCTools Console" };
        public Argument NoModLoader = new Argument() { ValueType = typeof(bool), DefaultValue = false, Name = "nomodloader", Description = "Disables vrctools mod loading" };
        // public Argument NoTitle = new Argument() { ValueType = typeof(bool), DefaultValue = false, Name = "notitle", Description = "Disables modifying the title of your game window" };
    }
    public class GameArguments {
        public Argument FPS = new GameArgument() { ValueType = typeof(int), DefaultValue = null, Name = "fps", Description = "Sets the max FPS the game will lock on" };
        public Argument NoVR = new GameArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "no-vr", Description = "Sets the game to desktop-mode" };
        public Argument OSC = new GameArgument() { ValueType = typeof(string), Name = "osc", Description = "Set additional arguments for osc" };
        public Argument URL = new GameArgument() { ValueType = typeof(string), Name = "url", Description = "Same as applying a URL without this param" };
        public Argument LogDebugLevels = new GameArgument() { ValueType = typeof(string), Name = "log-debug-levels", Description = "Sets log levels for the game" };
        public Argument ClearPlayerModerations = new GameArgument() { ValueType = typeof(bool), DefaultValue = false, Name = "clear-player-moderations", Description = "Clears all player moderations, be careful with this!" };
        public Argument AutoLoginUsername = new GameArgument() { ValueType = typeof(string), Name = "auto-login-un", Description = "Sets username for auto login" };
        public Argument AutoLoginPassword = new GameArgument() { ValueType = typeof(string), Name = "auto-login-pw", Description = "Sets password for auto login" };
        public Argument AutoLogin2FA = new GameArgument() { ValueType = typeof(string), Name = "auto-login-2fa", Description = "Sets two factor authentication code for auto login" };
        public Argument SpawnRadius = new GameArgument() { ValueType = typeof(string), DefaultValue = null, Name = "spawn-radius", Description = "N/A" };
        public Argument Profile = new GameArgument() { ValueType = typeof(string), DefaultValue = null, Name = "profile", Description = "N/A" };
    }
    public class VRCTArgument : Argument {
        public new ArgType ArgType = ArgType.VRCTools;
    }
    public class GameArgument : Argument {
        public new ArgType ArgType = ArgType.Game;
    }
    public class LauncherArgument : Argument {
        public new ArgType ArgType = ArgType.Launcher;
    }
    public class Argument
    {
        public ArgType ArgType; // = Constants.ArgType.Unknown;
        public Type ValueType;
        public string Name;
        public string Description;
        public List<object> Values;
        public object Value;
        public object DefaultValue;
        public bool IsSet = false;
        // public Argument(ArgType argType) { ArgType = argType; }
        public void SetValue(object value)
        {
            Value = value;
            IsSet = true;
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
