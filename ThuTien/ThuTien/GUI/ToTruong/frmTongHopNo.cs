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

namespace ThuTien.GUI.ToTruong
{
    public partial class frmTongHopNo : Form
    {
        string _mnu = "mnuTongHopNo";
        CHoaDon _cHoaDon = new CHoaDon();
        CTongHopNo _cTHN = new CTongHopNo();
        CTo _cTo = new CTo();
        CTamThu _cTamThu = new CTamThu();
        CKinhDoanh _cKTKS_DonKH = new CKinhDoanh();
        BindingSource bsHoaDon = new BindingSource();
        DataTable dt = new DataTable();

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

                List<TT_To> lstTo = _cTo.GetDSHanhThu();
                TT_To to = new TT_To();
                to.MaTo = 0;
                to.TenTo = "Tất Cả";
                lstTo.Insert(0, to);
                cmbTo.DataSource = lstTo;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }

            //DataTable dt = new DataTable();
            DataColumn col = new DataColumn("MaHD");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);
            //DataColumn[] columns = new DataColumn[1];
            //columns[0] = dt.Columns["MaHD"];
            //dt.PrimaryKey = columns;

            col = new DataColumn("HoTen");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("DanhBo");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("DiaChi");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("Ky");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("SoHoaDon");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("GiaBieu");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("DinhMuc");
            col.DataType = System.Type.GetType("System.Int32");

            dt.Columns.Add(col);
            col = new DataColumn("TieuThu");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("GiaBan");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("ThueGTGT");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("PhiBVMT");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("TongCong");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("DinhMuc_Cu");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("DinhMuc_Moi");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);
            //bsHoaDon.DataSource = dt;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable dtTemp = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
                if (dtTemp.Rows.Count > 0)
                {
                    foreach (DataRow item in dtTemp.Rows)
                        //if (!dt.Rows.Contains(item["MaHD"].ToString()))
                        {
                            DataRow row = dt.NewRow();
                            row["MaHD"] = item["MaHD"];
                            row["DanhBo"] = item["DanhBo"];
                            row["HoTen"] = item["HoTen"];
                            row["DiaChi"] = item["DiaChi"];
                            row["Ky"] = item["Ky"];
                            row["SoHoaDon"] = item["SoHoaDon"];
                            row["GiaBieu"] = item["GiaBieu"];
                            row["TieuThu"] = item["TieuThu"];
                            row["GiaBan"] = item["GiaBan"];
                            row["ThueGTGT"] = item["ThueGTGT"];
                            row["PhiBVMT"] = item["PhiBVMT"];
                            row["TongCong"] = item["TongCong"];
                            CTDCBD dcbd = _cKTKS_DonKH.GetDCBD(item["DanhBo"].ToString());
                            if (dcbd != null)
                            {
                                row["DinhMuc_Cu"] = dcbd.DinhMuc;
                                row["DinhMuc_Moi"] = dcbd.DinhMuc_BD;
                            }
                            dt.Rows.Add(row);
                        }
                }
                else
                {
                    HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim());

                    if (hoadon != null)
                    {
                        DataRow row = dt.NewRow();
                        row["MaHD"] = hoadon.ID_HOADON;
                        row["HoTen"] = hoadon.TENKH;
                        row["DanhBo"] = hoadon.DANHBA;
                        row["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                        row["GiaBieu"] = hoadon.GB;
                        if (hoadon.DM != null)
                            row["DinhMuc"] = hoadon.DM;
                        row["TieuThu"] = 0;
                        CTDCBD dcbd = _cKTKS_DonKH.GetDCBD(hoadon.DANHBA);
                        if (dcbd != null)
                        {
                            if (dcbd.DinhMuc!=null)
                            row["DinhMuc_Cu"] = dcbd.DinhMuc;
                            if (dcbd.DinhMuc_BD != null)
                            row["DinhMuc_Moi"] = dcbd.DinhMuc_BD;
                        }
                        dt.Rows.Add(row);
                    }
                }
                bsHoaDon.DataSource = dt;
                txtDanhBo.Text = "";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (!_cTHN.CheckExist(txtKinhGui.Text.Trim(), DateTime.Now))
                {
                    TT_TongHopNo tonghopno = new TT_TongHopNo();

                    tonghopno.DanhBo = txtDanhBo.Text.Trim().Replace(" ","");
                    tonghopno.KinhGui = txtKinhGui.Text.Trim();
                    if (!string.IsNullOrEmpty(txtCSM.Text.Trim()))
                        tonghopno.ChiSoMoi = int.Parse(txtCSM.Text.Trim());
                    if (!string.IsNullOrEmpty(txtCSC.Text.Trim()))
                        tonghopno.ChiSoCu = int.Parse(txtCSC.Text.Trim());
                    if (!string.IsNullOrEmpty(txtDM.Text.Trim()))
                        tonghopno.DinhMuc = int.Parse(txtDM.Text.Trim());
                    if (!string.IsNullOrEmpty(txtTT.Text.Trim()))
                        tonghopno.TieuThu = int.Parse(txtTT.Text.Trim());
                    tonghopno.NgayThanhToan = dateThanhToan.Value;
                    tonghopno.TuNgay = txtTuNgay.Text.Trim();
                    tonghopno.DenNgay = txtDenNgay.Text.Trim();
                    if (radGiamDoc.Checked)
                        tonghopno.NguoiKy = "GIÁM ĐỐC";
                    else
                        if (radPhoGiamDoc.Checked)
                            tonghopno.NguoiKy = "P.GIÁM ĐỐC";

                    int ID = _cTHN.GetNextID_CTTongHopNo();
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    {
                        TT_CTTongHopNo cttonghopno = new TT_CTTongHopNo();
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
                        cttonghopno.TongCong = decimal.Parse(item.Cells["TongCong"].Value.ToString());
                        tonghopno.TT_CTTongHopNos.Add(cttonghopno);
                    }
                    _cTHN.Them(tonghopno);
                }

                dsBaoCao ds = new dsBaoCao();
                int TongCongSo = 0;
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    DataRow dr = ds.Tables["TongHopNo"].NewRow();
                    dr["KinhGui"] = txtKinhGui.Text.Trim();
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                    dr["Ky"] = item.Cells["Ky"].Value.ToString();
                    dr["TieuThu"] = item.Cells["TieuThu"].Value.ToString();
                    dr["GiaBan"] = item.Cells["GiaBan"].Value.ToString();
                    dr["ThueGTGT"] = item.Cells["ThueGTGT"].Value.ToString();
                    dr["PhiBVMT"] = item.Cells["PhiBVMT"].Value.ToString();
                    dr["TongCong"] = item.Cells["TongCong"].Value.ToString();
                    TongCongSo += int.Parse(item.Cells["TongCong"].Value.ToString());
                    dr["CSM"] = txtCSM.Text.Trim();
                    dr["CSC"] = txtCSC.Text.Trim();
                    dr["TT"] = txtTT.Text.Trim();
                    dr["DM"] = txtDM.Text.Trim();
                    dr["TuNgay"] = txtTuNgay.Text.Trim();
                    dr["DenNgay"] = txtDenNgay.Text.Trim();

                    ds.Tables["TongHopNo"].Rows.Add(dr);
                }
                DataRow dr1 = ds.Tables["TongHopNo"].NewRow();
                dr1["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
                dr1["NgayThanhToan"] = dateThanhToan.Value.ToString("dd/MM/yyyy");
                if (radGiamDoc.Checked)
                    dr1["NguoiKy"] = "GIÁM ĐỐC";
                else
                    if (radPhoGiamDoc.Checked)
                        dr1["NguoiKy"] = "P.GIÁM ĐỐC";
                ds.Tables["TongHopNo"].Rows.Add(dr1);
                rptTongHopNo rpt = new rptTongHopNo();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
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
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
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
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
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

        private void dgvHoaDon_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GB" && e.FormattedValue.ToString().Replace(".", "") != dgvHoaDon[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                string ChiTiet = "";
                int DinhMuc = 0;
                int TieuThu = 0;
                if (dgvHoaDon["DinhMuc", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvHoaDon["DinhMuc", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvHoaDon["DinhMuc", e.RowIndex].Value.ToString());
                if (dgvHoaDon["TieuThu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvHoaDon["TieuThu", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvHoaDon["TieuThu", e.RowIndex].Value.ToString());
                int TongTien = _cKTKS_DonKH.TinhTienNuoc(false, 0, dgvHoaDon["DanhBo", e.RowIndex].Value.ToString(), int.Parse(e.FormattedValue.ToString().Replace(".", "")), DinhMuc, TieuThu, out ChiTiet);
                dgvHoaDon["GiaBan", e.RowIndex].Value = TongTien;
                dgvHoaDon["ThueGTGT", e.RowIndex].Value = Math.Round((double)TongTien * 5 / 100);
                dgvHoaDon["PhiBVMT", e.RowIndex].Value = TongTien * 10 / 100;
                dgvHoaDon["TongCong", e.RowIndex].Value = TongTien + Math.Round((double)TongTien * 5 / 100) + (TongTien * 10 / 100);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DinhMuc" && e.FormattedValue.ToString().Replace(".", "") != dgvHoaDon[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                string ChiTiet = "";
                int GiaBieu = 0;
                int TieuThu = 0;
                if (dgvHoaDon["GiaBieu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvHoaDon["GiaBieu", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvHoaDon["GiaBieu", e.RowIndex].Value.ToString());
                if (dgvHoaDon["TieuThu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvHoaDon["TieuThu", e.RowIndex].Value.ToString()))
                    TieuThu = int.Parse(dgvHoaDon["TieuThu", e.RowIndex].Value.ToString());
                int TongTien = _cKTKS_DonKH.TinhTienNuoc(false, 0, dgvHoaDon["DanhBo", e.RowIndex].Value.ToString(), GiaBieu, int.Parse(e.FormattedValue.ToString().Replace(".", "")),TieuThu, out ChiTiet);
                dgvHoaDon["GiaBan", e.RowIndex].Value = TongTien;
                dgvHoaDon["ThueGTGT", e.RowIndex].Value = Math.Round((double)TongTien * 5 / 100);
                dgvHoaDon["PhiBVMT", e.RowIndex].Value = TongTien * 10 / 100;
                dgvHoaDon["TongCong", e.RowIndex].Value = TongTien + Math.Round((double)TongTien * 5 / 100) + (TongTien * 10 / 100);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.FormattedValue.ToString().Replace(".", "") != dgvHoaDon[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                string ChiTiet = "";
                int GiaBieu = 0;
                int DinhMuc = 0;
                if (dgvHoaDon["GiaBieu", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvHoaDon["GiaBieu", e.RowIndex].Value.ToString()))
                    GiaBieu = int.Parse(dgvHoaDon["GiaBieu", e.RowIndex].Value.ToString());
                if (dgvHoaDon["DinhMuc", e.RowIndex].Value != null && !string.IsNullOrEmpty(dgvHoaDon["DinhMuc", e.RowIndex].Value.ToString()))
                    DinhMuc = int.Parse(dgvHoaDon["DinhMuc", e.RowIndex].Value.ToString());
                int TongTien = _cKTKS_DonKH.TinhTienNuoc(false, 0, dgvHoaDon["DanhBo", e.RowIndex].Value.ToString(), GiaBieu, DinhMuc, int.Parse(e.FormattedValue.ToString().Replace(".", "")), out ChiTiet);
                dgvHoaDon["GiaBan", e.RowIndex].Value = TongTien;
                dgvHoaDon["ThueGTGT", e.RowIndex].Value = Math.Round((double)TongTien * 5 / 100);
                dgvHoaDon["PhiBVMT", e.RowIndex].Value = TongTien * 10 / 100;
                dgvHoaDon["TongCong", e.RowIndex].Value = TongTien + Math.Round((double)TongTien * 5 / 100) + (TongTien * 10 / 100);
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
                    dgvTongHopNo.DataSource = _cTHN.GetDS(dateTu.Value,dateDen.Value);
                else
                    ///chọn 1 tổ cụ thể
                    if (cmbTo.SelectedIndex > 0)
                        dgvTongHopNo.DataSource = _cTHN.GetDS_To(int.Parse(cmbTo.SelectedValue.ToString()),dateTu.Value, dateDen.Value);
            }
            else
                dgvTongHopNo.DataSource = _cTHN.GetDS(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
        }

        private void dgvTongHopNo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTongHopNo.Columns[e.ColumnIndex].Name == "MaTHN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length-2,"-");
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
            foreach (TT_CTTongHopNo item in tonghopno.TT_CTTongHopNos)
            {
                DataRow dr = ds.Tables["TongHopNo"].NewRow();
                dr["KinhGui"] = tonghopno.KinhGui;
                dr["DanhBo"] = item.DanhBo.Insert(4, " ").Insert(8, " ");
                dr["DiaChi"] = item.DiaChi;
                dr["Ky"] = item.Ky;
                dr["TieuThu"] = item.TieuThu;
                dr["GiaBan"] = item.GiaBan.Value.ToString();
                dr["ThueGTGT"] = item.ThueGTGT.Value.ToString();
                dr["PhiBVMT"] = item.PhiBVMT.Value.ToString();
                dr["TongCong"] = item.TongCong.Value.ToString();
                TongCongSo += (int)item.TongCong.Value;
                dr["CSM"] = tonghopno.ChiSoMoi;
                dr["CSC"] = tonghopno.ChiSoCu;
                dr["TT"] = tonghopno.TieuThu;
                dr["DM"] = tonghopno.DinhMuc;
                dr["TuNgay"] = tonghopno.TuNgay;
                dr["DenNgay"] = tonghopno.DenNgay;

                ds.Tables["TongHopNo"].Rows.Add(dr);
            }
            DataRow dr1 = ds.Tables["TongHopNo"].NewRow();
            dr1["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
            dr1["NgayThanhToan"] = tonghopno.NgayThanhToan.Value.ToString("dd/MM/yyyy");
            if (radGiamDoc.Checked)
                dr1["NguoiKy"] = "GIÁM ĐỐC";
            else
                if (radPhoGiamDoc.Checked)
                    dr1["NguoiKy"] = "P.GIÁM ĐỐC";
            ds.Tables["TongHopNo"].Rows.Add(dr1);
            rptTongHopNo rpt = new rptTongHopNo();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }
        
    }
}
