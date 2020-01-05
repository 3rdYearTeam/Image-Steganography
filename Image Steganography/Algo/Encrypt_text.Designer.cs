namespace Image_Steganography

{
    partial class Encrypt_text
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encrypt_text));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.picture2 = new System.Windows.Forms.PictureBox();
            this.buttonbrowse_text = new System.Windows.Forms.Button();
            this.Encrpt_text = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 81);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 24);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // picture2
            // 
            this.picture2.BackColor = System.Drawing.Color.Transparent;
            this.picture2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture2.InitialImage = null;
            this.picture2.Location = new System.Drawing.Point(62, 137);
            this.picture2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(377, 295);
            this.picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture2.TabIndex = 4;
            this.picture2.TabStop = false;
            // 
            // buttonbrowse_text
            // 
            this.buttonbrowse_text.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonbrowse_text.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonbrowse_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonbrowse_text.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.buttonbrowse_text.Location = new System.Drawing.Point(62, 449);
            this.buttonbrowse_text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonbrowse_text.Name = "buttonbrowse_text";
            this.buttonbrowse_text.Size = new System.Drawing.Size(377, 36);
            this.buttonbrowse_text.TabIndex = 5;
            this.buttonbrowse_text.Text = "Select Image";
            this.buttonbrowse_text.UseVisualStyleBackColor = false;
            this.buttonbrowse_text.Click += new System.EventHandler(this.buttonbrowse_Click);
            // 
            // Encrpt_text
            // 
            this.Encrpt_text.BackColor = System.Drawing.Color.SkyBlue;
            this.Encrpt_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Encrpt_text.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Encrpt_text.Location = new System.Drawing.Point(62, 575);
            this.Encrpt_text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Encrpt_text.Name = "Encrpt_text";
            this.Encrpt_text.Size = new System.Drawing.Size(377, 38);
            this.Encrpt_text.TabIndex = 7;
            this.Encrpt_text.Text = "Encrypt";
            this.Encrpt_text.UseVisualStyleBackColor = false;
            this.Encrpt_text.Click += new System.EventHandler(this.Encrpt_text_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Enabled = false;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(739, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 36);
            this.label2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(664, 575);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 36);
            this.label3.TabIndex = 27;
            this.label3.Text = "Key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 27);
            this.label1.TabIndex = 28;
            this.label1.Text = "Text";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(535, 573);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 38);
            this.button1.TabIndex = 29;
            this.button1.Text = "Copy key";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Encrypt_text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Encrpt_text);
            this.Controls.Add(this.buttonbrowse_text);
            this.Controls.Add(this.picture2);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Encrypt_text";
            this.Size = new System.Drawing.Size(1121, 635);
            this.Load += new System.EventHandler(this.Encrypt_text_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox picture2;
        private System.Windows.Forms.Button buttonbrowse_text;
        private System.Windows.Forms.Button Encrpt_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
