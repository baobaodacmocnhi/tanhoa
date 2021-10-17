using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDanhSachDocLoChiSoNuoc : Form
    {
        CDocSo _cDocSo = new CDocSo();

        public frmDanhSachDocLoChiSoNuoc()
        {
            InitializeComponent();
        }

        private void frmDanhSachDocLoChiSoNuoc_Load(object sender, EventArgs e)
        {
            gridControl.LevelTree.Nodes.Add("Chi Tiết", gridViewChiTiet);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            gridControl.DataSource = _cDocSo.getDS_DocLoChiSoNuoc(int.Parse(txtNam.Text.Trim()), int.Parse(txtKy.Text.Trim()), int.Parse(txtDot.Text.Trim())).Tables["Parent"];
        }


    }
}
