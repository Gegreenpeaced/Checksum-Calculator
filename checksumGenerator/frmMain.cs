using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace checksumGenerator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public bool multiselect = false;

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                // activate textboxes
                tbMD5Hash.Enabled = true;
                tbSha256Hash.Enabled = true;

                // open file dialog
                OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Multiselect = true;
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file";
                if (ofd.FileNames.Length == 1)
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (MD5 md5 = MD5.Create())
                        {
                            // read file
                            byte[] file = System.IO.File.ReadAllBytes(ofd.FileName);
                            // generate hash
                            string md5hash = GetMd5Hash(md5, file);
                            // display hash
                            tbMD5Hash.Text = md5hash;
                        }
                        using (SHA256 sha256 = SHA256.Create())
                        {
                            // read file
                            byte[] file = System.IO.File.ReadAllBytes(ofd.FileName);
                            // generate hash
                            string sha256hash = Getsha256Hash(sha256, file);
                            // display hash
                            tbSha256Hash.Text = sha256hash;
                        }
                    }
                }
                /*/else // Begin multiselect files
                {
                    string message = "It looks like you selected multiple files.\nThis program is able to multi-generate checksums of the selected files\nand dump them into a file\n\nDo you want to continue?";
                    string title = "Multiselect found!";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        multiselect = true;
                        tbMD5Hash.Enabled = false;
                        tbSha256Hash.Enabled = false;

                        // Add all selected files to list
                        SelectedFiles[] sf = ofd.FileNames;

                        //create tmp file named "checksumdump.txt"
                        using (StreamWriter sw = new StreamWriter("checksumdump.txt"))
                        {
                            foreach()
                        }
                        
                    }
                }
                // no checksum clipboard accordance if multi generation/*/
                if (multiselect != true)
                {

                    // Compare Checksums to clipboard
                    if (Clipboard.ContainsText(TextDataFormat.Text))
                    {
                        {
                            string clipboardText = Clipboard.GetText(TextDataFormat.Text);

                            if (clipboardText == tbMD5Hash.Text)
                            {
                                string message = "MD5-Hash is eqal to clipboard!";
                                string title = "Accordance found!";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                            }
                            if (clipboardText == tbSha256Hash.Text)
                            {
                                string message = "SHA256-Hash is eqal to clipboard!";
                                string title = "Accordance found!";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                string message = "Error: " + ex;
                string title = "Fatal Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            }
        }

        private string GetMd5Hash(MD5 md5Hash, byte[] file)
        {
            // generate MD5 hash by arguments as string
            byte[] data = md5Hash.ComputeHash(file);
            // convert byte array to string
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }


        private string Getsha256Hash(SHA256 sha256hash, byte[] file)
        {
            // generate Sha265 Hash by arguments as string
            byte[] data = sha256hash.ComputeHash(file);
            // convert byte array to string
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string message = "Do you really want to close the application?";
            string title = "Close Application?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
