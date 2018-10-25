namespace KTKS_DonKH.GUI.ThuMoi
{
    partial class frmDSThuMoi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnXem = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.dgvDSThu = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.chkCreateBy = new System.Windows.Forms.CheckBox();
            this.radCDDM = new System.Windows.Forms.RadioButton();
            this.radDutChi = new System.Windows.Forms.RadioButton();
            this.btnInDS = new System.Windows.Forms.Button();
            this.In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SoPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VaoLuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radRong = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThu)).BeginInit();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(614, 18);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 25);
            this.btnXem.TabIndex = 39;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.Red;
            this.chkSelectAll.Location = new System.Drawing.Point(72, 42);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(80, 20);
            this.chkSelectAll.TabIndex = 35;
            this.chkSelectAll.Text = "In Tất Cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(695, 18);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 25);
            this.btnIn.TabIndex = 34;
            this.btnIn.Text = "In Thư";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Tìm Theo:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(80, 5);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Ngày"});
            this.cmbTimTheo.Location = new System.Drawing.Point(254, 15);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo.TabIndex = 31;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // dgvDSThu
            // 
            this.dgvDSThu.AllowUserToAddRows = false;
            this.dgvDSThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In,
            this.SoPhieu,
            this.CreateDate,
            this.MaDon,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.Lan,
            this.CanCu,
            this.VaoLuc,
            this.VeViec,
            this.GiaBieu,
            this.DinhMuc,
            this.CreateBy});
            this.dgvDSThu.Location = new System.Drawing.Point(12, 68);
            this.dgvDSThu.Name = "dgvDSThu";
            this.dgvDSThu.Size = new System.Drawing.Size(1311, 560);
            this.dgvDSThu.TabIndex = 36;
            this.dgvDSThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSThu_CellFormatting);
            this.dgvDSThu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSThu_RowPostPaint);
            this.dgvDSThu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSThu_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Nội Dung:";
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(434, 15);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem.TabIndex = 33;
            this.txtNoiDungTimKiem.Visible = false;
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(434, 37);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem2.TabIndex = 38;
            this.txtNoiDungTimKiem2.Visible = false;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(80, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(433, 3);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(175, 59);
            this.panel_KhoangThoiGian.TabIndex = 37;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // chkCreateBy
            // 
            this.chkCreateBy.AutoSize = true;
            this.chkCreateBy.Location = new System.Drawing.Point(254, 45);
            this.chkCreateBy.Name = "chkCreateBy";
            this.chkCreateBy.Size = new System.Drawing.Size(89, 20);
            this.chkCreateBy.TabIndex = 40;
            this.chkCreateBy.Text = "Người Lập";
            this.chkCreateBy.UseVisualStyleBackColor = true;
            // 
            // radCDDM
            // 
            this.radCDDM.AutoSize = true;
            this.radCDDM.Location = new System.Drawing.Point(776, 38);
            this.radCDDM.Name = "radCDDM";
            this.radCDDM.Size = new System.Drawing.Size(64, 20);
            this.radCDDM.TabIndex = 134;
            this.radCDDM.TabStop = true;
            this.radCDDM.Text = "CĐĐM";
            this.radCDDM.UseVisualStyleBackColor = true;
            // 
            // radDutChi
            // 
            this.radDutChi.AutoSize = true;
            this.radDutChi.Location = new System.Drawing.Point(776, 12);
            this.radDutChi.Name = "radDutChi";
            this.radDutChi.Size = new System.Drawing.Size(67, 20);
            this.radDutChi.TabIndex = 133;
            this.radDutChi.TabStop = true;
            this.radDutChi.Text = "Đứt Chì";
            this.radDutChi.UseVisualStyleBackColor = true;
            // 
            // btnInDS
            // 
            this.btnInDS.Location = new System.Drawing.Point(954, 18);
            this.btnInDS.Name = "btnInDS";
            this.btnInDS.Size = new System.Drawing.Size(75, 25);
            this.btnInDS.TabIndex = 135;
            this.btnInDS.Text = "In DS";
            this.btnInDS.UseVisualStyleBackColor = true;
            this.btnInDS.Click += new System.EventHandler(this.btnInDS_Click);
            // 
            // In
            // 
            this.In.DataPropertyName = "In";
            this.In.FalseValue = "False";
            this.In.HeaderText = "In";
            this.In.Name = "In";
            this.In.TrueValue = "True";
            this.In.Width = 30;
            // 
            // SoPhieu
            // 
            this.SoPhieu.DataPropertyName = "SoPhieu";
            this.SoPhieu.HeaderText = "SoPhieu";
            this.SoPhieu.Name = "SoPhieu";
            this.SoPhieu.Visible = false;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 200;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // Lan
            // 
            this.Lan.DataPropertyName = "Lan";
            this.Lan.HeaderText = "Lần";
            this.Lan.Name = "Lan";
            this.Lan.Width = 50;
            // 
            // CanCu
            // 
            this.CanCu.DataPropertyName = "CanCu";
            this.CanCu.HeaderText = "Căn Cứ";
            this.CanCu.Name = "CanCu";
            this.CanCu.Width = 150;
            // 
            // VaoLuc
            // 
            this.VaoLuc.DataPropertyName = "VaoLuc";
            this.VaoLuc.HeaderText = "Vào Lúc";
            this.VaoLuc.Name = "VaoLuc";
            this.VaoLuc.Width = 150;
            // 
            // VeViec
            // 
            this.VeViec.DataPropertyName = "VeViec";
            this.VeViec.HeaderText = "Về Việc";
            this.VeViec.Name = "VeViec";
            this.VeViec.ReadOnly = true;
            this.VeViec.Width = 150;
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "GiaBieu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.Visible = false;
            // 
            // DinhMuc
            // 
            this.DinhMuc.DataPropertyName = "DinhMuc";
            this.DinhMuc.HeaderText = "DinhMuc";
            this.DinhMuc.Name = "DinhMuc";
            this.DinhMuc.Visible = false;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "CreateBy";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.Visible = false;
            // 
            // radRong
            // 
            this.radRong.AutoSize = true;
            this.radRong.Location = new System.Drawing.Point(849, 12);
            this.radRong.Name = "radRong";
            this.radRong.Size = new System.Drawing.Size(59, 20);
            this.radRong.TabIndex = 136;
            this.radRong.TabStop = true;
            this.radRong.Text = "Rỗng";
            this.radRong.UseVisualStyleBackColor = true;
            // 
            // frmDSThuMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1340, 646);
            this.Controls.Add(this.radRong);
            this.Controls.Add(this.btnInDS);
            this.Controls.Add(this.radCDDM);
            this.Controls.Add(this.radDutChi);
            this.Controls.Add(this.chkCreateBy);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.dgvDSThu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.txtNoiDungTimKiem2);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDSThuMoi";
            this.Text = "Danh Sách Thư Mời";
            this.Load += new System.EventHandler(this.frmDSThuMoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThu)).EndInit();
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.DataGridView dgvDSThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.CheckBox chkCreateBy;
        private System.Windows.Forms.RadioButton radCDDM;
        private System.Windows.Forms.RadioButton radDutChi;
        private System.Windows.Forms.Button btnInDS;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn VaoLuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.RadioButton radRong;
    }
}