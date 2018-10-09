namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmKhuCongNghiep
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
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.dgvDanhBo = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtDinhMuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(77, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 1;
            // 
            // dgvDanhBo
            // 
            this.dgvDanhBo.AllowUserToAddRows = false;
            this.dgvDanhBo.AllowUserToDeleteRows = false;
            this.dgvDanhBo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhBo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo,
            this.DinhMuc,
            this.CreateDate});
            this.dgvDanhBo.Location = new System.Drawing.Point(12, 68);
            this.dgvDanhBo.Name = "dgvDanhBo";
            this.dgvDanhBo.Size = new System.Drawing.Size(364, 150);
            this.dgvDanhBo.TabIndex = 2;
            this.dgvDanhBo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhBo_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(183, 11);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(345, 11);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(77, 40);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(100, 22);
            this.txtDinhMuc.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Định Mức";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // DinhMuc
            // 
            this.DinhMuc.DataPropertyName = "DinhMuc";
            this.DinhMuc.HeaderText = "Định Mức";
            this.DinhMuc.Name = "DinhMuc";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(264, 11);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmKhuCongNghiep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(543, 558);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.txtDinhMuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvDanhBo);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKhuCongNghiep";
            this.Text = "Quản Lý Khu Công Nghiệp";
            this.Load += new System.EventHandler(this.frmKhuCongNghiep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhBo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.DataGridView dgvDanhBo;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtDinhMuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.Button btnSua;
    }
}