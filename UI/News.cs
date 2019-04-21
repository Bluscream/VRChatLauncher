using System;

namespace VRChatLauncher
{
    partial class Main
    {
        private const string newsurl = "https://github.com/Bluscream/VRChatLauncher/raw/master/News.rtf";
        public void LoadNews() {
            try
            {
                txt_news.Rtf = webClient.DownloadString(newsurl);
            } catch (Exception ex) {
                Utils.Logger.Error(ex);
                txt_news.Rtf = "Could not load news, more infos in the console/log file.";
            }
        }
    }
}
