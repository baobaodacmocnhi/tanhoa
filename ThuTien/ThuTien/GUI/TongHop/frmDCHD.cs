using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.BaoCao.TongHop;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.TongHop
{
    public partial class frmDCHD : Form
    {
        string _mnu = "mnuDCHD";
        CDCHD _cDCHD = new CDCHD();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmDCHD()
        {
            InitializeComponent();
        }

        private void frmDCHD_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvDCHD.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;

            DataTable dtNam = _cHoaDon.GetNam();
            //DataRow dr = dtNam.NewRow();
            //dr["ID"] = "Tất Cả";
            //dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void dgvHoaDon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvHoaDon.RowCount > 0 && e.Button == MouseButtons.Left)
            {
                frmShowDCHD frm = new frmShowDCHD(int.Parse(dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString()), dgvHoaDon.SelectedRows[0].Cells["SoHoaDon"].Value.ToString());
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _cDCHD.Refresh();
                    dgvHoaDon.DataSource = _cHoaDon.GetDSByDanhBo(txtDanhBo.Text.Trim());
                }
                else
                {
                    _cDCHD.Refresh();
                    dgvHoaDon.DataSource = _cHoaDon.GetDSByDanhBo(txtDanhBo.Text.Trim());
                }
            }
        }

        private void dgvDCHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvDCHD.RowCount > 0 && e.Button == MouseButtons.Left)
            {
                frmShowDCHD frm = new frmShowDCHD(int.Parse(dgvDCHD.SelectedRows[0].Cells["MaHD_DC"].Value.ToString()), dgvDCHD.SelectedRows[0].Cells["SoHoaDon_DC"].Value.ToString());
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _cDCHD.Refresh();
                    btnXem.PerformClick();
                }
                else
                {
                    _cDCHD.Refresh();
                    btnXem.PerformClick();
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (chkTrongKy.Checked)
                dgvDCHD.DataSource = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            else
                dgvDCHD.DataSource = _cDCHD.GetDSByNgayDC(dateTu.Value, dateDen.Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in dgvDCHD.SelectedRows)
                        if (_cHoaDon.CheckDangNganBySoHoaDon(item.Cells["SoHoaDon_DC"].Value.ToString()))
                        {
                            dgvDCHD.ClearSelection();
                            dgvDCHD.Rows[item.Index].Selected = true;
                            MessageBox.Show("Hóa đơn đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    try
                    {
                        _cDCHD.BeginTransaction();
                        foreach (DataGridViewRow item in dgvDCHD.SelectedRows)
                        {
                            DIEUCHINH_HD dchd = _cDCHD.GetByMaDC(int.Parse(item.Cells["MaDCHD"].Value.ToString()));
                            HOADON hd = _cHoaDon.Get(dchd.SoHoaDon);
                            if (hd.SoHoaDonCu != null)
                            {
                                hd.SOHOADON = hd.SoHoaDonCu;
                                hd.SoHoaDonCu = null;
                            }
                            hd.GIABAN = dchd.GIABAN_BD;
                            hd.THUE = dchd.THUE_BD;
                            hd.PHI = dchd.PHI_BD;
                            hd.TONGCONG = dchd.TONGCONG_BD;
                            if (_cHoaDon.Sua(hd))
                                _cDCHD.Xoa(dchd);
                        }
                        _cDCHD.CommitTransaction();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cDCHD.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInDSDangNgan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkTrongKy.Checked)
                dt = _cDCHD.GetDSDangNgan(dateTu.Value, dateDen.Value, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            else
                dt = _cDCHD.GetDSDangNgan(dateTu.Value, dateDen.Value);
            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DSDCHD"].NewRow();
                dr["LoaiBaoCao"] = "ĐĂNG NGÂN";
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                dr["Ky"] = item["Ky"];
                dr["SoHoaDon"] = item["SoHoaDon"];
                dr["GiaBan"] = item["GiaBan_End"];
                dr["ThueGTGT"] = item["ThueGTGT_End"];
                dr["PhiBVMT"] = item["PhiBVMT_End"];
                dr["TongCong"] = item["TongCong_End"];
                dr["TongCongTruoc"] = item["TongCong_Start"];
                dr["TongCongBD"] = item["TongCong_BD"];
                dr["TieuThuBD"] = item["TieuThu_BD"];
                dr["HanhThu"] = item["HanhThu"];
                dr["To"] = item["To"];
                ds.Tables["DSDCHD"].Rows.Add(dr);
            }

            rptDSDCHD rpt = new rptDSDCHD();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkTrongKy.Checked)
                dt = _cDCHD.GetDSTon(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            else
                dt = _cDCHD.GetDSTon();
            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DSDCHD"].NewRow();
                dr["LoaiBaoCao"] = "TỒN";
                //dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                //dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                dr["Ky"] = item["Ky"];
                dr["SoHoaDon"] = item["SoHoaDon"];
                dr["GiaBan"] = item["GiaBan_End"];
                dr["ThueGTGT"] = item["ThueGTGT_End"];
                dr["PhiBVMT"] = item["PhiBVMT_End"];
                dr["TongCong"] = item["TongCong_End"];
                dr["TongCongTruoc"] = item["TongCong_Start"];
                dr["TongCongBD"] = item["TongCong_BD"];
                dr["TieuThuBD"] = item["TieuThu_BD"];
                dr["HanhThu"] = item["HanhThu"];
                dr["To"] = item["To"];
                ds.Tables["DSDCHD"].Rows.Add(dr);
            }
            rptDSDCHD rpt = new rptDSDCHD();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
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

        private void dgvDCHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "DanhBo_DC" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "GiaBan_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "ThueGTGT_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "PhiBVMT_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_End" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_BD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "TongCong_Start" && e.Value != null)
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

        private void dgvDCHD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDCHD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDCHD_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvDCHD.Columns[e.ColumnIndex].Name == "ChuanThu1" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvDCHD[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    DIEUCHINH_HD dchd = _cDCHD.Get(int.Parse(dgvDCHD["MaHD_DC", e.RowIndex].Value.ToString()));
                    dchd.ChuanThu1 = bool.Parse(e.FormattedValue.ToString());
                    _cDCHD.Sua(dchd);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTrongKy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrongKy.Checked)
                panel1.Enabled = true;
            else
                panel1.Enabled = false;
        }

    }
}
