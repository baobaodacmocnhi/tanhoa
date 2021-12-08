namespace ThuTien.GUI.DongNuoc
{
    partial class frmTBDongNuoc
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridViewCTDN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SoHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ky = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TieuThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThueGTGT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhiBVMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TongCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewDN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.In = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.MaDN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DanhBo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MLT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TongCongLenh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNV_DongNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThemHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInTB = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnDSTB = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lstHD = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.groupBox_ThemDN = new System.Windows.Forms.GroupBox();
            this.btnThemDN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaDN = new System.Windows.Forms.TextBox();
            this.btnInGiayXN = new System.Windows.Forms.Button();
            this.chkChuKy = new System.Windows.Forms.CheckBox();
            this.chkCoTenNguoiKy = new System.Windows.Forms.CheckBox();
            this.radA5 = new System.Windows.Forms.RadioButton();
            this.radA4 = new System.Windows.Forms.RadioButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnInTBTrang = new System.Windows.Forms.Button();
            this.chkNangSuat = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox_ThemDN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
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
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewCTDN.GridControl = this.gridControl;
            this.gridViewCTDN.Name = "gridViewCTDN";
            this.gridViewCTDN.OptionsView.ColumnAutoWidth = false;
            this.gridViewCTDN.OptionsView.ShowGroupPanel = false;
            this.gridViewCTDN.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewCTDN_PopupMenuShowing);
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "MaDN";
            this.gridColumn2.FieldName = "MaDN";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "MaHD";
            this.gridColumn3.FieldName = "MaHD";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridControl
            // 
            gridLevelNode1.LevelTemplate = this.gridViewCTDN;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(247, 40);
            this.gridControl.MainView = this.gridViewDN;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl.Size = new System.Drawing.Size(804, 590);
            this.gridControl.TabIndex = 25;
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
            this.TongCongLenh,
            this.CreateBy,
            this.MaNV_DongNuoc,
            this.ThemHoaDon});
            this.gridViewDN.GridControl = this.gridControl;
            this.gridViewDN.IndicatorWidth = 41;
            this.gridViewDN.Name = "gridViewDN";
            this.gridViewDN.OptionsSelection.MultiSelect = true;
            this.gridViewDN.OptionsView.ColumnAutoWidth = false;
            this.gridViewDN.OptionsView.ShowGroupPanel = false;
            this.gridViewDN.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewDN_CustomDrawRowIndicator);
            this.gridViewDN.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewDN_RowStyle);
            this.gridViewDN.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewDN_CustomColumnDisplayText);
            // 
            // In
            // 
            this.In.Caption = "In";
            this.In.ColumnEdit = this.repositoryItemCheckEdit1;
            this.In.FieldName = "In";
            this.In.Name = "In";
            this.In.Visible = true;
            this.In.VisibleIndex = 0;
            this.In.Width = 50;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
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
            this.MLT.Width = 80;
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
            // TongCongLenh
            // 
            this.TongCongLenh.Caption = "Tổng Cộng";
            this.TongCongLenh.FieldName = "TongCongLenh";
            this.TongCongLenh.Name = "TongCongLenh";
            this.TongCongLenh.Visible = true;
            this.TongCongLenh.VisibleIndex = 7;
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
            // ThemHoaDon
            // 
            this.ThemHoaDon.Caption = "ThemHoaDon";
            this.ThemHoaDon.FieldName = "ThemHoaDon";
            this.ThemHoaDon.Name = "ThemHoaDon";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(692, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 24;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(586, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(522, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(416, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Từ Ngày:";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(156, 134);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 19;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(156, 105);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 18;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(156, 76);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 17;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(15, 25);
            this.txtSoHoaDon.Multiline = true;
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 45);
            this.txtSoHoaDon.TabIndex = 14;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Số Hóa Đơn:";
            // 
            // btnInTB
            // 
            this.btnInTB.Location = new System.Drawing.Point(773, 10);
            this.btnInTB.Name = "btnInTB";
            this.btnInTB.Size = new System.Drawing.Size(75, 23);
            this.btnInTB.TabIndex = 26;
            this.btnInTB.Text = "In TB";
            this.btnInTB.UseVisualStyleBackColor = true;
            this.btnInTB.Click += new System.EventHandler(this.btnInTB_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(247, 17);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(86, 17);
            this.chkAll.TabIndex = 27;
            this.chkAll.Text = "Chọn Tất Cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnDSTB
            // 
            this.btnDSTB.Location = new System.Drawing.Point(945, 10);
            this.btnDSTB.Name = "btnDSTB";
            this.btnDSTB.Size = new System.Drawing.Size(75, 23);
            this.btnDSTB.TabIndex = 28;
            this.btnDSTB.Text = "In DS TB";
            this.btnDSTB.UseVisualStyleBackColor = true;
            this.btnDSTB.Click += new System.EventHandler(this.btnDSTB_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Số Lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(90, 255);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(50, 20);
            this.txtSoLuong.TabIndex = 41;
            // 
            // lstHD
            // 
            this.lstHD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstHD.Location = new System.Drawing.Point(15, 76);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(125, 173);
            this.lstHD.TabIndex = 48;
            this.lstHD.UseCompatibleStateImageBehavior = false;
            this.lstHD.View = System.Windows.Forms.View.Details;
            this.lstHD.SelectedIndexChanged += new System.EventHandler(this.lstHD_SelectedIndexChanged);
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Danh Sách Hóa Đơn";
            this.columnHeader1.Width = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "(Enter)";
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(30, 281);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(110, 23);
            this.btnCopyToClipboard.TabIndex = 71;
            this.btnCopyToClipboard.Text = "Copy to Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // groupBox_ThemDN
            // 
            this.groupBox_ThemDN.Controls.Add(this.btnThemDN);
            this.groupBox_ThemDN.Controls.Add(this.label2);
            this.groupBox_ThemDN.Controls.Add(this.txtMaDN);
            this.groupBox_ThemDN.Location = new System.Drawing.Point(12, 334);
            this.groupBox_ThemDN.Name = "groupBox_ThemDN";
            this.groupBox_ThemDN.Size = new System.Drawing.Size(204, 85);
            this.groupBox_ThemDN.TabIndex = 72;
            this.groupBox_ThemDN.TabStop = false;
            this.groupBox_ThemDN.Text = "Thêm Hóa Đơn vào Lệnh đã có";
            this.groupBox_ThemDN.Visible = false;
            // 
            // btnThemDN
            // 
            this.btnThemDN.Location = new System.Drawing.Point(112, 50);
            this.btnThemDN.Name = "btnThemDN";
            this.btnThemDN.Size = new System.Drawing.Size(75, 23);
            this.btnThemDN.TabIndex = 45;
            this.btnThemDN.Text = "Thêm";
            this.btnThemDN.UseVisualStyleBackColor = true;
            this.btnThemDN.Click += new System.EventHandler(this.btnThemDN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Mã TB Đóng Nước:";
            // 
            // txtMaDN
            // 
            this.txtMaDN.Location = new System.Drawing.Point(112, 24);
            this.txtMaDN.Name = "txtMaDN";
            this.txtMaDN.Size = new System.Drawing.Size(80, 20);
            this.txtMaDN.TabIndex = 43;
            // 
            // btnInGiayXN
            // 
            this.btnInGiayXN.Location = new System.Drawing.Point(1026, 10);
            this.btnInGiayXN.Name = "btnInGiayXN";
            this.btnInGiayXN.Size = new System.Drawing.Size(95, 23);
            this.btnInGiayXN.TabIndex = 73;
            this.btnInGiayXN.Text = "In Giấy XN NKĐ";
            this.btnInGiayXN.UseVisualStyleBackColor = true;
            this.btnInGiayXN.Click += new System.EventHandler(this.btnInGiayXN_Click);
            // 
            // chkChuKy
            // 
            this.chkChuKy.AutoSize = true;
            this.chkChuKy.Location = new System.Drawing.Point(1127, 10);
            this.chkChuKy.Name = "chkChuKy";
            this.chkChuKy.Size = new System.Drawing.Size(76, 17);
            this.chkChuKy.TabIndex = 96;
            this.chkChuKy.Text = "Có Chữ Ký";
            this.chkChuKy.UseVisualStyleBackColor = true;
            this.chkChuKy.Visible = false;
            // 
            // chkCoTenNguoiKy
            // 
            this.chkCoTenNguoiKy.AutoSize = true;
            this.chkCoTenNguoiKy.Location = new System.Drawing.Point(1127, 33);
            this.chkCoTenNguoiKy.Name = "chkCoTenNguoiKy";
            this.chkCoTenNguoiKy.Size = new System.Drawing.Size(107, 17);
            this.chkCoTenNguoiKy.TabIndex = 97;
            this.chkCoTenNguoiKy.Text = "Có Tên Người Ký";
            this.chkCoTenNguoiKy.UseVisualStyleBackColor = true;
            // 
            // radA5
            // 
            this.radA5.AutoSize = true;
            this.radA5.Location = new System.Drawing.Point(1240, 32);
            this.radA5.Name = "radA5";
            this.radA5.Size = new System.Drawing.Size(38, 17);
            this.radA5.TabIndex = 103;
            this.radA5.Text = "A5";
            this.radA5.UseVisualStyleBackColor = true;
            // 
            // radA4
            // 
            this.radA4.AutoSize = true;
            this.radA4.Checked = true;
            this.radA4.Location = new System.Drawing.Point(1240, 9);
            this.radA4.Name = "radA4";
            this.radA4.Size = new System.Drawing.Size(38, 17);
            this.radA4.TabIndex = 102;
            this.radA4.TabStop = true;
            this.radA4.Text = "A4";
            this.radA4.UseVisualStyleBackColor = true;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Xóa";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1286, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 648);
            this.barDockControlBottom.Size = new System.Drawing.Size(1286, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 648);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1286, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 648);
            // 
            // btnInTBTrang
            // 
            this.btnInTBTrang.Location = new System.Drawing.Point(854, 10);
            this.btnInTBTrang.Name = "btnInTBTrang";
            this.btnInTBTrang.Size = new System.Drawing.Size(85, 23);
            this.btnInTBTrang.TabIndex = 108;
            this.btnInTBTrang.Text = "In TB (Trắng)";
            this.btnInTBTrang.UseVisualStyleBackColor = true;
            this.btnInTBTrang.Click += new System.EventHandler(this.btnInTBTrang_Click);
            // 
            // chkNangSuat
            // 
            this.chkNangSuat.AutoSize = true;
            this.chkNangSuat.Location = new System.Drawing.Point(155, 163);
            this.chkNangSuat.Name = "chkNangSuat";
            this.chkNangSuat.Size = new System.Drawing.Size(77, 17);
            this.chkNangSuat.TabIndex = 113;
            this.chkNangSuat.Text = "Năng Suất";
            this.chkNangSuat.UseVisualStyleBackColor = true;
            this.chkNangSuat.Visible = false;
            // 
            // frmTBDongNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1286, 648);
            this.Controls.Add(this.chkNangSuat);
            this.Controls.Add(this.btnInTBTrang);
            this.Controls.Add(this.radA5);
            this.Controls.Add(this.radA4);
            this.Controls.Add(this.chkCoTenNguoiKy);
            this.Controls.Add(this.chkChuKy);
            this.Controls.Add(this.btnInGiayXN);
            this.Controls.Add(this.groupBox_ThemDN);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnDSTB);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnInTB);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTBDongNuoc";
            this.Text = "Lập Thông Báo Đóng Nước";
            this.Load += new System.EventHandler(this.frmLenhDongNuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox_ThemDN.ResumeLayout(false);
            this.groupBox_ThemDN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCTDN;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDN;
        private DevExpress.XtraGrid.Columns.GridColumn SoHoaDon;
        private DevExpress.XtraGrid.Columns.GridColumn Ky;
        private DevExpress.XtraGrid.Columns.GridColumn TieuThu;
        private DevExpress.XtraGrid.Columns.GridColumn GiaBan;
        private DevExpress.XtraGrid.Columns.GridColumn ThueGTGT;
        private DevExpress.XtraGrid.Columns.GridColumn PhiBVMT;
        private DevExpress.XtraGrid.Columns.GridColumn TongCong;
        private DevExpress.XtraGrid.Columns.GridColumn MaDN;
        private DevExpress.XtraGrid.Columns.GridColumn DanhBo;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn MLT;
        private DevExpress.XtraGrid.Columns.GridColumn In;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.Button btnInTB;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnDSTB;
        private DevExpress.XtraGrid.Columns.GridColumn CreateDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn MaNV_DongNuoc;
        private System.Windows.Forms.ListView lstHD;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.GroupBox groupBox_ThemDN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaDN;
        private System.Windows.Forms.Button btnThemDN;
        private System.Windows.Forms.Button btnInGiayXN;
        private System.Windows.Forms.CheckBox chkChuKy;
        private DevExpress.XtraGrid.Columns.GridColumn CreateBy;
        private System.Windows.Forms.CheckBox chkCoTenNguoiKy;
        private System.Windows.Forms.RadioButton radA5;
        private System.Windows.Forms.RadioButton radA4;
        private DevExpress.XtraGrid.Columns.GridColumn ThemHoaDon;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn TongCongLenh;
        private System.Windows.Forms.Button btnInTBTrang;
        private System.Windows.Forms.CheckBox chkNangSuat;

    }
}