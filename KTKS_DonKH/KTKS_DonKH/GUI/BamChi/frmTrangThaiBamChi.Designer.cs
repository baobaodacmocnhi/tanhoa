namespace KTKS_DonKH.GUI.BamChi
{
    partial class frmTrangThaiBamChi
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXoaTrangThaiBC = new System.Windows.Forms.Button();
            this.dgvDSTrangThaiBC = new System.Windows.Forms.DataGridView();
            this.MaTTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSuaTrangThaiBC = new System.Windows.Forms.Button();
            this.btnThemTrangThaiBC = new System.Windows.Forms.Button();
            this.txtTrangThaiBC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTrangThaiBC)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXoaTrangThaiBC);
            this.groupBox2.Controls.Add(this.dgvDSTrangThaiBC);
            this.groupBox2.Controls.Add(this.btnSuaTrangThaiBC);
            this.groupBox2.Controls.Add(this.btnThemTrangThaiBC);
            this.groupBox2.Controls.Add(this.txtTrangThaiBC);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(484, 587);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạng Thái Bấm Chì";
            // 
            // btnXoaTrangThaiBC
            // 
            this.btnXoaTrangThaiBC.Location = new System.Drawing.Point(399, 58);
            this.btnXoaTrangThaiBC.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaTrangThaiBC.Name = "btnXoaTrangThaiBC";
            this.btnXoaTrangThaiBC.Size = new System.Drawing.Size(75, 25);
            this.btnXoaTrangThaiBC.TabIndex = 88;
            this.btnXoaTrangThaiBC.Text = "Xóa";
            this.btnXoaTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnXoaTrangThaiBC.Click += new System.EventHandler(this.btnXoaTrangThaiBC_Click);
            // 
            // dgvDSTrangThaiBC
            // 
            this.dgvDSTrangThaiBC.AllowDrop = true;
            this.dgvDSTrangThaiBC.AllowUserToAddRows = false;
            this.dgvDSTrangThaiBC.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSTrangThaiBC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSTrangThaiBC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTrangThaiBC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTTBC,
            this.TenTTBC});
            this.dgvDSTrangThaiBC.Location = new System.Drawing.Point(8, 91);
            this.dgvDSTrangThaiBC.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSTrangThaiBC.MultiSelect = false;
            this.dgvDSTrangThaiBC.Name = "dgvDSTrangThaiBC";
            this.dgvDSTrangThaiBC.Size = new System.Drawing.Size(466, 486);
            this.dgvDSTrangThaiBC.TabIndex = 8;
            this.dgvDSTrangThaiBC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSTrangThaiBC_CellContentClick);
            this.dgvDSTrangThaiBC.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSTrangThaiBC_RowPostPaint);
            this.dgvDSTrangThaiBC.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvDSTrangThaiBC_DragDrop);
            this.dgvDSTrangThaiBC.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvDSTrangThaiBC_DragEnter);
            this.dgvDSTrangThaiBC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDSTrangThaiBC_MouseClick);
            // 
            // MaTTBC
            // 
            this.MaTTBC.DataPropertyName = "MaTTBC";
            this.MaTTBC.HeaderText = "MaTTBC";
            this.MaTTBC.Name = "MaTTBC";
            this.MaTTBC.Visible = false;
            // 
            // TenTTBC
            // 
            this.TenTTBC.DataPropertyName = "TenTTBC";
            this.TenTTBC.HeaderText = "Trạng Thái Bấm Chì";
            this.TenTTBC.Name = "TenTTBC";
            this.TenTTBC.ReadOnly = true;
            this.TenTTBC.Width = 400;
            // 
            // btnSuaTrangThaiBC
            // 
            this.btnSuaTrangThaiBC.Location = new System.Drawing.Point(316, 58);
            this.btnSuaTrangThaiBC.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaTrangThaiBC.Name = "btnSuaTrangThaiBC";
            this.btnSuaTrangThaiBC.Size = new System.Drawing.Size(75, 25);
            this.btnSuaTrangThaiBC.TabIndex = 7;
            this.btnSuaTrangThaiBC.Text = "Sửa";
            this.btnSuaTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnSuaTrangThaiBC.Click += new System.EventHandler(this.btnSuaTrangThaiBC_Click);
            // 
            // btnThemTrangThaiBC
            // 
            this.btnThemTrangThaiBC.Location = new System.Drawing.Point(233, 58);
            this.btnThemTrangThaiBC.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemTrangThaiBC.Name = "btnThemTrangThaiBC";
            this.btnThemTrangThaiBC.Size = new System.Drawing.Size(75, 25);
            this.btnThemTrangThaiBC.TabIndex = 6;
            this.btnThemTrangThaiBC.Text = "Thêm";
            this.btnThemTrangThaiBC.UseVisualStyleBackColor = true;
            this.btnThemTrangThaiBC.Click += new System.EventHandler(this.btnThemTrangThaiBC_Click);
            // 
            // txtTrangThaiBC
            // 
            this.txtTrangThaiBC.Location = new System.Drawing.Point(147, 28);
            this.txtTrangThaiBC.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrangThaiBC.Name = "txtTrangThaiBC";
            this.txtTrangThaiBC.Size = new System.Drawing.Size(327, 22);
            this.txtTrangThaiBC.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trạng Thái Bấm Chì:";
            // 
            // frmTrangThaiBamChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(529, 611);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTrangThaiBamChi";
            this.Text = "Trạng Thái Bấm Chì";
            this.Load += new System.EventHandler(this.frmTrangThaiBamChi_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTrangThaiBC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXoaTrangThaiBC;
        private System.Windows.Forms.DataGridView dgvDSTrangThaiBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTTBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTTBC;
        private System.Windows.Forms.Button btnSuaTrangThaiBC;
        private System.Windows.Forms.Button btnThemTrangThaiBC;
        private System.Windows.Forms.TextBox txtTrangThaiBC;
        private System.Windows.Forms.Label label2;
    }
}