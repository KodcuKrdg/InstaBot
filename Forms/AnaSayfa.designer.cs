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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSag = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAyrac = new System.Windows.Forms.Panel();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).BeginInit();
            this.pnlSol.SuspendLayout();
            this.pnlSag.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(191)))), ((int)(((byte)(164)))));
            this.pnlUst.Controls.Add(this.pcCancel);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(862, 45);
            this.pnlUst.TabIndex = 0;
            this.pnlUst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseDown);
            this.pnlUst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseMove);
            this.pnlUst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlUst_MouseUp);
            // 
            // pcCancel
            // 
            this.pcCancel.Image = ((System.Drawing.Image)(resources.GetObject("pcCancel.Image")));
            this.pcCancel.Location = new System.Drawing.Point(812, 5);
            this.pcCancel.Name = "pcCancel";
            this.pcCancel.Size = new System.Drawing.Size(38, 34);
            this.pcCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcCancel.TabIndex = 0;
            this.pcCancel.TabStop = false;
            this.pcCancel.Click += new System.EventHandler(this.pcCancel_Click);
            // 
            // pnlSol
            // 
            this.pnlSol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(191)))), ((int)(((byte)(164)))));
            this.pnlSol.Controls.Add(this.label1);
            this.pnlSol.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSol.Location = new System.Drawing.Point(0, 55);
            this.pnlSol.Name = "pnlSol";
            this.pnlSol.Size = new System.Drawing.Size(129, 475);
            this.pnlSol.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giriş Yap";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlSag
            // 
            this.pnlSag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(206)))));
            this.pnlSag.Controls.Add(this.label2);
            this.pnlSag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSag.Location = new System.Drawing.Point(129, 55);
            this.pnlSag.Name = "pnlSag";
            this.pnlSag.Size = new System.Drawing.Size(733, 475);
            this.pnlSag.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(264, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 55);
            this.label2.TabIndex = 0;
            this.label2.Text = "LOGO";
            // 
            // pnlAyrac
            // 
            this.pnlAyrac.BackColor = System.Drawing.Color.White;
            this.pnlAyrac.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAyrac.Location = new System.Drawing.Point(0, 45);
            this.pnlAyrac.Name = "pnlAyrac";
            this.pnlAyrac.Size = new System.Drawing.Size(862, 10);
            this.pnlAyrac.TabIndex = 1;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 530);
            this.Controls.Add(this.pnlSag);
            this.Controls.Add(this.pnlSol);
            this.Controls.Add(this.pnlAyrac);
            this.Controls.Add(this.pnlUst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.pnlUst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcCancel)).EndInit();
            this.pnlSol.ResumeLayout(false);
            this.pnlSol.PerformLayout();
            this.pnlSag.ResumeLayout(false);
            this.pnlSag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Panel pnlSol;
        private System.Windows.Forms.Panel pnlSag;
        private System.Windows.Forms.Panel pnlAyrac;
        private System.Windows.Forms.PictureBox pcCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

