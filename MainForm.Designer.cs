namespace _90SISO
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpBuild;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtOutputIso;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.TextBox txtVolumeLabel;
        private System.Windows.Forms.CheckBox chkJoliet;
        private System.Windows.Forms.CheckBox chkBootable;
        private System.Windows.Forms.Button btnBuildIso;

        private System.Windows.Forms.GroupBox grpIsoActions;
        private System.Windows.Forms.Button btnExtractIso;
        private System.Windows.Forms.Button btnEditIso;
        private System.Windows.Forms.Button btnWriteUsb;
        private System.Windows.Forms.Button btnMountIso;

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;

        // Новые элементы
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.LinkLabel linkAbout;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpBuild = new System.Windows.Forms.GroupBox();
            this.btnBuildIso = new System.Windows.Forms.Button();
            this.chkBootable = new System.Windows.Forms.CheckBox();
            this.chkJoliet = new System.Windows.Forms.CheckBox();
            this.txtVolumeLabel = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.txtOutputIso = new System.Windows.Forms.TextBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.grpIsoActions = new System.Windows.Forms.GroupBox();
            this.btnMountIso = new System.Windows.Forms.Button();
            this.btnWriteUsb = new System.Windows.Forms.Button();
            this.btnEditIso = new System.Windows.Forms.Button();
            this.btnExtractIso = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.linkAbout = new System.Windows.Forms.LinkLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBuild.SuspendLayout();
            this.grpIsoActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBuild
            // 
            this.grpBuild.Controls.Add(this.btnBuildIso);
            this.grpBuild.Controls.Add(this.chkBootable);
            this.grpBuild.Controls.Add(this.chkJoliet);
            this.grpBuild.Controls.Add(this.txtVolumeLabel);
            this.grpBuild.Controls.Add(this.btnBrowseOutput);
            this.grpBuild.Controls.Add(this.txtOutputIso);
            this.grpBuild.Controls.Add(this.btnBrowseSource);
            this.grpBuild.Controls.Add(this.txtSourceFolder);
            this.grpBuild.Location = new System.Drawing.Point(12, 85);
            this.grpBuild.Name = "grpBuild";
            this.grpBuild.Size = new System.Drawing.Size(560, 160);
            this.grpBuild.TabIndex = 0;
            this.grpBuild.TabStop = false;
            this.grpBuild.Text = "Создание ISO";
            // 
            // btnBuildIso
            // 
            this.btnBuildIso.Location = new System.Drawing.Point(10, 115);
            this.btnBuildIso.Name = "btnBuildIso";
            this.btnBuildIso.Size = new System.Drawing.Size(200, 35);
            this.btnBuildIso.TabIndex = 0;
            this.btnBuildIso.Text = "Собрать ISO";
            this.btnBuildIso.Click += new System.EventHandler(this.btnBuildIso_Click);
            // 
            // chkBootable
            // 
            this.chkBootable.AutoSize = true;
            this.chkBootable.Location = new System.Drawing.Point(320, 87);
            this.chkBootable.Name = "chkBootable";
            this.chkBootable.Size = new System.Drawing.Size(140, 17);
            this.chkBootable.TabIndex = 1;
            this.chkBootable.Text = "Загрузочный (El Torito)";
            // 
            // chkJoliet
            // 
            this.chkJoliet.AutoSize = true;
            this.chkJoliet.Checked = true;
            this.chkJoliet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJoliet.Location = new System.Drawing.Point(230, 87);
            this.chkJoliet.Name = "chkJoliet";
            this.chkJoliet.Size = new System.Drawing.Size(50, 17);
            this.chkJoliet.TabIndex = 2;
            this.chkJoliet.Text = "Joliet";
            // 
            // txtVolumeLabel
            // 
            this.txtVolumeLabel.Location = new System.Drawing.Point(10, 85);
            this.txtVolumeLabel.Name = "txtVolumeLabel";
            this.txtVolumeLabel.Size = new System.Drawing.Size(200, 20);
            this.txtVolumeLabel.TabIndex = 3;
            this.txtVolumeLabel.Text = "ISO_TOOL";
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(516, 53);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseOutput.TabIndex = 4;
            this.btnBrowseOutput.Text = "...";
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtOutputIso
            // 
            this.txtOutputIso.Location = new System.Drawing.Point(10, 55);
            this.txtOutputIso.Name = "txtOutputIso";
            this.txtOutputIso.Size = new System.Drawing.Size(500, 20);
            this.txtOutputIso.TabIndex = 5;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(516, 23);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseSource.TabIndex = 6;
            this.btnBrowseSource.Text = "...";
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(10, 25);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.ReadOnly = true;
            this.txtSourceFolder.Size = new System.Drawing.Size(500, 20);
            this.txtSourceFolder.TabIndex = 7;
            // 
            // grpIsoActions
            // 
            this.grpIsoActions.Controls.Add(this.btnMountIso);
            this.grpIsoActions.Controls.Add(this.btnWriteUsb);
            this.grpIsoActions.Controls.Add(this.btnEditIso);
            this.grpIsoActions.Controls.Add(this.btnExtractIso);
            this.grpIsoActions.Location = new System.Drawing.Point(12, 255);
            this.grpIsoActions.Name = "grpIsoActions";
            this.grpIsoActions.Size = new System.Drawing.Size(560, 90);
            this.grpIsoActions.TabIndex = 1;
            this.grpIsoActions.TabStop = false;
            this.grpIsoActions.Text = "Действия с ISO";
            // 
            // btnMountIso
            // 
            this.btnMountIso.Location = new System.Drawing.Point(430, 25);
            this.btnMountIso.Name = "btnMountIso";
            this.btnMountIso.Size = new System.Drawing.Size(120, 50);
            this.btnMountIso.TabIndex = 0;
            this.btnMountIso.Text = "Смонтировать";
            this.btnMountIso.Click += new System.EventHandler(this.btnMountIso_Click);
            // 
            // btnWriteUsb
            // 
            this.btnWriteUsb.Location = new System.Drawing.Point(290, 25);
            this.btnWriteUsb.Name = "btnWriteUsb";
            this.btnWriteUsb.Size = new System.Drawing.Size(130, 50);
            this.btnWriteUsb.TabIndex = 1;
            this.btnWriteUsb.Text = "Записать на USB";
            this.btnWriteUsb.Click += new System.EventHandler(this.btnWriteUsb_Click);
            // 
            // btnEditIso
            // 
            this.btnEditIso.Location = new System.Drawing.Point(150, 25);
            this.btnEditIso.Name = "btnEditIso";
            this.btnEditIso.Size = new System.Drawing.Size(130, 50);
            this.btnEditIso.TabIndex = 2;
            this.btnEditIso.Text = "Редактировать";
            this.btnEditIso.Click += new System.EventHandler(this.btnEditIso_Click);
            // 
            // btnExtractIso
            // 
            this.btnExtractIso.Location = new System.Drawing.Point(10, 25);
            this.btnExtractIso.Name = "btnExtractIso";
            this.btnExtractIso.Size = new System.Drawing.Size(130, 50);
            this.btnExtractIso.TabIndex = 3;
            this.btnExtractIso.Text = "Распаковать";
            this.btnExtractIso.Click += new System.EventHandler(this.btnExtractIso_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 360);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(560, 20);
            this.progressBar.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 390);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Готово";
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(508, 5);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(64, 64);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            this.picLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.picLogo_Paint);
            // 
            // linkAbout
            // 
            this.linkAbout.AutoSize = true;
            this.linkAbout.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkAbout.Location = new System.Drawing.Point(505, 72);
            this.linkAbout.Name = "linkAbout";
            this.linkAbout.Size = new System.Drawing.Size(75, 13);
            this.linkAbout.TabIndex = 2;
            this.linkAbout.TabStop = true;
            this.linkAbout.Text = "О программе";
            this.linkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "90SISO";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(584, 415);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.linkAbout);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.grpIsoActions);
            this.Controls.Add(this.grpBuild);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "90SISO — Ultimate UltraISO Clone";
            this.grpBuild.ResumeLayout(false);
            this.grpBuild.PerformLayout();
            this.grpIsoActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}