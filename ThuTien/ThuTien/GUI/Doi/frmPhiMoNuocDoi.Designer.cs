namespace ThuTien.GUI.Doi
{
    partial class frmPhiMoNuocDoi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvPhiMoNuoc = new System.Windows.Forms.DataGridView();
            this.NgayDongPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuyenKhoan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvPhiMoNuocDoi = new System.Windows.Forms.DataGridView();
            this.ID_Doi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate_Doi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_Doi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_Doi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_Doi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhiMoNuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhiMoNuocDoi)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(112, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(282, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Đến Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(388, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 32;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvPhiMoNuoc
            // 
            this.dgvPhiMoNuoc.AllowUserToAddRows = false;
            this.dgvPhiMoNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhiMoNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhiMoNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhiMoNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayDongPhi,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.ChuyenKhoan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhiMoNuoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhiMoNuoc.Location = new System.Drawing.Point(12, 38);
            this.dgvPhiMoNuoc.Name = "dgvPhiMoNuoc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhiMoNuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhiMoNuoc.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPhiMoNuoc.Size = new System.Drawing.Size(643, 596);
            this.dgvPhiMoNuoc.TabIndex = 37;
            this.dgvPhiMoNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhiMoNuoc_CellFormatting);
            this.dgvPhiMoNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPhiMoNuoc_RowPostPaint);
            // 
            // NgayDongPhi
            // 
            this.NgayDongPhi.DataPropertyName = "NgayDongPhi";
            this.NgayDongPhi.HeaderText = "Ngày Đóng Phí";
            this.NgayDongPhi.Name = "NgayDongPhi";
            this.NgayDongPhi.Width = 80;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // ChuyenKhoan
            // 
            this.ChuyenKhoan.DataPropertyName = "ChuyenKhoan";
            this.ChuyenKhoan.HeaderText = "Chuyển Khoản";
            this.ChuyenKhoan.Name = "ChuyenKhoan";
            this.ChuyenKhoan.Width = 50;
            // 
            // dgvPhiMoNuocDoi
            // 
            this.dgvPhiMoNuocDoi.AllowUserToAddRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhiMoNuocDoi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPhiMoNuocDoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhiMoNuocDoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Doi,
            this.CreateDate_Doi,
            this.DanhBo_Doi,
            this.HoTen_Doi,
            this.DiaChi_Doi});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhiMoNuocDoi.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPhiMoNuocDoi.Location = new System.Drawing.Point(661, 38);
            this.dgvPhiMoNuocDoi.Name = "dgvPhiMoNuocDoi";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhiMoNuocDoi.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhiMoNuocDoi.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPhiMoNuocDoi.Size = new System.Drawing.Size(592, 596);
            this.dgvPhiMoNuocDoi.TabIndex = 38;
            this.dgvPhiMoNuocDoi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhiMoNuocDoi_CellEndEdit);
            this.dgvPhiMoNuocDoi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhiMoNuocDoi_CellFormatting);
            this.dgvPhiMoNuocDoi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPhiMoNuocDoi_RowPostPaint);
            this.dgvPhiMoNuocDoi.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPhiMoNuocDoi_UserDeletedRow);
            // 
            // ID_Doi
            // 
            this.ID_Doi.DataPropertyName = "ID";
            this.ID_Doi.HeaderText = "ID";
            this.ID_Doi.Name = "ID_Doi";
            this.ID_Doi.Visible = false;
            // 
            // CreateDate_Doi
            // 
            this.CreateDate_Doi.DataPropertyName = "CreateDate";
            this.CreateDate_Doi.HeaderText = "Ngày Lập";
            this.CreateDate_Doi.Name = "CreateDate_Doi";
            this.CreateDate_Doi.Width = 80;
            // 
            // DanhBo_Doi
            // 
            this.DanhBo_Doi.DataPropertyName = "DanhBo";
            this.DanhBo_Doi.HeaderText = "Danh Bộ";
            this.DanhBo_Doi.Name = "DanhBo_Doi";
            // 
            // HoTen_Doi
            // 
            this.HoTen_Doi.DataPropertyName = "HoTen";
            this.HoTen_Doi.HeaderText = "Khách Hàng";
            this.HoTen_Doi.Name = "HoTen_Doi";
            this.HoTen_Doi.Width = 150;
            // 
            // DiaChi_Doi
            // 
            this.DiaChi_Doi.DataPropertyName = "DiaChi";
            this.DiaChi_Doi.HeaderText = "Địa Chỉ";
            this.DiaChi_Doi.Name = "DiaChi_Doi";
            this.DiaChi_Doi.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Danh Sách Tự Nhập:";
            // 
            // frmPhiMoNuocDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 646);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPhiMoNuocDoi);
            this.Controls.Add(this.dgvPhiMoNuoc);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXem);
            this.Name = "frmPhiMoNuocDoi";
            this.Text = "Phí Mở Nước Đội";
            this.Load += new System.EventHandler(this.frmPhiMoNuocDoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhiMoNuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhiMoNuocDoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvPhiMoNuoc;
        private System.Windows.Forms.DataGridView dgvPhiMoNuocDoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Doi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_Doi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_Doi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_Doi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_Doi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDongPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChuyenKhoan;
    }
}