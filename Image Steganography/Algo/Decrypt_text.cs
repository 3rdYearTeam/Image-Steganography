using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Steganography
{
    public partial class Decrypt_text : UserControl
    {
        public Decrypt_text()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonbrowse_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*,*)|*,*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                    picture3.ImageLocation = imagelocation;
                }
            }
            catch
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("please enter a key");
                return;
            }
            if (picture3.ImageLocation == "")
            {
                MessageBox.Show("Please select the encrypted image");
                return;
            }
            label1.Text = "";
            string key = textBox2.Text.ToString();
            string path = picture3.ImageLocation;
            string original_text;
            StegoImage cv = new StegoImage();
            cv.ReadImage(new String(path));
            var et = cv.GetData();
            original_text = RSA.RSADecryption(et, new String(key)).ToString();
            label1.Text = original_text.ToString();
        }

        private void Decrypt_text_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
