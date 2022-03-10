namespace DocSo_PC.GUI.ToTruong
{
    partial class frmXemLichSuXuLy
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
            this.dgvGhiChu = new System.Windows.Forms.DataGridView();
            this.NamKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhiChu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGhiChu
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGhiChu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGhiChu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGhiChu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NamKy,
            this.OldValue,
            this.NewValue,
            this.EditTime,
            this.UserName});
            this.dgvGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGhiChu.Location = new System.Drawing.Point(0, 0);
            this.dgvGhiChu.Name = "dgvGhiChu";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvGhiChu.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGhiChu.Size = new System.Drawing.Size(726, 328);
            this.dgvGhiChu.TabIndex = 1;
            // 
            // NamKy
            // 
            this.NamKy.DataPropertyName = "NamKy";
            this.NamKy.HeaderText = "Kỳ";
            this.NamKy.Name = "NamKy";
            this.NamKy.Width = 60;
            // 
            // OldValue
            // 
            this.OldValue.DataPropertyName = "OldValue";
            this.OldValue.HeaderText = "Cũ";
            this.OldValue.Name = "OldValue";
            this.OldValue.Width = 200;
            // 
            // NewValue
            // 
            this.NewValue.DataPropertyName = "NewValue";
            this.NewValue.HeaderText = "Mới";
            this.NewValue.Name = "NewValue";
            this.NewValue.Width = 200;
            // 
            // EditTime
            // 
            this.EditTime.DataPropertyName = "EditTime";
            this.EditTime.HeaderText = "Ngày Cập Nhật";
            this.EditTime.Name = "EditTime";
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Người Cập Nhật";
            this.UserName.Name = "UserName";
            // 
            // frmXemLichSuXuLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 328);
            this.Controls.Add(this.dgvGhiChu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXemLichSuXuLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ghi Chú";
            this.Load += new System.EventHandler(this.frmXemLichSuXuLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhiChu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
    }
}