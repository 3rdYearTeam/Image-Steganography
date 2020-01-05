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
    public partial class Image_Dec : UserControl
    {
        public Image_Dec()
        {
            InitializeComponent();
        }

        private void buttonbrowse_Image2_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*,*)|*,*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                    stego.ImageLocation = imagelocation;
                }
            }
            catch
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonbrowse_Image_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*,*)|*,*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                    originalimage.ImageLocation = imagelocation;
                }
            }
            catch
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Image_Dec_Load(object sender, EventArgs e)
        {

        }

        private void Decrypt_Image_Click(object sender, EventArgs e)
        {

            string key = keytxt.Text;
            StegoImage stegoImage = new StegoImage();
            stegoImage.ReadImage(new String (stego.ImageLocation));
            var encryptedData = stegoImage.GetData();
            string new_path = stego.ImageLocation.Replace("stego", "original");
            var path = (string)File.GetCorrespondingData(encryptedData, FileType.image, key, new_path);
            originalimage.ImageLocation = path;
        }
    }
}
