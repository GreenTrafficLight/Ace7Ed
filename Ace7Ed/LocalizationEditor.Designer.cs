namespace Ace7Ed
{
    partial class LocalizationEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LocalizationEditorMenuStrip = new MenuStrip();
            MenuStripMain = new ToolStripMenuItem();
            MSMainOpenFolder = new ToolStripMenuItem();
            MSMainSave = new ToolStripMenuItem();
            MenuStripOptions = new ToolStripMenuItem();
            MSOptionBatchCopyLanguage = new ToolStripMenuItem();
            MSOptionsToggleDarkTheme = new ToolStripMenuItem();
            CmnTreeView = new TreeView();
            DatsDataGridView = new DataGridView();
            DatLanguageComboBox = new ComboBox();
            SelectedLanguageLabel = new Label();
            LocalizationEditorMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DatsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // LocalizationEditorMenuStrip
            // 
            LocalizationEditorMenuStrip.Items.AddRange(new ToolStripItem[] { MenuStripMain, MenuStripOptions });
            LocalizationEditorMenuStrip.Location = new Point(0, 0);
            LocalizationEditorMenuStrip.Name = "LocalizationEditorMenuStrip";
            LocalizationEditorMenuStrip.Size = new Size(800, 24);
            LocalizationEditorMenuStrip.TabIndex = 0;
            LocalizationEditorMenuStrip.Text = "menuStrip1";
            // 
            // MenuStripMain
            // 
            MenuStripMain.DropDownItems.AddRange(new ToolStripItem[] { MSMainOpenFolder, MSMainSave });
            MenuStripMain.Name = "MenuStripMain";
            MenuStripMain.Size = new Size(46, 20);
            MenuStripMain.Text = "Main";
            // 
            // MSMainOpenFolder
            // 
            MSMainOpenFolder.Name = "MSMainOpenFolder";
            MSMainOpenFolder.Size = new Size(139, 22);
            MSMainOpenFolder.Text = "Open Folder";
            MSMainOpenFolder.Click += MSMainOpenFolder_Click;
            // 
            // MSMainSave
            // 
            MSMainSave.Name = "MSMainSave";
            MSMainSave.ShortcutKeyDisplayString = "";
            MSMainSave.Size = new Size(139, 22);
            MSMainSave.Text = "Save";
            MSMainSave.Click += MSMainSave_Click;
            // 
            // MenuStripOptions
            // 
            MenuStripOptions.DropDownItems.AddRange(new ToolStripItem[] { MSOptionBatchCopyLanguage, MSOptionsToggleDarkTheme });
            MenuStripOptions.Name = "MenuStripOptions";
            MenuStripOptions.Size = new Size(61, 20);
            MenuStripOptions.Text = "Options";
            // 
            // MSOptionBatchCopyLanguage
            // 
            MSOptionBatchCopyLanguage.Enabled = false;
            MSOptionBatchCopyLanguage.Name = "MSOptionBatchCopyLanguage";
            MSOptionBatchCopyLanguage.Size = new Size(194, 22);
            MSOptionBatchCopyLanguage.Text = "Batch copy a language";
            MSOptionBatchCopyLanguage.Click += MSOptionBatchCopyLanguage_Click;
            // 
            // MSOptionsToggleDarkTheme
            // 
            MSOptionsToggleDarkTheme.Name = "MSOptionsToggleDarkTheme";
            MSOptionsToggleDarkTheme.Size = new Size(194, 22);
            MSOptionsToggleDarkTheme.Text = "Toggle Dark Theme";
            MSOptionsToggleDarkTheme.Click += MSOptionsToggleDarkTheme_Click;
            // 
            // CmnTreeView
            // 
            CmnTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            CmnTreeView.BackColor = SystemColors.Window;
            CmnTreeView.Location = new Point(12, 35);
            CmnTreeView.Name = "CmnTreeView";
            CmnTreeView.Size = new Size(253, 408);
            CmnTreeView.TabIndex = 2;
            CmnTreeView.AfterSelect += CmnTreeView_AfterSelect;
            CmnTreeView.NodeMouseClick += CmnTreeView_NodeMouseClick;
            // 
            // DatsDataGridView
            // 
            DatsDataGridView.AllowUserToAddRows = false;
            DatsDataGridView.AllowUserToDeleteRows = false;
            DatsDataGridView.AllowUserToResizeColumns = false;
            DatsDataGridView.AllowUserToResizeRows = false;
            DatsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DatsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            DatsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatsDataGridView.EnableHeadersVisualStyles = false;
            DatsDataGridView.Location = new Point(271, 56);
            DatsDataGridView.Name = "DatsDataGridView";
            DatsDataGridView.RowHeadersVisible = false;
            DatsDataGridView.Size = new Size(517, 387);
            DatsDataGridView.TabIndex = 3;
            DatsDataGridView.CellDoubleClick += DatsDataGridView_CellDoubleClick;
            DatsDataGridView.CellMouseClick += DatsDataGridView_CellMouseClick;
            DatsDataGridView.SelectionChanged += DatsDataGridView_SelectionChanged;
            // 
            // DatLanguageComboBox
            // 
            DatLanguageComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DatLanguageComboBox.FlatStyle = FlatStyle.Flat;
            DatLanguageComboBox.FormattingEnabled = true;
            DatLanguageComboBox.Location = new Point(667, 27);
            DatLanguageComboBox.Name = "DatLanguageComboBox";
            DatLanguageComboBox.Size = new Size(121, 23);
            DatLanguageComboBox.TabIndex = 5;
            DatLanguageComboBox.SelectedValueChanged += DatLanguageComboBox_SelectedValueChanged;
            // 
            // SelectedLanguageLabel
            // 
            SelectedLanguageLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SelectedLanguageLabel.AutoSize = true;
            SelectedLanguageLabel.Location = new Point(549, 30);
            SelectedLanguageLabel.Name = "SelectedLanguageLabel";
            SelectedLanguageLabel.Size = new Size(112, 15);
            SelectedLanguageLabel.TabIndex = 6;
            SelectedLanguageLabel.Text = "Selected Language :";
            // 
            // LocalizationEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SelectedLanguageLabel);
            Controls.Add(DatLanguageComboBox);
            Controls.Add(DatsDataGridView);
            Controls.Add(CmnTreeView);
            Controls.Add(LocalizationEditorMenuStrip);
            MainMenuStrip = LocalizationEditorMenuStrip;
            Name = "LocalizationEditor";
            Text = "Localization Editor";
            LocalizationEditorMenuStrip.ResumeLayout(false);
            LocalizationEditorMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DatsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip LocalizationEditorMenuStrip;
        private TreeView CmnTreeView;
        private ToolStripMenuItem LocalizationEditorMenuStripFile;
        private ToolStripMenuItem LEMSMainOpen;
        private DataGridView DatsDataGridView;
        private ToolStripMenuItem MenuStripMain;
        private ToolStripMenuItem MenuStripOptions;
        private ToolStripMenuItem MSOptionsToggleDarkTheme;
        private ComboBox DatLanguageComboBox;
        private Label SelectedLanguageLabel;
        private ToolStripMenuItem MSMainOpenFolder;
        private ToolStripMenuItem MSMainSave;
        private ToolStripMenuItem MSOptionBatchCopyLanguage;
    }
}
