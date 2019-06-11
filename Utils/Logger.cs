using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace VRChatLauncher.Utils
{
    class Logger
    {
        private static FileInfo getLogFile(string fileName = "Launcher.log") {
            return new FileInfo(Path.Combine(Utils.getOwnPath().DirectoryName, fileName));
        }
        public static void Init() {
            try { Console.Title = "VRChat Launcher Log"; } catch { }
            var args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            args = args.Select(s => s.ToLowerInvariant()).ToArray();
            if (args.Contains("--vrclauncher.console")) { ExternalConsole.InitConsole(); }
        }
        public static void ClearLog() {
            var log = getLogFile();
            if (log.Exists && log.Length > 0) try { File.WriteAllText(log.FullName, string.Empty); } catch { }
            }
        private static Tuple<Color, ConsoleColor> ColorFromLogLevel(VRChatApi.Logging.LogLevel logLevel) {
            switch (logLevel) {
                case VRChatApi.Logging.LogLevel.Trace:
                    return new Tuple<Color, ConsoleColor>(Color.Gray, ConsoleColor.Gray);
                case VRChatApi.Logging.LogLevel.Debug:
                    return new Tuple<Color, ConsoleColor>(Color.Cyan, ConsoleColor.Cyan);
                case VRChatApi.Logging.LogLevel.Warn:
                    return new Tuple<Color, ConsoleColor>(Color.Orange, ConsoleColor.DarkYellow);
                case VRChatApi.Logging.LogLevel.Error:
                    return new Tuple<Color, ConsoleColor>(Color.Red, ConsoleColor.Red);
                case VRChatApi.Logging.LogLevel.Fatal:
                    return new Tuple<Color, ConsoleColor>(Color.DarkRed, ConsoleColor.DarkRed);
                default:
                    return new Tuple<Color, ConsoleColor>(Color.White, ConsoleColor.White);
            }
        }
        public static void Trace(params object[] msg) => log(VRChatApi.Logging.LogLevel.Trace, msgs: msg);
        public static void Debug(params object[] msg) => log(VRChatApi.Logging.LogLevel.Debug, msgs: msg);
        public static void Log(params object[] msg) => log(VRChatApi.Logging.LogLevel.Info, msgs: msg);
        public static void LogLines(params object[] msg) => log(VRChatApi.Logging.LogLevel.Info, lines: true, msgs: msg);
        public static void Warn(params object[] msg) => log(VRChatApi.Logging.LogLevel.Warn, msgs: msg);
        public static void Error(params object[] msg) => log(VRChatApi.Logging.LogLevel.Error, msgs: msg);
        public static void Fatal(params object[] msg) => log(VRChatApi.Logging.LogLevel.Fatal, msgs: msg);
        private static void log(VRChatApi.Logging.LogLevel logLevel, bool lines = false, params object[] msgs) // [CallerMemberName] string cName = "Unknown.Unknown", 
        {
            string timestamp = DateTime.UtcNow.ToString("HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            StackFrame frame = new StackFrame(1); var method = frame.GetMethod(); var cName = method.DeclaringType.Name; var mName = method.Name;
            var oldColor = Console.ForegroundColor;
            var newColor = ColorFromLogLevel(logLevel);
            var item = new System.Windows.Forms.ListViewItem();
            item.ForeColor = newColor.Item1;
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
            if (Main.selflog != null) {
                item.Text = line;
                Main.selflog.Items.Add(item);
            }
            if (Main.statusBar != null && logLevel > VRChatApi.Logging.LogLevel.Debug) {
                try {
                    Main.statusBar.Text = line;
                    Main.statusBar.ForeColor = newColor.Item1;
                } catch (InvalidOperationException) { }
            }
            getLogFile().AppendLine(line);
            if (logLevel > VRChatApi.Logging.LogLevel.Trace || Main.args.Contains("--vrclauncher.verbose")) {
                try {
                    Console.ForegroundColor = newColor.Item2;
                    Console.WriteLine(line);
                    Console.ForegroundColor = oldColor;
                } catch { }
            }
        }
    }
}
