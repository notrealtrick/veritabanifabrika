namespace veritabanifabrika
{
    partial class Giris
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
            this.btnGiris = new System.Windows.Forms.Button();
            this.btnYeniUye = new System.Windows.Forms.Button();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.maskedtxtTC = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.Location = new System.Drawing.Point(483, 286);
            this.btnGiris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(141, 49);
            this.btnGiris.TabIndex = 14;
            this.btnGiris.Text = "GİRİŞ";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // btnYeniUye
            // 
            this.btnYeniUye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniUye.Location = new System.Drawing.Point(195, 286);
            this.btnYeniUye.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnYeniUye.Name = "btnYeniUye";
            this.btnYeniUye.Size = new System.Drawing.Size(133, 49);
            this.btnYeniUye.TabIndex = 15;
            this.btnYeniUye.Text = "YENİ ÜYE";
            this.btnYeniUye.UseVisualStyleBackColor = true;
            this.btnYeniUye.Click += new System.EventHandler(this.btnYeniUye_Click);
            // 
            // txtParola
            // 
            this.txtParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtParola.Location = new System.Drawing.Point(257, 223);
            this.txtParola.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtParola.MaxLength = 11;
            this.txtParola.Name = "txtParola";
            this.txtParola.PasswordChar = '●';
            this.txtParola.Size = new System.Drawing.Size(411, 41);
            this.txtParola.TabIndex = 13;
            this.txtParola.TextChanged += new System.EventHandler(this.txtParola_TextChanged);
            this.txtParola.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParola_KeyPress);
            // 
            // maskedtxtTC
            // 
            this.maskedtxtTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedtxtTC.Location = new System.Drawing.Point(257, 172);
            this.maskedtxtTC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maskedtxtTC.Mask = "00000000000";
            this.maskedtxtTC.Name = "maskedtxtTC";
            this.maskedtxtTC.Size = new System.Drawing.Size(411, 41);
            this.maskedtxtTC.TabIndex = 12;
            this.maskedtxtTC.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedtxtTC_MaskInputRejected);
            this.maskedtxtTC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedtxtTC_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(36, 235);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Parola";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(36, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kullanıcı TC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(209, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "FABRİKAYA HOŞGELDİNİZ";
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(749, 417);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.btnYeniUye);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.maskedtxtTC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "veritabanifabrika Yardımcısı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnYeniUye;
        private System.Windows.Forms.TextBox txtParola;
        public System.Windows.Forms.MaskedTextBox maskedtxtTC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

