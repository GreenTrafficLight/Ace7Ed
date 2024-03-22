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
            get { return DatStringEditorStringRichTextBox.Text + "\0"; }
            set { DatStringEditorStringRichTextBox.Text = value.ToString(); }
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

            DatStringEditorStringRichTextBox.BackColor = Theme.WindowColor;
            DatStringEditorStringRichTextBox.ForeColor = Theme.WindowTextColor;

            StringEditorSaveButton.BackColor = Theme.ControlColor;
            StringEditorSaveButton.ForeColor = Theme.ControlTextColor;
        }

        private void LoadStringEditorStringRichTextBox(string datText)
        {
            DatStringEditorStringRichTextBox.Text = datText;
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
            if (_savedChanges == false)
            {
                var result = MessageBox.Show("Exit Program?", "Exit?", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
