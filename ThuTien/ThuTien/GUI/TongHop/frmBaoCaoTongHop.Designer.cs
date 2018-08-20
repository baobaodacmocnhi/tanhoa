namespace ThuTien.GUI.TongHop
{
    partial class frmBaoCaoTongHop
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
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPhanKy = new System.Windows.Forms.CheckBox();
            this.btnTongHopDangNganCQ = new System.Windows.Forms.Button();
            this.btnTongHopDangNganTG = new System.Windows.Forms.Button();
            this.btnTongHopDangNganDoi = new System.Windows.Forms.Button();
            this.dateGiaiTrachTongHopDangNgan = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTongHopDangNganDoiMoi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTongHopDangNganDoiMoi);
            this.groupBox1.Controls.Add(this.cmbKy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbNam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkPhanKy);
            this.groupBox1.Controls.Add(this.btnTongHopDangNganCQ);
            this.groupBox1.Controls.Add(this.btnTongHopDangNganTG);
            this.groupBox1.Controls.Add(this.btnTongHopDangNganDoi);
            this.groupBox1.Controls.Add(this.dateGiaiTrachTongHopDangNgan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng Hợp Đăng Ngân";
            // 
            // cmbKy
            // 
            this.cmbKy.Enabled = false;
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
            this.cmbKy.Location = new System.Drawing.Point(234, 45);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.Enabled = false;
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(140, 45);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Năm:";
            // 
            // chkPhanKy
            // 
            this.chkPhanKy.AutoSize = true;
            this.chkPhanKy.Location = new System.Drawing.Point(30, 47);
            this.chkPhanKy.Name = "chkPhanKy";
            this.chkPhanKy.Size = new System.Drawing.Size(66, 17);
            this.chkPhanKy.TabIndex = 56;
            this.chkPhanKy.Text = "Phân Kỳ";
            this.chkPhanKy.UseVisualStyleBackColor = true;
            this.chkPhanKy.CheckedChanged += new System.EventHandler(this.chkPhanKy_CheckedChanged);
            // 
            // btnTongHopDangNganCQ
            // 
            this.btnTongHopDangNganCQ.Location = new System.Drawing.Point(368, 17);
            this.btnTongHopDangNganCQ.Name = "btnTongHopDangNganCQ";
            this.btnTongHopDangNganCQ.Size = new System.Drawing.Size(75, 23);
            this.btnTongHopDangNganCQ.TabIndex = 55;
            this.btnTongHopDangNganCQ.Text = "Cơ Quan";
            this.btnTongHopDangNganCQ.UseVisualStyleBackColor = true;
            this.btnTongHopDangNganCQ.Click += new System.EventHandler(this.btnTongHopDangNganCQ_Click);
            // 
            // btnTongHopDangNganTG
            // 
            this.btnTongHopDangNganTG.Location = new System.Drawing.Point(287, 17);
            this.btnTongHopDangNganTG.Name = "btnTongHopDangNganTG";
            this.btnTongHopDangNganTG.Size = new System.Drawing.Size(75, 23);
            this.btnTongHopDangNganTG.TabIndex = 54;
            this.btnTongHopDangNganTG.Text = "Tư Gia";
            this.btnTongHopDangNganTG.UseVisualStyleBackColor = true;
            this.btnTongHopDangNganTG.Click += new System.EventHandler(this.btnTongHopDangNganTG_Click);
            // 
            // btnTongHopDangNganDoi
            // 
            this.btnTongHopDangNganDoi.Location = new System.Drawing.Point(206, 17);
            this.btnTongHopDangNganDoi.Name = "btnTongHopDangNganDoi";
            this.btnTongHopDangNganDoi.Size = new System.Drawing.Size(75, 23);
            this.btnTongHopDangNganDoi.TabIndex = 53;
            this.btnTongHopDangNganDoi.Text = "Tổng Hợp";
            this.btnTongHopDangNganDoi.UseVisualStyleBackColor = true;
            this.btnTongHopDangNganDoi.Click += new System.EventHandler(this.btnTongHopDangNganDoi_Click);
            // 
            // dateGiaiTrachTongHopDangNgan
            // 
            this.dateGiaiTrachTongHopDangNgan.CustomFormat = "dd/MM/yyyy";
            this.dateGiaiTrachTongHopDangNgan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaiTrachTongHopDangNgan.Location = new System.Drawing.Point(100, 19);
            this.dateGiaiTrachTongHopDangNgan.Name = "dateGiaiTrachTongHopDangNgan";
            this.dateGiaiTrachTongHopDangNgan.Size = new System.Drawing.Size(100, 20);
            this.dateGiaiTrachTongHopDangNgan.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Ngày Giải Trách:";
            // 
            // btnTongHopDangNganDoiMoi
            // 
            this.btnTongHopDangNganDoiMoi.Location = new System.Drawing.Point(449, 17);
            this.btnTongHopDangNganDoiMoi.Name = "btnTongHopDangNganDoiMoi";
            this.btnTongHopDangNganDoiMoi.Size = new System.Drawing.Size(85, 23);
            this.btnTongHopDangNganDoiMoi.TabIndex = 61;
            this.btnTongHopDangNganDoiMoi.Text = "Tổng Hợp Mới";
            this.btnTongHopDangNganDoiMoi.UseVisualStyleBackColor = true;
            this.btnTongHopDangNganDoiMoi.Click += new System.EventHandler(this.btnTongHopDangNganDoiMoi_Click);
            // 
            // frmBaoCaoTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 404);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBaoCaoTongHop";
            this.Text = "Báo Cáo Tổng Hợp";
            this.Load += new System.EventHandler(this.frmBaoCaoTongHop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTongHopDangNganDoi;
        private System.Windows.Forms.DateTimePicker dateGiaiTrachTongHopDangNgan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTongHopDangNganCQ;
        private System.Windows.Forms.Button btnTongHopDangNganTG;
        private System.Windows.Forms.CheckBox chkPhanKy;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTongHopDangNganDoiMoi;
    }
}