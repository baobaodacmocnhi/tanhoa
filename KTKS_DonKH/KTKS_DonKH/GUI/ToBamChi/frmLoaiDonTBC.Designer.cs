namespace KTKS_DonKH.GUI.ToBamChi
{
    partial class frmLoaiDonTBC
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
            this.MaLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.KyHieuLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtKyHieuLD = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.An = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvLoaiDon = new System.Windows.Forms.DataGridView();
            this.txtTenLD = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiDon)).BeginInit();
            this.SuspendLayout();
            // 
            // MaLD
            // 
            this.MaLD.DataPropertyName = "MaLD";
            this.MaLD.HeaderText = "MaLD";
            this.MaLD.Name = "MaLD";
            this.MaLD.Visible = false;
            // 
            // TenLD
            // 
            this.TenLD.DataPropertyName = "TenLD";
            this.TenLD.HeaderText = "Tên Loại Đơn";
            this.TenLD.Name = "TenLD";
            this.TenLD.Width = 250;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(344, 75);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 103;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // KyHieuLD
            // 
            this.KyHieuLD.DataPropertyName = "KyHieuLD";
            this.KyHieuLD.HeaderText = "Ký Hiệu Loại Đơn";
            this.KyHieuLD.Name = "KyHieuLD";
            this.KyHieuLD.Width = 150;
            // 
            // txtKyHieuLD
            // 
            this.txtKyHieuLD.Location = new System.Drawing.Point(176, 13);
            this.txtKyHieuLD.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtKyHieuLD.Name = "txtKyHieuLD";
            this.txtKyHieuLD.Size = new System.Drawing.Size(165, 22);
            this.txtKyHieuLD.TabIndex = 97;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(176, 75);
            this.btnThem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 100;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // An
            // 
            this.An.DataPropertyName = "An";
            this.An.HeaderText = "Ẩn";
            this.An.Name = "An";
            this.An.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.An.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.An.Width = 50;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(261, 75);
            this.btnSua.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 101;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 96;
            this.label3.Text = "Ký Hiệu Loại Đơn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 98;
            this.label4.Text = "Tên Loại Đơn:";
            // 
            // dgvLoaiDon
            // 
            this.dgvLoaiDon.AllowDrop = true;
            this.dgvLoaiDon.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoaiDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoaiDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLD,
            this.KyHieuLD,
            this.TenLD,
            this.An});
            this.dgvLoaiDon.Location = new System.Drawing.Point(14, 108);
            this.dgvLoaiDon.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvLoaiDon.MultiSelect = false;
            this.dgvLoaiDon.Name = "dgvLoaiDon";
            this.dgvLoaiDon.Size = new System.Drawing.Size(514, 510);
            this.dgvLoaiDon.TabIndex = 102;
            this.dgvLoaiDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiDon_CellContentClick);
            this.dgvLoaiDon.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiDon_CellValueChanged);
            this.dgvLoaiDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLoaiDon_RowPostPaint);
            this.dgvLoaiDon.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvLoaiDon_DragDrop);
            this.dgvLoaiDon.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvLoaiDon_DragEnter);
            this.dgvLoaiDon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvLoaiDon_MouseClick);
            // 
            // txtTenLD
            // 
            this.txtTenLD.Location = new System.Drawing.Point(176, 45);
            this.txtTenLD.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTenLD.Name = "txtTenLD";
            this.txtTenLD.Size = new System.Drawing.Size(165, 22);
            this.txtTenLD.TabIndex = 99;
            // 
            // frmLoaiDonTBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(539, 629);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtKyHieuLD);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvLoaiDon);
            this.Controls.Add(this.txtTenLD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmLoaiDonTBC";
            this.Text = "Loại Đơn Tổ Bấm Chì";
            this.Load += new System.EventHandler(this.frmLoaiDonTBC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn MaLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieuLD;
        private System.Windows.Forms.TextBox txtKyHieuLD;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn An;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvLoaiDon;
        private System.Windows.Forms.TextBox txtTenLD;
    }
}