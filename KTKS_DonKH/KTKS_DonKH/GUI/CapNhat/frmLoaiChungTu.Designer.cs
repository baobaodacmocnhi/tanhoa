namespace KTKS_DonKH.GUI.CapNhat
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChungTu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ký Hiệu Chứng Từ:";
            // 
            // txtKyHieuLCT
            // 
            this.txtKyHieuLCT.Location = new System.Drawing.Point(270, 12);
            this.txtKyHieuLCT.Name = "txtKyHieuLCT";
            this.txtKyHieuLCT.Size = new System.Drawing.Size(200, 25);
            this.txtKyHieuLCT.TabIndex = 1;
            // 
            // txtTenLCT
            // 
            this.txtTenLCT.Location = new System.Drawing.Point(270, 43);
            this.txtTenLCT.Name = "txtTenLCT";
            this.txtTenLCT.Size = new System.Drawing.Size(200, 25);
            this.txtTenLCT.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Chứng Từ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thời Hạn (tháng):";
            // 
            // btnSua
            // 
            this.btnSua.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(404, 107);
            this.btnSua.Margin = new System.Windows.Forms.Padding(5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(66, 35);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Image = global::KTKS_DonKH.Properties.Resources.add_24x24;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(317, 107);
            this.btnThem.Margin = new System.Windows.Forms.Padding(5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(77, 35);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvDSChungTu
            // 
            this.dgvDSChungTu.AllowUserToAddRows = false;
            this.dgvDSChungTu.AllowUserToDeleteRows = false;
            this.dgvDSChungTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSChungTu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLCT,
            this.KyHieuLCT,
            this.TenLCT,
            this.ThoiHan});
            this.dgvDSChungTu.Location = new System.Drawing.Point(12, 150);
            this.dgvDSChungTu.MultiSelect = false;
            this.dgvDSChungTu.Name = "dgvDSChungTu";
            this.dgvDSChungTu.Size = new System.Drawing.Size(644, 196);
            this.dgvDSChungTu.TabIndex = 8;
            this.dgvDSChungTu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSChungTu_CellContentClick);
            this.dgvDSChungTu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSChungTu_RowPostPaint);
            // 
            // MaLCT
            // 
            this.MaLCT.DataPropertyName = "MaLCT";
            this.MaLCT.HeaderText = "MaLCT";
            this.MaLCT.Name = "MaLCT";
            this.MaLCT.Visible = false;
            // 
            // KyHieuLCT
            // 
            this.KyHieuLCT.DataPropertyName = "KyHieuLCT";
            this.KyHieuLCT.HeaderText = "Ký Hiệu Loại Chứng Từ";
            this.KyHieuLCT.Name = "KyHieuLCT";
            this.KyHieuLCT.Width = 150;
            // 
            // TenLCT
            // 
            this.TenLCT.DataPropertyName = "TenLCT";
            this.TenLCT.HeaderText = "Tên Loại Chứng Từ";
            this.TenLCT.Name = "TenLCT";
            this.TenLCT.Width = 300;
            // 
            // ThoiHan
            // 
            this.ThoiHan.DataPropertyName = "ThoiHan";
            this.ThoiHan.HeaderText = "Thời Hạn";
            this.ThoiHan.Name = "ThoiHan";
            this.ThoiHan.Width = 150;
            // 
            // txtThoiHan
            // 
            this.txtThoiHan.Location = new System.Drawing.Point(270, 74);
            this.txtThoiHan.Name = "txtThoiHan";
            this.txtThoiHan.Size = new System.Drawing.Size(200, 25);
            this.txtThoiHan.TabIndex = 5;
            this.txtThoiHan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThoiHan_KeyPress);
            // 
            // frmLoaiChungTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(674, 358);
            this.Controls.Add(this.dgvDSChungTu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtThoiHan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenLCT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKyHieuLCT);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLoaiChungTu";
            this.Text = "frmCapNhatChungTu";
            this.Load += new System.EventHandler(this.frmCapNhatChungTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChungTu)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieuLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiHan;
        private System.Windows.Forms.TextBox txtThoiHan;
    }
}