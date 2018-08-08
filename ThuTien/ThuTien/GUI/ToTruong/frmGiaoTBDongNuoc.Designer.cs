namespace ThuTien.GUI.ToTruong
{
    partial class frmGiaoTBDongNuoc
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridViewCTDN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SoHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ky = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TieuThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThueGTGT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhiBVMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TongCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayGiaiTrach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewDN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.In = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.MaDN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DanhBo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MLT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HanhThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen_DongNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNV_DongNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cmbNhanVienLap = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbNhanVienGiao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnInDSTBNguoiLap = new System.Windows.Forms.Button();
            this.btnInDSTBNguoiGiao = new System.Windows.Forms.Button();
            this.btnInDSTBTonNguoiGiao = new System.Windows.Forms.Button();
            this.btnInTB = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkChuKy = new System.Windows.Forms.CheckBox();
            this.btnInDSTBTonThucTeNguoiGiao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.chkCoTenNguoiKy = new System.Windows.Forms.CheckBox();
            this.radA4 = new System.Windows.Forms.RadioButton();
            this.radA5 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridViewCTDN
            // 
            this.gridViewCTDN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SoHoaDon,
            this.Ky,
            this.TieuThu,
            this.GiaBan,
            this.ThueGTGT,
            this.PhiBVMT,
            this.TongCong,
            this.NgayGiaiTrach});
            this.gridViewCTDN.GridControl = this.gridControl;
            this.gridViewCTDN.Name = "gridViewCTDN";
            this.gridViewCTDN.OptionsView.ColumnAutoWidth = false;
            this.gridViewCTDN.OptionsView.ShowGroupPanel = false;
            this.gridViewCTDN.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewCTDN_CustomColumnDisplayText);
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.Caption = "Số HĐ";
            this.SoHoaDon.FieldName = "SoHoaDon";
            this.SoHoaDon.Name = "SoHoaDon";
            this.SoHoaDon.Visible = true;
            this.SoHoaDon.VisibleIndex = 0;
            this.SoHoaDon.Width = 100;
            // 
            // Ky
            // 
            this.Ky.Caption = "Kỳ";
            this.Ky.FieldName = "Ky";
            this.Ky.Name = "Ky";
            this.Ky.Visible = true;
            this.Ky.VisibleIndex = 1;
            // 
            // TieuThu
            // 
            this.TieuThu.Caption = "Tiêu Thụ";
            this.TieuThu.FieldName = "TieuThu";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.Visible = true;
            this.TieuThu.VisibleIndex = 2;
            // 
            // GiaBan
            // 
            this.GiaBan.Caption = "Giá Bán";
            this.GiaBan.FieldName = "GiaBan";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Visible = true;
            this.GiaBan.VisibleIndex = 3;
            // 
            // ThueGTGT
            // 
            this.ThueGTGT.Caption = "Thuế GTGT";
            this.ThueGTGT.FieldName = "ThueGTGT";
            this.ThueGTGT.Name = "ThueGTGT";
            this.ThueGTGT.Visible = true;
            this.ThueGTGT.VisibleIndex = 4;
            // 
            // PhiBVMT
            // 
            this.PhiBVMT.Caption = "Phí BVMT";
            this.PhiBVMT.FieldName = "PhiBVMT";
            this.PhiBVMT.Name = "PhiBVMT";
            this.PhiBVMT.Visible = true;
            this.PhiBVMT.VisibleIndex = 5;
            // 
            // TongCong
            // 
            this.TongCong.Caption = "Tổng Cộng";
            this.TongCong.FieldName = "TongCong";
            this.TongCong.Name = "TongCong";
            this.TongCong.Visible = true;
            this.TongCong.VisibleIndex = 6;
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.Caption = "Ngày Giải Trách";
            this.NgayGiaiTrach.FieldName = "NgayGiaiTrach";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            this.NgayGiaiTrach.Visible = true;
            this.NgayGiaiTrach.VisibleIndex = 7;
            this.NgayGiaiTrach.Width = 100;
            // 
            // gridControl
            // 
            gridLevelNode1.LevelTemplate = this.gridViewCTDN;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(12, 38);
            this.gridControl.MainView = this.gridViewDN;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl.Size = new System.Drawing.Size(983, 590);
            this.gridControl.TabIndex = 26;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDN,
            this.gridViewCTDN});
            // 
            // gridViewDN
            // 
            this.gridViewDN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.In,
            this.MaDN,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.MLT,
            this.CreateDate,
            this.gridColumn1,
            this.HanhThu,
            this.HoTen_DongNuoc,
            this.TinhTrang,
            this.CreateBy,
            this.MaNV_DongNuoc});
            this.gridViewDN.GridControl = this.gridControl;
            this.gridViewDN.IndicatorWidth = 41;
            this.gridViewDN.Name = "gridViewDN";
            this.gridViewDN.OptionsSelection.MultiSelect = true;
            this.gridViewDN.OptionsView.ColumnAutoWidth = false;
            this.gridViewDN.OptionsView.ShowGroupPanel = false;
            this.gridViewDN.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewDN_CustomDrawRowIndicator);
            this.gridViewDN.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewDN_CustomColumnDisplayText);
            // 
            // In
            // 
            this.In.Caption = "In";
            this.In.ColumnEdit = this.repositoryItemCheckEdit2;
            this.In.FieldName = "In";
            this.In.Name = "In";
            this.In.Visible = true;
            this.In.VisibleIndex = 0;
            this.In.Width = 30;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // MaDN
            // 
            this.MaDN.Caption = "Mã Lệnh";
            this.MaDN.FieldName = "MaDN";
            this.MaDN.Name = "MaDN";
            this.MaDN.Visible = true;
            this.MaDN.VisibleIndex = 1;
            this.MaDN.Width = 70;
            // 
            // DanhBo
            // 
            this.DanhBo.Caption = "Danh Bộ";
            this.DanhBo.FieldName = "DanhBo";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Visible = true;
            this.DanhBo.VisibleIndex = 2;
            this.DanhBo.Width = 85;
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Khách Hàng";
            this.HoTen.FieldName = "HoTen";
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 3;
            this.HoTen.Width = 130;
            // 
            // DiaChi
            // 
            this.DiaChi.Caption = "Địa Chỉ";
            this.DiaChi.FieldName = "DiaChi";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Visible = true;
            this.DiaChi.VisibleIndex = 4;
            this.DiaChi.Width = 180;
            // 
            // MLT
            // 
            this.MLT.Caption = "MLT";
            this.MLT.FieldName = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Visible = true;
            this.MLT.VisibleIndex = 5;
            this.MLT.Width = 70;
            // 
            // CreateDate
            // 
            this.CreateDate.Caption = "Ngày Lập";
            this.CreateDate.FieldName = "CreateDate";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Visible = true;
            this.CreateDate.VisibleIndex = 6;
            this.CreateDate.Width = 70;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ngày Giải Trách";
            this.gridColumn1.FieldName = "NgayGiaiTrach";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 70;
            // 
            // HanhThu
            // 
            this.HanhThu.Caption = "Người Lập";
            this.HanhThu.FieldName = "HanhThu";
            this.HanhThu.Name = "HanhThu";
            this.HanhThu.Visible = true;
            this.HanhThu.VisibleIndex = 8;
            // 
            // HoTen_DongNuoc
            // 
            this.HoTen_DongNuoc.Caption = "Người Giao";
            this.HoTen_DongNuoc.FieldName = "HoTen_DongNuoc";
            this.HoTen_DongNuoc.Name = "HoTen_DongNuoc";
            this.HoTen_DongNuoc.Visible = true;
            this.HoTen_DongNuoc.VisibleIndex = 9;
            // 
            // TinhTrang
            // 
            this.TinhTrang.Caption = "Tình Trạng";
            this.TinhTrang.FieldName = "TinhTrang";
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Visible = true;
            this.TinhTrang.VisibleIndex = 10;
            // 
            // CreateBy
            // 
            this.CreateBy.Caption = "CreateBy";
            this.CreateBy.FieldName = "CreateBy";
            this.CreateBy.Name = "CreateBy";
            // 
            // MaNV_DongNuoc
            // 
            this.MaNV_DongNuoc.Caption = "MaNV_DongNuoc";
            this.MaNV_DongNuoc.FieldName = "MaNV_DongNuoc";
            this.MaNV_DongNuoc.Name = "MaNV_DongNuoc";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // cmbNhanVienLap
            // 
            this.cmbNhanVienLap.FormattingEnabled = true;
            this.cmbNhanVienLap.Location = new System.Drawing.Point(341, 12);
            this.cmbNhanVienLap.Name = "cmbNhanVienLap";
            this.cmbNhanVienLap.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVienLap.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nhân Viên Lập:";
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(151, 9);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(32, 19);
            this.lbTo.TabIndex = 10;
            this.lbTo.Text = "Tổ:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(691, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(627, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(521, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Từ Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(797, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 17;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbNhanVienGiao
            // 
            this.cmbNhanVienGiao.FormattingEnabled = true;
            this.cmbNhanVienGiao.Location = new System.Drawing.Point(1001, 107);
            this.cmbNhanVienGiao.Name = "cmbNhanVienGiao";
            this.cmbNhanVienGiao.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVienGiao.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(998, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Nhân Viên Giao:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(1125, 105);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 29;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(1125, 163);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 31;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(1125, 134);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 30;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnInDSTBNguoiLap
            // 
            this.btnInDSTBNguoiLap.Location = new System.Drawing.Point(878, 10);
            this.btnInDSTBNguoiLap.Name = "btnInDSTBNguoiLap";
            this.btnInDSTBNguoiLap.Size = new System.Drawing.Size(117, 23);
            this.btnInDSTBNguoiLap.TabIndex = 32;
            this.btnInDSTBNguoiLap.Text = "In DS TB (Người Lập)";
            this.btnInDSTBNguoiLap.UseVisualStyleBackColor = true;
            this.btnInDSTBNguoiLap.Click += new System.EventHandler(this.btnInDSTBNguoiLap_Click);
            // 
            // btnInDSTBNguoiGiao
            // 
            this.btnInDSTBNguoiGiao.Location = new System.Drawing.Point(1001, 207);
            this.btnInDSTBNguoiGiao.Name = "btnInDSTBNguoiGiao";
            this.btnInDSTBNguoiGiao.Size = new System.Drawing.Size(121, 23);
            this.btnInDSTBNguoiGiao.TabIndex = 33;
            this.btnInDSTBNguoiGiao.Text = "In DS TB (Người Giao)";
            this.btnInDSTBNguoiGiao.UseVisualStyleBackColor = true;
            this.btnInDSTBNguoiGiao.Click += new System.EventHandler(this.btnInDSTBNguoiGiao_Click);
            // 
            // btnInDSTBTonNguoiGiao
            // 
            this.btnInDSTBTonNguoiGiao.Location = new System.Drawing.Point(1001, 236);
            this.btnInDSTBTonNguoiGiao.Name = "btnInDSTBTonNguoiGiao";
            this.btnInDSTBTonNguoiGiao.Size = new System.Drawing.Size(145, 23);
            this.btnInDSTBTonNguoiGiao.TabIndex = 34;
            this.btnInDSTBTonNguoiGiao.Text = "In DS TB Tồn (Người Giao)";
            this.btnInDSTBTonNguoiGiao.UseVisualStyleBackColor = true;
            this.btnInDSTBTonNguoiGiao.Click += new System.EventHandler(this.btnInDSTBTonNguoiGiao_Click);
            // 
            // btnInTB
            // 
            this.btnInTB.Location = new System.Drawing.Point(1001, 10);
            this.btnInTB.Name = "btnInTB";
            this.btnInTB.Size = new System.Drawing.Size(75, 23);
            this.btnInTB.TabIndex = 35;
            this.btnInTB.Text = "In Giấy TB";
            this.btnInTB.UseVisualStyleBackColor = true;
            this.btnInTB.Click += new System.EventHandler(this.btnInTB_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(53, 17);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(86, 17);
            this.chkAll.TabIndex = 36;
            this.chkAll.Text = "Chọn Tất Cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkChuKy
            // 
            this.chkChuKy.AutoSize = true;
            this.chkChuKy.Checked = true;
            this.chkChuKy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChuKy.Location = new System.Drawing.Point(1001, 38);
            this.chkChuKy.Name = "chkChuKy";
            this.chkChuKy.Size = new System.Drawing.Size(76, 17);
            this.chkChuKy.TabIndex = 96;
            this.chkChuKy.Text = "Có Chữ Ký";
            this.chkChuKy.UseVisualStyleBackColor = true;
            // 
            // btnInDSTBTonThucTeNguoiGiao
            // 
            this.btnInDSTBTonThucTeNguoiGiao.Location = new System.Drawing.Point(1001, 265);
            this.btnInDSTBTonThucTeNguoiGiao.Name = "btnInDSTBTonThucTeNguoiGiao";
            this.btnInDSTBTonThucTeNguoiGiao.Size = new System.Drawing.Size(190, 23);
            this.btnInDSTBTonThucTeNguoiGiao.TabIndex = 97;
            this.btnInDSTBTonThucTeNguoiGiao.Text = "In DS TB Tồn Thực Tế (Người Giao)";
            this.btnInDSTBTonThucTeNguoiGiao.UseVisualStyleBackColor = true;
            this.btnInDSTBTonThucTeNguoiGiao.Click += new System.EventHandler(this.btnInDSTBTonThucTeNguoiGiao_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(1082, 10);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 98;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // chkCoTenNguoiKy
            // 
            this.chkCoTenNguoiKy.AutoSize = true;
            this.chkCoTenNguoiKy.Location = new System.Drawing.Point(1001, 61);
            this.chkCoTenNguoiKy.Name = "chkCoTenNguoiKy";
            this.chkCoTenNguoiKy.Size = new System.Drawing.Size(107, 17);
            this.chkCoTenNguoiKy.TabIndex = 99;
            this.chkCoTenNguoiKy.Text = "Có Tên Người Ký";
            this.chkCoTenNguoiKy.UseVisualStyleBackColor = true;
            // 
            // radA4
            // 
            this.radA4.AutoSize = true;
            this.radA4.Checked = true;
            this.radA4.Location = new System.Drawing.Point(1119, 37);
            this.radA4.Name = "radA4";
            this.radA4.Size = new System.Drawing.Size(38, 17);
            this.radA4.TabIndex = 100;
            this.radA4.TabStop = true;
            this.radA4.Text = "A4";
            this.radA4.UseVisualStyleBackColor = true;
            // 
            // radA5
            // 
            this.radA5.AutoSize = true;
            this.radA5.Location = new System.Drawing.Point(1119, 60);
            this.radA5.Name = "radA5";
            this.radA5.Size = new System.Drawing.Size(38, 17);
            this.radA5.TabIndex = 101;
            this.radA5.Text = "A5";
            this.radA5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCapNhat);
            this.groupBox1.Controls.Add(this.cmbNhanVien);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbTo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(1001, 326);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 130);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cập Nhật Người Lập";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tổ:";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(9, 32);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(121, 21);
            this.cmbTo.TabIndex = 1;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(9, 72);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(121, 21);
            this.cmbNhanVien.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nhân Viên:";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(9, 99);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 31;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // frmGiaoTBDongNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 666);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radA5);
            this.Controls.Add(this.radA4);
            this.Controls.Add(this.chkCoTenNguoiKy);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnInDSTBTonThucTeNguoiGiao);
            this.Controls.Add(this.chkChuKy);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnInTB);
            this.Controls.Add(this.btnInDSTBTonNguoiGiao);
            this.Controls.Add(this.btnInDSTBNguoiGiao);
            this.Controls.Add(this.btnInDSTBNguoiLap);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cmbNhanVienGiao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNhanVienLap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTo);
            this.Name = "frmGiaoTBDongNuoc";
            this.Text = "Giao Thông Báo Đóng Nước";
            this.Load += new System.EventHandler(this.frmGiaoTBDongNuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNhanVienLap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCTDN;
        private DevExpress.XtraGrid.Columns.GridColumn SoHoaDon;
        private DevExpress.XtraGrid.Columns.GridColumn Ky;
        private DevExpress.XtraGrid.Columns.GridColumn TieuThu;
        private DevExpress.XtraGrid.Columns.GridColumn GiaBan;
        private DevExpress.XtraGrid.Columns.GridColumn ThueGTGT;
        private DevExpress.XtraGrid.Columns.GridColumn PhiBVMT;
        private DevExpress.XtraGrid.Columns.GridColumn TongCong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDN;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn MaDN;
        private DevExpress.XtraGrid.Columns.GridColumn DanhBo;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn MLT;
        private System.Windows.Forms.ComboBox cmbNhanVienGiao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private DevExpress.XtraGrid.Columns.GridColumn HanhThu;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen_DongNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn CreateDate;
        private System.Windows.Forms.Button btnInDSTBNguoiLap;
        private System.Windows.Forms.Button btnInDSTBNguoiGiao;
        private System.Windows.Forms.Button btnInDSTBTonNguoiGiao;
        private DevExpress.XtraGrid.Columns.GridColumn NgayGiaiTrach;
        private System.Windows.Forms.Button btnInTB;
        private DevExpress.XtraGrid.Columns.GridColumn In;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn TinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.CheckBox chkChuKy;
        private System.Windows.Forms.Button btnInDSTBTonThucTeNguoiGiao;
        private System.Windows.Forms.Button btnXuatExcel;
        private DevExpress.XtraGrid.Columns.GridColumn CreateBy;
        private DevExpress.XtraGrid.Columns.GridColumn MaNV_DongNuoc;
        private System.Windows.Forms.CheckBox chkCoTenNguoiKy;
        private System.Windows.Forms.RadioButton radA4;
        private System.Windows.Forms.RadioButton radA5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label5;
    }
}