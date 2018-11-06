using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using System.Globalization;

namespace ThuTien.GUI.Doi
{
    public partial class frmNiemChi : Form
    {
        string _mnu = "mnuNiemChi";
        CNiemChi _cNiemChi = new CNiemChi();
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        bool _flagFirstLoad = false;

        public frmNiemChi()
        {
            InitializeComponent();
        }

        private void frmNiemChi_Load(object sender, EventArgs e)
        {
            dgvNiemChi_Nhap.AutoGenerateColumns = false;
            dgvNiemChi_Giao.AutoGenerateColumns = false;

            cmbTo_Giao.DataSource = _cTo.GetDSHanhThu();
            cmbTo_Giao.DisplayMember = "TenTo";
            cmbTo_Giao.ValueMember = "MaTo";

            loadNhap();

            cmbTo_Giao.SelectedIndex = -1;
            _flagFirstLoad = true;
        }

        public void loadNhap()
        {
            dgvNiemChi_Nhap.DataSource = _cNiemChi.getDSNhap_Group();
            int SLNhap = 0;
            int SLSuDung = 0;
            int SLTon = 0;
            foreach (DataGridViewRow item in dgvNiemChi_Nhap.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["SLNhap_Nhap"].Value.ToString()))
                    SLNhap += int.Parse(item.Cells["SLNhap_Nhap"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLSuDung_Nhap"].Value.ToString()))
                    SLSuDung += int.Parse(item.Cells["SLSuDung_Nhap"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLTon_Nhap"].Value.ToString()))
                    SLTon += int.Parse(item.Cells["SLTon_Nhap"].Value.ToString());
            }
            txtSLNhap_Nhap.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLNhap);
            txtSLSuDung_Nhap.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLSuDung);
            txtSLTon_Nhap.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLTon);
        }

