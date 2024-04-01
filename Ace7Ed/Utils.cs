using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider.Objects;
using CUE4Parse.FileProvider;
using CUE4Parse.UE4.Pak;
using UAssetAPI;

namespace Ace7Ed
{
    internal static class Utils
    {

        public static void GetGameFilesByOrder(DefaultFileProvider provider, string aesKey, List<KeyValuePair<string, Dictionary<string, GameFile>>> paksFiles)
        {
            provider.Initialize();
            provider.SubmitKey(new(0U), new FAesKey(aesKey));
            foreach (PakFileReader pak in provider.MountedVfs.OrderBy(x => x.Name).ToList())
            {
                Dictionary<string, GameFile> gameFiles = (Dictionary<string, GameFile>)pak.Mount();
                paksFiles.Add(new KeyValuePair<string, Dictionary<string, GameFile>>(Path.GetFileNameWithoutExtension(pak.Name), gameFiles));
            }
        }

        public static byte[] GetGameFileData(List<KeyValuePair<string, Dictionary<string, GameFile>>> paks, string fileName)
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

        public static GameFile GetGameFile(List<KeyValuePair<string, Dictionary<string, GameFile>>> paks, string fileName)
        {
            GameFile gameFile = null;

            foreach (var pakGameFiles in paks)
            {
                if (pakGameFiles.Value.ContainsKey(fileName) && gameFile == null)
                {
                    gameFile = pakGameFiles.Value[fileName];
                }
            }

            return gameFile;
        }

        public static UAsset GetUAsset(List<KeyValuePair<string, Dictionary<string, GameFile>>> paks, string fileName)
        {
            GameFile uasset = null;
            GameFile uexp = null;

            foreach (var pakGameFiles in paks)
            {
                if (pakGameFiles.Value.ContainsKey(fileName + ".uasset") && uasset == null)
                {
                    uasset = pakGameFiles.Value[fileName + ".uasset"];
                    uexp = pakGameFiles.Value[fileName + ".uexp"];
                }
            }

            AC7Decrypt ac7Decrypt = new AC7Decrypt();
            AC7XorKey ac7XorKey = new AC7XorKey(uasset.NameWithoutExtension);
            byte[] ac7UAsset = ac7Decrypt.DecryptUAssetBytes(uasset.Read(), ac7XorKey);
            byte[] ac7Uexp = ac7Decrypt.DecryptUexpBytes(uexp.Read(), ac7XorKey);
            byte[] assetData = new byte[ac7UAsset.Length + ac7Uexp.Length];
            Buffer.BlockCopy(ac7UAsset, 0, assetData, 0, ac7UAsset.Length);
            Buffer.BlockCopy(ac7Uexp, 0, assetData, ac7UAsset.Length, ac7Uexp.Length);
            AssetBinaryReader assetBinaryReader = new AssetBinaryReader(new MemoryStream(assetData));
            UAsset asset = new UAsset(assetBinaryReader, UAssetAPI.UnrealTypes.EngineVersion.VER_UE4_18);

            return asset;
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
