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
    public partial class image_design : UserControl
    {
        public image_design()
        {
            InitializeComponent();
            image_encrypt1.BringToFront();
        }

        private void image_Load(object sender, EventArgs e)
        {

        }

        

        private void buttonbrowse_Click(object sender, EventArgs e)
        {
            
        }

        private void image_encrypt1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            image_encrypt1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            image_Dec1.BringToFront();
        }
    }
}
