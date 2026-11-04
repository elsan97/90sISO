using _90SISO.Core;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _90SISO
{
    public partial class UsbSelectForm : Form
    {
        public int SelectedDriveIndex { get; private set; } = -1;

        public UsbSelectForm(List<UsbDriveInfo> drives)
        {
            InitializeComponent();
            foreach (var d in drives)
            {
                var item = new ListViewItem("PhysicalDrive" + d.Index);
                item.SubItems.Add(d.Model);
                item.SubItems.Add(d.SizeText);
                item.Tag = d;
                listViewDrives.Items.Add(item);
            }
            if (listViewDrives.Items.Count > 0)
                listViewDrives.Items[0].Selected = true;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (listViewDrives.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите диск.", "Инфо",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var info = (UsbDriveInfo)listViewDrives.SelectedItems[0].Tag;
            SelectedDriveIndex = info.Index;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void listViewDrives_DoubleClick(object sender, System.EventArgs e)
        {
            btnOk_Click(sender, e);
        }
    }
}