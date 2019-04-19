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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_play = new System.Windows.Forms.Button();
            this.tabs_main = new System.Windows.Forms.TabControl();
            this.tab_news = new System.Windows.Forms.TabPage();
            this.web_home = new System.Windows.Forms.WebBrowser();
            this.tab_friends = new System.Windows.Forms.TabPage();
            this.tab_avatars = new System.Windows.Forms.TabPage();
            this.tab_worlds = new System.Windows.Forms.TabPage();
            this.tab_profile = new System.Windows.Forms.TabPage();
            this.tab_mods = new System.Windows.Forms.TabPage();
            this.lst_mods = new System.Windows.Forms.ListView();
            this.txt_mod_description = new System.Windows.Forms.RichTextBox();
            this.lbl_mod_description = new System.Windows.Forms.Label();
            this.lbl_mod_type = new System.Windows.Forms.Label();
            this.txt_mod_type = new System.Windows.Forms.TextBox();
            this.lbl_mod_author = new System.Windows.Forms.Label();
            this.txt_mod_author = new System.Windows.Forms.TextBox();
            this.lbl_mod_version = new System.Windows.Forms.Label();
            this.txt_mod_version = new System.Windows.Forms.TextBox();
            this.lbl_mod_path = new System.Windows.Forms.Label();
            this.txt_mod_path = new System.Windows.Forms.TextBox();
            this.lbl_mod_name = new System.Windows.Forms.Label();
            this.txt_mod_name = new System.Windows.Forms.TextBox();
            this.tab_settings = new System.Windows.Forms.TabPage();
            this.tab_log = new System.Windows.Forms.TabPage();
            this.tabs_log = new System.Windows.Forms.TabControl();
            this.tab_log_launcher = new System.Windows.Forms.TabPage();
            this.lst_log_launcher = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tab_log_game = new System.Windows.Forms.TabPage();
            this.lst_log_game = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabs_main.SuspendLayout();
            this.tab_news.SuspendLayout();
            this.tab_mods.SuspendLayout();
            this.tab_log.SuspendLayout();
            this.tabs_log.SuspendLayout();
            this.tab_log_launcher.SuspendLayout();
            this.tab_log_game.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_play.Location = new System.Drawing.Point(0, 366);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(800, 84);
            this.btn_play.TabIndex = 0;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // tabs_main
            // 
            this.tabs_main.Controls.Add(this.tab_news);
            this.tabs_main.Controls.Add(this.tab_friends);
            this.tabs_main.Controls.Add(this.tab_avatars);
            this.tabs_main.Controls.Add(this.tab_worlds);
            this.tabs_main.Controls.Add(this.tab_profile);
            this.tabs_main.Controls.Add(this.tab_mods);
            this.tabs_main.Controls.Add(this.tab_settings);
            this.tabs_main.Controls.Add(this.tab_log);
            this.tabs_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_main.Location = new System.Drawing.Point(0, 0);
            this.tabs_main.Name = "tabs_main";
            this.tabs_main.SelectedIndex = 0;
            this.tabs_main.Size = new System.Drawing.Size(800, 366);
            this.tabs_main.TabIndex = 1;
            this.tabs_main.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_changed);
            // 
            // tab_news
            // 
            this.tab_news.Controls.Add(this.web_home);
            this.tab_news.Location = new System.Drawing.Point(4, 22);
            this.tab_news.Name = "tab_news";
            this.tab_news.Padding = new System.Windows.Forms.Padding(3);
            this.tab_news.Size = new System.Drawing.Size(792, 340);
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
            this.web_home.Size = new System.Drawing.Size(786, 334);
            this.web_home.TabIndex = 0;
            this.web_home.Url = new System.Uri("https://vrchat.com/home", System.UriKind.Absolute);
            this.web_home.WebBrowserShortcutsEnabled = false;
            // 
            // tab_friends
            // 
            this.tab_friends.Location = new System.Drawing.Point(4, 22);
            this.tab_friends.Name = "tab_friends";
            this.tab_friends.Padding = new System.Windows.Forms.Padding(3);
            this.tab_friends.Size = new System.Drawing.Size(792, 340);
            this.tab_friends.TabIndex = 1;
            this.tab_friends.Text = "Friends";
            this.tab_friends.UseVisualStyleBackColor = true;
            // 
            // tab_avatars
            // 
            this.tab_avatars.Location = new System.Drawing.Point(4, 22);
            this.tab_avatars.Name = "tab_avatars";
            this.tab_avatars.Size = new System.Drawing.Size(792, 340);
            this.tab_avatars.TabIndex = 2;
            this.tab_avatars.Text = "Avatars";
            this.tab_avatars.UseVisualStyleBackColor = true;
            // 
            // tab_worlds
            // 
            this.tab_worlds.Location = new System.Drawing.Point(4, 22);
            this.tab_worlds.Name = "tab_worlds";
            this.tab_worlds.Size = new System.Drawing.Size(792, 340);
            this.tab_worlds.TabIndex = 3;
            this.tab_worlds.Text = "Worlds";
            this.tab_worlds.UseVisualStyleBackColor = true;
            // 
            // tab_profile
            // 
            this.tab_profile.Location = new System.Drawing.Point(4, 22);
            this.tab_profile.Name = "tab_profile";
            this.tab_profile.Size = new System.Drawing.Size(792, 340);
            this.tab_profile.TabIndex = 4;
            this.tab_profile.Text = "Profile";
            this.tab_profile.UseVisualStyleBackColor = true;
            // 
            // tab_mods
            // 
            this.tab_mods.Controls.Add(this.lst_mods);
            this.tab_mods.Controls.Add(this.txt_mod_description);
            this.tab_mods.Controls.Add(this.lbl_mod_description);
            this.tab_mods.Controls.Add(this.lbl_mod_type);
            this.tab_mods.Controls.Add(this.txt_mod_type);
            this.tab_mods.Controls.Add(this.lbl_mod_author);
            this.tab_mods.Controls.Add(this.txt_mod_author);
            this.tab_mods.Controls.Add(this.lbl_mod_version);
            this.tab_mods.Controls.Add(this.txt_mod_version);
            this.tab_mods.Controls.Add(this.lbl_mod_path);
            this.tab_mods.Controls.Add(this.txt_mod_path);
            this.tab_mods.Controls.Add(this.lbl_mod_name);
            this.tab_mods.Controls.Add(this.txt_mod_name);
            this.tab_mods.Location = new System.Drawing.Point(4, 22);
            this.tab_mods.Name = "tab_mods";
            this.tab_mods.Size = new System.Drawing.Size(792, 340);
            this.tab_mods.TabIndex = 5;
            this.tab_mods.Text = "Mods";
            this.tab_mods.UseVisualStyleBackColor = true;
            // 
            // lst_mods
            // 
            this.lst_mods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_mods.Dock = System.Windows.Forms.DockStyle.Left;
            this.lst_mods.FullRowSelect = true;
            this.lst_mods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_mods.Location = new System.Drawing.Point(0, 0);
            this.lst_mods.MultiSelect = false;
            this.lst_mods.Name = "lst_mods";
            this.lst_mods.ShowGroups = false;
            this.lst_mods.ShowItemToolTips = true;
            this.lst_mods.Size = new System.Drawing.Size(121, 340);
            this.lst_mods.TabIndex = 13;
            this.lst_mods.UseCompatibleStateImageBehavior = false;
            this.lst_mods.View = System.Windows.Forms.View.List;
            this.lst_mods.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.on_mod_selected);
            // 
            // txt_mod_description
            // 
            this.txt_mod_description.Location = new System.Drawing.Point(196, 88);
            this.txt_mod_description.Name = "txt_mod_description";
            this.txt_mod_description.ReadOnly = true;
            this.txt_mod_description.Size = new System.Drawing.Size(587, 86);
            this.txt_mod_description.TabIndex = 12;
            this.txt_mod_description.Text = "";
            // 
            // lbl_mod_description
            // 
            this.lbl_mod_description.AutoSize = true;
            this.lbl_mod_description.Location = new System.Drawing.Point(127, 91);
            this.lbl_mod_description.Name = "lbl_mod_description";
            this.lbl_mod_description.Size = new System.Drawing.Size(63, 13);
            this.lbl_mod_description.TabIndex = 11;
            this.lbl_mod_description.Text = "Description:";
            // 
            // lbl_mod_type
            // 
            this.lbl_mod_type.AutoSize = true;
            this.lbl_mod_type.Location = new System.Drawing.Point(494, 65);
            this.lbl_mod_type.Name = "lbl_mod_type";
            this.lbl_mod_type.Size = new System.Drawing.Size(34, 13);
            this.lbl_mod_type.TabIndex = 10;
            this.lbl_mod_type.Text = "Type:";
            // 
            // txt_mod_type
            // 
            this.txt_mod_type.Location = new System.Drawing.Point(527, 62);
            this.txt_mod_type.Name = "txt_mod_type";
            this.txt_mod_type.ReadOnly = true;
            this.txt_mod_type.Size = new System.Drawing.Size(256, 20);
            this.txt_mod_type.TabIndex = 9;
            // 
            // lbl_mod_author
            // 
            this.lbl_mod_author.AutoSize = true;
            this.lbl_mod_author.Location = new System.Drawing.Point(127, 65);
            this.lbl_mod_author.Name = "lbl_mod_author";
            this.lbl_mod_author.Size = new System.Drawing.Size(41, 13);
            this.lbl_mod_author.TabIndex = 8;
            this.lbl_mod_author.Text = "Author:";
            // 
            // txt_mod_author
            // 
            this.txt_mod_author.Location = new System.Drawing.Point(171, 62);
            this.txt_mod_author.Name = "txt_mod_author";
            this.txt_mod_author.ReadOnly = true;
            this.txt_mod_author.Size = new System.Drawing.Size(306, 20);
            this.txt_mod_author.TabIndex = 7;
            // 
            // lbl_mod_version
            // 
            this.lbl_mod_version.AutoSize = true;
            this.lbl_mod_version.Location = new System.Drawing.Point(482, 39);
            this.lbl_mod_version.Name = "lbl_mod_version";
            this.lbl_mod_version.Size = new System.Drawing.Size(45, 13);
            this.lbl_mod_version.TabIndex = 6;
            this.lbl_mod_version.Text = "Version:";
            // 
            // txt_mod_version
            // 
            this.txt_mod_version.Location = new System.Drawing.Point(526, 36);
            this.txt_mod_version.Name = "txt_mod_version";
            this.txt_mod_version.ReadOnly = true;
            this.txt_mod_version.Size = new System.Drawing.Size(257, 20);
            this.txt_mod_version.TabIndex = 5;
            // 
            // lbl_mod_path
            // 
            this.lbl_mod_path.AutoSize = true;
            this.lbl_mod_path.Location = new System.Drawing.Point(126, 13);
            this.lbl_mod_path.Name = "lbl_mod_path";
            this.lbl_mod_path.Size = new System.Drawing.Size(32, 13);
            this.lbl_mod_path.TabIndex = 4;
            this.lbl_mod_path.Text = "Path:";
            // 
            // txt_mod_path
            // 
            this.txt_mod_path.Location = new System.Drawing.Point(170, 10);
            this.txt_mod_path.Name = "txt_mod_path";
            this.txt_mod_path.ReadOnly = true;
            this.txt_mod_path.Size = new System.Drawing.Size(613, 20);
            this.txt_mod_path.TabIndex = 3;
            // 
            // lbl_mod_name
            // 
            this.lbl_mod_name.AutoSize = true;
            this.lbl_mod_name.Location = new System.Drawing.Point(126, 39);
            this.lbl_mod_name.Name = "lbl_mod_name";
            this.lbl_mod_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_mod_name.TabIndex = 2;
            this.lbl_mod_name.Text = "Name:";
            // 
            // txt_mod_name
            // 
            this.txt_mod_name.Location = new System.Drawing.Point(170, 36);
            this.txt_mod_name.Name = "txt_mod_name";
            this.txt_mod_name.ReadOnly = true;
            this.txt_mod_name.Size = new System.Drawing.Size(306, 20);
            this.txt_mod_name.TabIndex = 1;
            // 
            // tab_settings
            // 
            this.tab_settings.Location = new System.Drawing.Point(4, 22);
            this.tab_settings.Name = "tab_settings";
            this.tab_settings.Size = new System.Drawing.Size(792, 340);
            this.tab_settings.TabIndex = 6;
            this.tab_settings.Text = "Settings";
            this.tab_settings.UseVisualStyleBackColor = true;
            // 
            // tab_log
            // 
            this.tab_log.Controls.Add(this.tabs_log);
            this.tab_log.Location = new System.Drawing.Point(4, 22);
            this.tab_log.Name = "tab_log";
            this.tab_log.Size = new System.Drawing.Size(792, 340);
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
            this.tabs_log.Size = new System.Drawing.Size(792, 340);
            this.tabs_log.TabIndex = 0;
            this.tabs_log.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_changed);
            // 
            // tab_log_launcher
            // 
            this.tab_log_launcher.Controls.Add(this.lst_log_launcher);
            this.tab_log_launcher.Location = new System.Drawing.Point(4, 22);
            this.tab_log_launcher.Name = "tab_log_launcher";
            this.tab_log_launcher.Padding = new System.Windows.Forms.Padding(3);
            this.tab_log_launcher.Size = new System.Drawing.Size(784, 314);
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
            this.lst_log_launcher.Size = new System.Drawing.Size(778, 308);
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
            this.tab_log_game.Size = new System.Drawing.Size(784, 314);
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
            this.lst_log_game.Size = new System.Drawing.Size(778, 308);
            this.lst_log_game.TabIndex = 0;
            this.lst_log_game.UseCompatibleStateImageBehavior = false;
            this.lst_log_game.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabs_main);
            this.Controls.Add(this.btn_play);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "VRChat Launcher";
            this.Load += new System.EventHandler(this.mainForm_loaded);
            this.tabs_main.ResumeLayout(false);
            this.tab_news.ResumeLayout(false);
            this.tab_mods.ResumeLayout(false);
            this.tab_mods.PerformLayout();
            this.tab_log.ResumeLayout(false);
            this.tabs_log.ResumeLayout(false);
            this.tab_log_launcher.ResumeLayout(false);
            this.tab_log_game.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.TabControl tabs_main;
        private System.Windows.Forms.TabPage tab_news;
        private System.Windows.Forms.WebBrowser web_home;
        private System.Windows.Forms.TabPage tab_friends;
        private System.Windows.Forms.TabPage tab_avatars;
        private System.Windows.Forms.TabPage tab_worlds;
        private System.Windows.Forms.TabPage tab_profile;
        private System.Windows.Forms.TabPage tab_mods;
        private System.Windows.Forms.TabPage tab_settings;
        private System.Windows.Forms.RichTextBox txt_mod_description;
        private System.Windows.Forms.Label lbl_mod_description;
        private System.Windows.Forms.Label lbl_mod_type;
        private System.Windows.Forms.TextBox txt_mod_type;
        private System.Windows.Forms.Label lbl_mod_author;
        private System.Windows.Forms.TextBox txt_mod_author;
        private System.Windows.Forms.Label lbl_mod_version;
        private System.Windows.Forms.TextBox txt_mod_version;
        private System.Windows.Forms.Label lbl_mod_path;
        private System.Windows.Forms.TextBox txt_mod_path;
        private System.Windows.Forms.Label lbl_mod_name;
        private System.Windows.Forms.TextBox txt_mod_name;
        private System.Windows.Forms.TabPage tab_log;
        private System.Windows.Forms.TabControl tabs_log;
        private System.Windows.Forms.TabPage tab_log_launcher;
        private System.Windows.Forms.TabPage tab_log_game;
        private System.Windows.Forms.ListView lst_mods;
        private System.Windows.Forms.ListView lst_log_launcher;
        private System.Windows.Forms.ListView lst_log_game;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

