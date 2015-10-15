namespace ThuTien.GUI.TongHop
{
    partial class frmCongVan
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvKQMoNuoc = new System.Windows.Forms.DataGridView();
            this.SoPhieuMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuyenMN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayChuyenMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvKQDongNuoc = new System.Windows.Forms.DataGridView();
            this.SoPhieuDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuyenDN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayChuyenDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnXem = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQMoNuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 626);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnXem);
            this.tabPage1.Controls.Add(this.dgvKQMoNuoc);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvKQDongNuoc);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(808, 600);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Đội QLĐHN";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvKQMoNuoc
            // 
            this.dgvKQMoNuoc.AllowUserToAddRows = false;
            this.dgvKQMoNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQMoNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKQMoNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQMoNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoPhieuMN,
            this.ChuyenMN,
            this.NgayChuyenMN});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKQMoNuoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKQMoNuoc.Location = new System.Drawing.Point(310, 35);
            this.dgvKQMoNuoc.MultiSelect = false;
            this.dgvKQMoNuoc.Name = "dgvKQMoNuoc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQMoNuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvKQMoNuoc.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKQMoNuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKQMoNuoc.Size = new System.Drawing.Size(296, 525);
            this.dgvKQMoNuoc.TabIndex = 33;
            this.dgvKQMoNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKQMoNuoc_CellFormatting);
            this.dgvKQMoNuoc.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvKQMoNuoc_CellValidating);
            this.dgvKQMoNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvKQMoNuoc_RowPostPaint);
            // 
            // SoPhieuMN
            // 
            this.SoPhieuMN.DataPropertyName = "SoPhieuMN";
            this.SoPhieuMN.HeaderText = "Số Phiếu";
            this.SoPhieuMN.Name = "SoPhieuMN";
            this.SoPhieuMN.Width = 80;
            // 
            // ChuyenMN
            // 
            this.ChuyenMN.DataPropertyName = "ChuyenMN";
            this.ChuyenMN.HeaderText = "Chuyển";
            this.ChuyenMN.Name = "ChuyenMN";
            this.ChuyenMN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChuyenMN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ChuyenMN.Width = 50;
            // 
            // NgayChuyenMN
            // 
            this.NgayChuyenMN.DataPropertyName = "NgayChuyenMN";
            this.NgayChuyenMN.HeaderText = "Ngày Chuyển";
            this.NgayChuyenMN.Name = "NgayChuyenMN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Danh Sách Phiếu Mở Nước:";
            // 
            // dgvKQDongNuoc
            // 
            this.dgvKQDongNuoc.AllowUserToAddRows = false;
            this.dgvKQDongNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQDongNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvKQDongNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQDongNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoPhieuDN,
            this.ChuyenDN,
            this.NgayChuyenDN});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKQDongNuoc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvKQDongNuoc.Location = new System.Drawing.Point(8, 35);
            this.dgvKQDongNuoc.MultiSelect = false;
            this.dgvKQDongNuoc.Name = "dgvKQDongNuoc";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKQDongNuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvKQDongNuoc.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvKQDongNuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKQDongNuoc.Size = new System.Drawing.Size(296, 525);
            this.dgvKQDongNuoc.TabIndex = 31;
            this.dgvKQDongNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKQDongNuoc_CellFormatting);
            this.dgvKQDongNuoc.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvKQDongNuoc_CellValidating);
            this.dgvKQDongNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvKQDongNuoc_RowPostPaint);
            // 
            // SoPhieuDN
            // 
            this.SoPhieuDN.DataPropertyName = "SoPhieuDN";
            this.SoPhieuDN.HeaderText = "Số Phiếu";
            this.SoPhieuDN.Name = "SoPhieuDN";
            this.SoPhieuDN.Width = 80;
            // 
            // ChuyenDN
            // 
            this.ChuyenDN.DataPropertyName = "ChuyenDN";
            this.ChuyenDN.HeaderText = "Chuyển";
            this.ChuyenDN.Name = "ChuyenDN";
            this.ChuyenDN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChuyenDN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ChuyenDN.Width = 50;
            // 
            // NgayChuyenDN
            // 
            this.NgayChuyenDN.DataPropertyName = "NgayChuyenDN";
            this.NgayChuyenDN.HeaderText = "Ngày Chuyển";
            this.NgayChuyenDN.Name = "NgayChuyenDN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Phiếu Đóng Nước:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(808, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kinh Doanh";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(229, 6);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 34;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // frmCongVan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 626);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmCongVan";
            this.Text = "Quản Lý Công Văn";
            this.Load += new System.EventHandler(this.frmCongVan_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQMoNuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvKQDongNuoc;
        private System.Windows.Forms.DataGridView dgvKQMoNuoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuDN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChuyenDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyenDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuMN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChuyenMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyenMN;
        private System.Windows.Forms.Button btnXem;

    }
}