using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.BaoCao.DonTu;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao.ToKhachHang;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmBaoCaoDonTu : Form
    {
        CDonTu _cDonTu = new CDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CTo _cTo = new CTo();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        public frmBaoCaoDonTu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDonTu_Load(object sender, EventArgs e)
        {
            List<NoiChuyen> lstNoiChuyen = _cNoiChuyen.GetDS("DonTuNhan");
            NoiChuyen en = new NoiChuyen();
            en.ID = 0;
            en.Name = "Tất Cả";
            lstNoiChuyen.Insert(0, en);
            cmbNoiNhan_LichSuChuyenDon.DataSource = lstNoiChuyen;
            cmbNoiNhan_LichSuChuyenDon.ValueMember = "ID";
            cmbNoiNhan_LichSuChuyenDon.DisplayMember = "Name";
            cmbNoiNhan_LichSuChuyenDon.SelectedIndex = -1;

            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                cmbTo.DataSource = _cTo.getDS_KTXM();
                cmbTo.ValueMember = "KyHieu";
                cmbTo.DisplayMember = "TenTo";
                panelTo.Visible = true;
            }
            else
            {
                panelTo.Visible = false;
            }

            //Danh Sách Chuyển KTXM (ngày chuyển)
            DataTable dt = new DataTable();
            dt = _cTaiKhoan.GetDS_KTXM(CTaiKhoan.KyHieuMaTo);
            DataRow dr = dt.NewRow();
            dr["MaU"] = 0;
            dr["HoTen"] = "Tất Cả";
            dt.Rows.InsertAt(dr, 0);
            cmbNhanVienKiemTra.DataSource = dt;
            cmbNhanVienKiemTra.ValueMember = "MaU";
            cmbNhanVienKiemTra.DisplayMember = "HoTen";
        }

        private void cmbTimTheo_LichSuChuyenDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
            {
                case "Số Công Văn":
                    txtNoiDungTimKiem_LichSuChuyenDon.Visible = true;
                    panel_KhoangThoiGian_LichSuChuyenDon.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem_LichSuChuyenDon.Visible = false;
                    panel_KhoangThoiGian_LichSuChuyenDon.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem_LichSuChuyenDon.Visible = false;
                    panel_KhoangThoiGian_LichSuChuyenDon.Visible = false;
                    break;
            }
        }

        private void btnBaoCao_LichSuChuyenDon_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkNguoiLap.Checked == true)
            {
                if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex == 0)
                    switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                    {
                        case "Ngày":
                            dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, CTaiKhoan.MaUser, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value);
                            break;
                        case "Số Công Văn":
                            dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, CTaiKhoan.MaUser, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper());
                            break;
                    }
                else
                    if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex > 0)
                        switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                        {
                            case "Ngày":
                                dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, CTaiKhoan.MaUser, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value, int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                                break;
                            case "Số Công Văn":
                                dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, CTaiKhoan.MaUser, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper(), int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                                break;
                        }
            }
            else
                if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex == 0)
                    switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                    {
                        case "Ngày":
                            dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value);
                            break;
                        case "Số Công Văn":
                            dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper());
                            break;
                    }
                else
                    if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex > 0)
                        switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                        {
                            case "Ngày":
                                dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value, int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                                break;
                            case "Số Công Văn":
                                dt = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper(), int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                                break;
                        }
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

                dr["TuNgay"] = dateTu_LichSuChuyenDon.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_LichSuChuyenDon.Value.ToString("dd/MM/yyyy");
                dr["Ma"] = item["MaDon"].ToString();
                dr["CreateDate"] = item["NgayChuyen"].ToString();
                if (item["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["NoiDung"] = item["NoiDungDon"].ToString();
                dr["NoiNhan"] = item["NoiNhan"].ToString();
                dr["GhiChu"] = item["NoiDung"].ToString();
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDSChuyenDonTu rpt = new rptDSChuyenDonTu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void cmbTimTheo_DSChuyenKTXM_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString())
            {
                case "Số Công Văn":
                    txtNoiDungTimKiem_DSChuyenKTXM.Visible = true;
                    panel_KhoangThoiGian_DSChuyenKTXM.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem_DSChuyenKTXM.Visible = false;
                    panel_KhoangThoiGian_DSChuyenKTXM.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem_DSChuyenKTXM.Visible = false;
                    panel_KhoangThoiGian_DSChuyenKTXM.Visible = false;
                    break;
            }
        }

        private void btnBaoCao_DSChuyenKTXM_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            switch (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString())
            {
                case "Ngày":
                    if (cmbNhanVienKiemTra.SelectedIndex == 0)
                        dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                    else
                        dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo,int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                    break;
                case "Số Công Văn":
                    if (cmbNhanVienKiemTra.SelectedIndex == 0)
                        dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                    else
                        dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.KyHieuMaTo, int.Parse(cmbNhanVienKiemTra.SelectedValue.ToString()), txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (chkChuaKT_DSChuyenKTXM.Checked)
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (bool.Parse(itemRow["GiaiQuyet"].ToString()) == false)
                    {
                        DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                        if (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString() == "Ngày")
                        {
                            dr["TuNgay"] = dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                        }
                        dr["MaDon"] = itemRow["MaDon"].ToString();
                        //dr["STT"] = itemRow["STT"].ToString();
                        dr["NgayChuyen"] = itemRow["NgayChuyen"];
                        dr["NgayNhan"] = itemRow["NgayNhan"];
                        dr["SoCongVan"] = itemRow["SoCongVan"];
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["NoiDung"] = itemRow["NoiDung"];
                        dr["GhiChuChuyenKT"] = itemRow["GhiChu"];
                        dr["NguoiDi"] = itemRow["NguoiDi"];
                        dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                        dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                    }
                }
            else
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                    if (cmbTimTheo_DSChuyenKTXM.SelectedItem.ToString() == "Ngày")
                    {
                        dr["TuNgay"] = dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                    }
                    dr["MaDon"] = itemRow["MaDon"].ToString();
                    //dr["STT"] = itemRow["STT"].ToString();
                    dr["NgayChuyen"] = itemRow["NgayChuyen"];
                    dr["NgayNhan"] = itemRow["NgayNhan"];
                    dr["SoCongVan"] = itemRow["SoCongVan"];
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["NoiDung"] = itemRow["NoiDung"];
                    dr["GhiChuChuyenKT"] = itemRow["GhiChu"];
                    dr["NguoiDi"] = itemRow["NguoiDi"];
                    dr["DaGiaiQuyet"] = itemRow["GiaiQuyet"];
                    dr["NgayGiaiQuyet"] = itemRow["NgayGiaiQuyet"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                }

            rptDSDonTXLChuyenKTXM rpt = new rptDSDonTXLChuyenKTXM();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            rpt.Subreports[1].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        //

        private void btnBaoCao_ThongKeNhomDon_ToGD_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
                dt = _cDonTu.getDS_ThongKeNhomDon("", dateTu_ThongKeNhomDon_ToGD.Value, dateDen_ThongKeNhomDon_ToGD.Value);
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_ToGD.Value, dateDen_ThongKeNhomDon_ToGD.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeNhomDon_ToGD.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeNhomDon_ToGD.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = CTaiKhoan.TenTo.ToUpper();
                dr["MaDon"] = item["MaDon"];
                dr["MaDonChiTiet"] = item["MaDonChiTiet"];
                dr["NhomDon"] = item["NhomDon"];
                dr["ChuyenToGD"] = item["ChuyenToGD"];
                dr["ChuyenToTB"] = item["ChuyenToTB"];
                dr["ChuyenToTP"] = item["ChuyenToTP"];
                dr["ChuyenToBC"] = item["ChuyenToBC"];
                dr["ChuyenKhac"] = item["ChuyenKhac"];
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
            }

            rptThongKeDonTu rpt = new rptThongKeDonTu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSChuaChuyen_ThongKeNhomDon_ToGD_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
                dt = _cDonTu.getDS_ThongKeNhomDon("", dateTu_ThongKeNhomDon_ToGD.Value, dateDen_ThongKeNhomDon_ToGD.Value);
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_ToGD.Value, dateDen_ThongKeNhomDon_ToGD.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["ChuyenToTB"].ToString()) == false && bool.Parse(item["ChuyenToTP"].ToString()) == false && bool.Parse(item["ChuyenToBC"].ToString()) == false && bool.Parse(item["ChuyenKhac"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_ToGD.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_ToGD.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "CHƯA CHUYỂN";
                    dr["MaDon"] = item["MaDonChiTiet"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
                }

            rptDanhSach_Doc rpt = new rptDanhSach_Doc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        //

        private void btnBaoCao_ThongKeNhomDon_3To_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                if (cmbTo.SelectedIndex > -1)
                    dt = _cDonTu.getDS_ThongKeNhomDon(cmbTo.SelectedValue.ToString(), dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            }
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = CTaiKhoan.TenTo.ToUpper();
                dr["MaDonMoi"] = item["MaDon"];
                dr["MaDon"] = item["MaDonChiTiet"];
                dr["TenLD"] = item["NhomDon"];
                dr["ChuyenTrucTiep"] = item["ChuyenTrucTiep"];
                dr["ChuyenKTXM"] = item["ChuyenKTXM"];
                dr["DaKTXM"] = item["DaKTXM"];
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
            }

            rptThongKeDonTKH rpt = new rptThongKeDonTKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSChuaChuyen_ThongKeNhomDon_3To_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                if (cmbTo.SelectedIndex > -1)
                    dt = _cDonTu.getDS_ThongKeNhomDon(cmbTo.SelectedValue.ToString(), dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            }
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["ChuyenTrucTiep"].ToString()) == false && bool.Parse(item["ChuyenKTXM"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["MaDon"] = item["MaDonChiTiet"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
                }

            rptDSDonKH rpt = new rptDSDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSChuaKTXM_ThongKeNhomDon_3To_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                if (cmbTo.SelectedIndex > -1)
                    dt = _cDonTu.getDS_ThongKeNhomDon(cmbTo.SelectedValue.ToString(), dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            }
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["ChuyenKTXM"].ToString()) == true && bool.Parse(item["DaKTXM"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["MaDon"] = item["MaDonChiTiet"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
                }

            rptDSDonKH rpt = new rptDSDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        //

        private void btnBaoCao_ThongKeNhomDon_Phong_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDonTu.getDS_ThongKeNhomDon(dateTu_ThongKeNhomDon_Phong.Value, dateDen_ThongKeNhomDon_Phong.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeNhomDon_Phong.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeNhomDon_Phong.Value.ToString("dd/MM/yyyy");
                dr["MaDon"] = item["MaDon"];
                dr["MaDonChiTiet"] = item["MaDonChiTiet"];
                dr["NhomDon"] = item["NhomDon"];
                //dr["ChuyenKhac"] = item["ChuyenTrucTiep"];
                dr["DaKTXM"] = item["DaKTXM"];
                dr["NguoiLap"] = CTaiKhoan.HoTen;
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
            }

            rptThongKeDonTu_Phong rpt = new rptThongKeDonTu_Phong();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSChuaChuyen_ThongKeNhomDon_Phong_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDonTu.getDS_ThongKeNhomDon(dateTu_ThongKeNhomDon_Phong.Value, dateDen_ThongKeNhomDon_Phong.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["DaKTXM"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_Phong.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_Phong.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "TỒN";
                    dr["MaDon"] = item["MaDonChiTiet"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
                }

            rptDanhSach_Doc rpt = new rptDanhSach_Doc();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDS_ThongKeNhomDon_3To_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin || CTaiKhoan.TruongPhong || CTaiKhoan.ToTruong)
            {
                if (cmbTo.SelectedIndex > -1)
                    dt = _cDonTu.getDS_ThongKeNhomDon(cmbTo.SelectedValue.ToString(), dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            }
            else
                dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.KyHieuMaTo, dateTu_ThongKeNhomDon_3To.Value, dateDen_ThongKeNhomDon_3To.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow[] checkExists = dsBaoCao.Tables["DanhSach"].Select("MaDon = '" + item["MaDon"] + "'");
                if (checkExists.Length == 0)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon_3To.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = CTaiKhoan.TenTo.ToUpper();
                    dr["MaDon"] = item["MaDon"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    dr["NhomDon"] = item["NhomDon"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
                }
            }

            rptDanhSach_Doc_GroupNhomDon rpt = new rptDanhSach_Doc_GroupNhomDon();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }




    }
}
