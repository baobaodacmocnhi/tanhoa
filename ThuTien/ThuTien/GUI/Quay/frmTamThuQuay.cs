using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao;
using ThuTien.BaoCao.Quay;
using ThuTien.GUI.BaoCao;
using ThuTien.GUI.TimKiem;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.DAL.DongNuoc;

namespace ThuTien.GUI.Quay
{
    public partial class frmTamThuQuay : Form
    {
        string _mnu = "mnuTamThuQuay";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CXacNhanNo _cXacNhanNo = new CXacNhanNo();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmTamThuQuay()
        {
            InitializeComponent();
        }

        private void frmTamThu_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTamThu.AutoGenerateColumns = false;
            dgvXacNhanNo.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            dateDen_XacNhanNo.Value = DateTime.Now;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            dgvHoaDon.DataSource = null;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
            {
                if (tabControl.SelectedTab.Name == "tabThongTin")
                {
                    dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim().Replace(" ", ""));

                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    {
                        item.Cells["Chon"].Value = "True";
                        if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon"].Value.ToString()))
                            item.DefaultCellStyle.BackColor = Color.Yellow;
                        item.Cells["DongNuoc"].Value = _cDongNuoc.GetNgayDNBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString());
                        if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                            item.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                else
                    if (tabControl.SelectedTab.Name == "tabTamThu")
                    {
                        dgvTamThu.DataSource = _cTamThu.GetDS(false, txtDanhBo.Text.Trim().Replace(" ", ""));
                    }
                    else
                        if (tabControl.SelectedTab.Name == "tabXacNhanNo")
                        {
                            dgvXacNhanNo.DataSource = _cXacNhanNo.GetDS(txtDanhBo.Text.Trim().Replace(" ", ""));
                        }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    if (item.Cells["Chon"].Value!=null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                    {
                        string loai = "";
                        if (_cTamThu.CheckExist(item.Cells["SoHoaDon"].Value.ToString(), out loai))
                        {
                            MessageBox.Show("Hóa Đơn này đã có Tạm Thu("+loai+")", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvHoaDon.CurrentCell = item.Cells["DanhBo"];
                            item.Selected = true;
                            return;
                        }

                        //if (_cDCHD.CheckExistByDangRutDC(item.Cells["SoHoaDon"].Value.ToString()))
                        //{
                        //    MessageBox.Show("Hóa Đơn này đã Rút đi Điều Chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    dgvHoaDon.CurrentCell = item.Cells["DanhBo"];
                        //    item.Selected = true;
                        //    return;
                        //}
                    }
                List<TAMTHU> lstTamThu = new List<TAMTHU>();
                try
                {
                    _cTamThu.BeginTransaction();
                    decimal SoPhieu = _cTamThu.GetMaxSoPhieu();
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                        if (item.Cells["Chon"].Value!=null&&bool.Parse(item.Cells["Chon"].Value.ToString()))
                        {
                            TAMTHU tamthu = new TAMTHU();
                            tamthu.DANHBA = item.Cells["DanhBo"].Value.ToString();
                            tamthu.FK_HOADON = int.Parse(item.Cells["MaHD"].Value.ToString());
                            tamthu.SoHoaDon = item.Cells["SoHoaDon"].Value.ToString();
                            tamthu.SoPhieu = SoPhieu;

                            if (_cTamThu.Them(tamthu))
                            {
                                lstTamThu.Add(tamthu);
                            }
                            else
                            {
                                _cTamThu.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    _cTamThu.CommitTransaction();
                }
                catch (Exception)
                {
                    _cTamThu.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Ky = "";
                Int32 TongCongSo = 0;
                foreach (var item in lstTamThu)
                {
                    HOADON hd = _cHoaDon.Get(item.SoHoaDon);
                    if(Ky=="")
                        Ky += hd.KY + "/" + hd.NAM + ": " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (Int32)hd.TONGCONG);
                    else
                        Ky += ", " + hd.KY + "/" + hd.NAM + ": " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (Int32)hd.TONGCONG);
                    TongCongSo += (Int32)hd.TONGCONG;
                }

                dsBaoCao ds = new dsBaoCao();
                HOADON hdIn = _cHoaDon.Get(lstTamThu[0].SoHoaDon);
                DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
                dr["SoPhieu"] = lstTamThu[0].SoPhieu.ToString().Insert(lstTamThu[0].SoPhieu.ToString().Length - 2, "-");
                dr["DanhBo"] = lstTamThu[0].DANHBA.Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = hdIn.TENKH;
                dr["DiaChi"] = hdIn.SO + " " + hdIn.DUONG;
                dr["MLT"] = hdIn.MALOTRINH.Insert(4, " ").Insert(2, " ");
                dr["GiaBieu"] = hdIn.GB;
                dr["DinhMuc"] = hdIn.DM;
                dr["Ky"] = Ky;
                dr["TongCongSo"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongSo);
                dr["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
                if (hdIn.MaNV_HanhThu != null)
                    dr["NhanVienThuTien"] = _cNguoiDung.GetHoTenByMaND(hdIn.MaNV_HanhThu.Value);
                dr["NhanVienQuay"] = CNguoiDung.HoTen;
                ds.Tables["PhieuTamThu"].Rows.Add(dr);

                rptPhieuTamThu rpt = new rptPhieuTamThu();
                rpt.SetDataSource(ds);
                frmInQuay frm = new frmInQuay(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabThongTin")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
            }
            else
                if (tabControl.SelectedTab.Name == "tabTamThu")
                {
                    btnThem.Enabled = false;
                    btnXoa.Enabled = true;
                }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateDen.Value >= dateTu.Value)
                dgvTamThu.DataSource = _cTamThu.GetDS(false, dateTu.Value, dateDen.Value);
            string HoTen = "", TenTo = "";
            foreach (DataGridViewRow item in dgvTamThu.Rows)
            {
                if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon_TT"].Value.ToString(), out HoTen, out TenTo))
                {
                    item.Cells["HanhThu_TT"].Value = HoTen;
                    item.Cells["To_TT"].Value = TenTo;
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                }
                //if (_cDongNuoc.CheckCTDongNuocBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString()))
                //    item.DefaultCellStyle.BackColor = Color.Yellow;
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon_TT"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (CNguoiDung.Doi == false)
                    {
                        DateTime CreateDate = new DateTime();
                        DateTime.TryParse(dgvTamThu.SelectedRows[0].Cells["CreateDate_TT"].Value.ToString(), out CreateDate);
                        if (CreateDate.Date != DateTime.Now.Date)
                        {
                            MessageBox.Show("Chỉ được Điều Chỉnh trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    foreach (DataGridViewRow item in dgvTamThu.SelectedRows)
                    {
                        TAMTHU tamthu = _cTamThu.GetByMaTT(int.Parse(item.Cells["MaTT"].Value.ToString()));
                        if (!_cHoaDon.CheckDangNganBySoHoaDon(tamthu.SoHoaDon))
                        {
                            if (!_cTamThu.Xoa(tamthu))
                            {
                                //MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                            }
                        }
                        else
                        {
                            dgvTamThu.ClearSelection();
                            item.Selected = true;
                            MessageBox.Show("Hóa đơn đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTamThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "MLT_TT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "DanhBo_TT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TieuThu_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "GiaBan_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "ThueGTGT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "PhiBVMT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TongCong_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTamThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTamThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXacNhanNo_Click(object sender, EventArgs e)
        {
            string Ky = "Hết nợ";
            Int32 TongCongSo = 0;
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                if (Ky == "Hết nợ")
                    Ky = "Còn nợ Kỳ " + item.Cells["Ky"].Value.ToString() + ": " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Int32.Parse(item.Cells["TongCong"].Value.ToString()));
                else
                    Ky += ", " + item.Cells["Ky"].Value.ToString() + ": " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Int32.Parse(item.Cells["TongCong"].Value.ToString()));
                TongCongSo += Int32.Parse(item.Cells["TongCong"].Value.ToString());
            }

            if (_cXacNhanNo.CheckExist(txtDanhBo.Text.Trim(), DateTime.Now))
            {
                MessageBox.Show("Danh Bộ này đã có Xác Nhận Nợ trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim());
            TT_XacNhanNo xacnhanno = new TT_XacNhanNo();
            xacnhanno.TinhDenKy = "Tính đến Kỳ " + hoadon.KY + "/" + hoadon.NAM;
            if (_cLenhHuy.GetCatByDanhBo(hoadon.DANHBA))
                xacnhanno.Cat = "ĐỀ NGHỊ K/H LIÊN HỆ P.KINH DOANH\nLÀM THỦ TỤC VÀ ĐÓNG CHI PHÍ NỐI LẠI ỐNG";

            if (dgvHoaDon.RowCount > 0)
            {
                xacnhanno.DanhBo = dgvHoaDon["DanhBo", 0].Value.ToString();
                xacnhanno.HoTen = dgvHoaDon["HoTen", 0].Value.ToString();
                xacnhanno.DiaChi = dgvHoaDon["DiaChi", 0].Value.ToString();
                xacnhanno.MLT = dgvHoaDon["MLT", 0].Value.ToString().Insert(4, " ").Insert(2, " ");
                xacnhanno.GiaBieu = int.Parse(dgvHoaDon["GiaBieu", 0].Value.ToString());
                if (!string.IsNullOrEmpty(dgvHoaDon["DinhMuc", 0].Value.ToString()))
                    xacnhanno.DinhMuc = int.Parse(dgvHoaDon["DinhMuc", 0].Value.ToString());
                xacnhanno.Ky = Ky;
                xacnhanno.TongCong = TongCongSo;
                //xacnhanno.CreateBy = CNguoiDung.MaND;
            }
            else
            {
                xacnhanno.DanhBo = hoadon.DANHBA;
                xacnhanno.HoTen = hoadon.TENKH;
                xacnhanno.DiaChi = hoadon.SO + " " + hoadon.DUONG;
                xacnhanno.MLT = hoadon.MALOTRINH;
                xacnhanno.GiaBieu = hoadon.GB;
                if (hoadon.DM != null)
                    xacnhanno.DinhMuc = (int)hoadon.DM;
                xacnhanno.Ky = Ky;
                xacnhanno.TongCong = TongCongSo;
                //xacnhanno.CreateBy = CNguoiDung.MaND;
            }

            if (_cXacNhanNo.Them(xacnhanno))
            {
                dsBaoCao ds = new dsBaoCao();
                DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
                dr["SoPhieu"] = xacnhanno.SoPhieu.ToString().Insert(xacnhanno.SoPhieu.ToString().Length - 2, "-");
                dr["DanhBo"] = xacnhanno.DanhBo.Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = xacnhanno.HoTen;
                dr["DiaChi"] = xacnhanno.DiaChi;
                dr["MLT"] = xacnhanno.MLT.Insert(4, " ").Insert(2, " ");
                dr["GiaBieu"] = xacnhanno.GiaBieu;
                if (xacnhanno.DinhMuc == null)
                    dr["DinhMuc"] = 0;
                else
                    dr["DinhMuc"] = xacnhanno.DinhMuc;
                dr["Ky"] = Ky;
                dr["TongCongSo"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##} đồng", TongCongSo);
                dr["TinhDenKy"] = xacnhanno.TinhDenKy;
                if (xacnhanno.Cat != null)
                    dr["Cat"] = xacnhanno.Cat;
                //dr["NhanVienQuay"] = CNguoiDung.HoTen;
                ds.Tables["PhieuTamThu"].Rows.Add(dr);

                rptXacNhanNo rpt = new rptXacNhanNo();
                rpt.SetDataSource(ds);
                frmInQuay frm = new frmInQuay(rpt);
                frm.Show();  
            }
            while (dgvHoaDon.Rows.Count > 0)
            {
                dgvHoaDon.Rows.RemoveAt(0);
            }
        }

        private void btnInTamThu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvTamThu.SelectedRows)
                {
                    string Ky = "";
                    Int32 TongCongSo = 0;
                    List<TAMTHU> lstTamThu = _cTamThu.GetDSBySoPhieu(decimal.Parse(item.Cells["SoPhieu_TT"].Value.ToString()));
                    foreach (var itemTT in lstTamThu)
                    {
                        HOADON hd = _cHoaDon.Get(itemTT.SoHoaDon);
                        Ky += hd.KY + "/" + hd.NAM + ": " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (Int32)hd.TONGCONG) + ", ";
                        TongCongSo += (Int32)hd.TONGCONG;
                    }

                    dsBaoCao ds = new dsBaoCao();
                    HOADON hdIn = _cHoaDon.Get(lstTamThu[0].SoHoaDon);
                    DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
                    dr["SoPhieu"] = lstTamThu[0].SoPhieu.ToString().Insert(lstTamThu[0].SoPhieu.ToString().Length - 2, "-");
                    dr["DanhBo"] = lstTamThu[0].DANHBA.Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = hdIn.TENKH;
                    dr["DiaChi"] = hdIn.SO + " " + hdIn.DUONG;
                    dr["MLT"] = hdIn.MALOTRINH.Insert(4, " ").Insert(2, " ");
                    dr["GiaBieu"] = hdIn.GB;
                    dr["DinhMuc"] = hdIn.DM;
                    dr["Ky"] = Ky;
                    dr["TongCongSo"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongSo);
                    dr["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
                    if (hdIn.MaNV_HanhThu != null)
                        dr["NhanVienThuTien"] = _cNguoiDung.GetHoTenByMaND(hdIn.MaNV_HanhThu.Value);
                    //dr["NhanVienQuay"] = CNguoiDung.HoTen;
                    ds.Tables["PhieuTamThu"].Rows.Add(dr);

                    rptPhieuTamThu rpt = new rptPhieuTamThu();
                    rpt.SetDataSource(ds);
                    frmInQuay frm = new frmInQuay(rpt);
                    frm.Show();
                }
        }

        private void btnInDSTamThu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTamThu.Rows)
            {
                DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = "TẠM THU QUẦY";
                dr["DanhBo"] = item.Cells["DanhBo_TT"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = item.Cells["HoTen_TT"].Value.ToString();
                dr["MLT"] = item.Cells["MLT_TT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                dr["Ky"] = item.Cells["Ky_TT"].Value.ToString();
                dr["TongCong"] = item.Cells["TongCong_TT"].Value.ToString();
                dr["HanhThu"] = item.Cells["HanhThu_TT"].Value.ToString();
                dr["To"] = item.Cells["To_TT"].Value.ToString();
                if (int.Parse(item.Cells["GiaBieu_TT"].Value.ToString()) > 20)
                    dr["Loai"] = "CQ";
                else
                    dr["Loai"] = "TG";
                ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
            }
            rptDSTamThuChuyenKhoan rpt = new rptDSTamThuChuyenKhoan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnXem_XacNhanNo_Click(object sender, EventArgs e)
        {
            dgvXacNhanNo.DataSource = _cXacNhanNo.GetDS(dateDen_XacNhanNo.Value);
        }

        private void btnIn_XacNhanNo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvXacNhanNo.SelectedRows)
            {
                dsBaoCao ds = new dsBaoCao();
                DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
                dr["SoPhieu"] = item.Cells["SoPhieu_XacNhanNo"].Value.ToString().Insert(item.Cells["SoPhieu_XacNhanNo"].Value.ToString().Length - 2, "-");
                dr["DanhBo"] = item.Cells["DanhBo_XacNhanNo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = item.Cells["HoTen_XacNhanNo"].Value.ToString();
                dr["DiaChi"] = item.Cells["DiaChi_XacNhanNo"].Value.ToString();
                dr["MLT"] = item.Cells["MLT_XacNhanNo"].Value.ToString().Insert(4, " ").Insert(2, " ");
                dr["GiaBieu"] = item.Cells["GiaBieu_XacNhanNo"].Value.ToString();
                if (item.Cells["DinhMuc_XacNhanNo"].Value == null)
                    dr["DinhMuc"] = 0;
                else
                    dr["DinhMuc"] = item.Cells["DinhMuc_XacNhanNo"].Value.ToString();
                if (item.Cells["Ky_XacNhanNo"].Value != null)
                    dr["Ky"] = item.Cells["Ky_XacNhanNo"].Value.ToString();
                if (item.Cells["TongCong_XacNhanNo"].Value != null)
                    dr["TongCongSo"] = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##} đồng", (int)item.Cells["TongCong_XacNhanNo"].Value);
                if (item.Cells["TinhDenKy_XacNhanNo"].Value != null)
                    dr["TinhDenKy"] = item.Cells["TinhDenKy_XacNhanNo"].Value.ToString();
                if (item.Cells["Cat_XacNhanNo"].Value != null)
                    dr["Cat"] = item.Cells["Cat_XacNhanNo"].Value.ToString();
                //dr["NhanVienQuay"] = CNguoiDung.HoTen;
                ds.Tables["PhieuTamThu"].Rows.Add(dr);

                rptXacNhanNo rpt = new rptXacNhanNo();
                rpt.SetDataSource(ds);
                frmInQuay frm = new frmInQuay(rpt);
                frm.Show();
            }

        }

        private void btnXoa_XacNhanNo_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _cXacNhanNo.BeginTransaction();
                    foreach (DataGridViewRow item in dgvXacNhanNo.SelectedRows)
                    {
                        TT_XacNhanNo xacnhanno = _cXacNhanNo.GetBySoPhieu(int.Parse(item.Cells["SoPhieu_XacNhanNo"].Value.ToString()));
                        if (!_cXacNhanNo.Xoa(xacnhanno))
                            {
                                _cXacNhanNo.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                    }
                    _cXacNhanNo.CommitTransaction();
                    btnXem_XacNhanNo.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvXacNhanNo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvXacNhanNo.Columns[e.ColumnIndex].Name == "SoPhieu_XacNhanNo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length-2, "-");
            }
            if (dgvXacNhanNo.Columns[e.ColumnIndex].Name == "DanhBo_XacNhanNo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvXacNhanNo.Columns[e.ColumnIndex].Name == "TongCong_XacNhanNo" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvXacNhanNo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvXacNhanNo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (tabControl.SelectedTab.Name == "tabThongTin")
            {
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    if (item.Cells["DanhBo"].Value.ToString() == NoiDung)
                    {
                        dgvHoaDon.CurrentCell = item.Cells["DanhBo"];
                        item.Selected = true;
                    }
            }
            else
                if (tabControl.SelectedTab.Name == "tabTamThu")
                {
                    foreach (DataGridViewRow item in dgvTamThu.Rows)
                        if (item.Cells["DanhBo_TT"].Value.ToString() == NoiDung)
                        {
                            dgvTamThu.CurrentCell = item.Cells["DanhBo_TT"];
                            item.Selected = true;
                        }
                }
                else
                    if (tabControl.SelectedTab.Name == "tabXacNhanNo")
                    {
                        foreach (DataGridViewRow item in dgvXacNhanNo.Rows)
                            if (item.Cells["DanhBo_XacNhanNo"].Value.ToString() == NoiDung)
                            {
                                dgvXacNhanNo.CurrentCell = item.Cells["DanhBo_XacNhanNo"];
                                item.Selected = true;
                            }
                    }

        }

        private void frmTamThuQuay_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvTamThu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "Tra_TT" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvTamThu[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TAMTHU tamthu = _cTamThu.GetByMaTT(int.Parse(dgvTamThu["MaTT", e.RowIndex].Value.ToString()));
                    tamthu.Tra = bool.Parse(e.FormattedValue.ToString());
                    if (tamthu.Tra)
                        tamthu.NgayTra = DateTime.Now;
                    else
                        tamthu.NgayTra = null;
                    _cTamThu.Sua(tamthu);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dgvTamThu.Columns[e.ColumnIndex].Name == "GhiChuTra_TT" && e.FormattedValue.ToString().Trim() != dgvTamThu[e.ColumnIndex, e.RowIndex].Value.ToString().Trim())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TAMTHU tamthu = _cTamThu.GetByMaTT(int.Parse(dgvTamThu["MaTT", e.RowIndex].Value.ToString()));
                    tamthu.GhiChuTra = e.FormattedValue.ToString().Trim();
                    _cTamThu.Sua(tamthu);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInTamThuKhong_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            DataRow dr = ds.Tables["PhieuTamThu"].NewRow();
            dr["SoPhieu"] = "";
            dr["DanhBo"] = "";
            dr["HoTen"] = "";
            dr["DiaChi"] = "";
            dr["MLT"] = "";
            dr["GiaBieu"] = "";
            dr["DinhMuc"] = "";
            dr["Ky"] = "";
            dr["NhanVienThuTien"] = "";
            ds.Tables["PhieuTamThu"].Rows.Add(dr);

            rptPhieuTamThu rpt = new rptPhieuTamThu();
            rpt.SetDataSource(ds);
            frmInQuay frm = new frmInQuay(rpt);
            frm.Show();
        }  

    }
}
