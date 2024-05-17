namespace rent_a_car_proje
{
    partial class frmAracKayıt
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAracKayıt));
            this.Plakatxt = new System.Windows.Forms.TextBox();
            this.Markacombo = new System.Windows.Forms.ComboBox();
            this.Sericombo = new System.Windows.Forms.ComboBox();
            this.Yıltxt = new System.Windows.Forms.TextBox();
            this.Renktxt = new System.Windows.Forms.TextBox();
            this.Kmtxt = new System.Windows.Forms.TextBox();
            this.Yakıtcombo = new System.Windows.Forms.ComboBox();
            this.Ücrettxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKayıt = new System.Windows.Forms.Button();
            this.btnİptal = new System.Windows.Forms.Button();
            this.btnResimEkle = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Plakatxt
            // 
            this.Plakatxt.Location = new System.Drawing.Point(180, 55);
            this.Plakatxt.Name = "Plakatxt";
            this.Plakatxt.Size = new System.Drawing.Size(141, 22);
            this.Plakatxt.TabIndex = 0;
            // 
            // Markacombo
            // 
            this.Markacombo.FormattingEnabled = true;
            this.Markacombo.Items.AddRange(new object[] {
            "Opel ",
            "Renault",
            "Fiat",
            "Ford"});
            this.Markacombo.Location = new System.Drawing.Point(180, 97);
            this.Markacombo.Name = "Markacombo";
            this.Markacombo.Size = new System.Drawing.Size(141, 24);
            this.Markacombo.TabIndex = 1;
            this.Markacombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Sericombo
            // 
            this.Sericombo.FormattingEnabled = true;
            this.Sericombo.Location = new System.Drawing.Point(180, 141);
            this.Sericombo.Name = "Sericombo";
            this.Sericombo.Size = new System.Drawing.Size(141, 24);
            this.Sericombo.TabIndex = 2;
            // 
            // Yıltxt
            // 
            this.Yıltxt.Location = new System.Drawing.Point(180, 185);
            this.Yıltxt.Name = "Yıltxt";
            this.Yıltxt.Size = new System.Drawing.Size(141, 22);
            this.Yıltxt.TabIndex = 3;
            // 
            // Renktxt
            // 
            this.Renktxt.Location = new System.Drawing.Point(180, 227);
            this.Renktxt.Name = "Renktxt";
            this.Renktxt.Size = new System.Drawing.Size(141, 22);
            this.Renktxt.TabIndex = 4;
            // 
            // Kmtxt
            // 
            this.Kmtxt.Location = new System.Drawing.Point(180, 269);
            this.Kmtxt.Name = "Kmtxt";
            this.Kmtxt.Size = new System.Drawing.Size(141, 22);
            this.Kmtxt.TabIndex = 5;
            // 
            // Yakıtcombo
            // 
            this.Yakıtcombo.FormattingEnabled = true;
            this.Yakıtcombo.Items.AddRange(new object[] {
            "Dizel",
            "Benzin",
            "Benzin+LPG"});
            this.Yakıtcombo.Location = new System.Drawing.Point(180, 311);
            this.Yakıtcombo.Name = "Yakıtcombo";
            this.Yakıtcombo.Size = new System.Drawing.Size(141, 24);
            this.Yakıtcombo.TabIndex = 6;
            // 
            // Ücrettxt
            // 
            this.Ücrettxt.Location = new System.Drawing.Point(180, 355);
            this.Ücrettxt.Name = "Ücrettxt";
            this.Ücrettxt.Size = new System.Drawing.Size(141, 22);
            this.Ücrettxt.TabIndex = 7;
            this.Ücrettxt.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Plaka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Marka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Seri";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Model(Yıl)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Renk";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "KM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Yakıt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(101, 356);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Kira Ücreti";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(387, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // btnKayıt
            // 
            this.btnKayıt.BackColor = System.Drawing.Color.White;
            this.btnKayıt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKayıt.ImageIndex = 1;
            this.btnKayıt.ImageList = this.ımageList1;
            this.btnKayıt.Location = new System.Drawing.Point(130, 413);
            this.btnKayıt.Name = "btnKayıt";
            this.btnKayıt.Size = new System.Drawing.Size(99, 46);
            this.btnKayıt.TabIndex = 17;
            this.btnKayıt.Text = "Kayıt";
            this.btnKayıt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKayıt.UseVisualStyleBackColor = false;
            this.btnKayıt.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnİptal
            // 
            this.btnİptal.BackColor = System.Drawing.Color.White;
            this.btnİptal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnİptal.ImageIndex = 0;
            this.btnİptal.ImageList = this.ımageList1;
            this.btnİptal.Location = new System.Drawing.Point(235, 413);
            this.btnİptal.Name = "btnİptal";
            this.btnİptal.Size = new System.Drawing.Size(99, 46);
            this.btnİptal.TabIndex = 18;
            this.btnİptal.Text = "İptal";
            this.btnİptal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnİptal.UseVisualStyleBackColor = false;
            this.btnİptal.Click += new System.EventHandler(this.btnİptal_Click);
            // 
            // btnResimEkle
            // 
            this.btnResimEkle.BackColor = System.Drawing.Color.White;
            this.btnResimEkle.Location = new System.Drawing.Point(401, 212);
            this.btnResimEkle.Name = "btnResimEkle";
            this.btnResimEkle.Size = new System.Drawing.Size(121, 46);
            this.btnResimEkle.TabIndex = 19;
            this.btnResimEkle.Text = "Resim Ekle";
            this.btnResimEkle.UseVisualStyleBackColor = false;
            this.btnResimEkle.Click += new System.EventHandler(this.btnResimEkle_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "iptal.png");
            this.ımageList1.Images.SetKeyName(1, "aracEkle.png");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAracKayıt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(573, 524);
            this.Controls.Add(this.btnResimEkle);
            this.Controls.Add(this.btnİptal);
            this.Controls.Add(this.btnKayıt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ücrettxt);
            this.Controls.Add(this.Yakıtcombo);
            this.Controls.Add(this.Kmtxt);
            this.Controls.Add(this.Renktxt);
            this.Controls.Add(this.Yıltxt);
            this.Controls.Add(this.Sericombo);
            this.Controls.Add(this.Markacombo);
            this.Controls.Add(this.Plakatxt);
            this.Name = "frmAracKayıt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Plakatxt;
        private System.Windows.Forms.ComboBox Markacombo;
        private System.Windows.Forms.ComboBox Sericombo;
        private System.Windows.Forms.TextBox Yıltxt;
        private System.Windows.Forms.TextBox Renktxt;
        private System.Windows.Forms.TextBox Kmtxt;
        private System.Windows.Forms.ComboBox Yakıtcombo;
        private System.Windows.Forms.TextBox Ücrettxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnKayıt;
        private System.Windows.Forms.Button btnİptal;
        private System.Windows.Forms.Button btnResimEkle;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}