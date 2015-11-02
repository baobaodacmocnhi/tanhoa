namespace ThuTien.GUI.Quay
{
    partial class frmPhiMoNuoc
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
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvKQDongNuoc = new System.Windows.Forms.DataGridView();
            this.MaDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKQDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DongPhi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayDongPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radChuaDongPhi = new System.Windows.Forms.RadioButton();
            this.radDaDongPhi = new System.Windows.Forms.RadioButton();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(330, 9);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 34;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvKQDongNuoc
            // 
            this.dgvKQDongNuoc.AllowUserToAddRows = false;
            this.dgvKQDongNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQDongNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKQDongNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQDongNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDN,
            this.MaKQDN,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NgayDN,
            this.DongPhi,
            this.NgayDongPhi,
            this.NgayGiaiTrach});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKQDongNuoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKQDongNuoc.Location = new System.Drawing.Point(12, 58);
            this.dgvKQDongNuoc.Name = "dgvKQDongNuoc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQDongNuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvKQDongNuoc.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKQDongNuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKQDongNuoc.Size = new System.Drawing.Size(1015, 563);
            this.dgvKQDongNuoc.TabIndex = 33;
            this.dgvKQDongNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKQDongNuoc_CellFormatting);
            this.dgvKQDongNuoc.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvKQDongNuoc_CellValidating);
            this.dgvKQDongNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvKQDongNuoc_RowPostPaint);
            // 
            // MaDN
            // 
            this.MaDN.DataPropertyName = "MaDN";
            this.MaDN.HeaderText = "Mã TB";
            this.MaDN.Name = "MaDN";
            this.MaDN.Width = 70;
            // 
            // MaKQDN
            // 
            this.MaKQDN.DataPropertyName = "MaKQDN";
            this.MaKQDN.HeaderText = "MaKQDN";
            this.MaKQDN.Name = "MaKQDN";
            this.MaKQDN.Visible = false;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
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
            // NgayDN
            // 
            this.NgayDN.DataPropertyName = "NgayDN";
            this.NgayDN.HeaderText = "Ngày ĐN";
            this.NgayDN.Name = "NgayDN";
            // 
            // DongPhi
            // 
            this.DongPhi.DataPropertyName = "DongPhi";
            this.DongPhi.HeaderText = "Đóng Phí";
            this.DongPhi.Name = "DongPhi";
            this.DongPhi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DongPhi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DongPhi.Width = 50;
            // 
            // NgayDongPhi
            // 
            this.NgayDongPhi.HeaderText = "Ngày Đóng Phí";
            this.NgayDongPhi.Name = "NgayDongPhi";
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach.HeaderText = "Đăng Ngân";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            // 
            // radChuaDongPhi
            // 
            this.radChuaDongPhi.AutoSize = true;
            this.radChuaDongPhi.Checked = true;
            this.radChuaDongPhi.Location = new System.Drawing.Point(52, 9);
            this.radChuaDongPhi.Name = "radChuaDongPhi";
            this.radChuaDongPhi.Size = new System.Drawing.Size(99, 17);
            this.radChuaDongPhi.TabIndex = 35;
            this.radChuaDongPhi.TabStop = true;
            this.radChuaDongPhi.Text = "Chưa Đóng Phí";
            this.radChuaDongPhi.UseVisualStyleBackColor = true;
            // 
            // radDaDongPhi
            // 
            this.radDaDongPhi.AutoSize = true;
            this.radDaDongPhi.Location = new System.Drawing.Point(52, 32);
            this.radDaDongPhi.Name = "radDaDongPhi";
            this.radDaDongPhi.Size = new System.Drawing.Size(86, 17);
            this.radDaDongPhi.TabIndex = 36;
            this.radDaDongPhi.Text = "Đã Đóng Phi";
            this.radDaDongPhi.UseVisualStyleBackColor = true;
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(224, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 38;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Danh Bộ:";
            // 
            // frmPhiMoNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 665);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radDaDongPhi);
            this.Controls.Add(this.radChuaDongPhi);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dgvKQDongNuoc);
            this.Name = "frmPhiMoNuoc";
            this.Text = "Phí Mở Nước";
            this.Load += new System.EventHandler(this.frmPhiMoNuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvKQDongNuoc;
        private System.Windows.Forms.RadioButton radChuaDongPhi;
        private System.Windows.Forms.RadioButton radDaDongPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKQDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DongPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDongPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
    }
}