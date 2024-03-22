using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ace7Ed.Prompt
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
            ToggleDarkTheme();
        }

        private void ToggleDarkTheme()
        {
            BackColor = Theme.WindowColor;
            ForeColor = Theme.WindowTextColor;
        }
    }
}
