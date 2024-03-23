using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider.Objects;
using CUE4Parse.FileProvider;
using CUE4Parse.UE4.Pak;

namespace Ace7Ed
{
    internal static class Utils
    {
        public static void GetGameFiles(DefaultFileProvider provider, string aesKey, List<KeyValuePair<string, Dictionary<string, GameFile>>> paksFiles)
        {
            provider.Initialize();
            provider.SubmitKey(new(0U), new FAesKey(aesKey));
            foreach (PakFileReader pak in provider.MountedVfs.OrderBy(x => x.Name).ToList())
            {
                Dictionary<string, GameFile> gameFiles = (Dictionary<string, GameFile>)pak.Mount();
                paksFiles.Add(new KeyValuePair<string, Dictionary<string, GameFile>>(Path.GetFileNameWithoutExtension(pak.Name), gameFiles));
            }
        }

        public static byte[] GetGameFile(List<KeyValuePair<string, Dictionary<string, GameFile>>> paks, string fileName)
        {
            byte[] gameFile = null;

            foreach (var pakGameFiles in paks)
            {
                if (pakGameFiles.Value.ContainsKey(fileName) && gameFile == null)
                {
                    gameFile = pakGameFiles.Value[fileName].Read();
                }
            }

            return gameFile;
        }

        public static ToolStripMenuItem CreateToolStripMenuItem(string text, string name, EventHandler eventHandler = null, bool enabled = true)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(text);
            toolStripMenuItem.Name = name;
            if (eventHandler != null)
            {
                toolStripMenuItem.Click += eventHandler;
            }
            toolStripMenuItem.Enabled = enabled;
            Theme.SetDarkThemeToolStripMenuItem(toolStripMenuItem);
            return toolStripMenuItem;
        }
    }
}
