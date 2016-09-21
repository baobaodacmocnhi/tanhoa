using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.BaoCao;

namespace KTKS_DonKH.GUI.BaoCao
{
    public partial class frmBaoCao : Form
    {
        CBaoCao _cBaoCao = new CBaoCao();

        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = _cBaoCao.TienTrinhXuLyDon(dateTu.Value,dateDen.Value);
            DataTable dtB = _cBaoCao.TienTrinhXuLyDon_B(dateTu.Value, dateDen.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

                DataRow dr = dsBaoCao.Tables["TienTrinhXuLyDon"].NewRow();

                dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                dr["DonKH"] = dt.Rows[0]["DonKH"];
                dr["DonTXL"] = dt.Rows[0]["DonTXL"];
                dr["DCBD"] = dt.Rows[0]["DCBD"];
                dr["DCHD"] = dt.Rows[0]["DCHD"];
                dr["CTDB"] = dt.Rows[0]["CTDB"];
                dr["CHDB"] = dt.Rows[0]["CHDB"];
                dr["TTTL"] = dt.Rows[0]["TTTL"];
                dr["DonKH_B"] = dtB.Rows[0]["DonKH"];
                dr["DonTXL_B"] = dtB.Rows[0]["DonTXL"];
                dr["DCBD_B"] = dtB.Rows[0]["DCBD"];
                dr["DCHD_B"] = dtB.Rows[0]["DCHD"];
                dr["CTDB_B"] = dtB.Rows[0]["CTDB"];
                dr["CHDB_B"] = dtB.Rows[0]["CHDB"];
                dr["TTTL_B"] = dtB.Rows[0]["TTTL"];

                dsBaoCao.Tables["TienTrinhXuLyDon"].Rows.Add(dr);

            rptTienTrinhXuLyDon rpt = new rptTienTrinhXuLyDon();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }
    }
}
