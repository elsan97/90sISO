using _90SISO.Core;
using System;
using System.IO;
using System.Windows.Forms;

namespace _90SISO
{
    public partial class IsoTreeForm : Form
    {
        private string _tempFolder;
        private string _originalIso;
        private IsoBuildOptions _buildOpts;

        public IsoTreeForm(string isoPath, IsoBuildOptions buildOpts)
        {
            InitializeComponent();
            _originalIso = isoPath;
            _buildOpts = buildOpts;
            _tempFolder = new IsoEditor().UnpackToTemp(isoPath);
            LoadTree();
        }

        private void LoadTree()
        {
            treeView.Nodes.Clear();
            var root = new TreeNode(Path.GetFileName(_originalIso)) { Tag = _tempFolder };
            treeView.Nodes.Add(root);
            Populate(root, _tempFolder);
            root.Expand();
        }

        private void Populate(TreeNode parent, string folder)
        {
            foreach (var dir in Directory.GetDirectories(folder))
                parent.Nodes.Add(new TreeNode(Path.GetFileName(dir)) { Tag = dir });
            foreach (var file in Directory.GetFiles(folder))
                parent.Nodes.Add(new TreeNode(Path.GetFileName(file)) { Tag = file });
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null) return;
            var targetDir = treeView.SelectedNode.Tag as string;
            if (targetDir != null && File.Exists(targetDir))
                targetDir = Path.GetDirectoryName(targetDir);
            if (targetDir == null || !Directory.Exists(targetDir)) return;

            using (var dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;
                File.Copy(dlg.FileName, Path.Combine(targetDir, Path.GetFileName(dlg.FileName)), true);
                LoadTree();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null || treeView.SelectedNode.Parent == null) return;
            var path = treeView.SelectedNode.Tag as string;
            if (path == null) return;
            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            if (File.Exists(path)) File.Delete(path);
            else if (Directory.Exists(path)) Directory.Delete(path, true);
            LoadTree();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog { Filter = "ISO|*.iso", FileName = Path.GetFileName(_originalIso) })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;
                try
                {
                    new IsoBuilder().CreateIso(_tempFolder, dlg.FileName, _buildOpts);
                    MessageBox.Show("Сохранено: " + dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}