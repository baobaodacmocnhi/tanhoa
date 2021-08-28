namespace ThuTien.GUI.QuanTri
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
            this.DongNuoc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TuCuonGCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenCuonGCS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.An = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtTuCuonGCS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDenCuonGCS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkHanhThu = new System.Windows.Forms.CheckBox();
            this.chkDongNuoc = new System.Windows.Forms.CheckBox();
            this.chkAn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTo)).BeginInit();
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
            this.txtTenTo.Location = new System.Drawing.Point(91, 12);
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
            this.DongNuoc,
            this.TuCuonGCS,
            this.DenCuonGCS,
            this.An});
            this.dgvTo.Location = new System.Drawing.Point(15, 99);
            this.dgvTo.MultiSelect = false;
            this.dgvTo.Name = "dgvTo";
            this.dgvTo.ReadOnly = true;
            this.dgvTo.Size = new System.Drawing.Size(491, 319);
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
            this.HanhThu.Width = 50;
            // 
            // DongNuoc
            // 
            this.DongNuoc.DataPropertyName = "DongNuoc";
            this.DongNuoc.HeaderText = "Đóng Nước";
            this.DongNuoc.Name = "DongNuoc";
            this.DongNuoc.ReadOnly = true;
            this.DongNuoc.Width = 50;
            // 
            // TuCuonGCS
            // 
            this.TuCuonGCS.DataPropertyName = "TuCuonGCS";
            this.TuCuonGCS.HeaderText = "Từ CuonGCS";
            this.TuCuonGCS.Name = "TuCuonGCS";
            this.TuCuonGCS.ReadOnly = true;
            // 
            // DenCuonGCS
            // 
            this.DenCuonGCS.DataPropertyName = "DenCuonGCS";
            this.DenCuonGCS.HeaderText = "Đến CuonGCS";
            this.DenCuonGCS.Name = "DenCuonGCS";
            this.DenCuonGCS.ReadOnly = true;
            // 
            // An
            // 
            this.An.DataPropertyName = "An";
            this.An.HeaderText = "Ẩn";
            this.An.Name = "An";
            this.An.ReadOnly = true;
            this.An.Width = 30;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(407, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(407, 41);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(407, 70);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtTuCuonGCS
            // 
            this.txtTuCuonGCS.Location = new System.Drawing.Point(91, 61);
            this.txtTuCuonGCS.Name = "txtTuCuonGCS";
            this.txtTuCuonGCS.Size = new System.Drawing.Size(100, 20);
            this.txtTuCuonGCS.TabIndex = 3;
            this.txtTuCuonGCS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuonGCS_From_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ CuonGCS:";
            // 
            // txtDenCuonGCS
            // 
            this.txtDenCuonGCS.Location = new System.Drawing.Point(283, 61);
            this.txtDenCuonGCS.Name = "txtDenCuonGCS";
            this.txtDenCuonGCS.Size = new System.Drawing.Size(100, 20);
            this.txtDenCuonGCS.TabIndex = 5;
            this.txtDenCuonGCS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuonGCS_To_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến CuonGCS:";
            // 
            // chkHanhThu
            // 
            this.chkHanhThu.AutoSize = true;
            this.chkHanhThu.Location = new System.Drawing.Point(91, 38);
            this.chkHanhThu.Name = "chkHanhThu";
            this.chkHanhThu.Size = new System.Drawing.Size(74, 17);
            this.chkHanhThu.TabIndex = 10;
            this.chkHanhThu.Text = "Hành Thu";
            this.chkHanhThu.UseVisualStyleBackColor = true;
            // 
            // chkDongNuoc
            // 
            this.chkDongNuoc.AutoSize = true;
            this.chkDongNuoc.Location = new System.Drawing.Point(171, 38);
            this.chkDongNuoc.Name = "chkDongNuoc";
            this.chkDongNuoc.Size = new System.Drawing.Size(81, 17);
            this.chkDongNuoc.TabIndex = 11;
            this.chkDongNuoc.Text = "Đóng Nước";
            this.chkDongNuoc.UseVisualStyleBackColor = true;
            // 
            // chkAn
            // 
            this.chkAn.AutoSize = true;
            this.chkAn.Location = new System.Drawing.Point(258, 38);
            this.chkAn.Name = "chkAn";
            this.chkAn.Size = new System.Drawing.Size(39, 17);
            this.chkAn.TabIndex = 12;
            this.chkAn.Text = "Ẩn";
            this.chkAn.UseVisualStyleBackColor = true;
            // 
            // frmTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(561, 430);
            this.Controls.Add(this.chkAn);
            this.Controls.Add(this.chkDongNuoc);
            this.Controls.Add(this.chkHanhThu);
            this.Controls.Add(this.txtDenCuonGCS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTuCuonGCS);
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
        private System.Windows.Forms.TextBox txtTuCuonGCS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDenCuonGCS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkHanhThu;
        private System.Windows.Forms.CheckBox chkDongNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DongNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuCuonGCS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenCuonGCS;
        private System.Windows.Forms.DataGridViewCheckBoxColumn An;
        private System.Windows.Forms.CheckBox chkAn;
    }
}