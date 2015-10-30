using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL;
using ThuTien.BaoCao;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmKQDongNuoc : Form
    {
        string _mnu = "mnuKQDongNuoc";
        CDongNuoc _cDongNuoc = new CDongNuoc();
        TT_DongNuoc _dongnuoc = null;
        TT_KQDongNuoc _kqdongnuoc = null;
        CCAPNUOCTANHOA _cCapNuocTanHoa = new CCAPNUOCTANHOA();

        public frmKQDongNuoc()
        {
            InitializeComponent();
        }

        private void frmKQDongNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtMLT.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            dateDongNuoc.Value = DateTime.Now;
            txtChiSoDN.Text = "";
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            cmbChiMatSo.SelectedIndex = -1;
            cmbChiKhoaGoc.SelectedIndex = -1;
            txtLyDo.Text = "";
            chkMoNuoc.Checked = false;
            dateMoNuoc.Value = DateTime.Now;
            txtChiSoMN.Text = "";
            _dongnuoc = null;
            _kqdongnuoc = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDN.Text.Trim()) && e.KeyChar == 13)
            {
                Clear();
                if (_cDongNuoc.CheckKQDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", ""))))
                {
                    _dongnuoc = _cDongNuoc.GetDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", "")));

                    _kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", "")));
                    txtDanhBo.Text = _kqdongnuoc.DanhBo;
                    txtMLT.Text = _kqdongnuoc.MLT;
                    txtHoTen.Text = _kqdongnuoc.HoTen;
                    txtDiaChi.Text = _kqdongnuoc.DiaChi;
                    dateDongNuoc.Value = _kqdongnuoc.NgayDN.Value;
                    if (_kqdongnuoc.ChiSoDN != null)
                        txtChiSoDN.Text = _kqdongnuoc.ChiSoDN.Value.ToString();
                    txtHieu.Text = _kqdongnuoc.Hieu;
                    if (_kqdongnuoc.Co != null)
                    txtCo.Text = _kqdongnuoc.Co.Value.ToString();
                    txtSoThan.Text = _kqdongnuoc.SoThan;
                    cmbChiMatSo.SelectedItem = _kqdongnuoc.ChiMatSo;
                    cmbChiKhoaGoc.SelectedItem = _kqdongnuoc.ChiKhoaGoc;
                    txtLyDo.Text = _kqdongnuoc.LyDo;
                    if (_kqdongnuoc.MoNuoc)
                    {
                        chkMoNuoc.Checked = _kqdongnuoc.MoNuoc;
                        dateMoNuoc.Value = _kqdongnuoc.NgayMN.Value;
                        if (_kqdongnuoc.ChiSoMN != null)
                            txtChiSoMN.Text = _kqdongnuoc.ChiSoMN.Value.ToString();
                    }
                }
                else
                    if (_cDongNuoc.GetDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", ""))) != null)
                    {
                        _dongnuoc = _cDongNuoc.GetDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", "")));
                        txtMaDN.Text = _dongnuoc.MaDN.ToString().Insert(_dongnuoc.MaDN.ToString().Length - 2, "-");
                        txtDanhBo.Text = _dongnuoc.DanhBo;
                        txtMLT.Text = _dongnuoc.MLT;
                        txtHoTen.Text = _dongnuoc.HoTen;
                        txtDiaChi.Text = _dongnuoc.DiaChi;
                        chkHuy.Checked = _dongnuoc.Huy;

                        DataTable dt = _cCapNuocTanHoa.GetTTKH(_dongnuoc.DanhBo);
                        txtHieu.Text = dt.Rows[0]["Hieu"].ToString();
                        txtCo.Text = dt.Rows[0]["Co"].ToString();
                        txtSoThan.Text = dt.Rows[0]["SoThan"].ToString();
                        //dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuocByMaDNDates(_dongnuoc.MaDN, dateTu.Value, dateDen.Value);
                        //btnXem.PerformClick();
                    }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (_dongnuoc != null)
                {
                    if (_cDongNuoc.CheckKQDongNuocByMaDN(_dongnuoc.MaDN))
                    {
                        MessageBox.Show("Lệnh này đã nhập Kết Quả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!CNguoiDung.ToTruong)
                        if (!_cDongNuoc.CheckDongNuocByMaDNMaNV_DongNuoc(_dongnuoc.MaDN, CNguoiDung.MaND))
                        {
                            MessageBox.Show("Thông báo này không được giao cho bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    TT_KQDongNuoc kqdongnuoc = new TT_KQDongNuoc();
                    kqdongnuoc.MaDN = _dongnuoc.MaDN;
                    kqdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                    kqdongnuoc.MLT = txtMLT.Text.Trim();
                    kqdongnuoc.HoTen = txtHoTen.Text.Trim();
                    kqdongnuoc.DiaChi = txtDiaChi.Text.Trim();

                    kqdongnuoc.DongNuoc = true;
                    kqdongnuoc.NgayDN = dateDongNuoc.Value;
                    if (!string.IsNullOrEmpty(txtChiSoDN.Text.Trim()))
                        kqdongnuoc.ChiSoDN = int.Parse(txtChiSoDN.Text.Trim());
                    kqdongnuoc.Hieu = txtHieu.Text.Trim();
                    if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                        kqdongnuoc.Co = int.Parse(txtCo.Text.Trim());
                    kqdongnuoc.SoThan = txtSoThan.Text.Trim();
                    if (cmbChiMatSo.SelectedItem != null)
                        kqdongnuoc.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();
                    if (cmbChiKhoaGoc.SelectedItem != null)
                        kqdongnuoc.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();
                    kqdongnuoc.LyDo = txtLyDo.Text.Trim();

                    kqdongnuoc.PhiMoNuoc = _cDongNuoc.GetPhiMoNuoc();

                    if (chkMoNuoc.Checked)
                    {
                        kqdongnuoc.MoNuoc = true;
                        kqdongnuoc.NgayMN = dateMoNuoc.Value;
                        kqdongnuoc.ChiSoMN = int.Parse(txtChiSoMN.Text.Trim());
                    }

                    if (_cDongNuoc.ThemKQ(kqdongnuoc))
                    {
                        Clear();
                        //btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_kqdongnuoc != null)
                {
                    _kqdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                    _kqdongnuoc.MLT = txtMLT.Text.Trim();
                    _kqdongnuoc.HoTen = txtHoTen.Text.Trim();
                    _kqdongnuoc.DiaChi = txtDiaChi.Text.Trim();

                    _kqdongnuoc.NgayDN = dateDongNuoc.Value;
                    if (!string.IsNullOrEmpty(txtChiSoDN.Text.Trim()))
                        _kqdongnuoc.ChiSoDN = int.Parse(txtChiSoDN.Text.Trim());
                    _kqdongnuoc.Hieu = txtHieu.Text.Trim();
                    if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                        _kqdongnuoc.Co = int.Parse(txtCo.Text.Trim());
                    _kqdongnuoc.SoThan = txtSoThan.Text.Trim();
                    if (cmbChiMatSo.SelectedItem != null)
                        _kqdongnuoc.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();
                    if (cmbChiKhoaGoc.SelectedItem != null)
                        _kqdongnuoc.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();
                    _kqdongnuoc.LyDo = txtLyDo.Text.Trim();

                    if (chkMoNuoc.Checked)
                    {
                        _kqdongnuoc.MoNuoc = true;
                        _kqdongnuoc.NgayMN = dateMoNuoc.Value;
                        _kqdongnuoc.ChiSoMN = int.Parse(txtChiSoMN.Text.Trim());
                    }
                    else
                    {
                        _kqdongnuoc.MoNuoc = false;
                        _kqdongnuoc.NgayMN = null;
                        _kqdongnuoc.ChiSoMN = null;
                    }

                    if (_cDongNuoc.SuaKQ(_kqdongnuoc))
                    {
                        Clear();
                        ////btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvKQDongNuoc.SelectedRows[0].Cells["MaKQDN"].Value.ToString()));
                    kqdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                    kqdongnuoc.MLT = txtMLT.Text.Trim();
                    kqdongnuoc.HoTen = txtHoTen.Text.Trim();
                    kqdongnuoc.DiaChi = txtDiaChi.Text.Trim();

                    kqdongnuoc.NgayDN = dateDongNuoc.Value;
                    if (!string.IsNullOrEmpty(txtChiSoDN.Text.Trim()))
                        kqdongnuoc.ChiSoDN = int.Parse(txtChiSoDN.Text.Trim());
                    kqdongnuoc.Hieu = txtHieu.Text.Trim();
                    if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                        kqdongnuoc.Co = int.Parse(txtCo.Text.Trim());
                    kqdongnuoc.SoThan = txtSoThan.Text.Trim();
                    if (cmbChiMatSo.SelectedItem != null)
                        kqdongnuoc.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();
                    if (cmbChiKhoaGoc.SelectedItem != null)
                        kqdongnuoc.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();
                    kqdongnuoc.LyDo = txtLyDo.Text.Trim();

                    if (chkMoNuoc.Checked)
                    {
                        kqdongnuoc.MoNuoc = true;
                        kqdongnuoc.NgayMN = dateMoNuoc.Value;
                        kqdongnuoc.ChiSoMN = int.Parse(txtChiSoMN.Text.Trim());
                    }
                    else
                    {
                        kqdongnuoc.MoNuoc = false;
                        kqdongnuoc.NgayMN = null;
                        kqdongnuoc.ChiSoMN = null;
                    }

                    if (_cDongNuoc.SuaKQ(kqdongnuoc))
                    {
                        Clear();
                        ////btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvKQDongNuoc.SelectedRows[0].Cells["MaKQDN"].Value.ToString()));
                    if (_cDongNuoc.XoaKQ(kqdongnuoc))
                    {
                        Clear();
                        //btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radDongNuoc.Checked)
            {
                if (CNguoiDung.Doi)
                    dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuocByDates(dateTu.Value, dateDen.Value);
                else
                    if (CNguoiDung.ToTruong)
                        dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuocByMaToDates(CNguoiDung.MaTo, dateTu.Value, dateDen.Value);
                    else
                        dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuocByMaNVDates(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            }
            else
                if (radMoNuoc.Checked)
                {
                    if (CNguoiDung.Doi)
                        dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQMoNuocByDates(dateTu.Value, dateDen.Value);
                    else
                        if (CNguoiDung.ToTruong)
                            dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQMoNuocByMaToDates(CNguoiDung.MaTo, dateTu.Value, dateDen.Value);
                        else
                            dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQMoNuocByMaNVDates(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
                }
            //foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
            //{
            //    item.Cells["Chon"].Value = true;
            //}
        }

        private void dgvKQDongNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //dgvKQDongNuoc.Rows[e.RowIndex].Selected = true;
                txtDanhBo.Text = dgvKQDongNuoc["DanhBo", e.RowIndex].Value.ToString();
                txtMLT.Text = dgvKQDongNuoc["MLT", e.RowIndex].Value.ToString();
                txtHoTen.Text = dgvKQDongNuoc["HoTen", e.RowIndex].Value.ToString();
                txtDiaChi.Text = dgvKQDongNuoc["DiaChi", e.RowIndex].Value.ToString();
                dateDongNuoc.Value = DateTime.Parse(dgvKQDongNuoc["NgayDN", e.RowIndex].Value.ToString());
                txtChiSoDN.Text = dgvKQDongNuoc["ChiSoDN", e.RowIndex].Value.ToString();
                txtHieu.Text = dgvKQDongNuoc["Hieu", e.RowIndex].Value.ToString();
                txtCo.Text = dgvKQDongNuoc["Co", e.RowIndex].Value.ToString();
                txtSoThan.Text = dgvKQDongNuoc["SoThan", e.RowIndex].Value.ToString();
                cmbChiMatSo.SelectedItem = dgvKQDongNuoc["ChiMatSo", e.RowIndex].Value.ToString();
                cmbChiKhoaGoc.SelectedItem = dgvKQDongNuoc["ChiKhoaGoc", e.RowIndex].Value.ToString();
                txtLyDo.Text = dgvKQDongNuoc["LyDo", e.RowIndex].Value.ToString();
                chkMoNuoc.Checked = bool.Parse(dgvKQDongNuoc["MoNuoc", e.RowIndex].Value.ToString());
                dateMoNuoc.Value = DateTime.Parse(dgvKQDongNuoc["NgayMN", e.RowIndex].Value.ToString());
                txtChiSoMN.Text = dgvKQDongNuoc["ChiSoMN", e.RowIndex].Value.ToString();
            }
            catch
            {
            }
        }

        private void dgvKQDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "MaDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "SoPhieuDN" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "SoPhieuMN" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvKQDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtChiSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void chkHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_dongnuoc != null)
                {
                    _dongnuoc.Huy = chkHuy.Checked;
                    if (_cDongNuoc.SuaDN(_dongnuoc))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkMoNuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoNuoc.Checked)
            {
                dateMoNuoc.Enabled = true;
                txtChiSoMN.ReadOnly = false;
            }
            else
            {
                dateMoNuoc.Enabled = false;
                txtChiSoMN.ReadOnly = true;
                dateMoNuoc.Value = DateTime.Now;
                txtChiSoMN.Text = "";
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn In Phiếu?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    dsBaoCao dsBaoCao = new dsBaoCao();
                    if (radDongNuoc.Checked)
                    {
                        decimal SoPhieuDN = _cDongNuoc.GetNextSoPhieuDN();
                        List<TT_KQDongNuoc> lst = new List<TT_KQDongNuoc>();

                        foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                            if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()) == true)
                            {
                                if (string.IsNullOrEmpty(item.Cells["SoPhieuDN"].Value.ToString()))
                                {
                                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(item.Cells["MaKQDN"].Value.ToString()));
                                    kqdongnuoc.SoPhieuDN = SoPhieuDN;
                                    kqdongnuoc.NgaySoPhieuDN = DateTime.Now;
                                    _cDongNuoc.SuaKQ(kqdongnuoc);
                                }
                                else
                                    if (!lst.Any(itemlst => itemlst.SoPhieuDN == decimal.Parse(item.Cells["SoPhieuDN"].Value.ToString())))
                                        lst = lst.Concat(_cDongNuoc.GetDSKQDongNuocBySoPhieuDN(decimal.Parse(item.Cells["SoPhieuDN"].Value.ToString()))).ToList();
                            }

                        lst = lst.Concat(_cDongNuoc.GetDSKQDongNuocBySoPhieuDN(SoPhieuDN)).ToList();
                        foreach (TT_KQDongNuoc item in lst)
                        {
                            DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();

                            dr["MaDN"] = item.SoPhieuDN.ToString().Insert(item.SoPhieuDN.ToString().Length - 2, "-");
                            dr["Loai"] = "ĐÓNG NƯỚC";
                            if (item.DanhBo.Length == 11)
                                dr["DanhBo"] = item.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["DiaChi"] = item.DiaChi;
                            string Ky = "";
                            foreach (TT_CTDongNuoc itemDN in item.TT_DongNuoc.TT_CTDongNuocs.ToList())
                            {
                                if (string.IsNullOrEmpty(Ky))
                                    Ky = itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                                else
                                    Ky += ", " + itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                            }
                            dr["Ky"] = Ky;
                            dr["NgayDongMoNuoc"] = item.NgayDN;
                            dr["ChiSoDongMoNuoc"] = item.ChiSoDN;

                            dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                        }
                    }
                    else
                        if (radMoNuoc.Checked)
                        {
                            decimal SoPhieuMN = _cDongNuoc.GetNextSoPhieuMN();
                            List<TT_KQDongNuoc> lst = new List<TT_KQDongNuoc>();

                            foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                                if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()) == true)
                                {
                                    if (string.IsNullOrEmpty(item.Cells["SoPhieuMN"].Value.ToString()))
                                    {
                                        TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(item.Cells["MaKQDN"].Value.ToString()));
                                        kqdongnuoc.SoPhieuMN = SoPhieuMN;
                                        kqdongnuoc.NgaySoPhieuMN = DateTime.Now;
                                        _cDongNuoc.SuaKQ(kqdongnuoc);
                                    }
                                    else
                                        if (!lst.Any(itemlst => itemlst.SoPhieuMN == decimal.Parse(item.Cells["SoPhieuMN"].Value.ToString())))
                                            lst = lst.Concat(_cDongNuoc.GetDSKQDongNuocBySoPhieuMN(decimal.Parse(item.Cells["SoPhieuMN"].Value.ToString()))).ToList();
                                }

                            lst = lst.Concat(_cDongNuoc.GetDSKQDongNuocBySoPhieuMN(SoPhieuMN)).ToList();
                            foreach (TT_KQDongNuoc item in lst)
                            {
                                DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();

                                dr["MaDN"] = item.SoPhieuMN.ToString().Insert(item.SoPhieuMN.ToString().Length - 2, "-");
                                dr["Loai"] = "MỞ NƯỚC";
                                if (item.DanhBo.Length == 11)
                                    dr["DanhBo"] = item.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["DiaChi"] = item.DiaChi;
                                string Ky = "";
                                foreach (TT_CTDongNuoc itemDN in item.TT_DongNuoc.TT_CTDongNuocs.ToList())
                                {
                                    if (string.IsNullOrEmpty(Ky))
                                        Ky = itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                                    else
                                        Ky += ", " + itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                                }
                                dr["Ky"] = Ky;
                                dr["NgayDongMoNuoc"] = item.NgayMN;
                                dr["ChiSoDongMoNuoc"] = item.ChiSoMN;

                                dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                            }
                        }

                    rptPhieuBaoDongMoNuoc rpt = new rptPhieuBaoDongMoNuoc();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();

                    //btnXem.PerformClick();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (radDongNuoc.Checked)
                    {
                        foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                            if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()) == true && !string.IsNullOrEmpty(item.Cells["SoPhieuDN"].Value.ToString()))
                            {
                                TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(item.Cells["MaKQDN"].Value.ToString()));
                                kqdongnuoc.SoPhieuDN = null;
                                kqdongnuoc.NgaySoPhieuDN = null;
                                _cDongNuoc.SuaKQ(kqdongnuoc);
                            }
                    }
                    else
                        if (radMoNuoc.Checked)
                        {
                            foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                                if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()) == true && !string.IsNullOrEmpty(item.Cells["SoPhieuMN"].Value.ToString()))
                                {
                                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(item.Cells["MaKQDN"].Value.ToString()));
                                    kqdongnuoc.SoPhieuMN = null;
                                    kqdongnuoc.NgaySoPhieuMN = null;
                                    _cDongNuoc.SuaKQ(kqdongnuoc);
                                }
                        }
                    //btnXem.PerformClick();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
