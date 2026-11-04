using _90SISO.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _90SISO
{
    public partial class MainForm : Form
    {
        private string _lastSourceFolder;

        public MainForm() { InitializeComponent(); }

        private void SetBusy(bool busy, string status = null)
        {
            grpBuild.Enabled = grpIsoActions.Enabled = !busy;
            if (status != null) lblStatus.Text = status;
            if (!busy) { progressBar.Value = 0; progressBar.Style = ProgressBarStyle.Blocks; }
        }

        // ---------- Создание ISO ----------
        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _lastSourceFolder = dlg.SelectedPath;
                    txtSourceFolder.Text = dlg.SelectedPath;
                }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog { Filter = "ISO|*.iso", FileName = "output.iso" })
                if (dlg.ShowDialog() == DialogResult.OK) txtOutputIso.Text = dlg.FileName;
        }

        private async void btnBuildIso_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSourceFolder.Text) ||
                string.IsNullOrWhiteSpace(txtOutputIso.Text))
            {
                MessageBox.Show("Укажите папку-источник и путь для ISO.");
                return;
            }

            var opts = new IsoBuildOptions
            {
                VolumeLabel = txtVolumeLabel.Text,
                UseJoliet = chkJoliet.Checked
            };

            if (chkBootable.Checked)
            {
                using (var dlg = new BootOptionsForm())
                {
                    if (dlg.ShowDialog() != DialogResult.OK) return;
                    if (!dlg.Bootable) { chkBootable.Checked = false; }
                    else
                    {
                        opts.Bootable = true;
                        opts.BootImagePath = dlg.BootImagePath;
                        opts.LoadSegment = dlg.LoadSegment;
                    }
                }
            }

            try
            {
                SetBusy(true, "Создание ISO...");
                progressBar.Style = ProgressBarStyle.Marquee;
                var builder = new IsoBuilder();
                builder.Progress += s => Invoke((Action)(() => lblStatus.Text = s));
                await Task.Run(() => builder.CreateIso(txtSourceFolder.Text, txtOutputIso.Text, opts));
				// Принудительное выравнивание файла после сборки
				var fi = new FileInfo(txtOutputIso.Text);
				if (fi.Length % 2048 != 0) {
					using (var fs = new FileStream(txtOutputIso.Text, FileMode.Append)) {
						long pad = 2048 - (fi.Length % 2048);
						fs.Write(new byte[pad], 0, (int)pad);
					}
				}
                lblStatus.Text = "ISO создан: " + txtOutputIso.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { SetBusy(false); }
        }

    
    private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        using (var about = new AboutForm())
            about.ShowDialog(this);
    }

        public void ApplyDarkTheme(Control parent)
        {
            var bg = System.Drawing.Color.FromArgb(30, 30, 30);
            var fg = System.Drawing.Color.FromArgb(220, 220, 220);
            var controlBg = System.Drawing.Color.FromArgb(45, 45, 48);

            parent.BackColor = bg;
            parent.ForeColor = fg;

            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = controlBg; btn.ForeColor = fg; btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(63, 63, 70);
                }
                else if (c is TextBox || c is ListView || c is TreeView)
                {
                    c.BackColor = controlBg; c.ForeColor = fg;
                }
                else if (c is GroupBox || c is Panel)
                {
                    c.ForeColor = fg;
                }
                ApplyDarkTheme(c); // рекурсия
            }
        }


        private void picLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Синий диск
            using (var brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 120, 215)))
                g.FillEllipse(brush, 0, 0, 60, 60);

            // Отверстие
            using (var brush = new System.Drawing.SolidBrush(System.Drawing.Color.White))
                g.FillEllipse(brush, 22, 22, 16, 16);

            // Текст 90
            using (var font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold))
            using (var brush = new System.Drawing.SolidBrush(System.Drawing.Color.White))
                g.DrawString("90", font, brush, 4, 18);
        }

        // ---------- Распаковка ----------
        private async void btnExtractIso_Click(object sender, EventArgs e)
        {
            using (var open = new OpenFileDialog { Filter = "ISO|*.iso" })
            {
                if (open.ShowDialog() != DialogResult.OK) return;
                using (var folder = new FolderBrowserDialog())
                {
                    if (folder.ShowDialog() != DialogResult.OK) return;
                    try
                    {
                        SetBusy(true, "Распаковка...");
                        progressBar.Style = ProgressBarStyle.Marquee;
                        var ex = new IsoExtractor();
                        ex.Progress += s => Invoke((Action)(() => lblStatus.Text = s));
                        await Task.Run(() => ex.Extract(open.FileName, folder.SelectedPath));
                        lblStatus.Text = "Распаковано в: " + folder.SelectedPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { SetBusy(false); }
                }
            }
        }

        // ---------- Редактирование ----------
        private void btnEditIso_Click(object sender, EventArgs e)
        {
            using (var open = new OpenFileDialog { Filter = "ISO|*.iso" })
            {
                if (open.ShowDialog() != DialogResult.OK) return;
                var opts = new IsoBuildOptions
                {
                    VolumeLabel = txtVolumeLabel.Text,
                    UseJoliet = chkJoliet.Checked
                };
                using (var editor = new IsoTreeForm(open.FileName, opts))
                    editor.ShowDialog();
            }
        }

        // ---------- Запись на USB ----------
        private async void btnWriteUsb_Click(object sender, EventArgs e)
        {
            var drives = UsbWriter.GetUsbDrives();
            if (drives.Count == 0)
            {
                MessageBox.Show("USB-диски не найдены.");
                return;
            }
            int idx;
            using (var sel = new UsbSelectForm(drives))
            {
                if (sel.ShowDialog() != DialogResult.OK) return;
                idx = sel.SelectedDriveIndex;
            }
            using (var open = new OpenFileDialog { Filter = "ISO|*.iso" })
            {
                if (open.ShowDialog() != DialogResult.OK) return;
                if (MessageBox.Show($"Точно записать на PhysicalDrive{idx}?\nВСЕ ДАННЫЕ БУДУТ УНИЧТОЖЕНЫ.",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
                try
                {
                    SetBusy(true, "Запись на USB...");
                    var w = new UsbWriter();
                    w.Progress += (done, total) => Invoke((Action)(() =>
                    {
                        progressBar.Maximum = 1000;
                        progressBar.Value = (int)(done * 1000 / Math.Max(1, total));
                        lblStatus.Text = $"Записано {done / 1024 / 1024} / {total / 1024 / 1024} МБ";
                    }));
                    await Task.Run(() => w.WriteIsoToUsb(open.FileName, idx));
                    lblStatus.Text = "Запись завершена.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { SetBusy(false); }
            }
        }

        // ---------- Монтирование ----------
        private void btnMountIso_Click(object sender, EventArgs e)
        {
            using (var open = new OpenFileDialog { Filter = "ISO|*.iso" })
            {
                if (open.ShowDialog() != DialogResult.OK) return;
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "powershell",
                        Arguments = $"-NoProfile -Command \"Mount-DiskImage -ImagePath '{open.FileName}'\"",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    });
                    lblStatus.Text = "Смонтировано (проверьте «Мой компьютер»).";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}