namespace KTKS_DonKH.GUI.ToXuLy
{
    partial class frmQLTruyThuTienNuoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.dgvDSTruyThuTienNuoc = new System.Windows.Forms.DataGridView();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTTTN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTruyThuTienNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(586, 39);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem2.TabIndex = 23;
            this.txtNoiDungTimKiem2.Visible = false;
            this.txtNoiDungTimKiem2.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tìm Theo:";
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(586, 39);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(130, 25);
            this.dateTimKiem.TabIndex = 22;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(578, 0);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(189, 64);
            this.panel_KhoangThoiGian.TabIndex = 24;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(83, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 25);
            this.dateTu.TabIndex = 13;
            this.dateTu.ValueChanged += new System.EventHandler(this.dateTu_ValueChanged);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(83, 35);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 25);
            this.dateDen.TabIndex = 14;
            this.dateDen.ValueChanged += new System.EventHandler(this.dateDen_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Số Phiếu",
            "Danh Bộ",
            "Ngày",
            "Khoảng Thời Gian"});
            this.cmbTimTheo.Location = new System.Drawing.Point(390, 12);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(120, 25);
            this.cmbTimTheo.TabIndex = 19;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nội Dung:";
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(586, 11);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem.TabIndex = 21;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // dgvDSTruyThuTienNuoc
            // 
            this.dgvDSTruyThuTienNuoc.AllowUserToAddRows = false;
            this.dgvDSTruyThuTienNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSTruyThuTienNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSTruyThuTienNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTruyThuTienNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDon,
            this.MaTTTN,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.DienThoai});
            this.dgvDSTruyThuTienNuoc.Location = new System.Drawing.Point(0, 66);
            this.dgvDSTruyThuTienNuoc.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSTruyThuTienNuoc.MultiSelect = false;
            this.dgvDSTruyThuTienNuoc.Name = "dgvDSTruyThuTienNuoc";
            this.dgvDSTruyThuTienNuoc.RowHeadersWidth = 60;
            this.dgvDSTruyThuTienNuoc.Size = new System.Drawing.Size(1088, 470);
            this.dgvDSTruyThuTienNuoc.TabIndex = 25;
            this.dgvDSTruyThuTienNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSTruyThuTienNuoc_CellFormatting);
            this.dgvDSTruyThuTienNuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSTruyThuTienNuoc_KeyDown);
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Ma Don";
            this.MaDon.Name = "MaDon";
            // 
            // MaTTTN
            // 
            this.MaTTTN.DataPropertyName = "MaTTTN";
            this.MaTTTN.HeaderText = "Số Phiếu";
            this.MaTTTN.Name = "MaTTTN";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 250;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 250;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "Điện Thoại";
            this.DienThoai.Name = "DienThoai";
            // 
            // frmQLTruyThuTienNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1332, 628);
            this.Controls.Add(this.dgvDSTruyThuTienNuoc);
            this.Controls.Add(this.txtNoiDungTimKiem2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLTruyThuTienNuoc";
            this.Text = "Quản Lý Truy Thu Tiền Nước";
            this.Load += new System.EventHandler(this.frmQLTruyThuTienNuoc_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTruyThuTienNuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.DataGridView dgvDSTruyThuTienNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTTTN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
    }
}