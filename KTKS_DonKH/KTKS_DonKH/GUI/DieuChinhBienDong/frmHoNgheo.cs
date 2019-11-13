using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmHoNgheo : Form
    {
        string _mnu = "mnuHoNgheo", _action = "";
        CHoNgheo _cHoNgheo = new CHoNgheo();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDHN = new CDHN();
        CTo _cTo = new CTo();

        public frmHoNgheo()
        {
            InitializeComponent();
        }

        private void frmHoNgheo_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            List<To> lst = _cTo.getDS_KTXM();
            To en = new To();
            en.MaTo = 0;
            en.TenTo = "Tất Cả";
            lst.Insert(0, en);
            cmbTo.DataSource = lst;
            cmbTo.ValueMember = "MaTo";
            cmbTo.DisplayMember = "TenTo";
            cmbDot.SelectedIndex = 0;
            Clear();
        }

        public void Clear()
        {
            _action = "";
            btnXem.PerformClick();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        CExcel fileExcel = new CExcel(dialog.FileName);
                        DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                        foreach (DataRow item in dtExcel.Rows)
                            if (!string.IsNullOrEmpty(item[0].ToString()) && item[0].ToString().Replace(" ", "").Length == 11
                                && _cHoNgheo.checkExist(item[0].ToString().Replace(" ", "")) == false)
                            {
                                HOADON hoadon = _cThuTien.GetMoiNhat(item[0].ToString().Replace(" ", ""));
                                if (hoadon != null)
                                {
                                    HoNgheo en = new HoNgheo();
                                    en.DanhBo = hoadon.DANHBA;
                                    en.HoTen = hoadon.TENKH;
                                    en.DiaChi = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                                    en.Dot = hoadon.DOT;
                                    en.Ky = hoadon.KY;
                                    en.Nam = hoadon.NAM;
                                    if (hoadon.DM != null)
                                        en.DinhMuc = (int)hoadon.DM;
                                    if (item[1].ToString() != "")
                                        en.DinhMucHN = int.Parse(item[1].ToString());
                                    if (item[2].ToString() != "")
                                        en.MaCT = item[2].ToString();
                                    en.DinhMucDC = 0;
                                    _cHoNgheo.Them(en);
                                }
                                else
                                {
                                    HoNgheo en = new HoNgheo();
                                    en.DanhBo = item[0].ToString().Replace(" ", "");
                                    _cHoNgheo.Them(en);
                                }
                            }
                    }
                    Clear();
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DanhBo" && _action == "add")
                try
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                    {
                        if (_cHoNgheo.checkExist(dgvDanhSach["DanhBo", e.RowIndex].Value.ToString().Replace(" ", "")) == false)
                        {
                            HOADON hoadon = _cThuTien.GetMoiNhat(dgvDanhSach["DanhBo", e.RowIndex].Value.ToString().Replace(" ", ""));
                            if (hoadon != null)
                            {
                                HoNgheo en = new HoNgheo();
                                en.DanhBo = hoadon.DANHBA;
                                en.HoTen = hoadon.TENKH;
                                en.DiaChi = hoadon.SO + " " + hoadon.DUONG + _cDHN.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                                en.Dot = hoadon.DOT;
                                en.Ky = hoadon.KY;
                                en.Nam = hoadon.NAM;
                                if (hoadon.DM != null)
                                    en.DinhMuc = (int)hoadon.DM;
                                if (_cHoNgheo.Them(en) == true)
                                {
                                    dgvDanhSach["HoTen", e.RowIndex].Value = en.HoTen;
                                    dgvDanhSach["DiaChi", e.RowIndex].Value = en.DiaChi;
                                    dgvDanhSach["DinhMuc", e.RowIndex].Value = en.DinhMuc;
                                }
                            }
                            else
                            {
                                HoNgheo en = new HoNgheo();
                                en.DanhBo = dgvDanhSach["DanhBo", e.RowIndex].Value.ToString().Replace(" ", "");
                                _cHoNgheo.Them(en);
                            }
                        }
                    }
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DinhMuc" || dgvDanhSach.Columns[e.ColumnIndex].Name == "DinhMucHN" || dgvDanhSach.Columns[e.ColumnIndex].Name == "DinhMucDC" || dgvDanhSach.Columns[e.ColumnIndex].Name == "MaCT")
            {
                try
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        HoNgheo en = _cHoNgheo.get(dgvDanhSach["DanhBo", e.RowIndex].Value.ToString());
                        if (en != null)
                        {
                            //if (dgvDanhSach["DinhMuc", e.RowIndex].Value.ToString() != "")
                            //    en.DinhMuc = int.Parse(dgvDanhSach["DinhMuc", e.RowIndex].Value.ToString());
                            if (dgvDanhSach["DinhMucHN", e.RowIndex].Value.ToString() != "")
                                en.DinhMucHN = int.Parse(dgvDanhSach["DinhMucHN", e.RowIndex].Value.ToString());
                            if (dgvDanhSach["DinhMucDC", e.RowIndex].Value.ToString() != "")
                                en.DinhMucDC = int.Parse(dgvDanhSach["DinhMucDC", e.RowIndex].Value.ToString());
                            if (dgvDanhSach["MaCT", e.RowIndex].Value.ToString() != "")
                                en.MaCT = dgvDanhSach["MaCT", e.RowIndex].Value.ToString();
                            _cHoNgheo.Sua(en);
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
        }

        private void dgvDanhSach_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    HoNgheo en = _cHoNgheo.get(e.Row.Cells["DanhBo"].Value.ToString());
                    if (en != null)
                    {
                        _cHoNgheo.Xoa(en);
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

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbTo.SelectedIndex == 0)
            {
                if (cmbDot.SelectedIndex == 0)
                {
                    dgvDanhSach.DataSource = _cHoNgheo.getDS();
                }
                else
                    if (cmbDot.SelectedIndex > 0)
                    {
                        dgvDanhSach.DataSource = _cHoNgheo.getDS_Dot(int.Parse(cmbDot.SelectedItem.ToString()));
                    }
            }
            else
                if (cmbTo.SelectedIndex > 0)
                {
                    if (cmbDot.SelectedIndex == 0)
                    {
                        dgvDanhSach.DataSource = _cHoNgheo.getDS_To(int.Parse(cmbTo.SelectedValue.ToString()));
                    }
                    else
                        if (cmbDot.SelectedIndex > 0)
                        {
                            dgvDanhSach.DataSource = _cHoNgheo.getDS(int.Parse(cmbTo.SelectedValue.ToString()),int.Parse(cmbDot.SelectedItem.ToString()));
                        }
                }
            
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
                if (item.Cells["DanhBo"].Value != null)
                {
                    DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                    if (item.Cells["DanhBo"].Value.ToString().Length == 11)
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                    dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                    dr["GiaBieu"] = item.Cells["DinhMuc"].Value.ToString();
                    dr["DinhMucHN"] = item.Cells["DinhMucHN"].Value.ToString();
                    dr["DinhMuc"] = item.Cells["DinhMucDC"].Value.ToString();

                    dsBaoCao.Tables["DCBD"].Rows.Add(dr);
                }
            rptDSHoNgheo rpt = new rptDSHoNgheo();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void dgvDanhSach_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    _action = "add";
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
        }


    }

}
