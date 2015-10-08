using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.GUI.TimKiem;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmBangKe : Form
    {
        string _mnu = "mnuBangKe";
        CBangKe _cBangKe = new CBangKe();
        CNganHang _cNganHang = new CNganHang();
        CTienDu _cTienDu = new CTienDu();
        
        public frmBangKe()
        {
            InitializeComponent();
        }

        private void frmBangKe_Load(object sender, EventArgs e)
        {
            dgvBangKe.AutoGenerateColumns = false;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Excel fileExcel = new Excel(dialog.FileName);
                        DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                        foreach (DataRow item in dtExcel.Rows)
                            if (!string.IsNullOrEmpty(item[1].ToString()) && !string.IsNullOrEmpty(item[2].ToString()))
                            {
                                //if (item[0].ToString().Length == 11 && _cBangKe.CheckExist(item[0].ToString(), DateTime.Now))
                                //{
                                //    MessageBox.Show("Danh Bộ: " + item[0].ToString() + " đã thêm trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    continue;
                                //}
                                TT_BangKe bangke = new TT_BangKe();
                                bangke.DanhBo = item[0].ToString().Trim();
                                bangke.SoTien = int.Parse(item[1].ToString().Trim());
                                bangke.MaNH = _cNganHang.GetMaNHByKyHieu(item[2].ToString().Trim());
                                bangke.CreateDate = dateNgayLap.Value;
                                bangke.CreateBy = CNguoiDung.MaND;
                                if (_cBangKe.Them(bangke))
                                    _cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value);
                            }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    btnXem.PerformClick();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvBangKe.DataSource = _cBangKe.GetDS(dateTu.Value,dateDen.Value);
            int TongCong = 0;
            if (dgvBangKe.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvBangKe.Rows)
                {
                    TongCong += int.Parse(item.Cells["SoTien"].Value.ToString());
                }
                txtTongHD.Text = dgvBangKe.RowCount.ToString();
                txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        foreach (DataGridViewRow item in dgvBangKe.SelectedRows)
                        {
                            TT_BangKe bangke = _cBangKe.Get(int.Parse(item.Cells["MaBK"].Value.ToString()));
                            if (_cBangKe.Xoa(bangke))
                                _cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value * -1);
                        }
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            foreach (DataGridViewRow item in dgvBangKe.Rows)
                if (item.Cells["DanhBo"].Value.ToString() == NoiDung || item.Cells["SoTien"].Value.ToString() == NoiDung)
                {
                    dgvBangKe.CurrentCell = item.Cells["DanhBo"];
                    item.Selected = true;
                }
        }

        private void dgvBangKe_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgvBangKe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length==11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvBangKe_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangKe.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBangKe_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "DanhBo" && e.FormattedValue.ToString().Replace(" ", "") != dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                TT_BangKe bangke = _cBangKe.Get(int.Parse(dgvBangKe["MaBK", e.RowIndex].Value.ToString()));
                bangke.DanhBo = e.FormattedValue.ToString().Replace(" ", "");
                if (_cBangKe.Sua(bangke))
                {
                    _cTienDu.Update(dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", ""), bangke.SoTien.Value * (-1));
                    _cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value);
                }
            }
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            ThuTien.DAL.Doi.CHoaDon _cHoaDon = new DAL.Doi.CHoaDon();
            CNguoiDung _cNguoiDung=new CNguoiDung();
            CTo _cTo = new CTo();
            ThuTien.BaoCao.dsBaoCao ds = new ThuTien.BaoCao.dsBaoCao();
            foreach (DataGridViewRow item in dgvBangKe.Rows)
                if(!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()))
                {
                    HOADON hd = _cHoaDon.GetMoiNhat(item.Cells["DanhBo"].Value.ToString());
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                    dr["LoaiBaoCao"] = "CHUYỂN KHOẢN TỒN";
                    dr["DanhBo"] = hd.DANHBA.Insert(4, " ").Insert(8, " ");
                    dr["DiaChi"] = hd.SO + " " + hd.DUONG;
                    dr["MLT"] = hd.MALOTRINH;
                    dr["TongCong"] = item.Cells["SoTien"].Value.ToString();
                    if (hd.MaNV_HanhThu != null)
                    {
                        dr["NhanVien"] = _cNguoiDung.GetHoTenByMaND(int.Parse(hd.MaNV_HanhThu.Value.ToString()));
                        dr["To"] = _cNguoiDung.GetTenToByMaND(int.Parse(hd.MaNV_HanhThu.Value.ToString()));
                    }
                    if (hd.GB.Value > 20)
                        dr["Loai"] = "CQ";
                    else
                        dr["Loai"] = "TG";
                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            ThuTien.BaoCao.TongHop.rptDSThu2Lan rpt = new ThuTien.BaoCao.TongHop.rptDSThu2Lan();
            rpt.SetDataSource(ds);
            ThuTien.GUI.BaoCao.frmBaoCao frm = new ThuTien.GUI.BaoCao.frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void frmBangKe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                frmTimKiemForm frm = new frmTimKiemForm();
                bool flag = false;
                foreach (var item in this.OwnedForms)
                    if (item.Name == frm.Name)
                    {
                        item.Activate();
                        flag = true;
                    }
                if (flag == false)
                {
                    frm.MyGetNoiDung = new frmTimKiemForm.GetNoiDung(GetNoiDungfrmTimKiem);
                    frm.Owner = this;
                    frm.Show();
                }
            }
        }

        
    }
}
