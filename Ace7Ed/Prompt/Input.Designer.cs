namespace Ace7Ed.Prompt
{
    partial class Input
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
            InputCustomTextLabel = new Label();
            InputTextBox = new TextBox();
            InputOkButton = new Button();
            InputExistingStringLabel = new Label();
            SuspendLayout();
            // 
            // InputCustomTextLabel
            // 
            InputCustomTextLabel.AutoSize = true;
            InputCustomTextLabel.Location = new Point(12, 9);
            InputCustomTextLabel.Name = "InputCustomTextLabel";
            InputCustomTextLabel.Size = new Size(73, 15);
            InputCustomTextLabel.TabIndex = 0;
            InputCustomTextLabel.Text = "Custom Text";
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new Point(12, 27);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(320, 23);
            InputTextBox.TabIndex = 1;
            // 
            // InputOkButton
            // 
            InputOkButton.Location = new Point(267, 56);
            InputOkButton.Name = "InputOkButton";
            InputOkButton.Size = new Size(65, 23);
            InputOkButton.TabIndex = 2;
            InputOkButton.Text = "OK";
            InputOkButton.UseVisualStyleBackColor = true;
            // 
            // InputExistingStringLabel
            // 
            InputExistingStringLabel.Location = new Point(12, 27);
            InputExistingStringLabel.Name = "InputExistingStringLabel";
            InputExistingStringLabel.Size = new Size(83, 23);
            InputExistingStringLabel.TabIndex = 3;
            InputExistingStringLabel.Text = "Existing String";
            InputExistingStringLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Input
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 86);
            Controls.Add(InputExistingStringLabel);
            Controls.Add(InputOkButton);
            Controls.Add(InputTextBox);
            Controls.Add(InputCustomTextLabel);
            MaximizeBox = false;
            Name = "Input";
            Text = "Input";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label InputCustomTextLabel;
        private TextBox InputTextBox;
        private Button InputOkButton;
        private Label InputExistingStringLabel;
    }
}