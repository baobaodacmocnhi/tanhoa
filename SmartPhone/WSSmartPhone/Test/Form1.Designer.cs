namespace Test
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.cbKy = new System.Windows.Forms.ComboBox();
            this.cbCode = new System.Windows.Forms.ComboBox();
            this.txtCSMoi = new System.Windows.Forms.TextBox();
            this.cbMayds = new System.Windows.Forms.ComboBox();
            this.Máy = new System.Windows.Forms.Label();
            this.cbDot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btLoad = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTieuThu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(69, 39);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(818, 254);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kỳ ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Năm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "CSMoi";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tính Tiêu Thụ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(190, 13);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(40, 20);
            this.txtNam.TabIndex = 3;
            this.txtNam.Text = "2017";
            // 
            // cbKy
            // 
            this.cbKy.FormattingEnabled = true;
            this.cbKy.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbKy.Location = new System.Drawing.Point(99, 12);
            this.cbKy.Name = "cbKy";
            this.cbKy.Size = new System.Drawing.Size(50, 21);
            this.cbKy.TabIndex = 4;
            this.cbKy.Text = "09";
            // 
            // cbCode
            // 
            this.cbCode.FormattingEnabled = true;
            this.cbCode.Location = new System.Drawing.Point(225, 360);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(100, 21);
            this.cbCode.TabIndex = 4;
            // 
            // txtCSMoi
            // 
            this.txtCSMoi.Location = new System.Drawing.Point(225, 391);
            this.txtCSMoi.Name = "txtCSMoi";
            this.txtCSMoi.Size = new System.Drawing.Size(100, 20);
            this.txtCSMoi.TabIndex = 3;
            // 
            // cbMayds
            // 
            this.cbMayds.FormattingEnabled = true;
            this.cbMayds.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbMayds.Location = new System.Drawing.Point(367, 12);
            this.cbMayds.Name = "cbMayds";
            this.cbMayds.Size = new System.Drawing.Size(53, 21);
            this.cbMayds.TabIndex = 6;
            this.cbMayds.Text = "01";
            // 
            // Máy
            // 
            this.Máy.AutoSize = true;
            this.Máy.Location = new System.Drawing.Point(334, 15);
            this.Máy.Name = "Máy";
            this.Máy.Size = new System.Drawing.Size(27, 13);
            this.Máy.TabIndex = 5;
            this.Máy.Text = "Máy";
            // 
            // cbDot
            // 
            this.cbDot.FormattingEnabled = true;
            this.cbDot.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbDot.Location = new System.Drawing.Point(275, 12);
            this.cbDot.Name = "cbDot";
            this.cbDot.Size = new System.Drawing.Size(53, 21);
            this.cbDot.TabIndex = 7;
            this.cbDot.Text = "01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Đợt";
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(435, 12);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(50, 23);
            this.btLoad.TabIndex = 2;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 451);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tiêu Thụ";
            // 
            // txtTieuThu
            // 
            this.txtTieuThu.Location = new System.Drawing.Point(225, 448);
            this.txtTieuThu.Name = "txtTieuThu";
            this.txtTieuThu.Size = new System.Drawing.Size(100, 20);
            this.txtTieuThu.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "DB";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(225, 336);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 624);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDot);
            this.Controls.Add(this.cbMayds);
            this.Controls.Add(this.Máy);
            this.Controls.Add(this.cbCode);
            this.Controls.Add(this.cbKy);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtTieuThu);
            this.Controls.Add(this.txtCSMoi);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.ComboBox cbKy;
        private System.Windows.Forms.ComboBox cbCode;
        private System.Windows.Forms.TextBox txtCSMoi;
        private System.Windows.Forms.ComboBox cbMayds;
        private System.Windows.Forms.Label Máy;
        private System.Windows.Forms.ComboBox cbDot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTieuThu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDanhBo;
    }
}

