namespace KTKS_DonKH.GUI.ToXuLy
{
    partial class frmBaoCaoDonTXL
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
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBaoCao_LichSuChuyenDon = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTu_LichSuChuyenDon = new System.Windows.Forms.DateTimePicker();
            this.dateDen_LichSuChuyenDon = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkChuaKT_DSChuyenKTXM = new System.Windows.Forms.CheckBox();
            this.btnBaoCao_DSChuyenKTXM = new System.Windows.Forms.Button();
            this.cmbTimTheo_DSChuyenKTXM = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem_DSChuyenKTXM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian_DSChuyenKTXM = new System.Windows.Forms.Panel();
            this.dateTu_DSChuyenKTXM = new System.Windows.Forms.DateTimePicker();
            this.dateDen_DSChuyenKTXM = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel_KhoangThoiGian_DSChuyenKTXM.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(189, 41);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao.TabIndex = 23;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(6, 21);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(177, 60);
            this.panel_KhoangThoiGian.TabIndex = 22;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(80, 5);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(80, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaoCao_LichSuChuyenDon);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 87);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lịch Sử Chuyển Đơn";
            // 
            // btnBaoCao_LichSuChuyenDon
            // 
            this.btnBaoCao_LichSuChuyenDon.Location = new System.Drawing.Point(189, 40);
            this.btnBaoCao_LichSuChuyenDon.Name = "btnBaoCao_LichSuChuyenDon";
            this.btnBaoCao_LichSuChuyenDon.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_LichSuChuyenDon.TabIndex = 25;
            this.btnBaoCao_LichSuChuyenDon.Text = "Báo Cáo";
            this.btnBaoCao_LichSuChuyenDon.UseVisualStyleBackColor = true;
            this.btnBaoCao_LichSuChuyenDon.Click += new System.EventHandler(this.btnBaoCao_LichSuChuyenDon_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTu_LichSuChuyenDon);
            this.panel1.Controls.Add(this.dateDen_LichSuChuyenDon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 60);
            this.panel1.TabIndex = 24;
            // 
            // dateTu_LichSuChuyenDon
            // 
            this.dateTu_LichSuChuyenDon.CustomFormat = "dd/MM/yyyy";
            this.dateTu_LichSuChuyenDon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_LichSuChuyenDon.Location = new System.Drawing.Point(80, 5);
            this.dateTu_LichSuChuyenDon.Name = "dateTu_LichSuChuyenDon";
            this.dateTu_LichSuChuyenDon.Size = new System.Drawing.Size(90, 22);
            this.dateTu_LichSuChuyenDon.TabIndex = 13;
            // 
            // dateDen_LichSuChuyenDon
            // 
            this.dateDen_LichSuChuyenDon.CustomFormat = "dd/MM/yyyy";
            this.dateDen_LichSuChuyenDon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_LichSuChuyenDon.Location = new System.Drawing.Point(80, 33);
            this.dateDen_LichSuChuyenDon.Name = "dateDen_LichSuChuyenDon";
            this.dateDen_LichSuChuyenDon.Size = new System.Drawing.Size(90, 22);
            this.dateDen_LichSuChuyenDon.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Từ Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Đến Ngày:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel_KhoangThoiGian);
            this.groupBox2.Controls.Add(this.btnBaoCao);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 87);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống Kê";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkChuaKT_DSChuyenKTXM);
            this.groupBox3.Controls.Add(this.btnBaoCao_DSChuyenKTXM);
            this.groupBox3.Controls.Add(this.cmbTimTheo_DSChuyenKTXM);
            this.groupBox3.Controls.Add(this.txtNoiDungTimKiem_DSChuyenKTXM);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.panel_KhoangThoiGian_DSChuyenKTXM);
            this.groupBox3.Location = new System.Drawing.Point(12, 198);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 85);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thống Kê Chuyển KTXM";
            // 
            // chkChuaKT_DSChuyenKTXM
            // 
            this.chkChuaKT_DSChuyenKTXM.AutoSize = true;
            this.chkChuaKT_DSChuyenKTXM.Location = new System.Drawing.Point(80, 59);
            this.chkChuaKT_DSChuyenKTXM.Name = "chkChuaKT_DSChuyenKTXM";
            this.chkChuaKT_DSChuyenKTXM.Size = new System.Drawing.Size(78, 20);
            this.chkChuaKT_DSChuyenKTXM.TabIndex = 38;
            this.chkChuaKT_DSChuyenKTXM.Text = "Chưa KT";
            this.chkChuaKT_DSChuyenKTXM.UseVisualStyleBackColor = true;
            // 
            // btnBaoCao_DSChuyenKTXM
            // 
            this.btnBaoCao_DSChuyenKTXM.Location = new System.Drawing.Point(442, 32);
            this.btnBaoCao_DSChuyenKTXM.Name = "btnBaoCao_DSChuyenKTXM";
            this.btnBaoCao_DSChuyenKTXM.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_DSChuyenKTXM.TabIndex = 37;
            this.btnBaoCao_DSChuyenKTXM.Text = "Báo Cáo";
            this.btnBaoCao_DSChuyenKTXM.UseVisualStyleBackColor = true;
            this.btnBaoCao_DSChuyenKTXM.Click += new System.EventHandler(this.btnBaoCao_DSChuyenKTXM_Click);
            // 
            // cmbTimTheo_DSChuyenKTXM
            // 
            this.cmbTimTheo_DSChuyenKTXM.FormattingEnabled = true;
            this.cmbTimTheo_DSChuyenKTXM.Items.AddRange(new object[] {
            "",
            "Số Công Văn",
            "Ngày"});
            this.cmbTimTheo_DSChuyenKTXM.Location = new System.Drawing.Point(80, 29);
            this.cmbTimTheo_DSChuyenKTXM.Name = "cmbTimTheo_DSChuyenKTXM";
            this.cmbTimTheo_DSChuyenKTXM.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo_DSChuyenKTXM.TabIndex = 33;
            this.cmbTimTheo_DSChuyenKTXM.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_DSChuyenKTXM_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem_DSChuyenKTXM
            // 
            this.txtNoiDungTimKiem_DSChuyenKTXM.Location = new System.Drawing.Point(259, 29);
            this.txtNoiDungTimKiem_DSChuyenKTXM.Name = "txtNoiDungTimKiem_DSChuyenKTXM";
            this.txtNoiDungTimKiem_DSChuyenKTXM.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem_DSChuyenKTXM.TabIndex = 35;
            this.txtNoiDungTimKiem_DSChuyenKTXM.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Nội Dung:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Tìm Theo:";
            // 
            // panel_KhoangThoiGian_DSChuyenKTXM
            // 
            this.panel_KhoangThoiGian_DSChuyenKTXM.Controls.Add(this.dateTu_DSChuyenKTXM);
            this.panel_KhoangThoiGian_DSChuyenKTXM.Controls.Add(this.dateDen_DSChuyenKTXM);
            this.panel_KhoangThoiGian_DSChuyenKTXM.Controls.Add(this.label7);
            this.panel_KhoangThoiGian_DSChuyenKTXM.Controls.Add(this.label8);
            this.panel_KhoangThoiGian_DSChuyenKTXM.Location = new System.Drawing.Point(259, 17);
            this.panel_KhoangThoiGian_DSChuyenKTXM.Name = "panel_KhoangThoiGian_DSChuyenKTXM";
            this.panel_KhoangThoiGian_DSChuyenKTXM.Size = new System.Drawing.Size(177, 60);
            this.panel_KhoangThoiGian_DSChuyenKTXM.TabIndex = 36;
            this.panel_KhoangThoiGian_DSChuyenKTXM.Visible = false;
            // 
            // dateTu_DSChuyenKTXM
            // 
            this.dateTu_DSChuyenKTXM.CustomFormat = "dd/MM/yyyy";
            this.dateTu_DSChuyenKTXM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_DSChuyenKTXM.Location = new System.Drawing.Point(80, 5);
            this.dateTu_DSChuyenKTXM.Name = "dateTu_DSChuyenKTXM";
            this.dateTu_DSChuyenKTXM.Size = new System.Drawing.Size(90, 22);
            this.dateTu_DSChuyenKTXM.TabIndex = 13;
            // 
            // dateDen_DSChuyenKTXM
            // 
            this.dateDen_DSChuyenKTXM.CustomFormat = "dd/MM/yyyy";
            this.dateDen_DSChuyenKTXM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_DSChuyenKTXM.Location = new System.Drawing.Point(80, 33);
            this.dateDen_DSChuyenKTXM.Name = "dateDen_DSChuyenKTXM";
            this.dateDen_DSChuyenKTXM.Size = new System.Drawing.Size(90, 22);
            this.dateDen_DSChuyenKTXM.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Từ Ngày:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Đến Ngày:";
            // 
            // frmBaoCaoDonTXL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(765, 422);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBaoCaoDonTXL";
            this.Text = "Báo Cáo Đơn Tổ Xử Lý";
            this.Load += new System.EventHandler(this.frmBaoCaoDonTXL_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel_KhoangThoiGian_DSChuyenKTXM.ResumeLayout(false);
            this.panel_KhoangThoiGian_DSChuyenKTXM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBaoCao_LichSuChuyenDon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTu_LichSuChuyenDon;
        private System.Windows.Forms.DateTimePicker dateDen_LichSuChuyenDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBaoCao_DSChuyenKTXM;
        private System.Windows.Forms.ComboBox cmbTimTheo_DSChuyenKTXM;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem_DSChuyenKTXM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_KhoangThoiGian_DSChuyenKTXM;
        private System.Windows.Forms.DateTimePicker dateTu_DSChuyenKTXM;
        private System.Windows.Forms.DateTimePicker dateDen_DSChuyenKTXM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkChuaKT_DSChuyenKTXM;
    }
}