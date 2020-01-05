using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Steganography

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //welcome1.BringToFront();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sidePanel2.Height = button3.Height;
            sidePanel2.Top = button3.Top;
            image1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sidePanel2.Height = button1.Height;
            sidePanel2.Top = button1.Top;
            text1.BringToFront();
            
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    sidePanel2.Height = button3.Height;
        //    sidePanel2.Top = button3.Top;
        //    audio11.BringToFront();
        //}

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void audio11_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
