﻿using Ace7LocalizationFormat.Formats;
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

        public int SelectedCopyLanguage
        {
            get
            {
                if (CopyLanguageComboBox.SelectedItem != null)
                {
                    return (char)CopyLanguageComboBox.SelectedItem - 65;
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

        private List<DAT> _Dats;

        public BatchCopyLanguage(List<DAT> dats)
        {
            InitializeComponent();
            ToggleDarkTheme();

            _Dats = dats;

            LoadPasteLanguageComboBox(_Dats);
            LoadLanguagesDataGridView(_Dats);
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

        private void LoadPasteLanguageComboBox(List<DAT> dats)
        {
            CopyLanguageComboBox.BeginUpdate();

            CopyLanguageComboBox.Items.Clear();

            dats.ForEach(dat => CopyLanguageComboBox.Items.Add(dat.Letter));

            CopyLanguageComboBox.EndUpdate();
        }

        private void LoadLanguagesDataGridView(List<DAT> dats)
        {
            PasteLanguagesDataGridView.Columns.Clear();
            PasteLanguagesDataGridView.Columns.Add("designLanguage", "Language");
            PasteLanguagesDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PasteLanguagesDataGridView.Columns[0].ReadOnly = true;

            PasteLanguagesDataGridView.Rows.Clear();

            foreach (var dat in dats)
            {
                if (dat.Letter != SelectedCopyLanguage + 65 && SelectedCopyLanguage != -1)
                {
                    PasteLanguagesDataGridView.Rows.Add(dat.Letter.ToString());
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
                SelectedPasteLanguages.Add(selectedLanguage.Value.ToString()[0]);
            }
            DialogResult = DialogResult.OK;
        }

        private void CopyLanguageComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadLanguagesDataGridView(_Dats);
        }
    }
}