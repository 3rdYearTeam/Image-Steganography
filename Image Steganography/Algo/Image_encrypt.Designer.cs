namespace Image_Steganography
{
    partial class Image_encrypt
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_encrypt));
            this.cover = new System.Windows.Forms.PictureBox();
            this.original = new System.Windows.Forms.PictureBox();
            this.Encrpt_Image = new System.Windows.Forms.Button();
            this.buttonbrowse_Image = new System.Windows.Forms.Button();
            this.buttonbrowse_Image2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.keytxt = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.original)).BeginInit();
            this.SuspendLayout();
            // 
            // cover
            // 
            this.cover.BackColor = System.Drawing.Color.Transparent;
            this.cover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cover.Location = new System.Drawing.Point(27, 341);
            this.cover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(352, 239);
            this.cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cover.TabIndex = 9;
            this.cover.TabStop = false;
            // 
            // original
            // 
            this.original.BackColor = System.Drawing.Color.Transparent;
            this.original.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.original.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.original.Location = new System.Drawing.Point(27, 21);
            this.original.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.original.Name = "original";
            this.original.Size = new System.Drawing.Size(352, 254);
            this.original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.original.TabIndex = 10;
            this.original.TabStop = false;
            // 
            // Encrpt_Image
            // 
            this.Encrpt_Image.BackColor = System.Drawing.Color.SkyBlue;
            this.Encrpt_Image.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Encrpt_Image.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Encrpt_Image.Location = new System.Drawing.Point(833, 562);
            this.Encrpt_Image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Encrpt_Image.Name = "Encrpt_Image";
            this.Encrpt_Image.Size = new System.Drawing.Size(277, 34);
            this.Encrpt_Image.TabIndex = 13;
            this.Encrpt_Image.Text = "Encrypt";
            this.Encrpt_Image.UseVisualStyleBackColor = false;
            this.Encrpt_Image.Click += new System.EventHandler(this.Encrpt_Image_Click);
            // 
            // buttonbrowse_Image
            // 
            this.buttonbrowse_Image.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonbrowse_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonbrowse_Image.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonbrowse_Image.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.buttonbrowse_Image.Location = new System.Drawing.Point(27, 283);
            this.buttonbrowse_Image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonbrowse_Image.Name = "buttonbrowse_Image";
            this.buttonbrowse_Image.Size = new System.Drawing.Size(352, 36);
            this.buttonbrowse_Image.TabIndex = 14;
            this.buttonbrowse_Image.Text = "Select Image";
            this.buttonbrowse_Image.UseVisualStyleBackColor = false;
            this.buttonbrowse_Image.Click += new System.EventHandler(this.buttonbrowse_Image_Click);
            // 
            // buttonbrowse_Image2
            // 
            this.buttonbrowse_Image2.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonbrowse_Image2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonbrowse_Image2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonbrowse_Image2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.buttonbrowse_Image2.Location = new System.Drawing.Point(27, 603);
            this.buttonbrowse_Image2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonbrowse_Image2.Name = "buttonbrowse_Image2";
            this.buttonbrowse_Image2.Size = new System.Drawing.Size(352, 36);
            this.buttonbrowse_Image2.TabIndex = 15;
            this.buttonbrowse_Image2.Text = "Select Cover Image";
            this.buttonbrowse_Image2.UseVisualStyleBackColor = false;
            this.buttonbrowse_Image2.Click += new System.EventHandler(this.buttonbrowse_Image2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(833, 603);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 36);
            this.label3.TabIndex = 28;
            this.label3.Text = "Key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(1118, 562);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 34);
            this.button1.TabIndex = 30;
            this.button1.Text = "Copy key";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // keytxt
            // 
            this.keytxt.Enabled = false;
            this.keytxt.Location = new System.Drawing.Point(920, 603);
            this.keytxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.keytxt.Name = "keytxt";
            this.keytxt.ReadOnly = true;
            this.keytxt.Size = new System.Drawing.Size(347, 36);
            this.keytxt.TabIndex = 32;
            this.keytxt.Text = "";
            // 
            // Image_encrypt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.keytxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonbrowse_Image2);
            this.Controls.Add(this.buttonbrowse_Image);
            this.Controls.Add(this.Encrpt_Image);
            this.Controls.Add(this.original);
            this.Controls.Add(this.cover);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Image_encrypt";
            this.Size = new System.Drawing.Size(1283, 650);
            this.Load += new System.EventHandler(this.Image_encrypt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.original)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox cover;
        private System.Windows.Forms.PictureBox original;
        private System.Windows.Forms.Button Encrpt_Image;
        private System.Windows.Forms.Button buttonbrowse_Image;
        private System.Windows.Forms.Button buttonbrowse_Image2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox keytxt;
    }
}
