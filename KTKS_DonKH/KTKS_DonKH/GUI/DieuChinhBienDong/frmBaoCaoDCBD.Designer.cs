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
            this.radThongKeDMCap = new System.Windows.Forms.RadioButton();
            this.radThongKeDC = new System.Windows.Forms.RadioButton();
            this.radDSChuyenDocSo = new System.Windows.Forms.RadioButton();
            this.radDSChuyenDocSo_LocUser = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystalReportViewer1);
            this.panel1.Location = new System.Drawing.Point(13, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1265, 490);
            this.panel1.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1259, 484);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(737, 2);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(192, 64);
            this.panel_KhoangThoiGian.TabIndex = 18;
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
            this.btnBaoCao.Location = new System.Drawing.Point(935, 2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(94, 35);
            this.btnBaoCao.TabIndex = 19;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // radThongKeDMCap
            // 
            this.radThongKeDMCap.AutoSize = true;
            this.radThongKeDMCap.Checked = true;
            this.radThongKeDMCap.Location = new System.Drawing.Point(71, 7);
            this.radThongKeDMCap.Name = "radThongKeDMCap";
            this.radThongKeDMCap.Size = new System.Drawing.Size(256, 21);
            this.radThongKeDMCap.TabIndex = 20;
            this.radThongKeDMCap.TabStop = true;
            this.radThongKeDMCap.Text = "Thống Kê Định Mức Cấp (có thời hạn)";
            this.radThongKeDMCap.UseVisualStyleBackColor = true;
            // 
            // radThongKeDC
            // 
            this.radThongKeDC.AutoSize = true;
            this.radThongKeDC.Location = new System.Drawing.Point(71, 34);
            this.radThongKeDC.Name = "radThongKeDC";
            this.radThongKeDC.Size = new System.Drawing.Size(155, 21);
            this.radThongKeDC.TabIndex = 21;
            this.radThongKeDC.Text = "Thống Kê Điều Chỉnh";
            this.radThongKeDC.UseVisualStyleBackColor = true;
            // 
            // radDSChuyenDocSo
            // 
            this.radDSChuyenDocSo.AutoSize = true;
            this.radDSChuyenDocSo.Location = new System.Drawing.Point(333, 7);
            this.radDSChuyenDocSo.Name = "radDSChuyenDocSo";
            this.radDSChuyenDocSo.Size = new System.Drawing.Size(188, 21);
            this.radDSChuyenDocSo.TabIndex = 22;
            this.radDSChuyenDocSo.Text = "Danh Sách Chuyển Đọc Số";
            this.radDSChuyenDocSo.UseVisualStyleBackColor = true;
            // 
            // radDSChuyenDocSo_LocUser
            // 
            this.radDSChuyenDocSo_LocUser.AutoSize = true;
            this.radDSChuyenDocSo_LocUser.Location = new System.Drawing.Point(333, 34);
            this.radDSChuyenDocSo_LocUser.Name = "radDSChuyenDocSo_LocUser";
            this.radDSChuyenDocSo_LocUser.Size = new System.Drawing.Size(231, 21);
            this.radDSChuyenDocSo_LocUser.TabIndex = 23;
            this.radDSChuyenDocSo_LocUser.Text = "Danh Sách Chuyển Đọc Số (User)";
            this.radDSChuyenDocSo_LocUser.UseVisualStyleBackColor = true;
            // 
            // frmBaoCaoDCBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1297, 598);
            this.Controls.Add(this.radDSChuyenDocSo_LocUser);
            this.Controls.Add(this.radDSChuyenDocSo);
            this.Controls.Add(this.radThongKeDC);
            this.Controls.Add(this.radThongKeDMCap);
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
        private System.Windows.Forms.RadioButton radThongKeDMCap;
        private System.Windows.Forms.RadioButton radThongKeDC;
        private System.Windows.Forms.RadioButton radDSChuyenDocSo;
        private System.Windows.Forms.RadioButton radDSChuyenDocSo_LocUser;
    }
}