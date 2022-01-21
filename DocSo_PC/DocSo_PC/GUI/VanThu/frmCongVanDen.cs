using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.VanThu;
using DocSo_PC.DAL;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.GUI.VanThu
{
    public partial class frmCongVanDen : Form
    {
        string _mnu = "mnuCongVanDen";
        CCongVanDen _cCVD = new CCongVanDen();
        CThuongVu _cThuongVu = new CThuongVu();

        public frmCongVanDen()
        {
            InitializeComponent();
        }

        private void frmCongVanDen_Load(object sender, EventArgs e)
        {
            dgvDanhSachChuaNhan.AutoGenerateColumns = false;
            dgvDanhSachDaNhan.AutoGenerateColumns = false;
        }

        private void dgvDanhSachChuaNhan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSachChuaNhan.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvDanhSachChuaNhan.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDanhSachChuaNhan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSachChuaNhan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSachChuaNhan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //object image = null;
                //switch (dgvDanhSachChuaNhan.CurrentRow.Cells["TableName"].Value.ToString())
                //{
                //    case "KTXM_ChiTiet":
                //        image = _cThuongVu.getHinh_KTXM(int.Parse(dgvDanhSachChuaNhan.CurrentRow.Cells["IDCT"].Value.ToString()));
                //        break;
                //    case "ToTrinh_ChiTiet":
                //        image = _cThuongVu.getHinh_ToTrinh(int.Parse(dgvDanhSachChuaNhan.CurrentRow.Cells["IDCT"].Value.ToString()));
                //        break;
                //}
                //if (image != null)
                //    _cCVD.LoadImageView((byte[])image);
                //else
                //    MessageBox.Show("Không có File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                object image = null;
                switch (dgvDanhSachChuaNhan.CurrentRow.Cells["TableName"].Value.ToString())
                {
                    case "KTXM_ChiTiet":
                        image = _cThuongVu.getHinh_KTXM(int.Parse(dgvDanhSachChuaNhan.CurrentRow.Cells["IDCT"].Value.ToString()));
                        break;
                    case "ToTrinh_ChiTiet":
                        image = _cThuongVu.getHinh_ToTrinh(int.Parse(dgvDanhSachChuaNhan.CurrentRow.Cells["IDCT"].Value.ToString()));
                        break;
                }
                if (image != null)
                {
                    if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                    {
                        CongVanDen en = new CongVanDen();
                        en.LoaiVB = dgvDanhSachChuaNhan.CurrentRow.Cells["LoaiVB"].Value.ToString();
                        en.NoiChuyen = dgvDanhSachChuaNhan.CurrentRow.Cells["NoiChuyen"].Value.ToString();
                        en.NgayChuyen = DateTime.Parse(dgvDanhSachChuaNhan.CurrentRow.Cells["NgayChuyen"].Value.ToString());
                        en.MLT = dgvDanhSachChuaNhan.CurrentRow.Cells["MLT"].Value.ToString();
                        en.DanhBo = dgvDanhSachChuaNhan.CurrentRow.Cells["DanhBo"].Value.ToString();
                        en.HoTen = dgvDanhSachChuaNhan.CurrentRow.Cells["HoTen"].Value.ToString();
                        en.DiaChi = dgvDanhSachChuaNhan.CurrentRow.Cells["DiaChi"].Value.ToString();
                        en.NoiDung = dgvDanhSachChuaNhan.CurrentRow.Cells["NoiDung"].Value.ToString();
                        en.MaDon = dgvDanhSachChuaNhan.CurrentRow.Cells["MaDon"].Value.ToString();
                        en.TableName = dgvDanhSachChuaNhan.CurrentRow.Cells["TableName"].Value.ToString();
                        en.IDCT = int.Parse(dgvDanhSachChuaNhan.CurrentRow.Cells["IDCT"].Value.ToString());
                        if (_cCVD.checkExists(en.TableName, en.IDCT.Value) == false)
                            if (_cCVD.Them(en) == true)
                            {
                                CThuongVu._cDAL.ExecuteNonQuery("update CongVanDi set Nhan_QLDHN=1,Nhan_QLDHN_Ngay=getdate() where ID=" + dgvDanhSachChuaNhan.CurrentRow.Cells["ID"].Value.ToString());
                            }
                        frmShowCongVan frm = new frmShowCongVan(en.TableName, en.IDCT.Value);
                        frm.ShowDialog();
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Không có File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabChuaNhan")
            {
                DataTable dt = _cThuongVu.getDS_KTXM_ChuaNhan(dateTu.Value, dateDen.Value);
                dt.Merge(_cThuongVu.getDS_ToTrinh_ChuaNhan(dateTu.Value, dateDen.Value));
                dgvDanhSachChuaNhan.DataSource = dt;
            }
            else
                if (tabControl.SelectedTab.Name == "tabDaNhan")
                    dgvDanhSachDaNhan.DataSource = _cCVD.getDS(dateTu.Value, dateDen.Value);
        }

        private void dgvDanhSachDaNhan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSachDaNhan.Columns[e.ColumnIndex].Name == "MLT_DaNhan" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvDanhSachDaNhan.Columns[e.ColumnIndex].Name == "DanhBo_DaNhan" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDanhSachDaNhan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSachDaNhan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSachDaNhan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmShowCongVan frm = new frmShowCongVan(dgvDanhSachDaNhan.CurrentRow.Cells["TableName_DaNhan"].Value.ToString(), int.Parse(dgvDanhSachDaNhan.CurrentRow.Cells["IDCT_DaNhan"].Value.ToString()));
            frm.ShowDialog();
        }

        private void btnXoa_DaNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        foreach (DataGridViewRow item in dgvDanhSachDaNhan.SelectedRows)
                        {
                            _cCVD.Xoa(_cCVD.get(int.Parse(item.Cells["ID_DaNhan"].Value.ToString())));
                        }
                    btnXem.PerformClick();
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
