using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.BaoCao;
using ThuTien.BaoCao.TongHop;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.TongHop
{
    public partial class frmThu2Lan : Form
    {
        string _mnu = "mnuThu2Lan";
        CHoaDon _cHoaDon = new CHoaDon();

        public frmThu2Lan()
        {
            InitializeComponent();
        }

        private void frmThu2Lan_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            DataTable dtNam = _cHoaDon.GetNam();
            DataRow dr = dtNam.NewRow();
            dr["ID"] = "Tất Cả";
            dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnXem.PerformClick();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                bool ChuyenKhoan = true;
                if (radDaTra.Checked)
                    ChuyenKhoan = true;
                if (radChuaTra.Checked)
                    ChuyenKhoan = false;

                if (_cHoaDon.Thu2Lan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()),txtDanhBo.Text.Trim(), ChuyenKhoan))
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        _cHoaDon.BeginTransaction();
                        foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                        {
                            HOADON hoadon = _cHoaDon.Get(int.Parse(item.Cells["MaHD"].Value.ToString()));
                            hoadon.Thu2Lan = false;
                        }
                        _cHoaDon.SubmitChanges();
                        _cHoaDon.CommitTransaction();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cHoaDon.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radDaTra.Checked)
            {
                if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                {
                    dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(txtDanhBo.Text.Trim().Replace(" ", ""), false, true);
                }
                else
                    if (cmbNam.SelectedIndex == 0)
                    {
                        dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(false, true);
                    }
                    else
                        if (cmbNam.SelectedIndex > 0)
                            if (cmbKy.SelectedIndex == 0)
                            {
                                dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(int.Parse(cmbNam.SelectedValue.ToString()), false, true);
                            }
                            else
                                if (cmbKy.SelectedIndex > 0)
                                    if (cmbDot.SelectedIndex == 0)
                                    {
                                        dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), false, true);
                                    }
                                    else
                                        if (cmbDot.SelectedIndex > 0)
                                            dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), false, true);
            }
            else
                if (radChuaTra.Checked)
                {
                    if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                    {
                        dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(txtDanhBo.Text.Trim().Replace(" ", ""), false, false);
                    }
                    else
                        if (cmbNam.SelectedIndex == 0)
                        {
                            dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(false, false);
                        }
                        else
                            if (cmbNam.SelectedIndex > 0)
                                if (cmbKy.SelectedIndex == 0)
                                {
                                    dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(int.Parse(cmbNam.SelectedValue.ToString()), false, false);
                                }
                                else
                                    if (cmbKy.SelectedIndex > 0)
                                        if (cmbDot.SelectedIndex == 0)
                                        {
                                            dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), false, false);
                                        }
                                        else
                                            if (cmbDot.SelectedIndex > 0)
                                                dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), false, false);
                }
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

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (dgvHoaDon.Columns[e.ColumnIndex].Name == "Tra")
                {
                    if (bool.Parse(dgvHoaDon["Tra", e.RowIndex].Value.ToString()))
                    {
                        _cHoaDon.Thu2Lan_Tra(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
                    }
                    else
                    {
                        _cHoaDon.Thu2Lan_XoaTra(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
                    }
                }

                if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GhiChu")
                {
                    _cHoaDon.Thu2Lan_GhiChu(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString(), dgvHoaDon["GhiChu", e.RowIndex].Value.ToString());
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (radDaTra.Checked)
            {
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    if (bool.Parse(item.Cells["ChuyenKhoan"].Value.ToString()) && !bool.Parse(item.Cells["Tra"].Value.ToString()))
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["LoaiBaoCao"] = "CHUYỂN KHOẢN TỒN";
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT"].Value.ToString();
                        dr["Ky"] = item.Cells["Ky"].Value.ToString();
                        dr["TongCong"] = item.Cells["TongCong"].Value.ToString();
                        dr["HanhThu"] = item.Cells["HanhThu"].Value.ToString();
                        dr["To"] = item.Cells["To"].Value.ToString();
                        if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
            }
            else
                if (radChuaTra.Checked)
                {
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                        if (!bool.Parse(item.Cells["ChuyenKhoan"].Value.ToString()) && !bool.Parse(item.Cells["Tra"].Value.ToString()))
                        {
                            DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                            dr["LoaiBaoCao"] = "QUẦY TỒN";
                            dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                            dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                            dr["MLT"] = item.Cells["MLT"].Value.ToString();
                            dr["Ky"] = item.Cells["Ky"].Value.ToString();
                            dr["TongCong"] = item.Cells["TongCong"].Value.ToString();
                            dr["HanhThu"] = item.Cells["HanhThu"].Value.ToString();
                            dr["To"] = item.Cells["To"].Value.ToString();
                            if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                                dr["Loai"] = "CQ";
                            else
                                dr["Loai"] = "TG";
                            ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                        }
                }
            
            rptDSThu2Lan rpt = new rptDSThu2Lan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInDSTra_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (radDaTra.Checked)
            {
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    if (bool.Parse(item.Cells["ChuyenKhoan"].Value.ToString()) && bool.Parse(item.Cells["Tra"].Value.ToString()))
                    {
                        DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                        dr["LoaiBaoCao"] = "CHUYỂN KHOẢN TRẢ";
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                        dr["MLT"] = item.Cells["MLT"].Value.ToString();
                        dr["Ky"] = item.Cells["Ky"].Value.ToString();
                        dr["TongCong"] = item.Cells["TongCong"].Value.ToString();
                        dr["HanhThu"] = item.Cells["HanhThu"].Value.ToString();
                        dr["To"] = item.Cells["To"].Value.ToString();
                        if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                            dr["Loai"] = "CQ";
                        else
                            dr["Loai"] = "TG";
                        ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                    }
            }
            else
                if (radChuaTra.Checked)
                {
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                        if (!bool.Parse(item.Cells["ChuyenKhoan"].Value.ToString()) && bool.Parse(item.Cells["Tra"].Value.ToString()))
                        {
                            DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                            dr["LoaiBaoCao"] = "QUẦY TRẢ";
                            dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                            dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                            dr["MLT"] = item.Cells["MLT"].Value.ToString();
                            dr["Ky"] = item.Cells["Ky"].Value.ToString();
                            dr["TongCong"] = item.Cells["TongCong"].Value.ToString();
                            dr["HanhThu"] = item.Cells["HanhThu"].Value.ToString();
                            dr["To"] = item.Cells["To"].Value.ToString();
                            if (int.Parse(item.Cells["GiaBieu"].Value.ToString()) > 20)
                                dr["Loai"] = "CQ";
                            else
                                dr["Loai"] = "TG";
                            ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                        }
                }

            rptDSThu2Lan rpt = new rptDSThu2Lan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }
 
    }
}
