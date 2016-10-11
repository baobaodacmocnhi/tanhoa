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
            this.dgvDSCTKTXM = new System.Windows.Forms.DataGridView();
            this.MaCTKTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToXuLy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDungKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkLoaiDon = new System.Windows.Forms.CheckBox();
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            this.btnInThongKe = new System.Windows.Forms.Button();
            this.radToKH = new System.Windows.Forms.RadioButton();
            this.radToXuLy = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTKTXM)).BeginInit();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSCTKTXM
            // 
            this.dgvDSCTKTXM.AllowUserToAddRows = false;
            this.dgvDSCTKTXM.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSCTKTXM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSCTKTXM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSCTKTXM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTKTXM,
            this.ToXuLy,
            this.MaDon,
            this.TenLD,
            this.NgayKTXM,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDungKiemTra,
            this.CreateBy,
            this.MaU});
            this.dgvDSCTKTXM.Location = new System.Drawing.Point(0, 69);
            this.dgvDSCTKTXM.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvDSCTKTXM.MultiSelect = false;
            this.dgvDSCTKTXM.Name = "dgvDSCTKTXM";
            this.dgvDSCTKTXM.RowHeadersWidth = 60;
            this.dgvDSCTKTXM.Size = new System.Drawing.Size(1362, 443);
            this.dgvDSCTKTXM.TabIndex = 9;
            this.dgvDSCTKTXM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSKTXM_CellFormatting);
            this.dgvDSCTKTXM.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSDonKH_RowPostPaint);
            this.dgvDSCTKTXM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSKTXM_KeyDown);
            // 
            // MaCTKTXM
            // 
            this.MaCTKTXM.DataPropertyName = "MaCTKTXM";
            this.MaCTKTXM.HeaderText = "MaCTKTXM";
            this.MaCTKTXM.Name = "MaCTKTXM";
            this.MaCTKTXM.Visible = false;
            // 
            // ToXuLy
            // 
            this.ToXuLy.DataPropertyName = "ToXuLy";
            this.ToXuLy.HeaderText = "TXL";
            this.ToXuLy.Name = "ToXuLy";
            this.ToXuLy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToXuLy.Width = 50;
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
            this.TenLD.Width = 130;
            // 
            // NgayKTXM
            // 
            this.NgayKTXM.DataPropertyName = "NgayKTXM";
            this.NgayKTXM.HeaderText = "Ngày KTXM";
            this.NgayKTXM.Name = "NgayKTXM";
            this.NgayKTXM.ReadOnly = true;
            this.NgayKTXM.Width = 110;
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
            // NoiDungKiemTra
            // 
            this.NoiDungKiemTra.DataPropertyName = "NoiDungKiemTra";
            this.NoiDungKiemTra.HeaderText = "Nội Dung";
            this.NoiDungKiemTra.Name = "NoiDungKiemTra";
            this.NoiDungKiemTra.ReadOnly = true;
            this.NoiDungKiemTra.Width = 350;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Thực Hiện";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.Width = 150;
            // 
            // MaU
            // 
            this.MaU.DataPropertyName = "MaU";
            this.MaU.HeaderText = "MaU";
            this.MaU.Name = "MaU";
            this.MaU.Visible = false;
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(504, 36);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(130, 22);
            this.dateTimKiem.TabIndex = 6;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm Theo:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Số Công Văn",
            "Ngày",
            "Khoảng Thời Gian"});
            this.cmbTimTheo.Location = new System.Drawing.Point(335, 15);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(121, 24);
            this.cmbTimTheo.TabIndex = 3;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(535, 15);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 22);
            this.txtNoiDungTimKiem.TabIndex = 5;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nội Dung:";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(723, 3);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(114, 25);
            this.btnIn.TabIndex = 10;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(525, 2);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(192, 59);
            this.panel_KhoangThoiGian.TabIndex = 11;
            this.panel_KhoangThoiGian.Visible = false;
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
            // chkLoaiDon
            // 
            this.chkLoaiDon.AutoSize = true;
            this.chkLoaiDon.Location = new System.Drawing.Point(723, 38);
            this.chkLoaiDon.Name = "chkLoaiDon";
            this.chkLoaiDon.Size = new System.Drawing.Size(115, 20);
            this.chkLoaiDon.TabIndex = 12;
            this.chkLoaiDon.Text = "Theo Loại Đơn";
            this.chkLoaiDon.UseVisualStyleBackColor = true;
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(535, 39);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(130, 22);
            this.txtNoiDungTimKiem2.TabIndex = 13;
            this.txtNoiDungTimKiem2.Visible = false;
            this.txtNoiDungTimKiem2.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem2_TextChanged);
            // 
            // btnInThongKe
            // 
            this.btnInThongKe.Location = new System.Drawing.Point(853, 3);
            this.btnInThongKe.Name = "btnInThongKe";
            this.btnInThongKe.Size = new System.Drawing.Size(114, 25);
            this.btnInThongKe.TabIndex = 15;
            this.btnInThongKe.Text = "In Thống Kê";
            this.btnInThongKe.UseVisualStyleBackColor = true;
            this.btnInThongKe.Click += new System.EventHandler(this.btnInThongKe_Click);
            // 
            // radToKH
            // 
            this.radToKH.AutoSize = true;
            this.radToKH.Location = new System.Drawing.Point(991, 5);
            this.radToKH.Name = "radToKH";
            this.radToKH.Size = new System.Drawing.Size(64, 20);
            this.radToKH.TabIndex = 16;
            this.radToKH.TabStop = true;
            this.radToKH.Text = "Tổ KH";
            this.radToKH.UseVisualStyleBackColor = true;
            // 
            // radToXuLy
            // 
            this.radToXuLy.AutoSize = true;
            this.radToXuLy.Location = new System.Drawing.Point(991, 32);
            this.radToXuLy.Name = "radToXuLy";
            this.radToXuLy.Size = new System.Drawing.Size(78, 20);
            this.radToXuLy.TabIndex = 17;
            this.radToXuLy.TabStop = true;
            this.radToXuLy.Text = "Tổ Xử Lý";
            this.radToXuLy.UseVisualStyleBackColor = true;
            // 
            // frmDSKTXM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1276, 561);
            this.Controls.Add(this.radToXuLy);
            this.Controls.Add(this.radToKH);
            this.Controls.Add(this.btnInThongKe);
            this.Controls.Add(this.chkLoaiDon);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvDSCTKTXM);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDungTimKiem2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDSKTXM";
            this.Text = "Danh Sách Kiểm Tra Xác Minh";
            this.Load += new System.EventHandler(this.frmKTXM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTKTXM)).EndInit();
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSCTKTXM;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkLoaiDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTKTXM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKTXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDungKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaU;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.Button btnInThongKe;
        private System.Windows.Forms.RadioButton radToKH;
        private System.Windows.Forms.RadioButton radToXuLy;
    }
}