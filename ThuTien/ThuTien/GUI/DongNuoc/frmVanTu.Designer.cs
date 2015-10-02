namespace ThuTien.GUI.DongNuoc
{
    partial class frmVanTu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnXoaDK = new System.Windows.Forms.Button();
            this.btnThemDK = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDanhBoDK = new System.Windows.Forms.TextBox();
            this.dgvVanTu = new System.Windows.Forms.DataGridView();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVanTu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoaDK
            // 
            this.btnXoaDK.Location = new System.Drawing.Point(294, 10);
            this.btnXoaDK.Name = "btnXoaDK";
            this.btnXoaDK.Size = new System.Drawing.Size(75, 23);
            this.btnXoaDK.TabIndex = 77;
            this.btnXoaDK.Text = "Xóa";
            this.btnXoaDK.UseVisualStyleBackColor = true;
            this.btnXoaDK.Click += new System.EventHandler(this.btnXoaDK_Click);
            // 
            // btnThemDK
            // 
            this.btnThemDK.Location = new System.Drawing.Point(213, 10);
            this.btnThemDK.Name = "btnThemDK";
            this.btnThemDK.Size = new System.Drawing.Size(75, 23);
            this.btnThemDK.TabIndex = 76;
            this.btnThemDK.Text = "Thêm";
            this.btnThemDK.UseVisualStyleBackColor = true;
            this.btnThemDK.Click += new System.EventHandler(this.btnThemDK_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Danh Bộ:";
            // 
            // txtDanhBoDK
            // 
            this.txtDanhBoDK.Location = new System.Drawing.Point(107, 12);
            this.txtDanhBoDK.Name = "txtDanhBoDK";
            this.txtDanhBoDK.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBoDK.TabIndex = 75;
            this.txtDanhBoDK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBoDK_KeyPress);
            // 
            // dgvVanTu
            // 
            this.dgvVanTu.AllowUserToAddRows = false;
            this.dgvVanTu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVanTu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvVanTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVanTu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo,
            this.DiaChi,
            this.To,
            this.HanhThu});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVanTu.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvVanTu.Location = new System.Drawing.Point(12, 38);
            this.dgvVanTu.Name = "dgvVanTu";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvVanTu.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvVanTu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVanTu.Size = new System.Drawing.Size(992, 381);
            this.dgvVanTu.TabIndex = 78;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
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
            this.HanhThu.Width = 150;
            // 
            // frmVanTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 448);
            this.Controls.Add(this.dgvVanTu);
            this.Controls.Add(this.btnXoaDK);
            this.Controls.Add(this.btnThemDK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDanhBoDK);
            this.Name = "frmVanTu";
            this.Text = "Van Từ";
            this.Load += new System.EventHandler(this.frmVanTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVanTu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXoaDK;
        private System.Windows.Forms.Button btnThemDK;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDanhBoDK;
        private System.Windows.Forms.DataGridView dgvVanTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
    }
}