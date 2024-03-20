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
        public static Color MainBackColor => Configurations.Default.DarkTheme
            ? Color.FromArgb(37, 36, 53) : SystemColors.Control;

        public static Color MainForeColor => Configurations.Default.DarkTheme
            ? SystemColors.Info : SystemColors.ControlText;

        public static Color ButtonBackColor => Configurations.Default.DarkTheme
            ? Color.FromArgb(51, 50, 68) : Color.FromArgb(175, 175, 200);

        public static Color ButtonForeColor => Configurations.Default.DarkTheme
            ? SystemColors.Info : SystemColors.ControlText;

        public static Color TextBoxBackColor => Configurations.Default.DarkTheme
            ? Color.FromArgb(60, 65, 72) : Color.FromArgb(180, 180, 200);

        public static Color TextBoxForeColor => Configurations.Default.DarkTheme
            ? SystemColors.Info : SystemColors.ControlText;
    }
}
