using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrungTamKhachHang.DAL;

namespace TrungTamKhachHang.GUI.KhachHang
{
    public partial class frmTimKiemDanhBo : Form
    {
        CThuTien _cThuTien = new CThuTien();

        public frmTimKiemDanhBo()
        {
            InitializeComponent();
        }

        public delegate void GetValue(string result);
        public GetValue GetResult;

        private void frmTimKiemDanhBo_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = _cThuTien.getDanhBo(txtHoTen.Text.Trim(), txtSoNha.Text.Trim(), txtTenDuong.Text.Trim());
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void txtSoNha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void txtTenDuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetResult(dataGridView.CurrentRow.Cells["DanhBo"].Value.ToString());
            this.Hide();
        }
    }
}
