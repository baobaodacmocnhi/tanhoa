namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    partial class frmDSKTXM
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
            this.radDaDuyet = new System.Windows.Forms.RadioButton();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvDSKTXM = new System.Windows.Forms.DataGridView();
            this.MaKTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayXuLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChuyen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LyDoChuyenDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNoiChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDoChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radChuaDuyet = new System.Windows.Forms.RadioButton();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKTXM)).BeginInit();
            this.SuspendLayout();
            // 
            // radDaDuyet
            // 
            this.radDaDuyet.AutoSize = true;
            this.radDaDuyet.Location = new System.Drawing.Point(12, 12);
            this.radDaDuyet.Name = "radDaDuyet";
            this.radDaDuyet.Size = new System.Drawing.Size(84, 21);
            this.radDaDuyet.TabIndex = 0;
            this.radDaDuyet.Text = "Đã Duyệt";
            this.radDaDuyet.UseVisualStyleBackColor = true;
            this.radDaDuyet.CheckedChanged += new System.EventHandler(this.radDaDuyet_CheckedChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(1180, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvDSKTXM
            // 
            this.dgvDSKTXM.AllowUserToAddRows = false;
            this.dgvDSKTXM.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKTXM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSKTXM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKTXM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKTXM,
            this.NgayXuLy,
            this.KetQua,
            this.MaChuyen,
            this.LyDoChuyenDi,
            this.MaDon,
            this.TenLD,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.MaNoiChuyenDen,
            this.NoiChuyenDen,
            this.LyDoChuyenDen});
            this.dgvDSKTXM.Location = new System.Drawing.Point(0, 67);
            this.dgvDSKTXM.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSKTXM.MultiSelect = false;
            this.dgvDSKTXM.Name = "dgvDSKTXM";
            this.dgvDSKTXM.Size = new System.Drawing.Size(2500, 470);
            this.dgvDSKTXM.TabIndex = 7;
            this.dgvDSKTXM.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDSKTXM_CellBeginEdit);
            this.dgvDSKTXM.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSKTXM_CellEndEdit);
            this.dgvDSKTXM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSKTXM_CellFormatting);
            this.dgvDSKTXM.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSDonKH_RowPostPaint);
            this.dgvDSKTXM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSKTXM_KeyDown);
            // 
            // MaKTXM
            // 
            this.MaKTXM.DataPropertyName = "MaKTXM";
            this.MaKTXM.HeaderText = "Mã KTXM";
            this.MaKTXM.Name = "MaKTXM";
            this.MaKTXM.Visible = false;
            // 
            // NgayXuLy
            // 
            this.NgayXuLy.DataPropertyName = "NgayXuLy";
            this.NgayXuLy.HeaderText = "Ngày Xử Lý";
            this.NgayXuLy.Name = "NgayXuLy";
            this.NgayXuLy.ReadOnly = true;
            this.NgayXuLy.Width = 110;
            // 
            // KetQua
            // 
            this.KetQua.DataPropertyName = "KetQua";
            this.KetQua.HeaderText = "Kết Quả";
            this.KetQua.Name = "KetQua";
            this.KetQua.Width = 200;
            // 
            // MaChuyen
            // 
            this.MaChuyen.DataPropertyName = "MaChuyen";
            this.MaChuyen.HeaderText = "Chuyển Đi";
            this.MaChuyen.Name = "MaChuyen";
            this.MaChuyen.Width = 150;
            // 
            // LyDoChuyenDi
            // 
            this.LyDoChuyenDi.DataPropertyName = "LyDoChuyenDi";
            this.LyDoChuyenDi.HeaderText = "Ly Do Chuyển Đi";
            this.LyDoChuyenDi.Name = "LyDoChuyenDi";
            this.LyDoChuyenDi.Width = 250;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            this.MaDon.Width = 90;
            // 
            // TenLD
            // 
            this.TenLD.DataPropertyName = "TenLD";
            this.TenLD.HeaderText = "Tên Loại Đơn";
            this.TenLD.Name = "TenLD";
            this.TenLD.ReadOnly = true;
            this.TenLD.Width = 130;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Nhận";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 110;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            this.DanhBo.Width = 90;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 250;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 250;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 250;
            // 
            // MaNoiChuyenDen
            // 
            this.MaNoiChuyenDen.DataPropertyName = "MaNoiChuyenDen";
            this.MaNoiChuyenDen.HeaderText = "Mã Nơi Chuyển Đến";
            this.MaNoiChuyenDen.Name = "MaNoiChuyenDen";
            this.MaNoiChuyenDen.Visible = false;
            // 
            // NoiChuyenDen
            // 
            this.NoiChuyenDen.DataPropertyName = "NoiChuyenDen";
            this.NoiChuyenDen.HeaderText = "Nơi Chuyển Đến";
            this.NoiChuyenDen.Name = "NoiChuyenDen";
            this.NoiChuyenDen.ReadOnly = true;
            this.NoiChuyenDen.Width = 200;
            // 
            // LyDoChuyenDen
            // 
            this.LyDoChuyenDen.DataPropertyName = "LyDoChuyenDen";
            this.LyDoChuyenDen.HeaderText = "Ly Do Chuyển Đến";
            this.LyDoChuyenDen.Name = "LyDoChuyenDen";
            this.LyDoChuyenDen.ReadOnly = true;
            this.LyDoChuyenDen.Width = 250;
            // 
            // radChuaDuyet
            // 
            this.radChuaDuyet.AutoSize = true;
            this.radChuaDuyet.Location = new System.Drawing.Point(12, 39);
            this.radChuaDuyet.Name = "radChuaDuyet";
            this.radChuaDuyet.Size = new System.Drawing.Size(98, 21);
            this.radChuaDuyet.TabIndex = 1;
            this.radChuaDuyet.Text = "Chưa Duyệt";
            this.radChuaDuyet.UseVisualStyleBackColor = true;
            this.radChuaDuyet.CheckedChanged += new System.EventHandler(this.radChuaDuyet_CheckedChanged);
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(951, 35);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(130, 25);
            this.dateTimKiem.TabIndex = 6;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(676, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm Theo:";
            this.label2.Visible = false;
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Ngày Lập"});
            this.cmbTimTheo.Location = new System.Drawing.Point(750, 12);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(120, 25);
            this.cmbTimTheo.TabIndex = 3;
            this.cmbTimTheo.Visible = false;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(951, 12);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem.TabIndex = 5;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(877, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nội Dung:";
            this.label1.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(388, 7);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 25);
            this.dateTu.TabIndex = 9;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(388, 38);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 25);
            this.dateDen.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Đến Ngày:";
            // 
            // frmDSKTXM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 579);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radDaDuyet);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvDSKTXM);
            this.Controls.Add(this.radChuaDuyet);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDSKTXM";
            this.Text = "Danh Sách Kiểm Tra Xác Minh";
            this.Load += new System.EventHandler(this.frmKTXM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKTXM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radDaDuyet;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.RadioButton radChuaDuyet;
        private System.Windows.Forms.DataGridView dgvDSKTXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKTXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetQua;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyenDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNoiChuyenDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyenDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyenDen;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}