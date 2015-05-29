using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.Doi
{
    public partial class frmPhanTichDoanhThu : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();

        public frmPhanTichDoanhThu()
        {
            InitializeComponent();
        }

        private void frmPhanTichDoanhThu_Load(object sender, EventArgs e)
        {
            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            decimal DoanhThu = 0, SanLuong = 0;
            if (cmbKy.SelectedIndex == 0)
                _cHoaDon.PhanTichDoanhThuByNam(int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), out DoanhThu, out SanLuong);
            else
                if (cmbKy.SelectedIndex > 0)
                    _cHoaDon.PhanTichDoanhThuByNamKy(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), out DoanhThu, out SanLuong);

            txtDoanhThu.Text= String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", DoanhThu);
            txtSanLuong.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SanLuong);
        }
    }
}
