using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.ToBamChi;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.GUI.DonTu;
using System.Transactions;
using CrystalDecisions.CrystalReports.Engine;

namespace KTKS_DonKH.GUI.ThuTraLoi
{
    public partial class frmDSToTrinh2021 : Form
    {
        string _mnu = "mnuToTrinh";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CToTrinh _cTT = new CToTrinh();
        CDHN _cDocSo = new CDHN();
        CToTrinh_VeViec _cVeViecToTrinh = new CToTrinh_VeViec();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();

        DonTu_ChiTiet _dontu_ChiTiet = null;
        ToTrinh_ChiTiet _cttt = null;
        int _IDCT = -1;

        public frmDSToTrinh2021()
        {
            InitializeComponent();
        }

        public frmDSToTrinh2021(int IDCT)
        {
            _IDCT = IDCT;
            InitializeComponent();
        }

        private void frmToTrinh_Load(object sender, EventArgs e)
        {
            dgvToTrinh.AutoGenerateColumns = false;
            cmbTimTheo.SelectedIndex = 3;
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Danh Bộ":
                case "Mã TT":
                case "Về Việc":
                    txtNoiDungTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvToTrinh.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã TT":
                    dgvToTrinh.DataSource = _cTT.get_ChiTiet(int.Parse(txtNoiDungTimKiem.Text.Trim().Replace(" ", "").Replace("-", "")));
                    break;
                case "Danh Bộ":
                    dgvToTrinh.DataSource = _cTT.getDS_ChiTiet_DanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                    break;
                case "Về Việc":
                    dgvToTrinh.DataSource = _cTT.getDS_ChiTiet_VeViec(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                    break;
                case "Ngày":
                    dgvToTrinh.DataSource = _cTT.getDS_ChiTiet(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void dgvToTrinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //_cttt = _cTT.get_ChiTiet(int.Parse(dgvToTrinh["IDCT", e.RowIndex].Value.ToString()));
                //frmToTrinh frm = new frmToTrinh(int.Parse(dgvToTrinh["IDCT", e.RowIndex].Value.ToString()));
                //frm.Show();
            }
            catch (Exception)
            {
            }

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_cttt != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                dr["SoPhieu"] = _cttt.IDCT.ToString().Insert(_cttt.IDCT.ToString().Length - 2, "-");
                dr["HoTen"] = _cttt.HoTen;
                dr["DiaChi"] = _cttt.DiaChi;
                if (!string.IsNullOrEmpty(_cttt.DanhBo) && _cttt.DanhBo.Length == 11)
                    dr["DanhBo"] = _cttt.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["LoTrinh"] = _cttt.LoTrinh;
                dr["GiaBieu"] = _cttt.GiaBieu;
                if (_cttt.DinhMuc != null)
                    dr["DinhMuc"] = _cttt.DinhMuc.Value;
                if (_cttt.DinhMucHN != null)
                    dr["DinhMucHN"] = _cttt.DinhMucHN.Value;

                dr["VeViec"] = _cttt.VeViec;
                dr["KinhTrinh"] = _cttt.KinhTrinh;
                dr["ThongQua"] = _cttt.ThongQua;
                dr["NoiDung"] = _cttt.NoiDung;
                dr["NoiNhan"] = _cttt.NoiNhan;
                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                    dr["ChucVu"] = "GIÁM ĐỐC";
                else
                    dr["ChucVu"] = "TRÌNH DUYỆT\n" + bangiamdoc.ChucVu.ToUpper();
                dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                ReportDocument rpt;
                if (_cttt.KinhTrinh.ToLower().Contains("thông qua") == true)
                {
                    rpt = new rptToTrinh_ThongQuaPGD();
                }
                else
                {
                    rpt = new rptToTrinh();
                }
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
        }

        private void dgvToTrinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvToTrinh.Columns[e.ColumnIndex].Name == "IDCT" && e.Value != null)
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void dgvToTrinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvToTrinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvToTrinh_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvToTrinh.Columns[e.ColumnIndex].Name == "ThuDuocKy" && e.FormattedValue.ToString() != dgvToTrinh[e.ColumnIndex, e.RowIndex].Value.ToString())
                    {
                        ToTrinh_ChiTiet tt = _cTT.get_ChiTiet(int.Parse(dgvToTrinh["IDCT", e.RowIndex].Value.ToString()));
                        tt.ThuDuocKy = bool.Parse(e.FormattedValue.ToString());
                        _cTT.Sua_ChiTiet(tt);
                    }
                    if (dgvToTrinh.Columns[e.ColumnIndex].Name == "TraTrinhKy" && e.FormattedValue.ToString() != dgvToTrinh[e.ColumnIndex, e.RowIndex].Value.ToString())
                    {
                        ToTrinh_ChiTiet tt = _cTT.get_ChiTiet(int.Parse(dgvToTrinh["IDCT", e.RowIndex].Value.ToString()));
                        tt.TraTrinhKy = bool.Parse(e.FormattedValue.ToString());
                        _cTT.Sua_ChiTiet(tt);
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

        private void btnInDS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Thư trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    for (int i = 0; i < dgvToTrinh.Rows.Count; i++)
                        if (dgvToTrinh["In", i].Value != null && bool.Parse(dgvToTrinh["In", i].Value.ToString()) == true)
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                            ToTrinh_ChiTiet cttt = _cTT.get_ChiTiet(int.Parse(dgvToTrinh["IDCT", i].Value.ToString()));

                            if (cttt.ToTrinh_ChiTiet_DanhSaches.Count == 0)
                            {
                                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                                dr["SoPhieu"] = cttt.IDCT.ToString().Insert(cttt.IDCT.ToString().Length - 2, "-");
                                dr["HoTen"] = cttt.HoTen;
                                dr["DiaChi"] = cttt.DiaChi;
                                if (!string.IsNullOrEmpty(cttt.DanhBo) && cttt.DanhBo.Length == 11)
                                    dr["DanhBo"] = cttt.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["LoTrinh"] = cttt.LoTrinh;
                                dr["GiaBieu"] = cttt.GiaBieu;
                                if (cttt.DinhMuc != null)
                                    dr["DinhMuc"] = cttt.DinhMuc;
                                if (cttt.DinhMuc != null)
                                    dr["DinhMucHN"] = cttt.DinhMucHN;

                                dr["VeViec"] = cttt.VeViec;
                                dr["KinhTrinh"] = cttt.KinhTrinh;
                                dr["ThongQua"] = cttt.ThongQua;
                                dr["NoiDung"] = cttt.NoiDung;
                                dr["NoiNhan"] = cttt.NoiNhan;
                                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                    dr["ChucVu"] = "GIÁM ĐỐC";
                                else
                                    dr["ChucVu"] = "TRÌNH DUYỆT\n" + bangiamdoc.ChucVu.ToUpper();
                                dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();

                                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                                ReportDocument rpt;
                                if (cttt.KinhTrinh.ToLower().Contains("thông qua") == true)
                                {
                                    rpt = new rptToTrinh_ThongQuaPGD();
                                }
                                else
                                {
                                    rpt = new rptToTrinh();
                                }
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                rpt.Clone();
                                rpt.Dispose();
                            }
                            else
                            {
                                foreach (ToTrinh_ChiTiet_DanhSach item in _cttt.ToTrinh_ChiTiet_DanhSaches.ToList())
                                {
                                    dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                                    dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                                    dr["SoPhieu"] = item.IDCT.ToString().Insert(item.IDCT.ToString().Length - 2, "-");
                                    dr["VeViec"] = item.ToTrinh_ChiTiet.VeViec;
                                    dr["KinhTrinh"] = item.ToTrinh_ChiTiet.KinhTrinh;
                                    dr["ThongQua"] = item.ToTrinh_ChiTiet.ThongQua;
                                    if (item.ToTrinh_ChiTiet.VeViec.Contains("Điều chỉnh hóa đơn"))
                                    {
                                        dr["NoiDung"] = item.ToTrinh_ChiTiet.NoiDung;
                                    }
                                    else
                                        if (item.ToTrinh_ChiTiet.VeViec.Contains("đứt chì mặt số"))
                                        {
                                            dr["NoiDung"] = item.ToTrinh_ChiTiet.NoiDung;
                                            dr["NoiDung2"] = "hộp bảo vệ, ngoài vỉa hè, chì mặt số đứt";

                                            if (item.ToTrinh_ChiTiet.VeViec.ToLower().Contains("nắp hộp bv") || item.ToTrinh_ChiTiet.VeViec.ToLower().Contains("nắp hộp bảo vệ"))
                                                dr["Luuy"] = "đồng hồ nước đứt chì+nắp hộp BV do đồng hồ nước lắp đặt ở ngoài khu vực quản lý của khách hàng sử dụng nước";
                                            else
                                                if (item.ToTrinh_ChiTiet.VeViec.ToLower().Contains("hộp bv") || item.ToTrinh_ChiTiet.VeViec.ToLower().Contains("hộp bảo vệ"))
                                                    dr["Luuy"] = "đồng hồ nước đứt chì+hộp BV do đồng hồ nước lắp đặt ở ngoài khu vực quản lý của khách hàng sử dụng nước";
                                                else
                                                    dr["Luuy"] = "đồng hồ nước đứt chì do đồng hồ nước lắp đặt ở ngoài khu vực quản lý của khách hàng sử dụng nước";
                                        }
                                        else
                                            if (item.ToTrinh_ChiTiet.VeViec.Contains("lỗi kỹ thuật"))
                                            {
                                                dr["NoiDung"] = "hoạt động không ổn định, không có dấu hiệu tháo mở gian lận";
                                                dr["NoiDung2"] = "nhà bị lỗi kỹ thuật";

                                                dr["Luuy"] = "đồng hồ nước bị lỗi kỹ thuật";
                                            }
                                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                        dr["ChucVu"] = "GIÁM ĐỐC";
                                    else
                                        dr["ChucVu"] = "TRÌNH DUYỆT\n" + bangiamdoc.ChucVu.ToUpper();
                                    dr["NguoiKy"] = bangiamdoc.HoTen.ToUpper();

                                    dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                                    //
                                    DataRow dr2 = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                                    if (item.ToTrinh_ChiTiet.VeViec.Contains("đứt chì mặt số"))
                                    {
                                        dr2["LoaiBaoCao"] = "ĐỨT CHÌ MẶT SỐ NẰM NGOÀI BẤT ĐỘNG SẢN (VỈA HÈ)";
                                    }
                                    else
                                        if (item.ToTrinh_ChiTiet.VeViec.Contains("lỗi kỹ thuật"))
                                        {
                                            dr2["LoaiBaoCao"] = "LỖI KỸ THUẬT";
                                        }
                                    dr2["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();
                                    dr2["SoPhieu"] = item.IDCT.ToString().Insert(item.IDCT.ToString().Length - 2, "-");
                                    dr2["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;
                                    if (item.DanhBo.Length == 11)
                                        dr2["DanhBo"] = item.DanhBo.Insert(7, " ").Insert(4, " ");
                                    dr2["HoTen"] = item.HoTen;
                                    dr2["DiaChi"] = item.DiaChi;
                                    dr2["Hieu"] = item.Hieu;
                                    dr2["Co"] = item.Co;
                                    dr2["SoThan"] = item.SoThan;
                                    dr2["Quan"] = item.Quan;
                                    dr2["NoiDung"] = item.IDCT.ToString().Insert(item.IDCT.ToString().Length - 2, "-") + "/TTr-" + CTaiKhoan.KyHieuPhong;
                                    LinQ.DonTu dontu = _cDonTu.get(item.MaDon.Value);
                                    if (dontu.DonTu_ChiTiets.Count == 1)
                                        dr2["NoiNhan"] = item.MaDon.Value;
                                    else
                                        dr2["NoiNhan"] = item.MaDon.Value + "." + item.STT;

                                    dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr2);
                                }

                                ReportDocument rpt1, rpt2;
                                if (_cttt.VeViec.Contains("Điều chỉnh hóa đơn") == true)
                                {
                                    rpt2 = new rptToTrinh_DCHD_DinhKem();
                                    rpt2.SetDataSource(dsBaoCao);
                                    rpt1 = new rptToTrinh_DCHD();
                                    rpt1.SetDataSource(dsBaoCao);
                                }
                                else
                                {
                                    rpt2 = new rptToTrinh_DCMS_DinhKem();
                                    rpt2.SetDataSource(dsBaoCao);
                                    rpt1 = new rptToTrinh_DCMS();
                                    rpt1.SetDataSource(dsBaoCao);
                                }

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt1.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt1.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                rpt1.Clone();
                                rpt1.Dispose();

                                rpt2.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt2.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                rpt2.Clone();
                                rpt2.Dispose();
                            }
                        }
                }
            }
        }

        private void frmToTrinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (_dontu_ChiTiet != null && e.Control && e.KeyCode == Keys.T)
            {
                frmCapNhatDonTu_Thumbnail frm = new frmCapNhatDonTu_Thumbnail(_dontu_ChiTiet);
                frm.ShowDialog();
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                for (int i = 0; i < dgvToTrinh.Rows.Count; i++)
                {
                    dgvToTrinh["In", i].Value = true;
                }
            }
            else
                for (int i = 0; i < dgvToTrinh.Rows.Count; i++)
                {
                    dgvToTrinh["In", i].Value = false;
                }
        }

        private void dgvToTrinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvToTrinh.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmToTrinh2021 frm = new frmToTrinh2021(int.Parse(dgvToTrinh["IDCT", dgvToTrinh.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }




    }
}
