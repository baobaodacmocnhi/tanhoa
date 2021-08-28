namespace ThuTien.GUI.Doi
{
    partial class frmDieuChinhMLT
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
            this.btnChonFile = new System.Windows.Forms.Button();
            this.lstView_A = new System.Windows.Forms.ListView();
            this.DanhBo_A = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MLT_A = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstView_B = new System.Windows.Forms.ListView();
            this.SoHoaDon_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ky_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DanhBo_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MLT_B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MLT_B_Moi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(12, 12);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 71;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // lstView_A
            // 
            this.lstView_A.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DanhBo_A,
            this.MLT_A});
            this.lstView_A.Location = new System.Drawing.Point(12, 41);
            this.lstView_A.Name = "lstView_A";
            this.lstView_A.Size = new System.Drawing.Size(226, 370);
            this.lstView_A.TabIndex = 72;
            this.lstView_A.UseCompatibleStateImageBehavior = false;
            this.lstView_A.View = System.Windows.Forms.View.Details;
            // 
            // DanhBo_A
            // 
            this.DanhBo_A.Text = "Danh Bộ";
            this.DanhBo_A.Width = 100;
            // 
            // MLT_A
            // 
            this.MLT_A.Text = "MLT";
            this.MLT_A.Width = 100;
            // 
            // lstView_B
            // 
            this.lstView_B.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SoHoaDon_B,
            this.Ky_B,
            this.DanhBo_B,
            this.MLT_B,
            this.MLT_B_Moi});
            this.lstView_B.Location = new System.Drawing.Point(244, 41);
            this.lstView_B.Name = "lstView_B";
            this.lstView_B.Size = new System.Drawing.Size(485, 370);
            this.lstView_B.TabIndex = 73;
            this.lstView_B.UseCompatibleStateImageBehavior = false;
            this.lstView_B.View = System.Windows.Forms.View.Details;
            // 
            // SoHoaDon_B
            // 
            this.SoHoaDon_B.Text = "Số Hóa Đơn";
            this.SoHoaDon_B.Width = 100;
            // 
            // Ky_B
            // 
            this.Ky_B.Text = "Kỳ";
            // 
            // DanhBo_B
            // 
            this.DanhBo_B.Text = "Danh Bộ";
            this.DanhBo_B.Width = 100;
            // 
            // MLT_B
            // 
            this.MLT_B.Text = "MLT Cũ";
            this.MLT_B.Width = 100;
            // 
            // MLT_B_Moi
            // 
            this.MLT_B_Moi.Text = "MLT Mới";
            this.MLT_B_Moi.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Nhập Vào";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(584, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Hiện Tại";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(503, 12);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 76;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // frmDieuChinhMLT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(873, 558);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstView_B);
            this.Controls.Add(this.lstView_A);
            this.Controls.Add(this.btnChonFile);
            this.Name = "frmDieuChinhMLT";
            this.Text = "Điều Chỉnh MLT";
            this.Load += new System.EventHandler(this.frmDieuChinhMLT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.ListView lstView_A;
        private System.Windows.Forms.ColumnHeader DanhBo_A;
        private System.Windows.Forms.ColumnHeader MLT_A;
        private System.Windows.Forms.ListView lstView_B;
        private System.Windows.Forms.ColumnHeader DanhBo_B;
        private System.Windows.Forms.ColumnHeader MLT_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.ColumnHeader SoHoaDon_B;
        private System.Windows.Forms.ColumnHeader Ky_B;
        private System.Windows.Forms.ColumnHeader MLT_B_Moi;
    }
}