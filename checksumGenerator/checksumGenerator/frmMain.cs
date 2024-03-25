using System;
using System.Diagnostics;
using System.Drawing.Text;
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

        // Invoke Delegate Method
        private delegate void SetFrmTitleThreadSafe(string text);
        private delegate void SetCR32TBThreadSafe(string CR32Hash);
        private delegate void SetMD5TBThreadSafe(string MD5Hash);
        private delegate void SetSHA1TBThreadSafe(string SHA1Hash);
        private delegate void SetSHA256TBThreadSafe(string SHA256Hash);


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
            // Start Task for Calculation


            if (File.Exists(tbFilePathOrString.Text))
            {
                // Ask if FileChecksum is wanted
                string message = "Looks like you selected a file.\nDo you want the Checksum of the selected file?";
                string title = "Filepath found!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Initalise new Task
                    Task TCalcChecksums = new Task(() => CalcChecksums(true, pathOrString));
                    // Start Task
                    TCalcChecksums.Start();
                    // Await Task Result
                    TCalcChecksums.Wait();
                    Console.WriteLine("Berechnung Abgeschlossen!");
                }
                else
                {
                    // Initalise new Task
                    Task TCalcChecksums = new Task(() => CalcChecksums(false, pathOrString));
                    // Start Task
                    TCalcChecksums.Start();
                    // Await Task Result
                    TCalcChecksums.Wait();
                    Console.WriteLine("Berechnung Abgeschlossen!");
                }
            }
            else
            {
                // Initalise new Task
                Task TCalcChecksums = new Task(() => CalcChecksums(false, pathOrString));
                // Start Task
                TCalcChecksums.Start();
                // Await Task Result
                TCalcChecksums.Wait();
                Console.WriteLine("Berechnung Abgeschlossen!");

            }
        }

        // CalcChecksums
        private async void CalcChecksums(bool isPath, string pathOrString)
        {
            // Check if Text is Path
            if (isPath)
            {
                // Mark Frm Tilte as Checksum for File
                this.Text = "Hauptformular - Prüfsumme: Datei!";

                // Calc CR32 Hash File in Thread
                Task<string> TCalcCR32HashFile = CalcCR32HashFile(pathOrString);

                // Calc MD5 Hash File in Thread
                Task<string> TCalcMD5HashFile = CalcMD5HashFile(pathOrString);

                // Calc SHA1 Hash File in Thread
                Task<string> TCalcSHA1HashFile = CalcSHA1HashFile(pathOrString);

                // Calc SHA256 Hash File in Thread
                Task<string> TCalcSHA256HashFile = CalcSHA256HashFile(pathOrString);

                // Await Results
                string MD5Sum = await TCalcMD5HashFile;
                string SHA1Sum = await TCalcSHA1HashFile;
                string SHA256Sum = await TCalcSHA256HashFile;
                string CR32Sum = await TCalcCR32HashFile;

                // Set Textboxes
                SetTextbox(CR32Sum, MD5Sum, SHA1Sum, SHA256Sum);

                // Check for Clipboard Accordance
                if (!multiselect) { CheckClipboardAccordance(); }

            }
            // isPath = 0
            else
            {
                
                // Get Encoding Type
                int encoding = 0;  //cbEncoding.SelectedIndex;

                // Mark as Checksum for String
                this.Text = "Hauptformular - Prüfsumme: Zeichenkette!";
                

                // Calc CR32 Hash File in Thread
                Task<string> TCalcCR32HashFile = CalcCR32HashString(pathOrString, encoding);

                // Calc MD5 Hash File in Thread
                Task<string> TCalcMD5HashFile = CalcMD5HashString(pathOrString, encoding);

                // Calc SHA1 Hash File in Thread
                Task<string> TCalcSHA1HashFile = CalcSHA1HashString(pathOrString, encoding);

                // Calc SHA256 Hash File in Thread
                Task<string> TCalcSHA256HashFile = CalcSHA256HashString(pathOrString, encoding);

                // Await Results
                string MD5Sum = await TCalcMD5HashFile;
                string SHA1Sum = await TCalcSHA1HashFile;
                string SHA256Sum = await TCalcSHA256HashFile;
                string CR32Sum = await TCalcCR32HashFile;

                // Set Textboxes
                SetTextbox(CR32Sum, MD5Sum, SHA1Sum, SHA256Sum);

                // Check for Clipboard Accordance
                if (!multiselect) { CheckClipboardAccordance(); }
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
        // Set Textboxes
        private void SetTextbox(string CR32Sum, string MD5Sum, string SHA1Sum, string SHA256Sum)
        {
            // Set Textboxes
            tbCR32Hash.Text = CR32Sum;
            tbMD5Hash.Text = MD5Sum;
            tbSha1Hash.Text = SHA1Sum;
            tbSha256Hash.Text = SHA256Sum;
        }



        // Calc Methods String
        // ADD Encoding Option
        private async Task<string> CalcCR32HashString(string String, int encodingType)
        {
            string s = "N/A";
            return await Task<string>.FromResult(s);
        }
        private async Task<string> CalcMD5HashString(string String, int encodingType)
        {
            using (MD5 md5 = MD5.Create())
            {
                // Calc Byte from String
                byte[] bytestring;
                switch (encodingType)
                {
                    default: // ASCII
                        {
                            bytestring = Encoding.ASCII.GetBytes(String);
                            break;
                        }
                    case (1):
                        {
                            bytestring = Encoding.Unicode.GetBytes(String);
                            break;
                        }
                    case (2):
                        {
                            bytestring = Encoding.UTF8.GetBytes(String);
                            break;
                        }
                    case (3):
                        {
                            bytestring = Encoding.UTF32.GetBytes(String);
                            break;
                        }
                }
                // generate MD5 hash by arguments as string
                byte[] data = md5.ComputeHash(bytestring);
                // convert byte array to string
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                string s = sBuilder.ToString();
                return await Task<string>.FromResult(s);
            }
        }
        private async Task<string> CalcSHA1HashString(string String, int encodingType)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                // Calc Byte from String
                byte[] bytestring;
                switch (encodingType)
                {
                    default: // ASCII
                        {
                            bytestring = Encoding.ASCII.GetBytes(String);
                            break;
                        }
                    case (1):
                        {
                            bytestring = Encoding.Unicode.GetBytes(String);
                            break;
                        }
                    case (2):
                        {
                            bytestring = Encoding.UTF8.GetBytes(String);
                            break;
                        }
                    case (3):
                        {
                            bytestring = Encoding.UTF32.GetBytes(String);
                            break;
                        }
                }
                // generate M5 hash by arguments as string
                byte[] data = sha1.ComputeHash(bytestring);
                // convert byte array to string
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                string s = sBuilder.ToString();
                return await Task<string>.FromResult(s);
            }
        }
        private async Task<string> CalcSHA256HashString(string String, int encodingType)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Calc Byte from String
                byte[] bytestring;
                switch (encodingType)
                {
                    default: // ASCII
                        {
                            bytestring = Encoding.ASCII.GetBytes(String);
                            break;
                        }
                    case (1):
                        {
                            bytestring = Encoding.Unicode.GetBytes(String);
                            break;
                        }
                    case (2):
                        {
                            bytestring = Encoding.UTF8.GetBytes(String);
                            break;
                        }
                    case (3):
                        {
                            bytestring = Encoding.UTF32.GetBytes(String);
                            break;
                        }
                }
                // generate Sha265 Hash by arguments as string
                byte[] data = sha256.ComputeHash(bytestring);
                // convert byte array to string
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                string s = sBuilder.ToString();
                return await Task<string>.FromResult(s);
            }
        }

        // Calc Methods File
        private async Task<string> CalcCR32HashFile(string filename)
        {
            string s = "N/A";
            return await Task<string>.FromResult(s);
        }
        private async Task<string> CalcMD5HashFile(string filename)
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
                string s = sBuilder.ToString();
                return await Task<string>.FromResult(s);
            }
        }
        private async Task<string> CalcSHA1HashFile(string filename)
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
                string s = sBuilder.ToString();
                return await Task<string>.FromResult(s);
            }
        }
        private async Task<string> CalcSHA256HashFile(string filename)
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
                string s = sBuilder.ToString();
                return await Task<string>.FromResult(s);
            }
        }


        // Multiselect
        /*private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                // activate textboxes
                tbCR32Hash.Enabled = true;
                tbMD5Hash.Enabled = true;
                tbSha256Hash.Enabled = true;
                tbSha1Hash.Enabled = true;
                multiselect = false;

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
        }*/

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