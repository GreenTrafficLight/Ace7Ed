namespace Ace7Ed.Interact
{
    partial class BatchCopyLanguage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PasteLanguageOverwriteStringsCheckBox = new CheckBox();
            OkButton = new Button();
            CopyLanguageComboBox = new ComboBox();
            PasteLanguageTextLabel = new Label();
            SelectAllButton = new Button();
            DeselectAllButton = new Button();
            PasteLanguagesDataGridView = new DataGridView();
            StartNumberLabel = new Label();
            StartNumnberNumericUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)PasteLanguagesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartNumnberNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // PasteLanguageOverwriteStringsCheckBox
            // 
            PasteLanguageOverwriteStringsCheckBox.AutoSize = true;
            PasteLanguageOverwriteStringsCheckBox.FlatStyle = FlatStyle.Flat;
            PasteLanguageOverwriteStringsCheckBox.Location = new Point(12, 56);
            PasteLanguageOverwriteStringsCheckBox.Name = "PasteLanguageOverwriteStringsCheckBox";
            PasteLanguageOverwriteStringsCheckBox.Size = new Size(156, 19);
            PasteLanguageOverwriteStringsCheckBox.TabIndex = 8;
            PasteLanguageOverwriteStringsCheckBox.Text = "Overwrite existing strings";
            PasteLanguageOverwriteStringsCheckBox.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            OkButton.FlatStyle = FlatStyle.Flat;
            OkButton.Location = new Point(286, 477);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(65, 23);
            OkButton.TabIndex = 7;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // CopyLanguageComboBox
            // 
            CopyLanguageComboBox.FlatStyle = FlatStyle.Flat;
            CopyLanguageComboBox.FormattingEnabled = true;
            CopyLanguageComboBox.Location = new Point(12, 27);
            CopyLanguageComboBox.Name = "CopyLanguageComboBox";
            CopyLanguageComboBox.Size = new Size(339, 23);
            CopyLanguageComboBox.TabIndex = 6;
            CopyLanguageComboBox.SelectedValueChanged += CopyLanguageComboBox_SelectedValueChanged;
            // 
            // PasteLanguageTextLabel
            // 
            PasteLanguageTextLabel.AutoSize = true;
            PasteLanguageTextLabel.Location = new Point(12, 9);
            PasteLanguageTextLabel.Name = "PasteLanguageTextLabel";
            PasteLanguageTextLabel.Size = new Size(206, 15);
            PasteLanguageTextLabel.TabIndex = 5;
            PasteLanguageTextLabel.Text = "Choose which language to copy from";
            // 
            // SelectAllButton
            // 
            SelectAllButton.Location = new Point(12, 110);
            SelectAllButton.Name = "SelectAllButton";
            SelectAllButton.Size = new Size(82, 23);
            SelectAllButton.TabIndex = 11;
            SelectAllButton.Text = "Select All";
            SelectAllButton.UseVisualStyleBackColor = true;
            SelectAllButton.Click += SelectAllButton_Click;
            // 
            // DeselectAllButton
            // 
            DeselectAllButton.Location = new Point(100, 110);
            DeselectAllButton.Name = "DeselectAllButton";
            DeselectAllButton.Size = new Size(82, 23);
            DeselectAllButton.TabIndex = 10;
            DeselectAllButton.Text = "Deselect All";
            DeselectAllButton.UseVisualStyleBackColor = true;
            DeselectAllButton.Click += DeselectAllButton_Click;
            // 
            // PasteLanguagesDataGridView
            // 
            PasteLanguagesDataGridView.AllowUserToAddRows = false;
            PasteLanguagesDataGridView.AllowUserToDeleteRows = false;
            PasteLanguagesDataGridView.AllowUserToResizeColumns = false;
            PasteLanguagesDataGridView.AllowUserToResizeRows = false;
            PasteLanguagesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PasteLanguagesDataGridView.ColumnHeadersVisible = false;
            PasteLanguagesDataGridView.Location = new Point(14, 139);
            PasteLanguagesDataGridView.Name = "PasteLanguagesDataGridView";
            PasteLanguagesDataGridView.RowHeadersVisible = false;
            PasteLanguagesDataGridView.Size = new Size(339, 332);
            PasteLanguagesDataGridView.TabIndex = 9;
            // 
            // StartNumberLabel
            // 
            StartNumberLabel.AutoSize = true;
            StartNumberLabel.Location = new Point(14, 83);
            StartNumberLabel.Name = "StartNumberLabel";
            StartNumberLabel.Size = new Size(78, 15);
            StartNumberLabel.TabIndex = 12;
            StartNumberLabel.Text = "Start Number";
            // 
            // StartNumnberNumericUpDown
            // 
            StartNumnberNumericUpDown.Location = new Point(98, 81);
            StartNumnberNumericUpDown.Name = "StartNumnberNumericUpDown";
            StartNumnberNumericUpDown.Size = new Size(120, 23);
            StartNumnberNumericUpDown.TabIndex = 14;
            // 
            // BatchCopyLanguage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 505);
            Controls.Add(StartNumnberNumericUpDown);
            Controls.Add(StartNumberLabel);
            Controls.Add(SelectAllButton);
            Controls.Add(DeselectAllButton);
            Controls.Add(PasteLanguagesDataGridView);
            Controls.Add(PasteLanguageOverwriteStringsCheckBox);
            Controls.Add(OkButton);
            Controls.Add(CopyLanguageComboBox);
            Controls.Add(PasteLanguageTextLabel);
            Name = "BatchCopyLanguage";
            Text = "Batch Copy Language";
            ((System.ComponentModel.ISupportInitialize)PasteLanguagesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartNumnberNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox PasteLanguageOverwriteStringsCheckBox;
        private Button OkButton;
        private ComboBox CopyLanguageComboBox;
        private Label PasteLanguageTextLabel;
        private Button SelectAllButton;
        private Button DeselectAllButton;
        private DataGridView PasteLanguagesDataGridView;
        private Label StartNumberLabel;
        private NumericUpDown StartNumnberNumericUpDown;
    }
}