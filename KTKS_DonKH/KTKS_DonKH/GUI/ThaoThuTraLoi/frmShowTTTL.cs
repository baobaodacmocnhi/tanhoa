using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThaoThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.KhachHang;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmShowTTTL : Form
    {
        decimal _MaCTTTTL = 0;
        CTTTL _cTTTL = new CTTTL();
        CTTTTL _cttttl = null;
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();

        public frmShowTTTL()
        {
            InitializeComponent();
        }

        public frmShowTTTL(decimal MaCTTTTL)
        {
            InitializeComponent();
            _MaCTTTTL = MaCTTTTL;
        }

        public frmShowTTTL(decimal MaCTTTTL,bool TimKiem)
        {
            InitializeComponent();
            _MaCTTTTL = MaCTTTTL;
            if (TimKiem)
            {
                btnSua.Enabled = false;
                btnIn.Enabled = false;
            }
        }
        
        /// <summary>
        /// Nhận Entity TTKhachHang để điền vào textbox
        /// </summary>
        /// <param name="ttkhachhang"></param>
        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtLoTrinh.Text = ttkhachhang.Dot + ttkhachhang.CuonGCS + ttkhachhang.CuonSTT;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
        }

        private void frmShowTTTL_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_cTTTL.getCTTTTLbyID(_MaCTTTTL) != null)
            {
                _cttttl = _cTTTL.getCTTTTLbyID(_MaCTTTTL);
                if(_cttttl.TTTL.ToXuLy)
                    txtMaDon.Text = "TXL"+_cttttl.TTTL.MaDonTXL.Value.ToString().Insert(_cttttl.TTTL.MaDonTXL.Value.ToString().Length - 2, "-");
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
            }
            
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_cttttl != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                dr["SoPhieu"] = _cttttl.MaCTTTTL.ToString().Insert(_cttttl.MaCTTTTL.ToString().Length - 2, "-");
                dr["LoTrinh"] = _cttttl.LoTrinh;
                dr["HoTen"] = _cttttl.HoTen;
                dr["DiaChi"] = _cttttl.DiaChi;
                if (!string.IsNullOrEmpty(_cttttl.DanhBo))
                    dr["DanhBo"] = _cttttl.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HopDong"] = _cttttl.HopDong;
                dr["GiaBieu"] = _cttttl.GiaBieu;
                dr["DinhMuc"] = _cttttl.DinhMuc;
                dr["NgayNhanDon"] = _cttttl.TTTL.DonKH.CreateDate.Value.ToString("dd/MM/yyyy");
                dr["VeViec"] = _cttttl.VeViec;
                dr["NoiDung"] = _cttttl.NoiDung;
                dr["NoiNhan"] = _cttttl.NoiNhan;
                dr["ChucVu"] = _cttttl.ChucVu;
                dr["NguoiKy"] = _cttttl.NguoiKy;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void frmShowTTTL_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cttttl != null)
                {
                    _cttttl.DanhBo = txtDanhBo.Text.Trim();
                    _cttttl.HopDong = txtHopDong.Text.Trim();
                    _cttttl.LoTrinh = txtLoTrinh.Text.Trim();
                    _cttttl.HoTen = txtHoTen.Text.Trim();
                    _cttttl.DiaChi = txtDiaChi.Text.Trim();
                    _cttttl.GiaBieu = txtGiaBieu.Text.Trim();
                    _cttttl.DinhMuc = txtDinhMuc.Text.Trim();
                    _cttttl.VeViec = txtVeViec.Text.Trim();
                    _cttttl.NoiDung = txtNoiDung.Text;
                    _cttttl.NoiNhan = txtNoiNhan.Text.Trim();
                    ///
                    if (chkGiamNuocXaBo.Checked)
                        _cttttl.GiamNuocXaBo = true;
                    if (chkKiemDinhDHN_Dung.Checked)
                        _cttttl.KiemDinhDHN_Dung = true;
                    if (chkKiemDinhDHN_Sai.Checked)
                        _cttttl.KiemDinhDHN_Sai = true;
                    if (chkThayDHN.Checked)
                        _cttttl.ThayDHN = true;
                    if (chkDieuChinh_GB_DM.Checked)
                        _cttttl.DieuChinh_GB_DM = true;
                    if (chkThuMoi.Checked)
                        _cttttl.ThuMoi = true;
                    if (chkThuBao.Checked)
                        _cttttl.ThuBao = true;

                    if (_cTTTL.SuaCTTTTL(_cttttl))
                        MessageBox.Show("Sửa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    LoadTTKH(_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()));
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
