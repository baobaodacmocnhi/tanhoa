namespace ThuTien.GUI.Doi
{
    partial class frmBaoCaoVatTu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dgvBamChi = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.MaKQDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duyet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSoDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBamChi)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Đến Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(378, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(95, 20);
            this.dateDen.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Từ Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(479, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 17;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(213, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(95, 20);
            this.dateTu.TabIndex = 16;
            // 
            // dgvBamChi
            // 
            this.dgvBamChi.AllowUserToAddRows = false;
            this.dgvBamChi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBamChi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBamChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBamChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKQDN,
            this.DanhBo,
            this.Duyet,
            this.HoTen,
            this.DiaChi,
            this.Hieu,
            this.Co,
            this.ChiSoDN,
            this.NgayDN,
            this.NhanVien,
            this.To});
            this.dgvBamChi.Location = new System.Drawing.Point(12, 38);
            this.dgvBamChi.MultiSelect = false;
            this.dgvBamChi.Name = "dgvBamChi";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBamChi.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBamChi.Size = new System.Drawing.Size(1174, 589);
            this.dgvBamChi.TabIndex = 20;
            this.dgvBamChi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBamChi_CellFormatting);
            this.dgvBamChi.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBamChi_CellValidating);
            this.dgvBamChi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBamChi_RowPostPaint);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(560, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 21;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // MaKQDN
            // 
            this.MaKQDN.DataPropertyName = "MaKQDN";
            this.MaKQDN.HeaderText = "MaKQDN";
            this.MaKQDN.Name = "MaKQDN";
            this.MaKQDN.Visible = false;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // Duyet
            // 
            this.Duyet.DataPropertyName = "Duyet";
            this.Duyet.HeaderText = "Duyệt";
            this.Duyet.Name = "Duyet";
            this.Duyet.Width = 50;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 200;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 300;
            // 
            // Hieu
            // 
            this.Hieu.DataPropertyName = "Hieu";
            this.Hieu.HeaderText = "Hiệu";
            this.Hieu.Name = "Hieu";
            this.Hieu.Width = 80;
            // 
            // Co
            // 
            this.Co.DataPropertyName = "Co";
            this.Co.HeaderText = "Cỡ";
            this.Co.Name = "Co";
            this.Co.Width = 50;
            // 
            // ChiSoDN
            // 
            this.ChiSoDN.DataPropertyName = "ChiSoDN";
            this.ChiSoDN.HeaderText = "Chỉ Số";
            this.ChiSoDN.Name = "ChiSoDN";
            this.ChiSoDN.Width = 80;
            // 
            // NgayDN
            // 
            this.NgayDN.DataPropertyName = "NgayDN";
            this.NgayDN.HeaderText = "Ngày ĐN";
            this.NgayDN.Name = "NgayDN";
            // 
            // NhanVien
            // 
            this.NhanVien.DataPropertyName = "NhanVien";
            this.NhanVien.HeaderText = "Nhân Viên";
            this.NhanVien.Name = "NhanVien";
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "Tổ";
            this.To.Name = "To";
            this.To.Width = 50;
            // 
            // frmBaoCaoVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 640);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvBamChi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateTu);
            this.Name = "frmBaoCaoVatTu";
            this.Text = "Báo Cáo Vật Tư";
            this.Load += new System.EventHandler(this.frmBaoCaoVatTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBamChi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DataGridView dgvBamChi;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKQDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Duyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSoDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
    }
}