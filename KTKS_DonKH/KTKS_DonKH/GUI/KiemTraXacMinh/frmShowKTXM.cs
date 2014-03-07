using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmShowKTXM : Form
    {
        decimal _MaDon = 0;

        public frmShowKTXM()
        {
            InitializeComponent();
        }

        public frmShowKTXM(decimal MaDon)
        {
            InitializeComponent();
            _MaDon = MaDon;
        }

        private void frmShowKTXM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            txtMaDon.Text = _MaDon.ToString().Insert(_MaDon.ToString().Length - 2, "-");
        }
    }
}
