using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmBaoCaoCHDB : Form
    {
        CCHDB _cCHDB = new CCHDB();
        CDocSo _cDocSo = new CDocSo();
        CCHDB_LyDo _cLyDoCHDB = new CCHDB_LyDo();
        CCHDB_NoiDungXuLy _cNoiDungXuLyCHDB = new CCHDB_NoiDungXuLy();

        public frmBaoCaoCHDB()
        {
            InitializeComponent();
        }

        private void frmBaoCaoCHDB_Load(object sender, EventArgs e)
        {
            List<QUAN> lst = _cDocSo.GetDSQuan();
            QUAN quan = new QUAN();
            quan.MAQUAN = 0;
            quan.TENQUAN = "Tất Cả";
            lst.Insert(0, quan);
            cmbQuan_TheoNgayLap.DataSource = lst;
            cmbQuan_TheoNgayLap.DisplayMember = "TenQuan";
            cmbQuan_TheoNgayLap.ValueMember = "MaQuan";

            cmbQuan_TheoNgayXuLy.DataSource = lst;
            cmbQuan_TheoNgayXuLy.DisplayMember = "TenQuan";
            cmbQuan_TheoNgayXuLy.ValueMember = "MaQuan";

            List<CHDB_LyDo> lst2 = _cLyDoCHDB.GetDS();
            CHDB_LyDo item2 = new CHDB_LyDo();
            item2.ID = 0;
            item2.LyDo = "Tất Cả";
            lst2.Insert(0, item2);

            cmbLyDo_TheoNgayLap.DataSource = lst2;
            cmbLyDo_TheoNgayLap.DisplayMember = "LyDo";
            cmbLyDo_TheoNgayLap.ValueMember = "LyDo";

            List<CHDB_NoiDungXuLy> lst3 = _cNoiDungXuLyCHDB.GetDS();
            CHDB_NoiDungXuLy item3 = new CHDB_NoiDungXuLy();
            item3.ID = 0;
            item3.NoiDung = "Tất Cả";
            lst3.Insert(0, item3);

            cmbNoiDung_TheoNgayXuLy.DataSource = lst3;
            cmbNoiDung_TheoNgayXuLy.DisplayMember = "NoiDung";
            cmbNoiDung_TheoNgayXuLy.ValueMember = "NoiDung";
        }

        private void btnBaoCao_TheoNgayLap_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (cmbQuan_TheoNgayLap.SelectedIndex == 0)
            {
                if (cmbLyDo_TheoNgayLap.SelectedIndex == 0)
                {
                    switch (cmbLoaiBaoCao_TheoNgayLap.SelectedItem.ToString())
                    {
                        case "DS Cắt Hủy Đã Xử Lý":
                            dt = _cCHDB.GetDSCatHuy_NgayLap_DaXuLy(dateTu.Value, dateDen.Value);
                            break;
                        case "DS Cắt Hủy Chưa Xử Lý":
                            dt = _cCHDB.GetDSCatHuy_NgayLap_ChuaXuLy(dateTu.Value, dateDen.Value);
                            break;
                        case "DS Cắt Tạm Đã Xử Lý":
                            dt = _cCHDB.GetDSCatTam_NgayLap_DaXuLy(dateTu.Value, dateDen.Value);
                            break;
                        case "DS Cắt Tạm Chưa Xử Lý":
                            dt = _cCHDB.GetDSCatTam_NgayLap_ChuaXuLy(dateTu.Value, dateDen.Value);
                            break;
                        default:
                            break;
                    }
                }
                else
                    if (cmbLyDo_TheoNgayLap.SelectedIndex > 0)
                {
                        switch (cmbLoaiBaoCao_TheoNgayLap.SelectedItem.ToString())
                        {
                            case "DS Cắt Hủy Đã Xử Lý":
                                dt = _cCHDB.GetDSCatHuy_NgayLap_LyDo_DaXuLy(dateTu.Value, dateDen.Value, cmbLyDo_TheoNgayLap.SelectedValue.ToString());
                                break;
                            case "DS Cắt Hủy Chưa Xử Lý":
                                dt = _cCHDB.GetDSCatHuy_NgayLap_LyDo_ChuaXuLy(dateTu.Value, dateDen.Value, cmbLyDo_TheoNgayLap.SelectedValue.ToString());
                                break;
                            case "DS Cắt Tạm Đã Xử Lý":
                                dt = _cCHDB.GetDSCatTam_NgayLap_LyDo_DaXuLy(dateTu.Value, dateDen.Value, cmbLyDo_TheoNgayLap.SelectedValue.ToString());
                                break;
                            case "DS Cắt Tạm Chưa Xử Lý":
                                dt = _cCHDB.GetDSCatTam_NgayLap_LyDo_ChuaXuLy(dateTu.Value, dateDen.Value, cmbLyDo_TheoNgayLap.SelectedValue.ToString());
                                break;
                            default:
                                break;
                        }
                }
            }
            else
                if (cmbQuan_TheoNgayLap.SelectedIndex > 0)
                {
                    if (cmbLyDo_TheoNgayLap.SelectedIndex == 0)
                    {
                        switch (cmbLoaiBaoCao_TheoNgayLap.SelectedItem.ToString())
                        {
                            case "DS Cắt Hủy Đã Xử Lý":
                                dt = _cCHDB.GetDSCatHuy_NgayLap_Quan_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayLap.SelectedValue.ToString());
                                break;
                            case "DS Cắt Hủy Chưa Xử Lý":
                                dt = _cCHDB.GetDSCatHuy_NgayLap_Quan_ChuaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayLap.SelectedValue.ToString());
                                break;
                            case "DS Cắt Tạm Đã Xử Lý":
                                dt = _cCHDB.GetDSCatTam_NgayLap_Quan_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayLap.SelectedValue.ToString());
                                break;
                            case "DS Cắt Tạm Chưa Xử Lý":
                                dt = _cCHDB.GetDSCatTam_NgayLap_Quan_ChuaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayLap.SelectedValue.ToString());
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        if (cmbLyDo_TheoNgayLap.SelectedIndex > 0)
                        {
                            switch (cmbLoaiBaoCao_TheoNgayLap.SelectedItem.ToString())
                            {
                                case "DS Cắt Hủy Đã Xử Lý":
                                    dt = _cCHDB.GetDSCatHuy_NgayLap_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayLap.SelectedValue.ToString(), cmbLyDo_TheoNgayLap.SelectedValue.ToString());
                                    break;
                                case "DS Cắt Hủy Chưa Xử Lý":
                                    dt = _cCHDB.GetDSCatHuy_NgayLap_ChuaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayLap.SelectedValue.ToString(), cmbLyDo_TheoNgayLap.SelectedValue.ToString());
                                    break;
                                case "DS Cắt Tạm Đã Xử Lý":
                                    dt = _cCHDB.GetDSCatTam_NgayLap_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayLap.SelectedValue.ToString(), cmbLyDo_TheoNgayLap.SelectedValue.ToString());
                                    break;
                                case "DS Cắt Tạm Chưa Xử Lý":
                                    dt = _cCHDB.GetDSCatTam_NgayLap_ChuaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayLap.SelectedValue.ToString(), cmbLyDo_TheoNgayLap.SelectedValue.ToString());
                                    break;
                                default:
                                    break;
                            }
                        }
                }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                if (cmbQuan_TheoNgayLap.SelectedIndex == 0)
                    switch (cmbLoaiBaoCao_TheoNgayLap.SelectedItem.ToString())
                    {
                        case "DS Cắt Hủy Đã Xử Lý":
                            dr["LoaiBaoCao"] = "TB CẮT HỦY ĐÃ XỬ LÝ";
                            dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                            break;
                        case "DS Cắt Hủy Chưa Xử Lý":
                            dr["LoaiBaoCao"] = "TB CẮT HỦY CHƯA XỬ LÝ";
                            dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                            break;
                        case "DS Cắt Tạm Đã Xử Lý":
                            dr["LoaiBaoCao"] = "TB CẮT TẠM ĐÃ XỬ LÝ";
                            dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                            break;
                        case "DS Cắt Tạm Chưa Xử Lý":
                            dr["LoaiBaoCao"] = "TB CẮT TẠM CHƯA XỬ LÝ";
                            dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                            break;
                        default:
                            break;
                    }
                else
                    if (cmbQuan_TheoNgayLap.SelectedIndex > 0)
                    switch (cmbLoaiBaoCao_TheoNgayLap.SelectedItem.ToString())
                    {
                        case "DS Cắt Hủy Đã Xử Lý":
                            dr["LoaiBaoCao"] = "TB CẮT HỦY ĐÃ XỬ LÝ " + cmbQuan_TheoNgayLap.Text;
                            dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                            break;
                        case "DS Cắt Hủy Chưa Xử Lý":
                            dr["LoaiBaoCao"] = "TB CẮT HỦY CHƯA XỬ LÝ " + cmbQuan_TheoNgayLap.Text;
                            dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                            break;
                        case "DS Cắt Tạm Đã Xử Lý":
                            dr["LoaiBaoCao"] = "TB CẮT TẠM ĐÃ XỬ LÝ " + cmbQuan_TheoNgayLap.Text;
                            dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                            break;
                        case "DS Cắt Tạm Chưa Xử Lý":
                            dr["LoaiBaoCao"] = "TB CẮT TẠM CHƯA XỬ LÝ " + cmbQuan_TheoNgayLap.Text;
                            dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                            break;
                        default:
                            break;
                    }

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["CreateDate"] = item["CreateDate"].ToString();
                if (item["DanhBo"].ToString() != "")
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"].ToString();
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["LyDo"] = item["LyDo"].ToString();
                dr["NgayXuLy"] = item["NgayXuLy"].ToString();
                dr["NoiDungXuLy"] = item["NoiDungXuLy"].ToString();
                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);
            }

            rptDSCHDB rpt = new rptDSCHDB();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCao_TheoNgayXuLy_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cmbQuan_TheoNgayLap.SelectedIndex == 0)
            {
                if (cmbNoiDung_TheoNgayXuLy.SelectedIndex == 0)
                    switch (cmbLoaiBaoCao_TheoNgayXuLy.SelectedItem.ToString())
                    {
                        case "DS Cắt Hủy":
                            dt = _cCHDB.GetDSCatHuy_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value);
                            break;
                        case "DS Cắt Tạm":
                            dt = _cCHDB.GetDSCatTam_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value);
                            break;
                        default:
                            break;
                    }
                else
                    if (cmbNoiDung_TheoNgayXuLy.SelectedIndex > 0)
                        switch (cmbLoaiBaoCao_TheoNgayXuLy.SelectedItem.ToString())
                        {
                            case "DS Cắt Hủy":
                                dt = _cCHDB.GetDSCatHuy_NgayXuLy_NoiDung_DaXuLy(dateTu.Value, dateDen.Value, cmbNoiDung_TheoNgayXuLy.SelectedValue.ToString());
                                break;
                            case "DS Cắt Tạm":
                                dt = _cCHDB.GetDSCatTam_NgayXuLy_NoiDung_DaXuLy(dateTu.Value, dateDen.Value, cmbNoiDung_TheoNgayXuLy.SelectedValue.ToString());
                                break;
                            default:
                                break;
                        }
            }
            else
                if (cmbQuan_TheoNgayLap.SelectedIndex > 0)
                {
                    if (cmbNoiDung_TheoNgayXuLy.SelectedIndex == 0)
                        switch (cmbLoaiBaoCao_TheoNgayXuLy.SelectedItem.ToString())
                        {
                            case "DS Cắt Hủy":
                                dt = _cCHDB.GetDSCatHuy_NgayXuLy_Quan_DaXuLy(dateTu.Value, dateDen.Value,cmbQuan_TheoNgayXuLy.SelectedValue.ToString());
                                break;
                            case "DS Cắt Tạm":
                                dt = _cCHDB.GetDSCatTam_NgayXuLy_Quan_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayXuLy.SelectedValue.ToString());
                                break;
                            default:
                                break;
                        }
                    else
                        if (cmbNoiDung_TheoNgayXuLy.SelectedIndex > 0)
                            switch (cmbLoaiBaoCao_TheoNgayXuLy.SelectedItem.ToString())
                            {
                                case "DS Cắt Hủy":
                                    dt = _cCHDB.GetDSCatHuy_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayXuLy.SelectedValue.ToString(), cmbNoiDung_TheoNgayXuLy.SelectedValue.ToString());
                                    break;
                                case "DS Cắt Tạm":
                                    dt = _cCHDB.GetDSCatTam_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayXuLy.SelectedValue.ToString(), cmbNoiDung_TheoNgayXuLy.SelectedValue.ToString());
                                    break;
                                default:
                                    break;
                            }
                }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                if (cmbQuan_TheoNgayLap.SelectedIndex == 0)
                    switch (cmbLoaiBaoCao_TheoNgayXuLy.SelectedItem.ToString())
                    {
                        case "DS Cắt Hủy":
                            dr["LoaiBaoCao"] = "CẮT HỦY ĐÃ XỬ LÝ";
                            dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                            break;
                        case "DS Cắt Tạm":
                            dr["LoaiBaoCao"] = "CẮT TẠM ĐÃ XỬ LÝ";
                            dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                            break;
                        default:
                            break;
                    }
                else
                    if (cmbQuan_TheoNgayLap.SelectedIndex > 0)
                        switch (cmbLoaiBaoCao_TheoNgayXuLy.SelectedItem.ToString())
                        {
                            case "DS Cắt Hủy":
                                dr["LoaiBaoCao"] = "CẮT HỦY ĐÃ XỬ LÝ " + cmbQuan_TheoNgayLap.Text;
                                dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                                break;
                            case "DS Cắt Tạm":
                                dr["LoaiBaoCao"] = "CẮT TẠM ĐÃ XỬ LÝ " + cmbQuan_TheoNgayLap.Text;
                                dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                                break;
                            default:
                                break;
                        }

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["CreateDate"] = item["CreateDate"].ToString();
                if (item["DanhBo"].ToString() != "")
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"].ToString();
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["LyDo"] = item["LyDo"].ToString();
                dr["NgayXuLy"] = item["NgayXuLy"].ToString();
                dr["NoiDungXuLy"] = item["NoiDungXuLy"].ToString();
                dr["GroupNoiDungXuLy"] = "True";
                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);
            }

            rptDSCHDB rpt = new rptDSCHDB();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DataTable dtCatTam_ThongKe = new DataTable();
            DataTable dtCatHuy_ThongKe = new DataTable();
            DataTable dtDSCatTam_DaXuLy = new DataTable();
            DataTable dtDSCatHuy_DaXuLy = new DataTable();
            DataTable dtDSPhieuHuy = new DataTable();

            dtCatTam_ThongKe = _cCHDB.getCatTam_BaoCao(dateTu.Value, dateDen.Value);
            dtCatHuy_ThongKe = _cCHDB.getCatHuy_BaoCao(dateTu.Value, dateDen.Value);
            dtDSCatTam_DaXuLy = _cCHDB.GetDSCatTam_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value);
            dtDSCatHuy_DaXuLy = _cCHDB.GetDSCatHuy_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value);
            dtDSPhieuHuy = _cCHDB.getDS_PhieuHuy(dateTu.Value, dateDen.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow drT = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();
            drT["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
            drT["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
            dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(drT);

            DataSetBaoCao dsCatTam = new DataSetBaoCao();
            foreach (DataRow itemRow in dtDSCatTam_DaXuLy.Rows)
            {
                DataRow dr = dsCatTam.Tables["ThongBaoCHDB"].NewRow();
                //dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                //dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["SoPhieu"] = itemRow["MaCTCTDB"];
                dr["LyDo"] = itemRow["LyDo"];
                dr["NoiDungXuLy"] = itemRow["NoiDungXuLy"];

                dr["LuyKe"] = dtCatTam_ThongKe.Rows[0]["LuyKe"];
                dr["Nhan"] = dtCatTam_ThongKe.Rows[0]["Nhan"];
                dr["XuLy"] = dtCatTam_ThongKe.Rows[0]["XuLy"];
                dr["Ton"] = dtCatTam_ThongKe.Rows[0]["Ton"];

                dsCatTam.Tables["ThongBaoCHDB"].Rows.Add(dr);
            }

            DataSetBaoCao dsCatHuy = new DataSetBaoCao();
            foreach (DataRow itemRow in dtDSCatHuy_DaXuLy.Rows)
            {
                DataRow dr = dsCatHuy.Tables["ThongBaoCHDB"].NewRow();
                //dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                //dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["SoPhieu"] = itemRow["MaCTCHDB"];
                dr["LyDo"] = itemRow["LyDo"];
                dr["NoiDungXuLy"] = itemRow["NoiDungXuLy"];

                dr["LuyKe"] = dtCatHuy_ThongKe.Rows[0]["LuyKe"];
                dr["Nhan"] = dtCatHuy_ThongKe.Rows[0]["Nhan"];
                dr["XuLy"] = dtCatHuy_ThongKe.Rows[0]["XuLy"];
                dr["Ton"] = dtCatHuy_ThongKe.Rows[0]["Ton"];

                dsCatHuy.Tables["ThongBaoCHDB"].Rows.Add(dr);
            }

            DataSetBaoCao dsPhieuHuy = new DataSetBaoCao();
            foreach (DataRow itemRow in dtDSPhieuHuy.Rows)
            {
                DataRow dr = dsPhieuHuy.Tables["PhieuCHDB"].NewRow();
                //dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                //dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["LyDo"] = itemRow["LyDo"];
                dr["SoPhieu"] = itemRow["ID"];;

                dsPhieuHuy.Tables["PhieuCHDB"].Rows.Add(dr);
            }

            rptThongKeCHDB rpt = new rptThongKeCHDB();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports["rptCatTam"].SetDataSource(dsCatTam);
            rpt.Subreports["rptCatHuy"].SetDataSource(dsCatHuy);
            rpt.Subreports["rptPhieuHuy"].SetDataSource(dsPhieuHuy);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }


    }
}