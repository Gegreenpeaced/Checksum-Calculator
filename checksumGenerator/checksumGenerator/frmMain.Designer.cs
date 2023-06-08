namespace checksumGenerator
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblMD5Checksum = new System.Windows.Forms.Label();
            this.ofdMD5Checksum = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbMD5Hash = new System.Windows.Forms.TextBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblSha256CheckSum = new System.Windows.Forms.Label();
            this.tbSha256Hash = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSha1Checksum = new System.Windows.Forms.Label();
            this.tbSha1Hash = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMD5Checksum
            // 
            this.lblMD5Checksum.AutoSize = true;
            this.lblMD5Checksum.Location = new System.Drawing.Point(13, 13);
            this.lblMD5Checksum.Name = "lblMD5Checksum";
            this.lblMD5Checksum.Size = new System.Drawing.Size(86, 13);
            this.lblMD5Checksum.TabIndex = 0;
            this.lblMD5Checksum.Text = "MD5 Checksum:";
            // 
            // ofdMD5Checksum
            // 
            this.ofdMD5Checksum.FileName = "openFileDialog1";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 104);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Datei öffnen";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbMD5Hash
            // 
            this.tbMD5Hash.Location = new System.Drawing.Point(122, 10);
            this.tbMD5Hash.Name = "tbMD5Hash";
            this.tbMD5Hash.Size = new System.Drawing.Size(491, 20);
            this.tbMD5Hash.TabIndex = 2;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(93, 104);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // lblSha256CheckSum
            // 
            this.lblSha256CheckSum.AutoSize = true;
            this.lblSha256CheckSum.Location = new System.Drawing.Point(13, 39);
            this.lblSha256CheckSum.Name = "lblSha256CheckSum";
            this.lblSha256CheckSum.Size = new System.Drawing.Size(103, 13);
            this.lblSha256CheckSum.TabIndex = 4;
            this.lblSha256CheckSum.Text = "SHA256 Checksum:";
            // 
            // tbSha256Hash
            // 
            this.tbSha256Hash.Location = new System.Drawing.Point(122, 36);
            this.tbSha256Hash.Name = "tbSha256Hash";
            this.tbSha256Hash.Size = new System.Drawing.Size(491, 20);
            this.tbSha256Hash.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(538, 102);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSha1Checksum
            // 
            this.lblSha1Checksum.AutoSize = true;
            this.lblSha1Checksum.Location = new System.Drawing.Point(13, 65);
            this.lblSha1Checksum.Name = "lblSha1Checksum";
            this.lblSha1Checksum.Size = new System.Drawing.Size(91, 13);
            this.lblSha1Checksum.TabIndex = 7;
            this.lblSha1Checksum.Text = "SHA1 Checksum:";
            // 
            // tbSha1Hash
            // 
            this.tbSha1Hash.Location = new System.Drawing.Point(122, 62);
            this.tbSha1Hash.Name = "tbSha1Hash";
            this.tbSha1Hash.Size = new System.Drawing.Size(491, 20);
            this.tbSha1Hash.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 137);
            this.Controls.Add(this.tbSha1Hash);
            this.Controls.Add(this.lblSha1Checksum);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbSha256Hash);
            this.Controls.Add(this.lblSha256CheckSum);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.tbMD5Hash);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.lblMD5Checksum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Hauptformular";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMD5Checksum;
        private System.Windows.Forms.OpenFileDialog ofdMD5Checksum;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox tbMD5Hash;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblSha256CheckSum;
        private System.Windows.Forms.TextBox tbSha256Hash;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSha1Checksum;
        private System.Windows.Forms.TextBox tbSha1Hash;
    }
}

