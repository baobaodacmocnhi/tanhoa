namespace DocSo_PC.GUI.HeThong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.btnCapNhatMenu = new System.Windows.Forms.Button();
            this.btnCapNhatPhanQuyenNhom = new System.Windows.Forms.Button();
            this.btnCapNhatPhanQuyenNguoiDung = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnChuyenHinhDHN = new System.Windows.Forms.Button();
            this.btnUpdatesDHNTCT = new System.Windows.Forms.Button();
            this.btnExportsDHN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
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
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 55);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(450, 100);
            this.txtQuery.TabIndex = 3;
            this.txtQuery.Text = resources.GetString("txtQuery.Text");
            this.txtQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuery_KeyPress);
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(12, 161);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(900, 350);
            this.dgvResult.TabIndex = 4;
            // 
            // btnChuyenHinhDHN
            // 
            this.btnChuyenHinhDHN.Location = new System.Drawing.Point(468, 55);
            this.btnChuyenHinhDHN.Name = "btnChuyenHinhDHN";
            this.btnChuyenHinhDHN.Size = new System.Drawing.Size(107, 23);
            this.btnChuyenHinhDHN.TabIndex = 11;
            this.btnChuyenHinhDHN.Text = "Chuyển Hình ĐHN";
            this.btnChuyenHinhDHN.UseVisualStyleBackColor = true;
            this.btnChuyenHinhDHN.Click += new System.EventHandler(this.btnChuyenHinhDHN_Click);
            // 
            // btnUpdatesDHNTCT
            // 
            this.btnUpdatesDHNTCT.Location = new System.Drawing.Point(468, 84);
            this.btnUpdatesDHNTCT.Name = "btnUpdatesDHNTCT";
            this.btnUpdatesDHNTCT.Size = new System.Drawing.Size(107, 23);
            this.btnUpdatesDHNTCT.TabIndex = 12;
            this.btnUpdatesDHNTCT.Text = "update sĐHN TCT";
            this.btnUpdatesDHNTCT.UseVisualStyleBackColor = true;
            this.btnUpdatesDHNTCT.Click += new System.EventHandler(this.btnUpdatesDHNTCT_Click);
            // 
            // btnExportsDHN
            // 
            this.btnExportsDHN.Location = new System.Drawing.Point(468, 113);
            this.btnExportsDHN.Name = "btnExportsDHN";
            this.btnExportsDHN.Size = new System.Drawing.Size(107, 23);
            this.btnExportsDHN.TabIndex = 13;
            this.btnExportsDHN.Text = "Export sĐHN";
            this.btnExportsDHN.UseVisualStyleBackColor = true;
            this.btnExportsDHN.Click += new System.EventHandler(this.btnExportsDHN_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 524);
            this.Controls.Add(this.btnExportsDHN);
            this.Controls.Add(this.btnUpdatesDHNTCT);
            this.Controls.Add(this.btnChuyenHinhDHN);
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

        private System.Windows.Forms.Button btnCapNhatMenu;
        private System.Windows.Forms.Button btnCapNhatPhanQuyenNhom;
        private System.Windows.Forms.Button btnCapNhatPhanQuyenNguoiDung;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnChuyenHinhDHN;
        private System.Windows.Forms.Button btnUpdatesDHNTCT;
        private System.Windows.Forms.Button btnExportsDHN;
    }
}