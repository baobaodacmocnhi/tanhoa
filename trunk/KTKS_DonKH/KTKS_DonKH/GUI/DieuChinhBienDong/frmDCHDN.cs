using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.KiemTraXacMinh;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCHDN : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CTTKH _cTTKH = new CTTKH();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CDonKH _cDonKH = new CDonKH();
        CDCBD _cDCBD = new CDCBD();
        CKTXM _cKTXM = new CKTXM();

        public frmDCHDN()
        {
            InitializeComponent();
        }

        public frmDCHDN(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmDCHDN_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            txtMaDon.Text = _source["MaDon"].Insert(4, "-");
            txtDanhBo.Text = _source["DanhBo"];
            txtHoTen.Text = _source["HoTen"];
            TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(_source["DanhBo"]);
            txtGiaBieu_Cu.Text = txtGiaBieu_Moi.Text = ttkhachhang.GB;
            txtDinhMuc_Cu.Text = txtDinhMuc_Moi.Text = ttkhachhang.TGDM;
        }

        private void frmDCHDN_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtGiaBieu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDinhMuc_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTieuThu_Cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtGiaBieu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDinhMuc_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTieuThu_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTieuThu_Moi_TextChanged(object sender, EventArgs e)
        {
            TinhTienNuoc();
        }

        private void txtGiaBieu_Cu_TextChanged(object sender, EventArgs e)
        {
            TinhTienNuoc();
        }

        private void txtGiaBieu_Moi_TextChanged(object sender, EventArgs e)
        {
            TinhTienNuoc();
        }

        private void txtDinhMuc_Cu_TextChanged(object sender, EventArgs e)
        {
            TinhTienNuoc();
        }

        private void txtDinhMuc_Moi_TextChanged(object sender, EventArgs e)
        {
            TinhTienNuoc();
        }

        private void txtTieuThu_Cu_TextChanged(object sender, EventArgs e)
        {
            TinhTienNuoc();
        }

        private void TinhTienNuoc()
        {
            int TongTienCu = _cGiaNuoc.TinhTienNuoc(txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Cu.Text.Trim()), int.Parse(txtDinhMuc_Cu.Text.Trim()), int.Parse(txtTieuThu_Cu.Text.Trim()));
            int TongTienMoi = _cGiaNuoc.TinhTienNuoc(txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu_Moi.Text.Trim()), int.Parse(txtDinhMuc_Moi.Text.Trim()), int.Parse(txtTieuThu_Moi.Text.Trim()));
            ///Tiêu Thụ
            txtTieuThu_Start.Text = txtTieuThu_Cu.Text.Trim();
            txtTieuThu_BD.Text = (int.Parse(txtTieuThu_Moi.Text.Trim()) - int.Parse(txtTieuThu_Cu.Text.Trim())).ToString();
            txtTieuThu_End.Text = txtTieuThu_Moi.Text.Trim();
            ///Tiền Nước
            txtTienNuoc_Start.Text = TongTienCu.ToString();
            txtTienNuoc_BD.Text = (TongTienMoi - TongTienCu).ToString();
            txtTienNuoc_End.Text = TongTienMoi.ToString();
            ///Thuế GTGT
            txtThueGTGT_Start.Text = Math.Round((double)TongTienCu * 5 / 100).ToString();
            txtThueGTGT_BD.Text = (Math.Round((double)TongTienMoi * 5 / 100) - Math.Round((double)TongTienCu * 5 / 100)).ToString();
            txtThueGTGT_End.Text = Math.Round((double)TongTienMoi * 5 / 100).ToString();
            ///Phí BVMT
            txtPhiBVMT_Start.Text = (TongTienCu * 10 / 100).ToString();
            txtPhiBVMT_BD.Text = ((TongTienMoi * 10 / 100) - (TongTienCu * 10 / 100)).ToString();
            txtPhiBVMT_End.Text = (TongTienMoi * 10 / 100).ToString();
            ///Tổng Cộng
            txtTongCong_Start.Text = (TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100)).ToString();
            txtTongCong_BD.Text = ((TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100)) - (TongTienCu + Math.Round((double)TongTienCu * 5 / 100) + (TongTienCu * 10 / 100))).ToString();
            txtTongCong_End.Text = (TongTienMoi + Math.Round((double)TongTienMoi * 5 / 100) + (TongTienMoi * 10 / 100)).ToString();

            if (TongTienMoi - TongTienCu == 0)
                lbTangGiam.Text = "";
            else
                if (TongTienMoi - TongTienCu > 0)
                    lbTangGiam.Text = "Tăng:";
                else
                    lbTangGiam.Text = "Giảm:";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoVB.Text.Trim() != "" && txtKyHD.Text.Trim() != "" && txtSoHD.Text.Trim() != "")
            {
                DCBD dcbd = new DCBD();
                dcbd.MaDon = decimal.Parse(_source["MaDon"]);
                dcbd.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                dcbd.NoiChuyenDen = _source["NoiChuyenDen"];
                dcbd.LyDoChuyenDen = _source["LyDoChuyenDen"];
                if (_cDCBD.ThemDCBD(dcbd))
                {
                    switch (_source["NoiChuyenDen"])
                    {
                        case "Khách Hàng":
                            ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                            DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                            donkh.Nhan = true;
                            _cDonKH.SuaDonKH(donkh);
                            break;
                        case "Kiểm Tra Xác Minh":
                            ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                            KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                            ktxm.Nhan = true;
                            _cKTXM.SuaKTXM(ktxm);
                            break;
                    }
                    _source.Add("MaDCBD", _cDCBD.getMaxMaDCBD().ToString());
                }
                CTDCHD ctdchd = new CTDCHD();
                ctdchd.MaDCDB = decimal.Parse(_source["MaDCBD"]);
                ctdchd.DanhBo = txtDanhBo.Text.Trim();
                ctdchd.HoTen = txtHoTen.Text.Trim();
                ctdchd.SoVB = txtSoVB.Text.Trim();
                ctdchd.NgayKy = dateNgayKy.Value;
                ctdchd.KyHD = txtKyHD.Text.Trim();
                ctdchd.SoHD = txtSoHD.Text.Trim();
                ///
                ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim());
                ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim());
                ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim());
                ///
                ctdchd.GiaBieuBD = int.Parse(txtGiaBieu_Moi.Text.Trim());
                ctdchd.DinhMucBD = int.Parse(txtDinhMuc_Moi.Text.Trim());
                ctdchd.TieuThuBD = int.Parse(txtTieuThu_Moi.Text.Trim());
                ///
                ctdchd.TienNuoc = int.Parse(txtThueGTGT_Start.Text.Trim());
                ctdchd.ThueGTGT = int.Parse(txtThueGTGT_Start.Text.Trim());
                ctdchd.PhiBVMT = int.Parse(txtPhiBVMT_Start.Text.Trim());
                ctdchd.TongCong = int.Parse(txtTongCong_Start.Text.Trim());
                ///
                ctdchd.TienNuocBD = int.Parse(txtThueGTGT_End.Text.Trim());
                ctdchd.ThueGTGTBD = int.Parse(txtThueGTGT_End.Text.Trim());
                ctdchd.PhiBVMTBD = int.Parse(txtPhiBVMT_End.Text.Trim());
                ctdchd.TongCongBD = int.Parse(txtTongCong_End.Text.Trim());
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        




    }
}
