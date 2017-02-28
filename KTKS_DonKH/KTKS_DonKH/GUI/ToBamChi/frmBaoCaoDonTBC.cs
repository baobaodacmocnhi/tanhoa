using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.BaoCao.CongVan;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.ToBamChi
{
    public partial class frmBaoCaoDonTBC : Form
    {
        CDonTBC _cDonTBC = new CDonTBC();
        CKTXM _cKTXM = new CKTXM();
        CBamChi _cBamChi = new CBamChi();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        public frmBaoCaoDonTBC()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDonTBC_Load(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDonTBC.GetDSByCreateDate(dateTu.Value, dateDen.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                dr["LoaiBaoCao"] = "TỔ BẤM CHÌ";
                dr["MaDon"] = item["MaDon"];
                dr["TenLD"] = item["TenLD"];
                if (_cKTXM.CheckExist("TBC",decimal.Parse(item["MaDon"].ToString())))
                    dr["DaGiaiQuyet"] = true;
                else
                    if (_cBamChi.CheckExist_BamChi("TBC",decimal.Parse(item["MaDon"].ToString())))
                        dr["DaGiaiQuyet"] = true;
                    else
                        dr["DaGiaiQuyet"] = false;

                dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
            }

            rptThongKeDonTXL rpt = new rptThongKeDonTXL();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCao_LichSuChuyenDon_Click(object sender, EventArgs e)
        {
            DataTable dt = _cLichSuDonTu.GetDS("TBC", dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

                dr["TuNgay"] = dateTu_LichSuChuyenDon.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_LichSuChuyenDon.Value.ToString("dd/MM/yyyy");
                dr["LoaiVanBan"] = item["TenLD"].ToString();
                if (item["MaDon"].ToString().Length > 2)
                    dr["Ma"] = item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                dr["CreateDate"] = item["NgayChuyen"].ToString();
                if (item["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["NoiChuyen"] = item["NoiChuyen"].ToString();
                dr["NoiDung"] = item["NoiNhan"].ToString();

                dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDSCongVan rpt = new rptDSCongVan();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void cmbTimTheo_DSChuyenKTXM_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString())
            {
                case "Số Công Văn":
                    txtNoiDungTimKiem_DSChuyenKTXM.Visible = true;
                    panel_KhoangThoiGian_DSChuyenKTXM.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem_DSChuyenKTXM.Visible = false;
                    panel_KhoangThoiGian_DSChuyenKTXM.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem_DSChuyenKTXM.Visible = false;
                    panel_KhoangThoiGian_DSChuyenKTXM.Visible = false;
                    break;
            }
        }

        private void btnBaoCao_DSChuyenKTXM_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            switch (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString())
            {
                case "Ngày":
                    dt = _cLichSuDonTu.GetDSChuyen_KTXM("TBC",dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                    break;
                case "Số Công Văn":
                    dt = _cLichSuDonTu.GetDSChuyen_KTXM("TBC", txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (chkChuaKT_DSChuyenKTXM.Checked)
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (bool.Parse(itemRow["GiaiQuyet"].ToString())==false)
                    {
                        DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        dr["MaDon"] = "TBC" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                        dr["TenLD"] = itemRow["TenLD"];
                        dr["SoCongVan"] = itemRow["SoCongVan"];
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["NoiDung"] = itemRow["NoiDung"];
                        dr["GhiChuChuyenKT"] = itemRow["GhiChuChuyen"];
                        dr["NguoiDi"] = itemRow["NguoiDi"];

                        dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                    }
                }
            else
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    dr["MaDon"] = "TBC" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"];
                    dr["SoCongVan"] = itemRow["SoCongVan"];
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["NoiDung"] = itemRow["NoiDung"];
                    dr["GhiChuChuyenKT"] = itemRow["GhiChuChuyen"];
                    dr["NguoiDi"] = itemRow["NguoiDi"];
                    dr["DaGiaiQuyet"] = itemRow["GiaiQuyet"];
                    dr["NgayGiaiQuyet"] = itemRow["NgayGiaiQuyet"];

                    dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                }

            rptDSDonTXLChuyenKTXM rpt = new rptDSDonTXLChuyenKTXM();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            rpt.Subreports[1].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        
    }
}

