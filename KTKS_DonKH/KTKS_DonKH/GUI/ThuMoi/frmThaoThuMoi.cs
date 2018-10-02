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
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.ThuMoi
{
    public partial class frmThaoThuMoi : Form
    {
        string _mnu = "mnuThaoThuMoi";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuMoi _cThuMoi = new CThuMoi();
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        LinQ.ThuMoi_ChiTiet _thumoi = null;

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

        public void LoadEntity(LinQ.ThuMoi_ChiTiet entity)
        {
            if (entity.ThuMoi.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(entity.ThuMoi.MaDonMoi.Value, entity.STT.Value);
                txtMaDonMoi.Text = entity.ThuMoi.MaDonMoi.Value.ToString();
            }
            else
                if (entity.ThuMoi.MaDonTKH != null)
            {
                _dontkh = _cDonKH.Get(entity.ThuMoi.MaDonTKH.Value);
                txtMaDonCu.Text = entity.ThuMoi.MaDonTKH.Value.ToString().Insert(entity.ThuMoi.MaDonTKH.Value.ToString().Length - 2, "-");
            }
            else
                    if (entity.ThuMoi.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(entity.ThuMoi.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + entity.ThuMoi.MaDonTXL.Value.ToString().Insert(entity.ThuMoi.MaDonTXL.Value.ToString().Length - 2, "-");
                }
                else
                        if (entity.ThuMoi.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(entity.ThuMoi.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + entity.ThuMoi.MaDonTBC.Value.ToString().Insert(entity.ThuMoi.MaDonTBC.Value.ToString().Length - 2, "-");
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
            //txtCanCu.Text = "Theo biên bản kiểm tra sử dụng nước";
            txtCanCu.Text = "";
            txtVaoLuc.Text = "";
            //txtVeViec.Text = "Thanh toán chi phí (đồng hồ nước) đứt chì góc theo biên bản số";
            txtVeViec.Text = "";

            _dontu_ChiTiet = null;
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
                        
                        dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TXL", _dontxl.MaDon);

                        _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                        if (_hoadon != null)
                        {
                            LoadTTKH(_hoadon);
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            //txtDanhBo.Text = _dontxl.DanhBo;
                            //txtHopDong.Text = _dontxl.HopDong;
                            //txtLoTrinh.Text = _dontxl.MLT;
                            //txtHoTen.Text = _dontxl.HoTen;
                            //txtDiaChi.Text = _dontxl.DiaChi;
                            //txtGiaBieu.Text = _dontxl.GiaBieu;
                            //txtDinhMuc.Text = _dontxl.DinhMuc;
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
                            dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TBC", _dontbc.MaDon);

                            _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                            if (_hoadon != null)
                            {
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                //txtDanhBo.Text = _dontbc.DanhBo;
                                //txtHopDong.Text = _dontbc.HopDong;
                                //txtLoTrinh.Text = _dontbc.MLT;
                                //txtHoTen.Text = _dontbc.HoTen;
                                //txtDiaChi.Text = _dontbc.DiaChi;
                                //txtGiaBieu.Text = _dontbc.GiaBieu;
                                //txtDinhMuc.Text = _dontbc.DinhMuc;
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
                            dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TKH", _dontkh.MaDon);

                            _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                            if (_hoadon != null)
                            {
                                LoadTTKH(_hoadon);
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                //txtDanhBo.Text = _dontkh.DanhBo;
                                //txtHopDong.Text = _dontkh.HopDong;
                                //txtLoTrinh.Text = _dontkh.MLT;
                                //txtHoTen.Text = _dontkh.HoTen;
                                //txtDiaChi.Text = _dontkh.DiaChi;
                                //txtGiaBieu.Text = _dontkh.GiaBieu;
                                //txtDinhMuc.Text = _dontkh.DinhMuc;
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVeViec.Text += " " + txtMaDonCu.Text.Trim();
            }
        }

        private void txtMaDonMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDonMoi.Text.Trim() != "")
            {
                string MaDon = txtMaDonMoi.Text.Trim();
                Clear();
                if (MaDon.Contains(".") == true)
                {
                    string[] MaDons = MaDon.Split('.');
                    _dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                }
                else
                {
                    _dontu_ChiTiet = _cDonTu.get(int.Parse(MaDon)).DonTu_ChiTiets.SingleOrDefault();
                }
                //
                if (_dontu_ChiTiet != null)
                {
                    txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString();
                    dgvDSThu.DataSource = _cThuMoi.getDS_ChiTiet("TBC", _dontbc.MaDon);

                    _hoadon = _cThuTien.GetMoiNhat(_dontu_ChiTiet.DanhBo);
                    if (_hoadon != null)
                    {
                        LoadTTKH(_hoadon);
                    }
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    LinQ.ThuMoi_ChiTiet entity = new LinQ.ThuMoi_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cThuMoi.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            LinQ.ThuMoi tm = new LinQ.ThuMoi();
                            tm.MaDonTKH = _dontu_ChiTiet.MaDon;
                            _cThuMoi.them(tm);
                        }
                        if (_cThuMoi.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()) == true)
                        {
                            if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                            else
                                entity.Lan = _cThuMoi.maxLan_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()) + 1;
                        }
                        else
                            entity.Lan = 2;
                        entity.ID = _cThuMoi.get(_dontu_ChiTiet.MaDon.Value).ID;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cThuMoi.checkExist("TKH", _dontkh.MaDon) == false)
                            {
                                LinQ.ThuMoi tm = new LinQ.ThuMoi();
                                tm.MaDonTKH = _dontkh.MaDon;
                                _cThuMoi.them(tm);
                            }
                            if (_cThuMoi.checkExist_ChiTiet("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()) == true)
                            {
                                if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                                else
                                    entity.Lan = _cThuMoi.maxLan_ChiTiet("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim())+1;
                            }
                            else
                                entity.Lan = 2;
                            entity.ID = _cThuMoi.get("TKH", _dontkh.MaDon).ID;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cThuMoi.checkExist("TXL", _dontxl.MaDon) == false)
                                {
                                    LinQ.ThuMoi tm = new LinQ.ThuMoi();
                                    tm.MaDonTXL = _dontxl.MaDon;
                                    _cThuMoi.them(tm);
                                }
                                if (_cThuMoi.checkExist_ChiTiet("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) == true)
                                {
                                    if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        return;
                                    else
                                        entity.Lan = _cThuMoi.maxLan_ChiTiet("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) + 1;
                                }
                                else
                                    entity.Lan = 2;
                                entity.ID = _cThuMoi.get("TXL", _dontxl.MaDon).ID;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cThuMoi.checkExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        LinQ.ThuMoi tm = new LinQ.ThuMoi();
                                        tm.MaDonTBC = _dontbc.MaDon;
                                        _cThuMoi.them(tm);
                                    }
                                    if (_cThuMoi.checkExist_ChiTiet("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                            return;
                                        else
                                            entity.Lan = _cThuMoi.maxLan_ChiTiet("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) + 1;
                                    }
                                    else
                                        entity.Lan = 2;
                                    entity.ID = _cThuMoi.get("TBC", _dontbc.MaDon).ID;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                    
                    entity.DanhBo = txtDanhBo.Text.Trim();
                    entity.HoTen = txtHoTen.Text.Trim();
                    entity.DiaChi = txtDiaChi.Text.Trim();
                    entity.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                        entity.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (_hoadon != null)
                    {
                        entity.Nam = _hoadon.NAM;
                        entity.Ky = _hoadon.KY;
                        entity.Dot = _hoadon.DOT;
                        entity.Quan = _hoadon.Quan;
                        entity.Phuong = _hoadon.Phuong;
                    }
                    entity.CanCu = txtCanCu.Text.Trim();
                    entity.VaoLuc = txtVaoLuc.Text.Trim();
                    entity.VeViec = txtVeViec.Text.Trim();

                    if (_cThuMoi.them_ChiTiet(entity))
                    {
                        if (_dontu_ChiTiet != null)
                            _cDonTu.Them_LichSu("Thư Mời", "Đã Gửi Thư Mời", _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
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
                        if (_hoadon != null)
                        {
                            _thumoi.Nam = _hoadon.NAM;
                            _thumoi.Ky = _hoadon.KY;
                            _thumoi.Dot = _hoadon.DOT;
                            _thumoi.Quan = _hoadon.Quan;
                            _thumoi.Phuong = _hoadon.Phuong;
                        }
                        _thumoi.CanCu = txtCanCu.Text.Trim();
                        _thumoi.VaoLuc = txtVaoLuc.Text.Trim();
                        _thumoi.VeViec = txtVeViec.Text.Trim();

                        if (_cThuMoi.sua_ChiTiet(_thumoi))
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
                        if (_cThuMoi.xoa_ChiTiet(_thumoi))
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

                if (_thumoi.ThuMoi.MaDonMoi != null)
                    dr["SoPhieu"] = _thumoi.ThuMoi.MaDonMoi.ToString();
                else
                    if (_thumoi.ThuMoi.MaDonTKH != null)
                        dr["SoPhieu"] = _thumoi.ThuMoi.MaDonTKH.ToString().Insert(_thumoi.ThuMoi.MaDonTKH.ToString().Length - 2, "-");
                else
                        if (_thumoi.ThuMoi.MaDonTXL != null)
                            dr["SoPhieu"] = _thumoi.ThuMoi.MaDonTXL.ToString().Insert(_thumoi.ThuMoi.MaDonTXL.ToString().Length - 2, "-");
                    else
                            if (_thumoi.ThuMoi.MaDonTBC != null)
                            dr["SoPhieu"] = _thumoi.ThuMoi.MaDonTBC.ToString().Insert(_thumoi.ThuMoi.MaDonTBC.ToString().Length - 2, "-");

                dr["HoTen"] = _thumoi.HoTen;
                dr["DiaChi"] = _thumoi.DiaChi;
                if (!string.IsNullOrEmpty(_thumoi.DanhBo) && _thumoi.DanhBo.Length == 11)
                    dr["DanhBo"] = _thumoi.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["GiaBieu"] = _thumoi.GiaBieu.Value.ToString();
                dr["DinhMuc"] = _thumoi.DinhMuc.Value.ToString();
                dr["CanCu"] = _thumoi.CanCu;
                dr["VaoLuc"] = _thumoi.VaoLuc;
                dr["VeViec"] = _thumoi.VeViec;
                dr["Lan"] = _thumoi.Lan;
                dr["NoiNhan"] = _cTaiKhoan.GetHoTen(_thumoi.CreateBy.Value);

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
                _thumoi = _cThuMoi.get_ChiTiet(int.Parse(dgvDSThu.CurrentRow.Cells["IDCT"].Value.ToString()));
                LoadEntity(_thumoi);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                if (_hoadon != null)
                {
                    LoadTTKH(_hoadon);
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
