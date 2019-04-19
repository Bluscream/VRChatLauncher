using System;
using System.Diagnostics;
using System.Linq;

namespace VRChatLauncher.Utils
{
    class Logger
    {
        public static void Init() {
            Console.Title = "VRChat Launcher Log";
            var args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            args = args.Select(s => s.ToLowerInvariant()).ToArray();
            if (args.Contains("--vrclauncher.console")) { /* ExternalConsole.InitConsole(); */ }
        }
        public static void Trace(params string[] msg) => log(VRChatApi.Logging.LogLevel.Trace, msg);
        public static void Debug(params string[] msg) => log(VRChatApi.Logging.LogLevel.Debug, msg);
        public static void Log(params string[] msg) => log(VRChatApi.Logging.LogLevel.Info, msg);
        public static void Warn(params string[] msg) => log(VRChatApi.Logging.LogLevel.Warn, msg);
        public static void Error(params string[] msg) => log(VRChatApi.Logging.LogLevel.Error, msg);
        public static void Fatal(params string[] msg) => log(VRChatApi.Logging.LogLevel.Fatal, msg);
        private static void log(VRChatApi.Logging.LogLevel logLevel, params string[] msg) // [CallerMemberName] string cName = "Unknown.Unknown", 
        {
            /*if (logLevel == VRChatApi.Logging.LogLevel.Trace || logLevel == VRChatApi.Logging.LogLevel.Debug) {
                if (!Main.args.Contains("--verbose") || !Main.args.Contains("-v")) return;
            }*/
            string timestamp = DateTime.UtcNow.ToString("HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            StackFrame frame = new StackFrame(1); var method = frame.GetMethod(); var cName = method.DeclaringType.Name; var mName = method.Name;
            var oldColor = Console.ForegroundColor;
            var item = new System.Windows.Forms.ListViewItem();
            switch (logLevel)
            {
                case VRChatApi.Logging.LogLevel.Trace:
                    Console.ForegroundColor = ConsoleColor.Gray; item.ForeColor = System.Drawing.Color.Gray;break;
                case VRChatApi.Logging.LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Cyan; item.ForeColor = System.Drawing.Color.Cyan; break;
                case VRChatApi.Logging.LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White; break;
                case VRChatApi.Logging.LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.DarkYellow; item.ForeColor = System.Drawing.Color.Orange; break;
                case VRChatApi.Logging.LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red; item.ForeColor = System.Drawing.Color.Red; break;
                case VRChatApi.Logging.LogLevel.Fatal:
                    Console.ForegroundColor = ConsoleColor.DarkRed; item.BackColor = System.Drawing.Color.Red; break;
                default:
                    break;
            }
            var line = $"[{timestamp}] {logLevel} - {cName}.{mName}: {string.Join(" ", msg)}";
            if (Main.selflog != null){
                item.Text = line;
                Main.selflog.Items.Add(item);
            }
            Console.WriteLine(line);
            Console.ForegroundColor = oldColor;
        }
    }
}
