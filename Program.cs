using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VRChatLauncher.Utils;

namespace VRChatLauncher
{
    class Program
    {
        public static Main mainWindow;
        public static IPC.Launcher ipc;
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Logger.Init();
            Logger.Trace("START");
            ipc = new IPC.Launcher(); ipc.Init();
            var args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            if (args.Length > 0) Logger.Warn("Catched command line arguments:");
            for (int i = 0; i < args.Length; i++)
            {
                Logger.Warn($"[{i}]", args[i]);
            }
            var msg = ipc.MakeRemoteRequestWithResponse(new IPC.Launcher.Message($"islauncherrunning {string.Join(" ", args)}"), 200);
            var launcher_running = Utils.Utils.IsLauncherAlreadyRunning();
            Logger.Log("Launcher already running:", launcher_running.ToString());
            if (msg.Str == "yes" || launcher_running) {
                Logger.Fatal("Launcher already running, exiting...");
                Utils.Utils.Exit();return;
            }
            var game_running = Game.IsGameAlreadyRunning();
            Logger.Log("Game already running:", game_running.ToString());
            if(!game_running) {
                var argstr = string.Join(" ", args);
                if (argstr.ToLower().Contains("skiplauncher=true")) {
                    Logger.Warn("Found \"skiplauncher=true\" in arguments, tunneling directly...");
                    Game.StartGame(args: args);
                    Utils.Utils.Exit();
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainWindow = new Main(args);
            Application.Run(mainWindow);
            Logger.Trace("END");
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            Logger.Log("Exiting...");
            // LogReader.Dispose();
            // IPC.Launcher.Dispose();
        }
    }
}
