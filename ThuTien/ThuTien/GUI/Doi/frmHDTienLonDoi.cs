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
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.Doi
{
    public partial class frmHDTienLonDoi : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CTo _cTo = new CTo();
        List<TT_To> _lstTo;
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmHDTienLonDoi()
        {
            InitializeComponent();
        }

        private void frmHDTienLonDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            _lstTo = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            _lstTo.Insert(0, to);
            cmbTo.DataSource = _lstTo;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //if (cmbKy.SelectedIndex != -1 && cmbDot.SelectedIndex != -1)
            //    if (int.Parse(cmbTo.SelectedValue.ToString()) == 0)
            //    {
            //        DataTable dtTG = new DataTable();
            //        DataTable dtCQ = new DataTable();

            //        dtTG = _cHoaDon.GetDSByTienLon_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
            //        dtCQ = _cHoaDon.GetDSByTienLon_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
            //        for (int i = 1; i < _lstTo.Count; i++)
            //        {
            //            dtTG.Merge(_cHoaDon.GetDSByTienLon_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
            //            dtCQ.Merge(_cHoaDon.GetDSByTienLon_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
            //        }

            //        dgvHDTuGia.DataSource = dtTG;
            //        dgvHDCoQuan.DataSource = dtCQ;
            //    }
            //    else
            //    {
            //        dgvHDTuGia.DataSource = _cHoaDon.GetDSByTienLon_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
            //        dgvHDCoQuan.DataSource = _cHoaDon.GetDSByTienLon_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
            //    }
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex == 0)
                {
                    if (cmbTo.SelectedIndex == 0)
                    {
                        DataTable dt = new DataTable();
                        foreach (TT_To item in _lstTo)
                        {
                            dt.Merge(_cHoaDon.GetDSByTienLon_Doi("TG", item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                        }
                        dgvHDTuGia.DataSource = dt;
                    }
                    else
                        if (cmbTo.SelectedIndex > 0)
                            dgvHDTuGia.DataSource = _cHoaDon.GetDSByTienLon_Doi("TG", ((TT_To)cmbTo.SelectedItem).MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                }
                ///chọn 1 kỳ cụ thể
                else
                    if (cmbKy.SelectedIndex > 0)
                        ///chọn tất cả các đợt
                        if (cmbDot.SelectedIndex == 0)
                        {
                            if (cmbTo.SelectedIndex == 0)
                            {
                                DataTable dt = new DataTable();
                                foreach (TT_To item in _lstTo)
                                {
                                    dt.Merge(_cHoaDon.GetDSByTienLon_Doi("TG", item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                }
                                dgvHDTuGia.DataSource = dt;
                            }
                            else
                                if (cmbTo.SelectedIndex > 0)
                                    dgvHDTuGia.DataSource = _cHoaDon.GetDSByTienLon_Doi("TG", ((TT_To)cmbTo.SelectedItem).MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                        }
                        ///chọn 1 đợt cụ thể
                        else
                            if (cmbDot.SelectedIndex > 0)
                            {
                                if (cmbTo.SelectedIndex == 0)
                                {
                                    DataTable dt = new DataTable();
                                    foreach (TT_To item in _lstTo)
                                    {
                                        dt.Merge(_cHoaDon.GetDSByTienLon_Doi("TG", item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                    }
                                    dgvHDTuGia.DataSource = dt;
                                }
                                else
                                    if (cmbTo.SelectedIndex > 0)
                                        dgvHDTuGia.DataSource = _cHoaDon.GetDSByTienLon_Doi("TG", ((TT_To)cmbTo.SelectedItem).MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                            }
                dgvHDTuGia.Sort(dgvHDTuGia.Columns["NgayGiaiTrach_TG"], ListSortDirection.Ascending);
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (_cDongNuoc.CheckCTDongNuocBySoHoaDon(item.Cells["SoHoaDon_TG"].Value.ToString()))
                        item.DefaultCellStyle.BackColor = Color.Yellow;
                    if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_TG"].Value.ToString()))
                        item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    ///chọn tất cả các kỳ
                    if (cmbKy.SelectedIndex == 0)
                    {
                        if (cmbTo.SelectedIndex == 0)
                        {
                            DataTable dt = new DataTable();
                            foreach (TT_To item in _lstTo)
                            {
                                dt.Merge(_cHoaDon.GetDSByTienLon_Doi("CQ", item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                            }
                            dgvHDCoQuan.DataSource = dt;
                        }
                        else
                            if (cmbTo.SelectedIndex > 0)
                                dgvHDCoQuan.DataSource = _cHoaDon.GetDSByTienLon_Doi("CQ", ((TT_To)cmbTo.SelectedItem).MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                    }
                    ///chọn 1 kỳ cụ thể
                    else
                        if (cmbKy.SelectedIndex > 0)
                            ///chọn tất cả các đợt
                            if (cmbDot.SelectedIndex == 0)
                            {
                                if (cmbTo.SelectedIndex == 0)
                                {
                                    DataTable dt = new DataTable();
                                    foreach (TT_To item in _lstTo)
                                    {
                                        dt.Merge(_cHoaDon.GetDSByTienLon_Doi("CQ", item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                    }
                                    dgvHDCoQuan.DataSource = dt;
                                }
                                else
                                    if (cmbTo.SelectedIndex > 0)
                                        dgvHDCoQuan.DataSource = _cHoaDon.GetDSByTienLon_Doi("CQ", ((TT_To)cmbTo.SelectedItem).MaTo, int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                            }
                            ///chọn 1 đợt cụ thể
                            else
                                if (cmbDot.SelectedIndex > 0)
                                {
                                    if (cmbTo.SelectedIndex == 0)
                                    {
                                        DataTable dt = new DataTable();
                                        foreach (TT_To item in _lstTo)
                                        {
                                            dt.Merge(_cHoaDon.GetDSByTienLon_Doi("CQ", item.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", ""))));
                                        }
                                        dgvHDCoQuan.DataSource = dt;
                                    }
                                    else
                                        if (cmbTo.SelectedIndex > 0)
                                            dgvHDCoQuan.DataSource = _cHoaDon.GetDSByTienLon_Doi("CQ", ((TT_To)cmbTo.SelectedItem).MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
                                }
                    dgvHDCoQuan.Sort(dgvHDCoQuan.Columns["NgayGiaiTrach_CQ"], ListSortDirection.Ascending);
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        if (_cDongNuoc.CheckCTDongNuocBySoHoaDon(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                            item.DefaultCellStyle.BackColor = Color.Yellow;
                        if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_CQ"].Value.ToString()))
                            item.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            txtSoTien.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(txtSoTien.Text.Trim().Replace(".", "")));
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "DanhBo_TG" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TieuThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "GiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "ThueGTGT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "PhiBVMT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "DanhBo_CQ" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TieuThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "GiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "ThueGTGT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "PhiBVMT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
 
    }
}
