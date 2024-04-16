using Ace7Ed.Properties;
using Ace7Ed.Prompt;
using Ace7LocalizationFormat.Formats;
using System.ComponentModel;
using System.Windows.Forms;
using static Ace7LocalizationFormat.Formats.CMN;
using Ace7Ed.Interact;
using System.Diagnostics;
using System.ComponentModel.Design.Serialization;

namespace Ace7Ed
{
    public partial class LocalizationEditor : Form
    {
        private (CMN, List<DAT>) _modifiedLocalization = new(null, null);

        private string _directory { get; set; }

        private (int, List<int>) _copyVariableStrings { get; set; }
        private List<string> _copyStrings = new List<string>();

        private int _selectedRowIndex = -1;
        private int _selectedColumnIndex = -1;

        private int _selectedDatIndex
        {
            get
            {
                if (DatLanguageComboBox.SelectedItem != null)
                {
                    DAT dat = (DAT)DatLanguageComboBox.SelectedItem;
                    return dat.Letter - 65;
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

            if (Clipboard.GetText() != null)
            {
                _copyStrings.Add(Clipboard.GetText());
            }

            MSOptionImportLocalization.Enabled = false;
            MSOptionImportLocalization.Visible = false;
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
            Theme.SetDarkThemeToolStripMenuItem(MSOptionImportLocalization);
            Theme.SetDarkThemeToolStripMenuItem(MSOptionBatchCopyLanguage);
            Theme.SetDarkThemeToolStripMenuItem(MSOptionsToggleDarkTheme);

            Theme.SetDarkThemeComboBox(DatLanguageComboBox);

            Theme.SetDarkThemeTreeView(CmnTreeView);

            Theme.SetDarkThemeDataGridView(DatsDataGridView);
        }

        private void CopyVariables()
        {
            List<int> copyVariableNumbers = new List<int>();

            // Copy variables from selected cells
            foreach (DataGridViewCell selectedCell in DatsDataGridView.SelectedCells)
            {
                int variableStringNumber = (int)DatsDataGridView.Rows[selectedCell.RowIndex].Cells[0].Value; // Get the variable string number from the first column
                copyVariableNumbers.Add(variableStringNumber); // Add the variable string number to the list of variables to copy
            }
            _copyVariableStrings = (_selectedDatIndex, copyVariableNumbers);
        }

        private void PasteVariables()
        {
            foreach (int copyVariableNumber in _copyVariableStrings.Item2)
            {
                _modifiedLocalization.Item2[_selectedDatIndex].Strings[copyVariableNumber] = _modifiedLocalization.Item2[_copyVariableStrings.Item1].Strings[copyVariableNumber];
            }
            LoadDatsDataGridView();
        }

        private void CopyStrings()
        {
            List<string> copyStrings = new List<string>();

            foreach (DataGridViewCell selectedCell in DatsDataGridView.SelectedCells)
            {
                string datString = selectedCell.Value.ToString();
                copyStrings.Add(datString);
            }

            _copyStrings = copyStrings;

            Clipboard.SetText(_copyStrings[0]);
        }

        private void PasteStrings()
        {
            int index = 0;
            foreach (DataGridViewCell selectedCell in DatsDataGridView.SelectedCells)
            {
                int variableStringNumber = (int)DatsDataGridView.Rows[selectedCell.RowIndex].Cells[0].Value;
                // If there is only one copied string, paste it to all selected cells
                if (_copyStrings.Count == 1)
                {
                    DatsDataGridView.Rows[selectedCell.RowIndex].Cells[2].Value = _copyStrings[0];
                    _modifiedLocalization.Item2[_selectedDatIndex].Strings[variableStringNumber] = _copyStrings[0];
                }
                // Copy strings to selected cells
                else if (index < _copyStrings.Count)
                {
                    DatsDataGridView.Rows[selectedCell.RowIndex].Cells[2].Value = _copyStrings[index];
                    _modifiedLocalization.Item2[_selectedDatIndex].Strings[variableStringNumber] = _copyStrings[index];
                }
                index++;
            }
        }

        #region Loading

        public (CMN, List<DAT>) LoadLocalization(string[] files)
        {
            CMN modifiedCmn = null;
            List<DAT> modifiedDats = new List<DAT>();

            foreach (string filePath in files)
            {
                if (Path.GetExtension(filePath) == ".dat")
                {
                    if (Path.GetFileNameWithoutExtension(filePath).Equals("Cmn", StringComparison.OrdinalIgnoreCase))
                    {
                        modifiedCmn = new CMN(filePath);
                    }
                    else if (AceLocalizationConstants.DatLetters.Keys.Contains(Path.GetFileNameWithoutExtension(filePath)[0]))
                    {
                        modifiedDats.Add(new DAT(filePath, Path.GetFileNameWithoutExtension(filePath)[0]));
                    }
                }
            }

            if (modifiedCmn == null || modifiedDats.Count != 13)
            {
                MessageBox.Show("Missing Dats", "Error");
                throw new Exception("Missing Dats");
            }

            return (modifiedCmn, modifiedDats);
        }

        private void LoadLocalizationForUI(string folder)
        {
            // Check if each dat string count has the same number as the CMN max string number
            foreach (var dat in _modifiedLocalization.Item2)
            {
                // Add null string for missing strings so the dat can be loaded
                if (dat.Strings.Count < _modifiedLocalization.Item1.MaxStringNumber)
                {
                    dat.Strings.AddRange(Enumerable.Repeat("\0", _modifiedLocalization.Item1.MaxStringNumber + 1 - dat.Strings.Count));
                }
            }

            _directory = folder;

            LoadDatLanguageComboBox();
            LoadCmnTreeView();
        }

        private void LoadDatLanguageComboBox()
        {
            DatLanguageComboBox.BeginUpdate();

            DatLanguageComboBox.Items.Clear();

            // Add dats to the comboBox
            _modifiedLocalization.Item2.ForEach(dat => DatLanguageComboBox.Items.Add(dat));

            DatLanguageComboBox.EndUpdate();
        }

        private void LoadCmnTreeView()
        {
            CmnTreeView.BeginUpdate();

            CmnTreeView.Nodes.Clear();

            // Add nodes of the CMN
            foreach (var node in _modifiedLocalization.Item1.Root.Childrens)
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

            if (DatLanguageComboBox.SelectedItem != null)
            {
                DatsDataGridView.Rows.Clear();
                DAT dat = _modifiedLocalization.Item2[_selectedDatIndex];

                if (_modifiedLocalization.Item1 != null)
                {
                    // Load strings of the selected CMN
                    if (CmnTreeView.SelectedNode is TreeNode treeNode)
                    {
                        AddCmnNodeToDataGridView(dat, (CmnString)treeNode.Tag);
                    }
                    // Load all strings
                    else if (CmnTreeView.SelectedNode == null)
                    {
                        foreach (var node in _modifiedLocalization.Item1.Root.Childrens)
                        {
                            AddCmnNodeToDataGridView(dat, node);
                        }
                    }
                }
            }

            DatsDataGridView.Sort(DatsDataGridView.Columns[0], ListSortDirection.Ascending);

            DatsDataGridView.ClearSelection();
        }

        #endregion

        #region Saving
        private void SaveChanges()
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

        #region Manage Controls

        public TreeNode GetTreeNodeFromCmn(CmnString parent)
        {
            var root = new TreeNode();
            root.Name = parent.Name;
            root.Text = parent.FullName;
            root.Tag = parent;

            List<TreeNode> nodesToVisit = [root];

            int index = 0;
            while (index < nodesToVisit.Count)
            {
                TreeNode currentCmnNode = nodesToVisit[index];
                CmnString cmnString = (CmnString)currentCmnNode.Tag;
                foreach (var child in cmnString.Childrens)
                {
                    TreeNode subNode = new TreeNode();
                    subNode.Name = child.Name;
                    subNode.Text = child.FullName;
                    subNode.Tag = child;
                    currentCmnNode.Nodes.Add(subNode);
                    nodesToVisit.Add(subNode);
                }
                index++;
            }

            return root;
        }

        public void ImportLocalization((CMN, List<DAT>) localization)
        {
            List<CmnString> nodesToVisit = [localization.Item1.Root];

            int index = 0;
            while (index < nodesToVisit.Count)
            {
                CmnString cmnString = nodesToVisit[index];
                foreach (var child in cmnString.Childrens)
                {
                    bool isVariableAdded = _modifiedLocalization.Item1.AddVariable(child.FullName, _modifiedLocalization.Item1.Root, out int variableStringNumber, child.StringNumber == -1 ? true : false);

                    if (child.StringNumber != -1)
                    {
                        foreach (var dat in localization.Item2)
                        {
                            if (child.StringNumber < dat.Strings.Count)
                            {
                                if (isVariableAdded)
                                {
                                    _modifiedLocalization.Item2[dat.Letter - 65].Strings.Add(localization.Item2[dat.Letter - 65].Strings[child.StringNumber]);
                                }
                                else
                                {
                                    _modifiedLocalization.Item2[dat.Letter - 65].Strings[variableStringNumber] = localization.Item2[dat.Letter - 65].Strings[child.StringNumber];
                                }
                            }
                            else
                            {
                                _modifiedLocalization.Item2[dat.Letter - 65].Strings.Add("\0");
                            }
                        }
                    }
                    nodesToVisit.Add(child);
                }
                index++;
            }

            Debug.WriteLine(_modifiedLocalization.Item1.MaxStringNumber);
        }

        private void AddCmnNodeToDataGridView(DAT dat, CmnString parent)
        {
            if (parent.StringNumber != -1)
            {
                string text = dat.Strings[parent.StringNumber];
                DatsDataGridView.Rows.Add(parent.StringNumber, parent.FullName, text);
            }

            foreach (var children in parent.Childrens)
            {
                AddCmnNodeToDataGridView(dat, children);
            }
        }

        private void LoadLocalization_DragDrop(object sender, DragEventArgs e)
        {
            string[] folderPaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string folderPath in folderPaths)
            {
                string[] files = Directory.GetFiles(folderPath);

                _modifiedLocalization = LoadLocalization(files);

                LoadLocalizationForUI(folderPath);
            }

        }

        private void LoadLocalization_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (Directory.Exists(path))
                    e.Effect = DragDropEffects.All;
            }
        }

