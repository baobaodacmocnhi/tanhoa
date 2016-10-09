using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.BamChi;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmBaoCaoBamChi : Form
    {
        string _tuNgay = "", _denNgay = "";
        CBamChi _cBamChi = new CBamChi();
        CTrangThaiBamChi _cTrangThaiBamChi = new CTrangThaiBamChi();

        public frmBaoCaoBamChi()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBamChi_Load(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (radThongKeBienBan.Checked)
                {
                    DataTable dt = _cBamChi.LoadDSCTBamChiByDates(dateTu.Value, dateDen.Value);
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["ThongKeBamChi"].NewRow();
                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        dr["TrangThaiBC"] = item["TrangThaiBC"];
                        dr["TenLD"] = item["TenLD"];
                        dr["DanhBo"] = item["DanhBo"];
                        dsBaoCao.Tables["ThongKeBamChi"].Rows.Add(dr);
                    }
                    dateTu.Value = DateTime.Now;
                    dateDen.Value = DateTime.Now;
                    _tuNgay = _denNgay = "";

                    rptThongKeBamChi rpt = new rptThongKeBamChi();
                    rpt.SetDataSource(dsBaoCao);
                    crystalReportViewer1.ReportSource = rpt;
                }

        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
        }

        
    }
}

