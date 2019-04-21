using System;
using System.Windows.Forms;
using VRChatLauncher.Utils;

namespace VRChatLauncher
{
    partial class Main
    {
        public bool settingsInitialized = false;

        public void SetupSettings() {
            flow_settings.Controls.Clear();
            foreach (var section in config.Sections)
            {
                var group = new GroupBox();
                group.Text = section.SectionName;
                group.AutoSizeMode = AutoSizeMode.GrowOnly;
                var table = new TableLayoutPanel();
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.00000F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.00000F));
                table.Dock = DockStyle.Fill;
                // table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
                table.AutoSize = true;
                table.ColumnCount = section.Keys.Count;
                group.Controls.Add(table);
                var i = 0;
                foreach (var setting in section.Keys)
                {
                    var label = new Label();
                    label.Text = setting.KeyName + ":";
                    label.AutoSize = true;
                    label.Anchor = (AnchorStyles.Left);
                    label.Dock = DockStyle.Fill;
                    label.TabIndex = 0;
                    table.Controls.Add(label, 0, i);
                    var txt = new TextBox();
                    txt.Text = setting.Value;
                    txt.AutoSize = true;
                    txt.Anchor = (AnchorStyles.Right | AnchorStyles.Left);
                    txt.Dock = DockStyle.Fill;
                    // txt.Anchor = AnchorStyles.Right; 
                    txt.TabIndex = 1;
                    table.Controls.Add(txt, 1, i);
                    i++;
                }
                flow_settings.Controls.Add(group);
                // group.AutoSize = true;
            }
        }

        private void Btn_config_save_Click(object sender, EventArgs e) {
            Config.Save(config);
        }
    }
}
