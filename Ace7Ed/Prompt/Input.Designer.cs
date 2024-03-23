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
            CustomTextLabel = new Label();
            TextBox = new TextBox();
            OkButton = new Button();
            ExistingStringLabel = new Label();
            SuspendLayout();
            // 
            // CustomTextLabel
            // 
            CustomTextLabel.AutoSize = true;
            CustomTextLabel.Location = new Point(12, 9);
            CustomTextLabel.Name = "CustomTextLabel";
            CustomTextLabel.Size = new Size(73, 15);
            CustomTextLabel.TabIndex = 0;
            CustomTextLabel.Text = "Custom Text";
            // 
            // TextBox
            // 
            TextBox.Location = new Point(12, 32);
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(320, 23);
            TextBox.TabIndex = 1;
            // 
            // OkButton
            // 
            OkButton.FlatStyle = FlatStyle.Flat;
            OkButton.Location = new Point(267, 61);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(65, 23);
            OkButton.TabIndex = 2;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // ExistingStringLabel
            // 
            ExistingStringLabel.Location = new Point(12, 32);
            ExistingStringLabel.Name = "ExistingStringLabel";
            ExistingStringLabel.Size = new Size(83, 23);
            ExistingStringLabel.TabIndex = 3;
            ExistingStringLabel.Text = "Existing String";
            ExistingStringLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Input
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 96);
            Controls.Add(ExistingStringLabel);
            Controls.Add(OkButton);
            Controls.Add(TextBox);
            Controls.Add(CustomTextLabel);
            MaximizeBox = false;
            Name = "Input";
            Text = "Input";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CustomTextLabel;
        private TextBox TextBox;
        private Button OkButton;
        private Label ExistingStringLabel;
    }
}