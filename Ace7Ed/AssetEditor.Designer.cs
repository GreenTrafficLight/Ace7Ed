namespace Ace7Ed
{
    partial class AssetEditor
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
            MenuStrip MenuStrip;
            MenuStripMain = new ToolStripMenuItem();
            MSMainNewLauncher = new ToolStripMenuItem();
            MenuStripOptions = new ToolStripMenuItem();
            MSOptionsToggleDarkTheme = new ToolStripMenuItem();
            AssetsTreeView = new TreeView();
            AssetPropertyGrid = new PropertyGrid();
            treeView2 = new TreeView();
            richTextBox1 = new RichTextBox();
            MenuStrip = new MenuStrip();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { MenuStripMain, MenuStripOptions });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(800, 24);
            MenuStrip.TabIndex = 1;
            MenuStrip.Text = "menuStrip1";
            // 
            // MenuStripMain
            // 
            MenuStripMain.DropDownItems.AddRange(new ToolStripItem[] { MSMainNewLauncher });
            MenuStripMain.Name = "MenuStripMain";
            MenuStripMain.Size = new Size(46, 20);
            MenuStripMain.Text = "Main";
            // 
            // MSMainNewLauncher
            // 
            MSMainNewLauncher.Name = "MSMainNewLauncher";
            MSMainNewLauncher.Size = new Size(150, 22);
            MSMainNewLauncher.Text = "New Launcher";
            MSMainNewLauncher.Click += MSMainNewLauncher_Click;
            // 
            // MenuStripOptions
            // 
            MenuStripOptions.DropDownItems.AddRange(new ToolStripItem[] { MSOptionsToggleDarkTheme });
            MenuStripOptions.Name = "MenuStripOptions";
            MenuStripOptions.Size = new Size(61, 20);
            MenuStripOptions.Text = "Options";
            // 
            // MSOptionsToggleDarkTheme
            // 
            MSOptionsToggleDarkTheme.Name = "MSOptionsToggleDarkTheme";
            MSOptionsToggleDarkTheme.Size = new Size(175, 22);
            MSOptionsToggleDarkTheme.Text = "Toggle Dark Theme";
            // 
            // AssetsTreeView
            // 
            AssetsTreeView.Location = new Point(12, 27);
            AssetsTreeView.Name = "AssetsTreeView";
            AssetsTreeView.Size = new Size(219, 411);
            AssetsTreeView.TabIndex = 0;
            // 
            // AssetPropertyGrid
            // 
            AssetPropertyGrid.HelpVisible = false;
            AssetPropertyGrid.Location = new Point(388, 27);
            AssetPropertyGrid.Name = "AssetPropertyGrid";
            AssetPropertyGrid.Size = new Size(400, 273);
            AssetPropertyGrid.TabIndex = 2;
            AssetPropertyGrid.ToolbarVisible = false;
            // 
            // treeView2
            // 
            treeView2.Location = new Point(237, 27);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(145, 273);
            treeView2.TabIndex = 3;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(237, 306);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(551, 132);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // AssetEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(treeView2);
            Controls.Add(AssetPropertyGrid);
            Controls.Add(AssetsTreeView);
            Controls.Add(MenuStrip);
            MainMenuStrip = MenuStrip;
            Name = "AssetEditor";
            Text = "AssetEditor";
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView AssetsTreeView;
        private MenuStrip MenuStrip;
        private PropertyGrid AssetPropertyGrid;
        private TreeView treeView2;
        private RichTextBox richTextBox1;
        private ToolStripMenuItem MenuStripMain;
        private ToolStripMenuItem MenuStripOptions;
        private ToolStripMenuItem MSOptionsToggleDarkTheme;
        private ToolStripMenuItem MSMainNewLauncher;
    }
}