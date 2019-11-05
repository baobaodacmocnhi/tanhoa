using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI
{
    public partial class frmTinhTienNuoc : Form
    {
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();

        public frmTinhTienNuoc()
        {
            InitializeComponent();
        }

        private void frmTinhTienNuoc_Load(object sender, EventArgs e)
        {
            _cGiaNuoc.TinhTienNuoc_Tang_Ky122019("",16,44,120);
        }
    }
}
