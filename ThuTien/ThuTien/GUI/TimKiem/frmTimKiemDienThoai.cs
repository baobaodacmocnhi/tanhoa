using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.HanhThu;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.BaoCao;
using ThuTien.BaoCao.NhanVien;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.TimKiem
{
    public partial class frmTimKiemDienThoai : Form
    {
        string _mnu = "mnuTimKiemDienThoai";
        CThongTinKhachHang _cTTKH = new CThongTinKhachHang();
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        bool _flagFirstLoad = true;

        public frmTimKiemDienThoai()
        {
            InitializeComponent();
        }

        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            dgvTTKH.AutoGenerateColumns = false;

            if (CNguoiDung.Doi)
            {
                lbTo.Visible = true;
                cmbTo.Visible = true;
                lbNhanVien.Visible = true;
                cmbNhanVien.Visible = true;

                List<TT_To> lstTo = _cTo.GetDSHanhThu();
                //TT_To to = new TT_To();
                //to.MaTo = 0;
                //to.TenTo = "Tất Cả";
                //lstTo.Insert(0, to);
                cmbTo.DataSource = lstTo;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
                if (CNguoiDung.ToTruong)
                {
                    lbNhanVien.Visible = true;
                    cmbNhanVien.Visible = true;

                    List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                    //TT_NguoiDung nguoidung = new TT_NguoiDung();
                    //nguoidung.MaND = 0;
                    //nguoidung.HoTen = "Tất Cả";
                    //lstND.Insert(0, nguoidung);
                    cmbNhanVien.DataSource = lstND;
                    cmbNhanVien.DisplayMember = "HoTen";
                    cmbNhanVien.ValueMember = "MaND";
                }
                else
                {
                    List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                    //TT_NguoiDung nguoidung = new TT_NguoiDung();
                    //nguoidung.MaND = 0;
                    //nguoidung.HoTen = "Tất Cả";
                    //lstND.Insert(0, nguoidung);
                    cmbNhanVien.DataSource = lstND;
                    cmbNhanVien.DisplayMember = "HoTen";
                    cmbNhanVien.ValueMember = "MaND";

                    cmbNhanVien.SelectedValue = CNguoiDung.MaND;
                }
            _flagFirstLoad = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string Loai = "";
            if (radTG.Checked)
                Loai = "TG";
            else
                if (radCQ.Checked)
                    Loai = "CQ";

            if (cmbDot.SelectedIndex >= 0 && cmbDenDot.SelectedIndex < 0)
                dgvTTKH.DataSource = _cTTKH.GetDS(Loai,int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
            else
                if (cmbDot.SelectedIndex >= 0 && cmbDenDot.SelectedIndex >= 0)
                    dgvTTKH.DataSource = _cTTKH.GetDS(Loai, int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbDenDot.SelectedItem.ToString()));
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_cTTKH.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")))
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_ThongTinKhachHang ttkh = _cTTKH.Get(txtDanhBo.Text.Trim().Replace(" ", ""));
                    ttkh.DienThoai = txtDienThoai.Text.Trim();

                    if (_cTTKH.Sua(ttkh))
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    TT_ThongTinKhachHang ttkh = new TT_ThongTinKhachHang();
                    ttkh.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    ttkh.DienThoai = txtDienThoai.Text.Trim();

                    if (_cTTKH.Them(ttkh))
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvTTKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTTKH.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvTTKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTTKH.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ","").Length == 11)
            {
                if (_cTTKH.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")))
                {
                    TT_ThongTinKhachHang ttkh = _cTTKH.Get(txtDanhBo.Text.Trim().Replace(" ", ""));
                    txtDienThoai.Text = ttkh.DienThoai;
                }
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirstLoad == false && cmbTo.SelectedIndex > -1)
            {
                List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                //TT_NguoiDung nguoidung = new TT_NguoiDung();
                //nguoidung.MaND = 0;
                //nguoidung.HoTen = "Tất Cả";
                //lstND.Insert(0, nguoidung);
                cmbNhanVien.DataSource = lstND;
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVien.DataSource = null;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTTKH.Rows)
            {
                DataRow dr = ds.Tables["ThongTinKhachHang"].NewRow();
                if (item.Cells["DanhBo"].Value.ToString().Length==11)
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                else
                    MessageBox.Show(item.Cells["DanhBo"].Value.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["DienThoai"] = item.Cells["DienThoai"].Value;

                ds.Tables["ThongTinKhachHang"].Rows.Add(dr);
            }

            rptThongTinKhachHang rpt = new rptThongTinKhachHang();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

    }
}
