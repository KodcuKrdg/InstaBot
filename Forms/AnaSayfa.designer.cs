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
            this.pcAyarlar = new System.Windows.Forms.PictureBox();
            this.pcGonderiler = new System.Windows.Forms.PictureBox();
            this.pcGiris = new System.Windows.Forms.PictureBox();
            this.pcLogo = new System.Windows.Forms.PictureBox();
            this.pnlSag = new System.Windows.Forms.Panel();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).BeginInit();
            this.pnlSol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcAyarlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcGonderiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcGiris)).BeginInit();
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
            this.pnlUst.Size = new System.Drawing.Size(800, 50);
            this.pnlUst.TabIndex = 0;
            this.pnlUst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseDown);
            this.pnlUst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseMove);
            this.pnlUst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseUp);
            // 
            // pcCancel
            // 
            this.pcCancel.Image = ((System.Drawing.Image)(resources.GetObject("pcCancel.Image")));
            this.pcCancel.Location = new System.Drawing.Point(750, 10);
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
            this.pnlSol.Controls.Add(this.pcAyarlar);
            this.pnlSol.Controls.Add(this.pcGonderiler);
            this.pnlSol.Controls.Add(this.pcGiris);
            this.pnlSol.Controls.Add(this.pcLogo);
            this.pnlSol.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSol.ForeColor = System.Drawing.Color.White;
            this.pnlSol.Location = new System.Drawing.Point(0, 0);
            this.pnlSol.Name = "pnlSol";
            this.pnlSol.Size = new System.Drawing.Size(140, 650);
            this.pnlSol.TabIndex = 3;
            // 
            // pcAyarlar
            // 
            this.pcAyarlar.Image = ((System.Drawing.Image)(resources.GetObject("pcAyarlar.Image")));
            this.pcAyarlar.Location = new System.Drawing.Point(3, 232);
            this.pcAyarlar.Name = "pcAyarlar";
            this.pcAyarlar.Size = new System.Drawing.Size(135, 50);
            this.pcAyarlar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcAyarlar.TabIndex = 6;
            this.pcAyarlar.TabStop = false;
            this.pcAyarlar.Click += new System.EventHandler(this.pcAyarlar_Click);
            // 
            // pcGonderiler
            // 
            this.pcGonderiler.Image = ((System.Drawing.Image)(resources.GetObject("pcGonderiler.Image")));
            this.pcGonderiler.Location = new System.Drawing.Point(3, 288);
            this.pcGonderiler.Name = "pcGonderiler";
            this.pcGonderiler.Size = new System.Drawing.Size(135, 50);
            this.pcGonderiler.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcGonderiler.TabIndex = 5;
            this.pcGonderiler.TabStop = false;
            this.pcGonderiler.Click += new System.EventHandler(this.pcGonderiler_Click);
            // 
            // pcGiris
            // 
            this.pcGiris.Image = ((System.Drawing.Image)(resources.GetObject("pcGiris.Image")));
            this.pcGiris.Location = new System.Drawing.Point(3, 401);
            this.pcGiris.Name = "pcGiris";
            this.pcGiris.Size = new System.Drawing.Size(135, 50);
            this.pcGiris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcGiris.TabIndex = 4;
            this.pcGiris.TabStop = false;
            this.pcGiris.Click += new System.EventHandler(this.pcGiris_Click);
            // 
            // pcLogo
            // 
            this.pcLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcLogo.Image")));
            this.pcLogo.Location = new System.Drawing.Point(3, 3);
            this.pcLogo.Name = "pcLogo";
            this.pcLogo.Size = new System.Drawing.Size(135, 135);
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
            this.pnlSag.Size = new System.Drawing.Size(800, 600);
            this.pnlSag.TabIndex = 2;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 650);
            this.Controls.Add(this.pnlSag);
            this.Controls.Add(this.pnlUst);
            this.Controls.Add(this.pnlSol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaSayfa_FormClosing);
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.pnlUst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).EndInit();
            this.pnlSol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcAyarlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcGonderiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcGiris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Panel pnlSol;
        private System.Windows.Forms.PictureBox pcCancel;
        private System.Windows.Forms.Panel pnlSag;
        private System.Windows.Forms.PictureBox pcLogo;
        private System.Windows.Forms.PictureBox pcGiris;
        private System.Windows.Forms.PictureBox pcAyarlar;
        private System.Windows.Forms.PictureBox pcGonderiler;
    }
}

