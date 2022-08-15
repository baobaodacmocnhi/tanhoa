namespace ThuTien.GUI.TimKiem
{
    partial class frmXuLyHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtSoHoaDonMoi = new System.Windows.Forms.TextBox();
            this.btnResetThanhToan = new System.Windows.Forms.Button();
            this.btnRestNopTien = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnNopTien = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTruoc01072022 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
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
            this.btnResetThanhToan.Location = new System.Drawing.Point(12, 39);
            this.btnResetThanhToan.Name = "btnResetThanhToan";
            this.btnResetThanhToan.Size = new System.Drawing.Size(110, 23);
            this.btnResetThanhToan.TabIndex = 3;
            this.btnResetThanhToan.Text = "Reset Thanh Toán";
            this.btnResetThanhToan.UseVisualStyleBackColor = true;
            this.btnResetThanhToan.Click += new System.EventHandler(this.btnResetThanhToan_Click);
            // 
            // btnRestNopTien
            // 
            this.btnRestNopTien.Location = new System.Drawing.Point(12, 68);
            this.btnRestNopTien.Name = "btnRestNopTien";
            this.btnRestNopTien.Size = new System.Drawing.Size(110, 23);
            this.btnRestNopTien.TabIndex = 4;
            this.btnRestNopTien.Text = "Reset Nộp Tiền";
            this.btnRestNopTien.UseVisualStyleBackColor = true;
            this.btnRestNopTien.Click += new System.EventHandler(this.btnRestNopTien_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(128, 39);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(75, 23);
            this.btnThanhToan.TabIndex = 5;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnNopTien
            // 
            this.btnNopTien.Location = new System.Drawing.Point(128, 68);
            this.btnNopTien.Name = "btnNopTien";
            this.btnNopTien.Size = new System.Drawing.Size(75, 23);
            this.btnNopTien.TabIndex = 6;
            this.btnNopTien.Text = "Nộp Tiền";
            this.btnNopTien.UseVisualStyleBackColor = true;
            this.btnNopTien.Click += new System.EventHandler(this.btnNopTien_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreateDate,
            this.GhiChu,
            this.CreateBy});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDanhSach.Location = new System.Drawing.Point(2, 113);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDanhSach.Size = new System.Drawing.Size(363, 193);
            this.dgvDanhSach.TabIndex = 7;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Lập";
            this.CreateBy.Name = "CreateBy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lịch Sử Đăng Ngân";
            // 
            // chkTruoc01072022
            // 
            this.chkTruoc01072022.AutoSize = true;
            this.chkTruoc01072022.Location = new System.Drawing.Point(213, 45);
            this.chkTruoc01072022.Name = "chkTruoc01072022";
            this.chkTruoc01072022.Size = new System.Drawing.Size(115, 17);
            this.chkTruoc01072022.TabIndex = 9;
            this.chkTruoc01072022.Text = "Trước 01/07/2022";
            this.chkTruoc01072022.UseVisualStyleBackColor = true;
            // 
            // frmXuLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(367, 308);
            this.Controls.Add(this.chkTruoc01072022);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnNopTien);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnRestNopTien);
            this.Controls.Add(this.btnResetThanhToan);
            this.Controls.Add(this.txtSoHoaDonMoi);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXuLyHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xử Lý Hóa Đơn";
            this.Load += new System.EventHandler(this.frmDoiSoHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTruoc01072022;
    }
}