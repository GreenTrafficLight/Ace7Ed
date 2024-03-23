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
            DatTextRichTextBox = new RichTextBox();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // DatTextRichTextBox
            // 
            DatTextRichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DatTextRichTextBox.Location = new Point(12, 12);
            DatTextRichTextBox.Name = "DatTextRichTextBox";
            DatTextRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            DatTextRichTextBox.Size = new Size(776, 426);
            DatTextRichTextBox.TabIndex = 0;
            DatTextRichTextBox.Text = "";
            DatTextRichTextBox.TextChanged += DatStringEditorStringRichTextBox_TextChanged;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.FlatStyle = FlatStyle.Flat;
            SaveButton.Location = new Point(713, 444);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += StringEditorSaveButton_Click;
            // 
            // DatStringEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(SaveButton);
            Controls.Add(DatTextRichTextBox);
            Name = "DatStringEditor";
            Text = "String Editor";
            FormClosing += DatStringEditor_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox DatTextRichTextBox;
        private Button SaveButton;
    }
}