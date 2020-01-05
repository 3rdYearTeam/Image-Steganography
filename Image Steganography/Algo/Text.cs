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
    public partial class Text1 : UserControl
    {
        public Text1()
        {
            InitializeComponent();
            encrypt_text1.BringToFront();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // text wehave to hide into image 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            encrypt_text1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decrypt_text1.BringToFront();
        }

        private void decrypt_text1_Load(object sender, EventArgs e)
        {

        }
    }
}
