namespace KTKS_DonKH.GUI.CallCenter
{
    partial class frmViewPdf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewPdf));
            this.axAcroPDF3 = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF3)).BeginInit();
            this.SuspendLayout();
            // 
            // axAcroPDF3
            // 
            this.axAcroPDF3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF3.Enabled = true;
            this.axAcroPDF3.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF3.Name = "axAcroPDF3";
            this.axAcroPDF3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF3.OcxState")));
            this.axAcroPDF3.Size = new System.Drawing.Size(1134, 652);
            this.axAcroPDF3.TabIndex = 0;
            // 
            // frmViewPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 652);
            this.Controls.Add(this.axAcroPDF3);
            this.Name = "frmViewPdf";
            this.Text = "frmViewPdf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF3;
    }
}