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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Me");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Test Friend");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Online", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Offline");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Friends", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Test Blocked");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Blocked", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Test Request");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Requests", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Personal");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Test Avatar");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Test Private");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Official", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Test Avatar");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("VRCTools", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabs_main = new System.Windows.Forms.TabControl();
            this.tab_news = new System.Windows.Forms.TabPage();
            this.web_home = new System.Windows.Forms.WebBrowser();
            this.tab_users = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_users_reload = new System.Windows.Forms.Button();
            this.tree_users = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_users_save = new System.Windows.Forms.Button();
            this.btn_users_friend_add = new System.Windows.Forms.Button();
            this.btn_users_friend_remove = new System.Windows.Forms.Button();
            this.btn_users_block = new System.Windows.Forms.Button();
            this.btn_users_unblock = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_users_tags = new System.Windows.Forms.RichTextBox();
            this.txt_users_rank = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_users_displayname = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_users_username = new System.Windows.Forms.TextBox();
            this.txt_users_status = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_users_search = new System.Windows.Forms.Button();
            this.txt_users_id = new System.Windows.Forms.TextBox();
            this.tab_avatars = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tree_avatars = new System.Windows.Forms.TreeView();
            this.btn_avatars_reload = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_avatar_description = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_avatar_name = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_avatar_version = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_avatar_search = new System.Windows.Forms.Button();
            this.txt_avatar_id = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_avatar_rip = new System.Windows.Forms.Button();
            this.txt_avatar_asseturl = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_avatars_profile = new System.Windows.Forms.Button();
            this.txt_avatar_author = new System.Windows.Forms.TextBox();
            this.tab_worlds = new System.Windows.Forms.TabPage();
            this.tab_mods = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lst_mods = new System.Windows.Forms.ListView();
            this.btn_mods_refresh = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.tab_settings = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_config_save = new System.Windows.Forms.Button();
            this.flow_settings = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tab_log = new System.Windows.Forms.TabPage();
            this.tabs_log = new System.Windows.Forms.TabControl();
            this.tab_log_launcher = new System.Windows.Forms.TabPage();
            this.lst_log_launcher = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tab_log_game = new System.Windows.Forms.TabPage();
            this.lst_log_game = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tab_test = new System.Windows.Forms.TabPage();
            this.panel_status = new System.Windows.Forms.Panel();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.btn_play = new System.Windows.Forms.Button();
            this.tabs_main.SuspendLayout();
            this.tab_news.SuspendLayout();
            this.tab_users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tab_avatars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tab_mods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tab_settings.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flow_settings.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tab_log.SuspendLayout();
            this.tabs_log.SuspendLayout();
            this.tab_log_launcher.SuspendLayout();
            this.tab_log_game.SuspendLayout();
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
            this.tabs_main.Controls.Add(this.tab_test);
            this.tabs_main.Location = new System.Drawing.Point(0, 0);
            this.tabs_main.Name = "tabs_main";
            this.tabs_main.SelectedIndex = 0;
            this.tabs_main.Size = new System.Drawing.Size(913, 386);
            this.tabs_main.TabIndex = 1;
            this.tabs_main.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_changedAsync);
            // 
            // tab_news
            // 
            this.tab_news.Controls.Add(this.web_home);
            this.tab_news.Location = new System.Drawing.Point(4, 22);
            this.tab_news.Name = "tab_news";
            this.tab_news.Padding = new System.Windows.Forms.Padding(3);
            this.tab_news.Size = new System.Drawing.Size(905, 360);
            this.tab_news.TabIndex = 0;
            this.tab_news.Text = "News";
            this.tab_news.UseVisualStyleBackColor = true;
            // 
            // web_home
            // 
            this.web_home.AllowNavigation = false;
            this.web_home.AllowWebBrowserDrop = false;
            this.web_home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_home.Location = new System.Drawing.Point(3, 3);
            this.web_home.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_home.Name = "web_home";
            this.web_home.ScriptErrorsSuppressed = true;
            this.web_home.ScrollBarsEnabled = false;
            this.web_home.Size = new System.Drawing.Size(899, 354);
            this.web_home.TabIndex = 0;
            this.web_home.Url = new System.Uri("https://vrchat.com/home", System.UriKind.Absolute);
            this.web_home.WebBrowserShortcutsEnabled = false;
            // 
            // tab_users
            // 
            this.tab_users.Controls.Add(this.splitContainer2);
            this.tab_users.Location = new System.Drawing.Point(4, 22);
            this.tab_users.Name = "tab_users";
            this.tab_users.Padding = new System.Windows.Forms.Padding(3);
            this.tab_users.Size = new System.Drawing.Size(905, 360);
            this.tab_users.TabIndex = 1;
            this.tab_users.Text = "Users";
            this.tab_users.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_users_reload);
            this.splitContainer2.Panel1.Controls.Add(this.tree_users);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel8);
            this.splitContainer2.Size = new System.Drawing.Size(899, 354);
            this.splitContainer2.SplitterDistance = 187;
            this.splitContainer2.TabIndex = 0;
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
            this.tree_users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_users.Location = new System.Drawing.Point(0, 0);
            this.tree_users.Name = "tree_users";
            treeNode1.Name = "node_user_self";
            treeNode1.Text = "Me";
            treeNode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode2.Name = "Node2";
            treeNode2.Text = "Test Friend";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Online";
            treeNode4.Name = "Node2";
            treeNode4.Text = "Offline";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Friends";
            treeNode5.ToolTipText = "Your VRChat friends";
            treeNode6.ForeColor = System.Drawing.Color.Red;
            treeNode6.Name = "Node4";
            treeNode6.Text = "Test Blocked";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Blocked";
            treeNode7.ToolTipText = "Avatars favorited though VRChat";
            treeNode8.ForeColor = System.Drawing.Color.Cyan;
            treeNode8.Name = "";
            treeNode8.Text = "Test Request";
            treeNode9.Name = "Node4";
            treeNode9.Text = "Requests";
            treeNode9.ToolTipText = "Users that want to become your friend";
            this.tree_users.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode7,
            treeNode9});
            this.tree_users.Size = new System.Drawing.Size(187, 354);
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
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 315);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(708, 39);
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
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33333F));
            this.tableLayoutPanel8.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.txt_users_tags, 1, 5);
            this.tableLayoutPanel8.Controls.Add(this.txt_users_rank, 1, 4);
            this.tableLayoutPanel8.Controls.Add(this.label17, 0, 5);
            this.tableLayoutPanel8.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label19, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.label20, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.txt_users_displayname, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.label21, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.txt_users_username, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.txt_users_status, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 6;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(708, 327);
            this.tableLayoutPanel8.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Display Name:";
            // 
            // txt_users_tags
            // 
            this.txt_users_tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_users_tags.Location = new System.Drawing.Point(121, 133);
            this.txt_users_tags.Name = "txt_users_tags";
            this.txt_users_tags.ReadOnly = true;
            this.txt_users_tags.Size = new System.Drawing.Size(584, 191);
            this.txt_users_tags.TabIndex = 12;
            this.txt_users_tags.Text = "";
            // 
            // txt_users_rank
            // 
            this.txt_users_rank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_users_rank.Location = new System.Drawing.Point(121, 107);
            this.txt_users_rank.Name = "txt_users_rank";
            this.txt_users_rank.ReadOnly = true;
            this.txt_users_rank.Size = new System.Drawing.Size(584, 20);
            this.txt_users_rank.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.label17.Location = new System.Drawing.Point(3, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "Tags:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "ID:";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Rank:";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 84);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "Status:";
            // 
            // txt_users_displayname
            // 
            this.txt_users_displayname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_users_displayname.Location = new System.Drawing.Point(121, 29);
            this.txt_users_displayname.Name = "txt_users_displayname";
            this.txt_users_displayname.ReadOnly = true;
            this.txt_users_displayname.Size = new System.Drawing.Size(584, 20);
            this.txt_users_displayname.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "Username:";
            // 
            // txt_users_username
            // 
            this.txt_users_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_users_username.Location = new System.Drawing.Point(121, 55);
            this.txt_users_username.Name = "txt_users_username";
            this.txt_users_username.ReadOnly = true;
            this.txt_users_username.Size = new System.Drawing.Size(584, 20);
            this.txt_users_username.TabIndex = 5;
            // 
            // txt_users_status
            // 
            this.txt_users_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_users_status.Location = new System.Drawing.Point(121, 81);
            this.txt_users_status.Name = "txt_users_status";
            this.txt_users_status.ReadOnly = true;
            this.txt_users_status.Size = new System.Drawing.Size(584, 20);
            this.txt_users_status.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btn_users_search);
            this.panel5.Controls.Add(this.txt_users_id);
            this.panel5.Location = new System.Drawing.Point(121, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(584, 20);
            this.panel5.TabIndex = 13;
            // 
            // btn_users_search
            // 
            this.btn_users_search.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_users_search.Location = new System.Drawing.Point(503, 0);
            this.btn_users_search.Name = "btn_users_search";
            this.btn_users_search.Size = new System.Drawing.Size(81, 20);
            this.btn_users_search.TabIndex = 1;
            this.btn_users_search.Text = "Search";
            this.btn_users_search.UseVisualStyleBackColor = true;
            // 
            // txt_users_id
            // 
            this.txt_users_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_users_id.Location = new System.Drawing.Point(0, 0);
            this.txt_users_id.Name = "txt_users_id";
            this.txt_users_id.Size = new System.Drawing.Size(497, 20);
            this.txt_users_id.TabIndex = 0;
            // 
            // tab_avatars
            // 
            this.tab_avatars.Controls.Add(this.splitContainer1);
            this.tab_avatars.Location = new System.Drawing.Point(4, 22);
            this.tab_avatars.Name = "tab_avatars";
            this.tab_avatars.Size = new System.Drawing.Size(905, 360);
            this.tab_avatars.TabIndex = 2;
            this.tab_avatars.Text = "Avatars";
            this.tab_avatars.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree_avatars);
            this.splitContainer1.Panel1.Controls.Add(this.btn_avatars_reload);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel7);
            this.splitContainer1.Size = new System.Drawing.Size(905, 360);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 0;
            // 
            // tree_avatars
            // 
            this.tree_avatars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_avatars.Location = new System.Drawing.Point(0, 0);
            this.tree_avatars.Name = "tree_avatars";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Personal";
            treeNode10.ToolTipText = "Avatars uploaded by you";
            treeNode11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode11.Name = "Node2";
            treeNode11.Text = "Test Avatar";
            treeNode12.ForeColor = System.Drawing.Color.Red;
            treeNode12.Name = "Node4";
            treeNode12.Text = "Test Private";
            treeNode13.Name = "Node0";
            treeNode13.Text = "Official";
            treeNode13.ToolTipText = "Avatars favorited though VRChat";
            treeNode14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            treeNode14.Name = "Node3";
            treeNode14.Text = "Test Avatar";
            treeNode15.Name = "Node1";
            treeNode15.Text = "VRCTools";
            treeNode15.ToolTipText = "Avatars favorited though VRCTools";
            this.tree_avatars.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode13,
            treeNode15});
            this.tree_avatars.Size = new System.Drawing.Size(177, 337);
            this.tree_avatars.TabIndex = 22;
            this.tree_avatars.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.avatars_node_selected);
            // 
            // btn_avatars_reload
            // 
            this.btn_avatars_reload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_avatars_reload.Location = new System.Drawing.Point(0, 337);
            this.btn_avatars_reload.Name = "btn_avatars_reload";
            this.btn_avatars_reload.Size = new System.Drawing.Size(177, 23);
            this.btn_avatars_reload.TabIndex = 21;
            this.btn_avatars_reload.Text = "Reload";
            this.btn_avatars_reload.UseVisualStyleBackColor = true;
            this.btn_avatars_reload.Click += new System.EventHandler(this.Btn_avatars_reload_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33333F));
            this.tableLayoutPanel7.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.txt_avatar_description, 1, 5);
            this.tableLayoutPanel7.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel7.Controls.Add(this.lbl, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.txt_avatar_name, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.txt_avatar_version, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.panel3, 1, 4);
            this.tableLayoutPanel7.Controls.Add(this.panel6, 1, 3);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 6;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(724, 360);
            this.tableLayoutPanel7.TabIndex = 22;
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
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btn_avatar_search);
            this.panel4.Controls.Add(this.txt_avatar_id);
            this.panel4.Location = new System.Drawing.Point(123, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(598, 20);
            this.panel4.TabIndex = 13;
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
            // 
            // txt_avatar_id
            // 
            this.txt_avatar_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_avatar_id.Location = new System.Drawing.Point(0, 0);
            this.txt_avatar_id.Name = "txt_avatar_id";
            this.txt_avatar_id.Size = new System.Drawing.Size(517, 20);
            this.txt_avatar_id.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.btn_avatar_rip);
            this.panel3.Controls.Add(this.txt_avatar_asseturl);
            this.panel3.Location = new System.Drawing.Point(123, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(598, 20);
            this.panel3.TabIndex = 14;
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
            this.btn_avatar_rip.Visible = false;
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
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.btn_avatars_profile);
            this.panel6.Controls.Add(this.txt_avatar_author);
            this.panel6.Location = new System.Drawing.Point(123, 81);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(598, 22);
            this.panel6.TabIndex = 15;
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
            this.tab_worlds.Location = new System.Drawing.Point(4, 22);
            this.tab_worlds.Name = "tab_worlds";
            this.tab_worlds.Size = new System.Drawing.Size(905, 360);
            this.tab_worlds.TabIndex = 3;
            this.tab_worlds.Text = "Worlds";
            this.tab_worlds.UseVisualStyleBackColor = true;
            // 
            // tab_mods
            // 
            this.tab_mods.Controls.Add(this.splitContainer3);
            this.tab_mods.Location = new System.Drawing.Point(4, 22);
            this.tab_mods.Name = "tab_mods";
            this.tab_mods.Size = new System.Drawing.Size(905, 360);
            this.tab_mods.TabIndex = 5;
            this.tab_mods.Text = "Mods";
            this.tab_mods.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer3.Size = new System.Drawing.Size(905, 360);
            this.splitContainer3.SplitterDistance = 169;
            this.splitContainer3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lst_mods);
            this.panel1.Controls.Add(this.btn_mods_refresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 360);
            this.panel1.TabIndex = 18;
            // 
            // lst_mods
            // 
            this.lst_mods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_mods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_mods.FullRowSelect = true;
            this.lst_mods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_mods.Location = new System.Drawing.Point(0, 0);
            this.lst_mods.MultiSelect = false;
            this.lst_mods.Name = "lst_mods";
            this.lst_mods.ShowGroups = false;
            this.lst_mods.ShowItemToolTips = true;
            this.lst_mods.Size = new System.Drawing.Size(169, 337);
            this.lst_mods.TabIndex = 13;
            this.lst_mods.UseCompatibleStateImageBehavior = false;
            this.lst_mods.View = System.Windows.Forms.View.List;
            this.lst_mods.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.on_list_mods_ItemSelectionChanged);
            // 
            // btn_mods_refresh
            // 
            this.btn_mods_refresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_mods_refresh.Location = new System.Drawing.Point(0, 337);
            this.btn_mods_refresh.Name = "btn_mods_refresh";
            this.btn_mods_refresh.Size = new System.Drawing.Size(169, 23);
            this.btn_mods_refresh.TabIndex = 14;
            this.btn_mods_refresh.Text = "Reload";
            this.btn_mods_refresh.UseVisualStyleBackColor = true;
            this.btn_mods_refresh.Click += new System.EventHandler(this.on_btn_mods_refresh_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_mod_name, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_mod_description, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txt_mod_type, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_mod_description, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbl_mod_path, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_mod_type, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_mod_path, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_mod_author, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_mod_name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_mod_version, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_mod_version, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_mod_author, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 360);
            this.tableLayoutPanel1.TabIndex = 19;
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
            this.txt_mod_description.Location = new System.Drawing.Point(125, 133);
            this.txt_mod_description.Name = "txt_mod_description";
            this.txt_mod_description.ReadOnly = true;
            this.txt_mod_description.Size = new System.Drawing.Size(604, 224);
            this.txt_mod_description.TabIndex = 12;
            this.txt_mod_description.Text = "";
            // 
            // txt_mod_type
            // 
            this.txt_mod_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_type.Location = new System.Drawing.Point(125, 107);
            this.txt_mod_type.Name = "txt_mod_type";
            this.txt_mod_type.ReadOnly = true;
            this.txt_mod_type.Size = new System.Drawing.Size(604, 20);
            this.txt_mod_type.TabIndex = 9;
            // 
            // lbl_mod_description
            // 
            this.lbl_mod_description.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_mod_description.AutoSize = true;
            this.lbl_mod_description.Location = new System.Drawing.Point(3, 238);
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
            this.txt_mod_path.Location = new System.Drawing.Point(125, 3);
            this.txt_mod_path.Name = "txt_mod_path";
            this.txt_mod_path.ReadOnly = true;
            this.txt_mod_path.Size = new System.Drawing.Size(604, 20);
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
            this.txt_mod_name.Location = new System.Drawing.Point(125, 29);
            this.txt_mod_name.Name = "txt_mod_name";
            this.txt_mod_name.ReadOnly = true;
            this.txt_mod_name.Size = new System.Drawing.Size(604, 20);
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
            this.txt_mod_version.Location = new System.Drawing.Point(125, 55);
            this.txt_mod_version.Name = "txt_mod_version";
            this.txt_mod_version.ReadOnly = true;
            this.txt_mod_version.Size = new System.Drawing.Size(604, 20);
            this.txt_mod_version.TabIndex = 5;
            // 
            // txt_mod_author
            // 
            this.txt_mod_author.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_author.Location = new System.Drawing.Point(125, 81);
            this.txt_mod_author.Name = "txt_mod_author";
            this.txt_mod_author.ReadOnly = true;
            this.txt_mod_author.Size = new System.Drawing.Size(604, 20);
            this.txt_mod_author.TabIndex = 7;
            // 
            // tab_settings
            // 
            this.tab_settings.BackColor = System.Drawing.Color.Transparent;
            this.tab_settings.Controls.Add(this.panel2);
            this.tab_settings.Location = new System.Drawing.Point(4, 22);
            this.tab_settings.Name = "tab_settings";
            this.tab_settings.Size = new System.Drawing.Size(905, 360);
            this.tab_settings.TabIndex = 6;
            this.tab_settings.Text = "Settings";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_config_save);
            this.panel2.Controls.Add(this.flow_settings);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 360);
            this.panel2.TabIndex = 1;
            // 
            // btn_config_save
            // 
            this.btn_config_save.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_config_save.Enabled = false;
            this.btn_config_save.Location = new System.Drawing.Point(0, 337);
            this.btn_config_save.Name = "btn_config_save";
            this.btn_config_save.Size = new System.Drawing.Size(905, 23);
            this.btn_config_save.TabIndex = 1;
            this.btn_config_save.Text = "Save";
            this.btn_config_save.UseVisualStyleBackColor = true;
            this.btn_config_save.Click += new System.EventHandler(this.Btn_config_save_Click);
            // 
            // flow_settings
            // 
            this.flow_settings.Controls.Add(this.tableLayoutPanel3);
            this.flow_settings.Controls.Add(this.tableLayoutPanel6);
            this.flow_settings.Controls.Add(this.tableLayoutPanel5);
            this.flow_settings.Controls.Add(this.tableLayoutPanel4);
            this.flow_settings.Controls.Add(this.tableLayoutPanel2);
            this.flow_settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_settings.Location = new System.Drawing.Point(0, 0);
            this.flow_settings.Name = "flow_settings";
            this.flow_settings.Size = new System.Drawing.Size(905, 360);
            this.flow_settings.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.74757F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.25243F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox3, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox4, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "label4";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(86, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(111, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(86, 15);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(111, 20);
            this.textBox4.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.74757F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.25243F));
            this.tableLayoutPanel6.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.textBox9, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.textBox10, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(209, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "label10";
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Location = new System.Drawing.Point(86, 65);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(111, 20);
            this.textBox9.TabIndex = 3;
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(86, 15);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(111, 20);
            this.textBox10.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.74757F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.25243F));
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBox7, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBox8, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(415, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "label8";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(86, 65);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(111, 20);
            this.textBox7.TabIndex = 3;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Location = new System.Drawing.Point(86, 15);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(111, 20);
            this.textBox8.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.74757F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.25243F));
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.textBox5, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.textBox6, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(621, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "label6";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(86, 65);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(111, 20);
            this.textBox5.TabIndex = 3;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(86, 15);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(111, 20);
            this.textBox6.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.74757F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.25243F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 109);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(86, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(111, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(86, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 20);
            this.textBox1.TabIndex = 1;
            // 
            // tab_log
            // 
            this.tab_log.Controls.Add(this.tabs_log);
            this.tab_log.Location = new System.Drawing.Point(4, 22);
            this.tab_log.Name = "tab_log";
            this.tab_log.Size = new System.Drawing.Size(905, 360);
            this.tab_log.TabIndex = 8;
            this.tab_log.Text = "Log";
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
            // tab_test
            // 
            this.tab_test.Location = new System.Drawing.Point(4, 22);
            this.tab_test.Name = "tab_test";
            this.tab_test.Size = new System.Drawing.Size(905, 360);
            this.tab_test.TabIndex = 9;
            this.tab_test.Text = "Test";
            this.tab_test.UseVisualStyleBackColor = true;
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
            this.Load += new System.EventHandler(this.mainForm_loaded);
            this.tabs_main.ResumeLayout(false);
            this.tab_news.ResumeLayout(false);
            this.tab_users.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tab_avatars.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tab_mods.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tab_settings.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flow_settings.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tab_log.ResumeLayout(false);
            this.tabs_log.ResumeLayout(false);
            this.tab_log_launcher.ResumeLayout(false);
            this.tab_log_game.ResumeLayout(false);
            this.panel_status.ResumeLayout(false);
            this.panel_status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabs_main;
        private System.Windows.Forms.TabPage tab_news;
        private System.Windows.Forms.WebBrowser web_home;
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
        private System.Windows.Forms.FlowLayoutPanel flow_settings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_config_save;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tab_test;
        private System.Windows.Forms.TreeView tree_avatars;
        private System.Windows.Forms.Button btn_avatars_reload;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox txt_avatar_description;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_avatar_name;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_avatar_version;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_avatar_search;
        private System.Windows.Forms.TextBox txt_avatar_id;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_avatar_rip;
        private System.Windows.Forms.TextBox txt_avatar_asseturl;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tree_users;
        private System.Windows.Forms.Button btn_users_reload;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_avatars_profile;
        private System.Windows.Forms.TextBox txt_avatar_author;
        private System.Windows.Forms.Button btn_users_save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_users_friend_add;
        private System.Windows.Forms.Button btn_users_friend_remove;
        private System.Windows.Forms.Button btn_users_block;
        private System.Windows.Forms.Button btn_users_unblock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox txt_users_tags;
        private System.Windows.Forms.TextBox txt_users_rank;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_users_displayname;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_users_username;
        private System.Windows.Forms.TextBox txt_users_status;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_users_search;
        private System.Windows.Forms.TextBox txt_users_id;
        private System.Windows.Forms.Panel panel_status;
        private System.Windows.Forms.Button btn_play;
        public System.Windows.Forms.TextBox txt_status;
        private System.Windows.Forms.TabPage tab_mods;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lst_mods;
        private System.Windows.Forms.Button btn_mods_refresh;
    }
}

