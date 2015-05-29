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

namespace ThuTien.GUI.Doi
{
    public partial class frmKetThucNamTaiKhoa : Form
    {
        string _fileName = "";
        string _mnu = "mnuLuuHD";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CHoaDon _cHoaDon = new CHoaDon();
        CHoaDonTon _cHoaDonTon = new CHoaDonTon();

        public frmKetThucNamTaiKhoa()
        {
            InitializeComponent();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.dat)|*.dat";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.FileName;
                _fileName = dialog.SafeFileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtDuongDan.Text.Trim() != "" && _fileName.Length == 12)
                {
                    if (_cHoaDonTon.Them(txtDuongDan.Text.Trim()))
                    {
                        txtDuongDan.Text = "";
                        _fileName = "";
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
    }
}
