namespace KTKS_DonKH.GUI.ThuTraLoi
{
    partial class frmToTrinhVeViec
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
            this.dgvDSVeViecTTTL = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVeViec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiNhan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSVeViecTTTL)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSVeViecTTTL
            // 
            this.dgvDSVeViecTTTL.AllowDrop = true;
            this.dgvDSVeViecTTTL.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSVeViecTTTL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSVeViecTTTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSVeViecTTTL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Namee,
            this.NoiDung,
            this.NoiNhan});
            this.dgvDSVeViecTTTL.Location = new System.Drawing.Point(12, 272);
            this.dgvDSVeViecTTTL.MultiSelect = false;
            this.dgvDSVeViecTTTL.Name = "dgvDSVeViecTTTL";
            this.dgvDSVeViecTTTL.Size = new System.Drawing.Size(870, 335);
            this.dgvDSVeViecTTTL.TabIndex = 8;
            this.dgvDSVeViecTTTL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSVeViecTTTL_CellContentClick);
            this.dgvDSVeViecTTTL.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSVeViecTTTL_RowPostPaint);
            this.dgvDSVeViecTTTL.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvDSVeViecTTTL_DragDrop);
            this.dgvDSVeViecTTTL.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvDSVeViecTTTL_DragEnter);
            this.dgvDSVeViecTTTL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDSVeViecTTTL_MouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "MaVV";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Namee
            // 
            this.Namee.DataPropertyName = "Name";
            this.Namee.HeaderText = "Về Việc";
            this.Namee.Name = "Namee";
            this.Namee.ReadOnly = true;
            this.Namee.Width = 300;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 350;
            // 
            // NoiNhan
            // 
            this.NoiNhan.DataPropertyName = "NoiNhan";
            this.NoiNhan.HeaderText = "Nơi Nhận";
            this.NoiNhan.Name = "NoiNhan";
            this.NoiNhan.ReadOnly = true;
            this.NoiNhan.Width = 150;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(783, 208);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(783, 177);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(12, 52);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDung.Size = new System.Drawing.Size(610, 214);
            this.txtNoiDung.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nội Dung:";
            // 
            // txtVeViec
            // 
            this.txtVeViec.Location = new System.Drawing.Point(80, 2);
            this.txtVeViec.Name = "txtVeViec";
            this.txtVeViec.Size = new System.Drawing.Size(542, 22);
            this.txtVeViec.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Về Việc:";
            // 
            // txtNoiNhan
            // 
            this.txtNoiNhan.Location = new System.Drawing.Point(628, 52);
            this.txtNoiNhan.Multiline = true;
            this.txtNoiNhan.Name = "txtNoiNhan";
            this.txtNoiNhan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiNhan.Size = new System.Drawing.Size(149, 214);
            this.txtNoiNhan.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(625, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nơi Nhận:";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(783, 239);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmToTrinhVeViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(919, 625);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtNoiNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDSVeViecTTTL);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVeViec);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmToTrinhVeViec";
            this.Text = "Về Việc Tờ Trình";
            this.Load += new System.EventHandler(this.frmVeViecTTTL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSVeViecTTTL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSVeViecTTTL;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVeViec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiNhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namee;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiNhan;

    }
}