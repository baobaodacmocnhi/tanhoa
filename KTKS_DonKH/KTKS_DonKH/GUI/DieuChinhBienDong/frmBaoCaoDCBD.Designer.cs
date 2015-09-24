namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmBaoCaoDCBD
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.radDanhSachDMCapCoThoiHan = new System.Windows.Forms.RadioButton();
            this.radThongKeDC = new System.Windows.Forms.RadioButton();
            this.radDSChuyenDocSo = new System.Windows.Forms.RadioButton();
            this.radDSChuyenDocSo_LocUser = new System.Windows.Forms.RadioButton();
            this.radDanhSachDMCapKThoiHan = new System.Windows.Forms.RadioButton();
            this.radDanhSachDMCapNgayHetHan = new System.Windows.Forms.RadioButton();
            this.cmbPhuong = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbQuan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radThongKeDCSoCT = new System.Windows.Forms.RadioButton();
            this.radDSDMCapHetHan = new System.Windows.Forms.RadioButton();
            this.radThongKeCapDMCoThoiHanTangGiam = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystalReportViewer1);
            this.panel1.Location = new System.Drawing.Point(13, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1265, 470);
            this.panel1.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1259, 464);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(768, 1);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(192, 64);
            this.panel_KhoangThoiGian.TabIndex = 6;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(85, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 25);
            this.dateTu.TabIndex = 13;
            this.dateTu.ValueChanged += new System.EventHandler(this.dateTu_ValueChanged);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(85, 35);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 25);
            this.dateDen.TabIndex = 14;
            this.dateDen.ValueChanged += new System.EventHandler(this.dateDen_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Image = global::KTKS_DonKH.Properties.Resources.find_24x24;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(1181, 6);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(94, 35);
            this.btnBaoCao.TabIndex = 11;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // radDanhSachDMCapCoThoiHan
            // 
            this.radDanhSachDMCapCoThoiHan.AutoSize = true;
            this.radDanhSachDMCapCoThoiHan.Checked = true;
            this.radDanhSachDMCapCoThoiHan.Location = new System.Drawing.Point(12, 6);
            this.radDanhSachDMCapCoThoiHan.Name = "radDanhSachDMCapCoThoiHan";
            this.radDanhSachDMCapCoThoiHan.Size = new System.Drawing.Size(283, 21);
            this.radDanhSachDMCapCoThoiHan.TabIndex = 0;
            this.radDanhSachDMCapCoThoiHan.TabStop = true;
            this.radDanhSachDMCapCoThoiHan.Text = "Danh Sách ĐM Cấp (có thời hạn, ngày tạo)";
            this.radDanhSachDMCapCoThoiHan.UseVisualStyleBackColor = true;
            // 
            // radThongKeDC
            // 
            this.radThongKeDC.AutoSize = true;
            this.radThongKeDC.Location = new System.Drawing.Point(295, 33);
            this.radThongKeDC.Name = "radThongKeDC";
            this.radThongKeDC.Size = new System.Drawing.Size(155, 21);
            this.radThongKeDC.TabIndex = 3;
            this.radThongKeDC.Text = "Thống Kê Điều Chỉnh";
            this.radThongKeDC.UseVisualStyleBackColor = true;
            // 
            // radDSChuyenDocSo
            // 
            this.radDSChuyenDocSo.AutoSize = true;
            this.radDSChuyenDocSo.Location = new System.Drawing.Point(531, 6);
            this.radDSChuyenDocSo.Name = "radDSChuyenDocSo";
            this.radDSChuyenDocSo.Size = new System.Drawing.Size(188, 21);
            this.radDSChuyenDocSo.TabIndex = 4;
            this.radDSChuyenDocSo.Text = "Danh Sách Chuyển Đọc Số";
            this.radDSChuyenDocSo.UseVisualStyleBackColor = true;
            // 
            // radDSChuyenDocSo_LocUser
            // 
            this.radDSChuyenDocSo_LocUser.AutoSize = true;
            this.radDSChuyenDocSo_LocUser.Location = new System.Drawing.Point(531, 33);
            this.radDSChuyenDocSo_LocUser.Name = "radDSChuyenDocSo_LocUser";
            this.radDSChuyenDocSo_LocUser.Size = new System.Drawing.Size(231, 21);
            this.radDSChuyenDocSo_LocUser.TabIndex = 5;
            this.radDSChuyenDocSo_LocUser.Text = "Danh Sách Chuyển Đọc Số (User)";
            this.radDSChuyenDocSo_LocUser.UseVisualStyleBackColor = true;
            // 
            // radDanhSachDMCapKThoiHan
            // 
            this.radDanhSachDMCapKThoiHan.AutoSize = true;
            this.radDanhSachDMCapKThoiHan.Location = new System.Drawing.Point(12, 33);
            this.radDanhSachDMCapKThoiHan.Name = "radDanhSachDMCapKThoiHan";
            this.radDanhSachDMCapKThoiHan.Size = new System.Drawing.Size(276, 21);
            this.radDanhSachDMCapKThoiHan.TabIndex = 1;
            this.radDanhSachDMCapKThoiHan.Text = "Danh Sách ĐM Cấp (k thời hạn, ngày tạo)";
            this.radDanhSachDMCapKThoiHan.UseVisualStyleBackColor = true;
            // 
            // radDanhSachDMCapNgayHetHan
            // 
            this.radDanhSachDMCapNgayHetHan.AutoSize = true;
            this.radDanhSachDMCapNgayHetHan.Location = new System.Drawing.Point(295, 6);
            this.radDanhSachDMCapNgayHetHan.Name = "radDanhSachDMCapNgayHetHan";
            this.radDanhSachDMCapNgayHetHan.Size = new System.Drawing.Size(236, 21);
            this.radDanhSachDMCapNgayHetHan.TabIndex = 2;
            this.radDanhSachDMCapNgayHetHan.Text = "Danh Sách ĐM Cấp (ngày hết hạn)";
            this.radDanhSachDMCapNgayHetHan.UseVisualStyleBackColor = true;
            // 
            // cmbPhuong
            // 
            this.cmbPhuong.FormattingEnabled = true;
            this.cmbPhuong.Location = new System.Drawing.Point(1025, 36);
            this.cmbPhuong.Name = "cmbPhuong";
            this.cmbPhuong.Size = new System.Drawing.Size(150, 25);
            this.cmbPhuong.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(962, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Phường:";
            // 
            // cmbQuan
            // 
            this.cmbQuan.FormattingEnabled = true;
            this.cmbQuan.Location = new System.Drawing.Point(1025, 5);
            this.cmbQuan.Name = "cmbQuan";
            this.cmbQuan.Size = new System.Drawing.Size(150, 25);
            this.cmbQuan.TabIndex = 8;
            this.cmbQuan.SelectedIndexChanged += new System.EventHandler(this.cmbQuan_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(962, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Quận:";
            // 
            // radThongKeDCSoCT
            // 
            this.radThongKeDCSoCT.AutoSize = true;
            this.radThongKeDCSoCT.Location = new System.Drawing.Point(295, 60);
            this.radThongKeDCSoCT.Name = "radThongKeDCSoCT";
            this.radThongKeDCSoCT.Size = new System.Drawing.Size(203, 21);
            this.radThongKeDCSoCT.TabIndex = 12;
            this.radThongKeDCSoCT.Text = "Thống Kê Điều Chỉnh(Sổ CT)";
            this.radThongKeDCSoCT.UseVisualStyleBackColor = true;
            // 
            // radDSDMCapHetHan
            // 
            this.radDSDMCapHetHan.AutoSize = true;
            this.radDSDMCapHetHan.Location = new System.Drawing.Point(531, 60);
            this.radDSDMCapHetHan.Name = "radDSDMCapHetHan";
            this.radDSDMCapHetHan.Size = new System.Drawing.Size(204, 21);
            this.radDSDMCapHetHan.TabIndex = 13;
            this.radDSDMCapHetHan.Text = "Danh Sách ĐM Cấp (hết hạn)";
            this.radDSDMCapHetHan.UseVisualStyleBackColor = true;
            this.radDSDMCapHetHan.Visible = false;
            // 
            // radThongKeCapDMCoThoiHanTangGiam
            // 
            this.radThongKeCapDMCoThoiHanTangGiam.AutoSize = true;
            this.radThongKeCapDMCoThoiHanTangGiam.Location = new System.Drawing.Point(12, 60);
            this.radThongKeCapDMCoThoiHanTangGiam.Name = "radThongKeCapDMCoThoiHanTangGiam";
            this.radThongKeCapDMCoThoiHanTangGiam.Size = new System.Drawing.Size(277, 21);
            this.radThongKeCapDMCoThoiHanTangGiam.TabIndex = 14;
            this.radThongKeCapDMCoThoiHanTangGiam.Text = "Thống Kê ĐM Cấp (có thời hạn, ngày tạo)";
            this.radThongKeCapDMCoThoiHanTangGiam.UseVisualStyleBackColor = true;
            // 
            // frmBaoCaoDCBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1321, 598);
            this.Controls.Add(this.radThongKeCapDMCoThoiHanTangGiam);
            this.Controls.Add(this.radDSDMCapHetHan);
            this.Controls.Add(this.radThongKeDCSoCT);
            this.Controls.Add(this.cmbPhuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbQuan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radDanhSachDMCapNgayHetHan);
            this.Controls.Add(this.radDanhSachDMCapKThoiHan);
            this.Controls.Add(this.radDSChuyenDocSo_LocUser);
            this.Controls.Add(this.radDSChuyenDocSo);
            this.Controls.Add(this.radThongKeDC);
            this.Controls.Add(this.radDanhSachDMCapCoThoiHan);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBaoCaoDCBD";
            this.Text = "Các Loại Báo Cáo Điều Chỉnh";
            this.Load += new System.EventHandler(this.frmBCCapDinhMuc_Load);
            this.panel1.ResumeLayout(false);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.RadioButton radDanhSachDMCapCoThoiHan;
        private System.Windows.Forms.RadioButton radThongKeDC;
        private System.Windows.Forms.RadioButton radDSChuyenDocSo;
        private System.Windows.Forms.RadioButton radDSChuyenDocSo_LocUser;
        private System.Windows.Forms.RadioButton radDanhSachDMCapKThoiHan;
        private System.Windows.Forms.RadioButton radDanhSachDMCapNgayHetHan;
        private System.Windows.Forms.ComboBox cmbPhuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbQuan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radThongKeDCSoCT;
        private System.Windows.Forms.RadioButton radDSDMCapHetHan;
        private System.Windows.Forms.RadioButton radThongKeCapDMCoThoiHanTangGiam;
    }
}