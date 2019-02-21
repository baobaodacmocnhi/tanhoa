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
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.BaoCao.BamChi;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmBaoCaoKTXM : Form
    {
        CKTXM _cKTXM = new CKTXM();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CDongTienNoiDung _cDongTienNoiDung = new CDongTienNoiDung();
        string TenTo = "";

        public frmBaoCaoKTXM()
        {
            InitializeComponent();
        }

        private void frmBaoCaoKTXM_Load(object sender, EventArgs e)
        {
            if (CTaiKhoan.ToTB == true)
                TenTo = "TKH";
            else
                if (CTaiKhoan.ToTP == true)
                    TenTo = "TXL";
                else
                    if (CTaiKhoan.ToBC == true)
                        TenTo = "TBC";
            DataTable dt = _cDongTienNoiDung.getDS(TenTo);
            DataRow dr = dt.NewRow();
            dr["ID"] = "0";
            dr["Name"] = "Tất Cả";
            dt.Rows.InsertAt(dr, 0);
            cmbNoiDungDongTien_ThongKeXuLyBB.DataSource = dt;
            cmbNoiDungDongTien_ThongKeXuLyBB.DisplayMember = "Name";
            cmbNoiDungDongTien_ThongKeXuLyBB.ValueMember = "Name";
            cmbNoiDungDongTien_ThongKeXuLyBB.SelectedIndex = -1;
        }

        private void btnBaoCao_ThongKeHienTrangKiemTra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkAll_ThongKeHienTrangKiemTra.Checked == true)
                dt = _cKTXM.getDS("",dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
            else
            {
                dt = _cKTXM.getDS(CTaiKhoan.MaTo, dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeHienTrangKiemTra.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeHienTrangKiemTra.Value.ToString("dd/MM/yyyy");
                if (chkAll_ThongKeHienTrangKiemTra.Checked == false)
                    dr["To"] = item["To"];
                dr["MaCTKTXM"] = item["MaCTKTXM"];
                dr["STT_HTKT"] = item["STT_HTKT"];
                dr["HienTrangKiemTra"] = item["HienTrangKiemTra"];
                dr["TieuThuTrungBinh"] = item["TieuThuTrungBinh"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptThongKeHienTrangKiemTra rpt = new rptThongKeHienTrangKiemTra();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo_SoLuong.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    panel1.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel1.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel1.Visible = false;
                    break;
            }
        }

        private void btnBaoCao_SoLuong_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            switch (cmbTimTheo_SoLuong.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                    {
                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                             dt = _cKTXM.getDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                        else
                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                            dt = _cKTXM.getDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                        else
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                dt = _cKTXM.getDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                dt = _cKTXM.getDS("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()), decimal.Parse(txtNoiDungTimKiem2.Text.Trim()));
                    }
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                        {
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                dt = _cKTXM.getDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                dt = _cKTXM.getDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                    dt = _cKTXM.getDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    dt = _cKTXM.getDS("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                        }
                    break;
                case "Danh Bộ":
                    dt = _cKTXM.getDS_ByDanhBo(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Số Công Văn":
                    dt = _cKTXM.getDS_BySoCongVan(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Ngày":
                        dt = _cKTXM.getDS(CTaiKhoan.MaTo, dateTu_SoLuong.Value, dateDen_SoLuong.Value);
                    break;
                default:
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                if (CTaiKhoan.ToTB)
                    dr["To"] = "TỔ KHÁCH HÀNG";
                else
                    if (CTaiKhoan.ToTP)
                        dr["To"] = "TỔ XỬ LÝ";
                    else
                        if (CTaiKhoan.ToBC)
                            dr["To"] = "TỔ BẤM CHÌ";
                dr["TuNgay"] = dateTu_ThongKeHienTrangKiemTra.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeHienTrangKiemTra.Value.ToString("dd/MM/yyyy");
                dr["MaCTKTXM"] = itemRow["MaCTKTXM"];
                dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                dr["NguoiLap"] = itemRow["CreateBy"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptThongKeDSKTXM rpt = new rptThongKeDSKTXM();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnBaoCao_DScoTruyThu_Click(object sender, EventArgs e)
        {
            DataTable dt = _cKTXM.GetDS_TruyThu(dateTu_DScoTruyThu.Value, dateDen_DScoTruyThu.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_DScoTruyThu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_DScoTruyThu.Value.ToString("dd/MM/yyyy");
                dr["TenLD"] = itemRow["TenLD"];
                dr["MaCTKTXM"] = itemRow["MaCTKTXM"];
                dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                if (itemRow["DinhMuc"].ToString() != "")
                    dr["DinhMucCu"] = itemRow["DinhMuc"];
                if (itemRow["DinhMucMoi"].ToString() != "")
                    dr["DinhMucMoi"] = itemRow["DinhMucMoi"];
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }
            rptKTXMcoTruyThu rpt = new rptKTXMcoTruyThu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnBaoCao_ThongKeXuLyBB_Click(object sender, EventArgs e)
        {
            //string TenTo = "";
            //if (CTaiKhoan.ToTB == true)
            //    TenTo = "TKH";
            //else
            //    if (CTaiKhoan.ToTP == true)
            //        TenTo = "TXL";
            //    else
            //        if (CTaiKhoan.ToBC == true)
            //            TenTo = "TBC";

            if (radLapBangGia.Checked == true)
                txtSoLuong_ThongKeXuLyBB.Text = _cKTXM.CountLapBangGia(TenTo, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value).ToString();
            else
                if (radDongTien.Checked == true)
                    txtSoLuong_ThongKeXuLyBB.Text = _cKTXM.CountDongTien(TenTo, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value).ToString();
                else
                    if (radChuyenLapTBCat.Checked == true)
                        txtSoLuong_ThongKeXuLyBB.Text = _cKTXM.CountChuyenLapTBCat(TenTo, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value).ToString();
            //if (chkDutChiGoc.Checked == true)
            //{
            //    if (chkLapBangGia.Checked == true && chkDongTienBoiThuong.Checked == true)
            //        txtSoLuong_ThongKeBBDongTienBoiThuong.Text = _cKTXM.CountLapBangGia_DongTienBoiThuong(TenTo,"DutChiGoc", dateTu_ThongKeBBDongTienBoiThuong.Value, dateDen_ThongKeBBDongTienBoiThuong.Value).ToString();
            //    else
            //        if (chkLapBangGia.Checked == true)
            //            txtSoLuong_ThongKeBBDongTienBoiThuong.Text = _cKTXM.CountLapBangGia(TenTo, "DutChiGoc", dateTu_ThongKeBBDongTienBoiThuong.Value, dateDen_ThongKeBBDongTienBoiThuong.Value).ToString();
            //        else
            //            if (chkDongTienBoiThuong.Checked == true)
            //                txtSoLuong_ThongKeBBDongTienBoiThuong.Text = _cKTXM.CountDongTienBoiThuong(TenTo, "DutChiGoc", dateTu_ThongKeBBDongTienBoiThuong.Value, dateDen_ThongKeBBDongTienBoiThuong.Value).ToString();
            //}
            //else
            //    if (chkMoNuoc.Checked == true)
            //    {
            //        if (chkLapBangGia.Checked == true && chkDongTienBoiThuong.Checked == true)
            //            txtSoLuong_ThongKeBBDongTienBoiThuong.Text = _cKTXM.CountLapBangGia_DongTienBoiThuong(TenTo,"MoNuoc", dateTu_ThongKeBBDongTienBoiThuong.Value, dateDen_ThongKeBBDongTienBoiThuong.Value).ToString();
            //        else
            //            if (chkLapBangGia.Checked == true)
            //                txtSoLuong_ThongKeBBDongTienBoiThuong.Text = _cKTXM.CountLapBangGia(TenTo, "MoNuoc", dateTu_ThongKeBBDongTienBoiThuong.Value, dateDen_ThongKeBBDongTienBoiThuong.Value).ToString();
            //            else
            //                if (chkDongTienBoiThuong.Checked == true)
            //                    txtSoLuong_ThongKeBBDongTienBoiThuong.Text = _cKTXM.CountDongTienBoiThuong(TenTo, "MoNuoc", dateTu_ThongKeBBDongTienBoiThuong.Value, dateDen_ThongKeBBDongTienBoiThuong.Value).ToString();
            //    }
            //    else
            //    {
            //        if (chkLapBangGia.Checked == true && chkDongTienBoiThuong.Checked == true)
            //            txtSoLuong_ThongKeBBDongTienBoiThuong.Text = _cKTXM.CountLapBangGia_DongTienBoiThuong(TenTo,"", dateTu_ThongKeBBDongTienBoiThuong.Value, dateDen_ThongKeBBDongTienBoiThuong.Value).ToString();
            //        else
            //            if (chkLapBangGia.Checked == true)
            //                txtSoLuong_ThongKeBBDongTienBoiThuong.Text = _cKTXM.CountLapBangGia(TenTo, "", dateTu_ThongKeBBDongTienBoiThuong.Value, dateDen_ThongKeBBDongTienBoiThuong.Value).ToString();
            //            else
            //                if (chkDongTienBoiThuong.Checked == true)
            //                    txtSoLuong_ThongKeBBDongTienBoiThuong.Text = _cKTXM.CountDongTienBoiThuong(TenTo, "", dateTu_ThongKeBBDongTienBoiThuong.Value, dateDen_ThongKeBBDongTienBoiThuong.Value).ToString();
            //    }
        }

        private void btnInDS_ThongKeXuLyBB_Click(object sender, EventArgs e)
        {
            if (cmbNoiDungDongTien_ThongKeXuLyBB.SelectedIndex == -1)
                return;
            string NoiDungXuLy = "";
            if (cmbNoiDungDongTien_ThongKeXuLyBB.SelectedIndex > 0)
                NoiDungXuLy = cmbNoiDungDongTien_ThongKeXuLyBB.SelectedValue.ToString();

            string LoaiBaoCao = "";
            DataTable dt = new DataTable();
            if (chkAll_ThongKeXuLyBB.Checked == true)
            {
                if (String.IsNullOrEmpty(txtSoCongVan_ThongKeXuLyBB.Text.Trim()) == true)
                {
                    if (radLapBangGia.Checked == true)
                    {
                        LoaiBaoCao = "LẬP BẢNG GIÁ";
                        dt = _cKTXM.getDSLapBangGia("", NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                    }
                    else
                        if (radDongTien.Checked == true)
                        {
                            LoaiBaoCao = "ĐÓNG TIỀN";
                            dt = _cKTXM.getDSDongTien("", NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                        }
                        else
                            if (radChuyenLapTBCat.Checked == true)
                            {
                                LoaiBaoCao = "CHUYỂN LẬP TB CẮT";
                                dt = _cKTXM.getDSChuyenLapTBCat("", NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                            }
                }
                else
                {
                    if (radLapBangGia.Checked == true)
                    {
                        LoaiBaoCao = "LẬP BẢNG GIÁ";
                        dt = _cKTXM.getDSLapBangGia("", txtSoCongVan_ThongKeXuLyBB.Text.Trim(), NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                    }
                    else
                        if (radDongTien.Checked == true)
                        {
                            LoaiBaoCao = "ĐÓNG TIỀN";
                            dt = _cKTXM.getDSDongTien("", txtSoCongVan_ThongKeXuLyBB.Text.Trim(), NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                        }
                        else
                            if (radChuyenLapTBCat.Checked == true)
                            {
                                LoaiBaoCao = "CHUYỂN LẬP TB CẮT";
                                dt = _cKTXM.getDSChuyenLapTBCat("", txtSoCongVan_ThongKeXuLyBB.Text.Trim(), NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                            }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(txtSoCongVan_ThongKeXuLyBB.Text.Trim()) == true)
                {
                    if (radLapBangGia.Checked == true)
                    {
                        LoaiBaoCao = "LẬP BẢNG GIÁ";
                        dt = _cKTXM.getDSLapBangGia(TenTo, NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                    }
                    else
                        if (radDongTien.Checked == true)
                        {
                            LoaiBaoCao = "ĐÓNG TIỀN";
                            dt = _cKTXM.getDSDongTien(TenTo, NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                        }
                        else
                            if (radChuyenLapTBCat.Checked == true)
                            {
                                LoaiBaoCao = "CHUYỂN LẬP TB CẮT";
                                dt = _cKTXM.getDSChuyenLapTBCat(TenTo, NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                            }
                }
                else
                {
                    if (radLapBangGia.Checked == true)
                    {
                        LoaiBaoCao = "LẬP BẢNG GIÁ";
                        dt = _cKTXM.getDSLapBangGia(TenTo, txtSoCongVan_ThongKeXuLyBB.Text.Trim(), NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                    }
                    else
                        if (radDongTien.Checked == true)
                        {
                            LoaiBaoCao = "ĐÓNG TIỀN";
                            dt = _cKTXM.getDSDongTien(TenTo, txtSoCongVan_ThongKeXuLyBB.Text.Trim(), NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                        }
                        else
                            if (radChuyenLapTBCat.Checked == true)
                            {
                                LoaiBaoCao = "CHUYỂN LẬP TB CẮT";
                                dt = _cKTXM.getDSChuyenLapTBCat(TenTo, txtSoCongVan_ThongKeXuLyBB.Text.Trim(), NoiDungXuLy, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                            }
                }
            }
            LoaiBaoCao += " " + NoiDungXuLy.ToUpper();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeXuLyBB.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeXuLyBB.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = LoaiBaoCao;
                dr["MaDon"] = item["MaDon"].ToString();
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"];
                dr["DiaChi"] = item["DiaChi"];
                dr["NgayLapBangGia"] = item["NgayLap"];
                dr["GhiChu"] = item["GhiChuNoiDungXuLy"];
                if (dt.Columns.Contains("SoTienDongTien") == true)
                {
                    if (String.IsNullOrEmpty(dr["GhiChu"].ToString()) == true)
                        dr["GhiChu"] = item["SoTienDongTien"];
                    else
                        dr["GhiChu"] += ", " + item["SoTienDongTien"];
                }

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptKTXM_XuLy rpt = new rptKTXM_XuLy();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCao_ThongKeLoaiDon_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkAll_ThongKeLoaiDon.Checked == true)
                dt = _cKTXM.getDS("", dateTu_ThongKeLoaiDon.Value, dateDen_ThongKeLoaiDon.Value);
            else
            {
                dt = _cKTXM.getDS(CTaiKhoan.MaTo, dateTu_ThongKeLoaiDon.Value, dateDen_ThongKeLoaiDon.Value);
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();
                dr["TuNgay"] = dateTu_ThongKeLoaiDon.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeLoaiDon.Value.ToString("dd/MM/yyyy");
                dr["MaCTKTXM"] = item["MaCTKTXM"];
                dr["TenLD"] = item["TenLD"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptThongKetheoLoaiDon rpt = new rptThongKetheoLoaiDon();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCao_BaoThay_Click(object sender, EventArgs e)
        {
            DataTable dt = _cKTXM.GetDS_BaoThay(dateTu_BaoThay.Value, dateDen_BaoThay.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_BaoThay.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_BaoThay.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = "KIỂM TRA XÁC MINH CÓ BÁO THAY";
                dr["MaDon"] = item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"];
                dr["DiaChi"] = item["DiaChi"];
                dr["NgayLapBangGia"] = item["NgayKTXM"];
                dr["GhiChu"] = item["NoiDungBaoThay"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptKTXM_BaoThay rpt = new rptKTXM_BaoThay();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        

    }
}
