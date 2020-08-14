namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmGiaNuoc
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
            this.dgvDSGiaNuoc = new System.Windows.Forms.DataGridView();
            this.MaGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtGiaNuoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDoiTuong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGiaNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSGiaNuoc
            // 
            this.dgvDSGiaNuoc.AllowUserToAddRows = false;
            this.dgvDSGiaNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSGiaNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSGiaNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSGiaNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaGN,
            this.TenGN,
            this.DonGia});
            this.dgvDSGiaNuoc.Location = new System.Drawing.Point(14, 105);
            this.dgvDSGiaNuoc.MultiSelect = false;
            this.dgvDSGiaNuoc.Name = "dgvDSGiaNuoc";
            this.dgvDSGiaNuoc.ReadOnly = true;
            this.dgvDSGiaNuoc.Size = new System.Drawing.Size(415, 160);
            this.dgvDSGiaNuoc.TabIndex = 17;
            this.dgvDSGiaNuoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSGiaNuoc_CellContentClick);
            this.dgvDSGiaNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSGiaNuoc_CellFormatting);
            this.dgvDSGiaNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSGiaNuoc_RowPostPaint);
            // 
            // MaGN
            // 
            this.MaGN.DataPropertyName = "MaGN";
            this.MaGN.HeaderText = "MaGN";
            this.MaGN.Name = "MaGN";
            this.MaGN.ReadOnly = true;
            this.MaGN.Visible = false;
            // 
            // TenGN
            // 
            this.TenGN.DataPropertyName = "TenGN";
            this.TenGN.HeaderText = "Đối Tượng";
            this.TenGN.Name = "TenGN";
            this.TenGN.ReadOnly = true;
            this.TenGN.Width = 200;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(252, 70);
            this.btnSua.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(167, 70);
            this.btnThem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Visible = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtGiaNuoc
            // 
            this.txtGiaNuoc.Location = new System.Drawing.Point(126, 41);
            this.txtGiaNuoc.Name = "txtGiaNuoc";
            this.txtGiaNuoc.Size = new System.Drawing.Size(201, 22);
            this.txtGiaNuoc.TabIndex = 12;
            this.txtGiaNuoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaNuoc_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Giá Nước:";
            // 
            // txtDoiTuong
            // 
            this.txtDoiTuong.Location = new System.Drawing.Point(126, 12);
            this.txtDoiTuong.Name = "txtDoiTuong";
            this.txtDoiTuong.ReadOnly = true;
            this.txtDoiTuong.Size = new System.Drawing.Size(201, 22);
            this.txtDoiTuong.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Đối Tượng:";
            // 
            // frmGiaNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(439, 305);
            this.Controls.Add(this.dgvDSGiaNuoc);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGiaNuoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDoiTuong);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmGiaNuoc";
            this.Text = "Giá Nước";
            this.Load += new System.EventHandler(this.frmGiaNuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSGiaNuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSGiaNuoc;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtGiaNuoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDoiTuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
    }
}