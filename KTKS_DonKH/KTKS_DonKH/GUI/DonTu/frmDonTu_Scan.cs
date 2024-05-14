using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.wrThuongVu;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmDonTu_Scan : Form
    {
        string _mnu = "mnuScanDonTu";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        DonTu_Scan _scan = null;
        HOADON _hoadon = null;
        wsThuongVu _wsThuongVu = new wsThuongVu();
        public frmDonTu_Scan()
        {
            InitializeComponent();
        }

        private void frmDonTu_Scan_Load(object sender, EventArgs e)
        {
            dgvScan.AutoGenerateColumns = false;
            dgvHinh.AutoGenerateColumns = false;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtNguoiBao.Text = "";
            _scan = null;
            _hoadon = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    DonTu_Scan en = new DonTu_Scan();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "");
                    en.DienThoai = txtDienThoai.Text.Trim();
                    en.NguoiBao = txtNguoiBao.Text.Trim();
                    if (_cDonTu.Them_Scan(en))
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_scan != null && MessageBox.Show("Bạn chắc chắn???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cDonTu.Xoa_Scan(_scan))
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

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", ""));
                if (_hoadon != null)
                {
                    txtHoTen.Text = _hoadon.TENKH;
                    txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG;
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvScan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _scan = _cDonTu.get_Scan(int.Parse(dgvScan.CurrentRow.Cells["ID"].Value.ToString()));
                dgvHinh.Rows.Clear();
                foreach (DonTu_Scan_ChiTiet item in _scan.DonTu_Scan_ChiTiets.OrderByDescending(o => o.CreateDate).ToList())
                {
                    var index = dgvHinh.Rows.Add();
                    dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
                }
            }
            catch { }
        }

        private void dgvScan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvScan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvScan.DataSource = _cDonTu.getDS_Scan(dateTu.Value, dateDen.Value);
        }

        //add file
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_scan != null)
                    {
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png|PDF files (*.pdf) | *.pdf";
                        dialog.Multiselect = false;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            byte[] bytes;
                            if (dialog.FileName.ToLower().Contains("pdf"))
                                bytes = _cDonTu.scanFile(dialog.FileName);
                            else
                                bytes = _cDonTu.scanImage(dialog.FileName);
                            DonTu_Scan_ChiTiet en = new DonTu_Scan_ChiTiet();
                            en.ID = _cDonTu.getNextIDScan_ChiTiet();
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            en.IDParent = _scan.ID;
                            en.CreateDate = DateTime.Now;
                            if (_wsThuongVu.ghi_Hinh("DonTu", _scan.DanhBo.ToString() + "." + _scan.CreateDate.ToString("yyyyMMdd"), en.Name + en.Loai, bytes) == true)
                            {
                                _scan.DonTu_Scan_ChiTiets.Add(en);
                                _cDonTu.SubmitChanges();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var index = dgvHinh.Rows.Add();
                                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = en.ID;
                                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = en.Name;
                                dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
                            }
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

        private void dgvHinh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvHinh.CurrentCell = dgvHinh.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvHinh_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvHinh, new Point(e.X, e.Y));
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            byte[] file = _wsThuongVu.get_Hinh("DonTu", _scan.DanhBo.ToString() + "." + _scan.CreateDate.ToString("yyyyMMdd"), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (file != null)
                if (dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString().ToLower().Contains("pdf"))
                    _cDonTu.viewPDF(1, file);
                else
                    _cDonTu.viewImage(file);
            else
                MessageBox.Show("File không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xoaFile_dgvHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_scan != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (dgvHinh.CurrentRow.Cells["ID_Hinh"].Value != null)
                            if (_wsThuongVu.xoa_Hinh("DonTu", _scan.DanhBo.ToString() + "." + _scan.CreateDate.ToString("yyyyMMdd"), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString()) == true)
                            {
                                _scan.DonTu_Scan_ChiTiets.Remove(_scan.DonTu_Scan_ChiTiets.SingleOrDefault(o => o.ID == int.Parse(dgvHinh.CurrentRow.Cells["ID_Hinh"].Value.ToString())));
                                _cDonTu.SubmitChanges();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvHinh.Rows.RemoveAt(dgvHinh.CurrentRow.Index);
                            }
                            else
                                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}
