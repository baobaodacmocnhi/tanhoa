namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmLoaiChungTu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKyHieuLCT = new System.Windows.Forms.TextBox();
            this.txtTenLCT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvDSChungTu = new System.Windows.Forms.DataGridView();
            this.MaLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHieuLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtThoiHan = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPhimTat = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChungTu)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhimTat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ký Hiệu Chứng Từ:";
            // 
            // txtKyHieuLCT
            // 
            this.txtKyHieuLCT.Location = new System.Drawing.Point(189, 12);
            this.txtKyHieuLCT.Name = "txtKyHieuLCT";
            this.txtKyHieuLCT.Size = new System.Drawing.Size(201, 22);
            this.txtKyHieuLCT.TabIndex = 1;
            // 
            // txtTenLCT
            // 
            this.txtTenLCT.Location = new System.Drawing.Point(189, 41);
            this.txtTenLCT.Name = "txtTenLCT";
            this.txtTenLCT.Size = new System.Drawing.Size(201, 22);
            this.txtTenLCT.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Chứng Từ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thời Hạn (tháng):";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(304, 99);
            this.btnSua.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(86, 27);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(209, 99);
            this.btnThem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(86, 27);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvDSChungTu
            // 
            this.dgvDSChungTu.AllowUserToAddRows = false;
            this.dgvDSChungTu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSChungTu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSChungTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSChungTu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLCT,
            this.KyHieuLCT,
            this.TenLCT,
            this.ThoiHan});
            this.dgvDSChungTu.Location = new System.Drawing.Point(14, 133);
            this.dgvDSChungTu.MultiSelect = false;
            this.dgvDSChungTu.Name = "dgvDSChungTu";
            this.dgvDSChungTu.ReadOnly = true;
            this.dgvDSChungTu.Size = new System.Drawing.Size(500, 420);
            this.dgvDSChungTu.TabIndex = 8;
            this.dgvDSChungTu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSChungTu_CellContentClick);
            this.dgvDSChungTu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSChungTu_RowPostPaint);
            // 
            // MaLCT
            // 
            this.MaLCT.DataPropertyName = "MaLCT";
            this.MaLCT.HeaderText = "MaLCT";
            this.MaLCT.Name = "MaLCT";
            this.MaLCT.ReadOnly = true;
            this.MaLCT.Visible = false;
            // 
            // KyHieuLCT
            // 
            this.KyHieuLCT.DataPropertyName = "KyHieuLCT";
            this.KyHieuLCT.HeaderText = "Ký Hiệu";
            this.KyHieuLCT.Name = "KyHieuLCT";
            this.KyHieuLCT.ReadOnly = true;
            // 
            // TenLCT
            // 
            this.TenLCT.DataPropertyName = "TenLCT";
            this.TenLCT.HeaderText = "Tên Loại Chứng Từ";
            this.TenLCT.Name = "TenLCT";
            this.TenLCT.ReadOnly = true;
            this.TenLCT.Width = 300;
            // 
            // ThoiHan
            // 
            this.ThoiHan.DataPropertyName = "ThoiHan";
            this.ThoiHan.HeaderText = "Thời Hạn";
            this.ThoiHan.Name = "ThoiHan";
            this.ThoiHan.ReadOnly = true;
            this.ThoiHan.Width = 50;
            // 
            // txtThoiHan
            // 
            this.txtThoiHan.Location = new System.Drawing.Point(189, 69);
            this.txtThoiHan.Name = "txtThoiHan";
            this.txtThoiHan.Size = new System.Drawing.Size(201, 22);
            this.txtThoiHan.TabIndex = 5;
            this.txtThoiHan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThoiHan_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPhimTat);
            this.groupBox1.Location = new System.Drawing.Point(520, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 540);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bộ phím tắt";
            // 
            // dgvPhimTat
            // 
            this.dgvPhimTat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhimTat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.KyHieu,
            this.NoiDung});
            this.dgvPhimTat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhimTat.Location = new System.Drawing.Point(3, 18);
            this.dgvPhimTat.Name = "dgvPhimTat";
            this.dgvPhimTat.Size = new System.Drawing.Size(458, 519);
            this.dgvPhimTat.TabIndex = 0;
            this.dgvPhimTat.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhimTat_CellEndEdit);
            this.dgvPhimTat.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhimTat_RowEnter);
            this.dgvPhimTat.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhimTat_RowLeave);
            this.dgvPhimTat.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPhimTat_RowPostPaint);
            this.dgvPhimTat.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvPhimTat_UserDeletingRow);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // KyHieu
            // 
            this.KyHieu.DataPropertyName = "KyHieu";
            this.KyHieu.HeaderText = "Ký Hiệu";
            this.KyHieu.Name = "KyHieu";
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 300;
            // 
            // frmLoaiChungTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1258, 564);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDSChungTu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtThoiHan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenLCT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKyHieuLCT);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmLoaiChungTu";
            this.Text = "Loại Chứng Từ";
            this.Load += new System.EventHandler(this.frmCapNhatChungTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChungTu)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhimTat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKyHieuLCT;
        private System.Windows.Forms.TextBox txtTenLCT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvDSChungTu;
        private System.Windows.Forms.TextBox txtThoiHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieuLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiHan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPhimTat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
    }
}