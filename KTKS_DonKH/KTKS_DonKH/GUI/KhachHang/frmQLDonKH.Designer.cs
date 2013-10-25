namespace KTKS_DonKH.GUI.KhachHang
{
    partial class frmQLDonKH
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
            this.dgvDSDonKH = new System.Windows.Forms.DataGridView();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChuyen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LyDoChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuu = new System.Windows.Forms.Button();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radChuDuyet = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonKH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSDonKH
            // 
            this.dgvDSDonKH.AllowUserToAddRows = false;
            this.dgvDSDonKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDonKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDon,
            this.TenLD,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.MaChuyen,
            this.LyDoChuyen});
            this.dgvDSDonKH.Location = new System.Drawing.Point(0, 67);
            this.dgvDSDonKH.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSDonKH.Name = "dgvDSDonKH";
            this.dgvDSDonKH.Size = new System.Drawing.Size(1362, 490);
            this.dgvDSDonKH.TabIndex = 0;
            this.dgvDSDonKH.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSDonKH_CellDoubleClick);
            this.dgvDSDonKH.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSDonKH_RowPostPaint);
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            this.MaDon.Width = 60;
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
            this.HoTen.Width = 200;
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
            this.NoiDung.Width = 250;
            // 
            // MaChuyen
            // 
            this.MaChuyen.DataPropertyName = "MaChuyen";
            this.MaChuyen.HeaderText = "Chuyển Đi";
            this.MaChuyen.Name = "MaChuyen";
            this.MaChuyen.Width = 150;
            // 
            // LyDoChuyen
            // 
            this.LyDoChuyen.DataPropertyName = "LyDoChuyen";
            this.LyDoChuyen.HeaderText = "Ly Do Chuyển";
            this.LyDoChuyen.Name = "LyDoChuyen";
            this.LyDoChuyen.Width = 127;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(1180, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 35);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(12, 12);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(67, 21);
            this.radAll.TabIndex = 2;
            this.radAll.Text = "Tất Cả";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // radChuDuyet
            // 
            this.radChuDuyet.AutoSize = true;
            this.radChuDuyet.Location = new System.Drawing.Point(12, 39);
            this.radChuDuyet.Name = "radChuDuyet";
            this.radChuDuyet.Size = new System.Drawing.Size(98, 21);
            this.radChuDuyet.TabIndex = 3;
            this.radChuDuyet.Text = "Chưa Duyệt";
            this.radChuDuyet.UseVisualStyleBackColor = true;
            this.radChuDuyet.CheckedChanged += new System.EventHandler(this.radChuDuyet_CheckedChanged);
            // 
            // frmQLDonKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 562);
            this.Controls.Add(this.radChuDuyet);
            this.Controls.Add(this.radAll);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvDSDonKH);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLDonKH";
            this.Text = "frmQLDonKH";
            this.Load += new System.EventHandler(this.frmQLDonKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSDonKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyen;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radChuDuyet;


    }
}