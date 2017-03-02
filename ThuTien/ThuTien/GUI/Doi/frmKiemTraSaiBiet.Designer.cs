namespace ThuTien.GUI.Doi
{
    partial class frmKiemTraSaiBiet
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
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateGiaiTrach = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTongHD_Billing = new System.Windows.Forms.TextBox();
            this.lstView_Billing = new System.Windows.Forms.ListView();
            this.SoHoaDon_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ky_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongCong_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DanhBo_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnChonFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTongHD_TH = new System.Windows.Forms.TextBox();
            this.lstView_TH = new System.Windows.Forms.ListView();
            this.SoHoaDon_TH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ky_TH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongCong_TH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DanhBo_TH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnKiemTraAll = new System.Windows.Forms.Button();
            this.lstViewA = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstViewB = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnChonFileA = new System.Windows.Forms.Button();
            this.btnChonFileB = new System.Windows.Forms.Button();
            this.txtTongA = new System.Windows.Forms.TextBox();
            this.txtTongB = new System.Windows.Forms.TextBox();
            this.btnCopyToClipboardA = new System.Windows.Forms.Button();
            this.btnCopyToClipboardB = new System.Windows.Forms.Button();
            this.btnCopyToClipboard_Billing = new System.Windows.Forms.Button();
            this.btnCopyToClipboard_TH = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoiDungA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(370, 12);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Nhân Viên:";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(248, 11);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(50, 21);
            this.cmbTo.TabIndex = 46;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tổ:";
            // 
            // dateGiaiTrach
            // 
            this.dateGiaiTrach.CustomFormat = "dd/MM/yyyy";
            this.dateGiaiTrach.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaiTrach.Location = new System.Drawing.Point(125, 20);
            this.dateGiaiTrach.Name = "dateGiaiTrach";
            this.dateGiaiTrach.Size = new System.Drawing.Size(100, 20);
            this.dateGiaiTrach.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Ngày Giải Trách:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(231, 19);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 51;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCopyToClipboard_Billing);
            this.groupBox1.Controls.Add(this.txtTongHD_Billing);
            this.groupBox1.Controls.Add(this.lstView_Billing);
            this.groupBox1.Controls.Add(this.btnChonFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 479);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Billing";
            // 
            // txtTongHD_Billing
            // 
            this.txtTongHD_Billing.Location = new System.Drawing.Point(6, 424);
            this.txtTongHD_Billing.Name = "txtTongHD_Billing";
            this.txtTongHD_Billing.Size = new System.Drawing.Size(100, 20);
            this.txtTongHD_Billing.TabIndex = 54;
            // 
            // lstView_Billing
            // 
            this.lstView_Billing.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SoHoaDon_B,
            this.Ky_B,
            this.TongCong_B,
            this.DanhBo_B});
            this.lstView_Billing.Location = new System.Drawing.Point(6, 48);
            this.lstView_Billing.Name = "lstView_Billing";
            this.lstView_Billing.Size = new System.Drawing.Size(346, 370);
            this.lstView_Billing.TabIndex = 53;
            this.lstView_Billing.UseCompatibleStateImageBehavior = false;
            this.lstView_Billing.View = System.Windows.Forms.View.Details;
            // 
            // SoHoaDon_B
            // 
            this.SoHoaDon_B.Text = "Số Hóa Đơn";
            this.SoHoaDon_B.Width = 100;
            // 
            // Ky_B
            // 
            this.Ky_B.Text = "Kỳ";
            // 
            // TongCong_B
            // 
            this.TongCong_B.Text = "Tổng Cộng";
            this.TongCong_B.Width = 70;
            // 
            // DanhBo_B
            // 
            this.DanhBo_B.Text = "Danh Bộ";
            this.DanhBo_B.Width = 100;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(54, 19);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 52;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCopyToClipboard_TH);
            this.groupBox2.Controls.Add(this.txtTongHD_TH);
            this.groupBox2.Controls.Add(this.lstView_TH);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dateGiaiTrach);
            this.groupBox2.Controls.Add(this.btnXem);
            this.groupBox2.Location = new System.Drawing.Point(459, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 479);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tân Hòa";
            // 
            // txtTongHD_TH
            // 
            this.txtTongHD_TH.Location = new System.Drawing.Point(6, 424);
            this.txtTongHD_TH.Name = "txtTongHD_TH";
            this.txtTongHD_TH.Size = new System.Drawing.Size(100, 20);
            this.txtTongHD_TH.TabIndex = 55;
            // 
            // lstView_TH
            // 
            this.lstView_TH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SoHoaDon_TH,
            this.Ky_TH,
            this.TongCong_TH,
            this.DanhBo_TH});
            this.lstView_TH.Location = new System.Drawing.Point(6, 48);
            this.lstView_TH.Name = "lstView_TH";
            this.lstView_TH.Size = new System.Drawing.Size(346, 370);
            this.lstView_TH.TabIndex = 54;
            this.lstView_TH.UseCompatibleStateImageBehavior = false;
            this.lstView_TH.View = System.Windows.Forms.View.Details;
            // 
            // SoHoaDon_TH
            // 
            this.SoHoaDon_TH.Text = "Số Hóa Đơn";
            this.SoHoaDon_TH.Width = 100;
            // 
            // Ky_TH
            // 
            this.Ky_TH.Text = "Kỳ";
            // 
            // TongCong_TH
            // 
            this.TongCong_TH.Text = "Tổng Cộng";
            this.TongCong_TH.Width = 70;
            // 
            // DanhBo_TH
            // 
            this.DanhBo_TH.Text = "Danh Bộ";
            this.DanhBo_TH.Width = 100;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(378, 87);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(75, 23);
            this.btnKiemTra.TabIndex = 54;
            this.btnKiemTra.Text = "Kiểm Tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnKiemTraAll
            // 
            this.btnKiemTraAll.Location = new System.Drawing.Point(951, 119);
            this.btnKiemTraAll.Name = "btnKiemTraAll";
            this.btnKiemTraAll.Size = new System.Drawing.Size(75, 23);
            this.btnKiemTraAll.TabIndex = 57;
            this.btnKiemTraAll.Text = "Kiểm Tra";
            this.btnKiemTraAll.UseVisualStyleBackColor = true;
            this.btnKiemTraAll.Click += new System.EventHandler(this.btnKiemTraAll_Click);
            // 
            // lstViewA
            // 
            this.lstViewA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstViewA.Location = new System.Drawing.Point(825, 119);
            this.lstViewA.Name = "lstViewA";
            this.lstViewA.Size = new System.Drawing.Size(120, 373);
            this.lstViewA.TabIndex = 58;
            this.lstViewA.UseCompatibleStateImageBehavior = false;
            this.lstViewA.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nội Dung";
            this.columnHeader1.Width = 100;
            // 
            // lstViewB
            // 
            this.lstViewB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lstViewB.Location = new System.Drawing.Point(1032, 119);
            this.lstViewB.Name = "lstViewB";
            this.lstViewB.Size = new System.Drawing.Size(120, 373);
            this.lstViewB.TabIndex = 59;
            this.lstViewB.UseCompatibleStateImageBehavior = false;
            this.lstViewB.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nội Dung";
            this.columnHeader2.Width = 100;
            // 
            // btnChonFileA
            // 
            this.btnChonFileA.Location = new System.Drawing.Point(825, 39);
            this.btnChonFileA.Name = "btnChonFileA";
            this.btnChonFileA.Size = new System.Drawing.Size(75, 23);
            this.btnChonFileA.TabIndex = 60;
            this.btnChonFileA.Text = "Chọn File";
            this.btnChonFileA.UseVisualStyleBackColor = true;
            this.btnChonFileA.Click += new System.EventHandler(this.btnChonFileA_Click);
            // 
            // btnChonFileB
            // 
            this.btnChonFileB.Location = new System.Drawing.Point(1032, 39);
            this.btnChonFileB.Name = "btnChonFileB";
            this.btnChonFileB.Size = new System.Drawing.Size(75, 23);
            this.btnChonFileB.TabIndex = 61;
            this.btnChonFileB.Text = "Chọn File";
            this.btnChonFileB.UseVisualStyleBackColor = true;
            this.btnChonFileB.Click += new System.EventHandler(this.btnChonFileB_Click);
            // 
            // txtTongA
            // 
            this.txtTongA.Location = new System.Drawing.Point(825, 498);
            this.txtTongA.Name = "txtTongA";
            this.txtTongA.Size = new System.Drawing.Size(100, 20);
            this.txtTongA.TabIndex = 62;
            // 
            // txtTongB
            // 
            this.txtTongB.Location = new System.Drawing.Point(1032, 498);
            this.txtTongB.Name = "txtTongB";
            this.txtTongB.Size = new System.Drawing.Size(100, 20);
            this.txtTongB.TabIndex = 63;
            // 
            // btnCopyToClipboardA
            // 
            this.btnCopyToClipboardA.Location = new System.Drawing.Point(825, 524);
            this.btnCopyToClipboardA.Name = "btnCopyToClipboardA";
            this.btnCopyToClipboardA.Size = new System.Drawing.Size(110, 23);
            this.btnCopyToClipboardA.TabIndex = 72;
            this.btnCopyToClipboardA.Text = "Copy to Clipboard";
            this.btnCopyToClipboardA.UseVisualStyleBackColor = true;
            this.btnCopyToClipboardA.Click += new System.EventHandler(this.btnCopyToClipboardA_Click);
            // 
            // btnCopyToClipboardB
            // 
            this.btnCopyToClipboardB.Location = new System.Drawing.Point(1032, 524);
            this.btnCopyToClipboardB.Name = "btnCopyToClipboardB";
            this.btnCopyToClipboardB.Size = new System.Drawing.Size(110, 23);
            this.btnCopyToClipboardB.TabIndex = 73;
            this.btnCopyToClipboardB.Text = "Copy to Clipboard";
            this.btnCopyToClipboardB.UseVisualStyleBackColor = true;
            this.btnCopyToClipboardB.Click += new System.EventHandler(this.btnCopyToClipboardB_Click);
            // 
            // btnCopyToClipboard_Billing
            // 
            this.btnCopyToClipboard_Billing.Location = new System.Drawing.Point(6, 450);
            this.btnCopyToClipboard_Billing.Name = "btnCopyToClipboard_Billing";
            this.btnCopyToClipboard_Billing.Size = new System.Drawing.Size(110, 23);
            this.btnCopyToClipboard_Billing.TabIndex = 74;
            this.btnCopyToClipboard_Billing.Text = "Copy to Clipboard";
            this.btnCopyToClipboard_Billing.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard_Billing.Click += new System.EventHandler(this.btnCopyToClipboard_Billing_Click);
            // 
            // btnCopyToClipboard_TH
            // 
            this.btnCopyToClipboard_TH.Location = new System.Drawing.Point(6, 450);
            this.btnCopyToClipboard_TH.Name = "btnCopyToClipboard_TH";
            this.btnCopyToClipboard_TH.Size = new System.Drawing.Size(110, 23);
            this.btnCopyToClipboard_TH.TabIndex = 73;
            this.btnCopyToClipboard_TH.Text = "Copy to Clipboard";
            this.btnCopyToClipboard_TH.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard_TH.Click += new System.EventHandler(this.btnCopyToClipboard_TH_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(931, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "(Enter)";
            // 
            // txtNoiDungA
            // 
            this.txtNoiDungA.Location = new System.Drawing.Point(825, 68);
            this.txtNoiDungA.Multiline = true;
            this.txtNoiDungA.Name = "txtNoiDungA";
            this.txtNoiDungA.Size = new System.Drawing.Size(100, 45);
            this.txtNoiDungA.TabIndex = 74;
            this.txtNoiDungA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoiDungA_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1138, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "(Enter)";
            // 
            // txtNoiDungB
            // 
            this.txtNoiDungB.Location = new System.Drawing.Point(1032, 68);
            this.txtNoiDungB.Multiline = true;
            this.txtNoiDungB.Name = "txtNoiDungB";
            this.txtNoiDungB.Size = new System.Drawing.Size(100, 45);
            this.txtNoiDungB.TabIndex = 76;
            this.txtNoiDungB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoiDungB_KeyPress);
            // 
            // frmKiemTraSaiBiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 574);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDungB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNoiDungA);
            this.Controls.Add(this.btnCopyToClipboardB);
            this.Controls.Add(this.btnCopyToClipboardA);
            this.Controls.Add(this.txtTongB);
            this.Controls.Add(this.txtTongA);
            this.Controls.Add(this.btnChonFileB);
            this.Controls.Add(this.btnChonFileA);
            this.Controls.Add(this.lstViewB);
            this.Controls.Add(this.lstViewA);
            this.Controls.Add(this.btnKiemTraAll);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label4);
            this.Name = "frmKiemTraSaiBiet";
            this.Text = "Kiểm Tra Sai Biệt";
            this.Load += new System.EventHandler(this.frmKiemTraSaiViec_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateGiaiTrach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstView_Billing;
        private System.Windows.Forms.ColumnHeader SoHoaDon_B;
        private System.Windows.Forms.ColumnHeader Ky_B;
        private System.Windows.Forms.ColumnHeader TongCong_B;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstView_TH;
        private System.Windows.Forms.ColumnHeader SoHoaDon_TH;
        private System.Windows.Forms.ColumnHeader Ky_TH;
        private System.Windows.Forms.ColumnHeader TongCong_TH;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.TextBox txtTongHD_Billing;
        private System.Windows.Forms.TextBox txtTongHD_TH;
        private System.Windows.Forms.ColumnHeader DanhBo_B;
        private System.Windows.Forms.ColumnHeader DanhBo_TH;
        private System.Windows.Forms.Button btnKiemTraAll;
        private System.Windows.Forms.ListView lstViewA;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstViewB;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnChonFileA;
        private System.Windows.Forms.Button btnChonFileB;
        private System.Windows.Forms.TextBox txtTongA;
        private System.Windows.Forms.TextBox txtTongB;
        private System.Windows.Forms.Button btnCopyToClipboardA;
        private System.Windows.Forms.Button btnCopyToClipboardB;
        private System.Windows.Forms.Button btnCopyToClipboard_Billing;
        private System.Windows.Forms.Button btnCopyToClipboard_TH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNoiDungA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungB;
    }
}