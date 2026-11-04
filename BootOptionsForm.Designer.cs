namespace _90SISO
{
    partial class BootOptionsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox chkBootable;
        private System.Windows.Forms.TextBox txtBootImage;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtLoadSegment;
        private System.Windows.Forms.Label lblLoadSeg;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chkBootable = new System.Windows.Forms.CheckBox();
            this.txtBootImage = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtLoadSegment = new System.Windows.Forms.TextBox();
            this.lblLoadSeg = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // chkBootable
            this.chkBootable.AutoSize = true;
            this.chkBootable.Location = new System.Drawing.Point(12, 12);
            this.chkBootable.Name = "chkBootable";
            this.chkBootable.Size = new System.Drawing.Size(200, 17);
            this.chkBootable.TabIndex = 0;
            this.chkBootable.Text = "Сделать загрузочным (El Torito BIOS)";
            this.chkBootable.UseVisualStyleBackColor = true;
            this.chkBootable.CheckedChanged += new System.EventHandler(this.chkBootable_CheckedChanged);
            // txtBootImage
            this.txtBootImage.Location = new System.Drawing.Point(12, 40);
            this.txtBootImage.Name = "txtBootImage";
            this.txtBootImage.Size = new System.Drawing.Size(360, 20);
            this.txtBootImage.TabIndex = 1;
            this.txtBootImage.Enabled = false;
            // btnBrowse
            this.btnBrowse.Location = new System.Drawing.Point(378, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // lblLoadSeg
            this.lblLoadSeg.AutoSize = true;
            this.lblLoadSeg.Location = new System.Drawing.Point(12, 70);
            this.lblLoadSeg.Name = "lblLoadSeg";
            this.lblLoadSeg.Size = new System.Drawing.Size(120, 13);
            this.lblLoadSeg.Text = "Load segment (hex):";
            // txtLoadSegment
            this.txtLoadSegment.Location = new System.Drawing.Point(140, 67);
            this.txtLoadSegment.Name = "txtLoadSegment";
            this.txtLoadSegment.Size = new System.Drawing.Size(80, 20);
            this.txtLoadSegment.TabIndex = 3;
            this.txtLoadSegment.Text = "7C0";
            this.txtLoadSegment.Enabled = false;
            // btnOk
            this.btnOk.Location = new System.Drawing.Point(250, 100);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(333, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // BootOptionsForm
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(420, 137);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtLoadSegment);
            this.Controls.Add(this.lblLoadSeg);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBootImage);
            this.Controls.Add(this.chkBootable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BootOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры загрузки";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}