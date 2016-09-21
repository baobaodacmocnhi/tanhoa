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
    public partial class frmShowBaoCao : Form
    {
        public frmShowBaoCao(ReportDocument rpt)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = rpt;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {

        }
    }
}
