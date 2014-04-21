using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmBaoCaoDCBD : Form
    {
        string _tuNgay = "", _denNgay = "";
        CChungTu _cChungTu = new CChungTu();
        CDCBD _cDCBD = new CDCBD();

        public frmBaoCaoDCBD()
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

        private void frmBCCapDinhMuc_Load(object sender, EventArgs e)
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
            if (radThongKeDMCap.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cChungTu.LoadDSCapDinhMuc(dateTu.Value, dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cChungTu.LoadDSCapDinhMuc(dateTu.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(itemRow["NgayHetHan"].ToString()))
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        dr["MaLCT"] = itemRow["MaLCT"];
                        dr["TenLCT"] = itemRow["TenLCT"];
                        if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                        {
                            string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                            dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                        }
                        else
                            dr["SoPhieu"] = "";
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                        dr["NgayHetHan"] = itemRow["NgayHetHan"];
                        dr["DienThoai"] = itemRow["DienThoai"];
                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                }

                rptDSCapDinhMuc rpt = new rptDSCapDinhMuc();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }
            if (radThongKeDCBD.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cDCBD.LoadDSCTDCBD(dateTu.Value,dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cDCBD.LoadDSCTDCBD(dateTu.Value);
                MessageBox.Show(dt.Rows.Count.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                 foreach (DataRow itemRow in dt.Rows)
                 {
                     DataRow dr = dsBaoCao.Tables["ThongKeDCBD"].NewRow();

                     dr["TuNgay"] = _tuNgay;
                     dr["DenNgay"] = _denNgay;
                     dr["DanhBo"] = itemRow["DanhBo"];
                     dr["HoTen"] = itemRow["HoTen_BD"];
                     dr["GiaBieuCu"] = itemRow["GiaBieu"];
                     dr["GiaBieuMoi"] = itemRow["GiaBieu_BD"];
                     dr["DinhMucCu"] = itemRow["DinhMuc"];
                     dr["DinhMucMoi"] = itemRow["DinhMuc_BD"];
                     dr["DiaChi"] = itemRow["DiaChi_BD"];
                     dr["MSThue"] = itemRow["MSThue_BD"];
                     dr["SH"] = itemRow["SH_BD"];
                     dr["SX"] = itemRow["SX_BD"];
                     dr["DV"] = itemRow["DV_BD"];
                     dr["HCSN"] = itemRow["HCSN_BD"];

                     dsBaoCao.Tables["ThongKeDCBD"].Rows.Add(dr);
                 }

                 rptThongKeDCBD rpt = new rptThongKeDCBD();
                 rpt.SetDataSource(dsBaoCao);
                 crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
