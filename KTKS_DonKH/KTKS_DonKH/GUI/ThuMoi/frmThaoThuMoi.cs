using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.ThuMoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThuMoi;
using KTKS_DonKH.GUI.BaoCao;
using CrystalDecisions.CrystalReports.Engine;

namespace KTKS_DonKH.GUI.ThuMoi
{
    public partial class frmThaoThuMoi : Form
    {
        string _mnu = "mnuThaoThuMoi";
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuMoi _cThuMoi = new CThuMoi();

        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        LinQ.ThuMoi _thumoi = null;

        public frmThaoThuMoi()
        {
            InitializeComponent();
        }

        private void frmThaoThuMoi_Load(object sender, EventArgs e)
        {
            dgvDSThu.AutoGenerateColumns = false;
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtLoTrinh.Text = hoadon.DOT + hoadon.MAY + hoadon.STT;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
        }

        public void LoadEntity(LinQ.ThuMoi entity)
        {
            if (entity.MaDonTKH != null)
            {
                _dontkh = _cDonKH.Get(entity.MaDonTKH.Value);
                txtMaDonCu.Text = entity.MaDonTKH.Value.ToString().Insert(entity.MaDonTKH.Value.ToString().Length - 2, "-");
            }
            else
                if (entity.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(entity.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + entity.MaDonTXL.Value.ToString().Insert(entity.MaDonTXL.Value.ToString().Length - 2, "-");
                }
                else
                    if (entity.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(entity.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + entity.MaDonTBC.Value.ToString().Insert(entity.MaDonTBC.Value.ToString().Length - 2, "-");
                    }

            txtDanhBo.Text = entity.DanhBo;
            //txtHopDong.Text = entity.HopDong;
            //txtLoTrinh.Text = entity.LoTrinh;
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            //txtGiaBieu.Text = entity.GiaBieu;
            //txtDinhMuc.Text = entity.DinhMuc;
            txtCanCu.Text = entity.CanCu;
            txtVaoLuc.Text = entity.VaoLuc;
            txtVeViec.Text = entity.VeViec;
        }

        public void Clear()
        {
            txtMaDonCu.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtLoTrinh.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            ///
            txtCanCu.Text = "Theo biên bản kiểm tra sử dụng nước";
            txtVaoLuc.Text = "";
            txtVeViec.Text = "Thanh toán chi phí (đồng hồ nước) đứt chì góc theo biên bản số";

            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _thumoi = null;
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
                        
                        dgvDSThu.DataSource = _cThuMoi.GetDS("TXL", _dontxl.MaDon);

                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            LoadTTKH(_hoadon);
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtDanhBo.Text = _dontxl.DanhBo;
                            txtHopDong.Text = _dontxl.HopDong;
                            txtLoTrinh.Text = _dontxl.MLT;
                            txtHoTen.Text = _dontxl.HoTen;
                            txtDiaChi.Text = _dontxl.DiaChi;
                            txtGiaBieu.Text = _dontxl.GiaBieu;
                            txtDinhMuc.Text = _dontxl.DinhMuc;
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
                            dgvDSThu.DataSource = _cThuMoi.GetDS("TBC", _dontbc.MaDon);

                            if (_cThuTien.GetMoiNhat(_dontbc.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtDanhBo.Text = _dontbc.DanhBo;
                                txtHopDong.Text = _dontbc.HopDong;
                                txtLoTrinh.Text = _dontbc.MLT;
                                txtHoTen.Text = _dontbc.HoTen;
                                txtDiaChi.Text = _dontbc.DiaChi;
                                txtGiaBieu.Text = _dontbc.GiaBieu;
                                txtDinhMuc.Text = _dontbc.DinhMuc;
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
                            dgvDSThu.DataSource = _cThuMoi.GetDS("TKH", _dontkh.MaDon);

                            if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                            {
                                _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtDanhBo.Text = _dontkh.DanhBo;
                                txtHopDong.Text = _dontkh.HopDong;
                                txtLoTrinh.Text = _dontkh.MLT;
                                txtHoTen.Text = _dontkh.HoTen;
                                txtDiaChi.Text = _dontkh.DiaChi;
                                txtGiaBieu.Text = _dontkh.GiaBieu;
                                txtDinhMuc.Text = _dontkh.DinhMuc;
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVeViec.Text += " " + txtMaDonCu.Text.Trim();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    LinQ.ThuMoi entity = new LinQ.ThuMoi();

                    if (_dontkh != null)
                        entity.MaDonTKH = _dontkh.MaDon;
                    else
                        if (_dontxl != null)
                            entity.MaDonTXL = _dontxl.MaDon;
                        else
                            if (_dontbc != null)
                                entity.MaDonTBC = _dontbc.MaDon;

                    entity.DanhBo = txtDanhBo.Text.Trim();
                    entity.HoTen = txtHoTen.Text.Trim();
                    entity.DiaChi = txtDiaChi.Text.Trim();
                    entity.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if(string.IsNullOrEmpty(txtDinhMuc.Text.Trim())==false)
                        entity.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    entity.CanCu = txtCanCu.Text.Trim();
                    entity.VaoLuc = txtVaoLuc.Text.Trim();
                    entity.VeViec = txtVeViec.Text.Trim();

                    if (_cThuMoi.Them(entity))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
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
                    if (_thumoi != null)
                    {
                        _thumoi.DanhBo = txtDanhBo.Text.Trim();
                        _thumoi.HoTen = txtHoTen.Text.Trim();
                        _thumoi.DiaChi = txtDiaChi.Text.Trim();
                        _thumoi.CanCu = txtCanCu.Text.Trim();
                        _thumoi.VaoLuc = txtVaoLuc.Text.Trim();
                        _thumoi.VeViec = txtVeViec.Text.Trim();

                        if (_cThuMoi.Sua(_thumoi))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                    MessageBox.Show("Chưa chọn thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (_thumoi != null)
                    {
                        if (_cThuMoi.Xoa(_thumoi))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Chưa chọn thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_thumoi != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                if (_thumoi.MaDonTKH != null)
                    dr["SoPhieu"] = _thumoi.MaDonTKH.ToString().Insert(_thumoi.MaDonTKH.ToString().Length - 2, "-");
                else
                    if (_thumoi.MaDonTXL != null)
                        dr["SoPhieu"] = _thumoi.MaDonTXL.ToString().Insert(_thumoi.MaDonTXL.ToString().Length - 2, "-");
                    else
                        if (_thumoi.MaDonTBC != null)
                            dr["SoPhieu"] = _thumoi.MaDonTBC.ToString().Insert(_thumoi.MaDonTBC.ToString().Length - 2, "-");

                dr["HoTen"] = _thumoi.HoTen;
                dr["DiaChi"] = _thumoi.DiaChi;
                if (!string.IsNullOrEmpty(_thumoi.DanhBo) && _thumoi.DanhBo.Length == 11)
                    dr["DanhBo"] = _thumoi.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["GiaBieu"] = _thumoi.GiaBieu.Value.ToString();
                dr["DinhMuc"] = _thumoi.DinhMuc.Value.ToString();
                dr["CanCu"] = _thumoi.CanCu;
                dr["VaoLuc"] = _thumoi.VaoLuc;
                dr["VeViec"] = _thumoi.VeViec;
                dr["Lan"] = _thumoi.STT;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                ReportDocument rpt=new ReportDocument();
                if (radDutChi.Checked == true)
                    rpt = new rptThuMoiDutChi();
                else
                    if (radCDDM.Checked == true)
                        rpt = new rptThuMoiChuyenDe();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            else
                MessageBox.Show("Chưa chọn thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _thumoi = _cThuMoi.Get(int.Parse(dgvDSThu.CurrentRow.Cells["ID"].Value.ToString()));
                LoadEntity(_thumoi);
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
