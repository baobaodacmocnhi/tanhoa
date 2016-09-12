namespace KTKS_DonKH.GUI.CapNhat
{
    partial class frmChiNhanh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenCN = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvDSChiNhanh = new System.Windows.Forms.DataGridView();
            this.MaCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChiNhanh)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Chi Nhánh:";
            // 
            // txtTenCN
            // 
            this.txtTenCN.Location = new System.Drawing.Point(111, 11);
            this.txtTenCN.Name = "txtTenCN";
            this.txtTenCN.Size = new System.Drawing.Size(350, 21);
            this.txtTenCN.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(152, 38);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(233, 38);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvDSChiNhanh
            // 
            this.dgvDSChiNhanh.AllowUserToAddRows = false;
            this.dgvDSChiNhanh.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSChiNhanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSChiNhanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSChiNhanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCN,
            this.TenCN});
            this.dgvDSChiNhanh.Location = new System.Drawing.Point(10, 69);
            this.dgvDSChiNhanh.Name = "dgvDSChiNhanh";
            this.dgvDSChiNhanh.ReadOnly = true;
            this.dgvDSChiNhanh.Size = new System.Drawing.Size(464, 218);
            this.dgvDSChiNhanh.TabIndex = 4;
            this.dgvDSChiNhanh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSChiNhanh_CellContentClick);
            this.dgvDSChiNhanh.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSChiNhanh_RowPostPaint);
            // 
            // MaCN
            // 
            this.MaCN.DataPropertyName = "MaCN";
            this.MaCN.HeaderText = "Mã Chi Nhánh";
            this.MaCN.Name = "MaCN";
            this.MaCN.ReadOnly = true;
            this.MaCN.Visible = false;
            // 
            // TenCN
            // 
            this.TenCN.DataPropertyName = "TenCN";
            this.TenCN.HeaderText = "Tên Chi Nhánh";
            this.TenCN.Name = "TenCN";
            this.TenCN.ReadOnly = true;
            this.TenCN.Width = 400;
            // 
            // frmChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(486, 303);
            this.Controls.Add(this.dgvDSChiNhanh);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTenCN);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChiNhanh";
            this.Text = "Chi Nhánh";
            this.Load += new System.EventHandler(this.frmChiNhanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChiNhanh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenCN;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvDSChiNhanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCN;
    }
}