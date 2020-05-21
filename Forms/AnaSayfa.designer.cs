namespace InstaBot
{
    partial class AnaSayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaSayfa));
            this.pnlUst = new System.Windows.Forms.Panel();
            this.pcCancel = new System.Windows.Forms.PictureBox();
            this.pnlSol = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAyarlar = new System.Windows.Forms.Panel();
            this.pcAyar = new System.Windows.Forms.PictureBox();
            this.lblAyarlar = new System.Windows.Forms.Label();
            this.pcLogo = new System.Windows.Forms.PictureBox();
            this.pnlSag = new System.Windows.Forms.Panel();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).BeginInit();
            this.pnlSol.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlAyarlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcAyar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.pnlUst.Controls.Add(this.pcCancel);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(140, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(760, 50);
            this.pnlUst.TabIndex = 0;
            this.pnlUst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseDown);
            this.pnlUst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseMove);
            this.pnlUst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseUp);
            // 
            // pcCancel
            // 
            this.pcCancel.Image = ((System.Drawing.Image)(resources.GetObject("pcCancel.Image")));
            this.pcCancel.Location = new System.Drawing.Point(690, 5);
            this.pcCancel.Name = "pcCancel";
            this.pcCancel.Size = new System.Drawing.Size(38, 34);
            this.pcCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcCancel.TabIndex = 0;
            this.pcCancel.TabStop = false;
            this.pcCancel.Click += new System.EventHandler(this.pcCancel_Click);
            // 
            // pnlSol
            // 
            this.pnlSol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pnlSol.Controls.Add(this.panel1);
            this.pnlSol.Controls.Add(this.pnlAyarlar);
            this.pnlSol.Controls.Add(this.pcLogo);
            this.pnlSol.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSol.ForeColor = System.Drawing.Color.White;
            this.pnlSol.Location = new System.Drawing.Point(0, 0);
            this.pnlSol.Name = "pnlSol";
            this.pnlSol.Size = new System.Drawing.Size(140, 650);
            this.pnlSol.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 305);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 50);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(102, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gönderiler";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlAyarlar
            // 
            this.pnlAyarlar.Controls.Add(this.pcAyar);
            this.pnlAyarlar.Controls.Add(this.lblAyarlar);
            this.pnlAyarlar.Location = new System.Drawing.Point(0, 235);
            this.pnlAyarlar.Name = "pnlAyarlar";
            this.pnlAyarlar.Size = new System.Drawing.Size(140, 50);
            this.pnlAyarlar.TabIndex = 2;
            // 
            // pcAyar
            // 
            this.pcAyar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcAyar.Image = ((System.Drawing.Image)(resources.GetObject("pcAyar.Image")));
            this.pcAyar.Location = new System.Drawing.Point(102, 0);
            this.pcAyar.Name = "pcAyar";
            this.pcAyar.Size = new System.Drawing.Size(38, 50);
            this.pcAyar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAyar.TabIndex = 1;
            this.pcAyar.TabStop = false;
            this.pcAyar.Click += new System.EventHandler(this.pnl_Ayar_Click);
            // 
            // lblAyarlar
            // 
            this.lblAyarlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAyarlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblAyarlar.Location = new System.Drawing.Point(0, 0);
            this.lblAyarlar.Name = "lblAyarlar";
            this.lblAyarlar.Size = new System.Drawing.Size(140, 50);
            this.lblAyarlar.TabIndex = 0;
            this.lblAyarlar.Text = "Ayarlar";
            this.lblAyarlar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAyarlar.Click += new System.EventHandler(this.pnl_Ayar_Click);
            // 
            // pcLogo
            // 
            this.pcLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcLogo.Image")));
            this.pcLogo.Location = new System.Drawing.Point(3, 5);
            this.pcLogo.Name = "pcLogo";
            this.pcLogo.Size = new System.Drawing.Size(100, 100);
            this.pcLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcLogo.TabIndex = 0;
            this.pcLogo.TabStop = false;
            this.pcLogo.Click += new System.EventHandler(this.pcLogo_Click);
            // 
            // pnlSag
            // 
            this.pnlSag.BackColor = System.Drawing.Color.White;
            this.pnlSag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSag.Location = new System.Drawing.Point(140, 50);
            this.pnlSag.Name = "pnlSag";
            this.pnlSag.Size = new System.Drawing.Size(760, 600);
            this.pnlSag.TabIndex = 2;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.pnlSag);
            this.Controls.Add(this.pnlUst);
            this.Controls.Add(this.pnlSol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.pnlUst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).EndInit();
            this.pnlSol.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlAyarlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcAyar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Panel pnlSol;
        private System.Windows.Forms.PictureBox pcCancel;
        private System.Windows.Forms.Panel pnlSag;
        private System.Windows.Forms.PictureBox pcLogo;
        private System.Windows.Forms.Panel pnlAyarlar;
        private System.Windows.Forms.PictureBox pcAyar;
        private System.Windows.Forms.Label lblAyarlar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

