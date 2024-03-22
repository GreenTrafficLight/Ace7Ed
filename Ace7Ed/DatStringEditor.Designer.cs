namespace Ace7Ed
{
    partial class DatStringEditor
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
            DatStringEditorStringRichTextBox = new RichTextBox();
            StringEditorSaveButton = new Button();
            SuspendLayout();
            // 
            // DatStringEditorStringRichTextBox
            // 
            DatStringEditorStringRichTextBox.Location = new Point(12, 12);
            DatStringEditorStringRichTextBox.Name = "DatStringEditorStringRichTextBox";
            DatStringEditorStringRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            DatStringEditorStringRichTextBox.Size = new Size(776, 426);
            DatStringEditorStringRichTextBox.TabIndex = 0;
            DatStringEditorStringRichTextBox.Text = "";
            DatStringEditorStringRichTextBox.TextChanged += DatStringEditorStringRichTextBox_TextChanged;
            // 
            // StringEditorSaveButton
            // 
            StringEditorSaveButton.Location = new Point(713, 444);
            StringEditorSaveButton.Name = "StringEditorSaveButton";
            StringEditorSaveButton.Size = new Size(75, 23);
            StringEditorSaveButton.TabIndex = 1;
            StringEditorSaveButton.Text = "Save";
            StringEditorSaveButton.UseVisualStyleBackColor = true;
            StringEditorSaveButton.Click += StringEditorSaveButton_Click;
            // 
            // DatStringEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(StringEditorSaveButton);
            Controls.Add(DatStringEditorStringRichTextBox);
            Name = "DatStringEditor";
            Text = "StringEditor";
            FormClosing += DatStringEditor_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox DatStringEditorStringRichTextBox;
        private Button StringEditorSaveButton;
    }
}