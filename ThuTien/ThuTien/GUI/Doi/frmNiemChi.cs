using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using System.Globalization;

namespace ThuTien.GUI.Doi
{
    public partial class frmNiemChi : Form
    {
        string _mnu = "mnuNiemChi";
        CNiemChi _cNiemChi = new CNiemChi();

        public frmNiemChi()
        {
            InitializeComponent();
        }

        private void frmNiemChi_Load(object sender, EventArgs e)
        {
            loadNhap();
        }

        public void loadNhap()
        {
            dgvNiemChi.DataSource = _cNiemChi.getDSNhap_Group();
            int SLNhap = 0;
            int SLSuDung = 0;
            int SLTon = 0;
            foreach (DataGridViewRow item in dgvNiemChi.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["SLNhap"].Value.ToString()))
                    SLNhap += int.Parse(item.Cells["SLNhap"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLSuDung"].Value.ToString()))
                    SLSuDung += int.Parse(item.Cells["SLSuDung"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLTon"].Value.ToString()))
                    SLTon += int.Parse(item.Cells["SLTon"].Value.ToString());
            }
            txtSLNhap.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLNhap);
            txtSLSuDung.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLSuDung);
            txtSLTon.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLTon);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (int.Parse(txtDenSo.Text.Trim()) > int.Parse(txtTuSo.Text.Trim()))
                {
                    int TuSo = int.Parse(txtTuSo.Text.Trim());
                    int DenSo = int.Parse(txtDenSo.Text.Trim());
                    for (int i = TuSo; i <= DenSo; i++)
                    {
                        if (_cNiemChi.checkExist(TuSo) == true)
                        {
                            MessageBox.Show("Mã " + TuSo + " đã có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    for (int i = TuSo; i <= DenSo; i++)
                    {
                        TT_NiemChi en = new TT_NiemChi();
                        en.ID = i;
                        _cNiemChi.Them(en);
                    }
                    loadNhap();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {

            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {

            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtTuSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDenSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDenSo_TextChanged(object sender, EventArgs e)
        {
            if (txtDenSo.Text.Trim() != "")
                txtSoLuong.Text = (int.Parse(txtDenSo.Text.Trim()) - int.Parse(txtTuSo.Text.Trim())+1).ToString();
        }
    }
}
