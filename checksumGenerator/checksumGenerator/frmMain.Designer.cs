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
            this.lblSha256CheckSum = new System.Windows.Forms.Label();
            this.tbSha256Hash = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSha1Checksum = new System.Windows.Forms.Label();
            this.tbSha1Hash = new System.Windows.Forms.TextBox();
            this.tbFilePathOrString = new System.Windows.Forms.TextBox();
            this.lblFilePathOrString = new System.Windows.Forms.Label();
            this.tbCR32Hash = new System.Windows.Forms.TextBox();
            this.lblCR32Cecksum = new System.Windows.Forms.Label();
            this.cbEncoding = new System.Windows.Forms.ComboBox();
            this.lblEncoding = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMD5Checksum
            // 
            this.lblMD5Checksum.AutoSize = true;
            this.lblMD5Checksum.Location = new System.Drawing.Point(14, 117);
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
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenFile.Location = new System.Drawing.Point(12, 202);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(93, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Datei(en) öffnen";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbMD5Hash
            // 
            this.tbMD5Hash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMD5Hash.Location = new System.Drawing.Point(123, 114);
            this.tbMD5Hash.Name = "tbMD5Hash";
            this.tbMD5Hash.Size = new System.Drawing.Size(491, 20);
            this.tbMD5Hash.TabIndex = 2;
            // 
            // lblSha256CheckSum
            // 
            this.lblSha256CheckSum.AutoSize = true;
            this.lblSha256CheckSum.Location = new System.Drawing.Point(14, 143);
            this.lblSha256CheckSum.Name = "lblSha256CheckSum";
            this.lblSha256CheckSum.Size = new System.Drawing.Size(103, 13);
            this.lblSha256CheckSum.TabIndex = 4;
            this.lblSha256CheckSum.Text = "SHA256 Checksum:";
            // 
            // tbSha256Hash
            // 
            this.tbSha256Hash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSha256Hash.Location = new System.Drawing.Point(123, 140);
            this.tbSha256Hash.Name = "tbSha256Hash";
            this.tbSha256Hash.Size = new System.Drawing.Size(491, 20);
            this.tbSha256Hash.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(538, 202);
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
            this.lblSha1Checksum.Location = new System.Drawing.Point(14, 169);
            this.lblSha1Checksum.Name = "lblSha1Checksum";
            this.lblSha1Checksum.Size = new System.Drawing.Size(91, 13);
            this.lblSha1Checksum.TabIndex = 7;
            this.lblSha1Checksum.Text = "SHA1 Checksum:";
            // 
            // tbSha1Hash
            // 
            this.tbSha1Hash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSha1Hash.Location = new System.Drawing.Point(123, 166);
            this.tbSha1Hash.Name = "tbSha1Hash";
            this.tbSha1Hash.Size = new System.Drawing.Size(491, 20);
            this.tbSha1Hash.TabIndex = 8;
            // 
            // tbFilePathOrString
            // 
            this.tbFilePathOrString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilePathOrString.Location = new System.Drawing.Point(123, 17);
            this.tbFilePathOrString.Name = "tbFilePathOrString";
            this.tbFilePathOrString.Size = new System.Drawing.Size(491, 20);
            this.tbFilePathOrString.TabIndex = 10;
            this.tbFilePathOrString.TextChanged += new System.EventHandler(this.tbFilePathOrString_TextChanged);
            // 
            // lblFilePathOrString
            // 
            this.lblFilePathOrString.AutoSize = true;
            this.lblFilePathOrString.Location = new System.Drawing.Point(14, 20);
            this.lblFilePathOrString.Name = "lblFilePathOrString";
            this.lblFilePathOrString.Size = new System.Drawing.Size(94, 13);
            this.lblFilePathOrString.TabIndex = 9;
            this.lblFilePathOrString.Text = "Dateipfad / String:";
            // 
            // tbCR32Hash
            // 
            this.tbCR32Hash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCR32Hash.Location = new System.Drawing.Point(123, 88);
            this.tbCR32Hash.Name = "tbCR32Hash";
            this.tbCR32Hash.Size = new System.Drawing.Size(491, 20);
            this.tbCR32Hash.TabIndex = 12;
            // 
            // lblCR32Cecksum
            // 
            this.lblCR32Cecksum.AutoSize = true;
            this.lblCR32Cecksum.Location = new System.Drawing.Point(14, 91);
            this.lblCR32Cecksum.Name = "lblCR32Cecksum";
            this.lblCR32Cecksum.Size = new System.Drawing.Size(90, 13);
            this.lblCR32Cecksum.TabIndex = 11;
            this.lblCR32Cecksum.Text = "CR32 Checksum:";
            // 
            // cbEncoding
            // 
            this.cbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEncoding.FormattingEnabled = true;
            this.cbEncoding.Items.AddRange(new object[] {
            "ASCII",
            "Unicode",
            "UTF8",
            "UTF32"});
            this.cbEncoding.Location = new System.Drawing.Point(123, 44);
            this.cbEncoding.Name = "cbEncoding";
            this.cbEncoding.Size = new System.Drawing.Size(490, 21);
            this.cbEncoding.TabIndex = 13;
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.Location = new System.Drawing.Point(14, 47);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(55, 13);
            this.lblEncoding.TabIndex = 14;
            this.lblEncoding.Text = "Encoding:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 233);
            this.Controls.Add(this.lblEncoding);
            this.Controls.Add(this.cbEncoding);
            this.Controls.Add(this.tbCR32Hash);
            this.Controls.Add(this.lblCR32Cecksum);
            this.Controls.Add(this.tbFilePathOrString);
            this.Controls.Add(this.lblFilePathOrString);
            this.Controls.Add(this.tbSha1Hash);
            this.Controls.Add(this.lblSha1Checksum);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbSha256Hash);
            this.Controls.Add(this.lblSha256CheckSum);
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
        private System.Windows.Forms.Label lblSha256CheckSum;
        private System.Windows.Forms.TextBox tbSha256Hash;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSha1Checksum;
        private System.Windows.Forms.TextBox tbSha1Hash;
        private System.Windows.Forms.TextBox tbFilePathOrString;
        private System.Windows.Forms.Label lblFilePathOrString;
        private System.Windows.Forms.TextBox tbCR32Hash;
        private System.Windows.Forms.Label lblCR32Cecksum;
        private System.Windows.Forms.ComboBox cbEncoding;
        private System.Windows.Forms.Label lblEncoding;
    }
}

