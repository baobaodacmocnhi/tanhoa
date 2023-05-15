using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.GUI.Doi
{
    public partial class frmKhongTinhPBVMT : Form
    {
        string _mnu = "mnuKhongTinhPBVMT";
        CDanhBoKhongTinhPBVMT _cPBVMT = new CDanhBoKhongTinhPBVMT();
        DanhBoKPBVMT _en = null;

        public frmKhongTinhPBVMT()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            _en = null;
            loaddgv();
        }

        public void loaddgv()
        {
            dgvDanhSach.DataSource = _cPBVMT.getDS();
        }

        public void fillData()
        {
            txtDanhBo.Text = _en.DanhBo;
        }

        private void frmKhongTinhPBVMT_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            loaddgv();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cPBVMT.checkExist(txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", "")) == true)
                    {
                        MessageBox.Show("Danh Bộ tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DanhBoKPBVMT en = new DanhBoKPBVMT();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", "");
                    if (_cPBVMT.them(en) == true)
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cPBVMT.xoa(_en) == true)
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

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _en = _cPBVMT.get(txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", ""));
                fillData();
            }
            catch
            {
            }
        }
    }
}
