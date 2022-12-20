using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.ToBamChi;
using System.Globalization;
using System.IO;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.ToBamChi
{
    public partial class frmNiemChi : Form
    {
        string _mnu = "mnuNiemChi";
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CNiemChi _cNiemChi = new CNiemChi();

        public frmNiemChi()
        {
            InitializeComponent();
        }

        private void frmNiemChi_Load(object sender, EventArgs e)
        {
            dgvNiemChi_Nhap.AutoGenerateColumns = false;
            dgvNiemChi_Giao.AutoGenerateColumns = false;
            dgvNiemChiTong_Giao.AutoGenerateColumns = false;

            DataTable dt = new DataTable();
            if (CTaiKhoan.Admin == true || CTaiKhoan.TruongPhong == true)
            {
                dt = _cTaiKhoan.getDS_BamChi();
            }
            else
            {
                dt = _cTaiKhoan.getDS_KTXM(CTaiKhoan.KyHieuMaTo);
            }
            cmbNhanVien_Giao.DataSource = dt;
            cmbNhanVien_Giao.DisplayMember = "HoTen";
            cmbNhanVien_Giao.ValueMember = "MaU";
            cmbNhanVien_Chuyen.DataSource = dt;
            cmbNhanVien_Chuyen.DisplayMember = "HoTen";
            cmbNhanVien_Chuyen.ValueMember = "MaU";

            cmbDotChia.SelectedIndex = 0;

            loadNhap();
        }

        public void loadNhap()
        {
            dgvNiemChi_Nhap.DataSource = _cNiemChi.getDSNhap_Group();
            int SLNhap = 0;
            int SLSuDung = 0;
            int SLHuHong = 0;
            int SLTon = 0;
            foreach (DataGridViewRow item in dgvNiemChi_Nhap.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["SLNhap_Nhap"].Value.ToString()))
                    SLNhap += int.Parse(item.Cells["SLNhap_Nhap"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLSuDung_Nhap"].Value.ToString()))
                    SLSuDung += int.Parse(item.Cells["SLSuDung_Nhap"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLHuHong_Nhap"].Value.ToString()))
                    SLHuHong += int.Parse(item.Cells["SLHuHong_Nhap"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLTon_Nhap"].Value.ToString()))
                    SLTon += int.Parse(item.Cells["SLTon_Nhap"].Value.ToString());
            }
            txtSLNhap_Nhap.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLNhap);
            txtSLSuDung_Nhap.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLSuDung);
            txtSLHuHong_Nhap.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLHuHong);
            txtSLTon_Nhap.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLTon);

            dgvNiemChi_HuHong.DataSource = _cNiemChi.getDSHuHong();
        }

        private void btnThem_Nhap_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (int.Parse(txtDenSo_Nhap.Text.Trim()) >= int.Parse(txtTuSo_Nhap.Text.Trim()))
                    {
                        int TuSo = int.Parse(txtTuSo_Nhap.Text.Trim());
                        int DenSo = int.Parse(txtDenSo_Nhap.Text.Trim());
                        for (int i = TuSo; i <= DenSo; i++)
                        {
                            if (_cNiemChi.checkExist(txtKyHieu.Text.Trim().ToUpper() + TuSo.ToString("000000")) == true)
                            {
                                MessageBox.Show("Mã " + TuSo + " đã có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        string sql = "";
                        for (int i = TuSo; i <= DenSo; i++)
                        {
                            //NiemChi en = new NiemChi();
                            //en.ID = i;
                            //_cNiemChi.Them(en);
                            sql += " insert into NiemChi(ID,KyHieu,STT,MauSac,CreateBy,CreateDate)values('" + txtKyHieu.Text.Trim().ToUpper() + i.ToString("000000") + "','" + txtKyHieu.Text.Trim().ToUpper() + "','" + i.ToString("000000") + "',N'" + cmbMauSac.Text + "'," + CTaiKhoan.MaUser + ",getDate())";
                        }
                        _cNiemChi.SqlBeginTransaction();
                        _cNiemChi.ExecuteNonQuery_Transaction(sql);
                        _cNiemChi.SqlCommitTransaction();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadNhap();
                    }
                }
                catch (Exception ex)
                {
                    _cNiemChi.SqlRollbackTransaction();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Nhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cNiemChi.checkGiao(DateTime.Parse(dgvNiemChi_Nhap.CurrentRow.Cells["CreateDate_Nhap"].Value.ToString())) == true)
                        {
                            MessageBox.Show("Niêm Chì đã Giao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cNiemChi.checkSuDung(DateTime.Parse(dgvNiemChi_Nhap.CurrentRow.Cells["CreateDate_Nhap"].Value.ToString())) == true)
                        {
                            MessageBox.Show("Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //List<NiemChi> lst = _cNiemChi.getDS(DateTime.Parse(dgvNiemChi_Nhap.CurrentRow.Cells["CreateDate"].Value.ToString()));
                        //if (_cNiemChi.Xoa(lst) == true)
                        //{
                        //    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    loadNhap();
                        //}
                        _cNiemChi.SqlBeginTransaction();
                        string sql = "delete NiemChi where cast(CreateDate as date)='" + DateTime.Parse(dgvNiemChi_Nhap.CurrentRow.Cells["CreateDate_Nhap"].Value.ToString()).ToString("yyyyMMdd") + "'";
                        _cNiemChi.ExecuteNonQuery_Transaction(sql);
                        _cNiemChi.SqlCommitTransaction();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadNhap();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _cNiemChi.SqlRollbackTransaction();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTuSo_Nhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDenSo_Nhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDenSo_Nhap_TextChanged(object sender, EventArgs e)
        {
            if (txtDenSo_Nhap.Text.Trim() != "" && txtTuSo_Nhap.Text.Trim() != "")
                txtSoLuong_Nhap.Text = (int.Parse(txtDenSo_Nhap.Text.Trim()) - int.Parse(txtTuSo_Nhap.Text.Trim()) + 1).ToString();
        }

        ////////////////////////////////////

        public void loadGiao()
        {
            dgvNiemChi_Giao.DataSource = _cNiemChi.getDSGiao_Group(dateLap_Giao.Value);
            int SLNhap = 0;
            int SLSuDung = 0;
            int SLHuHong = 0;
            int SLTon = 0;
            foreach (DataGridViewRow item in dgvNiemChi_Giao.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["SLNhap_Giao"].Value.ToString()))
                    SLNhap += int.Parse(item.Cells["SLNhap_Giao"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLSuDung_Giao"].Value.ToString()))
                    SLSuDung += int.Parse(item.Cells["SLSuDung_Giao"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLHuHong_Giao"].Value.ToString()))
                    SLHuHong += int.Parse(item.Cells["SLHuHong_Giao"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLTon_Giao"].Value.ToString()))
                    SLTon += int.Parse(item.Cells["SLTon_Giao"].Value.ToString());
            }
            txtSLNhap_Giao.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLNhap);
            txtSLSuDung_Giao.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLSuDung);
            txtSLHuHong_Giao.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLHuHong);
            txtSLTon_Giao.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLTon);

            dgvNiemChiTong_Giao.DataSource = _cNiemChi.getDSGiao_GroupTong(dateLap_Giao.Value);
        }

        private void btnXem_Giao_Click(object sender, EventArgs e)
        {
            loadGiao();
        }

        private void btnThem_Giao_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (int.Parse(txtDenSo_Giao.Text.Trim()) >= int.Parse(txtTuSo_Giao.Text.Trim()))
                    {
                        if (_cNiemChi.checkSuDung(txtKyHieu_Giao.Text.Trim().ToUpper(), int.Parse(txtTuSo_Giao.Text.Trim()), int.Parse(txtDenSo_Giao.Text.Trim())) == true)
                        {
                            MessageBox.Show("Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cNiemChi.checkGiao(txtKyHieu_Giao.Text.Trim().ToUpper(), int.Parse(txtTuSo_Giao.Text.Trim()), int.Parse(txtDenSo_Giao.Text.Trim())) == true)
                        {
                            MessageBox.Show("Niêm Chì đã Giao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _cNiemChi.SqlBeginTransaction();
                        string sql = "update NiemChi set MaNV=" + cmbNhanVien_Giao.SelectedValue.ToString() + ",DotChia=" + cmbDotChia.SelectedItem.ToString() + ",ModifyBy=" + CTaiKhoan.MaUser + ",ModifyDate=getDate() where KyHieu='" + txtKyHieu_Giao.Text.Trim().ToUpper() + "' and STT>=" + txtTuSo_Giao.Text.Trim() + " and STT<=" + txtDenSo_Giao.Text.Trim() + " and SuDung=0";
                        _cNiemChi.ExecuteNonQuery_Transaction(sql);
                        _cNiemChi.SqlCommitTransaction();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXem_Giao.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    _cNiemChi.SqlRollbackTransaction();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Giao_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cNiemChi.checkSuDung(dgvNiemChi_Giao.CurrentRow.Cells["KyHieu_Giao"].Value.ToString(), int.Parse(dgvNiemChi_Giao.CurrentRow.Cells["TuSo_Giao"].Value.ToString()), int.Parse(dgvNiemChi_Giao.CurrentRow.Cells["DenSo_Giao"].Value.ToString())) == true)
                        {
                            MessageBox.Show("Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _cNiemChi.SqlBeginTransaction();
                        string sql = "update NiemChi set MaNV=NULL,DotChia=NULL,ModifyBy=" + CTaiKhoan.MaUser + ",ModifyDate=getDate() where KyHieu='" + txtKyHieu_Giao.Text.Trim().ToUpper() + "' and STT>=" + dgvNiemChi_Giao.CurrentRow.Cells["TuSo_Giao"].Value.ToString() + " and STT<=" + dgvNiemChi_Giao.CurrentRow.Cells["DenSo_Giao"].Value.ToString() + " and SuDung=0";
                        _cNiemChi.ExecuteNonQuery_Transaction(sql);
                        _cNiemChi.SqlCommitTransaction();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXem_Giao.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _cNiemChi.SqlRollbackTransaction();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTuSo_Giao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDenSo_Giao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDenSo_Giao_TextChanged(object sender, EventArgs e)
        {
            if (txtDenSo_Giao.Text.Trim() != "" && txtTuSo_Giao.Text.Trim() != "")
                txtSoLuong_Giao.Text = (int.Parse(txtDenSo_Giao.Text.Trim()) - int.Parse(txtTuSo_Giao.Text.Trim()) + 1).ToString();
        }

        private void dgvNiemChiTong_Giao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNiemChiTon.Text = _cNiemChi.getDSNiemChiTon(int.Parse(dgvNiemChiTong_Giao["MaNV_Tong_Giao", e.RowIndex].Value.ToString()));
            }
            catch (Exception)
            {
            }
        }

        byte[] _imgHuHong = null;
        private void btnChonFile_HuHong_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.jpg)|*.jpeg";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(dialog.FileName);
                _imgHuHong = new byte[fs.Length];
                fs.Read(_imgHuHong, 0, (int)fs.Length);
            }
        }

        private void btnThem_HuHong_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    NiemChi en = _cNiemChi.get(txtID_HuHong.Text.Trim().ToUpper());
                    if (en != null)
                    {
                        if (en.MaNV == null)
                        {
                            MessageBox.Show("Niêm Chì chưa Giao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (en.SuDung == true)
                        {
                            MessageBox.Show("Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (en.HuHong == true)
                        {
                            MessageBox.Show("Niêm Chì đã Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_imgHuHong != null)
                            en.imgHuHong = _imgHuHong;
                        en.HuHong = true;
                        if (_cNiemChi.Sua(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _imgHuHong = null;
                            dgvNiemChi_HuHong.DataSource = _cNiemChi.getDSHuHong();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_HuHong_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    NiemChi en = _cNiemChi.get(dgvNiemChi_HuHong.CurrentRow.Cells["ID_HuHong"].Value.ToString());
                    if (en != null)
                    {
                        en.imgHuHong = null;
                        en.HuHong = false;
                        if (_cNiemChi.Sua(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _imgHuHong = null;
                            dgvNiemChi_HuHong.DataSource = _cNiemChi.getDSHuHong();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNiemChi_Nhap_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNiemChi_Nhap.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNiemChi_Giao_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNiemChi_Giao.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNiemChiTong_Giao_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNiemChiTong_Giao.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNiemChi_HuHong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNiemChi_HuHong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    NiemChi en = _cNiemChi.get(txtID_Chuyen.Text.Trim().ToUpper());
                    if (en != null)
                    {
                        if (en.MaNV == null)
                        {
                            MessageBox.Show("Niêm Chì chưa Giao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (en.SuDung == true)
                        {
                            MessageBox.Show("Niêm Chì đã Sử Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (en.HuHong == true)
                        {
                            MessageBox.Show("Niêm Chì đã Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        en.MaNV = int.Parse(cmbNhanVien_Chuyen.SelectedValue.ToString());
                        if (_cNiemChi.Sua(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNiemChi_Giao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNiemChi_Giao["MaNV_Giao", e.RowIndex].Value.ToString() != "")
                    cmbNhanVien_Giao.SelectedValue = dgvNiemChi_Giao["MaNV_Giao", e.RowIndex].Value;
                if (dgvNiemChi_Giao["DotChia_Giao", e.RowIndex].Value.ToString() != "")
                    cmbDotChia.SelectedValue = dgvNiemChi_Giao["DotChia_Giao", e.RowIndex].Value;
                txtKyHieu_Giao.Text = dgvNiemChi_Giao["KyHieu_Giao", e.RowIndex].Value.ToString();
                txtTuSo_Giao.Text = dgvNiemChi_Giao["TuSo_Giao", e.RowIndex].Value.ToString();
                txtDenSo_Giao.Text = dgvNiemChi_Giao["DenSo_Giao", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }



    }
}
