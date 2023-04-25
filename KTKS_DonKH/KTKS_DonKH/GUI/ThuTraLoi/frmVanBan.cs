using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.VanBan;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.QuanTri;
using System.Transactions;
using KTKS_DonKH.GUI.DonTu;
using KTKS_DonKH.BaoCao;
using CrystalDecisions.CrystalReports.Engine;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.BaoCao.VanBan;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.wrThuongVu;

namespace KTKS_DonKH.GUI.VanBan
{
    public partial class frmVanBan : Form
    {
        string _mnu = "mnuVanBan";
        CDonTu _cDonTu = new CDonTu();
        CVanBan _cVanBan = new CVanBan();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDocSo = new CDHN();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CTTTL_VeViec _cVeViecTTTL = new CTTTL_VeViec();
        wsThuongVu _wsThuongVu = new wsThuongVu();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        HOADON _hoadon = null;
        VanBan_ChiTiet _enCT = null;
        int _IDCT = -1;

        public frmVanBan()
        {
            InitializeComponent();
        }

        public frmVanBan(int IDCT)
        {
            _IDCT = IDCT;
            InitializeComponent();
        }

        private void frmVanBan_Load(object sender, EventArgs e)
        {
            dgvHinh.AutoGenerateColumns = false;

            cmbVeViec.DataSource = _cVeViecTTTL.getDS_VanBan();
            cmbVeViec.ValueMember = "TenVV";
            cmbVeViec.DisplayMember = "TenVV";
            cmbVeViec.SelectedIndex = -1;

            if (_IDCT != -1)
            {
                txtMaVanBan.Text = _IDCT.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaVanBan_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtLoTrinh.Text = hoadon.DOT + hoadon.MAY + hoadon.STT;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            if (hoadon.DM != null)
                txtDinhMuc.Text = hoadon.DM.Value.ToString();
            else
                txtDinhMuc.Text = "";
            if (hoadon.DinhMucHN != null)
                txtDinhMucHN.Text = hoadon.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";

        }

        public void LoadEntity(VanBan_ChiTiet en)
        {
            if (en.VanBan.MaDon != null)
            {
                _dontu_ChiTiet = _cDonTu.get_ChiTiet(en.VanBan.MaDon.Value, en.STT.Value);
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDonMoi.Text = en.VanBan.MaDon.ToString();
                else
                    txtMaDonMoi.Text = en.VanBan.MaDon.Value.ToString() + "." + en.STT.Value.ToString();
            }

            txtMaVanBan.Text = en.IDCT.ToString().Insert(en.IDCT.ToString().Length - 2, "-");
            txtTCHC.Text = en.TCHC;

            txtDanhBo.Text = en.DanhBo;
            txtHopDong.Text = en.HopDong;
            txtLoTrinh.Text = en.LoTrinh;
            txtHoTen.Text = en.HoTen;
            txtDiaChi.Text = en.DiaChi;
            txtGiaBieu.Text = en.GiaBieu.Value.ToString();
            if (en.DinhMuc != null)
                txtDinhMuc.Text = en.DinhMuc.Value.ToString();
            if (en.DinhMucHN != null)
                txtDinhMucHN.Text = en.DinhMucHN.Value.ToString();

            txtVeViec.Text = en.VeViec;
            txtNoiDung.Text = en.NoiDung;
            txtNoiNhan.Text = en.NoiNhan;

            dgvHinh.Rows.Clear();
            foreach (VanBan_ChiTiet_Hinh item in en.VanBan_ChiTiet_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                if (item.Hinh != null)
                    dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(item.Hinh.ToArray());
                dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
            }
        }

        public void Clear()
        {
            txtMaVanBan.Text = "";
            txtTCHC.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            ///
            cmbVeViec.SelectedIndex = -1;
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";

            _dontu_ChiTiet = null;
            _hoadon = null;
            _enCT = null;

            dgvHinh.Rows.Clear();

            txtMaDonMoi.Focus();
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
                    LinQ.DonTu dt = _cDonTu.get(int.Parse(MaDon));
                    if (dt != null)
                        _dontu_ChiTiet = dt.DonTu_ChiTiets.SingleOrDefault();
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

        private void txtMaVanBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && _cVanBan.CheckExist_ChiTiet(int.Parse(txtMaVanBan.Text.Trim().Replace("-", ""))) == true)
            {
                string MaDon = txtMaVanBan.Text.Trim();
                Clear();
                txtMaVanBan.Text = MaDon;
                _enCT = _cVanBan.get_ChiTiet(int.Parse(txtMaVanBan.Text.Trim().Replace("-", "")));
                if (_enCT != null)
                    LoadEntity(_enCT);
                else
                    MessageBox.Show("Mã này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (txtVeViec.Text.Trim() == "" || txtNoiDung.Text.Trim() == "" || txtNoiNhan.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    VanBan_ChiTiet enCT = new VanBan_ChiTiet();

                    if (_dontu_ChiTiet != null)
                    {
                        if (_cVanBan.checkExist(_dontu_ChiTiet.MaDon.Value) == false)
                        {
                            LinQ.VanBan en = new LinQ.VanBan();
                            en.MaDon = _dontu_ChiTiet.MaDon.Value;
                            _cVanBan.Them(en);
                        }
                        if (_cVanBan.checkExist_ChiTiet(_dontu_ChiTiet.MaDon.Value, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                        {
                            if (MessageBox.Show("Danh Bộ này đã được Lập Thư\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                        }
                        enCT.ID = _cVanBan.get_MaDon(_dontu_ChiTiet.MaDon.Value).ID;
                        enCT.STT = _dontu_ChiTiet.STT.Value;
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    enCT.DanhBo = txtDanhBo.Text.Trim();
                    enCT.HopDong = txtHopDong.Text.Trim();
                    enCT.LoTrinh = txtLoTrinh.Text.Trim();
                    enCT.HoTen = txtHoTen.Text.Trim();
                    enCT.DiaChi = txtDiaChi.Text.Trim();
                    enCT.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                        enCT.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                        enCT.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    if (_hoadon != null)
                    {
                        enCT.Dot = _hoadon.DOT;
                        enCT.Ky = _hoadon.KY;
                        enCT.Nam = _hoadon.NAM;
                        enCT.Phuong = _hoadon.Phuong;
                        enCT.Quan = _hoadon.Quan;
                    }
                    enCT.VeViec = txtVeViec.Text.Trim();
                    enCT.NoiDung = txtNoiDung.Text;
                    enCT.NoiNhan = txtNoiNhan.Text.Trim();

                    ///Ký Tên
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        enCT.ChucVu = "GIÁM ĐỐC";
                    else
                        enCT.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    enCT.NguoiKy = bangiamdoc.HoTen.ToUpper();
                    enCT.ThuDuocKy = true;

                    using (TransactionScope scope = new TransactionScope())
                        if (_cVanBan.ThemCT(enCT))
                        {
                            foreach (DataGridViewRow item in dgvHinh.Rows)
                            {
                                VanBan_ChiTiet_Hinh en = new VanBan_ChiTiet_Hinh();
                                en.IDVanBan_ChiTiet = enCT.IDCT;
                                en.Name = item.Cells["Name_Hinh"].Value.ToString();
                                //en.Hinh = Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString());
                                en.Loai = item.Cells["Loai_Hinh"].Value.ToString();
                                if (_wsThuongVu.ghi_Hinh("VanBan_ChiTiet_Hinh", en.IDVanBan_ChiTiet.Value.ToString(), en.Name + en.Loai, Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString())) == true)
                                    _cVanBan.Them_Hinh(en);
                            }
                            if (_dontu_ChiTiet != null)
                            {
                                if (_cDonTu.Them_LichSu(enCT.CreateDate.Value, "VanBan", "Đã Lập Văn Bản, " + enCT.VeViec, (int)enCT.IDCT, _dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value) == true)
                                    scope.Complete();
                            }
                            else
                                scope.Complete();
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_enCT != null)
                    {
                        _enCT.TCHC = txtTCHC.Text.Trim();
                        _enCT.DanhBo = txtDanhBo.Text.Trim();
                        _enCT.HopDong = txtHopDong.Text.Trim();
                        _enCT.LoTrinh = txtLoTrinh.Text.Trim();
                        _enCT.HoTen = txtHoTen.Text.Trim();
                        _enCT.DiaChi = txtDiaChi.Text.Trim();
                        _enCT.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                            _enCT.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        else
                            _enCT.DinhMuc = null;
                        if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                            _enCT.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        else
                            _enCT.DinhMucHN = null;
                        if (_hoadon != null)
                        {
                            _enCT.Dot = _hoadon.DOT;
                            _enCT.Ky = _hoadon.KY;
                            _enCT.Nam = _hoadon.NAM;
                            _enCT.Phuong = _hoadon.Phuong;
                            _enCT.Quan = _hoadon.Quan;
                        }
                        _enCT.VeViec = txtVeViec.Text.Trim();
                        _enCT.NoiDung = txtNoiDung.Text;
                        _enCT.NoiNhan = txtNoiNhan.Text.Trim();

                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            _enCT.ChucVu = "GIÁM ĐỐC";
                        else
                            _enCT.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        _enCT.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        _enCT.ThuDuocKy = true;

                        if (_cVanBan.SuaCT(_enCT))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_enCT != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string flagID = _enCT.IDCT.ToString();
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu("VanBan_ChiTiet", (int)_enCT.IDCT, _enCT.CreateBy.Value);
                            if (dtls != null)
                            {
                                _cDonTu.Xoa_LichSu(dtls, true);
                            }
                            if (_cVanBan.XoaCT(_enCT))
                            {
                                _wsThuongVu.xoa_Folder_Hinh("VanBan_ChiTiet_Hinh", flagID);
                                scope.Complete();
                                scope.Dispose();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_enCT != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                //dr["SoPhieu"] = _cttttl.MaCTTTTL.ToString().Insert(_cttttl.MaCTTTTL.ToString().Length - 2, "-");
                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

                dr["HoTen"] = _enCT.HoTen;
                dr["DiaChi"] = _enCT.DiaChi;
                if (!string.IsNullOrEmpty(_enCT.DanhBo) && _enCT.DanhBo.Length == 11)
                    dr["DanhBo"] = _enCT.DanhBo.Insert(7, " ").Insert(4, " ");

                dr["HopDong"] = _enCT.HopDong;

                dr["VeViec"] = _enCT.VeViec;
                dr["NoiDung"] = _enCT.NoiDung;
                dr["NoiNhan"] = _enCT.NoiNhan + "\r\nVB" + _enCT.IDCT.ToString().Insert(_enCT.IDCT.ToString().Length - 2, "-");
                dr["ChucVu"] = _enCT.ChucVu;
                dr["NguoiKy"] = _enCT.NguoiKy;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                ReportDocument rpt = new ReportDocument();
                switch (_enCT.VeViec)
                {
                    case "Thay hạ cỡ đồng hồ nước":
                        rpt = new rptThayHaCoDHN();
                        break;
                    case "Phối hợp đóng nước niêm chì đồng hồ nước":
                        rpt = new rptPhoiHopDongNuocNiemChiDHN();
                        break;
                }

                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
        }

        private void cmbVeViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVeViec.SelectedIndex != -1)
            {
                ThuTraLoi_VeViec vv = (ThuTraLoi_VeViec)cmbVeViec.SelectedItem;
                txtVeViec.Text = vv.TenVV;
                txtNoiDung.Text = vv.NoiDung;
                txtNoiNhan.Text = vv.NoiNhan;
                if (txtMaDonMoi.Text.Trim() != "")
                    txtNoiNhan.Text += " (" + txtMaDonMoi.Text.Trim() + ")";
            }
            else
            {
                txtVeViec.Text = "";
                txtNoiDung.Text = "";
                txtNoiNhan.Text = "";
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Mã VB":
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSThu.DataSource = _cVanBan.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()));
                    break;
                case "Mã VB":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        dgvDSThu.DataSource = _cVanBan.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), int.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSThu.DataSource = _cVanBan.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                    break;
                case "Danh Bộ":
                    dgvDSThu.DataSource = _cVanBan.getDS(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                    break;
                case "Ngày":
                    dgvDSThu.DataSource = _cVanBan.getDS(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {

        }

        private void dgvDSThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSThu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvDSThu.Columns[e.ColumnIndex].Name == "ThuDuocKy")
                    {
                        VanBan_ChiTiet enCT = _cVanBan.get_ChiTiet(int.Parse(dgvDSThu["IDCT", e.RowIndex].Value.ToString()));
                        enCT.ThuDuocKy = bool.Parse(dgvDSThu["ThuDuocKy", e.RowIndex].Value.ToString());
                        _cVanBan.SuaCT(enCT);
                    }
                    if (dgvDSThu.Columns[e.ColumnIndex].Name == "TraTrinhKy")
                    {
                        VanBan_ChiTiet enCT = _cVanBan.get_ChiTiet(int.Parse(dgvDSThu["IDCT", e.RowIndex].Value.ToString()));
                        enCT.TraTrinhKy = bool.Parse(dgvDSThu["TraTrinhKy", e.RowIndex].Value.ToString());
                        _cVanBan.SuaCT(enCT);
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

        private void dgvDSThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _enCT = _cVanBan.get_ChiTiet(int.Parse(dgvDSThu["IDCT", e.RowIndex].Value.ToString()));
                if (_enCT != null)
                    LoadEntity(_enCT);
            }
            catch
            {

            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png|PDF files (*.pdf) | *.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] bytes;
                    if (dialog.FileName.ToLower().Contains("pdf"))
                        bytes = _cVanBan.scanFile(dialog.FileName);
                    else
                        bytes = _cVanBan.scanImage(dialog.FileName);
                    if (_enCT == null)
                    {
                        var index = dgvHinh.Rows.Add();
                        dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                        dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
                    }
                    else
                    {
                        if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                        {
                            VanBan_ChiTiet_Hinh en = new VanBan_ChiTiet_Hinh();
                            en.IDVanBan_ChiTiet = _enCT.IDCT;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsThuongVu.ghi_Hinh("VanBan_ChiTiet_Hinh", en.IDVanBan_ChiTiet.Value.ToString(), en.Name + en.Loai, bytes) == true)
                                if (_cVanBan.Them_Hinh(en) == true)
                                {
                                    _cVanBan.Refresh();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var index = dgvHinh.Rows.Add();
                                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = en.Name;
                                    dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
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
            byte[] file = _wsThuongVu.get_Hinh("VanBan_ChiTiet_Hinh", _enCT.IDCT.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (file != null)
                if (dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString().ToLower().Contains("pdf"))
                    _cVanBan.viewPDF(file);
                else
                    _cVanBan.viewImage(file);
            else
                MessageBox.Show("File không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_enCT == null)
                    dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                else
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                                if (_wsThuongVu.xoa_Hinh("VanBan_ChiTiet_Hinh", _enCT.IDCT.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cVanBan.Xoa_Hinh(_cVanBan.get_Hinh(int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString()))))
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

        private void frmVanBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet, "VanBan_ChiTiet", _enCT.IDCT);
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
