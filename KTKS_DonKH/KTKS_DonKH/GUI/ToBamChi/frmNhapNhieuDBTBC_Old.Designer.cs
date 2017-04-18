namespace KTKS_DonKH.GUI.ToBamChi
{
    partial class frmNhapNhieuDBTBC_Old
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtNgayNhan = new System.Windows.Forms.TextBox();
            this.txtSoCongVan = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDung.Location = new System.Drawing.Point(408, 27);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(330, 22);
            this.txtNoiDung.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(408, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(330, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "                        Nội Dung Đơn Thư                         ";
            // 
            // txtNgayNhan
            // 
            this.txtNgayNhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayNhan.Location = new System.Drawing.Point(328, 27);
            this.txtNgayNhan.Name = "txtNgayNhan";
            this.txtNgayNhan.ReadOnly = true;
            this.txtNgayNhan.Size = new System.Drawing.Size(81, 22);
            this.txtNgayNhan.TabIndex = 21;
            this.txtNgayNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSoCongVan
            // 
            this.txtSoCongVan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoCongVan.Location = new System.Drawing.Point(210, 27);
            this.txtSoCongVan.Name = "txtSoCongVan";
            this.txtSoCongVan.Size = new System.Drawing.Size(119, 22);
            this.txtSoCongVan.TabIndex = 15;
            this.txtSoCongVan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(210, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 19);
            this.label16.TabIndex = 14;
            this.label16.Text = "   Số Công Văn   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "                 Loại Đơn                ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(328, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ngày Nhận";
            // 
            // cmbLD
            // 
            this.cmbLD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbLD.FormattingEnabled = true;
            this.cmbLD.Location = new System.Drawing.Point(11, 27);
            this.cmbLD.Name = "cmbLD";
            this.cmbLD.Size = new System.Drawing.Size(198, 24);
            this.cmbLD.TabIndex = 13;
            this.cmbLD.SelectedIndexChanged += new System.EventHandler(this.cmbLD_SelectedIndexChanged);
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
            this.dgvDanhBo.Location = new System.Drawing.Point(11, 55);
            this.dgvDanhBo.Name = "dgvDanhBo";
            this.dgvDanhBo.Size = new System.Drawing.Size(1282, 448);
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
            this.btnLuu.Location = new System.Drawing.Point(744, 9);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 25);
            this.btnLuu.TabIndex = 25;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmNhapNhieuDBTBC_Old
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1304, 515);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvDanhBo);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNgayNhan);
            this.Controls.Add(this.txtSoCongVan);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbLD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhapNhieuDBTBC_Old";
            this.Text = "Nhập Nhiều Danh Bộ Tổ Bấm Chì";
            this.Load += new System.EventHandler(this.frmNhapNhieuDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNgayNhan;
        private System.Windows.Forms.TextBox txtSoCongVan;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
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
    }
}