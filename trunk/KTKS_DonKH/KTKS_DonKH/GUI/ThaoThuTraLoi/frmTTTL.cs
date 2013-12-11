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
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThaoThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmTTTL : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CTTKH _cTTKH = new CTTKH();
        DonKH _donkh = new DonKH();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        CTTTL _cTTTL = new CTTTL();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

        public frmTTTL()
        {
            InitializeComponent();
        }

        public frmTTTL(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmTTTL_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"])) != null)
            {
                _donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"]));
                txtMaDon.Text = _donkh.MaDon.ToString().Insert(4, "-");
            }
            if (_cTTKH.getTTKHbyID(_source["DanhBo"]) != null)
            {
                _ttkhachhang = _cTTKH.getTTKHbyID(_source["DanhBo"]);
                txtDanhBo.Text = _ttkhachhang.DanhBo;
                txtHopDong.Text = _ttkhachhang.GiaoUoc;
                txtHoTen.Text = _ttkhachhang.HoTen;
                txtDiaChi.Text = _ttkhachhang.DC1 + _ttkhachhang.DC2 + _cCHDB.getPhuongQuanByID(_ttkhachhang.Quan, _ttkhachhang.Phuong);
                txtGiaBieu.Text = _ttkhachhang.GB;
                txtDinhMuc.Text = _ttkhachhang.TGDM;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" & txtNoiNhan.Text.Trim() != "")
            {
                TTTL tttl = new TTTL();
                tttl.MaDon = decimal.Parse(_source["MaDon"]);
                tttl.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                tttl.NoiChuyenDen = _source["NoiChuyenDen"];
                tttl.LyDoChuyenDen = _source["LyDoChuyenDen"];
                if (_cTTTL.ThemTTTL(tttl))
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
                    _source.Add("MaTTTL", _cTTTL.getMaxMaTTTL().ToString());
                }
                CTTTTL cttttl = new CTTTTL();
                cttttl.MaTTTL = decimal.Parse(_source["MaTTTL"]);
                cttttl.DanhBo = txtDanhBo.Text.Trim();
                cttttl.HopDong = txtHopDong.Text.Trim();
                cttttl.HoTen = txtHoTen.Text.Trim();
                cttttl.DiaChi = txtDiaChi.Text.Trim();
                cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                cttttl.VeViec = txtVeViec.Text.Trim();
                cttttl.NoiDung = txtNoiDung.Text.Trim();
                cttttl.NoiNhan = txtNoiNhan.Text.Trim();
                ///
                if (chkGiamNuocXaBo.Checked)
                    cttttl.GiamNuocXaBo = true;
                if (chkKiemDinhDHN_Dung.Checked)
                    cttttl.KiemDinhDHN_Dung = true;
                if (chkKiemDinhDHN_Sai.Checked)
                    cttttl.KiemDinhDHN_Sai = true;
                if (chkThayDHN.Checked)
                    cttttl.ThayDHN = true;
                if (chkDieuChinh_GB_DM.Checked)
                    cttttl.DieuChinh_GB_DM = true;
                if (chkThuMoi.Checked)
                    cttttl.ThuMoi = true;
                if (chkThuBao.Checked)
                    cttttl.ThuBao = true;

                ///Ký Tên
                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    cttttl.ChucVu = "GIÁM ĐỐC";
                else
                    cttttl.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();

                if (_cTTTL.ThemCTTTTL(cttttl))
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                    dr["SoPhieu"] = _cTTTL.getMaxMaCTTTTL().ToString().Insert(4, "-");
                    dr["HoTen"] = cttttl.HoTen;
                    dr["DiaChi"] = cttttl.DiaChi;
                    dr["DanhBo"] = cttttl.DanhBo;
                    dr["HopDong"] = cttttl.HopDong;
                    dr["GiaBieu"] = cttttl.GiaBieu;
                    dr["DinhMuc"] = cttttl.DinhMuc;
                    dr["NgayNhanDon"] = _donkh.CreateDate;
                    dr["VeViec"] = cttttl.VeViec;
                    dr["NoiDung"] = cttttl.NoiDung;
                    dr["NoiNhan"] = cttttl.NoiNhan;
                    dr["ChucVu"] = cttttl.ChucVu;
                    dr["NguoiKy"] = cttttl.NguoiKy;

                    dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                    rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
