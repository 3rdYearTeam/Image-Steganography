namespace Image_Steganography
{
    partial class Text1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Text1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.decrypt_text1 = new Image_Steganography.Decrypt_text();
            this.encrypt_text1 = new Image_Steganography.Encrypt_text();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 94);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(688, 4);
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
            this.button1.Location = new System.Drawing.Point(410, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 92);
            this.button1.TabIndex = 0;
            this.button1.Text = "Encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // decrypt_text1
            // 
            this.decrypt_text1.BackColor = System.Drawing.Color.White;
            this.decrypt_text1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("decrypt_text1.BackgroundImage")));
            this.decrypt_text1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.decrypt_text1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decrypt_text1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.decrypt_text1.Location = new System.Drawing.Point(3, 95);
            this.decrypt_text1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.decrypt_text1.Name = "decrypt_text1";
            this.decrypt_text1.Size = new System.Drawing.Size(1283, 650);
            this.decrypt_text1.TabIndex = 2;
            this.decrypt_text1.Load += new System.EventHandler(this.decrypt_text1_Load);
            // 
            // encrypt_text1
            // 
            this.encrypt_text1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("encrypt_text1.BackgroundImage")));
            this.encrypt_text1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.encrypt_text1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encrypt_text1.Location = new System.Drawing.Point(3, 97);
            this.encrypt_text1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.encrypt_text1.Name = "encrypt_text1";
            this.encrypt_text1.Size = new System.Drawing.Size(1283, 643);
            this.encrypt_text1.TabIndex = 1;
            // 
            // Text1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.decrypt_text1);
            this.Controls.Add(this.encrypt_text1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Text1";
            this.Size = new System.Drawing.Size(1287, 745);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Encrypt_text encrypt_text1;
        private Decrypt_text decrypt_text1;
    }
}
