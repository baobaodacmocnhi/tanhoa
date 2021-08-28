namespace ThuTien.GUI.Quay
{
    partial class frmInQuay
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
            this.components = new System.ComponentModel.Container();
            this.btnInKim = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnInKim
            // 
            this.btnInKim.Location = new System.Drawing.Point(398, 0);
            this.btnInKim.Name = "btnInKim";
            this.btnInKim.Size = new System.Drawing.Size(75, 23);
            this.btnInKim.TabIndex = 0;
            this.btnInKim.Text = "In Kim";
            this.btnInKim.UseVisualStyleBackColor = true;
            this.btnInKim.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 25);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(967, 548);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // timer
            // 
            this.timer.Interval = 300000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmInQuay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(967, 574);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnInKim);
            this.Name = "frmInQuay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hiện Thị Dữ Liệu Để In";
            this.Load += new System.EventHandler(this.frmInQuay_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmInQuay_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInKim;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Timer timer;
    }
}