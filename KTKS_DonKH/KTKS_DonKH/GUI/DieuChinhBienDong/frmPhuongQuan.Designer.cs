namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmPhuongQuan
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbQuan = new System.Windows.Forms.ComboBox();
            this.cmbPhuong = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.chkKhongThoiHan = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quận:";
            // 
            // cmbQuan
            // 
            this.cmbQuan.FormattingEnabled = true;
            this.cmbQuan.Location = new System.Drawing.Point(76, 12);
            this.cmbQuan.Name = "cmbQuan";
            this.cmbQuan.Size = new System.Drawing.Size(150, 25);
            this.cmbQuan.TabIndex = 1;
            this.cmbQuan.SelectedIndexChanged += new System.EventHandler(this.cmbQuan_SelectedIndexChanged);
            // 
            // cmbPhuong
            // 
            this.cmbPhuong.FormattingEnabled = true;
            this.cmbPhuong.Location = new System.Drawing.Point(76, 43);
            this.cmbPhuong.Name = "cmbPhuong";
            this.cmbPhuong.Size = new System.Drawing.Size(150, 25);
            this.cmbPhuong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phường:";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Image = global::KTKS_DonKH.Properties.Resources.find_24x24;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(264, 33);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(94, 35);
            this.btnBaoCao.TabIndex = 20;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // chkKhongThoiHan
            // 
            this.chkKhongThoiHan.AutoSize = true;
            this.chkKhongThoiHan.Location = new System.Drawing.Point(239, 6);
            this.chkKhongThoiHan.Name = "chkKhongThoiHan";
            this.chkKhongThoiHan.Size = new System.Drawing.Size(126, 21);
            this.chkKhongThoiHan.TabIndex = 21;
            this.chkKhongThoiHan.Text = "Không Thời Hạn";
            this.chkKhongThoiHan.UseVisualStyleBackColor = true;
            // 
            // frmPhuongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(377, 87);
            this.Controls.Add(this.chkKhongThoiHan);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.cmbPhuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbQuan);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhuongQuan";
            this.Text = "Phường, Quận";
            this.Load += new System.EventHandler(this.frmPhuongQuan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbQuan;
        private System.Windows.Forms.ComboBox cmbPhuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.CheckBox chkKhongThoiHan;
    }
}