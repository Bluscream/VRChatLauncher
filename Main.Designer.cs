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
            this.btn_mods_refresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabs_main.SuspendLayout();
            this.tab_news.SuspendLayout();
            this.tab_mods.SuspendLayout();
            this.tab_log.SuspendLayout();
            this.tabs_log.SuspendLayout();
            this.tab_log_launcher.SuspendLayout();
            this.tab_log_game.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_play.Location = new System.Drawing.Point(0, 367);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(913, 84);
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
            this.tabs_main.Size = new System.Drawing.Size(913, 367);
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
            this.tab_mods.Controls.Add(this.tableLayoutPanel1);
            this.tab_mods.Controls.Add(this.panel1);
            this.tab_mods.Location = new System.Drawing.Point(4, 22);
            this.tab_mods.Name = "tab_mods";
            this.tab_mods.Size = new System.Drawing.Size(905, 341);
            this.tab_mods.TabIndex = 5;
            this.tab_mods.Text = "Mods";
            this.tab_mods.UseVisualStyleBackColor = true;
            // 
            // lst_mods
            // 
            this.lst_mods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_mods.Dock = System.Windows.Forms.DockStyle.Top;
            this.lst_mods.FullRowSelect = true;
            this.lst_mods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_mods.Location = new System.Drawing.Point(0, 0);
            this.lst_mods.MultiSelect = false;
            this.lst_mods.Name = "lst_mods";
            this.lst_mods.ShowGroups = false;
            this.lst_mods.ShowItemToolTips = true;
            this.lst_mods.Size = new System.Drawing.Size(121, 311);
            this.lst_mods.TabIndex = 13;
            this.lst_mods.UseCompatibleStateImageBehavior = false;
            this.lst_mods.View = System.Windows.Forms.View.List;
            this.lst_mods.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.on_mod_selected);
            // 
            // txt_mod_description
            // 
            this.txt_mod_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_description.Location = new System.Drawing.Point(133, 133);
            this.txt_mod_description.Name = "txt_mod_description";
            this.txt_mod_description.ReadOnly = true;
            this.txt_mod_description.Size = new System.Drawing.Size(648, 88);
            this.txt_mod_description.TabIndex = 12;
            this.txt_mod_description.Text = "";
            // 
            // lbl_mod_description
            // 
            this.lbl_mod_description.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_mod_description.AutoSize = true;
            this.lbl_mod_description.Location = new System.Drawing.Point(3, 170);
            this.lbl_mod_description.Name = "lbl_mod_description";
            this.lbl_mod_description.Size = new System.Drawing.Size(63, 13);
            this.lbl_mod_description.TabIndex = 11;
            this.lbl_mod_description.Text = "Description:";
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
            // txt_mod_type
            // 
            this.txt_mod_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_type.Location = new System.Drawing.Point(133, 107);
            this.txt_mod_type.Name = "txt_mod_type";
            this.txt_mod_type.ReadOnly = true;
            this.txt_mod_type.Size = new System.Drawing.Size(648, 20);
            this.txt_mod_type.TabIndex = 9;
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
            // txt_mod_author
            // 
            this.txt_mod_author.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_author.Location = new System.Drawing.Point(133, 81);
            this.txt_mod_author.Name = "txt_mod_author";
            this.txt_mod_author.ReadOnly = true;
            this.txt_mod_author.Size = new System.Drawing.Size(648, 20);
            this.txt_mod_author.TabIndex = 7;
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
            this.txt_mod_version.Location = new System.Drawing.Point(133, 55);
            this.txt_mod_version.Name = "txt_mod_version";
            this.txt_mod_version.ReadOnly = true;
            this.txt_mod_version.Size = new System.Drawing.Size(648, 20);
            this.txt_mod_version.TabIndex = 5;
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
            // txt_mod_path
            // 
            this.txt_mod_path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_path.Location = new System.Drawing.Point(133, 3);
            this.txt_mod_path.Name = "txt_mod_path";
            this.txt_mod_path.ReadOnly = true;
            this.txt_mod_path.Size = new System.Drawing.Size(648, 20);
            this.txt_mod_path.TabIndex = 3;
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
            // txt_mod_name
            // 
            this.txt_mod_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mod_name.Location = new System.Drawing.Point(133, 29);
            this.txt_mod_name.Name = "txt_mod_name";
            this.txt_mod_name.ReadOnly = true;
            this.txt_mod_name.Size = new System.Drawing.Size(648, 20);
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
            // btn_mods_refresh
            // 
            this.btn_mods_refresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_mods_refresh.Location = new System.Drawing.Point(0, 318);
            this.btn_mods_refresh.Name = "btn_mods_refresh";
            this.btn_mods_refresh.Size = new System.Drawing.Size(121, 23);
            this.btn_mods_refresh.TabIndex = 14;
            this.btn_mods_refresh.Text = "Reload";
            this.btn_mods_refresh.UseVisualStyleBackColor = true;
            this.btn_mods_refresh.Click += new System.EventHandler(this.Btn_mods_refresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lst_mods);
            this.panel1.Controls.Add(this.btn_mods_refresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 341);
            this.panel1.TabIndex = 16;
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(121, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 224);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 451);
            this.Controls.Add(this.tabs_main);
            this.Controls.Add(this.btn_play);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "VRChat Launcher";
            this.Load += new System.EventHandler(this.mainForm_loaded);
            this.tabs_main.ResumeLayout(false);
            this.tab_news.ResumeLayout(false);
            this.tab_mods.ResumeLayout(false);
            this.tab_log.ResumeLayout(false);
            this.tabs_log.ResumeLayout(false);
            this.tab_log_launcher.ResumeLayout(false);
            this.tab_log_game.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.Button btn_mods_refresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

