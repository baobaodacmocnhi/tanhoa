using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.DAL.DongNuoc;

namespace KTKS_DonKH.GUI.QuanTri
{
    public partial class frmBanGiamDoc : Form
    {
        string _mnu = "mnuBanGiamDoc";
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        int selectedindex = -1;
        CDCBD _cDCBD = new CDCBD();
        CChungTu _cChungTu = new CChungTu();
        CCHDB _cCHDB = new CCHDB();
        CTTTL _cTTTL = new CTTTL();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CToTrinh _cToTrinh = new CToTrinh();

        public frmBanGiamDoc()
        {
            InitializeComponent();
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    this.ControlBox = false;
        //    this.WindowState = FormWindowState.Maximized;
        //    this.BringToFront();
        //}

        public void Clear()
        {
            txtChucVu.Text = "";
            txtHoTen.Text = "";
            selectedindex = -1;
            if (CTaiKhoan.Admin == true)
                dgvDSBanGiamDoc.DataSource = _cBanGiamDoc.getDS_Admin();
            else
                dgvDSBanGiamDoc.DataSource = _cBanGiamDoc.getDS();
        }

        private void frmBanGiamDoc_Load(object sender, EventArgs e)
        {
            dgvDSBanGiamDoc.AutoGenerateColumns = false;
            dgvDSBanGiamDoc.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSBanGiamDoc.Font, FontStyle.Bold);

            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDanhSach.Font, FontStyle.Bold);

