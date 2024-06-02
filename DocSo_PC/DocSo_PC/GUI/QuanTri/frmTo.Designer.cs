namespace DocSo_PC.GUI.QuanTri
{
    partial class frmTo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenTo = new System.Windows.Forms.TextBox();
            this.dgvTo = new System.Windows.Forms.DataGridView();
            this.MaTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TuMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtTuMay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDenMay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkHanhThu = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbPhong = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Tổ:";
            // 
            // txtTenTo
            // 
            this.txtTenTo.Location = new System.Drawing.Point(63, 12);
            this.txtTenTo.Name = "txtTenTo";
            this.txtTenTo.Size = new System.Drawing.Size(100, 20);
            this.txtTenTo.TabIndex = 1;
            // 
            // dgvTo
            // 
            this.dgvTo.AllowUserToAddRows = false;
            this.dgvTo.AllowUserToDeleteRows = false;
            this.dgvTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTo,
            this.TenTo,
            this.HanhThu,
            this.TuMay,
            this.DenMay});
            this.dgvTo.Location = new System.Drawing.Point(15, 99);
            this.dgvTo.MultiSelect = false;
            this.dgvTo.Name = "dgvTo";
            this.dgvTo.ReadOnly = true;
            this.dgvTo.Size = new System.Drawing.Size(467, 319);
            this.dgvTo.TabIndex = 9;
            this.dgvTo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTo_CellClick);
            this.dgvTo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTo_RowPostPaint);
            // 
            // MaTo
            // 
            this.MaTo.DataPropertyName = "MaTo";
            this.MaTo.HeaderText = "MaTo";
            this.MaTo.Name = "MaTo";
            this.MaTo.ReadOnly = true;
            this.MaTo.Visible = false;
            // 
            // TenTo
            // 
            this.TenTo.DataPropertyName = "TenTo";
            this.TenTo.HeaderText = "Tên Tổ";
            this.TenTo.Name = "TenTo";
            this.TenTo.ReadOnly = true;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "Hành Thu";
            this.HanhThu.Name = "HanhThu";
            this.HanhThu.ReadOnly = true;
            // 
            // TuMay
            // 
            this.TuMay.DataPropertyName = "TuMay";
            this.TuMay.HeaderText = "Từ Máy";
            this.TuMay.Name = "TuMay";
            this.TuMay.ReadOnly = true;
            // 
            // DenMay
            // 
            this.DenMay.DataPropertyName = "DenMay";
            this.DenMay.HeaderText = "Đến Máy";
            this.DenMay.Name = "DenMay";
            this.DenMay.ReadOnly = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(248, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(248, 41);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(248, 70);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtTuMay
            // 
            this.txtTuMay.Location = new System.Drawing.Point(63, 61);
            this.txtTuMay.Name = "txtTuMay";
            this.txtTuMay.Size = new System.Drawing.Size(50, 20);
            this.txtTuMay.TabIndex = 3;
            this.txtTuMay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuonGCS_From_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ Máy:";
            // 
            // txtDenMay
            // 
            this.txtDenMay.Location = new System.Drawing.Point(178, 61);
            this.txtDenMay.Name = "txtDenMay";
            this.txtDenMay.Size = new System.Drawing.Size(50, 20);
            this.txtDenMay.TabIndex = 5;
            this.txtDenMay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuonGCS_To_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến Máy:";
            // 
            // chkHanhThu
            // 
            this.chkHanhThu.AutoSize = true;
            this.chkHanhThu.Location = new System.Drawing.Point(63, 38);
            this.chkHanhThu.Name = "chkHanhThu";
            this.chkHanhThu.Size = new System.Drawing.Size(74, 17);
            this.chkHanhThu.TabIndex = 10;
            this.chkHanhThu.Text = "Hành Thu";
            this.chkHanhThu.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXem);
            this.panel1.Controls.Add(this.cmbPhong);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(329, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 78);
            this.panel1.TabIndex = 42;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(6, 49);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 41;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbPhong
            // 
            this.cmbPhong.FormattingEnabled = true;
            this.cmbPhong.Location = new System.Drawing.Point(6, 22);
            this.cmbPhong.Name = "cmbPhong";
            this.cmbPhong.Size = new System.Drawing.Size(200, 21);
            this.cmbPhong.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Phòng";
            // 
            // frmTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 430);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkHanhThu);
            this.Controls.Add(this.txtDenMay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTuMay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvTo);
            this.Controls.Add(this.txtTenTo);
            this.Controls.Add(this.label1);
            this.Name = "frmTo";
            this.Text = "Tổ";
            this.Load += new System.EventHandler(this.frmTo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenTo;
        private System.Windows.Forms.DataGridView dgvTo;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtTuMay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDenMay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkHanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenMay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbPhong;
        private System.Windows.Forms.Label label11;
    }
}