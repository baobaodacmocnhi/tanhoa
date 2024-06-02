using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;

namespace DocSo_PC.GUI.QuanTri
{
    public partial class frmNhanVienDocSo : Form
    {
        string _mnu = "mnuNhanVienDocSo";
        CMayDS _cMayDS = new CMayDS();
        CTo _cTo = new CTo();
        MayD _may = null;
        bool _flagLoad = false;

        public frmNhanVienDocSo()
        {
            InitializeComponent();
        }

        private void frmNhanVienDocSo_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            if (CNguoiDung.Admin)
            {
                panel1.Visible = true;
                cmbPhong.DataSource = _cTo.getDS_Phong();
                cmbPhong.DisplayMember = "Name";
                cmbPhong.ValueMember = "ID";
            }
            else
            {
                panel1.Visible = false;
                cmbTo.DataSource = _cTo.getDS_HanhThu(CNguoiDung.IDPhong);
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            cmbTo.SelectedIndex = -1;
        }

        public void Clear()
        {
            txtMay.Text = "";
            cmbTo.SelectedIndex = -1;
            _may = null;
            dgvDanhSach.DataSource = _cMayDS.getDS(int.Parse(cmbTo.SelectedValue.ToString()));
        }

        public void fill()
        {
            try
            {
                txtMay.Text = _may.May;
                cmbTo.SelectedValue = _may.MaTo.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _may = _cMayDS.get(dgvDanhSach.CurrentRow.Cells["May"].Value.ToString());
                fill();
            }
            catch
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (cmbTo.SelectedIndex > -1)
                    {
                        MayD en = new MayD();
                        en.May = int.Parse(txtMay.Text.Trim()).ToString("00");
                        en.MaTo = int.Parse(cmbTo.SelectedValue.ToString());
                        if (_cMayDS.them(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_may != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cMayDS.xoa(_may) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_may != null)
                    {
                        _may.MaTo = int.Parse(cmbTo.SelectedValue.ToString());
                        if (_cMayDS.sua(_may) == true)
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

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTo.Items.Count > 0 && cmbTo.SelectedIndex > -1 && _flagLoad == false)
                    dgvDanhSach.DataSource = _cMayDS.getDS(int.Parse(cmbTo.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                _flagLoad = true;
                cmbTo.DataSource = _cTo.getDS_HanhThu(int.Parse(cmbPhong.SelectedValue.ToString()));
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
                cmbTo.SelectedIndex = -1;
                _flagLoad = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
