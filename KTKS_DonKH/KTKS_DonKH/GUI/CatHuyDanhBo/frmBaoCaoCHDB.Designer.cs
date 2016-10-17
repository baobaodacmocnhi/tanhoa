namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    partial class frmBaoCaoCHDB
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
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.btnBaoCaoNgayLap = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLoaiBaoCaoNgayLap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbLoaiBaoCaoNgayXuLy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBaoCaoNgayXuLy = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(84, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(84, 5);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // btnBaoCaoNgayLap
            // 
            this.btnBaoCaoNgayLap.Location = new System.Drawing.Point(261, 20);
            this.btnBaoCaoNgayLap.Name = "btnBaoCaoNgayLap";
            this.btnBaoCaoNgayLap.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCaoNgayLap.TabIndex = 28;
            this.btnBaoCaoNgayLap.Text = "Báo Cáo";
            this.btnBaoCaoNgayLap.UseVisualStyleBackColor = true;
            this.btnBaoCaoNgayLap.Click += new System.EventHandler(this.btnBaoCaoNgayLap_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(165, 12);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(183, 60);
            this.panel_KhoangThoiGian.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLoaiBaoCaoNgayLap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBaoCaoNgayLap);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 56);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Theo Ngày Lập";
            // 
            // cmbLoaiBaoCaoNgayLap
            // 
            this.cmbLoaiBaoCaoNgayLap.FormattingEnabled = true;
            this.cmbLoaiBaoCaoNgayLap.Items.AddRange(new object[] {
            "DS Cắt Hủy Đã Xử Lý",
            "DS Cắt Hủy Chưa Xử Lý",
            "DS Cắt Tạm Đã Xử Lý",
            "DS Cắt Tạm Chưa Xử Lý"});
            this.cmbLoaiBaoCaoNgayLap.Location = new System.Drawing.Point(105, 21);
            this.cmbLoaiBaoCaoNgayLap.Name = "cmbLoaiBaoCaoNgayLap";
            this.cmbLoaiBaoCaoNgayLap.Size = new System.Drawing.Size(150, 24);
            this.cmbLoaiBaoCaoNgayLap.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại Báo Cáo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbLoaiBaoCaoNgayXuLy);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnBaoCaoNgayXuLy);
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 56);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Theo Ngày Xử Lý";
            // 
            // cmbLoaiBaoCaoNgayXuLy
            // 
            this.cmbLoaiBaoCaoNgayXuLy.FormattingEnabled = true;
            this.cmbLoaiBaoCaoNgayXuLy.Items.AddRange(new object[] {
            "DS Cắt Hủy",
            "DS Cắt Tạm"});
            this.cmbLoaiBaoCaoNgayXuLy.Location = new System.Drawing.Point(105, 21);
            this.cmbLoaiBaoCaoNgayXuLy.Name = "cmbLoaiBaoCaoNgayXuLy";
            this.cmbLoaiBaoCaoNgayXuLy.Size = new System.Drawing.Size(150, 24);
            this.cmbLoaiBaoCaoNgayXuLy.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại Báo Cáo:";
            // 
            // btnBaoCaoNgayXuLy
            // 
            this.btnBaoCaoNgayXuLy.Location = new System.Drawing.Point(261, 20);
            this.btnBaoCaoNgayXuLy.Name = "btnBaoCaoNgayXuLy";
            this.btnBaoCaoNgayXuLy.Size = new System.Drawing.Size(75, 25);
            this.btnBaoCaoNgayXuLy.TabIndex = 28;
            this.btnBaoCaoNgayXuLy.Text = "Báo Cáo";
            this.btnBaoCaoNgayXuLy.UseVisualStyleBackColor = true;
            this.btnBaoCaoNgayXuLy.Click += new System.EventHandler(this.btnBaoCaoNgayXuLy_Click);
            // 
            // frmBaoCaoCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(712, 402);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmBaoCaoCHDB";
            this.Text = "Báo Cáo Cắt Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmBaoCaoCHDB_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Button btnBaoCaoNgayLap;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLoaiBaoCaoNgayLap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbLoaiBaoCaoNgayXuLy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBaoCaoNgayXuLy;

    }
}