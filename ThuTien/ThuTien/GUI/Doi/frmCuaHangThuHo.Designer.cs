namespace ThuTien.GUI.Doi
{
    partial class frmCuaHangThuHo
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
            this.btnChonFile = new System.Windows.Forms.Button();
            this.dgvCuaHangThuHo = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioHoatDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuaHangThuHo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 12);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 71;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // dgvCuaHangThuHo
            // 
            this.dgvCuaHangThuHo.AllowUserToAddRows = false;
            this.dgvCuaHangThuHo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCuaHangThuHo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCuaHangThuHo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuaHangThuHo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name1,
            this.DiaChi,
            this.GioHoatDong,
            this.TenDichVu});
            this.dgvCuaHangThuHo.Location = new System.Drawing.Point(12, 41);
            this.dgvCuaHangThuHo.MultiSelect = false;
            this.dgvCuaHangThuHo.Name = "dgvCuaHangThuHo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCuaHangThuHo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCuaHangThuHo.Size = new System.Drawing.Size(716, 465);
            this.dgvCuaHangThuHo.TabIndex = 72;
            this.dgvCuaHangThuHo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuaHangThuHo_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Name1
            // 
            this.Name1.DataPropertyName = "Name";
            this.Name1.HeaderText = "Tên Cửa Hàng";
            this.Name1.Name = "Name1";
            this.Name1.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 300;
            // 
            // GioHoatDong
            // 
            this.GioHoatDong.DataPropertyName = "GioHoatDong";
            this.GioHoatDong.HeaderText = "Giờ Hoạt Động";
            this.GioHoatDong.Name = "GioHoatDong";
            // 
            // TenDichVu
            // 
            this.TenDichVu.DataPropertyName = "TenDichVu";
            this.TenDichVu.HeaderText = "Tên Dịch Vụ";
            this.TenDichVu.Name = "TenDichVu";
            // 
            // frmCuaHangThuHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 535);
            this.Controls.Add(this.dgvCuaHangThuHo);
            this.Controls.Add(this.btnChonFile);
            this.Name = "frmCuaHangThuHo";
            this.Text = "Cửa Hàng Thu Hộ";
            this.Load += new System.EventHandler(this.frmCuaHangThuHo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuaHangThuHo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.DataGridView dgvCuaHangThuHo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioHoatDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDichVu;
    }
}