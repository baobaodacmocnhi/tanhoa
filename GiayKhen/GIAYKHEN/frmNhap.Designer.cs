namespace GIAYKHEN
{
    partial class frmNhap
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
            this.btnCongDoan = new System.Windows.Forms.Button();
            this.btnCongTy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCongDoan
            // 
            this.btnCongDoan.Location = new System.Drawing.Point(12, 12);
            this.btnCongDoan.Name = "btnCongDoan";
            this.btnCongDoan.Size = new System.Drawing.Size(75, 23);
            this.btnCongDoan.TabIndex = 0;
            this.btnCongDoan.Text = "Công Đoàn";
            this.btnCongDoan.UseVisualStyleBackColor = true;
            this.btnCongDoan.Click += new System.EventHandler(this.btnCongDoan_Click);
            // 
            // btnCongTy
            // 
            this.btnCongTy.Location = new System.Drawing.Point(93, 12);
            this.btnCongTy.Name = "btnCongTy";
            this.btnCongTy.Size = new System.Drawing.Size(75, 23);
            this.btnCongTy.TabIndex = 1;
            this.btnCongTy.Text = "Công Ty";
            this.btnCongTy.UseVisualStyleBackColor = true;
            this.btnCongTy.Click += new System.EventHandler(this.btnCongTy_Click);
            // 
            // frmNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 210);
            this.Controls.Add(this.btnCongTy);
            this.Controls.Add(this.btnCongDoan);
            this.Name = "frmNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNhap";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCongDoan;
        private System.Windows.Forms.Button btnCongTy;

    }
}