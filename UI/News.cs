using Newtonsoft.Json;
using System;
using System.Net;

namespace VRChatLauncher
{
    partial class Main
    {
        private const string newsurl = "https://github.com/Bluscream/VRChatLauncher/raw/master/News.rtf";
        public void LoadNews() {
            try {
                
                using (var wc = new WebClient())
                {
                SetNews(wc.DownloadString(newsurl));
                }
            } catch (Exception ex) {
                Utils.Logger.Error(ex);
                SetNews("Could not load news, more infos in the console/log file.");
            }
        }
        public class NewsItem
        {
            public Notify Notify { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
            [JsonProperty(PropertyName = "timestamp")]
            public string time_stamp { get;  set; }
            [JsonIgnore]
            public DateTime TimeStamp { get { return Convert.ToDateTime(time_stamp); } }
        }
        public class Notify {
            [JsonProperty(PropertyName = "add_to_feed")]
            public bool AddToFeed { get; set; }
            [JsonProperty(PropertyName = "show_notification")]
            public bool ShowNotification { get; set; }
            [JsonProperty(PropertyName = "show_modal")]
            public bool ShowModal { get; set; }
            [JsonProperty(PropertyName = "show_modal_while_game_running")]
            public bool ShowModalWhileGameRunning { get; set; }
        }
    }
}
