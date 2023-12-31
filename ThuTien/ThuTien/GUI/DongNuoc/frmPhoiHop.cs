using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.DongNuoc;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.BaoCao;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmPhoiHop : Form
    {
        string _mnu = "mnuKQDongNuoc";
        CHoaDon _cHoaDon = new CHoaDon();
        CPhoiHop _cPhoiHop = new CPhoiHop();
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        HOADON _hoadon = null;
        TT_DongNuoc_PhoiHop _phoihop = null;

        public frmPhoiHop()
        {
            InitializeComponent();
        }

        private void frmPhoiHop_Load(object sender, EventArgs e)
        {
            dgvPhoiHop.AutoGenerateColumns = false;
            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                List<TT_To> lstTo = _cTo.getDS_HanhThu(CNguoiDung.IDPhong);
                TT_To to = new TT_To();
                to.MaTo = 0;
                to.TenTo = "Tất Cả";
                lstTo.Insert(0, to);
                cmbTo.DataSource = lstTo;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

            cmbLoaiPhoiHop.DataSource = _cPhoiHop.getDS_LoaiPhoiHop();
            cmbLoaiPhoiHop.DisplayMember = "Name";
            cmbLoaiPhoiHop.ValueMember = "Name";

            cmbDongNuoc.DataSource = _cNguoiDung.GetDSDongNuocToTruongByMaTo(CNguoiDung.MaTo);
            cmbDongNuoc.DisplayMember = "HoTen";
            cmbDongNuoc.ValueMember = "MaND";
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            cmbLoaiPhoiHop.SelectedIndex = -1;
            txtNoiDung.Text = "";

            _hoadon = null;
            _phoihop = null;
        }

        public void FillHoaDon(HOADON en)
        {
            txtDanhBo.Text = en.DANHBA.Insert(7, " ").Insert(4, " ");
            txtHoTen.Text = en.TENKH;
            txtDiaChi.Text = en.SO + " " + en.DUONG;
        }

        public void FillEntity(TT_DongNuoc_PhoiHop en)
        {
            txtDanhBo.Text = en.DanhBo.Insert(7, " ").Insert(4, " ");
            txtHoTen.Text = en.HoTen;
            txtDiaChi.Text = en.DiaChi;
            cmbLoaiPhoiHop.SelectedValue = en.Loai;
            txtNoiDung.Text = en.NoiDung;
            cmbDongNuoc.SelectedValue = en.CreateBy;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11 && e.KeyChar == 13)
            {
                _hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_hoadon != null)
                    FillHoaDon(_hoadon);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    TT_DongNuoc_PhoiHop en = new TT_DongNuoc_PhoiHop();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    en.HoTen = txtHoTen.Text.Trim();
                    en.DiaChi = txtDiaChi.Text.Trim();
                    en.Loai = cmbLoaiPhoiHop.SelectedValue.ToString();
                    en.NoiDung = txtNoiDung.Text.Trim();
                    if (_cPhoiHop.Them(en, int.Parse(cmbDongNuoc.SelectedValue.ToString())) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        btnXem.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    _phoihop.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    _phoihop.HoTen = txtHoTen.Text.Trim();
                    _phoihop.DiaChi = txtDiaChi.Text.Trim();
                    _phoihop.Loai = cmbLoaiPhoiHop.SelectedValue.ToString();
                    _phoihop.NoiDung = txtNoiDung.Text.Trim();
                    if (_cPhoiHop.Sua(_phoihop) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        btnXem.PerformClick();
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
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cPhoiHop.Xoa(_phoihop) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            btnXem.PerformClick();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

            if (CNguoiDung.Doi)
            {
                if (cmbTo.SelectedIndex == 0)
                    dgvPhoiHop.DataSource = _cPhoiHop.getDS(dateTu.Value, dateDen.Value);
                else
                    if (cmbTo.SelectedIndex > 0)
                        dgvPhoiHop.DataSource = _cPhoiHop.getDS_To((int)cmbTo.SelectedValue, dateTu.Value, dateDen.Value);
            }
            else
                if (CNguoiDung.ToTruong)
                    dgvPhoiHop.DataSource = _cPhoiHop.getDS_To(CNguoiDung.MaTo, dateTu.Value, dateDen.Value);
                else
                    dgvPhoiHop.DataSource = _cPhoiHop.getDS_NV(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
        }

        private void dgvPhoiHop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _phoihop = _cPhoiHop.get(int.Parse(dgvPhoiHop.CurrentRow.Cells["ID"].Value.ToString()));
                if (_phoihop != null)
                    FillEntity(_phoihop);
            }
            catch
            {
            }
        }

        private void dgvPhoiHop_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhoiHop.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvPhoiHop.Rows)
            {
                DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                dr["LoaiBaoCao"] = "CÔNG TÁC PHỐI HỢP";
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                if (item.Cells["DanhBo"].Value.ToString() != "")
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["Loai"] = item.Cells["Loai"].Value;
                dr["NgayLap"] = item.Cells["CreateBy"].Value;
                ds.Tables["DSHoaDon"].Rows.Add(dr);
            }
            rptPhoiHop rpt = new rptPhoiHop();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }
    }
}
