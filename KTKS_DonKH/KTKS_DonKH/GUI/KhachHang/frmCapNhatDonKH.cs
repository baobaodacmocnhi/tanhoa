using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmCapNhatDonKH : Form
    {
        string _mnu = "mnuCapNhatDon";
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        DonKH _donkh = new DonKH();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();
        bool _flagFirst = false;

        public frmCapNhatDonKH()
        {
            InitializeComponent();
        }

        private void frmCapNhatDonKH_Load(object sender, EventArgs e)
        {
            dgvLichSuChuyenKT.AutoGenerateColumns = false;
            dgvLichSuDonTu.AutoGenerateColumns = false;

            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon();
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            cmbNguoiDi.DataSource = _cTaiKhoan.LoadDSTaiKhoanTKH();
            cmbNguoiDi.DisplayMember = "HoTen";
            cmbNguoiDi.ValueMember = "MaU";
            cmbNguoiDi.SelectedIndex = -1;

            cmbVanPhong.DataSource = _cTaiKhoan.LoadDSTaiKhoanTVP();
            cmbVanPhong.DisplayMember = "HoTen";
            cmbVanPhong.ValueMember = "MaU";
            cmbVanPhong.SelectedIndex = -1;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS();
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.SelectedIndex = -1;

            _flagFirst = true;
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";
            txtTongSoDanhBo.Text = "1";

            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtMSThue.Text = "";
            //cmbNVKiemTra.SelectedIndex = 0;

            chkChuyenKT.Checked = false;
            dateChuyenKT.Value = DateTime.Now;
            cmbNguoiDi.SelectedIndex = -1;
            chkDM.Checked = false;
            chkCCDM.Checked = false;
            chkSTGB.Checked = false;
            chkKTTT.Checked = false;

            chkChuyenVanPhong.Checked = false;
            dateChuyenVanPhong.Value = DateTime.Now;
            cmbVanPhong.SelectedIndex = -1;

            chkXepDon.Checked = false;
            dateXepDon.Value = DateTime.Now;
            txtGhiChuXepDon.Text = "";

            chkChuyenBanDoiKhac.Checked = false;
            dateChuyenBanDoiKhac.Value = DateTime.Now;
            txtGhiChuChuyenBanDoiKhac.Text = "";

            chkChuyenToXuLy.Checked = false;
            dateChuyenToXuLy.Value = DateTime.Now;
            txtGhiChuChuyenToXuLy.Text = "";

            chkChuyenKhac.Checked = false;
            dateChuyenKhac.Value = DateTime.Now;
            txtGhiChuChuyenKhac.Text = "";
        }

        public void LoadLichSuChuyen(decimal MaDon)
        {
            DataTable dt = _cDonTXL.LoadDSLichSuChuyenKTbyMaDonTKH(MaDon);

            foreach (DataRow item in dt.Rows)
            {
                LichSuChuyenKT ls = _cDonTXL.getLichSuChuyenKTbyID(decimal.Parse(item["MaLSChuyen"].ToString()));
                string ChiTiet = "";
                if (ls.DM)
                {
                    if (ChiTiet == "")
                        ChiTiet += "ĐM";
                    else
                        ChiTiet += ",ĐM";
                }
                if (ls.CCDM)
                {
                    if (ChiTiet == "")
                        ChiTiet += "CCĐM";
                    else
                        ChiTiet += ",CCĐM";
                }
                if (ls.STGB)
                {
                    if (ChiTiet == "")
                        ChiTiet += "STGB";
                    else
                        ChiTiet += ",STGB";
                }
                if (ls.KTTT)
                {
                    if (ChiTiet == "")
                        ChiTiet += "TT";
                    else
                        ChiTiet += ",TT";
                }
                item["ChiTiet"] = ChiTiet;
            }

            dt.Merge(_cDonKH.LoadDSLichSuChuyenVanPhongbyMaDonTKH(MaDon));
            dt.Merge(_cDonKH.LoadDSLichSuChuyenBanDoiKhacbyMaDonTKH(MaDon));
            dt.Merge(_cDonKH.LoadDSLichSuChuyenKhacbyMaDonTKH(MaDon));
            if (_donkh.ChuyenToXuLy)
            {
                if (dt.Rows.Count == 0)
                {
                    DataColumn col = new DataColumn();
                    col.ColumnName = "NgayChuyen";
                    col.DataType = System.Type.GetType("System.String");

                    DataColumn col2 = new DataColumn();
                    col2.ColumnName = "LoaiChuyen";
                    col2.DataType = System.Type.GetType("System.String");

                    DataColumn col3 = new DataColumn();
                    col3.ColumnName = "GhiChuChuyen";
                    col3.DataType = System.Type.GetType("System.String");

                    dt.Columns.Add(col);
                    dt.Columns.Add(col2);
                    dt.Columns.Add(col3);

                    DataRow dr = dt.NewRow();
                    dr["NgayChuyen"] = _donkh.NgayChuyenToXuLy.Value.ToString("dd/MM/yyyy");
                    dr["LoaiChuyen"] = "TXL";
                    dr["GhiChuChuyen"] = _donkh.GhiChuChuyenToXuLy;

                    dt.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    //dr["Table"] = "";
                    //dr["MaLSChuyen"] = "1";
                    dr["NgayChuyen"] = _donkh.NgayChuyenToXuLy.Value.ToString("dd/MM/yyyy");
                    dr["LoaiChuyen"] = "TXL";
                    dr["GhiChuChuyen"] = _donkh.GhiChuChuyenToXuLy;
                    //dr["NguoiDi"] = "";
                    //dr["ChiTiet"] = "";

                    dt.Rows.Add(dr);
                }
            }
            if (_donkh.XepDon)
            {
                if (dt.Rows.Count == 0)
                {
                    DataColumn col = new DataColumn();
                    col.ColumnName = "NgayChuyen";
                    col.DataType = System.Type.GetType("System.String");

                    DataColumn col2 = new DataColumn();
                    col2.ColumnName = "LoaiChuyen";
                    col2.DataType = System.Type.GetType("System.String");

                    DataColumn col3 = new DataColumn();
                    col3.ColumnName = "GhiChuChuyen";
                    col3.DataType = System.Type.GetType("System.String");

                    dt.Columns.Add(col);
                    dt.Columns.Add(col2);
                    dt.Columns.Add(col3);

                    DataRow dr = dt.NewRow();
                    dr["NgayChuyen"] = _donkh.NgayXepDon.Value.ToString("dd/MM/yyyy");
                    dr["LoaiChuyen"] = "Xếp Đơn";
                    dr["GhiChuChuyen"] = _donkh.GhiChuXepDon;

                    dt.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    //dr["Table"] = "";
                    //dr["MaLSChuyen"] = "1";
                    dr["NgayChuyen"] = _donkh.NgayXepDon.Value.ToString("dd/MM/yyyy");
                    dr["LoaiChuyen"] = "Xếp Đơn";
                    dr["GhiChuChuyen"] = _donkh.GhiChuXepDon;
                    //dr["NguoiDi"] = "";
                    //dr["ChiTiet"] = "";

                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
                dt.DefaultView.Sort = "NgayChuyen desc";
            dgvLichSuChuyenKT.DataSource = dt;
        }

        private void btnNhapNhieuDB_Click(object sender, EventArgs e)
        {
            frmNhapNhieuDBTKH frm = new frmNhapNhieuDBTKH();
            frm.ShowDialog();
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                {
                    _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));

                    cmbLD.SelectedValue = _donkh.MaLD.Value;
                    txtSoCongVan.Text = _donkh.SoCongVan;
                    if (_donkh.TongSoDanhBo != null)
                        txtTongSoDanhBo.Text = _donkh.TongSoDanhBo.Value.ToString();
                    txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                    txtNgayNhan.Text = _donkh.CreateDate.Value.ToString("dd/MM/yyyy");
                    txtNoiDung.Text = _donkh.NoiDung;
                    //txtMaXepDon.Text = _donkh.MaXepDon.ToString().Insert(_donkh.MaXepDon.ToString().Length - 2, "-") + "/" + _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));

                    txtDanhBo.Text = _donkh.DanhBo;
                    txtHopDong.Text = _donkh.HopDong;
                    txtDienThoai.Text = _donkh.DienThoai;
                    txtHoTen.Text = _donkh.HoTen;
                    txtDiaChi.Text = _donkh.DiaChi;
                    txtGiaBieu.Text = _donkh.GiaBieu;
                    txtDinhMuc.Text = _donkh.DinhMuc;
                    //cmbNVKiemTra.Text = _donkh.GhiChuNguoiDi;
                    ///
                    LoadLichSuChuyen(_donkh.MaDon);
                    dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS(false, _donkh.MaDon);
                    ///
                    if (_donkh.ChuyenKT)
                    {
                        chkChuyenKT.Checked = true;
                        dateChuyenKT.Value = _donkh.NgayChuyenKT.Value;
                        cmbNguoiDi.SelectedValue = _donkh.NguoiDi;
                        chkDM.Checked = _donkh.DM;
                        chkCCDM.Checked = _donkh.CCDM;
                        chkSTGB.Checked = _donkh.STGB;
                        chkKTTT.Checked = _donkh.KTTT;
                        txtGhiChuChuyenKT.Text = _donkh.GhiChuChuyenKT;
                    }
                    else
                    {
                        chkChuyenKT.Checked = false;
                        dateChuyenKT.Value = DateTime.Now;
                        cmbNguoiDi.SelectedIndex = -1;
                        chkDM.Checked = false;
                        chkCCDM.Checked = false;
                        chkSTGB.Checked = false;
                        chkKTTT.Checked = false;
                        txtGhiChuChuyenKT.Text = "";
                    }

                    if (_donkh.ChuyenVanPhong)
                    {
                        chkChuyenVanPhong.Checked = true;
                        dateChuyenVanPhong.Value = _donkh.NgayChuyenVanPhong.Value;
                        cmbVanPhong.SelectedValue = _donkh.NguoiVanPhong;
                        txtGhiChuChuyenVanPhong.Text = _donkh.GhiChuChuyenVanPhong;
                    }
                    else
                    {
                        chkChuyenVanPhong.Checked = false;
                        dateChuyenVanPhong.Value = DateTime.Now;
                        cmbVanPhong.SelectedIndex = -1;
                        txtGhiChuChuyenVanPhong.Text = "";
                    }

                    if (_donkh.ChuyenBanDoiKhac)
                    {
                        chkChuyenBanDoiKhac.Checked = true;
                        dateChuyenBanDoiKhac.Value = _donkh.NgayChuyenBanDoiKhac.Value;
                        txtGhiChuChuyenBanDoiKhac.Text = _donkh.GhiChuChuyenBanDoiKhac;
                    }
                    else
                    {
                        chkChuyenBanDoiKhac.Checked = false;
                        dateChuyenBanDoiKhac.Value = DateTime.Now;
                        txtGhiChuChuyenBanDoiKhac.Text = "";
                    }

                    if (_donkh.ChuyenToXuLy)
                    {
                        chkChuyenToXuLy.Checked = true;
                        dateChuyenToXuLy.Value = _donkh.NgayChuyenToXuLy.Value;
                        txtGhiChuChuyenToXuLy.Text = _donkh.GhiChuChuyenToXuLy;
                    }
                    else
                    {
                        chkChuyenToXuLy.Checked = false;
                        dateChuyenToXuLy.Value = DateTime.Now;
                        txtGhiChuChuyenToXuLy.Text = "";
                    }

                    if (_donkh.ChuyenKhac)
                    {
                        chkChuyenKhac.Checked = true;
                        dateChuyenKhac.Value = _donkh.NgayChuyenKhac.Value;
                        txtGhiChuChuyenKhac.Text = _donkh.GhiChuChuyenKhac;
                    }
                    else
                    {
                        chkChuyenKhac.Checked = false;
                        dateChuyenKhac.Value = DateTime.Now;
                        txtGhiChuChuyenKhac.Text = "";
                    }

                    if (_donkh.XepDon)
                    {
                        chkXepDon.Checked = true;
                        dateXepDon.Value = _donkh.NgayXepDon.Value;
                        txtGhiChuXepDon.Text = _donkh.GhiChuXepDon;
                    }
                    else
                    {
                        chkXepDon.Checked = false;
                        dateXepDon.Value = DateTime.Now;
                        txtGhiChuXepDon.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (_donkh != null)
                {
                    bool flagSuaChuyenKT = false;
                    bool flagSuaChuyenVP = false;
                    bool flagSuaChuyenBDK = false;
                    bool flagSuaChuyenK = false;
                    if (chkChuyenKT.Checked)
                    {
                        _donkh.ChuyenKT = true;
                        if (_donkh.NgayChuyenKT != dateChuyenKT.Value || _donkh.NguoiDi != int.Parse(cmbNguoiDi.SelectedValue.ToString()) || (_donkh.GhiChuChuyenKT != null && _donkh.GhiChuChuyenKT != txtGhiChuChuyenKT.Text.Trim()))
                            flagSuaChuyenKT = true;
                        _donkh.NgayChuyenKT = dateChuyenKT.Value;
                        if (cmbNguoiDi.SelectedIndex != -1)
                            _donkh.NguoiDi = int.Parse(cmbNguoiDi.SelectedValue.ToString());
                        _donkh.DM = chkDM.Checked;
                        _donkh.CCDM = chkCCDM.Checked;
                        _donkh.STGB = chkSTGB.Checked;
                        _donkh.KTTT = chkKTTT.Checked;
                        _donkh.GhiChuChuyenKT = txtGhiChuChuyenKT.Text.Trim();
                    }
                    else
                    {
                        _donkh.ChuyenKT = false;
                        _donkh.NgayChuyenKT = null;
                        _donkh.NguoiDi = null;
                        _donkh.DM = false;
                        _donkh.CCDM = false;
                        _donkh.STGB = false;
                        _donkh.KTTT = false;
                        _donkh.GhiChuChuyenKT = null;
                    }

                    if (chkChuyenVanPhong.Checked)
                    {
                        _donkh.ChuyenVanPhong = true;
                        if (_donkh.NgayChuyenVanPhong != dateChuyenVanPhong.Value || _donkh.NguoiVanPhong != int.Parse(cmbVanPhong.SelectedValue.ToString()) || _donkh.GhiChuChuyenVanPhong != txtGhiChuChuyenVanPhong.Text.Trim())
                            flagSuaChuyenVP = true;
                        _donkh.NgayChuyenVanPhong = dateChuyenVanPhong.Value;
                        if (cmbVanPhong.SelectedIndex != -1)
                            _donkh.NguoiVanPhong = int.Parse(cmbVanPhong.SelectedValue.ToString());
                        _donkh.GhiChuChuyenVanPhong = txtGhiChuChuyenVanPhong.Text.Trim();
                    }
                    else
                    {
                        _donkh.ChuyenVanPhong = false;
                        _donkh.NgayChuyenVanPhong = null;
                        _donkh.NguoiVanPhong = null;
                        _donkh.GhiChuChuyenVanPhong = null;
                    }

                    if (chkChuyenBanDoiKhac.Checked)
                    {
                        _donkh.ChuyenBanDoiKhac = true;
                        if (_donkh.NgayChuyenBanDoiKhac != dateChuyenBanDoiKhac.Value || _donkh.GhiChuChuyenBanDoiKhac != txtGhiChuChuyenBanDoiKhac.Text.Trim())
                            flagSuaChuyenBDK = true;
                        _donkh.NgayChuyenBanDoiKhac = dateChuyenBanDoiKhac.Value;
                        _donkh.GhiChuChuyenBanDoiKhac = txtGhiChuChuyenBanDoiKhac.Text.Trim();
                    }
                    else
                    {
                        _donkh.ChuyenBanDoiKhac = false;
                        _donkh.NgayChuyenBanDoiKhac = null;
                        _donkh.GhiChuChuyenBanDoiKhac = null;
                    }

                    if (chkChuyenToXuLy.Checked)
                    {
                        _donkh.ChuyenToXuLy = true;
                        _donkh.NgayChuyenToXuLy = dateChuyenToXuLy.Value;
                        _donkh.GhiChuChuyenToXuLy = txtGhiChuChuyenToXuLy.Text.Trim();

                        LichSuDonTu entity = new LichSuDonTu();
                        entity.NgayChuyen = dateChuyenToXuLy.Value;
                        entity.NoiChuyen = "Tổ Xử Lý";
                        entity.GhiChu = txtGhiChuChuyenToXuLy.Text.Trim();
                        entity.MaDon = _donkh.MaDon;
                        _cLichSuDonTu.Them(entity);
                    }
                    else
                    {
                        _donkh.ChuyenToXuLy = false;
                        _donkh.NgayChuyenToXuLy = null;
                        _donkh.GhiChuChuyenToXuLy = null;
                    }

                    if (chkChuyenKhac.Checked)
                    {
                        _donkh.ChuyenKhac = true;
                        if (_donkh.NgayChuyenKhac != dateChuyenKhac.Value || _donkh.GhiChuChuyenKhac != txtGhiChuChuyenKhac.Text.Trim())
                            flagSuaChuyenK = true;
                        _donkh.NgayChuyenKhac = dateChuyenKhac.Value;
                        _donkh.GhiChuChuyenKhac = txtGhiChuChuyenKhac.Text.Trim();
                    }
                    else
                    {
                        _donkh.ChuyenKhac = false;
                        _donkh.NgayChuyenKhac = null;
                        _donkh.GhiChuChuyenKhac = null;
                    }

                    if (chkXepDon.Checked)
                    {
                        _donkh.XepDon = true;
                        _donkh.NgayXepDon = dateXepDon.Value;
                        _donkh.GhiChuXepDon = txtGhiChuXepDon.Text.Trim();

                        LichSuDonTu entity = new LichSuDonTu();
                        entity.NgayChuyen = dateXepDon.Value;
                        entity.NoiChuyen = "Xếp Đơn";
                        entity.GhiChu = txtGhiChuXepDon.Text.Trim();
                        entity.MaDon = _donkh.MaDon;
                        _cLichSuDonTu.Them(entity);
                    }
                    else
                    {
                        _donkh.XepDon = false;
                        _donkh.NgayXepDon = null;
                        _donkh.GhiChuXepDon = null;
                    }

                    if (_cDonKH.SuaDonKH(_donkh))
                    {
                        if (flagSuaChuyenKT)
                        {
                            LichSuChuyenKT lichsuchuyenkt = new LichSuChuyenKT();
                            lichsuchuyenkt.NgayChuyen = _donkh.NgayChuyenKT;
                            lichsuchuyenkt.NguoiDi = _donkh.NguoiDi;
                            lichsuchuyenkt.DM = _donkh.DM;
                            lichsuchuyenkt.CCDM = _donkh.CCDM;
                            lichsuchuyenkt.STGB = _donkh.STGB;
                            lichsuchuyenkt.KTTT = _donkh.KTTT;
                            lichsuchuyenkt.GhiChuChuyen = _donkh.GhiChuChuyenKT;
                            lichsuchuyenkt.MaDon = _donkh.MaDon;
                            _cDonTXL.ThemLichSuChuyenKT(lichsuchuyenkt);
                            flagSuaChuyenKT = false;

                            LichSuDonTu entity = new LichSuDonTu();
                            entity.NgayChuyen = dateChuyenKT.Value;
                            entity.NoiChuyen = "Kiểm Tra Xác Minh";
                            entity.ID_NoiNhan = _donkh.NguoiDi.Value;
                            entity.NoiNhan = _cTaiKhoan.getHoTenUserbyID(_donkh.NguoiDi.Value);
                            entity.GhiChu = txtGhiChuChuyenKT.Text.Trim();
                            entity.MaDon = _donkh.MaDon;
                            _cLichSuDonTu.Them(entity);
                        }
                        if (flagSuaChuyenVP)
                        {
                            LichSuChuyenVanPhong lichsuchuyenvanphong = new LichSuChuyenVanPhong();
                            lichsuchuyenvanphong.NgayChuyen = _donkh.NgayChuyenVanPhong;
                            lichsuchuyenvanphong.NguoiDi = _donkh.NguoiVanPhong;
                            lichsuchuyenvanphong.GhiChuChuyen = _donkh.GhiChuChuyenVanPhong;
                            lichsuchuyenvanphong.MaDon = _donkh.MaDon;
                            _cDonKH.ThemLichSuChuyenVanPhong(lichsuchuyenvanphong);
                            flagSuaChuyenVP = false;

                            LichSuDonTu entity = new LichSuDonTu();
                            entity.NgayChuyen = dateChuyenVanPhong.Value;
                            entity.NoiChuyen = "Tổ Văn Phòng";
                            entity.ID_NoiNhan = _donkh.NguoiVanPhong.Value;
                            entity.NoiNhan = _cTaiKhoan.getHoTenUserbyID(_donkh.NguoiVanPhong.Value);
                            entity.GhiChu = txtGhiChuChuyenVanPhong.Text.Trim();
                            entity.MaDon = _donkh.MaDon;
                            _cLichSuDonTu.Them(entity);
                        }
                        if (flagSuaChuyenBDK)
                        {
                            LichSuChuyenBanDoiKhac lichsuchuyenbandoikhac = new LichSuChuyenBanDoiKhac();
                            lichsuchuyenbandoikhac.NgayChuyen = _donkh.NgayChuyenBanDoiKhac;
                            lichsuchuyenbandoikhac.GhiChuChuyen = _donkh.GhiChuChuyenBanDoiKhac;
                            lichsuchuyenbandoikhac.MaDon = _donkh.MaDon;
                            _cDonKH.ThemLichSuChuyenBanDoiKhac(lichsuchuyenbandoikhac);
                            flagSuaChuyenBDK = false;

                            LichSuDonTu entity = new LichSuDonTu();
                            entity.NgayChuyen = dateChuyenBanDoiKhac.Value;
                            entity.NoiChuyen = "Ban Đội Khác";
                            entity.GhiChu = txtGhiChuChuyenBanDoiKhac.Text.Trim();
                            entity.MaDon = _donkh.MaDon;
                            _cLichSuDonTu.Them(entity);
                        }
                        if (flagSuaChuyenK)
                        {
                            LichSuChuyenKhac lichsuchuyenkhac = new LichSuChuyenKhac();
                            lichsuchuyenkhac.NgayChuyen = _donkh.NgayChuyenKhac;
                            lichsuchuyenkhac.GhiChuChuyen = _donkh.GhiChuChuyenKhac;
                            lichsuchuyenkhac.MaDon = _donkh.MaDon;
                            _cDonKH.ThemLichSuChuyenKhac(lichsuchuyenkhac);
                            flagSuaChuyenK = false;

                            LichSuDonTu entity = new LichSuDonTu();
                            entity.NgayChuyen = dateChuyenKhac.Value;
                            entity.NoiChuyen = "Khác";
                            entity.GhiChu = txtGhiChuChuyenKhac.Text.Trim();
                            entity.MaDon = _donkh.MaDon;
                            _cLichSuDonTu.Them(entity);
                        }
                        LoadLichSuChuyen(_donkh.MaDon);
                        MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvLichSuChuyenKT.CurrentRow.Cells["Table"].Value.ToString() == "LichSuChuyenKT")
                    if (_cDonTXL.XoaLichSuChuyenKT(_cDonTXL.getLichSuChuyenKTbyID(decimal.Parse(dgvLichSuChuyenKT.CurrentRow.Cells["MaLSChuyen"].Value.ToString()))))
                    {
                        LoadLichSuChuyen(_donkh.MaDon);
                    }
                if (dgvLichSuChuyenKT.CurrentRow.Cells["Table"].Value.ToString() == "LichSuChuyenVanPhong")
                    if (_cDonKH.XoaLichSuChuyenVanPhong(_cDonKH.getLichSuChuyenVanPhongbyID(decimal.Parse(dgvLichSuChuyenKT.CurrentRow.Cells["MaLSChuyen"].Value.ToString()))))
                    {
                        LoadLichSuChuyen(_donkh.MaDon);
                    }
                if (dgvLichSuChuyenKT.CurrentRow.Cells["Table"].Value.ToString() == "LichSuChuyenBanDoiKhac")
                    if (_cDonKH.XoaLichSuChuyenBanDoiKhac(_cDonKH.getLichSuChuyenBanDoiKhacbyID(decimal.Parse(dgvLichSuChuyenKT.CurrentRow.Cells["MaLSChuyen"].Value.ToString()))))
                    {
                        LoadLichSuChuyen(_donkh.MaDon);
                    }
                if (dgvLichSuChuyenKT.CurrentRow.Cells["Table"].Value.ToString() == "LichSuChuyenKhac")
                    if (_cDonKH.XoaLichSuChuyenKhac(_cDonKH.getLichSuChuyenKhacbyID(decimal.Parse(dgvLichSuChuyenKT.CurrentRow.Cells["MaLSChuyen"].Value.ToString()))))
                    {
                        LoadLichSuChuyen(_donkh.MaDon);
                    }
            }
        }

        private void chkChuyenKT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenKT.Checked)
            {
                groupBoxChuyenKTXM.Enabled = true;
                cmbNguoiDi.SelectedIndex = 0;
            }
            else
            {
                groupBoxChuyenKTXM.Enabled = false;
            }
        }

        private void chkChuyenVanPhong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenVanPhong.Checked)
            {
                groupBoxChuyenVanPhong.Enabled = true;
                cmbVanPhong.SelectedValue = 8;
            }
            else
            {
                groupBoxChuyenVanPhong.Enabled = false;
                cmbVanPhong.SelectedIndex = -1;
            }
        }

        private void chkChuyenBanDoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenBanDoiKhac.Checked)
            {
                groupBoxChuyenBanDoiKhac.Enabled = true;
            }
            else
            {
                groupBoxChuyenBanDoiKhac.Enabled = false;
            }
        }

        private void chkChuyenToXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenToXuLy.Checked)
            {
                groupBoxChuyenToXuLy.Enabled = true;
            }
            else
            {
                groupBoxChuyenToXuLy.Enabled = false;
            }
        }

        private void chkChuyenKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenKhac.Checked)
            {
                groupBoxChuyenKhac.Enabled = true;
            }
            else
            {
                groupBoxChuyenKhac.Enabled = false;
            }
        }

        private void dgvLichSuChuyenKT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvLichSuChuyenKT.CurrentCell = dgvLichSuChuyenKT.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvLichSuChuyenKT_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_donkh != null))
            {
                contextMenuStrip1.Show(dgvLichSuChuyenKT, new Point(e.X, e.Y));
            }
        }

        private void chkXepDon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXepDon.Checked)
            {
                groupBoxXepDon.Enabled = true;
            }
            else
            {
                groupBoxXepDon.Enabled = false;
            }
        }

        private void cmbNguoiDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkDM.Checked = false;
            chkCCDM.Checked = false;
            chkSTGB.Checked = false;
            chkKTTT.Checked = false;
        }

        private void cmbNoiChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirst&&cmbNoiChuyen.Items.Count > 0)
                switch (cmbNoiChuyen.SelectedValue.ToString())
                {
                    case "1"://Kiểm Tra Xác Minh
                        chkcmbNoiNhan.Properties.DataSource = _cTaiKhoan.GetDS_KTXM_TKH();
                        chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                        chkcmbNoiNhan.Properties.ValueMember = "MaU";

                        break;
                    case "2"://Tổ Khách Hàng
                        chkcmbNoiNhan.Properties.DataSource = _cTaiKhoan.GetDS_TKH();
                        chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                        chkcmbNoiNhan.Properties.ValueMember = "MaU";
                        break;
                    case "3"://Tổ Xử Lý
                        chkcmbNoiNhan.Properties.DataSource = _cTaiKhoan.GetDS_TXL();
                        chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                        chkcmbNoiNhan.Properties.ValueMember = "MaU";
                        break;
                    case "4"://Tổ Văn Phòng
                        chkcmbNoiNhan.Properties.DataSource = _cTaiKhoan.GetDS_TVP();
                        chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                        chkcmbNoiNhan.Properties.ValueMember = "MaU";
                        break;
                    case "5"://Phòng Ban Đội Khác
                        chkcmbNoiNhan.Properties.DataSource = _cPhongBanDoi.GetDS();
                        chkcmbNoiNhan.Properties.DisplayMember = "Name";
                        chkcmbNoiNhan.Properties.ValueMember = "ID";
                        break;
                    default:
                        chkcmbNoiNhan.Properties.DataSource = null;
                        chkcmbNoiNhan.Properties.Items.Clear();
                        break;
                }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
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
                            lichsuchuyenkt.MaDon = _donkh.MaDon;
                            _cDonTXL.ThemLichSuChuyenKT(lichsuchuyenkt);
                        }
                        LichSuDonTu entity = new LichSuDonTu();
                        entity.NgayChuyen = dateChuyen.Value;
                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                        entity.NoiChuyen = cmbNoiChuyen.Text;
                        entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                        entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                        entity.GhiChu = txtGhiChu.Text.Trim();
                        entity.MaDon = _donkh.MaDon;
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
                entity.MaDon = _donkh.MaDon;
                _cLichSuDonTu.Them(entity);
            }
            dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS(false, _donkh.MaDon);

        }
    }
}
