using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VRChatLauncher.Utils;
using VRChatApi.Classes;
using System.IO;

namespace VRChatLauncher
{
    partial class Main
    {
        public static List<AvatarResponse> favorite_avatars;public static List<AvatarResponse> personal_avatars;
        public static bool avatars_loading = false;

        private Color ColorFromReleaseStatus(string releaseStatus)
        {
            switch (releaseStatus)
            {
                case "private":
                    return Color.OrangeRed;
                case "hidden":
                    return Color.Gray;
                case "public":
                    return Color.Green;
                default:
                    return Color.Orange;
            }
        }
        private Color ColorFromReleaseStatus(ReleaseStatus releaseStatus)
        {
            switch (releaseStatus)
            {
                case ReleaseStatus.Public:
                    return Color.Green;
                case ReleaseStatus.Private:
                    return Color.OrangeRed;
                case ReleaseStatus.Hidden:
                    return Color.Gray;
                default:
                    return Color.Orange;
            }
        }

        public async void SetupAvatarsAsync(bool force = false) {
            if (avatars_loading) { Logger.Warn("Avatars are already loading, try again later");  return; }
            avatars_loading = true;
            tree_avatars.Nodes[0].Nodes.Clear();
            tree_avatars.Nodes[1].Nodes.Clear();
            tree_avatars.Nodes[2].Nodes.Clear();
            if (personal_avatars == null || force) {
                if (Utils.Utils.getRipper().Exists) btn_avatar_rip.Visible = true;
                personal_avatars = await vrcapi.AvatarApi.Personal();
                Logger.Debug("Downloaded list of", personal_avatars.Count, "official personal avatars");
            }
            foreach (var avatar in personal_avatars)
            {
                var node = new TreeNode(avatar.name);
                node.Tag = avatar;
                node.ForeColor = ColorFromReleaseStatus(avatar.releaseStatus);
                tree_avatars.Nodes[0].Nodes.Add(node);
            }
            tree_avatars.Nodes[0].Text = $"Personal ({tree_avatars.Nodes[0].Nodes.Count})";

            if (favorite_avatars == null || force) {
                favorite_avatars = await vrcapi.AvatarApi.Favorites();
                Logger.Debug("Downloaded list of", favorite_avatars.Count, "official favorite avatars");
            }
            foreach (var avatar in favorite_avatars)
            {
                var node = new TreeNode(avatar.name);
                node.Tag = avatar;
                node.ForeColor = ColorFromReleaseStatus(avatar.releaseStatus);
                tree_avatars.Nodes[1].Nodes.Add(node);
            }
            tree_avatars.Nodes[1].Text = $"Official ({tree_avatars.Nodes[1].Nodes.Count} / 16)";
            avatars_loading = false;
        }
        private void FillAvatar(AvatarResponse avatar)
        {
            txt_avatar_id.Text = avatar.id;
            txt_avatar_id.Tag = avatar;
            txt_avatar_name.Text = avatar.name;
            txt_avatar_version.Text = avatar.version.ToString();
            txt_avatar_author.Text = $"{avatar.authorName} ({avatar.authorId})";
            txt_avatar_asseturl.Text = avatar.assetUrl;
            txt_avatar_description.Text = avatar.description;
        }

        private void avatars_node_selected(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null) return;
            AvatarResponse avatar = (AvatarResponse)e.Node.Tag;
            FillAvatar(avatar);
        }

        private void Btn_avatars_reload_Click(object sender, EventArgs e)
        {
            SetupAvatarsAsync(force: true);
        }

        private async void Btn_avatar_search_ClickAsync(object sender, EventArgs e)
        {
            var avatar = await vrcapi.AvatarApi.GetById(txt_avatar_id.Text);
            FillAvatar(avatar);
        }
        
        private async void Btn_avatars_profile_ClickAsync(object sender, EventArgs e)
        {
            var avatar = (AvatarResponse)txt_avatar_id.Tag;
            var user = await vrcapi.UserApi.GetById(avatar.authorId);
            FillUser(user);
            tabs_main.SelectTab(1);
        }
        
        // private List<FileInfo> tmpAvatars;
        private void Btn_avatar_rip_Click(object sender, EventArgs e)
        {
            var ripper = Utils.Utils.getRipper();
            if (!ripper.Exists) {
                MessageBox.Show($"{ripper.Name} was not found in\n\n{ripper.Directory}\n\nIf you want to use this feature, place it there.");
                return;
            }
            var avatar = (AvatarResponse)txt_avatar_id.Tag;
            var tmpPath = new DirectoryInfo(Path.GetTempPath());
            Logger.Log("Ripping avatar ", avatar.name, avatar.id.Enclose(), "to", tmpPath.FullName.Quote()+avatar.name.Ext("vrca"));
            var file = Utils.Utils.DownloadFile(avatar.assetUrl, tmpPath, avatar.name.Ext("vrca"));
            var proc = Utils.Utils.StartProcess(ripper, file.FullName.Quote());
            // proc.Exited += Proc_Exited;
        }
        /*private void Proc_Exited(object sender, EventArgs e) {
            Logger.Trace("Process has exited", sender, e);
            var file = tmpAvatars.PopAt(0);
            file.Delete();
            Logger.Log("Temp avatar file ", file.Name, "has been deleted");
        }*/
    }
}
