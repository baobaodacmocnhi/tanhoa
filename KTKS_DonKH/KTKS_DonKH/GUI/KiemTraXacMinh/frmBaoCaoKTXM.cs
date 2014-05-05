using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.BaoCao.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmBaoCaoKTXM : Form
    {
        string _tuNgay = "", _denNgay = "";
        CKTXM _cKTXM = new CKTXM();

        public frmBaoCaoKTXM()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmBaoCaoKTXM_Load(object sender, EventArgs e)
        {

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

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (radThongKeBienBan.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cKTXM.LoadDSCTKTXM(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cKTXM.LoadDSCTKTXM(CTaiKhoan.MaUser,dateTu.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {


                    //DataRow dr = dsBaoCao.Tables["ThongKeBienBanKTXM"].NewRow();

                    //dr["TuNgay"] = _tuNgay;
                    //dr["DenNgay"] = _denNgay;
                    //dr["LoaiBienBan"] = itemRow["LoaiBienBan"];
                    //dr["DanhBo"] = itemRow["DanhBo"];

                    //dsBaoCao.Tables["ThongKeBienBanKTXM"].Rows.Add(dr);
                }


                _tuNgay = _denNgay = "";
                rptThongKeBienBanKTXM rpt = new rptThongKeBienBanKTXM();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