        #endregion

        #region Menu Strip Controls

        private void MSOptionImportLocalization_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowser = new FolderBrowserDialog()
            {
                Description = "Select DATs directory",
                RootFolder = Environment.SpecialFolder.MyComputer,
            };

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowser.SelectedPath);

                var localization = LoadLocalization(files);

                ImportLocalization(localization);

                LoadCmnTreeView();
                LoadDatsDataGridView();
            }
        }

        private void MSOptionBatchCopyLanguage_Click(object sender, EventArgs e)
        {
            using (var batchCopyLanguage = new BatchCopyLanguage(_modifiedLocalization))
            {
                batchCopyLanguage.ShowDialog();

                if (batchCopyLanguage.DialogResult == DialogResult.OK && batchCopyLanguage.SelectedCopyLanguageIndex != -1 && batchCopyLanguage.SelectedPasteLanguages.Count != 0)
                {
                    // Loop through each Dat that are going to be pasted
                    foreach (var pasteLanguageLetter in batchCopyLanguage.SelectedPasteLanguages)
                    {
                        for (int i = batchCopyLanguage.StartNumber; i < batchCopyLanguage.EndNumber; i++)
                        {
                            // If the string is empty OR if the option "Overwrite existing strings" is checked, then replace the string
                            if (_modifiedLocalization.Item2[pasteLanguageLetter - 65].Strings[i] == "\0" || batchCopyLanguage.OverwriteExistingString == true)
                            {
                                _modifiedLocalization.Item2[pasteLanguageLetter - 65].Strings[i] = _modifiedLocalization.Item2[batchCopyLanguage.SelectedCopyLanguageIndex].Strings[i];
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

                LoadLocalizationForUI(folderBrowser.SelectedPath);

                MSOptionImportLocalization.Enabled = true;
                MSOptionBatchCopyLanguage.Enabled = true;
            }
        }

        private void MSMainSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        #endregion

        #region Tree View Controls

        private void CmnTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
#if DEBUG
            CmnString cmnString = (CmnString)e.Node.Tag;
            Debug.WriteLine("\"" + cmnString.FullName + "\"" + " Index : " + cmnString.Index);
#endif
            if (e.Button == MouseButtons.Right)
            {
                CmnTreeView.SelectedNode = e.Node;

                if (CmnTreeView.SelectedNode is TreeNode cmnTreeNode)
                {
                    ContextMenuStrip contextMenu = new ContextMenuStrip();

                    ToolStripMenuItem newMenuItem = Utils.CreateToolStripMenuItem("New", "New", new EventHandler(NewVariableMenuItem_Click), _modifiedLocalization.Item2 == null ? false : true);
                    contextMenu.Items.Add(newMenuItem);

                    //ToolStripMenuItem renameMenuItem = Utils.CreateToolStripMenuItem("Rename", "Rename", new EventHandler(RenameMenuItem_Click), _modifiedLocalization.Item2 == null ? false : true);
                    //contextMenu.Items.Add(renameMenuItem);

                    //ToolStripMenuItem deleteMenuItem = Utils.CreateToolStripMenuItem("Delete", "Delete", new EventHandler(DeleteMenuItem_Click), _modifiedLocalization.Item2 == null ? false : true);
                    //contextMenu.Items.Add(deleteMenuItem);

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
            if (e.Button == MouseButtons.Right && DatsDataGridView.SelectedCells.Count > 0)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                if (e.ColumnIndex != 2)
                {
                    ToolStripMenuItem copyVariablesMenuItem = Utils.CreateToolStripMenuItem("Copy Variables", "CopyVariables", new EventHandler(CopyVariableStringMenuItem_Click), DatsDataGridView.SelectedCells.Count == 0 ? false : true);
                    contextMenu.Items.Add(copyVariablesMenuItem);

                    ToolStripMenuItem pasteVariablesMenuItem = Utils.CreateToolStripMenuItem("Paste Variables", "PasteVariables", new EventHandler(PasteVariableStringMenuItem_Click), _copyVariableStrings.Item2 == null ? false : true);
                    contextMenu.Items.Add(pasteVariablesMenuItem);

                    ToolStripMenuItem copyPasteToLanguagesMenuItem = Utils.CreateToolStripMenuItem("Copy Paste to languages", "CopyPasteToLanguages", new EventHandler(CopyPasteToLanguagesMenuItem_Click), DatsDataGridView.SelectedCells.Count == 0 ? false : true);
                    contextMenu.Items.Add(copyPasteToLanguagesMenuItem);
                }
                else
                {
                    ToolStripMenuItem copyStringsMenuItem = Utils.CreateToolStripMenuItem("Copy Strings", "CopyStrings", new EventHandler(CopyStringMenuItem_Click));
                    contextMenu.Items.Add(copyStringsMenuItem);

                    ToolStripMenuItem pasteStringsMenuItem = Utils.CreateToolStripMenuItem("Paste Strings", "PasteStrings", new EventHandler(PasteStringMenuItem_Click));
                    contextMenu.Items.Add(pasteStringsMenuItem);
                }


                ToolStripMenuItem selectAllMenuItem = Utils.CreateToolStripMenuItem("Select All", "SelectAll", new EventHandler(SelectAllMenuItem_Click));
                contextMenu.Items.Add(selectAllMenuItem);

                ToolStripMenuItem deSelectAllMenuItem = Utils.CreateToolStripMenuItem("Deselect All", "DeselectAll", new EventHandler(DeselectAllMenuItem_Click), DatsDataGridView.SelectedCells.Count == 0 ? false : true);
                contextMenu.Items.Add(deSelectAllMenuItem);

                contextMenu.Show(DatsDataGridView, DatsDataGridView.PointToClient(Cursor.Position));
            }
        }

        private void DatsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
            {
                string datText = DatsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); // Get the text of the selected cell
                int stringNumber = Convert.ToInt32(DatsDataGridView.Rows[e.RowIndex].Cells[0].Value); // Get the variable string number of the text

                using (var datStringEditor = new DatStringEditor(datText) { StartPosition = FormStartPosition.CenterScreen })
                {
                    datStringEditor.ShowDialog();
                    if (datStringEditor.DialogResult == DialogResult.OK)
                    {
                        DatsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = datStringEditor.DatText;
                        _modifiedLocalization.Item2[_selectedDatIndex].Strings[stringNumber] = datStringEditor.DatText;
                    }
                    datStringEditor.Dispose();
                }
            }
        }

        private void DatsDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTest = DatsDataGridView.HitTest(e.X, e.Y);

            if (hitTest.Type == DataGridViewHitTestType.None && DatsDataGridView.SelectedCells.Count > 0)
            {
                DatsDataGridView.ClearSelection();
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

        #region CmnTreeView Menu Items

        private void NewVariableMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = CmnTreeView.SelectedNode;
            int treeNodeIndex = treeNode.Index;

            TreeNode treeNodeParent = treeNode.Parent;

            using (var input = new Input("Enter a name for the new node", treeNode.Text) { StartPosition = FormStartPosition.CenterScreen })
            {
                input.ShowDialog();

                if (input.DialogResult == DialogResult.OK)
                {
                    CmnString selectedCmnNode = (CmnString)treeNode.Tag;
                    if (_modifiedLocalization.Item1.AddVariable(input.InputText, selectedCmnNode, out int variableStringNumber))
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

        private void RenameVariableMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = CmnTreeView.SelectedNode;
            int treeNodeIndex = treeNode.Index;

            TreeNode treeNodeParent = treeNode.Parent;

            using (var input = new Input("Enter a new name for the node", treeNodeParent.Text) { StartPosition = FormStartPosition.CenterScreen })
            {
                input.ShowDialog();

                if (input.DialogResult == DialogResult.OK)
                {
                    CmnString selectedCmnNode = (CmnString)treeNode.Tag;
                }

                input.Dispose();
            }
        }

        private void DeleteVariableMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = CmnTreeView.SelectedNode;

            TreeNode treeNodeParent = treeNode.Parent;

            CmnString selectedCmnNode = (CmnString)treeNode.Tag;

            List<int> variableStringNumbers = _modifiedLocalization.Item1.DeleteVariable(selectedCmnNode);

            foreach (var variableStringNumber in variableStringNumbers)
            {
                if (variableStringNumber != -1)
                {
                    foreach (var dat in _modifiedLocalization.Item2)
                    {
                        dat.Strings.RemoveAt(variableStringNumber);
                    }
                }
            }
        }

        #endregion

        #region DatsGridView Menu Items

        #region Variable Column (0 and 1)

        private void CopyVariableStringMenuItem_Click(object sender, EventArgs e)
        {
            CopyVariables();
        }

        private void PasteVariableStringMenuItem_Click(object sender, EventArgs e)
        {
            PasteVariables();
        }

        private void CopyPasteToLanguagesMenuItem_Click(object sender, EventArgs e)
        {
            using (var copyPasteLanguagesSelector = new CopyPasteLanguagesSelector(_modifiedLocalization.Item2, (DAT)DatLanguageComboBox.SelectedItem) { StartPosition = FormStartPosition.CenterScreen })
            {
                copyPasteLanguagesSelector.ShowDialog();

                foreach (DataGridViewCell selectedCell in DatsDataGridView.SelectedCells)
                {
                    int variableStringNumber = (int)DatsDataGridView.Rows[selectedCell.RowIndex].Cells[0].Value;
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

        #region String Column (2)

        private void CopyStringMenuItem_Click(object sender, EventArgs e)
        {
            CopyStrings();
        }

        private void PasteStringMenuItem_Click(object sender, EventArgs e)
        {
            PasteStrings();
        }

        #endregion

        private void SelectAllMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DatsDataGridView.Rows.Count; i++)
            {
                DatsDataGridView.Rows[i].Selected = true;
            }
        }

        private void DeselectAllMenuItem_Click(object sender, EventArgs e)
        {
            DatsDataGridView.ClearSelection();
        }

        #endregion

        #endregion

        private void DatsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (DatsDataGridView.SelectedCells.Count > 0 && DatsDataGridView.SelectedCells[0].ColumnIndex != 2)
                {
                    CopyVariables();
                }
                else if (DatsDataGridView.SelectedCells.Count > 0)
                {
                    CopyStrings();
                }
                
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (DatsDataGridView.SelectedCells.Count > 0 && DatsDataGridView.SelectedCells[0].ColumnIndex != 2)
                {
                    PasteVariables();
                }
                else if (DatsDataGridView.SelectedCells.Count > 0)
                {
                    PasteStrings();
                }
            }
        }
    }
}
