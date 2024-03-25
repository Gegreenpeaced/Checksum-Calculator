using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checksumGenerator
{
    public partial class frmMain : Form
    {
        // Pub Vars
        public bool multiselect;


        public frmMain()
        {
            InitializeComponent();
            // Preselect ASCII
            cbEncoding.SelectedIndex = 0;
            multiselect = false;
        }

        // On Update Method
        private void tbFilePathOrString_TextChanged(object sender, EventArgs e)
        {
            string pathOrString = tbFilePathOrString.Text;
            string[] resultSum;
            if (File.Exists(tbFilePathOrString.Text))
            {
                // Ask if FileChecksum is wanted
                string message = "Looks like you selected a file.\nDo you want the Checksum of the selected file?";
                string title = "Filepath found!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Get File Checksum
                    resultSum = CalcChecksums(true, pathOrString);
                }
                else
                {
                    // Get String Checksum
                    resultSum = CalcChecksums(false, pathOrString);
                }
            }
            else
            {
                resultSum = CalcChecksums(false, pathOrString);

            }

            // Update Textboxes
            tbCR32Hash.Text = resultSum[0];
            tbMD5Hash.Text = resultSum[1];
            tbSha1Hash.Text = resultSum[2];
            tbSha256Hash.Text = resultSum[3];

            // Check for Clipboard Accordance
            if (!multiselect)
            {
                CheckClipboardAccordance();
            }

        }

        // CalcChecksums

        /// ADD Encoding Parameter
        private string[] CalcChecksums(bool isPath, string pathOrString)
        {
            if (isPath)
            {
                string[] returnstring = { CalcCR32HashFile(pathOrString), CalcMD5HashFile(pathOrString), CalcSHA1HashFile(pathOrString), CalcSHA256HashFile(pathOrString) };
                this.Text = "Hauptformular - Prüfsumme: Datei!";
                return returnstring;
            }
            // isPath = 0
            else
            {
                /// ADD Multithreading
                /// 
                // Get Encoding Type
                string encoding;
                switch (cbEncoding.SelectedIndex)
                {
                    default:
                        {
                            encoding = "ASCII";
                            break;
                        }
                    case 1:
                        {
                            encoding = "Unicode";
                            break;
                        }
                    case 2:
                        {
                            encoding = "UTF8";
                            break;
                        }
                    case 3:
                        {
                            encoding = "UTF16";
                            break;
                        }
                }

                // Build String
                string[] returnstring = { CalcCR32HashString(pathOrString, encoding), CalcMD5HashString(pathOrString, encoding), CalcSHA1HashString(pathOrString, encoding), CalcSHA256HashString(pathOrString, encoding) };
                this.Text = "Hauptformular - Prüfsumme: String!";
                return returnstring;
            }
        }

        // Check Clipboard Method
        private void CheckClipboardAccordance()
        {
            // Compare Checksums to clipboard
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                {
                    string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                    if (clipboardText == tbCR32Hash.Text)
                    {
                        string message = "CR32-Hash is eqal to clipboard!";
                        string title = "Accordance found!";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                    }
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
                    if (clipboardText == tbSha1Hash.Text)
                    {
                        string message = "SHA1-Hash is eqal to clipboard!";
                        string title = "Accordance found!";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // Calc Methods String
        // ADD Encoding Option
        private string CalcCR32HashString(string String, string encodingType)
        {
            return "N/A";
        }
        private string CalcMD5HashString(string String, string encodingType)
        {
            using (MD5 md5 = MD5.Create())
            {
                // Calc Byte from String
                byte[] bytestring = Encoding.ASCII.GetBytes(String);
                // generate MD5 hash by arguments as string
                byte[] data = md5.ComputeHash(bytestring);
                // convert byte array to string
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        private string CalcSHA1HashString(string String, string encodingType)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                // Calc Byte from String
                byte[] bytestring = Encoding.ASCII.GetBytes(String);
                // generate M5 hash by arguments as string
                byte[] data = sha1.ComputeHash(bytestring);
                // convert byte array to string
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        private string CalcSHA256HashString(string String, string encodingType)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Calc Byte from String
                byte[] bytestring = Encoding.ASCII.GetBytes(String);
                // generate Sha265 Hash by arguments as string
                byte[] data = sha256.ComputeHash(bytestring);
                // convert byte array to string
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        // Calc Methods File
        private string CalcCR32HashFile(string filename)
        {
            return "N/A";
        }
        private string CalcMD5HashFile(string filename)
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
        private string CalcSHA1HashFile(string filename)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] file = System.IO.File.ReadAllBytes(filename);
                // generate M5 hash by arguments as string
                byte[] data = sha1.ComputeHash(file);
                // convert byte array to string
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        private string CalcSHA256HashFile(string filename)
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


        // Multiselect
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                // activate textboxes
                tbCR32Hash.Enabled = true;
                tbMD5Hash.Enabled = true;
                tbSha256Hash.Enabled = true;
                tbSha1Hash.Enabled = true;
                bool multiselect = false;

                // open file dialog
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = true;
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.FileNames.Length == 1)
                    {
                        tbCR32Hash.Text = "N/A";

                        tbMD5Hash.Text = CalcMD5HashFile(ofd.FileName);

                        tbSha256Hash.Text = CalcSHA256HashFile(ofd.FileName);

                        tbSha1Hash.Text = CalcSHA1HashFile(ofd.FileName);

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
                            tbCR32Hash.Enabled = false;
                            tbMD5Hash.Enabled = false;
                            tbSha256Hash.Enabled = false;
                            tbSha1Hash.Enabled = false;

                            // Add all selected files to list
                            String[] fileNames = ofd.FileNames;
                            string dumpfilename = "checksumdump.txt";

                            //if (fileNames.Any(dumpfilename.Contains))
                            //{

                            //create tmp file named "checksumdump.txt"
                            using (StreamWriter sw = new StreamWriter(dumpfilename))
                            {
                                sw.WriteLine("Filename | CR32 | MD5 Hash | SHA256 Hash | SHA1 Hash");
                                foreach (string fileName in fileNames)
                                {
                                    String cr32hash = "N/A";
                                    String md5hash = CalcMD5HashFile(fileName);
                                    String sha256hash = CalcSHA256HashFile(fileName);
                                    String sha1hash = CalcSHA1HashFile(fileName);
                                    sw.WriteLine($"{fileName} | {cr32hash} | {md5hash} | {sha256hash} | {sha1hash}");
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
                                Process.Start("notepad", dumpfilename);
                            }
                            else
                            {
                                // Path message
                                message = "The file is located under: " + System.IO.Path.GetDirectoryName(Application.ExecutablePath + dumpfilename); ;
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
                        // clear Textboxes
                        tbCR32Hash.Text = "";
                        tbMD5Hash.Text = "";
                        tbSha256Hash.Text = "";
                        tbSha1Hash.Text = "";
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