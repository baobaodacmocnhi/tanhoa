namespace KTKS_DonKH.GUI.ToBamChi
{
    partial class frmNhapNhieuDBTBC
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
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvDanhBoChuyenKT = new System.Windows.Forms.DataGridView();
            this.NgayChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiDi = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtSoCongVan = new System.Windows.Forms.TextBox();
            this.cmbLD = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabKiemTra = new System.Windows.Forms.TabPage();
            this.tabVanPhong = new System.Windows.Forms.TabPage();
            this.dgvDanhBoChuyenVanPhong = new System.Windows.Forms.DataGridView();
            this.NgayChuyenVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiDiVP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GhiChuVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBoVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChiVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HopDongVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSThueVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieuVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMucVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DotVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLTVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuanVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhuongVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBoChuyenKT)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabKiemTra.SuspendLayout();
            this.tabVanPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBoChuyenVanPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(480, 61);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 25);
            this.btnLuu.TabIndex = 39;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvDanhBoChuyenKT
            // 
            this.dgvDanhBoChuyenKT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhBoChuyenKT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayChuyen,
            this.NguoiDi,
            this.GhiChu,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.HopDong,
            this.MSThue,
            this.GiaBieu,
            this.DinhMuc,
            this.Dot,
            this.Ky,
            this.Nam,
            this.MLT,
            this.Quan,
            this.Phuong});
            this.dgvDanhBoChuyenKT.Location = new System.Drawing.Point(6, 5);
            this.dgvDanhBoChuyenKT.Name = "dgvDanhBoChuyenKT";
            this.dgvDanhBoChuyenKT.Size = new System.Drawing.Size(1275, 418);
            this.dgvDanhBoChuyenKT.TabIndex = 38;
            this.dgvDanhBoChuyenKT.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDanhBo_CellBeginEdit);
            this.dgvDanhBoChuyenKT.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBo_CellEndEdit);
            this.dgvDanhBoChuyenKT.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBoChuyenKT_RowLeave);
            this.dgvDanhBoChuyenKT.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhBo_RowPostPaint);
            // 
            // NgayChuyen
            // 
            this.NgayChuyen.HeaderText = "Ngày Chuyển";
            this.NgayChuyen.Name = "NgayChuyen";
            // 
            // NguoiDi
            // 
            this.NguoiDi.HeaderText = "Người Đi";
            this.NguoiDi.Name = "NguoiDi";
            this.NguoiDi.Width = 150;
            // 
            // GhiChu
            // 
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 150;
            // 
            // DanhBo
            // 
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 200;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 250;
            // 
            // HopDong
            // 
            this.HopDong.HeaderText = "Hợp Đồng";
            this.HopDong.Name = "HopDong";
            this.HopDong.Width = 80;
            // 
            // MSThue
            // 
            this.MSThue.HeaderText = "MS Thuế";
            this.MSThue.Name = "MSThue";
            this.MSThue.Width = 80;
            // 
            // GiaBieu
            // 
            this.GiaBieu.HeaderText = "Giá Biểu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.Width = 50;
            // 
            // DinhMuc
            // 
            this.DinhMuc.HeaderText = "Định Mức";
            this.DinhMuc.Name = "DinhMuc";
            this.DinhMuc.Width = 50;
            // 
            // Dot
            // 
            this.Dot.HeaderText = "Dot";
            this.Dot.Name = "Dot";
            this.Dot.Visible = false;
            // 
            // Ky
            // 
            this.Ky.HeaderText = "Ky";
            this.Ky.Name = "Ky";
            this.Ky.Visible = false;
            // 
            // Nam
            // 
            this.Nam.HeaderText = "Nam";
            this.Nam.Name = "Nam";
            this.Nam.Visible = false;
            // 
            // MLT
            // 
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Visible = false;
            // 
            // Quan
            // 
            this.Quan.HeaderText = "Quan";
            this.Quan.Name = "Quan";
            this.Quan.Visible = false;
            // 
            // Phuong
            // 
            this.Phuong.HeaderText = "Phuong";
            this.Phuong.Name = "Phuong";
            this.Phuong.Visible = false;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(374, 63);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(100, 26);
            this.txtNoiDung.TabIndex = 37;
            // 
            // txtSoCongVan
            // 
            this.txtSoCongVan.Location = new System.Drawing.Point(268, 63);
            this.txtSoCongVan.Name = "txtSoCongVan";
            this.txtSoCongVan.Size = new System.Drawing.Size(100, 26);
            this.txtSoCongVan.TabIndex = 29;
            this.txtSoCongVan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbLD
            // 
            this.cmbLD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLD.FormattingEnabled = true;
            this.cmbLD.Location = new System.Drawing.Point(12, 61);
            this.cmbLD.Name = "cmbLD";
            this.cmbLD.Size = new System.Drawing.Size(250, 28);
            this.cmbLD.TabIndex = 27;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabKiemTra);
            this.tabControl.Controls.Add(this.tabVanPhong);
            this.tabControl.Location = new System.Drawing.Point(0, 91);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1295, 460);
            this.tabControl.TabIndex = 40;
            // 
            // tabKiemTra
            // 
            this.tabKiemTra.Controls.Add(this.dgvDanhBoChuyenKT);
            this.tabKiemTra.Location = new System.Drawing.Point(4, 29);
            this.tabKiemTra.Name = "tabKiemTra";
            this.tabKiemTra.Padding = new System.Windows.Forms.Padding(3);
            this.tabKiemTra.Size = new System.Drawing.Size(1287, 427);
            this.tabKiemTra.TabIndex = 0;
            this.tabKiemTra.Text = "Kiểm Tra";
            this.tabKiemTra.UseVisualStyleBackColor = true;
            // 
            // tabVanPhong
            // 
            this.tabVanPhong.Controls.Add(this.dgvDanhBoChuyenVanPhong);
            this.tabVanPhong.Location = new System.Drawing.Point(4, 29);
            this.tabVanPhong.Name = "tabVanPhong";
            this.tabVanPhong.Padding = new System.Windows.Forms.Padding(3);
            this.tabVanPhong.Size = new System.Drawing.Size(1287, 427);
            this.tabVanPhong.TabIndex = 1;
            this.tabVanPhong.Text = "Văn Phòng";
            this.tabVanPhong.UseVisualStyleBackColor = true;
            // 
            // dgvDanhBoChuyenVanPhong
            // 
            this.dgvDanhBoChuyenVanPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhBoChuyenVanPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayChuyenVP,
            this.NguoiDiVP,
            this.GhiChuVP,
            this.DanhBoVP,
            this.HoTenVP,
            this.DiaChiVP,
            this.HopDongVP,
            this.MSThueVP,
            this.GiaBieuVP,
            this.DinhMucVP,
            this.DotVP,
            this.KyVP,
            this.NamVP,
            this.MLTVP,
            this.QuanVP,
            this.PhuongVP});
            this.dgvDanhBoChuyenVanPhong.Location = new System.Drawing.Point(6, 5);
            this.dgvDanhBoChuyenVanPhong.Name = "dgvDanhBoChuyenVanPhong";
            this.dgvDanhBoChuyenVanPhong.Size = new System.Drawing.Size(1275, 418);
            this.dgvDanhBoChuyenVanPhong.TabIndex = 39;
            this.dgvDanhBoChuyenVanPhong.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDanhBoChuyenVanPhong_CellBeginEdit);
            this.dgvDanhBoChuyenVanPhong.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBoChuyenVanPhong_CellEndEdit);
            this.dgvDanhBoChuyenVanPhong.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBoChuyenVanPhong_RowLeave);
            this.dgvDanhBoChuyenVanPhong.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhBoChuyenVanPhong_RowPostPaint);
            // 
            // NgayChuyenVP
            // 
            this.NgayChuyenVP.HeaderText = "Ngày Chuyển";
            this.NgayChuyenVP.Name = "NgayChuyenVP";
            // 
            // NguoiDiVP
            // 
            this.NguoiDiVP.HeaderText = "Người Đi";
            this.NguoiDiVP.Name = "NguoiDiVP";
            this.NguoiDiVP.Width = 150;
            // 
            // GhiChuVP
            // 
            this.GhiChuVP.HeaderText = "Ghi Chú";
            this.GhiChuVP.Name = "GhiChuVP";
            this.GhiChuVP.Width = 150;
            // 
            // DanhBoVP
            // 
            this.DanhBoVP.HeaderText = "Danh Bộ";
            this.DanhBoVP.Name = "DanhBoVP";
            // 
            // HoTenVP
            // 
            this.HoTenVP.HeaderText = "Khách Hàng";
            this.HoTenVP.Name = "HoTenVP";
            this.HoTenVP.Width = 200;
            // 
            // DiaChiVP
            // 
            this.DiaChiVP.HeaderText = "Địa Chỉ";
            this.DiaChiVP.Name = "DiaChiVP";
            this.DiaChiVP.Width = 250;
            // 
            // HopDongVP
            // 
            this.HopDongVP.HeaderText = "Hợp Đồng";
            this.HopDongVP.Name = "HopDongVP";
            this.HopDongVP.Width = 80;
            // 
            // MSThueVP
            // 
            this.MSThueVP.HeaderText = "MS Thuế";
            this.MSThueVP.Name = "MSThueVP";
            this.MSThueVP.Width = 80;
            // 
            // GiaBieuVP
            // 
            this.GiaBieuVP.HeaderText = "Giá Biểu";
            this.GiaBieuVP.Name = "GiaBieuVP";
            this.GiaBieuVP.Width = 50;
            // 
            // DinhMucVP
            // 
            this.DinhMucVP.HeaderText = "Định Mức";
            this.DinhMucVP.Name = "DinhMucVP";
            this.DinhMucVP.Width = 50;
            // 
            // DotVP
            // 
            this.DotVP.HeaderText = "Dot";
            this.DotVP.Name = "DotVP";
            this.DotVP.Visible = false;
            // 
            // KyVP
            // 
            this.KyVP.HeaderText = "Ky";
            this.KyVP.Name = "KyVP";
            this.KyVP.Visible = false;
            // 
            // NamVP
            // 
            this.NamVP.HeaderText = "Nam";
            this.NamVP.Name = "NamVP";
            this.NamVP.Visible = false;
            // 
            // MLTVP
            // 
            this.MLTVP.HeaderText = "MLT";
            this.MLTVP.Name = "MLTVP";
            this.MLTVP.Visible = false;
            // 
            // QuanVP
            // 
            this.QuanVP.HeaderText = "Quan";
            this.QuanVP.Name = "QuanVP";
            this.QuanVP.Visible = false;
            // 
            // PhuongVP
            // 
            this.PhuongVP.HeaderText = "Phuong";
            this.PhuongVP.Name = "PhuongVP";
            this.PhuongVP.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 95;
            this.label5.Text = "Nội Dung:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(265, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 20);
            this.label14.TabIndex = 94;
            this.label14.Text = "Số Công Văn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 93;
            this.label1.Text = "Loại Đơn:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(114, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 20);
            this.label15.TabIndex = 97;
            this.label15.Text = "Mã Đơn:";
            this.label15.Visible = false;
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(177, 12);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(85, 26);
            this.txtMaDon.TabIndex = 96;
            this.txtMaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaDon.Visible = false;
            this.txtMaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDon_KeyPress);
            // 
            // frmNhapNhieuDBTBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1303, 559);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.txtSoCongVan);
            this.Controls.Add(this.cmbLD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhapNhieuDBTBC";
            this.Text = "Nhập Nhiều Danh Bộ TBC";
            this.Load += new System.EventHandler(this.frmNhapNhieuDBTKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBoChuyenKT)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabKiemTra.ResumeLayout(false);
            this.tabVanPhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBoChuyenVanPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvDanhBoChuyenKT;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtSoCongVan;
        private System.Windows.Forms.ComboBox cmbLD;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabKiemTra;
        private System.Windows.Forms.TabPage tabVanPhong;
        private System.Windows.Forms.DataGridView dgvDanhBoChuyenVanPhong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyen;
        private System.Windows.Forms.DataGridViewComboBoxColumn NguoiDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HopDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSThue;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyenVP;
        private System.Windows.Forms.DataGridViewComboBoxColumn NguoiDiVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChuVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBoVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn HopDongVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSThueVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieuVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMucVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DotVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLTVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuanVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhuongVP;
    }
}