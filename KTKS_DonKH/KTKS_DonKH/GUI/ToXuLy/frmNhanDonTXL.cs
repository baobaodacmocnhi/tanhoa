﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmNhanDonTXL : Form
    {
        string _mnu = "mnuNhanDonTXL";
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();
        HOADON _hoadon = null;
        CDonTXL _cDonTXL = new CDonTXL();
        DonTXL _dontxl = null;
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();
        DataSet _dsNoiChuyen = new DataSet("NoiChuyen");
        bool _flagFirst = false;
        decimal _MaDon = 0;

        public frmNhanDonTXL()
        {
            InitializeComponent();
        }

        public frmNhanDonTXL(decimal MaDon)
        {
            _MaDon = MaDon;
            InitializeComponent();
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
            txtMSThue.Text = hoadon.MST;
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";
            txtTongSoDanhBo.Text = "1";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtMSThue.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDienThoai.Text = "";
            _hoadon = null;
            _dontxl = null;
        }

        private void frmNhanDonTXL_Load(object sender, EventArgs e)
        {
            dgvLichSuDon.AutoGenerateColumns = false;
            dgvLichSuDonTu.AutoGenerateColumns = false;

            cmbLD.DataSource = _cLoaiDonTXL.GetDS();
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS();
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.SelectedIndex = -1;

            _flagFirst = true;

            DataTable dt = new DataTable();
            dt = _cTaiKhoan.GetDS_KTXM("TXL");
            dt.TableName = "1";//Kiểm Tra Xác Minh
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TKH");
            dt.TableName = "2";//Tổ Khách Hàng
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TXL");
            dt.TableName = "3";//Tổ Xử Lý
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TBC");
            dt.TableName = "4";//Tổ Bấm Chì
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TVP");
            dt.TableName = "5";//Tổ Văn Phòng
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cPhongBanDoi.GetDS();
            dt.TableName = "6";//Phòng Ban Đội Khác
            _dsNoiChuyen.Tables.Add(dt);

            if (_MaDon != 0)
            {
                txtMaDon.Text = _MaDon.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaDon_KeyPress(sender, arg);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cThuTien.GetMoiNhat(txtDanhBo.Text.Trim()) != null)
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    LoadTTKH(_hoadon);
                    dgvLichSuDon.DataSource = _cDonTXL.LoadDSDonTXLByDanhBo(txtDanhBo.Text.Trim());
                    if (dgvLichSuDon.RowCount > 0)
                        dgvLichSuDon.Sort(dgvLichSuDon.Columns["CreateDate"], ListSortDirection.Descending);
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (cmbLD.SelectedIndex != -1)
                    {
                        DonTXL dontxl = new DonTXL();
                        dontxl.MaDon = _cDonTXL.getMaxNextID();
                        dontxl.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        dontxl.SoCongVan = txtSoCongVan.Text.Trim();
                        dontxl.TongSoDanhBo = int.Parse(txtTongSoDanhBo.Text.Trim());
                        dontxl.NoiDung = txtNoiDung.Text.Trim();

                        dontxl.DanhBo = txtDanhBo.Text.Trim();
                        dontxl.HopDong = txtHopDong.Text.Trim();
                        dontxl.HoTen = txtHoTen.Text.Trim();
                        dontxl.DiaChi = txtDiaChi.Text.Trim();
                        dontxl.DienThoai = txtDienThoai.Text.Trim();
                        dontxl.MSThue = txtMSThue.Text.Trim();
                        dontxl.GiaBieu = txtGiaBieu.Text.Trim();
                        dontxl.DinhMuc = txtDinhMuc.Text.Trim();
                        if (_hoadon != null)
                        {
                            dontxl.Dot = _hoadon.DOT.ToString();
                            dontxl.Ky = _hoadon.KY.ToString();
                            dontxl.Nam = _hoadon.NAM.ToString();
                            dontxl.MLT = _hoadon.MALOTRINH;
                        }

                        _cDonTXL.beginTransaction();
                        if (_cDonTXL.ThemDonTXL(dontxl))
                        {
                            bool flag = false;//ghi nhận có chọn checkcombobox
                            if (cmbNoiChuyen.SelectedIndex != -1)
                                if (chkcmbNoiNhan.Properties.Items.Count > 0)
                                {
                                    for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                        if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                        {
                                            if (cmbNoiChuyen.SelectedValue.ToString() == "1")///KTXM
                                            {
                                                LichSuChuyenKT lichsuchuyenkt = new LichSuChuyenKT();
                                                lichsuchuyenkt.NgayChuyen = dateChuyen.Value;
                                                lichsuchuyenkt.NguoiDi = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                lichsuchuyenkt.GhiChuChuyen = txtGhiChu.Text.Trim();
                                                lichsuchuyenkt.MaDonTXL = dontxl.MaDon;
                                                _cLichSuDonTu.Them(lichsuchuyenkt);
                                            }
                                            LichSuDonTu entity = new LichSuDonTu();
                                            entity.NgayChuyen = dateChuyen.Value;
                                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                            entity.NoiChuyen = cmbNoiChuyen.Text;
                                            entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                            entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                            entity.GhiChu = txtGhiChu.Text.Trim();
                                            entity.MaDonTXL = dontxl.MaDon;
                                            _cLichSuDonTu.Them(entity);
                                            flag = true;
                                            chkcmbNoiNhan.Properties.Items[i].CheckState = CheckState.Unchecked;
                                        }
                                    if (flag == false)
                                    {
                                        LichSuDonTu entity = new LichSuDonTu();
                                        entity.NgayChuyen = dateChuyen.Value;
                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                        //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                        entity.GhiChu = txtGhiChu.Text.Trim();
                                        entity.MaDonTXL = dontxl.MaDon;
                                        _cLichSuDonTu.Them(entity);
                                    }
                                }
                                else
                                {
                                    LichSuDonTu entity = new LichSuDonTu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.GhiChu = txtGhiChu.Text.Trim();
                                    entity.MaDonTXL = dontxl.MaDon;
                                    _cLichSuDonTu.Them(entity);
                                }

                            _cDonTXL.commitTransaction();
                            MessageBox.Show("Thêm Thành công/n Mã Đơn: TXL" + dontxl.MaDon.ToString().Insert(dontxl.MaDon.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _cDonTXL.rollback();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLD.SelectedIndex != -1)
            {
                //txtMaDon.Text = "TXL" + _cDonTXL.getMaxNextID().ToString().Insert(_cDonTXL.getMaxNextID().ToString().Length - 2, "-");
                txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("TXL", "").Replace("txl", "").Replace("-", ""))) != null)
                {
                    _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("TXL", "").Replace("txl", "").Replace("-", "")));

                    cmbLD.SelectedValue = _dontxl.MaLD.Value;
                    txtSoCongVan.Text = _dontxl.SoCongVan;
                    if (_dontxl.TongSoDanhBo != null)
                        txtTongSoDanhBo.Text = _dontxl.TongSoDanhBo.Value.ToString();
                    txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                    txtNgayNhan.Text = _dontxl.CreateDate.Value.ToString("dd/MM/yyyy");
                    txtNoiDung.Text = _dontxl.NoiDung;
                    ///
                    txtDanhBo.Text = _dontxl.DanhBo;
                    txtHopDong.Text = _dontxl.HopDong;
                    txtDienThoai.Text = _dontxl.DienThoai;
                    txtHoTen.Text = _dontxl.HoTen;
                    txtDiaChi.Text = _dontxl.DiaChi;
                    txtMSThue.Text = _dontxl.MSThue;
                    txtGiaBieu.Text = _dontxl.GiaBieu;
                    txtDinhMuc.Text = _dontxl.DinhMuc;
                    ///
                    dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TXL", _dontxl.MaDon);
                    cmbNoiChuyen.SelectedIndex = -1;
                    dateChuyen.Value = DateTime.Now;
                    txtGhiChu.Text = "";
                }
                else
                {
                    MessageBox.Show("Mã Đơn TXL này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_dontxl != null)
                    {
                        //bool flagSuaChuyenKT = false;

                        _dontxl.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        _dontxl.SoCongVan = txtSoCongVan.Text.Trim();
                        _dontxl.TongSoDanhBo = int.Parse(txtTongSoDanhBo.Text.Trim());
                        if (_hoadon != null && _dontxl.DanhBo != txtDanhBo.Text.Trim())
                        {
                            _dontxl.Dot = _hoadon.DOT.ToString();
                            _dontxl.Ky = _hoadon.KY.ToString();
                            _dontxl.Nam = _hoadon.NAM.ToString();
                            _dontxl.MLT = _hoadon.MALOTRINH;
                        }
                        _dontxl.DanhBo = txtDanhBo.Text.Trim();
                        _dontxl.HopDong = txtHopDong.Text.Trim();
                        _dontxl.HoTen = txtHoTen.Text.Trim();
                        _dontxl.DiaChi = txtDiaChi.Text.Trim();
                        _dontxl.DienThoai = txtDienThoai.Text.Trim();
                        _dontxl.MSThue = txtMSThue.Text.Trim();
                        _dontxl.GiaBieu = txtGiaBieu.Text.Trim();
                        _dontxl.DinhMuc = txtDinhMuc.Text.Trim();
                        _dontxl.NoiDung = txtNoiDung.Text.Trim();


                        //if (chkChuyenKT.Checked)
                        //{
                        //    _dontxl.ChuyenKT = true;
                        //    if (_dontxl.NgayChuyenKT != dateChuyenKT.Value || _dontxl.NguoiDi != int.Parse(cmbNguoiDi.SelectedValue.ToString()) || _dontxl.GhiChuChuyenKT != txtGhiChuChuyenKT.Text.Trim())
                        //        flagSuaChuyenKT = true;
                        //    _dontxl.NgayChuyenKT = dateChuyenKT.Value;
                        //    _dontxl.NguoiDi = int.Parse(cmbNguoiDi.SelectedValue.ToString());
                        //    _dontxl.GhiChuChuyenKT = txtGhiChuChuyenKT.Text.Trim();
                        //    _dontxl.TKN = chkTKN.Checked;
                        //    _dontxl.DCG = chkDCG.Checked;
                        //    _dontxl.DCMS = chkDCMS.Checked;
                        //}
                        //else
                        //{
                        //    _dontxl.ChuyenKT = false;
                        //    _dontxl.NgayChuyenKT = null;
                        //    _dontxl.NguoiDi = null;
                        //    _dontxl.GhiChuChuyenKT = null;
                        //    _dontxl.TKN = false;
                        //    _dontxl.DCG = false;
                        //    _dontxl.DCMS = false;
                        //}

                        //if (chkChuyenBanDoiKhac.Checked)
                        //{
                        //    _dontxl.ChuyenBanDoiKhac = true;
                        //    _dontxl.NgayChuyenBanDoiKhac = dateChuyenBanDoiKhac.Value;
                        //    _dontxl.QLDHN = chkQLDHN.Checked;
                        //    _dontxl.TCTB = chkTCTB.Checked;
                        //    _dontxl.GNKDT = chkGNKDT.Checked;
                        //    _dontxl.ToThay = chkToThay.Checked;
                        //    _dontxl.ThuTien = chkThuTien.Checked;
                        //    _dontxl.Khac = chkKhac.Checked;
                        //    _dontxl.GhiChuChuyenBanDoiKhac = txtGhiChuChuyenBanDoiKhac.Text.Trim();

                        //    LichSuDonTu entity = new LichSuDonTu();
                        //    entity.NgayChuyen = _dontxl.NgayChuyenBanDoiKhac;
                        //    entity.NoiChuyen = "Ban Đội Khác";
                        //    entity.NoiDung = _dontxl.GhiChuChuyenBanDoiKhac;
                        //    entity.MaDonTXL = _dontxl.MaDon;
                        //    _cLichSuDonTu.Them(entity);
                        //}
                        //else
                        //{
                        //    _dontxl.ChuyenBanDoiKhac = false;
                        //    _dontxl.NgayChuyenBanDoiKhac = null;
                        //    _dontxl.QLDHN = false;
                        //    _dontxl.TCTB = false;
                        //    _dontxl.GNKDT = false;
                        //    _dontxl.ToThay = false;
                        //    _dontxl.ThuTien = false;
                        //    _dontxl.Khac = false;
                        //    _dontxl.GhiChuChuyenBanDoiKhac = null;
                        //}

                        //if (chkChuyenToKhachHang.Checked)
                        //{
                        //    _dontxl.ChuyenToKhachHang = true;
                        //    _dontxl.NgayChuyenToKhachHang = dateChuyenToKhachHang.Value;
                        //    _dontxl.GhiChuChuyenToKhachHang = txtGhiChuChuyenToKhachHang.Text.Trim();

                        //    LichSuDonTu entity = new LichSuDonTu();
                        //    entity.NgayChuyen = _dontxl.NgayChuyenToKhachHang;
                        //    entity.NoiChuyen = "Tổ Khách Hàng";
                        //    entity.NoiDung = _dontxl.GhiChuChuyenToKhachHang;
                        //    entity.MaDonTXL = _dontxl.MaDon;
                        //    _cLichSuDonTu.Them(entity);
                        //}
                        //else
                        //{
                        //    _dontxl.ChuyenToKhachHang = false;
                        //    _dontxl.NgayChuyenToKhachHang = null;
                        //    _dontxl.GhiChuChuyenToKhachHang = null;
                        //}

                        //if (chkChuyenKhac.Checked)
                        //{
                        //    _dontxl.ChuyenKhac = true;
                        //    _dontxl.NgayChuyenKhac = dateChuyenKhac.Value;
                        //    _dontxl.GhiChuChuyenKhac = txtGhiChuChuyenKhac.Text.Trim();
                        //    _dontxl.ChiBoSung = chkChiBoSung.Checked;
                        //    _dontxl.GiuNguyen = chkGiuNguyen.Checked;
                        //    _dontxl.DieuChinh = chkDieuChinh.Checked;
                        //    _dontxl.TruyThu = chkTruyThu.Checked;

                        //    LichSuDonTu entity = new LichSuDonTu();
                        //    entity.NgayChuyen = _dontxl.NgayChuyenKhac;
                        //    entity.NoiChuyen = "Khác";
                        //    entity.NoiDung = _dontxl.GhiChuChuyenKhac;
                        //    entity.MaDonTXL = _dontxl.MaDon;
                        //    _cLichSuDonTu.Them(entity);
                        //}
                        //else
                        //{
                        //    _dontxl.ChuyenKhac = false;
                        //    _dontxl.NgayChuyenKhac = null;
                        //    _dontxl.GhiChuChuyenKhac = null;
                        //    _dontxl.GiuNguyen = false;
                        //    _dontxl.DieuChinh = false;
                        //    _dontxl.TruyThu = false;
                        //}

                        if (_cDonTXL.SuaDonTXL(_dontxl))
                        {
                            //if (flagSuaChuyenKT)
                            //{
                            //    LichSuChuyenKT lichsuchuyenkt = new LichSuChuyenKT();
                            //    lichsuchuyenkt.NgayChuyen = _dontxl.NgayChuyenKT;
                            //    lichsuchuyenkt.NguoiDi = _dontxl.NguoiDi;
                            //    lichsuchuyenkt.GhiChuChuyen = _dontxl.GhiChuChuyenKT;
                            //    lichsuchuyenkt.MaDonTXL = _dontxl.MaDon;
                            //    _cDonTXL.ThemLichSuChuyenKT(lichsuchuyenkt);
                            //    flagSuaChuyenKT = false;

                            //    LichSuDonTu entity = new LichSuDonTu();
                            //    entity.NgayChuyen = _dontxl.NgayChuyenKT;
                            //    entity.NoiChuyen = "Kiểm Tra Xác Minh";
                            //    entity.ID_NoiNhan = _dontxl.NguoiDi.Value;
                            //    entity.NoiNhan = _cTaiKhoan.getHoTenUserbyID(_dontxl.NguoiDi.Value);
                            //    entity.NoiDung = _dontxl.GhiChuChuyenKT;
                            //    entity.MaDonTXL = _dontxl.MaDon;
                            //    _cLichSuDonTu.Them(entity);
                            //}
                            MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Chưa chọn Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //if (_cDonTXL.XoaLichSuChuyenKT(_cDonTXL.getLichSuChuyenKTbyID(decimal.Parse(dgvLichSuChuyenKT.CurrentRow.Cells["MaLSChuyen"].Value.ToString()))))
                //{
                //    dgvLichSuChuyenKT.DataSource = _cDonTXL.LoadDSLichSuChuyenKTbyMaDonTXL(_dontxl.MaDon);
                //}
                    if (_cLichSuDonTu.Xoa(_cLichSuDonTu.Get(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()))))
                    {
                        dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TXL", _dontxl.MaDon);
                    }
            }
        }

        private void txtTongSoDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnNhapNhieuDB_Click(object sender, EventArgs e)
        {
            frmNhapNhieuDBTXL frm = new frmNhapNhieuDBTXL();
            frm.ShowDialog();
        }

        private void dgvLichSuDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuDon.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = "TXL" + e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void cmbNoiChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirst == true)
            {
                //chkcmbNoiNhan.Properties.Items.Clear();
                if (cmbNoiChuyen.SelectedIndex != -1)
                    switch (cmbNoiChuyen.SelectedValue.ToString())
                    {
                        case "1"://Kiểm Tra Xác Minh
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["1"];
                            //chkcmbNoiNhan.Properties.DataSource = _cTaiKhoan.GetDS_KTXM_TXL();
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "2"://Tổ Khách Hàng
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["2"];
                            //chkcmbNoiNhan.Properties.DataSource = _cTaiKhoan.GetDS_TKH();
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "3"://Tổ Xử Lý
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["3"];
                            //chkcmbNoiNhan.Properties.DataSource = _cTaiKhoan.GetDS_TXL();
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "4"://Tổ Bấm Chì
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["4"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "5"://Tổ Văn Phòng
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["5"];
                            //chkcmbNoiNhan.Properties.DataSource = _cTaiKhoan.GetDS_TVP();
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "6"://Phòng Ban Đội Khác
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["6"];
                            //chkcmbNoiNhan.Properties.DataSource = _cPhongBanDoi.GetDS();
                            chkcmbNoiNhan.Properties.DisplayMember = "Name";
                            chkcmbNoiNhan.Properties.ValueMember = "ID";
                            break;
                        case "9"://Tiến Trình
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["9"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        default:
                            //chkcmbNoiNhan.Properties.DataSource = null;
                            break;
                    }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    bool flag = false;//ghi nhận có chọn checkcombobox
                    if (chkcmbNoiNhan.Properties.Items.Count > 0)
                    {
                        for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                            if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (cmbNoiChuyen.SelectedValue.ToString() == "1")///KTXM
                                {
                                    LichSuChuyenKT lichsuchuyenkt = new LichSuChuyenKT();
                                    lichsuchuyenkt.NgayChuyen = dateChuyen.Value;
                                    lichsuchuyenkt.NguoiDi = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    lichsuchuyenkt.GhiChuChuyen = txtGhiChu.Text.Trim();
                                    lichsuchuyenkt.MaDonTXL = _dontxl.MaDon;
                                    _cLichSuDonTu.Them(lichsuchuyenkt);

                                    _dontxl.NguoiDi = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    _dontxl.NgayChuyenKT = dateChuyen.Value;
                                    _dontxl.GhiChuChuyenKT = txtGhiChu.Text.Trim();
                                    _cDonTXL.SuaDonTXL(_dontxl);
                                }
                                LichSuDonTu entity = new LichSuDonTu();
                                entity.NgayChuyen = dateChuyen.Value;
                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                entity.GhiChu = txtGhiChu.Text.Trim();
                                entity.MaDonTXL = _dontxl.MaDon;
                                _cLichSuDonTu.Them(entity);
                                flag = true;
                                chkcmbNoiNhan.Properties.Items[i].CheckState = CheckState.Unchecked;
                            }
                        if (flag == false)
                        {
                            LichSuDonTu entity = new LichSuDonTu();
                            entity.NgayChuyen = dateChuyen.Value;
                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                            entity.NoiChuyen = cmbNoiChuyen.Text;
                            //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                            //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                            entity.GhiChu = txtGhiChu.Text.Trim();
                            entity.MaDonTXL = _dontxl.MaDon;
                            _cLichSuDonTu.Them(entity);
                        }
                    }
                    else
                    {
                        LichSuDonTu entity = new LichSuDonTu();
                        entity.NgayChuyen = dateChuyen.Value;
                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                        entity.NoiChuyen = cmbNoiChuyen.Text;
                        //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                        //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                        entity.GhiChu = txtGhiChu.Text.Trim();
                        entity.MaDonTXL = _dontxl.MaDon;
                        _cLichSuDonTu.Them(entity);
                    }
                    dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TXL", _dontxl.MaDon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvLichSuDonTu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvLichSuDonTu.CurrentCell = dgvLichSuDonTu.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvLichSuDonTu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_dontxl != null))
            {
                contextMenuStrip1.Show(dgvLichSuDonTu, new Point(e.X, e.Y));
            }
        }
    }
}
