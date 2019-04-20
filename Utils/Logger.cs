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
        public static void Trace(params object[] msg) => log(VRChatApi.Logging.LogLevel.Trace, msgs: msg);
        public static void Debug(params object[] msg) => log(VRChatApi.Logging.LogLevel.Debug, msgs: msg);
        public static void Log(params object[] msg) => log(VRChatApi.Logging.LogLevel.Info, msgs: msg);
        public static void LogLines(bool lines = false, params object[] msg) => log(VRChatApi.Logging.LogLevel.Info, lines: lines, msgs: msg);
        public static void Warn(params object[] msg) => log(VRChatApi.Logging.LogLevel.Warn, msgs: msg);
        public static void Error(params object[] msg) => log(VRChatApi.Logging.LogLevel.Error, msgs: msg);
        public static void Fatal(params object[] msg) => log(VRChatApi.Logging.LogLevel.Fatal, msgs: msg);
        private static void log(VRChatApi.Logging.LogLevel logLevel, bool lines = false, params object[] msgs) // [CallerMemberName] string cName = "Unknown.Unknown", 
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
            var str = "";
            var seperator = lines ? Environment.NewLine : " ";
            foreach(var msg in msgs) {
                try { str += seperator + (string)msg;
                } catch (Exception ex) {
                    // Console.WriteLine($"Error {ex.ToString()}");
                    str += seperator + msg.ToString();
                }
            }
            var line = $"[{timestamp}] {logLevel} - {cName}.{mName}: {str}";
            if (Main.selflog != null){
                item.Text = line;
                Main.selflog.Items.Add(item);
            }
            Console.WriteLine(line);
            Console.ForegroundColor = oldColor;
        }
    }
}
