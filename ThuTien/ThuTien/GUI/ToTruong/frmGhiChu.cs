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
        CTo _cTo = new CTo();

        public frmGhiChu()
        {
            InitializeComponent();
        }

        private void frmGhiChu_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                cmbTo.DataSource = _cTo.getDS_HanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtDienThoai.Text = "";
            txtGiaBieu.Text = "";
            dateGiaBieu.Value = DateTime.Now;
            txtNiemChi.Text = "";
            dateNiemChi.Value = DateTime.Now;
            txtDiemBe.Text = "";
            dateDiemBe.Value = DateTime.Now;
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
                    if (_ghichu.GiaBieu_Ngay.Value != null)
                        dateGiaBieu.Value = _ghichu.GiaBieu_Ngay.Value;
                    txtNiemChi.Text = _ghichu.NiemChi;
                    if (_ghichu.NiemChi_Ngay.Value != null)
                        dateNiemChi.Value = _ghichu.NiemChi_Ngay.Value;
                    txtDiemBe.Text = _ghichu.DiemBe;
                    if (_ghichu.DiemBe_Ngay.Value != null)
                        dateDiemBe.Value = _ghichu.DiemBe_Ngay.Value;
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
                        if (txtGiaBieu.Text.Trim() != "")
                        {
                            en.GiaBieu = txtGiaBieu.Text.Trim();
                            en.GiaBieu_CreateBy = CNguoiDung.MaND;
                            en.GiaBieu_Ngay = DateTime.Now;
                        }
                        if (txtNiemChi.Text.Trim() != "")
                        {
                            en.NiemChi = txtNiemChi.Text.Trim();
                            en.NiemChi_CreateBy = CNguoiDung.MaND;
                            en.NiemChi_Ngay = DateTime.Now;
                        }
                        if (txtDiemBe.Text.Trim() != "")
                        {
                            en.DiemBe = txtDiemBe.Text.Trim();
                            en.DiemBe_CreateBy = CNguoiDung.MaND;
                            en.DiemBe_Ngay = DateTime.Now;
                        }
                        if (_cGhiChu.Them(en) == true)
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _ghichu.DienThoai = txtDienThoai.Text.Trim();
                        if (txtGiaBieu.Text.Trim() != "" && _ghichu.GiaBieu != txtGiaBieu.Text.Trim())
                        {
                            _ghichu.GiaBieu = txtGiaBieu.Text.Trim();
                            _ghichu.GiaBieu_CreateBy = CNguoiDung.MaND;
                            _ghichu.GiaBieu_Ngay = DateTime.Now;
                        }
                        if (txtNiemChi.Text.Trim() != "" && _ghichu.NiemChi != txtNiemChi.Text.Trim())
                        {
                            _ghichu.NiemChi = txtNiemChi.Text.Trim();
                            _ghichu.NiemChi_CreateBy = CNguoiDung.MaND;
                            _ghichu.NiemChi_Ngay = DateTime.Now;
                        }
                        if (txtDiemBe.Text.Trim() != "" && _ghichu.DiemBe != txtDiemBe.Text.Trim())
                        {
                            _ghichu.DiemBe = txtDiemBe.Text.Trim();
                            _ghichu.DiemBe_CreateBy = CNguoiDung.MaND;
                            _ghichu.DiemBe_Ngay = DateTime.Now;
                        }
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

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                string Loai = "";
                if (radGiaBieu.Checked)
                    Loai = "GiaBieu";
                else
                    if (radNiemChi.Checked)
                        Loai = "NiemChi";
                    else
                        if (radDiemBe.Checked)
                            Loai = "DiemBe";
                if (CNguoiDung.Doi == true)
                    dgvDanhSach.DataSource = _cGhiChu.getDS(Loai, int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                else
                    dgvDanhSach.DataSource = _cGhiChu.getDS(Loai, CNguoiDung.MaTo, dateTu.Value, dateDen.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
