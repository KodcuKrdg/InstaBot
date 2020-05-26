namespace InstaBot.MyDesign
{
    partial class My_FinishTime
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

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIslem = new System.Windows.Forms.Label();
            this.prgrsBar = new System.Windows.Forms.ProgressBar();
            this.lblDk = new System.Windows.Forms.Label();
            this.lblTextDk = new System.Windows.Forms.Label();
            this.lblSa = new System.Windows.Forms.Label();
            this.lblTextSa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIslem
            // 
            this.lblIslem.AutoSize = true;
            this.lblIslem.Location = new System.Drawing.Point(3, 0);
            this.lblIslem.Name = "lblIslem";
            this.lblIslem.Size = new System.Drawing.Size(57, 15);
            this.lblIslem.TabIndex = 36;
            this.lblIslem.Text = "İşlem Adı";
            // 
            // prgrsBar
            // 
            this.prgrsBar.Location = new System.Drawing.Point(3, 18);
            this.prgrsBar.Name = "prgrsBar";
            this.prgrsBar.Size = new System.Drawing.Size(174, 27);
            this.prgrsBar.TabIndex = 16;
            // 
            // lblDk
            // 
            this.lblDk.AutoSize = true;
            this.lblDk.Location = new System.Drawing.Point(134, 0);
            this.lblDk.Name = "lblDk";
            this.lblDk.Size = new System.Drawing.Size(14, 15);
            this.lblDk.TabIndex = 38;
            this.lblDk.Text = "o";
            this.lblDk.TextChanged += new System.EventHandler(this.lblDk_TextChanged);
            // 
            // lblTextDk
            // 
            this.lblTextDk.AutoSize = true;
            this.lblTextDk.Location = new System.Drawing.Point(155, 0);
            this.lblTextDk.Name = "lblTextDk";
            this.lblTextDk.Size = new System.Drawing.Size(22, 15);
            this.lblTextDk.TabIndex = 39;
            this.lblTextDk.Text = "Dk";
            // 
            // lblSa
            // 
            this.lblSa.AutoSize = true;
            this.lblSa.Location = new System.Drawing.Point(96, 0);
            this.lblSa.Name = "lblSa";
            this.lblSa.Size = new System.Drawing.Size(14, 15);
            this.lblSa.TabIndex = 40;
            this.lblSa.Text = "o";
            this.lblSa.TextChanged += new System.EventHandler(this.lblSa_TextChanged);
            // 
            // lblTextSa
            // 
            this.lblTextSa.AutoSize = true;
            this.lblTextSa.Location = new System.Drawing.Point(112, 0);
            this.lblTextSa.Name = "lblTextSa";
            this.lblTextSa.Size = new System.Drawing.Size(22, 15);
            this.lblTextSa.TabIndex = 41;
            this.lblTextSa.Text = "Sa";
            // 
            // My_FinishTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTextSa);
            this.Controls.Add(this.lblSa);
            this.Controls.Add(this.lblTextDk);
            this.Controls.Add(this.lblDk);
            this.Controls.Add(this.lblIslem);
            this.Controls.Add(this.prgrsBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "My_FinishTime";
            this.Size = new System.Drawing.Size(180, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIslem;
        private System.Windows.Forms.ProgressBar prgrsBar;
        private System.Windows.Forms.Label lblDk;
        private System.Windows.Forms.Label lblTextDk;
        private System.Windows.Forms.Label lblSa;
        private System.Windows.Forms.Label lblTextSa;
    }
}
