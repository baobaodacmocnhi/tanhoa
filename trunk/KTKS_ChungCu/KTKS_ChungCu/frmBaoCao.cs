using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace KTKS_ChungCu
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
            this.Location = new Point(70, 70);
        }
    }
}
