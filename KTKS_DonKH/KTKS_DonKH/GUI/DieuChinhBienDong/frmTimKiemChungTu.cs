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
    public partial class frmTimKiemChungTu : Form
    {
        CChungTu _cChungTu = new CChungTu();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();

        public frmTimKiemChungTu()
        {
            InitializeComponent();
        }

        private void frmTimKiemChungTu_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            dgvDSChungTu.AutoGenerateColumns = false;
            dgvDSChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);
            cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu();
            cmbLoaiCT.DisplayMember = "TenLCT";
            cmbLoaiCT.ValueMember = "MaLCT";
        }

        private void txtMaCT_TextChanged(object sender, EventArgs e)
        {
            dgvDSChungTu.DataSource = _cChungTu.GetDSCT(txtMaCT.Text.Trim(), int.Parse(cmbLoaiCT.SelectedValue.ToString()));
        }

        
    }
}
