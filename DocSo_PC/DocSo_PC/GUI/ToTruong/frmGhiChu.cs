using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;
using System.Globalization;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmGhiChu : Form
    {
        string _mnu = "mnuGhiChu";
        CDocSo _cDocSo = new CDocSo();
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        CDHN _cDHN = new CDHN();
        bool _flagLoadFirst = false;
        TB_DULIEUKHACHHANG _enDLKH = null;
        bool _flagThemDienThoai = false;
        public frmGhiChu()
        {
            InitializeComponent();
        }

        private void frmGhiChu_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDienThoai.AutoGenerateColumns = false;
            if (CNguoiDung.Admin)
                btnChonFile.Visible = true;
            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;
                List<To> lst = _cTo.getDS_HanhThu();
                To en = new To();
                en.MaTo = 0;
                en.TenTo = "Tất Cả";
                lst.Insert(0, en);
                cmbTo.DataSource = lst;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
                loadMay(cmbTo.SelectedValue.ToString());
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                loadMay(CNguoiDung.MaTo.ToString());
            }
            DataTable dt1, dt2;
            dt1 = dt2 = _cDHN.getDS_ViTriDHN();
            cmbViTri1.DataSource = dt1;
            cmbViTri1.DisplayMember = "KyHieu";
            cmbViTri1.ValueMember = "KyHieu";
            cmbViTri2.DataSource = dt2;
            cmbViTri2.DisplayMember = "KyHieu";
            cmbViTri2.ValueMember = "KyHieu";
            _flagLoadFirst = true;
        }

        public void loadMay(string MaTo)
        {
            try
            {
                DataTable dtMay = new DataTable();
                if (MaTo == "0")
                    for (int i = 1; i < cmbTo.Items.Count; i++)
                    {
                        dtMay.Merge(_cMayDS.getDS(((To)cmbTo.Items[i]).MaTo.ToString()));
                    }
                else
                    dtMay = _cMayDS.getDS(MaTo);
                DataRow dr = dtMay.NewRow();
                dr["May"] = "Tất Cả";
                dtMay.Rows.InsertAt(dr, 0);
                cmbMay.DataSource = dtMay;
                cmbMay.DisplayMember = "May";
                cmbMay.ValueMember = "May";
                cmbMay.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clear()
        {
            txtSoNha.Text = "";
            txtTenDuong.Text = "";
            cmbViTri1.SelectedIndex = -1;
            cmbViTri2.SelectedIndex = -1;
            chkGieng.Checked = false;
        }

        public void loadthongtin(TB_DULIEUKHACHHANG en)
        {
            if (en != null)
            {
                txtSoNha.Text = en.SONHA;
                txtTenDuong.Text = en.TENDUONG;
                if (en.VITRIDHN != null && en.VITRIDHN != "")
                    cmbViTri1.SelectedValue = en.VITRIDHN;
                if (en.ViTriDHN2 != null && en.ViTriDHN2 != "")
                    cmbViTri2.SelectedValue = en.ViTriDHN2;
                chkGieng.Checked = en.Gieng;
                dgvDienThoai.DataSource = _cDHN.getDS_DienThoai(en.DANHBO);
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex > -1)
                loadMay(cmbTo.SelectedValue.ToString());
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi == true)
            {
                if (txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                    dgvDanhSach.DataSource = _cDHN.getDS_DanhBo(txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", ""));
                else
                    if (cmbTo.SelectedIndex == 0)
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_Doi();
                    }
                    else
                    {
                        if (cmbMay.SelectedIndex == 0)
                        {
                            dgvDanhSach.DataSource = _cDHN.getDS_To(cmbTo.SelectedValue.ToString());
                        }
                        else
                        {
                            dgvDanhSach.DataSource = _cDHN.getDS_May(cmbDot.SelectedItem.ToString(),cmbMay.SelectedValue.ToString());
                        }
                    }
            }
            else
            {
                if (txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                    dgvDanhSach.DataSource = _cDHN.getDS_DanhBo(CNguoiDung.MaTo.ToString(), txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", ""));
                else
                    if (cmbMay.SelectedIndex == 0)
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_To(CNguoiDung.MaTo.ToString());
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_May(cmbDot.SelectedItem.ToString(), cmbMay.SelectedValue.ToString());
                    }
            }
            int TongViTri = 0, TongDTDHN = 0, TongDTKH = 0, TongDTTV = 0;
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                if (item.Cells["ViTri1"].Value.ToString() != "")
                    TongViTri++;
                if (item.Cells["DTDHN"].Value.ToString() != "")
                    TongDTDHN++;
                if (item.Cells["DTKH"].Value.ToString() != "")
                    TongDTKH++;
                if (item.Cells["DTTV"].Value.ToString() != "")
                    TongDTTV++;
            }
            txtTongViTri.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongViTri);
            txtTongDTDHN.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDTDHN);
            txtTongDTKH.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDTKH);
            txtTongDTTV.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDTTV);
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_enDLKH != null)
                    {
                        _enDLKH.SONHA = txtSoNha.Text.Trim();
                        _enDLKH.TENDUONG = txtTenDuong.Text.Trim();
                        if (cmbViTri1.SelectedIndex >= 0)
                            _enDLKH.VITRIDHN = cmbViTri1.SelectedValue.ToString();
                        if (cmbViTri2.SelectedIndex >= 0)
                            _enDLKH.ViTriDHN2 = cmbViTri2.SelectedValue.ToString();
                        _enDLKH.Gieng = chkGieng.Checked;
                        _cDHN.SubmitChanges();
                        foreach (DataGridViewRow item in dgvDienThoai.Rows)
                        {

                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _enDLKH = _cDHN.get(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString());
                loadthongtin(_enDLKH);
            }
            catch
            {
            }
        }

        private void dgvDienThoai_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _flagThemDienThoai = true;
        }

        private void dgvDienThoai_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_enDLKH != null)
                    {
                        SDT_DHN en = _cDHN.get_DienThoai(e.Row.Cells["DanhBo_DT"].Value.ToString(), e.Row.Cells["DienThoai_DT"].Value.ToString());
                        if (en != null)
                        {
                            if (_cDHN.xoa_DienThoai(en) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDienThoai_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_flagThemDienThoai == false && dgvDienThoai["DanhBo_DT", e.RowIndex].Value.ToString() != "" && (dgvDienThoai.Columns[e.ColumnIndex].Name == "HoTen_DT" || dgvDienThoai.Columns[e.ColumnIndex].Name == "SoChinh_DT"))
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (_enDLKH != null)
                        {
                            SDT_DHN en = _cDHN.get_DienThoai(dgvDienThoai["DanhBo_DT", e.RowIndex].Value.ToString(), dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString());
                            if (en != null)
                            {
                                en.HoTen = dgvDienThoai["HoTen_DT", e.RowIndex].Value.ToString();
                                if (dgvDienThoai["SoChinh_DT", e.RowIndex].Value != null && dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString() != "")
                                    en.SoChinh = bool.Parse(dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString());
                                else
                                    en.SoChinh = false;
                                en.ModifyBy = CNguoiDung.MaND;
                                en.ModifyDate = DateTime.Now;
                                _cDHN.SubmitChanges();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDienThoai_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_enDLKH != null && _flagThemDienThoai == true)
                    {
                        if (_cDHN.checkExists_DienThoai(_enDLKH.DANHBO, dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString()) == true)
                        {
                            MessageBox.Show("Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        SDT_DHN en = new SDT_DHN();
                        en.DanhBo = _enDLKH.DANHBO;
                        en.DienThoai = dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString();
                        en.HoTen = dgvDienThoai["HoTen_DT", e.RowIndex].Value.ToString();
                        if (dgvDienThoai["SoChinh_DT", e.RowIndex].Value != null && dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString() != "")
                            en.SoChinh = bool.Parse(dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString());
                        else
                            en.SoChinh = false;
                        en.DHN = true;
                        if (_cDHN.them_DienThoai(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _flagThemDienThoai = false;
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cDocSo.ExcelToDataTable(dialog.FileName);

                            foreach (DataRow item in dtExcel.Rows)
                                if (!string.IsNullOrEmpty(item[2].ToString()))
                                {
                                    string[] DanhBos = item[2].ToString().Split(',');
                                    foreach (string itemS in DanhBos)
                                    {
                                        SDT_DHN en = new SDT_DHN();
                                        en.DanhBo = itemS;
                                        en.HoTen = item[0].ToString();
                                        en.DienThoai = item[3].ToString();

                                        if (_cDHN.checkExists_DienThoai(en.DanhBo, en.DienThoai) == false)
                                            _cDHN.them_DienThoai(en);
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
    }
}
