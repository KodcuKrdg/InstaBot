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
            this.pnlYorum = new System.Windows.Forms.Panel();
            this.pcYorum = new System.Windows.Forms.PictureBox();
            this.lblYorum = new System.Windows.Forms.Label();
            this.pnlBegen = new System.Windows.Forms.Panel();
            this.pcBegen = new System.Windows.Forms.PictureBox();
            this.lblBegen = new System.Windows.Forms.Label();
            this.pnlGiris = new System.Windows.Forms.Panel();
            this.pcGiris = new System.Windows.Forms.PictureBox();
            this.lblGiris = new System.Windows.Forms.Label();
            this.pcLogo = new System.Windows.Forms.PictureBox();
            this.pnlAyrac = new System.Windows.Forms.Panel();
            this.pnlSag = new System.Windows.Forms.Panel();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).BeginInit();
            this.pnlSol.SuspendLayout();
            this.pnlYorum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcYorum)).BeginInit();
            this.pnlBegen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBegen)).BeginInit();
            this.pnlGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcGiris)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.pnlUst.Controls.Add(this.pcCancel);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(160, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(640, 45);
            this.pnlUst.TabIndex = 0;
            this.pnlUst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseDown);
            this.pnlUst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseMove);
            this.pnlUst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseUp);
            // 
            // pcCancel
            // 
            this.pcCancel.Image = ((System.Drawing.Image)(resources.GetObject("pcCancel.Image")));
            this.pcCancel.Location = new System.Drawing.Point(589, 5);
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
            this.pnlSol.Controls.Add(this.pnlYorum);
            this.pnlSol.Controls.Add(this.pnlBegen);
            this.pnlSol.Controls.Add(this.pnlGiris);
            this.pnlSol.Controls.Add(this.pcLogo);
            this.pnlSol.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSol.ForeColor = System.Drawing.Color.White;
            this.pnlSol.Location = new System.Drawing.Point(0, 0);
            this.pnlSol.Name = "pnlSol";
            this.pnlSol.Size = new System.Drawing.Size(160, 600);
            this.pnlSol.TabIndex = 3;
            // 
            // pnlYorum
            // 
            this.pnlYorum.Controls.Add(this.pcYorum);
            this.pnlYorum.Controls.Add(this.lblYorum);
            this.pnlYorum.Location = new System.Drawing.Point(3, 398);
            this.pnlYorum.Name = "pnlYorum";
            this.pnlYorum.Size = new System.Drawing.Size(160, 80);
            this.pnlYorum.TabIndex = 3;
            // 
            // pcYorum
            // 
            this.pcYorum.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcYorum.Image = ((System.Drawing.Image)(resources.GetObject("pcYorum.Image")));
            this.pcYorum.Location = new System.Drawing.Point(102, 0);
            this.pcYorum.Name = "pcYorum";
            this.pcYorum.Size = new System.Drawing.Size(58, 80);
            this.pcYorum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcYorum.TabIndex = 1;
            this.pcYorum.TabStop = false;
            // 
            // lblYorum
            // 
            this.lblYorum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYorum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblYorum.Location = new System.Drawing.Point(0, 0);
            this.lblYorum.Name = "lblYorum";
            this.lblYorum.Size = new System.Drawing.Size(160, 80);
            this.lblYorum.TabIndex = 0;
            this.lblYorum.Text = "Yorum Yap";
            this.lblYorum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBegen
            // 
            this.pnlBegen.Controls.Add(this.pcBegen);
            this.pnlBegen.Controls.Add(this.lblBegen);
            this.pnlBegen.Location = new System.Drawing.Point(3, 312);
            this.pnlBegen.Name = "pnlBegen";
            this.pnlBegen.Size = new System.Drawing.Size(160, 80);
            this.pnlBegen.TabIndex = 2;
            // 
            // pcBegen
            // 
            this.pcBegen.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcBegen.Image = ((System.Drawing.Image)(resources.GetObject("pcBegen.Image")));
            this.pcBegen.Location = new System.Drawing.Point(102, 0);
            this.pcBegen.Name = "pcBegen";
            this.pcBegen.Size = new System.Drawing.Size(58, 80);
            this.pcBegen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcBegen.TabIndex = 1;
            this.pcBegen.TabStop = false;
            this.pcBegen.Click += new System.EventHandler(this.pnl_Begen_Click);
            // 
            // lblBegen
            // 
            this.lblBegen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBegen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblBegen.Location = new System.Drawing.Point(0, 0);
            this.lblBegen.Name = "lblBegen";
            this.lblBegen.Size = new System.Drawing.Size(160, 80);
            this.lblBegen.TabIndex = 0;
            this.lblBegen.Text = "Beğen";
            this.lblBegen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBegen.Click += new System.EventHandler(this.pnl_Begen_Click);
            // 
            // pnlGiris
            // 
            this.pnlGiris.Controls.Add(this.pcGiris);
            this.pnlGiris.Controls.Add(this.lblGiris);
            this.pnlGiris.Location = new System.Drawing.Point(3, 226);
            this.pnlGiris.Name = "pnlGiris";
            this.pnlGiris.Size = new System.Drawing.Size(160, 80);
            this.pnlGiris.TabIndex = 1;
            // 
            // pcGiris
            // 
            this.pcGiris.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcGiris.Image = ((System.Drawing.Image)(resources.GetObject("pcGiris.Image")));
            this.pcGiris.Location = new System.Drawing.Point(102, 0);
            this.pcGiris.Name = "pcGiris";
            this.pcGiris.Size = new System.Drawing.Size(58, 80);
            this.pcGiris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcGiris.TabIndex = 1;
            this.pcGiris.TabStop = false;
            this.pcGiris.Click += new System.EventHandler(this.pnl_GirisYap_Click);
            // 
            // lblGiris
            // 
            this.lblGiris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGiris.Location = new System.Drawing.Point(0, 0);
            this.lblGiris.Name = "lblGiris";
            this.lblGiris.Size = new System.Drawing.Size(160, 80);
            this.lblGiris.TabIndex = 0;
            this.lblGiris.Text = "Giriş Yap";
            this.lblGiris.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGiris.Click += new System.EventHandler(this.pnl_GirisYap_Click);
            // 
            // pcLogo
            // 
            this.pcLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcLogo.Image")));
            this.pcLogo.Location = new System.Drawing.Point(3, 5);
            this.pcLogo.Name = "pcLogo";
            this.pcLogo.Size = new System.Drawing.Size(150, 150);
            this.pcLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcLogo.TabIndex = 0;
            this.pcLogo.TabStop = false;
            // 
            // pnlAyrac
            // 
            this.pnlAyrac.Location = new System.Drawing.Point(0, 0);
            this.pnlAyrac.Name = "pnlAyrac";
            this.pnlAyrac.Size = new System.Drawing.Size(200, 100);
            this.pnlAyrac.TabIndex = 0;
            // 
            // pnlSag
            // 
            this.pnlSag.BackColor = System.Drawing.Color.White;
            this.pnlSag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSag.Location = new System.Drawing.Point(0, 0);
            this.pnlSag.Name = "pnlSag";
            this.pnlSag.Size = new System.Drawing.Size(800, 600);
            this.pnlSag.TabIndex = 2;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlUst);
            this.Controls.Add(this.pnlSol);
            this.Controls.Add(this.pnlSag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.pnlUst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).EndInit();
            this.pnlSol.ResumeLayout(false);
            this.pnlYorum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcYorum)).EndInit();
            this.pnlBegen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcBegen)).EndInit();
            this.pnlGiris.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcGiris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Panel pnlSol;
        private System.Windows.Forms.PictureBox pcCancel;
        private System.Windows.Forms.Panel pnlAyrac;
        private System.Windows.Forms.Panel pnlSag;
        private System.Windows.Forms.PictureBox pcLogo;
        private System.Windows.Forms.Panel pnlGiris;
        private System.Windows.Forms.PictureBox pcGiris;
        private System.Windows.Forms.Label lblGiris;
        private System.Windows.Forms.Panel pnlBegen;
        private System.Windows.Forms.PictureBox pcBegen;
        private System.Windows.Forms.Label lblBegen;
        private System.Windows.Forms.Panel pnlYorum;
        private System.Windows.Forms.PictureBox pcYorum;
        private System.Windows.Forms.Label lblYorum;
    }
}

