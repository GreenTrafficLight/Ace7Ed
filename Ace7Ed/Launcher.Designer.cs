namespace Ace7Ed
{
    partial class Launcher
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
            LauncherLabelGameDir = new Label();
            LauncherTextBoxGameDir = new TextBox();
            LauncherButtonGameDir = new Button();
            LauncherButtonOk = new Button();
            LauncherTextBoxDatsDir = new TextBox();
            LauncherButtonDatsDir = new Button();
            LauncherLabelDatsDir = new Label();
            SuspendLayout();
            // 
            // LauncherLabelGameDir
            // 
            LauncherLabelGameDir.AutoSize = true;
            LauncherLabelGameDir.Location = new Point(12, 15);
            LauncherLabelGameDir.Name = "LauncherLabelGameDir";
            LauncherLabelGameDir.Size = new Size(65, 15);
            LauncherLabelGameDir.TabIndex = 0;
            LauncherLabelGameDir.Text = "Game Path";
            // 
            // LauncherTextBoxGameDir
            // 
            LauncherTextBoxGameDir.Location = new Point(83, 12);
            LauncherTextBoxGameDir.Name = "LauncherTextBoxGameDir";
            LauncherTextBoxGameDir.Size = new Size(365, 23);
            LauncherTextBoxGameDir.TabIndex = 1;
            // 
            // LauncherButtonGameDir
            // 
            LauncherButtonGameDir.Location = new Point(454, 12);
            LauncherButtonGameDir.Name = "LauncherButtonGameDir";
            LauncherButtonGameDir.Size = new Size(136, 23);
            LauncherButtonGameDir.TabIndex = 2;
            LauncherButtonGameDir.Text = "Select Game Directory";
            LauncherButtonGameDir.UseVisualStyleBackColor = true;
            LauncherButtonGameDir.Click += LauncherButtonGameDir_Click;
            // 
            // LauncherButtonOk
            // 
            LauncherButtonOk.Location = new Point(454, 69);
            LauncherButtonOk.Name = "LauncherButtonOk";
            LauncherButtonOk.Size = new Size(136, 23);
            LauncherButtonOk.TabIndex = 3;
            LauncherButtonOk.Text = "Ok";
            LauncherButtonOk.UseVisualStyleBackColor = true;
            LauncherButtonOk.Click += LauncherButtonOk_Click;
            // 
            // LauncherTextBoxDatsDir
            // 
            LauncherTextBoxDatsDir.Location = new Point(83, 41);
            LauncherTextBoxDatsDir.Name = "LauncherTextBoxDatsDir";
            LauncherTextBoxDatsDir.Size = new Size(365, 23);
            LauncherTextBoxDatsDir.TabIndex = 4;
            // 
            // LauncherButtonDatsDir
            // 
            LauncherButtonDatsDir.Location = new Point(454, 40);
            LauncherButtonDatsDir.Name = "LauncherButtonDatsDir";
            LauncherButtonDatsDir.Size = new Size(136, 23);
            LauncherButtonDatsDir.TabIndex = 5;
            LauncherButtonDatsDir.Text = "Select Dats Directory";
            LauncherButtonDatsDir.UseVisualStyleBackColor = true;
            // 
            // LauncherLabelDatsDir
            // 
            LauncherLabelDatsDir.AutoSize = true;
            LauncherLabelDatsDir.Location = new Point(18, 44);
            LauncherLabelDatsDir.Name = "LauncherLabelDatsDir";
            LauncherLabelDatsDir.Size = new Size(57, 15);
            LauncherLabelDatsDir.TabIndex = 6;
            LauncherLabelDatsDir.Text = "Dats Path";
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 101);
            Controls.Add(LauncherLabelDatsDir);
            Controls.Add(LauncherButtonDatsDir);
            Controls.Add(LauncherTextBoxDatsDir);
            Controls.Add(LauncherButtonOk);
            Controls.Add(LauncherButtonGameDir);
            Controls.Add(LauncherTextBoxGameDir);
            Controls.Add(LauncherLabelGameDir);
            MaximizeBox = false;
            Name = "Launcher";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LauncherLabelGameDir;
        private TextBox LauncherTextBoxGameDir;
        private Button LauncherButtonGameDir;
        private Button LauncherButtonOk;
        private TextBox LauncherTextBoxDatsDir;
        private Button LauncherButtonDatsDir;
        private Label LauncherLabelDatsDir;
    }
}