using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.DAL;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao.TruyThu;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.GUI.DonTu;
using KTKS_DonKH.DAL.ToXuLy;
using System.Transactions;

namespace KTKS_DonKH.GUI.TruyThu
{
    public partial class frmGianLan : Form
    {
        string _mnu = "mnuGianLanTienNuoc";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDocSo = new CDHN();
        CGianLan _cGianLan = new CGianLan();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        GianLan_ChiTiet _gianlan = null;
        int _ID = -1;

        public frmGianLan()
        {
            InitializeComponent();
        }

        public frmGianLan(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private void frmGianLan_Load(object sender, EventArgs e)
        {
            dgvGianLan.AutoGenerateColumns = false;

            DataTable dt = _cGianLan.GetDSNoiDungViPham();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (DataRow item in dt.Rows)
            {
                auto.Add(item["NoiDungViPham"].ToString());
            }
            txtNoiDungViPham.AutoCompleteCustomSource = auto;

            dt = _cGianLan.GetDSTinhTrang();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (DataRow item in dt.Rows)
            {
                auto1.Add(item["TinhTrang"].ToString());
            }
            txtTinhTrang.AutoCompleteCustomSource = auto1;

            if (_ID != -1)
            {
                _gianlan = _cGianLan.get_ChiTiet(int.Parse(dgvGianLan.SelectedRows[0].Cells["ID"].Value.ToString()));
                LoadGianLan(_gianlan);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
        }

        public void LoadGianLan(GianLan_ChiTiet entity)
        {
            if (entity.GianLan.MaDonMoi != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(entity.GianLan.MaDonMoi.Value, entity.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = entity.GianLan.MaDonMoi.ToString();
                else
                    txtMaDonMoi.Text = entity.GianLan.MaDonMoi.Value.ToString() + "." + entity.STT.Value.ToString();
            }
            else
            if (entity.GianLan.MaDon != null)
            {
                _dontkh = _cDonKH.Get(entity.GianLan.MaDon.Value);
                txtMaDonCu.Text = entity.GianLan.MaDon.Value.ToString().Insert(entity.GianLan.MaDon.Value.ToString().Length - 2, "-");
            }
            else
                if (entity.GianLan.MaDonTXL != null)
                {
                    _dontxl = _cDonTXL.Get(entity.GianLan.MaDonTXL.Value);
                    txtMaDonCu.Text = "TXL" + entity.GianLan.MaDonTXL.Value.ToString().Insert(entity.GianLan.MaDonTXL.Value.ToString().Length - 2, "-");
                }
                else
                    if (entity.GianLan.MaDonTBC != null)
                    {
                        _dontbc = _cDonTBC.Get(entity.GianLan.MaDonTBC.Value);
                        txtMaDonCu.Text = "TBC" + entity.GianLan.MaDonTBC.Value.ToString().Insert(entity.GianLan.MaDonTBC.Value.ToString().Length - 2, "-");
                    }
            chkXepDon.Checked = entity.XepDon;
            txtDanhBo.Text = entity.DanhBo;
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            if (entity.NgayKTXM != null)
                dateKTXM.Value = entity.NgayKTXM.Value;
            txtNoiDungViPham.Text = entity.NoiDungViPham;
            if (entity.TienDHN != null)
                txtTienDHN.Text = entity.TienDHN.Value.ToString();
            txtTinhTrang.Text = entity.TinhTrang;
            txtNhanVien.Text = entity.NhanVien;
            if (entity.ToTrinh1)
            {
                chkToTrinh1.Checked = true;
                txtTieuThu1.Text = entity.TieuThu1.Value.ToString();
                txtGiaBan1.Text = entity.GiaBan1.Value.ToString();
                txtSoThongBao1.Text = entity.SoThongBao1;
            }
            else
            {
                chkToTrinh1.Checked = false;
                txtTieuThu1.Text = "";
                txtGiaBan1.Text = "";
                txtSoThongBao1.Text = "";
            }
            ///
            if (entity.ToTrinh2)
            {
                chkToTrinh2.Checked = true;
                txtTieuThu2.Text = entity.TieuThu2.Value.ToString();
                txtGiaBan2.Text = entity.GiaBan2.Value.ToString();
                txtSoThongBao2.Text = entity.SoThongBao2;
            }
            else
            {
                chkToTrinh2.Checked = false;
                txtTieuThu2.Text = "";
                txtGiaBan2.Text = "";
                txtSoThongBao2.Text = "";
            }
            ///
            if (entity.ThanhToan1)
            {
                chkThanhToan1.Checked = true;
                dateThanhToan1.Value = entity.Ngay1.Value;
                txtSoTien1.Text = entity.SoTien1.Value.ToString();
                txtSoPhieu1.Text = entity.SoPhieu1;
            }
            else
            {
                chkThanhToan1.Checked = false;
                dateThanhToan1.Value = DateTime.Now;
                txtSoTien1.Text = "";
                txtSoPhieu1.Text = "";
            }
            ///
            if (entity.ThanhToan2)
            {
                chkThanhToan2.Checked = true;
                dateThanhToan2.Value = entity.Ngay2.Value;
                txtSoTien2.Text = entity.SoTien2.Value.ToString();
                txtSoPhieu2.Text = entity.SoPhieu2;
            }
            else
            {
                chkThanhToan2.Checked = false;
                dateThanhToan2.Value = DateTime.Now;
                txtSoTien2.Text = "";
                txtSoPhieu2.Text = "";
            }
            ///
            if (entity.ThanhToan3)
            {
                chkThanhToan3.Checked = true;
                dateThanhToan3.Value = entity.Ngay3.Value;
                txtSoTien3.Text = entity.SoTien3.Value.ToString();
                txtSoPhieu3.Text = entity.SoPhieu3;
            }
            else
            {
                chkThanhToan3.Checked = false;
                dateThanhToan3.Value = DateTime.Now;
                txtSoTien3.Text = "";
                txtSoPhieu3.Text = "";
            }

            dgvHinh.Rows.Clear();
            foreach (GianLan_ChiTiet_Hinh item in entity.GianLan_ChiTiet_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
            }
        }

        public void Clear()
        {
            chkXepDon.Checked = false;
            ///
            txtMaDonCu.Text = "";
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            dateKTXM.Value = DateTime.Now;
            txtNoiDungViPham.Text = "";
            txtTienDHN.Text = "";
            txtTinhTrang.Text = "";
            txtNhanVien.Text = "";
            chkToTrinh1.Checked = false;
            chkToTrinh2.Checked = false;
            chkThanhToan1.Checked = false;
            chkThanhToan2.Checked = false;
            chkThanhToan3.Checked = false;
            ///
            _dontu_ChiTiet = null;
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _gianlan = null;
            _file1 = null;
            _file2 = null;
            _fileBB = null;

            dgvHinh.Rows.Clear();

            txtMaDonMoi.Focus();
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
                        _gianlan = _cGianLan.get_ChiTiet("TXL", decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                        if (_gianlan!=null)
                        {
                            LoadGianLan(_gianlan);
                        }
                        else
                        {
                            _dontxl = _cDonTXL.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            txtMaDonCu.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");

                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            if (_hoadon != null)
                            {
                                LoadTTKH(_hoadon);
                            }
                            else
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            _gianlan = _cGianLan.get_ChiTiet("TBC", decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            if (_gianlan!=null)
                            {
                                LoadGianLan(_gianlan);
                            }
                            else
                            {
                                _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                                txtMaDonCu.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");

                                _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                                if (_hoadon != null)
                                {
                                    LoadTTKH(_hoadon);
                                }
                                else
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                        if (_cDonKH.CheckExist(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", ""))) == true)
                        {
                            _gianlan = _cGianLan.get_ChiTiet("TKH", decimal.Parse(txtMaDonCu.Text.Trim().Substring(3).Replace("-", "")));
                            if (_gianlan!=null)
                            {
                                LoadGianLan(_gianlan);
                            }
                            else
                            {
                                _dontkh = _cDonKH.Get(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));
                                txtMaDonCu.Text = "TKH" + _dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");

                                _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
                                if (_hoadon != null)
                                {
                                    LoadTTKH(_hoadon);
                                }
                                else
                                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count() == 1)
                        txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString();
                    else
                        txtMaDonMoi.Text = _dontu_ChiTiet.MaDon.Value.ToString() + "." + _dontu_ChiTiet.STT.Value.ToString();

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
                    GianLan_ChiTiet entity = new GianLan_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cGianLan.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            GianLan gl = new GianLan();
                            gl.MaDonMoi = _dontu_ChiTiet.MaDon.Value;
                            _cGianLan.Them(gl);
                        }
                        if (_cGianLan.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim()) == true)
                        {
                            MessageBox.Show("Đơn này đã lập Gian Lận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        entity.MaGL = _cGianLan.get(_dontu_ChiTiet.MaDon.Value).MaGL;
                        entity.STT = _dontu_ChiTiet.STT.Value;
                    }
                    else
                        if (_dontkh != null)
                        {
                            if (_cGianLan.checkExist("TKH", _dontkh.MaDon) == false)
                            {
                                GianLan gl = new GianLan();
                                gl.MaDon = _dontkh.MaDon;
                                _cGianLan.Them(gl);
                            }
                            if (_cGianLan.checkExist_ChiTiet("TKH", _dontkh.MaDon, txtDanhBo.Text.Trim()) == true)
                            {
                                MessageBox.Show("Đơn này đã lập Gian Lận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            entity.MaGL = _cGianLan.get("TKH", _dontkh.MaDon).MaGL;
                        }
                        else
                            if (_dontxl != null)
                            {
                                if (_cGianLan.checkExist("TXL", _dontxl.MaDon) == false)
                                {
                                    GianLan gl = new GianLan();
                                    gl.MaDonTXL = _dontxl.MaDon;
                                    _cGianLan.Them(gl);
                                }
                                if (_cGianLan.checkExist_ChiTiet("TXL", _dontxl.MaDon, txtDanhBo.Text.Trim()) == true)
                                {
                                    MessageBox.Show("Đơn này đã lập Gian Lận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                entity.MaGL = _cGianLan.get("TXL", _dontxl.MaDon).MaGL;
                            }
                            else
                                if (_dontbc != null)
                                {
                                    if (_cGianLan.checkExist("TBC", _dontbc.MaDon) == false)
                                    {
                                        GianLan gl = new GianLan();
                                        gl.MaDonTBC = _dontbc.MaDon;
                                        _cGianLan.Them(gl);
                                    }
                                    if (_cGianLan.checkExist_ChiTiet("TBC", _dontbc.MaDon, txtDanhBo.Text.Trim()) == true)
                                    {
                                        MessageBox.Show("Đơn này đã lập Gian Lận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    entity.MaGL = _cGianLan.get("TBC", _dontxl.MaDon).MaGL;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                    entity.XepDon = chkXepDon.Checked;
                    entity.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    entity.HoTen = txtHoTen.Text.Trim();
                    entity.DiaChi = txtDiaChi.Text.Trim();

                    if (_hoadon != null)
                    {
                        entity.Dot = _hoadon.DOT.ToString();
                        entity.Ky = _hoadon.KY.ToString();
                        entity.Nam = _hoadon.NAM.ToString();
                        entity.Phuong = _hoadon.Phuong;
                        entity.Quan = _hoadon.Quan;
                    }

                    entity.NgayKTXM = dateKTXM.Value;
                    entity.NoiDungViPham = txtNoiDungViPham.Text.Trim();
                    if (!string.IsNullOrEmpty(txtTienDHN.Text.Trim()))
                        entity.TienDHN = int.Parse(txtTienDHN.Text.Trim());
                    entity.TinhTrang = txtTinhTrang.Text.Trim();
                    entity.NhanVien = txtNhanVien.Text.Trim();

                    if (_fileBB != null)
                    {
                        entity.FileBienBan = _fileBB;
                    }

                    if (chkToTrinh1.Checked)
                    {
                        entity.ToTrinh1 = true;
                        entity.TieuThu1 = int.Parse(txtTieuThu1.Text.Trim());
                        entity.GiaBan1 = int.Parse(txtGiaBan1.Text.Trim());
                        if (_file1 != null)
                        {
                            entity.File1 = _file1;
                        }
                    }
                    ///
                    if (chkToTrinh2.Checked)
                    {
                        entity.ToTrinh2 = true;
                        entity.TieuThu2 = int.Parse(txtTieuThu2.Text.Trim());
                        entity.GiaBan2 = int.Parse(txtGiaBan2.Text.Trim());
                        if (_file2 != null)
                        {
                            entity.File2 = _file2;
                        }
                    }
                    ///
                    if (chkThanhToan1.Checked)
                    {
                        entity.ThanhToan1 = true;
                        entity.Ngay1 = dateThanhToan1.Value;
                        entity.SoTien1 = int.Parse(txtSoTien1.Text.Trim().Replace(".", ""));
                    }
                    ///
                    if (chkThanhToan2.Checked)
                    {
                        entity.ThanhToan2 = true;
                        entity.Ngay2 = dateThanhToan2.Value;
                        entity.SoTien2 = int.Parse(txtSoTien2.Text.Trim().Replace(".", ""));
                    }
                    ///
                    if (chkThanhToan3.Checked)
                    {
                        entity.ThanhToan3 = true;
                        entity.Ngay3 = dateThanhToan3.Value;
                        entity.SoTien3 = int.Parse(txtSoTien3.Text.Trim().Replace(".", ""));
                    }

                    using (TransactionScope scope = new TransactionScope())
                    if (_cGianLan.Them_ChiTiet(entity))
                    {
                        foreach (DataGridViewRow item in dgvHinh.Rows)
                        {
                            GianLan_ChiTiet_Hinh en = new GianLan_ChiTiet_Hinh();
                            en.IDGianLan_ChiTiet = entity.MaCTGL;
                            en.Name = item.Cells["Name_Hinh"].Value.ToString();
                            en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                            _cGianLan.Them_Hinh(en);
                        }
                        if (_dontu_ChiTiet != null)
                        {
                            if (_cDonTu.Them_LichSu(entity.CreateDate.Value, "GianLan", "Đã Lập Gian Lận, " + entity.NoiDungViPham, (int)entity.MaCTGL, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value) == true)
                                scope.Complete();
                        }
                        else
                            scope.Complete();
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
                    if (_gianlan != null)
                    {
                        _gianlan.XepDon = chkXepDon.Checked;
                        _gianlan.NgayKTXM = dateKTXM.Value;
                        _gianlan.NoiDungViPham = txtNoiDungViPham.Text.Trim();
                        if (!string.IsNullOrEmpty(txtTienDHN.Text.Trim()))
                            _gianlan.TienDHN = int.Parse(txtTienDHN.Text.Trim());
                        _gianlan.TinhTrang = txtTinhTrang.Text.Trim();
                        _gianlan.NhanVien = txtNhanVien.Text.Trim();

                        if (_fileBB != null)
                        {
                            _gianlan.FileBienBan = _fileBB;
                        }

                        if (chkToTrinh1.Checked)
                        {
                            _gianlan.ToTrinh1 = true;
                            _gianlan.TieuThu1 = int.Parse(txtTieuThu1.Text.Trim());
                            _gianlan.GiaBan1 = int.Parse(txtGiaBan1.Text.Trim());
                            if (_file1 != null)
                            {
                                _gianlan.File1 = _file1;
                            }
                        }
                        else
                        {
                            _gianlan.ToTrinh1 = false;
                            _gianlan.TieuThu1 = null;
                            _gianlan.GiaBan1 = null;
                            _gianlan.File1 = null;
                        }
                        ///
                        if (chkToTrinh2.Checked)
                        {
                            _gianlan.ToTrinh2 = true;
                            _gianlan.TieuThu2 = int.Parse(txtTieuThu2.Text.Trim());
                            _gianlan.GiaBan2 = int.Parse(txtGiaBan2.Text.Trim());
                            if (_file2 != null)
                            {
                                _gianlan.File2 = _file2;
                            }
                        }
                        else
                        {
                            _gianlan.ToTrinh2 = false;
                            _gianlan.TieuThu2 = null;
                            _gianlan.GiaBan2 = null;
                            _gianlan.File2 = null;
                        }
                        ///
                        if (chkThanhToan1.Checked)
                        {
                            _gianlan.ThanhToan1 = true;
                            _gianlan.Ngay1 = dateThanhToan1.Value;
                            _gianlan.SoTien1 = int.Parse(txtSoTien1.Text.Trim().Replace(".", ""));
                        }
                        else
                        {
                            _gianlan.ThanhToan1 = false;
                            _gianlan.Ngay1 = null;
                            _gianlan.SoTien1 = null;
                        }
                        ///
                        if (chkThanhToan2.Checked)
                        {
                            _gianlan.ThanhToan2 = true;
                            _gianlan.Ngay2 = dateThanhToan2.Value;
                            _gianlan.SoTien2 = int.Parse(txtSoTien2.Text.Trim().Replace(".", ""));
                        }
                        else
                        {
                            _gianlan.ThanhToan2 = false;
                            _gianlan.Ngay2 = null;
                            _gianlan.SoTien2 = null;
                        }
                        ///
                        if (chkThanhToan3.Checked)
                        {
                            _gianlan.ThanhToan3 = true;
                            _gianlan.Ngay3 = dateThanhToan3.Value;
                            _gianlan.SoTien3 = int.Parse(txtSoTien3.Text.Trim().Replace(".", ""));
                        }
                        else
                        {
                            _gianlan.ThanhToan3 = false;
                            _gianlan.Ngay3 = null;
                            _gianlan.SoTien3 = null;
                        }

                        if (_cGianLan.Sua_ChiTiet(_gianlan))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear(); 
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
                    if (_gianlan != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cGianLan.Xoa_ChiTiet(_gianlan))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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

        private void chkToTrinh1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToTrinh1.Checked)
                gbToTrinh1.Enabled = true;
            else
                gbToTrinh1.Enabled = false;
        }

        private void chkToTrinh2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToTrinh2.Checked)
                gbToTrinh2.Enabled = true;
            else
                gbToTrinh2.Enabled = false;
        }

        private void chkThanhToan1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThanhToan1.Checked)
                gbThanhToan1.Enabled = true;
            else
                gbThanhToan1.Enabled = false;
        }

        private void chkThanhToan2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThanhToan2.Checked)
                gbThanhToan2.Enabled = true;
            else
                gbThanhToan2.Enabled = false;
        }

        private void chkThanhToan3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThanhToan3.Checked)
                gbThanhToan3.Enabled = true;
            else
                gbThanhToan3.Enabled = false;
        }

        private void txtTieuThu1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTieuThu1.Text.Trim()) && !string.IsNullOrEmpty(txtGiaBan1.Text.Trim()))
            {
                txtThanhTien1.Text = ((int.Parse(txtTieuThu1.Text.Trim()) * int.Parse(txtGiaBan1.Text.Trim())) * 1.15).ToString();
            }
            else
                txtThanhTien1.Text = "";
        }

        private void txtGiaBan1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTieuThu1.Text.Trim()) && !string.IsNullOrEmpty(txtGiaBan1.Text.Trim()))
            {
                txtThanhTien1.Text = ((int.Parse(txtTieuThu1.Text.Trim()) * int.Parse(txtGiaBan1.Text.Trim())) * 1.15).ToString();
            }
            else
                txtThanhTien1.Text = "";
        }

        private void txtTieuThu2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTieuThu2.Text.Trim()) && !string.IsNullOrEmpty(txtGiaBan2.Text.Trim()))
            {
                txtThanhTien2.Text = ((int.Parse(txtTieuThu2.Text.Trim()) * int.Parse(txtGiaBan2.Text.Trim())) * 1.15).ToString();
            }
            else
                txtThanhTien2.Text = "";
        }

