using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;
using DocSo_PC.BaoCao;
using DocSo_PC.BaoCao.ToTruong;
using DocSo_PC.GUI.BaoCao;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmPhieuChuyen : Form
    {
        string _mnu = "mnuPhieuChuyen";
        CTo _cTo = new CTo();
        CDHN _cDHN = new CDHN();
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();

        public frmPhieuChuyen()
        {
            InitializeComponent();
        }

        private void frmPhieuChuyen_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;
                List<To> lst = _cTo.getDS_HanhThu();
                To en = new To();
                en.MaTo = 0;
                en.TenTo = "Tất Cả";
                lst.Insert(0, en);
                cmbTo.DataSource = lst;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
            }
            cmbLoai.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbLoai.SelectedItem.ToString())
            {
                case "Âm Sâu":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_AmSau(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_AmSau(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_AmSau(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Xây Dựng":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_XayDung(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_XayDung(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_XayDung(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Đứt Chì Góc":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_DutChiGoc(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_DutChiGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_DutChiGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Đứt Chì Thân":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_DutChiThan(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_DutChiThan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_DutChiThan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Ngập Nước":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_NgapNuoc(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_NgapNuoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_NgapNuoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Kẹt Tường":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_KetTuong(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_KetTuong(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_KetTuong(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Lấp Khóa Góc":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_LapKhoaGoc(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_LapKhoaGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_LapKhoaGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Bể Hộp Bảo Vệ":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_BeHBV(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_BeHBV(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_BeHBV(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Bể Nấp, Mất Nấp Hộp Bảo Vệ":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_BeNapMatNapHBV(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_BeNapMatNapHBV(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_BeNapMatNapHBV(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Gãy Tay Van":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_GayTayVan(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_GayTayVan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_GayTayVan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                default:
                    DataTable dt = new DataTable();
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                        {
                            dt.Merge(_cDHN.getDS_AmSau(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_XayDung(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_DutChiGoc(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_DutChiThan(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_NgapNuoc(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_KetTuong(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_LapKhoaGoc(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_BeHBV(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_BeNapMatNapHBV(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_GayTayVan(dateTuNgay.Value, dateDenNgay.Value));
                        }
                        else
                        {
                            dt.Merge(_cDHN.getDS_AmSau(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_XayDung(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_DutChiGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_DutChiThan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_NgapNuoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_KetTuong(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_LapKhoaGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_BeHBV(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_BeNapMatNapHBV(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_GayTayVan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                        }
                    }
                    else
                    {
                        dt.Merge(_cDHN.getDS_AmSau(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_XayDung(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_DutChiGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_DutChiThan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_NgapNuoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_KetTuong(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_LapKhoaGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_BeHBV(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_BeNapMatNapHBV(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_GayTayVan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                    }
                    dgvDanhSach.DataSource = dt;
                    break;
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    _cTo.LoadImageView(_cTo.imageToByteArray(_cTo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa(dgvDanhSach["Folder", e.RowIndex].Value.ToString(), "", dgvDanhSach["DanhBo", e.RowIndex].Value.ToString() + ".jpg"))));
                }
            }
            catch
            {
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                TB_DULIEUKHACHHANG ttkh = _cDHN.get(item.Cells["DanhBo"].Value.ToString());
                if (ttkh != null)
                {
                    DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                    dr["TenPhong"] = CNguoiDung.TenPhong;
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dr["SoPhieu"] = "Số:_____/DS";
                        else
                            dr["SoPhieu"] = "Số:_____/DS-" + _cTo.get(int.Parse(cmbTo.SelectedValue.ToString())).KyHieu;
                    }
                    else
                    {
                        dr["SoPhieu"] = "Số:_____/DS-" + _cTo.get(CNguoiDung.MaTo).KyHieu;
                    }
                    dr["TieuDe"] = "DANH SÁCH ĐỒNG HỒ NƯỚC " + item.Cells["NoiDung"].Value.ToString().ToUpper();
                    switch (item.Cells["NoiDung"].Value.ToString())
                    {
                        case "Âm Sâu":
                            if (ttkh.ViTriDHN_Ngoai)
                            {
                                dr["TieuDe"] = "DANH SÁCH ĐỒNG HỒ NƯỚC " + item.Cells["NoiDung"].Value.ToString().ToUpper() + " NGOÀI BẤT ĐỘNG SẢN";
                                dr["NoiNhan"] = "P. KHĐT\nLưu";
                            }
                            else
                            {
                                dr["TieuDe"] = "DANH SÁCH ĐỒNG HỒ NƯỚC " + item.Cells["NoiDung"].Value.ToString().ToUpper() + " TRONG BẤT ĐỘNG SẢN";
                                dr["NoiNhan"] = "P. Thương Vụ\nLưu";
                            }
                            break;
                        case "Kẹt Tường":
                            dr["NoiNhan"] = "P. Thương Vụ\nĐ. TCTB\nLưu";
                            break;
                        case "Ngập Nước":
                            dr["NoiNhan"] = "Đ. TCTB\nLưu";
                            break;
                        case "Lấp Khóa Góc":
                            dr["NoiNhan"] = "P. Thương Vụ\nLưu";
                            break;
                        default:
                            dr["NoiNhan"] = "P. Thương Vụ: thực hiện\nLưu";
                            break;
                    }
                    dr["ThoiGian"] = "Từ ngày " + dateTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateDenNgay.Value.ToString("dd/MM/yyyy");
                    dr["DanhBo"] = ttkh.DANHBO.Insert(7, " ").Insert(4, " ");
                    dr["MLT"] = ttkh.LOTRINH;
                    dr["HoTen"] = ttkh.HOTEN;
                    dr["DiaChi"] = ttkh.SONHA + " " + ttkh.TENDUONG + _cDHN.getPhuongQuan(ttkh.QUAN, ttkh.PHUONG);
                    HOADON hd = _cThuTien.GetMoiNhat(ttkh.DANHBO);
                    if (hd != null)
                        dr["HopDong"] = hd.SO + " " + hd.DUONG + _cDHN.getPhuongQuan(hd.Quan, hd.Phuong);
                    dr["Hieu"] = ttkh.HIEUDH;
                    dr["Co"] = ttkh.CODH;
                    dr["SoThan"] = ttkh.SOTHANDH;
                    dr["ViTri"] = ttkh.VITRIDHN;
                    DocSo docso = _cDocSo.get_DocSo_MoiNhat(ttkh.DANHBO);
                    dr["ChiSo"] = docso.CSMoi;
                    dr["TieuThu"] = docso.TieuThuMoi;
                    dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper();
                    dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                    dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                }
            }
            rptDSPhieuChuyen rpt = new rptDSPhieuChuyen();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", "").Length == 11)
            {
                TB_DULIEUKHACHHANG ttkh = _cDHN.get(txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", ""));
                if (ttkh != null)
                {
                    txtHoTen.Text = ttkh.HOTEN;
                    txtDiaChi.Text = ttkh.SONHA + " " + ttkh.TENDUONG;
                }
                else
                    MessageBox.Show("Danh Bộ không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                    {
                        if (cmbLoai.SelectedIndex <= 0)
                        {
                            MessageBox.Show("Chưa chọn Loại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        TB_DULIEUKHACHHANG ttkh = _cDHN.get(txtDanhBo.Text.Trim().Replace("-", "").Replace(" ", ""));
                        if (ttkh != null)
                        {
                            switch (cmbLoai.SelectedItem.ToString())
                            {
                                case "Âm Sâu":
                                    ttkh.AmSau = true;
                                    ttkh.AmSau_Ngay = DateTime.Now;
                                    break;
                                case "Xây Dựng":
                                    ttkh.XayDung = true;
                                    ttkh.XayDung_Ngay = DateTime.Now;
                                    break;
                                case "Đứt Chì Góc":
                                    ttkh.DutChi_Goc = true;
                                    ttkh.DutChi_Goc_Ngay = DateTime.Now;
                                    break;
                                case "Đứt Chì Thân":
                                    ttkh.DutChi_Than = true;
                                    ttkh.DutChi_Than_Ngay = DateTime.Now;
                                    break;
                                case "Ngập Nước":
                                    ttkh.NgapNuoc = true;
                                    ttkh.NgapNuoc_Ngay = DateTime.Now;
                                    break;
                                case "Kẹt Tường":
                                    ttkh.KetTuong = true;
                                    ttkh.KetTuong_Ngay = DateTime.Now;
                                    break;
                                case "Lấp Khóa Góc":
                                    ttkh.LapKhoaGoc = true;
                                    ttkh.LapKhoaGoc_Ngay = DateTime.Now;
                                    break;
                                case "Bể Hộp Bảo Vệ":
                                    ttkh.BeHBV = true;
                                    ttkh.BeHBV_Ngay = DateTime.Now;
                                    break;
                                case "Bể Nấp, Mất Nấp Hộp Bảo Vệ":
                                    ttkh.BeNapMatNapHBV = true;
                                    ttkh.BeNapMatNapHBV_Ngay = DateTime.Now;
                                    break;
                                case "Gãy Tay Van":
                                    ttkh.GayTayVan = true;
                                    ttkh.GayTayVan_Ngay = DateTime.Now;
                                    break;
                                default:
                                    break;
                            }
                            _cDHN.SubmitChanges();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TB_DULIEUKHACHHANG ttkh = _cDHN.get(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString());
                        if (ttkh != null)
                        {
                            switch (dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString())
                            {
                                case "Âm Sâu":
                                    ttkh.AmSau = false;
                                    break;
                                case "Xây Dựng":
                                    ttkh.XayDung = false;
                                    break;
                                case "Đứt Chì Góc":
                                    ttkh.DutChi_Goc = false;
                                    break;
                                case "Đứt Chì Thân":
                                    ttkh.DutChi_Goc = false;
                                    ttkh.DutChi_Than = false;
                                    break;
                                case "Ngập Nước":
                                    ttkh.NgapNuoc = false;
                                    break;
                                case "Kẹt Tường":
                                    ttkh.KetTuong = false;
                                    break;
                                case "Lấp Khóa Góc":
                                    ttkh.LapKhoaGoc = false;
                                    break;
                                case "Bể Hộp Bảo Vệ":
                                    ttkh.BeHBV = false;
                                    break;
                                case "Bể Nấp, Mất Nấp Hộp Bảo Vệ":
                                    ttkh.BeNapMatNapHBV = false;
                                    break;
                                case "Gãy Tay Van":
                                    ttkh.GayTayVan = false;
                                    break;
                                default:
                                    break;
                            }
                            _cDHN.SubmitChanges();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "GhiChu")
            {
                //TB_DULIEUKHACHHANG ttkh = _cDHN.get(dgvDanhSach["GhiChu", e.RowIndex].Value.ToString());
                //if (ttkh != null)
                //{
                //    ttkh.GhiChu = dgvDanhSach["GhiChu", e.RowIndex].Value.ToString();
                //}
            }
        }
    }
}
