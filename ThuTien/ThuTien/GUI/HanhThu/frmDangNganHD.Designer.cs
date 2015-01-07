namespace ThuTien.GUI.HanhThu
{
    partial class frmDangNganHD
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radDaThu = new System.Windows.Forms.RadioButton();
            this.radChuaThu = new System.Windows.Forms.RadioButton();
            this.cmbDot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongLNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongThueGTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongPhiBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageDaThu = new System.Windows.Forms.TabPage();
            this.tabPageChuaThu = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radChuaThu);
            this.groupBox1.Controls.Add(this.radDaThu);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại Nhập";
            // 
            // radDaThu
            // 
            this.radDaThu.AutoSize = true;
            this.radDaThu.Location = new System.Drawing.Point(6, 19);
            this.radDaThu.Name = "radDaThu";
            this.radDaThu.Size = new System.Drawing.Size(61, 17);
            this.radDaThu.TabIndex = 0;
            this.radDaThu.TabStop = true;
            this.radDaThu.Text = "Đã Thu";
            this.radDaThu.UseVisualStyleBackColor = true;
            // 
            // radChuaThu
            // 
            this.radChuaThu.AutoSize = true;
            this.radChuaThu.Location = new System.Drawing.Point(6, 42);
            this.radChuaThu.Name = "radChuaThu";
            this.radChuaThu.Size = new System.Drawing.Size(72, 17);
            this.radChuaThu.TabIndex = 1;
            this.radChuaThu.TabStop = true;
            this.radChuaThu.Text = "Chưa Thu";
            this.radChuaThu.UseVisualStyleBackColor = true;
            // 
            // cmbDot
            // 
            this.cmbDot.FormattingEnabled = true;
            this.cmbDot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbDot.Location = new System.Drawing.Point(361, 12);
            this.cmbDot.Name = "cmbDot";
            this.cmbDot.Size = new System.Drawing.Size(50, 21);
            this.cmbDot.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Đợt:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(417, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 13;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(272, 12);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(178, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Năm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Danh Sách Hóa Đơn:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(510, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(346, 56);
            this.listBox1.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvHoaDon);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(844, 84);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tổng Hóa Đơn Được Giao";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dot,
            this.TongHD,
            this.TongLNCC,
            this.TongGiaBan,
            this.TongThueGTGT,
            this.TongPhiBVMT,
            this.TongCong});
            this.dgvHoaDon.Location = new System.Drawing.Point(6, 19);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(780, 57);
            this.dgvHoaDon.TabIndex = 6;
            // 
            // Dot
            // 
            this.Dot.DataPropertyName = "Dot";
            this.Dot.HeaderText = "Đợt";
            this.Dot.Name = "Dot";
            // 
            // TongHD
            // 
            this.TongHD.DataPropertyName = "TongHD";
            this.TongHD.HeaderText = "Tổng HĐ";
            this.TongHD.Name = "TongHD";
            // 
            // TongLNCC
            // 
            this.TongLNCC.DataPropertyName = "TongLNCC";
            this.TongLNCC.HeaderText = "Tiêu Thụ";
            this.TongLNCC.Name = "TongLNCC";
            // 
            // TongGiaBan
            // 
            this.TongGiaBan.DataPropertyName = "TongGiaBan";
            this.TongGiaBan.HeaderText = "Giá Bán";
            this.TongGiaBan.Name = "TongGiaBan";
            // 
            // TongThueGTGT
            // 
            this.TongThueGTGT.DataPropertyName = "TongThueGTGT";
            this.TongThueGTGT.HeaderText = "Thuế GTGT";
            this.TongThueGTGT.Name = "TongThueGTGT";
            // 
            // TongPhiBVMT
            // 
            this.TongPhiBVMT.DataPropertyName = "TongPhiBVMT";
            this.TongPhiBVMT.HeaderText = "Phí BVMT";
            this.TongPhiBVMT.Name = "TongPhiBVMT";
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageDaThu);
            this.tabControl.Controls.Add(this.tabPageChuaThu);
            this.tabControl.Location = new System.Drawing.Point(12, 178);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(920, 470);
            this.tabControl.TabIndex = 17;
            // 
            // tabPageDaThu
            // 
            this.tabPageDaThu.Location = new System.Drawing.Point(4, 22);
            this.tabPageDaThu.Name = "tabPageDaThu";
            this.tabPageDaThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDaThu.Size = new System.Drawing.Size(912, 444);
            this.tabPageDaThu.TabIndex = 0;
            this.tabPageDaThu.Text = "Đã Thu";
            this.tabPageDaThu.UseVisualStyleBackColor = true;
            // 
            // tabPageChuaThu
            // 
            this.tabPageChuaThu.Location = new System.Drawing.Point(4, 22);
            this.tabPageChuaThu.Name = "tabPageChuaThu";
            this.tabPageChuaThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChuaThu.Size = new System.Drawing.Size(912, 74);
            this.tabPageChuaThu.TabIndex = 1;
            this.tabPageChuaThu.Text = "Chưa Thu";
            this.tabPageChuaThu.UseVisualStyleBackColor = true;
            // 
            // frmDangNganHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 711);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDangNganHD";
            this.Text = "Đăng Ngân Hóa Đơn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radChuaThu;
        private System.Windows.Forms.RadioButton radDaThu;
        private System.Windows.Forms.ComboBox cmbDot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongLNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThueGTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongPhiBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageDaThu;
        private System.Windows.Forms.TabPage tabPageChuaThu;
    }
}