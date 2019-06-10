using System.Windows.Forms;
using System.Drawing;
using System;

namespace VRChatLauncher.UI
{
    class Utils
    {
        public static DialogResult InputBox(string title, string promptText, ref string value, bool multiline = false)
        {
          Form form = new Form();
          Label label = new Label();
          TextBox textBox = new TextBox();
          Button buttonOk = new Button();
          Button buttonCancel = new Button();

          form.Text = title;
          label.Text = promptText;
          textBox.Text = value;
          if (multiline) textBox.Multiline = true;

          buttonOk.Text = "OK";
          buttonCancel.Text = "Cancel";
          buttonOk.DialogResult = DialogResult.OK;
          buttonCancel.DialogResult = DialogResult.Cancel;

          label.SetBounds(10, 20, 370, 15);
            if (multiline)
            {
                var btn_vertical = 130;
                buttonOk.SetBounds(230, btn_vertical, 75, 25);
                buttonCancel.SetBounds(310, btn_vertical, 75, 25);
                textBox.SetBounds(10, 35, 370, 90);
            }
            else
            {
                buttonOk.SetBounds(230, 70, 75, 25);
                buttonCancel.SetBounds(310, 70, 75, 25);
                textBox.SetBounds(10, 35, 370, 20);
            }

          label.AutoSize = true;
          textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
          buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
          buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

          if (multiline) form.ClientSize = new Size(400, 160);
          else form.ClientSize = new Size(400, 100);
          form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
          form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
          form.FormBorderStyle = FormBorderStyle.FixedDialog;
          form.StartPosition = FormStartPosition.CenterScreen;
          form.MinimizeBox = false;
          form.MaximizeBox = false;
          form.AcceptButton = buttonOk;
          form.CancelButton = buttonCancel;

          DialogResult dialogResult = form.ShowDialog();
          value = textBox.Text;
          textBox.Focus();
          return dialogResult;
        }

    }
}