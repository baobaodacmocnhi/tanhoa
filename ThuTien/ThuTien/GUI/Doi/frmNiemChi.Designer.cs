namespace ThuTien.GUI.Doi
{
    partial class frmNiemChi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTuSo = new System.Windows.Forms.TextBox();
            this.txtDenSo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvNiemChi = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLSuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSLNhap = new System.Windows.Forms.TextBox();
            this.txtSLSuDung = new System.Windows.Forms.TextBox();
            this.txtSLTon = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNiemChi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSLTon);
            this.groupBox1.Controls.Add(this.txtSLSuDung);
            this.groupBox1.Controls.Add(this.txtSLNhap);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.dgvNiemChi);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDenSo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTuSo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 633);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Kho";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ Số";
            // 
            // txtTuSo
            // 
            this.txtTuSo.Location = new System.Drawing.Point(69, 19);
            this.txtTuSo.Name = "txtTuSo";
            this.txtTuSo.Size = new System.Drawing.Size(100, 20);
            this.txtTuSo.TabIndex = 1;
            this.txtTuSo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTuSo_KeyPress);
            // 
            // txtDenSo
            // 
            this.txtDenSo.Location = new System.Drawing.Point(69, 45);
            this.txtDenSo.Name = "txtDenSo";
            this.txtDenSo.Size = new System.Drawing.Size(100, 20);
            this.txtDenSo.TabIndex = 3;
            this.txtDenSo.TextChanged += new System.EventHandler(this.txtDenSo_TextChanged);
            this.txtDenSo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenSo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến Số";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(69, 71);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuong.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số Lượng";
            // 
            // dgvNiemChi
            // 
            this.dgvNiemChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNiemChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreateDate,
            this.TuSo,
            this.DenSo,
            this.SLNhap,
            this.SLSuDung,
            this.SLTon});
            this.dgvNiemChi.Location = new System.Drawing.Point(6, 104);
            this.dgvNiemChi.Name = "dgvNiemChi";
            this.dgvNiemChi.Size = new System.Drawing.Size(454, 500);
            this.dgvNiemChi.TabIndex = 6;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(175, 17);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(175, 46);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(175, 75);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Nhập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
            // 
            // TuSo
            // 
            this.TuSo.DataPropertyName = "TuSo";
            this.TuSo.HeaderText = "Từ Số";
            this.TuSo.Name = "TuSo";
            this.TuSo.Width = 80;
            // 
            // DenSo
            // 
            this.DenSo.DataPropertyName = "DenSo";
            this.DenSo.HeaderText = "Đến Số";
            this.DenSo.Name = "DenSo";
            this.DenSo.Width = 80;
            // 
            // SLNhap
            // 
            this.SLNhap.DataPropertyName = "SLNhap";
            this.SLNhap.HeaderText = "Nhập";
            this.SLNhap.Name = "SLNhap";
            this.SLNhap.Width = 50;
            // 
            // SLSuDung
            // 
            this.SLSuDung.DataPropertyName = "SLSuDung";
            this.SLSuDung.HeaderText = "Sử Dụng";
            this.SLSuDung.Name = "SLSuDung";
            this.SLSuDung.Width = 50;
            // 
            // SLTon
            // 
            this.SLTon.DataPropertyName = "SLTon";
            this.SLTon.HeaderText = "Tồn";
            this.SLTon.Name = "SLTon";
            this.SLTon.Width = 50;
            // 
            // txtSLNhap
            // 
            this.txtSLNhap.Location = new System.Drawing.Point(288, 604);
            this.txtSLNhap.Name = "txtSLNhap";
            this.txtSLNhap.Size = new System.Drawing.Size(50, 20);
            this.txtSLNhap.TabIndex = 10;
            // 
            // txtSLSuDung
            // 
            this.txtSLSuDung.Location = new System.Drawing.Point(338, 604);
            this.txtSLSuDung.Name = "txtSLSuDung";
            this.txtSLSuDung.Size = new System.Drawing.Size(50, 20);
            this.txtSLSuDung.TabIndex = 11;
            // 
            // txtSLTon
            // 
            this.txtSLTon.Location = new System.Drawing.Point(388, 604);
            this.txtSLTon.Name = "txtSLTon";
            this.txtSLTon.Size = new System.Drawing.Size(50, 20);
            this.txtSLTon.TabIndex = 12;
            // 
            // frmNiemChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 657);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmNiemChi";
            this.Text = "Quản Lý Niêm Chì";
            this.Load += new System.EventHandler(this.frmNiemChi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNiemChi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDenSo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTuSo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvNiemChi;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLSuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLTon;
        private System.Windows.Forms.TextBox txtSLTon;
        private System.Windows.Forms.TextBox txtSLSuDung;
        private System.Windows.Forms.TextBox txtSLNhap;
    }
}