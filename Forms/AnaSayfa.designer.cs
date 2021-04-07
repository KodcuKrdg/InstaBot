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
            this.btnGonderi = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.pcLogo = new System.Windows.Forms.PictureBox();
            this.BtnIslem = new System.Windows.Forms.Button();
            this.pcCancel = new System.Windows.Forms.PictureBox();
            this.pnlSag = new System.Windows.Forms.Panel();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pnlUst.Controls.Add(this.btnGonderi);
            this.pnlUst.Controls.Add(this.btnList);
            this.pnlUst.Controls.Add(this.pcLogo);
            this.pnlUst.Controls.Add(this.BtnIslem);
            this.pnlUst.Controls.Add(this.pcCancel);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(800, 60);
            this.pnlUst.TabIndex = 0;
            this.pnlUst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseDown);
            this.pnlUst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseMove);
            this.pnlUst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseUp);
            // 
            // btnGonderi
            // 
            this.btnGonderi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonderi.Image = ((System.Drawing.Image)(resources.GetObject("btnGonderi.Image")));
            this.btnGonderi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGonderi.Location = new System.Drawing.Point(347, 4);
            this.btnGonderi.Name = "btnGonderi";
            this.btnGonderi.Size = new System.Drawing.Size(152, 50);
            this.btnGonderi.TabIndex = 3;
            this.btnGonderi.Text = "Gönderiler";
            this.btnGonderi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGonderi.UseVisualStyleBackColor = true;
            this.btnGonderi.Visible = false;
            this.btnGonderi.Click += new System.EventHandler(this.btnGonderi_Click);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnList.Image = ((System.Drawing.Image)(resources.GetObject("btnList.Image")));
            this.btnList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnList.Location = new System.Drawing.Point(210, 4);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(131, 50);
            this.btnList.TabIndex = 2;
            this.btnList.Text = "Listeler";
            this.btnList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // pcLogo
            // 
            this.pcLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcLogo.Image")));
            this.pcLogo.Location = new System.Drawing.Point(3, 4);
            this.pcLogo.Name = "pcLogo";
            this.pcLogo.Size = new System.Drawing.Size(50, 50);
            this.pcLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcLogo.TabIndex = 0;
            this.pcLogo.TabStop = false;
            this.pcLogo.Click += new System.EventHandler(this.pcLogo_Click);
            // 
            // BtnIslem
            // 
            this.BtnIslem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnIslem.Image = ((System.Drawing.Image)(resources.GetObject("BtnIslem.Image")));
            this.BtnIslem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIslem.Location = new System.Drawing.Point(73, 4);
            this.BtnIslem.Name = "BtnIslem";
            this.BtnIslem.Size = new System.Drawing.Size(131, 50);
            this.BtnIslem.TabIndex = 1;
            this.BtnIslem.Text = "İşlemler";
            this.BtnIslem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIslem.UseVisualStyleBackColor = true;
            this.BtnIslem.Click += new System.EventHandler(this.BtnIslem_Click);
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
            // pnlSag
            // 
            this.pnlSag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.pnlSag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSag.Location = new System.Drawing.Point(0, 60);
            this.pnlSag.Name = "pnlSag";
            this.pnlSag.Size = new System.Drawing.Size(800, 600);
            this.pnlSag.TabIndex = 2;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 660);
            this.Controls.Add(this.pnlSag);
            this.Controls.Add(this.pnlUst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.pnlUst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.PictureBox pcCancel;
        private System.Windows.Forms.Panel pnlSag;
        private System.Windows.Forms.PictureBox pcLogo;
        private System.Windows.Forms.Button btnGonderi;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button BtnIslem;
    }
}

