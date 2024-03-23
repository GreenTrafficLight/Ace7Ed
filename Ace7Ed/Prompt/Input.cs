using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Ace7Ed.Prompt
{
    public partial class Input : Form
    {
        public string InputText
        {
            get { return TextBox.Text; }
            set { TextBox.Text = value.ToString(); }
        }
        public Input(string labelText, string existingString = "")
        {
            InitializeComponent();
            ToggleDarkTheme();


            ExistingStringLabel.Text = existingString;
            Size s = TextRenderer.MeasureText(existingString, ExistingStringLabel.Font);
            ExistingStringLabel.Width = s.Width;

            TextBox.Left += s.Width;
            TextBox.Width -= s.Width;

            LoadInputCustomTextLabel(labelText);
        }

        private void ToggleDarkTheme()
        {
            BackColor = Theme.WindowColor;
            ForeColor = Theme.WindowTextColor;

            Theme.SetDarkThemeButton(OkButton);

            Theme.SetDarkThemeTextBox(TextBox);

            Theme.SetDarkThemeLabel(CustomTextLabel);
            Theme.SetDarkThemeLabel(ExistingStringLabel);
        }

        private void LoadInputCustomTextLabel(string labelText)
        {
            CustomTextLabel.Text = labelText;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
