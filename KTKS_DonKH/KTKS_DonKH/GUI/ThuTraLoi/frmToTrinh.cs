using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ThuTraLoi
{
    public partial class frmToTrinh : Form
    {
        string _mnu = "mnuTTTL";
        CThuTien _cThuTien = new CThuTien();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CToTrinh _cTT = new CToTrinh();
        CDocSo _cDocSo = new CDocSo();
        CVeViecToTrinh _cVeViecToTrinh = new CVeViecToTrinh();

        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CTToTrinh _cttt = null;
        decimal _MaCTTT = -1;

        public frmToTrinh()
        {
            InitializeComponent();
        }

        public frmToTrinh(decimal MaCTTT)
        {
            _MaCTTT = MaCTTT;
            InitializeComponent();
        }

        private void frmToTrinh_Load(object sender, EventArgs e)
        {
            dgvToTrinh.AutoGenerateColumns = false;
            cmbTimTheo.SelectedIndex = 3;

            cmbVeViec.DataSource = _cVeViecToTrinh.GetDS();
            cmbVeViec.DisplayMember = "TenVV";
            cmbVeViec.SelectedIndex = -1;

            if (_MaCTTT != -1)
            {
                txtMaCTTT.Text = _MaCTTT.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaCTTT_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
        }

        public void LoadTT(CTToTrinh cttt)
        {
            if (cttt.ToTrinh.MaDon != null)
            {
                _dontkh = _cDonKH.Get(cttt.ToTrinh.MaDon.Value);
                txtMaDonCu.Text = cttt.ToTrinh.MaDon.Value.ToString().Insert(cttt.ToTrinh.MaDon.Value.ToString().Length - 2, "-");
            }
            else
                if (cttt.ToTrinh.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(cttt.ToTrinh.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + cttt.ToTrinh.MaDonTXL.Value.ToString().Insert(cttt.ToTrinh.MaDonTXL.Value.ToString().Length - 2, "-");
                }
                else
                    if (cttt.ToTrinh.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(cttt.ToTrinh.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + cttt.ToTrinh.MaDonTBC.Value.ToString().Insert(cttt.ToTrinh.MaDonTBC.Value.ToString().Length - 2, "-");
                    }

            txtMaCTTT.Text = cttt.MaCTTT.ToString().Insert(cttt.MaCTTT.ToString().Length - 2, "-");
            txtDanhBo.Text = cttt.DanhBo;
            txtHoTen.Text = cttt.HoTen;
            txtDiaChi.Text = cttt.DiaChi;
            txtVeViec.Text = cttt.VeViec;
            txtKinhTrinh.Text = cttt.KinhTrinh;
            txtNoiDung.Text = cttt.NoiDung;
            txtNoiNhan.Text = cttt.NoiNhan;

        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            txtMaCTTT.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            txtVeViec.Text = "";
            txtKinhTrinh.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            ///
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _cttt = null;
        }

        private void txtMaDonCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDonCu.Text.Trim() != "")
            {
                string MaDon = txtMaDonCu.Text.Trim();
                Clear();
                txtMaDonCu.Text = MaDon;
                ///Đơn Tổ Xử Lý
                if (txtMaDonCu.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                    {
                        _dontxl = _cDonTXL.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDonCu.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");

                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            LoadTTKH(_hoadon);
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtDanhBo.Text = _dontxl.DanhBo;
                            txtHoTen.Text = _dontxl.HoTen;
                            txtDiaChi.Text = _dontxl.DiaChi;
                        }
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (txtMaDonCu.Text.Trim().ToUpper().Contains("TBC"))
                    {
                        if (_cDonTBC.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", ""))) == true)
                        {
                            _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDonCu.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");

                            if (_cThuTien.GetMoiNhat(_dontbc.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtDanhBo.Text = _dontbc.DanhBo;
                                txtHoTen.Text = _dontbc.HoTen;
                                txtDiaChi.Text = _dontbc.DiaChi;
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (_cDonKH.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", ""))) == true)
                        {
                            _dontkh = _cDonKH.Get(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));
                            txtMaDonCu.Text = _dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");

                            if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtDanhBo.Text = _dontkh.DanhBo;
                                txtHoTen.Text = _dontkh.HoTen;
                                txtDiaChi.Text = _dontkh.DiaChi;
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaCTTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && _cTT.CheckExist_CT(decimal.Parse(txtMaCTTT.Text.Trim().Replace("-", ""))) == true)
            {
                _cttt = _cTT.GetCT(decimal.Parse(txtMaCTTT.Text.Trim().Replace("-", "")));
                LoadTT(_cttt);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    CTToTrinh cttt = new CTToTrinh();

                    if (_dontkh != null)
                    {
                        if (_cTT.CheckExist("TKH", _dontkh.MaDon) == false)
                        {
                            ToTrinh tt = new ToTrinh();
                            tt.MaDon = _dontkh.MaDon;
                            tt.MaDonMoi = _dontkh.MaDonMoi;
                            _cTT.Them(tt);
                        }
                        if (_cTT.CheckExist_CT("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        cttt.MaTT = _cTT.Get("TKH", _dontkh.MaDon).MaTT;
                    }
                    else
                        if (_dontxl != null)
                        {
                            if (_cTT.CheckExist("TXL", _dontxl.MaDon) == false)
                            {
                                ToTrinh tt = new ToTrinh();
                                tt.MaDonTXL = _dontxl.MaDon;
                                tt.MaDonMoi = _dontxl.MaDonMoi;
                                _cTT.Them(tt);
                            }
                            if (_cTT.CheckExist_CT("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                            {
                                MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                            }
                            cttt.MaTT = _cTT.Get("TXL", _dontxl.MaDon).MaTT;
                        }
                        else
                            if (_dontbc != null)
                            {
                                if (_cTT.CheckExist("TBC", _dontbc.MaDon) == false)
                                {
                                    ToTrinh tt = new ToTrinh();
                                    tt.MaDonTBC = _dontbc.MaDon;
                                    tt.MaDonMoi = _dontbc.MaDonMoi;
                                    _cTT.Them(tt);
                                }
                                if (_cTT.CheckExist_CT("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //return;
                                }
                                cttt.MaTT = _cTT.Get("TBC", _dontbc.MaDon).MaTT;
                            }
                            else
                            {
                                MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                    cttt.DanhBo = txtDanhBo.Text.Trim();
                    cttt.HoTen = txtHoTen.Text.Trim();
                    cttt.DiaChi = txtDiaChi.Text.Trim();
                    cttt.VeViec = txtVeViec.Text.Trim();
                    cttt.KinhTrinh = txtKinhTrinh.Text.Trim();
                    cttt.NoiDung = txtNoiDung.Text;
                    cttt.NoiNhan = txtNoiNhan.Text.Trim();
                    if (_hoadon != null)
                    {
                        cttt.Dot = _hoadon.DOT.ToString();
                        cttt.Ky = _hoadon.KY.ToString();
                        cttt.Nam = _hoadon.NAM.ToString();
                        cttt.Phuong = _hoadon.Phuong;
                        cttt.Quan = _hoadon.Quan;
                    }

                    if (_cTT.ThemCT(cttt))
                    {
                        Clear();
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaDonCu.Focus();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_cttt != null)
                    {
                        _cttt.DanhBo = txtDanhBo.Text.Trim();
                        _cttt.HoTen = txtHoTen.Text.Trim();
                        _cttt.DiaChi = txtDiaChi.Text.Trim();
                        _cttt.VeViec = txtVeViec.Text.Trim();
                        _cttt.KinhTrinh = txtKinhTrinh.Text.Trim();
                        _cttt.NoiDung = txtNoiDung.Text;
                        _cttt.NoiNhan = txtNoiNhan.Text.Trim();
                        if (_hoadon != null)
                        {
                            _cttt.Dot = _hoadon.DOT.ToString();
                            _cttt.Ky = _hoadon.KY.ToString();
                            _cttt.Nam = _hoadon.NAM.ToString();
                            _cttt.Phuong = _hoadon.Phuong;
                            _cttt.Quan = _hoadon.Quan;
                        }

                        if (_cTT.SuaCT(_cttt))
                        {
                            Clear();
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDonCu.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_cttt != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cTT.XoaCT(_cttt))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDonCu.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Danh Bộ":
                case "Mã TT":
                    txtNoiDungTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvToTrinh.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã TT":
                    dgvToTrinh.DataSource = _cTT.GetDS(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace(" ", "").Replace("-","")));
                    break;
                case "Danh Bộ":
                    dgvToTrinh.DataSource = _cTT.GetDS(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                    break;
                case "Ngày":
                    dgvToTrinh.DataSource = _cTT.GetDS(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void dgvToTrinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _cttt = _cTT.GetCT(decimal.Parse(dgvToTrinh["MaCTTT",e.RowIndex].Value.ToString()));
            LoadTT(_cttt);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_cttt != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                dr["SoPhieu"] = _cttt.MaCTTT.ToString().Insert(_cttt.MaCTTT.ToString().Length - 2, "-");
                dr["HoTen"] = _cttt.HoTen;
                dr["DiaChi"] = _cttt.DiaChi;
                if (!string.IsNullOrEmpty(_cttt.DanhBo) && _cttt.DanhBo.Length == 11)
                    dr["DanhBo"] = _cttt.DanhBo.Insert(7, " ").Insert(4, " ");

                dr["VeViec"] = _cttt.VeViec;
                dr["KinhTrinh"] = _cttt.KinhTrinh;
                dr["ThongQua"] = _cttt.ThongQua;
                dr["NoiDung"] = _cttt.NoiDung;
                dr["NoiNhan"] = _cttt.NoiNhan;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                rptToTrinh rpt = new rptToTrinh();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
            }
        }

        private void dgvToTrinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvToTrinh.Columns[e.ColumnIndex].Name == "MaCTTT" && e.Value != null)
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void dgvToTrinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvToTrinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void cmbVeViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVeViec.SelectedIndex != -1)
            {
                ToTrinhVeViec vv = (ToTrinhVeViec)cmbVeViec.SelectedItem;
                txtVeViec.Text = vv.TenVV;
                txtNoiDung.Text = vv.NoiDung;
                if (txtMaDonCu.Text.Trim() != "")
                    txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDonCu.Text.Trim() + ")";
                //else
                //    if (txtMaDonMoi.Text.Trim() != "")
                //        txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDonMoi.Text.Trim() + ")";
            }
            else
            {
                txtVeViec.Text = "";
                txtNoiDung.Text = "";
                txtNoiNhan.Text = "";
            }
        }

        
    }
}
