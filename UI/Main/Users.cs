﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VRChatLauncher.Utils;
using VRChatApi;
using VRChatApi.Classes;
using System.Drawing;
using System.Collections;
using System.Linq;
using static VRChatLauncher.IPC.Game;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Data;
// using Microsoft.VisualBasic;

namespace VRChatLauncher
{
    partial class Main
    {
        public static UserResponse me;
        public static DateTime users_last_update;
        public static bool users_loading = false;
        public static bool requests_loading = false;
        public static bool blocked_loading = false;
        public static UI.ChatWindow ChatWindow;

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
#region FillNodes
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // var control = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            // Logger.Debug(control.Name, control.Text);
            var node = tree_users.SelectedNode;
            if (node.Index == 0) FillMe(true);
            else if (node.Name == "node_friends") { FillOnlineFriends(true); FillOfflineFriends(); }
            else if (node.Name == "node_friends_online") FillOnlineFriends(true);
            else if (node.Name == "node_friends_offline") FillOfflineFriends();
            else if (node.Name == "node_friends_blocked") FillBlocked();
            else if (node.Name == "node_friends_requests") { FillRequests(); FillOutgoingRequests(); }
            else if (node.Name == "node_friends_requests_incoming") { FillRequests(); }
            else if (node.Name == "node_friends_requests_outgoing") { FillOutgoingRequests(); }
        }
        public async void SetupUsers(bool force = false) {
            if (users_loading) { Logger.Warn("Users are already loading, try again later");  return; }
            users_loading = true;
            FillMe();
            var friends = await GetAllFriends();
            FillOnlineFriends(force, friends: friends.Where(f => !f.Offline).ToList());
            FillOfflineFriends(friends: friends.Where(f => f.Offline).ToList());
            /*if (users_last_update == DateTime.MinValue)*/ FriendsToCache(friends);
            // FillOnlineFriends(force);
            // tree_users.TreeViewNodeSorter = new NodeSorter();
            // tree_users.Sort(onlinenode);
            FillRequests();
            FillBlocked();
            users_loading = false;
        }
        public async void FillMe(bool update = true) {
            Logger.Trace("Me: ", me != null);
            if (me != null)  {
                Logger.Trace("Me: ", me.ToJson());
                if (update) {
                    me = await vrcapi.UserApi.UpdateInfo(userId: me.id);
                    // FriendsToCache(me.friends);
                }
                SetNodeColorFromTags(tree_users.Nodes[0], me.tags);
                tree_users.Nodes[0].Text = me.displayName;
                tree_users.Nodes[0].Tag = new TreeNodeTag(type: NodeType.Me, id: me.id, me);
                tree_users.Nodes[1].Text = $"Friends ({me.friends.Count})";
            }
        }
        public void FriendsToCache(List<UserBriefResponse> newFriends)
        {
            var friendCache = Utils.Utils.getOwnPath().Combine("friends.cache.json");
            Logger.Log("Loading cached friends from", friendCache.FullName.Quote());
            var newFriendsBackup = new FriendsBackup(me, newFriends);
            if (friendCache.Exists) {
                try {
                    var cachedFriends = JsonConvert.DeserializeObject<FriendsBackup>(File.ReadAllText(friendCache.FullName));
                    Logger.Log("Loaded", cachedFriends.Friends.Count, "cached friends from", friendCache.Name.Quote());
                    CompareFriendCaches(cachedFriends, newFriendsBackup);
                } catch (JsonException ex) {
                    MessageBox.Show($"An error was thrown while reading cached friends!\nClick okay to discard current cache and write a new one\n\n{ex.Message}\n\n{ex.StackTrace}", "Error while loading cached friends!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Logger.Log("Saving", newFriendsBackup.Friends.Count, "new friends to", friendCache.Name.Quote());
            // File.WriteAllLines(friendCache.FullName, newFriends);
            File.WriteAllText(friendCache.FullName, JsonConvert.SerializeObject(newFriendsBackup, Formatting.Indented));
        }
        private void CompareFriendCaches(FriendsBackup oldFriends, FriendsBackup newFriends) {
            if (oldFriends != newFriends) {
                var sb = new StringBuilder($"Last Backup: {oldFriends.TimeStamp} ({(DateTime.Now - oldFriends.TimeStamp).StripMilliseconds()} ago)\n\n");
                if (oldFriends.Account.id != newFriends.Account.id) {
                    var diffAccResult = MessageBox.Show($"Last Friends Backup was created with account\n\n{oldFriends.Account.displayName.Quote()}\n\nbut you're currently logged in as\n\n{newFriends.Account.displayName.Quote()}\n\nAre you sure you still want to compare them?", "Friend backup conflict detected!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (diffAccResult != DialogResult.OK) return;
                }
                // var addedFriends = new List<FriendsBackup.Friend>();
                var removedFriends = new List<FriendsBackup.Friend>();
                // var changedNames = new List<FriendsBackup.Friend>();
                var changed = false;
                foreach (var oldFriend in oldFriends.Friends)
                {
                    var oldInNew = newFriends.Friends.FirstOrDefault(c => c.id == oldFriend.id);
                    if (oldInNew is null) {
                        removedFriends.Add(oldFriend);changed = true;
                    } else {
                        if (oldInNew.displayName != oldFriend.displayName) {
                            sb.AppendLine($"{oldFriend.displayName.Quote()} changed their name to {oldInNew.displayName.Quote()}!"); changed = true;
                        }
                    }
                }
                if (changed)
                {
                    var title = "Friend List Changed";
                    if (removedFriends.Count > 0) {
                        Logger.Debug("Removed Friends:", removedFriends.ToJson());
                        foreach (var removedFriend in removedFriends) {
                            sb.AppendLine($"{removedFriend.displayName.Quote()} was removed!");
                        }
                        sb.AppendLine("\n\nPress Yes to re-add removed friends to your list");
                        var reAddResult = MessageBox.Show(sb.ToString(), title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (reAddResult == DialogResult.Yes) {
                            AddFriendsAsync(removedFriends.Select(c => c.id).ToList());
                        }
                    } else {
                        MessageBox.Show(sb.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                /*foreach (var oldFriend in oldFriends.Friends)
                {
                    // var change = FriendsBackup.Friend.Changed.Everything;
                    foreach (var newFriend in newFriends.Friends)
                    {
                        /*switch (oldFriend.Difference(newFriend))
                        {
                            case FriendsBackup.Friend.Changed.Name:
                                change = FriendsBackup.Friend.Changed.Name; break;
                            case FriendsBackup.Friend.Changed.Nothing:
                                change = FriendsBackup.Friend.Changed.Nothing; break;
                            default:
                                break;
                        }
                        if (change != FriendsBackup.Friend.Changed.Everything) break;

                    }
                    switch (change)
                    {
                        case FriendsBackup.Friend.Changed.Name:
                            changedNames.Add(oldFriend); break;
                        case FriendsBackup.Friend.Changed.Everything:
                            removedFriends.Add(oldFriend); break;
                        default:
                            break;
                    }
                }*/
                /*foreach (var newFriend in newFriends.Friends) {
                    if (!newFriends.Friends.Any(x => x.id == newFriend.id)) {
                        addedFriends.Add(newFriend);
                    }
                }*/

            }
        }

        public async Task<List<UserBriefResponse>> GetAllFriends() // New
        {
            var onlineFriends = await GetOnlineFriends();
            var offlineFriends = await GetOfflineFriends();
            var friends = new List<UserBriefResponse>();
            friends.AddRange(onlineFriends);
            friends.AddRange(offlineFriends);
            friends = friends.OrderBy(o => o.displayName).ToList();
            friends = friends.OrderBy(o => o.location).Reverse().ToList();
            Logger.Log("Downloaded list of", friends.Count, "official friends");
            return friends;
        }

        public async Task<List<UserBriefResponse>> GetOnlineFriends()
        {
            var friends = new List<UserBriefResponse>();
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
            friends = friends.OrderBy(o => o.displayName).ToList();
            friends = friends.OrderBy(o => o.location).Reverse().ToList();
            Logger.Log("Downloaded list of", friends.Count, "official online friends");
            return friends;
        }

        public async void FillOnlineFriends(bool force = false, List<UserBriefResponse> friends = null)
        {
            var onlinenode = tree_users.Nodes[1].Nodes[0];
            onlinenode.Nodes.Clear();
            tree_users.Nodes[2].Nodes.Clear();
            if (users_last_update == null || users_last_update.ExpiredSince(3) || force) {
                if (friends is null) { friends = await GetOnlineFriends(); }
                foreach (var friend in friends)
                {
                    var node = new TreeNode(friend.displayName);
                    node.Tag = new TreeNodeTag(type: NodeType.User, id: friend.id, friend);
                    SetNodeColorFromTags(node, friend.tags);
                    if (friend.location == "offline") {
                        tree_users.Nodes[1].Nodes[1].Nodes.Add(node);
                    } else { tree_users.Nodes[1].Nodes[0].Nodes.Add(node); }
                }
                onlinenode.Text = $"Online ({onlinenode.Nodes.Count})";
                users_last_update = DateTime.Now;
            }
        }

        public async Task<List<UserBriefResponse>> GetOfflineFriends()
        {
            var friends = new List<UserBriefResponse>();
            var offset = 0;
            for (int i = 0; i < 15; i++)
            {
                Logger.Debug(i, "Getting offline friends", offset, "to", offset + 100);
                var friends_part = await vrcapi.FriendsApi.Get(offset, 100, true);
                if (friends_part == null) break;
                // var friends_part = (List<UserBriefResponse>)response.Content;
                friends.AddRange(friends_part.Select(c => { c.Offline = true; return c; }));
                Logger.Debug(i, "Got", friends_part.Count, "offline friends");
                if (friends_part.Count < 100) break;
                offset += 100;
            }
            friends = friends.OrderBy(o => o.location).ToList();
            friends = friends.OrderBy(o => o.displayName).ToList();
            Logger.Log("Downloaded list of", friends.Count, "official offline friends");
            return friends;
        }

        public async void FillOfflineFriends(List<UserBriefResponse> friends = null) {
            var offlinenode = tree_users.Nodes[1].Nodes[1];
            offlinenode.Nodes.Clear();
            if (friends is null) { friends = await GetOfflineFriends(); }
            foreach (var friend in friends)
            {
                var node = new TreeNode(friend.displayName);
                node.Tag = new TreeNodeTag(type: NodeType.User, id: friend.id, friend);
                SetNodeColorFromTags(node, friend.tags);
                tree_users.Nodes[1].Nodes[1].Nodes.Add(node);
            }
            offlinenode.Text = $"Offline ({offlinenode.Nodes.Count})";
        }

        public async void FillBlocked() {
            try
            {
                if (blocked_loading) { Logger.Warn("Blocked users are already loading, try again later"); return; }
                blocked_loading = true;
                var blocked_node = tree_users.Nodes[2];
                blocked_node.Nodes.Clear();
                var outgoing_mods = await vrcapi.ModerationsApi.GetPlayerModerations();
                Logger.Log("Downloaded list of", outgoing_mods.Count, "own moderations");
                var outgoing_blocks = new List<PlayerModeratedResponse>();
                foreach (var mod in outgoing_mods)
                {
                    foreach (var _mod in outgoing_mods)
                    {
                        if (_mod.targetUserId == mod.targetUserId && _mod.type == "unblock") continue;
                    }
                    if (mod.type != "block") continue;
                    outgoing_blocks.Add(mod);
                }
                foreach (var block in outgoing_blocks)
                {
                    // Logger.Trace(block.ToJson());
                    // var user = await vrcapi.UserApi.GetById(block.targetUserId);
                    var node = new TreeNode(block.targetDisplayName);
                    node.Tag = new TreeNodeTag(NodeType.Moderation, id: block.id, block); //, user
                    // SetNodeColorFromTags(node, user.tags);
                    blocked_node.Nodes.Add(node);
                }
                blocked_node.Text = $"Blocked ({blocked_node.Nodes.Count})";
                blocked_loading = false;
            }  catch (Exception ex) { Logger.Error(ex.Message, Environment.NewLine, ex.StackTrace);  }
        }

        public async void FillRequests() {
            if (requests_loading) { Logger.Warn("Requests are already loading, try again later");  return; }
            requests_loading = true;
            var requests_node = tree_users.Nodes[3]; var incoming_node = tree_users.Nodes[3].Nodes[0]; var outgoing_node = tree_users.Nodes[3].Nodes[1];
            incoming_node.Nodes.Clear();
            var incoming_requests = await vrcapi.NotificationsAPI.GetAll("friendRequest", false);
            Logger.Log("Downloaded list of", incoming_requests.Count, "incoming friend requests");
            foreach (var request in incoming_requests)
            {
                // Logger.Trace(request.ToJson());
                // var user = await vrcapi.UserApi.GetById(request.SenderUserId);
                var node = new TreeNode(request.SenderUsername);
                node.Tag = new TreeNodeTag(type: NodeType.Notification, id: request.Id, request);
                // SetNodeColorFromTags(node, user.tags);
                incoming_node.Nodes.Add(node);
            }
            incoming_node.Expand();
            incoming_node.Text = $"Incoming ({incoming_node.Nodes.Count})";
            requests_node.Text = $"Requests ({incoming_node.Nodes.Count + outgoing_node.Nodes.Count})"; // Move
            requests_loading = false;
        }
        public async void FillOutgoingRequests() {
            var requests_node = tree_users.Nodes[3]; var incoming_node = tree_users.Nodes[3].Nodes[0]; var outgoing_node = tree_users.Nodes[3].Nodes[1];
            outgoing_node.Nodes.Clear();
            var outgoing_requests = await vrcapi.NotificationsAPI.GetAll(type: "friendRequest", sent: true);
            Logger.Log("Downloaded list of", outgoing_requests.Count, "outgoing friend requests");
            foreach (var request in outgoing_requests)
            {
                Logger.Trace(request.ToJson());
                // var user = await vrcapi.UserApi.GetById(request.ReceiverUserId);
                var node = new TreeNode(request.Id);
                node.Tag = new TreeNodeTag(NodeType.Notification, request.Id, request); 
                // SetNodeColorFromTags(node, user.tags);
                outgoing_node.Nodes.Add(node);
            }
            outgoing_node.Text = $"Outgoing ({outgoing_node.Nodes.Count})";
            requests_node.Text = $"Requests ({incoming_node.Nodes.Count + outgoing_node.Nodes.Count})"; // Move
        }
#endregion
        private async void FillUser(string userId) {
            var user = await vrcapi.UserApi.GetById(userId);
            FillUser(user);
        }
        private void FillUser(UserResponse user) => FillUser((UserBriefResponse)user);
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
            var location = new UserLocation(user.location);
            if (location.Type == UserLocationType.Public) {
                tooltip_user_location.SetToolTip(txt_users_location, location.WorldInstance.ToJson().ToString());
            } 
            /*if (tree_users.Nodes[0].Tag != null)
            {
                var tag = (TreeNodeTag)tree_users.Nodes[0].Tag;
                // if (user.id == me.id) { btn_users_save.Visible = true; } else { btn_users_save.Visible = false; }
            }*/
        }

        private void Txt_users_location_Enter(object sender, EventArgs e) {}

        private async void users_node_selectedAsync(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "Me") {
                FillMe(); return;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Text == "Offline") {
                    FillOfflineFriends(); return;
                } else if (e.Node.Text == "Outgoing") {
                    FillOutgoingRequests(); return;
                }
                if (!(e.Node.Tag is TreeNodeTag tag)) return;
                // Logger.Warn(tag.ToJson());
                if (tag.userResponse != null) { FillUser(tag.userResponse); return; }
                else if (tag.userBriefResponse != null) { FillUser(tag.userBriefResponse); return; }
                else if (tag.Type == NodeType.Notification) {
                    var id = "";
                    if (tag.notificationResponse.ReceiverUserId == me.id) id = tag.notificationResponse.SenderUserId;
                    else if (tag.notificationResponse.SenderUserId == me.id) id = tag.notificationResponse.ReceiverUserId;
                    if (string.IsNullOrEmpty(id)) return;
                    var user = await vrcapi.UserApi.GetById(id); tag.userBriefResponse = user; e.Node.Tag = tag; FillUser(user); return;
                } else if (tag.Type == NodeType.Moderation) {
                    var id = "";
                    if (tag.playerModeratedResponse.targetUserId == me.id) { id = tag.playerModeratedResponse.sourceUserId; }
                    else if (tag.playerModeratedResponse.sourceUserId == me.id) { id = tag.playerModeratedResponse.targetUserId; }
                    if (string.IsNullOrEmpty(id)) return;
                    var user = await vrcapi.UserApi.GetById(id); tag.userBriefResponse = user; e.Node.Tag = tag; FillUser(user); return;
                }
            } else if (e.Button == MouseButtons.Right) {
                if (Program.Arguments.Launcher.Verbose.IsTrue) { // Todo Change
                    for (int i = 0; i < menu_users.Items.Count; i++) {
                        Logger.Trace(i, menu_users.Items[i].Text);
                    }
                }
                tree_users.SelectedNode = e.Node;
                for (int i = 0; i < menu_users.Items.Count; i++) { menu_users.Items[i].Visible = false; }
                if (e.Node.Nodes.Count > 0 || e.Node.Index == 0) menu_users.Items[10].Visible = true; // Refresh
                if(e.Node.Text.StartsWith("Friends ("))
                {
                    menu_users.Items[5].Visible = true; menu_users.Items[6].Visible = true; // Import/Export
                    menu_users.Items[12].Visible = true; // Discord Names
                }
                else if(e.Node.Tag != null)
                {
                    var tag = (TreeNodeTag)tree_users.SelectedNode.Tag;
                    if (tag.Type == NodeType.Me || tag.Type == NodeType.User || tag.Type == NodeType.Moderation || tag.Type == NodeType.Notification) {
                        if (tag.Type == NodeType.Me) {
                            menu_users.Items[11].Visible = true; // Set Status
                        }
                        // if(tag.notificationResponse != null && tag.notificationResponse.)
                        if (!me.friends.Contains(tag.Id)) { menu_users.Items[1].Visible = true; // Unfriend
                        } else {
                            menu_users.Items[2].Visible = true; //Friend
                    }
                        var isBlocked = false;
                        if (tag.Type != NodeType.Moderation) { // Todo: proper implementation
                            foreach (TreeNode node in tree_users.Nodes[2].Nodes)
                            {
                                var nodetag = (TreeNodeTag)node.Tag;
                                if (nodetag.playerModeratedResponse.targetUserId == tag.Id) { isBlocked = true; break; }
                            }
                        } else { isBlocked = true; }
                        if (isBlocked) menu_users.Items[4].Visible = true; // Unblock
                        else { menu_users.Items[3].Visible = true; /*Block*/ }
                        menu_users.Items[0].Visible = true; // Profile
                        menu_users.Items[7].Visible = true; // Message
                        menu_users.Items[8].Visible = true; // Invite
                        menu_users.Items[9].Visible = true; // Chat
                    }
                }
                // if (menu_users.Items.Cast<ToolStripMenuItem>().ToList().Any(p => p.Visible))
                    menu_users.Show(tree_users, e.Location);
            }
        }
        private void Btn_users_search_Click(object sender, EventArgs e) {
            FillUser(txt_users_id.Text);
        }

        private async void Btn_users_search_name_ClickAsync(object sender, EventArgs e)
        {
            var node_search = tree_users.Nodes[4];
            var users = await vrcapi.UserApi.Search(txt_users_displayname.Text);
            users = users.OrderBy(o=>o.displayName).ToList();
            node_search.Nodes.Clear();
            foreach (var user in users)
            {
                var node = new TreeNode(user.displayName);
                node.Tag = new TreeNodeTag(NodeType.User, id: user.id, user);
                SetNodeColorFromTags(node, user.tags);
                node_search.Nodes.Add(node);
            }
            node_search.Text = $"Search ({node_search.Nodes.Count})";
            node_search.Expand();
        }

        private void Btn_user_join_Click(object sender, EventArgs e)
        {
            if(txt_users_location.Text == "offline") { MessageBox.Show($"{txt_users_displayname.Text} is offline. You can't join them!", "User offline", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            else if(txt_users_location.Text == "private") { MessageBox.Show($"{txt_users_displayname.Text} is in a private world. You can't join them!", "User in private world!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            var cmd = new Command(IPC.Game.CommandType.Launch); // , referrer: "vrclauncher"
            cmd.WorldInstanceID = new WorldInstanceID(txt_users_location.Text);
            Send(cmd);
        }

        private void Btn_users_reload_Click(object sender, EventArgs e)
        {
            if(me != null && me.id == null) { LoginVRCAPI(); }
            FillMe(true);
            SetupUsers(true);
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

        private void ProfileMenuItem_Click(object sender, EventArgs e)
        {
            TreeNodeTag tag = null;
            if (tabs_main.SelectedIndex == 1) tag = (TreeNodeTag)tree_users.SelectedNode.Tag;
            else if (tabs_main.SelectedIndex == 3) tag = (TreeNodeTag)tree_worlds.SelectedNode.Tag;
            MessageBox.Show(tag.ToJson().ToString());
            switch (tag.Type)
            {
                case NodeType.Me:
                    FillUser(tag.userResponse); tabs_main.SelectTab(1); return;
                case NodeType.User:
                    FillUser(tag.Id); tabs_main.SelectTab(1); return;
                case NodeType.World:
                    FillWorld(tag.worldResponse); tabs_main.SelectTab(3); return;
                case NodeType.Avatar:
                    FillAvatar(tag.avatarResponse); tabs_main.SelectTab(2); return;
                default:
                    return;
            }
        }

        private async void Menu_item_friend_add_ClickAsync(object sender, EventArgs e)
        {
            var tag = (TreeNodeTag)tree_users.SelectedNode.Tag; var name = "";var id = "";
            if (tag.userResponse != null) { id = tag.userResponse.id; name = tag.userResponse.displayName; }
            else if (tag.userBriefResponse != null) { id = tag.userBriefResponse.id; name = tag.userBriefResponse.displayName; } else { return; }
            var notification = await vrcapi.FriendsApi.SendRequest(id);
            Logger.Log(notification.ToJson());
            MessageBox.Show($"Sent friend request to {name}", "Friend Request sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void Menu_item_friend_remove_ClickAsync(object sender, EventArgs e)
        {
            var tag = (TreeNodeTag)tree_users.SelectedNode.Tag; var name = "";var id = "";
            if (tag.userResponse != null) { id = tag.userResponse.id; name = tag.userResponse.displayName; }
            else if (tag.userBriefResponse != null) { id = tag.userBriefResponse.id; name = tag.userBriefResponse.displayName; } else { return; }
            var confirmResult = MessageBox.Show($"Are you sure you want to remove {name} from your friendlist?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) { return ; }
            var notification = await vrcapi.FriendsApi.DeleteFriend(id);
            Logger.Log(notification.ToJson());
            MessageBox.Show($"Unfriended {name}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BlockToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            var tag = (TreeNodeTag)tree_users.SelectedNode.Tag;
            var notification = await vrcapi.ModerationsApi.BlockUser(tag.Id);
            Logger.Trace(notification);
        }

        private async void UnblockToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            var tag = (TreeNodeTag)tree_users.SelectedNode.Tag;
            if (tag.Type != NodeType.Moderation) { MessageBox.Show("Sorry, unblocking currently only works on active blocks :("); return; }
            var mod = tag.playerModeratedResponse;
            if (string.IsNullOrWhiteSpace(mod.targetUserId)) return;
            var notification = await vrcapi.ModerationsApi.UnblockUser(mod.targetUserId);
            Logger.Trace(notification.ToJson());
            if (notification == null) { MessageBox.Show($"Unable to unblock {mod.targetDisplayName}!\n\n{notification.ToJson()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else { MessageBox.Show($"Unblocked {mod.targetDisplayName}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); FillBlocked(); }
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
                var confirmResult = MessageBox.Show($"You're about to send {toAdd.Count} friend requests, this can flood the API quite a bit!\n\nStart adding now?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                var i = 1;var success = 0;
                foreach (var friend in toAdd)
                {
                    Logger.Log("Adding friend", i++, "/", toAdd.Count, friend.Enclose());
                    // progress_status.PerformStep();
                    var notification = await vrcapi.FriendsApi.SendRequest(friend);
                    Logger.Log(notification.ToJson());
                    if (notification != null) success += 1;
                    Logger.Log("Added friend", success, "/", toAdd.Count, friend.Enclose());
                    Thread.Sleep(2000);
                }
                MessageBox.Show($"Sent {success} / {toAdd.Count} friend requests", "Requests sent!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var operation = new UI.OperationsPanel();
                operation.Show();
                AddFriendsAsync(toImport);
            }
        }

        

        private async void MessageToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            var tag = (TreeNodeTag)tree_users.SelectedNode.Tag;
            // var message = Interaction.InputBox("", $"Send message to {tag.Id}");
            var toName = (tag.userResponse != null) ? tag.userResponse.displayName : tag.userBriefResponse.displayName;
            var title = $"Send message to {toName}";
            //var result = UI.Utils.InputBox(title, "Message:", ref message, true);
            var message = UI.MultilineInput.Get(title);
            if (string.IsNullOrWhiteSpace(message)) return;
            message = $"| Message from \"{me.displayName}\"\nAt: {DateTime.Now}\n{message}";
            var notification = await vrcapi.FriendsApi.SendMessage(tag.Id, message, "Messaging provided by github.com/Bluscream/VRCLauncher");
            Logger.Debug(notification);
            // MessageBox.Show(json.ToString(), "Message sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChatWindow is null || ChatWindow.IsDisposed)
            {
                ChatWindow = new UI.ChatWindow(vrcapi, me);
                // ChatWindow.FormClosed += ChatWindow_FormClosed;
            }
            ChatWindow.Show();
            var tag = (TreeNodeTag)tree_users.SelectedNode.Tag;
            ChatWindow.AddChat(tag.userBriefResponse);
        }

        /*private void ChatWindow_FormClosed(object sender, FormClosedEventArgs e) {
            ChatWindow = null;
        }*/

        private async void InviteToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            var tag = (TreeNodeTag)tree_users.SelectedNode.Tag;
            var target = (tag.userResponse != null) ? tag.userResponse : tag.userBriefResponse;
            /*
            var result = UI.Utils.InputBox("Enter World ID", "WorldID:", ref worldinstanceid);
            if (result != DialogResult.OK) return;
            var worldname = "";
            result = UI.Utils.InputBox("Enter World Name", "Name:", ref worldname);
            if (result != DialogResult.OK) return;
            */
            var worlds = new List<UI.InviteDialog.World>();
            if (remoteConfig is null) remoteConfig = await vrcapi.RemoteConfig.Get();
            if (remoteConfig != null)
            {
                worlds.Add(new UI.InviteDialog.World(remoteConfig.timeOutWorldId, "Timeout"));
                worlds.Add(new UI.InviteDialog.World(remoteConfig.hubWorldId, "Hub"));
                worlds.Add(new UI.InviteDialog.World(remoteConfig.homeWorldId, "Home"));
                worlds.Add(new UI.InviteDialog.World(remoteConfig.tutorialWorldId, "Tutorial"));
            }
            foreach (var node in tree_worlds.Nodes.GetAllChilds())
            {
                var nodetag = node.Tag as TreeNodeTag;
                if (nodetag is null) continue;
                if (nodetag.Type != NodeType.World) continue;
                var world = nodetag.worldBriefResponse;
                if (world.id is null) continue;
                worlds.Add(new UI.InviteDialog.World(world.id, world.name));
            }
            var result = UI.InviteDialog.Get($"Invite {target.displayName.Quote()}", worlds);
            if (!result.Continue) return;
            var notification = await vrcapi.FriendsApi.SendInvite(target.id, result.WorldId, result.WorldName);
            Logger.Debug(notification);
            MessageBox.Show($"Invited\n\n{target.displayName.Quote()}\n\nto\n\n{result.WorldName}", $"Invited {target.displayName.Quote()}");
        }

        private async void SetStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var title = $"Set Status";
            // var result = UI.Utils.InputBox(title, "Message:", ref message, true);
            // if (result != DialogResult.OK) return;
            var message = UI.MultilineInput.Get(title, me.statusDescription);
            if (string.IsNullOrWhiteSpace(message) || message == me.statusDescription) return;
            me = await vrcapi.UserApi.UpdateInfo(userId: me.id, status: me.status, statusDescription: message);
            FillMe(false);
            Logger.Debug("New Status:", me.status, me.statusDescription.Enclose());
        }

        private void DiscordNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var regex = new Regex(@"(?:^|\n*)(?:(?:[^\n:]|\|)*(?:dc|discord)[ \t\v\f\r]*:?[ \t\v\f\r]*)?([^\n]*#\d{4})", RegexOptions.Multiline | RegexOptions.IgnoreCase); // .*#(\d{4})
            var confirmResult = MessageBox.Show(
                $"This will search through all your friends statuses and extract the ones that might be discord names (matching {regex.ToString()}).\n\nYou can select multiple rows and copy them with [CTRL] + [C]"
            , "Search for discord names?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.OK) return;
            var dict = new SortedDictionary<string, string>();
            foreach (TreeNode node in tree_users.Nodes.GetAllChilds()) {
                var tag = node.Tag;
                if (tag is null) continue;
                var Tag = tag as TreeNodeTag;
                if (Tag.userBriefResponse is null) continue;
                if (!string.IsNullOrWhiteSpace(Tag.userBriefResponse.statusDescription)) {
                    foreach (Match m in regex.Matches(input: Tag.userBriefResponse.statusDescription)) {
                        dict.AddSafe(Tag.userBriefResponse.displayName.Trim(), m.Value.Trim());
                    }
                }
            }
            if (dict.Count < 1) {
                MessageBox.Show("Sorry, we could not find any discord names in your friends statuses :c");
                return;
            }
            dict.OrderBy(kv => kv.Key);
            Form form = new Form();
            form.Text = $"Discord names of your friends ({dict.Count})";
            form.Height *= 2;
            form.Width *= 3;
            form.Icon = ActiveForm.Icon;

            DataTable DiscordNames = new DataTable("DiscordNames");
            DiscordNames.Columns.Clear();
            DataColumn c0 = new DataColumn("Ingame Name"); c0.ReadOnly = true; DiscordNames.Columns.Add(c0);
            DataColumn c1 = new DataColumn("Status"); /* c1.ReadOnly = true; */ DiscordNames.Columns.Add(c1);
            foreach (var user in dict) {
                DataRow row = DiscordNames.NewRow();
                row[c0.ColumnName] = user.Key;
                row[c1.ColumnName] = user.Value;
                DiscordNames.Rows.Add(row);
            }

            var table = new DataGridView();
            table.Dock = DockStyle.Fill;
            table.DataSource = DiscordNames;
            form.Controls.Add(table);
            form.Show();
            table.Columns[c0.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            table.Columns[c1.ColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            table.Sort(table.Columns[c0.ColumnName], ListSortDirection.Ascending);
        }

    }
}
