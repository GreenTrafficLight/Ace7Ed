using Ace7Ed.Properties;
using Ace7Ed.Prompt;
using Ace7LocalizationFormat.Formats;
using System.ComponentModel;
using System.Windows.Forms;
using static Ace7LocalizationFormat.Formats.CMN;
using Ace7Ed.Interact;
using System.Diagnostics;

namespace Ace7Ed
{
    public partial class LocalizationEditor : Form
    {
        private (CMN, List<DAT>) _modifiedLocalization = new(null, null);

        private string _directory { get; set; }

        private (int, int, List<string>) _copyStrings { get; set; }

        private int _selectedRowIndex = -1;
        private int _selectedColumnIndex = -1;

        private int _selectedDatIndex
        {
            get
            {
                if (DatLanguageComboBox.SelectedItem != null)
                {
                    return (char)DatLanguageComboBox.SelectedItem - 65;
                }
                return -1;

            }
        }

        private bool _savedChanges = true;
        public bool SavedChanges
        {
            get
            {
                return _savedChanges;
            }
            set
            {
                _savedChanges = value;
                if (_savedChanges)
                {
                    Text = Text.Substring(0, Text.Length - 1); // Remove the "*"
                }
                else
                {
                    Text += "*";
                }
            }
        }

        public LocalizationEditor()
        {
            InitializeComponent();
            ToggleDarkTheme();
        }

        private void ToggleDarkTheme()
        {
            BackColor = Theme.ControlColor;
            ForeColor = Theme.ControlTextColor;

            LocalizationEditorMenuStrip.Renderer = new Theme.MenuStripRenderer();

            Theme.SetDarkThemeToolStripMenuItem(MenuStripMain);
            Theme.SetDarkThemeToolStripMenuItem(MSMainOpenFolder);
            Theme.SetDarkThemeToolStripMenuItem(MSMainSave);

            Theme.SetDarkThemeToolStripMenuItem(MenuStripOptions);
            Theme.SetDarkThemeToolStripMenuItem(MSOptionBatchCopyLanguage);
            Theme.SetDarkThemeToolStripMenuItem(MSOptionsToggleDarkTheme);

            Theme.SetDarkThemeComboBox(DatLanguageComboBox);

            CmnTreeView.BackColor = Theme.WindowColor;
            CmnTreeView.ForeColor = Theme.WindowTextColor;

            Theme.SetDarkThemeDataGridView(DatsDataGridView);
        }

        #region Loading

        private void LoadDatLanguageComboBox()
        {
            DatLanguageComboBox.BeginUpdate();

            DatLanguageComboBox.Items.Clear();
            
            _modifiedLocalization.Item2.ForEach(dat => DatLanguageComboBox.Items.Add(dat.Letter));

            DatLanguageComboBox.EndUpdate();
        }

        private void LoadCmnTreeView()
        {
            CmnTreeView.BeginUpdate();

            CmnTreeView.Nodes.Clear();

            foreach (var node in _modifiedLocalization.Item1.Root)
            {
                CmnTreeView.Nodes.Add(GetTreeNodeFromCmn(node));
            }

            CmnTreeView.EndUpdate();
        }

        private void LoadDatsDataGridView()
        {
            DatsDataGridView.Columns.Clear();
            DatsDataGridView.Columns.Add("designNumber", "Number");
            DatsDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DatsDataGridView.Columns[0].ReadOnly = true;
            DatsDataGridView.Columns.Add("designID", "ID");
            DatsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DatsDataGridView.Columns[1].ReadOnly = true;
            DatsDataGridView.Columns.Add("designText", "Text");
            DatsDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DatsDataGridView.Columns[2].ReadOnly = true;

            DatsDataGridView.Sort(DatsDataGridView.Columns[0], ListSortDirection.Ascending);

            if (DatLanguageComboBox.SelectedItem != null)
            {
                DatsDataGridView.Rows.Clear();
                DAT dat = _modifiedLocalization.Item2[_selectedDatIndex];
                if (CmnTreeView.SelectedNode is TreeNode treeNode)
                {
                    AddCmnNodeToDataGridView(dat, (CmnString)treeNode.Tag);
                }
                else if (CmnTreeView.SelectedNode == null)
                {
                    foreach (var node in _modifiedLocalization.Item1.Root)
                    {
                        AddCmnNodeToDataGridView(dat, node.Value);
                    }
                }
            }

            DatsDataGridView.ClearSelection();
        }

