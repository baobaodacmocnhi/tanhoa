using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.ToBamChi;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmCapNhatDonTKH : Form
    {
        string _mnu = "mnuCapNhatDon";
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();

        DataSet _dsNoiChuyen = new DataSet("NoiChuyen");
        LinQ.DonTu _dontu = null;
        DonKH _dontkh = null;
        HOADON _hoadon = null;
        bool _flagFirst = false;
        decimal _MaDonTo = -1;

        public frmCapNhatDonTKH()
        {
            InitializeComponent();
        }

        public frmCapNhatDonTKH(decimal MaDonTo)
        {
            InitializeComponent();
            _MaDonTo = MaDonTo;
        }

        private void frmCapNhatDonKH_Load(object sender, EventArgs e)
        {
            lbTruyThu.Text = "";
            dgvLichSuDonTu.AutoGenerateColumns = false;
            dgvLichSuDonTu_DCBD.AutoGenerateColumns = false;
            dgvLichSuDon.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;

            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon();
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("TKH");
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.SelectedIndex = -1;

            DataTable dt = new DataTable();
            dt = _cTaiKhoan.GetDS_KTXM("TKH");
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
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TVP");
            ///
            //DataRow dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Tổ Xử Lý";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Tổ Bấm Chì";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Tờ Trình Trình Phòng";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Trình Phòng Xem Xét";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Hẹn Định Mức 3 Ngày";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Hẹn Định Mức Nhà Trọ";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Hẹn Kiểm Định";
            //dt.Rows.Add(dr2);
            ///
            for (int i = 0; i < _dsNoiChuyen.Tables["6"].Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["MaU"] = _dsNoiChuyen.Tables["6"].Rows[i]["ID"];
                dr["HoTen"] = _dsNoiChuyen.Tables["6"].Rows[i]["Name"];
                dt.Rows.Add(dr);
            }
            DataTable dt2 = _cNoiChuyen.GetDS_CT(9);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["MaU"] = dt2.Rows[i]["ID"];
                dr["HoTen"] = dt2.Rows[i]["Name"];
                dt.Rows.Add(dr);
            }
            ///
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Khác";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Tiếp Kết";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Xếp Đơn";
            //dt.Rows.Add(dr2);
            dt.TableName = "9";//Tiến Trình
            _dsNoiChuyen.Tables.Add(dt);
            _flagFirst = true;
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

            //if (_cTTTN.CheckExist_ChuaXepDon(entity.DANHBA) == true)
            //    lbTruyThu.Text = "Danh Bộ này đang Truy Thu";
            //else
            //    lbTruyThu.Text = "";

            string str= _cTTTN.GetTinhTrang(entity.DANHBA);
            if (str != "")
                lbTruyThu.Text = "Tình Trạng Truy Thu: "+str;
            else
                lbTruyThu.Text = "";
        }

        public void LoadDonTKH(DonKH entity)
        {
            txtMaDonToMoi.Text = entity.MaDonMoi;

            cmbLD.SelectedValue = entity.MaLD.Value;
            txtSoCongVan.Text = entity.SoCongVan;
            txtMaDonToCu.Text = entity.MaDon.ToString().Insert(entity.MaDon.ToString().Length - 2, "-");
            txtNgayNhan.Text = entity.CreateDate.Value.ToString("dd/MM/yyyy");
            txtNoiDung.Text = entity.NoiDung;

            if (entity.DanhBo!=null&&entity.DanhBo.Length == 11)
                txtDanhBo.Text = entity.DanhBo.Insert(7, " ").Insert(4, " ");
            else
                txtDanhBo.Text = entity.DanhBo;
            txtHopDong.Text = entity.HopDong;
            txtDienThoai.Text = entity.DienThoai;
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            txtGiaBieu.Text = entity.GiaBieu;
            txtDinhMuc.Text = entity.DinhMuc;

            dgvLichSuDon.DataSource = _cLichSuDonTu.GetDS_3To(entity.DanhBo);
            dgvLichSuDonTu_DCBD.DataSource = _cLichSuDonTu.GetDS_DCBD(entity.DanhBo);

            dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TKH", entity.MaDon);
            //dataGridView1.DataSource = _cLichSuDonTu.GetDS_Old("TKH", entity.MaDon);
            dateChuyen.Value = DateTime.Now;
            cmbNoiChuyen.SelectedIndex = -1;
            txtGhiChu.Text = "";

            if (_cTTTN.CheckExist_ChuaXepDon(entity.DanhBo) == true)
            {
                lbTruyThu.Text = "Danh Bộ này đang Truy Thu";
                MessageBox.Show("Danh Bộ này đang Truy Thu", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            else
                lbTruyThu.Text = "";
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
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";

            _dontu = null;
            _dontkh = null;
            _hoadon = null;
            _MaDonTo = -1;
        }

        private void btnNhapNhieuDB_Click(object sender, EventArgs e)
        {
            frmNhapNhieuDBTKH frm = new frmNhapNhieuDBTKH();
            frm.ShowDialog();
        }

        private void txtMaDonTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDonToCu.Text.Trim() != "")
            {
                if (_cDonKH.CheckExist(decimal.Parse(txtMaDonToCu.Text.Trim().Replace("-", ""))) == true)
                {
                    _dontkh = _cDonKH.Get(decimal.Parse(txtMaDonToCu.Text.Trim().Replace("-", "")));
                    LoadDonTKH(_dontkh);
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_cLichSuDonTu.Xoa(_cLichSuDonTu.Get(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()))))
                {
                    dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TKH", _dontkh.MaDon);
                }
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
                    if (_dontkh != null)
                    {
                        if (chkcmbNoiNhan.Properties.Items.Count > 0)
                        {
                            bool flag = false;//ghi nhận có chọn checkcombobox
                            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                {
                                    if (cmbNoiChuyen.SelectedValue.ToString() == "1")///KTXM
                                    {
                                        //LichSuChuyenKTXM lichsuchuyenkt = new LichSuChuyenKTXM();
                                        //lichsuchuyenkt.NgayChuyen = dateChuyen.Value;
                                        //lichsuchuyenkt.NguoiDi = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        //lichsuchuyenkt.GhiChuChuyen = txtGhiChu.Text.Trim();
                                        //lichsuchuyenkt.MaDon = _donkh.MaDon;
                                        //_cLichSuDonTu.Them(lichsuchuyenkt);

                                        _dontkh.NguoiDi_KTXM = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        _dontkh.NgayChuyen_KTXM = dateChuyen.Value;
                                        _dontkh.GhiChuChuyen_KTXM = txtGhiChu.Text.Trim();
                                        _cDonKH.Sua(_dontkh);
                                    }
                                    LichSuDonTu entity = new LichSuDonTu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.GhiChu = txtGhiChu.Text.Trim();
                                    entity.MaDon = _dontkh.MaDon;
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
                                entity.MaDon = _dontkh.MaDon;
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
                            entity.MaDon = _dontkh.MaDon;
                            _cLichSuDonTu.Them(entity);
                        }
                        dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TKH", _dontkh.MaDon);
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
            if (e.Button == MouseButtons.Right && (_dontkh != null))
            {
                contextMenuStrip1.Show(dgvLichSuDonTu, new Point(e.X, e.Y));
            }
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

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11 && e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_hoadon != null)
                {
                    LoadTTKH(_hoadon);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (cmbLD.SelectedIndex != -1)
                    {
                        if (txtDanhBo.Text.Trim().Replace(" ", "") != "" && _cDonKH.CheckExist(txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now) == true)
                        {
                            if (MessageBox.Show("Danh Bộ này đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                        }

                        DonKH dontkh = new DonKH();

                        if (_dontu != null)
                        {
                            dontkh.MaDonCha = _dontu.MaDon;
                        }

                        dontkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        dontkh.SoCongVan = txtSoCongVan.Text.Trim();
                        dontkh.NoiDung = txtNoiDung.Text.Trim();

                        dontkh.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        dontkh.HopDong = txtHopDong.Text.Trim();
                        dontkh.HoTen = txtHoTen.Text.Trim();
                        dontkh.DiaChi = txtDiaChi.Text.Trim();
                        dontkh.DienThoai = txtDienThoai.Text.Trim();
                        dontkh.GiaBieu = txtGiaBieu.Text.Trim();
                        dontkh.DinhMuc = txtDinhMuc.Text.Trim();
                        if (_hoadon != null)
                        {
                            dontkh.Dot = _hoadon.DOT.ToString();
                            dontkh.Ky = _hoadon.KY.ToString();
                            dontkh.Nam = _hoadon.NAM.ToString();
                            dontkh.MLT = _hoadon.MALOTRINH;
                            dontkh.Phuong = _hoadon.Phuong;
                            dontkh.Quan = _hoadon.Quan;
                        }

                        _cDonKH.beginTransaction();
                        if (_cDonKH.Them(dontkh))
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
                                                LichSuChuyenKTXM lichsuchuyenkt = new LichSuChuyenKTXM();
                                                lichsuchuyenkt.NgayChuyen = dateChuyen.Value;
                                                lichsuchuyenkt.NguoiDi = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                lichsuchuyenkt.GhiChuChuyen = txtGhiChu.Text.Trim();
                                                lichsuchuyenkt.MaDon = dontkh.MaDon;
                                                _cLichSuDonTu.Them(lichsuchuyenkt);

                                                dontkh.NguoiDi_KTXM = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                dontkh.NgayChuyen_KTXM = dateChuyen.Value;
                                                dontkh.GhiChuChuyen_KTXM = txtGhiChu.Text.Trim();
                                                _cDonKH.Sua(dontkh);
                                            }
                                            LichSuDonTu entity = new LichSuDonTu();
                                            entity.NgayChuyen = dateChuyen.Value;
                                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                            entity.NoiChuyen = cmbNoiChuyen.Text;
                                            entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                            entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                            entity.GhiChu = txtGhiChu.Text.Trim();
                                            entity.MaDon = dontkh.MaDon;
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
                                        entity.MaDon = dontkh.MaDon;
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
                                    entity.MaDon = dontkh.MaDon;
                                    _cLichSuDonTu.Them(entity);
                                }

                            _cDonKH.commitTransaction();
                            MessageBox.Show("Thành công/n Mã Đơn: TKH" + dontkh.MaDon.ToString().Insert(dontkh.MaDon.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _cDonKH.rollback();
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
                    if (_dontkh != null)
                    {
                        _dontkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        _dontkh.SoCongVan = txtSoCongVan.Text.Trim();
                        if (_hoadon != null && _dontkh.DanhBo != txtDanhBo.Text.Trim().Replace(" ", ""))
                        {
                            _dontkh.Dot = _hoadon.DOT.ToString();
                            _dontkh.Ky = _hoadon.KY.ToString();
                            _dontkh.Nam = _hoadon.NAM.ToString();
                            _dontkh.MLT = _hoadon.MALOTRINH;
                            _dontkh.Phuong = _hoadon.Phuong;
                            _dontkh.Quan = _hoadon.Quan;
                        }
                        _dontkh.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        _dontkh.HopDong = txtHopDong.Text.Trim();
                        _dontkh.HoTen = txtHoTen.Text.Trim();
                        _dontkh.DiaChi = txtDiaChi.Text.Trim();
                        _dontkh.DienThoai = txtDienThoai.Text.Trim();
                        _dontkh.GiaBieu = txtGiaBieu.Text.Trim();
                        _dontkh.DinhMuc = txtDinhMuc.Text.Trim();
                        _dontkh.NoiDung = txtNoiDung.Text.Trim();

                        if (_cDonKH.Sua(_dontkh))
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
                    if (_dontkh != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cDonKH.Xoa(_dontkh))
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

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            //{
            //    if (_cDonTu.CheckExist(int.Parse(txtMaDon.Text.Trim())) == true)
            //    {
            //        _dontu = _cDonTu.getDonTu(int.Parse(txtMaDon.Text.Trim()));
            //        LoadDonTu(_dontu);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        Clear();
            //    }
            //}
        }

        private void dgvLichSuDonTu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //dateChuyen.Value = DateTime.Parse(dgvLichSuDonTu.CurrentRow.Cells["NgayChuyenA"].Value.ToString());
                //cmbNoiChuyen.SelectedValue = int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID_NoiChuyen"].Value.ToString());
                //if (dgvLichSuDonTu.CurrentRow.Cells["ID_NoiNhan"].Value!=null)
                //chkcmbNoiNhan.SetEditValue(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID_NoiNhan"].Value.ToString()));
            }
            catch (Exception)
            {
                
                
            }
        }


    }
}
