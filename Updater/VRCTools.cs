using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VRChatLauncher.Utils;
using static VRChatLauncher.Utils.Mods;

namespace VRChatLauncher.Updater
{
    public class VRCTools
    {
        
        private static bool needUpdate = false;
        private static string vrctoolsPath = null;

        private static bool errored = false;
        private static int errorCode = -1;
        public static Mod CheckForUpdate(Mod mod) // https://vrchat.survival-machines.fr/vrcmod/VRCToolsHashCheck.php?localhash=fd7d02ff07940b4617c0e333f2434021
        {
            return mod;
        }
        public static Mod Update(Mod mod)
        {
            return mod;
        }
        /*
        internal static bool CheckForVRCToolsUpdate()
        {
            vrctoolsPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) + "\\Mods\\VRCTools.dll";
            Directory.CreateDirectory(Path.GetDirectoryName(vrctoolsPath));
            Logger.Log("[VRCToolsUpdater] Supposed VRCToolsPath path: " + vrctoolsPath);

            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg.ToLower().Equals("--vrctools.forceupdate")) return true;
                if (arg.ToLower().Equals("--vrctools.noupdate")) return false;
            }

            //hash check
            string fileHash = "";

            if (File.Exists(vrctoolsPath))
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(vrctoolsPath))
                    {
                        var hash = md5.ComputeHash(stream);
                        fileHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
                Logger.Log("[VRCToolsUpdater] Local VRCToolsPath file hash: " + fileHash);

                WebClient webClient = new WebClient();
                var hashCheckWWW = webClient.DownloadString("https://vrchat.survival-machines.fr/vrcmod/VRCToolsHashCheck.php?localhash=" + fileHash); // MOD UNITY
                // while (!hashCheckWWW.isDone) ;
                int responseCode = getResponseCode(hashCheckWWW);
                Logger.Log("[VRCToolsUpdater] hash check webpage returned [" + responseCode + " / " + hashCheckWWW.error + "] \"" + hashCheckWWW.text + "\"");
                if (responseCode != 200) {
                    errored = true;
                    errorCode = responseCode;
                    return true;
                }
                else if(hashCheckWWW.text.Equals("OUTOFDATE"))
                {
                    Logger.Log("[VRCToolsUpdater] Update of VRCTools available");
                    return true;
                }
            }
            else
            {
                Logger.Log("[VRCToolsUpdater] Download of VRCTools required");
                return true;
            }

            return false;
            
        }

        internal static void SheduleVRCToolsUpdate()
        {
            if (!errored)
            {
                Logger.Log("[VRCToolsUpdater] Sheduling update");
                needUpdate = true;
            }
        }

        internal static IEnumerator UpdateAndRebootIfRequired()
        {
            if (needUpdate || errored)
            {
                bool goForUpdate = needUpdate;
                needUpdate = false;
                Logger.Log("[VRCToolsUpdater] Looking for VRCFlowManager");
                VRCFlowManager[] flowManagers = Resources.FindObjectsOfTypeAll<VRCFlowManager>();
                foreach(VRCFlowManager flowManager in flowManagers)
                {
                    flowManager.enabled = false;
                }
                Logger.Log("[VRCToolsUpdater] Disabled " + flowManagers.Length + " VRCFlowManager");


                if (GameObject.Find("UserInterface") == null)
                {
                    Logger.Log("[VRCToolsUpdater] Loading additive scene \"ui\"");
                    SceneManager.LoadScene("ui", LoadSceneMode.Single);
                }

                if (goForUpdate)
                {
                    needUpdate = false;

                    bool choiceDone = false;
                    bool update = false;
                    yield return ShowPopup("VRCTools Updater", "A VRCTools update is available", "Update", () => {
                        choiceDone = true;
                        update = true;
                    }, "Ignore", () => {
                        choiceDone = true;
                    });
                    yield return new WaitUntil(() => choiceDone);

                    if (update)
                    {
                        yield return ShowUpdatePopup();

                        Logger.Log("[VRCToolsUpdater] Update popup shown");

                        WWW vrctoolsDownload = new WWW("https://vrchat.survival-machines.fr/vrcmod/VRCTools.dll");
                        yield return vrctoolsDownload;
                        while (!vrctoolsDownload.isDone)
                        {
                            Logger.Log("[VRCToolsUpdater] Download progress: " + vrctoolsDownload.progress);
                            downloadProgressFillImage.fillAmount = vrctoolsDownload.progress;
                            yield return null;
                        }

                        int responseCode = getResponseCode(vrctoolsDownload);
                        Logger.Log("[VRCToolsUpdater] Download done ! response code: " + responseCode);
                        Logger.Log("[VRCToolsUpdater] File size: " + vrctoolsDownload.bytes.Length);

                        if (responseCode == 200)
                        {
                            yield return ShowPopup("VRCTools Updater", "Saving VRCTools");
                            Logger.Log("[VRCToolsUpdater] Saving file");
                            File.WriteAllBytes(vrctoolsPath, vrctoolsDownload.bytes);

                            Logger.Log("[VRCToolsUpdater] Showing restart dialog");
                            choiceDone = false;
                            yield return ShowPopup("VRCTools Updater", "Update downloaded", "Restart", () => {
                                choiceDone = true;
                            });
                            yield return new WaitUntil(() => choiceDone);

                            yield return ShowPopup("VRCTools Updater", "Restarting game");
                            Logger.Log("[VRCToolsUpdater] Rebooting game");
                            string args = "";
                            bool first = true;
                            foreach (string arg in Environment.GetCommandLineArgs())
                            {
                                if (first) first = false;
                                else args = args + arg + " ";
                            }

                            Thread t = new Thread(() =>
                            {
                                Thread.Sleep(1000);
                                System.Diagnostics.Process.Start(Path.GetDirectoryName(Path.GetDirectoryName(vrctoolsPath)) + "\\VRChat.exe", args);
                                Thread.Sleep(100);
                            });
                            t.Start();

                            Application.Quit();
                        }
                        else
                        {
                            yield return ShowErrorPopup("Unable to update VRCTools: Server returned code " + responseCode);
                        }
                    }
                    else
                    {
                        uiPopupManagerInstance.HideCurrentPopup();
                        foreach (VRCFlowManager flowManager in flowManagers)
                        {
                            flowManager.enabled = true;
                        }
                        Logger.Log("[VRCToolsUpdater] Enabled " + flowManagers.Length + " VRCFlowManager");
                    }
                    
                }
                else if (errored)
                {

                    yield return ShowErrorPopup("Unable to check VRCTools validity: Server returned code " + errorCode);

                }
            }
        }






        

        public static int getResponseCode(WebClient request)
        {
            int ret = 0;
            if (request.ResponseHeaders == null)
            {
                Logger.Error("no response headers.");
            }
            else
            {
                if (!request.ResponseHeaders.AllKeys.Contains("STATUS"))
                {
                    Logger.Error("response headers has no STATUS.");
                }
                else
                {
                    ret = parseResponseCode(request.ResponseHeaders["STATUS"]);
                }
            }

            return ret;
        }

        public static int parseResponseCode(string statusLine)
        {
            int ret = 0;

            string[] components = statusLine.Split(' ');
            if (components.Length < 3)
            {
                Logger.Error("invalid response status: " + statusLine);
            }
            else
            {
                if (!int.TryParse(components[1], out ret))
                {
                    Logger.Error("invalid response code: " + components[1]);
                }
            }

            return ret;
        }*/
    }
}
