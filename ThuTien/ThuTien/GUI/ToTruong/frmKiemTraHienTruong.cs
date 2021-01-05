using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ToTruong;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ToTruong;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmKiemTraHienTruong : Form
    {
        string _mnu = "mnuKiemTraHienTruong";
        CTo _cTo = new CTo();
        CKiemTraHienTruong _cKiemTraHienTruong = new CKiemTraHienTruong();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmKiemTraHienTruong()
        {
            InitializeComponent();
        }

        private void frmKiemTraHienTruong_Load(object sender, EventArgs e)
        {
            dgvKiemTraHienTruong.AutoGenerateColumns = false;

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                cmbTo.DataSource = _cTo.getDS_HanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi == true)
            {
                dgvKiemTraHienTruong.DataSource = _cKiemTraHienTruong.getDS((int)cmbTo.SelectedValue, dateTu.Value, dateDen.Value);
            }
            else
            {
                dgvKiemTraHienTruong.DataSource = _cKiemTraHienTruong.getDS(CNguoiDung.MaTo, dateTu.Value, dateDen.Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")) == false && _cKiemTraHienTruong.CheckExist(txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now) == false)
                    {
                        HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                        if (hoadon != null)
                        {
                            TT_KiemTraHienTruong entity = new TT_KiemTraHienTruong();
                            entity.DanhBo = hoadon.DANHBA;
                            entity.HoTen = hoadon.TENKH;
                            entity.DiaChi = hoadon.SO + " " + hoadon.DUONG;
                            if (_cKiemTraHienTruong.Them(entity))
                            {
                                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                                btnXem.PerformClick();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            foreach (DataGridViewRow item in dgvKiemTraHienTruong.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSHoaDon"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;

                dsBaoCao.Tables["DSHoaDon"].Rows.Add(dr);
            }
            rptDSKiemTraHienTruong rpt = new rptDSKiemTraHienTruong();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvKiemTraHienTruong_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKiemTraHienTruong.Columns[e.ColumnIndex].Name == "NoiDung" && e.FormattedValue.ToString() != dgvKiemTraHienTruong[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_KiemTraHienTruong entity = _cKiemTraHienTruong.get(int.Parse(dgvKiemTraHienTruong["ID", e.RowIndex].Value.ToString()));
                    entity.NoiDung = e.FormattedValue.ToString();
                    _cKiemTraHienTruong.SubmitChanges();
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
            {
                btnThem.PerformClick();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa") && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    foreach (DataGridViewRow item in dgvKiemTraHienTruong.SelectedRows)
                    {
                        TT_KiemTraHienTruong entity = _cKiemTraHienTruong.get(int.Parse(item.Cells["ID"].Value.ToString()));
                        _cKiemTraHienTruong.Xoa(entity);
                    }
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    btnXem.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
