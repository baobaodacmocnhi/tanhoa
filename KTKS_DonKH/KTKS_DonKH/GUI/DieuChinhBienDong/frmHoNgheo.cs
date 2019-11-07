using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmHoNgheo : Form
    {
        CHoNgheo _cHoNgheo = new CHoNgheo();

        public frmHoNgheo()
        {
            InitializeComponent();
        }

        private void frmHoNgheo_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }
    }
}
