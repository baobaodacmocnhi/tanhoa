namespace KTKS_DonKH.GUI.HeThong
{
    partial class frmAdmin
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
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnCapNhatPhanQuyenNguoiDung = new System.Windows.Forms.Button();
            this.btnCapNhatPhanQuyenNhom = new System.Windows.Forms.Button();
            this.btnCapNhatMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(12, 160);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(900, 350);
            this.dgvResult.TabIndex = 9;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 54);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(450, 100);
            this.txtQuery.TabIndex = 8;
            // 
            // btnCapNhatPhanQuyenNguoiDung
            // 
            this.btnCapNhatPhanQuyenNguoiDung.Location = new System.Drawing.Point(208, 11);
            this.btnCapNhatPhanQuyenNguoiDung.Name = "btnCapNhatPhanQuyenNguoiDung";
            this.btnCapNhatPhanQuyenNguoiDung.Size = new System.Drawing.Size(92, 37);
            this.btnCapNhatPhanQuyenNguoiDung.TabIndex = 7;
            this.btnCapNhatPhanQuyenNguoiDung.Text = "Cập Nhật Phân Quyền Người Dùng";
            this.btnCapNhatPhanQuyenNguoiDung.UseVisualStyleBackColor = true;
            // 
            // btnCapNhatPhanQuyenNhom
            // 
            this.btnCapNhatPhanQuyenNhom.Location = new System.Drawing.Point(110, 11);
            this.btnCapNhatPhanQuyenNhom.Name = "btnCapNhatPhanQuyenNhom";
            this.btnCapNhatPhanQuyenNhom.Size = new System.Drawing.Size(92, 37);
            this.btnCapNhatPhanQuyenNhom.TabIndex = 6;
            this.btnCapNhatPhanQuyenNhom.Text = "Cập Nhật Phân Quyền Nhóm";
            this.btnCapNhatPhanQuyenNhom.UseVisualStyleBackColor = true;
            // 
            // btnCapNhatMenu
            // 
            this.btnCapNhatMenu.Location = new System.Drawing.Point(12, 11);
            this.btnCapNhatMenu.Name = "btnCapNhatMenu";
            this.btnCapNhatMenu.Size = new System.Drawing.Size(92, 23);
            this.btnCapNhatMenu.TabIndex = 5;
            this.btnCapNhatMenu.Text = "Cập Nhật Menu";
            this.btnCapNhatMenu.UseVisualStyleBackColor = true;
            this.btnCapNhatMenu.Click += new System.EventHandler(this.btnCapNhatMenu_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 524);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnCapNhatPhanQuyenNguoiDung);
            this.Controls.Add(this.btnCapNhatPhanQuyenNhom);
            this.Controls.Add(this.btnCapNhatMenu);
            this.Name = "frmAdmin";
            this.Text = "frmAdmin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnCapNhatPhanQuyenNguoiDung;
        private System.Windows.Forms.Button btnCapNhatPhanQuyenNhom;
        private System.Windows.Forms.Button btnCapNhatMenu;
    }
}