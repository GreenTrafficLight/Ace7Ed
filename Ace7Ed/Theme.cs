using Ace7Ed.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ace7Ed
{
    internal static class Theme
    {
        static readonly Color ControlDarkTheme = Color.FromArgb(48, 48, 48);
        static readonly Color ControlTextDarkTheme = Color.FromArgb(204, 204, 204);
        static readonly Color WindowDarkTheme = Color.FromArgb(51, 51, 51);
        static readonly Color WindowTextDarkTheme = Color.FromArgb(204, 204, 204);

        public static Color ControlColor => Configurations.Default.DarkTheme
            ? ControlDarkTheme : SystemColors.Control;
        public static Color ControlTextColor => Configurations.Default.DarkTheme
            ? ControlTextDarkTheme : SystemColors.ControlText;
        public static Color WindowColor => Configurations.Default.DarkTheme
            ? WindowDarkTheme : SystemColors.Window;
        public static Color WindowTextColor => Configurations.Default.DarkTheme
            ? WindowTextDarkTheme : SystemColors.WindowText;

        public static void SetDarkThemeButton(Button button)
        {
            button.BackColor = ControlColor;
            button.ForeColor = ControlTextColor;
        }

        public static void SetDarkThemeDataGridView(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ControlColor;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = WindowTextColor;
            dataGridView.DefaultCellStyle.BackColor = WindowColor;
            dataGridView.DefaultCellStyle.ForeColor = ControlTextColor;
        }
    }
}
