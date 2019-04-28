﻿using System;
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
        public static bool requests_loading = false;

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
        public async void FillMe(bool update = true) {
            if (me != null)  {
                if (update) me = await vrcapi.UserApi.UpdateInfo(me.id);
                Logger.Debug("Me: ", me.ToJson());
                SetNodeColorFromTags(tree_users.Nodes[0], me.tags);
                tree_users.Nodes[0].Text = me.displayName;
                tree_users.Nodes[0].Tag = me;
                tree_users.Nodes[1].Text = $"Friends ({me.friends.Count})";
                // tree_users.Nodes[1].Tag = me.friends;
            }
        }

        public async void SetupUsersAsync(bool force = false) {
            if (users_loading) { Logger.Warn("Users are already loading, try again later");  return; }
            users_loading = true;var friends = new List<UserBriefResponse>();
            FillMe();
            var onlinenode = tree_users.Nodes[1].Nodes[0];
            onlinenode.Nodes.Clear();
            tree_users.Nodes[2].Nodes.Clear();
            if (users_last_update == null || users_last_update.ExpiredSince(3) || force) {
                var offset = 0;
                for (int i = 0; i < 10; i++)
                {
                    Logger.Debug(i, "Getting online friends", offset, "to", offset + 100);
                    var friends_part = await vrcapi.FriendsApi.Get(offset, 100, false);
                    if (friends_part == null) break;
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
                users_last_update = DateTime.Now;
            }
            // tree_users.TreeViewNodeSorter = new NodeSorter();
            // tree_users.Sort(onlinenode);
            users_loading = false;
            FillRequests();
        }
        public async void FillRequests() {
            if (requests_loading) { Logger.Warn("Users are already loading, try again later");  return; }
            requests_loading = true;
            var requests_node = tree_users.Nodes[3];
            var incoming_node = tree_users.Nodes[3].Nodes[0];
            var outgoing_node = tree_users.Nodes[3].Nodes[1];
            incoming_node.Nodes.Clear();
            var incoming_requests = await vrcapi.NotificationsAPI.GetAll("friendRequest", false);
            Logger.Log("Downloaded list of", incoming_requests.Count, "incoming friend requests");
            foreach (var request in incoming_requests)
            {
                Logger.Trace(request.ToJson());
                // var user = await vrcapi.UserApi.GetById(request.SenderUserId);
                var node = new TreeNode(request.SenderUsername);
                node.Tag = request;
                // SetNodeColorFromTags(node, user.tags);
                incoming_node.Nodes.Add(node);
            }
            incoming_node.Text = $"Incoming ({incoming_node.Nodes.Count})";
            outgoing_node.Nodes.Clear();
            var outgoing_requests = await vrcapi.NotificationsAPI.GetAll(type: "friendRequest", sent: true);
            Logger.Log("Downloaded list of", outgoing_requests.Count, "outgoing friend requests");
            foreach (var request in outgoing_requests)
            {
                Logger.Trace(request.ToJson());
                // var user = await vrcapi.UserApi.GetById(request.ReceiverUserId);
                var node = new TreeNode(request.Id);
                node.Tag = request; //node.Tag = new Tuple<NotificationResponse, UserBriefResponse>(request, user);
                // SetNodeColorFromTags(node, user.tags);
                outgoing_node.Nodes.Add(node);
            }
            outgoing_node.Text = $"Outgoing ({outgoing_node.Nodes.Count})";
            requests_node.Text = $"Requests ({incoming_node.Nodes.Count + outgoing_node.Nodes.Count})";
            requests_loading = false;
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
                for (int i = 0; i < menu_users.Items.Count; i++) { menu_users.Items[i].Visible = false; }
                if(e.Node.Text.StartsWith("Friends ("))
                {
                    menu_users.Items[5].Visible = true; menu_users.Items[6].Visible = true;
                    menu_users.Show(tree_users, e.Location);
                    return;
                }
                if(e.Node.Tag != null)
                {
                    if (e.Node.Tag is UserBriefResponse) {
                        var user = (UserBriefResponse)e.Node.Tag;
                        // if (e.Node.Parent.Text.StartsWith("Online (") || e.Node.Parent.Text.StartsWith("Offline (")) {
                        if (!me.friends.Contains(user.id)) {
                            menu_users.Items[1].Visible = true;
                        } else {
                            menu_users.Items[2].Visible = true;
                        }
                        menu_users.Items[0].Visible = true; menu_users.Items[3].Visible = true;
                        menu_users.Show(tree_users, e.Location);
                    } else if (e.Node.Tag is UserResponse) {
                        // var user = (UserResponse)e.Node.Tag;
                    }
                }
            }
        }
        private async void Btn_users_search_ClickAsync(object sender, EventArgs e)
        {
            var user = await vrcapi.UserApi.GetById(txt_users_id.Text);
            FillUser(user);
        }

        private async void Btn_users_search_name_ClickAsync(object sender, EventArgs e)
        {
            var users = await vrcapi.UserApi.Search(txt_users_displayname.Text);
            users = users.OrderBy(o=>o.displayName).ToList();
            tree_users.Nodes[4].Nodes.Clear();
            foreach (var user in users)
            {
                var node = new TreeNode(user.displayName);
                node.Tag = user;
                SetNodeColorFromTags(node, user.tags);
                tree_users.Nodes[4].Nodes.Add(node);
            }
            tree_users.Nodes[4].Expand();
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
            MessageBox.Show("btn_users_save_click");
        }

        private async void Btn_users_friend_add_ClickAsync(object sender, EventArgs e)
        {
            var notification = await vrcapi.FriendsApi.SendRequest(txt_users_id.Text);
            Logger.Log(notification.ToJson());
            MessageBox.Show($"Sent friend request to {txt_users_displayname.Text}", "Friend Request sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void Btn_users_friend_remove_ClickAsync(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show($"Are you sure you want to remove {txt_users_displayname.Text} from your friendlist?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) { return ; }
            var notification = await vrcapi.FriendsApi.DeleteFriend(txt_users_id.Text);
            Logger.Log(notification.ToJson());
            MessageBox.Show($"Unfriended {txt_users_displayname.Text}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_users_block_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Btn_users_block_Click");
        }

        private void Btn_users_unblock_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Btn_users_unblock_Click");
        }

        private void ProfileMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ProfileMenuItem_Click");
        }

        private async void Menu_item_friend_add_ClickAsync(object sender, EventArgs e)
        {
            var user = (UserBriefResponse)tree_users.SelectedNode.Tag;
            var notification = await vrcapi.FriendsApi.SendRequest(user.id);
            Logger.Log(notification.ToJson());
            MessageBox.Show($"Sent friend request to {user.displayName}", "Friend Request sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void Menu_item_friend_remove_ClickAsync(object sender, EventArgs e)
        {
            var user = (UserBriefResponse)tree_users.SelectedNode.Tag;
            var confirmResult = MessageBox.Show($"Are you sure you want to remove {user.displayName} from your friendlist?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) { return ; }
            var notification = await vrcapi.FriendsApi.DeleteFriend(user.id);
            Logger.Log(notification.ToJson());
            MessageBox.Show($"Unfriended {user.displayName}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BlockToolStripMenuItem_Click");
        }

        private void UnblockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UnblockToolStripMenuItem_Click");
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
        public async void AddFriendsAsync(List<string> ids)
        {
            var toAdd = ids.Except(me.friends).ToList();
            toAdd.RemoveAll(item => !item.StartsWith("usr_"));
            var skipped = ids.Count - toAdd.Count;
            Logger.Debug("ids:", ids.Count, "toAdd:", toAdd.Count, "skipped:", skipped);
            if (toAdd.Count > 1)
            {
                var confirmResult = MessageBox.Show($"You're about to send {toAdd.Count} friend requests, this will flood the API quite a bit!\n\nStart adding now?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes) { return; }
            }
            else if (toAdd.Count < 1) return;
            /*progress_status.Visible = true;
            progress_status.Maximum = toAdd.Count;
            progress_status.Step = 1;
            progress_status.Value = 0;*/
            // bgWorker.RunWorkerAsync();
            /*new Thread(async () =>
            {
                Thread.CurrentThread.IsBackground = true;*/
                var i = 1;
                foreach (var friend in toAdd)
                {
                    Logger.Log("Adding friend", i++, "/", toAdd.Count, friend.Enclose());
                    // progress_status.PerformStep();
                    var notification = await vrcapi.FriendsApi.SendRequest(friend);
                    Logger.Log(notification.ToJson());
                    Thread.Sleep(5000);
                }
                MessageBox.Show($"Sent {toAdd.Count} friend requests", "Requests sent!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // }).Start();
            // progress_status.Visible = false;
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
                AddFriendsAsync(toImport);
            }
        }
    }
}
