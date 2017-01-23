namespace Sinema
{
    partial class AnaMenu
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
            this.button_satis = new System.Windows.Forms.Button();
            this.button_guncelle = new System.Windows.Forms.Button();
            this.button_iptal = new System.Windows.Forms.Button();
            this.label_1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_satis
            // 
            this.button_satis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_satis.Location = new System.Drawing.Point(143, 183);
            this.button_satis.Name = "button_satis";
            this.button_satis.Size = new System.Drawing.Size(156, 96);
            this.button_satis.TabIndex = 0;
            this.button_satis.Text = "Bilet Satış";
            this.button_satis.UseVisualStyleBackColor = true;
            this.button_satis.Click += new System.EventHandler(this.button_satis_Click);
            // 
            // button_guncelle
            // 
            this.button_guncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_guncelle.Location = new System.Drawing.Point(305, 183);
            this.button_guncelle.Name = "button_guncelle";
            this.button_guncelle.Size = new System.Drawing.Size(156, 96);
            this.button_guncelle.TabIndex = 1;
            this.button_guncelle.Text = "Bilet Güncelle";
            this.button_guncelle.UseVisualStyleBackColor = true;
            this.button_guncelle.Click += new System.EventHandler(this.button_guncelle_Click);
            // 
            // button_iptal
            // 
            this.button_iptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_iptal.Location = new System.Drawing.Point(467, 183);
            this.button_iptal.Name = "button_iptal";
            this.button_iptal.Size = new System.Drawing.Size(156, 96);
            this.button_iptal.TabIndex = 2;
            this.button_iptal.Text = "Bilet İptal";
            this.button_iptal.UseVisualStyleBackColor = true;
            this.button_iptal.Click += new System.EventHandler(this.button_iptal_Click);
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_1.Location = new System.Drawing.Point(12, 9);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(191, 24);
            this.label_1.TabIndex = 3;
            this.label_1.Text = "Giriş Yapan Kullanıcı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(209, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // AnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.button_iptal);
            this.Controls.Add(this.button_guncelle);
            this.Controls.Add(this.button_satis);
            this.MaximizeBox = false;
            this.Name = "AnaMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menü";
            this.Load += new System.EventHandler(this.AnaMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_satis;
        private System.Windows.Forms.Button button_guncelle;
        private System.Windows.Forms.Button button_iptal;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.Label label2;
    }
}