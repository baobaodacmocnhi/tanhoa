namespace KTKS_DonKH.GUI.ToKhachHang
{
    partial class frmBaoCaoDonTKH
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
            this.groupBox3.SuspendLayout();
            this.panel_KhoangThoiGian_DSChuyenKTXM.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 85);
            this.groupBox3.TabIndex = 27;
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
            // frmBaoCaoDonTKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(665, 392);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmBaoCaoDonTKH";
            this.Text = "Các Loại Báo Cáo Đơn";
            this.Load += new System.EventHandler(this.frmBaoCaoDonTKH_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel_KhoangThoiGian_DSChuyenKTXM.ResumeLayout(false);
            this.panel_KhoangThoiGian_DSChuyenKTXM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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

    }
}