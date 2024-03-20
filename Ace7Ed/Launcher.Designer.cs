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
            SuspendLayout();
            // 
            // LauncherLabelGameDir
            // 
            LauncherLabelGameDir.AutoSize = true;
            LauncherLabelGameDir.Location = new Point(12, 16);
            LauncherLabelGameDir.Name = "LauncherLabelGameDir";
            LauncherLabelGameDir.Size = new Size(31, 15);
            LauncherLabelGameDir.TabIndex = 0;
            LauncherLabelGameDir.Text = "Path";
            // 
            // LauncherTextBoxGameDir
            // 
            LauncherTextBoxGameDir.Location = new Point(49, 12);
            LauncherTextBoxGameDir.Name = "LauncherTextBoxGameDir";
            LauncherTextBoxGameDir.Size = new Size(365, 23);
            LauncherTextBoxGameDir.TabIndex = 1;
            // 
            // LauncherButtonGameDir
            // 
            LauncherButtonGameDir.Location = new Point(420, 12);
            LauncherButtonGameDir.Name = "LauncherButtonGameDir";
            LauncherButtonGameDir.Size = new Size(136, 23);
            LauncherButtonGameDir.TabIndex = 2;
            LauncherButtonGameDir.Text = "Select Game Directory";
            LauncherButtonGameDir.UseVisualStyleBackColor = true;
            LauncherButtonGameDir.Click += LauncherButtonGameDir_Click;
            // 
            // LauncherButtonOk
            // 
            LauncherButtonOk.Location = new Point(420, 41);
            LauncherButtonOk.Name = "LauncherButtonOk";
            LauncherButtonOk.Size = new Size(136, 23);
            LauncherButtonOk.TabIndex = 3;
            LauncherButtonOk.Text = "Ok";
            LauncherButtonOk.UseVisualStyleBackColor = true;
            LauncherButtonOk.Click += LauncherButtonOk_Click;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 75);
            Controls.Add(LauncherButtonOk);
            Controls.Add(LauncherButtonGameDir);
            Controls.Add(LauncherTextBoxGameDir);
            Controls.Add(LauncherLabelGameDir);
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
    }
}