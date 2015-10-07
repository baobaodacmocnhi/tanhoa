using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.TongHop;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.TongHop;
using CrystalDecisions.CrystalReports.Engine;

namespace ThuTien.GUI.TongHop
{
    public partial class frmBaoCaoTongHop : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CChuyenNoKhoDoi _cCNKD = new CChuyenNoKhoDoi();

        public frmBaoCaoTongHop()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTongHop_Load(object sender, EventArgs e)
        {
            dateGiaiTrachTongHopDangNgan.Value = DateTime.Now;
        }

        ///Tổng hợp 3 report thành 1
//        private void btnTongHopDangNganDoi1_Click(object sender, EventArgs e)
//        {
//            List<TT_To> lst = _cTo.GetDS();
//            DataTable dt = new DataTable();
//            DataTable dtTG = new DataTable();
//            DataTable dtCQ = new DataTable();
//            DataTable dtCNKD = new DataTable();
//            DataTable dtCNKDTG = new DataTable();
//            DataTable dtCNKDCQ = new DataTable();
//            int TongHD = 0;
//            long TongGiaBanTM = 0;
//            long TongThueGTGTTM = 0;
//            long TongPhiBVMTTM = 0;
//            long TongCongTM = 0;
//            long TongGiaBanCK = 0;
//            long TongThueGTGTCK = 0;
//            long TongPhiBVMTCK = 0;
//            long TongCongCK = 0;

//            dt = _cHoaDon.GetTongHopDangNgan(dateGiaiTrachTongHopDangNgan.Value);
//            dtTG = _cHoaDon.GetTongHopDangNgan("TG", lst[0].MaTo, dateGiaiTrachTongHopDangNgan.Value);
//            dtCQ = _cHoaDon.GetTongHopDangNgan("CQ", lst[0].MaTo, dateGiaiTrachTongHopDangNgan.Value);
//            for (int i = 1; i < lst.Count; i++)
//            {
//                dtTG.Merge(_cHoaDon.GetTongHopDangNgan("TG", lst[i].MaTo, dateGiaiTrachTongHopDangNgan.Value));
//                dtCQ.Merge(_cHoaDon.GetTongHopDangNgan("CQ", lst[i].MaTo, dateGiaiTrachTongHopDangNgan.Value));
//            }

//            dtCNKD = _cCNKD.GetTongHopDangNgan(dateGiaiTrachTongHopDangNgan.Value);
//            dtCNKDTG = _cCNKD.GetTongHopDangNgan("TG", dateGiaiTrachTongHopDangNgan.Value);
//            dtCNKDCQ = _cCNKD.GetTongHopDangNgan("CQ", dateGiaiTrachTongHopDangNgan.Value);

//            #region Tổng Hợp

//            dsBaoCao dsTongHop = new dsBaoCao();
//            foreach (DataRow item in dt.Rows)
//            {
//                TongHD += int.Parse(item["TongHD"].ToString());
//                if (bool.Parse(item["ChuyenKhoan"].ToString()))
//                {
//                    TongGiaBanCK += long.Parse(item["TongGiaBan"].ToString());
//                    TongThueGTGTCK += long.Parse(item["TongThueGTGT"].ToString());
//                    TongPhiBVMTCK += long.Parse(item["TongPhiBVMT"].ToString());
//                    TongCongCK += long.Parse(item["TongCong"].ToString());
//                }
//                else
//                {
//                    TongGiaBanTM += long.Parse(item["TongGiaBan"].ToString());
//                    TongThueGTGTTM += long.Parse(item["TongThueGTGT"].ToString());
//                    TongPhiBVMTTM += long.Parse(item["TongPhiBVMT"].ToString());
//                    TongCongTM += long.Parse(item["TongCong"].ToString());
//                }
//            }
//            foreach (DataRow item in dt.Rows)
//            {
//                DataRow dr = dsTongHop.Tables["TongHopDangNgan"].NewRow();
//                dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
//                dr["LoaiBaoCao"] = "TƯ GIA";
//                dr["HoTen"] = item["HoTen"];

//                ///Tính dùm Tổng HĐ vì report không tính được
//                dr["Tong"] = TongHD;

//                dr["TongGiaBanCK"] = TongGiaBanCK;
//                dr["TongThueGTGTCK"] = TongThueGTGTCK;
//                dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
//                dr["TongCongCK"] = TongCongCK;

//                dr["TongGiaBanTM"] = TongGiaBanTM;
//                dr["TongThueGTGTTM"] = TongThueGTGTTM;
//                dr["TongPhiBVMTTM"] = TongPhiBVMTTM;
//                dr["TongCongTM"] = TongCongTM;

//                dr["TongHD"] = item["TongHD"];
//                dr["TongGiaBan"] = item["TongGiaBan"];
//                dr["TongThueGTGT"] = item["TongThueGTGT"];
//                dr["TongPhiBVMT"] = item["TongPhiBVMT"];
//                dr["TongCong"] = item["TongCong"];

//                if (dtCNKD.Rows.Count > 0)
//                {
//                    dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
//                    dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
//                    dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
//                    dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
//                }

//                dr["NhanVien"] = CNguoiDung.HoTen;
//                dsTongHop.Tables["TongHopDangNgan"].Rows.Add(dr);
//            }

//            #endregion

//            #region Chi Tiết

//            dsBaoCao dsChiTiet = new dsBaoCao();

//            TongGiaBanTM = 0;
//            TongThueGTGTTM = 0;
//            TongPhiBVMTTM = 0;
//            TongCongTM = 0;
//            TongGiaBanCK = 0;
//            TongThueGTGTCK = 0;
//            TongPhiBVMTCK = 0;
//            TongCongCK = 0;
//            foreach (DataRow item in dtTG.Rows)
//            {
//                if (bool.Parse(item["ChuyenKhoan"].ToString()))
//                {
//                    TongGiaBanCK += long.Parse(item["TongGiaBan"].ToString());
//                    TongThueGTGTCK += long.Parse(item["TongThueGTGT"].ToString());
//                    TongPhiBVMTCK += long.Parse(item["TongPhiBVMT"].ToString());
//                    TongCongCK += long.Parse(item["TongCong"].ToString());
//                }
//                else
//                {
//                    TongGiaBanTM += long.Parse(item["TongGiaBan"].ToString());
//                    TongThueGTGTTM += long.Parse(item["TongThueGTGT"].ToString());
//                    TongPhiBVMTTM += long.Parse(item["TongPhiBVMT"].ToString());
//                    TongCongTM += long.Parse(item["TongCong"].ToString());
//                }
//            }
//            foreach (DataRow item in dtTG.Rows)
//            {
//                DataRow dr = dsChiTiet.Tables["TongHopDangNgan"].NewRow();
//                dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
//                dr["LoaiBaoCao"] = "TƯ GIA";
//                dr["HoTen"] = item["HoTen"];

//                dr["TongGiaBanCK"] = TongGiaBanCK;
//                dr["TongThueGTGTCK"] = TongThueGTGTCK;
//                dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
//                dr["TongCongCK"] = TongCongCK;

//                dr["TongGiaBanTM"] = TongGiaBanTM;
//                dr["TongThueGTGTTM"] = TongThueGTGTTM;
//                dr["TongPhiBVMTTM"] = TongPhiBVMTTM;
//                dr["TongCongTM"] = TongCongTM;

//                dr["TongHD"] = item["TongHD"];
//                dr["TongGiaBan"] = item["TongGiaBan"];
//                dr["TongThueGTGT"] = item["TongThueGTGT"];
//                dr["TongPhiBVMT"] = item["TongPhiBVMT"];
//                dr["TongCong"] = item["TongCong"];

//                if (dtCNKDTG.Rows.Count > 0)
//                {
//                    dr["TongHDCNKD"] = dtCNKDTG.Rows[0]["TongHD"];
//                    dr["TongGiaBanCNKD"] = dtCNKDTG.Rows[0]["TongGiaBan"];
//                    dr["TongThueGTGTCNKD"] = dtCNKDTG.Rows[0]["TongThueGTGT"];
//                    dr["TongPhiBVMTCNKD"] = dtCNKDTG.Rows[0]["TongPhiBVMT"];
//                }

//                dr["NhanVien"] = CNguoiDung.HoTen;
//                dsChiTiet.Tables["TongHopDangNgan"].Rows.Add(dr);
//            }

//            TongGiaBanTM = 0;
//            TongThueGTGTTM = 0;
//            TongPhiBVMTTM = 0;
//            TongCongTM = 0;
//            TongGiaBanCK = 0;
//            TongThueGTGTCK = 0;
//            TongPhiBVMTCK = 0;
//            TongCongCK = 0;
//            foreach (DataRow item in dtCQ.Rows)
//            {
//                if (bool.Parse(item["ChuyenKhoan"].ToString()))
//                {
//                    TongGiaBanCK += long.Parse(item["TongGiaBan"].ToString());
//                    TongThueGTGTCK += long.Parse(item["TongThueGTGT"].ToString());
//                    TongPhiBVMTCK += long.Parse(item["TongPhiBVMT"].ToString());
//                    TongCongCK += long.Parse(item["TongCong"].ToString());
//                }
//                else
//                {
//                    TongGiaBanTM += long.Parse(item["TongGiaBan"].ToString());
//                    TongThueGTGTTM += long.Parse(item["TongThueGTGT"].ToString());
//                    TongPhiBVMTTM += long.Parse(item["TongPhiBVMT"].ToString());
//                    TongCongTM += long.Parse(item["TongCong"].ToString());
//                }
//            }
//            foreach (DataRow item in dtCQ.Rows)
//            {
//                DataRow dr = dsChiTiet.Tables["TongHopDangNgan"].NewRow();
//                dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
//                dr["LoaiBaoCao"] = "CƠ QUAN";
//                dr["HoTen"] = item["HoTen"];

//                dr["TongGiaBanCK"] = TongGiaBanCK;
//                dr["TongThueGTGTCK"] = TongThueGTGTCK;
//                dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
//                dr["TongCongCK"] = TongCongCK;

//                dr["TongGiaBanTM"] = TongGiaBanTM;
//                dr["TongThueGTGTTM"] = TongThueGTGTTM;
//                dr["TongPhiBVMTTM"] = TongPhiBVMTTM;
//                dr["TongCongTM"] = TongCongTM;

//                dr["TongHD"] = item["TongHD"];
//                dr["TongGiaBan"] = item["TongGiaBan"];
//                dr["TongThueGTGT"] = item["TongThueGTGT"];
//                dr["TongPhiBVMT"] = item["TongPhiBVMT"];
//                dr["TongCong"] = item["TongCong"];

//                if (dtCNKDCQ.Rows.Count > 0)
//                {
//                    dr["TongHDCNKD"] = dtCNKDCQ.Rows[0]["TongHD"];
//                    dr["TongGiaBanCNKD"] = dtCNKDCQ.Rows[0]["TongGiaBan"];
//                    dr["TongThueGTGTCNKD"] = dtCNKDCQ.Rows[0]["TongThueGTGT"];
//                    dr["TongPhiBVMTCNKD"] = dtCNKDCQ.Rows[0]["TongPhiBVMT"];
//                }

//                dr["NhanVien"] = CNguoiDung.HoTen;
//                dsChiTiet.Tables["TongHopDangNgan"].Rows.Add(dr);
//            }

//#endregion

//            rptTongHopDangNgan rpt = new rptTongHopDangNgan();
//            rpt.SetDataSource(dsTongHop);
//            rpt.Subreports[0].SetDataSource(dsChiTiet);
//            frmBaoCao frm = new frmBaoCao(rpt);
//            frm.ShowDialog();

//        }

