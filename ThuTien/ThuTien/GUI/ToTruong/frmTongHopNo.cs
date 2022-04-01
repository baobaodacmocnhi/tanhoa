using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.ToTruong;
using System.Globalization;
using ThuTien.DAL.Quay;
using ThuTien.LinQ;
using ThuTien.DAL;
using ThuTien.DAL.ToTruong;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmTongHopNo : Form
    {
        string _mnu = "mnuTongHopNo";
        CHoaDon _cHoaDon = new CHoaDon();
        CTongHopNo _cTHN = new CTongHopNo();
        CTo _cTo = new CTo();
        CTamThu _cTamThu = new CTamThu();
        CTienDu _cTienDu = new CTienDu();
        CKinhDoanh _cKinhDoanh = new CKinhDoanh();
        CDocSo _cDocSo = new CDocSo();
        BindingSource bsHoaDon = new BindingSource();
        DataTable _dt = new DataTable();

        public frmTongHopNo()
        {
            InitializeComponent();

            dateThanhToan.Value = DateTime.Now;
        }

        private void frmTongHopNo_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTongHopNo.AutoGenerateColumns = false;
            dgvHoaDon.DataSource = bsHoaDon;

            if (CNguoiDung.Doi)
            {
                lbTo.Visible = true;
                cmbTo.Visible = true;

                List<TT_To> lstTo = _cTo.getDS_HanhThu();
                TT_To to = new TT_To();
                to.MaTo = 0;
                to.TenTo = "Tất Cả";
                lstTo.Insert(0, to);
                cmbTo.DataSource = lstTo;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }

            //DataTable _dt = new DataTable();
            DataColumn col = new DataColumn("MaHD");
            col.DataType = System.Type.GetType("System.String");
            _dt.Columns.Add(col);
            //DataColumn[] columns = new DataColumn[1];
            //columns[0] = _dt.Columns["MaHD"];
            //_dt.PrimaryKey = columns;

            col = new DataColumn("HoTen");
            col.DataType = System.Type.GetType("System.String");
            _dt.Columns.Add(col);

            col = new DataColumn("DanhBo");
            col.DataType = System.Type.GetType("System.String");
            _dt.Columns.Add(col);

            col = new DataColumn("DiaChi");
            col.DataType = System.Type.GetType("System.String");
            _dt.Columns.Add(col);

            col = new DataColumn("Ky");
            col.DataType = System.Type.GetType("System.String");
            _dt.Columns.Add(col);

            col = new DataColumn("SoHoaDon");
            col.DataType = System.Type.GetType("System.String");
            _dt.Columns.Add(col);

            col = new DataColumn("GiaBieu");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("TyLeSH");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("TyLeHCSN");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("TyLeSX");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("TyLeDV");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("DinhMuc");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("DinhMucHN");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("TieuThu");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("GiaBan");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("ThueGTGT");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("PhiBVMT");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("PhiBVMT_Thue");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("TongCong");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("DinhMuc_Cu");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("DinhMuc_Moi");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("HieuLucKy");
            col.DataType = System.Type.GetType("System.String");
            _dt.Columns.Add(col);

            col = new DataColumn("TienDu");
            col.DataType = System.Type.GetType("System.Int32");
            _dt.Columns.Add(col);

            col = new DataColumn("TuNgay");
            col.DataType = System.Type.GetType("System.DateTime");
            _dt.Columns.Add(col);

            col = new DataColumn("DenNgay");
            col.DataType = System.Type.GetType("System.DateTime");
            _dt.Columns.Add(col);
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    DataTable dtTemp = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim().Replace(" ", ""));
                    if (dtTemp.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtTemp.Rows)
                        //if (!_dt.Rows.Contains(item["MaHD"].ToString()))
                        {
                            DataRow row = _dt.NewRow();
                            row["MaHD"] = item["MaHD"];
                            row["DanhBo"] = item["DanhBo"];
                            row["HoTen"] = item["HoTen"];
                            row["DiaChi"] = item["DiaChi"];
                            row["Ky"] = item["Ky"];
                            row["SoHoaDon"] = item["SoHoaDon"];
                            row["GiaBieu"] = item["GiaBieu"];
                            if (item["TyLeSH"].ToString() != "")
                                row["TyLeSH"] = item["TyLeSH"];
                            else
                                row["TyLeSH"] = 0;
                            if (item["TyLeHCSN"].ToString() != "")
                                row["TyLeHCSN"] = item["TyLeHCSN"];
                            else
                                row["TyLeHCSN"] = 0;
                            if (item["TyLeSX"].ToString() != "")
                                row["TyLeSX"] = item["TyLeSX"];
                            else
                                row["TyLeSX"] = 0;
                            if (item["TyLeDV"].ToString() != "")
                                row["TyLeDV"] = item["TyLeDV"];
                            else
                                row["TyLeDV"] = 0;
                            if (item["DinhMucHN"].ToString() != "")
                                row["DinhMucHN"] = item["DinhMucHN"];
                            else
                                row["DinhMucHN"] = 0;
                            if (item["DinhMuc"].ToString() != "")
                                row["DinhMuc"] = item["DinhMuc"];
                            else
                                row["DinhMuc"] = 0;
                            row["TieuThu"] = item["TieuThu"];
                            row["GiaBan"] = item["GiaBan"];
                            row["ThueGTGT"] = item["ThueGTGT"];
                            row["PhiBVMT"] = item["PhiBVMT"];
                            row["PhiBVMT_Thue"] = item["PhiBVMT_Thue"];
                            row["TongCong"] = item["TongCong"];
                            DCBD_ChiTietBienDong dcbd = _cKinhDoanh.get_BienDong(item["DanhBo"].ToString());
                            if (dcbd != null)
                            {
                                if (dcbd.DinhMuc != null)
                                    row["DinhMuc_Cu"] = dcbd.DinhMuc;
                                if (dcbd.DinhMuc_BD != null)
                                    row["DinhMuc_Moi"] = dcbd.DinhMuc_BD;
                                if (dcbd.HieuLucKy != null)
                                    row["HieuLucKy"] = dcbd.HieuLucKy;
                            }
                            row["TienDu"] = _cTienDu.GetTienDu(item["DanhBo"].ToString()) * -1;
                            row["TuNgay"] = item["TuNgay"];
                            row["DenNgay"] = item["DenNgay"];
                            _dt.Rows.Add(row);
                        }
                    }
                    else
                    {
                        HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                        int Ky = 0, Nam = 0;
                        if (hoadon.KY == 12)
                        {
                            Ky = 1;
                            Nam = hoadon.NAM + 1;
                        }
                        else
                        {
                            Ky = hoadon.KY + 1;
                            Nam = hoadon.NAM;
                        }
                        DocSo docso = new DocSo();
                        docso = _cDocSo.get(hoadon.DANHBA, Ky, Nam);
                        if (docso == null)
                            docso = _cDocSo.get(hoadon.DANHBA, hoadon.KY, hoadon.NAM);
                        if (hoadon != null && docso != null)
                        {
                            DataRow row = _dt.NewRow();
                            row["MaHD"] = hoadon.ID_HOADON;
                            row["HoTen"] = hoadon.TENKH;
                            row["DanhBo"] = hoadon.DANHBA;
                            row["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                            row["Ky"] = docso.Ky + "/" + docso.Nam;
                            row["GiaBieu"] = hoadon.GB;
                            if (hoadon.TILESH != null)
                                row["TyLeSH"] = hoadon.TILESH;
                            else
                                row["TyLeSH"] = 0;
                            if (hoadon.TILEHCSN != null)
                                row["TyLeHCSN"] = hoadon.TILEHCSN;
                            else
                                row["TyLeHCSN"] = 0;
                            if (hoadon.TILESX != null)
                                row["TyLeSX"] = hoadon.TILESX;
                            else
                                row["TyLeSX"] = 0;
                            if (hoadon.TILEDV != null)
                                row["TyLeDV"] = hoadon.TILEDV;
                            else
                                row["TyLeDV"] = 0;
                            if (hoadon.DinhMucHN != null)
                                row["DinhMucHN"] = hoadon.DinhMucHN;
                            else
                                row["DinhMucHN"] = 0;
                            if (hoadon.DM != null)
                                row["DinhMuc"] = hoadon.DM;
                            else
                                row["DinhMuc"] = 0;
                            row["TieuThu"] = 0;
                            DCBD_ChiTietBienDong dcbd = _cKinhDoanh.get_BienDong(hoadon.DANHBA);
                            if (dcbd != null)
                            {
                                if (dcbd.DinhMuc != null)
                                    row["DinhMuc_Cu"] = dcbd.DinhMuc;
                                if (dcbd.DinhMuc_BD != null)
                                    row["DinhMuc_Moi"] = dcbd.DinhMuc_BD;
                                if (dcbd.HieuLucKy != null)
                                    row["HieuLucKy"] = dcbd.HieuLucKy;
                            }
                            row["TienDu"] = _cTienDu.GetTienDu(hoadon.DANHBA) * -1;
                            row["TuNgay"] = docso.TuNgay.Value;
                            row["DenNgay"] = docso.DenNgay.Value;
                            _dt.Rows.Add(row);
                        }
                    }
                    bsHoaDon.DataSource = _dt;
                    txtDanhBo.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (!_cTHN.CheckExist(txtKinhGui.Text.Trim(), DateTime.Now))
                {
                    TT_TongHopNo tonghopno = new TT_TongHopNo();

                    tonghopno.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    tonghopno.KinhGui = txtKinhGui.Text.Trim();
                    if (!string.IsNullOrEmpty(txtCSM.Text.Trim()))
                        tonghopno.ChiSoMoi = txtCSM.Text.Trim();
                    if (!string.IsNullOrEmpty(txtCSC.Text.Trim()))
                        tonghopno.ChiSoCu = txtCSC.Text.Trim();
                    if (!string.IsNullOrEmpty(txtDM.Text.Trim()))
                        tonghopno.DinhMuc = txtDM.Text.Trim();
                    if (!string.IsNullOrEmpty(txtTT.Text.Trim()))
                        tonghopno.TieuThu = txtTT.Text.Trim();
                    tonghopno.NgayThanhToan = dateThanhToan.Value;
                    tonghopno.TuNgay = txtTuNgay.Text.Trim();
                    tonghopno.DenNgay = txtDenNgay.Text.Trim();
                    tonghopno.LyDoTienDu = txtLyDoTienDu.Text.Trim();
                    //if (radGiamDoc.Checked)
                    //    tonghopno.NguoiKy = "GIÁM ĐỐC";
                    //else
                    //    if (radPhoGiamDoc.Checked)
                    //        tonghopno.NguoiKy = "P.GIÁM ĐỐC";

                    int ID = _cTHN.GetNextID_CTTongHopNo();
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    {
                        TT_TongHopNo_ChiTiet cttonghopno = new TT_TongHopNo_ChiTiet();
                        cttonghopno.ID = ID++;
                        cttonghopno.DanhBo = item.Cells["DanhBo"].Value.ToString();
                        cttonghopno.DiaChi = item.Cells["DiaChi"].Value.ToString();
                        cttonghopno.Ky = item.Cells["Ky"].Value.ToString();
                        if (item.Cells["GiaBieu"].Value != null && !string.IsNullOrEmpty(item.Cells["GiaBieu"].Value.ToString()))
                            cttonghopno.GiaBieu = int.Parse(item.Cells["GiaBieu"].Value.ToString());
                        if (item.Cells["DinhMuc"].Value != null && !string.IsNullOrEmpty(item.Cells["DinhMuc"].Value.ToString()))
                            cttonghopno.DinhMuc = int.Parse(item.Cells["DinhMuc"].Value.ToString());
                        if (item.Cells["TieuThu"].Value != null && !string.IsNullOrEmpty(item.Cells["TieuThu"].Value.ToString()))
                            cttonghopno.TieuThu = int.Parse(item.Cells["TieuThu"].Value.ToString());
                        cttonghopno.GiaBan = decimal.Parse(item.Cells["GiaBan"].Value.ToString());
                        cttonghopno.ThueGTGT = decimal.Parse(item.Cells["ThueGTGT"].Value.ToString());
                        cttonghopno.PhiBVMT = decimal.Parse(item.Cells["PhiBVMT"].Value.ToString());
                        if (item.Cells["PhiBVMT_Thue"].Value != null && !string.IsNullOrEmpty(item.Cells["PhiBVMT_Thue"].Value.ToString()))
                            cttonghopno.PhiBVMT_Thue = decimal.Parse(item.Cells["PhiBVMT_Thue"].Value.ToString());
                        cttonghopno.TongCong = decimal.Parse(item.Cells["TongCong"].Value.ToString());
                        if (item.Cells["TienDu"] != null && item.Cells["TienDu"].Value.ToString() != "")
                            cttonghopno.TienDu = decimal.Parse(item.Cells["TienDu"].Value.ToString());
                        else
                            cttonghopno.TienDu = 0;
                        cttonghopno.CreateBy = CNguoiDung.MaND;
                        cttonghopno.CreateDate = DateTime.Now;
                        tonghopno.TT_TongHopNo_ChiTiets.Add(cttonghopno);
                    }
                    _cTHN.Them(tonghopno);

                    dsBaoCao ds = new dsBaoCao();
                    int TongCongSo = 0;
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    {
                        DataRow dr = ds.Tables["TongHopNo"].NewRow();
                        dr["SoPhieu"] = tonghopno.MaTHN.ToString().Insert(tonghopno.MaTHN.ToString().Length - 2, "-");
                        dr["KinhGui"] = txtKinhGui.Text.Trim();
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                        dr["Ky"] = item.Cells["Ky"].Value.ToString();
                        dr["TieuThu"] = item.Cells["TieuThu"].Value.ToString();
                        dr["GiaBan"] = item.Cells["GiaBan"].Value.ToString();
                        dr["ThueGTGT"] = item.Cells["ThueGTGT"].Value.ToString();
                        dr["PhiBVMT"] = item.Cells["PhiBVMT"].Value.ToString();
                        if (item.Cells["PhiBVMT_Thue"].Value != null && item.Cells["PhiBVMT_Thue"].Value.ToString() != "")
                            dr["PhiBVMT_Thue"] = item.Cells["PhiBVMT_Thue"].Value.ToString();
                        dr["TongCong"] = item.Cells["TongCong"].Value.ToString();
                        if (item.Cells["TienDu"] != null && item.Cells["TienDu"].Value.ToString() != "")
                            dr["TienDu"] = item.Cells["TienDu"].Value.ToString();
                        else
                            dr["TienDu"] = 0;
                        TongCongSo += int.Parse(item.Cells["TongCong"].Value.ToString()) + int.Parse(dr["TienDu"].ToString());
                        dr["CSM"] = txtCSM.Text.Trim();
                        dr["CSC"] = txtCSC.Text.Trim();
                        dr["TT"] = txtTT.Text.Trim();
                        dr["DM"] = txtDM.Text.Trim();
                        dr["TuNgay"] = txtTuNgay.Text.Trim();
                        dr["DenNgay"] = txtDenNgay.Text.Trim();

                        ds.Tables["TongHopNo"].Rows.Add(dr);
                    }
                    DataRow dr1 = ds.Tables["TongHopNo"].NewRow();
                    //dr1["CSM"] = txtCSM.Text.Trim();
                    //dr1["CSC"] = txtCSC.Text.Trim();
                    //dr1["TT"] = txtTT.Text.Trim();
                    //dr1["DM"] = txtDM.Text.Trim();
                    //dr1["TuNgay"] = txtTuNgay.Text.Trim();
                    //dr1["DenNgay"] = txtDenNgay.Text.Trim();
                    dr1["LyDo"] = txtLyDoTienDu.Text.Trim();
                    dr1["TongCongSo"] = TongCongSo;
                    dr1["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
                    dr1["NgayThanhToan"] = dateThanhToan.Value.ToString("dd/MM/yyyy");
                    //if (radGiamDoc.Checked)
                    //    dr1["NguoiKy"] = "GIÁM ĐỐC";
                    //else
                    //    if (radPhoGiamDoc.Checked)
                    //        dr1["NguoiKy"] = "P.GIÁM ĐỐC";
                    if (chkChuKy.Checked == true)
                    {
                        dr1["ChuKy"] = true;
                        dr1["ChuKyImage"] = Application.StartupPath.ToString() + @"\Resources\chuky.png";
                    }
                    if (chkTenKy.Checked == true)
                        dr1["NguoiKy"] = CNguoiKy.getNguoiKy();

                    ds.Tables["TongHopNo"].Rows.Add(dr1);
                    if (radA4.Checked)
                    {
                        rptTongHopNoA4 rpt = new rptTongHopNoA4();
                        rpt.SetDataSource(ds);

                        DataRow drLogo = ds.Tables["DSHoaDon"].NewRow();
                        drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                        ds.Tables["DSHoaDon"].Rows.Add(drLogo);
                        rpt.Subreports[0].SetDataSource(ds);

                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.Show();
                    }
                    else
                        if (radA5.Checked)
                        {
                            rptTongHopNoA5 rpt = new rptTongHopNoA5();
                            rpt.SetDataSource(ds);

                            DataRow drLogo = ds.Tables["DSHoaDon"].NewRow();
                            drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                            ds.Tables["DSHoaDon"].Rows.Add(drLogo);
                            rpt.Subreports[0].SetDataSource(ds);

                            frmBaoCao frm = new frmBaoCao(rpt);
                            frm.Show();
                        }
                }
                else
                    MessageBox.Show("Đã lập trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
            //if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            //{
            //    e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            //}
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT_Thue" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TienDu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDanhBo.Text = dgvHoaDon["DanhBo", e.RowIndex].Value.ToString();
                txtKinhGui.Text = dgvHoaDon["HoTen", e.RowIndex].Value.ToString();
            }
            catch
            {
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi)
            {
                ///chọn tất cả các tổ
                if (cmbTo.SelectedIndex == 0)
                    dgvTongHopNo.DataSource = _cTHN.GetDS(dateTu.Value, dateDen.Value);
                else
                    ///chọn 1 tổ cụ thể
                    if (cmbTo.SelectedIndex > 0)
                        dgvTongHopNo.DataSource = _cTHN.GetDS_To(int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
            }
            else
                dgvTongHopNo.DataSource = _cTHN.GetDS_To(CNguoiDung.MaTo, dateTu.Value, dateDen.Value);
        }

        private void dgvTongHopNo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTongHopNo.Columns[e.ColumnIndex].Name == "MaTHN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvTongHopNo.Columns[e.ColumnIndex].Name == "DanhBo_THN" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
            if (dgvTongHopNo.Columns[e.ColumnIndex].Name == "TongCong_THN" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTongHopNo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTongHopNo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTongHopNo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTongHopNo.RowCount > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {

            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            TT_TongHopNo tonghopno = _cTHN.Get(decimal.Parse(dgvTongHopNo.SelectedRows[0].Cells["MaTHN"].Value.ToString()));

            dsBaoCao ds = new dsBaoCao();
            int TongCongSo = 0;
            foreach (TT_TongHopNo_ChiTiet item in tonghopno.TT_TongHopNo_ChiTiets)
            {
                DataRow dr = ds.Tables["TongHopNo"].NewRow();
                dr["SoPhieu"] = tonghopno.MaTHN.ToString().Insert(tonghopno.MaTHN.ToString().Length - 2, "-");
                dr["KinhGui"] = tonghopno.KinhGui;
                dr["DanhBo"] = item.DanhBo.Insert(4, " ").Insert(8, " ");
                dr["DiaChi"] = item.DiaChi;
                dr["Ky"] = item.Ky;
                dr["TieuThu"] = item.TieuThu;
                dr["GiaBan"] = item.GiaBan.Value.ToString();
                dr["ThueGTGT"] = item.ThueGTGT.Value.ToString();
                dr["PhiBVMT"] = item.PhiBVMT.Value.ToString();
                if (item.PhiBVMT_Thue != null)
                    dr["PhiBVMT_Thue"] = item.PhiBVMT_Thue.Value.ToString();
                dr["TongCong"] = item.TongCong.Value.ToString();
                if (item.TienDu != null)
                    dr["TienDu"] = item.TienDu.Value.ToString();
                else
                    dr["TienDu"] = 0;
                TongCongSo += (int)item.TongCong.Value + int.Parse(dr["TienDu"].ToString());
                dr["CSM"] = tonghopno.ChiSoMoi;
                dr["CSC"] = tonghopno.ChiSoCu;
                dr["TT"] = tonghopno.TieuThu;
                dr["DM"] = tonghopno.DinhMuc;
                dr["TuNgay"] = tonghopno.TuNgay;
                dr["DenNgay"] = tonghopno.DenNgay;

                ds.Tables["TongHopNo"].Rows.Add(dr);
            }
            DataRow dr1 = ds.Tables["TongHopNo"].NewRow();
            //dr1["CSM"] = tonghopno.ChiSoMoi;
            //dr1["CSC"] = tonghopno.ChiSoCu;
            //dr1["TT"] = tonghopno.TieuThu;
            //dr1["DM"] = tonghopno.DinhMuc;
            //dr1["TuNgay"] = tonghopno.TuNgay;
            //dr1["DenNgay"] = tonghopno.DenNgay;
            dr1["LyDo"] = tonghopno.LyDoTienDu;
            dr1["TongCongSo"] = TongCongSo;
            dr1["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
            dr1["NgayThanhToan"] = tonghopno.NgayThanhToan.Value.ToString("dd/MM/yyyy");
            //if (radGiamDoc.Checked)
            //    dr1["NguoiKy"] = "GIÁM ĐỐC";
            //else
            //    if (radPhoGiamDoc.Checked)
            //        dr1["NguoiKy"] = "P.GIÁM ĐỐC";
            if (chkChuKy.Checked == true)
            {
                dr1["ChuKy"] = true;
                dr1["ChuKyImage"] = Application.StartupPath.ToString() + @"\Resources\chuky.png";
            }
            if (chkTenKy.Checked == true)
                dr1["NguoiKy"] = CNguoiKy.getNguoiKy();

            ds.Tables["TongHopNo"].Rows.Add(dr1);
            if (radA4.Checked)
            {
                rptTongHopNoA4 rpt = new rptTongHopNoA4();
                rpt.SetDataSource(ds);

                DataRow drLogo = ds.Tables["DSHoaDon"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                ds.Tables["DSHoaDon"].Rows.Add(drLogo);
                rpt.Subreports[0].SetDataSource(ds);

                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
            else
                if (radA5.Checked)
                {
                    rptTongHopNoA5 rpt = new rptTongHopNoA5();
                    rpt.SetDataSource(ds);

                    DataRow drLogo = ds.Tables["DSHoaDon"].NewRow();
                    drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                    ds.Tables["DSHoaDon"].Rows.Add(drLogo);
                    rpt.Subreports[0].SetDataSource(ds);

                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.Show();
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TT_TongHopNo tonghopno = _cTHN.Get(decimal.Parse(dgvTongHopNo.SelectedRows[0].Cells["MaTHN"].Value.ToString()));
                    if (tonghopno != null)
                    {
                        if (_cTHN.Xoa(tonghopno))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        wsThuTien.wsThuTien wsThuTien = new wsThuTien.wsThuTien();
        private void dgvHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.RowCount > 0)
                if (dgvHoaDon.Columns[e.ColumnIndex].Name != "GiaBan" && dgvHoaDon.Columns[e.ColumnIndex].Name != "ThueGTGT" && dgvHoaDon.Columns[e.ColumnIndex].Name != "PhiBVMT" && dgvHoaDon.Columns[e.ColumnIndex].Name != "PhiBVMT_Thue" && dgvHoaDon.Columns[e.ColumnIndex].Name != "TongCong")
                {

                    int TienNuocNamCu = 0, TienNuocNamMoi = 0, PhiBVMTNamCu = 0, PhiBVMTNamMoi = 0, TieuThu_DieuChinhGia = 0, TienNuoc = 0, ThueGTGT = 0, TDVTN = 0, ThueTDVTN = 0;
                    string ChiTietNamCu = "", ChiTietNamMoi = "", ChiTietPhiBVMTNamCu = "", ChiTietPhiBVMTNamMoi = "";
                    string[] Kys = dgvHoaDon["Ky", e.RowIndex].Value.ToString().Split('/');
                    HOADON hd = _cHoaDon.Get(dgvHoaDon["DanhBo", e.RowIndex].Value.ToString(), int.Parse(Kys[1]), int.Parse(Kys[0]));
                    if (hd != null && hd.DCHD == true)
                    {
                        dgvHoaDon["GiaBan", e.RowIndex].Value = hd.GIABAN;
                        dgvHoaDon["ThueGTGT", e.RowIndex].Value = hd.THUE;
                        dgvHoaDon["PhiBVMT", e.RowIndex].Value = hd.PHI;
                        if (hd.ThueGTGT_TDVTN != null)
                            dgvHoaDon["PhiBVMT_Thue", e.RowIndex].Value = hd.ThueGTGT_TDVTN;
                        else
                            dgvHoaDon["PhiBVMT_Thue", e.RowIndex].Value = 0;
                        dgvHoaDon["TongCong", e.RowIndex].Value = hd.TONGCONG;
                    }
                    else
                    {
                        wsThuTien.TinhTienNuoc(false, false, false, 0, dgvHoaDon["DanhBo", e.RowIndex].Value.ToString(), int.Parse(Kys[0]), int.Parse(Kys[1]), DateTime.Parse(dgvHoaDon["TuNgay", e.RowIndex].Value.ToString()), DateTime.Parse(dgvHoaDon["DenNgay", e.RowIndex].Value.ToString())
                             , int.Parse(dgvHoaDon["GiaBieu", e.RowIndex].Value.ToString()), int.Parse(dgvHoaDon["TyLeSH", e.RowIndex].Value.ToString()), int.Parse(dgvHoaDon["TyLeSX", e.RowIndex].Value.ToString()), int.Parse(dgvHoaDon["TyLeDV", e.RowIndex].Value.ToString()), int.Parse(dgvHoaDon["TyLeHCSN", e.RowIndex].Value.ToString())
                             , int.Parse(dgvHoaDon["DinhMuc", e.RowIndex].Value.ToString()), int.Parse(dgvHoaDon["DinhMucHN", e.RowIndex].Value.ToString()), int.Parse(dgvHoaDon["TieuThu", e.RowIndex].Value.ToString()), ref TienNuocNamCu, ref ChiTietNamCu, ref TienNuocNamMoi, ref ChiTietNamMoi, ref TieuThu_DieuChinhGia, ref PhiBVMTNamCu, ref ChiTietPhiBVMTNamCu, ref PhiBVMTNamMoi, ref ChiTietPhiBVMTNamMoi
                             , ref TienNuoc, ref ThueGTGT, ref TDVTN, ref ThueTDVTN);
                        dgvHoaDon["GiaBan", e.RowIndex].Value = TienNuoc;
                        dgvHoaDon["ThueGTGT", e.RowIndex].Value = ThueGTGT;
                        dgvHoaDon["PhiBVMT", e.RowIndex].Value = TDVTN;
                        //int ThueGTGTTDVTN = 0, TongCong = 0;
                        ////Từ 2022 Phí BVMT -> Tiền Dịch Vụ Thoát Nước
                        //if ((DateTime.Parse(dgvHoaDon["TuNgay", e.RowIndex].Value.ToString()).Year < 2021) || (DateTime.Parse(dgvHoaDon["TuNgay", e.RowIndex].Value.ToString()).Year == 2021 && DateTime.Parse(dgvHoaDon["DenNgay", e.RowIndex].Value.ToString()).Year == 2021))
                        //{
                        //    ThueGTGTTDVTN = 0;
                        //    TongCong = (int)((TienNuocNamCu + TienNuocNamMoi) + Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTNamCu + PhiBVMTNamMoi));
                        //}
                        //else
                        //    if (DateTime.Parse(dgvHoaDon["TuNgay", e.RowIndex].Value.ToString()).Year == 2021 && DateTime.Parse(dgvHoaDon["DenNgay", e.RowIndex].Value.ToString()).Year == 2022)
                        //    {
                        //        ThueGTGTTDVTN = (int)Math.Round((double)(PhiBVMTNamMoi) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                        //        TongCong = (int)((TienNuocNamCu + TienNuocNamMoi) + Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTNamCu + PhiBVMTNamMoi) + ThueGTGTTDVTN);
                        //    }
                        //    else
                        //        if (DateTime.Parse(dgvHoaDon["TuNgay", e.RowIndex].Value.ToString()).Year >= 2022)
                        //        {
                        //            ThueGTGTTDVTN = (int)Math.Round((double)(PhiBVMTNamCu + PhiBVMTNamMoi) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                        //            TongCong = (int)((TienNuocNamCu + TienNuocNamMoi) + Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (PhiBVMTNamCu + PhiBVMTNamMoi) + ThueGTGTTDVTN);
                        //        }
                        dgvHoaDon["PhiBVMT_Thue", e.RowIndex].Value = ThueTDVTN;
                        dgvHoaDon["TongCong", e.RowIndex].Value = TienNuoc + ThueGTGT + TDVTN + ThueTDVTN;
                    }
                }
        }

    }
}
