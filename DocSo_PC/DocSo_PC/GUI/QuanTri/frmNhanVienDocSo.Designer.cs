namespace DocSo_PC.GUI.QuanTri
{
    partial class frmNhanVienDocSo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbPhong = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.May = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Máy";
            // 
            // txtMay
            // 
            this.txtMay.Location = new System.Drawing.Point(42, 39);
            this.txtMay.Name = "txtMay";
            this.txtMay.Size = new System.Drawing.Size(100, 20);
            this.txtMay.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tổ";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(42, 12);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(100, 21);
            this.cmbTo.TabIndex = 28;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(235, 7);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 29;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(235, 36);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 30;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(235, 65);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 31;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.To,
            this.May});
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 65);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Size = new System.Drawing.Size(217, 485);
            this.dgvDanhSach.TabIndex = 32;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXem);
            this.panel1.Controls.Add(this.cmbPhong);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(316, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 78);
            this.panel1.TabIndex = 42;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(6, 49);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 41;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbPhong
            // 
            this.cmbPhong.FormattingEnabled = true;
            this.cmbPhong.Location = new System.Drawing.Point(6, 22);
            this.cmbPhong.Name = "cmbPhong";
            this.cmbPhong.Size = new System.Drawing.Size(200, 21);
            this.cmbPhong.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Phòng";
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "Tổ";
            this.To.Name = "To";
            // 
            // May
            // 
            this.May.DataPropertyName = "May";
            this.May.HeaderText = "Máy";
            this.May.Name = "May";
            this.May.Width = 50;
            // 
            // frmNhanVienDocSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 617);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMay);
            this.Controls.Add(this.label1);
            this.Name = "frmNhanVienDocSo";
            this.Text = "Máy Đọc Số";
            this.Load += new System.EventHandler(this.frmNhanVienDocSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbPhong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn May;
    }
}