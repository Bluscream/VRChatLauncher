namespace VRChatLauncher.UI
{
    partial class ChatWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_chat_input = new System.Windows.Forms.TextBox();
            this.tabs_chat = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_send);
            this.panel1.Controls.Add(this.txt_chat_input);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 27);
            this.panel1.TabIndex = 0;
            // 
            // btn_send
            // 
            this.btn_send.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_send.Location = new System.Drawing.Point(464, 3);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(93, 23);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.Btn_send_Click);
            // 
            // txt_chat_input
            // 
            this.txt_chat_input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_chat_input.Location = new System.Drawing.Point(3, 3);
            this.txt_chat_input.Multiline = true;
            this.txt_chat_input.Name = "txt_chat_input";
            this.txt_chat_input.Size = new System.Drawing.Size(455, 20);
            this.txt_chat_input.TabIndex = 0;
            this.txt_chat_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_chat_input_KeyPress);
            // 
            // tabs_chat
            // 
            this.tabs_chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_chat.Location = new System.Drawing.Point(0, 0);
            this.tabs_chat.Name = "tabs_chat";
            this.tabs_chat.SelectedIndex = 0;
            this.tabs_chat.Size = new System.Drawing.Size(560, 275);
            this.tabs_chat.TabIndex = 0;
            this.tabs_chat.Selected += new System.Windows.Forms.TabControlEventHandler(this.Tabs_chat_Selected);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 302);
            this.Controls.Add(this.tabs_chat);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chat";
            this.Text = "Chat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_chat_input;
        private System.Windows.Forms.TabControl tabs_chat;
    }
}