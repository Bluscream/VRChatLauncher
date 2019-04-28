using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VRChatLauncher.Utils;
using VRChatApi.Classes;
using System.Drawing;
using System.Collections;
using System.Linq;
using static VRChatLauncher.IPC.Game;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace VRChatLauncher
{
    partial class Main
    {
        public static UserResponse me;
        public static DateTime users_last_update;
        public static bool users_loading = false;

        public enum UserRank {
            Admin, Moderator, Legend, Veteran, Trusted, Known, User, New, Visitor, ProbableTroll, Troll
        }

        private UserRank RankFromTags(List<string> tags)
        {
            if (tags.Contains("admin_moderator")) return UserRank.Moderator;
            if (tags.Contains("system_troll")) return UserRank.Troll;
            if (tags.Contains("system_probable_troll")) return UserRank.ProbableTroll;
            // if (tags.Contains("system_trust_legend")) return UserRank.Legend;
            if (tags.Contains("system_trust_veteran")) return UserRank.Veteran;
            if (tags.Contains("system_trust_trusted")) return UserRank.Trusted;
            if (tags.Contains("system_trust_known")) return UserRank.Known;
            if (tags.Contains("system_trust_basic")) return UserRank.User;
            return UserRank.Visitor;
        }

        private TreeNode SetNodeColorFromTags(TreeNode node, List<string> tags)
        {
            if (tags.Contains("system_trust_basic")) node.ForeColor = Color.Blue;
            if (tags.Contains("system_trust_known")) node.ForeColor = Color.Green;
            if (tags.Contains("system_trust_trusted")) node.ForeColor = Color.Orange;
            if (tags.Contains("system_trust_veteran")) node.ForeColor = Color.DeepPink;
            if (tags.Contains("system_trust_legend")) node.ForeColor = Color.Gold;
            if (tags.Contains("system_probable_troll")) node.ForeColor = Color.Red;
            if (tags.Contains("system_troll")) node.ForeColor = Color.DarkRed;
            if (tags.Contains("admin_moderator")) node.BackColor = Color.Red;
            return node;
        }

         class NodeSorter : IComparer {
            public int Compare(object x, object y) 
            {         
                TreeNode tx = (TreeNode)x; 
                TreeNode ty = (TreeNode)y;

                if (tx.Text.Length < ty.Text.Length)
                {
                    return -1;
                }

                if (tx.Text.Length > ty.Text.Length)
                {
                    return 1;
                }

                return 0;
            } 
        }

        public async void SetupUsersAsync(bool force = false) {
            if (users_loading) { Logger.Warn("Users are already loading, try again later");  return; }
            users_loading = true;var friends = new List<UserBriefResponse>();
            var onlinenode = tree_users.Nodes[1].Nodes[0];
            onlinenode.Nodes.Clear();
            tree_users.Nodes[2].Nodes.Clear();
            tree_users.Nodes[3].Nodes.Clear();
            if (me != null)  {
                if (force) { me = await vrcapi.UserApi.UpdateInfo(me.id); }
                Logger.Debug("Me: ", me.ToJson());
                SetNodeColorFromTags(tree_users.Nodes[0], me.tags);
                tree_users.Nodes[0].Text = me.displayName;
                tree_users.Nodes[0].Tag = me;
                tree_users.Nodes[1].Text = $"Friends ({me.friends.Count})";
                // tree_users.Nodes[1].Tag = me.friends;
            }
            if (users_last_update == null || users_last_update.ExpiredSince(3) || force) {
                var offset = 0;
                for (int i = 0; i < 10; i++)
                {
                    Logger.Debug(i, "Getting online friends", offset, "to", offset + 100);
                    var friends_part = await vrcapi.FriendsApi.Get(offset, 100, false);
                    if (friends_part == null) break;
                    /*Logger.Trace(response.ToJson());
                    if (response.Banned) {
                        MessageBox.Show($"Banned until {response.Expires}!");
                        return;
                    }*/
                    // var friends_part = (List<UserBriefResponse>)response.Content;
                    friends.AddRange(friends_part);
                    Logger.Debug(i, "Got", friends_part.Count, "online friends");
                    if (friends_part.Count < 100) break;
                    offset += 100;
                }
                friends = friends.OrderBy(o=>o.displayName).ToList();
                friends = friends.OrderBy(o=>o.location).Reverse().ToList();
                Logger.Log("Downloaded list of", friends.Count, "official online friends");
                foreach (var friend in friends)
                {
                    var node = new TreeNode(friend.displayName);
                    node.Tag = friend;
                    SetNodeColorFromTags(node, friend.tags);
                    if (friend.location == "offline") {
                        tree_users.Nodes[1].Nodes[1].Nodes.Add(node);
                    } else { tree_users.Nodes[1].Nodes[0].Nodes.Add(node); }
                }
                //  tree_users.Nodes[1].Text = $"Friends ({onlinenode.Nodes.Count + offlinenode.Nodes.Count})";
                onlinenode.Text = $"Online ({onlinenode.Nodes.Count})";
            }
            // tree_users.TreeViewNodeSorter = new NodeSorter();
            // tree_users.Sort(onlinenode);
            users_loading = false;
        }
        public async void FillOfflineFriends() {
            var offlinenode = tree_users.Nodes[1].Nodes[1];
            offlinenode.Nodes.Clear();
            var friends = new List<UserBriefResponse>();
            var offset = 0;
            for (int i = 0; i < 15; i++)
            {
                Logger.Debug(i, "Getting offline friends", offset, "to", offset + 100);
                var friends_part = await vrcapi.FriendsApi.Get(offset, 100, true);
                if (friends_part == null) break;
                // var friends_part = (List<UserBriefResponse>)response.Content;
                friends.AddRange(friends_part);
                Logger.Debug(i, "Got", friends_part.Count, "offline friends");
                if (friends_part.Count < 100) break;
                offset += 100;
            }
            friends = friends.OrderBy(o=>o.location).ToList();
            friends = friends.OrderBy(o=>o.displayName).ToList();
            Logger.Log("Downloaded list of", friends.Count, "official offline friends");
            foreach (var friend in friends)
            {
                var node = new TreeNode(friend.displayName);
                node.Tag = friend;
                SetNodeColorFromTags(node, friend.tags);
                tree_users.Nodes[1].Nodes[1].Nodes.Add(node);
            }
            offlinenode.Text = $"Offline ({offlinenode.Nodes.Count})";
        }

        private void FillUser(UserBriefResponse user)
        {
            txt_users_id.Text = user.id;
            txt_users_id.Tag = user;
            txt_users_displayname.Text = user.displayName;
            txt_users_username.Text = user.username;
            txt_users_status.Text = user.statusDescription;
            txt_users_rank.Text = RankFromTags(user.tags).ToString();
            txt_users_tags.Text = user.tags.ToJson().ToString();
            txt_users_location.Text = user.location;
            if (tree_users.Nodes[0].Tag != null)
            {
                var me = (UserResponse)tree_users.Nodes[0].Tag;
                if (user.id == me.id) { btn_users_save.Visible = true; } else { btn_users_save.Visible = false; }
            }
        }

        private void FillUser(UserResponse user)
        {
            FillUser((UserBriefResponse)user);
        }

        private void users_node_selected(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Text == "Offline")
                {
                    FillOfflineFriends();
                    return;
                }
                if (e.Node.Tag == null) return;
                if (e.Node.Tag is UserResponse)
                {
                    var user = (UserResponse)e.Node.Tag; FillUser(user);
                }
                else if (e.Node.Tag is UserBriefResponse)
                {
                    var user = (UserBriefResponse)e.Node.Tag; FillUser(user);
                }
            } else if (e.Button == MouseButtons.Right) {
                tree_users.SelectedNode = e.Node;
                for (int i = 0; i < 5; i++) { menu_users.Items[i].Visible = false; }
                if(e.Node.Text.StartsWith("Friends ("))
                {
                    menu_users.Items[3].Visible = true; menu_users.Items[4].Visible = true;
                    menu_users.Show(tree_users, e.Location);
                }
            }
        }
        private async void Btn_users_search_ClickAsync(object sender, EventArgs e)
        {
            var user = await vrcapi.UserApi.GetById(txt_users_id.Text);
            FillUser(user);
        }

        private void Btn_users_search_name_Click(object sender, EventArgs e)
        {

        }

        private void Btn_user_join_Click(object sender, EventArgs e)
        {
            if(txt_users_location.Text == "offline") { MessageBox.Show($"{txt_users_displayname.Text} is offline. You can't join them!", "User offline", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            else if(txt_users_location.Text == "private") { MessageBox.Show($"{txt_users_displayname.Text} is in a private world. You can't join them!", "User in private world!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            var worldinstance = new WorldInstanceID(txt_users_location.Text);
            var cmd = new Command(CommandType.Launch, worldInstanceID: worldinstance); // , referrer: "vrclauncher"
            Send(cmd);
        }

        private void Btn_users_reload_Click(object sender, EventArgs e)
        {
            if(me != null && me.id == null) { LoginVRCAPI(); }
            SetupUsersAsync(true);
            FillOfflineFriends();
        }

        private void btn_users_save_click(object sender, EventArgs e)
        {

        }

        private void Btn_users_friend_add_Click(object sender, EventArgs e)
        {

        }

        private void Btn_users_friend_remove_Click(object sender, EventArgs e)
        {

        }

        private void Btn_users_block_Click(object sender, EventArgs e)
        {

        }

        private void Btn_users_unblock_Click(object sender, EventArgs e)
        {

        }

        private void Menu_item_exportfriends_Click(object sender, EventArgs e)
        {
            if (me == null) return;
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = $"Export {me.friends.Count} Friends";
            savefile.FileName = $"friends_{me.username}.txt";
            savefile.Filter = "Friends list|*.txt";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                var file = new FileInfo(savefile.FileName);
                Logger.Warn("Extenstion:", file.Extension);
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                {
                    sw.Write(string.Join(Environment.NewLine, me.friends));
                }
            }
        }
        public int AddFriends(List<string> ids)
        {
            var toAdd = ids.Except(me.friends).ToList();
            toAdd.RemoveAll(item => !item.StartsWith("usr_"));
            var skipped = ids.Count - toAdd.Count;
            Logger.Debug("ids:", ids.Count, "toAdd:", toAdd.Count, "skipped:", skipped);
            if (toAdd.Count > 1)
            {
                var confirmResult = MessageBox.Show($"You're about to send {toAdd.Count} friend requests, this will flood the API quite a bit!\n\nStart adding now?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes) { return 0; }
            }
            else if (toAdd.Count < 1) return 0;
            progress_status.Visible = true;
            progress_status.Maximum = toAdd.Count;
            progress_status.Step = 1;
            progress_status.Value = 0;
            // bgWorker.RunWorkerAsync();
            new Thread(async () =>
            {
                Thread.CurrentThread.IsBackground = true;
                foreach (var friend in toAdd)
                {
                    Logger.Log("Adding friend", progress_status.Value + 1, "/", toAdd.Count, friend.Enclose());
                    progress_status.PerformStep();
                    var notification = await vrcapi.FriendsApi.SendRequest(friend, me.id);
                    Logger.Log(notification.ToJson());
                    Thread.Sleep(1000);
                }
            }).Start();
            progress_status.Visible = false;
            return progress_status.Value;
        }

        /*private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            for (int j = 0; j < 100000; j++)
            {
                Calculate(j);
                backgroundWorker.ReportProgress((j * 100) / 100000);
            }
        }*/

        private void Menu_item_importfriends_Click(object sender, EventArgs e)
        {
            var fileSelector = new OpenFileDialog();
            fileSelector.Title = "Import friends";
            fileSelector.Filter = "Friends list|*.txt";
            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                var file = new FileInfo(fileSelector.FileName);
                if (!file.Exists) { MessageBox.Show("File does not exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);  return; }
                var toImport = new List<string>(File.ReadAllLines(file.FullName));
                var imported = AddFriends(toImport);
                MessageBox.Show($"Sent {imported} friend requests", "Import finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
