namespace Image_Steganography

{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.sidePanel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.welcome1 = new Image_Steganography.welcome();
            this.image1 = new Image_Steganography.image_design();
            this.text1 = new Image_Steganography.Text1();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.sidePanel2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 750);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(-3, 586);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(238, 89);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // sidePanel2
            // 
            this.sidePanel2.BackColor = System.Drawing.Color.Maroon;
            this.sidePanel2.Location = new System.Drawing.Point(0, 46);
            this.sidePanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sidePanel2.Name = "sidePanel2";
            this.sidePanel2.Size = new System.Drawing.Size(16, 89);
            this.sidePanel2.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 167);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 89);
            this.button3.TabIndex = 3;
            this.button3.Text = "IMAGE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 89);
            this.button1.TabIndex = 1;
            this.button1.Text = "TEXT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // welcome1
            // 
            this.welcome1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("welcome1.BackgroundImage")));
            this.welcome1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.welcome1.Location = new System.Drawing.Point(230, 5);
            this.welcome1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.welcome1.Name = "welcome1";
            this.welcome1.Size = new System.Drawing.Size(1126, 745);
            this.welcome1.TabIndex = 4;
            // 
            // image1
            // 
            this.image1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("image1.BackgroundImage")));
            this.image1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.image1.Location = new System.Drawing.Point(230, 5);
            this.image1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(1126, 745);
            this.image1.TabIndex = 2;
            // 
            // text1
            // 
            this.text1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("text1.BackgroundImage")));
            this.text1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.text1.Location = new System.Drawing.Point(230, 0);
            this.text1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(1126, 745);
            this.text1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1358, 750);
            this.Controls.Add(this.welcome1);
            this.Controls.Add(this.image1);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel sidePanel2;
        private System.Windows.Forms.Button button3;
        private Text1 text1;
        private image_design image1;
        private System.Windows.Forms.Button ExitButton;
        private welcome welcome1;
    }
}

