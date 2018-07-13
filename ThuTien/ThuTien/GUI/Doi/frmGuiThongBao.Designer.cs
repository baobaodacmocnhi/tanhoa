namespace ThuTien.GUI.Doi
{
    partial class frmGuiThongBao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.dgvGuiThongBao = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnXem_HD = new System.Windows.Forms.Button();
            this.cmbToDot = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbFromDot = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnXemAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuiThongBao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 108);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 71;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // dgvGuiThongBao
            // 
            this.dgvGuiThongBao.AllowUserToAddRows = false;
            this.dgvGuiThongBao.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGuiThongBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGuiThongBao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuiThongBao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.To,
            this.HanhThu,
            this.CreateDate,
            this.HopDong,
            this.In});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGuiThongBao.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGuiThongBao.Location = new System.Drawing.Point(93, 39);
            this.dgvGuiThongBao.Name = "dgvGuiThongBao";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGuiThongBao.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvGuiThongBao.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvGuiThongBao.Size = new System.Drawing.Size(840, 567);
            this.dgvGuiThongBao.TabIndex = 72;
            this.dgvGuiThongBao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGuiThongBao_CellFormatting);
            this.dgvGuiThongBao.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvGuiThongBao_RowPostPaint);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(12, 177);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 73;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(415, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 74;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnXem_HD
            // 
            this.btnXem_HD.Location = new System.Drawing.Point(334, 10);
            this.btnXem_HD.Name = "btnXem_HD";
            this.btnXem_HD.Size = new System.Drawing.Size(75, 23);
            this.btnXem_HD.TabIndex = 118;
            this.btnXem_HD.Text = "Xem";
            this.btnXem_HD.UseVisualStyleBackColor = true;
            this.btnXem_HD.Click += new System.EventHandler(this.btnXem_HD_Click);
            // 
            // cmbToDot
            // 
            this.cmbToDot.FormattingEnabled = true;
            this.cmbToDot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbToDot.Location = new System.Drawing.Point(288, 12);
            this.cmbToDot.Name = "cmbToDot";
            this.cmbToDot.Size = new System.Drawing.Size(40, 21);
            this.cmbToDot.TabIndex = 117;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(232, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 116;
            this.label10.Text = "Đến Đợt:";
            // 
            // cmbFromDot
            // 
            this.cmbFromDot.FormattingEnabled = true;
            this.cmbFromDot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbFromDot.Location = new System.Drawing.Point(186, 12);
            this.cmbFromDot.Name = "cmbFromDot";
            this.cmbFromDot.Size = new System.Drawing.Size(40, 21);
            this.cmbFromDot.TabIndex = 115;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(137, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 114;
            this.label11.Text = "Từ Đợt:";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
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
            this.HoTen.Width = 200;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "Tổ";
            this.To.Name = "To";
            this.To.Width = 50;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "Hành Thu";
            this.HanhThu.Name = "HanhThu";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // HopDong
            // 
            this.HopDong.DataPropertyName = "HopDong";
            this.HopDong.HeaderText = "HopDong";
            this.HopDong.Name = "HopDong";
            this.HopDong.Visible = false;
            // 
            // In
            // 
            this.In.DataPropertyName = "In";
            this.In.HeaderText = "In";
            this.In.Name = "In";
            this.In.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.In.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.In.Width = 30;
            // 
            // btnXemAll
            // 
            this.btnXemAll.Location = new System.Drawing.Point(12, 39);
            this.btnXemAll.Name = "btnXemAll";
            this.btnXemAll.Size = new System.Drawing.Size(75, 23);
            this.btnXemAll.TabIndex = 119;
            this.btnXemAll.Text = "Xem Tất Cả";
            this.btnXemAll.UseVisualStyleBackColor = true;
            this.btnXemAll.Click += new System.EventHandler(this.btnXemAll_Click);
            // 
            // frmGuiThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 631);
            this.Controls.Add(this.btnXemAll);
            this.Controls.Add(this.btnXem_HD);
            this.Controls.Add(this.cmbToDot);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbFromDot);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvGuiThongBao);
            this.Controls.Add(this.btnChonFile);
            this.Name = "frmGuiThongBao";
            this.Text = "Gửi Thông Báo";
            this.Load += new System.EventHandler(this.frmGuiThongBao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuiThongBao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.DataGridView dgvGuiThongBao;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnXem_HD;
        private System.Windows.Forms.ComboBox cmbToDot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbFromDot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn HopDong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In;
        private System.Windows.Forms.Button btnXemAll;
    }
}