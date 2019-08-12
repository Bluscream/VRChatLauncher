using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Net;

namespace VRChatLauncher.Utils
{
    public static partial class Utils
    {
        static FileInfo ownBinary;
        static FileInfo gameBinary;
        public static FileInfo getOwnPath()
        {
            if (ownBinary == null) {
                ownBinary = new FileInfo(Path.GetFullPath(Application.ExecutablePath));
            }
            return ownBinary;
        }
        public static  FileInfo getGamePath()
        {
            if (gameBinary == null) {
                var ownPath = Path.GetDirectoryName(Application.ExecutablePath);
                var gamePath = Path.Combine(ownPath, "VRChat.exe");
                gameBinary = new FileInfo(gamePath);
            }
            return gameBinary;
        }
        /*[DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);*/
        public static void BringSelfToFront()
        {
            var window = Program.mainWindow;
            if (window.WindowState == FormWindowState.Minimized)
                window.WindowState = FormWindowState.Normal;
            else
            {
                window.TopMost = true;
                window.Focus();
                window.BringToFront();
                window.TopMost = false;
            }
            /*Program.mainWindow.Activate();
            Program.mainWindow.Focus();
            Program.mainWindow.Focus();*/
            // SetForegroundWindow(SafeHandle.ToInt32());
        }
        public static bool IsLauncherAlreadyRunning()
        {
            System.Threading.Mutex m = new System.Threading.Mutex(false, "Launcher");
            if (m.WaitOne(1, false) == false)
            {
                return true;
            }
            return false;
        }
        internal static void Exit()
        {
            Application.Exit();
            var currentP = Process.GetCurrentProcess();
            currentP.Kill();
        }
        public static void RestartAsAdmin()
        {
            if (IsAdmin()) return;
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Assembly.GetEntryAssembly().CodeBase;
            proc.Arguments += Program.Arguments.ToString();
            proc.Verb = "runas";
            try
            {
                /*new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Process.Start(proc);
                }).Start();*/
                Process.Start(proc);
                Exit();
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to restart as admin!", ex.Message);
                MessageBox.Show("Unable to restart as admin for you. Please do this manually now!", "Can't restart as admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit();
            }
        }
        internal static bool IsAdmin()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }
        public static string Base64Encode(string plainText) {
          var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
          return Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData) {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static FileInfo DownloadFile(string url, DirectoryInfo destinationPath, string fileName = null) {
            if (fileName == null) fileName = url.Split('/').Last();
            Main.webClient.DownloadFile(url, Path.Combine(destinationPath.FullName, fileName));
            return new FileInfo(Path.Combine(destinationPath.FullName, fileName));
        }
        public static void ShowFileInExplorer(FileInfo file) {
            StartProcess("explorer.exe", null, "/select, "+file.FullName.Quote());
        }
        public static Process StartProcess(FileInfo file, params string[] args) => StartProcess(file.FullName, file.DirectoryName, args);
        public static Process StartProcess(string file, string workDir = null, params string[] args) {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = file;
            proc.Arguments = string.Join(" ", args);
            Logger.Debug(proc.FileName, proc.Arguments);
            if (workDir != null) {
                proc.WorkingDirectory = workDir;
                Logger.Debug("WorkingDirectory:", proc.WorkingDirectory);
            }
            return Process.Start(proc);
        }
    }
}
