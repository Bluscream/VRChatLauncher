namespace VRChatLauncher.UI
{
    partial class MultilineInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultilineInput));
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.panel_buttons = new System.Windows.Forms.Panel();
            this.panel_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_cancel.Location = new System.Drawing.Point(0, 0);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 33);
            this.btn_cancel.TabIndex = 0;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ok.Location = new System.Drawing.Point(358, 0);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 33);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
            // 
            // txt_input
            // 
            this.txt_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_input.Location = new System.Drawing.Point(0, 0);
            this.txt_input.Multiline = true;
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(433, 244);
            this.txt_input.TabIndex = 1;
            this.txt_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_input_KeyDown);
            this.txt_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_input_KeyPress);
            // 
            // panel_buttons
            // 
            this.panel_buttons.Controls.Add(this.btn_ok);
            this.panel_buttons.Controls.Add(this.btn_cancel);
            this.panel_buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_buttons.Location = new System.Drawing.Point(0, 211);
            this.panel_buttons.Name = "panel_buttons";
            this.panel_buttons.Size = new System.Drawing.Size(433, 33);
            this.panel_buttons.TabIndex = 2;
            // 
            // MultilineInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 244);
            this.Controls.Add(this.panel_buttons);
            this.Controls.Add(this.txt_input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultilineInput";
            this.panel_buttons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.Panel panel_buttons;
    }
}