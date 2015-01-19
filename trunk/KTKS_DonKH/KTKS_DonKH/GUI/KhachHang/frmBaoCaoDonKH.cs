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
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.DAL.DongNuoc;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmBaoCaoDonKH : Form
    {
        string _tuNgay = "", _denNgay = "";
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CKTXM _cKTXM = new CKTXM();
        CBamChi _cBamChi = new CBamChi();
        CDCBD _cDCBD = new CDCBD();
        CTTTL _cTTTL = new CTTTL();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CCHDB _cCHDB = new CCHDB();

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
            if (radChiTietDon.Checked)
            {
                DataTable dtTKH = new DataTable();
                DataTable dtTXL = new DataTable();
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                if (chkToKH.Checked)
                {
                    if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                        dtTKH = _cDonKH.LoadDSDonKHByDates(dateTu.Value, dateDen.Value);
                    else
                        if (!string.IsNullOrEmpty(_tuNgay))
                            dtTKH = _cDonKH.LoadDSDonKHByDate(dateTu.Value);
                }
                if (chkTXL.Checked)
                {
                    if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                        dtTXL = _cDonTXL.LoadDSDonTXLByDates(dateTu.Value, dateDen.Value);
                    else
                        if (!string.IsNullOrEmpty(_tuNgay))
                            dtTXL = _cDonTXL.LoadDSDonTXLByDate(dateTu.Value);
                }
                foreach (DataRow item in dtTKH.Rows)
                {
                    if (string.IsNullOrEmpty(item["TienTrinh"].ToString()))
                    {
                        DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();
                        if (chkToKH.Checked && chkTXL.Checked)
                            dr["To"] = "";
                        else
                            if (chkToKH.Checked)
                                dr["To"] = "Tổ Khách Hàng";
                            else
                                if (chkTXL.Checked)
                                    dr["To"] = "Tổ Xử Lý";
                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        dr["TenLD"] = item["TenLD"];
                        dr["MaDon"] = item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                        dr["NgayNhan"] = item["CreateDate"];
                        dr["NoiDung"] = item["NoiDung"];
                        dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                    }
                    else
                    {
                        string[] tientrinh = item["TienTrinh"].ToString().Split(',');
                        foreach (var itemTT in tientrinh)
                        {
                            DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();
                            if (chkToKH.Checked && chkTXL.Checked)
                                dr["To"] = "";
                            else
                                if (chkToKH.Checked)
                                    dr["To"] = "Tổ Khách Hàng";
                                else
                                    if (chkTXL.Checked)
                                        dr["To"] = "Tổ Xử Lý";
                            dr["TuNgay"] = _tuNgay;
                            dr["DenNgay"] = _denNgay;
                            dr["TenLD"] = item["TenLD"];
                            dr["MaDon"] = item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                            dr["NgayNhan"] = item["CreateDate"];
                            dr["NoiDung"] = item["NoiDung"];
                            switch (itemTT)
                            {
                                case "KTXM":
                                    KTXM ktxm = _cKTXM.getKTXMbyMaDon(decimal.Parse(item["MaDon"].ToString()));
                                    if (ktxm != null)
                                    {
                                        dr["LoaiChuyen"] = "KTXM";
                                        dr["NgayChuyen"] = ktxm.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "BamChi":
                                    LinQ.BamChi bamchi = _cBamChi.getBamChibyMaDon(decimal.Parse(item["MaDon"].ToString()));
                                    if (bamchi != null)
                                    {
                                        dr["LoaiChuyen"] = "BamChi";
                                        dr["NgayChuyen"] = bamchi.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "DCBD":
                                    DCBD dcbd = _cDCBD.getDCBDbyMaDon(decimal.Parse(item["MaDon"].ToString()));
                                    if (dcbd != null)
                                    {
                                        dr["LoaiChuyen"] = "DCBD";
                                        dr["NgayChuyen"] = dcbd.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "TTTL":
                                    TTTL tttl = _cTTTL.getTTTLbyMaDon(decimal.Parse(item["MaDon"].ToString()));
                                    if (tttl != null)
                                    {
                                        dr["LoaiChuyen"] = "TTTL";
                                        dr["NgayChuyen"] = tttl.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "DongNuoc":
                                    LinQ.DongNuoc dongnuoc = _cDongNuoc.getDongNuocbyMaDon(decimal.Parse(item["MaDon"].ToString()));
                                    if (dongnuoc != null)
                                    {
                                        dr["LoaiChuyen"] = "DongNuoc";
                                        dr["NgayChuyen"] = dongnuoc.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "CHDB":
                                    CHDB chdb = _cCHDB.getCHDBbyMaDon(decimal.Parse(item["MaDon"].ToString()));
                                    if (chdb != null)
                                    {
                                        dr["LoaiChuyen"] = "CHDB";
                                        dr["NgayChuyen"] = chdb.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                default:
                                    break;
                            }
                            dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                        }
                    }
                }

                foreach (DataRow item in dtTXL.Rows)
                {
                    if (string.IsNullOrEmpty(item["TienTrinh"].ToString()))
                    {
                        DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();
                        if (chkToKH.Checked && chkTXL.Checked)
                            dr["To"] = "";
                        else
                            if (chkToKH.Checked)
                                dr["To"] = "Tổ Khách Hàng";
                            else
                                if (chkTXL.Checked)
                                    dr["To"] = "Tổ Xử Lý";
                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        dr["TenLD"] = item["TenLD"];
                        dr["MaDon"] = "TXL"+item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                        dr["NgayNhan"] = item["CreateDate"];
                        dr["NoiDung"] = item["NoiDung"];
                        dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                    }
                    else
                    {
                        string[] tientrinh = item["TienTrinh"].ToString().Split(',');
                        foreach (var itemTT in tientrinh)
                        {
                            DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();
                            if (chkToKH.Checked && chkTXL.Checked)
                                dr["To"] = "";
                            else
                                if (chkToKH.Checked)
                                    dr["To"] = "Tổ Khách Hàng";
                                else
                                    if (chkTXL.Checked)
                                        dr["To"] = "Tổ Xử Lý";
                            dr["TuNgay"] = _tuNgay;
                            dr["DenNgay"] = _denNgay;
                            dr["TenLD"] = item["TenLD"];
                            dr["MaDon"] = "TXL" + item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                            dr["NgayNhan"] = item["CreateDate"];
                            dr["NoiDung"] = item["NoiDung"];
                            switch (itemTT)
                            {
                                case "KTXM":
                                    KTXM ktxm = _cKTXM.getKTXMbyMaDon_TXL(decimal.Parse(item["MaDon"].ToString()));
                                    if (ktxm != null)
                                    {
                                        dr["LoaiChuyen"] = "KTXM";
                                        dr["NgayChuyen"] = ktxm.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "BamChi":
                                    LinQ.BamChi bamchi = _cBamChi.getBamChibyMaDon_TXL(decimal.Parse(item["MaDon"].ToString()));
                                    if (bamchi != null)
                                    {
                                        dr["LoaiChuyen"] = "BamChi";
                                        dr["NgayChuyen"] = bamchi.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "DCBD":
                                    DCBD dcbd = _cDCBD.getDCBDbyMaDon_TXL(decimal.Parse(item["MaDon"].ToString()));
                                    if (dcbd != null)
                                    {
                                        dr["LoaiChuyen"] = "DCBD";
                                        dr["NgayChuyen"] = dcbd.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "TTTL":
                                    TTTL tttl = _cTTTL.getTTTLbyMaDon_TXL(decimal.Parse(item["MaDon"].ToString()));
                                    if (tttl != null)
                                    {
                                        dr["LoaiChuyen"] = "TTTL";
                                        dr["NgayChuyen"] = tttl.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "DongNuoc":
                                    LinQ.DongNuoc dongnuoc = _cDongNuoc.getDongNuocbyMaDon_TXL(decimal.Parse(item["MaDon"].ToString()));
                                    if (dongnuoc != null)
                                    {
                                        dr["LoaiChuyen"] = "DongNuoc";
                                        dr["NgayChuyen"] = dongnuoc.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                case "CHDB":
                                    CHDB chdb = _cCHDB.getCHDBbyMaDon_TXL(decimal.Parse(item["MaDon"].ToString()));
                                    if (chdb != null)
                                    {
                                        dr["LoaiChuyen"] = "CHDB";
                                        dr["NgayChuyen"] = chdb.CreateDate.Value.ToString("dd/MM/yyyy");
                                    }
                                    break;
                                default:
                                    break;
                            }
                            dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                        }
                    }
                }
                dateTu.Value = DateTime.Now;
                dateDen.Value = DateTime.Now;
                _tuNgay = _denNgay = "";

                rptChiTietDon rpt = new rptChiTietDon();
                rpt.SetDataSource(dsBaoCao);

                crystalReportViewer1.ReportSource = rpt;
            }
            //DataTable dt = new DataTable();
            //if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
            //    dt = _cDonKH.LoadBaoCaoDSDonKH(dateTu.Value, dateDen.Value);
            //else
            //    if (!string.IsNullOrEmpty(_tuNgay))
            //        dt = _cDonKH.LoadBaoCaoDSDonKH(dateTu.Value);

            //int SLDaXuLy = 0;
            //int SLChuaXuLy = 0;

            //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            //foreach (DataRow itemRow in dt.Rows)
            //{
            //    DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();
            //    dr["TuNgay"] = _tuNgay;
            //    dr["DenNgay"] = _denNgay;
            //    dr["MaLD"] = itemRow["MaLD"];
            //    dr["TenLD"] = itemRow["TenLD"];
            //    dr["MaDon"] = itemRow["MaDon"];
            //    dr["DanhBo"] = itemRow["DanhBo"];
            //    dr["TienTrinh"] = itemRow["TienTrinh"];
            //    if (string.IsNullOrEmpty(itemRow["TienTrinh"].ToString()))
            //        SLChuaXuLy++;
            //    else
            //        SLDaXuLy++;
            //    //dr["SoDanhBo"] = _cKTXM.countCTKTXMbyMaDon(decimal.Parse(itemRow["MaDon"].ToString()));
            //    dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
            //}

            //dateTu.Value = DateTime.Now;
            //dateDen.Value = DateTime.Now;
            //_tuNgay = _denNgay = "";

            //rptThongKeDonKH rpt = new rptThongKeDonKH();
            //rpt.SetDataSource(dsBaoCao);
            //rpt.SetParameterValue(0, SLChuaXuLy);
            //rpt.SetParameterValue(1, SLDaXuLy);

            //crystalReportViewer1.ReportSource = rpt;
        }
    }
}
