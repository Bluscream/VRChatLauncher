﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VRChatLauncher.Utils;

namespace VRChatLauncher
{
    public class Program
    {
        public static Main mainWindow;
        public IPC.Launcher ipc;
        public Arguments Arguments;
        [STAThread]
        static void Main(string[] args)
        {
            var prog = new Program();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Logger.Init();
            Logger.Trace("START");
            prog.ipc = new IPC.Launcher(); prog.ipc.Init();
            // var args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            /*if (args.Length > 0) Logger.Warn("Catched command line arguments:");
            for (int i = 0; i < args.Length; i++)
            {
                Logger.Warn($"[{i}]", args[i]);
            }*/
            prog.Arguments = Arguments.FromArgs(args.ToList());
            // Logger.Warn("Parsed Command Line Arguments", prog.Arguments.ToJson());
            var msg = prog.ipc.MakeRemoteRequestWithResponse(new IPC.Launcher.Message($"islauncherrunning {string.Join(" ", args)}"), 200);
            var launcher_running = Utils.Utils.IsLauncherAlreadyRunning();
            var keep_open = prog.Arguments.Launcher.KeepOpen.IsTrue();
            /*if (keep_open) {
                var firstAfter = args.SkipWhile(p => p != "--vrclauncher.keep").ElementAt(1);
                Logger.Warn("firstAfter", firstAfter);
            }*/
            Logger.Log("Launcher already running:", launcher_running.ToString());
            if ((msg.Str == "yes" || launcher_running) && !keep_open) {
                Logger.Fatal("Launcher already running, exiting...");
                Utils.Utils.Exit();return;
            }
            Logger.ClearLog();
            var game_running = Game.IsGameAlreadyRunning();
            Logger.Log("Game already running:", game_running.ToString());
            if(!game_running) {
                if (prog.Arguments.Launcher.Skip.IsTrue()) {
                    Logger.Warn("Found \"skiplauncher=true\" in arguments, tunneling directly...");
                    Game.StartGame(args: args);
                    Utils.Utils.Exit();
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainWindow = new Main(prog);
            Application.Run(mainWindow);
            Logger.Trace("END");
            OnProcessExit(false, new EventArgs());
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            Logger.Log("Exiting...");
            // LogReader.Dispose();
            // IPC.Launcher.Dispose();
            ExternalConsole.Dispose();
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }
    }
}
