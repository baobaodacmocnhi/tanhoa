using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_ChungCu.DAL;
using KTKS_ChungCu.BaoCao;
using KTKS_ChungCu.LinQ;

namespace KTKS_ChungCu
{
    public partial class frmDSCatChuyenDM : Form
    {
        CChungTu _cChungTu = new CChungTu();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CTTKH _cTTKH = new CTTKH();

        public frmDSCatChuyenDM()
        {
            InitializeComponent();
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Số Phiếu":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    //DSDCBD_BS.RemoveFilter();
                    break;
            }
            dgvDSCatChuyenDM.DataSource = null;
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByDate(dateTu.Value);
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByDates(dateTu.Value, dateDen.Value);
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNoiDungTimKiem.Text.Trim() != "")
                {
                    txtNoiDungTimKiem2.Text = "";
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Số Phiếu":
                            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMBySoPhieu(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            break;
                        case "Danh Bộ":
                            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtNoiDungTimKiem2_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem.Text.Trim().Length > 2 && txtNoiDungTimKiem2.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim().Length > 2)
            {
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Số Phiếu":
                        dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMBySoPhieus(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                        break;
                }

            }
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDMByDate(dateTimKiem.Value);
        }

        private void frmDSCatChuyenDM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(50,50);
            dgvDSCatChuyenDM.AutoGenerateColumns = false;

            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                        if (bool.Parse(dgvDSCatChuyenDM["InCatChuyen", i].Value.ToString()) == true)
                        //if (int.Parse(dgvDSCatChuyenDM["CreateBy_CC", i].Value.ToString()) == CTaiKhoan.MaUser)
                        {
                            LichSuChungTu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDSCatChuyenDM["CT_SoPhieu", i].Value.ToString()));
                            if (!string.IsNullOrEmpty(lichsuchungtu.NhanDM.ToString()))
                            {
                                if (lichsuchungtu.NhanDM.Value)
                                {
                                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                    DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                    if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                        if (lichsuchungtu.ToXuLy)
                                            dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                        else
                                            dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                    dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                    dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                    if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                        dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                    dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                    dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                    if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                        dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                    dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                    dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                    ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                    dr["SoNKCat"] = lichsuchungtu.SoNKNhan.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                    dr["ChucVu"] = lichsuchungtu.ChucVu;
                                    dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                    dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                    rptPhieuYCCatDMx2 rpt = new rptPhieuYCCatDMx2();
                                    for (int j = 0; j < rpt.Subreports.Count; j++)
                                    {
                                        rpt.Subreports[j].SetDataSource(dsBaoCao);
                                    }

                                    printDialog.AllowSomePages = true;
                                    printDialog.ShowHelp = true;

                                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    rpt.PrintToPrinter(1, false, 1, 1);
                                }
                            }
                            else
                                if (!string.IsNullOrEmpty(lichsuchungtu.CatDM.ToString()))
                                {
                                    if (lichsuchungtu.CatDM.Value)
                                    {
                                        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                        DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                        if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                            if (lichsuchungtu.ToXuLy)
                                                dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                            else
                                                dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                        dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                        dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.NhanNK_MaCN.Value);
                                        if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                            dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                        dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                        dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                        if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                            dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                        dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                        dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                        dr["SoNKCat"] = lichsuchungtu.SoNKCat + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                        dr["ChucVu"] = lichsuchungtu.ChucVu;
                                        dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                        dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                        rptPhieuYCNhanDMx2 rpt = new rptPhieuYCNhanDMx2();
                                        for (int j = 0; j < rpt.Subreports.Count; j++)
                                        {
                                            rpt.Subreports[j].SetDataSource(dsBaoCao);
                                        }

                                        printDialog.AllowSomePages = true;
                                        printDialog.ShowHelp = true;

                                        rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                        rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                        rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                        rpt.PrintToPrinter(1, false, 1, 1);
                                    }
                                }
                                else
                                    if (!string.IsNullOrEmpty(lichsuchungtu.YeuCauCat.ToString()))
                                    {
                                        if (lichsuchungtu.YeuCauCat.Value)
                                        {
                                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                            DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                            if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                                if (lichsuchungtu.ToXuLy)
                                                    dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                else
                                                    dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                            dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                            dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                            if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                                dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                            dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                            dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                            if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                                dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                            dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                            dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                            ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                            dr["SoNKCat"] = lichsuchungtu.SoNKNhan.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                            dr["ChucVu"] = lichsuchungtu.ChucVu;
                                            dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                            dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                            rptPhieuYCCatDMx2 rpt = new rptPhieuYCCatDMx2();
                                            for (int j = 0; j < rpt.Subreports.Count; j++)
                                            {
                                                rpt.Subreports[j].SetDataSource(dsBaoCao);
                                            }

                                            printDialog.AllowSomePages = true;
                                            printDialog.ShowHelp = true;

                                            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                            rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                            rpt.PrintToPrinter(1, false, 1, 1);
                                        }
                                    }
                        }
                }

            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
                for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                {
                    dgvDSCatChuyenDM["InCatChuyen", i].Value = true;
                }
            else
                for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                {
                    dgvDSCatChuyenDM["InCatChuyen", i].Value = false;
                }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
            {
                DataRow dr = dsBaoCao.Tables["DSChungTu"].NewRow();

                TTKhachHang _ttkhachhang = _cTTKH.getTTKHbyID(dgvDSCatChuyenDM["CT_NhanNK_DanhBo", i].Value.ToString());

                dr["STT"] = dgvDSCatChuyenDM["STT", i].Value.ToString();
                dr["DanhBo"] = _ttkhachhang.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = _ttkhachhang.HoTen;
                dr["DiaChi"] = _ttkhachhang.DC1 + " " + _ttkhachhang.DC2;
                dr["HopDong"] = _ttkhachhang.GiaoUoc;
                dr["GiaBieu"] = _ttkhachhang.GB;
                dr["DinhMuc"] = _ttkhachhang.TGDM;
                dr["LoTrinh"] = _ttkhachhang.Dot + _ttkhachhang.CuonGCS + _ttkhachhang.CuonSTT;
                dr["HoTenCT"] = dgvDSCatChuyenDM["CT_CatNK_HoTen", i].Value.ToString();
                dr["DiaChiCT"] = dgvDSCatChuyenDM["CT_CatNK_DiaChi", i].Value.ToString();
                dr["MaCT"] = dgvDSCatChuyenDM["CT_MaCT", i].Value.ToString();
                dr["SoNKDangKy"] = dgvDSCatChuyenDM["SoNKNhan", i].Value.ToString();
                if (dgvDSCatChuyenDM["CT_CatNK_DanhBo", i].Value.ToString().Length == 11)
                    dr["GhiChu"] = dgvDSCatChuyenDM["CT_CatNK_DanhBo", i].Value.ToString().Insert(7, " ").Insert(4, " ");
                else
                    dr["GhiChu"] = dgvDSCatChuyenDM["CT_CatNK_DanhBo", i].Value.ToString();
                dr["Lo"] = dgvDSCatChuyenDM["Lo", i].Value.ToString();
                dr["Phong"] = dgvDSCatChuyenDM["Phong", i].Value.ToString();

                dsBaoCao.Tables["DSChungTu"].Rows.Add(dr);
            }
            rptDSCatChuyen rpt = new rptDSCatChuyen();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }


    }
}
