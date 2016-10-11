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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.Controls.Add(this.btnXoaHienTrangKT);
            this.groupBox1.Controls.Add(this.dgvDSHienTrangKT);
            this.groupBox1.Controls.Add(this.btnSuaHienTrangKT);
            this.groupBox1.Controls.Add(this.btnThemHienTrangKT);
            this.groupBox1.Controls.Add(this.txtHienTrangKT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 585);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiện Trạng Kiểm Tra";
            // 
            // btnXoaHienTrangKT
            // 
            this.btnXoaHienTrangKT.Location = new System.Drawing.Point(371, 48);
            this.btnXoaHienTrangKT.Name = "btnXoaHienTrangKT";
            this.btnXoaHienTrangKT.Size = new System.Drawing.Size(75, 25);
            this.btnXoaHienTrangKT.TabIndex = 87;
            this.btnXoaHienTrangKT.Text = "Xóa";
            this.btnXoaHienTrangKT.UseVisualStyleBackColor = true;
            this.btnXoaHienTrangKT.Click += new System.EventHandler(this.btnXoaHienTrangKT_Click);
            // 
            // dgvDSHienTrangKT
            // 
            this.dgvDSHienTrangKT.AllowUserToAddRows = false;
            this.dgvDSHienTrangKT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSHienTrangKT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSHienTrangKT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHienTrangKT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHTKT,
            this.TenHTKT});
            this.dgvDSHienTrangKT.Location = new System.Drawing.Point(6, 79);
            this.dgvDSHienTrangKT.MultiSelect = false;
            this.dgvDSHienTrangKT.Name = "dgvDSHienTrangKT";
            this.dgvDSHienTrangKT.Size = new System.Drawing.Size(462, 500);
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
            // btnSuaHienTrangKT
            // 
            this.btnSuaHienTrangKT.Location = new System.Drawing.Point(290, 48);
            this.btnSuaHienTrangKT.Name = "btnSuaHienTrangKT";
            this.btnSuaHienTrangKT.Size = new System.Drawing.Size(75, 25);
            this.btnSuaHienTrangKT.TabIndex = 7;
            this.btnSuaHienTrangKT.Text = "Sửa";
            this.btnSuaHienTrangKT.UseVisualStyleBackColor = true;
            this.btnSuaHienTrangKT.Click += new System.EventHandler(this.btnSuaHienTrangKT_Click);
            // 
            // btnThemHienTrangKT
            // 
            this.btnThemHienTrangKT.Location = new System.Drawing.Point(209, 48);
            this.btnThemHienTrangKT.Name = "btnThemHienTrangKT";
            this.btnThemHienTrangKT.Size = new System.Drawing.Size(75, 25);
            this.btnThemHienTrangKT.TabIndex = 6;
            this.btnThemHienTrangKT.Text = "Thêm";
            this.btnThemHienTrangKT.UseVisualStyleBackColor = true;
            this.btnThemHienTrangKT.Click += new System.EventHandler(this.btnThemHienTrangKT_Click);
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
            this.ClientSize = new System.Drawing.Size(498, 609);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmHienTrangKiemTra";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHTKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHTKT;
    }
}