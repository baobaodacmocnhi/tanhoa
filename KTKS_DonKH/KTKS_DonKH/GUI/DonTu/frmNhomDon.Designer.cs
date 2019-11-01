namespace KTKS_DonKH.GUI.DonTu
{
    partial class frmNhomDon
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
            this.dgvDieuChinh = new System.Windows.Forms.DataGridView();
            this.ID_DieuChinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT_DieuChinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_DieuChinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvKhieuNai = new System.Windows.Forms.DataGridView();
            this.ID_KhieuNai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT_KhieuNai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_KhieuNai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDHN = new System.Windows.Forms.DataGridView();
            this.ID_DHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT_DHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_DHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDieuChinh)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhieuNai)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDHN)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDieuChinh);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 550);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều Chỉnh";
            // 
            // dgvDieuChinh
            // 
            this.dgvDieuChinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDieuChinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_DieuChinh,
            this.STT_DieuChinh,
            this.Name_DieuChinh});
            this.dgvDieuChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDieuChinh.Location = new System.Drawing.Point(3, 16);
            this.dgvDieuChinh.MultiSelect = false;
            this.dgvDieuChinh.Name = "dgvDieuChinh";
            this.dgvDieuChinh.Size = new System.Drawing.Size(364, 531);
            this.dgvDieuChinh.TabIndex = 0;
            this.dgvDieuChinh.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDieuChinh_CellEndEdit);
            this.dgvDieuChinh.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDieuChinh_RowEnter);
            this.dgvDieuChinh.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDieuChinh_RowPostPaint);
            this.dgvDieuChinh.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDieuChinh_UserAddedRow);
            this.dgvDieuChinh.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvDieuChinh_DragDrop);
            this.dgvDieuChinh.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvDieuChinh_DragEnter);
            this.dgvDieuChinh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDieuChinh_MouseClick);
            // 
            // ID_DieuChinh
            // 
            this.ID_DieuChinh.DataPropertyName = "ID";
            this.ID_DieuChinh.HeaderText = "ID";
            this.ID_DieuChinh.Name = "ID_DieuChinh";
            this.ID_DieuChinh.Visible = false;
            // 
            // STT_DieuChinh
            // 
            this.STT_DieuChinh.DataPropertyName = "STT";
            this.STT_DieuChinh.HeaderText = "STT";
            this.STT_DieuChinh.Name = "STT_DieuChinh";
            this.STT_DieuChinh.Width = 50;
            // 
            // Name_DieuChinh
            // 
            this.Name_DieuChinh.DataPropertyName = "Name";
            this.Name_DieuChinh.HeaderText = "Tên";
            this.Name_DieuChinh.Name = "Name_DieuChinh";
            this.Name_DieuChinh.Width = 250;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvKhieuNai);
            this.groupBox2.Location = new System.Drawing.Point(388, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 550);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khiếu Nại";
            // 
            // dgvKhieuNai
            // 
            this.dgvKhieuNai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhieuNai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_KhieuNai,
            this.STT_KhieuNai,
            this.Name_KhieuNai});
            this.dgvKhieuNai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhieuNai.Location = new System.Drawing.Point(3, 16);
            this.dgvKhieuNai.MultiSelect = false;
            this.dgvKhieuNai.Name = "dgvKhieuNai";
            this.dgvKhieuNai.Size = new System.Drawing.Size(364, 531);
            this.dgvKhieuNai.TabIndex = 0;
            this.dgvKhieuNai.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhieuNai_CellEndEdit);
            this.dgvKhieuNai.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhieuNai_RowEnter);
            this.dgvKhieuNai.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvKhieuNai_RowPostPaint);
            this.dgvKhieuNai.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvKhieuNai_UserAddedRow);
            this.dgvKhieuNai.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvKhieuNai_DragDrop);
            this.dgvKhieuNai.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvKhieuNai_DragEnter);
            this.dgvKhieuNai.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvKhieuNai_MouseClick);
            // 
            // ID_KhieuNai
            // 
            this.ID_KhieuNai.DataPropertyName = "ID";
            this.ID_KhieuNai.HeaderText = "ID";
            this.ID_KhieuNai.Name = "ID_KhieuNai";
            this.ID_KhieuNai.Visible = false;
            // 
            // STT_KhieuNai
            // 
            this.STT_KhieuNai.DataPropertyName = "STT";
            this.STT_KhieuNai.HeaderText = "STT";
            this.STT_KhieuNai.Name = "STT_KhieuNai";
            this.STT_KhieuNai.Width = 50;
            // 
            // Name_KhieuNai
            // 
            this.Name_KhieuNai.DataPropertyName = "Name";
            this.Name_KhieuNai.HeaderText = "Tên";
            this.Name_KhieuNai.Name = "Name_KhieuNai";
            this.Name_KhieuNai.Width = 250;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDHN);
            this.groupBox3.Location = new System.Drawing.Point(764, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 550);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sự Cố ĐHN";
            // 
            // dgvDHN
            // 
            this.dgvDHN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDHN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_DHN,
            this.STT_DHN,
            this.Name_DHN});
            this.dgvDHN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDHN.Location = new System.Drawing.Point(3, 16);
            this.dgvDHN.MultiSelect = false;
            this.dgvDHN.Name = "dgvDHN";
            this.dgvDHN.Size = new System.Drawing.Size(364, 531);
            this.dgvDHN.TabIndex = 0;
            this.dgvDHN.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDHN_CellEndEdit);
            this.dgvDHN.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDHN_RowEnter);
            this.dgvDHN.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDHN_RowPostPaint);
            this.dgvDHN.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDHN_UserAddedRow);
            this.dgvDHN.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvDHN_DragDrop);
            this.dgvDHN.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvDHN_DragEnter);
            this.dgvDHN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvDHN_MouseClick);
            // 
            // ID_DHN
            // 
            this.ID_DHN.DataPropertyName = "ID";
            this.ID_DHN.HeaderText = "ID";
            this.ID_DHN.Name = "ID_DHN";
            this.ID_DHN.Visible = false;
            // 
            // STT_DHN
            // 
            this.STT_DHN.DataPropertyName = "STT";
            this.STT_DHN.HeaderText = "STT";
            this.STT_DHN.Name = "STT_DHN";
            this.STT_DHN.Width = 50;
            // 
            // Name_DHN
            // 
            this.Name_DHN.DataPropertyName = "Name";
            this.Name_DHN.HeaderText = "Tên";
            this.Name_DHN.Name = "Name_DHN";
            this.Name_DHN.Width = 250;
            // 
            // frmNhomDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 656);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmNhomDon";
            this.Text = "Nhóm Đơn";
            this.Load += new System.EventHandler(this.frmNhomDon_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDieuChinh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhieuNai)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDHN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDieuChinh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvKhieuNai;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_DieuChinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT_DieuChinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_DieuChinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_KhieuNai;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT_KhieuNai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_KhieuNai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_DHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT_DHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_DHN;
    }
}