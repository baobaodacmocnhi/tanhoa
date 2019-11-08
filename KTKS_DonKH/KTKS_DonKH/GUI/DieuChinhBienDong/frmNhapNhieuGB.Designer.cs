namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmNhapNhieuGB
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
            this.dgvDanhBo = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HieuLucKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GBMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DMDCMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DMHNMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMucHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaQuanPhuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanhBo
            // 
            this.dgvDanhBo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhBo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDon,
            this.HieuLucKy,
            this.GBMoi,
            this.DMDCMoi,
            this.DMHNMoi,
            this.Dot,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.HopDong,
            this.MSThue,
            this.GiaBieu,
            this.DinhMuc,
            this.DinhMucHN,
            this.Ky,
            this.Nam,
            this.MLT,
            this.MaQuanPhuong,
            this.SH,
            this.HCSN,
            this.SX,
            this.DV,
            this.GhiChu});
            this.dgvDanhBo.Location = new System.Drawing.Point(12, 43);
            this.dgvDanhBo.Name = "dgvDanhBo";
            this.dgvDanhBo.Size = new System.Drawing.Size(1269, 441);
            this.dgvDanhBo.TabIndex = 25;
            this.dgvDanhBo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBo_CellEndEdit);
            this.dgvDanhBo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanhBo_CellFormatting);
            this.dgvDanhBo.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBo_RowLeave);
            this.dgvDanhBo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhBo_RowPostPaint);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(1112, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 25);
            this.btnLuu.TabIndex = 26;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // MaDon
            // 
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // HieuLucKy
            // 
            this.HieuLucKy.HeaderText = "Hiệu Lực Kỳ";
            this.HieuLucKy.Name = "HieuLucKy";
            this.HieuLucKy.Width = 70;
            // 
            // GBMoi
            // 
            this.GBMoi.HeaderText = "GB Mới";
            this.GBMoi.Name = "GBMoi";
            this.GBMoi.Width = 50;
            // 
            // DMDCMoi
            // 
            this.DMDCMoi.HeaderText = "ĐM DC Mới";
            this.DMDCMoi.Name = "DMDCMoi";
            this.DMDCMoi.Width = 50;
            // 
            // DMHNMoi
            // 
            this.DMHNMoi.HeaderText = "ĐM HN Mới";
            this.DMHNMoi.Name = "DMHNMoi";
            this.DMHNMoi.Width = 50;
            // 
            // Dot
            // 
            this.Dot.HeaderText = "Đợt";
            this.Dot.Name = "Dot";
            this.Dot.Width = 50;
            // 
            // DanhBo
            // 
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 200;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 250;
            // 
            // HopDong
            // 
            this.HopDong.HeaderText = "Hợp Đồng";
            this.HopDong.Name = "HopDong";
            this.HopDong.Width = 80;
            // 
            // MSThue
            // 
            this.MSThue.HeaderText = "MS Thuế";
            this.MSThue.Name = "MSThue";
            this.MSThue.Width = 80;
            // 
            // GiaBieu
            // 
            this.GiaBieu.HeaderText = "Giá Biểu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.Width = 50;
            // 
            // DinhMuc
            // 
            this.DinhMuc.HeaderText = "Định Mức";
            this.DinhMuc.Name = "DinhMuc";
            this.DinhMuc.Width = 50;
            // 
            // DinhMucHN
            // 
            this.DinhMucHN.HeaderText = "Định Mức HN";
            this.DinhMucHN.Name = "DinhMucHN";
            this.DinhMucHN.Width = 50;
            // 
            // Ky
            // 
            this.Ky.HeaderText = "Ky";
            this.Ky.Name = "Ky";
            this.Ky.Visible = false;
            // 
            // Nam
            // 
            this.Nam.HeaderText = "Nam";
            this.Nam.Name = "Nam";
            this.Nam.Visible = false;
            // 
            // MLT
            // 
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Visible = false;
            // 
            // MaQuanPhuong
            // 
            this.MaQuanPhuong.HeaderText = "MaQuanPhuong";
            this.MaQuanPhuong.Name = "MaQuanPhuong";
            this.MaQuanPhuong.Visible = false;
            // 
            // SH
            // 
            this.SH.HeaderText = "SH";
            this.SH.Name = "SH";
            this.SH.Visible = false;
            // 
            // HCSN
            // 
            this.HCSN.HeaderText = "HCSN";
            this.HCSN.Name = "HCSN";
            this.HCSN.Visible = false;
            // 
            // SX
            // 
            this.SX.HeaderText = "SX";
            this.SX.Name = "SX";
            this.SX.Visible = false;
            // 
            // DV
            // 
            this.DV.HeaderText = "DV";
            this.DV.Name = "DV";
            this.DV.Visible = false;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            // 
            // frmNhapNhieuGB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1290, 493);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvDanhBo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNhapNhieuGB";
            this.Text = "Nhập Nhiều GB";
            this.Load += new System.EventHandler(this.frmNhapNhieuGB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhBo;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn HieuLucKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn GBMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DMDCMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DMHNMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HopDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSThue;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMucHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQuanPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}