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
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmBaoCaoBamChi : Form
    {
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
            DataTable dt=new DataTable();
            if (CTaiKhoan.ToKH)
                dt = _cBamChi.GetDS("TKH",dateTu.Value, dateDen.Value);
            else
                if (CTaiKhoan.ToXL)
                    dt = _cBamChi.GetDS("TXL", dateTu.Value, dateDen.Value);
                else
                    if (CTaiKhoan.ToBC)
                        dt = _cBamChi.GetDS("TBC", dateTu.Value, dateDen.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["ThongKeBamChi"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["TrangThaiBC"] = item["TrangThaiBC"];
                dr["TenLD"] = item["TenLD"];
                dr["DanhBo"] = item["DanhBo"];
                dsBaoCao.Tables["ThongKeBamChi"].Rows.Add(dr);
            }

            rptThongKeBamChi rpt = new rptThongKeBamChi();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }


    }
}

