namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    partial class frmBaoCaoKTXM
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
            this.dateTu_ThongKeHienTrangKiemTra = new System.Windows.Forms.DateTimePicker();
            this.btnBaoCao_ThongKeHienTrangKiemTra = new System.Windows.Forms.Button();
            this.dateDen_ThongKeHienTrangKiemTra = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBaoCao_SoLuong = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTimTheo_SoLuong = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTu_SoLuong = new System.Windows.Forms.DateTimePicker();
            this.dateDen_SoLuong = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAll_ThongKeHienTrangKiemTra = new System.Windows.Forms.CheckBox();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTu_ThongKeHienTrangKiemTra
            // 
            this.dateTu_ThongKeHienTrangKiemTra.CustomFormat = "dd/MM/yyyy";
            this.dateTu_ThongKeHienTrangKiemTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_ThongKeHienTrangKiemTra.Location = new System.Drawing.Point(84, 4);
            this.dateTu_ThongKeHienTrangKiemTra.Name = "dateTu_ThongKeHienTrangKiemTra";
            this.dateTu_ThongKeHienTrangKiemTra.Size = new System.Drawing.Size(90, 22);
            this.dateTu_ThongKeHienTrangKiemTra.TabIndex = 13;
            // 
            // btnBaoCao_ThongKeHienTrangKiemTra
            // 
            this.btnBaoCao_ThongKeHienTrangKiemTra.Location = new System.Drawing.Point(192, 38);
            this.btnBaoCao_ThongKeHienTrangKiemTra.Name = "btnBaoCao_ThongKeHienTrangKiemTra";
            this.btnBaoCao_ThongKeHienTrangKiemTra.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_ThongKeHienTrangKiemTra.TabIndex = 24;
            this.btnBaoCao_ThongKeHienTrangKiemTra.Text = "Báo Cáo";
            this.btnBaoCao_ThongKeHienTrangKiemTra.UseVisualStyleBackColor = true;
            this.btnBaoCao_ThongKeHienTrangKiemTra.Click += new System.EventHandler(this.btnBaoCao_ThongKeHienTrangKiemTra_Click);
            // 
            // dateDen_ThongKeHienTrangKiemTra
            // 
            this.dateDen_ThongKeHienTrangKiemTra.CustomFormat = "dd/MM/yyyy";
            this.dateDen_ThongKeHienTrangKiemTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_ThongKeHienTrangKiemTra.Location = new System.Drawing.Point(84, 32);
            this.dateDen_ThongKeHienTrangKiemTra.Name = "dateDen_ThongKeHienTrangKiemTra";
            this.dateDen_ThongKeHienTrangKiemTra.Size = new System.Drawing.Size(90, 22);
            this.dateDen_ThongKeHienTrangKiemTra.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu_ThongKeHienTrangKiemTra);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen_ThongKeHienTrangKiemTra);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(6, 21);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(180, 60);
            this.panel_KhoangThoiGian.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll_ThongKeHienTrangKiemTra);
            this.groupBox1.Controls.Add(this.panel_KhoangThoiGian);
            this.groupBox1.Controls.Add(this.btnBaoCao_ThongKeHienTrangKiemTra);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 89);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê Hiện Trạng Kiểm Tra";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBaoCao_SoLuong);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbTimTheo_SoLuong);
            this.groupBox2.Controls.Add(this.txtNoiDungTimKiem);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtNoiDungTimKiem2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 91);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Số Lượng Biên Bản";
            // 
            // btnBaoCao_SoLuong
            // 
            this.btnBaoCao_SoLuong.Location = new System.Drawing.Point(436, 37);
            this.btnBaoCao_SoLuong.Name = "btnBaoCao_SoLuong";
            this.btnBaoCao_SoLuong.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_SoLuong.TabIndex = 25;
            this.btnBaoCao_SoLuong.Text = "Báo Cáo";
            this.btnBaoCao_SoLuong.UseVisualStyleBackColor = true;
            this.btnBaoCao_SoLuong.Click += new System.EventHandler(this.btnBaoCao_SoLuong_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tìm Theo:";
            // 
            // cmbTimTheo_SoLuong
            // 
            this.cmbTimTheo_SoLuong.FormattingEnabled = true;
            this.cmbTimTheo_SoLuong.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Số Công Văn",
            "Ngày"});
            this.cmbTimTheo_SoLuong.Location = new System.Drawing.Point(80, 34);
            this.cmbTimTheo_SoLuong.Name = "cmbTimTheo_SoLuong";
            this.cmbTimTheo_SoLuong.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo_SoLuong.TabIndex = 15;
            this.cmbTimTheo_SoLuong.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(260, 34);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 22);
            this.txtNoiDungTimKiem.TabIndex = 17;
            this.txtNoiDungTimKiem.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Nội Dung:";
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(260, 58);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(130, 22);
            this.txtNoiDungTimKiem2.TabIndex = 19;
            this.txtNoiDungTimKiem2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTu_SoLuong);
            this.panel1.Controls.Add(this.dateDen_SoLuong);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(250, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 59);
            this.panel1.TabIndex = 18;
            this.panel1.Visible = false;
            // 
            // dateTu_SoLuong
            // 
            this.dateTu_SoLuong.CustomFormat = "dd/MM/yyyy";
            this.dateTu_SoLuong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_SoLuong.Location = new System.Drawing.Point(82, 5);
            this.dateTu_SoLuong.Name = "dateTu_SoLuong";
            this.dateTu_SoLuong.Size = new System.Drawing.Size(90, 22);
            this.dateTu_SoLuong.TabIndex = 13;
            // 
            // dateDen_SoLuong
            // 
            this.dateDen_SoLuong.CustomFormat = "dd/MM/yyyy";
            this.dateDen_SoLuong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_SoLuong.Location = new System.Drawing.Point(82, 32);
            this.dateDen_SoLuong.Name = "dateDen_SoLuong";
            this.dateDen_SoLuong.Size = new System.Drawing.Size(90, 22);
            this.dateDen_SoLuong.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Từ Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Đến Ngày:";
            // 
            // chkAll_ThongKeHienTrangKiemTra
            // 
            this.chkAll_ThongKeHienTrangKiemTra.AutoSize = true;
            this.chkAll_ThongKeHienTrangKiemTra.Location = new System.Drawing.Point(273, 41);
            this.chkAll_ThongKeHienTrangKiemTra.Name = "chkAll_ThongKeHienTrangKiemTra";
            this.chkAll_ThongKeHienTrangKiemTra.Size = new System.Drawing.Size(114, 20);
            this.chkAll_ThongKeHienTrangKiemTra.TabIndex = 25;
            this.chkAll_ThongKeHienTrangKiemTra.Text = "Tất Cả Các Tổ";
            this.chkAll_ThongKeHienTrangKiemTra.UseVisualStyleBackColor = true;
            // 
            // frmBaoCaoKTXM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(676, 436);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBaoCaoKTXM";
            this.Text = "Báo Cáo Kiểm Tra Xác Minh";
            this.Load += new System.EventHandler(this.frmBaoCaoKTXM_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTu_ThongKeHienTrangKiemTra;
        private System.Windows.Forms.Button btnBaoCao_ThongKeHienTrangKiemTra;
        private System.Windows.Forms.DateTimePicker dateDen_ThongKeHienTrangKiemTra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBaoCao_SoLuong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTu_SoLuong;
        private System.Windows.Forms.DateTimePicker dateDen_SoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTimTheo_SoLuong;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.CheckBox chkAll_ThongKeHienTrangKiemTra;
    }
}