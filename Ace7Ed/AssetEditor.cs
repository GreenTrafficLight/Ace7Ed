using CUE4Parse.FileProvider.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAssetAPI.ExportTypes;
using UAssetAPI;
using CUE4Parse.GameTypes.ACE7.Encryption;
using System.Diagnostics;

namespace Ace7Ed
{
    public partial class AssetEditor : Form
    {
        public List<KeyValuePair<string, Dictionary<string, GameFile>>> _paksGameFiles = null;

        public AssetEditor()
        {
            InitializeComponent();

            
        }

        private void LoadAssetsTreeView()
        {
            foreach (var pak in _paksGameFiles)
            {
                foreach (var asset in pak.Value.Values)
                {
                    if (asset.Extension == "uasset")
                    {
                        int secondSlashIndex = asset.PathWithoutExtension.IndexOf('/', asset.PathWithoutExtension.IndexOf('/') + 1);
                        //MakeTreeFromDirectory(asset.PathWithoutExtension.Substring(secondSlashIndex + 1), AssetsTreeView.Nodes);
                    }
                }
            }
        }

        public void MakeTreeFromDirectory(string directoryPath, TreeNodeCollection parentNodes)
        {
            string directory = directoryPath.Split("/")[0];
            int slashIndex = directoryPath.IndexOf('/');
            if (slashIndex != -1)
            {
                TreeNode nodeDirectory = GetTreeNode(directory, parentNodes);
                if (nodeDirectory == null)
                {
                    nodeDirectory = new TreeNode(directory);
                    parentNodes.Add(nodeDirectory);
                }
                
                MakeTreeFromDirectory(directoryPath.Substring(slashIndex + 1), nodeDirectory.Nodes);
            }
            else
            {
                TreeNode nodeFile = GetTreeNode(directory, parentNodes);
                if (nodeFile == null)
                {
                    nodeFile = new TreeNode(directory);
                    parentNodes.Add(nodeFile);
                }
            }
        }

        private void LoadAsset(GameFile uasset)
        {
            /*AC7XorKey ac7XorKey = new AC7XorKey(uasset.NameWithoutExtension);
            byte[] ac7UAsset = _ac7Decrypt.DecryptUAssetBytes(uasset.Read(), ac7XorKey);
            byte[] ac7Uexp = _ac7Decrypt.DecryptUexpBytes(pak.Files[uasset.PathWithoutExtension + ".uexp"].Read(), ac7XorKey);
            byte[] test = new byte[ac7UAsset.Length + ac7Uexp.Length];
            Buffer.BlockCopy(ac7UAsset, 0, test, 0, ac7UAsset.Length);
            Buffer.BlockCopy(ac7Uexp, 0, test, ac7UAsset.Length, ac7Uexp.Length);
            AssetBinaryReader assetBinaryReader = new AssetBinaryReader(new MemoryStream(test));
            UAsset export = new UAsset(assetBinaryReader, UAssetAPI.UnrealTypes.EngineVersion.VER_UE4_18);*/
        }

        public TreeNode GetTreeNode(string name, TreeNodeCollection treeNodes)
        {
            foreach (TreeNode treeNode in treeNodes)
            {
                if (treeNode.Text == name)
                {
                    return treeNode;
                }
                GetTreeNode(name, treeNode.Nodes);
            }
            return null;
        }

        private void MSMainNewLauncher_Click(object sender, EventArgs e)
        {
            using (var launcher = new Launcher())
            {
                launcher.ShowDialog();
                if (launcher.DialogResult == DialogResult.OK)
                {
                    _paksGameFiles = launcher.PaksGameFiles;

                    UAsset asset = Utils.GetUAsset(_paksGameFiles, "Nimbus/Content/Blueprint/Information/PlayerPlaneDataTable");

                    AssetPropertyGrid.SelectedObject = ((DataTableExport)asset.Exports[0]).Table.Data[0].Value;

                    Debug.WriteLine("test");
                    //LoadAssetsTreeView();
                }
                launcher.Dispose();
            }
        }
    }
}
