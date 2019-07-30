using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace BauCu
{
    public partial class frmShowReport : Form
    {
        public frmShowReport(ReportDocument rpt)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = rpt;
        }

        private void frmShowReport_Load(object sender, EventArgs e)
        {

        }
    }
}
