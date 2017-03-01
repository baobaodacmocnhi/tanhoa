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

        private void btnBaoCao_ThongKeTrangThaiBamChi_Click(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();

            if (CTaiKhoan.ToKH)
                dt = _cBamChi.GetDS("TKH",dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
            else
                if (CTaiKhoan.ToXL)
                    dt = _cBamChi.GetDS("TXL", dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
                else
                    if (CTaiKhoan.ToBC)
                        dt = _cBamChi.GetDS("TBC", dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();
                dr["TuNgay"] = dateTu_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                dr["MaCTBC"] = item["MaCTBC"];
                dr["TrangThaiBC"] = item["TrangThaiBC"];
                
                dsBaoCao.Tables["DSBamChi"].Rows.Add(dr);
            }

            rptThongKeTrangThaiBamChi rpt = new rptThongKeTrangThaiBamChi();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }


    }
}

