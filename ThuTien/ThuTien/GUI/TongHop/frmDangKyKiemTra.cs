using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao.TongHop;

namespace ThuTien.GUI.TongHop
{
    public partial class frmDangKyKiemTra : Form
    {
        string _mnu = "mnuDangKyKiemTra";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDangKyKiemTra _cDangKyKT = new CDangKyKiemTra();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmDangKyKiemTra()
        {
            InitializeComponent();
        }

        private void frmChuyenKinhDoanh_Load(object sender, EventArgs e)
        {
            dgvDangKyKiemTra.AutoGenerateColumns = false;
            dgvCTDangKyKiemTra.AutoGenerateColumns = false;

            //List<TT_NguoiDung> lstND = null;
            //lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            //TT_NguoiDung nguoidung = new TT_NguoiDung();
            //nguoidung.MaND = 0;
            //nguoidung.HoTen = "Tất Cả";
            //lstND.Insert(0, nguoidung);

            //cmbNhanVien.DataSource = lstND;
            //cmbNhanVien.DisplayMember = "HoTen";
            //cmbNhanVien.ValueMember = "MaND";
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
            {
                if (_cDangKyKT.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")) == true)
                {
                    string ID = _cDangKyKT.GetMaDKKT(txtDanhBo.Text.Trim().Replace(" ", "")).ToString();
                    MessageBox.Show("Đã đăng ký ở tờ trình số: " + ID.Insert(ID.Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                bool exist = false;
                foreach (DataGridViewRow item in dgvCTDangKyKiemTra.Rows)
                    if (item.Cells["DanhBo"].Value.ToString() == txtDanhBo.Text.Trim().Replace(" ", ""))
                    {
                        exist = true;
                        break;
                    }
                if (exist == false)
                {
                    HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                    if (hoadon != null)
                        if (dgvCTDangKyKiemTra.DataSource == null)
                        {
                            dgvCTDangKyKiemTra.Rows.Add();

                            if (hoadon.MaNV_HanhThu == null)
                                hoadon = _cHoaDon.GetMoiNhi(hoadon.DANHBA);
                            dgvCTDangKyKiemTra["MaNV_HanhThu", dgvCTDangKyKiemTra.Rows.Count - 1].Value = hoadon.MaNV_HanhThu;
                            dgvCTDangKyKiemTra["HanhThu", dgvCTDangKyKiemTra.Rows.Count - 1].Value = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);
                            dgvCTDangKyKiemTra["DanhBo", dgvCTDangKyKiemTra.Rows.Count - 1].Value = hoadon.DANHBA;
                            dgvCTDangKyKiemTra["MLT", dgvCTDangKyKiemTra.Rows.Count - 1].Value = hoadon.MALOTRINH;
                            dgvCTDangKyKiemTra["DiaChi", dgvCTDangKyKiemTra.Rows.Count - 1].Value = hoadon.SO + " " + hoadon.DUONG;
                            dgvCTDangKyKiemTra["NgayNhan", dgvCTDangKyKiemTra.Rows.Count - 1].Value = dateNhap.Value.ToString("dd/MM/yyyy");
                            dgvCTDangKyKiemTra["GB_DM_Cu", dgvCTDangKyKiemTra.Rows.Count - 1].Value = hoadon.GB + " - " + hoadon.DM;
                        }
                        else
                        {
                            DataTable dtTemp = (DataTable)dgvCTDangKyKiemTra.DataSource;

                            DataRow dr = dtTemp.NewRow();

                            if (hoadon.MaNV_HanhThu == null)
                                hoadon = _cHoaDon.GetMoiNhi(hoadon.DANHBA);
                            dr["MaNV_HanhThu"] = hoadon.MaNV_HanhThu;
                            dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);
                            dr["DanhBo"] = hoadon.DANHBA;
                            dr["MLT"] = hoadon.MALOTRINH;
                            dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                            dr["NgayNhan"] = dateNhap.Value.ToString("dd/MM/yyyy");
                            dr["GB_DM_Cu"] = hoadon.GB + " - " + hoadon.DM;

                            dtTemp.Rows.Add(dr);
                            dtTemp.AcceptChanges();

                            dgvCTDangKyKiemTra.DataSource = dtTemp;
                        }

                    txtDanhBo.Text = "";
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            /////chọn tất cả nhân viên
            //if (cmbNhanVien.SelectedIndex == 0)
            //{
            //    DataTable dt = new DataTable();
            //    List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            //    foreach (TT_NguoiDung itemND in lstND)
            //    {
            //        dt.Merge(_cDangKyKT.GetDS(itemND.MaND));
            //    }
            //    dgvDanhBo.DataSource = dt;
            //}
            //else
            //    ///chọn 1 nhân viên cụ thể
            //    if (cmbNhanVien.SelectedIndex > 0)
            //    {
            //        dgvDanhBo.DataSource = _cDangKyKT.GetDS(int.Parse(cmbNhanVien.SelectedValue.ToString()));
            //    }
            dgvDangKyKiemTra.DataSource = _cDangKyKT.GetDS();
            if (dgvCTDangKyKiemTra.DataSource != null)
                dgvCTDangKyKiemTra.DataSource = null;
            if (dgvCTDangKyKiemTra.Rows.Count > 0)
                dgvCTDangKyKiemTra.Rows.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (dgvCTDangKyKiemTra.Rows.Count > 0)
                    try
                    {
                        TT_DangKyKiemTra dangky;
                        if (dgvCTDangKyKiemTra.DataSource == null)
                            dangky = new TT_DangKyKiemTra();
                        else
                            dangky = _cDangKyKT.Get(decimal.Parse(dgvCTDangKyKiemTra["MaDKKT_CT", 0].Value.ToString()));
                        int MaCTDKKT = _cDangKyKT.GetMaxMaCTDKKT();

                        foreach (DataGridViewRow item in dgvCTDangKyKiemTra.Rows)
                            if (item.Cells["MaCTDKKT"].Value == null || string.IsNullOrEmpty(item.Cells["MaCTDKKT"].Value.ToString()))
                            {
                                TT_CTDangKyKiemTra ctdangky = new TT_CTDangKyKiemTra();
                                ctdangky.MaCTDKKT = ++MaCTDKKT;
                                ctdangky.MaNV_HanhThu = int.Parse(item.Cells["MaNV_HanhThu"].Value.ToString());
                                ctdangky.HanhThu = item.Cells["HanhThu"].Value.ToString();
                                ctdangky.DanhBo = item.Cells["DanhBo"].Value.ToString();
                                ctdangky.MLT = item.Cells["MLT"].Value.ToString();
                                ctdangky.DiaChi = item.Cells["DiaChi"].Value.ToString();
                                ctdangky.NgayNhan = DateTime.Parse(item.Cells["NgayNhan"].Value.ToString());
                                ctdangky.GB_DM_Cu = item.Cells["GB_DM_Cu"].Value.ToString();
                                if (item.Cells["NoiDung"].Value != null)
                                    ctdangky.NoiDung = item.Cells["NoiDung"].Value.ToString();
                                ctdangky.CreateBy = CNguoiDung.MaND;
                                ctdangky.CreateDate = DateTime.Now;

                                dangky.TT_CTDangKyKiemTras.Add(ctdangky);
                            }

                        if (dgvCTDangKyKiemTra.DataSource == null)
                            if (_cDangKyKT.Them(dangky))
                            {
                                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnXem.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        else
                            if (_cDangKyKT.Sua(dangky))
                            {
                                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnXem.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        foreach (DataGridViewRow item in dgvCTDangKyKiemTra.SelectedRows)
                        {
                            TT_CTDangKyKiemTra ctdangky = _cDangKyKT.GetCT(item.Cells["DanhBo"].Value.ToString());
                            if (!_cDangKyKT.XoaCT(ctdangky))
                            {
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        ///xóa tờ trình nếu hết chi tiết
                        if (_cDangKyKT.CountCT(decimal.Parse(dgvDangKyKiemTra.SelectedRows[0].Cells["MaDKKT"].Value.ToString())) == 0)
                        {
                            TT_DangKyKiemTra dangky = _cDangKyKT.Get(decimal.Parse(dgvDangKyKiemTra.SelectedRows[0].Cells["MaDKKT"].Value.ToString()));
                            _cDangKyKT.Xoa(dangky);
                        }
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXem.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvCTDangKyKiemTra.Rows)
            {
                DataRow dr = ds.Tables["DangKyHD0"].NewRow();

                dr["SoPhieu"] = dgvDangKyKiemTra.CurrentRow.Cells["MaDKKT"].Value.ToString().Insert(dgvDangKyKiemTra.CurrentRow.Cells["MaDKKT"].Value.ToString().Length-2, "-");
                dr["NhanVien"] = item.Cells["HanhThu"].Value;
                dr["NgayLap"] = item.Cells["NgayNhan"].Value;
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["GB_DM_Cu"] = item.Cells["GB_DM_Cu"].Value;
                dr["NoiDung"] = item.Cells["NoiDung"].Value;
                ds.Tables["DangKyHD0"].Rows.Add(dr);
            }

            rptDangKyKiemTra rpt = new rptDangKyKiemTra();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvCTDangKyKiemTra_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (dgvCTDangKyKiemTra.Columns[e.ColumnIndex].Name == "NoiDung" && dgvCTDangKyKiemTra.CurrentRow.Cells["MaCTDKKT"].Value.ToString()!="" && e.FormattedValue.ToString() != dgvCTDangKyKiemTra[e.ColumnIndex, e.RowIndex].Value.ToString())
                {
                    TT_CTDangKyKiemTra ctdangky = _cDangKyKT.GetCT(int.Parse(dgvCTDangKyKiemTra["MaCTDKKT", e.RowIndex].Value.ToString()));
                    ctdangky.NoiDung = e.FormattedValue.ToString();
                    _cDangKyKT.SuaCT(ctdangky);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvCTDangKyKiemTra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCTDangKyKiemTra.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvCTDangKyKiemTra.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
        }

        private void dgvCTDangKyKiemTra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvCTDangKyKiemTra.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDangKyKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDangKyKiemTra.RowCount > 0)
                dgvCTDangKyKiemTra.DataSource = _cDangKyKT.GetDSCT(decimal.Parse(dgvDangKyKiemTra["MaDKKT", e.RowIndex].Value.ToString()));
        }

        private void dgvDangKyKiemTra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDangKyKiemTra.Columns[e.ColumnIndex].Name == "MaDKKT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDangKyKiemTra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDangKyKiemTra.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (_cDangKyKT.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")) == true)
            {
                string ID = _cDangKyKT.GetMaDKKT(txtDanhBo.Text.Trim().Replace(" ", "")).ToString();
                MessageBox.Show("Đã đăng ký ở tờ trình số: " + ID.Insert(ID.Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Chưa đăng ký", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            txtTongSo.Text = _cDangKyKT.CountCT(dateTu.Value,dateDen.Value).ToString();
            txtBaoBinhThuong.Text = _cDangKyKT.CountCT_BinhThuong(dateTu.Value, dateDen.Value).ToString();
            txtBaoTrung.Text = (int.Parse(txtTongSo.Text.Trim()) - int.Parse(txtBaoBinhThuong.Text.Trim())).ToString();
        }

        
    }
}
