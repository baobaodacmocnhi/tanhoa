using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace DocSo_PC.GUI.BaoCao
{
    public partial class frmShowBaoCao2 : Form
    {
        public frmShowBaoCao2(DataTable dt)
        {
            InitializeComponent();
            var report = reportViewer1.LocalReport;
            report.ReportPath = @"BaoCao\rptImageA4.rdlc";
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.RefreshReport();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);
            this.reportViewer1.RefreshReport();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBaoCao_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Stop();
        }
    }
}
