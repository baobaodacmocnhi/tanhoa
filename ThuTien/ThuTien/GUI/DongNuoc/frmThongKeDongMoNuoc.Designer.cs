namespace ThuTien.GUI.DongNuoc
{
    partial class frmThongKeDongMoNuoc
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
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvKQDongNuoc = new System.Windows.Forms.DataGridView();
            this.MaTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DongNuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoNuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongDongNuoc = new System.Windows.Forms.TextBox();
            this.txtTongMoNuoc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(345, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 34;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(239, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(69, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Từ Ngày:";
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
            this.MaTo,
            this.TenTo,
            this.DongNuoc,
            this.MoNuoc});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKQDongNuoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKQDongNuoc.Location = new System.Drawing.Point(12, 38);
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
            this.dgvKQDongNuoc.Size = new System.Drawing.Size(360, 121);
            this.dgvKQDongNuoc.TabIndex = 35;
            // 
            // MaTo
            // 
            this.MaTo.DataPropertyName = "MaTo";
            this.MaTo.HeaderText = "MaTo";
            this.MaTo.Name = "MaTo";
            this.MaTo.Visible = false;
            // 
            // TenTo
            // 
            this.TenTo.DataPropertyName = "TenTo";
            this.TenTo.HeaderText = "Tên Tổ";
            this.TenTo.Name = "TenTo";
            // 
            // DongNuoc
            // 
            this.DongNuoc.DataPropertyName = "DongNuoc";
            this.DongNuoc.HeaderText = "Đóng Nước";
            this.DongNuoc.Name = "DongNuoc";
            // 
            // MoNuoc
            // 
            this.MoNuoc.DataPropertyName = "MoNuoc";
            this.MoNuoc.HeaderText = "Mở Nước";
            this.MoNuoc.Name = "MoNuoc";
            // 
            // txtTongDongNuoc
            // 
            this.txtTongDongNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDongNuoc.Location = new System.Drawing.Point(154, 159);
            this.txtTongDongNuoc.Name = "txtTongDongNuoc";
            this.txtTongDongNuoc.Size = new System.Drawing.Size(100, 20);
            this.txtTongDongNuoc.TabIndex = 36;
            this.txtTongDongNuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongMoNuoc
            // 
            this.txtTongMoNuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongMoNuoc.Location = new System.Drawing.Point(254, 159);
            this.txtTongMoNuoc.Name = "txtTongMoNuoc";
            this.txtTongMoNuoc.Size = new System.Drawing.Size(100, 20);
            this.txtTongMoNuoc.TabIndex = 37;
            this.txtTongMoNuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmThongKeDongMoNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 236);
            this.Controls.Add(this.txtTongMoNuoc);
            this.Controls.Add(this.txtTongDongNuoc);
            this.Controls.Add(this.dgvKQDongNuoc);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label5);
            this.Name = "frmThongKeDongMoNuoc";
            this.Text = "Thống Kê Đóng Mở Nước";
            this.Load += new System.EventHandler(this.frmThongKeDongMoNuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQDongNuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvKQDongNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DongNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoNuoc;
        private System.Windows.Forms.TextBox txtTongDongNuoc;
        private System.Windows.Forms.TextBox txtTongMoNuoc;
    }
}