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
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmNhanDonKH : Form
    {
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CDonKH _cDonKH = new CDonKH();
        CTTKH _cTTKH = new CTTKH();
        string Dot = "";
        string Ky = "";

        public frmNhanDonKH()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";

            chkKiemTraDHN.Checked = false;
            chkTienNuoc.Checked = false;
            chkChiSoNuoc.Checked = false;
            chkDonGiaNuoc.Checked = false;
            chkSangTen.Checked = false;
            chkDangKyDM.Checked = false;
            chkCatChuyenDM.Checked = false;
            chkNuocDuc.Checked = false;
            chkLyDoKhac.Checked = false;

            txtLyDoKhac.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtGhiChu.Text = "";

            chkCT_HoaDon.Checked = false;
            chkCT_HK_KT3.Checked = false;
            chkCT_STT_GXNTT.Checked = false;
            chkCT_HDTN_CQN.Checked = false;
            chkCT_GC_SDSN.Checked = false;
            chkCT_GXN2SN.Checked = false;
            chkCT_GDKKD.Checked = false;
            chkCT_GCNDTDHN.Checked = false;
        }

        private void frmNhanDonKH_Load(object sender, EventArgs e)
        {
            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;
            Clear();
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLD.SelectedIndex != -1)
            {
                txtMaDon.Text = _cDonKH.getMaxNextID().ToString();
                txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void chkLyDoKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLyDoKhac.Checked)
                txtLyDoKhac.ReadOnly = false;
            else
                txtLyDoKhac.ReadOnly = true;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                if (ttkhachhang != null)
                {
                    txtHopDong.Text = ttkhachhang.GiaoUoc;
                    txtKhachHang.Text = ttkhachhang.HoTen;
                    txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
                    txtGiaBieu.Text = ttkhachhang.GB;
                    txtDinhMuc.Text = ttkhachhang.TGDM;
                    Dot = ttkhachhang.Dot;
                    Ky = ttkhachhang.Ky;
                }
            }
        }

        private void btnInBienNhan_Click(object sender, EventArgs e)
        {
            try
            {
                DonKH donkh = new DonKH();
                donkh.MaDon = int.Parse(txtMaDon.Text.Trim());
                donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                donkh.DanhBo = txtDanhBo.Text.Trim();
                donkh.HopDong = txtHopDong.Text.Trim();
                donkh.HoTen = txtKhachHang.Text.Trim();
                donkh.DiaChi = txtDiaChi.Text.Trim();
                donkh.DienThoai = txtDienThoai.Text.Trim();
                donkh.GiaBieu = txtGiaBieu.Text.Trim();
                donkh.DinhMuc = txtDinhMuc.Text.Trim();
                donkh.Dot = Dot;
                donkh.Ky = Ky;
                donkh.NoiDung = txtNoiDung.Text.Trim();
                donkh.GhiChu = txtGhiChu.Text.Trim();

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                dr["MaDon"] = txtMaDon.Text.Trim();
                dr["TenLD"] = cmbLD.Text;
                dr["KhachHang"] = txtKhachHang.Text.Trim();
                dr["DanhBo"] = txtDanhBo.Text.Trim();
                dr["DiaChi"] = txtDiaChi.Text.Trim();
                dr["HopDong"] = txtHopDong.Text.Trim();
                dr["DienThoai"] = txtDienThoai.Text.Trim();
                if (chkKiemTraDHN.Checked)
                {
                    donkh.KiemTraDHN = true;
                    dr["KiemTraDHN"] = true;
                }
                else
                {
                    donkh.KiemTraDHN = false;
                    dr["KiemTraDHN"] = false;
                }

                if (chkTienNuoc.Checked)
                {
                    donkh.TienNuoc = true;
                    dr["TienNuoc"] = true;
                }
                else
                {
                    donkh.TienNuoc = false;
                    dr["TienNuoc"] = false;
                }

                if (chkChiSoNuoc.Checked)
                {
                    donkh.ChiSoNuoc = true;
                    dr["ChiSoNuoc"] = true;
                }
                else
                {
                    donkh.ChiSoNuoc = false;
                    dr["ChiSoNuoc"] = false;
                }

                if (chkDonGiaNuoc.Checked)
                {
                    donkh.DonGiaNuoc = true;
                    dr["DonGiaNuoc"] = true;
                }
                else
                {
                    donkh.DonGiaNuoc = false;
                    dr["DonGiaNuoc"] = false;
                }

                if (chkSangTen.Checked)
                {
                    donkh.SangTen = true;
                    dr["SangTen"] = true;
                }
                else
                {
                    donkh.SangTen = false;
                    dr["SangTen"] = false;
                }

                if (chkDangKyDM.Checked)
                {
                    donkh.DangKyDM = true;
                    dr["DangKyDM"] = true;
                }
                else
                {
                    donkh.DangKyDM = false;
                    dr["DangKyDM"] = false;
                }

                if (chkCatChuyenDM.Checked)
                {
                    donkh.CatChuyenDM = true;
                    dr["CatChuyenDM"] = true;
                }
                else
                {
                    donkh.CatChuyenDM = false;
                    dr["CatChuyenDM"] = false;
                }

                if (chkNuocDuc.Checked)
                {
                    donkh.NuocDuc = true;
                    dr["NuocDuc"] = true;
                }
                else
                {
                    donkh.NuocDuc = false;
                    dr["NuocDuc"] = false;
                }

                if (chkLyDoKhac.Checked)
                {
                    donkh.LoaiKhac = true;
                    dr["LoaiKhac"] = true;
                    donkh.GhiChuLoaiKhac = txtLyDoKhac.Text.Trim();
                    dr["GhiChuLoaiKhac"] = txtLyDoKhac.Text.Trim();
                }
                else
                {
                    donkh.LoaiKhac = false;
                    dr["LoaiKhac"] = false;
                }

                if (chkCT_HoaDon.Checked)
                {
                    donkh.CT_HoaDon = true;
                    dr["CT_HoaDon"] = true;
                }
                else
                {
                    donkh.CT_HoaDon = false;
                    dr["CT_HoaDon"] = false;
                }

                if (chkCT_HK_KT3.Checked)
                {
                    donkh.CT_HK_KT3 = true;
                    dr["CT_HK_KT3"] = true;
                }
                else
                {
                    donkh.CT_HK_KT3 = false;
                    dr["CT_HK_KT3"] = false;
                }

                if (chkCT_STT_GXNTT.Checked)
                {
                    donkh.CT_STT_GXNTT = true;
                    dr["CT_STT_GXNTT"] = true;
                }
                else
                {
                    donkh.CT_STT_GXNTT = false;
                    dr["CT_STT_GXNTT"] = false;
                }

                if (chkCT_HDTN_CQN.Checked)
                {
                    donkh.CT_HDTN_CQN = true;
                    dr["CT_HDTN_CQN"] = true;
                }
                else
                {
                    donkh.CT_HDTN_CQN = false;
                    dr["CT_HDTN_CQN"] = false;
                }

                if (chkCT_GC_SDSN.Checked)
                {
                    donkh.CT_GC_SDSN = true;
                    dr["CT_GC_SDSN"] = true;
                }
                else
                {
                    donkh.CT_GC_SDSN = false;
                    dr["CT_GC_SDSN"] = false;
                }

                if (chkCT_GXN2SN.Checked)
                {
                    donkh.CT_GXN2SN = true;
                    dr["CT_GXN2SN"] = true;
                }
                else
                {
                    donkh.CT_GXN2SN = false;
                    dr["CT_GXN2SN"] = false;
                }

                if (chkCT_GDKKD.Checked)
                {
                    donkh.CT_GDKKD = true;
                    dr["CT_GDKKD"] = true;
                }
                else
                {
                    donkh.CT_GDKKD = false;
                    dr["CT_GDKKD"] = false;
                }

                if (chkCT_GCNDTDHN.Checked)
                {
                    donkh.CT_GCNDTDHN = true;
                    dr["CT_GCNDTDHN"] = true;
                }
                else
                {
                    donkh.CT_GCNDTDHN = false;
                    dr["CT_GCNDTDHN"] = false;
                }

                _cDonKH.ThemDonKH(donkh);

                dr["DM"] = txtDinhMuc.Text.Trim();
                dr["HoTenNV"] = CTaiKhoan.HoTen;
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                rptBienNhanDonKH rpt = new rptBienNhanDonKH();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();

                Clear();
            }
            catch (Exception)
            {

            }
        }

        
    }
}
