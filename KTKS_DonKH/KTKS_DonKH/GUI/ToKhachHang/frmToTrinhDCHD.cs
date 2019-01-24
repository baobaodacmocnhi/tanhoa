using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToKhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmToTrinhDCHD : Form
    {
        CDonKH _cDonKH = new CDonKH();
        CDonTu _cDonTu = new CDonTu();

        public frmToTrinhDCHD()
        {
            InitializeComponent();
        }

        private void frmToTrinhDCHD_Load(object sender, EventArgs e)
        {

        }

        private void txtMaDonCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtMaDonCu.Text.Trim()))
            {
                DonKH donkh = _cDonKH.Get(decimal.Parse(txtMaDonCu.Text.Trim().Replace("-", "")));

                txtMaDonCu.Text = donkh.MaDon.ToString().Insert(donkh.MaDon.ToString().Length - 2, "-");
                txtCreateDate.Text = donkh.CreateDate.Value.ToString("dd/MM/yyyy");
                txtDanhBo.Text = donkh.DanhBo;
                txtHopDong.Text = donkh.HopDong;
                txtMLT.Text = donkh.MLT;
                txtDiaChi.Text = donkh.DiaChi;
            }
        }

        private void txtMaDonMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtMaDonMoi.Text.Trim()))
            {
                DonTu_ChiTiet dontu_ChiTiet = new DonTu_ChiTiet();
                string MaDon = txtMaDonMoi.Text.Trim();
                if (MaDon.Contains(".") == true)
                {
                    string[] MaDons = MaDon.Split('.');
                    dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                }
                else
                {
                    dontu_ChiTiet = _cDonTu.get(int.Parse(MaDon)).DonTu_ChiTiets.SingleOrDefault();
                }
                //
                if (dontu_ChiTiet != null)
                {
                    if (dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count() == 1)
                        txtMaDonMoi.Text = dontu_ChiTiet.MaDon.Value.ToString();
                    else
                        txtMaDonMoi.Text = dontu_ChiTiet.MaDon.Value.ToString() + "." + dontu_ChiTiet.STT.Value.ToString();

                }
                else
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtMaDonMoi.Text = dontu_ChiTiet.MaDon.ToString();
                txtCreateDate.Text = dontu_ChiTiet.CreateDate.Value.ToString("dd/MM/yyyy");
                txtDanhBo.Text = dontu_ChiTiet.DanhBo;
                txtHopDong.Text = dontu_ChiTiet.HopDong;
                txtMLT.Text = dontu_ChiTiet.MLT;
                txtDiaChi.Text = dontu_ChiTiet.DiaChi;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow dr = dsBaoCao.Tables["ToTrinhDCHD"].NewRow();

            if (txtMaDonCu.Text.Trim()!=null)
            dr["MaDon"] = txtMaDonCu.Text.Trim();
            else
                if (txtMaDonMoi.Text.Trim() != null)
                    dr["MaDon"] = txtMaDonMoi.Text.Trim();
            dr["CreateDate"] = txtCreateDate.Text.Trim();
            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
            dr["HopDong"] = txtHopDong.Text.Trim();
            dr["MLT"] = txtMLT.Text.Trim();
            dr["DiaChi"] = txtDiaChi.Text.Trim();
            dr["Ho"] = txtHo.Text.Trim();
            dr["NhanKhau"] = txtNhanKhau.Text.Trim();
            dr["Dung"] = txtDung.Text.Trim();
            dr["XacNhanDTT"] = txtXacNhanDTT.Text.Trim();
            dr["NoKy"] = txtNoKy.Text.Trim();
            dr["TamTinh"] = txtTamTinh.Text.Trim()+" "+txtm3.Text.Trim();
            dr["DeXuat"] = txtDeXuat.Text.Trim();
            dr["Ky"] = txtKy.Text.Trim();
            dr["TuKy"] = txtTuKy.Text.Trim();
            dr["ChiSo"] = txtChiSo.Text.Trim();
            dr["HD0"] = false;

            dsBaoCao.Tables["ToTrinhDCHD"].Rows.Add(dr);
            rptToTrinhDCHD rpt=new rptToTrinhDCHD();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInHD0_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow dr = dsBaoCao.Tables["ToTrinhDCHD"].NewRow();

            if (txtMaDonCu.Text.Trim() != null)
                dr["MaDon"] = txtMaDonCu.Text.Trim();
            else
                if (txtMaDonMoi.Text.Trim() != null)
                    dr["MaDon"] = txtMaDonMoi.Text.Trim();
            dr["CreateDate"] = txtCreateDate.Text.Trim();
            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
            dr["HopDong"] = txtHopDong.Text.Trim();
            dr["MLT"] = txtMLT.Text.Trim();
            dr["DiaChi"] = txtDiaChi.Text.Trim();
            dr["Ho"] = txtHo.Text.Trim();
            dr["NhanKhau"] = txtNhanKhau.Text.Trim();
            dr["Dung"] = txtDung.Text.Trim();
            dr["NoKy"] = txtNoKy.Text.Trim();
            dr["TamTinh"] = txtTamTinh.Text.Trim() + " " + txtm3.Text.Trim();
            dr["DeXuat"] = txtDeXuat.Text.Trim();
            dr["Ky"] = txtKy.Text.Trim();
            dr["TuKy"] = txtTuKy.Text.Trim();
            dr["ChiSo"] = txtChiSo.Text.Trim();
            dr["HD0"] = true;

            dsBaoCao.Tables["ToTrinhDCHD"].Rows.Add(dr);
            rptToTrinhDCHD rpt = new rptToTrinhDCHD();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInKhac_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow dr = dsBaoCao.Tables["ToTrinhDCHD"].NewRow();

            if (txtMaDonCu.Text.Trim() != null)
                dr["MaDon"] = txtMaDonCu.Text.Trim();
            else
                if (txtMaDonMoi.Text.Trim() != null)
                    dr["MaDon"] = txtMaDonMoi.Text.Trim();
            dr["CreateDate"] = txtCreateDate.Text.Trim();
            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
            dr["HopDong"] = txtHopDong.Text.Trim();
            dr["MLT"] = txtMLT.Text.Trim();
            dr["DiaChi"] = txtDiaChi.Text.Trim();
            dr["Ho"] = txtHo.Text.Trim();
            dr["NhanKhau"] = txtNhanKhau.Text.Trim();
            dr["Dung"] = txtDung.Text.Trim();
            dr["DeXuat"] = txtDeXuat.Text.Trim();
            dr["HD0"] = false;

            dsBaoCao.Tables["ToTrinhDCHD"].Rows.Add(dr);
            rptToTrinh rpt = new rptToTrinh();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        

    }
}
