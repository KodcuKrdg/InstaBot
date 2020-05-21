namespace InstaBot.Forms
{
    partial class Ayarlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayarlar));
            this.grpYorumHashtag = new System.Windows.Forms.GroupBox();
            this.grpHashtag = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHashtagGrupAdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbHashtag = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.grpYorum = new System.Windows.Forms.GroupBox();
            this.btnGrupYorumSil = new System.Windows.Forms.Button();
            this.btnGrupYorumAdi = new System.Windows.Forms.Button();
            this.btnGrupYorumEkle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYorumGrupAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYorum = new System.Windows.Forms.ComboBox();
            this.btnYorumEkleDuzenle = new System.Windows.Forms.Button();
            this.txtYorum = new System.Windows.Forms.TextBox();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.grpYorumHashtag.SuspendLayout();
            this.grpHashtag.SuspendLayout();
            this.grpYorum.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpYorumHashtag
            // 
            this.grpYorumHashtag.Controls.Add(this.grpHashtag);
            this.grpYorumHashtag.Controls.Add(this.grpYorum);
            this.grpYorumHashtag.Controls.Add(this.btnDuzenle);
            this.grpYorumHashtag.Controls.Add(this.btnSil);
            this.grpYorumHashtag.Controls.Add(this.listBox1);
            this.grpYorumHashtag.Location = new System.Drawing.Point(12, 12);
            this.grpYorumHashtag.Name = "grpYorumHashtag";
            this.grpYorumHashtag.Size = new System.Drawing.Size(736, 396);
            this.grpYorumHashtag.TabIndex = 1;
            this.grpYorumHashtag.TabStop = false;
            this.grpYorumHashtag.Text = "Yorum/Hashtag Ayarları";
            // 
            // grpHashtag
            // 
            this.grpHashtag.Controls.Add(this.button1);
            this.grpHashtag.Controls.Add(this.button2);
            this.grpHashtag.Controls.Add(this.button3);
            this.grpHashtag.Controls.Add(this.label4);
            this.grpHashtag.Controls.Add(this.label5);
            this.grpHashtag.Controls.Add(this.txtHashtagGrupAdi);
            this.grpHashtag.Controls.Add(this.label6);
            this.grpHashtag.Controls.Add(this.cmbHashtag);
            this.grpHashtag.Controls.Add(this.button4);
            this.grpHashtag.Controls.Add(this.textBox2);
            this.grpHashtag.Location = new System.Drawing.Point(17, 187);
            this.grpHashtag.Name = "grpHashtag";
            this.grpHashtag.Size = new System.Drawing.Size(366, 128);
            this.grpHashtag.TabIndex = 12;
            this.grpHashtag.TabStop = false;
            this.grpHashtag.Text = "Yorum Ekle/Düzenle";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(267, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sil";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Adı Düzenle";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(186, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Grup Ekle";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Grup Seç";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Grup Adı";
            // 
            // txtHashtagGrupAdi
            // 
            this.txtHashtagGrupAdi.Location = new System.Drawing.Point(64, 44);
            this.txtHashtagGrupAdi.Name = "txtHashtagGrupAdi";
            this.txtHashtagGrupAdi.Size = new System.Drawing.Size(116, 20);
            this.txtHashtagGrupAdi.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Hashtag";
            // 
            // cmbHashtag
            // 
            this.cmbHashtag.FormattingEnabled = true;
            this.cmbHashtag.Location = new System.Drawing.Point(64, 17);
            this.cmbHashtag.Name = "cmbHashtag";
            this.cmbHashtag.Size = new System.Drawing.Size(116, 21);
            this.cmbHashtag.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(64, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Yorumu Ekle";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(276, 20);
            this.textBox2.TabIndex = 4;
            // 
            // grpYorum
            // 
            this.grpYorum.Controls.Add(this.btnGrupYorumSil);
            this.grpYorum.Controls.Add(this.btnGrupYorumAdi);
            this.grpYorum.Controls.Add(this.btnGrupYorumEkle);
            this.grpYorum.Controls.Add(this.label3);
            this.grpYorum.Controls.Add(this.label2);
            this.grpYorum.Controls.Add(this.txtYorumGrupAdi);
            this.grpYorum.Controls.Add(this.label1);
            this.grpYorum.Controls.Add(this.cmbYorum);
            this.grpYorum.Controls.Add(this.btnYorumEkleDuzenle);
            this.grpYorum.Controls.Add(this.txtYorum);
            this.grpYorum.Location = new System.Drawing.Point(17, 19);
            this.grpYorum.Name = "grpYorum";
            this.grpYorum.Size = new System.Drawing.Size(366, 128);
            this.grpYorum.TabIndex = 5;
            this.grpYorum.TabStop = false;
            this.grpYorum.Text = "Yorum Ekle/Düzenle";
            // 
            // btnGrupYorumSil
            // 
            this.btnGrupYorumSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGrupYorumSil.Image = ((System.Drawing.Image)(resources.GetObject("btnGrupYorumSil.Image")));
            this.btnGrupYorumSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrupYorumSil.Location = new System.Drawing.Point(267, 15);
            this.btnGrupYorumSil.Name = "btnGrupYorumSil";
            this.btnGrupYorumSil.Size = new System.Drawing.Size(73, 49);
            this.btnGrupYorumSil.TabIndex = 6;
            this.btnGrupYorumSil.Text = "Sil";
            this.btnGrupYorumSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrupYorumSil.UseVisualStyleBackColor = true;
            // 
            // btnGrupYorumAdi
            // 
            this.btnGrupYorumAdi.Location = new System.Drawing.Point(186, 41);
            this.btnGrupYorumAdi.Name = "btnGrupYorumAdi";
            this.btnGrupYorumAdi.Size = new System.Drawing.Size(75, 23);
            this.btnGrupYorumAdi.TabIndex = 11;
            this.btnGrupYorumAdi.Text = "Adı Düzenle";
            this.btnGrupYorumAdi.UseVisualStyleBackColor = true;
            // 
            // btnGrupYorumEkle
            // 
            this.btnGrupYorumEkle.Location = new System.Drawing.Point(186, 15);
            this.btnGrupYorumEkle.Name = "btnGrupYorumEkle";
            this.btnGrupYorumEkle.Size = new System.Drawing.Size(75, 23);
            this.btnGrupYorumEkle.TabIndex = 10;
            this.btnGrupYorumEkle.Text = "Grup Ekle";
            this.btnGrupYorumEkle.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Grup Seç";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Grup Adı";
            // 
            // txtYorumGrupAdi
            // 
            this.txtYorumGrupAdi.Location = new System.Drawing.Point(64, 44);
            this.txtYorumGrupAdi.Name = "txtYorumGrupAdi";
            this.txtYorumGrupAdi.Size = new System.Drawing.Size(116, 20);
            this.txtYorumGrupAdi.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Yorum";
            // 
            // cmbYorum
            // 
            this.cmbYorum.FormattingEnabled = true;
            this.cmbYorum.Location = new System.Drawing.Point(64, 17);
            this.cmbYorum.Name = "cmbYorum";
            this.cmbYorum.Size = new System.Drawing.Size(116, 21);
            this.cmbYorum.TabIndex = 1;
            // 
            // btnYorumEkleDuzenle
            // 
            this.btnYorumEkleDuzenle.Location = new System.Drawing.Point(64, 96);
            this.btnYorumEkleDuzenle.Name = "btnYorumEkleDuzenle";
            this.btnYorumEkleDuzenle.Size = new System.Drawing.Size(83, 23);
            this.btnYorumEkleDuzenle.TabIndex = 5;
            this.btnYorumEkleDuzenle.Text = "Yorumu Ekle";
            this.btnYorumEkleDuzenle.UseVisualStyleBackColor = true;
            // 
            // txtYorum
            // 
            this.txtYorum.Location = new System.Drawing.Point(64, 70);
            this.txtYorum.Name = "txtYorum";
            this.txtYorum.Size = new System.Drawing.Size(276, 20);
            this.txtYorum.TabIndex = 4;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnDuzenle.Image")));
            this.btnDuzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDuzenle.Location = new System.Drawing.Point(439, 340);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(130, 50);
            this.btnDuzenle.TabIndex = 3;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(600, 340);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(130, 50);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSil.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(439, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(291, 316);
            this.listBox1.TabIndex = 0;
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 600);
            this.Controls.Add(this.grpYorumHashtag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ayarlar";
            this.Text = "Ayarlar";
            this.grpYorumHashtag.ResumeLayout(false);
            this.grpHashtag.ResumeLayout(false);
            this.grpHashtag.PerformLayout();
            this.grpYorum.ResumeLayout(false);
            this.grpYorum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpYorumHashtag;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.ComboBox cmbYorum;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox grpYorum;
        private System.Windows.Forms.TextBox txtYorum;
        private System.Windows.Forms.Button btnGrupYorumSil;
        private System.Windows.Forms.Button btnGrupYorumAdi;
        private System.Windows.Forms.Button btnGrupYorumEkle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYorumGrupAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYorumEkleDuzenle;
        private System.Windows.Forms.GroupBox grpHashtag;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHashtagGrupAdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbHashtag;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
    }
}