using Ace7LocalizationFormat.Formats;
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
    public partial class CopyPasteLanguagesSelector : Form
    {
        public CopyPasteLanguagesSelector(List<DAT> dats, char selectedLanguage)
        {
            InitializeComponent();
            ToggleDarkTheme();

            LoadLanguagesDataGridView(dats, selectedLanguage);
        }

        private void ToggleDarkTheme()
        {
            BackColor = Theme.WindowColor;
            ForeColor = Theme.WindowTextColor;

            Theme.SetDarkThemeButton(SelectAllButton);
            Theme.SetDarkThemeButton(DeselectAllButton);
            Theme.SetDarkThemeButton(OkButton);

            Theme.SetDarkThemeDataGridView(LanguagesDataGridView);
        }

        private void LoadLanguagesDataGridView(List<DAT> dats, char selectedLanguage)
        {
            LanguagesDataGridView.Columns.Clear();
            LanguagesDataGridView.Columns.Add("designLanguage", "Language");
            LanguagesDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LanguagesDataGridView.Columns[0].ReadOnly = true;

            LanguagesDataGridView.Rows.Clear();

            foreach (var dat in dats)
            {
                if (dat.Letter != selectedLanguage)
                {
                    LanguagesDataGridView.Rows.Add(dat.Letter.ToString());
                }
            }

            LanguagesDataGridView.ClearSelection();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            LanguagesDataGridView.SelectAll();
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            LanguagesDataGridView.ClearSelection();
        }
    }
}