            if (CTaiKhoan.Admin == true)
                dgvDSBanGiamDoc.DataSource = _cBanGiamDoc.getDS_Admin();
            else
                dgvDSBanGiamDoc.DataSource = _cBanGiamDoc.getDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (txtChucVu.Text.Trim() != "" && txtHoTen.Text.Trim() != "")
                    {
                        BanGiamDoc bangiamdoc = new BanGiamDoc();
                        bangiamdoc.ChucVu = txtChucVu.Text.Trim();
                        bangiamdoc.HoTen = txtHoTen.Text.Trim();

                        if (_cBanGiamDoc.Them(bangiamdoc))
                            Clear();
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (selectedindex != -1)
                        if (txtChucVu.Text.Trim() != "" && txtHoTen.Text.Trim() != "")
                        {
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.get(int.Parse(dgvDSBanGiamDoc["MaBGD", selectedindex].Value.ToString()));
                            bangiamdoc.ChucVu = txtChucVu.Text.Trim();
                            bangiamdoc.HoTen = txtHoTen.Text.Trim();

                            if (_cBanGiamDoc.Sua(bangiamdoc))
                                Clear();
                        }
                        else
                            MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (selectedindex != -1)
                        if (txtChucVu.Text.Trim() != "" && txtHoTen.Text.Trim() != "")
                        {
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.get(int.Parse(dgvDSBanGiamDoc["MaBGD", selectedindex].Value.ToString()));
                            bangiamdoc.An = true;

                            if (_cBanGiamDoc.Sua(bangiamdoc))
                                Clear();
                        }
                        else
                            MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSBanGiamDoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSBanGiamDoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSBanGiamDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtChucVu.Text = dgvDSBanGiamDoc["ChucVu", e.RowIndex].Value.ToString();
                txtHoTen.Text = dgvDSBanGiamDoc["HoTen", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dgvDSBanGiamDoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BanGiamDoc bangiamdoc = _cBanGiamDoc.get(int.Parse(dgvDSBanGiamDoc["MaBGD", selectedindex].Value.ToString()));
            if (bool.Parse(dgvDSBanGiamDoc["KyTen", e.RowIndex].Value.ToString()) != bangiamdoc.KyTen)
            {
                bangiamdoc.KyTen = bool.Parse(dgvDSBanGiamDoc["KyTen", e.RowIndex].Value.ToString());
                _cBanGiamDoc.Sua(bangiamdoc);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "ID" && e.Value != null)
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã":
                    switch (cmbLoai.SelectedItem.ToString())
                    {
                        case "Điều Chỉnh Biến Động":
                            dgvDanhSach.DataSource = _cDCBD.getDS_BienDong_SoPhieu(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Điều Chỉnh Hóa Đơn":
                            dgvDanhSach.DataSource = _cDCBD.getDS_HoaDon_SoPhieu(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Cắt Chuyển":
                            dgvDanhSach.DataSource = _cChungTu.getDS_CatChuyenDM_SoPhieu(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Cắt Tạm Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.getDS_CatTam(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Cắt Hủy Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.getDS_CatHuy(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Yêu Cầu Cắt Hủy Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.getDS_PhieuHuy(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Đóng Nước":
                            dgvDanhSach.DataSource = _cDongNuoc.getDS_DongNuoc(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Mở Nước":
                            dgvDanhSach.DataSource = _cDongNuoc.GetDSMoNuoc(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Thảo Thư Trả Lời":
                            dgvDanhSach.DataSource = _cTTTL.GetDS(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Tờ Trình":
                            dgvDanhSach.DataSource = _cToTrinh.getDS_ChiTiet(int.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                    }
                    break;
                case "Ngày":
                    switch (cmbLoai.SelectedItem.ToString())
                    {
                        case "Điều Chỉnh Biến Động":
                            dgvDanhSach.DataSource = _cDCBD.getDS_BienDong_CreateDate(dateTu.Value, dateDen.Value);
                            break;
                        case "Điều Chỉnh Hóa Đơn":
                            dgvDanhSach.DataSource = _cDCBD.getDS_HoaDon_CreateDate(dateTu.Value, dateDen.Value);
                            break;
                        case "Cắt Chuyển":
                            dgvDanhSach.DataSource = _cChungTu.getDSCatChuyenDM(dateTu.Value, dateDen.Value);
                            break;
                        case "Cắt Tạm Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.getDS_CatTam(dateTu.Value, dateDen.Value);
                            break;
                        case "Cắt Hủy Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.getDS_CatHuy(dateTu.Value, dateDen.Value);
                            break;
                        case "Yêu Cầu Cắt Hủy Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.LoadDSYCCHDB_Don(dateTu.Value, dateDen.Value);
                            break;
                        case "Đóng Nước":
                            dgvDanhSach.DataSource = _cDongNuoc.getDS_DongNuoc_CreateDate(dateTu.Value, dateDen.Value);
                            break;
                        case "Mở Nước":
                            dgvDanhSach.DataSource = _cDongNuoc.GetDSMoNuoc(dateTu.Value, dateDen.Value);
                            break;
                        case "Thảo Thư Trả Lời":
                            dgvDanhSach.DataSource = _cTTTL.GetDS(dateTu.Value, dateDen.Value);
                            break;
                        case "Tờ Trình":
                            dgvDanhSach.DataSource = _cToTrinh.getDS_ChiTiet(dateTu.Value, dateDen.Value);
                            break;
                    }
                    break;
            }
        }

        private void btnSuaNguoiKy_Click(object sender, EventArgs e)
        {
            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
            switch (cmbLoai.SelectedItem.ToString())
            {
                case "Điều Chỉnh Biến Động":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDong(decimal.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdcbd.ChucVu = "GIÁM ĐỐC";
                            else
                                ctdcbd.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cDCBD.SuaDCBD(ctdcbd);
                        }
                    break;
                case "Điều Chỉnh Hóa Đơn":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            DCBD_ChiTietHoaDon ctdchd = _cDCBD.getHoaDon(decimal.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdchd.ChucVu = "GIÁM ĐỐC";
                            else
                                ctdchd.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cDCBD.SuaDCHD(ctdchd);
                        }
                    break;
                case "Cắt Chuyển":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            ChungTu_LichSu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                            else
                                lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cChungTu.SuaLichSuChungTu(lichsuchungtu);
                        }
                    break;
                case "Cắt Tạm Danh Bộ":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctctdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ctctdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctctdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cCHDB.SuaCTCTDB(ctctdb);
                        }
                    break;
                case "Cắt Hủy Danh Bộ":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ctchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cCHDB.SuaCTCHDB(ctchdb);
                        }
                    break;
                case "Yêu Cầu Cắt Hủy Danh Bộ":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuy(decimal.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ycchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ycchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cCHDB.SuaPhieuHuy(ycchdb);
                        }
                    break;
                case "Đóng Nước":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            DongNuoc_ChiTiet ctdongnuoc = _cDongNuoc.GetCTByMaCTDN(decimal.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdongnuoc.ChucVu_DN = "GIÁM ĐỐC";
                            else
                                ctdongnuoc.ChucVu_DN = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdongnuoc.NguoiKy_DN = bangiamdoc.HoTen.ToUpper();
                            _cDongNuoc.SuaCT(ctdongnuoc);
                        }
                    break;
                case "Mở Nước":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            DongNuoc_ChiTiet ctdongnuoc = _cDongNuoc.GetCTByMaCTMN(decimal.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdongnuoc.ChucVu_MN = "GIÁM ĐỐC";
                            else
                                ctdongnuoc.ChucVu_MN = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdongnuoc.NguoiKy_MN = bangiamdoc.HoTen.ToUpper();
                            _cDongNuoc.SuaCT(ctdongnuoc);
                        }
                    break;
                case "Thảo Thư Trả Lời":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            ThuTraLoi_ChiTiet cttttl = _cTTTL.GetCT(decimal.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                cttttl.ChucVu = "GIÁM ĐỐC";
                            else
                                cttttl.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cTTTL.SuaCT(cttttl);
                        }
                    break;
                case "Tờ Trình":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (dgvDanhSach["CapNhat", i].Value != null && bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            ToTrinh_ChiTiet tt = _cToTrinh.get_ChiTiet(int.Parse(dgvDanhSach["ID", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                tt.ChucVu = "GIÁM ĐỐC";
                            else
                                tt.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            tt.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cToTrinh.Sua_ChiTiet(tt);
                        }
                    break;
            }
            MessageBox.Show("Đã xử lý, Vui lòng kiểm tra lại thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnXem.PerformClick();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
                for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
                {
                    dgvDanhSach["CapNhat", i].Value = true;
                }
            else
                for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
                {
                    dgvDanhSach["CapNhat", i].Value = false;
                }
        }

        private void cmbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = null;
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã":
                    txtNoiDung.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDung.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDung.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
        }

        private void txtNoiDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNoiDung.Text.Trim().Length > 0 && e.KeyChar == 13)
                btnXem.PerformClick();
        }



    }
}
