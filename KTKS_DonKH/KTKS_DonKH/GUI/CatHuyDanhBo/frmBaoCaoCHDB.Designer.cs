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
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.radDSYCCHDB = new System.Windows.Forms.RadioButton();
            this.radDSYCCHDBNutBit = new System.Windows.Forms.RadioButton();
            this.radDSCTDBtheocamket = new System.Windows.Forms.RadioButton();
            this.radDSCTCTTon = new System.Windows.Forms.RadioButton();
            this.radDSCTCTDaXuLy = new System.Windows.Forms.RadioButton();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(85, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 22);
            this.dateDen.TabIndex = 14;
            this.dateDen.ValueChanged += new System.EventHandler(this.dateDen_ValueChanged);
            // 
            // radThongKeSoLuong
            // 
            this.radThongKeSoLuong.AutoSize = true;
            this.radThongKeSoLuong.Checked = true;
            this.radThongKeSoLuong.Location = new System.Drawing.Point(11, 12);
            this.radThongKeSoLuong.Name = "radThongKeSoLuong";
            this.radThongKeSoLuong.Size = new System.Drawing.Size(144, 20);
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
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(85, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 22);
            this.dateTu.TabIndex = 13;
            this.dateTu.ValueChanged += new System.EventHandler(this.dateTu_ValueChanged);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(804, 22);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCao.TabIndex = 28;
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
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(606, 2);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(192, 60);
            this.panel_KhoangThoiGian.TabIndex = 27;
            // 
            // radDSYCCHDB
            // 
            this.radDSYCCHDB.AutoSize = true;
            this.radDSYCCHDB.Location = new System.Drawing.Point(11, 36);
            this.radDSYCCHDB.Name = "radDSYCCHDB";
            this.radDSYCCHDB.Size = new System.Drawing.Size(187, 20);
            this.radDSYCCHDB.TabIndex = 30;
            this.radDSYCCHDB.Text = "Danh Sách Yêu Cầu CHDB";
            this.radDSYCCHDB.UseVisualStyleBackColor = true;
            // 
            // radDSYCCHDBNutBit
            // 
            this.radDSYCCHDBNutBit.AutoSize = true;
            this.radDSYCCHDBNutBit.Location = new System.Drawing.Point(165, 12);
            this.radDSYCCHDBNutBit.Name = "radDSYCCHDBNutBit";
            this.radDSYCCHDBNutBit.Size = new System.Drawing.Size(236, 20);
            this.radDSYCCHDBNutBit.TabIndex = 31;
            this.radDSYCCHDBNutBit.Text = "Danh Sách Yêu Cầu CHDB (Nút Bít)";
            this.radDSYCCHDBNutBit.UseVisualStyleBackColor = true;
            // 
            // radDSCTDBtheocamket
            // 
            this.radDSCTDBtheocamket.AutoSize = true;
            this.radDSCTDBtheocamket.Location = new System.Drawing.Point(211, 36);
            this.radDSCTDBtheocamket.Name = "radDSCTDBtheocamket";
            this.radDSCTDBtheocamket.Size = new System.Drawing.Size(211, 20);
            this.radDSCTDBtheocamket.TabIndex = 32;
            this.radDSCTDBtheocamket.Text = "Danh Sách CTDB theo cam kết";
            this.radDSCTDBtheocamket.UseVisualStyleBackColor = true;
            // 
            // radDSCTCTTon
            // 
            this.radDSCTCTTon.AutoSize = true;
            this.radDSCTCTTon.Location = new System.Drawing.Point(421, 12);
            this.radDSCTCTTon.Name = "radDSCTCTTon";
            this.radDSCTCTTon.Size = new System.Drawing.Size(163, 20);
            this.radDSCTCTTon.TabIndex = 33;
            this.radDSCTCTTon.Text = "Danh Sách CT-CH Tồn";
            this.radDSCTCTTon.UseVisualStyleBackColor = true;
            // 
            // radDSCTCTDaXuLy
            // 
            this.radDSCTCTDaXuLy.AutoSize = true;
            this.radDSCTCTDaXuLy.Location = new System.Drawing.Point(432, 36);
            this.radDSCTCTDaXuLy.Name = "radDSCTCTDaXuLy";
            this.radDSCTCTDaXuLy.Size = new System.Drawing.Size(144, 20);
            this.radDSCTCTDaXuLy.TabIndex = 34;
            this.radDSCTCTDaXuLy.Text = "DS CT-CH Đã Xử Lý";
            this.radDSCTCTDaXuLy.UseVisualStyleBackColor = true;
            // 
            // frmBaoCaoCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(907, 93);
            this.Controls.Add(this.radDSCTCTDaXuLy);
            this.Controls.Add(this.radDSCTCTTon);
            this.Controls.Add(this.radDSCTDBtheocamket);
            this.Controls.Add(this.radDSYCCHDBNutBit);
            this.Controls.Add(this.radDSYCCHDB);
            this.Controls.Add(this.radThongKeSoLuong);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmBaoCaoCHDB";
            this.Text = "Các Loại Báo Cáo Cắt Tạm/Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmBaoCaoCHDB_Load);
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
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.RadioButton radDSYCCHDB;
        private System.Windows.Forms.RadioButton radDSYCCHDBNutBit;
        private System.Windows.Forms.RadioButton radDSCTDBtheocamket;
        private System.Windows.Forms.RadioButton radDSCTCTTon;
        private System.Windows.Forms.RadioButton radDSCTCTDaXuLy;

    }
}