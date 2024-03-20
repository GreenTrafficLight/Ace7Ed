using Ace7Ed.Properties;
using Ace7LocalizationFormat.Formats;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using static Ace7LocalizationFormat.Formats.CMN;

namespace Ace7Ed
{
    public partial class LocalizationEditor : Form
    {
        private CMN _Cmn { get; set; }
        private List<DAT> _Dats { get; set; }
        public LocalizationEditor(CMN cmn, List<DAT> dats)
        {
            InitializeComponent();
            ToggleDarkTheme();

            _Cmn = cmn;
            _Dats = dats;

            LoadLocalizationEditorDatLanguageComboBox();
            LoadEditorLocalizationTreeView();

            LocalizationEditorDataGridView.Columns.Clear();
            LocalizationEditorDataGridView.Columns.Add("designNumber", "Number");
            LocalizationEditorDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            LocalizationEditorDataGridView.Columns[0].ReadOnly = true;
            LocalizationEditorDataGridView.Columns.Add("designID", "ID");
            LocalizationEditorDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            LocalizationEditorDataGridView.Columns[1].ReadOnly = true;
            LocalizationEditorDataGridView.Columns.Add("designText", "Text");
            LocalizationEditorDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LocalizationEditorDataGridView.Columns[2].ReadOnly = true;

            LocalizationEditorDataGridView.Sort(LocalizationEditorDataGridView.Columns[0], ListSortDirection.Ascending);
        }

        private void ToggleDarkTheme()
        {
            BackColor = Theme.MainBackColor;
            ForeColor = Theme.MainForeColor;
        }

        private void LoadLocalizationEditorDatLanguageComboBox()
        {
            LocalizationEditorDatLanguageComboBox.BeginUpdate();

            LocalizationEditorDatLanguageComboBox.Items.Clear();
            foreach (DAT dat in _Dats)
            {
                LocalizationEditorDatLanguageComboBox.Items.Add(dat.Letter);
            }

            LocalizationEditorDatLanguageComboBox.EndUpdate();
        }

        private void LoadEditorLocalizationTreeView()
        {
            LocalizationEditorCmnTreeView.BeginUpdate();

            LocalizationEditorCmnTreeView.Nodes.Clear();

            foreach (var node in _Cmn.Root)
            {
                LocalizationEditorCmnTreeView.Nodes.Add(GetTreeNodeFromCmn(node));
            }

            LocalizationEditorCmnTreeView.EndUpdate();
        }

        private void LoadLocalizationEditorDataGridView()
        {
            if (LocalizationEditorDatLanguageComboBox.SelectedItem != null)
            {
                LocalizationEditorDataGridView.Rows.Clear();
                char datLetter = (char)LocalizationEditorDatLanguageComboBox.SelectedItem;
                DAT dat = _Dats[datLetter - 65];
                if (LocalizationEditorCmnTreeView.SelectedNode is TreeNode treeNode)
                {
                    AddCmnNodeToDataGridView(dat, (CMNString)treeNode.Tag);
                }
                else if (LocalizationEditorCmnTreeView.SelectedNode == null)
                {
                    foreach (var node in _Cmn.Root)
                    {
                        AddCmnNodeToDataGridView(dat, node.Value);
                    }
                }


            }
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

        public void AddCmnNodeToDataGridView(DAT dat, CMNString child)
        {
            if (child.StringNumber != -1)
            {
                string text = dat.Strings[child.StringNumber];
                LocalizationEditorDataGridView.Rows.Add(child.StringNumber, child.FullName, text);
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

        private void LocalizationEditorDatLanguageComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadLocalizationEditorDataGridView();
        }

        private void LocalizationEditorCmnTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadLocalizationEditorDataGridView();
        }
    }
}
