using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

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
                ofd.Multiselect = true;
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.FileNames.Length == 1)
                    {
                        tbMD5Hash.Text = GetMd5Hash(ofd.FileName);

                        tbSha256Hash.Text = Getsha256Hash(ofd.FileName);

                    }
                    else // Begin multiselect files
                    {
                        string message = "It looks like you selected multiple files.\nThis program is able to multi-generate checksums of the selected files and dump them into a file\n\nDo you want to continue?";
                        string title = "Multiselect found!";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            multiselect = true;
                            tbMD5Hash.Enabled = false;
                            tbSha256Hash.Enabled = false;

                            // Add all selected files to list
                            String[] fileNames = ofd.FileNames;
                            if (fileNames.Contains("checksumdump.txt") == true)
                            {

                                //create tmp file named "checksumdump.txt"
                                using (StreamWriter sw = new StreamWriter("checksumdump.txt"))
                                {
                                    sw.WriteLine("Filename | MD5 Hash | SHA256 Hash");
                                    foreach (string fileName in fileNames)
                                    {
                                        String md5hash = GetMd5Hash(fileName);
                                        String sha256hash = Getsha256Hash(fileName);
                                        sw.WriteLine($"{fileName} | {md5hash} | {sha256hash}");
                                    }
                                }

                                // Done message
                                message = "Done!\n\nDo you want to open the file?";
                                title = "Task Done!";
                                buttons = MessageBoxButtons.YesNo;
                                result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {
                                    // open log file with windows notepad
                                    Process.Start("notepad", "checksumdump.txt");
                                    tbMD5Hash.Text = "";
                                    tbSha256Hash.Text = "";
                                }
                                else
                                {
                                    // Path message
                                    message = "The file is located under: " + System.IO.Path.GetDirectoryName(Application.ExecutablePath + "checksumdump.txt"); ;
                                    title = "Information!";
                                    buttons = MessageBoxButtons.OK;
                                    result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                // Error message string list contains dump file
                                message = "Your selected files contains the checksum dump file!\n\nUnselect and try again.";
                                title = "Error!";
                                buttons = MessageBoxButtons.OK;
                                result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

                // no checksum clipboard accordance if multi generation/
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
            catch (Exception ex)
            {
                string message = "Error: " + ex;
                string title = "Fatal Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            }
        }

        private string GetMd5Hash(String filename)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] file = System.IO.File.ReadAllBytes(filename);
                // generate MD5 hash by arguments as string
                byte[] data = md5.ComputeHash(file);
                // convert byte array to string
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }


        private string Getsha256Hash(String filename)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] file = System.IO.File.ReadAllBytes(filename);
                // generate Sha265 Hash by arguments as string
                byte[] data = sha256.ComputeHash(file);
                // convert byte array to string
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
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