namespace DocSo_PC.GUI.Doi
{
    partial class frmTaoDotKiemTra
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
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.btnSua = new System.Windows.Forms.Button();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DocSoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThuDS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThuHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSCuMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
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
            this.Chon,
            this.DocSoID,
            this.DanhBo,
            this.TieuThuDS,
            this.TieuThuHD,
            this.CSCu,
            this.CSCuMoi,
            this.Nam,
            this.Ky,
            this.Dot});
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 31);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Size = new System.Drawing.Size(615, 485);
            this.dgvDanhSach.TabIndex = 6;
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(94, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Cập Nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // Chon
            // 
            this.Chon.DataPropertyName = "Chon";
            this.Chon.HeaderText = "Chọn";
            this.Chon.Name = "Chon";
            this.Chon.Width = 40;
            // 
            // DocSoID
            // 
            this.DocSoID.DataPropertyName = "DocSoID";
            this.DocSoID.HeaderText = "DocSoID";
            this.DocSoID.Name = "DocSoID";
            this.DocSoID.Visible = false;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // TieuThuDS
            // 
            this.TieuThuDS.DataPropertyName = "TieuThuDS";
            this.TieuThuDS.HeaderText = "Tiêu Thụ ĐS";
            this.TieuThuDS.Name = "TieuThuDS";
            // 
            // TieuThuHD
            // 
            this.TieuThuHD.DataPropertyName = "TieuThuHD";
            this.TieuThuHD.HeaderText = "Tiêu Thụ HĐ";
            this.TieuThuHD.Name = "TieuThuHD";
            // 
            // CSCu
            // 
            this.CSCu.DataPropertyName = "CSCu";
            this.CSCu.HeaderText = "CS Nền Hiện Tại";
            this.CSCu.Name = "CSCu";
            this.CSCu.Width = 110;
            // 
            // CSCuMoi
            // 
            this.CSCuMoi.DataPropertyName = "CSCuMoi";
            this.CSCuMoi.HeaderText = "CS Nền Mới";
            this.CSCuMoi.Name = "CSCuMoi";
            // 
            // Nam
            // 
            this.Nam.DataPropertyName = "Nam";
            this.Nam.HeaderText = "Nam";
            this.Nam.Name = "Nam";
            this.Nam.Visible = false;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Ky";
            this.Ky.Name = "Ky";
            this.Ky.Visible = false;
            // 
            // Dot
            // 
            this.Dot.DataPropertyName = "Dot";
            this.Dot.HeaderText = "Dot";
            this.Dot.Name = "Dot";
            this.Dot.Visible = false;
            // 
            // frmTaoDotKiemTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 548);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dgvDanhSach);
            this.Name = "frmTaoDotKiemTra";
            this.Text = "Tạo Đợt Kiểm Tra Chỉ Số Nền";
            this.Load += new System.EventHandler(this.frmTaoDotKiemTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocSoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThuDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThuHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSCuMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
    }
}