namespace _90SISO
{
    partial class UsbSelectForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewDrives;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.ColumnHeader colModel;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.Label lblWarning;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listViewDrives = new System.Windows.Forms.ListView();
            this.colIndex = new System.Windows.Forms.ColumnHeader();
            this.colModel = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // listViewDrives
            this.listViewDrives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colIndex, this.colModel, this.colSize});
            this.listViewDrives.FullRowSelect = true;
            this.listViewDrives.GridLines = true;
            this.listViewDrives.HideSelection = false;
            this.listViewDrives.Location = new System.Drawing.Point(12, 12);
            this.listViewDrives.MultiSelect = false;
            this.listViewDrives.Name = "listViewDrives";
            this.listViewDrives.Size = new System.Drawing.Size(560, 220);
            this.listViewDrives.TabIndex = 0;
            this.listViewDrives.UseCompatibleStateImageBehavior = false;
            this.listViewDrives.View = System.Windows.Forms.View.Details;
            this.listViewDrives.DoubleClick += new System.EventHandler(this.listViewDrives_DoubleClick);
            // colIndex
            this.colIndex.Text = "PhysicalDrive";
            this.colIndex.Width = 110;
            // colModel
            this.colModel.Text = "Модель";
            this.colModel.Width = 320;
            // colSize
            this.colSize.Text = "Размер";
            this.colSize.Width = 100;
            // lblWarning
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.DarkRed;
            this.lblWarning.Location = new System.Drawing.Point(12, 240);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(400, 13);
            this.lblWarning.Text = "ВНИМАНИЕ: все данные на выбранном диске будут уничтожены!";
            // btnOk
            this.btnOk.Location = new System.Drawing.Point(400, 265);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 28);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Записать";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(490, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // UsbSelectForm
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 305);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.listViewDrives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsbSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор USB-диска";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}