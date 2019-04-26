using System;
using System.Collections.Generic;
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

        private void Btn_config_apply_Click(object sender, EventArgs e) // Todo: Clean up this clusterfuck
        {
            var sections = new Dictionary<string, Dictionary<int, Dictionary<string, string>>>();
            foreach (var _section in (flow_settings.Controls)) {
                if (!(_section is GroupBox)) continue;
                var section = (GroupBox)_section;
                if (!sections.ContainsKey(section.Text)) {
                    sections.Add(section.Text, new Dictionary<int, Dictionary<string, string>>());
                }
                var table = (TableLayoutPanel)section.Controls[0];
                var rowCount = table.Controls.Count / 2;
                // var rows = new Dictionary<int, Dictionary<string, string>>();
                var lastKey = "";
                foreach (Control _setting in table.Controls)
                {
                    var row = table.GetRow(_setting) + 1;
                    if (!sections[section.Text].ContainsKey(row)) {
                        sections[section.Text].Add(row, new Dictionary<string, string>());
                    }
                    if ((_setting is Label)) {
                        var setting = (Label)_setting;
                        var key = setting.Text.EndsWith(":") ? setting.Text.ReplaceLastOccurrence(":", "") : setting.Text;
                        sections[section.Text][row].Add(key, "");
                        lastKey = key;
                    } else if (_setting is TextBox) {
                        var setting = (TextBox)_setting;
                        var val = setting.Text;
                        sections[section.Text][row][lastKey] = val;
                    }
                }
            }
            Logger.Trace(sections.ToJson());
            foreach (var section in sections) {
                foreach (var _row in sections[section.Key])
                {
                    foreach (var row in _row.Value)
                    {
                        config[section.Key][row.Key] = row.Value;
                    }
                }
            }
        }

        private void Btn_config_save_Click(object sender, EventArgs e) {
            Config.Save(config);
            Logger.Log("Saved config to", Config.DefaultConfigFile.Quote(), $"{config.Sections.Count} sections".Enclose());
        }
    }
}
