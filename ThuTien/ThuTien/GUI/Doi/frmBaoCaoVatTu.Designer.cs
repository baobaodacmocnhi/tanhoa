namespace ThuTien.GUI.Doi
{
    partial class frmBaoCaoVatTu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dgvBamChi = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.radDongNuoc = new System.Windows.Forms.RadioButton();
            this.radMoNuoc = new System.Windows.Forms.RadioButton();
            this.MaKQDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duyet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSoDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NiemChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DongNuoc2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NiemChi1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSoDN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MauSac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSoMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NiemChiMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MauSacMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhoaTu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.KhoaKhac = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBamChi)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Đến Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(393, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(95, 20);
            this.dateDen.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Từ Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(494, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 17;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(228, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(95, 20);
            this.dateTu.TabIndex = 16;
            // 
            // dgvBamChi
            // 
            this.dgvBamChi.AllowUserToAddRows = false;
            this.dgvBamChi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBamChi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBamChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBamChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKQDN,
            this.DanhBo,
            this.Duyet,
            this.HoTen,
            this.DiaChi,
            this.Hieu,
            this.Co,
            this.ChiSoDN,
            this.NgayDN,
            this.NiemChi,
            this.DongNuoc2,
            this.NiemChi1,
            this.NgayDN1,
            this.ChiSoDN1,
            this.MauSac,
            this.ChiSoMN,
            this.NgayMN,
            this.NiemChiMN,
            this.MauSacMN,
            this.KhoaTu,
            this.KhoaKhac,
            this.To,
            this.NhanVien});
            this.dgvBamChi.Location = new System.Drawing.Point(12, 38);
            this.dgvBamChi.MultiSelect = false;
            this.dgvBamChi.Name = "dgvBamChi";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBamChi.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBamChi.Size = new System.Drawing.Size(1212, 589);
            this.dgvBamChi.TabIndex = 20;
            this.dgvBamChi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBamChi_CellFormatting);
            this.dgvBamChi.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBamChi_CellValidating);
            this.dgvBamChi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBamChi_RowPostPaint);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(575, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 21;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // radDongNuoc
            // 
            this.radDongNuoc.AutoSize = true;
            this.radDongNuoc.Checked = true;
            this.radDongNuoc.Location = new System.Drawing.Point(12, 13);
            this.radDongNuoc.Name = "radDongNuoc";
            this.radDongNuoc.Size = new System.Drawing.Size(80, 17);
            this.radDongNuoc.TabIndex = 22;
            this.radDongNuoc.TabStop = true;
            this.radDongNuoc.Text = "Đóng Nước";
            this.radDongNuoc.UseVisualStyleBackColor = true;
            this.radDongNuoc.CheckedChanged += new System.EventHandler(this.radDongNuoc_CheckedChanged);
            // 
            // radMoNuoc
            // 
            this.radMoNuoc.AutoSize = true;
            this.radMoNuoc.Location = new System.Drawing.Point(98, 13);
            this.radMoNuoc.Name = "radMoNuoc";
            this.radMoNuoc.Size = new System.Drawing.Size(69, 17);
            this.radMoNuoc.TabIndex = 23;
            this.radMoNuoc.Text = "Mở Nước";
            this.radMoNuoc.UseVisualStyleBackColor = true;
            this.radMoNuoc.CheckedChanged += new System.EventHandler(this.radMoNuoc_CheckedChanged);
            // 
            // MaKQDN
            // 
            this.MaKQDN.DataPropertyName = "MaKQDN";
            this.MaKQDN.HeaderText = "MaKQDN";
            this.MaKQDN.Name = "MaKQDN";
            this.MaKQDN.Visible = false;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // Duyet
            // 
            this.Duyet.DataPropertyName = "Duyet";
            this.Duyet.HeaderText = "Duyệt";
            this.Duyet.Name = "Duyet";
            this.Duyet.Width = 40;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // Hieu
            // 
            this.Hieu.DataPropertyName = "Hieu";
            this.Hieu.HeaderText = "Hiệu";
            this.Hieu.Name = "Hieu";
            this.Hieu.Width = 80;
            // 
            // Co
            // 
            this.Co.DataPropertyName = "Co";
            this.Co.HeaderText = "Cỡ";
            this.Co.Name = "Co";
            this.Co.Width = 40;
            // 
            // ChiSoDN
            // 
            this.ChiSoDN.DataPropertyName = "ChiSoDN";
            this.ChiSoDN.HeaderText = "Chỉ Số";
            this.ChiSoDN.Name = "ChiSoDN";
            this.ChiSoDN.Width = 50;
            // 
            // NgayDN
            // 
            this.NgayDN.DataPropertyName = "NgayDN";
            this.NgayDN.HeaderText = "Ngày ĐN";
            this.NgayDN.Name = "NgayDN";
            // 
            // NiemChi
            // 
            this.NiemChi.DataPropertyName = "NiemChi";
            this.NiemChi.HeaderText = "Niêm Chì";
            this.NiemChi.Name = "NiemChi";
            this.NiemChi.Width = 70;
            // 
            // DongNuoc2
            // 
            this.DongNuoc2.DataPropertyName = "DongNuoc2";
            this.DongNuoc2.HeaderText = "DongNuoc2";
            this.DongNuoc2.Name = "DongNuoc2";
            this.DongNuoc2.Visible = false;
            // 
            // NiemChi1
            // 
            this.NiemChi1.DataPropertyName = "NiemChi1";
            this.NiemChi1.HeaderText = "Niêm Chì 1";
            this.NiemChi1.Name = "NiemChi1";
            this.NiemChi1.Width = 70;
            // 
            // NgayDN1
            // 
            this.NgayDN1.DataPropertyName = "NgayDN1";
            this.NgayDN1.HeaderText = "NgayDN1";
            this.NgayDN1.Name = "NgayDN1";
            this.NgayDN1.Visible = false;
            // 
            // ChiSoDN1
            // 
            this.ChiSoDN1.DataPropertyName = "ChiSoDN1";
            this.ChiSoDN1.HeaderText = "ChiSo1";
            this.ChiSoDN1.Name = "ChiSoDN1";
            this.ChiSoDN1.Visible = false;
            // 
            // MauSac
            // 
            this.MauSac.DataPropertyName = "MauSac";
            this.MauSac.HeaderText = "Màu Sắc";
            this.MauSac.Name = "MauSac";
            this.MauSac.Width = 50;
            // 
            // ChiSoMN
            // 
            this.ChiSoMN.DataPropertyName = "ChiSoMN";
            this.ChiSoMN.HeaderText = "Chỉ Số";
            this.ChiSoMN.Name = "ChiSoMN";
            this.ChiSoMN.Visible = false;
            this.ChiSoMN.Width = 50;
            // 
            // NgayMN
            // 
            this.NgayMN.DataPropertyName = "NgayMN";
            this.NgayMN.HeaderText = "Ngày MN";
            this.NgayMN.Name = "NgayMN";
            this.NgayMN.Visible = false;
            // 
            // NiemChiMN
            // 
            this.NiemChiMN.DataPropertyName = "NiemChiMN";
            this.NiemChiMN.HeaderText = "Niêm Chì MN";
            this.NiemChiMN.Name = "NiemChiMN";
            this.NiemChiMN.Visible = false;
            this.NiemChiMN.Width = 70;
            // 
            // MauSacMN
            // 
            this.MauSacMN.DataPropertyName = "MauSacMN";
            this.MauSacMN.HeaderText = "Màu Sắc";
            this.MauSacMN.Name = "MauSacMN";
            this.MauSacMN.Visible = false;
            this.MauSacMN.Width = 50;
            // 
            // KhoaTu
            // 
            this.KhoaTu.DataPropertyName = "KhoaTu";
            this.KhoaTu.HeaderText = "Khóa Từ";
            this.KhoaTu.Name = "KhoaTu";
            this.KhoaTu.Width = 40;
            // 
            // KhoaKhac
            // 
            this.KhoaKhac.DataPropertyName = "KhoaKhac";
            this.KhoaKhac.HeaderText = "Khóa Khác";
            this.KhoaKhac.Name = "KhoaKhac";
            this.KhoaKhac.Width = 40;
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "Tổ";
            this.To.Name = "To";
            this.To.Width = 40;
            // 
            // NhanVien
            // 
            this.NhanVien.DataPropertyName = "NhanVien";
            this.NhanVien.HeaderText = "Nhân Viên";
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Width = 80;
            // 
            // frmBaoCaoVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1241, 640);
            this.Controls.Add(this.radMoNuoc);
            this.Controls.Add(this.radDongNuoc);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvBamChi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateTu);
            this.Name = "frmBaoCaoVatTu";
            this.Text = "Báo Cáo Vật Tư";
            this.Load += new System.EventHandler(this.frmBaoCaoVatTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBamChi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DataGridView dgvBamChi;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.RadioButton radDongNuoc;
        private System.Windows.Forms.RadioButton radMoNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKQDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Duyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSoDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NiemChi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DongNuoc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NiemChi1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSoDN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MauSac;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSoMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NiemChiMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MauSacMN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn KhoaTu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn KhoaKhac;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanVien;
    }
}