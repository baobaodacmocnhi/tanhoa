using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmShowKTXM : Form
    {
        decimal _MaCTKTXM = 0;
        CTKTXM _ctktxm = new CTKTXM();
        CKTXM _cKTXM = new CKTXM();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        TTKhachHang _ttkhachhang = null;
        CTTKH _cTTKH = new CTTKH();

        public frmShowKTXM()
        {
            InitializeComponent();
        }

        public frmShowKTXM(decimal MaCTKTXM)
        {
            InitializeComponent();
            _MaCTKTXM = MaCTKTXM;
        }

        public frmShowKTXM(decimal MaCTKTXM, bool TimKiem)
        {
            InitializeComponent();
            _MaCTKTXM = MaCTKTXM;
            if (TimKiem)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void frmShowKTXM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(30, 70);
            if (_cKTXM.CheckCTKTXMbyID(_MaCTKTXM))
            {
                _ctktxm = _cKTXM.getCTKTXMbyID(_MaCTKTXM);
                //if (CTaiKhoan.RoleQLKTXM_CapNhat)
                //    btnXoa.Enabled = true;
                if (_ctktxm.KTXM.ToXuLy)
                    txtMaDon.Text = "TXL"+_ctktxm.KTXM.MaDonTXL.ToString().Insert(_ctktxm.KTXM.MaDonTXL.ToString().Length - 2, "-");
                else
                    txtMaDon.Text = _ctktxm.KTXM.MaDon.ToString().Insert(_ctktxm.KTXM.MaDon.ToString().Length - 2, "-");
                LoadCTKTXM(_ctktxm);
            }
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
            string a, b, c;
            _cPhuongQuan.getTTDHNbyID(txtDanhBo.Text.Trim(), out a, out b, out c);
            txtHieu.Text = a;
            txtCo.Text = b;
            txtSoThan.Text = c;
        }

        public void LoadCTKTXM(CTKTXM ctktxm)
        {
            txtDanhBo.Text = ctktxm.DanhBo;
            txtHopDong.Text = ctktxm.HopDong;
            txtHoTen.Text = ctktxm.HoTen;
            txtDiaChi.Text = ctktxm.DiaChi;
            txtGiaBieu.Text = ctktxm.GiaBieu;
            txtDinhMuc.Text = ctktxm.DinhMuc;
            ///
            dateKTXM.Value = ctktxm.NgayKTXM.Value;
            txtHieu.Text = ctktxm.Hieu;
            txtCo.Text = ctktxm.Co;
            txtSoThan.Text = ctktxm.SoThan;
            txtChiSo.Text = ctktxm.ChiSo;
            txtChiMatSo.Text = ctktxm.ChiMatSo;
            txtChiKhoaGoc.Text = ctktxm.ChiKhoaGoc;
            txtMucDichSuDung.Text = ctktxm.MucDichSuDung;
            txtDienThoai.Text = ctktxm.DienThoai;
            txtHoTenKHKy.Text = ctktxm.HoTenKHKy;
            txtNoiDungKiemTra.Text = ctktxm.NoiDungKiemTra;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            //txtNoiDungKiemTra.Text = "";
            ///
            //dateKTXM.Value = DateTime.Now;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            //txtChiSo.Text = "";
            //txtChiMatSo.Text = "";
            //txtChiKhoaGoc.Text = "";
            //txtMucDichSuDung.Text = "";
            //txtDienThoai.Text = "";
            //txtHoTenKHKy.Text = "";
            //txtNoiDungKiemTra.Text = "";

        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                }
                else
                {
                    _ttkhachhang = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _ctktxm.DanhBo = txtDanhBo.Text.Trim();
            _ctktxm.HopDong = txtHopDong.Text.Trim();
            _ctktxm.HoTen = txtHoTen.Text.Trim();
            _ctktxm.DiaChi = txtDiaChi.Text.Trim();
            _ctktxm.GiaBieu = txtGiaBieu.Text.Trim();
            _ctktxm.DinhMuc = txtDinhMuc.Text.Trim();
            if (_ttkhachhang != null)
            {
                _ctktxm.Dot = _ttkhachhang.Dot;
                _ctktxm.Ky = _ttkhachhang.Ky;
                _ctktxm.Nam = _ttkhachhang.Nam;
            }
            ///
            _ctktxm.NgayKTXM = dateKTXM.Value;
            _ctktxm.Hieu = txtHieu.Text.Trim();
            _ctktxm.Co = txtCo.Text.Trim();
            _ctktxm.SoThan = txtSoThan.Text.Trim();
            _ctktxm.ChiSo = txtChiSo.Text.Trim();
            _ctktxm.ChiMatSo = txtChiMatSo.Text.Trim();
            _ctktxm.ChiKhoaGoc = txtChiKhoaGoc.Text.Trim();
            _ctktxm.MucDichSuDung = txtMucDichSuDung.Text.Trim();
            _ctktxm.DienThoai = txtDienThoai.Text.Trim();
            _ctktxm.HoTenKHKy = txtHoTenKHKy.Text.Trim();
            _ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();

            if (_cKTXM.SuaCTKTXM(_ctktxm))
            {
                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_cKTXM.XoaCTKTXM(_ctktxm))
                {
                    MessageBox.Show("Xóa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void frmShowKTXM_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
