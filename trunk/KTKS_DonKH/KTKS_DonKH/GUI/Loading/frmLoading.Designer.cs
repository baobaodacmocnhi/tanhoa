namespace KTKS_DonKH.GUI.Loading
{
    partial class frmLoading
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LyDoChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNoiChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDoChuyenDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChuyen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.KetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayXuLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDSCTKTXM = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTKTXM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đang Xử Lý:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KTKS_DonKH.Properties.Resources.loading6;
            this.pictureBox1.Location = new System.Drawing.Point(103, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 18);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LyDoChuyenDen
            // 
            this.LyDoChuyenDen.DataPropertyName = "LyDoChuyenDen";
            this.LyDoChuyenDen.HeaderText = "Ly Do Chuyển Đến";
            this.LyDoChuyenDen.Name = "LyDoChuyenDen";
            this.LyDoChuyenDen.ReadOnly = true;
            this.LyDoChuyenDen.Width = 250;
            // 
            // NoiChuyenDen
            // 
            this.NoiChuyenDen.DataPropertyName = "NoiChuyenDen";
            this.NoiChuyenDen.HeaderText = "Nơi Chuyển Đến";
            this.NoiChuyenDen.Name = "NoiChuyenDen";
            this.NoiChuyenDen.ReadOnly = true;
            this.NoiChuyenDen.Width = 200;
            // 
            // MaNoiChuyenDen
            // 
            this.MaNoiChuyenDen.DataPropertyName = "MaNoiChuyenDen";
            this.MaNoiChuyenDen.HeaderText = "Mã Nơi Chuyển Đến";
            this.MaNoiChuyenDen.Name = "MaNoiChuyenDen";
            this.MaNoiChuyenDen.Visible = false;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 250;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 250;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 250;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            this.DanhBo.Width = 90;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Nhận";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 110;
            // 
            // TenLD
            // 
            this.TenLD.DataPropertyName = "TenLD";
            this.TenLD.HeaderText = "Tên Loại Đơn";
            this.TenLD.Name = "TenLD";
            this.TenLD.ReadOnly = true;
            this.TenLD.Width = 130;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            this.MaDon.Width = 90;
            // 
            // LyDoChuyenDi
            // 
            this.LyDoChuyenDi.DataPropertyName = "LyDoChuyenDi";
            this.LyDoChuyenDi.HeaderText = "Ly Do Chuyển Đi";
            this.LyDoChuyenDi.Name = "LyDoChuyenDi";
            this.LyDoChuyenDi.Width = 250;
            // 
            // MaChuyen
            // 
            this.MaChuyen.DataPropertyName = "MaChuyen";
            this.MaChuyen.HeaderText = "Chuyển Đi";
            this.MaChuyen.Name = "MaChuyen";
            this.MaChuyen.Width = 150;
            // 
            // KetQua
            // 
            this.KetQua.DataPropertyName = "KetQua";
            this.KetQua.HeaderText = "Kết Quả";
            this.KetQua.Name = "KetQua";
            this.KetQua.Width = 200;
            // 
            // NgayXuLy
            // 
            this.NgayXuLy.DataPropertyName = "NgayXuLy";
            this.NgayXuLy.HeaderText = "Ngày Xử Lý";
            this.NgayXuLy.Name = "NgayXuLy";
            this.NgayXuLy.ReadOnly = true;
            this.NgayXuLy.Width = 110;
            // 
            // MaKTXM
            // 
            this.MaKTXM.DataPropertyName = "MaKTXM";
            this.MaKTXM.HeaderText = "Mã KTXM";
            this.MaKTXM.Name = "MaKTXM";
            this.MaKTXM.Visible = false;
            // 
            // dgvDSCTKTXM
            // 
            this.dgvDSCTKTXM.AllowUserToAddRows = false;
            this.dgvDSCTKTXM.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSCTKTXM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSCTKTXM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSCTKTXM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKTXM,
            this.NgayXuLy,
            this.KetQua,
            this.MaChuyen,
            this.LyDoChuyenDi,
            this.MaDon,
            this.TenLD,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.MaNoiChuyenDen,
            this.NoiChuyenDen,
            this.LyDoChuyenDen});
            this.dgvDSCTKTXM.Location = new System.Drawing.Point(15, 38);
            this.dgvDSCTKTXM.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSCTKTXM.MultiSelect = false;
            this.dgvDSCTKTXM.Name = "dgvDSCTKTXM";
            this.dgvDSCTKTXM.Size = new System.Drawing.Size(2384, 470);
            this.dgvDSCTKTXM.TabIndex = 8;
            this.dgvDSCTKTXM.Visible = false;
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1297, 520);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDSCTKTXM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Báo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTKTXM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyenDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyenDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNoiChuyenDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyenDi;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKTXM;
        private System.Windows.Forms.DataGridView dgvDSCTKTXM;
    }
}