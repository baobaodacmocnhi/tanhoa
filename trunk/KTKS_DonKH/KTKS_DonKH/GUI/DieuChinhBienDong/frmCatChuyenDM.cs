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
    public partial class frmCatChuyenDM : Form
    {
        CChiNhanh _cChiNhanh = new CChiNhanh();

        public frmCatChuyenDM()
        {
            InitializeComponent();
        }

        private void frmCatChuyenDM_Load(object sender, EventArgs e)
        {
            cmbNoiChuyen.DataSource = _cChiNhanh.LoadDSChiNhanh();
            cmbNoiChuyen.DisplayMember = "TenCN";
            cmbNoiChuyen.ValueMember = "MaCN";

            cmbNoiNhan.DataSource = _cChiNhanh.LoadDSChiNhanh();
            cmbNoiNhan.DisplayMember = "TenCN";
            cmbNoiNhan.ValueMember = "MaCN";
        }


    }
}
