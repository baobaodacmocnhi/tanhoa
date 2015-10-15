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
using ThuTien.BaoCao;
using ThuTien.BaoCao.Quay;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.Quay
{
    public partial class frmLenhHuy : Form
    {
        string _mnu = "mnuLenhHuy";
        CHoaDon _cHoaDon = new CHoaDon();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmLenhHuy()
        {
            InitializeComponent();
        }

        private void frmLenhHuy_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            dateLap.Value = DateTime.Now;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 13 && lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                    {
                        lstHD.Items.Add(item.Trim().ToUpper());
                        lstHD.EnsureVisible(lstHD.Items.Count - 1);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (ListViewItem item in lstHD.Items)
                {
                    if (!_cHoaDon.CheckBySoHoaDon(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn sai: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                    if (_cHoaDon.CheckDangNganBySoHoaDon(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                    if (_cLenhHuy.CheckExist(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn đã có trong Lệnh Hủy: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                }
                try
                {
                    _cLenhHuy.BeginTransaction();
                    foreach (ListViewItem item in lstHD.Items)
                    {
                        TT_LenhHuy lenhhuy = new TT_LenhHuy();
                        lenhhuy.SoHoaDon = item.Text;
                        if (!_cLenhHuy.Them(lenhhuy))
                        {
                            _cLenhHuy.Rollback();
                            MessageBox.Show("Lỗi, Vui lòng thử lại \r\n" + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    _cLenhHuy.CommitTransaction();
                    lstHD.Items.Clear();
                    dgvHoaDon.DataSource = _cLenhHuy.GetDSByCreatedDate(dateLap.Value);
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cLenhHuy.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _cLenhHuy.BeginTransaction();
                        foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                        {
                            TT_LenhHuy lenhhuy = _cLenhHuy.GetBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString());
                            if (!_cLenhHuy.Xoa(lenhhuy))
                            {
                                _cLenhHuy.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        _cLenhHuy.CommitTransaction();
                        lstHD.Items.Clear();
                        dgvHoaDon.DataSource = _cLenhHuy.GetDSByCreatedDate(dateLap.Value);
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cLenhHuy.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cLenhHuy.GetDS();
        }

        private void dgvHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
                if (string.IsNullOrEmpty(item.Cells["NgayGiaiTrach"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["DiaChi"] = item.Cells["DiaChi"].Value;
                    dr["Ky"] = item.Cells["Ky"].Value;
                    dr["MLT"] = item.Cells["MLT"].Value;
                    dr["TongCong"] = item.Cells["TongCong"].Value;
                    dr["TinhTrang"] = item.Cells["TinhTrang"].Value;
                    //dr["SoHoaDon"] = item.Cells["SoHoaDon"].Value;
                    dr["NhanVien"] = item.Cells["HanhThu"].Value.ToString();
                    dr["To"] = item.Cells["To"].Value.ToString();
                    if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSLenhHuy rpt = new rptDSLenhHuy();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TinhTrang")
            {
                TT_LenhHuy lenhhuy = _cLenhHuy.GetBySoHoaDon(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
                lenhhuy.TinhTrang = dgvHoaDon["TinhTrang", e.RowIndex].Value.ToString();
                _cLenhHuy.Sua(lenhhuy);
            }
        }

        private void btnInDSKhongTrung_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvHoaDon.DataSource;
            dsBaoCao ds = new dsBaoCao();
            ds.Tables["TamThuChuyenKhoan"].PrimaryKey = new DataColumn[] { ds.Tables["TamThuChuyenKhoan"].Columns["DanhBo"] };
            foreach (DataRow item in dt.Rows)
                if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString())&&!ds.Tables["TamThuChuyenKhoan"].Rows.Contains(item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ")))
                {
                    DataRow[] drDGV = dt.Select("DanhBo=" + item["DanhBo"]);
                    string Ky="";
                    int TongCong = 0 ;
                    foreach (DataRow itemRow in drDGV)
                    {
                        Ky += itemRow["Ky"].ToString().Trim()+", ";
                        TongCong += int.Parse(itemRow["TongCong"].ToString());
                    }
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["DanhBo"] = drDGV[drDGV.Count() - 1]["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["DiaChi"] = drDGV[drDGV.Count() - 1]["DiaChi"];
                    dr["Ky"] = Ky;
                    dr["MLT"] = drDGV[drDGV.Count() - 1]["MLT"];
                    dr["TongCong"] = TongCong;
                    dr["TinhTrang"] = drDGV[drDGV.Count() - 1]["TinhTrang"];
                    //dr["SoHoaDon"] = item.Cells["SoHoaDon"].Value;
                    dr["NhanVien"] = drDGV[drDGV.Count() - 1]["HanhThu"];
                    dr["To"] = drDGV[drDGV.Count() - 1]["To"];
                    if (int.Parse(drDGV[drDGV.Count() - 1]["GiaBieu"].ToString()) > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSLenhHuy rpt = new rptDSLenhHuy();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
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
