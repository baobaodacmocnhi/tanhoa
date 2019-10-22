using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ToTruong;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmGhiChu : Form
    {
        string _mnu = "mnuGhiChu";
        CGhiChu _cGhiChu = new CGhiChu();
        TT_GhiChu _ghichu = null;

        public frmGhiChu()
        {
            InitializeComponent();
        }

        private void frmGhiChu_Load(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtDanhBo.Text ="";
            txtDienThoai.Text = "";
            txtGiaBieu.Text = "";
            txtNiemChi.Text = "";
            txtDiemBe.Text = "";
            _ghichu = null;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
            {
                _ghichu = _cGhiChu.get(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_ghichu != null)
                {
                    txtDanhBo.Text = _ghichu.DanhBo;
                    txtDienThoai.Text = _ghichu.DienThoai;
                    txtGiaBieu.Text = _ghichu.GiaBieu;
                    txtNiemChi.Text = _ghichu.NiemChi;
                    txtDiemBe.Text = _ghichu.DiemBe;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_ghichu == null)
                    {
                        TT_GhiChu en = new TT_GhiChu();
                        en.DanhBo = txtDanhBo.Text.Trim();
                        en.DienThoai = txtDienThoai.Text.Trim();
                        en.GiaBieu = txtGiaBieu.Text.Trim();
                        en.NiemChi = txtNiemChi.Text.Trim();
                        en.DiemBe = txtDiemBe.Text.Trim();
                        if (_cGhiChu.Them(en) == true)
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _ghichu.DienThoai = txtDienThoai.Text.Trim();
                        _ghichu.GiaBieu = txtGiaBieu.Text.Trim();
                        _ghichu.NiemChi = txtNiemChi.Text.Trim();
                        _ghichu.DiemBe = txtDiemBe.Text.Trim();
                        if (_cGhiChu.Sua(_ghichu) == true)
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
