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
using ThuTien.DAL.Quay;
using System.Transactions;

namespace ThuTien.GUI.TongHop
{
    public partial class frmThu2Lan : Form
    {
        string _mnu = "mnuThu2Lan";
        CHoaDon _cHoaDon = new CHoaDon();
        CTienDuQuay _cTienDuQuay = new CTienDuQuay();

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
            //if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            //{
            //    bool ChuyenKhoan = true;
            //    if (radDaTra.Checked)
            //        ChuyenKhoan = true;
            //    if (radChuaTra.Checked)
            //        ChuyenKhoan = false;

            //    if (_cHoaDon.Thu2Lan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()),txtDanhBo.Text.Trim(), ChuyenKhoan))
            //        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (MessageBox.Show("Bạn có muốn trừ Tiền Dư Quầy?\r\nYes là Trừ, No là không Trừ", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        try
                        {
                            foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                                using (var scope = new TransactionScope())
                                {
                                    if (_cHoaDon.XoaThu2Lan(item.Cells["SoHoaDon"].Value.ToString()))
                                        if (_cTienDuQuay.UpdateThem(item.Cells["SoHoaDon"].Value.ToString(), "Thu 2 Lần", "Xóa"))
                                            scope.Complete();
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    else
                    {
                        try
                        {
                            foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                                if (_cHoaDon.XoaThu2Lan(item.Cells["SoHoaDon"].Value.ToString()))
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        private void dgvHoaDon_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "Tra" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvHoaDon[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (bool.Parse(dgvHoaDon["Tra", e.RowIndex].Value.ToString()))
                        if (MessageBox.Show("Bạn có muốn trừ Tiền Dư Quầy?\r\nYes là Trừ, No là không Trừ", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            using (var scope = new TransactionScope())
                            {
                                if (_cHoaDon.Thu2Lan_Tra(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString()))
                                    if (_cTienDuQuay.UpdateThem(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString(), "Trả Tiền Khách Hàng", "Thêm"))
                                        scope.Complete();
                            }
                        else
                        {
                            _cHoaDon.Thu2Lan_Tra(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
                        }
                    else
                        if (MessageBox.Show("Đã Trả, bạn có chắc chắn xóa trả?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            using (var scope = new TransactionScope())
                            {
                                if (_cHoaDon.Thu2Lan_XoaTra(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString()))
                                    if (_cTienDuQuay.UpdateXoa(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString(), "Trả Tiền Khách Hàng", "Xóa"))
                                        scope.Complete();
                            }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GhiChu" && e.FormattedValue.ToString() != dgvHoaDon[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    _cHoaDon.Thu2Lan_GhiChu(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString(), dgvHoaDon["GhiChu", e.RowIndex].Value.ToString());
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
    }
}
