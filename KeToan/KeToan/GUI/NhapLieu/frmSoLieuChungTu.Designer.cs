namespace KeToan.GUI.NhapLieu
{
    partial class frmSoLieuChungTu
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNganHang = new System.Windows.Forms.ComboBox();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngân Hàng";
            // 
            // cmbNganHang
            // 
            this.cmbNganHang.FormattingEnabled = true;
            this.cmbNganHang.Items.AddRange(new object[] {
            "AGR",
            "KB",
            "VCB",
            "MB"});
            this.cmbNganHang.Location = new System.Drawing.Point(90, 12);
            this.cmbNganHang.Name = "cmbNganHang";
            this.cmbNganHang.Size = new System.Drawing.Size(121, 21);
            this.cmbNganHang.TabIndex = 1;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(217, 10);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 4;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // frmSoLieuChungTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 83);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.cmbNganHang);
            this.Controls.Add(this.label1);
            this.Name = "frmSoLieuChungTu";
            this.Text = "Số Liệu Chứng Từ";
            this.Load += new System.EventHandler(this.frmSoLieuChungTu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNganHang;
        private System.Windows.Forms.Button btnChonFile;
    }
}