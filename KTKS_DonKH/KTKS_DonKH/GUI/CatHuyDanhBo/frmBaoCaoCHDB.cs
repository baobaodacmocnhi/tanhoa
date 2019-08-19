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
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmBaoCaoCHDB : Form
    {
        CCHDB _cCHDB = new CCHDB();
        CDHN _cDocSo = new CDHN();
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

            cmbQuan.DataSource = lst;
            cmbQuan.DisplayMember = "TenQuan";
            cmbQuan.ValueMember = "MaQuan";

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
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
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
                                dt = _cCHDB.GetDSCatHuy_NgayXuLy_Quan_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan_TheoNgayXuLy.SelectedValue.ToString());
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
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
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


            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            DataRow drT = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();
            drT["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
            drT["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
            drT["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
            if (cmbQuan.SelectedIndex == 0)
            {
                dtCatTam_ThongKe = _cCHDB.getCatTam_BaoCao(dateTu.Value, dateDen.Value);
                dtCatHuy_ThongKe = _cCHDB.getCatHuy_BaoCao(dateTu.Value, dateDen.Value);
                dtDSCatTam_DaXuLy = _cCHDB.GetDSCatTam_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value);
                dtDSCatHuy_DaXuLy = _cCHDB.GetDSCatHuy_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value);
                dtDSPhieuHuy = _cCHDB.getDS_PhieuHuy(dateTu.Value, dateDen.Value);
            }
            else
                if (cmbQuan.SelectedIndex > 0)
                {
                    dtCatTam_ThongKe = _cCHDB.getCatTam_BaoCao(dateTu.Value, dateDen.Value, cmbQuan.SelectedValue.ToString());
                    dtCatHuy_ThongKe = _cCHDB.getCatHuy_BaoCao(dateTu.Value, dateDen.Value, cmbQuan.SelectedValue.ToString());
                    dtDSCatTam_DaXuLy = _cCHDB.GetDSCatTam_NgayXuLy_Quan_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan.SelectedValue.ToString());
                    dtDSCatHuy_DaXuLy = _cCHDB.GetDSCatHuy_NgayXuLy_Quan_DaXuLy(dateTu.Value, dateDen.Value, cmbQuan.SelectedValue.ToString());
                    dtDSPhieuHuy = _cCHDB.getDS_PhieuHuy(dateTu.Value, dateDen.Value, cmbQuan.SelectedValue.ToString());
                    drT["Quan"] = cmbQuan.Text;
                }
            dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(drT);

            DataSetBaoCao dsCatTam = new DataSetBaoCao();
            foreach (DataRow itemRow in dtDSCatTam_DaXuLy.Rows)
            {
                DataRow dr = dsCatTam.Tables["ThongBaoCHDB"].NewRow();
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
                dr["LyDo"] = itemRow["LyDo"];
                dr["SoPhieu"] = itemRow["ID"]; ;

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

        private void btnImportExcelCatHuy_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("DanhBo", typeof(String));
                    dtExport.Columns.Add("ID", typeof(String));
                    dtExport.Columns.Add("LyDo", typeof(String));
                    dtExport.Columns.Add("NoiDungXuLy", typeof(String));
                    
                    CExcel fileExcel = new CExcel(dialog.FileName);
                    DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                    foreach (DataRow item in dtExcel.Rows)
                        if (item[0].ToString().Replace(" ", "").Length == 11)
                        {
                            DataRow dr = dtExport.NewRow();
                            dr["DanhBo"] = item[0].ToString().Replace(" ", "");

                            DataTable dtTemp = _cCHDB.getDS_CatHuy_DanhBo(item[0].ToString().Replace(" ", ""));
                            foreach (DataRow itemTemp in dtTemp.Rows)
                            {
                                if (dr["ID"].ToString() == "")
                                {
                                    if (itemTemp["ID"].ToString() != "")
                                        dr["ID"] = itemTemp["ID"].ToString().Insert(itemTemp["ID"].ToString().Length-2,"-");
                                }
                                else
                                {
                                    if (itemTemp["ID"].ToString() != "")
                                        dr["ID"] += " ; " + itemTemp["ID"].ToString().Insert(itemTemp["ID"].ToString().Length - 2, "-");
                                }

                                if (dr["LyDo"].ToString() == "")
                                {
                                    if (itemTemp["LyDo"].ToString() != "")
                                        dr["LyDo"] = itemTemp["LyDo"].ToString().Insert(itemTemp["LyDo"].ToString().Length - 2, "-");
                                }
                                else
                                {
                                    if (itemTemp["LyDo"].ToString() != "")
                                        dr["LyDo"] += " ; " + itemTemp["LyDo"].ToString().Insert(itemTemp["LyDo"].ToString().Length - 2, "-");
                                }

                                if (dr["NoiDungXuLy"].ToString() == "")
                                {
                                    if (itemTemp["NgayXuLy"].ToString() != "")
                                        dr["NoiDungXuLy"] = DateTime.Parse(itemTemp["NgayXuLy"].ToString()).ToString("dd/MM/yyyy");
                                    if (itemTemp["NoiDungXuLy"].ToString() != "")
                                        dr["NoiDungXuLy"] += ", " + itemTemp["NoiDungXuLy"];
                                }
                                else
                                {
                                    if (itemTemp["NgayXuLy"].ToString() != "")
                                        dr["NoiDungXuLy"] += " ; " + DateTime.Parse(itemTemp["NgayXuLy"].ToString()).ToString("dd/MM/yyyy");
                                    if (itemTemp["NoiDungXuLy"].ToString() != "")
                                        dr["NoiDungXuLy"] += ", " + itemTemp["NoiDungXuLy"];
                                }
                            }

                            dtExport.Rows.Add(dr);
                        }
                    //Tạo các đối tượng Excel
                    Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbooks oBooks;
                    Microsoft.Office.Interop.Excel.Sheets oSheets;
                    Microsoft.Office.Interop.Excel.Workbook oBook;
                    Microsoft.Office.Interop.Excel.Worksheet oSheet;
                    //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

                    //Tạo mới một Excel WorkBook 
                    oExcel.Visible = true;
                    oExcel.DisplayAlerts = false;
                    //khai báo số lượng sheet
                    oExcel.Application.SheetsInNewWorkbook = 1;
                    oBooks = oExcel.Workbooks;

                    oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                    oSheets = oBook.Worksheets;
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                    //oSheetCQ = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

                    XuatExcel(dtExport, oSheet, "Cắt Hủy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportExcelCatTam_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dtExport = new DataTable();
                    dtExport.Columns.Add("DanhBo", typeof(String));
                    dtExport.Columns.Add("ID", typeof(String));
                    dtExport.Columns.Add("LyDo", typeof(String));
                    dtExport.Columns.Add("NoiDungXuLy", typeof(String));

                    CExcel fileExcel = new CExcel(dialog.FileName);
                    DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                    foreach (DataRow item in dtExcel.Rows)
                        if (string.IsNullOrEmpty(item[0].ToString()) && item[0].ToString().Replace(" ", "").Length == 11)
                        {
                            DataRow dr = dtExport.NewRow();
                            dr["DanhBo"] = item[0].ToString().Replace(" ", "");

                            DataTable dtTemp = _cCHDB.getDS_CatTam_DanhBo(item[0].ToString().Replace(" ", ""));
                            foreach (DataRow itemTemp in dtTemp.Rows)
                            {
                                if (dr["ID"].ToString() == "")
                                {
                                    if (itemTemp["ID"].ToString() != "")
                                        dr["ID"] = itemTemp["ID"].ToString().Insert(itemTemp["ID"].ToString().Length - 2, "-");
                                }
                                else
                                {
                                    if (itemTemp["ID"].ToString() != "")
                                        dr["ID"] += " ; " + itemTemp["ID"].ToString().Insert(itemTemp["ID"].ToString().Length - 2, "-");
                                }

                                if (dr["LyDo"].ToString() == "")
                                {
                                    if (itemTemp["LyDo"].ToString() != "")
                                        dr["LyDo"] = itemTemp["LyDo"].ToString().Insert(itemTemp["LyDo"].ToString().Length - 2, "-");
                                }
                                else
                                {
                                    if (itemTemp["LyDo"].ToString() != "")
                                        dr["LyDo"] += " ; " + itemTemp["LyDo"].ToString().Insert(itemTemp["LyDo"].ToString().Length - 2, "-");
                                }

                                if (dr["NoiDungXuLy"].ToString() == "")
                                {
                                    if (itemTemp["NgayXuLy"].ToString() != "")
                                        dr["NoiDungXuLy"] = DateTime.Parse(itemTemp["NgayXuLy"].ToString()).ToString("dd/MM/yyyy");
                                    if (itemTemp["NoiDungXuLy"].ToString() != "")
                                        dr["NoiDungXuLy"] += ", " + itemTemp["NoiDungXuLy"];
                                }
                                else
                                {
                                    if (itemTemp["NgayXuLy"].ToString() != "")
                                        dr["NoiDungXuLy"] += " ; " + DateTime.Parse(itemTemp["NgayXuLy"].ToString()).ToString("dd/MM/yyyy");
                                    if (itemTemp["NoiDungXuLy"].ToString() != "")
                                        dr["NoiDungXuLy"] += ", " + itemTemp["NoiDungXuLy"];
                                }
                            }

                            dtExport.Rows.Add(dr);
                        }
                    //Tạo các đối tượng Excel
                    Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbooks oBooks;
                    Microsoft.Office.Interop.Excel.Sheets oSheets;
                    Microsoft.Office.Interop.Excel.Workbook oBook;
                    Microsoft.Office.Interop.Excel.Worksheet oSheet;
                    //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

                    //Tạo mới một Excel WorkBook 
                    oExcel.Visible = true;
                    oExcel.DisplayAlerts = false;
                    //khai báo số lượng sheet
                    oExcel.Application.SheetsInNewWorkbook = 1;
                    oBooks = oExcel.Workbooks;

                    oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                    oSheets = oBook.Worksheets;
                    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                    //oSheetCQ = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);

                    XuatExcel(dtExport, oSheet, "Cắt Tạm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Mã Lệnh";
            cl2.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Lý Do";
            cl3.ColumnWidth = 50;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Xử Lý";
            cl4.ColumnWidth = 30;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 4];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["DanhBo"].ToString();
                arr[i, 1] = dr["ID"].ToString();
                arr[i, 2] = dr["LyDo"].ToString();
                arr[i, 3] = dr["NoiDungXuLy"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 4;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3b.NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            c3d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            c3e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            c3e.NumberFormat = "@";

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }
    }
}