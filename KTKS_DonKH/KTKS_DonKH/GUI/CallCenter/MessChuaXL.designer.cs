namespace KTKS_DonKH.GUI.CallCenter
{
    partial class MessChuaXL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.checkChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sohoso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuyenHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYCHUYENXL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOVICHUYEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayXuLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanVienXuLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noidungxuly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeight = 30;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkChon,
            this.sohoso,
            this.DanhBo,
            this.DienThoai,
            this.TenLoai,
            this.GhiChu,
            this.NgayNhan,
            this.CreateBy,
            this.ChuyenHS,
            this.NGAYCHUYENXL,
            this.DOVICHUYEN,
            this.NgayXuLy,
            this.NhanVienXuLy,
            this.noidungxuly,
            this.TenKH,
            this.DiaChi});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 10;
            this.dataGrid.RowTemplate.Height = 30;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid.Size = new System.Drawing.Size(1383, 262);
            this.dataGrid.TabIndex = 730;
            // 
            // checkChon
            // 
            this.checkChon.FillWeight = 130F;
            this.checkChon.HeaderText = "";
            this.checkChon.Name = "checkChon";
            this.checkChon.Visible = false;
            this.checkChon.Width = 40;
            // 
            // sohoso
            // 
            this.sohoso.DataPropertyName = "SoHoSo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sohoso.DefaultCellStyle = dataGridViewCellStyle2;
            this.sohoso.HeaderText = "Số Hồ Sơ";
            this.sohoso.Name = "sohoso";
            this.sohoso.Width = 95;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DanhBo.DefaultCellStyle = dataGridViewCellStyle3;
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Width = 110;
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.DienThoai.DefaultCellStyle = dataGridViewCellStyle4;
            this.DienThoai.HeaderText = "Điện Thoại";
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.Width = 120;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TenLoai";
            this.TenLoai.HeaderText = "Loại Tiếp Nhận";
            this.TenLoai.Name = "TenLoai";
            this.TenLoai.Width = 180;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 220;
            // 
            // NgayNhan
            // 
            this.NgayNhan.DataPropertyName = "NgayNhan";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.NgayNhan.DefaultCellStyle = dataGridViewCellStyle5;
            this.NgayNhan.HeaderText = "Ngày Nhận";
            this.NgayNhan.Name = "NgayNhan";
            this.NgayNhan.Width = 110;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CreateBy.DefaultCellStyle = dataGridViewCellStyle6;
            this.CreateBy.HeaderText = "NV Nhận";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.Width = 120;
            // 
            // ChuyenHS
            // 
            this.ChuyenHS.DataPropertyName = "ChuyenHS";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChuyenHS.DefaultCellStyle = dataGridViewCellStyle7;
            this.ChuyenHS.HeaderText = "Chuyển Xử Lý";
            this.ChuyenHS.Name = "ChuyenHS";
            this.ChuyenHS.Width = 130;
            // 
            // NGAYCHUYENXL
            // 
            this.NGAYCHUYENXL.DataPropertyName = "NgayChuyen";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "dd/MM/yyyy";
            this.NGAYCHUYENXL.DefaultCellStyle = dataGridViewCellStyle8;
            this.NGAYCHUYENXL.HeaderText = "Ngày Chuyển";
            this.NGAYCHUYENXL.Name = "NGAYCHUYENXL";
            // 
            // DOVICHUYEN
            // 
            this.DOVICHUYEN.DataPropertyName = "DonViChuyen";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DOVICHUYEN.DefaultCellStyle = dataGridViewCellStyle9;
            this.DOVICHUYEN.HeaderText = "Đơn Vị  Nhận";
            this.DOVICHUYEN.Name = "DOVICHUYEN";
            // 
            // NgayXuLy
            // 
            this.NgayXuLy.DataPropertyName = "NgayXuLy";
            this.NgayXuLy.HeaderText = "Ngày Xử Lý";
            this.NgayXuLy.Name = "NgayXuLy";
            this.NgayXuLy.Width = 120;
            // 
            // NhanVienXuLy
            // 
            this.NhanVienXuLy.DataPropertyName = "NhanVienXuLy";
            this.NhanVienXuLy.HeaderText = "NV Xử Lý";
            this.NhanVienXuLy.Name = "NhanVienXuLy";
            this.NhanVienXuLy.Width = 120;
            // 
            // noidungxuly
            // 
            this.noidungxuly.DataPropertyName = "KetQuaXuLy";
            this.noidungxuly.HeaderText = "Nội Dung Xử Lý";
            this.noidungxuly.Name = "noidungxuly";
            this.noidungxuly.Width = 200;
            // 
            // TenKH
            // 
            this.TenKH.DataPropertyName = "TenKH";
            this.TenKH.HeaderText = "Tên Khách Hàng";
            this.TenKH.Name = "TenKH";
            this.TenKH.Width = 250;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // MessChuaXL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 262);
            this.Controls.Add(this.dataGrid);
            this.Name = "MessChuaXL";
            this.Text = "MessChuaXL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MessChuaXL_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn sohoso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChuyenHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYCHUYENXL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOVICHUYEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanVienXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn noidungxuly;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
    }
}