        private void btnTongHopDangNganDoi_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtCNKD = new DataTable();
            long TongGiaBanTM = 0;
            long TongThueGTGTTM = 0;
            long TongPhiBVMTTM = 0;
            long TongCongTM = 0;
            long TongGiaBanCK = 0;
            long TongThueGTGTCK = 0;
            long TongPhiBVMTCK = 0;
            long TongCongCK = 0;
            long TienDu = 0;
            long TienMat = 0;

            dt = _cHoaDon.GetTongHopDangNganDoi("TG", dateGiaiTrachTongHopDangNgan.Value);
            dt.Merge( _cHoaDon.GetTongHopDangNganDoi("CQ", dateGiaiTrachTongHopDangNgan.Value));
            dt.Merge(_cHoaDon.GetTongHopDangNganDoi("CK", dateGiaiTrachTongHopDangNgan.Value));
            dtCNKD = _cCNKD.GetTongHopDangNgan(dateGiaiTrachTongHopDangNgan.Value);

            DataTable dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD(dateGiaiTrachTongHopDangNgan.Value);
            if (dtCNKD_DCHD.Rows.Count > 0 && dtCNKD.Rows.Count > 0)
            {
                dtCNKD.Rows[0]["TongGiaBan"] = int.Parse(dtCNKD.Rows[0]["TongGiaBan"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongGiaBan"].ToString());
                dtCNKD.Rows[0]["TongThueGTGT"] = int.Parse(dtCNKD.Rows[0]["TongThueGTGT"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongThueGTGT"].ToString());
                dtCNKD.Rows[0]["TongPhiBVMT"] = int.Parse(dtCNKD.Rows[0]["TongPhiBVMT"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongPhiBVMT"].ToString());
                dtCNKD.Rows[0]["TongCong"] = int.Parse(dtCNKD.Rows[0]["TongCong"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongCong"].ToString());
            }

            foreach (DataRow item in dt.Rows)
            {
                if (bool.Parse(item["ChuyenKhoan"].ToString()))
                {
                    TongGiaBanCK += long.Parse(item["TongGiaBan"].ToString());
                    TongThueGTGTCK += long.Parse(item["TongThueGTGT"].ToString());
                    TongPhiBVMTCK += long.Parse(item["TongPhiBVMT"].ToString());
                    TongCongCK += long.Parse(item["TongCong"].ToString());
                    if (!string.IsNullOrEmpty(item["TienDu"].ToString()))
                    TienDu += long.Parse(item["TienDu"].ToString());
                    if (!string.IsNullOrEmpty(item["TienMat"].ToString()))
                    TienMat += long.Parse(item["TienMat"].ToString());
                }
                else
                {
                    TongGiaBanTM += long.Parse(item["TongGiaBan"].ToString());
                    TongThueGTGTTM += long.Parse(item["TongThueGTGT"].ToString());
                    TongPhiBVMTTM += long.Parse(item["TongPhiBVMT"].ToString());
                    TongCongTM += long.Parse(item["TongCong"].ToString());
                }
            }

            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
                dr["LoaiBaoCao"] = "THU TIỀN";
                dr["HoTen"] = item["HoTen"];

                dr["TongGiaBanCK"] = TongGiaBanCK;
                dr["TongThueGTGTCK"] = TongThueGTGTCK;
                dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                dr["TongCongCK"] = TongCongCK;
                dr["TienDu"] = TienDu;
                dr["TienMat"] = TienMat;

                dr["TongGiaBanTM"] = TongGiaBanTM;
                dr["TongThueGTGTTM"] = TongThueGTGTTM;
                dr["TongPhiBVMTTM"] = TongPhiBVMTTM;
                dr["TongCongTM"] = TongCongTM;

                dr["TongHD"] = item["TongHD"];
                dr["TongGiaBan"] = item["TongGiaBan"];
                dr["TongThueGTGT"] = item["TongThueGTGT"];
                dr["TongPhiBVMT"] = item["TongPhiBVMT"];
                dr["TongCong"] = item["TongCong"];

                if (dtCNKD.Rows.Count > 0)
                {
                    dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                    dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                    dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                    dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                    dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];
                }
                dr["NhanVien"] = CNguoiDung.HoTen;
                ds.Tables["TongHopDangNgan"].Rows.Add(dr);
            }

            if(dt.Rows.Count==0)
                if (dtCNKD.Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                    dr["LoaiBaoCao"] = "THU TIỀN";
                    dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                    dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                    dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                    dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                    dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                }

            ReportDocument rpt = new rptTongHopDangNgan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnTongHopDangNganTG_Click(object sender, EventArgs e)
        {
            List<TT_To> lst = _cTo.GetDS();
            DataTable dt = new DataTable();
            DataTable dtCNKD = new DataTable();
            long TongGiaBanTM = 0;
            long TongThueGTGTTM = 0;
            long TongPhiBVMTTM = 0;
            long TongCongTM = 0;
            long TongGiaBanCK = 0;
            long TongThueGTGTCK = 0;
            long TongPhiBVMTCK = 0;
            long TongCongCK = 0;

            dt = _cHoaDon.GetTongHopDangNganChiTiet_HanhThuTG(dateGiaiTrachTongHopDangNgan.Value);
            for (int i = 0; i < lst.Count; i++)
                if (lst[i].HanhThu == false)
                {
                    dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet("TG", lst[i].MaTo, dateGiaiTrachTongHopDangNgan.Value));
                }

            dtCNKD = _cCNKD.GetTongHopDangNgan("TG", dateGiaiTrachTongHopDangNgan.Value);

            DataTable dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD("TG",dateGiaiTrachTongHopDangNgan.Value);
            if (dtCNKD_DCHD.Rows.Count > 0 && dtCNKD.Rows.Count > 0)
            {
                dtCNKD.Rows[0]["TongGiaBan"] = int.Parse(dtCNKD.Rows[0]["TongGiaBan"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongGiaBan"].ToString());
                dtCNKD.Rows[0]["TongThueGTGT"] = int.Parse(dtCNKD.Rows[0]["TongThueGTGT"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongThueGTGT"].ToString());
                dtCNKD.Rows[0]["TongPhiBVMT"] = int.Parse(dtCNKD.Rows[0]["TongPhiBVMT"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongPhiBVMT"].ToString());
                dtCNKD.Rows[0]["TongCong"] = int.Parse(dtCNKD.Rows[0]["TongCong"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongCong"].ToString());
            }

            foreach (DataRow item in dt.Rows)
            {
                if (bool.Parse(item["ChuyenKhoan"].ToString()))
                {
                    TongGiaBanCK += long.Parse(item["TongGiaBan"].ToString());
                    TongThueGTGTCK += long.Parse(item["TongThueGTGT"].ToString());
                    TongPhiBVMTCK += long.Parse(item["TongPhiBVMT"].ToString());
                    TongCongCK += long.Parse(item["TongCong"].ToString());
                }
                else
                {
                    if (!string.IsNullOrEmpty(item["TongGiaBan"].ToString()))
                        TongGiaBanTM += long.Parse(item["TongGiaBan"].ToString());
                    if (!string.IsNullOrEmpty(item["TongThueGTGT"].ToString()))
                        TongThueGTGTTM += long.Parse(item["TongThueGTGT"].ToString());
                    if (!string.IsNullOrEmpty(item["TongPhiBVMT"].ToString()))
                        TongPhiBVMTTM += long.Parse(item["TongPhiBVMT"].ToString());
                    if (!string.IsNullOrEmpty(item["TongCong"].ToString()))
                        TongCongTM += long.Parse(item["TongCong"].ToString());
                }
            }

            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
                dr["LoaiBaoCao"] = "TƯ GIA";
                dr["HoTen"] = item["HoTen"];

                dr["TongGiaBanCK"] = TongGiaBanCK;
                dr["TongThueGTGTCK"] = TongThueGTGTCK;
                dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                dr["TongCongCK"] = TongCongCK;

                dr["TongGiaBanTM"] = TongGiaBanTM;
                dr["TongThueGTGTTM"] = TongThueGTGTTM;
                dr["TongPhiBVMTTM"] = TongPhiBVMTTM;
                dr["TongCongTM"] = TongCongTM;

                dr["TongHD"] = item["TongHD"];
                dr["TongGiaBan"] = item["TongGiaBan"];
                dr["TongThueGTGT"] = item["TongThueGTGT"];
                dr["TongPhiBVMT"] = item["TongPhiBVMT"];
                dr["TongCong"] = item["TongCong"];

                if (dtCNKD.Rows.Count > 0)
                {
                    dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                    dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                    dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                    dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                    dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];
                }
                dr["NhanVien"] = CNguoiDung.HoTen;
                ds.Tables["TongHopDangNgan"].Rows.Add(dr);
            }

            if (dt.Rows.Count == 0)
                if (dtCNKD.Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA";
                    dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                    dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                    dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                    dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                    dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                }

            ReportDocument rpt = new rptTongHopDangNganChiTiet();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnTongHopDangNganCQ_Click(object sender, EventArgs e)
        {
            List<TT_To> lst = _cTo.GetDS();
            DataTable dt = new DataTable();
            DataTable dtCNKD = new DataTable();
            long TongGiaBanTM = 0;
            long TongThueGTGTTM = 0;
            long TongPhiBVMTTM = 0;
            long TongCongTM = 0;
            long TongGiaBanCK = 0;
            long TongThueGTGTCK = 0;
            long TongPhiBVMTCK = 0;
            long TongCongCK = 0;

            dt = _cHoaDon.GetTongHopDangNganChiTiet("CQ", lst[0].MaTo, dateGiaiTrachTongHopDangNgan.Value);
            for (int i = 1; i < lst.Count; i++)
            {
                dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet("CQ", lst[i].MaTo, dateGiaiTrachTongHopDangNgan.Value));
            }

            dtCNKD = _cCNKD.GetTongHopDangNgan("CQ", dateGiaiTrachTongHopDangNgan.Value);

            DataTable dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD("CQ", dateGiaiTrachTongHopDangNgan.Value);
            if (dtCNKD_DCHD.Rows.Count > 0 && dtCNKD.Rows.Count > 0)
            {
                dtCNKD.Rows[0]["TongGiaBan"] = int.Parse(dtCNKD.Rows[0]["TongGiaBan"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongGiaBan"].ToString());
                dtCNKD.Rows[0]["TongThueGTGT"] = int.Parse(dtCNKD.Rows[0]["TongThueGTGT"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongThueGTGT"].ToString());
                dtCNKD.Rows[0]["TongPhiBVMT"] = int.Parse(dtCNKD.Rows[0]["TongPhiBVMT"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongPhiBVMT"].ToString());
                dtCNKD.Rows[0]["TongCong"] = int.Parse(dtCNKD.Rows[0]["TongCong"].ToString()) - int.Parse(dtCNKD_DCHD.Rows[0]["TongCong"].ToString());
            }

            foreach (DataRow item in dt.Rows)
            {
                if (bool.Parse(item["ChuyenKhoan"].ToString()))
                {
                    TongGiaBanCK += long.Parse(item["TongGiaBan"].ToString());
                    TongThueGTGTCK += long.Parse(item["TongThueGTGT"].ToString());
                    TongPhiBVMTCK += long.Parse(item["TongPhiBVMT"].ToString());
                    TongCongCK += long.Parse(item["TongCong"].ToString());
                }
                else
                {
                    TongGiaBanTM += long.Parse(item["TongGiaBan"].ToString());
                    TongThueGTGTTM += long.Parse(item["TongThueGTGT"].ToString());
                    TongPhiBVMTTM += long.Parse(item["TongPhiBVMT"].ToString());
                    TongCongTM += long.Parse(item["TongCong"].ToString());
                }
            }

            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
                dr["LoaiBaoCao"] = "CƠ QUAN";
                dr["HoTen"] = item["HoTen"];

                dr["TongGiaBanCK"] = TongGiaBanCK;
                dr["TongThueGTGTCK"] = TongThueGTGTCK;
                dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                dr["TongCongCK"] = TongCongCK;

                dr["TongGiaBanTM"] = TongGiaBanTM;
                dr["TongThueGTGTTM"] = TongThueGTGTTM;
                dr["TongPhiBVMTTM"] = TongPhiBVMTTM;
                dr["TongCongTM"] = TongCongTM;

                dr["TongHD"] = item["TongHD"];
                dr["TongGiaBan"] = item["TongGiaBan"];
                dr["TongThueGTGT"] = item["TongThueGTGT"];
                dr["TongPhiBVMT"] = item["TongPhiBVMT"];
                dr["TongCong"] = item["TongCong"];

                if (dtCNKD.Rows.Count > 0)
                {
                    dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                    dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                    dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                    dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                    dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];
                }
                dr["NhanVien"] = CNguoiDung.HoTen;
                ds.Tables["TongHopDangNgan"].Rows.Add(dr);
            }

            if (dt.Rows.Count == 0)
                if (dtCNKD.Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                    dr["LoaiBaoCao"] = "CƠ QUAN";
                    dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                    dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                    dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                    dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                    dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                    dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                }

            ReportDocument rpt = new rptTongHopDangNganChiTiet();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }
       
    }
}
