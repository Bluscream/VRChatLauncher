using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VRChatLauncher.Utils;
using VRChatApi.Classes;
using System.Drawing;
using System.Collections;
using System.Linq;

namespace VRChatLauncher
{
    partial class Main
    {
        public static List<UserBriefResponse> friends;
        public static List<UserResponse> blocked;
        public static List<UserResponse> user_requests;
        public static UserResponse me;
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
            users_loading = true;
            var onlinenode = tree_users.Nodes[1].Nodes[0];
            var offlinenode = tree_users.Nodes[1].Nodes[1];
            onlinenode.Nodes.Clear();
            offlinenode.Nodes.Clear();
            tree_users.Nodes[2].Nodes.Clear();
            tree_users.Nodes[3].Nodes.Clear();
            if (me != null)  {
                if (force) me = await vrcapi.UserApi.UpdateInfo(me.id);
                SetNodeColorFromTags(tree_users.Nodes[0], me.tags);
                tree_users.Nodes[0].Text = me.displayName;
                tree_users.Nodes[0].Tag = me;
                tree_users.Nodes[1].Text = $"Friends ({me.friends.Count})";
            }
            if (friends == null || force) {
                friends = new List<UserBriefResponse>();
                var offset = 0;
                for (int i = 0; i < 10; i++)
                {
                    var friends_part = await vrcapi.FriendsApi.Get(offset, 100, true);
                    friends.AddRange(friends_part);
                    if (friends_part.Count < 100) break;
                    offset += 100;
                }
                friends = friends.OrderBy(o=>o.location).ToList();
                friends = friends.OrderBy(o=>o.displayName).ToList();
                Logger.Log("Downloaded list of", friends.Count, "official friends");
            }
            foreach (var friend in friends)
            {
                var node = new TreeNode(friend.displayName);
                node.Tag = friend;
                SetNodeColorFromTags(node, friend.tags);
                // node.ForeColor = ColorFromReleaseStatus(avatar.releaseStatus);
                if (friend.location == "offline")
                    tree_users.Nodes[1].Nodes[1].Nodes.Add(node);
                else tree_users.Nodes[1].Nodes[0].Nodes.Add(node);
            }
            //  tree_users.Nodes[1].Text = $"Friends ({onlinenode.Nodes.Count + offlinenode.Nodes.Count})";
            onlinenode.Text = $"Online ({onlinenode.Nodes.Count})";
            offlinenode.Text = $"Offline ({offlinenode.Nodes.Count})";
            // tree_users.TreeViewNodeSorter = new NodeSorter();
            // tree_users.Sort(onlinenode);
            users_loading = false;
            return;
            if (favorite_avatars == null || force) {
                favorite_avatars = await vrcapi.AvatarApi.Favorites();
                Logger.Log("Downloaded list of", favorite_avatars.Count, "official favorite avatars");
            }
            foreach (var avatar in favorite_avatars)
            {
                var node = new TreeNode(avatar.name);
                node.Tag = avatar;
                node.ForeColor = ColorFromReleaseStatus(avatar.releaseStatus);
                tree_users.Nodes[1].Nodes.Add(node);
            }
            tree_users.Nodes[1].Text = $"Official ({tree_users.Nodes[0].Nodes.Count} / 16)";
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
            if (e.Node.Tag == null) return;
            if (e.Node.Tag is UserResponse) {
                var user = (UserResponse)e.Node.Tag; FillUser(user);
            } else {
                var user = (UserBriefResponse)e.Node.Tag; FillUser(user);
           }
        }
        private async void Btn_users_search_ClickAsync(object sender, EventArgs e)
        {
            var user = await vrcapi.UserApi.GetById(txt_users_id.Text);
            FillUser(user);
        }

        private void Btn_users_reload_Click(object sender, EventArgs e)
        {
            SetupUsersAsync(true);
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
