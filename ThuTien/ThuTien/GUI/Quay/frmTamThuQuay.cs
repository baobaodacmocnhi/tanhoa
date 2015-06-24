﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao;
using ThuTien.BaoCao.Quay;
using KTKS_DonKH.GUI.BaoCao;

namespace ThuTien.GUI.Quay
{
    public partial class frmTamThuQuay : Form
    {
        string _mnu = "mnuTamThuQuay";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CXacNhanNo _cXacNhanNo = new CXacNhanNo();

        public frmTamThuQuay()
        {
            InitializeComponent();
        }

        private void frmTamThu_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTamThu.AutoGenerateColumns = false;
            dgvXacNhanNo.AutoGenerateColumns = false;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            dgvHoaDon.DataSource = null;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    if (item.Cells["Chon"].Value!=null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                    {
                        if (_cTamThu.CheckBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString()))
                        {
                            MessageBox.Show("Hóa Đơn này đã có Tạm Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item.Selected = true;
                            return;
                        }

                        if (_cDCHD.CheckBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString()))
                        {
                            MessageBox.Show("Hóa Đơn này đã Rút đi Điều Chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item.Selected = true;
                            return;
                        }
                    }
                List<TAMTHU> lstTamThu = new List<TAMTHU>();
                try
                {
                    _cTamThu.BeginTransaction();
                    decimal SoPhieu = _cTamThu.GetMaxSoPhieu();
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                        if (item.Cells["Chon"].Value!=null&&bool.Parse(item.Cells["Chon"].Value.ToString()))
                        {
                            TAMTHU tamthu = new TAMTHU();
                            tamthu.DANHBA = item.Cells["DanhBo"].Value.ToString();
                            tamthu.FK_HOADON = int.Parse(item.Cells["MaHD"].Value.ToString());
                            tamthu.SoHoaDon = item.Cells["SoHoaDon"].Value.ToString();
                            tamthu.SoPhieu = SoPhieu;

                            if (_cTamThu.Them(tamthu))
                            {
                                lstTamThu.Add(tamthu);
                            }
                            else
                            {
                                _cTamThu.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    _cTamThu.CommitTransaction();
                }
                catch (Exception)
                {
                    _cTamThu.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Ky = "";
                Int32 TongCongSo = 0;
                foreach (var item in lstTamThu)
                {
                    Ky += item.HOADON.KY + "/" + item.HOADON.NAM + ", ";
                    TongCongSo += (Int32)item.HOADON.TONGCONG;
                }

                dsBaoCao ds = new dsBaoCao();
                DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
                dr["SoPhieu"] = lstTamThu[0].SoPhieu.ToString().Insert(lstTamThu[0].SoPhieu.ToString().Length - 2, "-");
                dr["DanhBo"] = lstTamThu[0].DANHBA;
                dr["HoTen"] = lstTamThu[0].HOADON.TENKH;
                dr["DiaChi"] = lstTamThu[0].HOADON.SO + " " + lstTamThu[0].HOADON.DUONG;
                dr["MLT"] = lstTamThu[0].HOADON.MALOTRINH;
                dr["GiaBieu"] = lstTamThu[0].HOADON.GB;
                dr["DinhMuc"] = lstTamThu[0].HOADON.DM;
                dr["Ky"] = Ky;
                dr["TongCongSo"] = TongCongSo;
                dr["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
                if (lstTamThu[0].HOADON.MaNV_HanhThu != null)
                    dr["NhanVienThuTien"] = _cNguoiDung.GetHoTenByMaND(lstTamThu[0].HOADON.MaNV_HanhThu.Value);
                dr["NhanVienQuay"] = CNguoiDung.HoTen;
                ds.Tables["PhieuTamThu"].Rows.Add(dr);

                rptPhieuTamThu rpt = new rptPhieuTamThu();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabThongTin")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
            }
            else
                if (tabControl.SelectedTab.Name == "tabTamThu")
                {
                    btnThem.Enabled = false;
                    btnXoa.Enabled = true;
                }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                dgvTamThu.DataSource = _cTamThu.GetDSByDates(false, CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _cTamThu.BeginTransaction();
                    foreach (DataGridViewRow item in dgvTamThu.SelectedRows)
                    {
                        TAMTHU tamthu = _cTamThu.GetByMaTT(int.Parse(item.Cells["MaTT"].Value.ToString()));
                        if (!_cHoaDon.CheckDangNganBySoHoaDon(tamthu.SoHoaDon))
                        {
                            if (!_cTamThu.Xoa(tamthu))
                            {
                                _cTamThu.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            _cTamThu.Rollback();
                            dgvTamThu.ClearSelection();
                            item.Selected = true;
                            MessageBox.Show("Hóa đơn đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    _cTamThu.CommitTransaction();
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
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

        private void dgvTamThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "DanhBo_TT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TieuThu_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "GiaBan_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "ThueGTGT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "PhiBVMT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TongCong_TT" && e.Value != null)
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

        private void dgvTamThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTamThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXacNhanNo_Click(object sender, EventArgs e)
        {
            string Ky = "Hết nợ";
            Int32 TongCongSo = 0;
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                if (Ky == "Hết nợ")
                    Ky = "Còn nợ Kỳ "+item.Cells["Ky"].Value.ToString();
                else
                    Ky += ", " + item.Cells["Ky"].Value.ToString();
                TongCongSo += Int32.Parse(item.Cells["TongCong"].Value.ToString());
            }

            if (_cXacNhanNo.CheckExistByDanhBoKy(dgvHoaDon["DanhBo", 0].Value.ToString(), Ky))
            {
                MessageBox.Show("Danh Bộ này đã có Xác Nhận Nợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TT_XacNhanNo xacnhanno = new TT_XacNhanNo();
            xacnhanno.DanhBo = dgvHoaDon["DanhBo", 0].Value.ToString();
            xacnhanno.HoTen = dgvHoaDon["HoTen", 0].Value.ToString();
            xacnhanno.DiaChi = dgvHoaDon["DiaChi", 0].Value.ToString();
            xacnhanno.MLT = dgvHoaDon["MLT", 0].Value.ToString();
            xacnhanno.GiaBieu = int.Parse(dgvHoaDon["GiaBieu", 0].Value.ToString());
            xacnhanno.DinhMuc = int.Parse(dgvHoaDon["DinhMuc", 0].Value.ToString());
            xacnhanno.Ky = Ky;
            xacnhanno.TongCong = TongCongSo;
            xacnhanno.CreateBy = CNguoiDung.MaND;

            if (_cXacNhanNo.Them(xacnhanno))
            {
                dsBaoCao ds = new dsBaoCao();
                DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
                dr["SoPhieu"] = xacnhanno.SoPhieu.ToString().Insert(xacnhanno.SoPhieu.ToString().Length - 2, "-");
                dr["DanhBo"] = dgvHoaDon["DanhBo", 0].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = dgvHoaDon["HoTen", 0].Value.ToString();
                dr["DiaChi"] = dgvHoaDon["DiaChi", 0].Value.ToString();
                dr["MLT"] = dgvHoaDon["MLT", 0].Value.ToString();
                dr["GiaBieu"] = dgvHoaDon["GiaBieu", 0].Value.ToString();
                dr["DinhMuc"] = dgvHoaDon["DinhMuc", 0].Value.ToString();
                dr["Ky"] = Ky;
                dr["TongCongSo"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##} đồng", TongCongSo);
                //dr["NhanVienQuay"] = CNguoiDung.HoTen;
                ds.Tables["PhieuTamThu"].Rows.Add(dr);

                rptXacNhanNo rpt = new rptXacNhanNo();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();  
            }
            dgvHoaDon.Rows.Clear();
        }

        private void btnInTamThu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvTamThu.SelectedRows)
                {
                    string Ky = "";
                    Int32 TongCongSo = 0;
                    List<TAMTHU> lstTamThu = _cTamThu.GetDSBySoPhieu(decimal.Parse(item.Cells["SoPhieu_TT"].Value.ToString()));
                    foreach (var itemTT in lstTamThu)
                    {
                        Ky += itemTT.HOADON.KY + "/" + itemTT.HOADON.NAM + ", ";
                        TongCongSo += (Int32)itemTT.HOADON.TONGCONG;
                    }

                    dsBaoCao ds = new dsBaoCao();
                    DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
                    dr["SoPhieu"] = lstTamThu[0].SoPhieu.ToString().Insert(lstTamThu[0].SoPhieu.ToString().Length - 2, "-");
                    dr["DanhBo"] = lstTamThu[0].DANHBA.Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = lstTamThu[0].HOADON.TENKH;
                    dr["DiaChi"] = lstTamThu[0].HOADON.SO + " " + lstTamThu[0].HOADON.DUONG;
                    dr["MLT"] = lstTamThu[0].HOADON.MALOTRINH;
                    dr["GiaBieu"] = lstTamThu[0].HOADON.GB;
                    dr["DinhMuc"] = lstTamThu[0].HOADON.DM;
                    dr["Ky"] = Ky;
                    dr["TongCongSo"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongSo);
                    dr["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
                    if (lstTamThu[0].HOADON.MaNV_HanhThu != null)
                        dr["NhanVienThuTien"] = _cNguoiDung.GetHoTenByMaND(lstTamThu[0].HOADON.MaNV_HanhThu.Value);
                    dr["NhanVienQuay"] = CNguoiDung.HoTen;
                    ds.Tables["PhieuTamThu"].Rows.Add(dr);

                    rptPhieuTamThu rpt = new rptPhieuTamThu();
                    rpt.SetDataSource(ds);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
        }

        private void btnXem_XacNhanNo_Click(object sender, EventArgs e)
        {
            if (dateTu_XacNhanNo.Value <= dateDen_XacNhanNo.Value)
            {
                dgvXacNhanNo.DataSource = _cXacNhanNo.GetDSByDates(CNguoiDung.MaND, dateTu_XacNhanNo.Value, dateDen_XacNhanNo.Value);
            }
        }

        private void btnIn_XacNhanNo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvXacNhanNo.SelectedRows)
            {
                dsBaoCao ds = new dsBaoCao();
                DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
                dr["SoPhieu"] = item.Cells["SoPhieu_XacNhanNo"].Value.ToString().Insert(item.Cells["SoPhieu_XacNhanNo"].Value.ToString().Length - 2, "-");
                dr["DanhBo"] = item.Cells["DanhBo_XacNhanNo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = item.Cells["HoTen_XacNhanNo"].Value.ToString();
                dr["DiaChi"] = item.Cells["DiaChi_XacNhanNo"].Value.ToString();
                dr["MLT"] = item.Cells["MLT_XacNhanNo"].Value.ToString();
                dr["GiaBieu"] = item.Cells["GiaBieu_XacNhanNo"].Value.ToString();
                dr["DinhMuc"] = item.Cells["DinhMuc_XacNhanNo"].Value.ToString();
                dr["Ky"] = item.Cells["Ky_XacNhanNo"].Value.ToString();
                dr["TongCongSo"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##} đồng", (int)item.Cells["TongCong_XacNhanNo"].Value);
                //dr["NhanVienQuay"] = CNguoiDung.HoTen;
                ds.Tables["PhieuTamThu"].Rows.Add(dr);

                rptXacNhanNo rpt = new rptXacNhanNo();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();  
            }
            
        }

        private void dgvXacNhanNo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvXacNhanNo.Columns[e.ColumnIndex].Name == "SoPhieu_XacNhanNo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length-2, "-");
            }
            if (dgvXacNhanNo.Columns[e.ColumnIndex].Name == "DanhBo_XacNhanNo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvXacNhanNo.Columns[e.ColumnIndex].Name == "TongCong_XacNhanNo" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvXacNhanNo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvXacNhanNo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }


    }
}
