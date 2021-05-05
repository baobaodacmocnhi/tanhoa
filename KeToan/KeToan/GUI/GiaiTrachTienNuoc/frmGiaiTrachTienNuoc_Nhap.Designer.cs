namespace KeToan.GUI.GiaiTrachTienNuoc
{
    partial class frmGiaiTrachTienNuoc_Nhap
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
            this.gridViewChiTiet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DanhBo_CT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ky = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTien_CT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayGiaiTrach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoPhieuThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayPhieuThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DanhBo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTienTon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.chkTon = new System.Windows.Forms.CheckBox();
            this.txtTongCongTon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewChiTiet
            // 
            this.gridViewChiTiet.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.gridViewChiTiet.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewChiTiet.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewChiTiet.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewChiTiet.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.gridViewChiTiet.Appearance.Row.Options.UseFont = true;
            this.gridViewChiTiet.ColumnPanelRowHeight = 25;
            this.gridViewChiTiet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DanhBo_CT,
            this.Ky,
            this.SoTien_CT,
            this.NgayGiaiTrach});
            this.gridViewChiTiet.GridControl = this.gridControl;
            this.gridViewChiTiet.Name = "gridViewChiTiet";
            this.gridViewChiTiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewChiTiet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewChiTiet.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewChiTiet.OptionsView.ColumnAutoWidth = false;
            this.gridViewChiTiet.OptionsView.ShowGroupPanel = false;
            this.gridViewChiTiet.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewChiTiet_CustomColumnDisplayText);
            // 
            // DanhBo_CT
            // 
            this.DanhBo_CT.Caption = "Danh Bộ";
            this.DanhBo_CT.FieldName = "DanhBo";
            this.DanhBo_CT.Name = "DanhBo_CT";
            this.DanhBo_CT.Visible = true;
            this.DanhBo_CT.VisibleIndex = 0;
            this.DanhBo_CT.Width = 200;
            // 
            // Ky
            // 
            this.Ky.Caption = "Kỳ";
            this.Ky.FieldName = "Ky";
            this.Ky.Name = "Ky";
            this.Ky.Visible = true;
            this.Ky.VisibleIndex = 1;
            this.Ky.Width = 100;
            // 
            // SoTien_CT
            // 
            this.SoTien_CT.Caption = "Số Tiền";
            this.SoTien_CT.FieldName = "SoTien";
            this.SoTien_CT.Name = "SoTien_CT";
            this.SoTien_CT.Visible = true;
            this.SoTien_CT.VisibleIndex = 2;
            this.SoTien_CT.Width = 100;
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.Caption = "Ngày Giải Trách";
            this.NgayGiaiTrach.FieldName = "NgayGiaiTrach";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            this.NgayGiaiTrach.Visible = true;
            this.NgayGiaiTrach.VisibleIndex = 3;
            this.NgayGiaiTrach.Width = 120;
            // 
            // gridControl
            // 
            gridLevelNode1.LevelTemplate = this.gridViewChiTiet;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(12, 34);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(810, 575);
            this.gridControl.TabIndex = 91;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridViewChiTiet});
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.ColumnPanelRowHeight = 25;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.SoPhieuThu,
            this.NgayPhieuThu,
            this.DanhBo,
            this.SoTien,
            this.SoTienTon,
            this.TinhTrang});
            this.gridView.GridControl = this.gridControl;
            this.gridView.IndicatorWidth = 41;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView.OptionsFind.AllowFindPanel = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView_CustomDrawRowIndicator);
            this.gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView_CustomColumnDisplayText);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // SoPhieuThu
            // 
            this.SoPhieuThu.Caption = "Số PT";
            this.SoPhieuThu.FieldName = "SoPhieuThu";
            this.SoPhieuThu.Name = "SoPhieuThu";
            this.SoPhieuThu.Visible = true;
            this.SoPhieuThu.VisibleIndex = 0;
            this.SoPhieuThu.Width = 150;
            // 
            // NgayPhieuThu
            // 
            this.NgayPhieuThu.Caption = "Ngày PT";
            this.NgayPhieuThu.FieldName = "NgayPhieuThu";
            this.NgayPhieuThu.Name = "NgayPhieuThu";
            this.NgayPhieuThu.Visible = true;
            this.NgayPhieuThu.VisibleIndex = 1;
            this.NgayPhieuThu.Width = 100;
            // 
            // DanhBo
            // 
            this.DanhBo.Caption = "Danh Bộ";
            this.DanhBo.FieldName = "DanhBo";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Visible = true;
            this.DanhBo.VisibleIndex = 2;
            this.DanhBo.Width = 200;
            // 
            // SoTien
            // 
            this.SoTien.Caption = "Số Tiền";
            this.SoTien.FieldName = "SoTien";
            this.SoTien.Name = "SoTien";
            this.SoTien.Visible = true;
            this.SoTien.VisibleIndex = 3;
            this.SoTien.Width = 100;
            // 
            // SoTienTon
            // 
            this.SoTienTon.Caption = "Số Tiền Tồn";
            this.SoTienTon.FieldName = "SoTienTon";
            this.SoTienTon.Name = "SoTienTon";
            this.SoTienTon.Visible = true;
            this.SoTienTon.VisibleIndex = 4;
            this.SoTienTon.Width = 100;
            // 
            // TinhTrang
            // 
            this.TinhTrang.Caption = "Tình Trạng";
            this.TinhTrang.FieldName = "TinhTrang";
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Visible = true;
            this.TinhTrang.VisibleIndex = 5;
            this.TinhTrang.Width = 100;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 5);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 78;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(175, 8);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Từ Ngày";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(342, 8);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 83;
            this.label3.Text = "Đến Ngày";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(498, 6);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 82;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(579, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 88;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtTongCong
            // 
            this.txtTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong.Location = new System.Drawing.Point(502, 609);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong.TabIndex = 89;
            // 
            // txtTong
            // 
            this.txtTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTong.Location = new System.Drawing.Point(12, 609);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(50, 20);
            this.txtTong.TabIndex = 90;
            // 
            // chkTon
            // 
            this.chkTon.AutoSize = true;
            this.chkTon.Location = new System.Drawing.Point(448, 10);
            this.chkTon.Name = "chkTon";
            this.chkTon.Size = new System.Drawing.Size(45, 17);
            this.chkTon.TabIndex = 92;
            this.chkTon.Text = "Tồn";
            this.chkTon.UseVisualStyleBackColor = true;
            // 
            // txtTongCongTon
            // 
            this.txtTongCongTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCongTon.Location = new System.Drawing.Point(602, 609);
            this.txtTongCongTon.Name = "txtTongCongTon";
            this.txtTongCongTon.Size = new System.Drawing.Size(100, 20);
            this.txtTongCongTon.TabIndex = 93;
            // 
            // frmGiaiTrachTienNuoc_Nhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 647);
            this.Controls.Add(this.txtTongCongTon);
            this.Controls.Add(this.chkTon);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.txtTong);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnChonFile);
            this.Name = "frmGiaiTrachTienNuoc_Nhap";
            this.Text = "Nhập";
            this.Load += new System.EventHandler(this.frmGiaiTrachTienNuoc_Nhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.TextBox txtTong;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewChiTiet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn DanhBo_CT;
        private DevExpress.XtraGrid.Columns.GridColumn Ky;
        private DevExpress.XtraGrid.Columns.GridColumn SoTien_CT;
        private DevExpress.XtraGrid.Columns.GridColumn NgayGiaiTrach;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn SoPhieuThu;
        private DevExpress.XtraGrid.Columns.GridColumn NgayPhieuThu;
        private DevExpress.XtraGrid.Columns.GridColumn DanhBo;
        private DevExpress.XtraGrid.Columns.GridColumn SoTien;
        private DevExpress.XtraGrid.Columns.GridColumn SoTienTon;
        private DevExpress.XtraGrid.Columns.GridColumn TinhTrang;
        private System.Windows.Forms.CheckBox chkTon;
        private System.Windows.Forms.TextBox txtTongCongTon;
    }
}