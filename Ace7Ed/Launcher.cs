using Ace7Ed.Properties;
using Ace7LocalizationFormat.Formats;
using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider;
using CUE4Parse.FileProvider.Objects;
using CUE4Parse.UE4.Pak;
using CUE4Parse.UE4.Versions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ace7Ed
{
    public partial class Launcher : Form
    {
        public List<KeyValuePair<string, Dictionary<string, GameFile>>> PaksGameFiles = new List<KeyValuePair<string, Dictionary<string, GameFile>>>();
        public List<KeyValuePair<string, Dictionary<string, GameFile>>> PaksModsGameFiles = new List<KeyValuePair<string, Dictionary<string, GameFile>>>();
        public DefaultFileProvider GameProvider;
        public DefaultFileProvider ModsProvider;

        public Launcher()
        {
            InitializeComponent();
            ToggleDarkTheme();

        }
        private void ToggleDarkTheme()
        {
            BackColor = Theme.MainBackColor;
            ForeColor = Theme.MainForeColor;
            LauncherButtonGameDir.BackColor = Theme.ButtonBackColor;
            LauncherButtonGameDir.ForeColor = Theme.ButtonForeColor;
            LauncherTextBoxGameDir.BackColor = Theme.TextBoxBackColor;
            LauncherTextBoxGameDir.ForeColor = Theme.TextBoxForeColor;
            LauncherButtonOk.BackColor = Theme.ButtonBackColor;
            LauncherButtonOk.ForeColor = Theme.ButtonForeColor;
        }
        private void LauncherButtonGameDir_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowser = new FolderBrowserDialog()
            {
                Description = "Select Ace Combat 7 game directory",
                RootFolder = Environment.SpecialFolder.MyComputer,
            };

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                LauncherTextBoxGameDir.Text = folderBrowser.SelectedPath;
            }
        }

        private void LauncherButtonOk_Click(object sender, EventArgs e)
        {
            string directory = LauncherTextBoxGameDir.Text;

            GameProvider = new DefaultFileProvider(directory + "\\Game\\Content\\Paks", SearchOption.TopDirectoryOnly, true, new VersionContainer(EGame.GAME_AceCombat7));
            Utils.GetGameFiles(GameProvider, "68747470733a2f2f616365372e616365636f6d6261742e6a702f737065636961", PaksGameFiles);

            
            CMN cmn = new CMN(Utils.GetGameFile(PaksGameFiles, "Nimbus/Content/Localization/Game/Cmn.dat"));
            char[] datLetters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M'];
            List<DAT> dats = new List<DAT>();
            foreach (char datLetter in datLetters)
            {
                dats.Add(new DAT(Utils.GetGameFile(PaksGameFiles, "Nimbus/Content/Localization/Game/" + datLetter + ".dat"), datLetter));
            }

            /*Dictionary<string, (CMN, List<DAT>)> tests = new Dictionary<string, (CMN, List<DAT>)>();
            tests.Add("test", (cmn, dats));*/

            /*List<KeyValuePair<string, (CMN, List<DAT>)>> tests = new List<KeyValuePair<string, (CMN, List<DAT>)>>();
            tests.Add(new KeyValuePair<string, (CMN, List<DAT>)>("test", (cmn, dats)));*/

            Hide();
            var start = FormStartPosition.CenterScreen;

            using (var localizationEditor = new LocalizationEditor(cmn, dats) { StartPosition = start})
            {
                localizationEditor.ShowDialog();
            }

            Close();
        }
    }
}