        #endregion

        #region Manage Controls
        public (CMN, List<DAT>) LoadLocalization(string[] files)
        {
            CMN modifiedCmn = null;
            List<DAT> modifiedDats = new List<DAT>();

            foreach (string filePath in files)
            {
                if (Path.GetFileNameWithoutExtension(filePath).Equals("Cmn", StringComparison.OrdinalIgnoreCase))
                {
                    modifiedCmn = new CMN(filePath);
                }
                else if (Constants.DatLetters.Contains(Path.GetFileNameWithoutExtension(filePath)[0]))
                {
                    modifiedDats.Add(new DAT(filePath, Path.GetFileNameWithoutExtension(filePath)[0]));
                }
            }

            if (modifiedCmn == null && modifiedDats.Count != 13)
            {
                throw new Exception("Missing Dats");
            }

            return (modifiedCmn, modifiedDats);
        }
        
        public static TreeNode GetTreeNodeFromCmn(KeyValuePair<string, CmnString> child)
        {
            var result = new TreeNode();
            result.Name = child.Key;
            result.Text = child.Value.FullName;
            result.Tag = child.Value;

            foreach (var subChild in child.Value.childrens)
            {
                result.Nodes.Add(GetTreeNodeFromCmn(subChild));
            }

            return result;
        }

        private void AddCmnNodeToDataGridView(DAT dat, CmnString child)
        {
            if (child.StringNumber != -1)
            {
                string text = dat.Strings[child.StringNumber];
                DatsDataGridView.Rows.Add(child.StringNumber, child.FullName, text);
            }

            foreach (var children in child.childrens)
            {
                AddCmnNodeToDataGridView(dat, children.Value);
            }
        }

        #endregion

        #region Menu Strip Controls

        private void MSOptionBatchCopyLanguage_Click(object sender, EventArgs e)
        {
            using (var batchCopyLanguage = new BatchCopyLanguage(_modifiedLocalization.Item2))
            {
                batchCopyLanguage.ShowDialog();
                if (batchCopyLanguage.DialogResult == DialogResult.OK && batchCopyLanguage.SelectedCopyLanguage != -1)
                {
                    foreach(var pasteLanguageLetter in  batchCopyLanguage.SelectedPasteLanguages)
                    {
                        for (int i = 0; i < _modifiedLocalization.Item2[batchCopyLanguage.SelectedCopyLanguage].Strings.Count; i++)
                        {
                            if (_modifiedLocalization.Item2[pasteLanguageLetter - 65].Strings[i] == "\0" || batchCopyLanguage.OverwriteExistingString == true)
                            {
                                _modifiedLocalization.Item2[pasteLanguageLetter - 65].Strings[i] = _modifiedLocalization.Item2[batchCopyLanguage.SelectedCopyLanguage].Strings[i];
                            }
                        }
                    }
                }
                batchCopyLanguage.Dispose();
            }
            LoadDatsDataGridView();
        }
        private void MSOptionsToggleDarkTheme_Click(object sender, EventArgs e)
        {
            Configurations.Default.DarkTheme = !Configurations.Default.DarkTheme;
            Configurations.Default.Save();
            ToggleDarkTheme();
        }

        private void MSMainOpenFolder_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowser = new FolderBrowserDialog()
            {
                Description = "Select DATs directory",
                RootFolder = Environment.SpecialFolder.MyComputer,
            };

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowser.SelectedPath);

                _modifiedLocalization = LoadLocalization(files);

                // Check if each dat string count has the same number as the CMN max string number
                foreach (var dat in _modifiedLocalization.Item2)
                {
                    // Add null string for missing strings so the dat can be loaded
                    if (dat.Strings.Count < _modifiedLocalization.Item1.MaxStringNumber)
                    {
                        dat.Strings.AddRange(Enumerable.Repeat("\0", _modifiedLocalization.Item1.MaxStringNumber + 1 - dat.Strings.Count));
                    }
                }

