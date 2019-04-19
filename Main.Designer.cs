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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_news = new System.Windows.Forms.TabPage();
            this.web_home = new System.Windows.Forms.WebBrowser();
            this.tab_friends = new System.Windows.Forms.TabPage();
            this.tab_avatars = new System.Windows.Forms.TabPage();
            this.tab_worlds = new System.Windows.Forms.TabPage();
            this.tab_profile = new System.Windows.Forms.TabPage();
            this.tab_mods = new System.Windows.Forms.TabPage();
            this.tab_settings = new System.Windows.Forms.TabPage();
            this.lst_mods = new System.Windows.Forms.ListView();
            this.tabControl1.SuspendLayout();
            this.tab_news.SuspendLayout();
            this.tab_mods.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_news);
            this.tabControl1.Controls.Add(this.tab_friends);
            this.tabControl1.Controls.Add(this.tab_avatars);
            this.tabControl1.Controls.Add(this.tab_worlds);
            this.tabControl1.Controls.Add(this.tab_profile);
            this.tabControl1.Controls.Add(this.tab_mods);
            this.tabControl1.Controls.Add(this.tab_settings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 366);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_changed);
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
            this.tab_mods.Location = new System.Drawing.Point(4, 22);
            this.tab_mods.Name = "tab_mods";
            this.tab_mods.Size = new System.Drawing.Size(792, 340);
            this.tab_mods.TabIndex = 5;
            this.tab_mods.Text = "Mods";
            this.tab_mods.UseVisualStyleBackColor = true;
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
            // lst_mods
            // 
            this.lst_mods.Dock = System.Windows.Forms.DockStyle.Left;
            this.lst_mods.FullRowSelect = true;
            this.lst_mods.Location = new System.Drawing.Point(0, 0);
            this.lst_mods.Name = "lst_mods";
            this.lst_mods.Size = new System.Drawing.Size(121, 340);
            this.lst_mods.TabIndex = 0;
            this.lst_mods.UseCompatibleStateImageBehavior = false;
            this.lst_mods.View = System.Windows.Forms.View.List;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_play);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "VRChat Launcher";
            this.tabControl1.ResumeLayout(false);
            this.tab_news.ResumeLayout(false);
            this.tab_mods.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_news;
        private System.Windows.Forms.WebBrowser web_home;
        private System.Windows.Forms.TabPage tab_friends;
        private System.Windows.Forms.TabPage tab_avatars;
        private System.Windows.Forms.TabPage tab_worlds;
        private System.Windows.Forms.TabPage tab_profile;
        private System.Windows.Forms.TabPage tab_mods;
        private System.Windows.Forms.TabPage tab_settings;
        private System.Windows.Forms.ListView lst_mods;
    }
}

