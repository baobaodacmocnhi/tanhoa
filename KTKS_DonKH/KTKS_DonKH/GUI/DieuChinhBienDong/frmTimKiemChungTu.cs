using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmTimKiemChungTu : Form
    {
        CChungTu _cChungTu = new CChungTu();


        public frmTimKiemChungTu()
        {
            InitializeComponent();
        }

        private void frmTimKiemChungTu_Load(object sender, EventArgs e)
        {
            dgvDSChungTu.AutoGenerateColumns = false;
            dgvDSChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);
        }

        private void txtMaCT_TextChanged(object sender, EventArgs e)
        {
            dgvDSChungTu.DataSource = _cChungTu.LoadDSCTChungTubyMaCT(txtMaCT.Text.Trim());
        }

        
    }
}
