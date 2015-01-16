using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.Quay
{
    public partial class frmDangNganQuay : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        string _mnu = "mnuDangNganQuay";

        public frmDangNganQuay()
        {
            InitializeComponent();
        }

        private void frmDangNganQuay_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSoHoaDon.Text.Trim() != "" && e.KeyChar == 13)
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSBySoHoaDon_Quay(txtSoHoaDon.Text.Trim());
            }
        }

        private void txtSoPhatHanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSoPhatHanh.Text.Trim() != "" && e.KeyChar == 13)
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSBySoPhatHanh_Quay(decimal.Parse(txtSoPhatHanh.Text.Trim()));
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                ///Có nhiều hơn 1 hóa đơn
                if (dgvHoaDon.RowCount > 1)
                {
                    ///Kiểm tra có chọn hóa đơn đăng ngân chưa
                    int Count = 0;
                    int index = -1;
                    for (int i = 0; i < dgvHoaDon.RowCount;i++ )
                    {
                        if (bool.Parse(dgvHoaDon["Chon", i].Value.ToString()))
                        {
                            Count++;
                            index = i;
                        }
                    }
                    if (Count == 0)
                    {
                        MessageBox.Show("Chưa chọn Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        if (Count > 1)
                        {
                            MessageBox.Show("Chọn quá 1 Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    if (string.IsNullOrEmpty(dgvHoaDon["NgayGiaiTrach", index].Value.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn đã đăng ngân rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ///Bắt đầu đăng ngân chỉ 1 hóa đơn được chọn
                    _cHoaDon.SqlBeginTransaction();
                    try
                    {
                        if (bool.Parse(dgvHoaDon["Chon", index].Value.ToString()))
                            if (!_cHoaDon.DangNgan("Quay", dgvHoaDon["SoHoaDon", index].ToString(), CNguoiDung.MaND, int.Parse(dgvHoaDon["Nam", index].ToString()), int.Parse(dgvHoaDon["Ky", index].ToString()), int.Parse(dgvHoaDon["Dot", index].ToString())))
                            {
                                _cHoaDon.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        _cHoaDon.SqlCommitTransaction();
                        if (txtSoHoaDon.Text.Trim() != "")
                            dgvHoaDon.DataSource = _cHoaDon.GetDSBySoHoaDon_Quay(txtSoHoaDon.Text.Trim());
                        else
                            if (txtSoPhatHanh.Text.Trim() != "")
                                dgvHoaDon.DataSource = _cHoaDon.GetDSBySoPhatHanh_Quay(decimal.Parse(txtSoPhatHanh.Text.Trim()));
                    }
                    catch (Exception)
                    {
                        _cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    ///Có 1 hóa đơn nên set mặc định row 0
                    if (dgvHoaDon.RowCount == 1)
                    {
                        if (string.IsNullOrEmpty(dgvHoaDon["NgayGiaiTrach", 0].Value.ToString()))
                        {
                            MessageBox.Show("Hóa Đơn đã đăng ngân rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _cHoaDon.SqlBeginTransaction();
                        try
                        {
                            if (!_cHoaDon.DangNgan("Quay", dgvHoaDon["SoHoaDon", 0].Value.ToString(),
                                CNguoiDung.MaND, int.Parse(dgvHoaDon["Nam", 0].Value.ToString()), int.Parse(dgvHoaDon["Ky", 0].Value.ToString()), int.Parse(dgvHoaDon["Dot", 0].Value.ToString())))
                            {
                                _cHoaDon.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            _cHoaDon.SqlCommitTransaction();
                        }
                        catch (Exception)
                        {
                            _cHoaDon.SqlRollbackTransaction();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Chưa có thông tin Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tabControl_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabThongTin")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
            }
            if (tabControl.SelectedTab.Name == "tabDSDangNgan")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                dgvDSDangNgan.DataSource = _cHoaDon.GetDSDangNganQuayByMaNVNgayGiaiTrachs(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }


    }
}
