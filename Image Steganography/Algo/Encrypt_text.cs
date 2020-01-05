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
    public partial class Encrypt_text : UserControl
    {
        public Encrypt_text()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                    picture2.ImageLocation = imagelocation;
                }
            }
            catch
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Encrpt_text_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("please enter a text to encrypt");
                return;
            }
            if(picture2.ImageLocation == "")
            {
                MessageBox.Show("Please select an image");
                return;
            }
            label2.Text = "";
            string txt = textBox1.Text.ToString();
            string path = picture2.ImageLocation;
            string key;
            CoverImage cv = new CoverImage();
            //path = path.Replace("jpg", "png");
            //cv.SaveImage(new String(path));

            cv.ReadImage(new String(path));
            var enc = RSA.RSAEncryption(new String(txt));
            key = enc.Key.ToString();
            cv.EmbedData(enc.Value, (int)FileType.text);
            path = path.Replace(".", "cover.");
            cv.SaveImage(new String(path));
            
            label2.Text = key;
        }

        private void Encrypt_text_Load(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(label2.Text);
        }
    }
}
