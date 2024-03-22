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
        public Input(string labelText, string existingString = "")
        {
            InitializeComponent();
            ToggleDarkTheme();


            InputExistingStringLabel.Text = existingString;
            Size s = TextRenderer.MeasureText(existingString, InputExistingStringLabel.Font);
            InputExistingStringLabel.Width = s.Width;

            InputTextBox.Left += s.Width;
            InputTextBox.Width -= s.Width;
            

            LoadInputCustomTextLabel(labelText);
        }

        private void ToggleDarkTheme()
        {
            BackColor = Theme.WindowColor;
            ForeColor = Theme.WindowTextColor;
        }

        private void LoadInputCustomTextLabel(string labelText)
        {
            InputCustomTextLabel.Text = labelText;
        }
    }
}
