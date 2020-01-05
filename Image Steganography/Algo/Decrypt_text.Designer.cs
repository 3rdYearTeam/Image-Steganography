namespace Image_Steganography
{
    partial class Decrypt_text
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Decrypt_text));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonbrowse_textD = new System.Windows.Forms.Button();
            this.picture3 = new System.Windows.Forms.PictureBox();
            this.Decrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(186, 83);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 24);
            this.textBox2.TabIndex = 2;
            // 
            // buttonbrowse_textD
            // 
            this.buttonbrowse_textD.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonbrowse_textD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonbrowse_textD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonbrowse_textD.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.buttonbrowse_textD.Location = new System.Drawing.Point(62, 447);
            this.buttonbrowse_textD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonbrowse_textD.Name = "buttonbrowse_textD";
            this.buttonbrowse_textD.Size = new System.Drawing.Size(377, 36);
            this.buttonbrowse_textD.TabIndex = 3;
            this.buttonbrowse_textD.Text = "Select Image";
            this.buttonbrowse_textD.UseVisualStyleBackColor = false;
            this.buttonbrowse_textD.Click += new System.EventHandler(this.buttonbrowse_Click);
            // 
            // picture3
            // 
            this.picture3.BackColor = System.Drawing.Color.Transparent;
            this.picture3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picture3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture3.Location = new System.Drawing.Point(62, 135);
            this.picture3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picture3.Name = "picture3";
            this.picture3.Size = new System.Drawing.Size(377, 295);
            this.picture3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture3.TabIndex = 5;
            this.picture3.TabStop = false;
            // 
            // Decrypt
            // 
            this.Decrypt.BackColor = System.Drawing.Color.SkyBlue;
            this.Decrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Decrypt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Decrypt.Location = new System.Drawing.Point(62, 574);
            this.Decrypt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(377, 38);
            this.Decrypt.TabIndex = 10;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = false;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(770, 574);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 38);
            this.label1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(521, 574);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 38);
            this.label2.TabIndex = 25;
            this.label2.Text = "The Original Text";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(62, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 27);
            this.label3.TabIndex = 26;
            this.label3.Text = "Enter Key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Decrypt_text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.picture3);
            this.Controls.Add(this.buttonbrowse_textD);
            this.Controls.Add(this.textBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Decrypt_text";
            this.Size = new System.Drawing.Size(1123, 637);
            this.Load += new System.EventHandler(this.Decrypt_text_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonbrowse_textD;
        private System.Windows.Forms.PictureBox picture3;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
