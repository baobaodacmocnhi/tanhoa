using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmToTrinhDCHD : Form
    {
        CDonKH _cDonKH = new CDonKH();

        public frmToTrinhDCHD()
        {
            InitializeComponent();
        }

        private void frmToTrinhDCHD_Load(object sender, EventArgs e)
        {

        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtMaDon.Text.Trim()))
            {
                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));

                txtMaDon.Text = donkh.MaDon.ToString().Insert(donkh.MaDon.ToString().Length - 2, "-");
                txtCreateDate.Text = donkh.CreateDate.Value.ToString("dd/MM/yyyy");
                txtDanhBo.Text = donkh.DanhBo;
                txtHopDong.Text = donkh.HopDong;
                txtMLT.Text = donkh.MLT;
                txtDiaChi.Text = donkh.DiaChi;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow dr = dsBaoCao.Tables["ToTrinhDCHD"].NewRow();

            dr["MaDon"] = txtMaDon.Text.Trim();
            dr["CreateDate"] = txtCreateDate.Text.Trim();
            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
            dr["HopDong"] = txtHopDong.Text.Trim();
            dr["MLT"] = txtMLT.Text.Trim();
            dr["DiaChi"] = txtDiaChi.Text.Trim();
            dr["Ho"] = txtHo.Text.Trim();
            dr["NhanKhau"] = txtNhanKhau.Text.Trim();
            dr["Dung"] = txtDung.Text.Trim();
            dr["NoKy"] = txtNoKy.Text.Trim();
            dr["TamTinh"] = txtTamTinh.Text.Trim();
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

            dr["MaDon"] = txtMaDon.Text.Trim();
            dr["CreateDate"] = txtCreateDate.Text.Trim();
            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
            dr["HopDong"] = txtHopDong.Text.Trim();
            dr["MLT"] = txtMLT.Text.Trim();
            dr["DiaChi"] = txtDiaChi.Text.Trim();
            dr["Ho"] = txtHo.Text.Trim();
            dr["NhanKhau"] = txtNhanKhau.Text.Trim();
            dr["Dung"] = txtDung.Text.Trim();
            dr["NoKy"] = txtNoKy.Text.Trim();
            dr["TamTinh"] = txtTamTinh.Text.Trim();
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
    }
}
