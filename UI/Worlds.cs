using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRChatLauncher.Utils;
using static VRChatLauncher.Utils.Mods;
using IniParser.Model;
using VRChatApi.Classes;
using System.IO;

namespace VRChatLauncher
{
    partial class Main
    {
        public static DateTime worlds_last_update;
        public static bool worlds_loading = false;

        public async void SetupWorldsAsync(bool force = false) {
            if (worlds_loading) { Logger.Warn("Worlds are already loading, try again later");  return; }
            worlds_loading = true;
            tree_worlds.Nodes[0].Nodes.Clear();
            tree_worlds.Nodes[1].Nodes.Clear();
            if (worlds_last_update == null || worlds_last_update.ExpiredSince(3) || force) {
                var personal_worlds = new List<WorldBriefResponse>();var favorite_worlds = new List<WorldBriefResponse>();
                if (string.IsNullOrEmpty(config["Paths"]["Ripper"])) btn_worlds_rip.Visible = true;
                personal_worlds = await vrcapi.WorldApi.Search(user: UserOptions.Me, releaseStatus: ReleaseStatus.All, count: 100);
                Logger.Log("Downloaded list of", personal_worlds.Count, "official personal worlds");
                favorite_worlds = await vrcapi.WorldApi.Search(WorldGroups.Favorite, releaseStatus: ReleaseStatus.All, count: 100);
                Logger.Log("Downloaded list of", favorite_worlds.Count, "official favorite worlds");
                worlds_last_update = DateTime.Now;
                foreach (var world in personal_worlds)
                {
                    var node = new TreeNode(world.name);
                    node.Tag = world;
                    node.ForeColor = ColorFromReleaseStatus(world.releaseStatus);
                    tree_worlds.Nodes[0].Nodes.Add(node);
                }
                tree_worlds.Nodes[0].Text = $"Personal ({tree_worlds.Nodes[0].Nodes.Count})";
                foreach (var world in favorite_worlds)
                {
                    var node = new TreeNode(world.name);
                    node.Tag = world;
                    node.ForeColor = ColorFromReleaseStatus(world.releaseStatus);
                    tree_worlds.Nodes[1].Nodes.Add(node);
                }
                tree_worlds.Nodes[1].Text = $"Favorites ({tree_worlds.Nodes[1].Nodes.Count})";
            }
            worlds_loading = false;
        }
        private void FillWorld(WorldResponse world)
        {
            txt_world_id.Text = world.id;
            txt_world_id.Tag = world;
            txt_world_name.Text = world.name;
            txt_world_version.Text = world.version.ToString();
            txt_world_author.Text = $"{world.authorName} ({world.authorId})";
            txt_world_asset.Text = world.assetUrl;
            txt_world_description.Text = world.description;
        }

