using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCapDinhMucNuocChungCu : Form
    {
        string _mnu = "mnuCapDinhMucNuocChungCu";
        CChungTu _cChungTu = new CChungTu();
        CThuTien _cThuTien = new CThuTien();
        HOADON _hoadon = null;

        public frmCapDinhMucNuocChungCu()
        {
            InitializeComponent();
        }

        private void frmCapDinhMucNuocChungCu_Load(object sender, EventArgs e)
        {

        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    if (_hoadon != null)
                    {
                        txtDanhBo.Text = _hoadon.DANHBA;
                        txtHoTen.Text = _hoadon.TENKH;
                        txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG;
                        txtGiaBieu.Text = _hoadon.GB.ToString();
                        if (_hoadon.DM != null)
                            txtDinhMuc.Text = _hoadon.DM.Value.ToString();
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
                    }
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
