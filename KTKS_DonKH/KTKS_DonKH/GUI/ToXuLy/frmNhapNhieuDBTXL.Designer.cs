namespace KTKS_DonKH.GUI.ToXuLy
{
    partial class frmNhapNhieuDBTXL
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
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtSoCongVan = new System.Windows.Forms.TextBox();
            this.cmbLD = new System.Windows.Forms.ComboBox();
            this.dgvDanhBo = new System.Windows.Forms.DataGridView();
            this.NgayChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiDi = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(374, 63);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDung.TabIndex = 23;
            // 
            // txtSoCongVan
            // 
            this.txtSoCongVan.Location = new System.Drawing.Point(268, 63);
            this.txtSoCongVan.Name = "txtSoCongVan";
            this.txtSoCongVan.Size = new System.Drawing.Size(100, 22);
            this.txtSoCongVan.TabIndex = 15;
            this.txtSoCongVan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbLD
            // 
            this.cmbLD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLD.FormattingEnabled = true;
            this.cmbLD.Location = new System.Drawing.Point(12, 61);
            this.cmbLD.Name = "cmbLD";
            this.cmbLD.Size = new System.Drawing.Size(250, 24);
            this.cmbLD.TabIndex = 13;
            // 
            // dgvDanhBo
            // 
            this.dgvDanhBo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhBo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayChuyen,
            this.NguoiDi,
            this.GhiChu,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.HopDong,
            this.MSThue,
            this.GiaBieu,
            this.DinhMuc,
            this.Dot,
            this.Ky,
            this.Nam,
            this.MLT});
            this.dgvDanhBo.Location = new System.Drawing.Point(0, 92);
            this.dgvDanhBo.Name = "dgvDanhBo";
            this.dgvDanhBo.Size = new System.Drawing.Size(1275, 418);
            this.dgvDanhBo.TabIndex = 24;
            this.dgvDanhBo.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDanhBo_CellBeginEdit);
            this.dgvDanhBo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBo_CellEndEdit);
            this.dgvDanhBo.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBo_RowLeave);
            this.dgvDanhBo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhBo_RowPostPaint);
            // 
            // NgayChuyen
            // 
            this.NgayChuyen.HeaderText = "Ngày Chuyển";
            this.NgayChuyen.Name = "NgayChuyen";
            // 
            // NguoiDi
            // 
            this.NguoiDi.HeaderText = "Người Đi";
            this.NguoiDi.Name = "NguoiDi";
            this.NguoiDi.Width = 150;
            // 
            // GhiChu
            // 
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 150;
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
            // Dot
            // 
            this.Dot.HeaderText = "Dot";
            this.Dot.Name = "Dot";
            this.Dot.Visible = false;
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
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(480, 61);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 25);
            this.btnLuu.TabIndex = 25;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(114, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 16);
            this.label15.TabIndex = 102;
            this.label15.Text = "Mã Đơn:";
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(177, 12);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(85, 22);
            this.txtMaDon.TabIndex = 101;
            this.txtMaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDon_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 100;
            this.label5.Text = "Nội Dung:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(265, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 16);
            this.label14.TabIndex = 99;
            this.label14.Text = "Số Công Văn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 98;
            this.label1.Text = "Loại Đơn:";
            // 
            // frmNhapNhieuDBTXL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1279, 512);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvDanhBo);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.txtSoCongVan);
            this.Controls.Add(this.cmbLD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhapNhieuDBTXL";
            this.Text = "Nhập Nhiều Danh Bộ Tổ Xử Lý";
            this.Load += new System.EventHandler(this.frmNhapNhieuDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtSoCongVan;
        private System.Windows.Forms.ComboBox cmbLD;
        private System.Windows.Forms.DataGridView dgvDanhBo;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyen;
        private System.Windows.Forms.DataGridViewComboBoxColumn NguoiDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HopDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSThue;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
    }
}