namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    partial class frmBaoCaoCHDB
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
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.radThongKeSoLuong = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.radDSYCCHDB = new System.Windows.Forms.RadioButton();
            this.radDSYCCHDBNutBit = new System.Windows.Forms.RadioButton();
            this.radDSCTDBtheocamket = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
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
            // radThongKeSoLuong
            // 
            this.radThongKeSoLuong.AutoSize = true;
            this.radThongKeSoLuong.Checked = true;
            this.radThongKeSoLuong.Location = new System.Drawing.Point(71, 7);
            this.radThongKeSoLuong.Name = "radThongKeSoLuong";
            this.radThongKeSoLuong.Size = new System.Drawing.Size(147, 21);
            this.radThongKeSoLuong.TabIndex = 29;
            this.radThongKeSoLuong.TabStop = true;
            this.radThongKeSoLuong.Text = "Thống Kê Số Lượng";
            this.radThongKeSoLuong.UseVisualStyleBackColor = true;
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
            // btnBaoCao
            // 
            this.btnBaoCao.Image = global::KTKS_DonKH.Properties.Resources.find_24x24;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(733, 2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(94, 35);
            this.btnBaoCao.TabIndex = 28;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystalReportViewer1);
            this.panel1.Location = new System.Drawing.Point(13, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1265, 490);
            this.panel1.TabIndex = 26;
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(535, 2);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(192, 64);
            this.panel_KhoangThoiGian.TabIndex = 27;
            // 
            // radDSYCCHDB
            // 
            this.radDSYCCHDB.AutoSize = true;
            this.radDSYCCHDB.Location = new System.Drawing.Point(71, 34);
            this.radDSYCCHDB.Name = "radDSYCCHDB";
            this.radDSYCCHDB.Size = new System.Drawing.Size(193, 21);
            this.radDSYCCHDB.TabIndex = 30;
            this.radDSYCCHDB.Text = "Danh Sách Yêu Cầu CHDB";
            this.radDSYCCHDB.UseVisualStyleBackColor = true;
            // 
            // radDSYCCHDBNutBit
            // 
            this.radDSYCCHDBNutBit.AutoSize = true;
            this.radDSYCCHDBNutBit.Location = new System.Drawing.Point(224, 7);
            this.radDSYCCHDBNutBit.Name = "radDSYCCHDBNutBit";
            this.radDSYCCHDBNutBit.Size = new System.Drawing.Size(250, 21);
            this.radDSYCCHDBNutBit.TabIndex = 31;
            this.radDSYCCHDBNutBit.Text = "Danh Sách Yêu Cầu CHDB (Nút Bít)";
            this.radDSYCCHDBNutBit.UseVisualStyleBackColor = true;
            // 
            // radDSCTDBtheocamket
            // 
            this.radDSCTDBtheocamket.AutoSize = true;
            this.radDSCTDBtheocamket.Location = new System.Drawing.Point(270, 34);
            this.radDSCTDBtheocamket.Name = "radDSCTDBtheocamket";
            this.radDSCTDBtheocamket.Size = new System.Drawing.Size(215, 21);
            this.radDSCTDBtheocamket.TabIndex = 32;
            this.radDSCTDBtheocamket.Text = "Danh Sách CTDB theo cam kết";
            this.radDSCTDBtheocamket.UseVisualStyleBackColor = true;
            // 
            // frmBaoCaoCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1297, 598);
            this.Controls.Add(this.radDSCTDBtheocamket);
            this.Controls.Add(this.radDSYCCHDBNutBit);
            this.Controls.Add(this.radDSYCCHDB);
            this.Controls.Add(this.radThongKeSoLuong);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBaoCaoCHDB";
            this.Text = "Các Loại Báo Cáo Cắt Tạm/Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmBaoCaoCHDB_Load);
            this.panel1.ResumeLayout(false);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.RadioButton radThongKeSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.RadioButton radDSYCCHDB;
        private System.Windows.Forms.RadioButton radDSYCCHDBNutBit;
        private System.Windows.Forms.RadioButton radDSCTDBtheocamket;

    }
}