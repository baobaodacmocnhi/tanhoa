namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmCapDinhMucNuocCCCD_Show
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvDSSoDangKy = new System.Windows.Forms.DataGridView();
            this.txtTongCCCD = new System.Windows.Forms.TextBox();
            this.txtTongDanhBo = new System.Windows.Forms.TextBox();
            this.CreateDate_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhacDiaBan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ThuongTru = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TamTru = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayHetHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GiaHan_SCT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Lo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSoDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(157, 6);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 20);
            this.dateTu.TabIndex = 17;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(317, 6);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 20);
            this.dateDen.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Đến Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(413, 3);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 25);
            this.btnXem.TabIndex = 89;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvDSSoDangKy
            // 
            this.dgvDSSoDangKy.AllowUserToAddRows = false;
            this.dgvDSSoDangKy.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSSoDangKy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSSoDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSoDangKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreateDate_CT,
            this.MaCT,
            this.HoTen,
            this.NgaySinh,
            this.DiaChi,
            this.KhacDiaBan,
            this.ThuongTru,
            this.TamTru,
            this.NgayHetHan,
            this.Cat,
            this.GiaHan_SCT,
            this.Lo,
            this.Phong,
            this.GhiChu,
            this.DanhBo,
            this.DienThoai,
            this.MaLCT});
            this.dgvDSSoDangKy.Location = new System.Drawing.Point(0, 32);
            this.dgvDSSoDangKy.MultiSelect = false;
            this.dgvDSSoDangKy.Name = "dgvDSSoDangKy";
            this.dgvDSSoDangKy.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvDSSoDangKy.Size = new System.Drawing.Size(1351, 370);
            this.dgvDSSoDangKy.TabIndex = 90;
            this.dgvDSSoDangKy.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSSoDangKy_RowPostPaint);
            // 
            // txtTongCCCD
            // 
            this.txtTongCCCD.Location = new System.Drawing.Point(142, 402);
            this.txtTongCCCD.Name = "txtTongCCCD";
            this.txtTongCCCD.Size = new System.Drawing.Size(100, 20);
            this.txtTongCCCD.TabIndex = 91;
            // 
            // txtTongDanhBo
            // 
            this.txtTongDanhBo.Location = new System.Drawing.Point(1207, 402);
            this.txtTongDanhBo.Name = "txtTongDanhBo";
            this.txtTongDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtTongDanhBo.TabIndex = 92;
            // 
            // CreateDate_CT
            // 
            this.CreateDate_CT.DataPropertyName = "CreateDate";
            this.CreateDate_CT.HeaderText = "Ngày Lập";
            this.CreateDate_CT.Name = "CreateDate_CT";
            // 
            // MaCT
            // 
            this.MaCT.DataPropertyName = "MaCT";
            this.MaCT.HeaderText = "Số Chứng Từ";
            this.MaCT.Name = "MaCT";
            this.MaCT.Width = 110;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 200;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày Sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Width = 85;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 250;
            // 
            // KhacDiaBan
            // 
            this.KhacDiaBan.DataPropertyName = "KhacDiaBan";
            this.KhacDiaBan.HeaderText = "Khác Địa Bàn";
            this.KhacDiaBan.Name = "KhacDiaBan";
            this.KhacDiaBan.Width = 40;
            // 
            // ThuongTru
            // 
            this.ThuongTru.DataPropertyName = "ThuongTru";
            this.ThuongTru.HeaderText = "Thường Trú";
            this.ThuongTru.Name = "ThuongTru";
            this.ThuongTru.Width = 50;
            // 
            // TamTru
            // 
            this.TamTru.DataPropertyName = "TamTru";
            this.TamTru.HeaderText = "Tạm Trú";
            this.TamTru.Name = "TamTru";
            this.TamTru.Width = 40;
            // 
            // NgayHetHan
            // 
            this.NgayHetHan.DataPropertyName = "NgayHetHan";
            this.NgayHetHan.HeaderText = "Ngày Hết Hạn";
            this.NgayHetHan.Name = "NgayHetHan";
            this.NgayHetHan.Width = 85;
            // 
            // Cat
            // 
            this.Cat.DataPropertyName = "Cat";
            this.Cat.HeaderText = "Cắt";
            this.Cat.Name = "Cat";
            this.Cat.Width = 30;
            // 
            // GiaHan_SCT
            // 
            this.GiaHan_SCT.DataPropertyName = "GiaHan";
            this.GiaHan_SCT.HeaderText = "Gia Hạn";
            this.GiaHan_SCT.Name = "GiaHan_SCT";
            this.GiaHan_SCT.Visible = false;
            this.GiaHan_SCT.Width = 40;
            // 
            // Lo
            // 
            this.Lo.DataPropertyName = "Lo";
            this.Lo.HeaderText = "Lô";
            this.Lo.Name = "Lo";
            this.Lo.Width = 30;
            // 
            // Phong
            // 
            this.Phong.DataPropertyName = "Phong";
            this.Phong.HeaderText = "Phòng";
            this.Phong.Name = "Phong";
            this.Phong.Width = 50;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "Điện Thoại";
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DienThoai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DienThoai.Width = 90;
            // 
            // MaLCT
            // 
            this.MaLCT.DataPropertyName = "MaLCT";
            this.MaLCT.HeaderText = "MaLCT";
            this.MaLCT.Name = "MaLCT";
            this.MaLCT.Visible = false;
            // 
            // frmCapDinhMucNuocCCCD_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1354, 426);
            this.Controls.Add(this.txtTongDanhBo);
            this.Controls.Add(this.txtTongCCCD);
            this.Controls.Add(this.dgvDSSoDangKy);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "frmCapDinhMucNuocCCCD_Show";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh Sách CCCD đã nhập";
            this.Load += new System.EventHandler(this.frmCapDinhMucNuocCCCD_Show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSoDangKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvDSSoDangKy;
        private System.Windows.Forms.TextBox txtTongCCCD;
        private System.Windows.Forms.TextBox txtTongDanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn KhacDiaBan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ThuongTru;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TamTru;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHetHan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GiaHan_SCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLCT;
    }
}