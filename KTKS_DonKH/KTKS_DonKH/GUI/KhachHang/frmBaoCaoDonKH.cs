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
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.BaoCao.ToXuLy;

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
        CLoaiDon _cLoaiDon = new CLoaiDon();

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
                                    TTTL tttl = _cTTTL.GetByMaDon(decimal.Parse(item["MaDon"].ToString()));
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
                                    TTTL tttl = _cTTTL.GetByMaDon_TXL(decimal.Parse(item["MaDon"].ToString()));
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
                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptChiTietDon rpt = new rptChiTietDon();
                rpt.SetDataSource(dsBaoCao);

                crystalReportViewer1.ReportSource = rpt;
            }

            if (radThongKe.Checked)
            {
                if (chkToKH.Checked)
                {
                    DataTable dt = new DataTable();
                    if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                        dt = _cDonKH.LoadBaoCaoDSDonKH(dateTu.Value, dateDen.Value);
                    else
                        if (!string.IsNullOrEmpty(_tuNgay))
                            dt = _cDonKH.LoadBaoCaoDSDonKH(dateTu.Value);

                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();

                    LoaiDon[] a = new LoaiDon[_cLoaiDon.GetSoLuongLoaiDon() + 1];
                    for (int i = 0; i < _cLoaiDon.GetSoLuongLoaiDon() + 1; i++)
                    {
                        a[i] = new LoaiDon();
                        for (int j = 0; j < 17; j++)
                        {
                            a[i].Loai[j] = new LoaiCheck();
                        }
                    }

                    foreach (DataRow itemRow in dt.Rows)
                    {
                        int i = int.Parse(itemRow["MaLD"].ToString());
                        a[i].MaLD = itemRow["MaLD"].ToString();
                        a[i].TenLD = itemRow["TenLD"].ToString();
                        a[i].SoLuong++;
                        if (bool.Parse(itemRow["CapDM"].ToString()))
                        {
                            a[i].Loai[0].Loai = "Cấp định mức nước";
                            a[i].Loai[0].SoLuong++;
                        }
                        if (bool.Parse(itemRow["GiamDM"].ToString()))
                        {
                            a[i].Loai[1].Loai = "Giảm định mức nước";
                            a[i].Loai[1].SoLuong++;
                        }
                        if (bool.Parse(itemRow["CatChuyenDM"].ToString()))
                        {
                            a[i].Loai[2].Loai = "Cắt chuyển định mức nước";
                            a[i].Loai[2].SoLuong++;
                        }
                        if (bool.Parse(itemRow["KiemTraDHN"].ToString()))
                        {
                            a[i].Loai[3].Loai = "Kiểm tra ĐHN";
                            a[i].Loai[3].SoLuong++;
                        }
                        if (bool.Parse(itemRow["MatDHN"].ToString()))
                        {
                            a[i].Loai[4].Loai = "Mất ĐHN";
                            a[i].Loai[4].SoLuong++;
                        }
                        if (bool.Parse(itemRow["HuHongDHN"].ToString()))
                        {
                            a[i].Loai[5].Loai = "Hư hỏng ĐHN";
                            a[i].Loai[5].SoLuong++;
                        }
                        if (bool.Parse(itemRow["ChiNiem"].ToString()))
                        {
                            a[i].Loai[6].Loai = "Chì niêm";
                            a[i].Loai[6].SoLuong++;
                        }
                        if (bool.Parse(itemRow["TienNuoc"].ToString()))
                        {
                            a[i].Loai[7].Loai = "Tiền nước";
                            a[i].Loai[7].SoLuong++;
                        }
                        if (bool.Parse(itemRow["ChiSoNuoc"].ToString()))
                        {
                            a[i].Loai[8].Loai = "Chỉ số nước";
                            a[i].Loai[8].SoLuong++;
                        }
                        if (bool.Parse(itemRow["DieuChinhSoNha"].ToString()))
                        {
                            a[i].Loai[9].Loai = "Điều chỉnh số nhà";
                            a[i].Loai[9].SoLuong++;
                        }
                        if (bool.Parse(itemRow["ThayDoiTenHopDong"].ToString()))
                        {
                            a[i].Loai[10].Loai = "Thay đổi tên hợp đồng";
                            a[i].Loai[10].SoLuong++;
                        }
                        if (bool.Parse(itemRow["ThayDoiMST"].ToString()))
                        {
                            a[i].Loai[11].Loai = "Thay đổi mã số thuế";
                            a[i].Loai[11].SoLuong++;
                        }
                        if (bool.Parse(itemRow["ThayDoiGiaNuoc"].ToString()))
                        {
                            a[i].Loai[12].Loai = "Thay đổi giá nước";
                            a[i].Loai[12].SoLuong++;
                        }
                        if (bool.Parse(itemRow["TamNgung"].ToString()))
                        {
                            a[i].Loai[13].Loai = "Tạm ngưng sử dụng nước";
                            a[i].Loai[13].SoLuong++;
                        }
                        if (bool.Parse(itemRow["HuyHopDong"].ToString()))
                        {
                            a[i].Loai[14].Loai = "Hủy hợp đồng";
                            a[i].Loai[14].SoLuong++;
                        }
                        if (bool.Parse(itemRow["MoNuoc"].ToString()))
                        {
                            a[i].Loai[15].Loai = "Mở nước";
                            a[i].Loai[15].SoLuong++;
                        }
                        if (bool.Parse(itemRow["LoaiKhac"].ToString()))
                        {
                            a[i].Loai[16].Loai = "Lý Do Khác";
                            a[i].Loai[16].SoLuong++;
                        }
                    }

                    foreach (LoaiDon item in a)
                    {
                        foreach (LoaiCheck itemb in item.Loai)
                            if (itemb.SoLuong > 0)
                            {
                                DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();
                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;
                                dr["MaLD"] = item.MaLD;
                                dr["TenLD"] = item.TenLD;
                                dr["MaDon"] = item.SoLuong;
                                dr["Loai"] = itemb.Loai;
                                dr["SoLuong"] = itemb.SoLuong;
                                dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
                            }
                    }
                    //dateTu.Value = DateTime.Now;
                    //dateDen.Value = DateTime.Now;
                    //_tuNgay = _denNgay = "";

                    rptThongKeDonKH rpt = new rptThongKeDonKH();
                    rpt.SetDataSource(dsBaoCao);
                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                    crystalReportViewer1.ReportSource = rpt;
                }

                if (chkTXL.Checked)
                {
                    DataTable dt = new DataTable();
                    if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                        dt = _cDonTXL.LoadDSDonTXLByDates(dateTu.Value, dateDen.Value);
                    else
                        if (!string.IsNullOrEmpty(_tuNgay))
                            dt = _cDonTXL.LoadDSDonTXLByDate(dateTu.Value);

                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();

                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();
                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        dr["TenLD"] = item["TenLD"];
                        dr["MaDon"] = item["MaDon"];
                        dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                    }

                    //dateTu.Value = DateTime.Now;
                    //dateDen.Value = DateTime.Now;
                    //_tuNgay = _denNgay = "";

                    rptThongKeDonTXL rpt = new rptThongKeDonTXL();
                    rpt.SetDataSource(dsBaoCao);
                    crystalReportViewer1.ReportSource = rpt;
                }
            }
        }

        class LoaiDon
        {
            public int SoLuong=0;
            public string MaLD;
            public string TenLD;
            //public int CapDM = 0;
            //public int GiamDM = 0;
            //public int ChuyenDM = 0;
            //public int DHN = 0;
            //public int MatDHN = 0;
            //public int HuHongDHN = 0;
            //public int ChiNiem = 0;
            //public int TinhTienNuoc = 0;
            //public int GhiChiSoNuoc = 0;
            //public int DieuChinhSoNha = 0;
            //public int ThayDoiTenHopDong = 0;
            //public int ThayDoiMST = 0;
            //public int ThayDoiGiaNuoc = 0;
            //public int TamNgung = 0;
            //public int HuyHopDong = 0;
            //public int MoNuoc = 0;
            //public int LoaiKhac = 0;
            public LoaiCheck[] Loai = new LoaiCheck[17];
        };

        class LoaiCheck
        {
            public string Loai;
            public int SoLuong;
        }

        private void chkToKH_CheckedChanged(object sender, EventArgs e)
        {
            if (radThongKe.Checked)
                if (chkToKH.Checked)
                    chkTXL.Checked = false;
        }

        private void chkTXL_CheckedChanged(object sender, EventArgs e)
        {
            if (radThongKe.Checked)
                if (chkTXL.Checked)
                    chkToKH.Checked = false;
        }
    }
}
