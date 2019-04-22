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
        public static List<WorldBriefResponse> favorite_worlds;public static List<WorldBriefResponse> personal_worlds;
        public static bool worlds_loading = false;

        public async void SetupWorldsAsync(bool force = false) {
            if (worlds_loading) { Logger.Warn("Worlds are already loading, try again later");  return; }
            worlds_loading = true;
            tree_worlds.Nodes[0].Nodes.Clear();
            tree_worlds.Nodes[1].Nodes.Clear();
            if (personal_worlds == null || force) {
                if (Utils.Utils.getRipper().Exists) btn_worlds_rip.Visible = true;
                personal_worlds = await vrcapi.WorldApi.Search(user: UserOptions.Me, releaseStatus: ReleaseStatus.All, count: 100);
                Logger.Debug("Downloaded list of", personal_worlds.Count, "official personal worlds");
            }
            foreach (var world in personal_worlds)
            {
                var node = new TreeNode(world.name);
                node.Tag = world;
                node.ForeColor = ColorFromReleaseStatus(world.releaseStatus);
                tree_worlds.Nodes[0].Nodes.Add(node);
            }
            tree_worlds.Nodes[0].Text = $"Personal ({tree_worlds.Nodes[0].Nodes.Count})";
            if (favorite_worlds == null || force) {
                favorite_worlds = await vrcapi.WorldApi.Search(WorldGroups.Favorite, releaseStatus: ReleaseStatus.All, count: 100);
                Logger.Debug("Downloaded list of", favorite_worlds.Count, "official favorite worlds");
            }
            foreach (var avatar in favorite_worlds)
            {
                var node = new TreeNode(avatar.name);
                node.Tag = avatar;
                node.ForeColor = ColorFromReleaseStatus(avatar.releaseStatus);
                tree_worlds.Nodes[1].Nodes.Add(node);
            }
            tree_worlds.Nodes[1].Text = $"Favorites ({tree_worlds.Nodes[1].Nodes.Count})";
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
            WorldResponse world;
            if (e.Node.Tag is WorldResponse) {
                world = (WorldResponse)e.Node.Tag;
            } else if (e.Node.Tag is WorldBriefResponse) {
                var _world = (WorldBriefResponse)e.Node.Tag;
            Logger.Warn("test7");
                var fullworld = await vrcapi.WorldApi.Get(_world.id);
            Logger.Warn("test8");
                e.Node.Tag = fullworld;
            Logger.Warn("test9");
                world = (WorldResponse)e.Node.Tag;
            Logger.Warn("test10");
            } else { return; }
            Logger.Warn("test11");
            FillWorld(world);
            Logger.Warn("test12");
            e.Node.Nodes.Clear();
            Logger.Warn("test13");
            foreach (var instance in world.instances)
            {
            Logger.Warn("test14");
                var node = new TreeNode($"{instance.id} ({instance.occupants}/{world.capacity})");
                e.Node.Nodes.Add(node);
            }
            Logger.Warn("test15");
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
