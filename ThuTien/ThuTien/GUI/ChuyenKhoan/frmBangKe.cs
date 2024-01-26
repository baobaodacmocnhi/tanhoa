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
using System.Transactions;
using ThuTien.DAL;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmBangKe : Form
    {
        string _mnu = "mnuBangKe";
        CBangKe _cBangKe = new CBangKe();
        CNganHang _cNganHang = new CNganHang();
        CTienDu _cTienDu = new CTienDu();
        CDHN _cDHN = new CDHN();

        public frmBangKe()
        {
            InitializeComponent();
        }

        private void frmBangKe_Load(object sender, EventArgs e)
        {
            dgvBangKe.AutoGenerateColumns = false;
            dgvBangKeGroup.AutoGenerateColumns = false;
            dgvBangKeGroup3.AutoGenerateColumns = false;
            dgvBangKeGroup_Tong.AutoGenerateColumns = false;
            dgvBangKeGroup3_Tong.AutoGenerateColumns = false;
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            dateNgayLap.Value = DateTime.Now;
            if (CNguoiDung.Admin)
                btnXoaLuonLichSu.Visible = true;
            else
                btnXoaLuonLichSu.Visible = false;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cBangKe.ExcelToDataTable(dialog.FileName);
                            //CExcel fileExcel = new CExcel(dialog.FileName);
                            //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                            //foreach (DataRow item in dtExcel.Rows)
                            //    if ((!string.IsNullOrEmpty(item[1].ToString()) && item[1].ToString().Replace(" ", "").Length == 11))
                            //    {
                            //        dbThuTienDataContext db = new dbThuTienDataContext();
                            //        TT_ThoatNgheo en = new TT_ThoatNgheo();
                            //        en.DanhBo = item[1].ToString().Replace(" ", "");
                            //        db.TT_ThoatNgheos.InsertOnSubmit(en);
                            //        db.SubmitChanges();
                            //    }
                            //foreach (DataRow item in dtExcel.Rows)
                            //    if (item[1].ToString().Replace(" ", "").Length == 11)
                            //    {
                            //        _cDHN.ExecuteNonQuery("update TB_DULIEUKHACHHANG set CHIGOC='" + item[3].ToString().Replace(" ", "") + "',MauSacChiGoc=N'Vàng' where danhbo='" + item[1].ToString().Replace(" ", "") + "'");
                            //    }
                            DataTable dtBK = new DataTable();
                            dtBK.Columns.Add("DanhBo", typeof(System.String));
                            dtBK.Columns.Add("SoTien", typeof(System.String));
                            dtBK.Columns.Add("Bank", typeof(System.String));
                            foreach (DataRow item in dtExcel.Rows)
                                if ((string.IsNullOrEmpty(item[0].ToString()) || item[0].ToString().Replace(" ", "").Length == 11)
                                    && !string.IsNullOrEmpty(item[1].ToString()) && !string.IsNullOrEmpty(item[2].ToString()))
                                {
                                    bool flag = false;
                                    TB_DULIEUKHACHHANG ttkh = _cDHN.get(item[0].ToString().Replace(" ", ""));
                                    if (ttkh != null && int.Parse(ttkh.LOTRINH.Substring(0, 2)) >= CNguoiDung.FromDot && int.Parse(ttkh.LOTRINH.Substring(0, 2)) <= CNguoiDung.ToDot)
                                    {
                                        flag = true;
                                    }
                                    else
                                        if (ttkh == null && CNguoiDung.IDPhong == 2)
                                        {
                                            flag = true;
                                        }
                                    if (flag == true)
                                    {
                                        var transactionOptions = new TransactionOptions();
                                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                        {
                                            //if (item[0].ToString().Length == 11 && _cBangKe.CheckExist(item[0].ToString(), DateTime.Now))
                                            //{
                                            //    MessageBox.Show("Danh Bộ: " + item[0].ToString() + " đã thêm trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            //    continue;
                                            //}
                                            TT_BangKe bangke = new TT_BangKe();
                                            bangke.DanhBo = item[0].ToString().Trim().Replace(" ", "");
                                            bangke.SoTien = int.Parse(item[1].ToString().Trim());
                                            if (_cNganHang.CheckExist(item[2].ToString().Trim()))
                                                bangke.MaNH = _cNganHang.GetMaNHByKyHieu(item[2].ToString().Trim());
                                            else
                                            {
                                                MessageBox.Show("Lỗi Tên Ngân Hàng tại Danh Bộ: " + bangke.DanhBo + "\nBảng Kê đã lưu được tới đây", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            bangke.CreateBy = CNguoiDung.MaND;
                                            bangke.CreateDate2 = DateTime.Now;
                                            if (chkNgayLap.Checked == true)
                                            {
                                                bangke.CreateDate = dateNgayLap.Value;
                                                if (_cBangKe.Them(bangke))
                                                    if (_cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value, "Bảng Kê", "Thêm", bangke.MaNH.Value, bangke.MaBK, dateNgayLap.Value))
                                                    {
                                                        DataRow drBK = dtBK.NewRow();
                                                        drBK["DanhBo"] = bangke.DanhBo;
                                                        drBK["SoTien"] = bangke.SoTien;
                                                        drBK["Bank"] = item[2].ToString().Trim();
                                                        dtBK.Rows.Add(drBK);
                                                        flag = false;
                                                        scope.Complete();
                                                        scope.Dispose();
                                                    }
                                            }
                                            else
                                            {
                                                bangke.CreateDate = DateTime.Now;
                                                if (_cBangKe.Them(bangke))
                                                    if (_cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value, "Bảng Kê", "Thêm", bangke.MaNH.Value, bangke.MaBK))
                                                    {
                                                        DataRow drBK = dtBK.NewRow();
                                                        drBK["DanhBo"] = bangke.DanhBo;
                                                        drBK["SoTien"] = bangke.SoTien;
                                                        drBK["Bank"] = item[2].ToString().Trim();
                                                        dtBK.Rows.Add(drBK);
                                                        flag = false;
                                                        scope.Complete();
                                                        scope.Dispose();
                                                    }
                                            }
                                        }
                                    }
                                }
                            if (dtBK.Rows.Count > 0)
                                _cBangKe.XuatExcel(dtBK, "Bảng Kê " + CNguoiDung.TenPhong);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //dgvBangKe.DataSource = _cBangKe.GetDS_BangKe_DangNgan(dateTu.Value, dateDen.Value);
            dgvBangKe.DataSource = _cBangKe.GetDS_BangKe_DangNgan(dateTu.Value, dateDen.Value, CNguoiDung.IDPhong);
            long TongSoTien = 0;
            int TongHD = 0;
            long TongCong = 0;
            if (dgvBangKe.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvBangKe.Rows)
                {
                    TongSoTien += long.Parse(item.Cells["SoTien"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["HoaDon"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["HoaDon"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong"].Value.ToString());
                    //if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()) && !_cCapNuocTanHoa.CheckExist(item.Cells["DanhBo"].Value.ToString()))
                    //    item.DefaultCellStyle.BackColor = Color.Red;
                }
                txtTongDanhBo.Text = dgvBangKe.RowCount.ToString();
                txtTongSoTien.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongSoTien);
                txtTongHD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            TongCong = 0;
            dgvBangKeGroup.DataSource = _cBangKe.GetDS_Group(dateTu.Value, dateDen.Value, CNguoiDung.IDPhong);
            foreach (DataGridViewRow item in dgvBangKeGroup.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["TongCong_Group"].Value.ToString()))
                    TongCong += long.Parse(item.Cells["TongCong_Group"].Value.ToString());
            }
            txtTongCong_Group.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            TongCong = 0;
            dgvBangKeGroup3.DataSource = _cBangKe.GetDS_Group3(dateTu.Value, dateDen.Value, CNguoiDung.IDPhong);
            foreach (DataGridViewRow item in dgvBangKeGroup3.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["TongCong_Group3"].Value.ToString()))
                    TongCong += long.Parse(item.Cells["TongCong_Group3"].Value.ToString());
            }
            txtTongCong_Group3.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            TongCong = 0;
            dgvBangKeGroup_Tong.DataSource = _cBangKe.GetDS_Group(dateTu.Value, dateDen.Value);
            foreach (DataGridViewRow item in dgvBangKeGroup_Tong.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["TongCong_Group_Tong"].Value.ToString()))
                    TongCong += long.Parse(item.Cells["TongCong_Group_Tong"].Value.ToString());
            }
            txtTongCong_Group_Tong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            TongCong = 0;
            dgvBangKeGroup3_Tong.DataSource = _cBangKe.GetDS_Group3(dateTu.Value, dateDen.Value);
            foreach (DataGridViewRow item in dgvBangKeGroup3_Tong.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["TongCong_Group3_Tong"].Value.ToString()))
                    TongCong += long.Parse(item.Cells["TongCong_Group3_Tong"].Value.ToString());
            }
            txtTongCong_Group3_Tong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        if (CNguoiDung.Doi == false)
                        {
                            DateTime CreateDate = new DateTime();
                            DateTime.TryParse(dgvBangKe.SelectedRows[0].Cells["CreateDate"].Value.ToString(), out CreateDate);
                            if (CreateDate.Date != DateTime.Now.Date)
                            {
                                MessageBox.Show("Chỉ được Điều Chỉnh trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        foreach (DataGridViewRow item in dgvBangKe.SelectedRows)
                        {
                            var transactionOptions = new TransactionOptions();
                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                            {
                                TT_BangKe bangke = _cBangKe.get(int.Parse(item.Cells["MaBK"].Value.ToString()));
                                bool flagLuiNgay = false;
                                DateTime CreateDate = new DateTime();
                                if (bangke.CreateDate.Value.Date != bangke.CreateDate2.Value.Date)
                                {
                                    flagLuiNgay = true;
                                    CreateDate = bangke.CreateDate.Value;
                                }
                                if (_cBangKe.Xoa(bangke))
                                    if (flagLuiNgay == true)
                                    {
                                        if (_cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value * -1, "Bảng Kê", "Xóa", CreateDate))
                                        {
                                            scope.Complete();
                                            scope.Dispose();
                                        }
                                    }
                                    else
                                    {
                                        if (_cTienDu.Update(bangke.DanhBo, bangke.SoTien.Value * -1, "Bảng Kê", "Xóa"))
                                        {
                                            scope.Complete();
                                            scope.Dispose();
                                        }
                                    }
                            }
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXem.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int _searchIndex = -1;
        private string _searchNoiDung = "";

        private void GetNoiDungfrmTimKiem(string NoiDung)
        {
            if (_searchNoiDung != NoiDung)
                _searchIndex = -1;

            for (int i = 0; i < dgvBangKe.Rows.Count; i++)
            {
                if (_searchNoiDung != NoiDung)
                    _searchNoiDung = NoiDung;

                _searchIndex = (_searchIndex + 1) % dgvBangKe.Rows.Count;
                DataGridViewRow row = dgvBangKe.Rows[_searchIndex];
                if (row.Cells["DanhBo"].Value == null || row.Cells["SoTien"].Value == null)
                {
                    continue;
                }
                if (row.Cells["DanhBo"].Value.ToString() == NoiDung || row.Cells["SoTien"].Value.ToString() == NoiDung)
                {
                    dgvBangKe.CurrentCell = row.Cells["DanhBo"];
                    dgvBangKe.Rows[_searchIndex].Selected = true;
                    return;
                }
            }
        }

        private void dgvBangKe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "ChenhLech" && e.Value != null)
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
            if (dgvBangKe.Columns[e.ColumnIndex].Name == "DanhBo" && e.FormattedValue.ToString().Replace(" ", "") != dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString() && e.FormattedValue.ToString().Replace(" ", "").Length == 11)
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    try
                    {
                        if (CNguoiDung.Doi == false)
                        {
                            DateTime CreateDate = new DateTime();
                            DateTime.TryParse(dgvBangKe["CreateDate", e.RowIndex].Value.ToString(), out CreateDate);
                            if (CreateDate.Date != DateTime.Now.Date)
                            {
                                MessageBox.Show("Chỉ được Điều Chỉnh trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            TT_BangKe bangke = _cBangKe.get(int.Parse(dgvBangKe["MaBK", e.RowIndex].Value.ToString()));
                            int SoTien = bangke.SoTien.Value;
                            bangke.DanhBo = e.FormattedValue.ToString().Replace(" ", "");
                            if (_cBangKe.Sua(bangke))
                            {
                                //if (_cTienDu.Update(dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", ""), bangke.SoTien.Value * (-1), "Bảng Kê", "Sửa Đến Danh Bộ " + e.FormattedValue.ToString().Replace(" ", "").Insert(7, " ").Insert(4, " ")))
                                //    if (string.IsNullOrEmpty(dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", "")))
                                //    {
                                //        if (_cTienDu.Update(bangke.DanhBo, SoTien, "Bảng Kê", "Sửa Từ Danh Bộ Rỗng"))
                                //            scope.Complete();
                                //    }
                                //    else
                                //        if (_cTienDu.Update(bangke.DanhBo, SoTien, "Bảng Kê", "Sửa Từ Danh Bộ " + dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", "").Insert(7, " ").Insert(4, " ")))
                                //            scope.Complete();
                                TT_TienDu tdOld = _cTienDu.Get(dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", ""));
                                tdOld.SoTien -= bangke.SoTien;
                                _cTienDu.Sua(tdOld);
                                TT_TienDu tdNew = _cTienDu.Get(bangke.DanhBo);
                                if (tdNew == null)
                                {
                                    TT_TienDu en = new TT_TienDu();
                                    en.DanhBo = bangke.DanhBo;
                                    en.MaNH = bangke.MaNH.Value;
                                    en.SoTien = bangke.SoTien;
                                    _cTienDu.Them(en);
                                }
                                else
                                {
                                    tdNew.SoTien += bangke.SoTien;
                                    _cTienDu.Sua(tdNew);
                                }
                                TT_TienDuLichSu tdls = _cTienDu.get_LichSu(dgvBangKe[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", ""), bangke.SoTien.Value, bangke.CreateDate.Value, bangke.MaBK);
                                tdls.DanhBoTruoc = tdls.DanhBo;
                                tdls.DanhBo = bangke.DanhBo;
                                tdls.DanhBoSau = tdls.DanhBo;
                                tdls.DanhBoNgay = DateTime.Now;
                                _cTienDu.SubmitChanges();
                                scope.Complete();
                            }
                        }
                        _cTienDu.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dgvBangKeGroup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKeGroup.Columns[e.ColumnIndex].Name == "TongCong_Group" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvBangKeGroup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangKeGroup.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBangKeGroup3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKeGroup3.Columns[e.ColumnIndex].Name == "TongCong_Group3" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvBangKeGroup3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangKeGroup3.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBangKe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dgvBangKe.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["DanhBo"].Value.ToString()) && !_cDHN.CheckExist(item.Cells["DanhBo"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void btnChonFileCapNhatPhieuThu_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;
                    if (dgvBangKe.Rows.Count == 0)
                    {
                        MessageBox.Show("Chưa tải dữ liệu Bảng kê", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Cập nhật ngày " + dgvBangKe.Rows[0].Cells["CreateDate"].Value.ToString() + "?", "Xác nhận Cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cBangKe.ExcelToDataTable(dialog.FileName);
                            ////đội thu tiền
                            ////check 2 source
                            //if (dgvBangKe.Rows.Count != dtExcel.Rows.Count)
                            //{
                            //    MessageBox.Show("2 Danh Sách Khác Nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            //var transactionOptions = new TransactionOptions();
                            //transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                            //{
                            //    for (int i = 0; i < dgvBangKe.Rows.Count; i++)
                            //        //if (dtExcel.Rows[i][0].ToString().Replace(" ", "") == "13253310340")
                            //            if (dgvBangKe.Rows[i].Cells["DanhBo"].Value.ToString() == dtExcel.Rows[i][0].ToString().Replace(" ", "") && dgvBangKe.Rows[i].Cells["SoTien"].Value.ToString() == dtExcel.Rows[i][1].ToString().Trim()
                            //                && !string.IsNullOrEmpty(dtExcel.Rows[i][3].ToString().Trim()) && !string.IsNullOrEmpty(dtExcel.Rows[i][4].ToString().Trim()))
                            //            {
                            //                TT_BangKe bangke = _cBangKe.get(int.Parse(dgvBangKe.Rows[i].Cells["MaBK"].Value.ToString()));
                            //                bangke.SoPhieuThu = dtExcel.Rows[i][3].ToString().Trim();
                            //                string[] date = dtExcel.Rows[i][4].ToString().Trim().Split('/');
                            //                string[] year = date[2].Split(' ');
                            //                bangke.NgayPhieuThu = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]));
                            //                _cBangKe.Sua(bangke);
                            //            }
                            //            else
                            //            {
                            //                MessageBox.Show("Lỗi Danh Bộ " + dtExcel.Rows[i][0].ToString().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //                return;
                            //            }
                            //    scope.Complete();
                            //}
                            //phòng ghi thu

                            for (int i = 0; i < dgvBangKe.Rows.Count; i++)
                                if (dgvBangKe["SoPhieuThu", i].Value.ToString() == "")
                                {
                                    var transactionOptions = new TransactionOptions();
                                    transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                    {
                                        DataRow[] dr = dtExcel.Select("DanhBo like '" + dgvBangKe["DanhBo", i].Value.ToString() + "' and SoTien like '" + dgvBangKe["SoTien", i].Value.ToString()+"'");
                                        if (dr != null && dr.Count() > 0)
                                            if (dr != null && dr.Count() == 1)
                                            {
                                                if (!string.IsNullOrEmpty(dr[0][3].ToString().Trim()) && !string.IsNullOrEmpty(dr[0][4].ToString().Trim()))
                                                {
                                                    TT_BangKe bangke = _cBangKe.get(int.Parse(dgvBangKe["MaBK", i].Value.ToString()));
                                                    bangke.SoPhieuThu = dr[0][3].ToString().Trim();
                                                    string[] date = dr[0][4].ToString().Trim().Split('/');
                                                    string[] year = date[2].Split(' ');
                                                    bangke.NgayPhieuThu = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]));
                                                    _cBangKe.Sua(bangke);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Lỗi Danh Bộ " + dgvBangKe["DanhBo", i].Value.ToString().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                //MessageBox.Show("Lỗi Danh Bộ " + dgvBangKe["DanhBo", i].Value.ToString() + " có nhiều hơn 1 dòng cùng Số Tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                //return;
                                                for (int j = 0; j < dr.Count(); j++)
                                                    if (!string.IsNullOrEmpty(dr[j][3].ToString().Trim()) && !string.IsNullOrEmpty(dr[j][4].ToString().Trim()))
                                                    {
                                                        for (int k = i; k < dgvBangKe.Rows.Count; k++)
                                                            if (dgvBangKe["SoPhieuThu", k].Value.ToString() == "")
                                                            {
                                                                TT_BangKe bangke = _cBangKe.get(int.Parse(dgvBangKe["MaBK", k].Value.ToString()));
                                                                bangke.SoPhieuThu = dr[j][3].ToString().Trim();
                                                                string[] date = dr[j][4].ToString().Trim().Split('/');
                                                                string[] year = date[2].Split(' ');
                                                                bangke.NgayPhieuThu = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]));
                                                                _cBangKe.Sua(bangke);
                                                                dgvBangKe["SoPhieuThu", k].Value = bangke.SoPhieuThu;
                                                                break;
                                                            }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Lỗi Danh Bộ " + dgvBangKe["DanhBo", i].Value.ToString().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return;
                                                    }
                                            }
                                        scope.Complete();
                                    }
                                }
                            MessageBox.Show("Đã xử lý, vui lòng kiểm tra lại dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNgayLap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayLap.Checked == true)
                dateNgayLap.Enabled = true;
            else
                dateNgayLap.Enabled = false;
        }

        private void btnXoaLuonLichSu_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        _cBangKe.BeginTransaction();
                        foreach (DataGridViewRow item in dgvBangKe.SelectedRows)
                        {
                            TT_BangKe bangke = _cBangKe.get(int.Parse(item.Cells["MaBK"].Value.ToString()));
                            TT_TienDu tiendu = _cTienDu.Get(bangke.DanhBo);
                            TT_TienDuLichSu tiendulichsu = _cTienDu.get_LichSu(bangke.DanhBo, bangke.SoTien.Value, bangke.CreateDate.Value, bangke.MaBK);
                            if (bangke != null && tiendu != null && tiendulichsu != null)
                            {
                                tiendu.SoTien -= bangke.SoTien.Value;
                                _cTienDu.xoa_LichSu(tiendulichsu);
                                _cBangKe.Xoa(bangke);
                            }
                        }
                        _cBangKe.CommitTransaction();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _cBangKe.Rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBK = new DataTable();
                dtBK.Columns.Add("DanhBo", typeof(System.String));
                dtBK.Columns.Add("SoTien", typeof(System.String));
                dtBK.Columns.Add("Bank", typeof(System.String));
                foreach (DataGridViewRow item in dgvBangKe.Rows)
                {
                    DataRow drBK = dtBK.NewRow();
                    drBK["DanhBo"] = item.Cells["DanhBo"].Value.ToString();
                    drBK["SoTien"] = item.Cells["SoTien"].Value.ToString();
                    drBK["Bank"] = _cNganHang.getKyHieuByTenNH(item.Cells["TenNH"].Value.ToString());
                    dtBK.Rows.Add(drBK);
                }
                if (dtBK.Rows.Count > 0)
                    _cBangKe.XuatExcel(dtBK, "Bảng Kê " + CNguoiDung.TenPhong);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBangKeGroup_Tong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangKeGroup_Tong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBangKeGroup_Tong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKeGroup_Tong.Columns[e.ColumnIndex].Name == "TongCong_Group_Tong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvBangKeGroup3_Tong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBangKeGroup3_Tong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBangKeGroup3_Tong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangKeGroup3_Tong.Columns[e.ColumnIndex].Name == "TongCong_Group3_Tong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }



    }
}

