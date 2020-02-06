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
            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";

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
            if (!chkPhanKy.Checked)
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
                //long TongTienDu = 0;
                long TongTienMat = 0;

                dt = _cHoaDon.GetTongHopDangNganDoi("TG", dateGiaiTrachTongHopDangNgan.Value);
                dt.Merge(_cHoaDon.GetTongHopDangNganDoi("CQ", dateGiaiTrachTongHopDangNgan.Value));
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
                        //if (!string.IsNullOrEmpty(item["TongTienDu"].ToString()))
                        //TongTienDu += long.Parse(item["TongTienDu"].ToString());
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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
                    //dr["TongTienDu"] = TongTienDu;
                    dr["TongTienMat"] = TongTienMat;

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
                        dr["LoaiBaoCao"] = "THU TIỀN";
                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }

                rptTongHopDangNgan rpt = new rptTongHopDangNgan();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
            ///Phân kỳ
            else
            {
                ///Lớn
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
                long TongTienMat = 0;

                dt = _cHoaDon.GetTongHopDangNganDoi_PhanKyLon("TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
                dt.Merge(_cHoaDon.GetTongHopDangNganDoi_PhanKyLon("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                dt.Merge(_cHoaDon.GetTongHopDangNganDoi_PhanKyLon("CK", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                dtCNKD = _cCNKD.GetTongHopDangNgan_PhanKyLon(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);

                DataTable dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD_PhanKyLon(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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

                    dr["PhanKy"] = "Kỳ " + cmbKy.SelectedItem.ToString();

                    dr["TongGiaBanCK"] = TongGiaBanCK;
                    dr["TongThueGTGTCK"] = TongThueGTGTCK;
                    dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                    dr["TongCongCK"] = TongCongCK;
                    dr["TongTienMat"] = TongTienMat;

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
                        dr["LoaiBaoCao"] = "THU TIỀN";

                        dr["PhanKy"] = "Kỳ " + cmbKy.SelectedItem.ToString();

                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }
                ///Nhỏ
                dt = new DataTable();
                dtCNKD = new DataTable();
                TongGiaBanTM = 0;
                TongThueGTGTTM = 0;
                TongPhiBVMTTM = 0;
                TongCongTM = 0;
                TongGiaBanCK = 0;
                TongThueGTGTCK = 0;
                TongPhiBVMTCK = 0;
                TongCongCK = 0;
                TongTienMat = 0;

                dt = _cHoaDon.GetTongHopDangNganDoi_PhanKyNho("TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
                dt.Merge(_cHoaDon.GetTongHopDangNganDoi_PhanKyNho("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                dt.Merge(_cHoaDon.GetTongHopDangNganDoi_PhanKyNho("CK", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                dtCNKD = _cCNKD.GetTongHopDangNgan_PhanKyNho(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);

                dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD_PhanKyNho(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
                    }
                    else
                    {
                        TongGiaBanTM += long.Parse(item["TongGiaBan"].ToString());
                        TongThueGTGTTM += long.Parse(item["TongThueGTGT"].ToString());
                        TongPhiBVMTTM += long.Parse(item["TongPhiBVMT"].ToString());
                        TongCongTM += long.Parse(item["TongCong"].ToString());
                    }
                }

                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                    dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
                    dr["LoaiBaoCao"] = "THU TIỀN";
                    dr["HoTen"] = item["HoTen"];

                    dr["PhanKy"] = "Kỳ <" + cmbKy.SelectedItem.ToString();

                    dr["TongGiaBanCK"] = TongGiaBanCK;
                    dr["TongThueGTGTCK"] = TongThueGTGTCK;
                    dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                    dr["TongCongCK"] = TongCongCK;
                    dr["TongTienMat"] = TongTienMat;

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
                        dr["LoaiBaoCao"] = "THU TIỀN";

                        dr["PhanKy"] = "Kỳ <" + cmbKy.SelectedItem.ToString();

                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }
                rptTongHopDangNgan_PhanKy rpt = new rptTongHopDangNgan_PhanKy();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void btnTongHopDangNganTG_Click(object sender, EventArgs e)
        {
            if (!chkPhanKy.Checked)
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
                long TongTienMat = 0;

                //in kể cả người nghỉ phép
                dt = _cHoaDon.GetTongHopDangNganChiTiet_HanhThuTG(dateGiaiTrachTongHopDangNgan.Value);
                for (int i = 0; i < lst.Count; i++)
                    if (lst[i].HanhThu == false)
                    {
                        dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet("TG", lst[i].MaTo, dateGiaiTrachTongHopDangNgan.Value));
                    }
                //for (int i = 0; i < lst.Count; i++)
                //{
                //    dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet("TG", lst[i].MaTo, dateGiaiTrachTongHopDangNgan.Value));
                //}

                dtCNKD = _cCNKD.GetTongHopDangNgan("TG", dateGiaiTrachTongHopDangNgan.Value);

                DataTable dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD("TG", dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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
                    dr["TongTienMat"] = TongTienMat;

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

                rptTongHopDangNganChiTiet rpt = new rptTongHopDangNganChiTiet();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
            ///Phân kỳ
            else
            {
                ///Lớn
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
                long TongTienMat = 0;

                //in kể cả người nghỉ phép
                dt = _cHoaDon.GetTongHopDangNganChiTiet_HanhThuTG_PhanKyLon(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
                for (int i = 0; i < lst.Count; i++)
                    if (lst[i].HanhThu == false)
                    {
                        dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet_PhanKyLon("TG", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                    }
                //for (int i = 0; i < lst.Count; i++)
                //{
                //    dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet_PhanKyLon("TG", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                //}

                dtCNKD = _cCNKD.GetTongHopDangNgan_PhanKyLon("TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);

                DataTable dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD_PhanKyLon("TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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

                    dr["PhanKy"] = "Kỳ " + cmbKy.SelectedItem.ToString();

                    dr["TongGiaBanCK"] = TongGiaBanCK;
                    dr["TongThueGTGTCK"] = TongThueGTGTCK;
                    dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                    dr["TongCongCK"] = TongCongCK;
                    dr["TongTienMat"] = TongTienMat;

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

                        dr["PhanKy"] = "Kỳ " + cmbKy.SelectedItem.ToString();

                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }
                ///Nhỏ
                //List<TT_To> lst = _cTo.GetDS();
                dt = new DataTable();
                dtCNKD = new DataTable();
                TongGiaBanTM = 0;
                TongThueGTGTTM = 0;
                TongPhiBVMTTM = 0;
                TongCongTM = 0;
                TongGiaBanCK = 0;
                TongThueGTGTCK = 0;
                TongPhiBVMTCK = 0;
                TongCongCK = 0;
                TongTienMat = 0;

                //in kể cả người nghỉ phép
                dt = _cHoaDon.GetTongHopDangNganChiTiet_HanhThuTG_PhanKyNho(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
                for (int i = 0; i < lst.Count; i++)
                    if (lst[i].HanhThu == false)
                    {
                        dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet_PhanKyNho("TG", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                    }
                //for (int i = 0; i < lst.Count; i++)
                //{
                //    dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet_PhanKyNho("TG", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                //}

                dtCNKD = _cCNKD.GetTongHopDangNgan_PhanKyNho("TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);

                dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD_PhanKyNho("TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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

                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                    dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
                    dr["LoaiBaoCao"] = "TƯ GIA";
                    dr["HoTen"] = item["HoTen"];

                    dr["PhanKy"] = "Kỳ <" + cmbKy.SelectedItem.ToString();

                    dr["TongGiaBanCK"] = TongGiaBanCK;
                    dr["TongThueGTGTCK"] = TongThueGTGTCK;
                    dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                    dr["TongCongCK"] = TongCongCK;
                    dr["TongTienMat"] = TongTienMat;

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

                        dr["PhanKy"] = "Kỳ <" + cmbKy.SelectedItem.ToString();

                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }
                rptTongHopDangNganChiTiet_PhanKy rpt = new rptTongHopDangNganChiTiet_PhanKy();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void btnTongHopDangNganCQ_Click(object sender, EventArgs e)
        {
            if (!chkPhanKy.Checked)
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
                long TongTienMat = 0;

                //dt = _cHoaDon.GetTongHopDangNganChiTiet("CQ", lst[0].MaTo, dateGiaiTrachTongHopDangNgan.Value);
                for (int i = 0; i < lst.Count; i++)
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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
                    dr["TongTienMat"] = TongTienMat;

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

                rptTongHopDangNganChiTiet rpt = new rptTongHopDangNganChiTiet();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
            ///Phân kỳ
            else
            {
                ///Lớn
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
                long TongTienMat = 0;

                //dt = _cHoaDon.GetTongHopDangNganChiTiet_PhanKyLon("CQ", lst[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
                for (int i = 0; i < lst.Count; i++)
                {
                    dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet_PhanKyLon("CQ", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                }

                dtCNKD = _cCNKD.GetTongHopDangNgan_PhanKyLon("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);

                DataTable dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD_PhanKyLon("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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

                    dr["PhanKy"] = "Kỳ " + cmbKy.SelectedItem.ToString();

                    dr["TongGiaBanCK"] = TongGiaBanCK;
                    dr["TongThueGTGTCK"] = TongThueGTGTCK;
                    dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                    dr["TongCongCK"] = TongCongCK;
                    dr["TongTienMat"] = TongTienMat;

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

                        dr["PhanKy"] = "Kỳ " + cmbKy.SelectedItem.ToString();

                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }
                ///Nhỏ
                dt = new DataTable();
                dtCNKD = new DataTable();
                TongGiaBanTM = 0;
                TongThueGTGTTM = 0;
                TongPhiBVMTTM = 0;
                TongCongTM = 0;
                TongGiaBanCK = 0;
                TongThueGTGTCK = 0;
                TongPhiBVMTCK = 0;
                TongCongCK = 0;
                TongTienMat = 0;

                //dt = _cHoaDon.GetTongHopDangNganChiTiet_PhanKyNho("CQ", lst[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
                for (int i = 0; i < lst.Count; i++)
                {
                    dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet_PhanKyNho("CQ", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                }

                dtCNKD = _cCNKD.GetTongHopDangNgan_PhanKyNho("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);

                dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD_PhanKyNho("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
                    }
                    else
                    {
                        TongGiaBanTM += long.Parse(item["TongGiaBan"].ToString());
                        TongThueGTGTTM += long.Parse(item["TongThueGTGT"].ToString());
                        TongPhiBVMTTM += long.Parse(item["TongPhiBVMT"].ToString());
                        TongCongTM += long.Parse(item["TongCong"].ToString());
                    }
                }

                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                    dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
                    dr["LoaiBaoCao"] = "CƠ QUAN";
                    dr["HoTen"] = item["HoTen"];

                    dr["PhanKy"] = "Kỳ <" + cmbKy.SelectedItem.ToString();

                    dr["TongGiaBanCK"] = TongGiaBanCK;
                    dr["TongThueGTGTCK"] = TongThueGTGTCK;
                    dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                    dr["TongCongCK"] = TongCongCK;
                    dr["TongTienMat"] = TongTienMat;

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

                        dr["PhanKy"] = "Kỳ <" + cmbKy.SelectedItem.ToString();

                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }
                rptTongHopDangNganChiTiet_PhanKy rpt = new rptTongHopDangNganChiTiet_PhanKy();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void chkPhanKy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPhanKy.Checked)
            {
                cmbNam.Enabled = true;
                cmbKy.Enabled = true;
            }
            else
            {
                cmbNam.Enabled = false;
                cmbKy.Enabled = false;
            }
        }

        private void btnTongHopDangNganDoiMoi_Click(object sender, EventArgs e)
        {
            if (!chkPhanKy.Checked)
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
                long TongTienMat = 0;

                dt = _cHoaDon.GetTongHopDangNganChiTiet_HanhThu(dateGiaiTrachTongHopDangNgan.Value);
                for (int i = 0; i < lst.Count; i++)
                    if (lst[i].HanhThu == false)
                    {
                        dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet("", lst[i].MaTo, dateGiaiTrachTongHopDangNgan.Value));
                    }

                dtCNKD = _cCNKD.GetTongHopDangNgan("", dateGiaiTrachTongHopDangNgan.Value);

                DataTable dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD("", dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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
                    dr["LoaiBaoCao"] = "THU TIỀN";
                    dr["HoTen"] = item["HoTen"];

                    dr["TongGiaBanCK"] = TongGiaBanCK;
                    dr["TongThueGTGTCK"] = TongThueGTGTCK;
                    dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                    dr["TongCongCK"] = TongCongCK;
                    dr["TongTienMat"] = TongTienMat;

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
                        dr["LoaiBaoCao"] = "THU TIỀN";
                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }

                rptTongHopDangNgan rpt = new rptTongHopDangNgan();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
            ///Phân kỳ
            else
            {
                ///Lớn
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
                long TongTienMat = 0;

                dt = _cHoaDon.GetTongHopDangNganChiTiet_HanhThu_PhanKyLon(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
                for (int i = 0; i < lst.Count; i++)
                    if (lst[i].HanhThu == false)
                    {
                        dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet_PhanKyLon("", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                    }

                dtCNKD = _cCNKD.GetTongHopDangNgan_PhanKyLon("", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);

                DataTable dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD_PhanKyLon("", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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
                    dr["LoaiBaoCao"] = "THU TIỀN";
                    dr["HoTen"] = item["HoTen"];

                    dr["PhanKy"] = "Kỳ " + cmbKy.SelectedItem.ToString();

                    dr["TongGiaBanCK"] = TongGiaBanCK;
                    dr["TongThueGTGTCK"] = TongThueGTGTCK;
                    dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                    dr["TongCongCK"] = TongCongCK;
                    dr["TongTienMat"] = TongTienMat;

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
                        dr["LoaiBaoCao"] = "THU TIỀN";

                        dr["PhanKy"] = "Kỳ " + cmbKy.SelectedItem.ToString();

                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }
                ///Nhỏ
                //List<TT_To> lst = _cTo.GetDS();
                dt = new DataTable();
                dtCNKD = new DataTable();
                TongGiaBanTM = 0;
                TongThueGTGTTM = 0;
                TongPhiBVMTTM = 0;
                TongCongTM = 0;
                TongGiaBanCK = 0;
                TongThueGTGTCK = 0;
                TongPhiBVMTCK = 0;
                TongCongCK = 0;
                TongTienMat = 0;

                dt = _cHoaDon.GetTongHopDangNganChiTiet_HanhThu_PhanKyNho(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
                for (int i = 0; i < lst.Count; i++)
                    if (lst[i].HanhThu == false)
                    {
                        dt.Merge(_cHoaDon.GetTongHopDangNganChiTiet_PhanKyNho("", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value));
                    }

                dtCNKD = _cCNKD.GetTongHopDangNgan_PhanKyNho("", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);

                dtCNKD_DCHD = _cCNKD.GetTongHopDangNganDCHD_PhanKyNho("", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrachTongHopDangNgan.Value);
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
                        if (!string.IsNullOrEmpty(item["TongTienMat"].ToString()))
                            TongTienMat += long.Parse(item["TongTienMat"].ToString());
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

                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                    dr["Ngay"] = "Ngày " + dateGiaiTrachTongHopDangNgan.Value.Day + " tháng " + dateGiaiTrachTongHopDangNgan.Value.Month + " năm " + dateGiaiTrachTongHopDangNgan.Value.Year;
                    dr["LoaiBaoCao"] = "THU TIỀN";
                    dr["HoTen"] = item["HoTen"];

                    dr["PhanKy"] = "Kỳ <" + cmbKy.SelectedItem.ToString();

                    dr["TongGiaBanCK"] = TongGiaBanCK;
                    dr["TongThueGTGTCK"] = TongThueGTGTCK;
                    dr["TongPhiBVMTCK"] = TongPhiBVMTCK;
                    dr["TongCongCK"] = TongCongCK;
                    dr["TongTienMat"] = TongTienMat;

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
                        dr["LoaiBaoCao"] = "THU TIỀN";

                        dr["PhanKy"] = "Kỳ <" + cmbKy.SelectedItem.ToString();

                        dr["TongHDCNKD"] = dtCNKD.Rows[0]["TongHD"];
                        dr["TongGiaBanCNKD"] = dtCNKD.Rows[0]["TongGiaBan"];
                        dr["TongThueGTGTCNKD"] = dtCNKD.Rows[0]["TongThueGTGT"];
                        dr["TongPhiBVMTCNKD"] = dtCNKD.Rows[0]["TongPhiBVMT"];
                        dr["TongCongCNKD"] = dtCNKD.Rows[0]["TongCong"];

                        dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                    }
                rptTongHopDangNgan_PhanKy rpt = new rptTongHopDangNgan_PhanKy();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void btnIn_KeToan_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            DataTable dt = new DataTable();
            if (chkTheoThang.Checked == true)
                dt = _cHoaDon.getTongHopDangNgan_KeToan_TheoThang(dateTu_KeToan.Value, dateDen_KeToan.Value);
            else
                dt = _cHoaDon.getTongHopDangNgan_KeToan_TheoNgay(dateTu_KeToan.Value, dateDen_KeToan.Value);

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();

                dr["TuNgay"] = dateDen_KeToan.Value.Month.ToString("00");
                dr["DenNgay"] = dateDen_KeToan.Value.Year.ToString("0000");
                switch (item["PhanKy"].ToString())
                {
                    case "Cùng Kỳ":
                        dr["PhanKy"] = "của Kỳ " + dateDen_KeToan.Value.Month.ToString();
                        break;
                    case "Khác Kỳ":
                        dr["PhanKy"] = "từ Kỳ 1 - " + (dateDen_KeToan.Value.Month - 1).ToString();
                        break;
                    case "Khác Kỳ Năm":
                        dr["PhanKy"] = "của Kỳ 12 năm " + (dateDen_KeToan.Value.Year - 1).ToString() + " trở về trước";
                        break;
                    default:
                        break;
                }

                dr["Ngay"] = item["NgayGiaiTrach"];
                dr["STT"] = item["STT"];
                dr["TongGiaBan"] = item["GiaBan"];
                dr["TongThueGTGT"] = item["ThueGTGT"];
                dr["TongPhiBVMT"] = item["PhiBVMT"];
                dr["TongCong"] = item["TongCong"];

                ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                //add page tổng cộng
                DataRow drTC = ds.Tables["TongHopDangNgan"].NewRow();

                drTC["TuNgay"] = dateDen_KeToan.Value.Month.ToString("00");
                drTC["DenNgay"] = dateDen_KeToan.Value.Year.ToString("0000");
                drTC["PhanKy"] = "";
                drTC["Ngay"] = item["NgayGiaiTrach"];
                drTC["STT"] = item["STT"];
                drTC["TongGiaBan"] = item["GiaBan"];
                drTC["TongThueGTGT"] = item["ThueGTGT"];
                drTC["TongPhiBVMT"] = item["PhiBVMT"];
                drTC["TongCong"] = item["TongCong"];

                ds.Tables["TongHopDangNgan"].Rows.Add(drTC);
            }
            rptTongHopDangNgan_KeToan rpt = new rptTongHopDangNgan_KeToan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnXuatExcel_KeToan_Click(object sender, EventArgs e)
        {
            DataTable dtCungKy = _cHoaDon.getTongHopDangNgan_KeToan_CungKy(dateTu_KeToan.Value, dateDen_KeToan.Value);
            DataTable dtKhacKy = _cHoaDon.getTongHopDangNgan_KeToan_KhacKy(dateTu_KeToan.Value, dateDen_KeToan.Value);
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheetCungKy;
            Microsoft.Office.Interop.Excel.Worksheet oSheetKhacKy;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            //khai báo số lượng sheet
            oExcel.Application.SheetsInNewWorkbook = 2;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheetCungKy = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheetKhacKy = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

            XuatExcel(dtCungKy, oSheetCungKy, "Tiền Nước thu được Cùng kỳ");
            XuatExcel(dtKhacKy, oSheetKhacKy, "Tiền Nước thu được Khác kỳ");
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Ngày";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Loại";
            cl2.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Doanh thu tiền nước";
            cl3.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Thuế";
            cl4.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "Phí bảo vệ môi trường";
            cl5.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Tổng cộng";
            cl6.ColumnWidth = 20;
            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 6];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = DateTime.Parse(dr["NgayGiaiTrach"].ToString()).ToString("dd/MM/yyyy");
                arr[i, 1] = dr["Loai"].ToString();
                arr[i, 2] = dr["GiaBan"].ToString();
                arr[i, 3] = dr["ThueGTGT"].ToString();
                arr[i, 4] = dr["PhiBVMT"].ToString();
                arr[i, 5] = dr["TongCong"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 6;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            //Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            //Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            //c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            //Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            //Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            //c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //c3b.NumberFormat = "@";

            //Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            //Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            //Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            //c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            //Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            //Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            //c3d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            //Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            //Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            //c3e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //c3e.NumberFormat = "@";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            Microsoft.Office.Interop.Excel.Range c1sum1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 1];
            Microsoft.Office.Interop.Excel.Range c2sum1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 3, 1];
            Microsoft.Office.Interop.Excel.Range c3sum1 = oSheet.get_Range(c1sum1, c2sum1);
            c3sum1.MergeCells = true;

            Microsoft.Office.Interop.Excel.Range c1sum2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 4, 1];
            Microsoft.Office.Interop.Excel.Range c2sum2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 4, 2];
            Microsoft.Office.Interop.Excel.Range c3sum2 = oSheet.get_Range(c1sum2, c2sum2);
            c3sum2.MergeCells = true;

            oSheet.Cells[rowEnd + 1, 1] = "Tổng Cộng";
            oSheet.Cells[rowEnd + 1, 2] = "Hành Thu";
            oSheet.Cells[rowEnd + 2, 2] = "Quầy";
            oSheet.Cells[rowEnd + 3, 2] = "Chuyển Khoản";
            //
            oSheet.Cells[rowEnd + 1, 3] = dt.Compute("sum(GiaBan)", "Loai like 'Hành Thu'");
            oSheet.Cells[rowEnd + 2, 3] = dt.Compute("sum(GiaBan)", "Loai like 'Quầy'");
            oSheet.Cells[rowEnd + 3, 3] = dt.Compute("sum(GiaBan)", "Loai like 'Chuyển Khoản'");
            //
            oSheet.Cells[rowEnd + 1, 4] = dt.Compute("sum(ThueGTGT)", "Loai like 'Hành Thu'");
            oSheet.Cells[rowEnd + 2, 4] = dt.Compute("sum(ThueGTGT)", "Loai like 'Quầy'");
            oSheet.Cells[rowEnd + 3, 4] = dt.Compute("sum(ThueGTGT)", "Loai like 'Chuyển Khoản'");
            //
            oSheet.Cells[rowEnd + 1, 5] = dt.Compute("sum(PhiBVMT)", "Loai like 'Hành Thu'");
            oSheet.Cells[rowEnd + 2, 5] = dt.Compute("sum(PhiBVMT)", "Loai like 'Quầy'");
            oSheet.Cells[rowEnd + 3, 5] = dt.Compute("sum(PhiBVMT)", "Loai like 'Chuyển Khoản'");
            //
            oSheet.Cells[rowEnd + 1, 6] = dt.Compute("sum(TongCong)", "Loai like 'Hành Thu'");
            oSheet.Cells[rowEnd + 2, 6] = dt.Compute("sum(TongCong)", "Loai like 'Quầy'");
            oSheet.Cells[rowEnd + 3, 6] = dt.Compute("sum(TongCong)", "Loai like 'Chuyển Khoản'");
            //tổng cộng cuối
            oSheet.Cells[rowEnd + 4, 2] = "Tổng Cộng";
            oSheet.Cells[rowEnd + 4, 3] = dt.Compute("sum(GiaBan)", "");
            oSheet.Cells[rowEnd + 4, 4] = dt.Compute("sum(ThueGTGT)", "");
            oSheet.Cells[rowEnd + 4, 5] = dt.Compute("sum(PhiBVMT)", "");
            oSheet.Cells[rowEnd + 4, 6] = dt.Compute("sum(TongCong)", "");
        }

        private void btnIn_KeToan_Chot2019_Click(object sender, EventArgs e)
        {
            if (dateTu_KeToan_Chot2019.Value.Year < 2020)
            {
                MessageBox.Show("Chạy từ 2020", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dsBaoCao ds = new dsBaoCao();
            DataTable dt = new DataTable();
            dt = _cHoaDon.GetDSDangNgan(dateTu_KeToan_Chot2019.Value, dateDen_KeToan_Chot2019.Value);
            foreach (DataRow item in dt.Rows)
            {
                if (int.Parse(item["Nam2"].ToString()) == 2019)
                {
                    DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                    dr["TuNgay"] = dateDen_KeToan.Value.Month.ToString("00");
                    dr["DenNgay"] = dateDen_KeToan.Value.Year.ToString("0000");
                    dr["PhanKy"] = "Năm 2019";
                    if (chkTheoThang_Chot2019.Checked == true)
                    {
                        dr["Ngay"] = DateTime.Parse(item["NgayGiaiTrach"].ToString()).ToString("MMyyyy");
                        dr["STT"] = DateTime.Parse(item["NgayGiaiTrach"].ToString()).ToString("yyyyMM");
                    }
                    else
                    {
                        dr["Ngay"] = item["NgayGiaiTrach"];
                        dr["STT"] = DateTime.Parse(item["NgayGiaiTrach"].ToString()).ToString("yyyyMMdd");
                    }
                    dr["TongGiaBan"] = item["GiaBan"];
                    dr["TongThueGTGT"] = item["ThueGTGT"];
                    dr["TongPhiBVMT"] = item["PhiBVMT"];
                    dr["TongCong"] = item["TongCong"];
                    ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                }
                if (int.Parse(item["Ky2"].ToString()) == dateTu_KeToan_Chot2019.Value.Month && int.Parse(item["Nam2"].ToString()) == 2020)
                {
                    DataRow dr = ds.Tables["TongHopDangNgan"].NewRow();
                    dr["TuNgay"] = dateDen_KeToan.Value.Month.ToString("00");
                    dr["DenNgay"] = dateDen_KeToan.Value.Year.ToString("0000");
                    dr["PhanKy"] = "của Kỳ " + dateDen_KeToan_Chot2019.Value.Month.ToString();
                    if (chkTheoThang_Chot2019.Checked == true)
                    {
                        dr["Ngay"] = DateTime.Parse(item["NgayGiaiTrach"].ToString()).ToString("MMyyyy");
                        dr["STT"] = DateTime.Parse(item["NgayGiaiTrach"].ToString()).ToString("yyyyMM");
                    }
                    else
                    {
                        dr["Ngay"] = item["NgayGiaiTrach"];
                        dr["STT"] = DateTime.Parse(item["NgayGiaiTrach"].ToString()).ToString("yyyyMMdd");
                    }
                    dr["TongGiaBan"] = item["GiaBan"];
                    dr["TongThueGTGT"] = item["ThueGTGT"];
                    dr["TongPhiBVMT"] = item["PhiBVMT"];
                    dr["TongCong"] = item["TongCong"];
                    ds.Tables["TongHopDangNgan"].Rows.Add(dr);
                }

            }
            rptTongHopDangNgan_KeToan rpt = new rptTongHopDangNgan_KeToan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }
    }
}
