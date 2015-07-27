using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace ThuTien.GUI.Quay
{
    public partial class frmInQuay : Form
    {
        ReportDocument _rpt = new ReportDocument();

        public frmInQuay(ReportDocument rpt)
        {
            InitializeComponent();
            _rpt = rpt;
            crystalReportViewer1.ReportSource = rpt;
        }

        private void frmInQuay_Load(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.AllowSomePages = true;
                printDialog.ShowHelp = true;

                _rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                _rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                _rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                _rpt.PrintToPrinter(1, false, 1, 1);

            }
        }
    }
}
