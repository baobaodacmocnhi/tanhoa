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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDownHienTrangKT = new System.Windows.Forms.Button();
            this.btnUpHienTrangKT = new System.Windows.Forms.Button();
            this.btnXoaHienTrangKT = new System.Windows.Forms.Button();
            this.dgvDSHienTrangKT = new System.Windows.Forms.DataGridView();
            this.MaHTKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHTKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSuaHienTrangKT = new System.Windows.Forms.Button();
            this.btnThemHienTrangKT = new System.Windows.Forms.Button();
            this.txtHienTrangKT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHienTrangKT)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDownHienTrangKT);
            this.groupBox1.Controls.Add(this.btnUpHienTrangKT);
            this.groupBox1.Controls.Add(this.btnXoaHienTrangKT);
            this.groupBox1.Controls.Add(this.dgvDSHienTrangKT);
            this.groupBox1.Controls.Add(this.btnSuaHienTrangKT);
            this.groupBox1.Controls.Add(this.btnThemHienTrangKT);
            this.groupBox1.Controls.Add(this.txtHienTrangKT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(54, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiện Trạng Kiểm Tra";
            // 
            // btnDownHienTrangKT
            // 
            this.btnDownHienTrangKT.Location = new System.Drawing.Point(87, 47);
            this.btnDownHienTrangKT.Name = "btnDownHienTrangKT";
            this.btnDownHienTrangKT.Size = new System.Drawing.Size(75, 23);
            this.btnDownHienTrangKT.TabIndex = 89;
            this.btnDownHienTrangKT.Text = "Down";
            this.btnDownHienTrangKT.UseVisualStyleBackColor = true;
            this.btnDownHienTrangKT.Click += new System.EventHandler(this.btnDownHienTrangKT_Click);
            // 
            // btnUpHienTrangKT
            // 
            this.btnUpHienTrangKT.Location = new System.Drawing.Point(6, 47);
            this.btnUpHienTrangKT.Name = "btnUpHienTrangKT";
            this.btnUpHienTrangKT.Size = new System.Drawing.Size(75, 23);
            this.btnUpHienTrangKT.TabIndex = 88;
            this.btnUpHienTrangKT.Text = "Up";
            this.btnUpHienTrangKT.UseVisualStyleBackColor = true;
            this.btnUpHienTrangKT.Click += new System.EventHandler(this.btnUpHienTrangKT_Click);
            // 
            // btnXoaHienTrangKT
            // 
            this.btnXoaHienTrangKT.Location = new System.Drawing.Point(396, 47);
            this.btnXoaHienTrangKT.Name = "btnXoaHienTrangKT";
            this.btnXoaHienTrangKT.Size = new System.Drawing.Size(75, 23);
            this.btnXoaHienTrangKT.TabIndex = 87;
            this.btnXoaHienTrangKT.Text = "Xóa";
            this.btnXoaHienTrangKT.UseVisualStyleBackColor = true;
            this.btnXoaHienTrangKT.Click += new System.EventHandler(this.btnXoaHienTrangKT_Click);
            // 
            // dgvDSHienTrangKT
            // 
            this.dgvDSHienTrangKT.AllowUserToAddRows = false;
            this.dgvDSHienTrangKT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSHienTrangKT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDSHienTrangKT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHienTrangKT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHTKT,
            this.TenHTKT});
            this.dgvDSHienTrangKT.Location = new System.Drawing.Point(6, 76);
            this.dgvDSHienTrangKT.MultiSelect = false;
            this.dgvDSHienTrangKT.Name = "dgvDSHienTrangKT";
            this.dgvDSHienTrangKT.Size = new System.Drawing.Size(468, 395);
            this.dgvDSHienTrangKT.TabIndex = 8;
            this.dgvDSHienTrangKT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHienTrangKT_CellContentClick);
            this.dgvDSHienTrangKT.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSHienTrangKT_RowPostPaint);
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
            // btnSuaHienTrangKT
            // 
            this.btnSuaHienTrangKT.Location = new System.Drawing.Point(315, 47);
            this.btnSuaHienTrangKT.Name = "btnSuaHienTrangKT";
            this.btnSuaHienTrangKT.Size = new System.Drawing.Size(75, 23);
            this.btnSuaHienTrangKT.TabIndex = 7;
            this.btnSuaHienTrangKT.Text = "Sửa";
            this.btnSuaHienTrangKT.UseVisualStyleBackColor = true;
            this.btnSuaHienTrangKT.Click += new System.EventHandler(this.btnSuaHienTrangKT_Click);
            // 
            // btnThemHienTrangKT
            // 
            this.btnThemHienTrangKT.Location = new System.Drawing.Point(234, 47);
            this.btnThemHienTrangKT.Name = "btnThemHienTrangKT";
            this.btnThemHienTrangKT.Size = new System.Drawing.Size(75, 23);
            this.btnThemHienTrangKT.TabIndex = 6;
            this.btnThemHienTrangKT.Text = "Thêm";
            this.btnThemHienTrangKT.UseVisualStyleBackColor = true;
            this.btnThemHienTrangKT.Click += new System.EventHandler(this.btnThemHienTrangKT_Click);
            // 
            // txtHienTrangKT
            // 
            this.txtHienTrangKT.Location = new System.Drawing.Point(144, 19);
            this.txtHienTrangKT.Name = "txtHienTrangKT";
            this.txtHienTrangKT.Size = new System.Drawing.Size(246, 21);
            this.txtHienTrangKT.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hiện Trạng Kiểm Tra:";
            // 
            // frmThongTin_KT_BC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1019, 515);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongTin_KT_BC";
            this.Text = "Thông Tin Hiện Trạng KT/ Trạng Thái BC";
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
        private System.Windows.Forms.Button btnSuaHienTrangKT;
        private System.Windows.Forms.Button btnThemHienTrangKT;
        private System.Windows.Forms.DataGridView dgvDSHienTrangKT;
        private System.Windows.Forms.Button btnXoaHienTrangKT;
        private System.Windows.Forms.Button btnDownHienTrangKT;
        private System.Windows.Forms.Button btnUpHienTrangKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHTKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHTKT;
    }
}