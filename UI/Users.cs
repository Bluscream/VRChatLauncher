using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VRChatLauncher.Utils;
using VRChatApi.Classes;
using System.Drawing;
using System.Collections;
using System.Linq;
using static VRChatLauncher.IPC.Game;

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
                if (force) me = await vrcapi.UserApi.UpdateInfo(me.id);
                SetNodeColorFromTags(tree_users.Nodes[0], me.tags);
                tree_users.Nodes[0].Text = me.displayName;
                tree_users.Nodes[0].Tag = me;
                tree_users.Nodes[1].Text = $"Friends ({me.friends.Count})";
            }
            if (users_last_update == null || users_last_update.ExpiredSince(3) || force) {
                var offset = 0;
                for (int i = 0; i < 10; i++)
                {
                    Logger.Debug(i, "Getting online friends", offset, "to", offset + 100);
                    var friends_part = await vrcapi.FriendsApi.Get(offset, 100, false);
                    friends.AddRange(friends_part);
                    Logger.Debug(i, "Got", friends_part.Count, "online friends");
                    if (friends_part.Count < 100) break;
                    offset += 100;
                }
                /*foreach (var friend_id in me.friends) {
                    if (friends.Any(n=> n.id == friend_id)) continue;
                    var user = await vrcapi.UserApi.GetById(friend_id);
                    friends.Add(user);
                }*/
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
            if( e.Node.Text == "Offline") {
                FillOfflineFriends();
                return;
            }
            if (e.Node.Tag == null) return;
            if (e.Node.Tag is UserResponse) {
                var user = (UserResponse)e.Node.Tag; FillUser(user);
            } else if (e.Node.Tag is UserBriefResponse) {
                var user = (UserBriefResponse)e.Node.Tag; FillUser(user);
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
            var cmd = new Command(CommandType.Launch, worldInstanceID: worldinstance, referrer: "vrclauncher");
            Send(cmd);
        }

        private void Btn_users_reload_Click(object sender, EventArgs e)
        {
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
    }
}
