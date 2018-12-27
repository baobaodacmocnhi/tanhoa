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
    public partial class frmThongTinKhachHang : Form
    {
        CCapNuocTanHoa _cCapNuocTanHoa = new CCapNuocTanHoa();
        CDocSo _cDocSo = new CDocSo();

        public frmThongTinKhachHang()
        {
            InitializeComponent();
        }

        public void GetResult(string DanhBo)
        {
            if (DanhBo.Length == 11)
            {
                txtDanhBoTimKiem.Text = DanhBo;
                btnTimKiem.PerformClick();
            }
        }

        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            dgvDHN_DocSo.AutoGenerateColumns = false;
            dgvDHN_GhiChu.AutoGenerateColumns = false;
            //dgvThuTien.AutoGenerateColumns = false;
            //dgvKinhDoanh.AutoGenerateColumns = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtDanhBoTimKiem.Text.Trim().Replace(" ", "").Length == 11)
            {
                string strDanhBo=txtDanhBoTimKiem.Text.Trim().Replace(" ", "");
                //lấy thông tin khách hàng
                DataTable dt = _cCapNuocTanHoa.getThongTin(strDanhBo);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtDanhBo.Text = dt.Rows[0]["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    txtMLT.Text = dt.Rows[0]["MLT"].ToString().Insert(4, " ").Insert(2, " ");
                    txtHopDong.Text = dt.Rows[0]["HopDong"].ToString();
                    txtHieuLuc.Text = dt.Rows[0]["HieuLuc"].ToString();
                    txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                    txtGiaBieu.Text = dt.Rows[0]["GiaBieu"].ToString();
                    txtDinhMuc.Text = dt.Rows[0]["DinhMuc"].ToString();
                    txtHieu.Text = dt.Rows[0]["HieuDH"].ToString();
                    txtCo.Text = dt.Rows[0]["CoDH"].ToString();
                    txtCap.Text = dt.Rows[0]["Cap"].ToString();
                    txtSoThan.Text = dt.Rows[0]["SoThanDH"].ToString();
                    txtViTri.Text = dt.Rows[0]["ViTriDHN"].ToString();
                    dateNgayGan.Value = DateTime.Parse(dt.Rows[0]["NgayThay"].ToString());
                    dateNgayKiemDinh.Value = DateTime.Parse(dt.Rows[0]["NgayKiemDinh"].ToString());
                }
                //lấy thông tin đọc số
                dgvDHN_DocSo.DataSource = _cDocSo.getGhiChiSo(strDanhBo);
                //lấy thông tin ghi chú
                dgvDHN_GhiChu.DataSource = _cCapNuocTanHoa.getGhiChu(strDanhBo);
            }
        }

        private void txtDanhBoTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void frmThongTinKhachHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                frmTimKiemDanhBo frm = new frmTimKiemDanhBo();
                frm.GetResult = new frmTimKiemDanhBo.GetValue(GetResult);
                frm.ShowDialog();
            }
        }
    }
}
