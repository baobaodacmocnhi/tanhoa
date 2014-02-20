using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.KiemTraXacMinh;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmKTXM : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        DonKH _donkh = null;
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CDonKH _cDonKH = new CDonKH();
        CTTKH _cTTKH = new CTTKH();
        CKTXM _cKTXM = new CKTXM();
        int selectedindex = -1;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public frmKTXM()
        {
            InitializeComponent();
        }

        private void frmKTXM_Load(object sender, EventArgs e)
        {
            dgvDSKetQuaKiemTra.AutoGenerateColumns = false;
            dgvDSKetQuaKiemTra.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSKetQuaKiemTra.Font, FontStyle.Bold);
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
            //txtDienThoai.Text = _donkh.DienThoai;
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
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
            txtNoiDungKiemTra.Text = "";
            ///
            dateKTXM.Value = DateTime.Now;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiSo.Text = "";
            txtChiMatSo.Text = "";
            txtChiKhoaGoc.Text = "";
            txtMucDichSuDung.Text = "";
            txtDienThoai.Text = "";
            txtHoTenKHKy.Text = "";
            txtNoiDungKiemTra.Text = "";

            selectedindex = -1;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                {
                    _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                    //txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                    {
                        _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                        LoadTTKH(_ttkhachhang);
                    }
                    else
                    {
                        _ttkhachhang = null;
                        Clear();
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(_donkh.MaDon);

                }
                else
                {
                    _donkh = null;
                    dgvDSKetQuaKiemTra.DataSource = null;
                    Clear();
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void dgvDSKetQuaKiemTra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSKetQuaKiemTra.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSKetQuaKiemTra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSKetQuaKiemTra.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSKetQuaKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                LoadCTKTXM(_cKTXM.getCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", e.RowIndex].Value.ToString())));
            }
            catch (Exception)
            {
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_donkh != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != "") && txtNoiDungKiemTra.Text.Trim() != "")
            {
                if (!_cKTXM.CheckKTMXbyMaDon(_donkh.MaDon))
                {
                    KTXM ktxm = new KTXM();
                    ktxm.MaDon = _donkh.MaDon;
                    //string MaNoiChuyenDen, NoiChuyenDen, LyDoChuyenDen;
                    //_cKTXM.GetInfobyMaDon(_donkh.MaDon, out MaNoiChuyenDen, out NoiChuyenDen, out LyDoChuyenDen);
                    //ktxm.MaNoiChuyenDen = decimal.Parse(MaNoiChuyenDen);
                    //ktxm.NoiChuyenDen = NoiChuyenDen;
                    //ktxm.LyDoChuyenDen = LyDoChuyenDen;
                    if (_cKTXM.ThemKTXM(ktxm))
                    {
                        ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                        //DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(MaNoiChuyenDen));
                        //donkh.Chuyen = true;
                        //donkh.MaChuyen = "KTXM";
                        //donkh.LyDoChuyen = "";
                        //donkh.Nhan = true;
                        //_cDonKH.SuaDonKH(donkh);
                    }
                }
                CTKTXM ctktxm = new CTKTXM();
                ctktxm.MaKTXM = _cKTXM.getKTXMbyMaDon(_donkh.MaDon).MaKTXM;
                ctktxm.DanhBo = txtDanhBo.Text.Trim();
                ctktxm.HopDong = txtHopDong.Text.Trim();
                ctktxm.HoTen = txtHoTen.Text.Trim();
                ctktxm.DiaChi = txtDiaChi.Text.Trim();
                ctktxm.GiaBieu = txtGiaBieu.Text.Trim();
                ctktxm.DinhMuc = txtDinhMuc.Text.Trim();
                ctktxm.Dot = _ttkhachhang.Dot;
                ctktxm.Ky = _ttkhachhang.Ky;
                ctktxm.Nam = _ttkhachhang.Nam;
                ///
                ctktxm.NgayKTXM = dateKTXM.Value;
                ctktxm.Hieu = txtHieu.Text.Trim();
                ctktxm.Co = txtCo.Text.Trim();
                ctktxm.SoThan = txtSoThan.Text.Trim();
                ctktxm.ChiSo = txtChiSo.Text.Trim();
                ctktxm.ChiMatSo = txtChiMatSo.Text.Trim();
                ctktxm.ChiKhoaGoc = txtChiKhoaGoc.Text.Trim();
                ctktxm.MucDichSuDung = txtMucDichSuDung.Text.Trim();
                ctktxm.DienThoai = txtDienThoai.Text.Trim();
                ctktxm.HoTenKHKy = txtHoTenKHKy.Text.Trim();
                ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();

                if (_cKTXM.ThemCTKTXM(ctktxm))
                {
                    dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(_donkh.MaDon);
                    _ttkhachhang = null;
                    Clear();
                }
            }
            else
                MessageBox.Show("Đơn này không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
            {
                CTKTXM ctktxm = new CTKTXM();
                ctktxm = _cKTXM.getCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", selectedindex].Value.ToString()));
                ctktxm.DanhBo = txtDanhBo.Text.Trim();
                ctktxm.HopDong = txtHopDong.Text.Trim();
                ctktxm.HoTen = txtHoTen.Text.Trim();
                ctktxm.DiaChi = txtDiaChi.Text.Trim();
                ctktxm.GiaBieu = txtGiaBieu.Text.Trim();
                ctktxm.DinhMuc = txtDinhMuc.Text.Trim();
                ctktxm.Dot = _ttkhachhang.Dot;
                ctktxm.Ky = _ttkhachhang.Ky;
                ctktxm.Nam = _ttkhachhang.Nam;
                ///
                ctktxm.NgayKTXM = dateKTXM.Value;
                ctktxm.Hieu = txtHieu.Text.Trim();
                ctktxm.Co = txtCo.Text.Trim();
                ctktxm.SoThan = txtSoThan.Text.Trim();
                ctktxm.ChiSo = txtChiSo.Text.Trim();
                ctktxm.ChiMatSo = txtChiMatSo.Text.Trim();
                ctktxm.ChiKhoaGoc = txtChiKhoaGoc.Text.Trim();
                ctktxm.MucDichSuDung = txtMucDichSuDung.Text.Trim();
                ctktxm.DienThoai = txtDienThoai.Text.Trim();
                ctktxm.HoTenKHKy = txtHoTenKHKy.Text.Trim();
                ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();

                if (_donkh != null && (txtDanhBo.Text.Trim() != "" || txtHoTen.Text.Trim() != "" || txtDiaChi.Text.Trim() != "") && txtNoiDungKiemTra.Text.Trim() != "")
                {
                    if (_cKTXM.SuaCTKTXM(ctktxm))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
