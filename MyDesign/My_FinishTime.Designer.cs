﻿namespace InstaBot.MyDesign
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
            this.lblAdim = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAdimMax = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIslem
            // 
            this.lblIslem.AutoSize = true;
            this.lblIslem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIslem.Location = new System.Drawing.Point(3, 3);
            this.lblIslem.Name = "lblIslem";
            this.lblIslem.Size = new System.Drawing.Size(72, 16);
            this.lblIslem.TabIndex = 36;
            this.lblIslem.Text = "İşlem Adı";
            // 
            // prgrsBar
            // 
            this.prgrsBar.Location = new System.Drawing.Point(3, 46);
            this.prgrsBar.Name = "prgrsBar";
            this.prgrsBar.Size = new System.Drawing.Size(369, 27);
            this.prgrsBar.TabIndex = 16;
            // 
            // lblDk
            // 
            this.lblDk.AutoSize = true;
            this.lblDk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDk.Location = new System.Drawing.Point(280, 13);
            this.lblDk.Name = "lblDk";
            this.lblDk.Size = new System.Drawing.Size(19, 20);
            this.lblDk.TabIndex = 38;
            this.lblDk.Text = "o";
            this.lblDk.TextChanged += new System.EventHandler(this.lblDk_TextChanged);
            // 
            // lblTextDk
            // 
            this.lblTextDk.AutoSize = true;
            this.lblTextDk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTextDk.Location = new System.Drawing.Point(306, 13);
            this.lblTextDk.Name = "lblTextDk";
            this.lblTextDk.Size = new System.Drawing.Size(64, 20);
            this.lblTextDk.TabIndex = 39;
            this.lblTextDk.Text = "Dakika";
            // 
            // lblSa
            // 
            this.lblSa.AutoSize = true;
            this.lblSa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSa.Location = new System.Drawing.Point(202, 13);
            this.lblSa.Name = "lblSa";
            this.lblSa.Size = new System.Drawing.Size(19, 20);
            this.lblSa.TabIndex = 40;
            this.lblSa.Text = "o";
            this.lblSa.TextChanged += new System.EventHandler(this.lblSa_TextChanged);
            // 
            // lblTextSa
            // 
            this.lblTextSa.AutoSize = true;
            this.lblTextSa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTextSa.Location = new System.Drawing.Point(224, 13);
            this.lblTextSa.Name = "lblTextSa";
            this.lblTextSa.Size = new System.Drawing.Size(57, 20);
            this.lblTextSa.TabIndex = 41;
            this.lblTextSa.Text = "Saaat";
            // 
            // lblAdim
            // 
            this.lblAdim.AutoSize = true;
            this.lblAdim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdim.Location = new System.Drawing.Point(3, 27);
            this.lblAdim.Name = "lblAdim";
            this.lblAdim.Size = new System.Drawing.Size(29, 16);
            this.lblAdim.TabIndex = 42;
            this.lblAdim.Text = "320";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(27, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "/";
            // 
            // lblAdimMax
            // 
            this.lblAdimMax.AutoSize = true;
            this.lblAdimMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdimMax.Location = new System.Drawing.Point(35, 27);
            this.lblAdimMax.Name = "lblAdimMax";
            this.lblAdimMax.Size = new System.Drawing.Size(29, 16);
            this.lblAdimMax.TabIndex = 44;
            this.lblAdimMax.Text = "400";
            // 
            // My_FinishTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.lblAdimMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAdim);
            this.Controls.Add(this.lblTextSa);
            this.Controls.Add(this.lblSa);
            this.Controls.Add(this.lblTextDk);
            this.Controls.Add(this.lblDk);
            this.Controls.Add(this.lblIslem);
            this.Controls.Add(this.prgrsBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "My_FinishTime";
            this.Size = new System.Drawing.Size(375, 80);
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
        private System.Windows.Forms.Label lblAdim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAdimMax;
    }
}
