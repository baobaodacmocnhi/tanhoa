﻿using System;
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
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.DAL.DongNuoc;

namespace KTKS_DonKH.GUI.QuanTri
{
    public partial class frmBanGiamDoc : Form
    {
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        int selectedindex = -1;
        CDCBD _cDCBD = new CDCBD();
        CChungTu _cChungTu = new CChungTu();
        CCHDB _cCHDB = new CCHDB();
        CTTTL _cTTTL = new CTTTL();
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmBanGiamDoc()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public void Clear()
        {
            txtChucVu.Text = "";
            txtHoTen.Text = "";
            selectedindex = -1;
            dgvDSBanGiamDoc.DataSource = _cBanGiamDoc.LoadDSBanGiamDoc();
        }

        private void frmBanGiamDoc_Load(object sender, EventArgs e)
        {
            dgvDSBanGiamDoc.AutoGenerateColumns = false;
            dgvDSBanGiamDoc.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSBanGiamDoc.Font, FontStyle.Bold);
            dgvDSBanGiamDoc.DataSource = _cBanGiamDoc.LoadDSBanGiamDoc();

            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDanhSach.Font, FontStyle.Bold);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtChucVu.Text.Trim() != "" && txtHoTen.Text.Trim() != "")
            {
                BanGiamDoc bangiamdoc = new BanGiamDoc();
                bangiamdoc.ChucVu = txtChucVu.Text.Trim();
                bangiamdoc.HoTen = txtHoTen.Text.Trim();

                if (_cBanGiamDoc.ThemBanGiamDoc(bangiamdoc))
                    Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
                if (txtChucVu.Text.Trim() != "" && txtHoTen.Text.Trim() != "")
                {
                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBanGiamDocbyID(int.Parse(dgvDSBanGiamDoc["MaBGD", selectedindex].Value.ToString()));
                    bangiamdoc.ChucVu = txtChucVu.Text.Trim();
                    bangiamdoc.HoTen = txtHoTen.Text.Trim();

                    if (_cBanGiamDoc.SuaBanGiamDoc(bangiamdoc))
                        Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBanGiamDocbyID(int.Parse(dgvDSBanGiamDoc["MaBGD", selectedindex].Value.ToString()));
            if (bool.Parse(dgvDSBanGiamDoc["KyTen", e.RowIndex].Value.ToString()) != bangiamdoc.KyTen)
            {
                bangiamdoc.KyTen = bool.Parse(dgvDSBanGiamDoc["KyTen", e.RowIndex].Value.ToString());
                _cBanGiamDoc.SuaBanGiamDoc(bangiamdoc);
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
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "Ma" && e.Value != null)
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
                            dgvDanhSach.DataSource = _cDCBD.LoadDSCTDCBDBySoPhieu(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Điều Chỉnh Hóa Đơn":
                            dgvDanhSach.DataSource = _cDCBD.LoadDSCTDCHDBySoPhieu(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Cắt Chuyển":
                            dgvDanhSach.DataSource = _cChungTu.LoadDSCatChuyenDMBySoPhieu(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Cắt Tạm Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.LoadDSCTCTDBByMaTB(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Cắt Hủy Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.LoadDSCTCHDBByMaTB(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Yêu Cầu Cắt Hủy Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.LoadDSYCCHDBBySoPhieu(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Đóng Nước":
                            dgvDanhSach.DataSource = _cDongNuoc.LoadDSCTDongNuocByMaTB(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Mở Nước":
                            dgvDanhSach.DataSource = _cDongNuoc.LoadDSCTMoNuocByMaTB(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                        case "Thảo Thư Trả Lời":
                            dgvDanhSach.DataSource = _cTTTL.GetDSByMaTB(decimal.Parse(txtNoiDung.Text.Trim().Replace("-", "")));
                            break;
                    }
                    break;
                case "Ngày":
                    switch (cmbLoai.SelectedItem.ToString())
                    {
                        case "Điều Chỉnh Biến Động":
                            dgvDanhSach.DataSource = _cDCBD.LoadDSCTDCBD(dateTu.Value);
                            break;
                        case "Điều Chỉnh Hóa Đơn":
                            dgvDanhSach.DataSource = _cDCBD.LoadDSCTDCHD(dateTu.Value);
                            break;
                        case "Cắt Chuyển":
                            dgvDanhSach.DataSource = _cChungTu.LoadDSCatChuyenDM(dateTu.Value);
                            break;
                        case "Cắt Tạm Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.LoadDSCTCTDB(dateTu.Value);
                            break;
                        case "Cắt Hủy Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.LoadDSCTCHDB(dateTu.Value);
                            break;
                        case "Yêu Cầu Cắt Hủy Danh Bộ":
                            dgvDanhSach.DataSource = _cCHDB.LoadDSYCCHDB_Don(dateTu.Value);
                            break;
                        case "Đóng Nước":
                            dgvDanhSach.DataSource = _cDongNuoc.LoadDSCTDongNuoc(dateTu.Value);
                            break;
                        case "Mở Nước":
                            dgvDanhSach.DataSource = _cDongNuoc.LoadDSCTMoNuoc(dateTu.Value);
                            break;
                        case "Thảo Thư Trả Lời":
                            dgvDanhSach.DataSource = _cTTTL.GetDSByCreateDate(dateTu.Value, dateDen.Value);
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
                        if (bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CTDCBD ctdcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(dgvDanhSach["Ma", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdcbd.ChucVu = "GIÁM ĐỐC";
                            else
                                ctdcbd.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cDCBD.SuaCTDCBD(ctdcbd);
                        }
                    break;
                case "Điều Chỉnh Hóa Đơn":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CTDCHD ctdchd = _cDCBD.getCTDCHDbyID(decimal.Parse(dgvDanhSach["Ma", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdchd.ChucVu = "GIÁM ĐỐC";
                            else
                                ctdchd.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cDCBD.SuaCTDCHD(ctdchd);
                        }
                    break;
                case "Cắt Chuyển":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            LichSuChungTu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDanhSach["Ma", i].Value.ToString()));

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
                        if (bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CTCTDB ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(dgvDanhSach["Ma", i].Value.ToString()));

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
                        if (bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CTCHDB ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(dgvDanhSach["Ma", i].Value.ToString()));

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
                        if (bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            PhieuCHDB ycchdb = _cCHDB.getYeuCauCHDbyID(decimal.Parse(dgvDanhSach["Ma", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ycchdb.ChucVu = "GIÁM ĐỐC";
                            else
                                ycchdb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ycchdb.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cCHDB.SuaYeuCauCHDB(ycchdb);
                        }
                    break;
                case "Đóng Nước":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CTDongNuoc ctdongnuoc = _cDongNuoc.getCTDongNuocbyID(decimal.Parse(dgvDanhSach["Ma", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdongnuoc.ChucVu_DN = "GIÁM ĐỐC";
                            else
                                ctdongnuoc.ChucVu_DN = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdongnuoc.NguoiKy_DN = bangiamdoc.HoTen.ToUpper();
                            _cDongNuoc.SuaCTDongNuoc(ctdongnuoc);
                        }
                    break;
                case "Mở Nước":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CTDongNuoc ctdongnuoc = _cDongNuoc.getCTMoNuocbyID(decimal.Parse(dgvDanhSach["Ma", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdongnuoc.ChucVu_MN = "GIÁM ĐỐC";
                            else
                                ctdongnuoc.ChucVu_MN = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdongnuoc.NguoiKy_MN = bangiamdoc.HoTen.ToUpper();
                            _cDongNuoc.SuaCTDongNuoc(ctdongnuoc);
                        }
                    break;
                case "Thảo Thư Trả Lời":
                    for (int i = 0; i < dgvDanhSach.RowCount; i++)
                        if (bool.Parse(dgvDanhSach["CapNhat", i].Value.ToString()) == true)
                        {
                            CTTTTL cttttl = _cTTTL.GetCTByID(decimal.Parse(dgvDanhSach["Ma", i].Value.ToString()));

                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                cttttl.ChucVu = "GIÁM ĐỐC";
                            else
                                cttttl.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            cttttl.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            _cTTTL.SuaCT(cttttl);
                        }
                    break;
            }
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
                    dateTu.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDung.Visible = false;
                    dateTu.Visible = true;
                    break;
                default:
                    txtNoiDung.Visible = false;
                    dateTu.Visible = false;
                    break;
            }
        }

    }
}