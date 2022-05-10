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
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCapDinhMucNuocCCCD : Form
    {
        string _mnu = "mnuCapDinhMucNuocCCCD";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CDangKyDinhMucCCCD _cDKDM = new CDangKyDinhMucCCCD();
        CDHN _cDHN = new CDHN();
        HOADON _hoadon = null;
        DCBD_DKDM_DanhBo _danhbo = null;
        bool _flag = false;

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
            chkNhaTro.Checked = false;
            txtMaDon.Text = "";
            dgvDanhSach.Rows.Clear();
            _hoadon = null;
            _danhbo = null;
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
                        en.NhaTro = chkNhaTro.Checked;
                        en.MaDon = txtMaDon.Text.Trim();
                        foreach (DataGridViewRow item in dgvDanhSach.Rows)
                            if (item.Cells["CCCD"].Value != null && item.Cells["CCCD"].Value.ToString() != "")
                            {
                                DCBD_DKDM_CCCD enCT = new DCBD_DKDM_CCCD();
                                enCT.CCCD = item.Cells["CCCD"].Value.ToString();
                                enCT.HoTen = item.Cells["HoTen"].Value.ToString();
                                string[] NgaySinhs = item.Cells["NgaySinh"].Value.ToString().Split('/');
                                if (NgaySinhs.Count() == 3)
                                {
                                    enCT.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_danhbo != null)
                    {
                        _danhbo.DanhBo = txtDanhBo.Text.Trim();
                        _danhbo.SDT = txtDienThoai.Text.Trim();
                        _danhbo.ChungTu = chkChungTu.Checked;
                        _danhbo.NhaTro = chkNhaTro.Checked;
                        _danhbo.MaDon = txtMaDon.Text.Trim();
                        foreach (DataGridViewRow item in dgvDanhSach.Rows)
                            if (item.Cells["ID"].Value != null && item.Cells["ID"].Value.ToString() != "")
                            {
                                _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).CCCD = item.Cells["CCCD"].Value.ToString();
                                _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).HoTen = item.Cells["HoTen"].Value.ToString();
                                string[] NgaySinhs = item.Cells["NgaySinh"].Value.ToString().Split('/');
                                if (NgaySinhs.Count() == 3)
                                {
                                    _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                }
                                else
                                    _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).NgaySinh = new DateTime(int.Parse(item.Cells["NgaySinh"].Value.ToString()), 1, 1);
                                if (item.Cells["DCThuongTru"].Value != null && item.Cells["DCThuongTru"].Value.ToString() != "")
                                    _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).DCThuongTru = item.Cells["DCThuongTru"].Value.ToString();
                                if (item.Cells["DCTamTru"].Value != null && item.Cells["DCTamTru"].Value.ToString() != "")
                                    _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).DCTamTru = item.Cells["DCTamTru"].Value.ToString();
                                _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).ModifyBy = CTaiKhoan.MaUser;
                                _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(o => o.ID == int.Parse(item.Cells["ID"].Value.ToString())).ModifyDate = DateTime.Now;
                            }
                        if (_cDKDM.Sua(_danhbo))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                LinQ.DonTu dontu = _cDonTu.get(int.Parse(txtMaDon.Text.Trim()));
                if (dontu != null)
                {
                    _hoadon = _cThuTien.GetMoiNhat(dontu.DonTu_ChiTiets.SingleOrDefault().DanhBo);
                    if (_hoadon != null)
                    {
                        txtDanhBo.Text = _hoadon.DANHBA;
                        txtHoTen.Text = _hoadon.TENKH;
                        txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG;
                        txtDienThoai.Text = dontu.DienThoai;
                        txtDienThoai.Focus();
                    }
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtDienThoai.Text.Trim() != "" && txtDienThoai.Text.Trim().Length != 10 && txtDienThoai.Text.Trim().Length != 11)
                {
                    MessageBox.Show("Điện thoại phải 10 hoặc 11 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtSoNK.Focus();
            }
        }

        private void txtSoNK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dgvDanhSach.Focus();
        }

        private void dgvDanhSach_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (_danhbo != null && e.Row.Cells["ID"].Value != null && e.Row.Cells["ID"].Value.ToString() != "")
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                    {
                        DCBD_DKDM_CCCD en = _danhbo.DCBD_DKDM_CCCDs.SingleOrDefault(item => item.ID == int.Parse(e.Row.Cells["ID"].Value.ToString()));
                        if (_cDKDM.XoaCT(en))
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_flag == false && dgvDanhSach.Columns[e.ColumnIndex].Name == "CCCD" && dgvDanhSach["CCCD", e.RowIndex].Value.ToString() != "")
            {
                if (dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Trim().Length != 9 && dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Trim().Length != 12)
                {
                    MessageBox.Show("CMND=9 số hoặc CCCD=12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Thung = "";
                if (_cDKDM.checkExists(dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Trim(), out Thung) == true)
                {
                    MessageBox.Show("CCCD đã tồn tại\n" + Thung, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //

        private void txtDanhBo_DS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo_DS.Text.Trim() != "")
                btnXem.PerformClick();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (txtDanhBo_DS.Text.Trim() != "")
                dgvDanhSach2.DataSource = _cDKDM.getDS(txtDanhBo_DS.Text.Trim());
            else
                if (CTaiKhoan.TruongPhong || CTaiKhoan.Admin || CTaiKhoan.ThuKy)
                    dgvDanhSach2.DataSource = _cDKDM.getDS(dateTu.Value, dateDen.Value);
                else
                    dgvDanhSach2.DataSource = _cDKDM.getDS(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
        }

        private void dgvDanhSach2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                _flag = true;
                Clear();
                _danhbo = _cDKDM.get(int.Parse(dgvDanhSach2["ID_DS", e.RowIndex].Value.ToString()));
                if (_danhbo != null)
                {
                    txtDanhBo.Text = _danhbo.DanhBo;
                    txtDienThoai.Text = _danhbo.SDT;
                    txtSoNK.Text = _danhbo.DCBD_DKDM_CCCDs.Count.ToString();
                    txtMaDon.Text = _danhbo.MaDon;
                    chkChungTu.Checked = _danhbo.ChungTu;
                    chkNhaTro.Checked = _danhbo.NhaTro;
                    dgvDanhSach.Rows.Clear();
                    foreach (DCBD_DKDM_CCCD item in _danhbo.DCBD_DKDM_CCCDs.ToList())
                    {
                        var index = dgvDanhSach.Rows.Add();
                        dgvDanhSach.Rows[index].Cells["ID"].Value = item.ID;
                        dgvDanhSach.Rows[index].Cells["HoTen"].Value = item.HoTen;
                        dgvDanhSach.Rows[index].Cells["NgaySinh"].Value = item.NgaySinh.Value.ToString("dd/MM/yyyy");
                        dgvDanhSach.Rows[index].Cells["DCThuongTru"].Value = item.DCThuongTru;
                        dgvDanhSach.Rows[index].Cells["DCTamTru"].Value = item.DCTamTru;
                        dgvDanhSach.Rows[index].Cells["CCCD"].Value = item.CCCD;
                    }
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                    _flag = false;
                }
            }
            catch
            {
            }
        }

        private void dgvDanhSach2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void frmCapDinhMucNuocCCCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
                if (e.Control && e.KeyCode == Keys.T)
                {
                    btnThem.PerformClick();
                }
        }

        private void btnDCBD_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen("mnuDCBD", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

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

        //

        private void txtDanhBo_Online_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo_Online.Text.Trim() != "")
                btnXem.PerformClick();
        }

        private void btnXem_Online_Click(object sender, EventArgs e)
        {
            if (txtDanhBo_Online.Text.Trim() != "")
                dgvDanhSach_Online.DataSource = _cDKDM.getDS_Online(txtDanhBo_Online.Text.Trim());
            else
                dgvDanhSach_Online.DataSource = _cDKDM.getDS_Online(dateTu_Online.Value, dateDen_Online.Value);
        }

        private void dgvDanhSach_Online_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach_Online.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_Online_Click(object sender, EventArgs e)
        {
            try
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataGridViewRow item in dgvDanhSach_Online.Rows)
                {
                    DCBD_DKDM_DanhBo en = _cDKDM.get(int.Parse(item.Cells["ID_Online"].Value.ToString()));
                    HOADON hd = _cThuTien.GetMoiNhat(en.DanhBo);
                    foreach (DCBD_DKDM_CCCD itemCT in en.DCBD_DKDM_CCCDs)
                    {
                        DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();
                        dr["SoPhieu"] = en.ID;
                        dr["DanhBo"] = en.DanhBo;
                        dr["HoTen"] = hd.TENKH;
                        dr["DiaChi"] = hd.SO + " " + hd.DUONG + _cDHN.GetPhuongQuan(hd.Quan, hd.Phuong); ;
                        dr["HopDong"] = en.SDT;
                        dr["DinhMuc"] = en.DCBD_DKDM_CCCDs.Count * 4;
                        dr["MSThue"] = itemCT.DCThuongTru;
                        dr["MSThueBD"] = itemCT.DCTamTru;
                        dr["GiaBieu"] = itemCT.NgaySinh.Value.ToString("dd/MM/yyyy");
                        dr["DinhMucHN"] = itemCT.CCCD;
                        dr["HoTenBD"] = itemCT.HoTen;
                        dr["MaQuanPhuong"] = hd.Quan;
                        dsBaoCao.Tables["DCBD"].Rows.Add(dr);
                    }
                }
                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);
                if (dsBaoCao.Tables["DCBD"].Rows.Count > 0)
                {
                    rptDKDM_CCCD rpt = new rptDKDM_CCCD();
                    rpt.SetDataSource(dsBaoCao);
                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
