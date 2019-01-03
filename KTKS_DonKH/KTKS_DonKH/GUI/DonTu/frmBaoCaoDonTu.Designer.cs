namespace KTKS_DonKH.GUI.DonTu
{
    partial class frmBaoCaoDonTu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBaoCao_LichSuChuyenDon = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian_LichSuChuyenDon = new System.Windows.Forms.Panel();
            this.dateTu_LichSuChuyenDon = new System.Windows.Forms.DateTimePicker();
            this.dateDen_LichSuChuyenDon = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.cmbTimTheo_LichSuChuyenDon = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem_LichSuChuyenDon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel_KhoangThoiGian_LichSuChuyenDon.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel_KhoangThoiGian_DSChuyenKTXM.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNoiDungTimKiem_LichSuChuyenDon);
            this.groupBox1.Controls.Add(this.cmbTimTheo_LichSuChuyenDon);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBaoCao_LichSuChuyenDon);
            this.groupBox1.Controls.Add(this.panel_KhoangThoiGian_LichSuChuyenDon);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 87);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lịch Sử Chuyển Đơn";
            // 
            // btnBaoCao_LichSuChuyenDon
            // 
            this.btnBaoCao_LichSuChuyenDon.Location = new System.Drawing.Point(442, 40);
            this.btnBaoCao_LichSuChuyenDon.Name = "btnBaoCao_LichSuChuyenDon";
            this.btnBaoCao_LichSuChuyenDon.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao_LichSuChuyenDon.TabIndex = 25;
            this.btnBaoCao_LichSuChuyenDon.Text = "Báo Cáo";
            this.btnBaoCao_LichSuChuyenDon.UseVisualStyleBackColor = true;
            this.btnBaoCao_LichSuChuyenDon.Click += new System.EventHandler(this.btnBaoCao_LichSuChuyenDon_Click);
            // 
            // panel_KhoangThoiGian_LichSuChuyenDon
            // 
            this.panel_KhoangThoiGian_LichSuChuyenDon.Controls.Add(this.dateTu_LichSuChuyenDon);
            this.panel_KhoangThoiGian_LichSuChuyenDon.Controls.Add(this.dateDen_LichSuChuyenDon);
            this.panel_KhoangThoiGian_LichSuChuyenDon.Controls.Add(this.label1);
            this.panel_KhoangThoiGian_LichSuChuyenDon.Controls.Add(this.label2);
            this.panel_KhoangThoiGian_LichSuChuyenDon.Location = new System.Drawing.Point(259, 21);
            this.panel_KhoangThoiGian_LichSuChuyenDon.Name = "panel_KhoangThoiGian_LichSuChuyenDon";
            this.panel_KhoangThoiGian_LichSuChuyenDon.Size = new System.Drawing.Size(177, 60);
            this.panel_KhoangThoiGian_LichSuChuyenDon.TabIndex = 24;
            this.panel_KhoangThoiGian_LichSuChuyenDon.Visible = false;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkChuaKT_DSChuyenKTXM);
            this.groupBox3.Controls.Add(this.btnBaoCao_DSChuyenKTXM);
            this.groupBox3.Controls.Add(this.cmbTimTheo_DSChuyenKTXM);
            this.groupBox3.Controls.Add(this.txtNoiDungTimKiem_DSChuyenKTXM);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.panel_KhoangThoiGian_DSChuyenKTXM);
            this.groupBox3.Location = new System.Drawing.Point(12, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 85);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Chuyển KTXM";
            // 
            // chkChuaKT_DSChuyenKTXM
            // 
            this.chkChuaKT_DSChuyenKTXM.AutoSize = true;
            this.chkChuaKT_DSChuyenKTXM.Location = new System.Drawing.Point(80, 59);
            this.chkChuaKT_DSChuyenKTXM.Name = "chkChuaKT_DSChuyenKTXM";
            this.chkChuaKT_DSChuyenKTXM.Size = new System.Drawing.Size(78, 20);
            this.chkChuaKT_DSChuyenKTXM.TabIndex = 39;
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
            // cmbTimTheo_LichSuChuyenDon
            // 
            this.cmbTimTheo_LichSuChuyenDon.FormattingEnabled = true;
            this.cmbTimTheo_LichSuChuyenDon.Items.AddRange(new object[] {
            "",
            "Số Công Văn",
            "Ngày"});
            this.cmbTimTheo_LichSuChuyenDon.Location = new System.Drawing.Point(80, 33);
            this.cmbTimTheo_LichSuChuyenDon.Name = "cmbTimTheo_LichSuChuyenDon";
            this.cmbTimTheo_LichSuChuyenDon.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo_LichSuChuyenDon.TabIndex = 37;
            this.cmbTimTheo_LichSuChuyenDon.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_LichSuChuyenDon_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem_LichSuChuyenDon
            // 
            this.txtNoiDungTimKiem_LichSuChuyenDon.Location = new System.Drawing.Point(259, 33);
            this.txtNoiDungTimKiem_LichSuChuyenDon.Name = "txtNoiDungTimKiem_LichSuChuyenDon";
            this.txtNoiDungTimKiem_LichSuChuyenDon.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem_LichSuChuyenDon.TabIndex = 39;
            this.txtNoiDungTimKiem_LichSuChuyenDon.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Nội Dung:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "Tìm Theo:";
            // 
            // frmBaoCaoDonTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(551, 407);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBaoCaoDonTu";
            this.Text = "Báo Cáo Đơn Từ";
            this.Load += new System.EventHandler(this.frmBaoCaoDonTu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_KhoangThoiGian_LichSuChuyenDon.ResumeLayout(false);
            this.panel_KhoangThoiGian_LichSuChuyenDon.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel_KhoangThoiGian_DSChuyenKTXM.ResumeLayout(false);
            this.panel_KhoangThoiGian_DSChuyenKTXM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBaoCao_LichSuChuyenDon;
        private System.Windows.Forms.Panel panel_KhoangThoiGian_LichSuChuyenDon;
        private System.Windows.Forms.DateTimePicker dateTu_LichSuChuyenDon;
        private System.Windows.Forms.DateTimePicker dateDen_LichSuChuyenDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkChuaKT_DSChuyenKTXM;
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
        private System.Windows.Forms.ComboBox cmbTimTheo_LichSuChuyenDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem_LichSuChuyenDon;
    }
}