                _directory = folderBrowser.SelectedPath;

                LoadDatLanguageComboBox();
                LoadCmnTreeView();

                MSOptionBatchCopyLanguage.Enabled = true;
            }
        }

        private void MSMainSave_Click(object sender, EventArgs e)
        {
            if (_modifiedLocalization.Item1 != null)
            {
                string cmnFilePath = _directory + "\\Cmn.dat";
                if (File.Exists(cmnFilePath))
                    File.Copy(cmnFilePath, cmnFilePath + ".bak", true);

                _modifiedLocalization.Item1.Write(cmnFilePath);
            }

            foreach (var dat in _modifiedLocalization.Item2)
            {
                string datFilePath = _directory + "\\" + dat.Letter + ".dat";

                if (File.Exists(datFilePath))
                    File.Copy(datFilePath, datFilePath + ".bak", true);

                dat.Write(datFilePath, dat.Letter);
            }
        }

        #endregion

        #region Tree View Controls

        private void CmnTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CmnTreeView.SelectedNode = e.Node;

                if (CmnTreeView.SelectedNode is TreeNode cmnTreeNode)
                {
                    ContextMenuStrip contextMenu = new ContextMenuStrip();

                    ToolStripMenuItem newMenuItem = Utils.CreateToolStripMenuItem("New", "New", new EventHandler(NewMenuItem_Click), _modifiedLocalization.Item2 == null ? false : true);
                    contextMenu.Items.Add(newMenuItem);

                    contextMenu.Show(CmnTreeView, CmnTreeView.PointToClient(Cursor.Position));
                }
            }
        }

        private void CmnTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadDatsDataGridView();
        }

        #endregion

        #region Data Grid View Controls

        private void DatsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Limit user to multiselect in columns and in only one
            switch (DatsDataGridView.SelectedCells.Count)
            {
                case 0:
                    _selectedRowIndex = -1;
                    _selectedColumnIndex = -1;
                    return;
                case 1:
                    _selectedRowIndex = DatsDataGridView.SelectedCells[0].RowIndex;
                    _selectedColumnIndex = DatsDataGridView.SelectedCells[0].ColumnIndex;
                    // Disable the number column for selection
                    if (_selectedColumnIndex == 0)
                    {
                        foreach (DataGridViewCell cell in DatsDataGridView.SelectedCells)
                        {
                            cell.Selected = false;
                        }
                    }
                    return;
            }

            foreach (DataGridViewCell cell in DatsDataGridView.SelectedCells)
            {
                if (cell.ColumnIndex == _selectedColumnIndex)
                {
                    if (cell.RowIndex != _selectedRowIndex)
                    {
                        _selectedRowIndex = -1;
                    }
                }
                else
                {
                    cell.Selected = false;
                }
            }
        }

        private void DatsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex == 1)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                ToolStripMenuItem copyMenuItem = Utils.CreateToolStripMenuItem("Copy", "Copy", new EventHandler(CopyMenuItem_Click), DatsDataGridView.SelectedCells.Count == 0 ? false : true);
                contextMenu.Items.Add(copyMenuItem);

                ToolStripMenuItem pasteMenuItem = Utils.CreateToolStripMenuItem("Paste", "Paste", new EventHandler(PasteMenuItem_Click), _copyStrings.Item3 == null ? false : true);
                contextMenu.Items.Add(pasteMenuItem);

                if (e.ColumnIndex == 1)
                {
                    ToolStripMenuItem copyPasteToLanguagesMenuItem = Utils.CreateToolStripMenuItem("Copy Paste to languages", "CopyPasteToLanguages", new EventHandler(CopyPasteToLanguagesMenuItem_Click), DatsDataGridView.SelectedCells.Count == 0 ? false : true);
                    contextMenu.Items.Add(copyPasteToLanguagesMenuItem);
                }

                contextMenu.Show(DatsDataGridView, DatsDataGridView.PointToClient(Cursor.Position));
            }
        }

        private void DatsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string datText = DatsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int stringNumber = Convert.ToInt32(DatsDataGridView.Rows[e.RowIndex].Cells[0].Value);

                using (var datStringEditor = new DatStringEditor(datText) { StartPosition = FormStartPosition.CenterScreen })
                {
                    datStringEditor.ShowDialog();
                    if (datStringEditor.DialogResult == DialogResult.OK)
                    {
                        _modifiedLocalization.Item2[_selectedDatIndex].Strings[stringNumber] = datStringEditor.DatText;
                        LoadDatsDataGridView();
                    }
                    datStringEditor.Dispose();
                }
            }
        }

        #endregion

        #region Combo Box Controls
        private void DatLanguageComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDatsDataGridView();
        }

        #endregion

        #region Menu Items

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = CmnTreeView.SelectedNode;
            int treeNodeIndex = treeNode.Index;

            TreeNode treeNodeParent = treeNode.Parent;

            using (var input = new Input("Enter a name for the new node", treeNode.Text) { StartPosition = FormStartPosition.CenterScreen })
            {
                input.ShowDialog();

                if (input.DialogResult == DialogResult.OK)
                {
                    KeyValuePair<string, CmnString> selectedCmnNode = new KeyValuePair<string, CmnString>(treeNode.Name, (CmnString)treeNode.Tag);
                    if (_modifiedLocalization.Item1.AddVariable(input.InputText, selectedCmnNode))
                    {
                        // Add the new string variable to each dat
                        foreach (var dat in _modifiedLocalization.Item2)
                        {
                            dat.Strings.Add("\0");
                        }

                        // Remove the treeNode because we need to update it
                        treeNode.Remove();

                        // Re-insert the node after updating it
                        TreeNode reInsertTreeNode = GetTreeNodeFromCmn(selectedCmnNode); // Create the new treeNode and its childrens

                        // Re-insert the tree node in the right place
                        if (treeNodeParent == null)
                        {
                            CmnTreeView.Nodes.Insert(treeNodeIndex, reInsertTreeNode);
                        }
                        else
                        {
                            treeNodeParent.Nodes.Insert(treeNodeIndex, reInsertTreeNode); 
                        }

                        CmnTreeView.SelectedNode = reInsertTreeNode;
                        CmnTreeView.SelectedNode.Expand();
                    }
                    else
                    {
                        // Show Message Box
                    }
                }

                input.Dispose();
            }
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex = -1;
            List<string> copyStrings = new List<string>();

            foreach (DataGridViewCell selectedCell in DatsDataGridView.SelectedCells)
            {
                columnIndex = selectedCell.ColumnIndex;
                copyStrings.Add(selectedCell.Value.ToString());
            }

            _copyStrings = (columnIndex, _selectedDatIndex ,copyStrings);
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            if (_copyStrings.Item1 == 1)
            {
                foreach (var copyString in _copyStrings.Item3)
                {
                    int variableStringNumber = _modifiedLocalization.Item1.GetVariableStringNumber(copyString);
                    _modifiedLocalization.Item2[_selectedDatIndex].Strings[variableStringNumber] = _modifiedLocalization.Item2[_copyStrings.Item2].Strings[variableStringNumber];  
                }
            }
            LoadDatsDataGridView();
        }

        private void CopyPasteToLanguagesMenuItem_Click(object sender, EventArgs e)
        {
            using (var copyPasteLanguagesSelector = new CopyPasteLanguagesSelector(_modifiedLocalization.Item2, (char)DatLanguageComboBox.SelectedItem) { StartPosition = FormStartPosition.CenterScreen })
            {
                copyPasteLanguagesSelector.ShowDialog();

                // For each string variable selected
                foreach (DataGridViewCell stringVariable in DatsDataGridView.SelectedCells)
                {
                    int variableStringNumber = _modifiedLocalization.Item1.GetVariableStringNumber(stringVariable.Value.ToString());
                    if (variableStringNumber != -1)
                    {
                        // Paste to dats selected
                        foreach (char datLetter in copyPasteLanguagesSelector.SelectedLanguages)
                        {
                            _modifiedLocalization.Item2[datLetter - 65].Strings[variableStringNumber] = _modifiedLocalization.Item2[_selectedDatIndex].Strings[variableStringNumber];
                        }
                    }
                }

                copyPasteLanguagesSelector.Dispose();
            }
        }

        #endregion


    }
}
