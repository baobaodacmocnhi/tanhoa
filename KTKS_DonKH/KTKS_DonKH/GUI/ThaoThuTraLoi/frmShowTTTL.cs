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
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmShowTTTL : Form
    {
        decimal _MaCTTTTL = 0;
        CTTTL _cTTTL = new CTTTL();
        CTTTTL _cttttl = null;
        CThuTien _cThuTien = new CThuTien();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CVeViecTTTL _cVeViecTTTL = new CVeViecTTTL();

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

        private void frmShowTTTL_Load(object sender, EventArgs e)
        {
            cmbVeViec.DataSource = _cVeViecTTTL.LoadDS();
            cmbVeViec.DisplayMember = "TenVV";
            cmbVeViec.SelectedIndex = -1;

            this.Location = new Point(70, 70);
            if (_cTTTL.GetCTByID(_MaCTTTTL) != null)
            {
                _cttttl = _cTTTL.GetCTByID(_MaCTTTTL);
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
                if (_cttttl.TTTL.ToXuLy)
                    dr["NgayNhanDon"] = _cttttl.TTTL.DonTXL.CreateDate.Value.ToString("dd/MM/yyyy");
                else
                    dr["NgayNhanDon"] = _cttttl.TTTL.DonKH.CreateDate.Value.ToString("dd/MM/yyyy");
                dr["VeViec"] = _cttttl.VeViec;
                dr["NoiDung"] = _cttttl.NoiDung;
                dr["NoiNhan"] = _cttttl.NoiNhan;
                dr["ChucVu"] = _cttttl.ChucVu;
                dr["NguoiKy"] = _cttttl.NguoiKy;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
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

                    if (_cTTTL.SuaCT(_cttttl))
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
                if (_cThuTien.GetMoiNhat(txtDanhBo.Text.Trim()) != null)
                {
                    LoadTTKH(_cThuTien.GetMoiNhat(txtDanhBo.Text.Trim()));
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_cttttl != null)
                if (MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    if (_cTTTL.XoaCT(_cttttl))
                    {
                        MessageBox.Show("Xóa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
        }
    }
}
