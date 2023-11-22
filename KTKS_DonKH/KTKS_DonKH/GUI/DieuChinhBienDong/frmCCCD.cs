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
    public partial class frmCCCD : Form
    {
        string _mnu = "mnuDCBD";
        CChungTu _cChungTu = new CChungTu();
        string _DanhBo = "";

        public frmCCCD(string DanhBo)
        {
            InitializeComponent();
            _DanhBo = DanhBo;
        }

        private void frmCCCD_Load(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(_DanhBo);
        }
    }
}
