using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.GUI.ToKhachHang;
using KTKS_DonKH.GUI.ToXuLy;

namespace KTKS_DonKH.GUI.ToBamChi
{
    public partial class frmNhanDonTBC : Form
    {
        string _mnu = "mnuNhanDonTBC";
        CDHN _cDocSo = new CDHN();
        CThuTien _cThuTien = new CThuTien();
        CDonTu _cDonTu = new CDonTu();
        CLoaiDonTBC _cLoaiDonTBC = new CLoaiDonTBC();
        CDonTBC _cDonTBC = new CDonTBC();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();

        DataSet _dsNoiChuyen = new DataSet("NoiChuyen");
        DonTBC _dontbc = null;
        HOADON _hoadon = null;
        bool _flagFirst = false;
        decimal _MaDonTo = -1;

        public frmNhanDonTBC()
        {
            InitializeComponent();
        }

        public frmNhanDonTBC(decimal MaDonTo)
        {
            _MaDonTo = MaDonTo;
            InitializeComponent();
        }

        private void frmNhanDonTBC_Load(object sender, EventArgs e)
        {
            dgvLichSuDon.AutoGenerateColumns = false;
            dgvLichSuDonTu.AutoGenerateColumns = false;
            dgvLichSuDonTu_DCBD.AutoGenerateColumns = false;

            cmbLD.DataSource = _cLoaiDonTBC.GetDS();
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("TBC");
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.SelectedIndex = -1;

            _flagFirst = true;

            //DataTable dt = new DataTable();
            //dt = _cTaiKhoan.GetDS_KTXM(CTaiKhoan.KyHieuMaTo);
            //dt.TableName = "1";//Kiểm Tra Xác Minh
            //_dsNoiChuyen.Tables.Add(dt);
            /////
            //dt = new DataTable();
            //dt = _cTaiKhoan.GetDS_ThuKy("TKH");
            //dt.TableName = "2";//Tổ Khách Hàng
            //_dsNoiChuyen.Tables.Add(dt);
            /////
            //dt = new DataTable();
            //dt = _cTaiKhoan.GetDS_ThuKy("TXL");
            //dt.TableName = "3";//Tổ Xử Lý
            //_dsNoiChuyen.Tables.Add(dt);
            /////
            //dt = new DataTable();
            //dt = _cTaiKhoan.GetDS_ThuKy("TBC");
            //dt.TableName = "4";//Tổ Bấm Chì
            //_dsNoiChuyen.Tables.Add(dt);
            /////
            //dt = new DataTable();
            //dt = _cTaiKhoan.GetDS_ThuKy("TVP");
            //dt.TableName = "5";//Tổ Văn Phòng
            //_dsNoiChuyen.Tables.Add(dt);
            /////
            //dt = new DataTable();
            //dt = _cPhongBanDoi.GetDS();
            //dt.TableName = "6";//Phòng Ban Đội Khác
            //_dsNoiChuyen.Tables.Add(dt);

            if (_MaDonTo != -1)
            {
                txtMaDonToCu.Text = _MaDonTo.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaDonTo_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON entity)
        {
            txtDanhBo.Text = entity.DANHBA.Insert(7, " ").Insert(4, " ");
            txtHopDong.Text = entity.HOPDONG;
            txtHoTen.Text = entity.TENKH;
            txtDiaChi.Text = entity.SO + " " + entity.DUONG + _cDocSo.GetPhuongQuan(entity.Quan, entity.Phuong);
            txtGiaBieu.Text = entity.GB.ToString();
            txtDinhMuc.Text = entity.DM.ToString();
            dgvLichSuDon.DataSource = _cLichSuDonTu.GetDS_3To(entity.DANHBA);
            dgvLichSuDonTu_DCBD.DataSource = _cLichSuDonTu.GetDS_DCBD(entity.DANHBA);
        }

        public void LoadDonTBC(DonTBC entity)
        {
            cmbLD.SelectedValue = entity.MaLD.Value;
            txtSoCongVan.Text = entity.SoCongVan;
            txtMaDonToCu.Text = "TBC" + entity.MaDon.ToString().Insert(entity.MaDon.ToString().Length - 2, "-");
            txtNgayNhan.Text = entity.CreateDate.Value.ToString("dd/MM/yyyy");
            txtNoiDung.Text = entity.NoiDung;

            if (entity.DanhBo != null && entity.DanhBo.Length == 11)
            txtDanhBo.Text = entity.DanhBo.Insert(7, " ").Insert(4, " ");
            else
                txtDanhBo.Text = entity.DanhBo;
            txtHopDong.Text = entity.HopDong;
            txtDienThoai.Text = entity.DienThoai;
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            txtGiaBieu.Text = entity.GiaBieu.Value.ToString();
            txtDinhMuc.Text = entity.DinhMuc.Value.ToString();

            dgvLichSuDon.DataSource = _cLichSuDonTu.GetDS_3To(entity.DanhBo);
            dgvLichSuDonTu_DCBD.DataSource = _cLichSuDonTu.GetDS_DCBD(txtDanhBo.Text.Trim());

            dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TBC", entity.MaDon);
            cmbNoiChuyen.SelectedIndex = -1;
            dateChuyen.Value = DateTime.Now;
            txtGhiChu.Text = "";
        }

        public void LoadDonTu(LinQ.DonTu entity)
        {
            txtSoCongVan.Text = entity.SoCongVan;
            txtDanhBo.Text = entity.DanhBo;
            txtHopDong.Text = entity.HopDong;
            txtDienThoai.Text = entity.DienThoai;
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            if (entity.GiaBieu != null)
                txtGiaBieu.Text = entity.GiaBieu.Value.ToString();
            if (entity.DinhMuc != null)
                txtDinhMuc.Text = entity.DinhMuc.Value.ToString();
        }

        public void Clear()
        {
            txtMaDon.Text = "";
            txtMaDonToMoi.Text = "";

            cmbLD.SelectedIndex = -1;
            txtMaDonToCu.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";
            
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDienThoai.Text = "";

            _dontbc = null;
            _hoadon = null;
            _MaDonTo = -1;
        }

        private void txtMaDonTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDonToCu.Text.Trim() != "")
            {
                string MaDon = "";
                if (txtMaDonToCu.Text.Trim().ToUpper().Contains("TBC"))
                    MaDon = txtMaDonToCu.Text.Trim().Substring(3).Replace("-", "");
                else
                    MaDon = txtMaDonToCu.Text.Trim().Replace("-", "");
                if (_cDonTBC.CheckExist(decimal.Parse(MaDon)) == true)
                {
                    _dontbc = _cDonTBC.Get(decimal.Parse(MaDon));
                    LoadDonTBC(_dontbc);
                }
                else
                {
                    MessageBox.Show("Mã Đơn TBC này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11 && e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_hoadon != null)
                {
                    LoadTTKH(_hoadon);
                    
                    //if (dgvLichSuDon.RowCount > 0)
                    //    dgvLichSuDon.Sort(dgvLichSuDon.Columns["CreateDate"], ListSortDirection.Descending);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (txtDanhBo.Text.Trim().Replace(" ", "") != "" && _cDonTBC.CheckExist(txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now) == true)
                        {
                            if (MessageBox.Show("Danh Bộ này đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                        }

                        DonTBC dontbc = new DonTBC();

                        //dontbc.MaDon = _cDonTBC.getMaxNextID();
                        dontbc.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        dontbc.SoCongVan = txtSoCongVan.Text.Trim();
                        dontbc.NoiDung = txtNoiDung.Text.Trim();

                        dontbc.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        dontbc.HopDong = txtHopDong.Text.Trim();
                        dontbc.HoTen = txtHoTen.Text.Trim();
                        dontbc.DiaChi = txtDiaChi.Text.Trim();
                        dontbc.DienThoai = txtDienThoai.Text.Trim();
                        if (txtGiaBieu.Text.Trim() != "")
                            dontbc.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (txtDinhMuc.Text.Trim() != "")
                            dontbc.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (_hoadon != null)
                        {
                            dontbc.Dot = _hoadon.DOT.ToString();
                            dontbc.Ky = _hoadon.KY.ToString();
                            dontbc.Nam = _hoadon.NAM.ToString();
                            dontbc.MLT = _hoadon.MALOTRINH;
                            dontbc.Phuong = _hoadon.Phuong;
                            dontbc.Quan = _hoadon.Quan;
                        }

                        _cDonTBC.beginTransaction();
                        if (_cDonTBC.Them(dontbc))
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
                                                //LichSuChuyenKTXM lichsuchuyenkt = new LichSuChuyenKTXM();
                                                //lichsuchuyenkt.NgayChuyen = dateChuyen.Value;
                                                //lichsuchuyenkt.NguoiDi = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                //lichsuchuyenkt.GhiChuChuyen = txtGhiChu.Text.Trim();
                                                //lichsuchuyenkt.MaDonTBC = dontbc.MaDon;
                                                //_cLichSuDonTu.Them(lichsuchuyenkt);

                                                dontbc.NguoiDi_KTXM = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                dontbc.NgayChuyen_KTXM = dateChuyen.Value;
                                                dontbc.GhiChuChuyen_KTXM = txtGhiChu.Text.Trim();
                                                _cDonTBC.Sua(dontbc);
                                            }
                                            LichSuDonTu entity = new LichSuDonTu();
                                            entity.NgayChuyen = dateChuyen.Value;
                                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                            entity.NoiChuyen = cmbNoiChuyen.Text;
                                            entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                            entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                            entity.GhiChu = txtGhiChu.Text.Trim();
                                            entity.MaDonTBC = dontbc.MaDon;
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
                                        entity.MaDonTBC = dontbc.MaDon;
                                        _cLichSuDonTu.Them(entity);
                                    }
                                }
                                ///không có nơi chọn nơi nhận
                                else
                                {
                                    LichSuDonTu entity = new LichSuDonTu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.GhiChu = txtGhiChu.Text.Trim();
                                    entity.MaDonTBC = dontbc.MaDon;
                                    _cLichSuDonTu.Them(entity);
                                }

                            _cDonTBC.commitTransaction();
                            MessageBox.Show("Thành công/n Mã Đơn: TBC" + dontbc.MaDon.ToString().Insert(dontbc.MaDon.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _cDonTBC.rollback();
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
                    if (_dontbc != null)
                    {
                        _dontbc.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        _dontbc.SoCongVan = txtSoCongVan.Text.Trim();
                        if (_hoadon != null && _dontbc.DanhBo != txtDanhBo.Text.Trim().Replace(" ", ""))
                        {
                            _dontbc.Dot = _hoadon.DOT.ToString();
                            _dontbc.Ky = _hoadon.KY.ToString();
                            _dontbc.Nam = _hoadon.NAM.ToString();
                            _dontbc.MLT = _hoadon.MALOTRINH;
                        }
                        _dontbc.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        _dontbc.HopDong = txtHopDong.Text.Trim();
                        _dontbc.HoTen = txtHoTen.Text.Trim();
                        _dontbc.DiaChi = txtDiaChi.Text.Trim();
                        _dontbc.DienThoai = txtDienThoai.Text.Trim();
                        if (txtGiaBieu.Text.Trim() != "")
                            _dontbc.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (txtDinhMuc.Text.Trim() != "")
                            _dontbc.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        _dontbc.NoiDung = txtNoiDung.Text.Trim();

                        if (_cDonTBC.Sua(_dontbc))
                        {
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_dontbc != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cDonTBC.Xoa(_dontbc))
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
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLD.SelectedIndex != -1)
            {
                //txtMaDon.Text = "TXL" + _cDonTXL.getMaxNextID().ToString().Insert(_cDonTXL.getMaxNextID().ToString().Length - 2, "-");
                txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void cmbNoiChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirst == true)
            {
                if (cmbNoiChuyen.SelectedIndex != -1)
                {
                    switch (cmbNoiChuyen.SelectedValue.ToString())
                    {
                        case "1"://Kiểm Tra Xác Minh
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["1"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "2"://Tổ Khách Hàng
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["2"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "3"://Tổ Xử Lý
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["3"];
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
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "6"://Phòng Ban Đội Khác
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["6"];
                            chkcmbNoiNhan.Properties.DisplayMember = "Name";
                            chkcmbNoiNhan.Properties.ValueMember = "ID";
                            break;
                        case "9"://Tiến Trình
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["9"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        default:
                            chkcmbNoiNhan.Properties.DataSource = null;
                            break;
                    }
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_dontbc != null)
                    {
                        bool flag = false;//ghi nhận có chọn checkcombobox
                        if (chkcmbNoiNhan.Properties.Items.Count > 0)
                        {
                            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                {
                                    if (cmbNoiChuyen.SelectedValue.ToString() == "1")///KTXM
                                    {
                                        //LichSuChuyenKTXM lichsuchuyenkt = new LichSuChuyenKTXM();
                                        //lichsuchuyenkt.NgayChuyen = dateChuyen.Value;
                                        //lichsuchuyenkt.NguoiDi = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        //lichsuchuyenkt.GhiChuChuyen = txtGhiChu.Text.Trim();
                                        //lichsuchuyenkt.MaDonTBC = _dontbc.MaDon;
                                        //_cLichSuDonTu.Them(lichsuchuyenkt);

                                        _dontbc.NguoiDi_KTXM = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        _dontbc.NgayChuyen_KTXM = dateChuyen.Value;
                                        _dontbc.GhiChuChuyen_KTXM = txtGhiChu.Text.Trim();
                                        _cDonTBC.Sua(_dontbc);
                                    }
                                    LichSuDonTu entity = new LichSuDonTu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.GhiChu = txtGhiChu.Text.Trim();
                                    entity.MaDonTBC = _dontbc.MaDon;
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
                                entity.MaDonTBC = _dontbc.MaDon;
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
                            entity.MaDonTBC = _dontbc.MaDon;
                            _cLichSuDonTu.Them(entity);
                        }
                        dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TBC", _dontbc.MaDon);
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

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_cLichSuDonTu.Xoa(_cLichSuDonTu.Get(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()))))
                {
                    dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TBC", _dontbc.MaDon);
                }
            }
        }

        private void btnNhapNhieuDB_Click(object sender, EventArgs e)
        {
            frmNhapNhieuDBTBC frm = new frmNhapNhieuDBTBC();
            frm.ShowDialog();
        }

        private void dgvLichSuDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuDon.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvLichSuDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvLichSuDon.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                if (dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().ToUpper().Contains("TKH"))
                {
                    frmNhanDonTKH frm = new frmNhanDonTKH(decimal.Parse(dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().Substring(3)));
                    frm.ShowDialog();
                }
                else
                    if (dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().ToUpper().Contains("TXL"))
                    {
                        frmNhanDonTXL frm = new frmNhanDonTXL(decimal.Parse(dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().Substring(3)));
                        frm.ShowDialog();
                    }
                    else

                        if (dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().ToUpper().Contains("TBC"))
                        {
                            frmNhanDonTBC frm = new frmNhanDonTBC(decimal.Parse(dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().Substring(3)));
                            frm.ShowDialog();
                        }
            }
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
            if (e.Button == MouseButtons.Right && (_dontbc != null))
            {
                contextMenuStrip1.Show(dgvLichSuDonTu, new Point(e.X, e.Y));
            }
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                //if (_cDonTu.CheckExist(int.Parse(txtMaDon.Text.Trim())) == true)
                //{
                //    _dontu = _cDonTu.getDonTu(int.Parse(txtMaDon.Text.Trim()));
                //    LoadDonTu(_dontu);
                //}
                //else
                //{
                //    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Clear();
                //}
            }
        }
        
    }
}
