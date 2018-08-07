namespace KTKS_DonKH.GUI.ThuMoi
{
    partial class frmThaoThuMoi
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
            this.txtMaDonMoi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVeViec = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVaoLuc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCanCu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMaDonCu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoTrinh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDinhMuc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiaBieu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDSThu = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VaoLuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radDutChi = new System.Windows.Forms.RadioButton();
            this.radCDDM = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThu)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaDonMoi
            // 
            this.txtMaDonMoi.Location = new System.Drawing.Point(427, 12);
            this.txtMaDonMoi.Name = "txtMaDonMoi";
            this.txtMaDonMoi.Size = new System.Drawing.Size(80, 22);
            this.txtMaDonMoi.TabIndex = 129;
            this.txtMaDonMoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDonMoi_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(329, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 16);
            this.label15.TabIndex = 128;
            this.label15.Text = "Mã Đơn(New):";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(674, 185);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 25);
            this.btnIn.TabIndex = 127;
            this.btnIn.Text = "In Thư";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(584, 195);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 126;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(584, 164);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 125;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(584, 133);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 122;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtVeViec);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtVaoLuc);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtCanCu);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 109);
            this.groupBox2.TabIndex = 121;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nội Dung Thư";
            // 
            // txtVeViec
            // 
            this.txtVeViec.Location = new System.Drawing.Point(70, 77);
            this.txtVeViec.Name = "txtVeViec";
            this.txtVeViec.Size = new System.Drawing.Size(487, 22);
            this.txtVeViec.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Về Việc:";
            // 
            // txtVaoLuc
            // 
            this.txtVaoLuc.Location = new System.Drawing.Point(70, 49);
            this.txtVaoLuc.Name = "txtVaoLuc";
            this.txtVaoLuc.Size = new System.Drawing.Size(487, 22);
            this.txtVaoLuc.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Vào Lúc:";
            // 
            // txtCanCu
            // 
            this.txtCanCu.Location = new System.Drawing.Point(70, 21);
            this.txtCanCu.Name = "txtCanCu";
            this.txtCanCu.Size = new System.Drawing.Size(487, 22);
            this.txtCanCu.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Căn Cứ:";
            // 
            // txtMaDonCu
            // 
            this.txtMaDonCu.Location = new System.Drawing.Point(248, 12);
            this.txtMaDonCu.Name = "txtMaDonCu";
            this.txtMaDonCu.Size = new System.Drawing.Size(75, 22);
            this.txtMaDonCu.TabIndex = 119;
            this.txtMaDonCu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDonCu_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(166, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 16);
            this.label21.TabIndex = 118;
            this.label21.Text = "Mã Đơn Cũ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoTrinh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDinhMuc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGiaBieu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHopDong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 87);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtLoTrinh
            // 
            this.txtLoTrinh.Location = new System.Drawing.Point(432, 24);
            this.txtLoTrinh.Name = "txtLoTrinh";
            this.txtLoTrinh.Size = new System.Drawing.Size(100, 22);
            this.txtLoTrinh.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Lộ Trình:";
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(718, 24);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(35, 22);
            this.txtDinhMuc.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(647, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Định Mức:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(606, 24);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(35, 22);
            this.txtGiaBieu.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(538, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giá Biểu:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(422, 52);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(331, 22);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(98, 52);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(260, 22);
            this.txtHoTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng:";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(261, 24);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(100, 22);
            this.txtHopDong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hợp Đồng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(77, 24);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
            // 
            // dgvDSThu
            // 
            this.dgvDSThu.AllowUserToAddRows = false;
            this.dgvDSThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Lan,
            this.CreateDate,
            this.CanCu,
            this.VaoLuc});
            this.dgvDSThu.Location = new System.Drawing.Point(12, 257);
            this.dgvDSThu.Name = "dgvDSThu";
            this.dgvDSThu.Size = new System.Drawing.Size(647, 126);
            this.dgvDSThu.TabIndex = 130;
            this.dgvDSThu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSThu_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Lan
            // 
            this.Lan.DataPropertyName = "Lan";
            this.Lan.HeaderText = "Lần";
            this.Lan.Name = "Lan";
            this.Lan.Width = 50;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // CanCu
            // 
            this.CanCu.DataPropertyName = "CanCu";
            this.CanCu.HeaderText = "Căn Cứ";
            this.CanCu.Name = "CanCu";
            this.CanCu.Width = 200;
            // 
            // VaoLuc
            // 
            this.VaoLuc.DataPropertyName = "VaoLuc";
            this.VaoLuc.HeaderText = "Vào Lúc";
            this.VaoLuc.Name = "VaoLuc";
            this.VaoLuc.Width = 200;
            // 
            // radDutChi
            // 
            this.radDutChi.AutoSize = true;
            this.radDutChi.Location = new System.Drawing.Point(674, 133);
            this.radDutChi.Name = "radDutChi";
            this.radDutChi.Size = new System.Drawing.Size(67, 20);
            this.radDutChi.TabIndex = 131;
            this.radDutChi.TabStop = true;
            this.radDutChi.Text = "Đứt Chì";
            this.radDutChi.UseVisualStyleBackColor = true;
            // 
            // radCDDM
            // 
            this.radCDDM.AutoSize = true;
            this.radCDDM.Location = new System.Drawing.Point(674, 159);
            this.radCDDM.Name = "radCDDM";
            this.radCDDM.Size = new System.Drawing.Size(64, 20);
            this.radCDDM.TabIndex = 132;
            this.radCDDM.TabStop = true;
            this.radCDDM.Text = "CĐĐM";
            this.radCDDM.UseVisualStyleBackColor = true;
            // 
            // frmThaoThuMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(853, 396);
            this.Controls.Add(this.radCDDM);
            this.Controls.Add(this.radDutChi);
            this.Controls.Add(this.dgvDSThu);
            this.Controls.Add(this.txtMaDonMoi);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMaDonCu);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThaoThuMoi";
            this.Text = "Thảo Thư Mời";
            this.Load += new System.EventHandler(this.frmThaoThuMoi_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaDonMoi;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCanCu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMaDonCu;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLoTrinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDinhMuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiaBieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVeViec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVaoLuc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvDSThu;
        private System.Windows.Forms.RadioButton radDutChi;
        private System.Windows.Forms.RadioButton radCDDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn VaoLuc;
    }
}