using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeToan.DAL.CapNhat;
using KeToan.LinQ;
using KeToan.DAL.QuanTri;

namespace KeToan.GUI.CapNhat
{
    public partial class frmDoiTuong : Form
    {
        string _mnu = "mnuDoiTuong";
        CDoiTuong _cDoiTuong = new CDoiTuong();
        DoiTuong _doituong = null;

        public frmDoiTuong()
        {
            InitializeComponent();
        }

        private void frmDoiTuong_Load(object sender, EventArgs e)
        {
            dgvDoiTuong.AutoGenerateColumns = false;
            dgvDoiTuong.DataSource = _cDoiTuong.GetDS();
        }

        public void Clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDiaChi.Text = "";
            txtNoiDung.Text = "";
            _doituong = null;
            dgvDoiTuong.DataSource = _cDoiTuong.GetDS();
        }

        public void LoadEntity(DoiTuong entity)
        {
            txtID.Text = entity.ID.ToString();
            txtName.Text = entity.Name;
            txtDiaChi.Text = entity.DiaChi;
            txtNoiDung.Text = entity.NoiDung;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    DoiTuong doituong = new DoiTuong();
                    doituong.ID = int.Parse(txtID.Text.Trim());
                    doituong.Name = txtName.Text.Trim();
                    doituong.DiaChi = txtDiaChi.Text.Trim();
                    doituong.NoiDung = txtNoiDung.Text.Trim();

                    if (_cDoiTuong.Them(doituong))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
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
                if (CUser.CheckQuyen(_mnu, "Sua"))
                {
                    if (_doituong != null)
                    {
                        _doituong.Name = txtName.Text.Trim();
                        _doituong.DiaChi = txtDiaChi.Text.Trim();
                        _doituong.NoiDung = txtNoiDung.Text.Trim();

                        if (_cDoiTuong.Sua(_doituong))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Đối Tượng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CUser.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_doituong != null)
                        {
                            if (_cDoiTuong.Xoa(_doituong))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                        }
                        else
                            MessageBox.Show("Lỗi, Vui lòng chọn Đối Tượng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDoiTuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _doituong = _cDoiTuong.Get(int.Parse(dgvDoiTuong.CurrentRow.Cells["ID"].Value.ToString()));
                LoadEntity(_doituong);
            }
            catch (Exception)
            {
            }
        }

        private void dgvDoiTuong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDoiTuong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
