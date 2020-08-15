namespace InstaBot.Forms
{
    partial class Listeler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listeler));
            this.grpKullanicilar = new System.Windows.Forms.GroupBox();
            this.btnKullaniciGrupSil = new System.Windows.Forms.Button();
            this.btnKullaniciGrupAdi = new System.Windows.Forms.Button();
            this.btnKullaniciGrupEkle = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKullaniciGrupAdi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbKullanici = new System.Windows.Forms.ComboBox();
            this.btnKullaniciEkle = new System.Windows.Forms.Button();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.grpHashtag = new System.Windows.Forms.GroupBox();
            this.btnHastagGrupSil = new System.Windows.Forms.Button();
            this.btnGrupHashtag = new System.Windows.Forms.Button();
            this.btnHashtagGrupEkle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHashtagGrupAdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbHashtag = new System.Windows.Forms.ComboBox();
            this.btnHashtagEkle = new System.Windows.Forms.Button();
            this.txtHashtagEkle = new System.Windows.Forms.TextBox();
            this.grpYorum = new System.Windows.Forms.GroupBox();
            this.btnGrupYorumSil = new System.Windows.Forms.Button();
            this.btnGrupYorumDuzenle = new System.Windows.Forms.Button();
            this.btnGrupYorumEkle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYorumGrupAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYorum = new System.Windows.Forms.ComboBox();
            this.btnYorumEkle = new System.Windows.Forms.Button();
            this.txtYorum = new System.Windows.Forms.TextBox();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lstBx = new System.Windows.Forms.ListBox();
            this.grpKullanicilar.SuspendLayout();
            this.grpHashtag.SuspendLayout();
            this.grpYorum.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpKullanicilar
            // 
            this.grpKullanicilar.Controls.Add(this.btnKullaniciGrupSil);
            this.grpKullanicilar.Controls.Add(this.btnKullaniciGrupAdi);
            this.grpKullanicilar.Controls.Add(this.btnKullaniciGrupEkle);
            this.grpKullanicilar.Controls.Add(this.label7);
            this.grpKullanicilar.Controls.Add(this.label8);
            this.grpKullanicilar.Controls.Add(this.txtKullaniciGrupAdi);
            this.grpKullanicilar.Controls.Add(this.label9);
            this.grpKullanicilar.Controls.Add(this.cmbKullanici);
            this.grpKullanicilar.Controls.Add(this.btnKullaniciEkle);
            this.grpKullanicilar.Controls.Add(this.txtKullaniciAdi);
            this.grpKullanicilar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpKullanicilar.Location = new System.Drawing.Point(18, 366);
            this.grpKullanicilar.Name = "grpKullanicilar";
            this.grpKullanicilar.Size = new System.Drawing.Size(430, 140);
            this.grpKullanicilar.TabIndex = 19;
            this.grpKullanicilar.TabStop = false;
            this.grpKullanicilar.Text = "Kullanıcı Adı Ekle/Düzenle";
            // 
            // btnKullaniciGrupSil
            // 
            this.btnKullaniciGrupSil.Enabled = false;
            this.btnKullaniciGrupSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullaniciGrupSil.Image = ((System.Drawing.Image)(resources.GetObject("btnKullaniciGrupSil.Image")));
            this.btnKullaniciGrupSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKullaniciGrupSil.Location = new System.Drawing.Point(348, 14);
            this.btnKullaniciGrupSil.Name = "btnKullaniciGrupSil";
            this.btnKullaniciGrupSil.Size = new System.Drawing.Size(73, 49);
            this.btnKullaniciGrupSil.TabIndex = 6;
            this.btnKullaniciGrupSil.Text = "Sil";
            this.btnKullaniciGrupSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKullaniciGrupSil.UseVisualStyleBackColor = true;
            this.btnKullaniciGrupSil.Click += new System.EventHandler(this.btnKullaniciGrupSil_Click);
            // 
            // btnKullaniciGrupAdi
            // 
            this.btnKullaniciGrupAdi.Enabled = false;
            this.btnKullaniciGrupAdi.Location = new System.Drawing.Point(249, 40);
            this.btnKullaniciGrupAdi.Name = "btnKullaniciGrupAdi";
            this.btnKullaniciGrupAdi.Size = new System.Drawing.Size(93, 23);
            this.btnKullaniciGrupAdi.TabIndex = 11;
            this.btnKullaniciGrupAdi.Text = "Adı Düzenle";
            this.btnKullaniciGrupAdi.UseVisualStyleBackColor = true;
            this.btnKullaniciGrupAdi.Click += new System.EventHandler(this.btnKullaniciGrupDuzenle_Click);
            // 
            // btnKullaniciGrupEkle
            // 
            this.btnKullaniciGrupEkle.Location = new System.Drawing.Point(249, 14);
            this.btnKullaniciGrupEkle.Name = "btnKullaniciGrupEkle";
            this.btnKullaniciGrupEkle.Size = new System.Drawing.Size(93, 23);
            this.btnKullaniciGrupEkle.TabIndex = 10;
            this.btnKullaniciGrupEkle.Text = "Grup Ekle";
            this.btnKullaniciGrupEkle.UseVisualStyleBackColor = true;
            this.btnKullaniciGrupEkle.Click += new System.EventHandler(this.btnKullaniciGrupEkle_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Grup Seç";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Grup Adı";
            // 
            // txtKullaniciGrupAdi
            // 
            this.txtKullaniciGrupAdi.Enabled = false;
            this.txtKullaniciGrupAdi.Location = new System.Drawing.Point(92, 44);
            this.txtKullaniciGrupAdi.Name = "txtKullaniciGrupAdi";
            this.txtKullaniciGrupAdi.Size = new System.Drawing.Size(151, 22);
            this.txtKullaniciGrupAdi.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Kullanıcı Adı";
            // 
            // cmbKullanici
            // 
            this.cmbKullanici.FormattingEnabled = true;
            this.cmbKullanici.Location = new System.Drawing.Point(92, 17);
            this.cmbKullanici.Name = "cmbKullanici";
            this.cmbKullanici.Size = new System.Drawing.Size(151, 24);
            this.cmbKullanici.TabIndex = 1;
            this.cmbKullanici.SelectedIndexChanged += new System.EventHandler(this.cmbKullanici_SelectedIndexChanged);
            // 
            // btnKullaniciEkle
            // 
            this.btnKullaniciEkle.Enabled = false;
            this.btnKullaniciEkle.Location = new System.Drawing.Point(92, 97);
            this.btnKullaniciEkle.Name = "btnKullaniciEkle";
            this.btnKullaniciEkle.Size = new System.Drawing.Size(137, 35);
            this.btnKullaniciEkle.TabIndex = 5;
            this.btnKullaniciEkle.Text = "Kullanıcı Adı Ekle";
            this.btnKullaniciEkle.UseVisualStyleBackColor = true;
            this.btnKullaniciEkle.Click += new System.EventHandler(this.btnKullaniciEkle_Click);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Enabled = false;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(92, 70);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(329, 22);
            this.txtKullaniciAdi.TabIndex = 4;
            // 
            // grpHashtag
            // 
            this.grpHashtag.Controls.Add(this.btnHastagGrupSil);
            this.grpHashtag.Controls.Add(this.btnGrupHashtag);
            this.grpHashtag.Controls.Add(this.btnHashtagGrupEkle);
            this.grpHashtag.Controls.Add(this.label4);
            this.grpHashtag.Controls.Add(this.label5);
            this.grpHashtag.Controls.Add(this.txtHashtagGrupAdi);
            this.grpHashtag.Controls.Add(this.label6);
            this.grpHashtag.Controls.Add(this.cmbHashtag);
            this.grpHashtag.Controls.Add(this.btnHashtagEkle);
            this.grpHashtag.Controls.Add(this.txtHashtagEkle);
            this.grpHashtag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpHashtag.Location = new System.Drawing.Point(18, 198);
            this.grpHashtag.Name = "grpHashtag";
            this.grpHashtag.Size = new System.Drawing.Size(430, 140);
            this.grpHashtag.TabIndex = 18;
            this.grpHashtag.TabStop = false;
            this.grpHashtag.Text = "Hashtag Ekle/Düzenle";
            // 
            // btnHastagGrupSil
            // 
            this.btnHastagGrupSil.Enabled = false;
            this.btnHastagGrupSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHastagGrupSil.Image = ((System.Drawing.Image)(resources.GetObject("btnHastagGrupSil.Image")));
            this.btnHastagGrupSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHastagGrupSil.Location = new System.Drawing.Point(348, 18);
            this.btnHastagGrupSil.Name = "btnHastagGrupSil";
            this.btnHastagGrupSil.Size = new System.Drawing.Size(73, 49);
            this.btnHastagGrupSil.TabIndex = 6;
            this.btnHastagGrupSil.Text = "Sil";
            this.btnHastagGrupSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHastagGrupSil.UseVisualStyleBackColor = true;
            this.btnHastagGrupSil.Click += new System.EventHandler(this.btnHastagGrupSil_Click);
            // 
            // btnGrupHashtag
            // 
            this.btnGrupHashtag.Enabled = false;
            this.btnGrupHashtag.Location = new System.Drawing.Point(249, 43);
            this.btnGrupHashtag.Name = "btnGrupHashtag";
            this.btnGrupHashtag.Size = new System.Drawing.Size(93, 24);
            this.btnGrupHashtag.TabIndex = 11;
            this.btnGrupHashtag.Text = "Adı Düzenle";
            this.btnGrupHashtag.UseVisualStyleBackColor = true;
            this.btnGrupHashtag.Click += new System.EventHandler(this.btnHashtagAdiDuznele_Click);
            // 
            // btnHashtagGrupEkle
            // 
            this.btnHashtagGrupEkle.Location = new System.Drawing.Point(249, 17);
            this.btnHashtagGrupEkle.Name = "btnHashtagGrupEkle";
            this.btnHashtagGrupEkle.Size = new System.Drawing.Size(93, 23);
            this.btnHashtagGrupEkle.TabIndex = 10;
            this.btnHashtagGrupEkle.Text = "Grup Ekle";
            this.btnHashtagGrupEkle.UseVisualStyleBackColor = true;
            this.btnHashtagGrupEkle.Click += new System.EventHandler(this.btnHashtagGrupEkle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Grup Seç";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Grup Adı";
            // 
            // txtHashtagGrupAdi
            // 
            this.txtHashtagGrupAdi.Enabled = false;
            this.txtHashtagGrupAdi.Location = new System.Drawing.Point(76, 46);
            this.txtHashtagGrupAdi.Name = "txtHashtagGrupAdi";
            this.txtHashtagGrupAdi.Size = new System.Drawing.Size(167, 22);
            this.txtHashtagGrupAdi.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Hashtag";
            // 
            // cmbHashtag
            // 
            this.cmbHashtag.FormattingEnabled = true;
            this.cmbHashtag.Location = new System.Drawing.Point(76, 19);
            this.cmbHashtag.Name = "cmbHashtag";
            this.cmbHashtag.Size = new System.Drawing.Size(167, 24);
            this.cmbHashtag.TabIndex = 1;
            this.cmbHashtag.SelectedIndexChanged += new System.EventHandler(this.cmbHashtag_SelectedIndexChanged);
            // 
            // btnHashtagEkle
            // 
            this.btnHashtagEkle.Enabled = false;
            this.btnHashtagEkle.Location = new System.Drawing.Point(76, 101);
            this.btnHashtagEkle.Name = "btnHashtagEkle";
            this.btnHashtagEkle.Size = new System.Drawing.Size(120, 35);
            this.btnHashtagEkle.TabIndex = 5;
            this.btnHashtagEkle.Text = "Hashtag Ekle";
            this.btnHashtagEkle.UseVisualStyleBackColor = true;
            this.btnHashtagEkle.Click += new System.EventHandler(this.btnHashtagEkle_Click);
            // 
            // txtHashtagEkle
            // 
            this.txtHashtagEkle.Enabled = false;
            this.txtHashtagEkle.Location = new System.Drawing.Point(76, 73);
            this.txtHashtagEkle.Name = "txtHashtagEkle";
            this.txtHashtagEkle.Size = new System.Drawing.Size(345, 22);
            this.txtHashtagEkle.TabIndex = 4;
            // 
            // grpYorum
            // 
            this.grpYorum.Controls.Add(this.btnGrupYorumSil);
            this.grpYorum.Controls.Add(this.btnGrupYorumDuzenle);
            this.grpYorum.Controls.Add(this.btnGrupYorumEkle);
            this.grpYorum.Controls.Add(this.label3);
            this.grpYorum.Controls.Add(this.label2);
            this.grpYorum.Controls.Add(this.txtYorumGrupAdi);
            this.grpYorum.Controls.Add(this.label1);
            this.grpYorum.Controls.Add(this.cmbYorum);
            this.grpYorum.Controls.Add(this.btnYorumEkle);
            this.grpYorum.Controls.Add(this.txtYorum);
            this.grpYorum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpYorum.Location = new System.Drawing.Point(18, 33);
            this.grpYorum.Name = "grpYorum";
            this.grpYorum.Size = new System.Drawing.Size(430, 140);
            this.grpYorum.TabIndex = 17;
            this.grpYorum.TabStop = false;
            this.grpYorum.Text = "Yorum Ekle/Düzenle";
            // 
            // btnGrupYorumSil
            // 
            this.btnGrupYorumSil.Enabled = false;
            this.btnGrupYorumSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGrupYorumSil.Image = ((System.Drawing.Image)(resources.GetObject("btnGrupYorumSil.Image")));
            this.btnGrupYorumSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrupYorumSil.Location = new System.Drawing.Point(348, 17);
            this.btnGrupYorumSil.Name = "btnGrupYorumSil";
            this.btnGrupYorumSil.Size = new System.Drawing.Size(73, 49);
            this.btnGrupYorumSil.TabIndex = 6;
            this.btnGrupYorumSil.Text = "Sil";
            this.btnGrupYorumSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrupYorumSil.UseVisualStyleBackColor = true;
            this.btnGrupYorumSil.Click += new System.EventHandler(this.btnGrupYorumSil_Click);
            // 
            // btnGrupYorumDuzenle
            // 
            this.btnGrupYorumDuzenle.Enabled = false;
            this.btnGrupYorumDuzenle.Location = new System.Drawing.Point(249, 43);
            this.btnGrupYorumDuzenle.Name = "btnGrupYorumDuzenle";
            this.btnGrupYorumDuzenle.Size = new System.Drawing.Size(93, 23);
            this.btnGrupYorumDuzenle.TabIndex = 11;
            this.btnGrupYorumDuzenle.Text = "Adı Düzenle";
            this.btnGrupYorumDuzenle.UseVisualStyleBackColor = true;
            this.btnGrupYorumDuzenle.Click += new System.EventHandler(this.btnGrupYorumDuzenle_Click);
            // 
            // btnGrupYorumEkle
            // 
            this.btnGrupYorumEkle.Location = new System.Drawing.Point(249, 17);
            this.btnGrupYorumEkle.Name = "btnGrupYorumEkle";
            this.btnGrupYorumEkle.Size = new System.Drawing.Size(93, 23);
            this.btnGrupYorumEkle.TabIndex = 10;
            this.btnGrupYorumEkle.Text = "Grup Ekle";
            this.btnGrupYorumEkle.UseVisualStyleBackColor = true;
            this.btnGrupYorumEkle.Click += new System.EventHandler(this.btnGrupYorumEkle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Grup Seç";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Grup Adı";
            // 
            // txtYorumGrupAdi
            // 
            this.txtYorumGrupAdi.Enabled = false;
            this.txtYorumGrupAdi.Location = new System.Drawing.Point(76, 44);
            this.txtYorumGrupAdi.Name = "txtYorumGrupAdi";
            this.txtYorumGrupAdi.Size = new System.Drawing.Size(167, 22);
            this.txtYorumGrupAdi.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Yorum";
            // 
            // cmbYorum
            // 
            this.cmbYorum.FormattingEnabled = true;
            this.cmbYorum.Location = new System.Drawing.Point(76, 17);
            this.cmbYorum.Name = "cmbYorum";
            this.cmbYorum.Size = new System.Drawing.Size(167, 24);
            this.cmbYorum.TabIndex = 1;
            this.cmbYorum.SelectedIndexChanged += new System.EventHandler(this.cmbYorum_SelectedIndexChanged);
            // 
            // btnYorumEkle
            // 
            this.btnYorumEkle.Enabled = false;
            this.btnYorumEkle.Location = new System.Drawing.Point(76, 98);
            this.btnYorumEkle.Name = "btnYorumEkle";
            this.btnYorumEkle.Size = new System.Drawing.Size(120, 35);
            this.btnYorumEkle.TabIndex = 5;
            this.btnYorumEkle.Text = "Yorum Ekle";
            this.btnYorumEkle.UseVisualStyleBackColor = true;
            this.btnYorumEkle.Click += new System.EventHandler(this.btnYorumEkle_Click);
            // 
            // txtYorum
            // 
            this.txtYorum.Enabled = false;
            this.txtYorum.Location = new System.Drawing.Point(76, 70);
            this.txtYorum.Name = "txtYorum";
            this.txtYorum.Size = new System.Drawing.Size(345, 22);
            this.txtYorum.TabIndex = 4;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Enabled = false;
            this.btnDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnDuzenle.Image")));
            this.btnDuzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDuzenle.Location = new System.Drawing.Point(466, 518);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(130, 50);
            this.btnDuzenle.TabIndex = 16;
            this.btnDuzenle.Text = "Düzelt";
            this.btnDuzenle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click_1);
            // 
            // btnSil
            // 
            this.btnSil.Enabled = false;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(652, 518);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(130, 50);
            this.btnSil.TabIndex = 15;
            this.btnSil.Text = "Sil";
            this.btnSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lstBx
            // 
            this.lstBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBx.FormattingEnabled = true;
            this.lstBx.ItemHeight = 20;
            this.lstBx.Location = new System.Drawing.Point(466, 40);
            this.lstBx.Name = "lstBx";
            this.lstBx.Size = new System.Drawing.Size(316, 464);
            this.lstBx.TabIndex = 14;
            this.lstBx.SelectedIndexChanged += new System.EventHandler(this.lstBx_SelectedIndexChanged);
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.grpKullanicilar);
            this.Controls.Add(this.grpHashtag);
            this.Controls.Add(this.grpYorum);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.lstBx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ayarlar";
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.Ayarlar_Load);
            this.grpKullanicilar.ResumeLayout(false);
            this.grpKullanicilar.PerformLayout();
            this.grpHashtag.ResumeLayout(false);
            this.grpHashtag.PerformLayout();
            this.grpYorum.ResumeLayout(false);
            this.grpYorum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpKullanicilar;
        private System.Windows.Forms.Button btnKullaniciGrupSil;
        private System.Windows.Forms.Button btnKullaniciGrupAdi;
        private System.Windows.Forms.Button btnKullaniciGrupEkle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKullaniciGrupAdi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbKullanici;
        private System.Windows.Forms.Button btnKullaniciEkle;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.GroupBox grpHashtag;
        private System.Windows.Forms.Button btnHastagGrupSil;
        private System.Windows.Forms.Button btnGrupHashtag;
        private System.Windows.Forms.Button btnHashtagGrupEkle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHashtagGrupAdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbHashtag;
        private System.Windows.Forms.Button btnHashtagEkle;
        private System.Windows.Forms.TextBox txtHashtagEkle;
        private System.Windows.Forms.GroupBox grpYorum;
        private System.Windows.Forms.Button btnGrupYorumSil;
        private System.Windows.Forms.Button btnGrupYorumDuzenle;
        private System.Windows.Forms.Button btnGrupYorumEkle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYorumGrupAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbYorum;
        private System.Windows.Forms.Button btnYorumEkle;
        private System.Windows.Forms.TextBox txtYorum;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.ListBox lstBx;
    }
}