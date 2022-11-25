namespace DocSo_PC.GUI.VanThu
{
    partial class frmCongVanDenAuto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabChuaNhan = new System.Windows.Forms.TabPage();
            this.dgvDanhSachChuaNhan = new System.Windows.Forms.DataGridView();
            this.Nhan_QLDHN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiVB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDaNhan = new System.Windows.Forms.TabPage();
            this.btnXoa_DaNhan = new System.Windows.Forms.Button();
            this.dgvDanhSachDaNhan = new System.Windows.Forms.DataGridView();
            this.CreateDate_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiVB_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCT_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyen_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_DaNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTieuThu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BaoThay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BaoThayThu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radKTXM = new System.Windows.Forms.RadioButton();
            this.radToTrinh = new System.Windows.Forms.RadioButton();
            this.tabControl.SuspendLayout();
            this.tabChuaNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachChuaNhan)).BeginInit();
            this.tabDaNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDaNhan)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabChuaNhan);
            this.tabControl.Controls.Add(this.tabDaNhan);
            this.tabControl.Location = new System.Drawing.Point(0, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1144, 645);
            this.tabControl.TabIndex = 0;
            // 
            // tabChuaNhan
            // 
            this.tabChuaNhan.AutoScroll = true;
            this.tabChuaNhan.Controls.Add(this.dgvDanhSachChuaNhan);
            this.tabChuaNhan.Location = new System.Drawing.Point(4, 22);
            this.tabChuaNhan.Name = "tabChuaNhan";
            this.tabChuaNhan.Padding = new System.Windows.Forms.Padding(3);
            this.tabChuaNhan.Size = new System.Drawing.Size(1136, 619);
            this.tabChuaNhan.TabIndex = 0;
            this.tabChuaNhan.Text = "Chưa Nhận";
            this.tabChuaNhan.UseVisualStyleBackColor = true;
            // 
            // dgvDanhSachChuaNhan
            // 
            this.dgvDanhSachChuaNhan.AllowUserToAddRows = false;
            this.dgvDanhSachChuaNhan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachChuaNhan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSachChuaNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachChuaNhan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nhan_QLDHN,
            this.NgayChuyen,
            this.LoaiVB,
            this.MLT,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.MaDon,
            this.TableName,
            this.IDCT,
            this.NoiChuyen,
            this.ID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachChuaNhan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachChuaNhan.Location = new System.Drawing.Point(3, 32);
            this.dgvDanhSachChuaNhan.Name = "dgvDanhSachChuaNhan";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachChuaNhan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSachChuaNhan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDanhSachChuaNhan.Size = new System.Drawing.Size(994, 550);
            this.dgvDanhSachChuaNhan.TabIndex = 56;
            this.dgvDanhSachChuaNhan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanhSachChuaNhan_CellFormatting);
            this.dgvDanhSachChuaNhan.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDanhSachChuaNhan_CellMouseDoubleClick);
            this.dgvDanhSachChuaNhan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSachChuaNhan_RowPostPaint);
            // 
            // Nhan_QLDHN
            // 
            this.Nhan_QLDHN.DataPropertyName = "Nhan_QLDHN";
            this.Nhan_QLDHN.HeaderText = "Nhận";
            this.Nhan_QLDHN.Name = "Nhan_QLDHN";
            this.Nhan_QLDHN.Width = 50;
            // 
            // NgayChuyen
            // 
            this.NgayChuyen.DataPropertyName = "NgayChuyen";
            this.NgayChuyen.HeaderText = "TV Chuyển";
            this.NgayChuyen.Name = "NgayChuyen";
            this.NgayChuyen.Width = 80;
            // 
            // LoaiVB
            // 
            this.LoaiVB.DataPropertyName = "LoaiVB";
            this.LoaiVB.HeaderText = "Loại VB";
            this.LoaiVB.Name = "LoaiVB";
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
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = false;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 300;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "TableName";
            this.TableName.Name = "TableName";
            this.TableName.Visible = false;
            // 
            // IDCT
            // 
            this.IDCT.DataPropertyName = "IDCT";
            this.IDCT.HeaderText = "IDCT";
            this.IDCT.Name = "IDCT";
            this.IDCT.Visible = false;
            // 
            // NoiChuyen
            // 
            this.NoiChuyen.DataPropertyName = "NoiChuyen";
            this.NoiChuyen.HeaderText = "NoiChuyen";
            this.NoiChuyen.Name = "NoiChuyen";
            this.NoiChuyen.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // tabDaNhan
            // 
            this.tabDaNhan.AutoScroll = true;
            this.tabDaNhan.Controls.Add(this.btnXoa_DaNhan);
            this.tabDaNhan.Controls.Add(this.dgvDanhSachDaNhan);
            this.tabDaNhan.Location = new System.Drawing.Point(4, 22);
            this.tabDaNhan.Name = "tabDaNhan";
            this.tabDaNhan.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaNhan.Size = new System.Drawing.Size(1136, 619);
            this.tabDaNhan.TabIndex = 1;
            this.tabDaNhan.Text = "Đã Nhận";
            this.tabDaNhan.UseVisualStyleBackColor = true;
            // 
            // btnXoa_DaNhan
            // 
            this.btnXoa_DaNhan.Location = new System.Drawing.Point(8, 6);
            this.btnXoa_DaNhan.Name = "btnXoa_DaNhan";
            this.btnXoa_DaNhan.Size = new System.Drawing.Size(75, 23);
            this.btnXoa_DaNhan.TabIndex = 58;
            this.btnXoa_DaNhan.Text = "Xóa";
            this.btnXoa_DaNhan.UseVisualStyleBackColor = true;
            this.btnXoa_DaNhan.Click += new System.EventHandler(this.btnXoa_DaNhan_Click);
            // 
            // dgvDanhSachDaNhan
            // 
            this.dgvDanhSachDaNhan.AllowUserToAddRows = false;
            this.dgvDanhSachDaNhan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachDaNhan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDanhSachDaNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachDaNhan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreateDate_DaNhan,
            this.LoaiVB_DaNhan,
            this.MLT_DaNhan,
            this.DanhBo_DaNhan,
            this.HoTen_DaNhan,
            this.DiaChi_DaNhan,
            this.NoiDung_DaNhan,
            this.MaDon_DaNhan,
            this.TableName_DaNhan,
            this.IDCT_DaNhan,
            this.NoiChuyen_DaNhan,
            this.ID_DaNhan,
            this.TinhTieuThu,
            this.BaoThay,
            this.BaoThayThu});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachDaNhan.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDanhSachDaNhan.Location = new System.Drawing.Point(3, 32);
            this.dgvDanhSachDaNhan.Name = "dgvDanhSachDaNhan";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachDaNhan.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSachDaNhan.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDanhSachDaNhan.Size = new System.Drawing.Size(1093, 550);
            this.dgvDanhSachDaNhan.TabIndex = 57;
            this.dgvDanhSachDaNhan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachDaNhan_CellDoubleClick);
            this.dgvDanhSachDaNhan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanhSachDaNhan_CellFormatting);
            this.dgvDanhSachDaNhan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSachDaNhan_RowPostPaint);
            // 
            // CreateDate_DaNhan
            // 
            this.CreateDate_DaNhan.DataPropertyName = "CreateDate";
            this.CreateDate_DaNhan.HeaderText = "Ngày Nhận";
            this.CreateDate_DaNhan.Name = "CreateDate_DaNhan";
            this.CreateDate_DaNhan.Width = 80;
            // 
            // LoaiVB_DaNhan
            // 
            this.LoaiVB_DaNhan.DataPropertyName = "LoaiVB";
            this.LoaiVB_DaNhan.HeaderText = "Loại VB";
            this.LoaiVB_DaNhan.Name = "LoaiVB_DaNhan";
            // 
            // MLT_DaNhan
            // 
            this.MLT_DaNhan.DataPropertyName = "MLT";
            this.MLT_DaNhan.HeaderText = "MLT";
            this.MLT_DaNhan.Name = "MLT_DaNhan";
            // 
            // DanhBo_DaNhan
            // 
            this.DanhBo_DaNhan.DataPropertyName = "DanhBo";
            this.DanhBo_DaNhan.HeaderText = "Danh Bộ";
            this.DanhBo_DaNhan.Name = "DanhBo_DaNhan";
            // 
            // HoTen_DaNhan
            // 
            this.HoTen_DaNhan.DataPropertyName = "HoTen";
            this.HoTen_DaNhan.HeaderText = "Khách Hàng";
            this.HoTen_DaNhan.Name = "HoTen_DaNhan";
            this.HoTen_DaNhan.Visible = false;
            // 
            // DiaChi_DaNhan
            // 
            this.DiaChi_DaNhan.DataPropertyName = "DiaChi";
            this.DiaChi_DaNhan.HeaderText = "Địa Chỉ";
            this.DiaChi_DaNhan.Name = "DiaChi_DaNhan";
            // 
            // NoiDung_DaNhan
            // 
            this.NoiDung_DaNhan.DataPropertyName = "NoiDung";
            this.NoiDung_DaNhan.HeaderText = "Nội Dung";
            this.NoiDung_DaNhan.Name = "NoiDung_DaNhan";
            this.NoiDung_DaNhan.Width = 300;
            // 
            // MaDon_DaNhan
            // 
            this.MaDon_DaNhan.DataPropertyName = "MaDon";
            this.MaDon_DaNhan.HeaderText = "Mã Đơn";
            this.MaDon_DaNhan.Name = "MaDon_DaNhan";
            // 
            // TableName_DaNhan
            // 
            this.TableName_DaNhan.DataPropertyName = "TableName";
            this.TableName_DaNhan.HeaderText = "TableName";
            this.TableName_DaNhan.Name = "TableName_DaNhan";
            this.TableName_DaNhan.Visible = false;
            // 
            // IDCT_DaNhan
            // 
            this.IDCT_DaNhan.DataPropertyName = "IDCT";
            this.IDCT_DaNhan.HeaderText = "IDCT";
            this.IDCT_DaNhan.Name = "IDCT_DaNhan";
            this.IDCT_DaNhan.Visible = false;
            // 
            // NoiChuyen_DaNhan
            // 
            this.NoiChuyen_DaNhan.DataPropertyName = "NoiChuyen";
            this.NoiChuyen_DaNhan.HeaderText = "NoiChuyen";
            this.NoiChuyen_DaNhan.Name = "NoiChuyen_DaNhan";
            this.NoiChuyen_DaNhan.Visible = false;
            // 
            // ID_DaNhan
            // 
            this.ID_DaNhan.DataPropertyName = "ID";
            this.ID_DaNhan.HeaderText = "ID";
            this.ID_DaNhan.Name = "ID_DaNhan";
            this.ID_DaNhan.Visible = false;
            // 
            // TinhTieuThu
            // 
            this.TinhTieuThu.DataPropertyName = "TinhTieuThu";
            this.TinhTieuThu.HeaderText = "Tính Tiêu Thụ";
            this.TinhTieuThu.Name = "TinhTieuThu";
            this.TinhTieuThu.Width = 50;
            // 
            // BaoThay
            // 
            this.BaoThay.DataPropertyName = "BaoThay";
            this.BaoThay.HeaderText = "Báo Thay";
            this.BaoThay.Name = "BaoThay";
            this.BaoThay.Width = 50;
            // 
            // BaoThayThu
            // 
            this.BaoThayThu.DataPropertyName = "BaoThayThu";
            this.BaoThayThu.HeaderText = "Báo Thay Thử";
            this.BaoThayThu.Name = "BaoThayThu";
            this.BaoThayThu.Width = 50;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(466, 0);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 26;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(200, 1);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(95, 20);
            this.dateTu.TabIndex = 22;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(365, 1);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(95, 20);
            this.dateDen.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Đến Ngày:";
            // 
            // radKTXM
            // 
            this.radKTXM.AutoSize = true;
            this.radKTXM.Checked = true;
            this.radKTXM.Location = new System.Drawing.Point(579, 0);
            this.radKTXM.Name = "radKTXM";
            this.radKTXM.Size = new System.Drawing.Size(55, 17);
            this.radKTXM.TabIndex = 27;
            this.radKTXM.TabStop = true;
            this.radKTXM.Text = "KTXM";
            this.radKTXM.UseVisualStyleBackColor = true;
            // 
            // radToTrinh
            // 
            this.radToTrinh.AutoSize = true;
            this.radToTrinh.Location = new System.Drawing.Point(640, 0);
            this.radToTrinh.Name = "radToTrinh";
            this.radToTrinh.Size = new System.Drawing.Size(65, 17);
            this.radToTrinh.TabIndex = 28;
            this.radToTrinh.Text = "Tờ Trình";
            this.radToTrinh.UseVisualStyleBackColor = true;
            // 
            // frmCongVanDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 708);
            this.Controls.Add(this.radToTrinh);
            this.Controls.Add(this.radKTXM);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl);
            this.Name = "frmCongVanDen";
            this.Text = "Công Văn Đến";
            this.Load += new System.EventHandler(this.frmCongVanDen_Load);
            this.tabControl.ResumeLayout(false);
            this.tabChuaNhan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachChuaNhan)).EndInit();
            this.tabDaNhan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDaNhan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabChuaNhan;
        private System.Windows.Forms.TabPage tabDaNhan;
        private System.Windows.Forms.DataGridView dgvDanhSachChuaNhan;
        private System.Windows.Forms.DataGridView dgvDanhSachDaNhan;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXoa_DaNhan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Nhan_QLDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiVB;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiVB_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCT_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyen_DaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_DaNhan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TinhTieuThu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BaoThay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BaoThayThu;
        private System.Windows.Forms.RadioButton radKTXM;
        private System.Windows.Forms.RadioButton radToTrinh;
    }
}