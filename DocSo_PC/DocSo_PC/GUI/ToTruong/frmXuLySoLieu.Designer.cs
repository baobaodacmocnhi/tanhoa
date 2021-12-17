namespace DocSo_PC.GUI.ToTruong
{
    partial class frmXuLySoLieu
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
            this.lbTo = new System.Windows.Forms.Label();
            this.cmbMay = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.cmbDot = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.cmbCode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.DocSoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTDHNCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTDHNMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThuMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCodeMoi = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCSC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCSM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTieuThu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(9, 12);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(32, 19);
            this.lbTo.TabIndex = 43;
            this.lbTo.Text = "Tổ:";
            // 
            // cmbMay
            // 
            this.cmbMay.FormattingEnabled = true;
            this.cmbMay.Location = new System.Drawing.Point(426, 12);
            this.cmbMay.Name = "cmbMay";
            this.cmbMay.Size = new System.Drawing.Size(60, 21);
            this.cmbMay.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Máy";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbTo.Location = new System.Drawing.Point(47, 12);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(100, 21);
            this.cmbTo.TabIndex = 40;
            this.cmbTo.Visible = false;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // cmbDot
            // 
            this.cmbDot.FormattingEnabled = true;
            this.cmbDot.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
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
            this.cmbDot.Location = new System.Drawing.Point(348, 12);
            this.cmbDot.Name = "cmbDot";
            this.cmbDot.Size = new System.Drawing.Size(39, 21);
            this.cmbDot.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Đợt";
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(275, 12);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(37, 21);
            this.cmbKy.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Năm ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Kỳ ";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(191, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(50, 21);
            this.cmbNam.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(573, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Danh Bộ";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(628, 14);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 51;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // cmbCode
            // 
            this.cmbCode.FormattingEnabled = true;
            this.cmbCode.Location = new System.Drawing.Point(772, 13);
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.Size = new System.Drawing.Size(60, 21);
            this.cmbCode.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(734, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Code";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(492, 11);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 54;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocSoID,
            this.MLT,
            this.DanhBo,
            this.TTDHNCu,
            this.TTDHNMoi,
            this.CodeCu,
            this.CodeMoi,
            this.CSCu,
            this.CSMoi,
            this.TieuThuMoi,
            this.TBTT});
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 121);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Size = new System.Drawing.Size(948, 485);
            this.dgvDanhSach.TabIndex = 55;
            // 
            // DocSoID
            // 
            this.DocSoID.DataPropertyName = "DocSoID";
            this.DocSoID.HeaderText = "DocSoID";
            this.DocSoID.Name = "DocSoID";
            this.DocSoID.Visible = false;
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // TTDHNCu
            // 
            this.TTDHNCu.DataPropertyName = "TTDHNCu";
            this.TTDHNCu.HeaderText = "TTĐHN Cũ";
            this.TTDHNCu.Name = "TTDHNCu";
            // 
            // TTDHNMoi
            // 
            this.TTDHNMoi.DataPropertyName = "TTDHNMoi";
            this.TTDHNMoi.HeaderText = "TTĐHN Mới";
            this.TTDHNMoi.Name = "TTDHNMoi";
            // 
            // CodeCu
            // 
            this.CodeCu.DataPropertyName = "CodeCu";
            this.CodeCu.HeaderText = "Code Cũ";
            this.CodeCu.Name = "CodeCu";
            this.CodeCu.Width = 80;
            // 
            // CodeMoi
            // 
            this.CodeMoi.DataPropertyName = "CodeMoi";
            this.CodeMoi.HeaderText = "Code Mới";
            this.CodeMoi.Name = "CodeMoi";
            this.CodeMoi.Width = 80;
            // 
            // CSCu
            // 
            this.CSCu.DataPropertyName = "CSCu";
            this.CSCu.HeaderText = "CS Cũ";
            this.CSCu.Name = "CSCu";
            this.CSCu.Width = 80;
            // 
            // CSMoi
            // 
            this.CSMoi.DataPropertyName = "CSMoi";
            this.CSMoi.HeaderText = "CS Mới";
            this.CSMoi.Name = "CSMoi";
            this.CSMoi.Width = 80;
            // 
            // TieuThuMoi
            // 
            this.TieuThuMoi.DataPropertyName = "TieuThuMoi";
            this.TieuThuMoi.HeaderText = "Tiêu Thụ";
            this.TieuThuMoi.Name = "TieuThuMoi";
            this.TieuThuMoi.Width = 80;
            // 
            // TBTT
            // 
            this.TBTT.DataPropertyName = "TBTT";
            this.TBTT.HeaderText = "TBTT";
            this.TBTT.Name = "TBTT";
            this.TBTT.Width = 80;
            // 
            // cmbCodeMoi
            // 
            this.cmbCodeMoi.FormattingEnabled = true;
            this.cmbCodeMoi.Location = new System.Drawing.Point(209, 39);
            this.cmbCodeMoi.Name = "cmbCodeMoi";
            this.cmbCodeMoi.Size = new System.Drawing.Size(60, 21);
            this.cmbCodeMoi.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(151, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Code Mới";
            // 
            // txtCSC
            // 
            this.txtCSC.Location = new System.Drawing.Point(330, 38);
            this.txtCSC.Name = "txtCSC";
            this.txtCSC.Size = new System.Drawing.Size(50, 20);
            this.txtCSC.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "CS Cũ";
            // 
            // txtCSM
            // 
            this.txtCSM.Location = new System.Drawing.Point(433, 38);
            this.txtCSM.Name = "txtCSM";
            this.txtCSM.Size = new System.Drawing.Size(50, 20);
            this.txtCSM.TabIndex = 61;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(386, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "CS Mới";
            // 
            // txtTieuThu
            // 
            this.txtTieuThu.Location = new System.Drawing.Point(545, 38);
            this.txtTieuThu.Name = "txtTieuThu";
            this.txtTieuThu.Size = new System.Drawing.Size(50, 20);
            this.txtTieuThu.TabIndex = 63;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(489, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Tiêu Thụ";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(601, 36);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 64;
            this.btnSua.Text = "Cập Nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // frmXuLySoLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(993, 636);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.txtTieuThu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCSM);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCSC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbCodeMoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.cmbMay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTo);
            this.Name = "frmXuLySoLieu";
            this.Text = "Xử Lý Số Liệu";
            this.Load += new System.EventHandler(this.frmXuLySoLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.ComboBox cmbMay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.ComboBox cmbDot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.ComboBox cmbCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocSoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTDHNCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTDHNMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThuMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBTT;
        private System.Windows.Forms.ComboBox cmbCodeMoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCSC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCSM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTieuThu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSua;
    }
}