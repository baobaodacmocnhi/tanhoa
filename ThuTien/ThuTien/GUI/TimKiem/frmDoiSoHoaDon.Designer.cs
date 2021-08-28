namespace ThuTien.GUI.TimKiem
{
    partial class frmDoiSoHoaDon
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
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtSoHoaDonMoi = new System.Windows.Forms.TextBox();
            this.btnResetThanhToan = new System.Windows.Forms.Button();
            this.btnRestNopTien = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnNopTien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Hóa Đơn Mới:";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(218, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtSoHoaDonMoi
            // 
            this.txtSoHoaDonMoi.Location = new System.Drawing.Point(112, 12);
            this.txtSoHoaDonMoi.Name = "txtSoHoaDonMoi";
            this.txtSoHoaDonMoi.Size = new System.Drawing.Size(100, 20);
            this.txtSoHoaDonMoi.TabIndex = 1;
            // 
            // btnResetThanhToan
            // 
            this.btnResetThanhToan.Location = new System.Drawing.Point(218, 39);
            this.btnResetThanhToan.Name = "btnResetThanhToan";
            this.btnResetThanhToan.Size = new System.Drawing.Size(110, 23);
            this.btnResetThanhToan.TabIndex = 3;
            this.btnResetThanhToan.Text = "Reset Thanh Toán";
            this.btnResetThanhToan.UseVisualStyleBackColor = true;
            this.btnResetThanhToan.Click += new System.EventHandler(this.btnResetThanhToan_Click);
            // 
            // btnRestNopTien
            // 
            this.btnRestNopTien.Location = new System.Drawing.Point(218, 68);
            this.btnRestNopTien.Name = "btnRestNopTien";
            this.btnRestNopTien.Size = new System.Drawing.Size(110, 23);
            this.btnRestNopTien.TabIndex = 4;
            this.btnRestNopTien.Text = "Reset Nộp Tiền";
            this.btnRestNopTien.UseVisualStyleBackColor = true;
            this.btnRestNopTien.Click += new System.EventHandler(this.btnRestNopTien_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(112, 39);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(75, 23);
            this.btnThanhToan.TabIndex = 5;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnNopTien
            // 
            this.btnNopTien.Location = new System.Drawing.Point(112, 67);
            this.btnNopTien.Name = "btnNopTien";
            this.btnNopTien.Size = new System.Drawing.Size(75, 23);
            this.btnNopTien.TabIndex = 6;
            this.btnNopTien.Text = "Nộp Tiền";
            this.btnNopTien.UseVisualStyleBackColor = true;
            this.btnNopTien.Click += new System.EventHandler(this.btnNopTien_Click);
            // 
            // frmDoiSoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(341, 102);
            this.Controls.Add(this.btnNopTien);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnRestNopTien);
            this.Controls.Add(this.btnResetThanhToan);
            this.Controls.Add(this.txtSoHoaDonMoi);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiSoHoaDon";
            this.Text = "Đổi Số Hóa Đơn";
            this.Load += new System.EventHandler(this.frmDoiSoHoaDon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtSoHoaDonMoi;
        private System.Windows.Forms.Button btnResetThanhToan;
        private System.Windows.Forms.Button btnRestNopTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnNopTien;
    }
}