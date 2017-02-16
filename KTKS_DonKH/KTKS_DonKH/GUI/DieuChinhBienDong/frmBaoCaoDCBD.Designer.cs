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
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.radDSDMCapCoThoiHan = new System.Windows.Forms.RadioButton();
            this.radThongKeDC = new System.Windows.Forms.RadioButton();
            this.radDSDMCapKThoiHan = new System.Windows.Forms.RadioButton();
            this.radDSDMCapNgayHetHan = new System.Windows.Forms.RadioButton();
            this.cmbPhuong = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbQuan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radThongKeDCSoCT = new System.Windows.Forms.RadioButton();
            this.radDSDMCapHetHan = new System.Windows.Forms.RadioButton();
            this.radThongKeCapDMCoThoiHanTangGiam = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHieuLucKy = new System.Windows.Forms.TextBox();
            this.radDSDanhBoDMCap = new System.Windows.Forms.RadioButton();
            this.radDSDanhBoCapDMDoanThanhNien = new System.Windows.Forms.RadioButton();
            this.radDSDanhBoDCHDCodeF2 = new System.Windows.Forms.RadioButton();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(620, 12);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(192, 60);
            this.panel_KhoangThoiGian.TabIndex = 6;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(85, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 22);
            this.dateTu.TabIndex = 13;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(85, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 22);
            this.dateDen.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(983, 23);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao.TabIndex = 11;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // radDSDMCapCoThoiHan
            // 
            this.radDSDMCapCoThoiHan.AutoSize = true;
            this.radDSDMCapCoThoiHan.Checked = true;
            this.radDSDMCapCoThoiHan.Location = new System.Drawing.Point(12, 6);
            this.radDSDMCapCoThoiHan.Name = "radDSDMCapCoThoiHan";
            this.radDSDMCapCoThoiHan.Size = new System.Drawing.Size(276, 20);
            this.radDSDMCapCoThoiHan.TabIndex = 0;
            this.radDSDMCapCoThoiHan.TabStop = true;
            this.radDSDMCapCoThoiHan.Text = "Danh Sách ĐM Cấp (có thời hạn, ngày tạo)";
            this.radDSDMCapCoThoiHan.UseVisualStyleBackColor = true;
            // 
            // radThongKeDC
            // 
            this.radThongKeDC.AutoSize = true;
            this.radThongKeDC.Location = new System.Drawing.Point(295, 31);
            this.radThongKeDC.Name = "radThongKeDC";
            this.radThongKeDC.Size = new System.Drawing.Size(150, 20);
            this.radThongKeDC.TabIndex = 3;
            this.radThongKeDC.Text = "Thống Kê Điều Chỉnh";
            this.radThongKeDC.UseVisualStyleBackColor = true;
            // 
            // radDSDMCapKThoiHan
            // 
            this.radDSDMCapKThoiHan.AutoSize = true;
            this.radDSDMCapKThoiHan.Location = new System.Drawing.Point(12, 31);
            this.radDSDMCapKThoiHan.Name = "radDSDMCapKThoiHan";
            this.radDSDMCapKThoiHan.Size = new System.Drawing.Size(268, 20);
            this.radDSDMCapKThoiHan.TabIndex = 1;
            this.radDSDMCapKThoiHan.Text = "Danh Sách ĐM Cấp (k thời hạn, ngày tạo)";
            this.radDSDMCapKThoiHan.UseVisualStyleBackColor = true;
            // 
            // radDSDMCapNgayHetHan
            // 
            this.radDSDMCapNgayHetHan.AutoSize = true;
            this.radDSDMCapNgayHetHan.Location = new System.Drawing.Point(295, 6);
            this.radDSDMCapNgayHetHan.Name = "radDSDMCapNgayHetHan";
            this.radDSDMCapNgayHetHan.Size = new System.Drawing.Size(230, 20);
            this.radDSDMCapNgayHetHan.TabIndex = 2;
            this.radDSDMCapNgayHetHan.Text = "Danh Sách ĐM Cấp (ngày hết hạn)";
            this.radDSDMCapNgayHetHan.UseVisualStyleBackColor = true;
            // 
            // cmbPhuong
            // 
            this.cmbPhuong.FormattingEnabled = true;
            this.cmbPhuong.Location = new System.Drawing.Point(877, 45);
            this.cmbPhuong.Name = "cmbPhuong";
            this.cmbPhuong.Size = new System.Drawing.Size(100, 24);
            this.cmbPhuong.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(814, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Phường:";
            // 
            // cmbQuan
            // 
            this.cmbQuan.FormattingEnabled = true;
            this.cmbQuan.Location = new System.Drawing.Point(877, 16);
            this.cmbQuan.Name = "cmbQuan";
            this.cmbQuan.Size = new System.Drawing.Size(100, 24);
            this.cmbQuan.TabIndex = 8;
            this.cmbQuan.SelectedIndexChanged += new System.EventHandler(this.cmbQuan_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(814, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Quận:";
            // 
            // radThongKeDCSoCT
            // 
            this.radThongKeDCSoCT.AutoSize = true;
            this.radThongKeDCSoCT.Location = new System.Drawing.Point(295, 56);
            this.radThongKeDCSoCT.Name = "radThongKeDCSoCT";
            this.radThongKeDCSoCT.Size = new System.Drawing.Size(196, 20);
            this.radThongKeDCSoCT.TabIndex = 12;
            this.radThongKeDCSoCT.Text = "Thống Kê Điều Chỉnh(Sổ CT)";
            this.radThongKeDCSoCT.UseVisualStyleBackColor = true;
            // 
            // radDSDMCapHetHan
            // 
            this.radDSDMCapHetHan.AutoSize = true;
            this.radDSDMCapHetHan.Location = new System.Drawing.Point(797, 78);
            this.radDSDMCapHetHan.Name = "radDSDMCapHetHan";
            this.radDSDMCapHetHan.Size = new System.Drawing.Size(197, 20);
            this.radDSDMCapHetHan.TabIndex = 13;
            this.radDSDMCapHetHan.Text = "Danh Sách ĐM Cấp (hết hạn)";
            this.radDSDMCapHetHan.UseVisualStyleBackColor = true;
            this.radDSDMCapHetHan.Visible = false;
            // 
            // radThongKeCapDMCoThoiHanTangGiam
            // 
            this.radThongKeCapDMCoThoiHanTangGiam.AutoSize = true;
            this.radThongKeCapDMCoThoiHanTangGiam.Location = new System.Drawing.Point(12, 56);
            this.radThongKeCapDMCoThoiHanTangGiam.Name = "radThongKeCapDMCoThoiHanTangGiam";
            this.radThongKeCapDMCoThoiHanTangGiam.Size = new System.Drawing.Size(268, 20);
            this.radThongKeCapDMCoThoiHanTangGiam.TabIndex = 14;
            this.radThongKeCapDMCoThoiHanTangGiam.Text = "Thống Kê ĐM Cấp (có thời hạn, ngày tạo)";
            this.radThongKeCapDMCoThoiHanTangGiam.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(446, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "HLK:";
            // 
            // txtHieuLucKy
            // 
            this.txtHieuLucKy.Location = new System.Drawing.Point(488, 30);
            this.txtHieuLucKy.Name = "txtHieuLucKy";
            this.txtHieuLucKy.Size = new System.Drawing.Size(55, 22);
            this.txtHieuLucKy.TabIndex = 16;
            // 
            // radDSDanhBoDMCap
            // 
            this.radDSDanhBoDMCap.AutoSize = true;
            this.radDSDanhBoDMCap.Location = new System.Drawing.Point(12, 82);
            this.radDSDanhBoDMCap.Name = "radDSDanhBoDMCap";
            this.radDSDanhBoDMCap.Size = new System.Drawing.Size(273, 20);
            this.radDSDanhBoDMCap.TabIndex = 17;
            this.radDSDanhBoDMCap.Text = "Danh Sách Danh Bộ ĐM Cấp (có thời hạn)";
            this.radDSDanhBoDMCap.UseVisualStyleBackColor = true;
            this.radDSDanhBoDMCap.CheckedChanged += new System.EventHandler(this.radDSDanhBoDMCap_CheckedChanged);
            // 
            // radDSDanhBoCapDMDoanThanhNien
            // 
            this.radDSDanhBoCapDMDoanThanhNien.AutoSize = true;
            this.radDSDanhBoCapDMDoanThanhNien.Location = new System.Drawing.Point(295, 82);
            this.radDSDanhBoCapDMDoanThanhNien.Name = "radDSDanhBoCapDMDoanThanhNien";
            this.radDSDanhBoCapDMDoanThanhNien.Size = new System.Drawing.Size(313, 20);
            this.radDSDanhBoCapDMDoanThanhNien.TabIndex = 18;
            this.radDSDanhBoCapDMDoanThanhNien.Text = "Danh Sách Danh Bộ ĐM Cấp (Đoàn Thanh Niên)";
            this.radDSDanhBoCapDMDoanThanhNien.UseVisualStyleBackColor = true;
            // 
            // radDSDanhBoDCHDCodeF2
            // 
            this.radDSDanhBoDCHDCodeF2.AutoSize = true;
            this.radDSDanhBoDCHDCodeF2.Location = new System.Drawing.Point(295, 108);
            this.radDSDanhBoDCHDCodeF2.Name = "radDSDanhBoDCHDCodeF2";
            this.radDSDanhBoDCHDCodeF2.Size = new System.Drawing.Size(263, 20);
            this.radDSDanhBoDCHDCodeF2.TabIndex = 19;
            this.radDSDanhBoDCHDCodeF2.Text = "Danh Sách Danh Bộ ĐCHĐ (Code F2=0)";
            this.radDSDanhBoDCHDCodeF2.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(1064, 23);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(80, 25);
            this.btnXuatExcel.TabIndex = 20;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // frmBaoCaoDCBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1321, 563);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.radDSDanhBoDCHDCodeF2);
            this.Controls.Add(this.radDSDanhBoCapDMDoanThanhNien);
            this.Controls.Add(this.radDSDanhBoDMCap);
            this.Controls.Add(this.txtHieuLucKy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radThongKeCapDMCoThoiHanTangGiam);
            this.Controls.Add(this.radDSDMCapHetHan);
            this.Controls.Add(this.radThongKeDCSoCT);
            this.Controls.Add(this.cmbPhuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbQuan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radDSDMCapNgayHetHan);
            this.Controls.Add(this.radDSDMCapKThoiHan);
            this.Controls.Add(this.radThongKeDC);
            this.Controls.Add(this.radDSDMCapCoThoiHan);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBaoCaoDCBD";
            this.Text = "Các Loại Báo Cáo Điều Chỉnh";
            this.Load += new System.EventHandler(this.frmBCCapDinhMuc_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.RadioButton radDSDMCapCoThoiHan;
        private System.Windows.Forms.RadioButton radThongKeDC;
        private System.Windows.Forms.RadioButton radDSDMCapKThoiHan;
        private System.Windows.Forms.RadioButton radDSDMCapNgayHetHan;
        private System.Windows.Forms.ComboBox cmbPhuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbQuan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radThongKeDCSoCT;
        private System.Windows.Forms.RadioButton radDSDMCapHetHan;
        private System.Windows.Forms.RadioButton radThongKeCapDMCoThoiHanTangGiam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHieuLucKy;
        private System.Windows.Forms.RadioButton radDSDanhBoDMCap;
        private System.Windows.Forms.RadioButton radDSDanhBoCapDMDoanThanhNien;
        private System.Windows.Forms.RadioButton radDSDanhBoDCHDCodeF2;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}