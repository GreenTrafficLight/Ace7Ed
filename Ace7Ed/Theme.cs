using Ace7Ed.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ace7Ed
{
    internal static class Theme
    {
        static readonly Color ButtonFaceDarkTheme = Color.FromArgb(48, 48, 48);
        static readonly Color ControlDarkTheme = Color.FromArgb(48, 48, 48);
        static readonly Color ControlDarkDarkTheme = Color.FromArgb(32, 32, 32);
        static readonly Color ControlTextDarkTheme = Color.FromArgb(204, 204, 204);
        static readonly Color HighlightDarkTheme = Color.FromArgb(1, 61, 121);
        static readonly Color HighlightTextDarkTheme = Color.FromArgb(51, 51, 51);
        static readonly Color WindowDarkTheme = Color.FromArgb(51, 51, 51);
        static readonly Color WindowTextDarkTheme = Color.FromArgb(204, 204, 204);
        
        public static Color ButtonFaceColor => Configurations.Default.DarkTheme
            ? ButtonFaceDarkTheme : SystemColors.ButtonFace;

        public static Color ControlColor => Configurations.Default.DarkTheme
            ? ControlDarkTheme : SystemColors.Control;
        
        public static Color ControlDarkColor => Configurations.Default.DarkTheme
            ? ControlDarkDarkTheme : SystemColors.ControlDark;
        
        public static Color ControlTextColor => Configurations.Default.DarkTheme
            ? ControlTextDarkTheme : SystemColors.ControlText;
        
        public static Color HighlightColor => Configurations.Default.DarkTheme
            ? HighlightDarkTheme : SystemColors.Highlight;
        
        public static Color HighlightTextColor => Configurations.Default.DarkTheme
            ? HighlightTextDarkTheme : SystemColors.HighlightText;
        
        public static Color WindowColor => Configurations.Default.DarkTheme
            ? WindowDarkTheme : SystemColors.Window;
        
        public static Color WindowTextColor => Configurations.Default.DarkTheme
            ? WindowTextDarkTheme : SystemColors.WindowText;

        public class MenuStripRenderer : ToolStripProfessionalRenderer
        {
            public MenuStripRenderer() : base(new MenuStripColors()) { }
        }

        private class MenuStripColors : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => ButtonFaceColor;

            public override Color MenuStripGradientEnd => Configurations.Default.DarkTheme
                ? Color.FromArgb(76, 76, 76) : Color.FromArgb(252, 252, 252);

            public override Color MenuBorder => Configurations.Default.DarkTheme
                ? Color.FromArgb(26, 26, 26) : Color.FromArgb(128, 128, 128);

            public override Color MenuItemBorder => HighlightColor;

            public override Color MenuItemPressedGradientBegin => Configurations.Default.DarkTheme
                ? Color.FromArgb(101, 101, 101) : Color.FromArgb(252, 252, 252);

            public override Color MenuItemPressedGradientMiddle => Configurations.Default.DarkTheme
                ? Color.FromArgb(98, 98, 98) : Color.FromArgb(245, 245, 245);

            public override Color MenuItemPressedGradientEnd => Configurations.Default.DarkTheme
                ? Color.FromArgb(99, 99, 99) : Color.FromArgb(248, 248, 248);

            public override Color MenuItemSelected => Configurations.Default.DarkTheme
                ? Color.FromArgb(24, 91, 146) : Color.FromArgb(181, 215, 243);

            public override Color MenuItemSelectedGradientBegin => Configurations.Default.DarkTheme
                ? Color.FromArgb(23, 92, 146) : Color.FromArgb(179, 215, 243);

            public override Color MenuItemSelectedGradientEnd => Configurations.Default.DarkTheme
                ? Color.FromArgb(23, 92, 146) : Color.FromArgb(179, 215, 243);
        }

        public static void SetDarkThemeButton(Button button)
        {
            button.BackColor = ControlColor;
            button.ForeColor = ControlTextColor;
            button.FlatAppearance.BorderColor = ControlDarkColor;
        }

        public static void SetDarkThemeCheckBox(CheckBox checkBox)
        {
            checkBox.BackColor = ControlColor;
            checkBox.ForeColor = ControlTextColor;
            checkBox.FlatAppearance.BorderColor = ControlDarkColor;
        }

        public static void SetDarkThemeComboBox(ComboBox comboBox)
        {
            comboBox.BackColor = WindowColor;
            comboBox.ForeColor = WindowTextColor;
        }

        public static void SetDarkThemeLabel(Label label)
        {
            label.BackColor = ControlColor;
            label.ForeColor = ControlTextColor;
        }

        public static void SetDarkThemeToolStripMenuItem(ToolStripMenuItem toolStripMenuItem)
        {
            toolStripMenuItem.BackColor = ControlColor;
            toolStripMenuItem.ForeColor = ControlTextColor;
        }

        public static void SetDarkThemeTextBox(TextBox textBox)
        {
            textBox.BackColor = WindowColor;
            textBox.ForeColor = WindowTextColor;
        }

        public static void SetDarkThemeRichTextBox(RichTextBox richTextBox)
        {
            richTextBox.BackColor = WindowColor;
            richTextBox.ForeColor = WindowTextColor;
        }

        public static void SetDarkThemeDataGridView(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ControlColor;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = WindowTextColor;
            dataGridView.DefaultCellStyle.BackColor = WindowColor;
            dataGridView.DefaultCellStyle.ForeColor = ControlTextColor;
            dataGridView.DefaultCellStyle.SelectionBackColor = HighlightColor;
            dataGridView.BackgroundColor = ControlDarkColor;
        }
    }
}
