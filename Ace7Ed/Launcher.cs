using Ace7Ed.Properties;
using Ace7LocalizationFormat.Formats;
using Ace7LocalizationFormat;
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
using CUE4Parse.UE4.Readers;
using CUE4Parse.UE4.Assets;
using Newtonsoft.Json;

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
            LauncherTextBoxGameDir.Text = Configurations.Default.GamePath;

        }
        
        private void ToggleDarkTheme()
        {
            BackColor = Theme.ControlColor;
            ForeColor = Theme.ControlTextColor;

            #region Button
            LauncherButtonGameDir.BackColor = Theme.ControlColor;
            LauncherButtonGameDir.ForeColor = Theme.ControlTextColor;

            LauncherButtonOk.BackColor = Theme.ControlColor;
            LauncherButtonOk.ForeColor = Theme.ControlTextColor;
            #endregion

            #region TextBox
            LauncherTextBoxGameDir.BackColor = Theme.WindowColor;
            LauncherTextBoxGameDir.ForeColor = Theme.WindowTextColor;

            #endregion
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
            string gameDirectory = LauncherTextBoxGameDir.Text;

            GameProvider = new DefaultFileProvider(gameDirectory + "\\Game\\Content\\Paks", SearchOption.TopDirectoryOnly, true, new VersionContainer(EGame.GAME_AceCombat7));
            Utils.GetGameFiles(GameProvider, "68747470733a2f2f616365372e616365636f6d6261742e6a702f737065636961", PaksGameFiles);

            Configurations.Default.GamePath = LauncherTextBoxGameDir.Text;
            Configurations.Default.Save();

            (CMN, List<DAT>) gameLocalization = LoadGameLocalization(AceLocalizationConstants.DatLetters.Keys.ToArray());

            /*
            GameFile gameFileUasset = Utils.GetGameFile(PaksGameFiles, "Nimbus/Content/Blueprint/Information/PlayerPlaneDataTable.uasset");
            GameFile gameFileUexp = Utils.GetGameFile(PaksGameFiles, "Nimbus/Content/Blueprint/Information/PlayerPlaneDataTable.uexp");

            gameFileUasset.TryCreateReader(out FArchive uasset);
            gameFileUexp.TryCreateReader(out FArchive uexp);
            FArchive ubulk = null;

            var test = new Package(uasset, uexp, ubulk, null, null, null, true);
            var test2 = test.GetExports();
            var fullJson = JsonConvert.SerializeObject(test2, Formatting.Indented);*/
        }
    
        private (CMN, List<DAT>) LoadGameLocalization(char[] datLetters)
        {
            CMN gameCmn = new CMN(Utils.GetGameFileData(PaksGameFiles, "Nimbus/Content/Localization/Game/Cmn.dat"));
            List<DAT> gameDats = new List<DAT>();
            foreach (char datLetter in datLetters)
            {
                gameDats.Add(new DAT(Utils.GetGameFileData(PaksGameFiles, "Nimbus/Content/Localization/Game/" + datLetter + ".dat"), datLetter));
            }

            return (gameCmn, gameDats);
        }
    }
}
