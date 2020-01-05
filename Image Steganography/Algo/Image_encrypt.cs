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
    public partial class Image_encrypt : UserControl
    {
        public Image_encrypt()
        {
            InitializeComponent();
        }

        private void Image_encrypt_Load(object sender, EventArgs e)
        {
            keytxt.Clear();
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
                    original.ImageLocation = imagelocation;
                }
            }
            catch
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    cover.ImageLocation = imagelocation;
                }
            }
            catch
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Encrpt_Image_Click(object sender, EventArgs e)
        {
            if (original.ImageLocation == "")
            {
                MessageBox.Show("Please select the origanal image.");
                return;
            }
            else if (cover.ImageLocation == "")
            {
                MessageBox.Show("Please select the cover image.");
                return;
            }
            keytxt.Clear();
            CoverImage coverImage = new CoverImage();
            StegoImage stegoImage = new StegoImage();
            String stegoImagePath = new String (original.ImageLocation.Replace(".","stego."));

            var encryption = ImageCyptography.Encrypte(original.ImageLocation);
            keytxt.Text = encryption.Key;
            coverImage.ReadImage(new String(cover.ImageLocation));
            
            if(!coverImage.EmbedData(encryption.Value, (int)FileType.image))  return;
            
            coverImage.SaveImage(stegoImagePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(keytxt.Text);
        }
    }
    
    
}
