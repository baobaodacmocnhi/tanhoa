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
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.btnBaoCaoThongKe = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radToXuLy = new System.Windows.Forms.RadioButton();
            this.btnBaoCaoSoLuong = new System.Windows.Forms.Button();
            this.radToKH = new System.Windows.Forms.RadioButton();
            this.chkLoaiDon = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(84, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // btnBaoCaoThongKe
            // 
            this.btnBaoCaoThongKe.Location = new System.Drawing.Point(192, 38);
            this.btnBaoCaoThongKe.Name = "btnBaoCaoThongKe";
            this.btnBaoCaoThongKe.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCaoThongKe.TabIndex = 24;
            this.btnBaoCaoThongKe.Text = "Báo Cáo";
            this.btnBaoCaoThongKe.UseVisualStyleBackColor = true;
            this.btnBaoCaoThongKe.Click += new System.EventHandler(this.btnBaoCaoThongKe_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(84, 32);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
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
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(6, 21);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(180, 60);
            this.panel_KhoangThoiGian.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel_KhoangThoiGian);
            this.groupBox1.Controls.Add(this.btnBaoCaoThongKe);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 89);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radToXuLy);
            this.groupBox2.Controls.Add(this.btnBaoCaoSoLuong);
            this.groupBox2.Controls.Add(this.radToKH);
            this.groupBox2.Controls.Add(this.chkLoaiDon);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbTimTheo);
            this.groupBox2.Controls.Add(this.txtNoiDungTimKiem);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtNoiDungTimKiem2);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 114);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Số Lượng Biên Bản Thực Tế";
            // 
            // radToXuLy
            // 
            this.radToXuLy.AutoSize = true;
            this.radToXuLy.Location = new System.Drawing.Point(150, 64);
            this.radToXuLy.Name = "radToXuLy";
            this.radToXuLy.Size = new System.Drawing.Size(78, 20);
            this.radToXuLy.TabIndex = 29;
            this.radToXuLy.Text = "Tổ Xử Lý";
            this.radToXuLy.UseVisualStyleBackColor = true;
            this.radToXuLy.Visible = false;
            // 
            // btnBaoCaoSoLuong
            // 
            this.btnBaoCaoSoLuong.Location = new System.Drawing.Point(436, 37);
            this.btnBaoCaoSoLuong.Name = "btnBaoCaoSoLuong";
            this.btnBaoCaoSoLuong.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCaoSoLuong.TabIndex = 25;
            this.btnBaoCaoSoLuong.Text = "Báo Cáo";
            this.btnBaoCaoSoLuong.UseVisualStyleBackColor = true;
            this.btnBaoCaoSoLuong.Click += new System.EventHandler(this.btnBaoCaoSoLuong_Click);
            // 
            // radToKH
            // 
            this.radToKH.AutoSize = true;
            this.radToKH.Checked = true;
            this.radToKH.Location = new System.Drawing.Point(80, 64);
            this.radToKH.Name = "radToKH";
            this.radToKH.Size = new System.Drawing.Size(64, 20);
            this.radToKH.TabIndex = 28;
            this.radToKH.TabStop = true;
            this.radToKH.Text = "Tổ KH";
            this.radToKH.UseVisualStyleBackColor = true;
            this.radToKH.Visible = false;
            // 
            // chkLoaiDon
            // 
            this.chkLoaiDon.AutoSize = true;
            this.chkLoaiDon.Location = new System.Drawing.Point(250, 86);
            this.chkLoaiDon.Name = "chkLoaiDon";
            this.chkLoaiDon.Size = new System.Drawing.Size(115, 20);
            this.chkLoaiDon.TabIndex = 27;
            this.chkLoaiDon.Text = "Theo Loại Đơn";
            this.chkLoaiDon.UseVisualStyleBackColor = true;
            this.chkLoaiDon.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(250, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 59);
            this.panel1.TabIndex = 18;
            this.panel1.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(82, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(90, 22);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(82, 32);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(90, 22);
            this.dateTimePicker2.TabIndex = 14;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tìm Theo:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Số Công Văn",
            "Ngày"});
            this.cmbTimTheo.Location = new System.Drawing.Point(80, 34);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo.TabIndex = 15;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
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
            this.Text = "Các Loại Báo Cáo Kiểm Tra Xác Minh";
            this.Load += new System.EventHandler(this.frmBaoCaoKTXM_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Button btnBaoCaoThongKe;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBaoCaoSoLuong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.RadioButton radToXuLy;
        private System.Windows.Forms.RadioButton radToKH;
        private System.Windows.Forms.CheckBox chkLoaiDon;
    }
}