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
            LocalizationEditorMenuStripTools = new ToolStripMenuItem();
            LocalizationEditorMenuStripOptions = new ToolStripMenuItem();
            LEMSToggleDarkTheme = new ToolStripMenuItem();
            LocalizationEditorCmnTreeView = new TreeView();
            LocalizationEditorDataGridView = new DataGridView();
            LocalizationEditorCmnChosenComboBox = new ComboBox();
            LocalizationEditorDatLanguageComboBox = new ComboBox();
            LocalizationEditorSelectedLanguageLabel = new Label();
            LocalizationEditorMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LocalizationEditorDataGridView).BeginInit();
            SuspendLayout();
            // 
            // LocalizationEditorMenuStrip
            // 
            LocalizationEditorMenuStrip.Items.AddRange(new ToolStripItem[] { LocalizationEditorMenuStripTools, LocalizationEditorMenuStripOptions });
            LocalizationEditorMenuStrip.Location = new Point(0, 0);
            LocalizationEditorMenuStrip.Name = "LocalizationEditorMenuStrip";
            LocalizationEditorMenuStrip.Size = new Size(800, 24);
            LocalizationEditorMenuStrip.TabIndex = 0;
            LocalizationEditorMenuStrip.Text = "menuStrip1";
            // 
            // LocalizationEditorMenuStripTools
            // 
            LocalizationEditorMenuStripTools.Name = "LocalizationEditorMenuStripTools";
            LocalizationEditorMenuStripTools.Size = new Size(46, 20);
            LocalizationEditorMenuStripTools.Text = "Tools";
            // 
            // LocalizationEditorMenuStripOptions
            // 
            LocalizationEditorMenuStripOptions.DropDownItems.AddRange(new ToolStripItem[] { LEMSToggleDarkTheme });
            LocalizationEditorMenuStripOptions.Name = "LocalizationEditorMenuStripOptions";
            LocalizationEditorMenuStripOptions.Size = new Size(61, 20);
            LocalizationEditorMenuStripOptions.Text = "Options";
            // 
            // LEMSToggleDarkTheme
            // 
            LEMSToggleDarkTheme.Name = "LEMSToggleDarkTheme";
            LEMSToggleDarkTheme.Size = new Size(175, 22);
            LEMSToggleDarkTheme.Text = "Toggle Dark Theme";
            LEMSToggleDarkTheme.Click += LEMSToggleDarkTheme_Click;
            // 
            // LocalizationEditorCmnTreeView
            // 
            LocalizationEditorCmnTreeView.Location = new Point(12, 56);
            LocalizationEditorCmnTreeView.Name = "LocalizationEditorCmnTreeView";
            LocalizationEditorCmnTreeView.Size = new Size(193, 382);
            LocalizationEditorCmnTreeView.TabIndex = 2;
            LocalizationEditorCmnTreeView.AfterSelect += LocalizationEditorCmnTreeView_AfterSelect;
            // 
            // LocalizationEditorDataGridView
            // 
            LocalizationEditorDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LocalizationEditorDataGridView.Location = new Point(211, 56);
            LocalizationEditorDataGridView.Name = "LocalizationEditorDataGridView";
            LocalizationEditorDataGridView.Size = new Size(577, 382);
            LocalizationEditorDataGridView.TabIndex = 3;
            // 
            // LocalizationEditorCmnChosenComboBox
            // 
            LocalizationEditorCmnChosenComboBox.FormattingEnabled = true;
            LocalizationEditorCmnChosenComboBox.Location = new Point(12, 27);
            LocalizationEditorCmnChosenComboBox.Name = "LocalizationEditorCmnChosenComboBox";
            LocalizationEditorCmnChosenComboBox.Size = new Size(193, 23);
            LocalizationEditorCmnChosenComboBox.TabIndex = 4;
            // 
            // LocalizationEditorDatLanguageComboBox
            // 
            LocalizationEditorDatLanguageComboBox.FormattingEnabled = true;
            LocalizationEditorDatLanguageComboBox.Location = new Point(667, 27);
            LocalizationEditorDatLanguageComboBox.Name = "LocalizationEditorDatLanguageComboBox";
            LocalizationEditorDatLanguageComboBox.Size = new Size(121, 23);
            LocalizationEditorDatLanguageComboBox.TabIndex = 5;
            LocalizationEditorDatLanguageComboBox.SelectedValueChanged += LocalizationEditorDatLanguageComboBox_SelectedValueChanged;
            // 
            // LocalizationEditorSelectedLanguageLabel
            // 
            LocalizationEditorSelectedLanguageLabel.AutoSize = true;
            LocalizationEditorSelectedLanguageLabel.Location = new Point(549, 30);
            LocalizationEditorSelectedLanguageLabel.Name = "LocalizationEditorSelectedLanguageLabel";
            LocalizationEditorSelectedLanguageLabel.Size = new Size(112, 15);
            LocalizationEditorSelectedLanguageLabel.TabIndex = 6;
            LocalizationEditorSelectedLanguageLabel.Text = "Selected Language :";
            // 
            // LocalizationEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LocalizationEditorSelectedLanguageLabel);
            Controls.Add(LocalizationEditorDatLanguageComboBox);
            Controls.Add(LocalizationEditorCmnChosenComboBox);
            Controls.Add(LocalizationEditorDataGridView);
            Controls.Add(LocalizationEditorCmnTreeView);
            Controls.Add(LocalizationEditorMenuStrip);
            MainMenuStrip = LocalizationEditorMenuStrip;
            Name = "LocalizationEditor";
            Text = "Form1";
            LocalizationEditorMenuStrip.ResumeLayout(false);
            LocalizationEditorMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LocalizationEditorDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip LocalizationEditorMenuStrip;
        private TreeView LocalizationEditorCmnTreeView;
        private ToolStripMenuItem LocalizationEditorMenuStripFile;
        private ToolStripMenuItem LEMSMainOpen;
        private DataGridView LocalizationEditorDataGridView;
        private ComboBox LocalizationEditorCmnChosenComboBox;
        private ToolStripMenuItem LocalizationEditorMenuStripTools;
        private ToolStripMenuItem LocalizationEditorMenuStripOptions;
        private ToolStripMenuItem LEMSToggleDarkTheme;
        private ComboBox LocalizationEditorDatLanguageComboBox;
        private Label LocalizationEditorSelectedLanguageLabel;
    }
}
