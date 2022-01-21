namespace DocSo_PC.GUI.VanThu
{
    partial class frmShowCongVan
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.chkTinhTieuThu = new System.Windows.Forms.CheckBox();
            this.chkBaoThay = new System.Windows.Forms.CheckBox();
            this.chkBaoThayThu = new System.Windows.Forms.CheckBox();
            this.btnSua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(2, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 600);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            this.pictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseWheel);
            // 
            // chkTinhTieuThu
            // 
            this.chkTinhTieuThu.AutoSize = true;
            this.chkTinhTieuThu.Location = new System.Drawing.Point(608, 12);
            this.chkTinhTieuThu.Name = "chkTinhTieuThu";
            this.chkTinhTieuThu.Size = new System.Drawing.Size(95, 17);
            this.chkTinhTieuThu.TabIndex = 1;
            this.chkTinhTieuThu.Text = "Tính Tiêu Thụ";
            this.chkTinhTieuThu.UseVisualStyleBackColor = true;
            // 
            // chkBaoThay
            // 
            this.chkBaoThay.AutoSize = true;
            this.chkBaoThay.Location = new System.Drawing.Point(608, 35);
            this.chkBaoThay.Name = "chkBaoThay";
            this.chkBaoThay.Size = new System.Drawing.Size(72, 17);
            this.chkBaoThay.TabIndex = 2;
            this.chkBaoThay.Text = "Báo Thay";
            this.chkBaoThay.UseVisualStyleBackColor = true;
            // 
            // chkBaoThayThu
            // 
            this.chkBaoThayThu.AutoSize = true;
            this.chkBaoThayThu.Location = new System.Drawing.Point(608, 58);
            this.chkBaoThayThu.Name = "chkBaoThayThu";
            this.chkBaoThayThu.Size = new System.Drawing.Size(94, 17);
            this.chkBaoThayThu.TabIndex = 3;
            this.chkBaoThayThu.Text = "Báo Thay Thử";
            this.chkBaoThayThu.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(605, 81);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Cập Nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmShowCongVan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 604);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.chkBaoThayThu);
            this.Controls.Add(this.chkBaoThay);
            this.Controls.Add(this.chkTinhTieuThu);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowCongVan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hiển Thị Công Văn";
            this.Load += new System.EventHandler(this.frmShowCongVan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox chkTinhTieuThu;
        private System.Windows.Forms.CheckBox chkBaoThay;
        private System.Windows.Forms.CheckBox chkBaoThayThu;
        private System.Windows.Forms.Button btnSua;
    }
}