namespace VRChatLauncher.UI
{
    partial class CommandLineArguments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandLineArguments));
            this.lst_arguments = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_launch_path = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst_arguments
            // 
            this.lst_arguments.Dock = System.Windows.Forms.DockStyle.Top;
            this.lst_arguments.FormattingEnabled = true;
            this.lst_arguments.Location = new System.Drawing.Point(0, 0);
            this.lst_arguments.Name = "lst_arguments";
            this.lst_arguments.Size = new System.Drawing.Size(800, 420);
            this.lst_arguments.TabIndex = 0;
            this.lst_arguments.SelectedIndexChanged += new System.EventHandler(this.Lst_arguments_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_launch_path);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 24);
            this.panel1.TabIndex = 1;
            // 
            // btn_start
            // 
            this.btn_start.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_start.Location = new System.Drawing.Point(725, 0);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 24);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // txt_launch_path
            // 
            this.txt_launch_path.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_launch_path.Location = new System.Drawing.Point(3, 1);
            this.txt_launch_path.Name = "txt_launch_path";
            this.txt_launch_path.Size = new System.Drawing.Size(716, 20);
            this.txt_launch_path.TabIndex = 1;
            // 
            // CommandLineArguments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lst_arguments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommandLineArguments";
            this.Text = "VRCLauncher - Command Line Arguments";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_arguments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_launch_path;
    }
}