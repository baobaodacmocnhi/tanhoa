namespace ThuTien.GUI.Doi
{
    partial class frmXemTBDongNuocDoi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.MaDN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DanhBo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MLT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.To = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreateBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNV_DongNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTongDN = new System.Windows.Forms.DataGridView();
            this.TenTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongDN)).BeginInit();
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
            this.gridControl.Location = new System.Drawing.Point(5, 39);
            this.gridControl.MainView = this.gridViewDN;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl.Size = new System.Drawing.Size(1042, 593);
            this.gridControl.TabIndex = 50;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDN,
            this.gridViewCTDN});
            // 
            // gridViewDN
            // 
            this.gridViewDN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaDN,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.gridColumn1,
            this.MLT,
            this.To,
            this.CreateDate,
            this.gridColumn2,
            this.CreateBy,
            this.MaNV_DongNuoc,
            this.TinhTrang});
            this.gridViewDN.GridControl = this.gridControl;
            this.gridViewDN.IndicatorWidth = 41;
            this.gridViewDN.Name = "gridViewDN";
            this.gridViewDN.OptionsSelection.MultiSelect = true;
            this.gridViewDN.OptionsView.ColumnAutoWidth = false;
            this.gridViewDN.OptionsView.ShowGroupPanel = false;
            this.gridViewDN.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewDN_CustomDrawRowIndicator);
            this.gridViewDN.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewDN_CustomColumnDisplayText);
            // 
            // MaDN
            // 
            this.MaDN.Caption = "Mã Đóng Nước";
            this.MaDN.FieldName = "MaDN";
            this.MaDN.Name = "MaDN";
            this.MaDN.Visible = true;
            this.MaDN.VisibleIndex = 0;
            this.MaDN.Width = 80;
            // 
            // DanhBo
            // 
            this.DanhBo.Caption = "Danh Bộ";
            this.DanhBo.FieldName = "DanhBo";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Visible = true;
            this.DanhBo.VisibleIndex = 1;
            this.DanhBo.Width = 90;
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Khách Hàng";
            this.HoTen.FieldName = "HoTen";
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 2;
            this.HoTen.Width = 130;
            // 
            // DiaChi
            // 
            this.DiaChi.Caption = "Địa Chỉ";
            this.DiaChi.FieldName = "DiaChi";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Visible = true;
            this.DiaChi.VisibleIndex = 3;
            this.DiaChi.Width = 180;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tổng Cộng";
            this.gridColumn1.FieldName = "TongCong";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // MLT
            // 
            this.MLT.Caption = "Mã Lộ Trình";
            this.MLT.FieldName = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Visible = true;
            this.MLT.VisibleIndex = 5;
            // 
            // To
            // 
            this.To.Caption = "Tổ";
            this.To.FieldName = "TenTo";
            this.To.Name = "To";
            this.To.Visible = true;
            this.To.VisibleIndex = 6;
            this.To.Width = 30;
            // 
            // CreateDate
            // 
            this.CreateDate.Caption = "Ngày Lập";
            this.CreateDate.FieldName = "CreateDate";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Visible = true;
            this.CreateDate.VisibleIndex = 7;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ngày Giải Trách";
            this.gridColumn2.FieldName = "NgayGiaiTrach";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            // 
            // CreateBy
            // 
            this.CreateBy.Caption = "Người Lập";
            this.CreateBy.FieldName = "CreateBy";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.Visible = true;
            this.CreateBy.VisibleIndex = 9;
            this.CreateBy.Width = 80;
            // 
            // MaNV_DongNuoc
            // 
            this.MaNV_DongNuoc.Caption = "Người Giao";
            this.MaNV_DongNuoc.FieldName = "MaNV_DongNuoc";
            this.MaNV_DongNuoc.Name = "MaNV_DongNuoc";
            this.MaNV_DongNuoc.Visible = true;
            this.MaNV_DongNuoc.VisibleIndex = 10;
            this.MaNV_DongNuoc.Width = 80;
            // 
            // TinhTrang
            // 
            this.TinhTrang.Caption = "Tình Trạng";
            this.TinhTrang.FieldName = "TinhTrang";
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Visible = true;
            this.TinhTrang.VisibleIndex = 11;
            this.TinhTrang.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(153, 11);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(50, 21);
            this.cmbTo.TabIndex = 42;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Tổ:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(731, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 49;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(625, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(561, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(455, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Từ Ngày:";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(275, 12);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Nhân Viên:";
            // 
            // dgvTongDN
            // 
            this.dgvTongDN.AllowUserToAddRows = false;
            this.dgvTongDN.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTongDN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTongDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongDN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenTo,
            this.Tong,
            this.TongThu,
            this.TongDN,
            this.TongTon});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTongDN.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTongDN.Location = new System.Drawing.Point(1053, 39);
            this.dgvTongDN.MultiSelect = false;
            this.dgvTongDN.Name = "dgvTongDN";
            this.dgvTongDN.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTongDN.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTongDN.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTongDN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTongDN.Size = new System.Drawing.Size(298, 154);
            this.dgvTongDN.TabIndex = 51;
            // 
            // TenTo
            // 
            this.TenTo.DataPropertyName = "TenTo";
            this.TenTo.HeaderText = "Tổ";
            this.TenTo.Name = "TenTo";
            this.TenTo.ReadOnly = true;
            this.TenTo.Width = 50;
            // 
            // Tong
            // 
            this.Tong.DataPropertyName = "Tong";
            this.Tong.HeaderText = "Tổng";
            this.Tong.Name = "Tong";
            this.Tong.ReadOnly = true;
            this.Tong.Width = 50;
            // 
            // TongThu
            // 
            this.TongThu.DataPropertyName = "TongThu";
            this.TongThu.HeaderText = "Thu";
            this.TongThu.Name = "TongThu";
            this.TongThu.ReadOnly = true;
            this.TongThu.Width = 50;
            // 
            // TongDN
            // 
            this.TongDN.DataPropertyName = "TongDN";
            this.TongDN.HeaderText = "Đóng Nước";
            this.TongDN.Name = "TongDN";
            this.TongDN.ReadOnly = true;
            this.TongDN.Width = 50;
            // 
            // TongTon
            // 
            this.TongTon.DataPropertyName = "TongTon";
            this.TongTon.HeaderText = "Tồn";
            this.TongTon.Name = "TongTon";
            this.TongTon.ReadOnly = true;
            this.TongTon.Width = 50;
            // 
            // frmXemTBDongNuocDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 666);
            this.Controls.Add(this.dgvTongDN);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label4);
            this.Name = "frmXemTBDongNuocDoi";
            this.Text = "Xem Thông Báo Đóng Nước Đội";
            this.Load += new System.EventHandler(this.frmXemTBDongNuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongDN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label4;
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
        private DevExpress.XtraGrid.Columns.GridColumn MaDN;
        private DevExpress.XtraGrid.Columns.GridColumn DanhBo;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn MLT;
        private DevExpress.XtraGrid.Columns.GridColumn CreateBy;
        private DevExpress.XtraGrid.Columns.GridColumn MaNV_DongNuoc;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn NgayGiaiTrach;
        private DevExpress.XtraGrid.Columns.GridColumn TinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn To;
        private System.Windows.Forms.DataGridView dgvTongDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTon;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn CreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}