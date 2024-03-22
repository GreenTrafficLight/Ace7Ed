namespace Ace7Ed.Prompt
{
    partial class CopyPasteLanguagesSelector
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
            OkButton = new Button();
            LanguagesDataGridView = new DataGridView();
            DeselectAllButton = new Button();
            SelectAllButton = new Button();
            ((System.ComponentModel.ISupportInitialize)LanguagesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // OkButton
            // 
            OkButton.Location = new Point(272, 379);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(79, 35);
            OkButton.TabIndex = 0;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // LanguagesDataGridView
            // 
            LanguagesDataGridView.AllowUserToAddRows = false;
            LanguagesDataGridView.AllowUserToDeleteRows = false;
            LanguagesDataGridView.AllowUserToResizeColumns = false;
            LanguagesDataGridView.AllowUserToResizeRows = false;
            LanguagesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LanguagesDataGridView.ColumnHeadersVisible = false;
            LanguagesDataGridView.Location = new Point(12, 41);
            LanguagesDataGridView.Name = "LanguagesDataGridView";
            LanguagesDataGridView.RowHeadersVisible = false;
            LanguagesDataGridView.Size = new Size(339, 332);
            LanguagesDataGridView.TabIndex = 1;
            // 
            // DeselectAllButton
            // 
            DeselectAllButton.Location = new Point(100, 12);
            DeselectAllButton.Name = "DeselectAllButton";
            DeselectAllButton.Size = new Size(82, 23);
            DeselectAllButton.TabIndex = 2;
            DeselectAllButton.Text = "Deselect All";
            DeselectAllButton.UseVisualStyleBackColor = true;
            DeselectAllButton.Click += DeselectAllButton_Click;
            // 
            // SelectAllButton
            // 
            SelectAllButton.Location = new Point(12, 12);
            SelectAllButton.Name = "SelectAllButton";
            SelectAllButton.Size = new Size(82, 23);
            SelectAllButton.TabIndex = 3;
            SelectAllButton.Text = "Select All";
            SelectAllButton.UseVisualStyleBackColor = true;
            SelectAllButton.Click += SelectAllButton_Click;
            // 
            // CopyPasteLanguagesSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 426);
            Controls.Add(SelectAllButton);
            Controls.Add(DeselectAllButton);
            Controls.Add(LanguagesDataGridView);
            Controls.Add(OkButton);
            Name = "CopyPasteLanguagesSelector";
            Text = "CopyPasteLanguagesSelector";
            ((System.ComponentModel.ISupportInitialize)LanguagesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button OkButton;
        private DataGridView LanguagesDataGridView;
        private Button DeselectAllButton;
        private Button SelectAllButton;
    }
}