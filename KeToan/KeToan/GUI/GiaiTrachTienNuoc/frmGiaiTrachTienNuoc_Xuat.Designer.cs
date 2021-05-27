namespace KeToan.GUI.GiaiTrachTienNuoc
{
    partial class frmGiaiTrachTienNuoc_Xuat
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
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayPhieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.txtTong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(529, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 96;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NgayGiaiTrach,
            this.DanhBo,
            this.Ky,
            this.TongCong,
            this.SoPhieuThu,
            this.NgayPhieuThu});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 34);
            this.dgvHoaDon.Name = "dgvHoaDon";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHoaDon.Size = new System.Drawing.Size(691, 575);
            this.dgvHoaDon.TabIndex = 95;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            this.dgvHoaDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHoaDon_RowPostPaint);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            this.NgayGiaiTrach.Width = 110;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Width = 150;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.Width = 50;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            // 
            // SoPhieuThu
            // 
            this.SoPhieuThu.DataPropertyName = "SoPhieuThu";
            this.SoPhieuThu.HeaderText = "Số PT";
            this.SoPhieuThu.Name = "SoPhieuThu";
            // 
            // NgayPhieuThu
            // 
            this.NgayPhieuThu.DataPropertyName = "NgayPhieuThu";
            this.NgayPhieuThu.HeaderText = "Ngày PT";
            this.NgayPhieuThu.Name = "NgayPhieuThu";
            this.NgayPhieuThu.Width = 120;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(175, 8);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 93;
            this.label4.Text = "Từ Ngày";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(342, 8);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 91;
            this.label3.Text = "Đến Ngày";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(448, 5);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 90;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 5);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 89;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // txtTongCong
            // 
            this.txtTongCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong.Location = new System.Drawing.Point(364, 609);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong.TabIndex = 97;
            // 
            // txtTong
            // 
            this.txtTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTong.Location = new System.Drawing.Point(12, 609);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(50, 20);
            this.txtTong.TabIndex = 98;
            // 
            // frmGiaiTrachTienNuoc_Xuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 674);
            this.Controls.Add(this.txtTong);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnChonFile);
            this.Name = "frmGiaiTrachTienNuoc_Xuat";
            this.Text = "Xuất";
            this.Load += new System.EventHandler(this.frmGiaiTrachTienNuoc_Xuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayPhieuThu;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.TextBox txtTong;
    }
}