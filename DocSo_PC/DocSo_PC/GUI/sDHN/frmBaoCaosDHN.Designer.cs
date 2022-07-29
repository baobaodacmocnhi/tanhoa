namespace DocSo_PC.GUI.sDHN
{
    partial class frmBaoCaosDHN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.btnXem = new System.Windows.Forms.Button();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThuCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThuMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChenhLech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MLT,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NgayThay,
            this.TieuThuCu,
            this.TieuThuMoi,
            this.ChenhLech});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDanhSach.Location = new System.Drawing.Point(2, 41);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDanhSach.Size = new System.Drawing.Size(915, 581);
            this.dgvDanhSach.TabIndex = 58;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(117, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 57;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
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
            this.HoTen.Width = 120;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 150;
            // 
            // NgayThay
            // 
            this.NgayThay.DataPropertyName = "NgayThay";
            this.NgayThay.HeaderText = "Ngày Thay";
            this.NgayThay.Name = "NgayThay";
            // 
            // TieuThuCu
            // 
            this.TieuThuCu.DataPropertyName = "TieuThuCu";
            this.TieuThuCu.HeaderText = "Tiêu Thụ Cũ";
            this.TieuThuCu.Name = "TieuThuCu";
            // 
            // TieuThuMoi
            // 
            this.TieuThuMoi.DataPropertyName = "TieuThuMoi";
            this.TieuThuMoi.HeaderText = "Tiêu Thụ Mới";
            this.TieuThuMoi.Name = "TieuThuMoi";
            // 
            // ChenhLech
            // 
            this.ChenhLech.DataPropertyName = "ChenhLech";
            this.ChenhLech.HeaderText = "Chênh Lệch";
            this.ChenhLech.Name = "ChenhLech";
            // 
            // frmBaoCaosDHN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 653);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnXem);
            this.Name = "frmBaoCaosDHN";
            this.Text = "Báo Cáo ĐHN Thông Minh";
            this.Load += new System.EventHandler(this.frmBaoCaosDHN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThuCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThuMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChenhLech;
    }
}