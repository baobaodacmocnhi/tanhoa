using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.NhapLieu;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.NhapLieu
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

        private void frmNhanDonKH_Load(object sender, EventArgs e)
        {
            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaDon.Text = _cDonKH.getMaxID().ToString();
            txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            DonKH donkh = new DonKH();
            donkh.MaDon = int.Parse(txtMaDon.Text.Trim());
            donkh.MaLD = int.Parse(cmbLD.SelectedText);
            donkh.DanhBo = txtDanhBo.Text.Trim();
            donkh.SoHopDong = txtHopDong.Text.Trim();
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
                dr["KiemTraDHN"] = true;
            }
            else
            {
                dr["KiemTraDHN"] = false;
            }

            if (chkTienNuoc.Checked)
            {
                dr["TienNuoc"] = true;
            }
            else
            {
                dr["TienNuoc"] = false;
            }

            if (chkChiSoNuoc.Checked)
            {
                dr["ChiSoNuoc"] = true;
            }
            else
            { dr["ChiSoNuoc"] = false; }

            if (chkDonGiaNuoc.Checked)
            { dr["DonGiaNuoc"] = true; }
            else
            { dr["DonGiaNuoc"] = false; }

            if (chkSangTen.Checked)
            { dr["SangTen"] = true; }
            else
            {dr["SangTen"] = false;}

            if (chkDangKyDM.Checked)
            { dr["DangKyDM"] = true; }
            else
            { dr["DangKyDM"] = false; }

            if (chkCatChuyenDM.Checked)
            { dr["CatChuyenDM"] = true; }
            else
            { dr["CatChuyenDM"] = false; }

            if (chkNuocDuc.Checked)
            { dr["NuocDuc"] = true; }
            else
            {dr["NuocDuc"] = false;}

            if (chkLyDoKhac.Checked)
            {
                dr["LoaiKhac"] = true;
                dr["GhiChuLoaiKhac"] = txtGhiChu.Text.Trim();
            }
            else
            { dr["LoaiKhac"] = false; }

            if (chkCT_HoaDon.Checked)
            { dr["CT_HoaDon"] = true; }
            else
            { dr["CT_HoaDon"] = false; }

            if (chkCT_HoKhau_KT3.Checked)
            { dr["CT_HK_KT3"] = true; }
            else
            { dr["CT_HK_KT3"] = false; }

            if (chkCT_STT_GXNTT.Checked)
            { dr["CT_STT_GXNTT"] = true; }
            else
            { dr["CT_STT_GXNTT"] = false; }

            if (chkCT_HDTN_CQN.Checked)
            { dr["CT_HDTN_CQN"] = true; }
            else
            { dr["CT_HDTN_CQN"] = false; }

            if (chkCT_GC_SDSN.Checked)
            { dr["CT_GC_SDSN"] = true; }
            else
            { dr["CT_GC_SDSN"] = false; }

            if (chkCT_GXN2SN.Checked)
            { dr["CT_GXN2SN"] = true; }
            else
            {dr["CT_GXN2SN"] = false;}

            if (chkCT_GDKKD.Checked)
            { dr["CT_GDKKD"] = true; }
            else
            {dr["CT_GDKKD"] = false;}

            if (chkCT_GCNDTDHN.Checked)
            { dr["CT_GCNDTDHN"] = true; }
            else
            {dr["CT_GCNDTDHN"] = false;}
            dr["DM"] = txtDinhMuc.Text.Trim();
            dr["HoTenNV"] = CTaiKhoan.HoTen;
            dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
            rptBienNhanDonKH rpt = new rptBienNhanDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }
    }
}
