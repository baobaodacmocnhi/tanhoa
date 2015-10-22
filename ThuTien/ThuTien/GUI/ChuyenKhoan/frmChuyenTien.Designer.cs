namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmChuyenTien
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtDanhBoA = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoTienA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSoTienB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBoB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChuyen = new System.Windows.Forms.Button();
            this.txtSoTienChuyen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "Danh Bộ:";
            // 
            // txtDanhBoA
            // 
            this.txtDanhBoA.Location = new System.Drawing.Point(72, 21);
            this.txtDanhBoA.Name = "txtDanhBoA";
            this.txtDanhBoA.ReadOnly = true;
            this.txtDanhBoA.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBoA.TabIndex = 86;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSoTienA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDanhBoA);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 80);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Bộ Chuyển";
            // 
            // txtSoTienA
            // 
            this.txtSoTienA.Location = new System.Drawing.Point(72, 47);
            this.txtSoTienA.Name = "txtSoTienA";
            this.txtSoTienA.ReadOnly = true;
            this.txtSoTienA.Size = new System.Drawing.Size(100, 20);
            this.txtSoTienA.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "Số Tiền:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSoTienB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDanhBoB);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(208, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 80);
            this.groupBox2.TabIndex = 90;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Bộ Nhận";
            // 
            // txtSoTienB
            // 
            this.txtSoTienB.Location = new System.Drawing.Point(72, 47);
            this.txtSoTienB.Name = "txtSoTienB";
            this.txtSoTienB.ReadOnly = true;
            this.txtSoTienB.Size = new System.Drawing.Size(100, 20);
            this.txtSoTienB.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "Số Tiền:";
            // 
            // txtDanhBoB
            // 
            this.txtDanhBoB.Location = new System.Drawing.Point(72, 21);
            this.txtDanhBoB.Name = "txtDanhBoB";
            this.txtDanhBoB.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBoB.TabIndex = 86;
            this.txtDanhBoB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBoB_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Danh Bộ:";
            // 
            // btnChuyen
            // 
            this.btnChuyen.Location = new System.Drawing.Point(259, 96);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(75, 23);
            this.btnChuyen.TabIndex = 91;
            this.btnChuyen.Text = "Chuyển";
            this.btnChuyen.UseVisualStyleBackColor = true;
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // txtSoTienChuyen
            // 
            this.txtSoTienChuyen.Location = new System.Drawing.Point(153, 98);
            this.txtSoTienChuyen.Name = "txtSoTienChuyen";
            this.txtSoTienChuyen.Size = new System.Drawing.Size(100, 20);
            this.txtSoTienChuyen.TabIndex = 90;
            this.txtSoTienChuyen.TextChanged += new System.EventHandler(this.txtSoTienChuyen_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Số Tiền Chuyển:";
            // 
            // frmChuyenTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 129);
            this.Controls.Add(this.txtSoTienChuyen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnChuyen);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmChuyenTien";
            this.Text = "Chuyển Tiền";
            this.Load += new System.EventHandler(this.frmChuyenTien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDanhBoA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSoTienA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSoTienB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBoB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChuyen;
        private System.Windows.Forms.TextBox txtSoTienChuyen;
        private System.Windows.Forms.Label label4;
    }
}