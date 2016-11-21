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

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmBaoCaoDonTXL : Form
    {
        CDonTXL _cDonTXL = new CDonTXL();
        CKTXM _cKTXM = new CKTXM();
        CBamChi _cBamChi = new CBamChi();

        public frmBaoCaoDonTXL()
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
    }
}
