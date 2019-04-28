namespace VRChatLauncher
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Me");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Online");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Offline");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Friends", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Blocked");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Requests");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Search");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Personal");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Favorites");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("VRCTools");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Personal", 2, 2);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Favorites", -2, -2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabs_main = new System.Windows.Forms.TabControl();
            this.tab_news = new System.Windows.Forms.TabPage();
            this.txt_news = new System.Windows.Forms.RichTextBox();
            this.tab_users = new System.Windows.Forms.TabPage();
            this.splitContainerUsers = new System.Windows.Forms.SplitContainer();
            this.btn_users_reload = new System.Windows.Forms.Button();
            this.tree_users = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_users_save = new System.Windows.Forms.Button();
            this.btn_users_friend_add = new System.Windows.Forms.Button();
            this.btn_users_friend_remove = new System.Windows.Forms.Button();
            this.btn_users_block = new System.Windows.Forms.Button();
            this.btn_users_unblock = new System.Windows.Forms.Button();
            this.tableLayoutPanelUSers = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_users_rank = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_users_username = new System.Windows.Forms.TextBox();
            this.txt_users_status = new System.Windows.Forms.TextBox();
            this.panel_users_id = new System.Windows.Forms.Panel();
            this.btn_users_search = new System.Windows.Forms.Button();
            this.txt_users_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_user_join = new System.Windows.Forms.Button();
            this.txt_users_location = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_users_displayname = new System.Windows.Forms.TextBox();
            this.btn_users_search_name = new System.Windows.Forms.Button();
            this.txt_users_tags = new System.Windows.Forms.RichTextBox();
            this.tab_avatars = new System.Windows.Forms.TabPage();
            this.splitContainerAvatars = new System.Windows.Forms.SplitContainer();
            this.button5 = new System.Windows.Forms.Button();
            this.tree_avatars = new System.Windows.Forms.TreeView();
            this.tableLayoutPanelTEST = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_avatar_description = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_avatar_name = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_avatar_version = new System.Windows.Forms.TextBox();
            this.panel_worlds_id = new System.Windows.Forms.Panel();
            this.btn_avatar_search = new System.Windows.Forms.Button();
            this.txt_avatar_id = new System.Windows.Forms.TextBox();
            this.panel_worlds_asseturl = new System.Windows.Forms.Panel();
            this.btn_avatar_rip = new System.Windows.Forms.Button();
            this.txt_avatar_asseturl = new System.Windows.Forms.TextBox();
            this.panel_worlds_author = new System.Windows.Forms.Panel();
            this.btn_avatars_profile = new System.Windows.Forms.Button();
            this.txt_avatar_author = new System.Windows.Forms.TextBox();
            this.tab_worlds = new System.Windows.Forms.TabPage();
            this.splitContainerWOrlds = new System.Windows.Forms.SplitContainer();
            this.tree_worlds = new System.Windows.Forms.TreeView();
            this.btn_worlds_reload = new System.Windows.Forms.Button();
            this.tableLayoutPanelWorlds = new System.Windows.Forms.TableLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_world_description = new System.Windows.Forms.RichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_world_name = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_world_version = new System.Windows.Forms.TextBox();
            this.panel_words_id_2 = new System.Windows.Forms.Panel();
            this.btn_worlds_search = new System.Windows.Forms.Button();
            this.txt_world_id = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn_worlds_rip = new System.Windows.Forms.Button();
            this.txt_world_asset = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btn_worlds_author = new System.Windows.Forms.Button();
            this.txt_world_author = new System.Windows.Forms.TextBox();
            this.tab_mods = new System.Windows.Forms.TabPage();
            this.tabs_mods = new System.Windows.Forms.TabControl();
            this.tab_mods_installed = new System.Windows.Forms.TabPage();
            this.splitContainerMods = new System.Windows.Forms.SplitContainer();
            this.panel_mods_list = new System.Windows.Forms.Panel();
            this.lst_mods = new System.Windows.Forms.ListView();
            this.menu_mod = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompileModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.icons_mods = new System.Windows.Forms.ImageList(this.components);
            this.btn_mods_refresh = new System.Windows.Forms.Button();
            this.tableLayoutPanelmods = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_mod_name = new System.Windows.Forms.Label();
            this.txt_mod_description = new System.Windows.Forms.RichTextBox();
            this.txt_mod_type = new System.Windows.Forms.TextBox();
            this.lbl_mod_description = new System.Windows.Forms.Label();
            this.lbl_mod_path = new System.Windows.Forms.Label();
            this.lbl_mod_type = new System.Windows.Forms.Label();
            this.txt_mod_path = new System.Windows.Forms.TextBox();
            this.lbl_mod_author = new System.Windows.Forms.Label();
            this.txt_mod_name = new System.Windows.Forms.TextBox();
            this.lbl_mod_version = new System.Windows.Forms.Label();
            this.txt_mod_version = new System.Windows.Forms.TextBox();
            this.txt_mod_author = new System.Windows.Forms.TextBox();
            this.tab_mods_available = new System.Windows.Forms.TabPage();
            this.tab_settings = new System.Windows.Forms.TabPage();
            this.panel_setings = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_config_save = new System.Windows.Forms.Button();
            this.btn_config_apply = new System.Windows.Forms.Button();
            this.flow_settings = new System.Windows.Forms.FlowLayoutPanel();
            this.tab_log = new System.Windows.Forms.TabPage();
            this.tabs_log = new System.Windows.Forms.TabControl();
            this.tab_log_launcher = new System.Windows.Forms.TabPage();
            this.lst_log_launcher = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tab_log_game = new System.Windows.Forms.TabPage();
            this.lst_log_game = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menu_users = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.profileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.friendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_exportfriends = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_importfriends = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_status = new System.Windows.Forms.Panel();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.btn_play = new System.Windows.Forms.Button();
            this.icons_worlds = new System.Windows.Forms.ImageList(this.components);
            this.tabs_main.SuspendLayout();
            this.tab_news.SuspendLayout();
            this.tab_users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUsers)).BeginInit();
            this.splitContainerUsers.Panel1.SuspendLayout();
            this.splitContainerUsers.Panel2.SuspendLayout();
            this.splitContainerUsers.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelUSers.SuspendLayout();
            this.panel_users_id.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tab_avatars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAvatars)).BeginInit();
            this.splitContainerAvatars.Panel1.SuspendLayout();
            this.splitContainerAvatars.Panel2.SuspendLayout();
            this.splitContainerAvatars.SuspendLayout();
            this.tableLayoutPanelTEST.SuspendLayout();
            this.panel_worlds_id.SuspendLayout();
            this.panel_worlds_asseturl.SuspendLayout();
            this.panel_worlds_author.SuspendLayout();
            this.tab_worlds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWOrlds)).BeginInit();
            this.splitContainerWOrlds.Panel1.SuspendLayout();
            this.splitContainerWOrlds.Panel2.SuspendLayout();
            this.splitContainerWOrlds.SuspendLayout();
            this.tableLayoutPanelWorlds.SuspendLayout();
            this.panel_words_id_2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tab_mods.SuspendLayout();
            this.tabs_mods.SuspendLayout();
            this.tab_mods_installed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMods)).BeginInit();
            this.splitContainerMods.Panel1.SuspendLayout();
            this.splitContainerMods.Panel2.SuspendLayout();
            this.splitContainerMods.SuspendLayout();
            this.panel_mods_list.SuspendLayout();
            this.menu_mod.SuspendLayout();
            this.tableLayoutPanelmods.SuspendLayout();
            this.tab_settings.SuspendLayout();
            this.panel_setings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tab_log.SuspendLayout();
            this.tabs_log.SuspendLayout();
            this.tab_log_launcher.SuspendLayout();
            this.tab_log_game.SuspendLayout();
            this.menu_users.SuspendLayout();
            this.panel_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs_main
            // 
            this.tabs_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs_main.Controls.Add(this.tab_news);
            this.tabs_main.Controls.Add(this.tab_users);
            this.tabs_main.Controls.Add(this.tab_avatars);
            this.tabs_main.Controls.Add(this.tab_worlds);
            this.tabs_main.Controls.Add(this.tab_mods);
            this.tabs_main.Controls.Add(this.tab_settings);
            this.tabs_main.Controls.Add(this.tab_log);
            this.tabs_main.Controls.Add(this.tabPage1);
            this.tabs_main.Location = new System.Drawing.Point(0, 0);
            this.tabs_main.Name = "tabs_main";
            this.tabs_main.SelectedIndex = 0;
            this.tabs_main.Size = new System.Drawing.Size(913, 386);
            this.tabs_main.TabIndex = 1;
            this.tabs_main.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_changedAsync);
            // 
            // tab_news
            // 
            this.tab_news.Controls.Add(this.txt_news);
            this.tab_news.Location = new System.Drawing.Point(4, 22);
            this.tab_news.Name = "tab_news";
            this.tab_news.Padding = new System.Windows.Forms.Padding(3);
            this.tab_news.Size = new System.Drawing.Size(905, 360);
            this.tab_news.TabIndex = 0;
            this.tab_news.Text = "News";
            this.tab_news.UseVisualStyleBackColor = true;
            // 
            // txt_news
            // 
            this.txt_news.AutoWordSelection = true;
            this.txt_news.BulletIndent = 1;
            this.txt_news.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_news.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_news.Location = new System.Drawing.Point(3, 3);
            this.txt_news.Name = "txt_news";
            this.txt_news.ReadOnly = true;
            this.txt_news.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txt_news.ShortcutsEnabled = false;
            this.txt_news.Size = new System.Drawing.Size(899, 354);
            this.txt_news.TabIndex = 0;
            this.txt_news.Text = "Fetching news ...";
            // 
            // tab_users
            // 
            this.tab_users.Controls.Add(this.splitContainerUsers);
            this.tab_users.Location = new System.Drawing.Point(4, 22);
            this.tab_users.Name = "tab_users";
            this.tab_users.Padding = new System.Windows.Forms.Padding(3);
            this.tab_users.Size = new System.Drawing.Size(905, 360);
            this.tab_users.TabIndex = 1;
            this.tab_users.Text = "Users";
            this.tab_users.UseVisualStyleBackColor = true;
            // 
            // splitContainerUsers
            // 
            this.splitContainerUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUsers.Location = new System.Drawing.Point(3, 3);
            this.splitContainerUsers.Name = "splitContainerUsers";
            // 
            // splitContainerUsers.Panel1
            // 
            this.splitContainerUsers.Panel1.Controls.Add(this.btn_users_reload);
            this.splitContainerUsers.Panel1.Controls.Add(this.tree_users);
            // 
            // splitContainerUsers.Panel2
            // 
            this.splitContainerUsers.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainerUsers.Panel2.Controls.Add(this.tableLayoutPanelUSers);
            this.splitContainerUsers.Size = new System.Drawing.Size(899, 354);
            this.splitContainerUsers.SplitterDistance = 187;
            this.splitContainerUsers.TabIndex = 0;
            // 
            // btn_users_reload
            // 
            this.btn_users_reload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_users_reload.Location = new System.Drawing.Point(0, 331);
            this.btn_users_reload.Name = "btn_users_reload";
            this.btn_users_reload.Size = new System.Drawing.Size(187, 23);
            this.btn_users_reload.TabIndex = 23;
            this.btn_users_reload.Text = "Reload";
            this.btn_users_reload.UseVisualStyleBackColor = true;
            this.btn_users_reload.Click += new System.EventHandler(this.Btn_users_reload_Click);
            // 
            // tree_users
            // 
            this.tree_users.Dock = System.Windows.Forms.DockStyle.Top;
            this.tree_users.Location = new System.Drawing.Point(0, 0);
            this.tree_users.Name = "tree_users";
            treeNode1.Name = "node_user_self";
            treeNode1.Text = "Me";
            treeNode2.Name = "Node3";
            treeNode2.Text = "Online";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Offline";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Friends";
            treeNode4.ToolTipText = "Your VRChat friends";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Blocked";
            treeNode5.ToolTipText = "Avatars favorited though VRChat";
            treeNode6.Name = "Node4";
            treeNode6.Text = "Requests";
            treeNode6.ToolTipText = "Users that want to become your friend";
            treeNode7.Name = "node_users_search";
            treeNode7.Text = "Search";
            this.tree_users.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.tree_users.Size = new System.Drawing.Size(187, 325);
            this.tree_users.TabIndex = 22;
            this.tree_users.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.users_node_selected);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_users_save);
            this.flowLayoutPanel1.Controls.Add(this.btn_users_friend_add);
            this.flowLayoutPanel1.Controls.Add(this.btn_users_friend_remove);
            this.flowLayoutPanel1.Controls.Add(this.btn_users_block);
            this.flowLayoutPanel1.Controls.Add(this.btn_users_unblock);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 315);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(702, 39);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // btn_users_save
            // 
            this.btn_users_save.Location = new System.Drawing.Point(3, 3);
            this.btn_users_save.Name = "btn_users_save";
            this.btn_users_save.Size = new System.Drawing.Size(90, 33);
            this.btn_users_save.TabIndex = 15;
            this.btn_users_save.Text = "Save";
            this.btn_users_save.UseVisualStyleBackColor = true;
            this.btn_users_save.Visible = false;
            this.btn_users_save.Click += new System.EventHandler(this.btn_users_save_click);
            // 
            // btn_users_friend_add
            // 
            this.btn_users_friend_add.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_users_friend_add.Location = new System.Drawing.Point(99, 3);
            this.btn_users_friend_add.Name = "btn_users_friend_add";
            this.btn_users_friend_add.Size = new System.Drawing.Size(90, 33);
            this.btn_users_friend_add.TabIndex = 16;
            this.btn_users_friend_add.Text = "Add Friend";
            this.btn_users_friend_add.UseVisualStyleBackColor = true;
            this.btn_users_friend_add.Visible = false;
            this.btn_users_friend_add.Click += new System.EventHandler(this.Btn_users_friend_add_Click);
            // 
            // btn_users_friend_remove
            // 
            this.btn_users_friend_remove.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_users_friend_remove.Location = new System.Drawing.Point(195, 3);
            this.btn_users_friend_remove.Name = "btn_users_friend_remove";
            this.btn_users_friend_remove.Size = new System.Drawing.Size(90, 33);
            this.btn_users_friend_remove.TabIndex = 17;
            this.btn_users_friend_remove.Text = "Remove Friend";
            this.btn_users_friend_remove.UseVisualStyleBackColor = true;
            this.btn_users_friend_remove.Visible = false;
            this.btn_users_friend_remove.Click += new System.EventHandler(this.Btn_users_friend_remove_Click);
            // 
            // btn_users_block
            // 
            this.btn_users_block.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_users_block.Location = new System.Drawing.Point(291, 3);
            this.btn_users_block.Name = "btn_users_block";
            this.btn_users_block.Size = new System.Drawing.Size(90, 33);
            this.btn_users_block.TabIndex = 18;
            this.btn_users_block.Text = "Block";
            this.btn_users_block.UseVisualStyleBackColor = true;
            this.btn_users_block.Visible = false;
            this.btn_users_block.Click += new System.EventHandler(this.Btn_users_block_Click);
            // 
            // btn_users_unblock
            // 
            this.btn_users_unblock.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_users_unblock.Location = new System.Drawing.Point(387, 3);
            this.btn_users_unblock.Name = "btn_users_unblock";
            this.btn_users_unblock.Size = new System.Drawing.Size(90, 33);
            this.btn_users_unblock.TabIndex = 19;
            this.btn_users_unblock.Text = "Unblock";
            this.btn_users_unblock.UseVisualStyleBackColor = true;
            this.btn_users_unblock.Visible = false;
            this.btn_users_unblock.Click += new System.EventHandler(this.Btn_users_unblock_Click);
            // 
            // tableLayoutPanelUSers
            // 
            this.tableLayoutPanelUSers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelUSers.ColumnCount = 2;
            this.tableLayoutPanelUSers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.64407F));
            this.tableLayoutPanelUSers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.35593F));
            this.tableLayoutPanelUSers.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanelUSers.Controls.Add(this.txt_users_rank, 1, 4);
            this.tableLayoutPanelUSers.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanelUSers.Controls.Add(this.label19, 0, 4);
            this.tableLayoutPanelUSers.Controls.Add(this.label20, 0, 3);
            this.tableLayoutPanelUSers.Controls.Add(this.label21, 0, 2);
            this.tableLayoutPanelUSers.Controls.Add(this.txt_users_username, 1, 2);
            this.tableLayoutPanelUSers.Controls.Add(this.txt_users_status, 1, 3);
            this.tableLayoutPanelUSers.Controls.Add(this.panel_users_id, 1, 0);
            this.tableLayoutPanelUSers.Controls.Add(this.label1, 0, 5);
            this.tableLayoutPanelUSers.Controls.Add(this.label17, 0, 6);
            this.tableLayoutPanelUSers.Controls.Add(this.panel2, 1, 5);
            this.tableLayoutPanelUSers.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanelUSers.Controls.Add(this.txt_users_tags, 1, 6);
            this.tableLayoutPanelUSers.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelUSers.Name = "tableLayoutPanelUSers";
            this.tableLayoutPanelUSers.RowCount = 7;
            this.tableLayoutPanelUSers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelUSers.Size = new System.Drawing.Size(708, 312);
            this.tableLayoutPanelUSers.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Display Name:";
            // 
            // txt_users_rank
            // 
            this.txt_users_rank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_users_rank.Location = new System.Drawing.Point(135, 111);
            this.txt_users_rank.Name = "txt_users_rank";
            this.txt_users_rank.ReadOnly = true;
            this.txt_users_rank.Size = new System.Drawing.Size(570, 20);
            this.txt_users_rank.TabIndex = 9;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "ID:";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Rank:";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 88);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "Status:";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 62);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "Username:";
            // 
            // txt_users_username
            // 
            this.txt_users_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_users_username.Location = new System.Drawing.Point(135, 59);
            this.txt_users_username.Name = "txt_users_username";
            this.txt_users_username.ReadOnly = true;
            this.txt_users_username.Size = new System.Drawing.Size(570, 20);
            this.txt_users_username.TabIndex = 5;
            // 
            // txt_users_status
            // 
            this.txt_users_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_users_status.Location = new System.Drawing.Point(135, 85);
            this.txt_users_status.Name = "txt_users_status";
            this.txt_users_status.ReadOnly = true;
            this.txt_users_status.Size = new System.Drawing.Size(570, 20);
            this.txt_users_status.TabIndex = 7;
            // 
            // panel_users_id
            // 
            this.panel_users_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_users_id.Controls.Add(this.btn_users_search);
            this.panel_users_id.Controls.Add(this.txt_users_id);
            this.panel_users_id.Location = new System.Drawing.Point(135, 3);
            this.panel_users_id.Name = "panel_users_id";
            this.panel_users_id.Size = new System.Drawing.Size(570, 23);
            this.panel_users_id.TabIndex = 13;
            // 
            // btn_users_search
            // 
            this.btn_users_search.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_users_search.Location = new System.Drawing.Point(489, 0);
            this.btn_users_search.Name = "btn_users_search";
            this.btn_users_search.Size = new System.Drawing.Size(81, 23);
            this.btn_users_search.TabIndex = 1;
            this.btn_users_search.Text = "Search";
            this.btn_users_search.UseVisualStyleBackColor = true;
            this.btn_users_search.Click += new System.EventHandler(this.Btn_users_search_ClickAsync);
            // 
            // txt_users_id
            // 
            this.txt_users_id.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_users_id.Location = new System.Drawing.Point(0, 1);
            this.txt_users_id.Name = "txt_users_id";
            this.txt_users_id.Size = new System.Drawing.Size(483, 20);
            this.txt_users_id.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Location:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 163);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "Tags:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_user_join);
            this.panel2.Controls.Add(this.txt_users_location);
            this.panel2.Location = new System.Drawing.Point(135, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 23);
            this.panel2.TabIndex = 15;
            // 
            // btn_user_join
            // 
            this.btn_user_join.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_user_join.Location = new System.Drawing.Point(489, 0);
            this.btn_user_join.Name = "btn_user_join";
            this.btn_user_join.Size = new System.Drawing.Size(81, 23);
            this.btn_user_join.TabIndex = 2;
            this.btn_user_join.Text = "Join";
            this.btn_user_join.UseVisualStyleBackColor = true;
            this.btn_user_join.Click += new System.EventHandler(this.Btn_user_join_Click);
            // 
            // txt_users_location
            // 
            this.txt_users_location.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_users_location.Location = new System.Drawing.Point(0, 1);
            this.txt_users_location.Name = "txt_users_location";
            this.txt_users_location.ReadOnly = true;
            this.txt_users_location.Size = new System.Drawing.Size(483, 20);
            this.txt_users_location.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.txt_users_displayname);
            this.panel3.Controls.Add(this.btn_users_search_name);
            this.panel3.Location = new System.Drawing.Point(135, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(570, 21);
            this.panel3.TabIndex = 16;
            // 
            // txt_users_displayname
            // 
            this.txt_users_displayname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_users_displayname.Location = new System.Drawing.Point(0, 0);
            this.txt_users_displayname.Name = "txt_users_displayname";
            this.txt_users_displayname.Size = new System.Drawing.Size(483, 20);
            this.txt_users_displayname.TabIndex = 3;
            // 
            // btn_users_search_name
            // 
            this.btn_users_search_name.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_users_search_name.Location = new System.Drawing.Point(489, 0);
            this.btn_users_search_name.Name = "btn_users_search_name";
            this.btn_users_search_name.Size = new System.Drawing.Size(81, 21);
            this.btn_users_search_name.TabIndex = 2;
            this.btn_users_search_name.Text = "Search";
            this.btn_users_search_name.UseVisualStyleBackColor = true;
            this.btn_users_search_name.Click += new System.EventHandler(this.Btn_users_search_name_Click);
            // 
            // txt_users_tags
            // 
            this.txt_users_tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_users_tags.Location = new System.Drawing.Point(135, 166);
            this.txt_users_tags.Name = "txt_users_tags";
            this.txt_users_tags.ReadOnly = true;
            this.txt_users_tags.Size = new System.Drawing.Size(570, 143);
            this.txt_users_tags.TabIndex = 17;
            this.txt_users_tags.Text = "";
            // 
            // tab_avatars
            // 
            this.tab_avatars.Controls.Add(this.splitContainerAvatars);
            this.tab_avatars.Location = new System.Drawing.Point(4, 22);
            this.tab_avatars.Name = "tab_avatars";
            this.tab_avatars.Size = new System.Drawing.Size(905, 360);
            this.tab_avatars.TabIndex = 2;
            this.tab_avatars.Text = "Avatars";
            this.tab_avatars.UseVisualStyleBackColor = true;
            // 
            // splitContainerAvatars
            // 
            this.splitContainerAvatars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAvatars.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAvatars.Name = "splitContainerAvatars";
            // 
            // splitContainerAvatars.Panel1
            // 
            this.splitContainerAvatars.Panel1.Controls.Add(this.button5);
            this.splitContainerAvatars.Panel1.Controls.Add(this.tree_avatars);
            // 
            // splitContainerAvatars.Panel2
            // 
            this.splitContainerAvatars.Panel2.Controls.Add(this.tableLayoutPanelTEST);
            this.splitContainerAvatars.Size = new System.Drawing.Size(905, 360);
            this.splitContainerAvatars.SplitterDistance = 177;
            this.splitContainerAvatars.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button5.Location = new System.Drawing.Point(0, 337);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(177, 23);
            this.button5.TabIndex = 25;
            this.button5.Text = "Reload";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Btn_avatars_reload_Click);
            // 
            // tree_avatars
            // 
            this.tree_avatars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_avatars.Location = new System.Drawing.Point(0, 0);
            this.tree_avatars.Name = "tree_avatars";
            treeNode8.Name = "Node0";
            treeNode8.Text = "Personal";
            treeNode9.Name = "Node1";
            treeNode9.Text = "Favorites";
            treeNode10.Name = "Node2";
            treeNode10.Text = "VRCTools";
            this.tree_avatars.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            this.tree_avatars.Size = new System.Drawing.Size(177, 360);
            this.tree_avatars.TabIndex = 24;
            this.tree_avatars.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.avatars_node_selected);
            // 
            // tableLayoutPanelTEST
            // 
            this.tableLayoutPanelTEST.ColumnCount = 2;
            this.tableLayoutPanelTEST.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelTEST.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33333F));
            this.tableLayoutPanelTEST.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanelTEST.Controls.Add(this.txt_avatar_description, 1, 5);
            this.tableLayoutPanelTEST.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanelTEST.Controls.Add(this.lbl, 0, 0);
            this.tableLayoutPanelTEST.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanelTEST.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanelTEST.Controls.Add(this.txt_avatar_name, 1, 1);
            this.tableLayoutPanelTEST.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanelTEST.Controls.Add(this.txt_avatar_version, 1, 2);
            this.tableLayoutPanelTEST.Controls.Add(this.panel_worlds_id, 1, 0);
            this.tableLayoutPanelTEST.Controls.Add(this.panel_worlds_asseturl, 1, 4);
            this.tableLayoutPanelTEST.Controls.Add(this.panel_worlds_author, 1, 3);
            this.tableLayoutPanelTEST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTEST.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTEST.Name = "tableLayoutPanelTEST";
            this.tableLayoutPanelTEST.RowCount = 6;
            this.tableLayoutPanelTEST.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTEST.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTEST.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTEST.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTEST.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelTEST.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTEST.Size = new System.Drawing.Size(724, 360);
            this.tableLayoutPanelTEST.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Name:";
            // 
            // txt_avatar_description
            // 
            this.txt_avatar_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_avatar_description.Location = new System.Drawing.Point(123, 135);
            this.txt_avatar_description.Name = "txt_avatar_description";
            this.txt_avatar_description.ReadOnly = true;
            this.txt_avatar_description.Size = new System.Drawing.Size(598, 222);
            this.txt_avatar_description.TabIndex = 12;
            this.txt_avatar_description.Text = "";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 239);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Description:";
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(3, 6);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(21, 13);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "ID:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Asset URL:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Author:";
            // 
            // txt_avatar_name
            // 
            this.txt_avatar_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_avatar_name.Location = new System.Drawing.Point(123, 29);
            this.txt_avatar_name.Name = "txt_avatar_name";
            this.txt_avatar_name.ReadOnly = true;
            this.txt_avatar_name.Size = new System.Drawing.Size(598, 20);
            this.txt_avatar_name.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 58);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Version:";
            // 
            // txt_avatar_version
            // 
            this.txt_avatar_version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_avatar_version.Location = new System.Drawing.Point(123, 55);
            this.txt_avatar_version.Name = "txt_avatar_version";
            this.txt_avatar_version.ReadOnly = true;
            this.txt_avatar_version.Size = new System.Drawing.Size(598, 20);
            this.txt_avatar_version.TabIndex = 5;
            // 
            // panel_worlds_id
            // 
            this.panel_worlds_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_worlds_id.Controls.Add(this.btn_avatar_search);
            this.panel_worlds_id.Controls.Add(this.txt_avatar_id);
            this.panel_worlds_id.Location = new System.Drawing.Point(123, 3);
            this.panel_worlds_id.Name = "panel_worlds_id";
            this.panel_worlds_id.Size = new System.Drawing.Size(598, 20);
            this.panel_worlds_id.TabIndex = 13;
            // 
            // btn_avatar_search
            // 
            this.btn_avatar_search.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_avatar_search.Location = new System.Drawing.Point(523, 0);
            this.btn_avatar_search.Name = "btn_avatar_search";
            this.btn_avatar_search.Size = new System.Drawing.Size(75, 20);
            this.btn_avatar_search.TabIndex = 1;
            this.btn_avatar_search.Text = "Search";
            this.btn_avatar_search.UseVisualStyleBackColor = true;
            this.btn_avatar_search.Click += new System.EventHandler(this.Btn_avatar_search_ClickAsync);
            // 
            // txt_avatar_id
            // 
            this.txt_avatar_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_avatar_id.Location = new System.Drawing.Point(0, 0);
            this.txt_avatar_id.Name = "txt_avatar_id";
            this.txt_avatar_id.Size = new System.Drawing.Size(517, 20);
            this.txt_avatar_id.TabIndex = 0;
            // 
            // panel_worlds_asseturl
            // 
            this.panel_worlds_asseturl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_worlds_asseturl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_worlds_asseturl.Controls.Add(this.btn_avatar_rip);
            this.panel_worlds_asseturl.Controls.Add(this.txt_avatar_asseturl);
            this.panel_worlds_asseturl.Location = new System.Drawing.Point(123, 109);
            this.panel_worlds_asseturl.Name = "panel_worlds_asseturl";
            this.panel_worlds_asseturl.Size = new System.Drawing.Size(598, 20);
            this.panel_worlds_asseturl.TabIndex = 14;
            // 
            // btn_avatar_rip
            // 
            this.btn_avatar_rip.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_avatar_rip.Location = new System.Drawing.Point(523, 0);
            this.btn_avatar_rip.Name = "btn_avatar_rip";
            this.btn_avatar_rip.Size = new System.Drawing.Size(75, 20);
            this.btn_avatar_rip.TabIndex = 1;
            this.btn_avatar_rip.Text = "Rip";
            this.btn_avatar_rip.UseVisualStyleBackColor = true;
            this.btn_avatar_rip.Click += new System.EventHandler(this.Btn_avatar_rip_Click);
            // 
            // txt_avatar_asseturl
            // 
            this.txt_avatar_asseturl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_avatar_asseturl.Location = new System.Drawing.Point(0, 0);
            this.txt_avatar_asseturl.Name = "txt_avatar_asseturl";
            this.txt_avatar_asseturl.ReadOnly = true;
            this.txt_avatar_asseturl.Size = new System.Drawing.Size(517, 20);
            this.txt_avatar_asseturl.TabIndex = 0;
            // 
            // panel_worlds_author
            // 
            this.panel_worlds_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_worlds_author.Controls.Add(this.btn_avatars_profile);
            this.panel_worlds_author.Controls.Add(this.txt_avatar_author);
            this.panel_worlds_author.Location = new System.Drawing.Point(123, 81);
            this.panel_worlds_author.Name = "panel_worlds_author";
            this.panel_worlds_author.Size = new System.Drawing.Size(598, 22);
            this.panel_worlds_author.TabIndex = 15;
            // 
            // btn_avatars_profile
            // 
            this.btn_avatars_profile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_avatars_profile.Location = new System.Drawing.Point(523, 0);
            this.btn_avatars_profile.Name = "btn_avatars_profile";
            this.btn_avatars_profile.Size = new System.Drawing.Size(75, 22);
            this.btn_avatars_profile.TabIndex = 10;
            this.btn_avatars_profile.Text = "Profile";
            this.btn_avatars_profile.UseVisualStyleBackColor = true;
            this.btn_avatars_profile.Click += new System.EventHandler(this.Btn_avatars_profile_ClickAsync);
            // 
            // txt_avatar_author
            // 
            this.txt_avatar_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_avatar_author.Location = new System.Drawing.Point(0, 3);
            this.txt_avatar_author.Name = "txt_avatar_author";
            this.txt_avatar_author.ReadOnly = true;
            this.txt_avatar_author.Size = new System.Drawing.Size(517, 20);
            this.txt_avatar_author.TabIndex = 9;
            // 
            // tab_worlds
            // 
            this.tab_worlds.Controls.Add(this.splitContainerWOrlds);
            this.tab_worlds.Location = new System.Drawing.Point(4, 22);
            this.tab_worlds.Name = "tab_worlds";
            this.tab_worlds.Size = new System.Drawing.Size(905, 360);
            this.tab_worlds.TabIndex = 3;
            this.tab_worlds.Text = "Worlds";
            this.tab_worlds.UseVisualStyleBackColor = true;
            // 
            // splitContainerWOrlds
            // 
            this.splitContainerWOrlds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerWOrlds.Location = new System.Drawing.Point(0, 0);
            this.splitContainerWOrlds.Name = "splitContainerWOrlds";
            // 
            // splitContainerWOrlds.Panel1
            // 
            this.splitContainerWOrlds.Panel1.Controls.Add(this.tree_worlds);
            this.splitContainerWOrlds.Panel1.Controls.Add(this.btn_worlds_reload);
            // 
            // splitContainerWOrlds.Panel2
            // 
            this.splitContainerWOrlds.Panel2.Controls.Add(this.tableLayoutPanelWorlds);
            this.splitContainerWOrlds.Size = new System.Drawing.Size(905, 360);
            this.splitContainerWOrlds.SplitterDistance = 177;
            this.splitContainerWOrlds.TabIndex = 1;
            // 
            // tree_worlds
            // 
            this.tree_worlds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_worlds.Location = new System.Drawing.Point(0, 0);
            this.tree_worlds.Name = "tree_worlds";
            treeNode11.ImageIndex = 2;
            treeNode11.Name = "Node0";
            treeNode11.SelectedImageIndex = 2;
            treeNode11.Text = "Personal";
            treeNode11.ToolTipText = "Worlds uploaded by you";
            treeNode12.ImageIndex = -2;
            treeNode12.Name = "Node0";
            treeNode12.SelectedImageIndex = -2;
            treeNode12.Text = "Favorites";
            treeNode12.ToolTipText = "Worlds favorited though VRChat";
            this.tree_worlds.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            this.tree_worlds.Size = new System.Drawing.Size(177, 337);
            this.tree_worlds.TabIndex = 22;
            this.tree_worlds.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.worlds_node_selectedAsync);
            // 
            // btn_worlds_reload
            // 
            this.btn_worlds_reload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_worlds_reload.Location = new System.Drawing.Point(0, 337);
            this.btn_worlds_reload.Name = "btn_worlds_reload";
            this.btn_worlds_reload.Size = new System.Drawing.Size(177, 23);
            this.btn_worlds_reload.TabIndex = 21;
            this.btn_worlds_reload.Text = "Reload";
            this.btn_worlds_reload.UseVisualStyleBackColor = true;
            this.btn_worlds_reload.Click += new System.EventHandler(this.Btn_worlds_reload_Click);
            // 
            // tableLayoutPanelWorlds
            // 
            this.tableLayoutPanelWorlds.ColumnCount = 2;
            this.tableLayoutPanelWorlds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelWorlds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33333F));
            this.tableLayoutPanelWorlds.Controls.Add(this.label22, 0, 1);
            this.tableLayoutPanelWorlds.Controls.Add(this.txt_world_description, 1, 5);
            this.tableLayoutPanelWorlds.Controls.Add(this.label23, 0, 5);
            this.tableLayoutPanelWorlds.Controls.Add(this.label24, 0, 0);
            this.tableLayoutPanelWorlds.Controls.Add(this.label25, 0, 4);
            this.tableLayoutPanelWorlds.Controls.Add(this.label26, 0, 3);
            this.tableLayoutPanelWorlds.Controls.Add(this.txt_world_name, 1, 1);
            this.tableLayoutPanelWorlds.Controls.Add(this.label27, 0, 2);
            this.tableLayoutPanelWorlds.Controls.Add(this.txt_world_version, 1, 2);
            this.tableLayoutPanelWorlds.Controls.Add(this.panel_words_id_2, 1, 0);
            this.tableLayoutPanelWorlds.Controls.Add(this.panel8, 1, 4);
            this.tableLayoutPanelWorlds.Controls.Add(this.panel9, 1, 3);
            this.tableLayoutPanelWorlds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWorlds.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelWorlds.Name = "tableLayoutPanelWorlds";
            this.tableLayoutPanelWorlds.RowCount = 6;
            this.tableLayoutPanelWorlds.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelWorlds.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelWorlds.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelWorlds.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelWorlds.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelWorlds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWorlds.Size = new System.Drawing.Size(724, 360);
            this.tableLayoutPanelWorlds.TabIndex = 22;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 32);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(38, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "Name:";
            // 
            // txt_world_description
            // 
            this.txt_world_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_world_description.Location = new System.Drawing.Point(123, 135);
            this.txt_world_description.Name = "txt_world_description";
            this.txt_world_description.ReadOnly = true;
            this.txt_world_description.Size = new System.Drawing.Size(598, 222);
            this.txt_world_description.TabIndex = 12;
            this.txt_world_description.Text = "";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 239);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 13);
            this.label23.TabIndex = 11;
            this.label23.Text = "Description:";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(21, 13);
            this.label24.TabIndex = 4;
            this.label24.Text = "ID:";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 112);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 13);
            this.label25.TabIndex = 10;
            this.label25.Text = "Asset URL:";
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(3, 85);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 13);
            this.label26.TabIndex = 8;
            this.label26.Text = "Author:";
            // 
            // txt_world_name
            // 
            this.txt_world_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_world_name.Location = new System.Drawing.Point(123, 29);
            this.txt_world_name.Name = "txt_world_name";
            this.txt_world_name.ReadOnly = true;
            this.txt_world_name.Size = new System.Drawing.Size(598, 20);
            this.txt_world_name.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 58);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(45, 13);
            this.label27.TabIndex = 6;
            this.label27.Text = "Version:";
            // 
            // txt_world_version
            // 
            this.txt_world_version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_world_version.Location = new System.Drawing.Point(123, 55);
            this.txt_world_version.Name = "txt_world_version";
            this.txt_world_version.ReadOnly = true;
            this.txt_world_version.Size = new System.Drawing.Size(598, 20);
            this.txt_world_version.TabIndex = 5;
            // 
            // panel_words_id_2
            // 
            this.panel_words_id_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_words_id_2.Controls.Add(this.btn_worlds_search);
            this.panel_words_id_2.Controls.Add(this.txt_world_id);
            this.panel_words_id_2.Location = new System.Drawing.Point(123, 3);
            this.panel_words_id_2.Name = "panel_words_id_2";
            this.panel_words_id_2.Size = new System.Drawing.Size(598, 20);
            this.panel_words_id_2.TabIndex = 13;
            // 
            // btn_worlds_search
            // 
            this.btn_worlds_search.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_worlds_search.Location = new System.Drawing.Point(523, 0);
            this.btn_worlds_search.Name = "btn_worlds_search";
            this.btn_worlds_search.Size = new System.Drawing.Size(75, 20);
            this.btn_worlds_search.TabIndex = 1;
            this.btn_worlds_search.Text = "Search";
            this.btn_worlds_search.UseVisualStyleBackColor = true;
            this.btn_worlds_search.Click += new System.EventHandler(this.Btn_worlds_search_ClickAsync);
            // 
            // txt_world_id
            // 
            this.txt_world_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_world_id.Location = new System.Drawing.Point(0, 0);
            this.txt_world_id.Name = "txt_world_id";
            this.txt_world_id.Size = new System.Drawing.Size(517, 20);
            this.txt_world_id.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel8.Controls.Add(this.btn_worlds_rip);
            this.panel8.Controls.Add(this.txt_world_asset);
            this.panel8.Location = new System.Drawing.Point(123, 109);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(598, 20);
            this.panel8.TabIndex = 14;
            // 
            // btn_worlds_rip
            // 
            this.btn_worlds_rip.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_worlds_rip.Location = new System.Drawing.Point(523, 0);
            this.btn_worlds_rip.Name = "btn_worlds_rip";
            this.btn_worlds_rip.Size = new System.Drawing.Size(75, 20);
            this.btn_worlds_rip.TabIndex = 1;
            this.btn_worlds_rip.Text = "Rip";
            this.btn_worlds_rip.UseVisualStyleBackColor = true;
            this.btn_worlds_rip.Visible = false;
            this.btn_worlds_rip.Click += new System.EventHandler(this.Btn_worlds_rip_Click);
            // 
            // txt_world_asset
            // 
            this.txt_world_asset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_world_asset.Location = new System.Drawing.Point(0, 0);
            this.txt_world_asset.Name = "txt_world_asset";
            this.txt_world_asset.ReadOnly = true;
            this.txt_world_asset.Size = new System.Drawing.Size(517, 20);
            this.txt_world_asset.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.btn_worlds_author);
            this.panel9.Controls.Add(this.txt_world_author);
            this.panel9.Location = new System.Drawing.Point(123, 81);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(598, 22);
            this.panel9.TabIndex = 15;
            // 
            // btn_worlds_author
            // 
            this.btn_worlds_author.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_worlds_author.Location = new System.Drawing.Point(523, 0);
            this.btn_worlds_author.Name = "btn_worlds_author";
            this.btn_worlds_author.Size = new System.Drawing.Size(75, 22);
            this.btn_worlds_author.TabIndex = 10;
            this.btn_worlds_author.Text = "Profile";
            this.btn_worlds_author.UseVisualStyleBackColor = true;
            this.btn_worlds_author.Click += new System.EventHandler(this.Btn_worlds_author_ClickAsync);
            // 
            // txt_world_author
            // 
            this.txt_world_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_world_author.Location = new System.Drawing.Point(0, 3);
            this.txt_world_author.Name = "txt_world_author";
            this.txt_world_author.ReadOnly = true;
            this.txt_world_author.Size = new System.Drawing.Size(517, 20);
            this.txt_world_author.TabIndex = 9;
            // 
            // tab_mods
            // 
            this.tab_mods.Controls.Add(this.tabs_mods);
            this.tab_mods.Location = new System.Drawing.Point(4, 22);
            this.tab_mods.Name = "tab_mods";
            this.tab_mods.Size = new System.Drawing.Size(905, 360);
            this.tab_mods.TabIndex = 5;
            this.tab_mods.Text = "Mods";
            this.tab_mods.UseVisualStyleBackColor = true;
            // 
            // tabs_mods
            // 
            this.tabs_mods.Controls.Add(this.tab_mods_installed);
            this.tabs_mods.Controls.Add(this.tab_mods_available);
            this.tabs_mods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_mods.Location = new System.Drawing.Point(0, 0);
            this.tabs_mods.Name = "tabs_mods";
            this.tabs_mods.SelectedIndex = 0;
            this.tabs_mods.Size = new System.Drawing.Size(905, 360);
            this.tabs_mods.TabIndex = 0;
            // 
            // tab_mods_installed
            // 
            this.tab_mods_installed.Controls.Add(this.splitContainerMods);
            this.tab_mods_installed.Location = new System.Drawing.Point(4, 22);
            this.tab_mods_installed.Name = "tab_mods_installed";
            this.tab_mods_installed.Padding = new System.Windows.Forms.Padding(3);
            this.tab_mods_installed.Size = new System.Drawing.Size(897, 334);
            this.tab_mods_installed.TabIndex = 0;
            this.tab_mods_installed.Text = "Installed";
            this.tab_mods_installed.UseVisualStyleBackColor = true;
            // 
            // splitContainerMods
            // 
            this.splitContainerMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMods.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMods.Name = "splitContainerMods";
            // 
            // splitContainerMods.Panel1
            // 
            this.splitContainerMods.Panel1.Controls.Add(this.panel_mods_list);
            // 
            // splitContainerMods.Panel2
            // 
            this.splitContainerMods.Panel2.Controls.Add(this.tableLayoutPanelmods);
            this.splitContainerMods.Size = new System.Drawing.Size(891, 328);
            this.splitContainerMods.SplitterDistance = 166;
            this.splitContainerMods.TabIndex = 2;
            // 
            // panel_mods_list
            // 
            this.panel_mods_list.Controls.Add(this.lst_mods);
            this.panel_mods_list.Controls.Add(this.btn_mods_refresh);
            this.panel_mods_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_mods_list.Location = new System.Drawing.Point(0, 0);
            this.panel_mods_list.Name = "panel_mods_list";
            this.panel_mods_list.Size = new System.Drawing.Size(166, 328);
            this.panel_mods_list.TabIndex = 18;
            // 
            // lst_mods
            // 
            this.lst_mods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_mods.ContextMenuStrip = this.menu_mod;
            this.lst_mods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_mods.FullRowSelect = true;
            this.lst_mods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_mods.LargeImageList = this.icons_mods;
            this.lst_mods.Location = new System.Drawing.Point(0, 0);
            this.lst_mods.MultiSelect = false;
            this.lst_mods.Name = "lst_mods";
            this.lst_mods.ShowGroups = false;
            this.lst_mods.ShowItemToolTips = true;
            this.lst_mods.Size = new System.Drawing.Size(166, 305);
            this.lst_mods.SmallImageList = this.icons_mods;
            this.lst_mods.TabIndex = 13;
            this.lst_mods.UseCompatibleStateImageBehavior = false;
            this.lst_mods.View = System.Windows.Forms.View.SmallIcon;
            this.lst_mods.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.on_list_mods_ItemSelectionChanged);
            // 
            // menu_mod
            // 
            this.menu_mod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.toggleModToolStripMenuItem,
            this.deleteModToolStripMenuItem,
            this.decompileModToolStripMenuItem});
            this.menu_mod.Name = "menu_mod";
            this.menu_mod.Size = new System.Drawing.Size(202, 92);
            this.menu_mod.Opening += new System.ComponentModel.CancelEventHandler(this.Menu_mod_Opening);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openFolderToolStripMenuItem.Text = "Open Containing Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItem_Click);
            // 
            // toggleModToolStripMenuItem
            // 
            this.toggleModToolStripMenuItem.Name = "toggleModToolStripMenuItem";
            this.toggleModToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.toggleModToolStripMenuItem.Text = "Disable";
            this.toggleModToolStripMenuItem.Click += new System.EventHandler(this.ToggleModToolStripMenuItem_Click);
            // 
            // deleteModToolStripMenuItem
            // 
            this.deleteModToolStripMenuItem.Name = "deleteModToolStripMenuItem";
            this.deleteModToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.deleteModToolStripMenuItem.Text = "Delete";
            this.deleteModToolStripMenuItem.Click += new System.EventHandler(this.DeleteModToolStripMenuItem_Click);
            // 
            // decompileModToolStripMenuItem
            // 
            this.decompileModToolStripMenuItem.Name = "decompileModToolStripMenuItem";
            this.decompileModToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.decompileModToolStripMenuItem.Text = "Decompile";
            this.decompileModToolStripMenuItem.Click += new System.EventHandler(this.DecompileModToolStripMenuItem_Click);
            // 
            // icons_mods
            // 
            this.icons_mods.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons_mods.ImageStream")));
            this.icons_mods.TransparentColor = System.Drawing.Color.Transparent;
            this.icons_mods.Images.SetKeyName(0, "vrctoolspng.png");
            // 
            // btn_mods_refresh
            // 
            this.btn_mods_refresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_mods_refresh.Location = new System.Drawing.Point(0, 305);
            this.btn_mods_refresh.Name = "btn_mods_refresh";
            this.btn_mods_refresh.Size = new System.Drawing.Size(166, 23);
            this.btn_mods_refresh.TabIndex = 14;
            this.btn_mods_refresh.Text = "Reload";
            this.btn_mods_refresh.UseVisualStyleBackColor = true;
            this.btn_mods_refresh.Click += new System.EventHandler(this.on_btn_mods_refresh_Click);
            // 
            // tableLayoutPanelmods
            // 
            this.tableLayoutPanelmods.ColumnCount = 2;
            this.tableLayoutPanelmods.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelmods.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanelmods.Controls.Add(this.lbl_mod_name, 0, 1);
            this.tableLayoutPanelmods.Controls.Add(this.txt_mod_description, 1, 5);
            this.tableLayoutPanelmods.Controls.Add(this.txt_mod_type, 1, 4);
            this.tableLayoutPanelmods.Controls.Add(this.lbl_mod_description, 0, 5);
            this.tableLayoutPanelmods.Controls.Add(this.lbl_mod_path, 0, 0);
            this.tableLayoutPanelmods.Controls.Add(this.lbl_mod_type, 0, 4);
            this.tableLayoutPanelmods.Controls.Add(this.txt_mod_path, 1, 0);
            this.tableLayoutPanelmods.Controls.Add(this.lbl_mod_author, 0, 3);
            this.tableLayoutPanelmods.Controls.Add(this.txt_mod_name, 1, 1);
            this.tableLayoutPanelmods.Controls.Add(this.lbl_mod_version, 0, 2);
            this.tableLayoutPanelmods.Controls.Add(this.txt_mod_version, 1, 2);
            this.tableLayoutPanelmods.Controls.Add(this.txt_mod_author, 1, 3);
            this.tableLayoutPanelmods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelmods.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelmods.Name = "tableLayoutPanelmods";
            this.tableLayoutPanelmods.RowCount = 6;
            this.tableLayoutPanelmods.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelmods.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelmods.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelmods.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelmods.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelmods.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelmods.Size = new System.Drawing.Size(721, 328);
            this.tableLayoutPanelmods.TabIndex = 19;
            // 
            // lbl_mod_name
            // 
            this.lbl_mod_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_mod_name.AutoSize = true;
            this.lbl_mod_name.Location = new System.Drawing.Point(3, 32);
            this.lbl_mod_name.Name = "lbl_mod_name";
            this.lbl_mod_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_mod_name.TabIndex = 2;
            this.lbl_mod_name.Text = "Name:";
            // 
            // txt_mod_description
            // 
            this.txt_mod_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_description.Location = new System.Drawing.Point(123, 133);
            this.txt_mod_description.Name = "txt_mod_description";
            this.txt_mod_description.ReadOnly = true;
            this.txt_mod_description.Size = new System.Drawing.Size(595, 192);
            this.txt_mod_description.TabIndex = 12;
            this.txt_mod_description.Text = "";
            // 
            // txt_mod_type
            // 
            this.txt_mod_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_type.Location = new System.Drawing.Point(123, 107);
            this.txt_mod_type.Name = "txt_mod_type";
            this.txt_mod_type.ReadOnly = true;
            this.txt_mod_type.Size = new System.Drawing.Size(595, 20);
            this.txt_mod_type.TabIndex = 9;
            // 
            // lbl_mod_description
            // 
            this.lbl_mod_description.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_mod_description.AutoSize = true;
            this.lbl_mod_description.Location = new System.Drawing.Point(3, 222);
            this.lbl_mod_description.Name = "lbl_mod_description";
            this.lbl_mod_description.Size = new System.Drawing.Size(63, 13);
            this.lbl_mod_description.TabIndex = 11;
            this.lbl_mod_description.Text = "Description:";
            // 
            // lbl_mod_path
            // 
            this.lbl_mod_path.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_mod_path.AutoSize = true;
            this.lbl_mod_path.Location = new System.Drawing.Point(3, 6);
            this.lbl_mod_path.Name = "lbl_mod_path";
            this.lbl_mod_path.Size = new System.Drawing.Size(32, 13);
            this.lbl_mod_path.TabIndex = 4;
            this.lbl_mod_path.Text = "Path:";
            // 
            // lbl_mod_type
            // 
            this.lbl_mod_type.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_mod_type.AutoSize = true;
            this.lbl_mod_type.Location = new System.Drawing.Point(3, 110);
            this.lbl_mod_type.Name = "lbl_mod_type";
            this.lbl_mod_type.Size = new System.Drawing.Size(34, 13);
            this.lbl_mod_type.TabIndex = 10;
            this.lbl_mod_type.Text = "Type:";
            // 
            // txt_mod_path
            // 
            this.txt_mod_path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_path.Location = new System.Drawing.Point(123, 3);
            this.txt_mod_path.Name = "txt_mod_path";
            this.txt_mod_path.ReadOnly = true;
            this.txt_mod_path.Size = new System.Drawing.Size(595, 20);
            this.txt_mod_path.TabIndex = 3;
            // 
            // lbl_mod_author
            // 
            this.lbl_mod_author.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_mod_author.AutoSize = true;
            this.lbl_mod_author.Location = new System.Drawing.Point(3, 84);
            this.lbl_mod_author.Name = "lbl_mod_author";
            this.lbl_mod_author.Size = new System.Drawing.Size(41, 13);
            this.lbl_mod_author.TabIndex = 8;
            this.lbl_mod_author.Text = "Author:";
            // 
            // txt_mod_name
            // 
            this.txt_mod_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_name.Location = new System.Drawing.Point(123, 29);
            this.txt_mod_name.Name = "txt_mod_name";
            this.txt_mod_name.ReadOnly = true;
            this.txt_mod_name.Size = new System.Drawing.Size(595, 20);
            this.txt_mod_name.TabIndex = 1;
            // 
            // lbl_mod_version
            // 
            this.lbl_mod_version.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_mod_version.AutoSize = true;
            this.lbl_mod_version.Location = new System.Drawing.Point(3, 58);
            this.lbl_mod_version.Name = "lbl_mod_version";
            this.lbl_mod_version.Size = new System.Drawing.Size(45, 13);
            this.lbl_mod_version.TabIndex = 6;
            this.lbl_mod_version.Text = "Version:";
            // 
            // txt_mod_version
            // 
            this.txt_mod_version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_version.Location = new System.Drawing.Point(123, 55);
            this.txt_mod_version.Name = "txt_mod_version";
            this.txt_mod_version.ReadOnly = true;
            this.txt_mod_version.Size = new System.Drawing.Size(595, 20);
            this.txt_mod_version.TabIndex = 5;
            // 
            // txt_mod_author
            // 
            this.txt_mod_author.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_author.Location = new System.Drawing.Point(123, 81);
            this.txt_mod_author.Name = "txt_mod_author";
            this.txt_mod_author.ReadOnly = true;
            this.txt_mod_author.Size = new System.Drawing.Size(595, 20);
            this.txt_mod_author.TabIndex = 7;
            // 
            // tab_mods_available
            // 
            this.tab_mods_available.Location = new System.Drawing.Point(4, 22);
            this.tab_mods_available.Name = "tab_mods_available";
            this.tab_mods_available.Padding = new System.Windows.Forms.Padding(3);
            this.tab_mods_available.Size = new System.Drawing.Size(897, 334);
            this.tab_mods_available.TabIndex = 1;
            this.tab_mods_available.Text = "Available";
            this.tab_mods_available.UseVisualStyleBackColor = true;
            // 
            // tab_settings
            // 
            this.tab_settings.BackColor = System.Drawing.Color.Transparent;
            this.tab_settings.Controls.Add(this.panel_setings);
            this.tab_settings.Location = new System.Drawing.Point(4, 22);
            this.tab_settings.Name = "tab_settings";
            this.tab_settings.Size = new System.Drawing.Size(905, 360);
            this.tab_settings.TabIndex = 6;
            this.tab_settings.Text = "Settings";
            // 
            // panel_setings
            // 
            this.panel_setings.Controls.Add(this.panel1);
            this.panel_setings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_setings.Location = new System.Drawing.Point(0, 0);
            this.panel_setings.Name = "panel_setings";
            this.panel_setings.Size = new System.Drawing.Size(905, 360);
            this.panel_setings.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.flow_settings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 360);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn_config_save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_config_apply, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 322);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(905, 38);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btn_config_save
            // 
            this.btn_config_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_config_save.Location = new System.Drawing.Point(455, 7);
            this.btn_config_save.Name = "btn_config_save";
            this.btn_config_save.Size = new System.Drawing.Size(447, 23);
            this.btn_config_save.TabIndex = 1;
            this.btn_config_save.Text = "Save";
            this.btn_config_save.UseVisualStyleBackColor = true;
            this.btn_config_save.Click += new System.EventHandler(this.Btn_config_save_Click);
            // 
            // btn_config_apply
            // 
            this.btn_config_apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_config_apply.Location = new System.Drawing.Point(3, 7);
            this.btn_config_apply.Name = "btn_config_apply";
            this.btn_config_apply.Size = new System.Drawing.Size(446, 23);
            this.btn_config_apply.TabIndex = 2;
            this.btn_config_apply.Text = "Apply";
            this.btn_config_apply.UseVisualStyleBackColor = true;
            this.btn_config_apply.Click += new System.EventHandler(this.Btn_config_apply_Click);
            // 
            // flow_settings
            // 
            this.flow_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flow_settings.Location = new System.Drawing.Point(8, 8);
            this.flow_settings.Name = "flow_settings";
            this.flow_settings.Size = new System.Drawing.Size(899, 308);
            this.flow_settings.TabIndex = 2;
            // 
            // tab_log
            // 
            this.tab_log.Controls.Add(this.tabs_log);
            this.tab_log.Location = new System.Drawing.Point(4, 22);
            this.tab_log.Name = "tab_log";
            this.tab_log.Size = new System.Drawing.Size(905, 360);
            this.tab_log.TabIndex = 8;
            this.tab_log.Text = "Logs";
            this.tab_log.UseVisualStyleBackColor = true;
            // 
            // tabs_log
            // 
            this.tabs_log.Controls.Add(this.tab_log_launcher);
            this.tabs_log.Controls.Add(this.tab_log_game);
            this.tabs_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_log.Location = new System.Drawing.Point(0, 0);
            this.tabs_log.Name = "tabs_log";
            this.tabs_log.SelectedIndex = 0;
            this.tabs_log.Size = new System.Drawing.Size(905, 360);
            this.tabs_log.TabIndex = 0;
            this.tabs_log.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_changedAsync);
            // 
            // tab_log_launcher
            // 
            this.tab_log_launcher.Controls.Add(this.lst_log_launcher);
            this.tab_log_launcher.Location = new System.Drawing.Point(4, 22);
            this.tab_log_launcher.Name = "tab_log_launcher";
            this.tab_log_launcher.Padding = new System.Windows.Forms.Padding(3);
            this.tab_log_launcher.Size = new System.Drawing.Size(897, 334);
            this.tab_log_launcher.TabIndex = 0;
            this.tab_log_launcher.Text = "Launcher";
            this.tab_log_launcher.UseVisualStyleBackColor = true;
            // 
            // lst_log_launcher
            // 
            this.lst_log_launcher.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lst_log_launcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_log_launcher.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_log_launcher.Location = new System.Drawing.Point(3, 3);
            this.lst_log_launcher.Name = "lst_log_launcher";
            this.lst_log_launcher.Size = new System.Drawing.Size(891, 328);
            this.lst_log_launcher.TabIndex = 1;
            this.lst_log_launcher.UseCompatibleStateImageBehavior = false;
            this.lst_log_launcher.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 25;
            // 
            // tab_log_game
            // 
            this.tab_log_game.Controls.Add(this.lst_log_game);
            this.tab_log_game.Location = new System.Drawing.Point(4, 22);
            this.tab_log_game.Name = "tab_log_game";
            this.tab_log_game.Padding = new System.Windows.Forms.Padding(3);
            this.tab_log_game.Size = new System.Drawing.Size(897, 334);
            this.tab_log_game.TabIndex = 1;
            this.tab_log_game.Text = "Game";
            this.tab_log_game.UseVisualStyleBackColor = true;
            // 
            // lst_log_game
            // 
            this.lst_log_game.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lst_log_game.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_log_game.FullRowSelect = true;
            this.lst_log_game.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_log_game.Location = new System.Drawing.Point(3, 3);
            this.lst_log_game.Name = "lst_log_game";
            this.lst_log_game.Size = new System.Drawing.Size(891, 328);
            this.lst_log_game.TabIndex = 0;
            this.lst_log_game.UseCompatibleStateImageBehavior = false;
            this.lst_log_game.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(905, 360);
            this.tabPage1.TabIndex = 9;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // menu_users
            // 
            this.menu_users.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileMenuItem,
            this.friendToolStripMenuItem,
            this.blockToolStripMenuItem,
            this.menu_item_exportfriends,
            this.menu_item_importfriends});
            this.menu_users.Name = "contextMenuStrip1";
            this.menu_users.Size = new System.Drawing.Size(137, 114);
            // 
            // profileMenuItem
            // 
            this.profileMenuItem.Name = "profileMenuItem";
            this.profileMenuItem.Size = new System.Drawing.Size(136, 22);
            this.profileMenuItem.Text = "View Profile";
            // 
            // friendToolStripMenuItem
            // 
            this.friendToolStripMenuItem.Name = "friendToolStripMenuItem";
            this.friendToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.friendToolStripMenuItem.Text = "Friend";
            // 
            // blockToolStripMenuItem
            // 
            this.blockToolStripMenuItem.Name = "blockToolStripMenuItem";
            this.blockToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.blockToolStripMenuItem.Text = "Block";
            // 
            // menu_item_exportfriends
            // 
            this.menu_item_exportfriends.Name = "menu_item_exportfriends";
            this.menu_item_exportfriends.Size = new System.Drawing.Size(136, 22);
            this.menu_item_exportfriends.Text = "Export";
            this.menu_item_exportfriends.Click += new System.EventHandler(this.Menu_item_exportfriends_Click);
            // 
            // menu_item_importfriends
            // 
            this.menu_item_importfriends.Name = "menu_item_importfriends";
            this.menu_item_importfriends.Size = new System.Drawing.Size(136, 22);
            this.menu_item_importfriends.Text = "Import";
            this.menu_item_importfriends.Click += new System.EventHandler(this.Menu_item_importfriends_Click);
            // 
            // panel_status
            // 
            this.panel_status.Controls.Add(this.txt_status);
            this.panel_status.Controls.Add(this.btn_play);
            this.panel_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_status.Location = new System.Drawing.Point(0, 392);
            this.panel_status.Name = "panel_status";
            this.panel_status.Size = new System.Drawing.Size(913, 73);
            this.panel_status.TabIndex = 2;
            // 
            // txt_status
            // 
            this.txt_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_status.Location = new System.Drawing.Point(0, 53);
            this.txt_status.Name = "txt_status";
            this.txt_status.ReadOnly = true;
            this.txt_status.Size = new System.Drawing.Size(913, 20);
            this.txt_status.TabIndex = 3;
            // 
            // btn_play
            // 
            this.btn_play.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_play.Location = new System.Drawing.Point(0, 0);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(913, 50);
            this.btn_play.TabIndex = 2;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // icons_worlds
            // 
            this.icons_worlds.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons_worlds.ImageStream")));
            this.icons_worlds.TransparentColor = System.Drawing.Color.Transparent;
            this.icons_worlds.Images.SetKeyName(0, "lock.png");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 465);
            this.Controls.Add(this.panel_status);
            this.Controls.Add(this.tabs_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "VRChat Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_loaded);
            this.tabs_main.ResumeLayout(false);
            this.tab_news.ResumeLayout(false);
            this.tab_users.ResumeLayout(false);
            this.splitContainerUsers.Panel1.ResumeLayout(false);
            this.splitContainerUsers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUsers)).EndInit();
            this.splitContainerUsers.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelUSers.ResumeLayout(false);
            this.tableLayoutPanelUSers.PerformLayout();
            this.panel_users_id.ResumeLayout(false);
            this.panel_users_id.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tab_avatars.ResumeLayout(false);
            this.splitContainerAvatars.Panel1.ResumeLayout(false);
            this.splitContainerAvatars.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAvatars)).EndInit();
            this.splitContainerAvatars.ResumeLayout(false);
            this.tableLayoutPanelTEST.ResumeLayout(false);
            this.tableLayoutPanelTEST.PerformLayout();
            this.panel_worlds_id.ResumeLayout(false);
            this.panel_worlds_id.PerformLayout();
            this.panel_worlds_asseturl.ResumeLayout(false);
            this.panel_worlds_asseturl.PerformLayout();
            this.panel_worlds_author.ResumeLayout(false);
            this.panel_worlds_author.PerformLayout();
            this.tab_worlds.ResumeLayout(false);
            this.splitContainerWOrlds.Panel1.ResumeLayout(false);
            this.splitContainerWOrlds.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWOrlds)).EndInit();
            this.splitContainerWOrlds.ResumeLayout(false);
            this.tableLayoutPanelWorlds.ResumeLayout(false);
            this.tableLayoutPanelWorlds.PerformLayout();
            this.panel_words_id_2.ResumeLayout(false);
            this.panel_words_id_2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tab_mods.ResumeLayout(false);
            this.tabs_mods.ResumeLayout(false);
            this.tab_mods_installed.ResumeLayout(false);
            this.splitContainerMods.Panel1.ResumeLayout(false);
            this.splitContainerMods.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMods)).EndInit();
            this.splitContainerMods.ResumeLayout(false);
            this.panel_mods_list.ResumeLayout(false);
            this.menu_mod.ResumeLayout(false);
            this.tableLayoutPanelmods.ResumeLayout(false);
            this.tableLayoutPanelmods.PerformLayout();
            this.tab_settings.ResumeLayout(false);
            this.panel_setings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tab_log.ResumeLayout(false);
            this.tabs_log.ResumeLayout(false);
            this.tab_log_launcher.ResumeLayout(false);
            this.tab_log_game.ResumeLayout(false);
            this.menu_users.ResumeLayout(false);
            this.panel_status.ResumeLayout(false);
            this.panel_status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabs_main;
        private System.Windows.Forms.TabPage tab_news;
        private System.Windows.Forms.TabPage tab_users;
        private System.Windows.Forms.TabPage tab_avatars;
        private System.Windows.Forms.TabPage tab_worlds;
        private System.Windows.Forms.TabPage tab_settings;
        private System.Windows.Forms.TabPage tab_log;
        private System.Windows.Forms.TabControl tabs_log;
        private System.Windows.Forms.TabPage tab_log_launcher;
        private System.Windows.Forms.TabPage tab_log_game;
        private System.Windows.Forms.ListView lst_log_launcher;
        private System.Windows.Forms.ListView lst_log_game;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel_setings;
        private System.Windows.Forms.SplitContainer splitContainerAvatars;
        private System.Windows.Forms.SplitContainer splitContainerUsers;
        private System.Windows.Forms.TreeView tree_users;
        private System.Windows.Forms.Button btn_users_reload;
        private System.Windows.Forms.Button btn_users_save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_users_friend_add;
        private System.Windows.Forms.Button btn_users_friend_remove;
        private System.Windows.Forms.Button btn_users_block;
        private System.Windows.Forms.Button btn_users_unblock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUSers;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_users_rank;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_users_username;
        private System.Windows.Forms.TextBox txt_users_status;
        private System.Windows.Forms.Panel panel_users_id;
        private System.Windows.Forms.Button btn_users_search;
        private System.Windows.Forms.TextBox txt_users_id;
        private System.Windows.Forms.Panel panel_status;
        private System.Windows.Forms.Button btn_play;
        public System.Windows.Forms.TextBox txt_status;
        private System.Windows.Forms.TabPage tab_mods;
        private System.Windows.Forms.RichTextBox txt_news;
        private System.Windows.Forms.SplitContainer splitContainerWOrlds;
        private System.Windows.Forms.TreeView tree_worlds;
        private System.Windows.Forms.Button btn_worlds_reload;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWorlds;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RichTextBox txt_world_description;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_world_name;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txt_world_version;
        private System.Windows.Forms.Panel panel_words_id_2;
        private System.Windows.Forms.Button btn_worlds_search;
        private System.Windows.Forms.TextBox txt_world_id;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btn_worlds_rip;
        private System.Windows.Forms.TextBox txt_world_asset;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btn_worlds_author;
        private System.Windows.Forms.TextBox txt_world_author;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TreeView tree_avatars;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTEST;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox txt_avatar_description;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_avatar_name;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_avatar_version;
        private System.Windows.Forms.Panel panel_worlds_id;
        private System.Windows.Forms.Button btn_avatar_search;
        private System.Windows.Forms.TextBox txt_avatar_id;
        private System.Windows.Forms.Panel panel_worlds_asseturl;
        private System.Windows.Forms.Button btn_avatar_rip;
        private System.Windows.Forms.TextBox txt_avatar_asseturl;
        private System.Windows.Forms.Panel panel_worlds_author;
        private System.Windows.Forms.Button btn_avatars_profile;
        private System.Windows.Forms.TextBox txt_avatar_author;
        private System.Windows.Forms.ContextMenuStrip menu_users;
        private System.Windows.Forms.ToolStripMenuItem friendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menu_mod;
        private System.Windows.Forms.ToolStripMenuItem toggleModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompileModToolStripMenuItem;
        private System.Windows.Forms.ImageList icons_mods;
        private System.Windows.Forms.ImageList icons_worlds;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.TabControl tabs_mods;
        private System.Windows.Forms.TabPage tab_mods_installed;
        private System.Windows.Forms.SplitContainer splitContainerMods;
        private System.Windows.Forms.Panel panel_mods_list;
        private System.Windows.Forms.ListView lst_mods;
        private System.Windows.Forms.Button btn_mods_refresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelmods;
        private System.Windows.Forms.Label lbl_mod_name;
        private System.Windows.Forms.RichTextBox txt_mod_description;
        private System.Windows.Forms.TextBox txt_mod_type;
        private System.Windows.Forms.Label lbl_mod_description;
        private System.Windows.Forms.Label lbl_mod_path;
        private System.Windows.Forms.Label lbl_mod_type;
        private System.Windows.Forms.TextBox txt_mod_path;
        private System.Windows.Forms.Label lbl_mod_author;
        private System.Windows.Forms.TextBox txt_mod_name;
        private System.Windows.Forms.Label lbl_mod_version;
        private System.Windows.Forms.TextBox txt_mod_version;
        private System.Windows.Forms.TextBox txt_mod_author;
        private System.Windows.Forms.TabPage tab_mods_available;
        private System.Windows.Forms.ToolStripMenuItem profileMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_config_save;
        private System.Windows.Forms.Button btn_config_apply;
        private System.Windows.Forms.FlowLayoutPanel flow_settings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_user_join;
        private System.Windows.Forms.TextBox txt_users_location;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_users_displayname;
        private System.Windows.Forms.Button btn_users_search_name;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox txt_users_tags;
        private System.Windows.Forms.ToolStripMenuItem menu_item_exportfriends;
        private System.Windows.Forms.ToolStripMenuItem menu_item_importfriends;
    }
}

