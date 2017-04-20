using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ToTruong;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ToTruong;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmDangKyKiemTra : Form
    {
        string _mnu = "mnuDangKyKiemTra";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDangKyKiemTra _cDangKyKT = new CDangKyKiemTra();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmDangKyKiemTra()
        {
            InitializeComponent();
        }

        private void frmChuyenKinhDoanh_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;

            List<TT_NguoiDung> lstND = null;
            lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            TT_NguoiDung nguoidung = new TT_NguoiDung();
            nguoidung.MaND = 0;
            nguoidung.HoTen = "Tất Cả";
            lstND.Insert(0, nguoidung);

            cmbNhanVien.DataSource = lstND;
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaND";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ///chọn tất cả nhân viên
            if (cmbNhanVien.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                foreach (TT_NguoiDung itemND in lstND)
                {
                    dt.Merge(_cDangKyKT.GetDS(itemND.MaND));
                }
                dgvDanhBo.DataSource = dt;
            }
            else
                ///chọn 1 nhân viên cụ thể
                if (cmbNhanVien.SelectedIndex > 0)
                {
                    dgvDanhBo.DataSource = _cDangKyKT.GetDS(int.Parse(cmbNhanVien.SelectedValue.ToString()));
                }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtDanhBo.Text.Trim().Replace(" ", "") != "")
                {
                    if (cmbNhanVien.Items.Count == 0 || cmbNhanVien.SelectedIndex == 0)
                    {
                        MessageBox.Show("Chưa chọn Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cDangKyKT.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")) == true)
                    {
                        MessageBox.Show(_cDangKyKT.GetHoTen(txtDanhBo.Text.Trim().Replace(" ", "")) + " đã đăng ký " + txtDanhBo.Text.Trim().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TT_DangKyKiemTra dangky = new TT_DangKyKiemTra();
                    dangky.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    dangky.MaNV = int.Parse(cmbNhanVien.SelectedValue.ToString());
                    
                    HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                    if (hoadon != null)
                    {
                        dangky.MLT = hoadon.MALOTRINH;
                        dangky.DiaChi = hoadon.SO + " " + hoadon.DUONG;
                        dangky.GB_DM_Cu = hoadon.GB + " - " + hoadon.DM;
                    }

                    if (_cDangKyKT.Them(dangky))
                    {
                        txtDanhBo.Text = "";
                        btnXem.PerformClick();
                    }
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
                    foreach (DataGridViewRow item in dgvDanhBo.SelectedRows)
                    {
                        TT_DangKyKiemTra dangky = _cDangKyKT.Get(item.Cells["DanhBo"].Value.ToString());
                        _cDangKyKT.Xoa(dangky);
                    }
                    btnXem.PerformClick();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDanhBo.Rows)
            {
                DataRow dr = ds.Tables["DangKyHD0"].NewRow();
                dr["NhanVien"] = item.Cells["HoTen"].Value;
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["GB_DM_Cu"] = item.Cells["GB_DM_Cu"].Value;
                dr["NoiDung"] = item.Cells["NoiDung"].Value;
                ds.Tables["DangKyHD0"].Rows.Add(dr);
            }

            rptDangKyKiemTra rpt = new rptDangKyKiemTra();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvDanhBo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (dgvDanhBo.Columns[e.ColumnIndex].Name == "NoiDung" && e.FormattedValue.ToString() != dgvDanhBo[e.ColumnIndex, e.RowIndex].Value.ToString())
                {
                    TT_DangKyKiemTra dangky = _cDangKyKT.Get(dgvDanhBo["DanhBo", e.RowIndex].Value.ToString());
                    dangky.NoiDung = e.FormattedValue.ToString();
                    _cDangKyKT.Sua(dangky);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDanhBo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        
    }
}
