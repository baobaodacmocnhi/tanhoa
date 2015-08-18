using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.TongHop;

namespace ThuTien.GUI.TongHop
{
    public partial class frmShowChuyenNoKhoDoi : Form
    {
        string _DanhBo;
        decimal _MaCNKD;
        TT_ChuyenNoKhoDoi _cnkd = null;
        YeuCauCHDB _ycch = null;
        CChuyenNoKhoDoi _cCNKD = new CChuyenNoKhoDoi();

        public frmShowChuyenNoKhoDoi(string DanhBo, decimal MaCNKD)
        {
            InitializeComponent();
            _DanhBo = DanhBo;
            _MaCNKD = MaCNKD;
        }

        private void frmShowChuyenNoKhoDoi_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);

            LoadForm();
        }

        public void LoadForm()
        {
            _cnkd = _cCNKD.Get(_MaCNKD);
            if (_cnkd.SoPhieuYCCHDB != null)
            {
                txtSoPhieu.Text = _cnkd.SoPhieuYCCHDB.ToString().Insert(_cnkd.SoPhieuYCCHDB.ToString().Length - 2, "-");
                dateLap.Value = _cnkd.NgayYCCHDB.Value;
            }
            txtDanhBo.Text = _cnkd.DanhBo;
            txtHoTen.Text = _cnkd.HoTen;
            txtDiaChi.Text = _cnkd.DiaChi;
        }

        private void txtSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoPhieu.Text.Trim()) && e.KeyChar == 13)
            {
                _ycch = _cCNKD.GetYeuCauCHDB(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", "")));

                txtSoPhieu.Text = _ycch.MaYCCHDB.ToString().Insert(_ycch.MaYCCHDB.ToString().Length - 2, "-");
                dateLap.Value = _ycch.CreateDate.Value;
                txtDanhBo.Text = _ycch.DanhBo;
                txtHoTen.Text = _ycch.HoTen;
                txtDiaChi.Text = _ycch.DiaChi;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuChuyenNoKhoDoi", "Sua"))
            {
                if (_ycch != null)
                    try
                    {
                        _cnkd.SoPhieuYCCHDB = _ycch.MaYCCHDB;
                        _cnkd.NgayYCCHDB = dateLap.Value;
                        _cnkd.DanhBo = _ycch.DanhBo;
                        _cnkd.HoTen = _ycch.HoTen;
                        _cnkd.DiaChi = _ycch.DiaChi;

                        if (_cCNKD.Sua(_cnkd))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuChuyenNoKhoDoi", "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _cnkd.SoPhieuYCCHDB = null;
                    _cnkd.NgayYCCHDB = null;
                    _cnkd.DanhBo = null;
                    _cnkd.HoTen = null;
                    _cnkd.DiaChi = null;

                    if (_cCNKD.Sua(_cnkd))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
