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
                            dt = _cDonTu.getDS_LichSu(CTaiKhoan.TenTo, CTaiKhoan.MaUser, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value);
                            break;
                        case "Số Công Văn":
                            dt = _cDonTu.getDS_LichSu(CTaiKhoan.TenTo, CTaiKhoan.MaUser, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper());
                            break;
                    }
                else
                    if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex > 0)
                        switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                        {
                            case "Ngày":
                                dt = _cDonTu.getDS_LichSu(CTaiKhoan.TenTo, CTaiKhoan.MaUser, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value, int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                                break;
                            case "Số Công Văn":
                                dt = _cDonTu.getDS_LichSu(CTaiKhoan.TenTo, CTaiKhoan.MaUser, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper(), int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                                break;
                        }
            }
            else
                if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex == 0)
                    switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                    {
                        case "Ngày":
                            dt = _cDonTu.getDS_LichSu(CTaiKhoan.TenTo, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value);
                            break;
                        case "Số Công Văn":
                            dt = _cDonTu.getDS_LichSu(CTaiKhoan.TenTo, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper());
                            break;
                    }
                else
                    if (cmbNoiNhan_LichSuChuyenDon.SelectedIndex > 0)
                        switch (cmbTimTheo_LichSuChuyenDon.SelectedItem.ToString())
                        {
                            case "Ngày":
                                dt = _cDonTu.getDS_LichSu(CTaiKhoan.TenTo, dateTu_LichSuChuyenDon.Value, dateDen_LichSuChuyenDon.Value, int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
                                break;
                            case "Số Công Văn":
                                dt = _cDonTu.getDS_LichSu(CTaiKhoan.TenTo, txtNoiDungTimKiem_LichSuChuyenDon.Text.Trim().ToUpper(), int.Parse(cmbNoiNhan_LichSuChuyenDon.SelectedValue.ToString()));
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
                    dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.TenTo, dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                    break;
                case "Số Công Văn":
                    dt = _cDonTu.getDS_ChuyenKTXM(CTaiKhoan.TenTo, txtNoiDungTimKiem_DSChuyenKTXM.Text.Trim().ToUpper());
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (chkChuaKT_DSChuyenKTXM.Checked)
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (bool.Parse(itemRow["GiaiQuyet"].ToString()) == false)
                    {
                        DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                        dr["TuNgay"] = dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                        dr["MaDon"] = itemRow["MaDon"].ToString();
                        //dr["STT"] = itemRow["STT"].ToString();
                        //dr["TenLD"] = itemRow["TenLD"];
                        dr["SoCongVan"] = itemRow["SoCongVan"];
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["NoiDung"] = itemRow["NoiDung"];
                        dr["GhiChuChuyenKT"] = itemRow["GhiChu"];
                        dr["NguoiDi"] = itemRow["NguoiDi"];

                        dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                    }
                }
            else
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                    dr["TuNgay"] = dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                    dr["MaDon"] = itemRow["MaDon"].ToString();
                    //dr["STT"] = itemRow["STT"].ToString();
                    //dr["TenLD"] = itemRow["TenLD"];
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

                    dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                }

            rptDSDonTXLChuyenKTXM rpt = new rptDSDonTXLChuyenKTXM();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            rpt.Subreports[1].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCao_ThongKeNhomDon_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.TenTo, dateTu_ThongKeNhomDon.Value, dateDen_ThongKeNhomDon.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeNhomDon.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeNhomDon.Value.ToString("dd/MM/yyyy");
                dr["MaDon"] = item["MaDon"];
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

        private void btnInDSChuaChuyen_ThongKeNhomDon_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.TenTo, dateTu_ThongKeNhomDon.Value, dateDen_ThongKeNhomDon.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["ChuyenTrucTiep"].ToString()) == false && bool.Parse(item["ChuyenKTXM"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon.Value.ToString("dd/MM/yyyy");
                    dr["MaDon"] = item["MaDon"];

                    dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
                }

            rptDSDonKH rpt = new rptDSDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSChuaKTXM_ThongKeNhomDon_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDonTu.getDS_ThongKeNhomDon(CTaiKhoan.TenTo, dateTu_ThongKeNhomDon.Value, dateDen_ThongKeNhomDon.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["ChuyenKTXM"].ToString()) == true && bool.Parse(item["DaKTXM"].ToString()) == false)
                {
                    DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                    dr["TuNgay"] = dateTu_ThongKeNhomDon.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeNhomDon.Value.ToString("dd/MM/yyyy");
                    dr["MaDon"] = item["MaDon"];

                    dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
                }

            rptDSDonKH rpt = new rptDSDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        


    }
}
