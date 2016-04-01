using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KTKS_DonKH.GUI.CongVan
{
    public partial class frmCongVanDi : Form
    {
        public frmCongVanDi()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmCongVanDi_Load(object sender, EventArgs e)
        {

        }

        
    }
}
