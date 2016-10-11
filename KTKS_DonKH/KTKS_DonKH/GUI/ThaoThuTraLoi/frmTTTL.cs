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
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThaoThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmTTTL : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CThuTien _cThuTien = new CThuTien();
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        HOADON _hoadon = null;
        CTTTTL _cttttl = null;
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CKTXM _cKTXM = new CKTXM();
        CTTTL _cTTTL = new CTTTL();
        CGhiChuCTTTTL _cGhiChuCTTTTL = new CGhiChuCTTTTL();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CVeViecTTTL _cVeViecTTTL = new CVeViecTTTL();
        bool _direct = false;///Mở form trực tiếp không qua Danh Sách Đơn
        //bool _flagTXL = false;
  
        public frmTTTL()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load Form trực tiếp không qua Danh Sách Đơn
        /// </summary>
        /// <param name="direct"></param>
        public frmTTTL(bool direct)
        {
            InitializeComponent();
            _direct = direct;
        }

        public frmTTTL(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        /// <summary>
        /// Nhận Entity TTKhachHang để điền vào textbox
        /// </summary>
        /// <param name="ttkhachhang"></param>
        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHopDong.Text = hoadon.HOPDONG;
            txtLoTrinh.Text = hoadon.DOT + hoadon.MAY + hoadon.STT;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cPhuongQuan.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            ///
            txtVeViec.Text = "";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            ///
            chkGiamNuocXaBo.Checked = false;
            chkKiemDinhDHN_Dung.Checked = false;
            chkKiemDinhDHN_Sai.Checked = false;
            chkThayDHN.Checked = false;
            chkDieuChinh_GB_DM.Checked = false;
            chkThuMoi.Checked = false;
            chkThuBao.Checked = false;
            _hoadon = null;
        }

        private void frmTTTL_Load(object sender, EventArgs e)
        {
            dgvLichSuTTTL.AutoGenerateColumns = false;
            dgvGhiChu.AutoGenerateColumns = false;

            cmbVeViec.DataSource = _cVeViecTTTL.LoadDS();
            cmbVeViec.DisplayMember = "TenVV";
            cmbVeViec.SelectedIndex = -1;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_dontxl != null && txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" & txtNoiNhan.Text.Trim() != "")
                    {
                        if (!_cTTTL.CheckTTTLbyMaDon_TXL(_dontxl.MaDon))
                        {
                            TTTL tttl = new TTTL();
                            tttl.ToXuLy = true;
                            tttl.MaDonTXL = _dontxl.MaDon;
                            if (_cTTTL.ThemTTTL(tttl))
                            {
                            }
                        }
                        if (_cTTTL.CheckCTTTTLbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim(), DateTime.Now))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        CTTTTL cttttl = new CTTTTL();
                        cttttl.MaTTTL = _cTTTL.getTTTLbyMaDon_TXL(_dontxl.MaDon).MaTTTL;
                        cttttl.DanhBo = txtDanhBo.Text.Trim();
                        cttttl.HopDong = txtHopDong.Text.Trim();
                        cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                        cttttl.HoTen = txtHoTen.Text.Trim();
                        cttttl.DiaChi = txtDiaChi.Text.Trim();
                        cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                        cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                        if (_hoadon != null)
                        {
                            cttttl.Dot = _hoadon.DOT.ToString();
                            cttttl.Ky = _hoadon.KY.ToString();
                            cttttl.Nam = _hoadon.NAM.ToString();
                        }
                        cttttl.VeViec = txtVeViec.Text.Trim();
                        cttttl.NoiDung = txtNoiDung.Text;
                        cttttl.NoiNhan = txtNoiNhan.Text.Trim();
                        ///
                        if (chkGiamNuocXaBo.Checked)
                            cttttl.GiamNuocXaBo = true;
                        if (chkKiemDinhDHN_Dung.Checked)
                            cttttl.KiemDinhDHN_Dung = true;
                        if (chkKiemDinhDHN_Sai.Checked)
                            cttttl.KiemDinhDHN_Sai = true;
                        if (chkThayDHN.Checked)
                            cttttl.ThayDHN = true;
                        if (chkDieuChinh_GB_DM.Checked)
                            cttttl.DieuChinh_GB_DM = true;
                        if (chkThuMoi.Checked)
                            cttttl.ThuMoi = true;
                        if (chkThuBao.Checked)
                            cttttl.ThuBao = true;

                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            cttttl.ChucVu = "GIÁM ĐỐC";
                        else
                            cttttl.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        cttttl.ThuDuocKy = true;

                        if (_cTTTL.ThemCTTTTL(cttttl))
                        {
                            MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Clear();

                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                    if (_donkh != null && txtVeViec.Text.Trim() != "" && txtNoiDung.Text.Trim() != "" & txtNoiNhan.Text.Trim() != "")
                    {
                        if (!_cTTTL.CheckTTTLbyMaDon(_donkh.MaDon))
                        {
                            TTTL tttl = new TTTL();
                            tttl.MaDon = _donkh.MaDon;
                            if (_cTTTL.ThemTTTL(tttl))
                            {
                            }
                        }
                        if (_cTTTL.CheckCTTTTLbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim(), DateTime.Now))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Thư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        CTTTTL cttttl = new CTTTTL();
                        cttttl.MaTTTL = _cTTTL.getTTTLbyMaDon(_donkh.MaDon).MaTTTL;
                        cttttl.DanhBo = txtDanhBo.Text.Trim();
                        cttttl.HopDong = txtHopDong.Text.Trim();
                        cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                        cttttl.HoTen = txtHoTen.Text.Trim();
                        cttttl.DiaChi = txtDiaChi.Text.Trim();
                        cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                        cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                        if (_hoadon != null)
                        {
                            cttttl.Dot = _hoadon.DOT.ToString();
                            cttttl.Ky = _hoadon.KY.ToString();
                            cttttl.Nam = _hoadon.NAM.ToString();
                        }
                        cttttl.VeViec = txtVeViec.Text.Trim();
                        cttttl.NoiDung = txtNoiDung.Text;
                        cttttl.NoiNhan = txtNoiNhan.Text.Trim();
                        ///
                        if (chkGiamNuocXaBo.Checked)
                            cttttl.GiamNuocXaBo = true;
                        if (chkKiemDinhDHN_Dung.Checked)
                            cttttl.KiemDinhDHN_Dung = true;
                        if (chkKiemDinhDHN_Sai.Checked)
                            cttttl.KiemDinhDHN_Sai = true;
                        if (chkThayDHN.Checked)
                            cttttl.ThayDHN = true;
                        if (chkDieuChinh_GB_DM.Checked)
                            cttttl.DieuChinh_GB_DM = true;
                        if (chkThuMoi.Checked)
                            cttttl.ThuMoi = true;
                        if (chkThuBao.Checked)
                            cttttl.ThuBao = true;

                        ///Ký Tên
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            cttttl.ChucVu = "GIÁM ĐỐC";
                        else
                            cttttl.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        cttttl.ThuDuocKy = true;

                        if (_cTTTL.ThemCTTTTL(cttttl))
                        {
                            MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            //DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                            //dr["SoPhieu"] = _cTTTL.getMaxMaCTTTTL().ToString().Insert(_cTTTL.getMaxMaCTTTTL().ToString().Length - 2, "-");
                            //dr["LoTrinh"] = cttttl.LoTrinh;
                            //dr["HoTen"] = cttttl.HoTen;
                            //dr["DiaChi"] = cttttl.DiaChi;
                            //dr["DanhBo"] = cttttl.DanhBo.Insert(7, " ").Insert(4, " ");
                            //dr["HopDong"] = cttttl.HopDong;
                            //dr["GiaBieu"] = cttttl.GiaBieu;
                            //dr["DinhMuc"] = cttttl.DinhMuc;
                            //dr["NgayNhanDon"] = _donkh.CreateDate.Value.ToString("dd/MM/yyyy");
                            //dr["VeViec"] = cttttl.VeViec;
                            //dr["NoiDung"] = cttttl.NoiDung;
                            //dr["NoiNhan"] = cttttl.NoiNhan;
                            //dr["ChucVu"] = cttttl.ChucVu;
                            //dr["NguoiKy"] = cttttl.NguoiKy;

                            //dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                            //rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                            //rpt.SetDataSource(dsBaoCao);
                            //frmBaoCao frm = new frmBaoCao(rpt);
                            //frm.ShowDialog();

                            Clear();

                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL"+_dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            LoadTTKH(_hoadon);
                        }
                        else
                        {
                            Clear();
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        _dontxl = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_donkh.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_donkh.DanhBo);
                            LoadTTKH(_hoadon);
                        }
                        else
                        {
                            Clear();
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        _donkh = null;
                        Clear();
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                    dgvLichSuTTTL.DataSource = _cTTTL.LoadLichSuTTTLbyDanhBo(_hoadon.DANHBA);
                }
                else
                {
                    _hoadon = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLichSuTTTL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuTTTL.Columns[e.ColumnIndex].Name == "MaCTTTTL" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvLichSuTTTL.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void cmbVeViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVeViec.SelectedIndex != -1)
            {
                VeViecTTTL vv = (VeViecTTTL)cmbVeViec.SelectedItem;
                txtVeViec.Text = vv.TenVV;
                txtNoiDung.Text = vv.NoiDung;
                txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDon.Text.Trim() + ")";
            }
            else
            {
                txtVeViec.Text = "";
                txtNoiDung.Text = "";
                txtNoiNhan.Text = "";
            }
        }

        private void txtMaCTTTTL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _cttttl = _cTTTL.getCTTTTLbyID(decimal.Parse(txtMaCTTTTL.Text.Trim().Replace("-", "")));
                if (_cttttl != null)
                {
                     
                    if (_cttttl.TTTL.ToXuLy)
                        txtMaDon.Text = "TXL" + _cttttl.TTTL.MaDonTXL.Value.ToString().Insert(_cttttl.TTTL.MaDonTXL.Value.ToString().Length - 2, "-");
                    else
                        txtMaDon.Text = _cttttl.TTTL.MaDon.Value.ToString().Insert(_cttttl.TTTL.MaDon.Value.ToString().Length - 2, "-");
                    txtDanhBo.Text = _cttttl.DanhBo;
                    txtHopDong.Text = _cttttl.HopDong;
                    txtLoTrinh.Text = _cttttl.LoTrinh;
                    txtHoTen.Text = _cttttl.HoTen;
                    txtDiaChi.Text = _cttttl.DiaChi;
                    txtGiaBieu.Text = _cttttl.GiaBieu;
                    txtDinhMuc.Text = _cttttl.DinhMuc;
                    txtVeViec.Text = _cttttl.VeViec;
                    txtNoiDung.Text = _cttttl.NoiDung;
                    txtNoiNhan.Text = _cttttl.NoiNhan;
                    if (_cttttl.GiamNuocXaBo)
                        chkGiamNuocXaBo.Checked = true;
                    if (_cttttl.KiemDinhDHN_Dung)
                        chkKiemDinhDHN_Dung.Checked = true;
                    if (_cttttl.KiemDinhDHN_Sai)
                        chkKiemDinhDHN_Sai.Checked = true;
                    if (_cttttl.ThayDHN)
                        chkThayDHN.Checked = true;
                    if (_cttttl.DieuChinh_GB_DM)
                        chkDieuChinh_GB_DM.Checked = true;
                    if (_cttttl.ThuMoi)
                        chkThuMoi.Checked = true;
                    if (_cttttl.ThuBao)
                        chkThuBao.Checked = true;

                    dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(_cttttl.MaCTTTTL);
                }
            }
        }

        private void btnCapNhatGhiChu_Click(object sender, EventArgs e)
        {
            if (_cttttl != null)
            {
                GhiChuCTTTTL ghichu = new GhiChuCTTTTL();
                ghichu.NgayGhiChu = dateGhiChu.Value;
                ghichu.GhiChu = txtGhiChu.Text.Trim();
                ghichu.MaCTTTTL=_cttttl.MaCTTTTL;
                if (_cGhiChuCTTTTL.Them(ghichu))
                    dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(_cttttl.MaCTTTTL);
            }
        }

        private void dgvGhiChu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvGhiChu.CurrentCell = dgvGhiChu.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvGhiChu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_donkh != null))
            {
                contextMenuStrip1.Show(dgvGhiChu, new Point(e.X, e.Y));
            }

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_cGhiChuCTTTTL.Xoa(_cGhiChuCTTTTL.Get(int.Parse(dgvGhiChu.CurrentRow.Cells["ID"].Value.ToString()))))
                {
                    dgvGhiChu.DataSource = _cGhiChuCTTTTL.GetDS(_cttttl.MaCTTTTL);
                }
            }
        }
    }
}
