namespace KeToan.GUI.CapNhat
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
            this.txtSoTK_Co = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoTK_No = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTK_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTK_Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNganHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên Ngân Hàng:";
            // 
            // txtTenNH
            // 
            this.txtTenNH.Location = new System.Drawing.Point(103, 12);
            this.txtTenNH.Name = "txtTenNH";
            this.txtTenNH.Size = new System.Drawing.Size(200, 20);
            this.txtTenNH.TabIndex = 3;
            // 
            // dgvNganHang
            // 
            this.dgvNganHang.AllowUserToAddRows = false;
            this.dgvNganHang.AllowUserToDeleteRows = false;
            this.dgvNganHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNganHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Namee,
            this.KyHieu,
            this.SoTK_No,
            this.SoTK_Co});
            this.dgvNganHang.Location = new System.Drawing.Point(12, 116);
            this.dgvNganHang.MultiSelect = false;
            this.dgvNganHang.Name = "dgvNganHang";
            this.dgvNganHang.ReadOnly = true;
            this.dgvNganHang.Size = new System.Drawing.Size(511, 378);
            this.dgvNganHang.TabIndex = 9;
            this.dgvNganHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNganHang_CellContentClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(309, 70);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(309, 41);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(309, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtKyHieu
            // 
            this.txtKyHieu.Location = new System.Drawing.Point(103, 38);
            this.txtKyHieu.Name = "txtKyHieu";
            this.txtKyHieu.Size = new System.Drawing.Size(200, 20);
            this.txtKyHieu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ký Hiệu:";
            // 
            // txtSoTK_Co
            // 
            this.txtSoTK_Co.Location = new System.Drawing.Point(103, 64);
            this.txtSoTK_Co.Name = "txtSoTK_Co";
            this.txtSoTK_Co.Size = new System.Drawing.Size(200, 20);
            this.txtSoTK_Co.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số TK Có:";
            // 
            // txtSoTK_No
            // 
            this.txtSoTK_No.Location = new System.Drawing.Point(103, 90);
            this.txtSoTK_No.Name = "txtSoTK_No";
            this.txtSoTK_No.Size = new System.Drawing.Size(200, 20);
            this.txtSoTK_No.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Số TK Nợ:";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Namee
            // 
            this.Namee.DataPropertyName = "Name";
            this.Namee.HeaderText = "Tên Ngân Hàng";
            this.Namee.Name = "Namee";
            this.Namee.ReadOnly = true;
            this.Namee.Width = 150;
            // 
            // KyHieu
            // 
            this.KyHieu.DataPropertyName = "KyHieu";
            this.KyHieu.HeaderText = "Ký Hiệu";
            this.KyHieu.Name = "KyHieu";
            this.KyHieu.ReadOnly = true;
            // 
            // SoTK_No
            // 
            this.SoTK_No.DataPropertyName = "SoTK_No";
            this.SoTK_No.HeaderText = "Số TK Nợ";
            this.SoTK_No.Name = "SoTK_No";
            this.SoTK_No.ReadOnly = true;
            // 
            // SoTK_Co
            // 
            this.SoTK_Co.DataPropertyName = "SoTK_Co";
            this.SoTK_Co.HeaderText = "Số TK Có";
            this.SoTK_Co.Name = "SoTK_Co";
            this.SoTK_Co.ReadOnly = true;
            // 
            // frmNganHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 614);
            this.Controls.Add(this.txtSoTK_No);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSoTK_Co);
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
        private System.Windows.Forms.TextBox txtSoTK_Co;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoTK_No;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namee;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTK_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTK_Co;
    }
}