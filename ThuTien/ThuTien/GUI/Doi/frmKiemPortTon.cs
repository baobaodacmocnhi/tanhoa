﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ThuTien.LinQ;
using ThuTien.DAL;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using System.Runtime.InteropServices;
using System.Globalization;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.Doi
{
    public partial class frmKiemPortTon : Form
    {
        dbThuTienDataContext _db = new dbThuTienDataContext();
        CDAL _cDAL = new CDAL();

        public frmKiemPortTon()
        {
            InitializeComponent();
        }

        private void frmKiemPortTon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
        }

        public void LoadDSHoaDon()
        {
            var query = from item in _db.TT_PortTons
                        join itemHD in _db.HOADONs on item.SoHoaDon equals itemHD.SOHOADON into tableHD
                        from itemtableHD in tableHD.DefaultIfEmpty()
                        join itemND in _db.TT_NguoiDungs on itemtableHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.CreateDate.Value.Month == dateNgayLap2.Value.Month && item.CreateDate.Value.Year == dateNgayLap2.Value.Year
                        select new
                        {
                            item.MaHD,
                            item.Loai,
                            item.SoHoaDon,
                            Ky = item.Ky + "/" + item.Nam,
                            item.MLT,
                            item.DanhBo,
                            item.HoTen,
                            item.SoNha,
                            item.Duong,
                            item.TieuThu,
                            TongCong = item.GiaBan + item.ThueGTGT + item.PhiBVMT,
                            item.SoPhatHanh,
                            item.Xoa,
                            HanhThu=itemtableND.HoTen,
                        };

            dgvHoaDon.DataSource = _cDAL.LINQToDataTable(query);

            dgvHoaDon2.DataSource = _cDAL.LINQToDataTable(_db.TT_PortTon_SaiBiets.ToList());
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 13)
                    {
                        if (lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            lstHD.Items.Add(item.Trim().ToUpper());
                            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                        }
                    }
                    else
                        ///Trung An thêm 'K' phía cuối liên hóa đơn
                        if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 14)
                        {
                            if (lstHD.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                            {
                                lstHD.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                                lstHD.EnsureVisible(lstHD.Items.Count - 1);
                            }
                        }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
                txtSoHoaDon.Text = "";
            }
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0 && e.Button == MouseButtons.Left)
            {
                foreach (ListViewItem item in lstHD.SelectedItems)
                {
                    lstHD.Items.Remove(item);
                }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
            }
        }

        private void lstHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = lstHD.Items.Count.ToString();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            int k = -1;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
                    _excelApp.Visible = false;

                    //open the workbook
                    Workbook workbook = _excelApp.Workbooks.Open(dialog.FileName,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);

                    //select the first sheet        
                    Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

                    //find the used range in worksheet
                    Range excelRange = worksheet.UsedRange;

                    //get an object array of all of the cells in the worksheet (their values)
                    object[,] valueArray = (object[,])excelRange.get_Value(
                                XlRangeValueDataType.xlRangeValueDefault);

                    //access the cells
                    for (int row = 2; row <= worksheet.UsedRange.Rows.Count; ++row)
                    {
                        k++;
                        //for (int col = 1; col <= worksheet.UsedRange.Columns.Count; ++col)
                        //{
                        //access each cell
                        //if (!_db.TT_TestHoaDonTons.Any(itemHD => itemHD.SoHoaDon == valueArray[row, 14].ToString()))
                        //{
                            TT_PortTon hoadon = new TT_PortTon();
                            hoadon.MaHD = _db.TT_PortTons.Max(item => item.MaHD) + 1;
                            hoadon.DanhBo = valueArray[row, 4].ToString();
                            hoadon.Nam = int.Parse(valueArray[row, 5].ToString());
                            hoadon.Ky = int.Parse(valueArray[row, 6].ToString());
                            hoadon.Loai = valueArray[row, 7].ToString();
                            hoadon.SoPhatHanh = valueArray[row, 8].ToString();
                            hoadon.TieuThu = int.Parse(valueArray[row, 9].ToString());
                            hoadon.GiaBan = int.Parse(valueArray[row, 10].ToString());
                            hoadon.ThueGTGT = int.Parse(valueArray[row, 11].ToString());
                            hoadon.PhiBVMT = int.Parse(valueArray[row, 12].ToString());
                            hoadon.MLT = valueArray[row, 13].ToString();
                            hoadon.SoHoaDon = valueArray[row, 14].ToString();
                            hoadon.HoTen = valueArray[row, 15].ToString();
                            if (valueArray[row, 16] != null)
                                hoadon.SoNha = valueArray[row, 16].ToString();
                            hoadon.Duong = valueArray[row, 17].ToString();
                            hoadon.CreateBy = CNguoiDung.MaND;
                            hoadon.CreateDate = dateNgayLap.Value;

                            _db.TT_PortTons.InsertOnSubmit(hoadon);
                            _db.SubmitChanges();
                        //}
                        //}
                    }

                    //clean up stuffs
                    workbook.Close(false, Type.Missing, Type.Missing);
                    Marshal.ReleaseComObject(workbook);

                    _excelApp.Quit();
                    Marshal.FinalReleaseComObject(_excelApp);

                    LoadDSHoaDon();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                MessageBox.Show("Lỗi, Vui lòng thử lại \r\n Dòng: " + k.ToString()+" --- " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDSHoaDon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {   
            try
            {
                foreach (ListViewItem item in lstHD.Items)
                    if (_db.TT_PortTons.Any(itemHD => itemHD.SoHoaDon == item.Text && itemHD.Xoa == false))
                    {
                        TT_PortTon hoadon = _db.TT_PortTons.Where(itemHD => itemHD.SoHoaDon == item.Text && itemHD.Xoa == false).OrderByDescending(itemHD => itemHD.MaHD).First();
                        //_db.TT_TestHoaDonTons.DeleteOnSubmit(hoadon);
                        hoadon.Xoa = true;
                        hoadon.ModifyBy = CNguoiDung.MaND;
                        hoadon.ModifyDate = DateTime.Now;
                        _db.SubmitChanges();
                    }
                    else
                    {
                        TT_PortTon_SaiBiet hoadon = new TT_PortTon_SaiBiet();
                        if (_db.TT_PortTon_SaiBiets.Count() > 0)
                            hoadon.ID = _db.TT_PortTon_SaiBiets.Max(itemHD => itemHD.ID) + 1;
                        else
                            hoadon.ID = 1;
                        hoadon.SoHoaDon = item.Text;
                        hoadon.CreateBy = CNguoiDung.MaND;
                        hoadon.CreateDate = DateTime.Now;
                        _db.TT_PortTon_SaiBiets.InsertOnSubmit(hoadon);
                        _db.SubmitChanges();
                    }
                lstHD.Items.Clear();
                LoadDSHoaDon();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thực hiện lại \r\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                    if (_db.TT_PortTons.Any(itemHD => itemHD.SoHoaDon == item.Cells["SoHoaDon"].Value.ToString()))
                    {
                        //TT_TestHoaDonTon hoadon = _db.TT_TestHoaDonTons.SingleOrDefault(itemHD => itemHD.SoHoaDon == item.Cells["SoHoaDon"].Value.ToString());
                        //_db.TT_TestHoaDonTons.DeleteOnSubmit(hoadon);
                        //_db.SubmitChanges();
                        _db.ExecuteCommand("delete TT_PortTon where MaHD=" + item.Cells["MaHD"].Value.ToString());
                    }
                lstHD.Items.Clear();
                LoadDSHoaDon();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thực hiện lại \r\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
                if (!bool.Parse(item.Cells["Xoa"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "TỒN";
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item.Cells["Ky"].Value;
                    dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item.Cells["TongCong"].Value;
                    dr["SoPhatHanh"] = item.Cells["SoPhatHanh"].Value;
                    dr["SoHoaDon"] = item.Cells["SoHoaDon"].Value;
                    dr["HanhThu"] = item.Cells["HanhThu"].Value;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
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

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInDSDaXoa_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
                if (bool.Parse(item.Cells["Xoa"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "ĐÃ XÓA";
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item.Cells["Ky"].Value;
                    dr["MLT"] = item.Cells["MLT"].Value;
                    dr["TongCong"] = item.Cells["TongCong"].Value;
                    dr["SoPhatHanh"] = item.Cells["SoPhatHanh"].Value;
                    dr["SoHoaDon"] = item.Cells["SoHoaDon"].Value;
                    dr["HanhThu"] = item.Cells["HanhThu"].Value;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstHD.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

    }
}