        private void btnThem_Nhap_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (int.Parse(txtDenSo_Nhap.Text.Trim()) > int.Parse(txtTuSo_Nhap.Text.Trim()))
                    {
                        int TuSo = int.Parse(txtTuSo_Nhap.Text.Trim());
                        int DenSo = int.Parse(txtDenSo_Nhap.Text.Trim());
                        for (int i = TuSo; i <= DenSo; i++)
                        {
                            if (_cNiemChi.checkExist(TuSo) == true)
                            {
                                MessageBox.Show("Mã " + TuSo + " đã có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        string sql = "";
                        for (int i = TuSo; i <= DenSo; i++)
                        {
                            //TT_NiemChi en = new TT_NiemChi();
                            //en.ID = i;
                            //_cNiemChi.Them(en);
                            sql += " insert into TT_NiemChi(ID,CreateBy,CreateDate)values(" + i + "," + CNguoiDung.MaND + ",getDate())";   
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

        private void btnSua_Nhap_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {

            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Nhap_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_cNiemChi.checkGiao(DateTime.Parse(dgvNiemChi_Nhap.CurrentRow.Cells["CreateDate_Nhap"].Value.ToString())) == true)
                    {
                        MessageBox.Show("Niêm Chì đã Giao, Không Xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cNiemChi.checkSuDung(DateTime.Parse(dgvNiemChi_Nhap.CurrentRow.Cells["CreateDate_Nhap"].Value.ToString())) == true)
                    {
                        MessageBox.Show("Niêm Chì đã Sử Dụng, Không Xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //List<TT_NiemChi> lst = _cNiemChi.getDS(DateTime.Parse(dgvNiemChi_Nhap.CurrentRow.Cells["CreateDate"].Value.ToString()));
                    //if (_cNiemChi.Xoa(lst) == true)
                    //{
                    //    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    loadNhap();
                    //}
                    _cNiemChi.SqlBeginTransaction();
                    string sql = "delete TT_NiemChi where cast(CreateDate as date)='" + DateTime.Parse(dgvNiemChi_Nhap.CurrentRow.Cells["CreateDate_Nhap"].Value.ToString()).ToString("yyyyMMdd") + "'";
                    _cNiemChi.ExecuteNonQuery_Transaction(sql);
                    _cNiemChi.SqlCommitTransaction();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _cNiemChi.SqlRollbackTransaction();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtSoLuong_Nhap.Text = (int.Parse(txtDenSo_Nhap.Text.Trim()) - int.Parse(txtTuSo_Nhap.Text.Trim())+1).ToString();
        }

        ////////////////////////////////////

        public void loadGiao()
        {
            dgvNiemChi_Giao.DataSource = _cNiemChi.getDSGiao_Group(dateLap_Giao.Value);
            int SLNhap = 0;
            int SLSuDung = 0;
            int SLTon = 0;
            foreach (DataGridViewRow item in dgvNiemChi_Giao.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["SLNhap_Giao"].Value.ToString()))
                    SLNhap += int.Parse(item.Cells["SLNhap_Giao"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLSuDung_Giao"].Value.ToString()))
                    SLSuDung += int.Parse(item.Cells["SLSuDung_Giao"].Value.ToString());
                if (!string.IsNullOrEmpty(item.Cells["SLTon_Giao"].Value.ToString()))
                    SLTon += int.Parse(item.Cells["SLTon_Giao"].Value.ToString());
            }
            txtSLNhap_Giao.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLNhap);
            txtSLSuDung_Giao.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLSuDung);
            txtSLTon_Giao.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", SLTon);
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
                txtSoLuong_Giao.Text = (int.Parse(txtDenSo_Giao.Text.Trim()) - int.Parse(txtTuSo_Giao.Text.Trim())+1).ToString();
        }

        private void btnXem_Giao_Click(object sender, EventArgs e)
        {
            loadGiao();
        }

        private void btnThem_Giao_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (int.Parse(txtDenSo_Giao.Text.Trim()) > int.Parse(txtTuSo_Giao.Text.Trim()))
                    {
                        if (_cNiemChi.checkSuDung(int.Parse(txtTuSo_Giao.Text.Trim()), int.Parse(txtDenSo_Giao.Text.Trim())) == true)
                        {
                            MessageBox.Show("Niêm Chì đã Sử Dụng, Không Xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cNiemChi.checkGiao(int.Parse(txtTuSo_Giao.Text.Trim()), int.Parse(txtDenSo_Giao.Text.Trim())) == true)
                        {
                            MessageBox.Show("Niêm Chì đã Giao, Không Xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _cNiemChi.SqlBeginTransaction();
                        string sql = "update TT_NiemChi set MaTo=" + cmbTo_Giao.SelectedValue.ToString() + ",MaNV=" + cmbNhanVien_Giao.SelectedValue.ToString() + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getDate() where ID>=" + txtTuSo_Giao.Text.Trim() + " and ID<=" + txtDenSo_Giao.Text.Trim() + " and SuDung=0";
                        //string sql = "update TT_NiemChi set MaTo=" + cmbTo_Giao.SelectedValue.ToString() + ",MaNV=" + cmbNhanVien_Giao.SelectedValue.ToString() + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getDate() where ID>=" + txtTuSo_Giao.Text.Trim() + " and ID<=" + txtDenSo_Giao.Text.Trim();
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

        private void btnSua_Giao_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {

            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Giao_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_cNiemChi.checkSuDung(int.Parse(dgvNiemChi_Giao.CurrentRow.Cells["TuSo_Giao"].Value.ToString()), int.Parse(dgvNiemChi_Giao.CurrentRow.Cells["DenSo_Giao"].Value.ToString())) == true)
                    {
                        MessageBox.Show("Niêm Chì đã Sử Dụng, Không Xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _cNiemChi.SqlBeginTransaction();
                    string sql = "update TT_NiemChi set MaTo=NULL,MaNV=NULL,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getDate() where ID>=" + dgvNiemChi_Giao.CurrentRow.Cells["TuSo_Giao"].Value.ToString() + " and ID<=" + dgvNiemChi_Giao.CurrentRow.Cells["DenSo_Giao"].Value.ToString() + " and SuDung=0";
                    //string sql = "update TT_NiemChi set MaTo=NULL,MaNV=NULL,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getDate() where ID>=" + dgvNiemChi_Giao.CurrentRow.Cells["TuSo_Giao"].Value.ToString() + " and ID<=" + dgvNiemChi_Giao.CurrentRow.Cells["DenSo_Giao"].Value.ToString();
                    _cNiemChi.ExecuteNonQuery_Transaction(sql);
                    _cNiemChi.SqlCommitTransaction();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnXem_Giao.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNiemChi_Giao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNiemChi_Giao["MaTo_Giao", e.RowIndex].Value.ToString() != "")
                    cmbTo_Giao.SelectedValue = dgvNiemChi_Giao["MaTo_Giao", e.RowIndex].Value;
                if (dgvNiemChi_Giao["MaNV_Giao", e.RowIndex].Value.ToString() != "")
                    cmbNhanVien_Giao.SelectedValue = dgvNiemChi_Giao["MaNV_Giao", e.RowIndex].Value;
                txtTuSo_Giao.Text = dgvNiemChi_Giao["TuSo_Giao", e.RowIndex].Value.ToString();
                txtDenSo_Giao.Text = dgvNiemChi_Giao["DenSo_Giao", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void cmbTo_Giao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirstLoad==true&&cmbTo_Giao.Items.Count > 0 && cmbTo_Giao.SelectedIndex > -1)
            {
                List<TT_NguoiDung> lst = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo_Giao.SelectedValue.ToString()));
                cmbNhanVien_Giao.DataSource = lst;
                cmbNhanVien_Giao.DisplayMember = "HoTen";
                cmbNhanVien_Giao.ValueMember = "MaND";
            }
        }


    }
}