        private void txtGiaBan2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTieuThu2.Text.Trim()) && !string.IsNullOrEmpty(txtGiaBan2.Text.Trim()))
            {
                txtThanhTien2.Text = ((int.Parse(txtTieuThu2.Text.Trim()) * int.Parse(txtGiaBan2.Text.Trim())) * 1.15).ToString();
            }
            else
                txtThanhTien2.Text = "";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Danh Bộ":
                    dgvGianLan.DataSource = _cGianLan.getDS_ChiTiet(txtNoiDungTimKiem.Text.Trim().Replace(" ",""));
                    break;
                case "Ngày":
                    dgvGianLan.DataSource = _cGianLan.getDS_ChiTiet(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvGianLan.Rows)
            {
                DataRow dr = dsBaoCao.Tables["GianLan"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");

                GianLan_ChiTiet entity = _cGianLan.get_ChiTiet(int.Parse(item.Cells["ID"].Value.ToString()));

                if (entity.GianLan.MaDonMoi != null)
                {
                    if (entity.GianLan.DonTu.DonTu_ChiTiets.Count == 1)
                        dr["MaDon"] = entity.GianLan.MaDonMoi.Value.ToString();
                    else
                        dr["MaDon"] = entity.GianLan.MaDonMoi.Value.ToString()+"."+entity.STT.Value.ToString();
                }
                else
                if (entity.GianLan.MaDon != null)
                    dr["MaDon"] = "TKH" + entity.GianLan.MaDon.Value.ToString().Insert(entity.GianLan.MaDon.Value.ToString().Length - 2, "-");
                else
                    if (entity.GianLan.MaDonTXL != null)
                        dr["MaDon"] = "TKH" + entity.GianLan.MaDonTXL.Value.ToString().Insert(entity.GianLan.MaDonTXL.Value.ToString().Length - 2, "-");
                    else
                        if (entity.GianLan.MaDonTBC != null)
                            dr["MaDon"] = "TKH" + entity.GianLan.MaDonTBC.Value.ToString().Insert(entity.GianLan.MaDonTBC.Value.ToString().Length - 2, "-");
                dr["ID"] = entity.MaCTGL.ToString().Insert(entity.MaCTGL.ToString().Length-2,"-");
                if (entity.NgayKTXM != null)
                    dr["NgayKTXM"] = entity.NgayKTXM.Value.ToString("dd/MM/yyyy");
                if (entity.DanhBo!="")
                dr["DanhBo"] = entity.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = entity.HoTen;
                dr["DiaChi"] = entity.DiaChi;
                dr["NoiDungViPham"] = entity.NoiDungViPham;
                if (entity.TieuThu1 != null)
                {
                    dr["TieuThu1"] = entity.TieuThu1;
                    dr["ThanhTien1"] = entity.TieuThu1 * entity.GiaBan1 * 1.15;
                }
                if (entity.TieuThu2 != null)
                {
                    dr["TieuThu2"] = entity.TieuThu2;
                    dr["ThanhTien2"] = entity.TieuThu2 * entity.GiaBan2 * 1.15;
                }
                if (entity.Ngay1 != null)
                {
                    dr["Ngay1"] = entity.Ngay1.Value.ToString("dd/MM/yyyy");
                    dr["SoTien1"] = entity.SoTien1;
                }
                if (entity.Ngay2 != null)
                {
                    dr["Ngay2"] = entity.Ngay2.Value.ToString("dd/MM/yyyy");
                    dr["SoTien2"] = entity.SoTien2;
                }
                if (entity.Ngay3 != null)
                {
                    dr["Ngay3"] = entity.Ngay3.Value.ToString("dd/MM/yyyy");
                    dr["SoTien3"] = entity.SoTien3;
                }

                dsBaoCao.Tables["GianLan"].Rows.Add(dr);
            }
            rptDSGianLan rpt = new rptDSGianLan();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        byte[] _file1 = null;
        private void btnChonFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.pdf)|*.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(dialog.FileName);
                _file1 = new byte[fs.Length];
                fs.Read(_file1, 0, (int)fs.Length);
            }
        }

        byte[] _file2 = null;
        private void btnChonFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.pdf)|*.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(dialog.FileName);
                _file2 = new byte[fs.Length];
                fs.Read(_file2, 0, (int)fs.Length);
            }
        }

        private void btnXemFile1_Click(object sender, EventArgs e)
        {
            if (_gianlan != null && _gianlan.File1 != null)
            {
                frmPDFViewer frm = new frmPDFViewer(_gianlan.File1.ToArray());
                frm.ShowDialog();
            }
        }

        private void btnXemFile2_Click(object sender, EventArgs e)
        {
            if (_gianlan != null && _gianlan.File2 != null)
            {
                frmPDFViewer frm = new frmPDFViewer(_gianlan.File2.ToArray());
                frm.ShowDialog();
            }
        }

        byte[] _fileBB = null;
        private void btnChonBB_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.pdf)|*.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(dialog.FileName);
                _fileBB = new byte[fs.Length];
                fs.Read(_fileBB, 0, (int)fs.Length);
            }
        }

        private void btnXemBB_Click(object sender, EventArgs e)
        {
            if (_gianlan != null && _gianlan.FileBienBan != null)
            {
                frmPDFViewer frm = new frmPDFViewer(_gianlan.FileBienBan.ToArray());
                frm.ShowDialog();
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Danh Bộ":
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
            dgvGianLan.DataSource = null;
        }

        private void dgvGianLan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvGianLan.Rows[e.RowIndex].Selected = true;
                _gianlan = _cGianLan.get_ChiTiet(int.Parse(dgvGianLan.SelectedRows[0].Cells["ID"].Value.ToString()));
                LoadGianLan(_gianlan);
            }
            catch
            {

            }
        }

        private void dgvGianLan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvGianLan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvGianLan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvGianLan.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null )
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        private void txtMaCTGL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaCTGL.Text.Trim() != "")
            {
                string MaCTGL = txtMaCTGL.Text.Trim().Replace("-", "");
                Clear();
                txtMaCTGL.Text = MaCTGL;
                _gianlan = _cGianLan.get_ChiTiet(int.Parse(txtMaCTGL.Text.Trim()));
                if (_gianlan != null)
                    LoadGianLan(_gianlan);
                else
                    MessageBox.Show("Mã này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmGianLan_KeyUp(object sender, KeyEventArgs e)
        {
            if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            {
                frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet);
                frm.ShowDialog();
            }
        }

        //add file
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //ListViewItem item = new ListViewItem();
                    //item.ImageKey = "file";
                    //item.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    //item.SubItems.Add(Convert.ToBase64String(bytes));
                    //lstVFile.Items.Add(item);
                    byte[] bytes = System.IO.File.ReadAllBytes(dialog.FileName);
                    if (_gianlan == null)
                    {
                        var index = dgvHinh.Rows.Add();
                        dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                    }
                    else
                    {
                        if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                        {
                            GianLan_ChiTiet_Hinh en = new GianLan_ChiTiet_Hinh();
                            en.IDGianLan_ChiTiet = _gianlan.MaCTGL;
                            en.Name = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            en.Hinh = bytes;
                            if (_cGianLan.Them_Hinh(en) == true)
                            {
                                _cGianLan.Refresh();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var index = dgvHinh.Rows.Add();
                                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = en.Name;
                                dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                            }
                        }
                        else
                            MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvHinh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvHinh.CurrentCell = dgvHinh.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvHinh_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(dgvHinh, new Point(e.X, e.Y));
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cGianLan.LoadImageView(Convert.FromBase64String(dgvHinh.CurrentRow.Cells["Bytes_Hinh"].Value.ToString()));
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_gianlan == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_cGianLan.Xoa_Hinh(_cGianLan.get_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
                                {
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                                }
                                else
                                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        

    }
}
