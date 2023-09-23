using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.VanThu;
using ThuTien.DAL;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.VanThu
{
    public partial class frmCongVanDen : Form
    {
        string _mnu = "mnuCongVanDen";
        CCongVanDen _cCVD = new CCongVanDen();
        CThuongVu _cThuongVu = new CThuongVu();
        CDHN _cDHN = new CDHN();

        public frmCongVanDen()
        {
            InitializeComponent();
        }

        private void frmCongVanDen_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                btnXem.PerformClick();
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (chkAuto.Checked)
            {
                dgvDanhSach.DataSource = _cThuongVu.getDS_CVD("", dateTu.Value, dateDen.Value);
            }
            else
            {
                if (txtMaDon.Text.Trim() != "")
                    dgvDanhSach.DataSource = _cCVD.getDS(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                else
                    dgvDanhSach.DataSource = _cCVD.getDS(dateTu.Value, dateDen.Value);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    if (dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString() == "")
                    {
                        MessageBox.Show("Không có File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }
                    DataTable dt = _cThuongVu.getFile(dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString(), int.Parse(dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString()));
                    if (dt != null && dt.Rows.Count > 0)
                        foreach (DataRow item in dt.Rows)
                        {
                            if (item["Type"].ToString().ToLower().Contains("pdf"))
                                _cCVD.viewPDF((byte[])item["File"]);
                            else
                                _cCVD.viewImage((byte[])item["File"]);
                        }
                    //string TableNameHinh, IDName;
                    //_cThuongVu.getTableHinh(dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString(), out TableNameHinh, out IDName);
                    //System.Diagnostics.Process.Start("https://service.cskhtanhoa.com.vn/ThuongVu/viewFile?TableName=" + TableNameHinh + "&IDFileName=" + IDName + "&IDFileContent=" + dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString());
                }
                else
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "Them")
                    {
                        if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                        {
                            if (dgvDanhSach.CurrentRow.Cells["NoiDung"].Value == null || string.IsNullOrEmpty(dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString().Trim()))
                            {
                                MessageBox.Show("Nội Dung rỗng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            TT_CongVanDen en = new TT_CongVanDen();
                            en.LoaiVB = dgvDanhSach.CurrentRow.Cells["LoaiVB"].Value.ToString();
                            en.NoiChuyen = dgvDanhSach.CurrentRow.Cells["NoiChuyen"].Value.ToString();
                            //en.NgayChuyen = DateTime.Parse(dgvDanhSach.CurrentRow.Cells["NgayChuyen"].Value.ToString());
                            en.MLT = dgvDanhSach.CurrentRow.Cells["MLT"].Value.ToString();
                            en.DanhBo = dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString();
                            en.HoTen = dgvDanhSach.CurrentRow.Cells["HoTen"].Value.ToString();
                            en.DiaChi = dgvDanhSach.CurrentRow.Cells["DiaChi"].Value.ToString();
                            en.NoiDung = dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString();
                            en.MaDon = dgvDanhSach.CurrentRow.Cells["MaDon"].Value.ToString();
                            en.TableName = dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString();
                            en.IDCT = int.Parse(dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString());
                            if (_cCVD.checkExists(en.TableName, en.IDCT.Value) == true)
                            {
                                MessageBox.Show("Đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (_cCVD.Them(en) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "NoiDung" && dgvDanhSach.CurrentRow.Cells["ID"].Value != null && dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString() != "")
                    {
                        TT_CongVanDen en = _cCVD.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                        en.NoiDung = dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString();
                        _cCVD.Sua(en);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa") && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TT_CongVanDen en = _cCVD.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                    if (en != null)
                    {
                        if (_cCVD.Xoa(en))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnThemAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    foreach (DataGridViewRow item in dgvDanhSach.Rows)
                    {
                        if (item.Cells["NoiDung"].Value == null || string.IsNullOrEmpty(item.Cells["NoiDung"].Value.ToString().Trim()))
                        {
                            MessageBox.Show("Nội Dung rỗng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        TT_CongVanDen en = new TT_CongVanDen();
                        en.LoaiVB = item.Cells["LoaiVB"].Value.ToString();
                        en.NoiChuyen = item.Cells["NoiChuyen"].Value.ToString();
                        //en.NgayChuyen = DateTime.Parse(item.Cells["NgayChuyen"].Value.ToString());
                        en.MLT = item.Cells["MLT"].Value.ToString();
                        en.DanhBo = item.Cells["DanhBo"].Value.ToString();
                        en.HoTen = item.Cells["HoTen"].Value.ToString();
                        en.DiaChi = item.Cells["DiaChi"].Value.ToString();
                        en.NoiDung = item.Cells["NoiDung"].Value.ToString();
                        en.MaDon = item.Cells["MaDon"].Value.ToString();
                        en.TableName = item.Cells["TableName"].Value.ToString();
                        en.IDCT = int.Parse(item.Cells["IDCT"].Value.ToString());
                        if (!_cCVD.checkExists(en.TableName, en.IDCT.Value))
                        {
                            _cCVD.Them(en);
                        }
                        MessageBox.Show("Đã Xử Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


    }
}
