namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    partial class frmDSKTXM
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.radDaDuyet = new System.Windows.Forms.RadioButton();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvDSKTXM = new System.Windows.Forms.DataGridView();
            this.MaKTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayXuLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChuyen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LyDoChuyenDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNoiChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDoChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radChuaDuyet = new System.Windows.Forms.RadioButton();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewCTKTXM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewKTXM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKTXM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTKTXM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKTXM)).BeginInit();
            this.SuspendLayout();
            // 
            // radDaDuyet
            // 
            this.radDaDuyet.AutoSize = true;
            this.radDaDuyet.Location = new System.Drawing.Point(12, 12);
            this.radDaDuyet.Name = "radDaDuyet";
            this.radDaDuyet.Size = new System.Drawing.Size(84, 21);
            this.radDaDuyet.TabIndex = 0;
            this.radDaDuyet.Text = "Đã Duyệt";
            this.radDaDuyet.UseVisualStyleBackColor = true;
            this.radDaDuyet.CheckedChanged += new System.EventHandler(this.radDaDuyet_CheckedChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(1180, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvDSKTXM
            // 
            this.dgvDSKTXM.AllowUserToAddRows = false;
            this.dgvDSKTXM.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKTXM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSKTXM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKTXM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKTXM,
            this.NgayXuLy,
            this.KetQua,
            this.MaChuyen,
            this.LyDoChuyenDi,
            this.MaDon,
            this.TenLD,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.MaNoiChuyenDen,
            this.NoiChuyenDen,
            this.LyDoChuyenDen});
            this.dgvDSKTXM.Location = new System.Drawing.Point(0, 114);
            this.dgvDSKTXM.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSKTXM.MultiSelect = false;
            this.dgvDSKTXM.Name = "dgvDSKTXM";
            this.dgvDSKTXM.Size = new System.Drawing.Size(2384, 470);
            this.dgvDSKTXM.TabIndex = 7;
            this.dgvDSKTXM.Visible = false;
            this.dgvDSKTXM.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDSKTXM_CellBeginEdit);
            this.dgvDSKTXM.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSKTXM_CellEndEdit);
            this.dgvDSKTXM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSKTXM_CellFormatting);
            this.dgvDSKTXM.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSDonKH_RowPostPaint);
            this.dgvDSKTXM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSKTXM_KeyDown);
            // 
            // MaKTXM
            // 
            this.MaKTXM.DataPropertyName = "MaKTXM";
            this.MaKTXM.HeaderText = "Mã KTXM";
            this.MaKTXM.Name = "MaKTXM";
            this.MaKTXM.Visible = false;
            // 
            // NgayXuLy
            // 
            this.NgayXuLy.DataPropertyName = "NgayXuLy";
            this.NgayXuLy.HeaderText = "Ngày Xử Lý";
            this.NgayXuLy.Name = "NgayXuLy";
            this.NgayXuLy.ReadOnly = true;
            this.NgayXuLy.Width = 110;
            // 
            // KetQua
            // 
            this.KetQua.DataPropertyName = "KetQua";
            this.KetQua.HeaderText = "Kết Quả";
            this.KetQua.Name = "KetQua";
            this.KetQua.Width = 200;
            // 
            // MaChuyen
            // 
            this.MaChuyen.DataPropertyName = "MaChuyen";
            this.MaChuyen.HeaderText = "Chuyển Đi";
            this.MaChuyen.Name = "MaChuyen";
            this.MaChuyen.Width = 150;
            // 
            // LyDoChuyenDi
            // 
            this.LyDoChuyenDi.DataPropertyName = "LyDoChuyenDi";
            this.LyDoChuyenDi.HeaderText = "Ly Do Chuyển Đi";
            this.LyDoChuyenDi.Name = "LyDoChuyenDi";
            this.LyDoChuyenDi.Width = 250;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            this.MaDon.Width = 90;
            // 
            // TenLD
            // 
            this.TenLD.DataPropertyName = "TenLD";
            this.TenLD.HeaderText = "Tên Loại Đơn";
            this.TenLD.Name = "TenLD";
            this.TenLD.ReadOnly = true;
            this.TenLD.Width = 130;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Nhận";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 110;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            this.DanhBo.Width = 90;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 250;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 250;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 250;
            // 
            // MaNoiChuyenDen
            // 
            this.MaNoiChuyenDen.DataPropertyName = "MaNoiChuyenDen";
            this.MaNoiChuyenDen.HeaderText = "Mã Nơi Chuyển Đến";
            this.MaNoiChuyenDen.Name = "MaNoiChuyenDen";
            this.MaNoiChuyenDen.Visible = false;
            // 
            // NoiChuyenDen
            // 
            this.NoiChuyenDen.DataPropertyName = "NoiChuyenDen";
            this.NoiChuyenDen.HeaderText = "Nơi Chuyển Đến";
            this.NoiChuyenDen.Name = "NoiChuyenDen";
            this.NoiChuyenDen.ReadOnly = true;
            this.NoiChuyenDen.Width = 200;
            // 
            // LyDoChuyenDen
            // 
            this.LyDoChuyenDen.DataPropertyName = "LyDoChuyenDen";
            this.LyDoChuyenDen.HeaderText = "Ly Do Chuyển Đến";
            this.LyDoChuyenDen.Name = "LyDoChuyenDen";
            this.LyDoChuyenDen.ReadOnly = true;
            this.LyDoChuyenDen.Width = 250;
            // 
            // radChuaDuyet
            // 
            this.radChuaDuyet.AutoSize = true;
            this.radChuaDuyet.Location = new System.Drawing.Point(12, 39);
            this.radChuaDuyet.Name = "radChuaDuyet";
            this.radChuaDuyet.Size = new System.Drawing.Size(98, 21);
            this.radChuaDuyet.TabIndex = 1;
            this.radChuaDuyet.Text = "Chưa Duyệt";
            this.radChuaDuyet.UseVisualStyleBackColor = true;
            this.radChuaDuyet.CheckedChanged += new System.EventHandler(this.radChuaDuyet_CheckedChanged);
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(577, 35);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(130, 25);
            this.dateTimKiem.TabIndex = 6;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm Theo:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Ngày Lập"});
            this.cmbTimTheo.Location = new System.Drawing.Point(376, 12);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(120, 25);
            this.cmbTimTheo.TabIndex = 3;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(577, 12);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem.TabIndex = 5;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nội Dung:";
            // 
            // gridControl
            // 
            gridLevelNode1.LevelTemplate = this.gridViewCTKTXM;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 66);
            this.gridControl.MainView = this.gridViewKTXM;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(2500, 470);
            this.gridControl.TabIndex = 9;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCTKTXM,
            this.gridViewKTXM});
            // 
            // gridViewCTKTXM
            // 
            this.gridViewCTKTXM.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.gridViewCTKTXM.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewCTKTXM.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewCTKTXM.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewCTKTXM.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.gridViewCTKTXM.Appearance.Row.Options.UseFont = true;
            this.gridViewCTKTXM.ColumnPanelRowHeight = 25;
            this.gridViewCTKTXM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn20});
            this.gridViewCTKTXM.GridControl = this.gridControl;
            this.gridViewCTKTXM.IndicatorWidth = 41;
            this.gridViewCTKTXM.Name = "gridViewCTKTXM";
            this.gridViewCTKTXM.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCTKTXM.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCTKTXM.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewCTKTXM.OptionsView.ColumnAutoWidth = false;
            this.gridViewCTKTXM.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Mã CTKTXM";
            this.gridColumn14.FieldName = "MaCTKTXM";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            this.gridColumn14.Width = 100;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Ngày Lập";
            this.gridColumn15.FieldName = "CreateDate";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            this.gridColumn15.Width = 100;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Danh Bộ";
            this.gridColumn16.FieldName = "DanhBo";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            this.gridColumn16.Width = 250;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Nội Dung Kiểm Tra";
            this.gridColumn17.FieldName = "NoiDungKiemTra";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 3;
            this.gridColumn17.Width = 500;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Người Đi";
            this.gridColumn20.FieldName = "CreateBy";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 4;
            this.gridColumn20.Width = 300;
            // 
            // gridViewKTXM
            // 
            this.gridViewKTXM.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewKTXM.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewKTXM.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewKTXM.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewKTXM.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewKTXM.Appearance.Row.Options.UseFont = true;
            this.gridViewKTXM.ColumnPanelRowHeight = 25;
            this.gridViewKTXM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn18,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn19,
            this.gridColumn12,
            this.gridColumn13});
            this.gridViewKTXM.GridControl = this.gridControl;
            this.gridViewKTXM.IndicatorWidth = 41;
            this.gridViewKTXM.Name = "gridViewKTXM";
            this.gridViewKTXM.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewKTXM.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewKTXM.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewKTXM.OptionsFind.AllowFindPanel = false;
            this.gridViewKTXM.OptionsView.ColumnAutoWidth = false;
            this.gridViewKTXM.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Mã KTXM";
            this.gridColumn18.FieldName = "MaKTXM";
            this.gridColumn18.Name = "gridColumn18";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ngày Xử Lý";
            this.gridColumn1.FieldName = "NgayXuLy";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 110;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kết Quả";
            this.gridColumn2.FieldName = "KetQua";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Chuyển Đi";
            this.gridColumn3.FieldName = "MaChuyen";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Lý Do Chuyển";
            this.gridColumn4.FieldName = "LyDoChuyenDi";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 250;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mã Đơn";
            this.gridColumn5.FieldName = "MaDon";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 90;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tên Loại Đơn";
            this.gridColumn6.FieldName = "TenLD";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 130;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ngày Nhận";
            this.gridColumn7.FieldName = "CreateDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 110;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Danh Bộ";
            this.gridColumn8.FieldName = "DanhBo";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 90;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Khách Hàng";
            this.gridColumn9.FieldName = "HoTen";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 250;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Địa Chỉ";
            this.gridColumn10.FieldName = "DiaChi";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 250;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Nội Dung";
            this.gridColumn11.FieldName = "NoiDung";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 250;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Mã Nơi Chuyển Đến";
            this.gridColumn19.FieldName = "MaNoiChuyenDen";
            this.gridColumn19.Name = "gridColumn19";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Nơi Chuyển Đến";
            this.gridColumn12.FieldName = "NoiChuyenDen";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            this.gridColumn12.Width = 200;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Lý Do Chuyển Đến";
            this.gridColumn13.FieldName = "LyDoChuyenDen";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            this.gridColumn13.Width = 250;
            // 
            // frmDSKTXM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 579);
            this.Controls.Add(this.dgvDSKTXM);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radDaDuyet);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.radChuaDuyet);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDSKTXM";
            this.Text = "Danh Sách Kiểm Tra Xác Minh";
            this.Load += new System.EventHandler(this.frmKTXM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKTXM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTKTXM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKTXM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radDaDuyet;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.RadioButton radChuaDuyet;
        private System.Windows.Forms.DataGridView dgvDSKTXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKTXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetQua;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyenDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNoiChuyenDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyenDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyenDen;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCTKTXM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewKTXM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
    }
}