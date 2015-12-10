using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmPhiMoNuocChuyenKhoan : Form
    {
        string _mnu = "mnuPhiMoNuocChuyenKhoan";
        CTienDu _cTienDu = new CTienDu();

        public frmPhiMoNuocChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmPhiMoNuocChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvPhiMoNuoc.AutoGenerateColumns = false;

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvPhiMoNuoc.DataSource = _cTienDu.GetDSPhiMoNuoc();
        }

        
    }
}
