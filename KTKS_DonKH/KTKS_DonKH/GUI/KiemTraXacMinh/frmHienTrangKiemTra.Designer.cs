namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    partial class frmHienTrangKiemTra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvDSHienTrangKT = new System.Windows.Forms.DataGridView();
            this.MaHTKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHTKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtHienTrangKT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHienTrangKT)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.dgvDSHienTrangKT);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtHienTrangKT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 612);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiện Trạng Kiểm Tra";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(371, 48);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 87;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvDSHienTrangKT
            // 
            this.dgvDSHienTrangKT.AllowDrop = true;
            this.dgvDSHienTrangKT.AllowUserToAddRows = false;
            this.dgvDSHienTrangKT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSHienTrangKT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSHienTrangKT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHienTrangKT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHTKT,
            this.TenHTKT});
            this.dgvDSHienTrangKT.Location = new System.Drawing.Point(6, 79);
            this.dgvDSHienTrangKT.MultiSelect = false;
            this.dgvDSHienTrangKT.Name = "dgvDSHienTrangKT";
            this.dgvDSHienTrangKT.Size = new System.Drawing.Size(462, 527);
            this.dgvDSHienTrangKT.TabIndex = 8;
            this.dgvDSHienTrangKT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHienTrangKT_CellContentClick);
            this.dgvDSHienTrangKT.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSHienTrangKT_RowPostPaint);
            this.dgvDSHienTrangKT.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvDSHienTrangKT_DragDrop);
            this.dgvDSHienTrangKT.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvDSHienTrangKT_DragEnter);
            this.dgvDSHienTrangKT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDSHienTrangKT_MouseClick);
            // 
            // MaHTKT
            // 
            this.MaHTKT.DataPropertyName = "MaHTKT";
            this.MaHTKT.HeaderText = "MaHTKT";
            this.MaHTKT.Name = "MaHTKT";
            this.MaHTKT.Visible = false;
            // 
            // TenHTKT
            // 
            this.TenHTKT.DataPropertyName = "TenHTKT";
            this.TenHTKT.HeaderText = "Hiện Trạng Kiểm Tra";
            this.TenHTKT.Name = "TenHTKT";
            this.TenHTKT.ReadOnly = true;
            this.TenHTKT.Width = 400;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(290, 48);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(209, 48);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtHienTrangKT
            // 
            this.txtHienTrangKT.Location = new System.Drawing.Point(165, 20);
            this.txtHienTrangKT.Name = "txtHienTrangKT";
            this.txtHienTrangKT.Size = new System.Drawing.Size(281, 22);
            this.txtHienTrangKT.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hiện Trạng Kiểm Tra:";
            // 
            // frmHienTrangKiemTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(498, 656);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmHienTrangKiemTra";
            this.Text = "Thông Tin Hiện Trạng Kiểm Tra";
            this.Load += new System.EventHandler(this.frmThongTin_KT_BC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHienTrangKT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHienTrangKT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvDSHienTrangKT;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHTKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHTKT;
    }
}