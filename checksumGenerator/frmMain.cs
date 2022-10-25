using System;
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


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            ofd.Title = "Select a file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (MD5 md5 = MD5.Create())
                {
                    // read file
                    byte[] file = System.IO.File.ReadAllBytes(ofd.FileName);
                    // generate hash
                    string hash = GetMd5Hash(md5, file);
                    // display hash
                    tbMD5Hash.Text = hash;
                }
                using (SHA256 sha256 = SHA256.Create())
                {
                    // read file
                    byte[] file = System.IO.File.ReadAllBytes(ofd.FileName);
                    // generate hash
                    string hash = Getsha256Hash(sha256, file);
                    // display hash
                    tbSha256Hash.Text = hash;
                }
            }


            /*/
            // create MD5 hash
            using (MD5 md5Hash = MD5.Create())
            {
                // open file dialog
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Title = "Select a file";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // read file
                    byte[] file = System.IO.File.ReadAllBytes(ofd.FileName);
                    // generate hash
                    string hash = GetMd5Hash(md5Hash, file);
                    // display hash
                    tbMD5Hash.Text = hash;
                }
            }
            /*/
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
            Application.Exit();
        }
    }
}
