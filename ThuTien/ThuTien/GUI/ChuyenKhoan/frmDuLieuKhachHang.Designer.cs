namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmDuLieuKhachHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDaThu = new System.Windows.Forms.TabPage();
            this.txtTongCong_DT = new System.Windows.Forms.TextBox();
            this.dgvHDDaThu = new System.Windows.Forms.DataGridView();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabChuaThu = new System.Windows.Forms.TabPage();
            this.txtTongCong_CT = new System.Windows.Forms.TextBox();
            this.dgvHDChuaThu = new System.Windows.Forms.DataGridView();
            this.SoHoaDon_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabDaThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDDaThu)).BeginInit();
            this.tabChuaThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDChuaThu)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(251, 12);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(157, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Năm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Danh Bộ:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(458, 12);
            this.txtDanhBo.Multiline = true;
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDanhBo.Size = new System.Drawing.Size(100, 45);
            this.txtDanhBo.TabIndex = 5;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(726, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(645, 12);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(564, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDaThu);
            this.tabControl.Controls.Add(this.tabChuaThu);
            this.tabControl.Location = new System.Drawing.Point(12, 63);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(827, 472);
            this.tabControl.TabIndex = 10;
            // 
            // tabDaThu
            // 
            this.tabDaThu.Controls.Add(this.txtTongCong_DT);
            this.tabDaThu.Controls.Add(this.dgvHDDaThu);
            this.tabDaThu.Location = new System.Drawing.Point(4, 22);
            this.tabDaThu.Name = "tabDaThu";
            this.tabDaThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaThu.Size = new System.Drawing.Size(819, 446);
            this.tabDaThu.TabIndex = 0;
            this.tabDaThu.Text = "Đã Thu";
            this.tabDaThu.UseVisualStyleBackColor = true;
            // 
            // txtTongCong_DT
            // 
            this.txtTongCong_DT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_DT.Location = new System.Drawing.Point(691, 425);
            this.txtTongCong_DT.Name = "txtTongCong_DT";
            this.txtTongCong_DT.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_DT.TabIndex = 1;
            this.txtTongCong_DT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDDaThu
            // 
            this.dgvHDDaThu.AllowUserToAddRows = false;
            this.dgvHDDaThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDDaThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHDDaThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDDaThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayGiaiTrach,
            this.SoHoaDon_DT,
            this.Ky_DT,
            this.Nam_DT,
            this.DanhBo_DT,
            this.TieuThu_DT,
            this.GiaBan_DT,
            this.ThueGTGT_DT,
            this.PhiBVMT_DT,
            this.TongCong_DT});
            this.dgvHDDaThu.Location = new System.Drawing.Point(6, 6);
            this.dgvHDDaThu.Name = "dgvHDDaThu";
            this.dgvHDDaThu.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDDaThu.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHDDaThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDDaThu.Size = new System.Drawing.Size(805, 419);
            this.dgvHDDaThu.TabIndex = 0;
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            this.NgayGiaiTrach.ReadOnly = true;
            this.NgayGiaiTrach.Width = 80;
            // 
            // SoHoaDon_DT
            // 
            this.SoHoaDon_DT.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_DT.HeaderText = "Số HĐ";
            this.SoHoaDon_DT.Name = "SoHoaDon_DT";
            this.SoHoaDon_DT.ReadOnly = true;
            // 
            // Ky_DT
            // 
            this.Ky_DT.DataPropertyName = "Ky";
            this.Ky_DT.HeaderText = "Kỳ";
            this.Ky_DT.Name = "Ky_DT";
            this.Ky_DT.ReadOnly = true;
            this.Ky_DT.Visible = false;
            // 
            // Nam_DT
            // 
            this.Nam_DT.DataPropertyName = "Nam";
            this.Nam_DT.HeaderText = "Năm";
            this.Nam_DT.Name = "Nam_DT";
            this.Nam_DT.ReadOnly = true;
            this.Nam_DT.Visible = false;
            // 
            // DanhBo_DT
            // 
            this.DanhBo_DT.DataPropertyName = "DanhBo";
            this.DanhBo_DT.HeaderText = "Danh Bộ";
            this.DanhBo_DT.Name = "DanhBo_DT";
            this.DanhBo_DT.ReadOnly = true;
            // 
            // TieuThu_DT
            // 
            this.TieuThu_DT.DataPropertyName = "TieuThu";
            this.TieuThu_DT.HeaderText = "Tiêu Thụ";
            this.TieuThu_DT.Name = "TieuThu_DT";
            this.TieuThu_DT.ReadOnly = true;
            this.TieuThu_DT.Width = 80;
            // 
            // GiaBan_DT
            // 
            this.GiaBan_DT.DataPropertyName = "GiaBan";
            this.GiaBan_DT.HeaderText = "Giá Bán";
            this.GiaBan_DT.Name = "GiaBan_DT";
            this.GiaBan_DT.ReadOnly = true;
            this.GiaBan_DT.Width = 80;
            // 
            // ThueGTGT_DT
            // 
            this.ThueGTGT_DT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_DT.HeaderText = "Thuế GTGT";
            this.ThueGTGT_DT.Name = "ThueGTGT_DT";
            this.ThueGTGT_DT.ReadOnly = true;
            // 
            // PhiBVMT_DT
            // 
            this.PhiBVMT_DT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_DT.HeaderText = "Phí BVMT";
            this.PhiBVMT_DT.Name = "PhiBVMT_DT";
            this.PhiBVMT_DT.ReadOnly = true;
            // 
            // TongCong_DT
            // 
            this.TongCong_DT.DataPropertyName = "TongCong";
            this.TongCong_DT.HeaderText = "Tổng Cộng";
            this.TongCong_DT.Name = "TongCong_DT";
            this.TongCong_DT.ReadOnly = true;
            // 
            // tabChuaThu
            // 
            this.tabChuaThu.Controls.Add(this.txtTongCong_CT);
            this.tabChuaThu.Controls.Add(this.dgvHDChuaThu);
            this.tabChuaThu.Location = new System.Drawing.Point(4, 22);
            this.tabChuaThu.Name = "tabChuaThu";
            this.tabChuaThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabChuaThu.Size = new System.Drawing.Size(819, 446);
            this.tabChuaThu.TabIndex = 1;
            this.tabChuaThu.Text = "Chưa Thu";
            this.tabChuaThu.UseVisualStyleBackColor = true;
            // 
            // txtTongCong_CT
            // 
            this.txtTongCong_CT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_CT.Location = new System.Drawing.Point(611, 425);
            this.txtTongCong_CT.Name = "txtTongCong_CT";
            this.txtTongCong_CT.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_CT.TabIndex = 9;
            this.txtTongCong_CT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDChuaThu
            // 
            this.dgvHDChuaThu.AllowUserToAddRows = false;
            this.dgvHDChuaThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDChuaThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHDChuaThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDChuaThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoHoaDon_CT,
            this.Ky_CT,
            this.Nam_CT,
            this.DanhBo_CT,
            this.TieuThu_CT,
            this.GiaBan_CT,
            this.ThueGTGT_CT,
            this.PhiBVMT_CT,
            this.TongCong_CT});
            this.dgvHDChuaThu.Location = new System.Drawing.Point(6, 6);
            this.dgvHDChuaThu.MultiSelect = false;
            this.dgvHDChuaThu.Name = "dgvHDChuaThu";
            this.dgvHDChuaThu.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDChuaThu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHDChuaThu.Size = new System.Drawing.Size(729, 419);
            this.dgvHDChuaThu.TabIndex = 8;
            // 
            // SoHoaDon_CT
            // 
            this.SoHoaDon_CT.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_CT.HeaderText = "Số HĐ";
            this.SoHoaDon_CT.Name = "SoHoaDon_CT";
            this.SoHoaDon_CT.ReadOnly = true;
            // 
            // Ky_CT
            // 
            this.Ky_CT.DataPropertyName = "Ky";
            this.Ky_CT.HeaderText = "Kỳ";
            this.Ky_CT.Name = "Ky_CT";
            this.Ky_CT.ReadOnly = true;
            this.Ky_CT.Visible = false;
            // 
            // Nam_CT
            // 
            this.Nam_CT.DataPropertyName = "Nam";
            this.Nam_CT.HeaderText = "Năm";
            this.Nam_CT.Name = "Nam_CT";
            this.Nam_CT.ReadOnly = true;
            this.Nam_CT.Visible = false;
            // 
            // DanhBo_CT
            // 
            this.DanhBo_CT.DataPropertyName = "DanhBo";
            this.DanhBo_CT.HeaderText = "Danh Bộ";
            this.DanhBo_CT.Name = "DanhBo_CT";
            this.DanhBo_CT.ReadOnly = true;
            // 
            // TieuThu_CT
            // 
            this.TieuThu_CT.DataPropertyName = "TieuThu";
            this.TieuThu_CT.HeaderText = "Tiêu Thụ";
            this.TieuThu_CT.Name = "TieuThu_CT";
            this.TieuThu_CT.ReadOnly = true;
            this.TieuThu_CT.Width = 80;
            // 
            // GiaBan_CT
            // 
            this.GiaBan_CT.DataPropertyName = "GiaBan";
            this.GiaBan_CT.HeaderText = "Giá Bán";
            this.GiaBan_CT.Name = "GiaBan_CT";
            this.GiaBan_CT.ReadOnly = true;
            this.GiaBan_CT.Width = 80;
            // 
            // ThueGTGT_CT
            // 
            this.ThueGTGT_CT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_CT.HeaderText = "Thuế GTGT";
            this.ThueGTGT_CT.Name = "ThueGTGT_CT";
            this.ThueGTGT_CT.ReadOnly = true;
            // 
            // PhiBVMT_CT
            // 
            this.PhiBVMT_CT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_CT.HeaderText = "Phí BVMT";
            this.PhiBVMT_CT.Name = "PhiBVMT_CT";
            this.PhiBVMT_CT.ReadOnly = true;
            // 
            // TongCong_CT
            // 
            this.TongCong_CT.DataPropertyName = "TongCong";
            this.TongCong_CT.HeaderText = "Tổng Cộng";
            this.TongCong_CT.Name = "TongCong_CT";
            this.TongCong_CT.ReadOnly = true;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(307, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // frmDuLieuKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 548);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label2);
            this.Name = "frmDuLieuKhachHang";
            this.Text = "Dữ Liệu Khách Hàng";
            this.Load += new System.EventHandler(this.frmDuLieuKhachHang_Load);
            this.tabControl.ResumeLayout(false);
            this.tabDaThu.ResumeLayout(false);
            this.tabDaThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDDaThu)).EndInit();
            this.tabChuaThu.ResumeLayout(false);
            this.tabChuaThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDChuaThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDaThu;
        private System.Windows.Forms.TextBox txtTongCong_DT;
        private System.Windows.Forms.DataGridView dgvHDDaThu;
        private System.Windows.Forms.TabPage tabChuaThu;
        private System.Windows.Forms.TextBox txtTongCong_CT;
        private System.Windows.Forms.DataGridView dgvHDChuaThu;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CT;
    }
}