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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDownTrangThaiBC = new System.Windows.Forms.Button();
            this.btnXoaTrangThaiBC = new System.Windows.Forms.Button();
            this.btnUpTrangThaiBC = new System.Windows.Forms.Button();
            this.dgvDSTrangThaiBC = new System.Windows.Forms.DataGridView();
            this.MaTTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSuaTrangThaiBC = new System.Windows.Forms.Button();
            this.btnThemTrangThaiBC = new System.Windows.Forms.Button();
            this.txtTrangThaiBC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHienTrangKT)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTrangThaiBC)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(38, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 484);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hiện Trạng Kiểm Tra";
            // 
            // btnDownHienTrangKT
            // 
            this.btnDownHienTrangKT.Location = new System.Drawing.Point(60, 47);
            this.btnDownHienTrangKT.Name = "btnDownHienTrangKT";
            this.btnDownHienTrangKT.Size = new System.Drawing.Size(66, 31);
            this.btnDownHienTrangKT.TabIndex = 89;
            this.btnDownHienTrangKT.Text = "Down";
            this.btnDownHienTrangKT.UseVisualStyleBackColor = true;
            this.btnDownHienTrangKT.Click += new System.EventHandler(this.btnDownHienTrangKT_Click);
            // 
            // btnUpHienTrangKT
            // 
            this.btnUpHienTrangKT.Location = new System.Drawing.Point(5, 47);
            this.btnUpHienTrangKT.Name = "btnUpHienTrangKT";
            this.btnUpHienTrangKT.Size = new System.Drawing.Size(49, 31);
            this.btnUpHienTrangKT.TabIndex = 88;
            this.btnUpHienTrangKT.Text = "Up";
            this.btnUpHienTrangKT.UseVisualStyleBackColor = true;
            this.btnUpHienTrangKT.Click += new System.EventHandler(this.btnUpHienTrangKT_Click);
            // 
            // btnXoaHienTrangKT
            // 
            this.btnXoaHienTrangKT.Location = new System.Drawing.Point(331, 47);
            this.btnXoaHienTrangKT.Name = "btnXoaHienTrangKT";
            this.btnXoaHienTrangKT.Size = new System.Drawing.Size(59, 31);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSHienTrangKT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSHienTrangKT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHienTrangKT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHTKT,
            this.TenHTKT});
            this.dgvDSHienTrangKT.Location = new System.Drawing.Point(5, 83);
            this.dgvDSHienTrangKT.MultiSelect = false;
            this.dgvDSHienTrangKT.Name = "dgvDSHienTrangKT";
            this.dgvDSHienTrangKT.Size = new System.Drawing.Size(397, 395);
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
            this.btnSuaHienTrangKT.Location = new System.Drawing.Point(215, 47);
            this.btnSuaHienTrangKT.Name = "btnSuaHienTrangKT";
            this.btnSuaHienTrangKT.Size = new System.Drawing.Size(57, 31);
            this.btnSuaHienTrangKT.TabIndex = 7;
            this.btnSuaHienTrangKT.Text = "Sửa";
            this.btnSuaHienTrangKT.UseVisualStyleBackColor = true;
            this.btnSuaHienTrangKT.Click += new System.EventHandler(this.btnSuaHienTrangKT_Click);
            // 
            // btnThemHienTrangKT
            // 
            this.btnThemHienTrangKT.Location = new System.Drawing.Point(144, 47);
            this.btnThemHienTrangKT.Name = "btnThemHienTrangKT";
            this.btnThemHienTrangKT.Size = new System.Drawing.Size(66, 31);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDownTrangThaiBC);
            this.groupBox2.Controls.Add(this.btnXoaTrangThaiBC);
            this.groupBox2.Controls.Add(this.btnUpTrangThaiBC);
            this.groupBox2.Controls.Add(this.dgvDSTrangThaiBC);
            this.groupBox2.Controls.Add(this.btnSuaTrangThaiBC);
            this.groupBox2.Controls.Add(this.btnThemTrangThaiBC);
            this.groupBox2.Controls.Add(this.txtTrangThaiBC);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(481, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 484);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạng Thái Bấm Chì";
            // 
            // btnDownTrangThaiBC
            // 
            this.btnDownTrangThaiBC.Location = new System.Drawing.Point(60, 47);
            this.btnDownTrangThaiBC.Name = "btnDownTrangThaiBC";
            this.btnDownTrangThaiBC.Size = new System.Drawing.Size(66, 31);
            this.btnDownTrangThaiBC.TabIndex = 91;
            this.btnDownTrangThaiBC.Text = "Down";
            this.btnDownTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnDownTrangThaiBC.Click += new System.EventHandler(this.btnDownTrangThaiBC_Click);
            // 
            // btnXoaTrangThaiBC
            // 
            this.btnXoaTrangThaiBC.Location = new System.Drawing.Point(331, 47);
            this.btnXoaTrangThaiBC.Name = "btnXoaTrangThaiBC";
            this.btnXoaTrangThaiBC.Size = new System.Drawing.Size(59, 31);
            this.btnXoaTrangThaiBC.TabIndex = 88;
            this.btnXoaTrangThaiBC.Text = "Xóa";
            this.btnXoaTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnXoaTrangThaiBC.Click += new System.EventHandler(this.btnXoaTrangThaiBC_Click);
            // 
            // btnUpTrangThaiBC
            // 
            this.btnUpTrangThaiBC.Location = new System.Drawing.Point(5, 47);
            this.btnUpTrangThaiBC.Name = "btnUpTrangThaiBC";
            this.btnUpTrangThaiBC.Size = new System.Drawing.Size(49, 31);
            this.btnUpTrangThaiBC.TabIndex = 90;
            this.btnUpTrangThaiBC.Text = "Up";
            this.btnUpTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnUpTrangThaiBC.Click += new System.EventHandler(this.btnUpTrangThaiBC_Click);
            // 
            // dgvDSTrangThaiBC
            // 
            this.dgvDSTrangThaiBC.AllowUserToAddRows = false;
            this.dgvDSTrangThaiBC.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSTrangThaiBC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSTrangThaiBC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTrangThaiBC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTTBC,
            this.TenTTBC});
            this.dgvDSTrangThaiBC.Location = new System.Drawing.Point(5, 83);
            this.dgvDSTrangThaiBC.MultiSelect = false;
            this.dgvDSTrangThaiBC.Name = "dgvDSTrangThaiBC";
            this.dgvDSTrangThaiBC.Size = new System.Drawing.Size(397, 395);
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
            this.btnSuaTrangThaiBC.Location = new System.Drawing.Point(216, 47);
            this.btnSuaTrangThaiBC.Name = "btnSuaTrangThaiBC";
            this.btnSuaTrangThaiBC.Size = new System.Drawing.Size(57, 31);
            this.btnSuaTrangThaiBC.TabIndex = 7;
            this.btnSuaTrangThaiBC.Text = "Sửa";
            this.btnSuaTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnSuaTrangThaiBC.Click += new System.EventHandler(this.btnSuaTrangThaiBC_Click);
            // 
            // btnThemTrangThaiBC
            // 
            this.btnThemTrangThaiBC.Location = new System.Drawing.Point(144, 47);
            this.btnThemTrangThaiBC.Name = "btnThemTrangThaiBC";
            this.btnThemTrangThaiBC.Size = new System.Drawing.Size(66, 31);
            this.btnThemTrangThaiBC.TabIndex = 6;
            this.btnThemTrangThaiBC.Text = "Thêm";
            this.btnThemTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnThemTrangThaiBC.Click += new System.EventHandler(this.btnThemTrangThaiBC_Click);
            // 
            // txtTrangThaiBC
            // 
            this.txtTrangThaiBC.Location = new System.Drawing.Point(144, 19);
            this.txtTrangThaiBC.Name = "txtTrangThaiBC";
            this.txtTrangThaiBC.Size = new System.Drawing.Size(246, 21);
            this.txtTrangThaiBC.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trạng Thái Bấm Chì:";
            // 
            // frmThongTin_KT_BC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1019, 498);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTTBC;
        private System.Windows.Forms.Button btnXoaHienTrangKT;
        private System.Windows.Forms.Button btnXoaTrangThaiBC;
        private System.Windows.Forms.Button btnDownHienTrangKT;
        private System.Windows.Forms.Button btnUpHienTrangKT;
        private System.Windows.Forms.Button btnDownTrangThaiBC;
        private System.Windows.Forms.Button btnUpTrangThaiBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHTKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHTKT;
    }
}