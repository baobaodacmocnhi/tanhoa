﻿namespace KTKS_DonKH.GUI.DonTu
{
    partial class frmCapNhatDonTu_Thumbnail
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
            this.components = new System.ComponentModel.Container();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkcmbNoiNhan = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.txtNoiDung_LichSu = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbNoiChuyen = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dateChuyen = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.dgvLichSuDonTu = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkHoanThanh = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkcmbNoiNhanKTXM = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lstMa = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCapNhat_Nhieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDonTu)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhanKTXM.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(269, 4);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(100, 22);
            this.txtMaDon.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(208, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 16);
            this.label14.TabIndex = 14;
            this.label14.Text = "Mã Đơn:";
            // 
            // chkcmbNoiNhan
            // 
            this.chkcmbNoiNhan.Location = new System.Drawing.Point(355, 56);
            this.chkcmbNoiNhan.Name = "chkcmbNoiNhan";
            this.chkcmbNoiNhan.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkcmbNoiNhan.Properties.Appearance.Options.UseFont = true;
            this.chkcmbNoiNhan.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkcmbNoiNhan.Properties.AppearanceDropDown.Options.UseFont = true;
            this.chkcmbNoiNhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkcmbNoiNhan.Properties.PopupFormSize = new System.Drawing.Size(230, 250);
            this.chkcmbNoiNhan.Properties.SelectAllItemVisible = false;
            this.chkcmbNoiNhan.Size = new System.Drawing.Size(200, 22);
            this.chkcmbNoiNhan.TabIndex = 92;
            this.chkcmbNoiNhan.EditValueChanged += new System.EventHandler(this.chkcmbNoiNhan_EditValueChanged);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(873, 53);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 25);
            this.btnCapNhat.TabIndex = 91;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtNoiDung_LichSu
            // 
            this.txtNoiDung_LichSu.Location = new System.Drawing.Point(717, 56);
            this.txtNoiDung_LichSu.Name = "txtNoiDung_LichSu";
            this.txtNoiDung_LichSu.Size = new System.Drawing.Size(150, 22);
            this.txtNoiDung_LichSu.TabIndex = 90;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(713, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(67, 16);
            this.label34.TabIndex = 89;
            this.label34.Text = "Nội Dung:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(354, 37);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(67, 16);
            this.label33.TabIndex = 88;
            this.label33.Text = "Nơi Nhận:";
            // 
            // cmbNoiChuyen
            // 
            this.cmbNoiChuyen.FormattingEnabled = true;
            this.cmbNoiChuyen.Location = new System.Drawing.Point(149, 56);
            this.cmbNoiChuyen.MaxDropDownItems = 10;
            this.cmbNoiChuyen.Name = "cmbNoiChuyen";
            this.cmbNoiChuyen.Size = new System.Drawing.Size(200, 24);
            this.cmbNoiChuyen.TabIndex = 87;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(149, 37);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(80, 16);
            this.label32.TabIndex = 86;
            this.label32.Text = "Nơi Chuyển:";
            // 
            // dateChuyen
            // 
            this.dateChuyen.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateChuyen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChuyen.Location = new System.Drawing.Point(3, 56);
            this.dateChuyen.Name = "dateChuyen";
            this.dateChuyen.Size = new System.Drawing.Size(140, 22);
            this.dateChuyen.TabIndex = 85;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(0, 37);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(92, 16);
            this.label30.TabIndex = 84;
            this.label30.Text = "Ngày Chuyển:";
            // 
            // dgvLichSuDonTu
            // 
            this.dgvLichSuDonTu.AllowUserToAddRows = false;
            this.dgvLichSuDonTu.AllowUserToDeleteRows = false;
            this.dgvLichSuDonTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuDonTu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NgayChuyen,
            this.NoiChuyen,
            this.NoiNhan,
            this.NoiDung,
            this.KTXM,
            this.CreateBy});
            this.dgvLichSuDonTu.Location = new System.Drawing.Point(3, 102);
            this.dgvLichSuDonTu.Name = "dgvLichSuDonTu";
            this.dgvLichSuDonTu.ReadOnly = true;
            this.dgvLichSuDonTu.Size = new System.Drawing.Size(1070, 180);
            this.dgvLichSuDonTu.TabIndex = 93;
            this.dgvLichSuDonTu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichSuDonTu_CellClick);
            this.dgvLichSuDonTu.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLichSuDonTu_CellMouseClick);
            this.dgvLichSuDonTu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvLichSuDonTu_MouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // NgayChuyen
            // 
            this.NgayChuyen.DataPropertyName = "NgayChuyen";
            this.NgayChuyen.HeaderText = "Ngày Chuyển";
            this.NgayChuyen.Name = "NgayChuyen";
            this.NgayChuyen.ReadOnly = true;
            this.NgayChuyen.Width = 120;
            // 
            // NoiChuyen
            // 
            this.NoiChuyen.DataPropertyName = "NoiChuyen";
            this.NoiChuyen.HeaderText = "Nơi Chuyển";
            this.NoiChuyen.Name = "NoiChuyen";
            this.NoiChuyen.ReadOnly = true;
            this.NoiChuyen.Width = 250;
            // 
            // NoiNhan
            // 
            this.NoiNhan.DataPropertyName = "NoiNhan";
            this.NoiNhan.HeaderText = "Nơi Nhận";
            this.NoiNhan.Name = "NoiNhan";
            this.NoiNhan.ReadOnly = true;
            this.NoiNhan.Width = 250;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 150;
            // 
            // KTXM
            // 
            this.KTXM.DataPropertyName = "KTXM";
            this.KTXM.HeaderText = "KTXM";
            this.KTXM.Name = "KTXM";
            this.KTXM.ReadOnly = true;
            this.KTXM.Width = 120;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Lập";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.ReadOnly = true;
            this.CreateBy.Width = 120;
            // 
            // chkHoanThanh
            // 
            this.chkHoanThanh.AutoSize = true;
            this.chkHoanThanh.Location = new System.Drawing.Point(972, 56);
            this.chkHoanThanh.Name = "chkHoanThanh";
            this.chkHoanThanh.Size = new System.Drawing.Size(101, 20);
            this.chkHoanThanh.TabIndex = 94;
            this.chkHoanThanh.Text = "Hoàn Thành";
            this.chkHoanThanh.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(0, 83);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(242, 16);
            this.label28.TabIndex = 95;
            this.label28.Text = "Chuột Phải để XÓA Lịch Sử Chuyển Đơn";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // chkcmbNoiNhanKTXM
            // 
            this.chkcmbNoiNhanKTXM.Location = new System.Drawing.Point(561, 56);
            this.chkcmbNoiNhanKTXM.Name = "chkcmbNoiNhanKTXM";
            this.chkcmbNoiNhanKTXM.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkcmbNoiNhanKTXM.Properties.Appearance.Options.UseFont = true;
            this.chkcmbNoiNhanKTXM.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkcmbNoiNhanKTXM.Properties.AppearanceDropDown.Options.UseFont = true;
            this.chkcmbNoiNhanKTXM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkcmbNoiNhanKTXM.Properties.PopupFormSize = new System.Drawing.Size(150, 250);
            this.chkcmbNoiNhanKTXM.Properties.SelectAllItemVisible = false;
            this.chkcmbNoiNhanKTXM.Size = new System.Drawing.Size(150, 22);
            this.chkcmbNoiNhanKTXM.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 96;
            this.label1.Text = "Nhân Viên Kiểm Tra";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCapNhat_Nhieu);
            this.groupBox1.Controls.Add(this.lstMa);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(1079, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 260);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Nhiều";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(38, 21);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(100, 22);
            this.txtMa.TabIndex = 1;
            this.txtMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMa_KeyPress);
            // 
            // lstMa
            // 
            this.lstMa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstMa.Location = new System.Drawing.Point(38, 49);
            this.lstMa.Name = "lstMa";
            this.lstMa.Size = new System.Drawing.Size(100, 173);
            this.lstMa.TabIndex = 49;
            this.lstMa.UseCompatibleStateImageBehavior = false;
            this.lstMa.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Danh Sách";
            this.columnHeader1.Width = 80;
            // 
            // btnCapNhat_Nhieu
            // 
            this.btnCapNhat_Nhieu.Location = new System.Drawing.Point(38, 228);
            this.btnCapNhat_Nhieu.Name = "btnCapNhat_Nhieu";
            this.btnCapNhat_Nhieu.Size = new System.Drawing.Size(75, 25);
            this.btnCapNhat_Nhieu.TabIndex = 92;
            this.btnCapNhat_Nhieu.Text = "Cập Nhật";
            this.btnCapNhat_Nhieu.UseVisualStyleBackColor = true;
            this.btnCapNhat_Nhieu.Click += new System.EventHandler(this.btnCapNhat_Nhieu_Click);
            // 
            // frmCapNhatDonTu_Thumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1244, 284);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkcmbNoiNhanKTXM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.chkHoanThanh);
            this.Controls.Add(this.dgvLichSuDonTu);
            this.Controls.Add(this.chkcmbNoiNhan);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.txtNoiDung_LichSu);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.cmbNoiChuyen);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.dateChuyen);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCapNhatDonTu_Thumbnail";
            this.Text = "Cập Nhật Đơn Từ";
            this.Load += new System.EventHandler(this.frmCapNhanDonTu_Thumbnail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDonTu)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhanKTXM.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkcmbNoiNhan;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.TextBox txtNoiDung_LichSu;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cmbNoiChuyen;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker dateChuyen;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridView dgvLichSuDonTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn KTXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.CheckBox chkHoanThanh;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkcmbNoiNhanKTXM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCapNhat_Nhieu;
        private System.Windows.Forms.ListView lstMa;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label2;
    }
}