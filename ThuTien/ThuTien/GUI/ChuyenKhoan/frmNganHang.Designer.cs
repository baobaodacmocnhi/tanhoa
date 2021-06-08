namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmNganHang
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
            this.txtTenNH = new System.Windows.Forms.TextBox();
            this.dgvNganHang = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtKyHieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoTK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGroupBank = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNganHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên Ngân Hàng:";
            // 
            // txtTenNH
            // 
            this.txtTenNH.Location = new System.Drawing.Point(103, 38);
            this.txtTenNH.Name = "txtTenNH";
            this.txtTenNH.Size = new System.Drawing.Size(280, 20);
            this.txtTenNH.TabIndex = 3;
            // 
            // dgvNganHang
            // 
            this.dgvNganHang.AllowUserToAddRows = false;
            this.dgvNganHang.AllowUserToDeleteRows = false;
            this.dgvNganHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNganHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNH,
            this.KyHieu,
            this.TenNH,
            this.SoTK,
            this.GroupBank});
            this.dgvNganHang.Location = new System.Drawing.Point(12, 116);
            this.dgvNganHang.MultiSelect = false;
            this.dgvNganHang.Name = "dgvNganHang";
            this.dgvNganHang.ReadOnly = true;
            this.dgvNganHang.Size = new System.Drawing.Size(664, 378);
            this.dgvNganHang.TabIndex = 7;
            this.dgvNganHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNganHang_CellContentClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(389, 63);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(389, 34);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(389, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtKyHieu
            // 
            this.txtKyHieu.Location = new System.Drawing.Point(103, 12);
            this.txtKyHieu.Name = "txtKyHieu";
            this.txtKyHieu.Size = new System.Drawing.Size(280, 20);
            this.txtKyHieu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ký Hiệu:";
            // 
            // txtSoTK
            // 
            this.txtSoTK.Location = new System.Drawing.Point(103, 64);
            this.txtSoTK.Name = "txtSoTK";
            this.txtSoTK.Size = new System.Drawing.Size(280, 20);
            this.txtSoTK.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Số TK:";
            // 
            // MaNH
            // 
            this.MaNH.DataPropertyName = "MaNH";
            this.MaNH.HeaderText = "MaNH";
            this.MaNH.Name = "MaNH";
            this.MaNH.ReadOnly = true;
            this.MaNH.Visible = false;
            // 
            // KyHieu
            // 
            this.KyHieu.DataPropertyName = "KyHieu";
            this.KyHieu.HeaderText = "Ký Hiệu";
            this.KyHieu.Name = "KyHieu";
            this.KyHieu.ReadOnly = true;
            // 
            // TenNH
            // 
            this.TenNH.DataPropertyName = "TenNH";
            this.TenNH.HeaderText = "Tên Ngân Hàng";
            this.TenNH.Name = "TenNH";
            this.TenNH.ReadOnly = true;
            this.TenNH.Width = 200;
            // 
            // SoTK
            // 
            this.SoTK.DataPropertyName = "SoTK";
            this.SoTK.HeaderText = "Số TK";
            this.SoTK.Name = "SoTK";
            this.SoTK.ReadOnly = true;
            this.SoTK.Width = 200;
            // 
            // GroupBank
            // 
            this.GroupBank.DataPropertyName = "GroupBank";
            this.GroupBank.HeaderText = "Group Bank";
            this.GroupBank.Name = "GroupBank";
            this.GroupBank.ReadOnly = true;
            // 
            // txtGroupBank
            // 
            this.txtGroupBank.Location = new System.Drawing.Point(103, 90);
            this.txtGroupBank.Name = "txtGroupBank";
            this.txtGroupBank.Size = new System.Drawing.Size(280, 20);
            this.txtGroupBank.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Group Bank";
            // 
            // frmNganHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 583);
            this.Controls.Add(this.txtGroupBank);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSoTK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKyHieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvNganHang);
            this.Controls.Add(this.txtTenNH);
            this.Controls.Add(this.label1);
            this.Name = "frmNganHang";
            this.Text = "Ngân Hàng";
            this.Load += new System.EventHandler(this.frmNganHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNganHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNH;
        private System.Windows.Forms.DataGridView dgvNganHang;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtKyHieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoTK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupBank;
        private System.Windows.Forms.TextBox txtGroupBank;
        private System.Windows.Forms.Label label4;
    }
}