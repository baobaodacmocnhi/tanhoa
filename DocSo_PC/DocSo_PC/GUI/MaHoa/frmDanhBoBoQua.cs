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
using DocSo_PC.DAL.MaHoa;

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmDanhBoBoQua : Form
    {
        string _mnu = "mnuDanhBoBoQua";
        CDanhBoBoQua _cDBBQ = new CDanhBoBoQua();
        MaHoa_DanhBo_Except _danhbo = null;

        public frmDanhBoBoQua()
        {
            InitializeComponent();
        }

        private void frmDanhBoBoQua_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            _danhbo = null;
            dgvDanhSach.DataSource = _cDBBQ.getDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "").Length == 11
                        && !_cDBBQ.checkExist(txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "")))
                    {
                        MaHoa_DanhBo_Except en = new MaHoa_DanhBo_Except();
                        en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "");
                        en.NoiDung = txtNoiDung.Text.Trim();
                        if (_cDBBQ.Them(en))
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
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_danhbo != null)
                        {
                            if (_cDBBQ.Xoa(_danhbo))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
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

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _danhbo = _cDBBQ.get(dgvDanhSach.Rows[e.RowIndex].Cells["DanhBo"].Value.ToString());
                if (_danhbo != null)
                {
                    txtDanhBo.Text = _danhbo.DanhBo;
                    txtNoiDung.Text = _danhbo.NoiDung;
                }
            }
            catch { }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_danhbo != null)
                        {
                            _danhbo.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "");
                            _danhbo.NoiDung = txtNoiDung.Text.Trim();
                            _cDBBQ.SubmitChanges();
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
    }
}
