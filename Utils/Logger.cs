using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
// using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VRChatLauncher.Utils
{
    class Logger
    {
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
            switch (logLevel)
            {
                case VRChatApi.Logging.LogLevel.Trace:
                    Console.ForegroundColor = ConsoleColor.Gray;break;
                case VRChatApi.Logging.LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Cyan; break;
                case VRChatApi.Logging.LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White; break;
                case VRChatApi.Logging.LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case VRChatApi.Logging.LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red; break;
                case VRChatApi.Logging.LogLevel.Fatal:
                    Console.ForegroundColor = ConsoleColor.DarkRed; break;
                default:
                    break;
            }
            Console.WriteLine($"[{timestamp}] {logLevel} - {cName}.{mName}: {string.Join(" ", msg)}");
            Console.ForegroundColor = oldColor;
        }
    }
}
