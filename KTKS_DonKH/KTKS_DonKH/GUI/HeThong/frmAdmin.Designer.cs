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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(16, 197);
            this.dgvResult.Margin = new System.Windows.Forms.Padding(4);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(1200, 431);
            this.dgvResult.TabIndex = 9;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(16, 66);
            this.txtQuery.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(599, 122);
            this.txtQuery.TabIndex = 8;
            this.txtQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuery_KeyPress);
            // 
            // btnCapNhatPhanQuyenNguoiDung
            // 
            this.btnCapNhatPhanQuyenNguoiDung.Location = new System.Drawing.Point(277, 14);
            this.btnCapNhatPhanQuyenNguoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapNhatPhanQuyenNguoiDung.Name = "btnCapNhatPhanQuyenNguoiDung";
            this.btnCapNhatPhanQuyenNguoiDung.Size = new System.Drawing.Size(123, 46);
            this.btnCapNhatPhanQuyenNguoiDung.TabIndex = 7;
            this.btnCapNhatPhanQuyenNguoiDung.Text = "Cập Nhật Phân Quyền Người Dùng";
            this.btnCapNhatPhanQuyenNguoiDung.UseVisualStyleBackColor = true;
            this.btnCapNhatPhanQuyenNguoiDung.Click += new System.EventHandler(this.btnCapNhatPhanQuyenNguoiDung_Click);
            // 
            // btnCapNhatPhanQuyenNhom
            // 
            this.btnCapNhatPhanQuyenNhom.Location = new System.Drawing.Point(147, 14);
            this.btnCapNhatPhanQuyenNhom.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapNhatPhanQuyenNhom.Name = "btnCapNhatPhanQuyenNhom";
            this.btnCapNhatPhanQuyenNhom.Size = new System.Drawing.Size(123, 46);
            this.btnCapNhatPhanQuyenNhom.TabIndex = 6;
            this.btnCapNhatPhanQuyenNhom.Text = "Cập Nhật Phân Quyền Nhóm";
            this.btnCapNhatPhanQuyenNhom.UseVisualStyleBackColor = true;
            this.btnCapNhatPhanQuyenNhom.Click += new System.EventHandler(this.btnCapNhatPhanQuyenNhom_Click);
            // 
            // btnCapNhatMenu
            // 
            this.btnCapNhatMenu.Location = new System.Drawing.Point(16, 14);
            this.btnCapNhatMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapNhatMenu.Name = "btnCapNhatMenu";
            this.btnCapNhatMenu.Size = new System.Drawing.Size(123, 28);
            this.btnCapNhatMenu.TabIndex = 5;
            this.btnCapNhatMenu.Text = "Cập Nhật Menu";
            this.btnCapNhatMenu.UseVisualStyleBackColor = true;
            this.btnCapNhatMenu.Click += new System.EventHandler(this.btnCapNhatMenu_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(622, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "orignal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(407, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(920, 46);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "SELECT ID,TableName=\'KTXM_ChiTiet_Hinh\',IDCT=IDKTXM_ChiTiet,[Name] FROM [KTKS_Don" +
                "KH].[dbo].[KTXM_ChiTiet_Hinh] where Loai is null and cast(createdate as date)>=\'" +
                "20211001\' and id>=32663";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(703, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "resize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 645);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnCapNhatPhanQuyenNguoiDung);
            this.Controls.Add(this.btnCapNhatPhanQuyenNhom);
            this.Controls.Add(this.btnCapNhatMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}