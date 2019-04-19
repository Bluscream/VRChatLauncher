using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Talifun.FileWatcher;

namespace VRChatLauncher.Utils
{
    public class LogReader
    {
        public static DirectoryInfo logDir;
        public const string logFilter = @"output_log_*-*-*_*.txt";
        public static Regex logRegex = new Regex(@"output_log_\d{1,2}-\d{1,2}-\d{1,2}_(?:AM|PM)\.txt$");
        private static readonly object Lock = new object();
        public static IEnhancedFileSystemWatcher FSWatcher;
        public static List<Log> watching = new List<Log>();
        public void Init()
        {
            logDir = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "..", "LocalLow", "VRChat", "vrchat"));
            watching.Add(new Log(getLatestLog()));
            var filter = logRegex.ToString();
            FSWatcher = EnhancedFileSystemWatcherFactory.Instance.CreateEnhancedFileSystemWatcher(logDir.FullName, filter, 1000, false);
            FSWatcher.Start();
            FSWatcher.FileCreatedEvent += OnFileCreatedEvent;
            FSWatcher.FileChangedEvent += OnFileChangedEvent;
            FSWatcher.FileDeletedEvent += OnFileDeletedEvent;
            Logger.Debug("Initialised Log Watcher >", Environment.NewLine, "Folder:", logDir.FullName, Environment.NewLine, "Filter:", filter);
        }

        private static void OnFileCreatedEvent(object sender, FileCreatedEventArgs e) {
            lock (Lock) {
                var file = new FileInfo(e.FilePath);
                foreach (var log in watching) {
                    if (log.File.Name == file.Name) {
                        Logger.Debug("Already watching", file.Name); return;
                    }
                }
                Logger.Debug("Now also watching", file.Name);
                watching.Add(new Log(file));
            }
        }
        private static void OnFileDeletedEvent(object sender, FileDeletedEventArgs e) {
            lock (Lock) {
                var file = new FileInfo(e.FilePath);
                foreach (var log in watching) {
                    if (log.File.Name == file.Name) {
                    watching.Remove(log);
                    Logger.Debug("No longer watching", file.Name);
                    return;
                    }
                }
                Logger.Debug("Not watching", file.Name);
            }
        }
        private static void OnFileChangedEvent(object sender, FileChangedEventArgs e) {
            //lock (Lock) {
                var file = new FileInfo(e.FilePath);
                foreach (var log in watching) {
                    if (log.File.Name == file.Name) {
                        var line = ReadLastLine(e.FilePath);
                        if (string.IsNullOrWhiteSpace(line)) return;
                        Logger.Trace(file.Name, line);
                        return;
                    }
                }
            //}
        }


        public static FileInfo getLatestLog() {
            return logDir.GetFiles(logFilter).OrderByDescending(f => f.LastWriteTime).First();
        }
        /*public void ReadLogs()
        {
            if (logDir == null) Init();
            var wh = new AutoResetEvent(false);
            var fsw = new FileSystemWatcher();
            fsw.Filter = getLatestLog().FullName;
            fsw.EnableRaisingEvents = true;
            fsw.Changed += (s, e) => wh.Set();

            var fs = new FileStream(fsw.Filter, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //UInt64 i = 0;
            using (var sr = new StreamReader(fs))
            {
                var s = "";
                while (true)
                {
                    s = sr.ReadLine();
                    if (s != null && !string.IsNullOrWhiteSpace(s))
                    {
                        // if (!s.Contains("OnPlayerJoined") && !s.Contains("OnPlayerLeft") && !s.Contains("OnJoinedRoom") && !s.Contains("OnLeftRoom")) continue;
                        /*
                        LogLine line = ParseLine(s);
                        if (joins_only)
                        {
                            if (line.Logger != Logger.NetworkManager) continue;
                            if (line.EventType != EventType.OnPlayerJoined && line.EventType != EventType.OnPlayerLeft &&
                                line.EventType != EventType.OnJoinedRoom && line.EventType != EventType.OnLeftRoom) continue;
                        }
                        Console.WriteLine(@"<{0}> [{1}] {2} ({3}): {4}", line.DateTime.ToString(), line.Category.ToString(), line.Logger.ToString(), line.EventType.ToString(), line.Message);
                        *\/
                        Logger.Log(s);
                        //i += 1;
                    }
                    else
                    {
                        wh.WaitOne(50);
                    }
                }
            }
            wh.Close();
        }*/

        public static string ReadLastLine(string path, Encoding encoding = null, string newline = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            if (newline == null) newline = Environment.NewLine;
            int charsize = encoding.GetByteCount(newline);
            byte[] buffer = encoding.GetBytes(newline);
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                long endpos = stream.Length / charsize;
                for (long pos = charsize; pos < endpos; pos += charsize)
                {
                    stream.Seek(-pos, SeekOrigin.End);
                    stream.Read(buffer, 0, buffer.Length);
                    if (encoding.GetString(buffer) == newline)
                    {
                        buffer = new byte[stream.Length - stream.Position];
                        stream.Read(buffer, 0, buffer.Length);
                        return encoding.GetString(buffer);
                    }
                }
            }
            return null;
        }
        public void Dispose()
        {
            if (FSWatcher != null)
            {
                FSWatcher.FileCreatedEvent -= OnFileCreatedEvent;
                FSWatcher.FileChangedEvent -= OnFileChangedEvent;
                FSWatcher.FileDeletedEvent -= OnFileDeletedEvent;
                FSWatcher.Dispose();
            }
        }
        public class Log {
            public FileInfo File { get; set; }
            public string LastLine { get; set; }
            public Log(FileInfo file) {
                File = file;
            }
        }
    }
}
