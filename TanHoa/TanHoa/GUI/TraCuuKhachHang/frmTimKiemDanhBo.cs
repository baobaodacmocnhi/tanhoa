using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoa.DAL;

namespace TanHoa.GUI.TraCuuKhachHang
{
    public partial class frmTimKiemDanhBo : Form
    {
        //CConnection _cThuTien = new CConnection("Data Source=192.168.90.9;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=P@ssW012d9");
        CConnection _cThuTien = new CConnection("Data Source=server9;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=P@ssW012d9");

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
            dataGridView.DataSource = _cThuTien.ExecuteQuery_DataTable("select * from fnTimKiemTTKH('" + txtHoTen.Text.Trim() + "','" + txtSoNha.Text.Trim() + "','" + txtTenDuong.Text.Trim() + "')");
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
