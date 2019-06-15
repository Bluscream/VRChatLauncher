using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRChatApi.Classes;
using VRChatLauncher.Utils;

namespace VRChatLauncher.UI
{
    public partial class ChatWindow : Form
    {
        private UserResponse me; private VRChatApi.VRChatApi vrcapi;
        public ChatWindow(VRChatApi.VRChatApi Vrcapi, UserResponse Me)
        {
            me = Me; vrcapi = Vrcapi;
            InitializeComponent();
        }
        public void AddChat(UserBriefResponse user)
        {
            BringUp();
            var chatId = $"chat_{user.id}";
            if (tabs_chat.TabPages.ContainsKey(chatId))
            {
                tabs_chat.SelectedIndex = tabs_chat.TabPages.IndexOfKey(chatId);
                return;
            }
            var tab = new TabPage();
            tab.Text = user.displayName;
            tab.Name = chatId;
            tab.Tag = new TabTag(user, DateTime.Now, TargetType.User);
            tab.TabIndex = tabs_chat.TabPages.Count;
            tab.MouseClick += Tab_MouseClick;
            var lst_messages = new ListBox();
            lst_messages.Dock = DockStyle.Fill;
            lst_messages.FormattingEnabled = true;
            lst_messages.Location = new Point(3, 3);
            // lst_messages.Name = 
            lst_messages.Size = new Size(546, 243);
            tab.Controls.Add(lst_messages);
            tabs_chat.Controls.Add(tab);
            tabs_chat.SelectTab(tab.TabIndex); // Select Tab
            this.Text = $"Chat with {user.displayName}";
            txt_chat_input.Focus();
            var tag = (TabTag)tab.Tag;
            LogLine(chatId, tag.SessionStart, $"Chat session with {user.displayName.Quote()} started.");
        }

        private void BringUp()
        {
            if (WindowState == FormWindowState.Minimized) {
                WindowState = FormWindowState.Normal;
            } else {
                TopMost = true;
                Focus();
                BringToFront();
                TopMost = false;
            }
        }

        private void Tab_MouseClick(object sender, MouseEventArgs e)
        {
            Logger.Debug("Tab_MouseClick");
            if (e.Button == MouseButtons.Middle) {
            Logger.Debug(e.Button);
                var tab = (TabPage)sender;
                Logger.Debug(tab.Name);
                tabs_chat.TabPages.RemoveByKey(tab.Name);
            }
        }

        private void Txt_chat_input_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var chatId = tabs_chat.SelectedTab.Name;
                SendMessageAsync(chatId, txt_chat_input.Text);
                txt_chat_input.Clear();
                e.Handled = true;
            }
        }
        private void Btn_send_Click(object sender, EventArgs e)
        {
            var chatId = tabs_chat.SelectedTab.Name;
            SendMessageAsync(chatId, txt_chat_input.Text);
            txt_chat_input.Clear();
        }
        private async void SendMessageAsync(string chatId, string message)
        {
            if (string.IsNullOrWhiteSpace(message)) { return; }
            var timestamp = DateTime.Now;
            var fullmessage = $"| Chat Message from \"{me.displayName}\"\nAt: {timestamp}\n{message}";
            var notification = await vrcapi.FriendsApi.SendMessage(chatId.Replace("chat_", ""), fullmessage, "Chatting provided by github.com/Bluscream/VRCLauncher");
            Logger.Debug(notification);
            var line = $"{me.displayName}: {message}";
            LogLine(chatId, timestamp, line);
        }
        private void LogLine(string chatId, DateTime dateTime, string text)
        {
            if (string.IsNullOrWhiteSpace(text)) { return; }
            string timestamp = dateTime.ToString("HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            var line = $"[{timestamp}] {text}";
            var chatList = ChatById(chatId).MessageList;
            chatList.Items.Add(line);
        }

        private Chat ChatById(string chatId)
        {
            var chatIndex = tabs_chat.TabPages.IndexOfKey(chatId);
            var tabTag = tabs_chat.TabPages[chatIndex].Tag;
            var messageList = tabs_chat.TabPages[chatIndex].Controls[0];
            return new Chat(tabs_chat.TabPages[chatIndex], (TabTag)tabTag, (ListBox)messageList);
        }

        private void Tabs_chat_Selected(object sender, TabControlEventArgs e)
        {
            var tag = (TabTag)e.TabPage.Tag;
            this.Text = $"Chat with {tag.Target.displayName}";
        }
        private class Chat
        {
            public TabPage Tab { get; set; }
            public TabTag Tag { get; set; }
            public ListBox MessageList { get; set; }
            public Chat(TabPage tab, TabTag tag, ListBox messageList)
            {
                Tab = tab; Tag = tag; MessageList = messageList;
            }
        }
        public enum TargetType
        {
            Unknown, User, Group, Instance, World, Global
        }
        public class TabTag
        {
            public TargetType Type { get; set; }
            public UserBriefResponse Target { get; set; }
            public DateTime SessionStart { get; set; }
            public TabTag(UserBriefResponse target, DateTime sessionStart, TargetType type = TargetType.Unknown)
            {
                Target = target; SessionStart = sessionStart; Type = type;
            }
        }
    }
}
