namespace ThuTien.GUI.ToTruong
{
    partial class frmMoNuoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvKQDongNuoc = new System.Windows.Forms.DataGridView();
            this.MaDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKQDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoThan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiMatSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiKhoaGoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoNuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKQDongNuoc
            // 
            this.dgvKQDongNuoc.AllowUserToAddRows = false;
            this.dgvKQDongNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQDongNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvKQDongNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQDongNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDN,
            this.CreateDate,
            this.MaKQDN,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.MLT,
            this.NgayDN,
            this.NgayGiaiTrach,
            this.ChiSo,
            this.Hieu,
            this.Co,
            this.SoThan,
            this.ChiMatSo,
            this.ChiKhoaGoc,
            this.LyDo,
            this.MoNuoc,
            this.NgayMN});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKQDongNuoc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvKQDongNuoc.Location = new System.Drawing.Point(12, 41);
            this.dgvKQDongNuoc.MultiSelect = false;
            this.dgvKQDongNuoc.Name = "dgvKQDongNuoc";
            this.dgvKQDongNuoc.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQDongNuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvKQDongNuoc.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvKQDongNuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKQDongNuoc.Size = new System.Drawing.Size(883, 470);
            this.dgvKQDongNuoc.TabIndex = 31;
            this.dgvKQDongNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKQDongNuoc_CellFormatting);
            this.dgvKQDongNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvKQDongNuoc_RowPostPaint);
            // 
            // MaDN
            // 
            this.MaDN.DataPropertyName = "MaDN";
            this.MaDN.HeaderText = "Mã TB";
            this.MaDN.Name = "MaDN";
            this.MaDN.ReadOnly = true;
            this.MaDN.Width = 80;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 80;
            // 
            // MaKQDN
            // 
            this.MaKQDN.DataPropertyName = "MaKQDN";
            this.MaKQDN.HeaderText = "MaKQDN";
            this.MaKQDN.Name = "MaKQDN";
            this.MaKQDN.ReadOnly = true;
            this.MaKQDN.Visible = false;
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
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.ReadOnly = true;
            this.MLT.Visible = false;
            // 
            // NgayDN
            // 
            this.NgayDN.DataPropertyName = "NgayDN";
            this.NgayDN.HeaderText = "Đóng Nước";
            this.NgayDN.Name = "NgayDN";
            this.NgayDN.ReadOnly = true;
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach.HeaderText = "Đăng Ngân";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            this.NgayGiaiTrach.ReadOnly = true;
            // 
            // ChiSo
            // 
            this.ChiSo.DataPropertyName = "ChiSo";
            this.ChiSo.HeaderText = "ChiSo";
            this.ChiSo.Name = "ChiSo";
            this.ChiSo.ReadOnly = true;
            this.ChiSo.Visible = false;
            // 
            // Hieu
            // 
            this.Hieu.DataPropertyName = "Hieu";
            this.Hieu.HeaderText = "Hieu";
            this.Hieu.Name = "Hieu";
            this.Hieu.ReadOnly = true;
            this.Hieu.Visible = false;
            // 
            // Co
            // 
            this.Co.DataPropertyName = "Co";
            this.Co.HeaderText = "Co";
            this.Co.Name = "Co";
            this.Co.ReadOnly = true;
            this.Co.Visible = false;
            // 
            // SoThan
            // 
            this.SoThan.DataPropertyName = "SoThan";
            this.SoThan.HeaderText = "SoThan";
            this.SoThan.Name = "SoThan";
            this.SoThan.ReadOnly = true;
            this.SoThan.Visible = false;
            // 
            // ChiMatSo
            // 
            this.ChiMatSo.DataPropertyName = "ChiMatSo";
            this.ChiMatSo.HeaderText = "ChiMatSo";
            this.ChiMatSo.Name = "ChiMatSo";
            this.ChiMatSo.ReadOnly = true;
            this.ChiMatSo.Visible = false;
            // 
            // ChiKhoaGoc
            // 
            this.ChiKhoaGoc.DataPropertyName = "ChiKhoaGoc";
            this.ChiKhoaGoc.HeaderText = "ChiKhoaGoc";
            this.ChiKhoaGoc.Name = "ChiKhoaGoc";
            this.ChiKhoaGoc.ReadOnly = true;
            this.ChiKhoaGoc.Visible = false;
            // 
            // LyDo
            // 
            this.LyDo.DataPropertyName = "LyDo";
            this.LyDo.HeaderText = "LyDo";
            this.LyDo.Name = "LyDo";
            this.LyDo.ReadOnly = true;
            this.LyDo.Visible = false;
            // 
            // MoNuoc
            // 
            this.MoNuoc.DataPropertyName = "MoNuoc";
            this.MoNuoc.HeaderText = "DongNuoc";
            this.MoNuoc.Name = "MoNuoc";
            this.MoNuoc.ReadOnly = true;
            this.MoNuoc.Visible = false;
            // 
            // NgayMN
            // 
            this.NgayMN.DataPropertyName = "NgayMN";
            this.NgayMN.HeaderText = "NgayMN";
            this.NgayMN.Name = "NgayMN";
            this.NgayMN.ReadOnly = true;
            this.NgayMN.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 32;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmMoNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 523);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvKQDongNuoc);
            this.Name = "frmMoNuoc";
            this.Text = "Danh Bộ Cần Mở Nước";
            this.Load += new System.EventHandler(this.frmMoNuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKQDongNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKQDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoThan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiMatSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiKhoaGoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMN;
        private System.Windows.Forms.Button btnRefresh;
    }
}