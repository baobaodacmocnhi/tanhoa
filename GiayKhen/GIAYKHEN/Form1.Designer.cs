namespace GIAYKHEN
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnNhap = new System.Windows.Forms.Button();
            this.cmbGiayKhen = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuyetDinhTapThe = new System.Windows.Forms.TextBox();
            this.txtQDNam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNhom = new System.Windows.Forms.ComboBox();
            this.btXem = new System.Windows.Forms.Button();
            this.txtNguoiKy = new System.Windows.Forms.TextBox();
            this.txtNgay = new System.Windows.Forms.DateTimePicker();
            this.txtQuyetDinhCaNhan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnNhap);
            this.splitContainer1.Panel1.Controls.Add(this.cmbGiayKhen);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtQuyetDinhTapThe);
            this.splitContainer1.Panel1.Controls.Add(this.txtQDNam);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.cmbNhom);
            this.splitContainer1.Panel1.Controls.Add(this.btXem);
            this.splitContainer1.Panel1.Controls.Add(this.txtNguoiKy);
            this.splitContainer1.Panel1.Controls.Add(this.txtNgay);
            this.splitContainer1.Panel1.Controls.Add(this.txtQuyetDinhCaNhan);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1215, 577);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(1070, 14);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(92, 27);
            this.btnNhap.TabIndex = 14;
            this.btnNhap.Text = "Nhập";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // cmbGiayKhen
            // 
            this.cmbGiayKhen.FormattingEnabled = true;
            this.cmbGiayKhen.Items.AddRange(new object[] {
            "Công ty",
            "Công đoàn",
            "Đảng",
            "Đoàn thanh niên",
            "Gương 5 năm",
            "HCM",
            "Dân vận khéo"});
            this.cmbGiayKhen.Location = new System.Drawing.Point(83, 8);
            this.cmbGiayKhen.Name = "cmbGiayKhen";
            this.cmbGiayKhen.Size = new System.Drawing.Size(165, 27);
            this.cmbGiayKhen.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Loại GK:";
            // 
            // txtQuyetDinhTapThe
            // 
            this.txtQuyetDinhTapThe.Location = new System.Drawing.Point(490, 47);
            this.txtQuyetDinhTapThe.Name = "txtQuyetDinhTapThe";
            this.txtQuyetDinhTapThe.Size = new System.Drawing.Size(160, 26);
            this.txtQuyetDinhTapThe.TabIndex = 11;
            this.txtQuyetDinhTapThe.Text = "0058/QĐ-TH-TCHC";
            // 
            // txtQDNam
            // 
            this.txtQDNam.Location = new System.Drawing.Point(300, 13);
            this.txtQDNam.Name = "txtQDNam";
            this.txtQDNam.Size = new System.Drawing.Size(68, 26);
            this.txtQDNam.TabIndex = 2;
            this.txtQDNam.Text = "2023";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Năm :";
            // 
            // cmbNhom
            // 
            this.cmbNhom.FormattingEnabled = true;
            this.cmbNhom.Items.AddRange(new object[] {
            "Cá Nhân",
            "Tập Thể"});
            this.cmbNhom.Location = new System.Drawing.Point(83, 41);
            this.cmbNhom.Name = "cmbNhom";
            this.cmbNhom.Size = new System.Drawing.Size(165, 27);
            this.cmbNhom.TabIndex = 1;
            // 
            // btXem
            // 
            this.btXem.Location = new System.Drawing.Point(711, 47);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(92, 27);
            this.btXem.TabIndex = 6;
            this.btXem.Text = "Xem";
            this.btXem.UseVisualStyleBackColor = true;
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // txtNguoiKy
            // 
            this.txtNguoiKy.Location = new System.Drawing.Point(898, 15);
            this.txtNguoiKy.Name = "txtNguoiKy";
            this.txtNguoiKy.Size = new System.Drawing.Size(166, 26);
            this.txtNguoiKy.TabIndex = 5;
            this.txtNguoiKy.Text = "NGUYỄN MƯỜI";
            // 
            // txtNgay
            // 
            this.txtNgay.CustomFormat = "dd/MM/yyyy";
            this.txtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgay.Location = new System.Drawing.Point(711, 15);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(108, 26);
            this.txtNgay.TabIndex = 4;
            // 
            // txtQuyetDinhCaNhan
            // 
            this.txtQuyetDinhCaNhan.Location = new System.Drawing.Point(490, 15);
            this.txtQuyetDinhCaNhan.Name = "txtQuyetDinhCaNhan";
            this.txtQuyetDinhCaNhan.Size = new System.Drawing.Size(160, 26);
            this.txtQuyetDinhCaNhan.TabIndex = 3;
            this.txtQuyetDinhCaNhan.Text = "0058/QĐ-TH-TCHC";
            this.txtQuyetDinhCaNhan.TextChanged += new System.EventHandler(this.txtQuyetDinhCaNhan_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nhóm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(825, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Người ký";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(656, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quyết Định Số :";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1215, 497);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 577);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtNgay;
        private System.Windows.Forms.TextBox txtQuyetDinhCaNhan;
        private System.Windows.Forms.Button btXem;
        private System.Windows.Forms.ComboBox cmbNhom;
        private System.Windows.Forms.TextBox txtQDNam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNguoiKy;
        private System.Windows.Forms.TextBox txtQuyetDinhTapThe;
        private System.Windows.Forms.ComboBox cmbGiayKhen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNhap;

    }
}

