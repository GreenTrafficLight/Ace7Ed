using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ace7Ed
{
    public partial class DatStringEditor : Form
    {
        private string _oldDatText { get; }
        public string DatText
        {
            get { return DatTextRichTextBox.Text + "\0"; }
            set { DatTextRichTextBox.Text = value.ToString(); }
        }

        private bool _savedChanges = true;

        public DatStringEditor(string datText)
        {
            InitializeComponent();
            ToggleDarkTheme();

            _oldDatText = datText;

            LoadStringEditorStringRichTextBox(datText);
        }

        private void ToggleDarkTheme()
        {
            BackColor = Theme.ControlColor;
            ForeColor = Theme.ControlTextColor;

            Theme.SetDarkThemeButton(SaveButton);

            Theme.SetDarkThemeRichTextBox(DatTextRichTextBox);
        }

        private void LoadStringEditorStringRichTextBox(string datText)
        {
            DatTextRichTextBox.Text = datText;
        }

        private void StringEditorSaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void DatStringEditorStringRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_savedChanges == true)
            {
                Text += "*";
                _savedChanges = false;
            }

            if (_oldDatText.Equals(DatText))
            {
                Text = Text.Substring(0, Text.Length - 1); // Remove the "*"
                _savedChanges = true;
            }
        }

        private void DatStringEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_savedChanges == false && DialogResult != DialogResult.OK)
            {
                var result = MessageBox.Show("You have unsaved changes, are you sure that you want to exit ?", "Exit ?", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else if (DialogResult == DialogResult.OK)
            {
                _savedChanges = true;
            }
        }
    }
}
