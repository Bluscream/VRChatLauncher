namespace VRChatLauncher.UI
{
    partial class OperationsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationsPanel));
            this.btn_startstop = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lst_operation = new System.Windows.Forms.ListView();
            this.progress_operation = new System.Windows.Forms.ProgressBar();
            this.grp_settings = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_startstop
            // 
            this.btn_startstop.Depth = 0;
            this.btn_startstop.Location = new System.Drawing.Point(444, 3);
            this.btn_startstop.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_startstop.Name = "btn_startstop";
            this.btn_startstop.Primary = true;
            this.btn_startstop.Size = new System.Drawing.Size(109, 52);
            this.btn_startstop.TabIndex = 0;
            this.btn_startstop.Text = "Start";
            this.btn_startstop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_startstop.UseVisualStyleBackColor = true;
            this.btn_startstop.Click += new System.EventHandler(this.Btn_startstop_Click);
            // 
            // lst_operation
            // 
            this.lst_operation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_operation.Location = new System.Drawing.Point(10, 3);
            this.lst_operation.Name = "lst_operation";
            this.lst_operation.Size = new System.Drawing.Size(549, 151);
            this.lst_operation.TabIndex = 1;
            this.lst_operation.UseCompatibleStateImageBehavior = false;
            // 
            // progress_operation
            // 
            this.progress_operation.Dock = System.Windows.Forms.DockStyle.Top;
            this.progress_operation.Location = new System.Drawing.Point(0, 0);
            this.progress_operation.Name = "progress_operation";
            this.progress_operation.Size = new System.Drawing.Size(434, 23);
            this.progress_operation.TabIndex = 2;
            // 
            // grp_settings
            // 
            this.grp_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_settings.Location = new System.Drawing.Point(7, 0);
            this.grp_settings.Name = "grp_settings";
            this.grp_settings.Size = new System.Drawing.Size(549, 154);
            this.grp_settings.TabIndex = 3;
            this.grp_settings.TabStop = false;
            this.grp_settings.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.grp_settings);
            this.panel1.Controls.Add(this.lst_operation);
            this.panel1.Location = new System.Drawing.Point(12, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 221);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btn_startstop);
            this.panel2.Location = new System.Drawing.Point(3, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(556, 58);
            this.panel2.TabIndex = 4;
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(0, 29);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(434, 23);
            this.materialSingleLineTextField1.TabIndex = 3;
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.materialSingleLineTextField1);
            this.panel3.Controls.Add(this.progress_operation);
            this.panel3.Location = new System.Drawing.Point(4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 52);
            this.panel3.TabIndex = 5;
            // 
            // OperationsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 309);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OperationsPanel";
            this.Text = "VRChat Launcher";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btn_startstop;
        private System.Windows.Forms.ListView lst_operation;
        private System.Windows.Forms.ProgressBar progress_operation;
        private System.Windows.Forms.GroupBox grp_settings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
    }
}