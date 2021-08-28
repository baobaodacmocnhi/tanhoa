namespace ThuTien.GUI.ToTruong
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiaBieu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNiemChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiemBe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.dateGiaBieu = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateNiemChi = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateDiemBe = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.radGiaBieu = new System.Windows.Forms.RadioButton();
            this.radNiemChi = new System.Windows.Forms.RadioButton();
            this.radDiemBe = new System.Windows.Forms.RadioButton();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.lbTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(95, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(95, 38);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(100, 20);
            this.txtDienThoai.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Điện Thoại";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(95, 64);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(300, 20);
            this.txtGiaBieu.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giá Biểu";
            // 
            // txtNiemChi
            // 
            this.txtNiemChi.Location = new System.Drawing.Point(95, 116);
            this.txtNiemChi.Name = "txtNiemChi";
            this.txtNiemChi.Size = new System.Drawing.Size(300, 20);
            this.txtNiemChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Niêm Chì";
            // 
            // txtDiemBe
            // 
            this.txtDiemBe.Location = new System.Drawing.Point(95, 168);
            this.txtDiemBe.Name = "txtDiemBe";
            this.txtDiemBe.Size = new System.Drawing.Size(300, 20);
            this.txtDiemBe.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điểm Bể";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(95, 220);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 10;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // dateGiaBieu
            // 
            this.dateGiaBieu.CustomFormat = "dd/MM/yyyy";
            this.dateGiaBieu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaBieu.Location = new System.Drawing.Point(95, 90);
            this.dateGiaBieu.Name = "dateGiaBieu";
            this.dateGiaBieu.Size = new System.Drawing.Size(100, 20);
            this.dateGiaBieu.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Giá Biểu Ngày";
            // 
            // dateNiemChi
            // 
            this.dateNiemChi.CustomFormat = "dd/MM/yyyy";
            this.dateNiemChi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNiemChi.Location = new System.Drawing.Point(95, 142);
            this.dateNiemChi.Name = "dateNiemChi";
            this.dateNiemChi.Size = new System.Drawing.Size(100, 20);
            this.dateNiemChi.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Niêm Chì Ngày";
            // 
            // dateDiemBe
            // 
            this.dateDiemBe.CustomFormat = "dd/MM/yyyy";
            this.dateDiemBe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDiemBe.Location = new System.Drawing.Point(95, 194);
            this.dateDiemBe.Name = "dateDiemBe";
            this.dateDiemBe.Size = new System.Drawing.Size(100, 20);
            this.dateDiemBe.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Điểm Bể Ngày";
            // 
            // radGiaBieu
            // 
            this.radGiaBieu.AutoSize = true;
            this.radGiaBieu.Checked = true;
            this.radGiaBieu.Location = new System.Drawing.Point(508, 11);
            this.radGiaBieu.Name = "radGiaBieu";
            this.radGiaBieu.Size = new System.Drawing.Size(65, 17);
            this.radGiaBieu.TabIndex = 39;
            this.radGiaBieu.TabStop = true;
            this.radGiaBieu.Text = "Giá Biểu";
            this.radGiaBieu.UseVisualStyleBackColor = true;
            // 
            // radNiemChi
            // 
            this.radNiemChi.AutoSize = true;
            this.radNiemChi.Location = new System.Drawing.Point(508, 34);
            this.radNiemChi.Name = "radNiemChi";
            this.radNiemChi.Size = new System.Drawing.Size(67, 17);
            this.radNiemChi.TabIndex = 40;
            this.radNiemChi.Text = "Niêm Chì";
            this.radNiemChi.UseVisualStyleBackColor = true;
            // 
            // radDiemBe
            // 
            this.radDiemBe.AutoSize = true;
            this.radDiemBe.Location = new System.Drawing.Point(508, 58);
            this.radDiemBe.Name = "radDiemBe";
            this.radDiemBe.Size = new System.Drawing.Size(65, 17);
            this.radDiemBe.TabIndex = 41;
            this.radDiemBe.Text = "Điểm Bể";
            this.radDiemBe.UseVisualStyleBackColor = true;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(636, 13);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(579, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(806, 13);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(742, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Đến Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(912, 11);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 46;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(993, 11);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 47;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.NgayLap});
            this.dgvDanhSach.Location = new System.Drawing.Point(401, 80);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Size = new System.Drawing.Size(760, 300);
            this.dgvDanhSach.TabIndex = 48;
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 200;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 150;
            // 
            // NgayLap
            // 
            this.NgayLap.DataPropertyName = "NgayLap";
            this.NgayLap.HeaderText = "Ngày Lập";
            this.NgayLap.Name = "NgayLap";
            this.NgayLap.ReadOnly = true;
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(442, 12);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(60, 21);
            this.cmbTo.TabIndex = 110;
            this.cmbTo.Visible = false;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(404, 11);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(32, 19);
            this.lbTo.TabIndex = 109;
            this.lbTo.Text = "Tổ:";
            // 
            // frmGhiChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1303, 492);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.radDiemBe);
            this.Controls.Add(this.radNiemChi);
            this.Controls.Add(this.radGiaBieu);
            this.Controls.Add(this.dateDiemBe);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateNiemChi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateGiaBieu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.txtDiemBe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNiemChi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGiaBieu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Name = "frmGhiChu";
            this.Text = "Ghi Chú";
            this.Load += new System.EventHandler(this.frmGhiChu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiaBieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNiemChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiemBe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.DateTimePicker dateGiaBieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateNiemChi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateDiemBe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radGiaBieu;
        private System.Windows.Forms.RadioButton radNiemChi;
        private System.Windows.Forms.RadioButton radDiemBe;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label lbTo;
    }
}