namespace DocSo_PC.GUI.TraCuuThongTin
{
    partial class frmTimKiemDhn
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.rbDiaChi = new System.Windows.Forms.RadioButton();
            this.rbDanhBo = new System.Windows.Forms.RadioButton();
            this.rbLoTrinh = new System.Windows.Forms.RadioButton();
            this.rbSoThan = new System.Windows.Forms.RadioButton();
            this.rbMayDS = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1047, 613);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.rbMayDS);
            this.panel1.Controls.Add(this.rbSoThan);
            this.panel1.Controls.Add(this.rbLoTrinh);
            this.panel1.Controls.Add(this.rbDanhBo);
            this.panel1.Controls.Add(this.rbDiaChi);
            this.panel1.Controls.Add(this.btTimKiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1041, 72);
            this.panel1.TabIndex = 0;
            // 
            // btTimKiem
            // 
            this.btTimKiem.Location = new System.Drawing.Point(514, 37);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(117, 27);
            this.btTimKiem.TabIndex = 2;
            this.btTimKiem.Text = "Tìm Kiếm";
            this.btTimKiem.UseVisualStyleBackColor = true;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // rbDiaChi
            // 
            this.rbDiaChi.AutoSize = true;
            this.rbDiaChi.Location = new System.Drawing.Point(44, 9);
            this.rbDiaChi.Name = "rbDiaChi";
            this.rbDiaChi.Size = new System.Drawing.Size(73, 23);
            this.rbDiaChi.TabIndex = 3;
            this.rbDiaChi.TabStop = true;
            this.rbDiaChi.Text = "Địa Chỉ";
            this.rbDiaChi.UseVisualStyleBackColor = true;
            // 
            // rbDanhBo
            // 
            this.rbDanhBo.AutoSize = true;
            this.rbDanhBo.Location = new System.Drawing.Point(123, 9);
            this.rbDanhBo.Name = "rbDanhBo";
            this.rbDanhBo.Size = new System.Drawing.Size(81, 23);
            this.rbDanhBo.TabIndex = 3;
            this.rbDanhBo.TabStop = true;
            this.rbDanhBo.Text = "Danh Bộ";
            this.rbDanhBo.UseVisualStyleBackColor = true;
            // 
            // rbLoTrinh
            // 
            this.rbLoTrinh.AutoSize = true;
            this.rbLoTrinh.Location = new System.Drawing.Point(211, 9);
            this.rbLoTrinh.Name = "rbLoTrinh";
            this.rbLoTrinh.Size = new System.Drawing.Size(78, 23);
            this.rbLoTrinh.TabIndex = 3;
            this.rbLoTrinh.TabStop = true;
            this.rbLoTrinh.Text = "Lộ Trình";
            this.rbLoTrinh.UseVisualStyleBackColor = true;
            // 
            // rbSoThan
            // 
            this.rbSoThan.AutoSize = true;
            this.rbSoThan.Location = new System.Drawing.Point(303, 9);
            this.rbSoThan.Name = "rbSoThan";
            this.rbSoThan.Size = new System.Drawing.Size(78, 23);
            this.rbSoThan.TabIndex = 3;
            this.rbSoThan.TabStop = true;
            this.rbSoThan.Text = "Số Thân";
            this.rbSoThan.UseVisualStyleBackColor = true;
            // 
            // rbMayDS
            // 
            this.rbMayDS.AutoSize = true;
            this.rbMayDS.Location = new System.Drawing.Point(387, 9);
            this.rbMayDS.Name = "rbMayDS";
            this.rbMayDS.Size = new System.Drawing.Size(106, 23);
            this.rbMayDS.TabIndex = 3;
            this.rbMayDS.TabStop = true;
            this.rbMayDS.Text = "Đợt Máy ĐS";
            this.rbMayDS.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(44, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(449, 26);
            this.txtSearch.TabIndex = 4;
            // 
            // frmTimKiemDhn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 613);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTimKiemDhn";
            this.Text = "Tra cứu Thông tin ĐHN";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.RadioButton rbSoThan;
        private System.Windows.Forms.RadioButton rbLoTrinh;
        private System.Windows.Forms.RadioButton rbDanhBo;
        private System.Windows.Forms.RadioButton rbDiaChi;
        private System.Windows.Forms.RadioButton rbMayDS;
        private System.Windows.Forms.TextBox txtSearch;
    }
}