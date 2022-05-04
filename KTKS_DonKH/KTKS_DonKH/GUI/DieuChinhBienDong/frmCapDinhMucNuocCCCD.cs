using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using System.Globalization;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCapDinhMucNuocCCCD : Form
    {
        string _mnu = "mnuCapDinhMucNuocCCCD";
        CThuTien _cThuTien = new CThuTien();
        CDangKyDinhMucCCCD _cDKDM = new CDangKyDinhMucCCCD();
        HOADON _hoadon = null;

        public frmCapDinhMucNuocCCCD()
        {
            InitializeComponent();
        }

        private void frmCapDinhMucNuocCCCD_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach2.AutoGenerateColumns = false;
            dgvDanhSach_Online.AutoGenerateColumns = false;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtSoNK.Text = "";
            chkChungTu.Checked = false;
            dgvDanhSach.Rows.Clear();
            _hoadon = null;
            txtDanhBo.Focus();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                if (_hoadon != null)
                {
                    txtDanhBo.Text = _hoadon.DANHBA;
                    txtHoTen.Text = _hoadon.TENKH;
                    txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG;
                    txtDienThoai.Focus();
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (_hoadon != null)
                    {
                        DCBD_DKDM_DanhBo en = new DCBD_DKDM_DanhBo();
                        en.DanhBo = txtDanhBo.Text.Trim();
                        en.SDT = txtDienThoai.Text.Trim();
                        en.Quan = _hoadon.Quan;
                        en.ChungTu = chkChungTu.Checked;
                        foreach (DataGridViewRow item in dgvDanhSach.Rows)
                            if (item.Cells["CCCD"].Value != null && item.Cells["CCCD"].Value.ToString() != "")
                            {
                                DCBD_DKDM_CCCD enCT = new DCBD_DKDM_CCCD();
                                enCT.CCCD = item.Cells["CCCD"].Value.ToString();
                                enCT.HoTen = item.Cells["HoTen"].Value.ToString();
                                string[] NgaySinhs = item.Cells["NgaySinh"].Value.ToString().Split('/');
                                if (NgaySinhs.Count() == 3)
                                {
                                    IFormatProvider culture = new CultureInfo("en-US", true);
                                    enCT.NgaySinh = DateTime.ParseExact(item.Cells["NgaySinh"].Value.ToString(), "dd/MM/yyyy", culture);
                                }
                                else
                                    enCT.NgaySinh = new DateTime(int.Parse(item.Cells["NgaySinh"].Value.ToString()), 1, 1);
                                if (item.Cells["DCThuongTru"].Value != null && item.Cells["DCThuongTru"].Value.ToString() != "")
                                    enCT.DCThuongTru = item.Cells["DCThuongTru"].Value.ToString();
                                if (item.Cells["DCTamTru"].Value != null && item.Cells["DCTamTru"].Value.ToString() != "")
                                    enCT.DCTamTru = item.Cells["DCTamTru"].Value.ToString();
                                enCT.CreateBy = CTaiKhoan.MaUser;
                                enCT.CreateDate = DateTime.Now;
                                en.DCBD_DKDM_CCCDs.Add(enCT);
                            }
                        string Thung = "";
                        if (_cDKDM.Them(en, out Thung))
                        {
                            MessageBox.Show("Thành công\n" + Thung, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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

        private void txtSoNK_TextChanged(object sender, EventArgs e)
        {
            //if (txtSoNK.Text.Trim() != "" && txtSoNK.Text.Trim().All(char.IsDigit))
            //{
            //    int count = int.Parse(txtSoNK.Text.Trim());
            //    dgvDanhSach.Rows.Clear();
            //    dgvDanhSach.Rows.Add(count);
            //    for (int i = 0; i < count; i++)
            //    {
            //        dgvDanhSach["STT", i].Value = i + 1;
            //    }
            //}
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "CCCD" && dgvDanhSach["CCCD", e.RowIndex].Value.ToString() != "")
            {
                if (dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Trim().Length != 9 && dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Trim().Length != 12)
                {
                    MessageBox.Show("CMND=9 số hoặc CCCD=12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_cDKDM.checkExists(dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Trim()) == true)
                {
                    MessageBox.Show("CCCD đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.TruongPhong || CTaiKhoan.Admin)
                dgvDanhSach2.DataSource = _cDKDM.getDS(dateTu.Value, dateDen.Value);
            else
                dgvDanhSach2.DataSource = _cDKDM.getDS(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
        }

        private void btnXem_Online_Click(object sender, EventArgs e)
        {
            dgvDanhSach_Online.DataSource = _cDKDM.getDS_Online(dateTu_Online.Value, dateDen_Online.Value);
        }

        private void dgvDanhSach_Online_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach_Online.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtDienThoai.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Điện thoại phải 10 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtSoNK.Focus();
            }
        }

        private void dgvDanhSach_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach["HoTen", e.RowIndex].Value != null && dgvDanhSach["HoTen", e.RowIndex].Value.ToString() != "")
                if (e.RowIndex < dgvDanhSach.RowCount - 1)
                {
                    if ((dgvDanhSach["DCThuongTru", e.RowIndex].Value != null && dgvDanhSach["DCThuongTru", e.RowIndex].Value.ToString() != "")
                        && (dgvDanhSach["DCThuongTru", e.RowIndex + 1].Value == null || dgvDanhSach["DCThuongTru", e.RowIndex + 1].Value.ToString() == ""))
                        dgvDanhSach["DCThuongTru", e.RowIndex + 1].Value = dgvDanhSach["DCThuongTru", e.RowIndex].Value;
                    if ((dgvDanhSach["DCTamTru", e.RowIndex].Value != null && dgvDanhSach["DCTamTru", e.RowIndex].Value.ToString() != "")
                        && (dgvDanhSach["DCTamTru", e.RowIndex + 1].Value == null || dgvDanhSach["DCTamTru", e.RowIndex + 1].Value.ToString() == ""))
                        dgvDanhSach["DCTamTru", e.RowIndex + 1].Value = dgvDanhSach["DCTamTru", e.RowIndex].Value;
                }
        }

        private void txtSoNK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dgvDanhSach.Focus();
        }

        private void frmCapDinhMucNuocCCCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
                if (e.Control && e.KeyCode == Keys.T)
                {
                    btnThem.PerformClick();
                }
        }

    }
}
