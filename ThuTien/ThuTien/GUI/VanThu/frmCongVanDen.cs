using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.VanThu;
using ThuTien.DAL;

namespace ThuTien.GUI.VanThu
{
    public partial class frmCongVanDen : Form
    {
        string _mnu = "mnuCongVanDen";
        CCongVanDen _cCVD = new CCongVanDen();
        CThuongVu _cThuongVu = new CThuongVu();

        public frmCongVanDen()
        {
            InitializeComponent();
        }

        private void frmCongVanDen_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cThuongVu.getDS_CVD("", dateTu.Value, dateDen.Value);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

    }
}
