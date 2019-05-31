using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmXacNhanThanhToan : Form
    {
        string _mnu = "mnuXacNhanThanhToan";
        CHoaDon _cHoaDon = new CHoaDon();
        HOADON _hoadon = new HOADON();
        CXacNhanThanhToan _cXNTT = new CXacNhanThanhToan();
        TT_XacNhanThanhToan _xntt = null;

        public frmXacNhanThanhToan()
        {
            InitializeComponent();
        }

        private void frmXacNhanThanhToan_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            DataTable dtNamFrom = _cHoaDon.GetNam();
            DataTable dtNamTo = _cHoaDon.GetNam();
            cmbFromNam.DataSource = dtNamFrom;
            cmbFromNam.DisplayMember = "ID";
            cmbFromNam.ValueMember = "Nam";

            cmbToNam.DataSource = dtNamTo;
            cmbToNam.DisplayMember = "ID";
            cmbToNam.ValueMember = "Nam";
        }

        public void LoadTTKH(HOADON en)
        {
            txtDanhBo.Text = en.DANHBA.Insert(7, " ").Insert(4, " ");
            txtHoTen.Text = en.TENKH;
            txtDiaChi.Text = en.SO + " " + en.DUONG;
        }

        public void LoadXacNhanThanhToan(TT_XacNhanThanhToan en)
        {
            dateNgayDeNghi.Value = en.NgayDeNghi.Value;
            txtDanhBo.Text = en.DanhBo.Insert(7, " ").Insert(4, " ");
            txtHoTen.Text = en.HoTen;
            txtDiaChi.Text = en.DiaChi;
            txtTCHC.Text = en.TCHC.Value.ToString();
        }

        public void Clear()
        {
            dateNgayDeNghi.Value = DateTime.Now;
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtTCHC.Text = "";
            cmbFromKy.SelectedIndex = -1;
            cmbFromNam.SelectedIndex = -1;
            cmbToKy.SelectedIndex = -1;
            cmbToNam.SelectedIndex = -1;
            _xntt = null;
            btnXem.PerformClick();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
            {
                _hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_hoadon != null)
                    LoadTTKH(_hoadon);
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cXNTT.checkExist(txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now) == true)
                    {
                        MessageBox.Show("Danh Bộ này đã lập trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataTable dt = _cHoaDon.getDS_XacNhanThanhToan(txtDanhBo.Text.Trim().Replace(" ", ""), int.Parse(cmbFromKy.SelectedItem.ToString()), int.Parse(cmbFromNam.SelectedValue.ToString()), int.Parse(cmbToKy.SelectedItem.ToString()), int.Parse(cmbToNam.SelectedValue.ToString()));
                    TT_XacNhanThanhToan en = new TT_XacNhanThanhToan();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    en.HoTen = txtHoTen.Text.Trim();
                    en.DiaChi = txtDiaChi.Text.Trim();
                    en.NgayDeNghi = dateNgayDeNghi.Value;
                    if (_cXNTT.Them(en) == true)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            TT_XacNhanThanhToan_ChiTiet en_CT = new TT_XacNhanThanhToan_ChiTiet();
                            en_CT.Ky = int.Parse(item["Ky"].ToString());
                            en_CT.Nam = int.Parse(item["Nam"].ToString());
                            en_CT.GiaBan = int.Parse(item["GiaBan"].ToString());
                            en_CT.ThueGTGT = int.Parse(item["ThueGTGT"].ToString());
                            en_CT.PhiBVMT = int.Parse(item["PhiBVMT"].ToString());
                            en_CT.TongCong = int.Parse(item["TongCong"].ToString());
                            if (item["NgayGiaiTrach"].ToString() != "")
                                en_CT.NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());
                            en_CT.ID = en.ID;
                            _cXNTT.Them_ChiTiet(en_CT);
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        _cXNTT.Refresh();
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
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_xntt != null)
                    {
                        _xntt.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        _xntt.HoTen = txtHoTen.Text.Trim();
                        _xntt.DiaChi = txtDiaChi.Text.Trim();
                        _xntt.NgayDeNghi = dateNgayDeNghi.Value;
                        if (txtTCHC.Text.Trim()!="")
                        _xntt.TCHC = int.Parse(txtTCHC.Text.Trim());
                        DataTable dt = _cHoaDon.getDS_XacNhanThanhToan(txtDanhBo.Text.Trim().Replace(" ", ""), int.Parse(cmbFromKy.SelectedItem.ToString()), int.Parse(cmbFromNam.SelectedValue.ToString()), int.Parse(cmbToKy.SelectedItem.ToString()), int.Parse(cmbToNam.SelectedValue.ToString()));
                        _cXNTT.Xoa_ChiTiet(_xntt.TT_XacNhanThanhToan_ChiTiets.ToList());
                        foreach (DataRow item in dt.Rows)
                            //không có thì thêm
                            //if (_xntt.TT_XacNhanThanhToan_ChiTiets.Any(itemA => itemA.Ky == int.Parse(item["Ky"].ToString()) && itemA.Nam == int.Parse(item["Nam"].ToString())) == false)
                            {
                                TT_XacNhanThanhToan_ChiTiet en_CT = new TT_XacNhanThanhToan_ChiTiet();
                                en_CT.Ky = int.Parse(item["Ky"].ToString());
                                en_CT.Nam = int.Parse(item["Nam"].ToString());
                                en_CT.GiaBan = int.Parse(item["GiaBan"].ToString());
                                en_CT.ThueGTGT = int.Parse(item["ThueGTGT"].ToString());
                                en_CT.PhiBVMT = int.Parse(item["PhiBVMT"].ToString());
                                en_CT.TongCong = int.Parse(item["TongCong"].ToString());
                                if (item["NgayGiaiTrach"].ToString() != "")
                                    en_CT.NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());
                                en_CT.ID = _xntt.ID;
                                _cXNTT.Them_ChiTiet(en_CT);
                            }
                        //foreach (TT_XacNhanThanhToan_ChiTiet item in _xntt.TT_XacNhanThanhToan_ChiTiets.ToList())
                        //    //không có thì xóa
                        //    if (dt.AsEnumerable().Any(row => item.Ky == row.Field<Int32>("Ky") && item.Nam == row.Field<Int32>("Nam")) == false)
                        //    {
                        //        _cXNTT.Xoa_ChiTiet(item);
                        //    }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        _cXNTT.Refresh();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_xntt != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cXNTT.Xoa(_xntt) == true)
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cXNTT.getDS(dateTu.Value,dateDen.Value);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_xntt != null)
            {
                dsBaoCao ds = new dsBaoCao();
                foreach (TT_XacNhanThanhToan_ChiTiet item in _xntt.TT_XacNhanThanhToan_ChiTiets.ToList())
                {
                    DataRow dr = ds.Tables["TongHopNo"].NewRow();
                    dr["TuNgay"] = "ngày " + item.TT_XacNhanThanhToan.NgayDeNghi.Value.ToString("dd") + " tháng " + item.TT_XacNhanThanhToan.NgayDeNghi.Value.ToString("MM") + " năm " + item.TT_XacNhanThanhToan.NgayDeNghi.Value.ToString("yyyy");
                    dr["DanhBo"] = item.TT_XacNhanThanhToan.DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = item.TT_XacNhanThanhToan.HoTen;
                    dr["DiaChi"] = item.TT_XacNhanThanhToan.DiaChi;
                    dr["Ky"] = item.Ky+"/"+item.Nam;
                    dr["GiaBan"] = item.GiaBan.ToString();
                    dr["ThueGTGT"] = item.ThueGTGT.ToString();
                    dr["PhiBVMT"] = item.PhiBVMT.ToString();
                    dr["TongCong"] = item.TongCong.ToString();
                    if (item.NgayGiaiTrach!=null)
                    dr["NgayThanhToan"] = item.NgayGiaiTrach.Value.ToString("dd/MM/yyyy");
                    ds.Tables["TongHopNo"].Rows.Add(dr);
                }
                rptXacNhanThanhToan rpt = new rptXacNhanThanhToan();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _xntt = _cXNTT.get(int.Parse(dgvHoaDon.CurrentRow.Cells["ID"].Value.ToString()));
                LoadXacNhanThanhToan(_xntt);
            }
            catch (Exception)
            {
            }
        }
    }
}
