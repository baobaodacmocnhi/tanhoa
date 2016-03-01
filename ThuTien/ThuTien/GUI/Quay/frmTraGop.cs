using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using ThuTien.DAL.Quay;
using ThuTien.DAL.QuanTri;
using ThuTien.BaoCao;
using ThuTien.BaoCao.Quay;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.Quay
{
    public partial class frmTraGop : Form
    {
        string _mnu = "mnuTraGop";
        CHoaDon _cHoaDon = new CHoaDon();
        CTraGop _cTraGop = new CTraGop();
        CTamThu _cTamThu = new CTamThu();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmTraGop()
        {
            InitializeComponent();
        }

        private void frmTraGop_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTraGop.AutoGenerateColumns = false;
        }

        public void LoadDanhSach()
        {
            dgvTraGop.DataSource = _cTraGop.GetDSBySoHoaDon(dgvHoaDon.CurrentRow.Cells["SoHoaDon"].Value.ToString());
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
                if (_cHoaDon.CheckExist(txtSoHoaDon.Text.Trim()))
                {
                    dgvHoaDon.Rows.Clear();
                    HOADON hoadon = _cHoaDon.Get(txtSoHoaDon.Text.Trim());
                    dgvHoaDon.Rows.Add(hoadon.ID_HOADON,hoadon.SOHOADON,hoadon.KY+"/"+hoadon.NAM,hoadon.MALOTRINH,hoadon.SOPHATHANH,hoadon.DANHBA,hoadon.SO+" "+hoadon.DUONG,hoadon.TENKH,hoadon.TONGCONG);
                    txtSoHoaDon.Text = "";
                }
                else
                    MessageBox.Show("Hóa Đơn sai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cTraGop.GetDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                TT_TraGop tragop = new TT_TraGop();

                //tragop.MaHD = int.Parse(dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString());
                tragop.SoHoaDon = dgvHoaDon.CurrentRow.Cells["SoHoaDon"].Value.ToString();
                //string[] date = dgvHoaDon.CurrentRow.Cells["NgayTra"].Value.ToString().Split('/');
                //tragop.NgayTra = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                tragop.NgayTra = dateTra.Value;
                tragop.SoTien = int.Parse(txtSoTien.Text.Trim());

                if (_cTraGop.Them(tragop))
                {
                    LoadDanhSach();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                TT_TraGop tragop = _cTraGop.GetByMaTG(int.Parse(dgvTraGop.CurrentRow.Cells["MaTG"].Value.ToString()));

                //string[] date = dgvHoaDon.CurrentRow.Cells["NgayTra"].Value.ToString().Split('/');
                //tragop.NgayTra = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                //tragop.SoTien = int.Parse(dgvHoaDon.CurrentRow.Cells["SoTien"].Value.ToString());
                tragop.NgayTra = dateTra.Value;
                tragop.SoTien = int.Parse(txtSoTien.Text.Trim());

                if (_cTraGop.Sua(tragop))
                {
                    LoadDanhSach();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    TT_TraGop tragop = _cTraGop.GetByMaTG(int.Parse(dgvTraGop.CurrentRow.Cells["MaTG"].Value.ToString()));

                    if (_cTraGop.Xoa(tragop))
                    {
                        LoadDanhSach();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
            TT_TraGop tragop = _cTraGop.GetByMaTG(int.Parse(dgvTraGop.SelectedRows[0].Cells["MaTG"].Value.ToString()));
            HOADON hd = _cHoaDon.Get(tragop.SoHoaDon);
            dr["SoPhieu"] = tragop.MaTG.ToString().Insert(tragop.MaTG.ToString().Length - 2, "-");
            dr["DanhBo"] = hd.DANHBA.Insert(4, " ").Insert(8, " ");
            dr["HoTen"] = hd.TENKH;
            dr["DiaChi"] = hd.SO + " " + hd.DUONG;
            dr["MLT"] = hd.MALOTRINH.Insert(4, " ").Insert(2, " ");
            dr["GiaBieu"] = hd.GB;
            dr["DinhMuc"] = hd.DM;
            dr["Ky"] = hd.KY + "/" + hd.NAM;
            dr["TongCongSo"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", tragop.SoTien);
            dr["TongCongChu"] = _cTamThu.ConvertMoneyToWord(tragop.SoTien.ToString());
            if (hd.MaNV_HanhThu != null)
                dr["NhanVienThuTien"] = _cNguoiDung.GetHoTenByMaND(hd.MaNV_HanhThu.Value);
            dr["NhanVienQuay"] = CNguoiDung.HoTen;
            ds.Tables["PhieuTamThu"].Rows.Add(dr);

            rptPhieuTamThuTraGop rpt = new rptPhieuTamThuTraGop();
            rpt.SetDataSource(ds);
            frmInQuay frm = new frmInQuay(rpt);
            frm.Show();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDanhSach();
        }

        private void dgvTraGop_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTraGop.Columns[e.ColumnIndex].Name == "DaThanhToan")
            {
                TT_TraGop tragop = _cTraGop.GetByMaTG(int.Parse(dgvTraGop.CurrentRow.Cells["MaTG"].Value.ToString()));

                if (tragop.DaThanhToan != bool.Parse(dgvTraGop.CurrentRow.Cells["DaThanhToan"].Value.ToString()))
                {
                    tragop.DaThanhToan = bool.Parse(dgvTraGop.CurrentRow.Cells["DaThanhToan"].Value.ToString());
                    if (tragop.SoPhieu == null)
                        tragop.SoPhieu = _cTraGop.GetNextSoPhieu();
                    _cTraGop.Sua(tragop);
                }
            }
        }

        private void dgvTraGop_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTraGop.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTraGop_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTraGop.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTraGop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dateTra.Value = DateTime.Parse(dgvTraGop["NgayTra", e.RowIndex].Value.ToString());
                txtSoTien.Text = dgvTraGop["SoTien", e.RowIndex].Value.ToString();
            }
            catch
            {
            }
        }
        
    }
}
