using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.BaoCao;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;
using ThuTien.GUI.TimKiem;
using ThuTien.DAL;
using System.Transactions;
using ThuTien.DAL.TongHop;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmTienDu : Form
    {
        string _mnu = "mnuTienDu";
        CTienDu _cTienDu = new CTienDu();
        CHoaDon _cHoaDon = new CHoaDon();
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CTamThu _cTamThu = new CTamThu();
        CBangKe _cBangKe = new CBangKe();
        CDHN _cDocSo = new CDHN();
        CNganHang _cNganHang = new CNganHang();
        CDCHD _cDCHD = new CDCHD();

        public frmTienDu()
        {
            InitializeComponent();
        }

        private void frmTienDu_Load(object sender, EventArgs e)
        {
            dgvTienAm.AutoGenerateColumns = false;
            dgvTienDu.AutoGenerateColumns = false;

            dateNgayGiaiTrach.Value = DateTime.Now;

            cmbFromDot.SelectedIndex = 0;
            cmbToDot.SelectedIndex = 0;
        }

        public void CountdgvTienDu()
        {
            long TongCong = 0;
            if (dgvTienDu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvTienDu.Rows)
                {
                    TongCong += long.Parse(item.Cells["SoTien_TienDu"].Value.ToString());
                }
                txtTongCongTienDu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvTienAm()
        {
            long TongCong = 0;
            if (dgvTienAm.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvTienAm.Rows)
                {
                    TongCong += long.Parse(item.Cells["SoTien_TienAm"].Value.ToString());
                }
                txtTongCongTienAm.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void dgvTienAm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTienAm.Columns[e.ColumnIndex].Name == "DanhBo_TienAm" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTienAm.Columns[e.ColumnIndex].Name == "SoTien_TienAm" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTienAm_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTienAm.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "DanhBo_TienDu" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTienDu.Columns[e.ColumnIndex].Name == "SoTien_TienDu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTienDu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTienDu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTienDu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if ((dgvTienDu.Columns[e.ColumnIndex].Name == "DienThoai_TienDu" && e.FormattedValue.ToString().Replace(" ", "") != dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString())
                    || (dgvTienDu.Columns[e.ColumnIndex].Name == "ChoXuLy_TienDu" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString())))
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (dgvTienDu.Columns[e.ColumnIndex].Name == "DienThoai_TienDu" && e.FormattedValue.ToString().Replace(" ", "") != dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString())
                        {
                            TT_TienDu tiendu = _cTienDu.Get(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString());
                            tiendu.DienThoai = e.FormattedValue.ToString();
                            _cTienDu.Sua(tiendu);
                        }
                        if (dgvTienDu.Columns[e.ColumnIndex].Name == "ChoXuLy_TienDu" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString()))
                        {
                            TT_TienDu tiendu = _cTienDu.Get(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString());
                            tiendu.ChoXuLy = bool.Parse(e.FormattedValue.ToString());
                            _cTienDu.Sua(tiendu);
                        }
                        //if (dgvTienDu.Columns[e.ColumnIndex].Name == "Quan" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvTienDu[e.ColumnIndex, e.RowIndex].Value.ToString()))
                        //{
                        //    TT_TienDu tiendu = _cTienDu.Get(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString());
                        //    tiendu.Quan = Int32.Parse(e.FormattedValue.ToString()).ToString();
                        //    _cTienDu.Sua(tiendu);
                        //}
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTienDu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTienDu.RowCount > 0 && e.Button == MouseButtons.Left && dgvTienDu.Columns[e.ColumnIndex].Name != "DienThoai_TienDu")
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    frmDieuChinhTienDu frm = new frmDieuChinhTienDu(dgvTienDu["DanhBo_TienDu", e.RowIndex].Value.ToString(), dgvTienDu["SoTien_TienDu", e.RowIndex].Value.ToString());
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _cTienDu.Refresh();
                        btnXem.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvTienAm.DataSource = _cTienDu.GetDSTienAm(CNguoiDung.FromDot, CNguoiDung.ToDot);
            CountdgvTienAm();
            dgvTienDu.DataSource = _cTienDu.GetDSTienDu(CNguoiDung.FromDot, CNguoiDung.ToDot);
            CountdgvTienDu();
        }

        private void btnInDSThuThem_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTienDu.Rows)
                if (_cHoaDon.CheckDCHDTienDuByDanhBo(item.Cells["DanhBo_TienDu"].Value.ToString()) == true)
                {
                    MessageBox.Show("Danh bộ: " + item.Cells["DanhBo_TienDu"].Value.ToString() + " có ĐCHĐ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<HOADON> lstHD = _cHoaDon.GetDSTon_CoChanTienDu(item.Cells["DanhBo_TienDu"].Value.ToString());

                    if (lstHD != null && lstHD.Count > 0 && !bool.Parse(item.Cells["ChoXuLy_TienDu"].Value.ToString()) && lstHD[0].DOT >= int.Parse(cmbFromDot.SelectedItem.ToString()) && lstHD[0].DOT <= int.Parse(cmbToDot.SelectedItem.ToString()) && int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) < lstHD.Sum(itemHD => itemHD.TONGCONG))
                    {
                        string ThongTin = "";
                        foreach (HOADON itemHD in lstHD)
                        ///nếu có trong dịch vụ thu thì không thu thêm
                        //if (!_cDichVuThu.CheckExist(itemHD.SOHOADON))
                        {
                            DataRow dr = ds.Tables["TienDuKhachHang"].NewRow();
                            dr["DanhBo"] = item.Cells["DanhBo_TienDu"].Value.ToString().Insert(4, " ").Insert(8, " ");
                            dr["HoTen"] = itemHD.TENKH;
                            dr["MLT"] = itemHD.MALOTRINH;
                            dr["DienThoai"] = _cDocSo.getDienThoai(itemHD.DANHBA);
                            dr["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                            dr["TienDu"] = item.Cells["SoTien_TienDu"].Value;
                            dr["TongCong"] = itemHD.TONGCONG;
                            if (lstHD[0].MaNV_HanhThu != null)
                            {
                                dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                                dr["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                            }
                            ThongTin += "Hóa đơn kỳ " + itemHD.KY + "/" + itemHD.NAM + " : " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemHD.TONGCONG) + " đồng\r\n";
                            dr["ThongTin"] = ThongTin;

                            ds.Tables["TienDuKhachHang"].Rows.Add(dr);

                            DataRow drTT = ds.Tables["TamThuChuyenKhoan"].NewRow();
                            drTT["LoaiBaoCao"] = "TIỀN DƯ THU THÊM";
                            drTT["DanhBo"] = itemHD.DANHBA.Insert(4, " ").Insert(8, " ");
                            drTT["HoTen"] = itemHD.TENKH;
                            drTT["MLT"] = itemHD.MALOTRINH;
                            drTT["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                            drTT["TongCong"] = itemHD.TONGCONG;
                            if (itemHD.MaNV_HanhThu != null)
                            {
                                drTT["HanhThu"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                                drTT["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                            }
                            if (itemHD.GB > 20)
                                drTT["Loai"] = "CQ";
                            else
                                drTT["Loai"] = "TG";
                            if (_cLenhHuy.CheckExist(itemHD.SOHOADON))
                                drTT["LenhHuy"] = true;
                            ds.Tables["TamThuChuyenKhoan"].Rows.Add(drTT);
                        }
                    }
                }
            rptTienDuKhachHang rpt = new rptTienDuKhachHang();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();

            rptDSTamThuChuyenKhoan rptTT = new rptDSTamThuChuyenKhoan();
            rptTT.SetDataSource(ds);
            frmBaoCao frmTT = new frmBaoCao(rptTT);
            frmTT.ShowDialog();
        }

        private void btnInDSDuTien_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTienDu.Rows)
                if (_cHoaDon.CheckDCHDTienDuByDanhBo(item.Cells["DanhBo_TienDu"].Value.ToString()) == true)
                {
                    MessageBox.Show("Danh bộ: " + item.Cells["DanhBo_TienDu"].Value.ToString() + " có ĐCHĐ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<HOADON> lstHD;
                    if (chkTruHoNgheo.Checked)
                        lstHD = _cHoaDon.GetDSTon_CoChanTienDu_TruHoNgheo(item.Cells["DanhBo_TienDu"].Value.ToString());
                    else
                        lstHD = _cHoaDon.GetDSTon_CoChanTienDu(item.Cells["DanhBo_TienDu"].Value.ToString());

                    if (lstHD != null && lstHD.Count > 0 && !bool.Parse(item.Cells["ChoXuLy_TienDu"].Value.ToString()) && lstHD[0].DOT >= int.Parse(cmbFromDot.SelectedItem.ToString()) && lstHD[0].DOT <= int.Parse(cmbToDot.SelectedItem.ToString()) && int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) >= lstHD.Sum(itemHD => itemHD.TONGCONG))
                    {
                        string ThongTin = "";
                        foreach (HOADON itemHD in lstHD)
                        {
                            DataRow dr = ds.Tables["TienDuKhachHang"].NewRow();
                            dr["DanhBo"] = item.Cells["DanhBo_TienDu"].Value.ToString().Insert(4, " ").Insert(8, " ");
                            dr["HoTen"] = itemHD.TENKH;
                            dr["MLT"] = itemHD.MALOTRINH;
                            dr["DienThoai"] = _cDocSo.getDienThoai(itemHD.DANHBA);
                            dr["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                            dr["TienDu"] = item.Cells["SoTien_TienDu"].Value;
                            dr["TongCong"] = itemHD.TONGCONG;
                            if (lstHD[0].MaNV_HanhThu != null)
                            {
                                dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                                dr["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                            }
                            ThongTin += "Hóa đơn kỳ " + itemHD.KY + "/" + itemHD.NAM + " : " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemHD.TONGCONG) + "đồng\r\n";
                            dr["ThongTin"] = ThongTin;

                            ds.Tables["TienDuKhachHang"].Rows.Add(dr);

                            DataRow drTT = ds.Tables["TamThuChuyenKhoan"].NewRow();
                            drTT["LoaiBaoCao"] = "ĐỦ TIỀN";
                            drTT["DanhBo"] = itemHD.DANHBA.Insert(4, " ").Insert(8, " ");
                            drTT["HoTen"] = itemHD.TENKH;
                            drTT["MLT"] = itemHD.MALOTRINH;
                            drTT["Ky"] = itemHD.KY + "/" + itemHD.NAM;
                            drTT["TongCong"] = itemHD.TONGCONG;
                            if (itemHD.MaNV_HanhThu != null)
                            {
                                drTT["HanhThu"] = _cNguoiDung.GetHoTenByMaND(itemHD.MaNV_HanhThu.Value);
                                drTT["To"] = _cNguoiDung.GetTenToByMaND(itemHD.MaNV_HanhThu.Value);
                            }
                            if (itemHD.GB > 20)
                                drTT["Loai"] = "CQ";
                            else
                                drTT["Loai"] = "TG";
                            if (_cLenhHuy.CheckExist(itemHD.SOHOADON))
                                drTT["LenhHuy"] = true;
                            ds.Tables["TamThuChuyenKhoan"].Rows.Add(drTT);
                        }
                    }
                }
            rptTienDuKhachHang rpt = new rptTienDuKhachHang();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();

            rptDSTamThuChuyenKhoan rptTT = new rptDSTamThuChuyenKhoan();
            rptTT.SetDataSource(ds);
            frmBaoCao frmTT = new frmBaoCao(rptTT);
            frmTT.ShowDialog();
        }

        private void btnChuyenTamThu_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuTamThuChuyenKhoan", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn Chuyển Tạm Thu từ Đợt " + cmbFromDot.SelectedItem.ToString() + " -> " + cmbToDot.SelectedItem.ToString() + " ?", "Xác nhận chuyển", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvTienDu.Rows)
                            //if (_cDCHD.CheckExist_ChuaUpdatedHDDT(item.Cells["DanhBo_TienDu"].Value.ToString()) == false)
                            if (_cHoaDon.CheckDCHDTienDuByDanhBo(item.Cells["DanhBo_TienDu"].Value.ToString()) == true)
                            {
                                MessageBox.Show("Danh bộ: " + item.Cells["DanhBo_TienDu"].Value.ToString() + " có Điều Chỉnh Hóa Đơn(Chuyển Khoản)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                List<HOADON> lstHD;
                                if (chkTruHoNgheo.Checked)
                                    lstHD = _cHoaDon.GetDSTon_CoChanTienDu_TruHoNgheo(item.Cells["DanhBo_TienDu"].Value.ToString());
                                else
                                    lstHD = _cHoaDon.GetDSTon_CoChanTienDu(item.Cells["DanhBo_TienDu"].Value.ToString());
                                if (lstHD != null && lstHD.Count > 0 && !bool.Parse(item.Cells["ChoXuLy_TienDu"].Value.ToString()) && lstHD[0].DOT >= int.Parse(cmbFromDot.SelectedItem.ToString()) && lstHD[0].DOT <= int.Parse(cmbToDot.SelectedItem.ToString()) && int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) >= lstHD.Sum(itemHD => itemHD.TONGCONG))
                                {
                                    foreach (HOADON itemHD in lstHD)
                                        if (!_cTamThu.CheckExist(itemHD.SOHOADON))
                                        {
                                            TAMTHU tamthu = new TAMTHU();
                                            tamthu.DANHBA = itemHD.DANHBA;
                                            tamthu.FK_HOADON = itemHD.ID_HOADON;
                                            tamthu.SoHoaDon = itemHD.SOHOADON;
                                            tamthu.ChuyenKhoan = true;
                                            tamthu.TienDu = true;
                                            _cTamThu.Them(tamthu);
                                        }
                                }
                            }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form Tạm Thu Chuyển Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcelTienDu_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTienDu.getDSTienDu(dateNgayGiaiTrach.Value, CNguoiDung.FromDot, CNguoiDung.ToDot);
            DataTable dtTD = new DataTable();
            dtTD.Columns.Add("DanhBo", typeof(string));
            dtTD.Columns.Add("SoTien", typeof(int));
            dtTD.Columns.Add("NgayBK", typeof(string));
            dtTD.Columns.Add("MLT", typeof(string));
            dtTD.Columns.Add("HoTen", typeof(string));
            dtTD.Columns.Add("DiaChi", typeof(string));
            dtTD.Columns.Add("To", typeof(string));
            dtTD.Columns.Add("HanhThu", typeof(string));
            dtTD.Columns.Add("Bank", typeof(string));
            dtTD.Columns.Add("DienThoai", typeof(string));
            dtTD.Columns.Add("Loai", typeof(string));
            dtTD.Columns.Add("SoPhieuThu", typeof(string));
            dtTD.Columns.Add("NgayPhieuThu", typeof(string));
            DataTable dtTDAo = new DataTable();
            dtTDAo.Columns.Add("DanhBo", typeof(string));
            dtTDAo.Columns.Add("SoTien", typeof(int));
            dtTDAo.Columns.Add("NgayBK", typeof(string));
            dtTDAo.Columns.Add("MLT", typeof(string));
            dtTDAo.Columns.Add("HoTen", typeof(string));
            dtTDAo.Columns.Add("DiaChi", typeof(string));
            dtTDAo.Columns.Add("To", typeof(string));
            dtTDAo.Columns.Add("HanhThu", typeof(string));
            dtTDAo.Columns.Add("Bank", typeof(string));
            dtTDAo.Columns.Add("DienThoai", typeof(string));
            dtTDAo.Columns.Add("Loai", typeof(string));
            dtTDAo.Columns.Add("SoPhieuThu", typeof(string));
            dtTDAo.Columns.Add("NgayPhieuThu", typeof(string));
            foreach (DataRow item in dt.Rows)
                if (item["Dot"].ToString() != "")
                {
                    DataRow drTD = dtTD.NewRow();
                    drTD["DanhBo"] = item["DanhBo"];
                    drTD["SoTien"] = item["SoTien"];
                    //TT_BangKe bangke = _cBangKe.get(dr["DanhBo"].ToString(), dateNgayGiaiTrach.Value);
                    //if (bangke != null)
                    //{
                    //    arr[i, 2] = bangke.CreateDate.Value.ToString("dd/MM/yyyy");
                    //    arr[i, 8] = _cNganHang.getTenNH(bangke.MaNH.Value);
                    //    arr[i, 11] = bangke.SoPhieuThu;
                    //    arr[i, 12] = bangke.NgayPhieuThu;
                    //}
                    HOADON hoadon = _cHoaDon.GetMoiNhat(item["DanhBo"].ToString());
                    if (hoadon != null)
                    {
                        drTD["MLT"] = hoadon.MALOTRINH;
                        drTD["HoTen"] = hoadon.TENKH;
                        drTD["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                        if (hoadon.MaNV_HanhThu != null)
                        {
                            drTD["To"] = _cNguoiDung.GetTenToByMaND(hoadon.MaNV_HanhThu.Value);
                            drTD["HanhThu"] = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);
                        }
                        if (hoadon.GB <= 20)
                            drTD["Loai"] = "TG";
                        else
                            drTD["Loai"] = "CQ";
                    }
                    drTD["DienThoai"] = item["DienThoai"].ToString();
                    //tính sophieuthu
                    //DataTable dtBK = _cBangKe.getDS_XuatTienDu(item["DanhBo"].ToString(), dateNgayGiaiTrach.Value);
                    //if (dtBK != null && dtBK.Rows.Count > 0)
                    //{
                    //    int TienDu = int.Parse(item["SoTien"].ToString());
                    //    int TienBK = int.Parse(dtBK.Rows[0]["SoTien"].ToString());
                    //    int k = 1;
                    //    while (TienBK < TienDu && k < dtBK.Rows.Count)
                    //    {
                    //        TienBK += int.Parse(dtBK.Rows[k]["SoTien"].ToString());
                    //        k++;
                    //    }
                    //    if (k == 1)
                    //    {
                    //        drTD["NgayPhieuThu"] = dtBK.Rows[0]["NgayPhieuThu"];
                    //        drTD["SoPhieuThu"] = dtBK.Rows[0]["SoPhieuThu"];
                    //        dtTD.Rows.Add(drTD);
                    //    }
                    //    else
                    //    {
                    //        dtTD.Rows.Add(drTD);
                    //        TienBK = 0;
                    //        k = 0;
                    //        while (TienBK < TienDu && k < dtBK.Rows.Count)
                    //        {
                    //            DataRow drTD_extra = dtTD.NewRow();
                    //            drTD_extra["DanhBo"] = item["DanhBo"];
                    //            if (dtBK.Rows[k]["SoTien"].ToString() != "")
                    //                drTD_extra["SoTien"] = dtBK.Rows[k]["SoTien"];
                    //            if (dtBK.Rows[k]["SoPhieuThu"].ToString() != "")
                    //                drTD_extra["SoPhieuThu"] = dtBK.Rows[k]["SoPhieuThu"];
                    //            if (dtBK.Rows[k]["NgayPhieuThu"].ToString() != "")
                    //                drTD_extra["NgayPhieuThu"] = dtBK.Rows[k]["NgayPhieuThu"];
                    //            if (dtBK.Rows[k]["SoPhieuThu"].ToString() != "" || dtBK.Rows[k]["NgayPhieuThu"].ToString() != "")
                    //                dtTD.Rows.Add(drTD_extra);
                    //            TienBK += int.Parse(dtBK.Rows[k]["SoTien"].ToString());
                    //            k++;
                    //        };
                    //    }
                    //}
                    //else
                    {
                        dtTD.Rows.Add(drTD);
                    }
                }
                else
                {
                    DataRow drTD = dtTDAo.NewRow();
                    drTD["DanhBo"] = item["DanhBo"];
                    drTD["SoTien"] = item["SoTien"];
                    //TT_BangKe bangke = _cBangKe.get(dr["DanhBo"].ToString(), dateNgayGiaiTrach.Value);
                    //if (bangke != null)
                    //{
                    //    arr[i, 2] = bangke.CreateDate.Value.ToString("dd/MM/yyyy");
                    //    arr[i, 8] = _cNganHang.getTenNH(bangke.MaNH.Value);
                    //    arr[i, 11] = bangke.SoPhieuThu;
                    //    arr[i, 12] = bangke.NgayPhieuThu;
                    //}
                    //HOADON hoadon = _cHoaDon.GetMoiNhat(item["DanhBo"].ToString());
                    //if (hoadon != null)
                    //{
                    //    drTD["MLT"] = hoadon.MALOTRINH;
                    //    drTD["HoTen"] = hoadon.TENKH;
                    //    drTD["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                    //    if (hoadon.MaNV_HanhThu != null)
                    //    {
                    //        drTD["To"] = _cNguoiDung.GetTenToByMaND(hoadon.MaNV_HanhThu.Value);
                    //        drTD["HanhThu"] = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);
                    //    }
                    //    if (hoadon.GB <= 20)
                    //        drTD["Loai"] = "TG";
                    //    else
                    //        drTD["Loai"] = "CQ";
                    //}
                    //drTD["DienThoai"] = item["DienThoai"].ToString();
                    //tính sophieuthu
                    //DataTable dtBK = _cBangKe.getDS_XuatTienDu(item["DanhBo"].ToString(), dateNgayGiaiTrach.Value);
                    //if (dtBK != null && dtBK.Rows.Count > 0)
                    //{
                    //    int TienDu = int.Parse(item["SoTien"].ToString());
                    //    int TienBK = int.Parse(dtBK.Rows[0]["SoTien"].ToString());
                    //    int k = 1;
                    //    while (TienBK < TienDu && k < dtBK.Rows.Count)
                    //    {
                    //        TienBK += int.Parse(dtBK.Rows[k]["SoTien"].ToString());
                    //        k++;
                    //    }
                    //    if (k == 1)
                    //    {
                    //        drTD["NgayPhieuThu"] = dtBK.Rows[0]["NgayPhieuThu"];
                    //        drTD["SoPhieuThu"] = dtBK.Rows[0]["SoPhieuThu"];
                    //        dtTD.Rows.Add(drTD);
                    //    }
                    //    else
                    //    {
                    //        dtTD.Rows.Add(drTD);
                    //        TienBK = 0;
                    //        k = 0;
                    //        while (TienBK < TienDu && k < dtBK.Rows.Count)
                    //        {
                    //            DataRow drTD_extra = dtTD.NewRow();
                    //            drTD_extra["DanhBo"] = item["DanhBo"];
                    //            if (dtBK.Rows[k]["SoTien"].ToString() != "")
                    //                drTD_extra["SoTien"] = dtBK.Rows[k]["SoTien"];
                    //            if (dtBK.Rows[k]["SoPhieuThu"].ToString() != "")
                    //                drTD_extra["SoPhieuThu"] = dtBK.Rows[k]["SoPhieuThu"];
                    //            if (dtBK.Rows[k]["NgayPhieuThu"].ToString() != "")
                    //                drTD_extra["NgayPhieuThu"] = dtBK.Rows[k]["NgayPhieuThu"];
                    //            if (dtBK.Rows[k]["SoPhieuThu"].ToString() != "" || dtBK.Rows[k]["NgayPhieuThu"].ToString() != "")
                    //                dtTD.Rows.Add(drTD_extra);
                    //            TienBK += int.Parse(dtBK.Rows[k]["SoTien"].ToString());
                    //            k++;
                    //        };
                    //    }
                    //}
                    //else
                    {
                        dtTDAo.Rows.Add(drTD);
                    }
                }
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Worksheet oSheetAo;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            //khai báo số lượng sheet
            oExcel.Application.SheetsInNewWorkbook = 2;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheetAo = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(2);
            oSheet.Name = "Tiền Dư " + CNguoiDung.TenPhong;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH TIỀN DƯ NGÀY \r\n" + dateNgayGiaiTrach.Value.ToString("dd/MM/yyyy");
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Số Tiền";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Ngày BK";
            cl3.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "MLT";
            cl4.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Khách Hàng";
            cl5.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Địa Chỉ";
            cl6.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Tổ";
            cl7.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Hành Thu";
            cl8.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "Bank";
            cl9.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "Điện Thoại";
            cl10.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "Loại";
            cl11.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L3", "L3");
            cl12.Value2 = "SPT";
            cl12.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M3", "M3");
            cl13.Value2 = "NPT";
            cl13.ColumnWidth = 12;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dtTD.Rows.Count - 1;
            int columnEnd = 13;
            object[,] arr = new object[dtTD.Rows.Count, columnEnd];
            for (int i = 0; i < dtTD.Rows.Count; i++)
            {
                DataRow dr = dtTD.Rows[i];
                arr[i, 0] = dr["DanhBo"].ToString();
                arr[i, 1] = dr["SoTien"].ToString();
                arr[i, 3] = dr["MLT"].ToString();
                arr[i, 4] = dr["HoTen"].ToString();
                arr[i, 5] = dr["DiaChi"].ToString();
                arr[i, 6] = dr["To"].ToString();
                arr[i, 7] = dr["HanhThu"].ToString();
                arr[i, 10] = dr["Loai"].ToString();
                arr[i, 9] = dr["DienThoai"].ToString();
                arr[i, 11] = dr["SoPhieuThu"].ToString();
                if (dr["NgayPhieuThu"].ToString() != "")
                    arr[i, 12] = DateTime.Parse(dr["NgayPhieuThu"].ToString()).ToString("dd/MM/yyyy");
            }
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            c3b.NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            c3c.NumberFormat = "@";
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3g = oSheet.get_Range(c1g, c2g);
            c3g.NumberFormat = "@";
            c3g.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 10];
            Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 10];
            Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            c3e.NumberFormat = "@";
            c3e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 13];
            Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 13];
            Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
            c3f.NumberFormat = "@";
            c3f.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            oSheet.Cells[rowEnd + 1, 2] = dtTD.Compute("sum(SoTien)", "");
            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 2];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 2];
            oSheet.get_Range(c1d, c2d).NumberFormat = "#,##0";
            //bổ sung lịch sử chuyển nhận tiền
            DataTable dtLSChuyenNhan = _cTienDu.getDSTienDu_ChuyenNhanTien(dateNgayGiaiTrach.Value, CNguoiDung.FromDot, CNguoiDung.ToDot);
            for (int i = 0; i < dtLSChuyenNhan.Rows.Count; i++)
            {
                oSheet.Cells[rowEnd + 1 + i + 2, 1] = dtLSChuyenNhan.Rows[i]["DanhBo"].ToString();
                oSheet.Cells[rowEnd + 1 + i + 2, 2] = dtLSChuyenNhan.Rows[i]["SoTien"].ToString();
                oSheet.Cells[rowEnd + 1 + i + 2, 3] = dtLSChuyenNhan.Rows[i]["DanhBoChuyenNhan"].ToString();
                oSheet.Cells[rowEnd + 1 + i + 2, 4] = dtLSChuyenNhan.Rows[i]["Loai"].ToString();
                oSheet.Cells[rowEnd + 1 + i + 2, 5] = dtLSChuyenNhan.Rows[i]["GhiChu"].ToString();
            }

            /////////////////////////////tiền dư danh bộ ảo///////////////////////////////////////////
            oSheetAo.Name = "Tiền Dư Danh Bộ Ảo";
            // Tạo phần đầu nếu muốn
            head = oSheetAo.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH TIỀN DƯ NGÀY \r\n" + dateNgayGiaiTrach.Value.ToString("dd/MM/yyyy");
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            cl1 = oSheetAo.get_Range("A3", "A3");
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 15;

            cl2 = oSheetAo.get_Range("B3", "B3");
            cl2.Value2 = "Số Tiền";
            cl2.ColumnWidth = 10;

            cl3 = oSheetAo.get_Range("C3", "C3");
            cl3.Value2 = "Ngày BK";
            cl3.ColumnWidth = 12;

            cl4 = oSheetAo.get_Range("D3", "D3");
            cl4.Value2 = "MLT";
            cl4.ColumnWidth = 12;

            cl5 = oSheetAo.get_Range("E3", "E3");
            cl5.Value2 = "Khách Hàng";
            cl5.ColumnWidth = 20;

            cl6 = oSheetAo.get_Range("F3", "F3");
            cl6.Value2 = "Địa Chỉ";
            cl6.ColumnWidth = 30;

            cl7 = oSheetAo.get_Range("G3", "G3");
            cl7.Value2 = "Tổ";
            cl7.ColumnWidth = 5;

            cl8 = oSheetAo.get_Range("H3", "H3");
            cl8.Value2 = "Hành Thu";
            cl8.ColumnWidth = 12;

            cl9 = oSheetAo.get_Range("I3", "I3");
            cl9.Value2 = "Bank";
            cl9.ColumnWidth = 10;

            cl10 = oSheetAo.get_Range("J3", "J3");
            cl10.Value2 = "Điện Thoại";
            cl10.ColumnWidth = 12;

            cl11 = oSheetAo.get_Range("K3", "K3");
            cl11.Value2 = "Loại";
            cl11.ColumnWidth = 5;

            cl12 = oSheetAo.get_Range("L3", "L3");
            cl12.Value2 = "SPT";
            cl12.ColumnWidth = 10;

            cl13 = oSheetAo.get_Range("M3", "M3");
            cl13.Value2 = "NPT";
            cl13.ColumnWidth = 12;
            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            //Thiết lập vùng điền dữ liệu
            rowStart = 4;
            columnStart = 1;
            rowEnd = rowStart + dtTDAo.Rows.Count - 1;
            columnEnd = 13;
            arr = null;
            arr = new object[dtTDAo.Rows.Count, columnEnd];
            for (int i = 0; i < dtTDAo.Rows.Count; i++)
            {
                DataRow dr = dtTDAo.Rows[i];
                arr[i, 0] = dr["DanhBo"].ToString();
                arr[i, 1] = dr["SoTien"].ToString();
                arr[i, 3] = dr["MLT"].ToString();
                arr[i, 4] = dr["HoTen"].ToString();
                arr[i, 5] = dr["DiaChi"].ToString();
                arr[i, 6] = dr["To"].ToString();
                arr[i, 7] = dr["HanhThu"].ToString();
                arr[i, 10] = dr["Loai"].ToString();
                arr[i, 9] = dr["DienThoai"].ToString();
                arr[i, 11] = dr["SoPhieuThu"].ToString();
                if (dr["NgayPhieuThu"].ToString() != "")
                    arr[i, 12] = DateTime.Parse(dr["NgayPhieuThu"].ToString()).ToString("dd/MM/yyyy");
            }
            // Ô bắt đầu điền dữ liệu
            c1 = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            c2 = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            range = oSheetAo.get_Range(c1, c2);

            c1a = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowStart, 1];
            c2a = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowEnd, 1];
            c3a = oSheetAo.get_Range(c1a, c2a);
            c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            c1b = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowStart, 2];
            c2b = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowEnd, 2];
            c3b = oSheetAo.get_Range(c1b, c2b);
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            c3b.NumberFormat = "#,##0";

            c1c = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowStart, 3];
            c2c = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowEnd, 3];
            c3c = oSheetAo.get_Range(c1c, c2c);
            c3c.NumberFormat = "@";
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            c1g = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowStart, 4];
            c2g = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowEnd, 4];
            c3g = oSheetAo.get_Range(c1g, c2g);
            c3g.NumberFormat = "@";
            c3g.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            c1e = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowStart, 10];
            c2e = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowEnd, 10];
            c3e = oSheetAo.get_Range(c1e, c2e);
            c3e.NumberFormat = "@";
            c3e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            c1f = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowStart, 13];
            c2f = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowEnd, 13];
            c3f = oSheetAo.get_Range(c1f, c2f);
            c3f.NumberFormat = "@";
            c3f.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            oSheetAo.Cells[rowEnd + 1, 2] = dtTDAo.Compute("sum(SoTien)", "");
            c1d = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowEnd + 1, 2];
            c2d = (Microsoft.Office.Interop.Excel.Range)oSheetAo.Cells[rowEnd + 1, 2];
            oSheetAo.get_Range(c1d, c2d).NumberFormat = "#,##0";
        }

        private void btnXuatExcelTienDuTong_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTienDu.getDSTienDu(dateNgayGiaiTrach.Value);
            DataTable dtTD = new DataTable();
            dtTD.Columns.Add("DanhBo", typeof(string));
            dtTD.Columns.Add("SoTien", typeof(string));
            dtTD.Columns.Add("NgayBK", typeof(string));
            dtTD.Columns.Add("MLT", typeof(string));
            dtTD.Columns.Add("HoTen", typeof(string));
            dtTD.Columns.Add("DiaChi", typeof(string));
            dtTD.Columns.Add("To", typeof(string));
            dtTD.Columns.Add("HanhThu", typeof(string));
            dtTD.Columns.Add("Bank", typeof(string));
            dtTD.Columns.Add("DienThoai", typeof(string));
            dtTD.Columns.Add("Loai", typeof(string));
            dtTD.Columns.Add("SoPhieuThu", typeof(string));
            dtTD.Columns.Add("NgayPhieuThu", typeof(string));
            foreach (DataRow item in dt.Rows)
            {
                DataRow drTD = dtTD.NewRow();
                drTD["DanhBo"] = item["DanhBo"];
                drTD["SoTien"] = item["SoTien"];
                //TT_BangKe bangke = _cBangKe.get(dr["DanhBo"].ToString(), dateNgayGiaiTrach.Value);
                //if (bangke != null)
                //{
                //    arr[i, 2] = bangke.CreateDate.Value.ToString("dd/MM/yyyy");
                //    arr[i, 8] = _cNganHang.getTenNH(bangke.MaNH.Value);
                //    arr[i, 11] = bangke.SoPhieuThu;
                //    arr[i, 12] = bangke.NgayPhieuThu;
                //}
                HOADON hoadon = _cHoaDon.GetMoiNhat(item["DanhBo"].ToString());
                if (hoadon != null)
                {
                    drTD["MLT"] = hoadon.MALOTRINH;
                    drTD["HoTen"] = hoadon.TENKH;
                    drTD["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                    if (hoadon.MaNV_HanhThu != null)
                    {
                        drTD["To"] = _cNguoiDung.GetTenToByMaND(hoadon.MaNV_HanhThu.Value);
                        drTD["HanhThu"] = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);
                    }
                    if (hoadon.GB <= 20)
                        drTD["Loai"] = "TG";
                    else
                        drTD["Loai"] = "CQ";
                }
                drTD["DienThoai"] = item["DienThoai"].ToString();
                //tính sophieuthu
                //DataTable dtBK = _cBangKe.getDS_XuatTienDu(item["DanhBo"].ToString(), dateNgayGiaiTrach.Value);
                //if (dtBK != null && dtBK.Rows.Count > 0)
                //{
                //    int TienDu = int.Parse(item["SoTien"].ToString());
                //    int TienBK = int.Parse(dtBK.Rows[0]["SoTien"].ToString());
                //    int k = 1;
                //    while (TienBK < TienDu && k < dtBK.Rows.Count)
                //    {
                //        TienBK += int.Parse(dtBK.Rows[k]["SoTien"].ToString());
                //        k++;
                //    }
                //    if (k == 1)
                //    {
                //        drTD["NgayPhieuThu"] = dtBK.Rows[0]["NgayPhieuThu"];
                //        drTD["SoPhieuThu"] = dtBK.Rows[0]["SoPhieuThu"];
                //        dtTD.Rows.Add(drTD);
                //    }
                //    else
                //    {
                //        dtTD.Rows.Add(drTD);
                //        TienBK = 0;
                //        k = 0;
                //        while (TienBK < TienDu && k < dtBK.Rows.Count)
                //        {
                //            DataRow drTD_extra = dtTD.NewRow();
                //            drTD_extra["DanhBo"] = item["DanhBo"];
                //            if (dtBK.Rows[k]["SoTien"].ToString() != "")
                //                drTD_extra["SoTien"] = dtBK.Rows[k]["SoTien"];
                //            if (dtBK.Rows[k]["SoPhieuThu"].ToString() != "")
                //                drTD_extra["SoPhieuThu"] = dtBK.Rows[k]["SoPhieuThu"];
                //            if (dtBK.Rows[k]["NgayPhieuThu"].ToString() != "")
                //                drTD_extra["NgayPhieuThu"] = dtBK.Rows[k]["NgayPhieuThu"];
                //            if (dtBK.Rows[k]["SoPhieuThu"].ToString() != "" || dtBK.Rows[k]["NgayPhieuThu"].ToString() != "")
                //                dtTD.Rows.Add(drTD_extra);

                //            TienBK += int.Parse(dtBK.Rows[k]["SoTien"].ToString());
                //            k++;
                //        };
                //    }
                //}
                //else
                {
                    dtTD.Rows.Add(drTD);
                }
            }
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            //khai báo số lượng sheet
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = "Tiền Dư";

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH TIỀN DƯ NGÀY \r\n" + dateNgayGiaiTrach.Value.ToString("dd/MM/yyyy");
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Danh Bộ";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Số Tiền";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Ngày BK";
            cl3.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "MLT";
            cl4.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Khách Hàng";
            cl5.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Địa Chỉ";
            cl6.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Tổ";
            cl7.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Hành Thu";
            cl8.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "Bank";
            cl9.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "Điện Thoại";
            cl10.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "Loại";
            cl11.ColumnWidth = 5;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L3", "L3");
            cl12.Value2 = "SPT";
            cl12.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M3", "M3");
            cl13.Value2 = "NPT";
            cl13.ColumnWidth = 12;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dtTD.Rows.Count - 1;
            int columnEnd = 13;
            object[,] arr = new object[dtTD.Rows.Count, columnEnd];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dtTD.Rows.Count; i++)
            {
                DataRow dr = dtTD.Rows[i];
                arr[i, 0] = dr["DanhBo"].ToString();
                arr[i, 1] = dr["SoTien"].ToString();
                arr[i, 3] = dr["MLT"].ToString();
                arr[i, 4] = dr["HoTen"].ToString();
                arr[i, 5] = dr["DiaChi"].ToString();
                arr[i, 6] = dr["To"].ToString();
                arr[i, 7] = dr["HanhThu"].ToString();
                arr[i, 10] = dr["Loai"].ToString();
                arr[i, 9] = dr["DienThoai"].ToString();
                arr[i, 11] = dr["SoPhieuThu"].ToString();
                if (dr["NgayPhieuThu"].ToString() != "")
                    arr[i, 12] = DateTime.Parse(dr["NgayPhieuThu"].ToString()).ToString("dd/MM/yyyy");
            }
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            c3b.NumberFormat = "#,##0";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            c3c.NumberFormat = "@";
            c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c1g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2g = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3g = oSheet.get_Range(c1g, c2g);
            c3g.NumberFormat = "@";
            c3g.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 12];
            Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 12];
            Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            c3e.NumberFormat = "@";
            c3e.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 13];
            Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 13];
            Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
            c3f.NumberFormat = "@";
            c3f.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            oSheet.Cells[rowEnd + 1, 2] = dt.Compute("sum(SoTien)", "");
            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 2];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, 2];
            oSheet.get_Range(c1d, c2d).NumberFormat = "#,##0";
        }

        private int _searchIndex = -1;
        private string _searchNoiDung = "";

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (_searchNoiDung != NoiDung)
                _searchIndex = -1;

            for (int i = 0; i < dgvTienDu.Rows.Count; i++)
            {
                if (_searchNoiDung != NoiDung)
                    _searchNoiDung = NoiDung;

                _searchIndex = (_searchIndex + 1) % dgvTienDu.Rows.Count;
                DataGridViewRow row = dgvTienDu.Rows[_searchIndex];
                if (row.Cells["DanhBo_TienDu"].Value == null)
                {
                    continue;
                }
                if (row.Cells["DanhBo_TienDu"].Value.ToString() == NoiDung)
                {
                    dgvTienDu.CurrentCell = row.Cells["DanhBo_TienDu"];
                    dgvTienDu.Rows[_searchIndex].Selected = true;
                    return;
                }
            }
        }

        private void frmTienDu_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvTienAm_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTienAm.RowCount > 0 && e.Button == MouseButtons.Left)
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    frmDieuChinhTienDu frm = new frmDieuChinhTienDu(dgvTienAm["DanhBo_TienAm", e.RowIndex].Value.ToString(), dgvTienAm["SoTien_TienAm", e.RowIndex].Value.ToString());
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _cTienDu.Refresh();
                        btnXem.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInTBTienDu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvTienDu.SelectedRows)
            {
                HOADON hoadon = _cHoaDon.GetTonMoiNhat(item.Cells["DanhBo_TienDu"].Value.ToString());
                if (hoadon != null)
                {
                    DataRow dr = ds.Tables["TienDuKhachHang"].NewRow();
                    dr["DanhBo"] = item.Cells["DanhBo_TienDu"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = hoadon.TENKH;
                    dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                    dr["MLT"] = hoadon.MALOTRINH;
                    dr["DienThoai"] = _cDocSo.getDienThoai(hoadon.DANHBA);
                    dr["Ky"] = hoadon.KY + "/" + hoadon.NAM;
                    dr["TienDu"] = item.Cells["SoTien_TienDu"].Value;
                    dr["TongCong"] = hoadon.TONGCONG - (int)item.Cells["SoTien_TienDu"].Value;
                    ds.Tables["TienDuKhachHang"].Rows.Add(dr);
                }
            }
            rptThongBaoTienDu rpt = new rptThongBaoTienDu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnChuyenChanTienDu_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuChanTienDu", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn Chuyển Chặn Tiền Dư từ Đợt " + cmbFromDot.SelectedItem.ToString() + " -> " + cmbToDot.SelectedItem.ToString() + " ?", "Xác nhận chuyển", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvTienDu.Rows)
                        //if (_cDCHD.CheckExist_ChuaUpdatedHDDT(item.Cells["DanhBo_TienDu"].Value.ToString()) == false)
                        {
                            List<HOADON> lstHD = _cHoaDon.getDSTon_KhongChanTienDu_KhongDCHD(item.Cells["DanhBo_TienDu"].Value.ToString());
                            if (lstHD != null && lstHD.Count > 0 && !bool.Parse(item.Cells["ChoXuLy_TienDu"].Value.ToString()) && lstHD[0].DOT >= int.Parse(cmbFromDot.SelectedItem.ToString()) && lstHD[0].DOT <= int.Parse(cmbToDot.SelectedItem.ToString()))
                                //số tiền dư > tổng cộng => thêm vào chặn tiền
                                if (int.Parse(item.Cells["SoTien_TienDu"].Value.ToString()) >= lstHD.Sum(itemHD => itemHD.TONGCONG))
                                {
                                    foreach (HOADON itemHD in lstHD)
                                    {
                                        itemHD.KhoaTienDu = true;
                                        itemHD.ChanTienDu = true;
                                        itemHD.NgayChanTienDu = DateTime.Now;
                                        itemHD.NGAYGIAITRACH = DateTime.Now;
                                        itemHD.Name_PC = CNguoiDung.Name_PC;
                                        itemHD.IP_PC = CNguoiDung.IP_PC;
                                        _cHoaDon.Sua(itemHD);
                                    }
                                }
                                //số tiền dư < tổng cộng => thêm vào điều chỉnh tiền
                                else
                                {
                                    using (TransactionScope scope = new TransactionScope())
                                    {
                                        int TienDu = _cTienDu.GetTienDu(lstHD[0].DANHBA);
                                        foreach (HOADON itemHD in lstHD)
                                            if (itemHD.DCHD == false)
                                            {
                                                if (TienDu > 0 && TienDu >= (int)itemHD.TONGCONG.Value)
                                                {
                                                    itemHD.DCHD = true;
                                                    itemHD.Ngay_DCHD = DateTime.Now;
                                                    itemHD.TongCongTruoc_DCHD = (int)itemHD.TONGCONG.Value;
                                                    itemHD.TienDuTruoc_DCHD = (int)itemHD.TONGCONG.Value;
                                                    itemHD.TONGCONG = 0;
                                                    itemHD.Name_PC = CNguoiDung.Name_PC;
                                                    itemHD.IP_PC = CNguoiDung.IP_PC;
                                                    _cHoaDon.Sua(itemHD);
                                                    TienDu -= itemHD.TongCongTruoc_DCHD.Value;
                                                }
                                                else
                                                    if (TienDu > 0)
                                                    {
                                                        itemHD.DCHD = true;
                                                        itemHD.Ngay_DCHD = DateTime.Now;
                                                        itemHD.TongCongTruoc_DCHD = (int)itemHD.TONGCONG.Value;
                                                        itemHD.TienDuTruoc_DCHD = TienDu;
                                                        itemHD.TONGCONG -= TienDu;
                                                        itemHD.Name_PC = CNguoiDung.Name_PC;
                                                        itemHD.IP_PC = CNguoiDung.IP_PC;
                                                        _cHoaDon.Sua(itemHD);
                                                        TienDu -= TienDu;
                                                    }
                                            }
                                        scope.Complete();
                                    }
                                }
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form Tạm Thu Chuyển Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_ThongKe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cần thống nhất quy trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            DataTable dt = _cTienDu.getThongKe(dateThongKe.Value, CNguoiDung.FromDot, CNguoiDung.ToDot);
            if (dt.Rows[0]["TienDau"].ToString() != "")
                txtTienDau.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["TienDau"].ToString()));
            else
                txtTienDau.Text = "0";
            if (dt.Rows[0]["BangKe"].ToString() != "")
                txtBangKe.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["BangKe"].ToString()));
            else
                txtBangKe.Text = "0";
            if (dt.Rows[0]["GiaiTrach"].ToString() != "")
                txtGiaiTrach.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["GiaiTrach"].ToString()));
            else
                txtGiaiTrach.Text = "0";
            if (dt.Rows[0]["TienMat"].ToString() != "")
                txtTienMat.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["TienMat"].ToString()));
            else
                txtTienMat.Text = "0";
            if (dt.Rows[0]["PhiMoNuoc"].ToString() != "")
                txtPhiMoNuoc.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["PhiMoNuoc"].ToString()));
            else
                txtPhiMoNuoc.Text = "0";
            if (dt.Rows[0]["DieuChinh"].ToString() != "")
                txtDieuChinh.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["DieuChinh"].ToString()));
            else
                txtDieuChinh.Text = "0";
            if (dt.Rows[0]["TienCuoi"].ToString() != "")
                txtTienCuoi.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["TienCuoi"].ToString()));
            else
                txtTienCuoi.Text = "0";
        }

        private void btnXem_ThongKeTong_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTienDu.getThongKe(dateThongKe.Value);
            if (dt.Rows[0]["TienDau"].ToString() != "")
                txtTienDauTong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["TienDau"].ToString()));
            else
                txtTienDauTong.Text = "0";
            if (dt.Rows[0]["BangKe"].ToString() != "")
                txtBangKeTong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["BangKe"].ToString()));
            else
                txtBangKeTong.Text = "0";
            if (dt.Rows[0]["GiaiTrach"].ToString() != "")
                txtGiaiTrachTong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["GiaiTrach"].ToString()));
            else
                txtGiaiTrachTong.Text = "0";
            if (dt.Rows[0]["TienMat"].ToString() != "")
                txtTienMatTong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["TienMat"].ToString()));
            else
                txtTienMatTong.Text = "0";
            if (dt.Rows[0]["PhiMoNuoc"].ToString() != "")
                txtPhiMoNuocTong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["PhiMoNuoc"].ToString()));
            else
                txtPhiMoNuocTong.Text = "0";
            if (dt.Rows[0]["DieuChinh"].ToString() != "")
                txtDieuChinhTong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["DieuChinh"].ToString()));
            else
                txtDieuChinhTong.Text = "0";
            if (dt.Rows[0]["TienCuoi"].ToString() != "")
                txtTienCuoiTong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dt.Rows[0]["TienCuoi"].ToString()));
            else
                txtTienCuoiTong.Text = "0";
        }



    }
}
