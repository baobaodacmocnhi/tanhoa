namespace GIAYKHEN
{
    partial class frmNhap
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
            this.btnImport = new System.Windows.Forms.Button();
            this.radCongDoan = new System.Windows.Forms.RadioButton();
            this.radDoanThanhNien = new System.Windows.Forms.RadioButton();
            this.radCongTy = new System.Windows.Forms.RadioButton();
            this.radHCM = new System.Windows.Forms.RadioButton();
            this.radDanVanKheo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(137, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // radCongDoan
            // 
            this.radCongDoan.AutoSize = true;
            this.radCongDoan.Location = new System.Drawing.Point(12, 35);
            this.radCongDoan.Name = "radCongDoan";
            this.radCongDoan.Size = new System.Drawing.Size(79, 17);
            this.radCongDoan.TabIndex = 3;
            this.radCongDoan.TabStop = true;
            this.radCongDoan.Text = "Công Đoàn";
            this.radCongDoan.UseVisualStyleBackColor = true;
            // 
            // radDoanThanhNien
            // 
            this.radDoanThanhNien.AutoSize = true;
            this.radDoanThanhNien.Location = new System.Drawing.Point(12, 58);
            this.radDoanThanhNien.Name = "radDoanThanhNien";
            this.radDoanThanhNien.Size = new System.Drawing.Size(110, 17);
            this.radDoanThanhNien.TabIndex = 4;
            this.radDoanThanhNien.TabStop = true;
            this.radDoanThanhNien.Text = "Đoàn Thanh Niên";
            this.radDoanThanhNien.UseVisualStyleBackColor = true;
            // 
            // radCongTy
            // 
            this.radCongTy.AutoSize = true;
            this.radCongTy.Location = new System.Drawing.Point(12, 12);
            this.radCongTy.Name = "radCongTy";
            this.radCongTy.Size = new System.Drawing.Size(65, 17);
            this.radCongTy.TabIndex = 5;
            this.radCongTy.TabStop = true;
            this.radCongTy.Text = "Công Ty";
            this.radCongTy.UseVisualStyleBackColor = true;
            // 
            // radHCM
            // 
            this.radHCM.AutoSize = true;
            this.radHCM.Location = new System.Drawing.Point(12, 81);
            this.radHCM.Name = "radHCM";
            this.radHCM.Size = new System.Drawing.Size(49, 17);
            this.radHCM.TabIndex = 6;
            this.radHCM.TabStop = true;
            this.radHCM.Text = "HCM";
            this.radHCM.UseVisualStyleBackColor = true;
            // 
            // radDanVanKheo
            // 
            this.radDanVanKheo.AutoSize = true;
            this.radDanVanKheo.Location = new System.Drawing.Point(12, 104);
            this.radDanVanKheo.Name = "radDanVanKheo";
            this.radDanVanKheo.Size = new System.Drawing.Size(95, 17);
            this.radDanVanKheo.TabIndex = 7;
            this.radDanVanKheo.TabStop = true;
            this.radDanVanKheo.Text = "Dân Vận Khéo";
            this.radDanVanKheo.UseVisualStyleBackColor = true;
            // 
            // frmNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 136);
            this.Controls.Add(this.radDanVanKheo);
            this.Controls.Add(this.radHCM);
            this.Controls.Add(this.radCongTy);
            this.Controls.Add(this.radDoanThanhNien);
            this.Controls.Add(this.radCongDoan);
            this.Controls.Add(this.btnImport);
            this.Name = "frmNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.RadioButton radCongDoan;
        private System.Windows.Forms.RadioButton radDoanThanhNien;
        private System.Windows.Forms.RadioButton radCongTy;
        private System.Windows.Forms.RadioButton radHCM;
        private System.Windows.Forms.RadioButton radDanVanKheo;

    }
}