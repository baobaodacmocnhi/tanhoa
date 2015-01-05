namespace ThuTien.GUI.HeThong
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
            this.btnCapNhatMenu = new System.Windows.Forms.Button();
            this.btnCapNhatPhanQuyenNhom = new System.Windows.Forms.Button();
            this.btnCapNhatPhanQuyenNguoiDung = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCapNhatMenu
            // 
            this.btnCapNhatMenu.Location = new System.Drawing.Point(12, 12);
            this.btnCapNhatMenu.Name = "btnCapNhatMenu";
            this.btnCapNhatMenu.Size = new System.Drawing.Size(92, 23);
            this.btnCapNhatMenu.TabIndex = 0;
            this.btnCapNhatMenu.Text = "Cập Nhật Menu";
            this.btnCapNhatMenu.UseVisualStyleBackColor = true;
            this.btnCapNhatMenu.Click += new System.EventHandler(this.btnCapNhatMenu_Click);
            // 
            // btnCapNhatPhanQuyenNhom
            // 
            this.btnCapNhatPhanQuyenNhom.Location = new System.Drawing.Point(110, 12);
            this.btnCapNhatPhanQuyenNhom.Name = "btnCapNhatPhanQuyenNhom";
            this.btnCapNhatPhanQuyenNhom.Size = new System.Drawing.Size(92, 37);
            this.btnCapNhatPhanQuyenNhom.TabIndex = 1;
            this.btnCapNhatPhanQuyenNhom.Text = "Cập Nhật Phân Quyền Nhóm";
            this.btnCapNhatPhanQuyenNhom.UseVisualStyleBackColor = true;
            this.btnCapNhatPhanQuyenNhom.Click += new System.EventHandler(this.btnCapNhatPhanQuyenNhom_Click);
            // 
            // btnCapNhatPhanQuyenNguoiDung
            // 
            this.btnCapNhatPhanQuyenNguoiDung.Location = new System.Drawing.Point(208, 12);
            this.btnCapNhatPhanQuyenNguoiDung.Name = "btnCapNhatPhanQuyenNguoiDung";
            this.btnCapNhatPhanQuyenNguoiDung.Size = new System.Drawing.Size(92, 37);
            this.btnCapNhatPhanQuyenNguoiDung.TabIndex = 2;
            this.btnCapNhatPhanQuyenNguoiDung.Text = "Cập Nhật Phân Quyền Người Dùng";
            this.btnCapNhatPhanQuyenNguoiDung.UseVisualStyleBackColor = true;
            this.btnCapNhatPhanQuyenNguoiDung.Click += new System.EventHandler(this.btnCapNhatPhanQuyenNguoiDung_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 297);
            this.Controls.Add(this.btnCapNhatPhanQuyenNguoiDung);
            this.Controls.Add(this.btnCapNhatPhanQuyenNhom);
            this.Controls.Add(this.btnCapNhatMenu);
            this.Name = "frmAdmin";
            this.Text = "frmAdmin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCapNhatMenu;
        private System.Windows.Forms.Button btnCapNhatPhanQuyenNhom;
        private System.Windows.Forms.Button btnCapNhatPhanQuyenNguoiDung;
    }
}