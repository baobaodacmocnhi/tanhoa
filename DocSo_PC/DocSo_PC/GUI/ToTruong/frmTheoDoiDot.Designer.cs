namespace DocSo_PC.GUI.ToTruong
{
    partial class frmTheoDoiDot
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbDot = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbToDS = new System.Windows.Forms.ComboBox();
            this.dataTaoDS = new System.Windows.Forms.DataGridView();
            this.May = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TangCuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuaDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dongcua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataTaoDS)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDot
            // 
            this.cmbDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbDot.Location = new System.Drawing.Point(589, 14);
            this.cmbDot.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDot.Name = "cmbDot";
            this.cmbDot.Size = new System.Drawing.Size(56, 27);
            this.cmbDot.TabIndex = 25;
            this.cmbDot.SelectedValueChanged += new System.EventHandler(this.cmbDot_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(555, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 19);
            this.label4.TabIndex = 24;
            this.label4.Text = "Đợt";
            // 
            // cmbKy
            // 
            this.cmbKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbKy.Location = new System.Drawing.Point(466, 14);
            this.cmbKy.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(53, 27);
            this.cmbKy.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "Năm ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "Kỳ ";
            // 
            // cmbNam
            // 
            this.cmbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(343, 14);
            this.cmbNam.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(59, 27);
            this.cmbNam.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tổ Đọc Số";
            // 
            // cmbToDS
            // 
            this.cmbToDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToDS.FormattingEnabled = true;
            this.cmbToDS.Items.AddRange(new object[] {
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
            this.cmbToDS.Location = new System.Drawing.Point(102, 13);
            this.cmbToDS.Margin = new System.Windows.Forms.Padding(4);
            this.cmbToDS.Name = "cmbToDS";
            this.cmbToDS.Size = new System.Drawing.Size(178, 27);
            this.cmbToDS.TabIndex = 27;
            this.cmbToDS.SelectedValueChanged += new System.EventHandler(this.cmbToDS_SelectedValueChanged);
            // 
            // dataTaoDS
            // 
            this.dataTaoDS.AllowUserToAddRows = false;
            this.dataTaoDS.AllowUserToDeleteRows = false;
            this.dataTaoDS.AllowUserToOrderColumns = true;
            this.dataTaoDS.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTaoDS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataTaoDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTaoDS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.May,
            this.slDoc,
            this.TangCuong,
            this.DaDoc,
            this.ChuaDoc,
            this.dongcua});
            this.dataTaoDS.Location = new System.Drawing.Point(21, 62);
            this.dataTaoDS.Name = "dataTaoDS";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTaoDS.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataTaoDS.RowHeadersWidth = 40;
            this.dataTaoDS.Size = new System.Drawing.Size(701, 676);
            this.dataTaoDS.TabIndex = 29;
            this.dataTaoDS.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataTaoDS_RowPostPaint);
            // 
            // May
            // 
            this.May.DataPropertyName = "May";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.May.DefaultCellStyle = dataGridViewCellStyle2;
            this.May.HeaderText = "Máy";
            this.May.Name = "May";
            this.May.Width = 80;
            // 
            // slDoc
            // 
            this.slDoc.DataPropertyName = "SLDoc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.slDoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.slDoc.HeaderText = "Số Lượng Đọc";
            this.slDoc.Name = "slDoc";
            this.slDoc.Width = 125;
            // 
            // TangCuong
            // 
            this.TangCuong.DataPropertyName = "TANGCUONG";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TangCuong.DefaultCellStyle = dataGridViewCellStyle4;
            this.TangCuong.HeaderText = "Tăng Cường";
            this.TangCuong.Name = "TangCuong";
            this.TangCuong.Width = 110;
            // 
            // DaDoc
            // 
            this.DaDoc.DataPropertyName = "DADOC";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DaDoc.DefaultCellStyle = dataGridViewCellStyle5;
            this.DaDoc.HeaderText = "Đã Đọc";
            this.DaDoc.Name = "DaDoc";
            // 
            // ChuaDoc
            // 
            this.ChuaDoc.DataPropertyName = "CHUADOC";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChuaDoc.DefaultCellStyle = dataGridViewCellStyle6;
            this.ChuaDoc.HeaderText = "Chưa Đọc";
            this.ChuaDoc.Name = "ChuaDoc";
            // 
            // dongcua
            // 
            this.dongcua.DataPropertyName = "DONGCUA";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dongcua.DefaultCellStyle = dataGridViewCellStyle7;
            this.dongcua.HeaderText = "Đóng Cửa";
            this.dongcua.Name = "dongcua";
            // 
            // frmKiemSoatDocSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 750);
            this.Controls.Add(this.dataTaoDS);
            this.Controls.Add(this.cmbToDS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNam);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKiemSoatDocSo";
            this.Text = "Theo Dõi Đợt";
            this.Load += new System.EventHandler(this.frmGiaoTangCuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTaoDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbToDS;
        private System.Windows.Forms.DataGridView dataTaoDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn May;
        private System.Windows.Forms.DataGridViewTextBoxColumn slDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TangCuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChuaDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dongcua;
    }
}