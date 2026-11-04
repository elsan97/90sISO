using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace _90SISO
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
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
        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://github.com/elsan97/90SISO") { UseShellExecute = true });
            }
            catch { /* Игнорируем, если нет браузера */ }
        }
    }
}