using System;
using System.Windows.Forms;

namespace _90SISO
{
    public partial class BootOptionsForm : Form
    {
        public bool Bootable => chkBootable.Checked;
        public string BootImagePath => txtBootImage.Text;
        public ushort LoadSegment { get; private set; } = 0x7C0;

        public BootOptionsForm()
        {
            InitializeComponent();
        }

        private void chkBootable_CheckedChanged(object sender, EventArgs e)
        {
            txtBootImage.Enabled = btnBrowse.Enabled = txtLoadSegment.Enabled = chkBootable.Checked;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog { Filter = "Boot image (*.bin)|*.bin|All files|*.*" })
                if (dlg.ShowDialog() == DialogResult.OK) txtBootImage.Text = dlg.FileName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkBootable.Checked)
            {
                if (!System.IO.File.Exists(txtBootImage.Text))
                {
                    MessageBox.Show("Укажите существующий boot image.");
                    return;
                }
                if (!ushort.TryParse(txtLoadSegment.Text,
                        System.Globalization.NumberStyles.HexNumber, null, out var seg))
                {
                    MessageBox.Show("Load segment должен быть hex (например, 7C0).");
                    return;
                }
                LoadSegment = seg;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}