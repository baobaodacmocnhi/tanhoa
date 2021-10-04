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
    public partial class frmSoDangKyDinhMuc : Form
    {
        CChungTu _cChungTu = new CChungTu();

        public frmSoDangKyDinhMuc()
        {
            InitializeComponent();
        }

        private void frmSoDangKyDinhMuc_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cChungTu.getTimKiemSoDangKyDinhMuc(txtMaCT.Text.Trim());
        }

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

    }
}
