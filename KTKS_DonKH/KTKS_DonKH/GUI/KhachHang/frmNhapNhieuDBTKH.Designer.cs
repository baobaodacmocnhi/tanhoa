namespace KTKS_DonKH.GUI.KhachHang
{
    partial class frmNhapNhieuDBTKH
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
            this.txtTongSoDanhBo = new System.Windows.Forms.TextBox();
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
            this.label23 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNgayNhan = new System.Windows.Forms.TextBox();
            this.txtSoCongVan = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBoChuyenKT)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabKiemTra.SuspendLayout();
            this.tabVanPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBoChuyenVanPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTongSoDanhBo
            // 
            this.txtTongSoDanhBo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongSoDanhBo.Location = new System.Drawing.Point(327, 27);
            this.txtTongSoDanhBo.Name = "txtTongSoDanhBo";
            this.txtTongSoDanhBo.Size = new System.Drawing.Size(90, 22);
            this.txtTongSoDanhBo.TabIndex = 31;
            this.txtTongSoDanhBo.Text = "1";
            this.txtTongSoDanhBo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(877, 24);
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
            this.MLT});
            this.dgvDanhBoChuyenKT.Location = new System.Drawing.Point(6, 5);
            this.dgvDanhBoChuyenKT.Name = "dgvDanhBoChuyenKT";
            this.dgvDanhBoChuyenKT.Size = new System.Drawing.Size(1287, 418);
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
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(327, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 19);
            this.label23.TabIndex = 30;
            this.label23.Text = "Tổng Số DB";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDung.Location = new System.Drawing.Point(581, 27);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(290, 22);
            this.txtNoiDung.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(581, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 19);
            this.label5.TabIndex = 36;
            this.label5.Text = "                   Nội Dung Đơn Thư                    ";
            // 
            // txtNgayNhan
            // 
            this.txtNgayNhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayNhan.Location = new System.Drawing.Point(501, 27);
            this.txtNgayNhan.Name = "txtNgayNhan";
            this.txtNgayNhan.ReadOnly = true;
            this.txtNgayNhan.Size = new System.Drawing.Size(81, 22);
            this.txtNgayNhan.TabIndex = 35;
            this.txtNgayNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSoCongVan
            // 
            this.txtSoCongVan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoCongVan.Location = new System.Drawing.Point(210, 27);
            this.txtSoCongVan.Name = "txtSoCongVan";
            this.txtSoCongVan.Size = new System.Drawing.Size(119, 22);
            this.txtSoCongVan.TabIndex = 29;
            this.txtSoCongVan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(210, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 19);
            this.label16.TabIndex = 28;
            this.label16.Text = "   Số Công Văn   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "                 Loại Đơn                ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(501, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "Ngày Nhận";
            // 
            // txtMaDon
            // 
            this.txtMaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaDon.Location = new System.Drawing.Point(416, 27);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(85, 22);
            this.txtMaDon.TabIndex = 33;
            this.txtMaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaDon.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(416, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 32;
            this.label3.Text = "   Số Đơn    ";
            this.label3.Visible = false;
            // 
            // cmbLD
            // 
            this.cmbLD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbLD.FormattingEnabled = true;
            this.cmbLD.Location = new System.Drawing.Point(11, 27);
            this.cmbLD.Name = "cmbLD";
            this.cmbLD.Size = new System.Drawing.Size(198, 24);
            this.cmbLD.TabIndex = 27;
            this.cmbLD.SelectedIndexChanged += new System.EventHandler(this.cmbLD_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabKiemTra);
            this.tabControl.Controls.Add(this.tabVanPhong);
            this.tabControl.Location = new System.Drawing.Point(1, 55);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1307, 459);
            this.tabControl.TabIndex = 40;
            // 
            // tabKiemTra
            // 
            this.tabKiemTra.Controls.Add(this.dgvDanhBoChuyenKT);
            this.tabKiemTra.Location = new System.Drawing.Point(4, 25);
            this.tabKiemTra.Name = "tabKiemTra";
            this.tabKiemTra.Padding = new System.Windows.Forms.Padding(3);
            this.tabKiemTra.Size = new System.Drawing.Size(1299, 430);
            this.tabKiemTra.TabIndex = 0;
            this.tabKiemTra.Text = "Kiểm Tra";
            this.tabKiemTra.UseVisualStyleBackColor = true;
            // 
            // tabVanPhong
            // 
            this.tabVanPhong.Controls.Add(this.dgvDanhBoChuyenVanPhong);
            this.tabVanPhong.Location = new System.Drawing.Point(4, 25);
            this.tabVanPhong.Name = "tabVanPhong";
            this.tabVanPhong.Padding = new System.Windows.Forms.Padding(3);
            this.tabVanPhong.Size = new System.Drawing.Size(1299, 430);
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
            this.MLTVP});
            this.dgvDanhBoChuyenVanPhong.Location = new System.Drawing.Point(6, 5);
            this.dgvDanhBoChuyenVanPhong.Name = "dgvDanhBoChuyenVanPhong";
            this.dgvDanhBoChuyenVanPhong.Size = new System.Drawing.Size(1287, 418);
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
            // frmNhapNhieuDBTKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1315, 515);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.txtTongSoDanhBo);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNgayNhan);
            this.Controls.Add(this.txtSoCongVan);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhapNhieuDBTKH";
            this.Text = "Nhập Nhiều Danh Bộ TKH";
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

        private System.Windows.Forms.TextBox txtTongSoDanhBo;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvDanhBoChuyenKT;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNgayNhan;
        private System.Windows.Forms.TextBox txtSoCongVan;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLD;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabKiemTra;
        private System.Windows.Forms.TabPage tabVanPhong;
        private System.Windows.Forms.DataGridView dgvDanhBoChuyenVanPhong;
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
    }
}