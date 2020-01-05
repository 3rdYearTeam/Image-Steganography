namespace Image_Steganography

{
    partial class image_design
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(image_design));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.image_Dec1 = new Image_Steganography.Image_Dec();
            this.image_encrypt1 = new Image_Steganography.Image_encrypt();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-15, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1299, 100);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(701, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(275, 92);
            this.button2.TabIndex = 1;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(424, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 92);
            this.button1.TabIndex = 0;
            this.button1.Text = "Encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // image_Dec1
            // 
            this.image_Dec1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("image_Dec1.BackgroundImage")));
            this.image_Dec1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.image_Dec1.Location = new System.Drawing.Point(4, 95);
            this.image_Dec1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.image_Dec1.Name = "image_Dec1";
            this.image_Dec1.Size = new System.Drawing.Size(1283, 650);
            this.image_Dec1.TabIndex = 3;
            // 
            // image_encrypt1
            // 
            this.image_encrypt1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("image_encrypt1.BackgroundImage")));
            this.image_encrypt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.image_encrypt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.image_encrypt1.Location = new System.Drawing.Point(1, 95);
            this.image_encrypt1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.image_encrypt1.Name = "image_encrypt1";
            this.image_encrypt1.Size = new System.Drawing.Size(1283, 650);
            this.image_encrypt1.TabIndex = 4;
            // 
            // image_design
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.image_Dec1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.image_encrypt1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "image_design";
            this.Size = new System.Drawing.Size(1287, 745);
            this.Load += new System.EventHandler(this.image_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Image_Dec image_Dec1;
        private Image_encrypt image_encrypt1;
    }
}
