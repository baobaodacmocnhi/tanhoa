using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrungTamKhachHang.DAL;
using TrungTamKhachHang.DAL.KhachHang;
using TrungTamKhachHang.DAL.QuanTri;

namespace TrungTamKhachHang.GUI.KhachHang
{
    public partial class frmThongTinKhachHang : Form
    {
        CCapNuocTanHoa _cCapNuocTanHoa = new CCapNuocTanHoa();
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        CKinhDoanh _cKinhDoanh = new CKinhDoanh();
        CKhieuNai _cKN = new CKhieuNai();
        System.IO.StreamWriter _log;

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
            dgvKhieuNai.AutoGenerateColumns = false;
            dgvDHN_DocSo.AutoGenerateColumns = false;
            dgvDHN_GhiChu.AutoGenerateColumns = false;
            dgvThuTien.AutoGenerateColumns = false;

            gridControl.LevelTree.Nodes.Add("Chi Tiết Kiểm Tra Xác Minh", gridViewKTXM);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Bấm Chì", gridViewBamChi);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewDongNuoc);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Điều Chỉnh Biến Động", gridViewDCBD);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", gridViewCHDB);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Phiếu Hủy Danh Bộ", gridViewPhieuCHDB);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Thảo Thư Trả Lời", gridViewTTTL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Gian Lận", gridViewGianLan);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Truy Thu", gridViewTruyThu);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Tờ Trình", gridViewToTrinh);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Thư Mời", gridViewThuMoi);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Tiến Trình", gridViewTienTrinh);

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtDanhBoTimKiem.Text.Trim().Replace(" ", "").Length == 11)
            {
                try
                {
                    //_log = System.IO.File.AppendText("\\\\192.168.90.9\\BaoBao$\\TrungTamKhachHang\\log" + CUser.MaUser + ".txt");
                    string strDanhBo = txtDanhBoTimKiem.Text.Trim().Replace(" ", "");
                    //lấy lịch sử khiếu nại
                    //DateTime dateTong = DateTime.Now;
                    //DateTime date = DateTime.Now;
                    dgvKhieuNai.DataSource = _cKN.getDS_DanhBo(strDanhBo);
                    //TimeSpan diff = DateTime.Now - date;
                    //_log.WriteLine("lấy lịch sử khiếu nại " + diff.TotalSeconds);

                    //lấy thông tin khách hàng
                    //date = DateTime.Now;
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
                    //diff = DateTime.Now - date;
                    //_log.WriteLine("lấy thông tin khách hàng " + diff.TotalSeconds);

                    //lấy thông tin đọc số
                    //date = DateTime.Now;
                    dgvDHN_DocSo.DataSource = _cDocSo.getGhiChiSo(strDanhBo);
                    //diff = DateTime.Now - date;
                    //_log.WriteLine("lấy thông tin đọc số " + diff.TotalSeconds);

                    //lấy thông tin ghi chú
                    //date = DateTime.Now;
                    dgvDHN_GhiChu.DataSource = _cCapNuocTanHoa.getGhiChu(strDanhBo);
                    //diff = DateTime.Now - date;
                    //_log.WriteLine("lấy thông tin ghi chú " + diff.TotalSeconds);

                    //lấy thông tin thu tiền
                    //date = DateTime.Now;
                    dgvThuTien.DataSource = _cThuTien.getTimKiem(strDanhBo);
                    //diff = DateTime.Now - date;
                    //_log.WriteLine("lấy thông tin thu tiền " + diff.TotalSeconds);

                    //lấy thông tin kinh doanh
                    //date = DateTime.Now;
                    gridControl.DataSource = _cKinhDoanh.getTimKiem(strDanhBo).Tables["DonTu"];
                    //diff = DateTime.Now - date;
                    //_log.WriteLine("lấy thông tin kinh doanh " + diff.TotalSeconds);

                    //diff = DateTime.Now - dateTong;
                    //_log.WriteLine("Tổng " + diff.TotalSeconds);
                    //_log.WriteLine("=============================================");
                    //_log.Close();
                    //_log.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDanhBoTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void frmThongTinKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.F://mở form tìm kiếm danh bộ
                        frmTimKiemDanhBo frm = new frmTimKiemDanhBo();
                        frm.GetResult = new frmTimKiemDanhBo.GetValue(GetResult);
                        frm.ShowDialog();
                        break;
                    case Keys.K://mở form thêm khiếu nại
                        frmKhieuNaiKhachHang frm2 = new frmKhieuNaiKhachHang();
                        frm2.ShowDialog();
                        break;
                    default:
                        break;
                }
        }
    }
}
