namespace DocSo_PC.GUI.ChuanBiDocSo
{
    partial class frmTaoDocSo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.DaTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnTaoDocSo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dsTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dsDenNgay = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataTaoDS)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDot
            // 
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
            this.cmbDot.SelectedIndexChanged += new System.EventHandler(this.cmbDot_SelectedIndexChanged);
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
            this.DaTao,
            this.NguoiTao,
            this.NgayTao});
            this.dataTaoDS.Location = new System.Drawing.Point(12, 123);
            this.dataTaoDS.Name = "dataTaoDS";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTaoDS.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataTaoDS.RowHeadersWidth = 40;
            this.dataTaoDS.Size = new System.Drawing.Size(669, 676);
            this.dataTaoDS.TabIndex = 28;
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
            this.slDoc.DataPropertyName = "SOLUONG";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.slDoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.slDoc.HeaderText = "Số Lượng Đọc";
            this.slDoc.Name = "slDoc";
            this.slDoc.Width = 125;
            // 
            // DaTao
            // 
            this.DaTao.DataPropertyName = "DaTao";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DaTao.DefaultCellStyle = dataGridViewCellStyle4;
            this.DaTao.HeaderText = "Đã Tạo";
            this.DaTao.Name = "DaTao";
            this.DaTao.Width = 90;
            // 
            // NguoiTao
            // 
            this.NguoiTao.DataPropertyName = "NVTaoDS";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NguoiTao.DefaultCellStyle = dataGridViewCellStyle5;
            this.NguoiTao.HeaderText = "Người Tạo";
            this.NguoiTao.Name = "NguoiTao";
            // 
            // NgayTao
            // 
            this.NgayTao.DataPropertyName = "NgayTaoDS";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NgayTao.DefaultCellStyle = dataGridViewCellStyle6;
            this.NgayTao.HeaderText = "Ngày Tạo";
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.Width = 200;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 90);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(629, 26);
            this.progressBar.TabIndex = 30;
            // 
            // btnTaoDocSo
            // 
            this.btnTaoDocSo.Location = new System.Drawing.Point(479, 54);
            this.btnTaoDocSo.Margin = new System.Windows.Forms.Padding(6);
            this.btnTaoDocSo.Name = "btnTaoDocSo";
            this.btnTaoDocSo.Size = new System.Drawing.Size(166, 26);
            this.btnTaoDocSo.TabIndex = 29;
            this.btnTaoDocSo.Text = "Tạo Dữ Liệu Đọc Số";
            this.btnTaoDocSo.UseVisualStyleBackColor = true;
            this.btnTaoDocSo.Click += new System.EventHandler(this.btnTaoDocSo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 19);
            this.label5.TabIndex = 31;
            this.label5.Text = "Đọc Từ Ngày";
            // 
            // dsTuNgay
            // 
            this.dsTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dsTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dsTuNgay.Location = new System.Drawing.Point(106, 53);
            this.dsTuNgay.Name = "dsTuNgay";
            this.dsTuNgay.Size = new System.Drawing.Size(112, 26);
            this.dsTuNgay.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 19);
            this.label6.TabIndex = 33;
            this.label6.Text = "Đến Ngày";
            // 
            // dsDenNgay
            // 
            this.dsDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dsDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dsDenNgay.Location = new System.Drawing.Point(303, 53);
            this.dsDenNgay.Name = "dsDenNgay";
            this.dsDenNgay.Size = new System.Drawing.Size(112, 26);
            this.dsDenNgay.TabIndex = 34;
            // 
            // frmTaoDocSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 811);
            this.Controls.Add(this.dsDenNgay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dsTuNgay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnTaoDocSo);
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
            this.Name = "frmTaoDocSo";
            this.Text = "Tạo Dữ Liệu Đọc Số";
            this.Load += new System.EventHandler(this.frmTaoDocSo_Load);
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
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnTaoDocSo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dsTuNgay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dsDenNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn May;
        private System.Windows.Forms.DataGridViewTextBoxColumn slDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
    }
}