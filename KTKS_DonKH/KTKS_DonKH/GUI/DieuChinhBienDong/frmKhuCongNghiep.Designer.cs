namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmKhuCongNghiep
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.dgvDanhBo = new System.Windows.Forms.DataGridView();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtDinhMuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSoTienConLai_KhauTru = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvKhauTruLichSu = new System.Windows.Forms.DataGridView();
            this.DanhBo_KTLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_KTLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien_KTLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate_KTLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDanhBo_KhauTru = new System.Windows.Forms.TextBox();
            this.btnSua_KhauTru = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoTien_KhauTru = new System.Windows.Forms.TextBox();
            this.dgvKhauTru = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThem_KhauTru = new System.Windows.Forms.Button();
            this.btnXoa_KhauTru = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_KhauTru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien_KhauTru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate_KhauTru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TatToan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhauTruLichSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhauTru)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(75, 21);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 1;
            // 
            // dgvDanhBo
            // 
            this.dgvDanhBo.AllowUserToAddRows = false;
            this.dgvDanhBo.AllowUserToDeleteRows = false;
            this.dgvDanhBo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhBo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo,
            this.DinhMuc,
            this.CreateDate});
            this.dgvDanhBo.Location = new System.Drawing.Point(10, 77);
            this.dgvDanhBo.Name = "dgvDanhBo";
            this.dgvDanhBo.Size = new System.Drawing.Size(364, 150);
            this.dgvDanhBo.TabIndex = 2;
            this.dgvDanhBo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBo_CellClick);
            this.dgvDanhBo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanhBo_CellFormatting);
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // DinhMuc
            // 
            this.DinhMuc.DataPropertyName = "DinhMuc";
            this.DinhMuc.HeaderText = "Định Mức";
            this.DinhMuc.Name = "DinhMuc";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(181, 20);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(343, 20);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(75, 49);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(100, 22);
            this.txtDinhMuc.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Định Mức";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(262, 20);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDinhMuc);
            this.groupBox1.Controls.Add(this.dgvDanhBo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Location = new System.Drawing.Point(506, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 236);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khu Công Nghiệp";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSoTienConLai_KhauTru);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtDanhBo_KhauTru);
            this.groupBox2.Controls.Add(this.btnSua_KhauTru);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtSoTien_KhauTru);
            this.groupBox2.Controls.Add(this.dgvKhauTru);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnThem_KhauTru);
            this.groupBox2.Controls.Add(this.btnXoa_KhauTru);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 582);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khấu Trừ";
            // 
            // txtSoTienConLai_KhauTru
            // 
            this.txtSoTienConLai_KhauTru.Location = new System.Drawing.Point(250, 551);
            this.txtSoTienConLai_KhauTru.Name = "txtSoTienConLai_KhauTru";
            this.txtSoTienConLai_KhauTru.Size = new System.Drawing.Size(100, 22);
            this.txtSoTienConLai_KhauTru.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 554);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Số Tiền Còn Lại";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvKhauTruLichSu);
            this.groupBox3.Location = new System.Drawing.Point(6, 354);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 200);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lịch Sử Khấu Trừ";
            // 
            // dgvKhauTruLichSu
            // 
            this.dgvKhauTruLichSu.AllowUserToAddRows = false;
            this.dgvKhauTruLichSu.AllowUserToDeleteRows = false;
            this.dgvKhauTruLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhauTruLichSu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo_KTLS,
            this.Ky_KTLS,
            this.SoTien_KTLS,
            this.CreateDate_KTLS});
            this.dgvKhauTruLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhauTruLichSu.Location = new System.Drawing.Point(3, 18);
            this.dgvKhauTruLichSu.Name = "dgvKhauTruLichSu";
            this.dgvKhauTruLichSu.Size = new System.Drawing.Size(462, 179);
            this.dgvKhauTruLichSu.TabIndex = 11;
            this.dgvKhauTruLichSu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKhauTruLichSu_CellFormatting);
            this.dgvKhauTruLichSu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvKhauTruLichSu_RowPostPaint);
            // 
            // DanhBo_KTLS
            // 
            this.DanhBo_KTLS.DataPropertyName = "DanhBo";
            this.DanhBo_KTLS.HeaderText = "Danh Bộ";
            this.DanhBo_KTLS.Name = "DanhBo_KTLS";
            // 
            // Ky_KTLS
            // 
            this.Ky_KTLS.DataPropertyName = "Ky";
            this.Ky_KTLS.HeaderText = "Kỳ HĐ";
            this.Ky_KTLS.Name = "Ky_KTLS";
            // 
            // SoTien_KTLS
            // 
            this.SoTien_KTLS.DataPropertyName = "SoTien";
            this.SoTien_KTLS.HeaderText = "Số Tiền";
            this.SoTien_KTLS.Name = "SoTien_KTLS";
            // 
            // CreateDate_KTLS
            // 
            this.CreateDate_KTLS.DataPropertyName = "CreateDate";
            this.CreateDate_KTLS.HeaderText = "Ngày Lập";
            this.CreateDate_KTLS.Name = "CreateDate_KTLS";
            // 
            // txtDanhBo_KhauTru
            // 
            this.txtDanhBo_KhauTru.Location = new System.Drawing.Point(75, 21);
            this.txtDanhBo_KhauTru.Name = "txtDanhBo_KhauTru";
            this.txtDanhBo_KhauTru.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo_KhauTru.TabIndex = 9;
            // 
            // btnSua_KhauTru
            // 
            this.btnSua_KhauTru.Location = new System.Drawing.Point(262, 20);
            this.btnSua_KhauTru.Name = "btnSua_KhauTru";
            this.btnSua_KhauTru.Size = new System.Drawing.Size(75, 23);
            this.btnSua_KhauTru.TabIndex = 15;
            this.btnSua_KhauTru.Text = "Sửa";
            this.btnSua_KhauTru.UseVisualStyleBackColor = true;
            this.btnSua_KhauTru.Visible = false;
            this.btnSua_KhauTru.Click += new System.EventHandler(this.btnSua_KhauTru_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Danh Bộ";
            // 
            // txtSoTien_KhauTru
            // 
            this.txtSoTien_KhauTru.Location = new System.Drawing.Point(75, 49);
            this.txtSoTien_KhauTru.Name = "txtSoTien_KhauTru";
            this.txtSoTien_KhauTru.Size = new System.Drawing.Size(100, 22);
            this.txtSoTien_KhauTru.TabIndex = 14;
            // 
            // dgvKhauTru
            // 
            this.dgvKhauTru.AllowUserToAddRows = false;
            this.dgvKhauTru.AllowUserToDeleteRows = false;
            this.dgvKhauTru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhauTru.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DanhBo_KhauTru,
            this.SoTien_KhauTru,
            this.CreateDate_KhauTru,
            this.TatToan});
            this.dgvKhauTru.Location = new System.Drawing.Point(10, 77);
            this.dgvKhauTru.Name = "dgvKhauTru";
            this.dgvKhauTru.Size = new System.Drawing.Size(435, 271);
            this.dgvKhauTru.TabIndex = 10;
            this.dgvKhauTru.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhauTru_CellClick);
            this.dgvKhauTru.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhauTru_CellEndEdit);
            this.dgvKhauTru.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKhauTru_CellFormatting);
            this.dgvKhauTru.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvKhauTru_RowPostPaint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Số Tiền";
            // 
            // btnThem_KhauTru
            // 
            this.btnThem_KhauTru.Location = new System.Drawing.Point(181, 20);
            this.btnThem_KhauTru.Name = "btnThem_KhauTru";
            this.btnThem_KhauTru.Size = new System.Drawing.Size(75, 23);
            this.btnThem_KhauTru.TabIndex = 11;
            this.btnThem_KhauTru.Text = "Thêm";
            this.btnThem_KhauTru.UseVisualStyleBackColor = true;
            this.btnThem_KhauTru.Click += new System.EventHandler(this.btnThem_KhauTru_Click);
            // 
            // btnXoa_KhauTru
            // 
            this.btnXoa_KhauTru.Location = new System.Drawing.Point(343, 20);
            this.btnXoa_KhauTru.Name = "btnXoa_KhauTru";
            this.btnXoa_KhauTru.Size = new System.Drawing.Size(75, 23);
            this.btnXoa_KhauTru.TabIndex = 12;
            this.btnXoa_KhauTru.Text = "Xóa";
            this.btnXoa_KhauTru.UseVisualStyleBackColor = true;
            this.btnXoa_KhauTru.Click += new System.EventHandler(this.btnXoa_KhauTru_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // DanhBo_KhauTru
            // 
            this.DanhBo_KhauTru.DataPropertyName = "DanhBo";
            this.DanhBo_KhauTru.HeaderText = "Danh Bộ";
            this.DanhBo_KhauTru.Name = "DanhBo_KhauTru";
            // 
            // SoTien_KhauTru
            // 
            this.SoTien_KhauTru.DataPropertyName = "SoTien";
            this.SoTien_KhauTru.HeaderText = "Số Tiền";
            this.SoTien_KhauTru.Name = "SoTien_KhauTru";
            // 
            // CreateDate_KhauTru
            // 
            this.CreateDate_KhauTru.DataPropertyName = "CreateDate";
            this.CreateDate_KhauTru.HeaderText = "Ngày Lập";
            this.CreateDate_KhauTru.Name = "CreateDate_KhauTru";
            // 
            // TatToan
            // 
            this.TatToan.DataPropertyName = "TatToan";
            this.TatToan.HeaderText = "Tất Toán";
            this.TatToan.Name = "TatToan";
            this.TatToan.Width = 70;
            // 
            // frmKhuCongNghiep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1134, 637);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKhuCongNghiep";
            this.Text = "Quản Lý Khấu Trừ / Khu Công Nghiệp";
            this.Load += new System.EventHandler(this.frmKhuCongNghiep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhauTruLichSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhauTru)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.DataGridView dgvDanhBo;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtDinhMuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDanhBo_KhauTru;
        private System.Windows.Forms.Button btnSua_KhauTru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoTien_KhauTru;
        private System.Windows.Forms.DataGridView dgvKhauTru;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThem_KhauTru;
        private System.Windows.Forms.Button btnXoa_KhauTru;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvKhauTruLichSu;
        private System.Windows.Forms.TextBox txtSoTienConLai_KhauTru;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_KTLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_KTLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien_KTLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_KTLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_KhauTru;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien_KhauTru;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_KhauTru;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TatToan;
    }
}