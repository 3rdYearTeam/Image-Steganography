namespace Image_Steganography
{
    partial class Image_Dec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Dec));
            this.originalimage = new System.Windows.Forms.PictureBox();
            this.Decrypt_Image = new System.Windows.Forms.Button();
            this.stego = new System.Windows.Forms.PictureBox();
            this.buttonbrowse_Image2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.keytxt = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stego)).BeginInit();
            this.SuspendLayout();
            // 
            // originalimage
            // 
            this.originalimage.BackColor = System.Drawing.Color.Transparent;
            this.originalimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.originalimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalimage.Location = new System.Drawing.Point(711, 268);
            this.originalimage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.originalimage.Name = "originalimage";
            this.originalimage.Size = new System.Drawing.Size(377, 295);
            this.originalimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalimage.TabIndex = 11;
            this.originalimage.TabStop = false;
            // 
            // Decrypt_Image
            // 
            this.Decrypt_Image.BackColor = System.Drawing.Color.SkyBlue;
            this.Decrypt_Image.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Decrypt_Image.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Decrypt_Image.Location = new System.Drawing.Point(45, 582);
            this.Decrypt_Image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Decrypt_Image.Name = "Decrypt_Image";
            this.Decrypt_Image.Size = new System.Drawing.Size(377, 36);
            this.Decrypt_Image.TabIndex = 18;
            this.Decrypt_Image.Text = "Decrypt";
            this.Decrypt_Image.UseVisualStyleBackColor = false;
            this.Decrypt_Image.Click += new System.EventHandler(this.Decrypt_Image_Click);
            // 
            // stego
            // 
            this.stego.BackColor = System.Drawing.Color.Transparent;
            this.stego.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stego.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stego.Location = new System.Drawing.Point(45, 110);
            this.stego.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stego.Name = "stego";
            this.stego.Size = new System.Drawing.Size(377, 295);
            this.stego.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stego.TabIndex = 20;
            this.stego.TabStop = false;
            // 
            // buttonbrowse_Image2
            // 
            this.buttonbrowse_Image2.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonbrowse_Image2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonbrowse_Image2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonbrowse_Image2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.buttonbrowse_Image2.Location = new System.Drawing.Point(45, 429);
            this.buttonbrowse_Image2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonbrowse_Image2.Name = "buttonbrowse_Image2";
            this.buttonbrowse_Image2.Size = new System.Drawing.Size(377, 36);
            this.buttonbrowse_Image2.TabIndex = 21;
            this.buttonbrowse_Image2.Text = "Select Stego Image";
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
            this.label3.Location = new System.Drawing.Point(45, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 27);
            this.label3.TabIndex = 27;
            this.label3.Text = "Enter Key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(711, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 36);
            this.label1.TabIndex = 28;
            this.label1.Text = "The Original Image";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keytxt
            // 
            this.keytxt.Location = new System.Drawing.Point(182, 53);
            this.keytxt.Name = "keytxt";
            this.keytxt.Size = new System.Drawing.Size(240, 27);
            this.keytxt.TabIndex = 29;
            this.keytxt.Text = "";
            // 
            // Image_Dec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.keytxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonbrowse_Image2);
            this.Controls.Add(this.stego);
            this.Controls.Add(this.Decrypt_Image);
            this.Controls.Add(this.originalimage);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Image_Dec";
            this.Size = new System.Drawing.Size(1123, 650);
            this.Load += new System.EventHandler(this.Image_Dec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.originalimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stego)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox originalimage;
        private System.Windows.Forms.Button Decrypt_Image;
        private System.Windows.Forms.PictureBox stego;
        private System.Windows.Forms.Button buttonbrowse_Image2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox keytxt;
    }
}
