using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeToan.DAL.QuanTri;
using KeToan.DAL;
using KeToan.DAL.HoaDonDienTu;
using KeToan.BaoCao;
using KeToan.BaoCao.HoaDonDienTu;
using KeToan.GUI.BaoCao;
using System.Globalization;

namespace KeToan.GUI.HoaDonDienTu
{
    public partial class frmBienLaiThuTien : Form
    {
        string _mnu = "mnuBienLaiThuTien";
        CHoaDonDienTu _cHDDT = new CHoaDonDienTu();
        public frmBienLaiThuTien()
        {
            InitializeComponent();
        }

        private void frmBienLaiThuTien_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cHDDT.ExcelToDataTable(dialog.FileName);
                            //CExcel fileExcel = new CExcel(dialog.FileName);
                            //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                            foreach (DataRow item in dtExcel.Rows)
                                if (item[1].ToString().Trim() != "" && item[4].ToString().Trim() != "")
                                    if (chkNgayLap.Checked == true)
                                    {
                                        if (_cHDDT.checkExist(item[1].ToString().Trim(), item[4].ToString().Trim(), dateNgayLap.Value) == false)
                                        {
                                            LinQ.HoaDonDienTu en = new LinQ.HoaDonDienTu();
                                            en.HoTen = item[1].ToString().Trim();
                                            en.DanhBo = item[18 + 3].ToString().Trim().Replace(" ", "").Replace(".", "");
                                            en.DiaChi = item[4].ToString().Trim();
                                            en.NoiDung = item[10].ToString().Trim();
                                            en.SoTien = int.Parse(item[17].ToString().Trim());
                                            if (item[19 + 3].ToString().Trim() != "")
                                                en.SoHoaDon = int.Parse(item[19 + 3].ToString().Trim());
                                            en.MaTaiHoaDon = item[20 + 3].ToString().Trim();
                                            _cHDDT.Them(en, dateNgayLap.Value);
                                        }
                                        else
                                        {
                                            LinQ.HoaDonDienTu en = _cHDDT.get(item[1].ToString().Trim(), item[4].ToString().Trim(), dateNgayLap.Value);
                                            en.NoiDung += ", " + item[10].ToString().Trim();
                                            en.SoTien += int.Parse(item[17].ToString().Trim());
                                            _cHDDT.Sua(en);
                                        }
                                    }
                                    else
                                    {
                                        if (_cHDDT.checkExist(item[1].ToString().Trim(), item[4].ToString().Trim(), DateTime.Now) == false)
                                        {
                                            LinQ.HoaDonDienTu en = new LinQ.HoaDonDienTu();
                                            en.HoTen = item[1].ToString().Trim();
                                            en.DanhBo = item[18 + 3].ToString().Trim().Replace(" ", "").Replace(".", "");
                                            en.DiaChi = item[4].ToString().Trim();
                                            en.NoiDung = item[10].ToString().Trim();
                                            en.SoTien = int.Parse(item[17].ToString().Trim());
                                            if (item[19 + 3].ToString().Trim() != "")
                                                en.SoHoaDon = int.Parse(item[19 + 3].ToString().Trim());
                                            en.MaTaiHoaDon = item[20 + 3].ToString().Trim();
                                            _cHDDT.Them(en);
                                        }
                                        else
                                        {
                                            LinQ.HoaDonDienTu en = _cHDDT.get(item[1].ToString().Trim(), item[4].ToString().Trim(), DateTime.Now);
                                            en.NoiDung += ". " + item[10].ToString().Trim();
                                            en.SoTien += int.Parse(item[17].ToString().Trim());
                                            _cHDDT.Sua(en);
                                        }
                                    }

                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cHDDT.getDS(dateTu.Value, dateDen.Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                        {
                            LinQ.HoaDonDienTu en = _cHDDT.get(int.Parse(item.Cells["ID"].Value.ToString()));
                            _cHDDT.Xoa(en);
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXem.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
                if (item.Cells["In"].Value != null && bool.Parse(item.Cells["In"].Value.ToString()) == true)
                {
                    DataRow dr = ds.Tables["HoaDonDienTu"].NewRow();
                    string str = String.Format("{0:D6}", int.Parse(item.Cells["ID"].Value.ToString()));
                    dr["ID"] = str.Insert(str.Length - 2, "-");
                    dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                    if (item.Cells["DanhBo"].Value != null && item.Cells["DanhBo"].Value.ToString().Length == 11)
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                    dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                    dr["NoiDung"] = item.Cells["NoiDung"].Value.ToString();
                    dr["SoTien"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(item.Cells["SoTien"].Value.ToString()));
                    dr["SoTienChu"] = _cHDDT.ConvertMoneyToWord(item.Cells["SoTien"].Value.ToString());
                    if (item.Cells["SoHoaDon"].Value.ToString() != "")
                    {
                        str = String.Format("{0:D7}", int.Parse(item.Cells["SoHoaDon"].Value.ToString()));
                        dr["SoHoaDon"] = str;
                    }
                    dr["MaTaiHoaDon"] = item.Cells["MaTaiHoaDon"].Value.ToString();
                    DateTime dateNgayLap = DateTime.Parse(item.Cells["CreateDate"].Value.ToString());
                    dr["NgayLap"] = "Ngày " + String.Format("{0:D2}", dateNgayLap.Day) + " tháng " + String.Format("{0:D2}", dateNgayLap.Month) + " năm " + dateNgayLap.Year;
                    dr["NguoiKy"] = CUser.Name;
                    dr["Nam"] = DateTime.Now.ToString("yy");
                    ds.Tables["HoaDonDienTu"].Rows.Add(dr);
                }
            rptBienLaiThuTienA5 rpt = new rptBienLaiThuTienA5();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ID" && e.Value != null)
            {
                string str = String.Format("{0:D6}", int.Parse(e.Value.ToString()));
                e.Value = str.ToString().Insert(str.ToString().Length - 2, "-");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString() != "" && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "SoHoaDon" && e.Value != null)
            {
                if (e.Value.ToString() != "")
                {
                    string str = String.Format("{0:D7}", int.Parse(e.Value.ToString()));
                    e.Value = str.ToString();
                }
            }
        }

        private void dgvHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.Rows.Count > 0 && dgvHoaDon.Columns[e.ColumnIndex].Name != "In")
            {
                if (CUser.CheckQuyen(_mnu, "Sua"))
                {
                    try
                    {
                        LinQ.HoaDonDienTu en = _cHDDT.get(int.Parse(dgvHoaDon["ID", e.RowIndex].Value.ToString()));
                        en.DanhBo = dgvHoaDon["DanhBo", e.RowIndex].Value.ToString();
                        en.HoTen = dgvHoaDon["HoTen", e.RowIndex].Value.ToString();
                        en.DiaChi = dgvHoaDon["DiaChi", e.RowIndex].Value.ToString();
                        en.NoiDung = dgvHoaDon["NoiDung", e.RowIndex].Value.ToString();
                        en.SoTien = int.Parse(dgvHoaDon["SoTien", e.RowIndex].Value.ToString().Replace(".", ""));
                        if (dgvHoaDon["SoHoaDon", e.RowIndex].Value != null && dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString() != "")
                            en.SoHoaDon = int.Parse(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
                        if (dgvHoaDon["MaTaiHoaDon", e.RowIndex].Value != null && dgvHoaDon["MaTaiHoaDon", e.RowIndex].Value.ToString() != "")
                            en.MaTaiHoaDon = dgvHoaDon["MaTaiHoaDon", e.RowIndex].Value.ToString();
                        if (_cHDDT.Sua(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNgayLap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayLap.Checked == true)
                dateNgayLap.Enabled = true;
            else
                dateNgayLap.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "")
            {
                dgvHoaDon.DataSource = _cHDDT.getDS(txtNoiDungTimKiem.Text.Trim());
            }
        }


    }
}
