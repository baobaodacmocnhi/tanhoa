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
            this.Location = new Point(70, 70);
            cmbChiNhanh_Cat.DataSource = _cChiNhanh.LoadDSChiNhanh();
            cmbChiNhanh_Cat.DisplayMember = "TenCN";
            cmbChiNhanh_Cat.ValueMember = "MaCN";

            cmbCN_Nhan.DataSource = _cChiNhanh.LoadDSChiNhanh();
            cmbCN_Nhan.DisplayMember = "TenCN";
            cmbCN_Nhan.ValueMember = "MaCN";
        }


    }
}
