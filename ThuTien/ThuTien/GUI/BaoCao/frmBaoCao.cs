using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace KTKS_DonKH.GUI.BaoCao
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao(ReportDocument rpt)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = rpt;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);
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
