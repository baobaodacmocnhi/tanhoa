namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    partial class frmDSCatHuyDB
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridViewCTDCBD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridViewCTDCHD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewCHDB = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.radDaDuyet = new System.Windows.Forms.RadioButton();
            this.btnLuu = new System.Windows.Forms.Button();
            this.radChuaDuyet = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDCBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDCHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCHDB)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewCTDCBD
            // 
            this.gridViewCTDCBD.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.gridViewCTDCBD.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewCTDCBD.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewCTDCBD.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewCTDCBD.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.gridViewCTDCBD.Appearance.Row.Options.UseFont = true;
            this.gridViewCTDCBD.ColumnPanelRowHeight = 25;
            this.gridViewCTDCBD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.gridViewCTDCBD.GridControl = this.gridControl;
            this.gridViewCTDCBD.IndicatorWidth = 41;
            this.gridViewCTDCBD.Name = "gridViewCTDCBD";
            this.gridViewCTDCBD.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCTDCBD.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCTDCBD.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewCTDCBD.OptionsView.ColumnAutoWidth = false;
            this.gridViewCTDCBD.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Số Phiếu";
            this.gridColumn14.FieldName = "MaCTDCBD";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            this.gridColumn14.Width = 90;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Danh Bộ";
            this.gridColumn15.FieldName = "DanhBo";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            this.gridColumn15.Width = 90;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Định Mức Cũ";
            this.gridColumn16.FieldName = "DinhMuc";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            this.gridColumn16.Width = 100;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Định Mức Mới";
            this.gridColumn17.FieldName = "DinhMuc_BD";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 3;
            this.gridColumn17.Width = 110;
            // 
            // gridControl
            // 
            gridLevelNode1.LevelTemplate = this.gridViewCTDCBD;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.LevelTemplate = this.gridViewCTDCHD;
            gridLevelNode2.RelationName = "Level2";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gridControl.Location = new System.Drawing.Point(0, 67);
            this.gridControl.MainView = this.gridViewCHDB;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(2500, 470);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCTDCHD,
            this.gridViewCHDB,
            this.gridViewCTDCBD});
            // 
            // gridViewCTDCHD
            // 
            this.gridViewCTDCHD.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewCTDCHD.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewCTDCHD.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewCTDCHD.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewCTDCHD.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewCTDCHD.Appearance.Row.Options.UseFont = true;
            this.gridViewCTDCHD.ColumnPanelRowHeight = 25;
            this.gridViewCTDCHD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn20,
            this.gridColumn21});
            this.gridViewCTDCHD.GridControl = this.gridControl;
            this.gridViewCTDCHD.IndicatorWidth = 41;
            this.gridViewCTDCHD.Name = "gridViewCTDCHD";
            this.gridViewCTDCHD.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCTDCHD.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCTDCHD.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewCTDCHD.OptionsView.ColumnAutoWidth = false;
            this.gridViewCTDCHD.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Số Phiếu";
            this.gridColumn20.FieldName = "MaCTDCHD";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            this.gridColumn20.Width = 90;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Danh Bộ";
            this.gridColumn21.FieldName = "DanhBo";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 1;
            this.gridColumn21.Width = 90;
            // 
            // gridViewCHDB
            // 
            this.gridViewCHDB.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewCHDB.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewCHDB.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewCHDB.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewCHDB.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewCHDB.Appearance.Row.Options.UseFont = true;
            this.gridViewCHDB.ColumnPanelRowHeight = 25;
            this.gridViewCHDB.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridViewCHDB.GridControl = this.gridControl;
            this.gridViewCHDB.IndicatorWidth = 41;
            this.gridViewCHDB.Name = "gridViewCHDB";
            this.gridViewCHDB.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCHDB.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCHDB.OptionsBehavior.AutoPopulateColumns = false;
            this.gridViewCHDB.OptionsView.ColumnAutoWidth = false;
            this.gridViewCHDB.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Mã DCBD";
            this.gridColumn18.FieldName = "MaDCBD";
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
            // radDaDuyet
            // 
            this.radDaDuyet.AutoSize = true;
            this.radDaDuyet.Location = new System.Drawing.Point(12, 12);
            this.radDaDuyet.Name = "radDaDuyet";
            this.radDaDuyet.Size = new System.Drawing.Size(84, 21);
            this.radDaDuyet.TabIndex = 0;
            this.radDaDuyet.Text = "Đã Duyệt";
            this.radDaDuyet.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(1180, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
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
            // 
            // frmDSCatHuyDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1362, 628);
            this.Controls.Add(this.radDaDuyet);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.radChuaDuyet);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDSCatHuyDB";
            this.Text = "frmDSCHDB";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDCBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTDCHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCHDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radDaDuyet;
        private System.Windows.Forms.Button btnLuu;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCTDCBD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCTDCHD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCHDB;
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
        private System.Windows.Forms.RadioButton radChuaDuyet;
    }
}