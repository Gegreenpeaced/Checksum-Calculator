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
            this.lblChecksum = new System.Windows.Forms.Label();
            this.ofdMD5Checksum = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbHash = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblChecksum
            // 
            this.lblChecksum.AutoSize = true;
            this.lblChecksum.Location = new System.Drawing.Point(13, 13);
            this.lblChecksum.Name = "lblChecksum";
            this.lblChecksum.Size = new System.Drawing.Size(86, 13);
            this.lblChecksum.TabIndex = 0;
            this.lblChecksum.Text = "MD5 Checksum:";
            // 
            // ofdMD5Checksum
            // 
            this.ofdMD5Checksum.FileName = "openFileDialog1";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(13, 54);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Datei öffnen";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tbHash
            // 
            this.tbHash.Location = new System.Drawing.Point(105, 10);
            this.tbHash.Name = "tbHash";
            this.tbHash.Size = new System.Drawing.Size(222, 20);
            this.tbHash.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 101);
            this.Controls.Add(this.tbHash);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.lblChecksum);
            this.Name = "frmMain";
            this.Text = "Hauptformular";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChecksum;
        private System.Windows.Forms.OpenFileDialog ofdMD5Checksum;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox tbHash;
    }
}

