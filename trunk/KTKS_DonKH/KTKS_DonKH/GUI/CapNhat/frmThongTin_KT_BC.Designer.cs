namespace KTKS_DonKH.GUI.CapNhat
{
    partial class frmThongTin_KT_BC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDSHienTrangKT = new System.Windows.Forms.DataGridView();
            this.MaHTKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHTKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSuaHienTrangKT = new System.Windows.Forms.Button();
            this.btnThemHienTrangKT = new System.Windows.Forms.Button();
            this.txtHienTrangKT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDSTrangThaiBC = new System.Windows.Forms.DataGridView();
            this.MaTTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSuaTrangThaiBC = new System.Windows.Forms.Button();
            this.btnThemTrangThaiBC = new System.Windows.Forms.Button();
            this.txtTrangThaiBC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoaHienTrangKT = new System.Windows.Forms.Button();
            this.btnXoaTrangThaiBC = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHienTrangKT)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTrangThaiBC)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(44, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 548);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiện Trạng Kiểm Tra";
            // 
            // dgvDSHienTrangKT
            // 
            this.dgvDSHienTrangKT.AllowUserToAddRows = false;
            this.dgvDSHienTrangKT.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSHienTrangKT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSHienTrangKT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHienTrangKT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHTKT,
            this.TenHTKT});
            this.dgvDSHienTrangKT.Location = new System.Drawing.Point(6, 94);
            this.dgvDSHienTrangKT.Name = "dgvDSHienTrangKT";
            this.dgvDSHienTrangKT.Size = new System.Drawing.Size(454, 448);
            this.dgvDSHienTrangKT.TabIndex = 8;
            this.dgvDSHienTrangKT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHienTrangKT_CellContentClick);
            this.dgvDSHienTrangKT.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSHienTrangKT_RowPostPaint);
            // 
            // MaHTKT
            // 
            this.MaHTKT.DataPropertyName = "MaHTKT";
            this.MaHTKT.HeaderText = "MaBGD";
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
            this.btnSuaHienTrangKT.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSuaHienTrangKT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaHienTrangKT.Location = new System.Drawing.Point(246, 53);
            this.btnSuaHienTrangKT.Name = "btnSuaHienTrangKT";
            this.btnSuaHienTrangKT.Size = new System.Drawing.Size(65, 35);
            this.btnSuaHienTrangKT.TabIndex = 7;
            this.btnSuaHienTrangKT.Text = "Sửa";
            this.btnSuaHienTrangKT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaHienTrangKT.UseVisualStyleBackColor = true;
            this.btnSuaHienTrangKT.Click += new System.EventHandler(this.btnSuaHienTrangKT_Click);
            // 
            // btnThemHienTrangKT
            // 
            this.btnThemHienTrangKT.Image = global::KTKS_DonKH.Properties.Resources.add_24x24;
            this.btnThemHienTrangKT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemHienTrangKT.Location = new System.Drawing.Point(164, 53);
            this.btnThemHienTrangKT.Name = "btnThemHienTrangKT";
            this.btnThemHienTrangKT.Size = new System.Drawing.Size(76, 35);
            this.btnThemHienTrangKT.TabIndex = 6;
            this.btnThemHienTrangKT.Text = "Thêm";
            this.btnThemHienTrangKT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemHienTrangKT.UseVisualStyleBackColor = true;
            this.btnThemHienTrangKT.Click += new System.EventHandler(this.btnThemHienTrangKT_Click);
            // 
            // txtHienTrangKT
            // 
            this.txtHienTrangKT.Location = new System.Drawing.Point(164, 22);
            this.txtHienTrangKT.Name = "txtHienTrangKT";
            this.txtHienTrangKT.Size = new System.Drawing.Size(281, 25);
            this.txtHienTrangKT.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hiện Trạng Kiểm Tra:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXoaTrangThaiBC);
            this.groupBox2.Controls.Add(this.dgvDSTrangThaiBC);
            this.groupBox2.Controls.Add(this.btnSuaTrangThaiBC);
            this.groupBox2.Controls.Add(this.btnThemTrangThaiBC);
            this.groupBox2.Controls.Add(this.txtTrangThaiBC);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(550, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 548);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạng Thái Bấm Chì";
            // 
            // dgvDSTrangThaiBC
            // 
            this.dgvDSTrangThaiBC.AllowUserToAddRows = false;
            this.dgvDSTrangThaiBC.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSTrangThaiBC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDSTrangThaiBC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTrangThaiBC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTTBC,
            this.TenTTBC});
            this.dgvDSTrangThaiBC.Location = new System.Drawing.Point(6, 94);
            this.dgvDSTrangThaiBC.Name = "dgvDSTrangThaiBC";
            this.dgvDSTrangThaiBC.Size = new System.Drawing.Size(454, 448);
            this.dgvDSTrangThaiBC.TabIndex = 8;
            this.dgvDSTrangThaiBC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSTrangThaiBC_CellContentClick);
            this.dgvDSTrangThaiBC.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSTrangThaiBC_RowPostPaint);
            // 
            // MaTTBC
            // 
            this.MaTTBC.DataPropertyName = "MaTTBC";
            this.MaTTBC.HeaderText = "MaTTBC";
            this.MaTTBC.Name = "MaTTBC";
            this.MaTTBC.Visible = false;
            // 
            // TenTTBC
            // 
            this.TenTTBC.DataPropertyName = "TenTTBC";
            this.TenTTBC.HeaderText = "Trạng Thái Bấm Chì";
            this.TenTTBC.Name = "TenTTBC";
            this.TenTTBC.ReadOnly = true;
            this.TenTTBC.Width = 400;
            // 
            // btnSuaTrangThaiBC
            // 
            this.btnSuaTrangThaiBC.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSuaTrangThaiBC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaTrangThaiBC.Location = new System.Drawing.Point(247, 53);
            this.btnSuaTrangThaiBC.Name = "btnSuaTrangThaiBC";
            this.btnSuaTrangThaiBC.Size = new System.Drawing.Size(65, 35);
            this.btnSuaTrangThaiBC.TabIndex = 7;
            this.btnSuaTrangThaiBC.Text = "Sửa";
            this.btnSuaTrangThaiBC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnSuaTrangThaiBC.Click += new System.EventHandler(this.btnSuaTrangThaiBC_Click);
            // 
            // btnThemTrangThaiBC
            // 
            this.btnThemTrangThaiBC.Image = global::KTKS_DonKH.Properties.Resources.add_24x24;
            this.btnThemTrangThaiBC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemTrangThaiBC.Location = new System.Drawing.Point(164, 53);
            this.btnThemTrangThaiBC.Name = "btnThemTrangThaiBC";
            this.btnThemTrangThaiBC.Size = new System.Drawing.Size(76, 35);
            this.btnThemTrangThaiBC.TabIndex = 6;
            this.btnThemTrangThaiBC.Text = "Thêm";
            this.btnThemTrangThaiBC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnThemTrangThaiBC.Click += new System.EventHandler(this.btnThemTrangThaiBC_Click);
            // 
            // txtTrangThaiBC
            // 
            this.txtTrangThaiBC.Location = new System.Drawing.Point(164, 22);
            this.txtTrangThaiBC.Name = "txtTrangThaiBC";
            this.txtTrangThaiBC.Size = new System.Drawing.Size(281, 25);
            this.txtTrangThaiBC.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trạng Thái Bấm Chì:";
            // 
            // btnXoaHienTrangKT
            // 
            this.btnXoaHienTrangKT.Image = global::KTKS_DonKH.Properties.Resources.delete_24x24;
            this.btnXoaHienTrangKT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaHienTrangKT.Location = new System.Drawing.Point(378, 53);
            this.btnXoaHienTrangKT.Name = "btnXoaHienTrangKT";
            this.btnXoaHienTrangKT.Size = new System.Drawing.Size(67, 35);
            this.btnXoaHienTrangKT.TabIndex = 87;
            this.btnXoaHienTrangKT.Text = "Xóa";
            this.btnXoaHienTrangKT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaHienTrangKT.UseVisualStyleBackColor = true;
            this.btnXoaHienTrangKT.Click += new System.EventHandler(this.btnXoaHienTrangKT_Click);
            // 
            // btnXoaTrangThaiBC
            // 
            this.btnXoaTrangThaiBC.Image = global::KTKS_DonKH.Properties.Resources.delete_24x24;
            this.btnXoaTrangThaiBC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaTrangThaiBC.Location = new System.Drawing.Point(378, 53);
            this.btnXoaTrangThaiBC.Name = "btnXoaTrangThaiBC";
            this.btnXoaTrangThaiBC.Size = new System.Drawing.Size(67, 35);
            this.btnXoaTrangThaiBC.TabIndex = 88;
            this.btnXoaTrangThaiBC.Text = "Xóa";
            this.btnXoaTrangThaiBC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnXoaTrangThaiBC.Click += new System.EventHandler(this.btnXoaTrangThaiBC_Click);
            // 
            // frmThongTin_KT_BC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1165, 564);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongTin_KT_BC";
            this.Text = "Thông Tin Hiện Trạng KT/ Trạng Thái BC";
            this.Load += new System.EventHandler(this.frmThongTin_KT_BC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHienTrangKT)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTrangThaiBC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHienTrangKT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuaHienTrangKT;
        private System.Windows.Forms.Button btnThemHienTrangKT;
        private System.Windows.Forms.DataGridView dgvDSHienTrangKT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDSTrangThaiBC;
        private System.Windows.Forms.Button btnSuaTrangThaiBC;
        private System.Windows.Forms.Button btnThemTrangThaiBC;
        private System.Windows.Forms.TextBox txtTrangThaiBC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHTKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHTKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTTBC;
        private System.Windows.Forms.Button btnXoaHienTrangKT;
        private System.Windows.Forms.Button btnXoaTrangThaiBC;
    }
}