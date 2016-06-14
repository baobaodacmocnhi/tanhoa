namespace ThuTien.GUI.Doi
{
    partial class frmTinhGiaBanBinhQuan
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
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvGiaBanBinhQuan = new System.Windows.Forms.DataGridView();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBanBinhQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.txtTongSanLuong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaBanBinhQuan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(210, 11);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 54;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(144, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Năm:";
            // 
            // dgvGiaBanBinhQuan
            // 
            this.dgvGiaBanBinhQuan.AllowUserToAddRows = false;
            this.dgvGiaBanBinhQuan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGiaBanBinhQuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGiaBanBinhQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaBanBinhQuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ky,
            this.TongGiaBan,
            this.TongTieuThu,
            this.GiaBanBinhQuan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGiaBanBinhQuan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGiaBanBinhQuan.Location = new System.Drawing.Point(68, 40);
            this.dgvGiaBanBinhQuan.Name = "dgvGiaBanBinhQuan";
            this.dgvGiaBanBinhQuan.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGiaBanBinhQuan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvGiaBanBinhQuan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGiaBanBinhQuan.Size = new System.Drawing.Size(412, 300);
            this.dgvGiaBanBinhQuan.TabIndex = 57;
            this.dgvGiaBanBinhQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGiaBanBinhQuan_CellFormatting);
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.ReadOnly = true;
            this.Ky.Width = 50;
            // 
            // TongGiaBan
            // 
            this.TongGiaBan.DataPropertyName = "TongGiaBan";
            this.TongGiaBan.HeaderText = "Doanh Thu";
            this.TongGiaBan.Name = "TongGiaBan";
            this.TongGiaBan.ReadOnly = true;
            // 
            // TongTieuThu
            // 
            this.TongTieuThu.DataPropertyName = "TongTieuThu";
            this.TongTieuThu.HeaderText = "Sản Lượng";
            this.TongTieuThu.Name = "TongTieuThu";
            this.TongTieuThu.ReadOnly = true;
            // 
            // GiaBanBinhQuan
            // 
            this.GiaBanBinhQuan.DataPropertyName = "GiaBanBinhQuan";
            this.GiaBanBinhQuan.HeaderText = "Giá Bán Bình Quân";
            this.GiaBanBinhQuan.Name = "GiaBanBinhQuan";
            this.GiaBanBinhQuan.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Giá Billing";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDoanhThu.Location = new System.Drawing.Point(159, 340);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.Size = new System.Drawing.Size(100, 20);
            this.txtTongDoanhThu.TabIndex = 59;
            this.txtTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongSanLuong
            // 
            this.txtTongSanLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSanLuong.Location = new System.Drawing.Point(259, 340);
            this.txtTongSanLuong.Name = "txtTongSanLuong";
            this.txtTongSanLuong.Size = new System.Drawing.Size(100, 20);
            this.txtTongSanLuong.TabIndex = 60;
            this.txtTongSanLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTinhGiaBanBinhQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 412);
            this.Controls.Add(this.txtTongSanLuong);
            this.Controls.Add(this.txtTongDoanhThu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvGiaBanBinhQuan);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label2);
            this.Name = "frmTinhGiaBanBinhQuan";
            this.Text = "Tính Giá Bán Bình Quân";
            this.Load += new System.EventHandler(this.frmTinhGiaBanBinhQuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaBanBinhQuan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvGiaBanBinhQuan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBanBinhQuan;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.TextBox txtTongSanLuong;
    }
}