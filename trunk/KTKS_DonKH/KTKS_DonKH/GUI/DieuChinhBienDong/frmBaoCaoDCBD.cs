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
                        if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                        {
                            string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                            dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                        }
                        else
                            dr["SoPhieu"] = "";


                        if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                        {
                            decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                            dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                        }
                        else
                            dr["MaDon"] = "";

                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["MaLCT"] = itemRow["MaLCT"];
                        dr["TenLCT"] = itemRow["TenLCT"];
                        dr["MaCT"] = itemRow["MaCT"];
                        dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                        dr["NgayHetHan"] = itemRow["NgayHetHan"];
                        dr["DienThoai"] = itemRow["DienThoai"];
                        dr["GhiChu"] = itemRow["GhiChu"];
                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                }

                dateTu.Value = DateTime.Now;
                dateDen.Value = DateTime.Now;
                _tuNgay = _denNgay = "";

                rptDSCapDinhMuc rpt = new rptDSCapDinhMuc();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
                
            }
            if (radThongKeDC.Checked)
            {
                DataTable dtDCBD = new DataTable();
                DataTable dtDCHD = new DataTable();
                DataTable dtCatChuyenDM = new DataTable();

                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                {
                    dtDCBD = _cDCBD.LoadDSCTDCBD(dateTu.Value, dateDen.Value);
                    dtDCHD = _cDCBD.LoadDSCTDCHD(dateTu.Value, dateDen.Value);
                    dtCatChuyenDM = _cChungTu.LoadDSCatChuyenDM(dateTu.Value, dateDen.Value);
                }
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                    {
                        dtDCBD = _cDCBD.LoadDSCTDCBD(dateTu.Value);
                        dtDCHD = _cDCBD.LoadDSCTDCHD(dateTu.Value);
                        dtCatChuyenDM = _cChungTu.LoadDSCatChuyenDM(dateTu.Value);
                    }

                int DanhBoTangDM = 0;
                int DanhBoGiamDM = 0;
                int DinhMucTang = 0;
                int DinhMucGiam = 0;

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dtDCBD.Rows)
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

                    if (!string.IsNullOrEmpty(itemRow["DinhMuc_BD"].ToString()))
                    {
                        int a = 0;
                        if (string.IsNullOrEmpty(itemRow["DinhMuc"].ToString()))
                            a = 0;
                        else
                            a = int.Parse(itemRow["DinhMuc"].ToString());

                        if (int.Parse(itemRow["DinhMuc_BD"].ToString()) > a)
                        {
                            DanhBoTangDM++;
                            DinhMucTang += int.Parse(itemRow["DinhMuc_BD"].ToString()) - a;
                        }
                        else
                        {
                            DanhBoGiamDM++;
                            DinhMucGiam += a - int.Parse(itemRow["DinhMuc_BD"].ToString());
                        }
                    }

                    dsBaoCao.Tables["ThongKeDCBD"].Rows.Add(dr);
                }

                foreach (DataRow itemRow in dtDCHD.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeDCHD"].NewRow();
                    dr["DanhBo"] = itemRow["DanhBo"];
                    dr["TangGiam"] = itemRow["TangGiam"];
                    dr["SoTien"] = itemRow["TongCong_BD"];

                    dsBaoCao.Tables["ThongKeDCHD"].Rows.Add(dr);
                }

                foreach (DataRow itemRow in dtCatChuyenDM.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeCatChuyenDM"].NewRow();
                    dr["SoPhieu"] = itemRow["SoPhieu"];
                    if (itemRow["CatDM"].ToString() != "")
                    {
                        if (bool.Parse(itemRow["CatDM"].ToString()))
                            dr["LoaiCatChuyen"] = "Cắt Chuyển đến Công ty khác";
                    }
                    else
                        if (itemRow["YeuCauCat"].ToString() != "")
                        {
                            if (bool.Parse(itemRow["YeuCauCat"].ToString()))
                                dr["LoaiCatChuyen"] = "Yêu Cầu Công ty khác Cắt";
                        }
                        else
                            if (itemRow["NhanDM"].ToString() != "")
                                if (bool.Parse(itemRow["NhanDM"].ToString()))
                                    dr["LoaiCatChuyen"] = "Nhận từ Công ty khác";

                    dsBaoCao.Tables["ThongKeCatChuyenDM"].Rows.Add(dr);
                }

                dateTu.Value = DateTime.Now;
                dateDen.Value = DateTime.Now;
                _tuNgay = _denNgay = "";

                rptThongKeDCBD rpt = new rptThongKeDCBD();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                rpt.Subreports[1].SetDataSource(dsBaoCao);

                rpt.SetParameterValue(0, DanhBoTangDM);
                rpt.SetParameterValue(1, DinhMucTang);
                rpt.SetParameterValue(2, DanhBoGiamDM);
                rpt.SetParameterValue(3, DinhMucGiam);

                crystalReportViewer1.ReportSource = rpt;
                
            }
        }
    }
}
