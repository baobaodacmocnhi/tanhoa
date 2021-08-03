namespace KTKS_DonKH.GUI.DonTu
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
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDonTu)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(269, 0);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(100, 26);
            this.txtMaDon.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(208, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 20);
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
            this.chkcmbNoiNhan.Size = new System.Drawing.Size(200, 26);
            this.chkcmbNoiNhan.TabIndex = 92;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(717, 53);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 25);
            this.btnCapNhat.TabIndex = 91;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtNoiDung_LichSu
            // 
            this.txtNoiDung_LichSu.Location = new System.Drawing.Point(561, 56);
            this.txtNoiDung_LichSu.Name = "txtNoiDung_LichSu";
            this.txtNoiDung_LichSu.Size = new System.Drawing.Size(150, 26);
            this.txtNoiDung_LichSu.TabIndex = 90;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(557, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 20);
            this.label34.TabIndex = 89;
            this.label34.Text = "Nội Dung:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(354, 37);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(83, 20);
            this.label33.TabIndex = 88;
            this.label33.Text = "Nơi Nhận:";
            // 
            // cmbNoiChuyen
            // 
            this.cmbNoiChuyen.FormattingEnabled = true;
            this.cmbNoiChuyen.Location = new System.Drawing.Point(149, 56);
            this.cmbNoiChuyen.MaxDropDownItems = 10;
            this.cmbNoiChuyen.Name = "cmbNoiChuyen";
            this.cmbNoiChuyen.Size = new System.Drawing.Size(200, 28);
            this.cmbNoiChuyen.TabIndex = 87;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(149, 37);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(100, 20);
            this.label32.TabIndex = 86;
            this.label32.Text = "Nơi Chuyển:";
            // 
            // dateChuyen
            // 
            this.dateChuyen.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateChuyen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChuyen.Location = new System.Drawing.Point(3, 56);
            this.dateChuyen.Name = "dateChuyen";
            this.dateChuyen.Size = new System.Drawing.Size(140, 26);
            this.dateChuyen.TabIndex = 85;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(0, 37);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(113, 20);
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
            this.dgvLichSuDonTu.Location = new System.Drawing.Point(0, 86);
            this.dgvLichSuDonTu.Name = "dgvLichSuDonTu";
            this.dgvLichSuDonTu.ReadOnly = true;
            this.dgvLichSuDonTu.Size = new System.Drawing.Size(1070, 180);
            this.dgvLichSuDonTu.TabIndex = 93;
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
            this.chkHoanThanh.Location = new System.Drawing.Point(560, 14);
            this.chkHoanThanh.Name = "chkHoanThanh";
            this.chkHoanThanh.Size = new System.Drawing.Size(122, 24);
            this.chkHoanThanh.TabIndex = 94;
            this.chkHoanThanh.Text = "Hoàn Thành";
            this.chkHoanThanh.UseVisualStyleBackColor = true;
            // 
            // frmCapNhatDonTu_Thumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1070, 268);
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
    }
}