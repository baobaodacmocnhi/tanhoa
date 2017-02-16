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

namespace KTKS_DonKH.GUI.ToBamChi
{
    public partial class frmBaoCaoDonTBC : Form
    {
        CDonTXL _cDonTXL = new CDonTXL();
        CKTXM _cKTXM = new CKTXM();
        CBamChi _cBamChi = new CBamChi();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();

        public frmBaoCaoDonTBC()
        {
            InitializeComponent();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDonTXL.LoadDSDonTXLByDates(dateTu.Value, dateDen.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                dr["MaDon"] = item["MaDon"];
                dr["TenLD"] = item["TenLD"];
                if (_cKTXM.CheckKTMXbyMaDon_TXL(decimal.Parse(item["MaDon"].ToString())))
                    dr["DaGiaiQuyet"] = true;
                else
                    if (_cBamChi.CheckBamChibyMaDon_TXL(decimal.Parse(item["MaDon"].ToString())))
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

        private void btnBaoCaoLichSuChuyenDon_Click(object sender, EventArgs e)
        {
            DataTable dt = _cLichSuDonTu.GetDS("TBC",dateTu_LichSuChuyenDon.Value,dateDen_LichSuChuyenDon.Value);
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

        private void frmBaoCaoDonTXL_Load(object sender, EventArgs e)
        {

        }
    }
}
