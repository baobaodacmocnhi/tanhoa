namespace KTKS_DonKH.GUI.CapNhat
{
    partial class frmVeViecCHDB
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
            this.txtNoiNhan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDSVeViecTTTL = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVeViec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MaVV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSVeViecTTTL)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoiNhan
            // 
            this.txtNoiNhan.Location = new System.Drawing.Point(651, 58);
            this.txtNoiNhan.Multiline = true;
            this.txtNoiNhan.Name = "txtNoiNhan";
            this.txtNoiNhan.Size = new System.Drawing.Size(131, 201);
            this.txtNoiNhan.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(648, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nơi Nhận:";
            // 
            // dgvDSVeViecTTTL
            // 
            this.dgvDSVeViecTTTL.AllowUserToAddRows = false;
            this.dgvDSVeViecTTTL.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSVeViecTTTL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSVeViecTTTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSVeViecTTTL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVV,
            this.TenVV,
            this.NoiDung,
            this.NoiNhan});
            this.dgvDSVeViecTTTL.Location = new System.Drawing.Point(17, 264);
            this.dgvDSVeViecTTTL.Name = "dgvDSVeViecTTTL";
            this.dgvDSVeViecTTTL.Size = new System.Drawing.Size(765, 217);
            this.dgvDSVeViecTTTL.TabIndex = 17;
            this.dgvDSVeViecTTTL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSVeViecTTTL_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(787, 228);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(17, 58);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(630, 201);
            this.txtNoiDung.TabIndex = 12;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(868, 228);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nội Dung:";
            // 
            // txtVeViec
            // 
            this.txtVeViec.Location = new System.Drawing.Point(76, 11);
            this.txtVeViec.Name = "txtVeViec";
            this.txtVeViec.Size = new System.Drawing.Size(706, 21);
            this.txtVeViec.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Về Việc:";
            // 
            // MaVV
            // 
            this.MaVV.DataPropertyName = "MaVV";
            this.MaVV.HeaderText = "MaVV";
            this.MaVV.Name = "MaVV";
            this.MaVV.Visible = false;
            // 
            // TenVV
            // 
            this.TenVV.DataPropertyName = "TenVV";
            this.TenVV.HeaderText = "Về Việc";
            this.TenVV.Name = "TenVV";
            this.TenVV.ReadOnly = true;
            this.TenVV.Width = 200;
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
            // frmVeViecCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1011, 509);
            this.Controls.Add(this.txtNoiNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDSVeViecTTTL);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVeViec);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVeViecCHDB";
            this.Text = "Về Việc CHDB";
            this.Load += new System.EventHandler(this.frmVeViecCHDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSVeViecTTTL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoiNhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDSVeViecTTTL;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVeViec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiNhan;
    }
}