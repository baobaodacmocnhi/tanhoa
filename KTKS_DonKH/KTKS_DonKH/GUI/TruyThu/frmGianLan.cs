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
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao.TruyThu;

namespace KTKS_DonKH.GUI.TruyThu
{
    public partial class frmGianLan : Form
    {
        string _mnu = "mnuGianLanTienNuoc";
        DonKH _dontkh = null;
        DonTXL _dontxl = null;
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CGianLan _cGianLan = new CGianLan();
        GianLan _gianlan = null;
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
                _gianlan = _cGianLan.Get(int.Parse(dgvGianLan.SelectedRows[0].Cells["ID"].Value.ToString()));
                LoadGianLan(_gianlan);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
        }

        public void LoadGianLan(GianLan entity)
        {
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
            }
            else
            {
                chkThanhToan1.Checked = false;
                dateThanhToan1.Value = DateTime.Now;
                txtSoTien1.Text = "";
            }
            ///
            if (entity.ThanhToan1)
            {
                chkThanhToan2.Checked = true;
                dateThanhToan2.Value = entity.Ngay2.Value;
                txtSoTien2.Text = entity.SoTien2.Value.ToString();
            }
            else
            {
                chkThanhToan2.Checked = false;
                dateThanhToan2.Value = DateTime.Now;
                txtSoTien2.Text = "";
            }
            ///
            if (entity.ThanhToan3)
            {
                chkThanhToan3.Checked = true;
                dateThanhToan3.Value = entity.Ngay3.Value;
                txtSoTien3.Text = entity.SoTien3.Value.ToString();
            }
            else
            {
                chkThanhToan3.Checked = false;
                dateThanhToan3.Value = DateTime.Now;
                txtSoTien3.Text = "";
            }
        }

        public void Clear()
        {
            txtMaDon.Text = "";
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
            _dontkh = null;
            _dontxl = null;
            _dontbc = null;
            _hoadon = null;
            _gianlan = null;
            _file1 = null;
            _file2 = null;
            _fileBB = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                string MaDon = txtMaDon.Text.Trim();
                Clear();
                txtMaDon.Text = MaDon;
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.CheckExist(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) ==true)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            LoadTTKH(_hoadon);
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTBC.CheckExist(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) ==true)
                    {
                        _dontbc = _cDonTBC.Get(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TBC" + _dontbc.MaDon.ToString().Insert(_dontbc.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_dontbc.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontbc.DanhBo);
                            LoadTTKH(_hoadon);
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.CheckExist(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) ==true)
                    {
                        _dontkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        txtMaDon.Text = "TKH"+_dontkh.MaDon.ToString().Insert(_dontkh.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_dontkh.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontkh.DanhBo);
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
                    GianLan entity = new GianLan();
                    if (_dontxl != null)
                    {
                        if (_cGianLan.CheckExist("TXL", _dontxl.MaDon))
                        {
                            MessageBox.Show("Đơn này đã lập Gian Lận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        entity.MaDonTXL = _dontxl.MaDon;
                    }
                    else
                        if (_dontbc != null)
                        {
                            if (_cGianLan.CheckExist("TBC", _dontbc.MaDon))
                            {
                                MessageBox.Show("Đơn này đã lập Gian Lận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            entity.MaDonTBC = _dontbc.MaDon;
                        }
                        else
                            if (_dontkh != null)
                            {
                                if (_cGianLan.CheckExist("TKH", _dontkh.MaDon))
                                {
                                    MessageBox.Show("Đơn này đã lập Gian Lận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                entity.MaDon = _dontkh.MaDon;
                            }
                            else
                            {
                                MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                    entity.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    entity.HoTen = txtHoTen.Text.Trim();
                    entity.DiaChi = txtDiaChi.Text.Trim();
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
                        entity.SoTien1 = int.Parse(txtSoTien1.Text.Trim());
                    }
                    ///
                    if (chkThanhToan2.Checked)
                    {
                        entity.ThanhToan2 = true;
                        entity.Ngay2 = dateThanhToan2.Value;
                        entity.SoTien2 = int.Parse(txtSoTien2.Text.Trim());
                    }
                    ///
                    if (chkThanhToan3.Checked)
                    {
                        entity.ThanhToan3 = true;
                        entity.Ngay3 = dateThanhToan3.Value;
                        entity.SoTien3 = int.Parse(txtSoTien3.Text.Trim());
                    }

                    if (_cGianLan.Them(entity))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            _gianlan.SoTien1 = int.Parse(txtSoTien1.Text.Trim());
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
                            _gianlan.SoTien2 = int.Parse(txtSoTien2.Text.Trim());
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
                            _gianlan.SoTien3 = int.Parse(txtSoTien3.Text.Trim());
                        }
                        else
                        {
                            _gianlan.ThanhToan3 = false;
                            _gianlan.Ngay3 = null;
                            _gianlan.SoTien3 = null;
                        }

                        if (_cGianLan.Sua(_gianlan))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (_cGianLan.Xoa(_gianlan))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaDon.Focus();
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
                    dgvGianLan.DataSource = _cGianLan.GetDS(txtNoiDungTimKiem.Text.Trim().Replace(" ",""));
                    break;
                case "Ngày":
                    dgvGianLan.DataSource = _cGianLan.GetDS(dateTu.Value, dateDen.Value);
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

                GianLan entity = _cGianLan.Get(int.Parse(item.Cells["ID"].Value.ToString()));

                if (entity.MaDon != null)
                    dr["MaDon"] = "TKH" + entity.MaDon.Value.ToString().Insert(entity.MaDon.Value.ToString().Length - 2, "-");
                else
                    if (entity.MaDonTXL != null)
                        dr["MaDon"] = "TKH" + entity.MaDonTXL.Value.ToString().Insert(entity.MaDonTXL.Value.ToString().Length - 2, "-");
                    else
                        if (entity.MaDonTBC != null)
                            dr["MaDon"] = "TKH" + entity.MaDonTBC.Value.ToString().Insert(entity.MaDonTBC.Value.ToString().Length - 2, "-");
                if (entity.NgayKTXM != null)
                    dr["NgayKTXM"] = entity.NgayKTXM.Value.ToString("dd/MM/yyyy");
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
                _gianlan = _cGianLan.Get(int.Parse(dgvGianLan.SelectedRows[0].Cells["ID"].Value.ToString()));
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
            if (dgvGianLan.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvGianLan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGianLan.Columns[e.ColumnIndex].Name == "GiaQuyet")
            {
                _gianlan = _cGianLan.Get(int.Parse(dgvGianLan.SelectedRows[0].Cells["ID"].Value.ToString()));
                _gianlan.GiaiQuyet = bool.Parse(dgvGianLan.SelectedRows[0].Cells["GiaiQuyet"].Value.ToString());
                _cGianLan.Sua(_gianlan);
            }
        }

        

    }
}