        private async void worlds_node_selectedAsync(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) return;
            WorldResponse world = null; WorldInstance instance; // WorldInstanceUserResponse user;
            var isworld = e.Node.Tag is WorldResponse || e.Node.Tag is WorldBriefResponse; var isinstance = e.Node.Tag is WorldInstance; var isuser = e.Node.Tag is WorldInstanceUserResponse;
            if (isuser) { world = (WorldResponse)e.Node.Parent.Parent.Tag; instance = (WorldInstance)e.Node.Parent.Tag; }
            if (isinstance) { world = (WorldResponse)e.Node.Parent.Tag; }
            if (isworld)
            {
                if (e.Node.Tag is WorldResponse)
                {
                    world = (WorldResponse)e.Node.Tag;
                }
                else
                {
                    var _world = (WorldBriefResponse)e.Node.Tag;
                    var fullworld = await vrcapi.WorldApi.Get(_world.id);
                    e.Node.Tag = fullworld;
                    world = (WorldResponse)e.Node.Tag;
                }
                e.Node.Nodes.Clear();
                foreach (var _instance in world.instances)
                {
                    var node = new TreeNode($"{_instance.id} ({_instance.occupants}/{world.capacity})", 1, 1);
                    node.Tag = _instance;
                    node.ImageIndex = 2;
                    e.Node.Nodes.Add(node);
                }
            }
            if (isinstance)
            {
                e.Node.Nodes.Clear();
                instance = (WorldInstance)e.Node.Tag;
                var fullinstance = await vrcapi.WorldApi.GetInstance(world.id, instance.id);
                Logger.Warn("hidden:", fullinstance.hidden);
                e.Node.ImageIndex = (string.IsNullOrEmpty(fullinstance.hidden) ? 1 : 2);
                // e.Node.Tag = fullinstance; // TODO: Fix
                foreach (var user in fullinstance.users)
                {
                    var node = new TreeNode(user.displayName);
                    var menu = new ContextMenuStrip();
                    // var item = new List<ToolStripMenuItem>();
                    var user_profile = new ToolStripMenuItem("View Profile");
                    user_profile.Click += User_profile_ClickAsync;
                    node.ContextMenuStrip = menu;
                    /*
                    private System.Windows.Forms.ContextMenuStrip menu_mod;
                    private System.Windows.Forms.ToolStripMenuItem toggleModToolStripMenuItem;
                    private System.Windows.Forms.ToolStripMenuItem deleteModToolStripMenuItem;
                    private System.Windows.Forms.ToolStripMenuItem decompileModToolStripMenuItem;
                    this.menu_mod = new System.Windows.Forms.ContextMenuStrip(this.components);
                    this.toggleModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                    this.deleteModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                    this.decompileModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                    this.lst_mods.ContextMenuStrip = this.menu_mod;
                    */
                    e.Node.Nodes.Add(node);
                }
                e.Node.Expand();
            }
            if (isuser && e.Button == MouseButtons.Right) {
                // menu_users.Show();
            }
            FillWorld(world);
        }

        private async void User_profile_ClickAsync(object sender, EventArgs e)
        {
            var _user = (WorldInstanceUserResponse)tree_worlds.SelectedNode.Tag;
            var user = await vrcapi.UserApi.GetById(_user.id);
            tree_users.Nodes[4].Nodes.Clear();
            var node = new TreeNode(user.displayName);
            node.Tag = user;
            node = SetNodeColorFromTags(node, user.tags);
            tree_users.Nodes[4].Nodes.Add(node);
            FillUser(user);
            tabs_main.SelectTab(1);
        }

        private void Menu_worlds_Opened(object sender, EventArgs e)
        {
            /*
            Logger.Warn("test");
            var node = tree_worlds.SelectedNode;
            if (node == null || node.Tag == null) return;
            WorldResponse world = null; WorldInstance instance; // WorldInstanceUserResponse user;
            var isworld = node.Tag is WorldResponse || node.Tag is WorldBriefResponse; var isinstance = node.Tag is WorldInstance; var isuser = node.Tag is WorldInstanceUserResponse;
            if (isuser) { world = (WorldResponse)node.Parent.Parent.Tag; instance = (WorldInstance)node.Parent.Tag; }
            if (isinstance) { world = (WorldResponse)node.Parent.Tag; }
            if (isworld) {
                menu_worlds.Items[0].Visible = true;menu_worlds.Items[1].Visible = true;menu_worlds.Items[2].Visible = true;
                menu_worlds.Items[3].Visible = false;
                return;
            } else if (isinstance) {
                menu_worlds.Items[0].Visible = false;menu_worlds.Items[1].Visible = false;menu_worlds.Items[2].Visible = false;
                menu_worlds.Items[3].Visible = true;
            } else { menu_worlds.Items[0].Visible = false;menu_worlds.Items[1].Visible = false;menu_worlds.Items[2].Visible = false; menu_worlds.Items[3].Visible = false; }
            */
        }

        private void CreateInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void JoinInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RemoveFromFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Btn_worlds_reload_Click(object sender, EventArgs e)
        {
            SetupWorldsAsync(force: true);
        }

        private async void Btn_worlds_search_ClickAsync(object sender, EventArgs e)
        {
            var world = await vrcapi.WorldApi.Get(txt_world_id.Text);
            FillWorld(world);
        }
        
        private async void Btn_worlds_author_ClickAsync(object sender, EventArgs e)
        {
            var avatar = (AvatarResponse)txt_avatar_id.Tag;
            var user = await vrcapi.UserApi.GetById(avatar.authorId);
            FillUser(user);
            tabs_main.SelectTab(1);
        }

        private void Btn_worlds_rip_Click(object sender, EventArgs e)
        {

        }
    }
}
