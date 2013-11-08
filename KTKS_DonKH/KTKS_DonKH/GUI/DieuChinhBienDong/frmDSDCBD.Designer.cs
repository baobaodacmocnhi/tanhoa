namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmDSDCBD
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.điềuChỉnhBiếnĐộngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điềuChỉnhHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radDaDuyet = new System.Windows.Forms.RadioButton();
            this.dgvDSDCBD = new System.Windows.Forms.DataGridView();
            this.radChuDuyet = new System.Windows.Forms.RadioButton();
            this.btnLuu = new System.Windows.Forms.Button();
            this.MaDCBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayXuLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChuyen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LyDoChuyenDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDoChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDCBD)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.điềuChỉnhBiếnĐộngToolStripMenuItem,
            this.điềuChỉnhHóaĐơnToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(210, 48);
            // 
            // điềuChỉnhBiếnĐộngToolStripMenuItem
            // 
            this.điềuChỉnhBiếnĐộngToolStripMenuItem.Name = "điềuChỉnhBiếnĐộngToolStripMenuItem";
            this.điềuChỉnhBiếnĐộngToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.điềuChỉnhBiếnĐộngToolStripMenuItem.Text = "Điều Chỉnh Biến Động";
            this.điềuChỉnhBiếnĐộngToolStripMenuItem.Click += new System.EventHandler(this.điềuChỉnhBiếnĐộngToolStripMenuItem_Click);
            // 
            // điềuChỉnhHóaĐơnToolStripMenuItem
            // 
            this.điềuChỉnhHóaĐơnToolStripMenuItem.Name = "điềuChỉnhHóaĐơnToolStripMenuItem";
            this.điềuChỉnhHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.điềuChỉnhHóaĐơnToolStripMenuItem.Text = "Điều Chỉnh Hóa Đơn";
            this.điềuChỉnhHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.điềuChỉnhHóaĐơnToolStripMenuItem_Click);
            // 
            // radDaDuyet
            // 
            this.radDaDuyet.AutoSize = true;
            this.radDaDuyet.Location = new System.Drawing.Point(12, 12);
            this.radDaDuyet.Name = "radDaDuyet";
            this.radDaDuyet.Size = new System.Drawing.Size(84, 21);
            this.radDaDuyet.TabIndex = 10;
            this.radDaDuyet.Text = "Đã Duyệt";
            this.radDaDuyet.UseVisualStyleBackColor = true;
            this.radDaDuyet.CheckedChanged += new System.EventHandler(this.radDaDuyet_CheckedChanged);
            // 
            // dgvDSDCBD
            // 
            this.dgvDSDCBD.AllowUserToAddRows = false;
            this.dgvDSDCBD.AllowUserToDeleteRows = false;
            this.dgvDSDCBD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDCBD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDCBD,
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
            this.NoiChuyenDen,
            this.LyDoChuyenDen});
            this.dgvDSDCBD.Location = new System.Drawing.Point(0, 67);
            this.dgvDSDCBD.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSDCBD.MultiSelect = false;
            this.dgvDSDCBD.Name = "dgvDSDCBD";
            this.dgvDSDCBD.Size = new System.Drawing.Size(2500, 470);
            this.dgvDSDCBD.TabIndex = 8;
            this.dgvDSDCBD.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDSDCBD_CellMouseClick);
            this.dgvDSDCBD.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSDCBD_RowPostPaint);
            this.dgvDSDCBD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSDCBD_KeyDown);
            this.dgvDSDCBD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDSDCBD_MouseClick);
            // 
            // radChuDuyet
            // 
            this.radChuDuyet.AutoSize = true;
            this.radChuDuyet.Location = new System.Drawing.Point(12, 39);
            this.radChuDuyet.Name = "radChuDuyet";
            this.radChuDuyet.Size = new System.Drawing.Size(98, 21);
            this.radChuDuyet.TabIndex = 11;
            this.radChuDuyet.Text = "Chưa Duyệt";
            this.radChuDuyet.UseVisualStyleBackColor = true;
            this.radChuDuyet.CheckedChanged += new System.EventHandler(this.radChuDuyet_CheckedChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(1180, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // MaDCBD
            // 
            this.MaDCBD.DataPropertyName = "MaDCBD";
            this.MaDCBD.HeaderText = "Số Phiếu";
            this.MaDCBD.Name = "MaDCBD";
            this.MaDCBD.ReadOnly = true;
            this.MaDCBD.Width = 90;
            // 
            // NgayXuLy
            // 
            this.NgayXuLy.DataPropertyName = "NgayXuLy";
            this.NgayXuLy.HeaderText = "Ngày Xử Lý";
            this.NgayXuLy.Name = "NgayXuLy";
            this.NgayXuLy.ReadOnly = true;
            this.NgayXuLy.Width = 110;
            // 
            // KetQua
            // 
            this.KetQua.DataPropertyName = "KetQua";
            this.KetQua.HeaderText = "Kết Quả";
            this.KetQua.Name = "KetQua";
            this.KetQua.Width = 200;
            // 
            // MaChuyen
            // 
            this.MaChuyen.DataPropertyName = "MaChuyen";
            this.MaChuyen.HeaderText = "Chuyển Đi";
            this.MaChuyen.Name = "MaChuyen";
            this.MaChuyen.Width = 150;
            // 
            // LyDoChuyenDi
            // 
            this.LyDoChuyenDi.DataPropertyName = "LyDoChuyenDi";
            this.LyDoChuyenDi.HeaderText = "Ly Do Chuyển Đi";
            this.LyDoChuyenDi.Name = "LyDoChuyenDi";
            this.LyDoChuyenDi.Width = 250;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            this.MaDon.Width = 90;
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
            this.HoTen.Width = 250;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 250;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 250;
            // 
            // NoiChuyenDen
            // 
            this.NoiChuyenDen.DataPropertyName = "NoiChuyenDen";
            this.NoiChuyenDen.HeaderText = "Nơi Chuyển Đến";
            this.NoiChuyenDen.Name = "NoiChuyenDen";
            this.NoiChuyenDen.ReadOnly = true;
            this.NoiChuyenDen.Width = 200;
            // 
            // LyDoChuyenDen
            // 
            this.LyDoChuyenDen.DataPropertyName = "LyDoChuyenDen";
            this.LyDoChuyenDen.HeaderText = "Ly Do Chuyển Đến";
            this.LyDoChuyenDen.Name = "LyDoChuyenDen";
            this.LyDoChuyenDen.ReadOnly = true;
            this.LyDoChuyenDen.Width = 250;
            // 
            // frmDSDCBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 560);
            this.Controls.Add(this.radDaDuyet);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.radChuDuyet);
            this.Controls.Add(this.dgvDSDCBD);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDSDCBD";
            this.Text = "frmDSDCBD";
            this.Load += new System.EventHandler(this.frmDSDCBD_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDCBD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem điềuChỉnhBiếnĐộngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem điềuChỉnhHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.RadioButton radDaDuyet;
        private System.Windows.Forms.DataGridView dgvDSDCBD;
        private System.Windows.Forms.RadioButton radChuDuyet;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDCBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetQua;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyenDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyenDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyenDen;
    }
}