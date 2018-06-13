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
            if (CTaiKhoan.ToKH == true)
                TenTo = "TKH";
            else
                if (CTaiKhoan.ToXL == true)
                    TenTo = "TXL";
                else
                    if (CTaiKhoan.ToBC == true)
                        TenTo = "TBC";

            cmbNoiDungDongTien_ThongKeXuLyBB.DataSource = _cDongTienNoiDung.getDS(TenTo);
            cmbNoiDungDongTien_ThongKeXuLyBB.DisplayMember = "Name";
            cmbNoiDungDongTien_ThongKeXuLyBB.ValueMember = "Name";
            cmbNoiDungDongTien_ThongKeXuLyBB.SelectedIndex = -1;
        }

        private void btnBaoCao_ThongKeHienTrangKiemTra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkAll_ThongKeHienTrangKiemTra.Checked == true)
                dt = _cKTXM.GetDS(dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
            else
            {
                if (CTaiKhoan.ToKH)
                    dt = _cKTXM.GetDS("TKH", dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
                else
                    if (CTaiKhoan.ToXL)
                        dt = _cKTXM.GetDS("TXL", dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
                    else
                        if (CTaiKhoan.ToBC)
                            dt = _cKTXM.GetDS("TBC", dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
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
                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                            dt = _cKTXM.GetDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                        else
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                dt = _cKTXM.GetDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                dt = _cKTXM.GetDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                    }
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                        {
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                dt = _cKTXM.GetDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                    dt = _cKTXM.GetDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    dt = _cKTXM.GetDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                        }
                    break;
                case "Danh Bộ":
                    dt = _cKTXM.GetDS(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Số Công Văn":
                    dt = _cKTXM.GetDSBySoCongVan(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Ngày":
                    if (CTaiKhoan.ToKH)
                        dt = _cKTXM.GetDS("TKH", dateTu_SoLuong.Value, dateDen_SoLuong.Value);
                    else
                        if (CTaiKhoan.ToXL)
                            dt = _cKTXM.GetDS("TXL", dateTu_SoLuong.Value, dateDen_SoLuong.Value);
                        else
                            if (CTaiKhoan.ToBC)
                                dt = _cKTXM.GetDS("TBC", dateTu_SoLuong.Value, dateDen_SoLuong.Value);
                    break;
                default:
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                if (CTaiKhoan.ToKH)
                    dr["To"] = "TỔ KHÁCH HÀNG";
                else
                    if (CTaiKhoan.ToXL)
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
            DataTable dt = _cKTXM.GetDScoTruyThu(dateTu_DScoTruyThu.Value, dateDen_DScoTruyThu.Value);
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
            //if (CTaiKhoan.ToKH == true)
            //    TenTo = "TKH";
            //else
            //    if (CTaiKhoan.ToXL == true)
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
            //string TenTo = "";
            //if (CTaiKhoan.ToKH == true)
            //    TenTo = "TKH";
            //else
            //    if (CTaiKhoan.ToXL == true)
            //        TenTo = "TXL";
            //    else
            //        if (CTaiKhoan.ToBC == true)
            //            TenTo = "TBC";
            string LoaiBaoCao = "";
            DataTable dt = new DataTable();
            if (radLapBangGia.Checked == true)
            {
                LoaiBaoCao = "LẬP BẢNG GIÁ";
                dt = _cKTXM.GetDSLapBangGia(TenTo, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
            }
            else
                if (radDongTien.Checked == true)
                {
                    LoaiBaoCao = "ĐÓNG TIỀN " + cmbNoiDungDongTien_ThongKeXuLyBB.SelectedValue.ToString().ToUpper();
                    dt = _cKTXM.GetDSDongTien(TenTo, cmbNoiDungDongTien_ThongKeXuLyBB.SelectedValue.ToString(), dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                }
                else
                    if (radChuyenLapTBCat.Checked == true)
                    {
                        LoaiBaoCao = "CHUYỂN LẬP TB CẮT";
                        dt = _cKTXM.GetDSChuyenLapTBCat(TenTo, dateTu_ThongKeXuLyBB.Value, dateDen_ThongKeXuLyBB.Value);
                    }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeXuLyBB.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeXuLyBB.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = LoaiBaoCao;
                dr["MaDon"] = item["MaDon"];
                dr["DanhBo"] = item["DanhBo"];
                dr["HoTen"] = item["HoTen"];
                dr["DiaChi"] = item["DiaChi"];
                dr["NgayLapBangGia"] = item["NgayLap"];
                dr["GhiChu"] = item["GhiChu"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptKTXM_XuLy rpt = new rptKTXM_XuLy();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
