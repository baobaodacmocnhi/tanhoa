using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmBaoCaoDonKH : Form
    {
        string _tuNgay = "", _denNgay = "";
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();

        public frmBaoCaoDonKH()
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
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                dt = _cDonKH.LoadDSDonKH(dateTu.Value, dateDen.Value);
            else
                if (!string.IsNullOrEmpty(_tuNgay))
                    dt = _cDonKH.LoadDSDonKH(dateTu.Value);

            int SLDaXuLy = 0;
            int SLChuaXuLy = 0;

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();
                dr["TuNgay"] = _tuNgay;
                dr["DenNgay"] = _denNgay;
                dr["MaLD"] = itemRow["MaLD"];
                dr["TenLD"] = itemRow["TenLD"];
                dr["MaDon"] = itemRow["MaDon"];
                dr["DanhBo"] = itemRow["DanhBo"];
                dr["TienTrinh"] = itemRow["TienTrinh"];
                if (string.IsNullOrEmpty(itemRow["TienTrinh"].ToString()))
                    SLChuaXuLy++;
                else
                    SLDaXuLy++;
                //dr["SoDanhBo"] = _cKTXM.countCTKTXMbyMaDon(decimal.Parse(itemRow["MaDon"].ToString()));
                dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
            }

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            _tuNgay = _denNgay = "";

            rptThongKeDonKH rpt = new rptThongKeDonKH();
            rpt.SetDataSource(dsBaoCao);
            rpt.SetParameterValue(0, SLChuaXuLy);
            rpt.SetParameterValue(1, SLDaXuLy);

            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
