namespace DocSo_PC.GUI.ToTruong
{
    partial class frmGhiChu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnXem = new System.Windows.Forms.Button();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.cmbMay = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbViTri1 = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtSoNha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkGieng = new System.Windows.Forms.CheckBox();
            this.txtTenDuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDienThoai = new System.Windows.Forms.DataGridView();
            this.DanhBo_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoChinh_DT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.cmbViTri2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTongDienThoai = new System.Windows.Forms.TextBox();
            this.txtTongViTri = new System.Windows.Forms.TextBox();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViTri1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViTri2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDienThoai)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(255, 1);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 67;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(391, 2);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Danh Bộ";
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(12, 2);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(32, 19);
            this.lbTo.TabIndex = 58;
            this.lbTo.Text = "Tổ:";
            // 
            // cmbMay
            // 
            this.cmbMay.FormattingEnabled = true;
            this.cmbMay.Location = new System.Drawing.Point(189, 2);
            this.cmbMay.Name = "cmbMay";
            this.cmbMay.Size = new System.Drawing.Size(60, 21);
            this.cmbMay.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Máy";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbTo.Location = new System.Drawing.Point(50, 2);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(100, 21);
            this.cmbTo.TabIndex = 55;
            this.cmbTo.Visible = false;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MLT,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.ViTri1,
            this.ViTri2,
            this.DienThoai});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 29);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDanhSach.Size = new System.Drawing.Size(821, 580);
            this.dgvDanhSach.TabIndex = 68;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(842, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Vị Trí 1";
            // 
            // cmbViTri1
            // 
            this.cmbViTri1.FormattingEnabled = true;
            this.cmbViTri1.Location = new System.Drawing.Point(909, 227);
            this.cmbViTri1.Name = "cmbViTri1";
            this.cmbViTri1.Size = new System.Drawing.Size(100, 21);
            this.cmbViTri1.TabIndex = 70;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(909, 277);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 71;
            this.btnSua.Text = "Cập Nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtSoNha
            // 
            this.txtSoNha.Location = new System.Drawing.Point(909, 175);
            this.txtSoNha.Name = "txtSoNha";
            this.txtSoNha.Size = new System.Drawing.Size(100, 20);
            this.txtSoNha.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(842, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Số Nhà";
            // 
            // chkGieng
            // 
            this.chkGieng.AutoSize = true;
            this.chkGieng.Location = new System.Drawing.Point(909, 254);
            this.chkGieng.Name = "chkGieng";
            this.chkGieng.Size = new System.Drawing.Size(54, 17);
            this.chkGieng.TabIndex = 74;
            this.chkGieng.Text = "Giếng";
            this.chkGieng.UseVisualStyleBackColor = true;
            // 
            // txtTenDuong
            // 
            this.txtTenDuong.Location = new System.Drawing.Point(909, 201);
            this.txtTenDuong.Name = "txtTenDuong";
            this.txtTenDuong.Size = new System.Drawing.Size(150, 20);
            this.txtTenDuong.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(842, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 75;
            this.label4.Text = "Tên Đường";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDienThoai);
            this.groupBox1.Location = new System.Drawing.Point(841, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 140);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điện Thoại";
            // 
            // dgvDienThoai
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDienThoai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDienThoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDienThoai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo_DT,
            this.DienThoai_DT,
            this.HoTen_DT,
            this.SoChinh_DT,
            this.CreateDate});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDienThoai.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDienThoai.Location = new System.Drawing.Point(3, 16);
            this.dgvDienThoai.Name = "dgvDienThoai";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDienThoai.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDienThoai.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDienThoai.Size = new System.Drawing.Size(410, 121);
            this.dgvDienThoai.TabIndex = 69;
            this.dgvDienThoai.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDienThoai_CellEndEdit);
            this.dgvDienThoai.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDienThoai_RowValidated);
            this.dgvDienThoai.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDienThoai_UserAddedRow);
            this.dgvDienThoai.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDienThoai_UserDeletingRow);
            // 
            // DanhBo_DT
            // 
            this.DanhBo_DT.DataPropertyName = "DanhBo";
            this.DanhBo_DT.HeaderText = "Danh Bộ";
            this.DanhBo_DT.Name = "DanhBo_DT";
            this.DanhBo_DT.Visible = false;
            // 
            // DienThoai_DT
            // 
            this.DienThoai_DT.DataPropertyName = "DienThoai";
            this.DienThoai_DT.HeaderText = "Điện Thoại";
            this.DienThoai_DT.Name = "DienThoai_DT";
            // 
            // HoTen_DT
            // 
            this.HoTen_DT.DataPropertyName = "HoTen";
            this.HoTen_DT.HeaderText = "Khách Hàng";
            this.HoTen_DT.Name = "HoTen_DT";
            // 
            // SoChinh_DT
            // 
            this.SoChinh_DT.DataPropertyName = "SoChinh";
            this.SoChinh_DT.FalseValue = "False";
            this.SoChinh_DT.HeaderText = "Số Chính";
            this.SoChinh_DT.IndeterminateValue = "False";
            this.SoChinh_DT.Name = "SoChinh_DT";
            this.SoChinh_DT.TrueValue = "True";
            this.SoChinh_DT.Width = 50;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(890, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(268, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "Xóa SĐT: Chọn dòng => bấm nút Delete trên bàn phím";
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(909, 306);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 79;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Visible = false;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // cmbViTri2
            // 
            this.cmbViTri2.FormattingEnabled = true;
            this.cmbViTri2.Location = new System.Drawing.Point(1063, 227);
            this.cmbViTri2.Name = "cmbViTri2";
            this.cmbViTri2.Size = new System.Drawing.Size(100, 21);
            this.cmbViTri2.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1015, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "Vị Trí 2";
            // 
            // txtTongDienThoai
            // 
            this.txtTongDienThoai.Location = new System.Drawing.Point(716, 609);
            this.txtTongDienThoai.Name = "txtTongDienThoai";
            this.txtTongDienThoai.Size = new System.Drawing.Size(100, 20);
            this.txtTongDienThoai.TabIndex = 82;
            // 
            // txtTongViTri
            // 
            this.txtTongViTri.Location = new System.Drawing.Point(656, 609);
            this.txtTongViTri.Name = "txtTongViTri";
            this.txtTongViTri.Size = new System.Drawing.Size(60, 20);
            this.txtTongViTri.TabIndex = 83;
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Width = 80;
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
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // ViTri1
            // 
            this.ViTri1.DataPropertyName = "ViTri1";
            this.ViTri1.HeaderText = "Vị Trí 1";
            this.ViTri1.Name = "ViTri1";
            this.ViTri1.Width = 65;
            // 
            // ViTri2
            // 
            this.ViTri2.DataPropertyName = "ViTri2";
            this.ViTri2.HeaderText = "Vị Trí 2";
            this.ViTri2.Name = "ViTri2";
            this.ViTri2.Width = 65;
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "Điện Thoại";
            this.DienThoai.Name = "DienThoai";
            // 
            // frmGhiChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 655);
            this.Controls.Add(this.txtTongViTri);
            this.Controls.Add(this.txtTongDienThoai);
            this.Controls.Add(this.cmbViTri2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTenDuong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkGieng);
            this.Controls.Add(this.txtSoNha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.cmbViTri1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.cmbMay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTo);
            this.Name = "frmGhiChu";
            this.Text = "Ghi Chú";
            this.Load += new System.EventHandler(this.frmGhiChu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDienThoai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.ComboBox cmbMay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbViTri1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtSoNha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkGieng;
        private System.Windows.Forms.TextBox txtTenDuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDienThoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.ComboBox cmbViTri2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTongDienThoai;
        private System.Windows.Forms.TextBox txtTongViTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_DT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SoChinh_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ViTri1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ViTri2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
    }
}