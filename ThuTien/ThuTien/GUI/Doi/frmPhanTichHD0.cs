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

namespace ThuTien.GUI.Doi
{
    public partial class frmPhanTichHD0 : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmPhanTichHD0()
        {
            InitializeComponent();
        }

        private void frmPhanTichHD0_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            List<TT_To> lst = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lst.Insert(0, to);
            cmbTo.DataSource = lst;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ///chọn tất cả tổ
            if (cmbTo.SelectedIndex == 0)
            {
                if (cmbKy.SelectedIndex == 0)
                    dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0(int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                else
                    if (cmbKy.SelectedIndex > 0)
                        dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
            }
            else
                ///chọn 1 tổ cụ thể
                if (cmbTo.SelectedIndex > 0)
                {
                    ///chọn tất cả nhân viên
                    if (cmbNhanVien.SelectedIndex == 0)
                    {
                        if (cmbKy.SelectedIndex == 0)
                            dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_To(((TT_To)cmbTo.SelectedItem).MaTo,int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                        else
                            if (cmbKy.SelectedIndex > 0)
                                dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_To(((TT_To)cmbTo.SelectedItem).MaTo,int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                    }
                    else
                        ///chọn 1 nhân viên cụ thể
                        if (cmbNhanVien.SelectedIndex > 0)
                        {
                            if (cmbKy.SelectedIndex == 0)
                                dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_NV(((TT_NguoiDung)cmbNhanVien.SelectedItem).MaND, int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                            else
                                if (cmbKy.SelectedIndex > 0)
                                    dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_NV(((TT_NguoiDung)cmbNhanVien.SelectedItem).MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                        }
                    
                }
            
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTo.SelectedIndex > 0)
            {
                List<TT_NguoiDung> lst = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = 0;
                nguoidung.HoTen = "Tất Cả";
                lst.Insert(0, nguoidung);
                cmbNhanVien.DataSource = lst;
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVien.DataSource = null;
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }
    }
}
