using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.MaHoa;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;
using DocSo_PC.DAL.QuanTri;
using System.Transactions;
using DocSo_PC.DAL.Doi;
using System.IO;

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmKTXM : Form
    {
        string _mnu = "mnuKTXM";
        CKTXM _cKTXM = new CKTXM();
        CDHN _cDHN = new CDHN();
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDocSo _cDocSo = new CDocSo();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();

        MaHoa_DonTu _dontu = null;
        BienDong _biendong = null;
        MaHoa_KTXM _ctktxm = null;

        public frmKTXM()
        {
            InitializeComponent();
        }

        private void frmKTXM_Load(object sender, EventArgs e)
        {
            dgvDSKetQuaKiemTra.AutoGenerateColumns = false;
            dgvDanhSach.AutoGenerateColumns = false;
            dgvHinh.AutoGenerateColumns = false;
            cmbHienTrangKiemTra.DataSource = _cKTXM.getDS_HienTrang();
            cmbHienTrangKiemTra.DisplayMember = "Name";
            cmbHienTrangKiemTra.ValueMember = "Name";
            cmbHienTrangKiemTra.SelectedIndex = -1;
            if (CNguoiDung.Doi == true || CNguoiDung.ToTruong == true)
            {
                label24.Visible = true;
                cmbKTXM.Visible = true;
                DataTable dt = _cNguoiDung.getDS_KTXM();
                cmbKTXM.DataSource = dt;
                cmbKTXM.ValueMember = "MaND";
                cmbKTXM.DisplayMember = "HoTen";
            }
            else
            {
                label24.Visible = false;
                cmbKTXM.Visible = false;
            }
        }

        public void loadTTKH(BienDong hoadon)
        {
            txtDanhBo.Text = hoadon.DanhBa;
            txtHopDong.Text = hoadon.HopDong;
            txtHoTen.Text = hoadon.TenKH;
            txtDiaChi.Text = hoadon.So + " " + hoadon.Duong;
            //txtDienThoai.Text = _donkh.DienThoai;
            txtGiaBieu.Text = hoadon.GB.ToString();
            if (hoadon.DM != null)
                txtDinhMuc.Text = hoadon.DM.Value.ToString();
            else
                txtDinhMuc.Text = "";
            if (hoadon.DMHN != null)
                txtDinhMucHN.Text = hoadon.DMHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
            TB_DULIEUKHACHHANG ttkh = _cDHN.get(txtDanhBo.Text.Trim());
            txtHieu.Text = ttkh.HIEUDH;
            txtCo.Text = ttkh.CODH;
            txtSoThan.Text = ttkh.SOTHANDH;
        }

        public void loadCTKTXM(MaHoa_KTXM ctktxm)
        {
            try
            {
                txtMaDon.Text = ctktxm.IDMaDon.Value.ToString();
                chkBanChinh.Checked = ctktxm.BanChinh;
                txtDanhBo.Text = ctktxm.DanhBo;
                txtHopDong.Text = ctktxm.HopDong;
                txtHoTen.Text = ctktxm.HoTen;
                txtDiaChi.Text = ctktxm.DiaChi;
                txtGiaBieu.Text = ctktxm.GiaBieu.Value.ToString();
                if (ctktxm.DinhMuc != null)
                    txtDinhMuc.Text = ctktxm.DinhMuc.Value.ToString();
                if (ctktxm.DinhMucHN != null)
                    txtDinhMucHN.Text = ctktxm.DinhMucHN.Value.ToString();
                ///
                chkNgayKTXMTruocNgayGiao.Checked = ctktxm.NgayKTXM_Truoc_NgayGiao;
                dateKTXM.Value = ctktxm.NgayKTXM.Value;
                if (ctktxm.HienTrangKiemTra != null)
                    cmbHienTrangKiemTra.SelectedValue = ctktxm.HienTrangKiemTra;
                cmbViTriDHN1.SelectedItem = ctktxm.ViTriDHN1;
                cmbViTriDHN2.SelectedItem = ctktxm.ViTriDHN2;
                ///
                txtHieu.Text = ctktxm.Hieu;
                txtCo.Text = ctktxm.Co;
                txtSoThan.Text = ctktxm.SoThan;
                txtChiSo.Text = ctktxm.ChiSo;
                cmbTinhTrangChiSo.SelectedItem = ctktxm.TinhTrangChiSo;
                cmbChiMatSo.SelectedItem = ctktxm.ChiMatSo;
                cmbChiKhoaGoc.SelectedItem = ctktxm.ChiKhoaGoc;
                txtMucDichSuDung.Text = ctktxm.MucDichSuDung;
                txtDienThoai.Text = ctktxm.DienThoai;
                txtHoTenKHKy.Text = ctktxm.HoTenKHKy;
                txtNoiDungKiemTra.Text = ctktxm.NoiDungKiemTra;
                if (ctktxm.NoiDungBaoThay != null)
                {
                    cmbNoiDungBaoThay.SelectedText = ctktxm.NoiDungBaoThay;
                    txtGhiChuNoiDungBaoThay.Text = ctktxm.GhiChuNoiDungBaoThay;
                }
                dgvHinh.Rows.Clear();
                foreach (MaHoa_KTXM_Hinh item in ctktxm.MaHoa_KTXM_Hinhs.ToList())
                {
                    var index = dgvHinh.Rows.Add();
                    dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            chkBanChinh.Checked = false;
            txtMaDon.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            ///
            chkNgayKTXMTruocNgayGiao.Checked = false;
            //dateKTXM.Value = DateTime.Now;
            //cmbTinhTrangKiemTra.SelectedIndex = -1;
            cmbViTriDHN1.SelectedIndex = -1;
            cmbViTriDHN2.SelectedIndex = -1;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiSo.Text = "";
            cmbTinhTrangChiSo.SelectedIndex = -1;
            //cmbChiMatSo.SelectedIndex = -1;
            //cmbChiKhoaGoc.SelectedIndex = -1;
            txtMucDichSuDung.Text = "";
            txtDienThoai.Text = "";
            txtHoTenKHKy.Text = "";
            txtNoiDungKiemTra.Text = "";
            cmbNoiDungBaoThay.SelectedIndex = -1;
            txtGhiChuNoiDungBaoThay.Text = "";

            _dontu = null;
            _biendong = null;
            _ctktxm = null;
            dgvDSKetQuaKiemTra.DataSource = null;
            dgvHinh.Rows.Clear();
            txtMaDon.Focus();
        }

        public void Clear_LoadDSKTXM()
        {
            txtMaDon.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            ///
            //dateKTXM.Value = DateTime.Now;
            //cmbTinhTrangKiemTra.SelectedIndex = -1;
            cmbViTriDHN1.SelectedIndex = -1;
            cmbViTriDHN2.SelectedIndex = -1;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiSo.Text = "";
            cmbTinhTrangChiSo.SelectedIndex = -1;
            //cmbChiMatSo.SelectedIndex = -1;
            //cmbChiKhoaGoc.SelectedIndex = -1;
            txtMucDichSuDung.Text = "";
            txtDienThoai.Text = "";
            txtHoTenKHKy.Text = "";
            txtNoiDungKiemTra.Text = "";
            cmbNoiDungBaoThay.SelectedIndex = -1;
            txtGhiChuNoiDungBaoThay.Text = "";

            _dontu = null;
            _biendong = null;
            _ctktxm = null;
            dgvHinh.Rows.Clear();
            txtMaDon.Focus();
        }

        public void loadDSKTXM()
        {
            if (_dontu != null)
                dgvDSKetQuaKiemTra.DataSource = _cKTXM.getDS(_dontu.ID);
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtMaDon.Text.Trim() != "" && e.KeyChar == 13)
                {
                    string MaDon = txtMaDon.Text.Trim();
                    Clear();
                    txtMaDon.Text = MaDon;
                    _dontu = _cDonTu.get(int.Parse(MaDon));
                    if (_dontu != null)
                    {
                        _biendong = _cDocSo.get_BienDong_MoiNhat(_dontu.DanhBo);
                        if (_biendong != null)
                        {
                            loadTTKH(_biendong);
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        loadDSKTXM();
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtDanhBo.Text.Trim() != "" && e.KeyChar == 13)
                {
                    _biendong = _cDocSo.get_BienDong_MoiNhat(txtDanhBo.Text.Trim());
                    if (_biendong != null)
                    {
                        loadTTKH(_biendong);
                    }
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if ((txtDanhBo.Text.Trim().Length > 0 && txtDanhBo.Text.Trim().Length < 11) || txtDanhBo.Text.Trim().Length > 11)
                    {
                        MessageBox.Show("Lỗi Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txtHoTen.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtNoiDungKiemTra.Text.Trim() == "")
                    {
                        MessageBox.Show("Chưa đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MaHoa_KTXM ctktxm = new MaHoa_KTXM();

                    if (_dontu != null)
                    {
                        if (txtDanhBo.Text.Trim() != "" && _cKTXM.checkExist(CNguoiDung.MaND, _dontu.ID, txtDanhBo.Text.Trim(), dateKTXM.Value, cmbHienTrangKiemTra.SelectedValue.ToString()) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Nội Dung Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ctktxm.IDMaDon = _dontu.ID;
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ctktxm.BanChinh = chkBanChinh.Checked;
                    ctktxm.DanhBo = txtDanhBo.Text.Trim();
                    ctktxm.HopDong = txtHopDong.Text.Trim();
                    ctktxm.HoTen = txtHoTen.Text.Trim().ToUpper();
                    ctktxm.DiaChi = txtDiaChi.Text.Trim().ToUpper();
                    ctktxm.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                        ctktxm.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()))
                        ctktxm.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    if (_biendong != null)
                    {
                        ctktxm.Dot = int.Parse(_biendong.Dot);
                        ctktxm.Ky = int.Parse(_biendong.Ky);
                        ctktxm.Nam = _biendong.Nam;
                        ctktxm.Phuong = _biendong.Phuong;
                        ctktxm.Quan = _biendong.Quan;
                    }
                    ///
                    ctktxm.NgayKTXM_Truoc_NgayGiao = chkNgayKTXMTruocNgayGiao.Checked;
                    ctktxm.NgayKTXM = dateKTXM.Value;

                    if (cmbHienTrangKiemTra.SelectedValue != null)
                        ctktxm.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedValue.ToString();

                    if (cmbViTriDHN1.SelectedItem != null)
                        ctktxm.ViTriDHN1 = cmbViTriDHN1.SelectedItem.ToString();

                    if (cmbViTriDHN2.SelectedItem != null)
                        ctktxm.ViTriDHN2 = cmbViTriDHN2.SelectedItem.ToString();

                    ctktxm.Hieu = txtHieu.Text.Trim();
                    ctktxm.Co = txtCo.Text.Trim();
                    ctktxm.SoThan = txtSoThan.Text.Trim();
                    ctktxm.ChiSo = txtChiSo.Text.Trim();

                    if (cmbTinhTrangChiSo.SelectedItem != null)
                        ctktxm.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                    if (cmbChiMatSo.SelectedItem != null)
                        ctktxm.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                    if (cmbChiKhoaGoc.SelectedItem != null)
                        ctktxm.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                    ctktxm.MucDichSuDung = txtMucDichSuDung.Text.Trim();
                    ctktxm.DienThoai = txtDienThoai.Text.Trim();
                    //auto thêm sđt vào phần ghi chú
                    if (ctktxm.DienThoai != "" && ctktxm.DienThoai.Length == 10)
                    {
                        if (_cDHN.checkExists_DienThoai(ctktxm.DanhBo, ctktxm.DienThoai) == false)
                        {
                            SDT_DHN en = new SDT_DHN();
                            en.DanhBo = ctktxm.DanhBo;
                            en.DienThoai = ctktxm.DienThoai;
                            en.HoTen = "";
                            en.SoChinh = true;
                            en.GhiChu = "Đ. QLĐHN";
                            _cDHN.them_DienThoai(en);
                        }
                    }
                    ctktxm.HoTenKHKy = txtHoTenKHKy.Text.Trim().ToUpper();

                    ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();
                    if (cmbNoiDungBaoThay.SelectedIndex != -1 && string.IsNullOrEmpty(cmbNoiDungBaoThay.SelectedItem.ToString()) == false)
                    {
                        ctktxm.NoiDungBaoThay = cmbNoiDungBaoThay.SelectedItem.ToString();
                        if (txtGhiChuNoiDungBaoThay.Text.Trim() != "")
                            ctktxm.GhiChuNoiDungBaoThay = txtGhiChuNoiDungBaoThay.Text.Trim();
                    }
                    if (_cKTXM.Them(ctktxm) == true)
                    {
                        foreach (DataGridViewRow item in dgvHinh.Rows)
                        {
                            MaHoa_KTXM_Hinh en = new MaHoa_KTXM_Hinh();
                            en.IDParent = ctktxm.ID;
                            en.Name = item.Cells["Name_Hinh"].Value.ToString();
                            en.Loai = item.Cells["Loai_Hinh"].Value.ToString();
                            if (_wsDHN.ghi_Hinh_MaHoa("KTXM", ctktxm.ID.ToString(), en.Name + en.Loai, Convert.FromBase64String(item.Cells["Bytes_Hinh"].Value.ToString())) == true)
                                _cKTXM.Them_Hinh(en);
                        }
                        if (_dontu != null)
                        {
                            _cDonTu.Them_LichSu(ctktxm.NgayKTXM.Value, "KTXM", "Đã Kiểm Tra, " + ctktxm.NoiDungKiemTra, ctktxm.ID, _dontu.ID);
                        }
                        string noidung = "Mã Đơn: " + ctktxm.IDMaDon + ", " + ctktxm.NgayKTXM.Value.ToString("dd/MM/yyyy") + ", " + ctktxm.NoiDungKiemTra + ", " + CNguoiDung.HoTen;
                        string sql = "insert into TB_GHICHU(DANHBO,DONVI,NOIDUNG,CREATEDATE,CREATEBY)values('" + ctktxm.DanhBo + "',N'QLDHN',N'" + noidung + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture) + "',N'" + CNguoiDung.HoTen + "')";
                        CDHN._cDAL.ExecuteNonQuery(sql);
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear_LoadDSKTXM();
                        txtMaDon.Focus();
                    }
                    loadDSKTXM();
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_ctktxm != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (CNguoiDung.Admin == false && CNguoiDung.ToTruong == false && CNguoiDung.ThuKy == false)
                            if (_ctktxm.CreateBy != CNguoiDung.MaND)
                            {
                                MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        string flagID = _ctktxm.ID.ToString();
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            if (_cKTXM.Xoa(_ctktxm))
                            {
                                _wsDHN.xoa_Folder_Hinh_MaHoa("KTXM", flagID);
                                scope.Complete();
                                scope.Dispose();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                                txtMaDon.Focus();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_ctktxm != null)
                    {
                        _ctktxm.BanChinh = chkBanChinh.Checked;
                        _ctktxm.DanhBo = txtDanhBo.Text.Trim();
                        _ctktxm.HopDong = txtHopDong.Text.Trim();
                        _ctktxm.HoTen = txtHoTen.Text.Trim().ToUpper();
                        _ctktxm.DiaChi = txtDiaChi.Text.Trim().ToUpper();
                        _ctktxm.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            _ctktxm.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (!string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()))
                            _ctktxm.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        if (_biendong != null)
                        {
                            _ctktxm.Dot = int.Parse(_biendong.Dot);
                            _ctktxm.Ky = int.Parse(_biendong.Ky);
                            _ctktxm.Nam = _biendong.Nam;
                            _ctktxm.Phuong = _biendong.Phuong;
                            _ctktxm.Quan = _biendong.Quan;
                        }
                        ///
                        _ctktxm.NgayKTXM_Truoc_NgayGiao = chkNgayKTXMTruocNgayGiao.Checked;
                        //cập nhật lại thời gian bên lịch sử chuyển đơn
                        if (_ctktxm.NgayKTXM.Value.Date != dateKTXM.Value.Date)
                        {
                            MaHoa_DonTu_LichSu dtls = _cDonTu.get_LichSu("KTXM", (int)_ctktxm.ID);
                            if (dtls != null)
                            {
                                dtls.NgayChuyen = dateKTXM.Value;
                                _cDonTu.SubmitChanges();
                            }
                        }
                        _ctktxm.NgayKTXM = dateKTXM.Value;

                        if (cmbHienTrangKiemTra.SelectedValue != null)
                            _ctktxm.HienTrangKiemTra = cmbHienTrangKiemTra.SelectedValue.ToString();

                        if (cmbViTriDHN1.SelectedItem != null)
                            _ctktxm.ViTriDHN1 = cmbViTriDHN1.SelectedItem.ToString();

                        if (cmbViTriDHN2.SelectedItem != null)
                            _ctktxm.ViTriDHN2 = cmbViTriDHN2.SelectedItem.ToString();

                        _ctktxm.Hieu = txtHieu.Text.Trim();
                        _ctktxm.Co = txtCo.Text.Trim();
                        _ctktxm.SoThan = txtSoThan.Text.Trim();
                        _ctktxm.ChiSo = txtChiSo.Text.Trim();

                        if (cmbTinhTrangChiSo.SelectedItem != null)
                            _ctktxm.TinhTrangChiSo = cmbTinhTrangChiSo.SelectedItem.ToString();

                        if (cmbChiMatSo.SelectedItem != null)
                            _ctktxm.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();

                        if (cmbChiKhoaGoc.SelectedItem != null)
                            _ctktxm.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();

                        _ctktxm.MucDichSuDung = txtMucDichSuDung.Text.Trim();
                        _ctktxm.DienThoai = txtDienThoai.Text.Trim();
                        _ctktxm.HoTenKHKy = txtHoTenKHKy.Text.Trim().ToUpper();

                        _ctktxm.NoiDungKiemTra = txtNoiDungKiemTra.Text.Trim();
                        if (cmbNoiDungBaoThay.SelectedIndex != -1 && string.IsNullOrEmpty(cmbNoiDungBaoThay.SelectedItem.ToString()) == false)
                        {
                            _ctktxm.NoiDungBaoThay = cmbNoiDungBaoThay.SelectedItem.ToString();
                            if (txtGhiChuNoiDungBaoThay.Text.Trim() != "")
                                _ctktxm.GhiChuNoiDungBaoThay = txtGhiChuNoiDungBaoThay.Text.Trim();
                        }
                        if (_cKTXM.Sua(_ctktxm) == true)
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbHienTrangKiemTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHienTrangKiemTra.Items.Count > 0 && cmbHienTrangKiemTra.SelectedIndex >= 0)
                switch (cmbHienTrangKiemTra.SelectedValue.ToString())
                {
                    case "Nhà đóng cửa":
                        txtChiSo.Enabled = false;
                        cmbTinhTrangChiSo.Enabled = false;
                        cmbChiMatSo.Enabled = false;
                        cmbChiKhoaGoc.Enabled = false;
                        txtHieu.Enabled = false;
                        txtCo.Enabled = false;
                        txtSoThan.Enabled = false;
                        txtMucDichSuDung.Enabled = false;
                        txtDienThoai.Enabled = false;
                        txtHoTenKHKy.Enabled = false;
                        ///
                        cmbViTriDHN1.SelectedIndex = -1;
                        cmbViTriDHN2.SelectedIndex = -1;
                        txtChiSo.Text = "";
                        cmbTinhTrangChiSo.SelectedIndex = -1;
                        cmbChiMatSo.SelectedIndex = -1;
                        cmbChiKhoaGoc.SelectedIndex = -1;
                        //txtHieu.Text = "";
                        //txtCo.Text = "";
                        //txtSoThan.Text = "";
                        txtMucDichSuDung.Text = "";
                        txtDienThoai.Text = "";
                        txtHoTenKHKy.Text = "";
                        break;
                    case "BB mất ĐHN bồi thường":
                    case "BB mất ĐHN không bồi thường":
                        txtChiSo.Enabled = false;
                        cmbTinhTrangChiSo.Enabled = false;
                        cmbChiMatSo.Enabled = false;
                        cmbChiKhoaGoc.Enabled = false;
                        txtHieu.Enabled = false;
                        txtCo.Enabled = false;
                        txtSoThan.Enabled = false;
                        txtDienThoai.Enabled = true;
                        txtHoTenKHKy.Enabled = true;
                        ///
                        cmbViTriDHN1.SelectedIndex = -1;
                        cmbViTriDHN2.SelectedIndex = -1;
                        txtChiSo.Text = "";
                        cmbTinhTrangChiSo.SelectedIndex = -1;
                        cmbChiMatSo.SelectedIndex = -1;
                        cmbChiKhoaGoc.SelectedIndex = -1;
                        //txtHieu.Text = "";
                        //txtCo.Text = "";
                        //txtSoThan.Text = "";
                        txtMucDichSuDung.Text = "";
                        txtDienThoai.Text = "";
                        txtHoTenKHKy.Text = "";
                        break;
                    default:
                        txtChiSo.Enabled = true;
                        cmbTinhTrangChiSo.Enabled = true;
                        cmbChiMatSo.Enabled = true;
                        cmbChiKhoaGoc.Enabled = true;
                        txtHieu.Enabled = true;
                        txtCo.Enabled = true;
                        txtSoThan.Enabled = true;
                        txtMucDichSuDung.Enabled = true;
                        txtDienThoai.Enabled = true;
                        txtHoTenKHKy.Enabled = true;
                        ///
                        cmbViTriDHN1.SelectedIndex = -1;
                        cmbViTriDHN2.SelectedIndex = -1;
                        txtChiSo.Text = "";
                        cmbTinhTrangChiSo.SelectedIndex = -1;
                        cmbChiMatSo.SelectedIndex = -1;
                        cmbChiKhoaGoc.SelectedIndex = -1;
                        //txtHieu.Text = "";
                        //txtCo.Text = "";
                        //txtSoThan.Text = "";
                        txtMucDichSuDung.Text = "";
                        txtDienThoai.Text = "";
                        txtHoTenKHKy.Text = "";
                        break;
                }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png|PDF files (*.pdf) | *.pdf";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] bytes = _cKTXM.scanVanBan(dialog.FileName);
                    if (_ctktxm == null)
                    {
                        var index = dgvHinh.Rows.Add();
                        dgvHinh.Rows[index].Cells["Name_Hinh"].Value = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                        dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                        dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
                    }
                    else
                    {
                        if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                        {
                            if (CNguoiDung.Admin == false && CNguoiDung.ToTruong == false && CNguoiDung.ThuKy == false)
                                if (_ctktxm.CreateBy != CNguoiDung.MaND)
                                {
                                    MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            MaHoa_KTXM_Hinh en = new MaHoa_KTXM_Hinh();
                            en.IDParent = _ctktxm.ID;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsDHN.ghi_Hinh_MaHoa("KTXM", _ctktxm.ID.ToString(), en.Name + en.Loai, bytes) == true)
                                if (_cKTXM.Them_Hinh(en) == true)
                                {
                                    _cKTXM.Refresh();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            byte[] file = _wsDHN.get_Hinh_MaHoa("KTXM", _ctktxm.ID.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (file != null)
                if (dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString().Contains("pdf"))
                    _cKTXM.viewPDF(1, file);
                else
                    _cKTXM.viewImage(file);
            else
                MessageBox.Show("Lỗi File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHinh_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (_ctktxm == null)
                    dgvHinh.Rows.RemoveAt(e.Row.Index);
                else
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (CNguoiDung.Admin == false && CNguoiDung.ToTruong == false && CNguoiDung.ThuKy == false)
                                if (_ctktxm.CreateBy != CNguoiDung.MaND)
                                {
                                    MessageBox.Show("Bạn không phải người lập nên không được phép điều chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            if (e.Row.Cells["ID_Hinh"].Value != null)
                                if (_wsDHN.xoa_Hinh_MaHoa("KTXM", _ctktxm.ID.ToString(), e.Row.Cells["Name_Hinh"].Value.ToString() + e.Row.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cKTXM.Xoa_Hinh(_cKTXM.get_Hinh(int.Parse(e.Row.Cells["ID_Hinh"].Value.ToString()))))
                                    {
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        dgvHinh.Rows.RemoveAt(e.Row.Index);
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

        private void dgvDSKetQuaKiemTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _ctktxm = _cKTXM.get(int.Parse(dgvDSKetQuaKiemTra.Rows[e.RowIndex].Cells["MaCTKTXM"].Value.ToString()));
                loadCTKTXM(_ctktxm);
            }
            catch (Exception)
            {
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi == true || CNguoiDung.ToTruong == true)
            {
                dgvDanhSach.DataSource = _cKTXM.getDS(CNguoiDung.FromDot, CNguoiDung.ToDot, int.Parse(cmbKTXM.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
            }
            else
            {
                dgvDanhSach.DataSource = _cKTXM.getDS(CNguoiDung.FromDot, CNguoiDung.ToDot, CNguoiDung.MaND, dateTuNgay.Value, dateDenNgay.Value);
            }
        }

        private void btnImportHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int count = 0;
                        string message = "";
                        using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                        {
                            dlg.Description = "Chọn Thư Mục Chứa File";
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                foreach (string file in Directory.GetFiles(dlg.SelectedPath))
                                    if (file.ToLower().Contains(".jpg") || file.ToLower().Contains(".jpeg") || file.ToLower().Contains(".png") || file.ToLower().Contains(".pdf"))
                                    {
                                        byte[] bytes = _cKTXM.scanVanBan(file);
                                        MaHoa_KTXM_Hinh en = new MaHoa_KTXM_Hinh();
                                        MaHoa_KTXM ktxm = _cKTXM.get_MaDon(int.Parse(System.IO.Path.GetFileNameWithoutExtension(file)));
                                        en.IDParent = ktxm.ID;
                                        en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                                        en.Loai = System.IO.Path.GetExtension(file);
                                        if (_wsDHN.ghi_Hinh_MaHoa("KTXM", ktxm.ID.ToString(), en.Name + en.Loai, bytes) == true)
                                            if (_cKTXM.Them_Hinh(en) == true)
                                            {
                                                count++;
                                                message += ktxm.IDMaDon + "\n";
                                            }
                                    }
                                _cKTXM.Refresh();
                                MessageBox.Show("Đã xử lý " + count + " mã đơn\n" + message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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


    }
}
