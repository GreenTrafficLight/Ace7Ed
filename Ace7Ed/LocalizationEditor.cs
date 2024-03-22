using Ace7Ed.Properties;
using Ace7Ed.Prompt;
using Ace7LocalizationFormat.Formats;
using System.ComponentModel;
using System.Windows.Forms;
using static Ace7LocalizationFormat.Formats.CMN;

namespace Ace7Ed
{
    public partial class LocalizationEditor : Form
    {
        private (CMN, List<DAT>) _gameLocalization { get; set; }
        private (CMN, List<DAT>) _modifiedLocalization { get; set; }

        private int _selectedRowIndex = -1;
        private int _selectedColumnIndex = -1;
        public LocalizationEditor((CMN, List<DAT>) gameLocalization, (CMN, List<DAT>) modifiedLocalization)
        {
            InitializeComponent();
            ToggleDarkTheme();

            _gameLocalization = gameLocalization;
            _modifiedLocalization = modifiedLocalization;

            LoadDatLanguageComboBox();
            LoadCmnTreeView();
        }

        private void ToggleDarkTheme()
        {
            BackColor = Theme.ControlColor;
            ForeColor = Theme.ControlTextColor;

            DatLanguageComboBox.BackColor = Theme.WindowColor;
            DatLanguageComboBox.ForeColor = Theme.WindowTextColor;

            CmnTreeView.BackColor = Theme.WindowColor;
            CmnTreeView.ForeColor = Theme.WindowTextColor;

            Theme.SetDarkThemeDataGridView(DatsDataGridView);
        }

        private void LoadDatLanguageComboBox()
        {
            DatLanguageComboBox.BeginUpdate();

            DatLanguageComboBox.Items.Clear();
            foreach (DAT dat in _modifiedLocalization.Item2)
            {
                DatLanguageComboBox.Items.Add(dat.Letter);
            }

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
                char datLetter = (char)DatLanguageComboBox.SelectedItem;
                DAT dat = _modifiedLocalization.Item2[datLetter - 65];
                if (CmnTreeView.SelectedNode is TreeNode treeNode)
                {
                    AddCmnNodeToDataGridView(dat, (CMNString)treeNode.Tag);
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

        public static TreeNode GetTreeNodeFromCmn(KeyValuePair<string, CMNString> child)
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

        private void AddCmnNodeToDataGridView(DAT dat, CMNString child)
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

        private void LEMSToggleDarkTheme_Click(object sender, EventArgs e)
        {
            Configurations.Default.DarkTheme = !Configurations.Default.DarkTheme;
            Configurations.Default.Save();
            ToggleDarkTheme();
        }

        private void DatLanguageComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDatsDataGridView();
        }

        private void CmnTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadDatsDataGridView();
        }

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

        private void DatsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string datText = DatsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                using (var datStringEditor = new DatStringEditor(datText) { StartPosition = FormStartPosition.CenterScreen })
                {
                    datStringEditor.ShowDialog();
                    if (datStringEditor.DialogResult == DialogResult.OK)
                    {
                        DatsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = datStringEditor.DatText;
                    }
                    datStringEditor.Dispose();
                }
            }
        }

        private void CmnTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CmnTreeView.SelectedNode = e.Node;

                if (CmnTreeView.SelectedNode is TreeNode cmnTreeNode)
                {
                    ContextMenuStrip contextMenu = new ContextMenuStrip();

                    ToolStripMenuItem newMenuItem = new ToolStripMenuItem("New");
                    newMenuItem.Click += new EventHandler(NewMenuItem_Click);
                    newMenuItem.Name = "New";
                    contextMenu.Items.Add(newMenuItem);

                    contextMenu.Show(CmnTreeView, CmnTreeView.PointToClient(Cursor.Position));
                }
            }
        }

        private void DatsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && DatsDataGridView.SelectedCells.Count > 0)
            {
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Copy");
                copyMenuItem.Name = "Copy";
                contextMenu.Items.Add(copyMenuItem);

                ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Paste");
                pasteMenuItem.Name = "Paste";
                pasteMenuItem.Enabled = false;
                contextMenu.Items.Add(pasteMenuItem);

                if (DatsDataGridView.SelectedCells[0].ColumnIndex == 1)
                {
                    ToolStripMenuItem copyPasteToLanguagesMenuItem = new ToolStripMenuItem("Copy Paste to languages");
                    copyPasteToLanguagesMenuItem.Click += new EventHandler(CopyPasteToLanguagesMenuItem_Click);
                    copyPasteToLanguagesMenuItem.Name = "CopyPasteToLanguages";
                    contextMenu.Items.Add(copyPasteToLanguagesMenuItem);
                }

                contextMenu.Show(DatsDataGridView, DatsDataGridView.PointToClient(Cursor.Position));
            }
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = CmnTreeView.SelectedNode;

            using (var input = new Input("Enter a name for the new node", treeNode.Text))
            {
                input.ShowDialog();

                input.Dispose();
            }
        }

        private void CopyPasteToLanguagesMenuItem_Click(object sender, EventArgs e)
        {
            using (var copyPasteLanguagesSelector = new CopyPasteLanguagesSelector(_modifiedLocalization.Item2, (char)DatLanguageComboBox.SelectedItem))
            {
                copyPasteLanguagesSelector.ShowDialog();

                copyPasteLanguagesSelector.Dispose();
            }
        }

        private void MSMainOpenFolder_Click(object sender, EventArgs e)
        {

        }
    }
}
