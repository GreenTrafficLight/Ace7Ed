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

namespace Ace7Ed.Interact
{
    public partial class BatchCopyLanguage : Form
    {
        public List<char> SelectedPasteLanguages = new List<char>();

        public int SelectedCopyLanguageIndex
        {
            get
            {
                if (CopyLanguageComboBox.SelectedItem != null)
                {
                    DAT dat = (DAT)CopyLanguageComboBox.SelectedItem;
                    return dat.Letter - 65;
                }
                return -1;
            }
        }

        public bool OverwriteExistingString
        {
            get
            {
                return PasteLanguageOverwriteStringsCheckBox.Checked;
            }
        }

        public int StartNumber
        {
            get
            {
                return Convert.ToInt32(StartNumberNumericUpDown.Value);
            }
        }

        public int EndNumber
        {
            get
            {
                return Convert.ToInt32(EndNumberNumericUpDown.Value);
            }
        }


        private List<DAT> _Dats;

        public BatchCopyLanguage((CMN, List<DAT>) localization)
        {
            InitializeComponent();
            ToggleDarkTheme();

            _Dats = localization.Item2;

            LoadStartNumberNumericUpDown(localization.Item1);
            LoadEndNumberNumericUpDown(localization.Item1);
            LoadPasteLanguageComboBox(_Dats);
        }

        private void ToggleDarkTheme()
        {
            BackColor = Theme.WindowColor;
            ForeColor = Theme.WindowTextColor;

            Theme.SetDarkThemeLabel(PasteLanguageTextLabel);

            Theme.SetDarkThemeButton(SelectAllButton);
            Theme.SetDarkThemeButton(DeselectAllButton);
            Theme.SetDarkThemeButton(OkButton);

            Theme.SetDarkThemeComboBox(CopyLanguageComboBox);

            Theme.SetDarkThemeCheckBox(PasteLanguageOverwriteStringsCheckBox);

            Theme.SetDarkThemeDataGridView(PasteLanguagesDataGridView);
        }

        private void LoadStartNumberNumericUpDown(CMN cmn)
        {
            StartNumberNumericUpDown.Maximum = cmn.MaxStringNumber;
        }

        private void LoadEndNumberNumericUpDown(CMN cmn)
        {
            EndNumberNumericUpDown.Minimum = StartNumberNumericUpDown.Value + 1;
            EndNumberNumericUpDown.Maximum = cmn.MaxStringNumber + 1;
            EndNumberNumericUpDown.Value = cmn.MaxStringNumber + 1;
        }

        private void LoadPasteLanguageComboBox(List<DAT> dats)
        {
            CopyLanguageComboBox.BeginUpdate();

            CopyLanguageComboBox.Items.Clear();

            dats.ForEach(dat => CopyLanguageComboBox.Items.Add(dat));

            CopyLanguageComboBox.EndUpdate();
        }

        private void LoadLanguagesDataGridView(List<DAT> dats)
        {
            PasteLanguagesDataGridView.Columns.Clear();
            PasteLanguagesDataGridView.Columns.Add("designLanguage", "Language");
            PasteLanguagesDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PasteLanguagesDataGridView.Columns[0].ReadOnly = true;

            PasteLanguagesDataGridView.Rows.Clear();

            DAT selectedItem = (DAT)CopyLanguageComboBox.SelectedItem;

            foreach (var dat in dats)
            {
                if (dat.Letter != selectedItem.Letter && SelectedCopyLanguageIndex != -1)
                {
                    PasteLanguagesDataGridView.Rows.Add(dat);
                }
            }

            PasteLanguagesDataGridView.ClearSelection();
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            PasteLanguagesDataGridView.SelectAll();
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            PasteLanguagesDataGridView.ClearSelection();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell selectedLanguage in PasteLanguagesDataGridView.SelectedCells)
            {
                DAT dat = (DAT)selectedLanguage.Value;
                SelectedPasteLanguages.Add(dat.Letter);
            }
            DialogResult = DialogResult.OK;
        }

        private void CopyLanguageComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadLanguagesDataGridView(_Dats);
        }

        private void StartNumberNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EndNumberNumericUpDown.Minimum = StartNumberNumericUpDown.Value + 1;
        }
    }
}
