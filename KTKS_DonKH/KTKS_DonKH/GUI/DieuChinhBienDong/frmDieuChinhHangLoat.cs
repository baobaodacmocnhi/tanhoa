using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDieuChinhHangLoat : Form
    {
        string _mnu = "mnuDieuChinhHangLoat";
        CDCBD _cDCBD = new CDCBD();
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CDocSo _cDocSo = new CDocSo();
        dbKinhDoanhDataContext _db = new dbKinhDoanhDataContext();

        public frmDieuChinhHangLoat()
        {
            InitializeComponent();
        }

        private void frmDieuChinhHangLoat_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cDCBD.ExcelToDataTable(dialog.FileName);

                            foreach (DataRow item in dtExcel.Rows)
                                if (item[1].ToString().Trim() != "")
                                {
                                    string DanhBo = "";
                                    if (item[1].ToString().Trim().Length == 11)
                                        DanhBo = item[1].ToString().Trim();
                                    else
                                        DanhBo = item[1].ToString().Trim().Substring(6, 11);
                                    if (_db.DieuChinhHangLoats.Any(itemA => itemA.DanhBo == DanhBo && itemA.Nam == int.Parse(txtNam.Text.Trim()) && itemA.Ky == int.Parse(txtKy.Text.Trim())) == false)
                                    {
                                        DieuChinhHangLoat en = new DieuChinhHangLoat();
                                        en.DanhBo = DanhBo;
                                        en.Nam = int.Parse(txtNam.Text.Trim());
                                        en.Ky = int.Parse(txtKy.Text.Trim());
                                        if (txtDot.Text.Trim() != "")
                                            en.Dot = int.Parse(txtDot.Text.Trim());
                                        en.STT2 = int.Parse(item[0].ToString().Trim());
                                        if (radDCBD.Checked)
                                            en.DCBD = true;
                                        else
                                            if (radDCHD.Checked)
                                                en.DCHD = true;
                                        //DocSo docso = _cDocSo.get(en.DanhBo, en.Ky, en.Nam);
                                        //if (docso != null)
                                        //{
                                        //    en.CSC = docso.CSCu.Value.ToString();
                                        //    en.CSM = docso.CSMoi.Value.ToString();
                                        //    en.Code = docso.CodeMoi;
                                        //    en.TieuThu = docso.TieuThuMoi;
                                        //}
                                        en.CreateBy = CTaiKhoan.MaUser;
                                        en.CreateDate = DateTime.Now;
                                        _db.DieuChinhHangLoats.InsertOnSubmit(en);
                                        _db.SubmitChanges();
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //string sql = "select * from DieuChinhHangLoat where Nam=" + int.Parse(txtNam.Text.Trim()) + " and Ky=" + int.Parse(txtKy.Text.Trim()) + " and Dot=" + int.Parse(txtDot.Text.Trim()) + " order by STT2 asc";
            string sql = "select * from DieuChinhHangLoat where Nam=" + int.Parse(txtNam.Text.Trim()) + " and Ky=" + int.Parse(txtKy.Text.Trim());
            if (txtDot.Text.Trim() != "")
                sql += " and Dot=" + int.Parse(txtDot.Text.Trim());
            if (radDCBD.Checked)
                sql += " and DCBD=1";
            else
                if (radDCHD.Checked)
                    sql += " and DCHD=1";
            sql += "  order by STT2 asc";
            dgvDanhSach.DataSource = _cDCBD.ExecuteQuery_DataTable(sql);
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnTVLapDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen("mnuDCHD", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_db.DieuChinhHangLoats.Any(item => item.Nam == int.Parse(dgvDanhSach.Rows[0].Cells["Nam"].Value.ToString()) && item.Ky == int.Parse(dgvDanhSach.Rows[0].Cells["Ky"].Value.ToString()) && item.Dot == int.Parse(dgvDanhSach.Rows[0].Cells["Dot"].Value.ToString()) && item.MaDon != null) == true)
                        {
                            MessageBox.Show("Đã có Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        LinQ.DonTu entity = new LinQ.DonTu();

                        int ID = _cDonTu.getMaxID_ChiTiet();
                        int STT = 0;
                        for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
                        {
                            //HOADON hd = _cThuTien.Get(dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString(), int.Parse(dgvDanhSach.Rows[0].Cells["Ky"].Value.ToString()), int.Parse(dgvDanhSach.Rows[0].Cells["Nam"].Value.ToString()));
                            HOADON hd = _cThuTien.GetMoiNhat(dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString());
                            if (hd != null)
                            {
                                DonTu_ChiTiet entityCT = new DonTu_ChiTiet();
                                entityCT.ID = ++ID;
                                entityCT.STT = ++STT;

                                entityCT.DanhBo = hd.DANHBA;
                                entityCT.MLT = hd.MALOTRINH;
                                entityCT.HopDong = hd.HOPDONG;
                                entityCT.HoTen = hd.TENKH;
                                entityCT.DiaChi = hd.SO + " " + hd.DUONG;
                                entityCT.GiaBieu = hd.GB;
                                entityCT.DinhMuc = hd.DM;
                                entityCT.DinhMucHN = hd.DinhMucHN;
                                entityCT.Dot = hd.DOT;
                                entityCT.Ky = hd.KY;
                                entityCT.Nam = hd.NAM;
                                entityCT.Quan = hd.Quan;
                                entityCT.Phuong = hd.Phuong;

                                entityCT.CreateBy = CTaiKhoan.MaUser;
                                entityCT.CreateDate = DateTime.Now;
                                entityCT.TinhTrang = "Hoàn Thành";

                                entity.DonTu_ChiTiets.Add(entityCT);
                            }
                        }
                        entity.TinhTrang = "Hoàn Thành";
                        entity.SoCongVan_PhongBanDoi = "P. TV";
                        entity.TongDB = entity.DonTu_ChiTiets.Count;
                        entity.ID_NhomDon_PKH = "7";
                        entity.Name_NhomDon_PKH = "Định mức";
                        entity.ID_NhomDon = "2";
                        entity.Name_NhomDon = "Cắt chuyển định mức";
                        entity.VanPhong = true;
                        entity.MaPhong = 1;
                        if (_cDonTu.Them(entity))
                        {
                            foreach (DonTu_ChiTiet itemDonChiTiet in entity.DonTu_ChiTiets)
                            {
                                _cDCBD.ExecuteNonQuery("update DieuChinhHangLoat set MaDon=" + itemDonChiTiet.MaDon + ",STT=" + itemDonChiTiet.STT + " where DanhBo='" + itemDonChiTiet.DanhBo + "' and Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and Dot=" + txtDot.Text.Trim());
                            }
                            _db = new dbKinhDoanhDataContext();
                            MessageBox.Show("Thành công\nMã Đơn: " + entity.MaDon.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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

        private void btnTVDieuChinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen("mnuDCHD", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_db.DieuChinhHangLoats.Count(item => item.Nam == int.Parse(dgvDanhSach.Rows[0].Cells["Nam"].Value.ToString()) && item.Ky == int.Parse(dgvDanhSach.Rows[0].Cells["Ky"].Value.ToString()) && item.Dot == int.Parse(dgvDanhSach.Rows[0].Cells["Dot"].Value.ToString()) && item.MaDon == null) == dgvDanhSach.Rows.Count)
                        {
                            MessageBox.Show("Chưa có Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_db.DieuChinhHangLoats.Any(item => item.Nam == int.Parse(dgvDanhSach.Rows[0].Cells["Nam"].Value.ToString()) && item.Ky == int.Parse(dgvDanhSach.Rows[0].Cells["Ky"].Value.ToString()) && item.Dot == int.Parse(dgvDanhSach.Rows[0].Cells["Dot"].Value.ToString()) && item.DaXuLy == true) == true)
                        {
                            MessageBox.Show("Đã Điều Chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
                        {
                            if (dgvDanhSach.Rows[i].Cells["MaDon"].Value.ToString() != "")
                            {
                                DonTu_ChiTiet dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(dgvDanhSach.Rows[i].Cells["MaDon"].Value.ToString()), int.Parse(dgvDanhSach.Rows[i].Cells["STT"].Value.ToString()));

                                if (_cDCBD.checkExist(dontu_ChiTiet.MaDon.Value) == false)
                                {
                                    DCBD dcbd = new DCBD();
                                    dcbd.MaDonMoi = dontu_ChiTiet.MaDon.Value;
                                    _cDCBD.Them(dcbd);
                                }
                                if (radDCBD.Checked)
                                {
                                    //kiểm tra có lập điều chỉnh biến động
                                    if (_cDCBD.checkExist_BienDong(dontu_ChiTiet.DanhBo, DateTime.Now.Date) == false)
                                        if (_cDCBD.checkExist_BienDong(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.DanhBo) == false)
                                        {
                                            DCBD_ChiTietBienDong ctdcbd = new DCBD_ChiTietBienDong();
                                            ctdcbd.MaDCBD = _cDCBD.get(dontu_ChiTiet.MaDon.Value).MaDCBD;
                                            ctdcbd.STT = dontu_ChiTiet.STT.Value;
                                            ctdcbd.DanhBo = dontu_ChiTiet.DanhBo;
                                            ctdcbd.HopDong = dontu_ChiTiet.HopDong;
                                            ctdcbd.HoTen = dontu_ChiTiet.HoTen;
                                            ctdcbd.DiaChi = dontu_ChiTiet.DiaChi;
                                            ctdcbd.MaQuanPhuong = dontu_ChiTiet.Quan + " " + dontu_ChiTiet.Phuong;
                                            ctdcbd.Ky = dontu_ChiTiet.Ky.ToString();
                                            ctdcbd.Nam = dontu_ChiTiet.Nam.ToString();
                                            ctdcbd.Phuong = dontu_ChiTiet.Phuong;
                                            ctdcbd.Quan = dontu_ChiTiet.Quan;
                                            ctdcbd.MSThue = dontu_ChiTiet.MST;
                                            ctdcbd.GiaBieu = dontu_ChiTiet.GiaBieu;
                                            ctdcbd.DinhMuc = dontu_ChiTiet.DinhMuc;
                                            ctdcbd.DinhMucHN = dontu_ChiTiet.DinhMucHN;
                                            HOADON hd = _cThuTien.Get(dontu_ChiTiet.DanhBo, dontu_ChiTiet.Ky.Value, dontu_ChiTiet.Nam.Value);
                                            if (hd != null)
                                            {
                                                if (hd.TILESH != null)
                                                    ctdcbd.SH = hd.TILESH.Value.ToString();
                                                else
                                                    ctdcbd.SH = "";
                                                if (hd.TILESX != null)
                                                    ctdcbd.SX = hd.TILESX.Value.ToString();
                                                else
                                                    ctdcbd.SX = "";
                                                if (hd.TILEDV != null)
                                                    ctdcbd.DV = hd.TILEDV.Value.ToString();
                                                else
                                                    ctdcbd.DV = "";
                                                if (hd.TILEHCSN != null)
                                                    ctdcbd.HCSN = hd.TILEHCSN.Value.ToString();
                                                else
                                                    ctdcbd.HCSN = "";
                                            }
                                            ctdcbd.Dot = dontu_ChiTiet.Dot.ToString();
                                            ctdcbd.HieuLucKy = "12/2023";

                                            ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                                            string ThongTin = "";
                                            ///Họ Tên
                                            //if (txtHoTen_BD.Text.Trim() != "")
                                            //{
                                            //    if (string.IsNullOrEmpty(ThongTin) == true)
                                            //        ThongTin += "Tên";
                                            //    else
                                            //        ThongTin += ". Tên";
                                            //    ctdcbd.HoTen_BD = txtHoTen_BD.Text.Trim();
                                            //}
                                            /////Địa Chỉ
                                            //if (txtDiaChi_BD.Text.Trim() != "")
                                            //{
                                            //    if (string.IsNullOrEmpty(ThongTin) == true)
                                            //        ThongTin += "Địa Chỉ";
                                            //    else
                                            //        ThongTin += ". Địa Chỉ";
                                            //    ctdcbd.DiaChi_BD = txtDiaChi_BD.Text.Trim();
                                            //}
                                            //if (chkXoaDiaChiLienHe.Checked)
                                            //{
                                            //    //ThongTin += "Địa Chỉ. ";
                                            //    ctdcbd.XoaDiaChiLienHe = true;
                                            //}
                                            /////Mã Số Thuế
                                            //if (txtMSThue_BD.Text.Trim() != "")
                                            //{
                                            //    if (string.IsNullOrEmpty(ThongTin) == true)
                                            //        ThongTin += "MST";
                                            //    else
                                            //        ThongTin += ". MST";
                                            //    ctdcbd.MSThue_BD = txtMSThue_BD.Text.Trim();
                                            //}
                                            //if (chkCatMSThue.Checked)
                                            //{
                                            //    if (string.IsNullOrEmpty(ThongTin) == true)
                                            //        ThongTin += "Cắt MST";
                                            //    else
                                            //        ThongTin += ". Cắt MST";
                                            //    ctdcbd.CatMSThue = true;
                                            //}
                                            /////Giá Biểu
                                            //if (txtGiaBieu_BD.Text.Trim() != "")
                                            //{
                                            //    if (string.IsNullOrEmpty(ThongTin) == true)
                                            //        ThongTin += "Giá Biểu";
                                            //    else
                                            //        ThongTin += ". Giá Biểu";
                                            //    ctdcbd.GiaBieu_BD = int.Parse(txtGiaBieu_BD.Text.Trim());
                                            //}
                                            /////Định Mức
                                            //if (txtDinhMuc_BD.Text.Trim() != "" && txtDinhMuc.Text.Trim() != txtDinhMuc_BD.Text.Trim())
                                            {
                                                if (string.IsNullOrEmpty(ThongTin) == true)
                                                    ThongTin += "Định Mức";
                                                else
                                                    ThongTin += ". Định Mức";
                                                int TieuThu = int.Parse(_cDCBD.ExecuteQuery_ReturnOneValue("select TieuThu from  KTKS_DonKH.dbo.DieuChinhHangLoat where DanhBo='" + dontu_ChiTiet.DanhBo + "' and Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and Dot=" + txtDot.Text.Trim()).ToString());
                                                if (TieuThu == 0)
                                                    ctdcbd.DinhMuc_BD = 0;
                                                else
                                                {
                                                    while (TieuThu % 4 != 0)
                                                    {
                                                        TieuThu++;
                                                    }
                                                    ctdcbd.DinhMuc_BD = TieuThu;
                                                }
                                                if (hd.DinhMucHN != null)
                                                {
                                                    if (string.IsNullOrEmpty(ThongTin) == true)
                                                        ThongTin += "Định Mức Nghèo";
                                                    else
                                                        ThongTin += ". Định Mức Nghèo";
                                                    ctdcbd.DinhMucHN_BD = 0;
                                                }
                                            }

                                            //if (txtSH_BD.Text.Trim() != "" || txtSX_BD.Text.Trim() != "" || txtDV_BD.Text.Trim() != "" || txtHCSN_BD.Text.Trim() != "")
                                            //{
                                            //    if (string.IsNullOrEmpty(ThongTin) == true)
                                            //        ThongTin += "Tỷ Lệ";
                                            //    else
                                            //        ThongTin += ". Tỷ Lệ";
                                            //}
                                            //if (chkTinhPhiBVMT.Checked)
                                            //{
                                            //    if (string.IsNullOrEmpty(ThongTin) == true)
                                            //        ThongTin += "Tính Phí BVMT";
                                            //    else
                                            //        ThongTin += ". Tính Phí BVMT";
                                            //    ctdcbd.TinhPhiBVMT = true;
                                            //}
                                            //if (chkKhongTinhPhiBVMT.Checked)
                                            //{
                                            //    if (string.IsNullOrEmpty(ThongTin) == true)
                                            //        ThongTin += "Không Tính Phí BVMT";
                                            //    else
                                            //        ThongTin += ". Không Tính Phí BVMT";
                                            //    ctdcbd.KhongTinhPhiBVMT = true;
                                            //}
                                            /////SH
                                            //if (txtSH_BD.Text.Trim() != "")
                                            //    ctdcbd.SH_BD = txtSH_BD.Text.Trim();
                                            /////SX
                                            //if (txtSX_BD.Text.Trim() != "")
                                            //    ctdcbd.SX_BD = txtSX_BD.Text.Trim();
                                            /////DV
                                            //if (txtDV_BD.Text.Trim() != "")
                                            //    ctdcbd.DV_BD = txtDV_BD.Text.Trim();
                                            /////HCSN
                                            //if (txtHCSN_BD.Text.Trim() != "")
                                            //    ctdcbd.HCSN_BD = txtHCSN_BD.Text.Trim();

                                            ctdcbd.ThongTin = ThongTin;
                                            ctdcbd.PhieuDuocKy = true;
                                            _cDCBD.ThemDCBD(ctdcbd);
                                            _cDCBD.ExecuteNonQuery("update DieuChinhHangLoat set DaXuLy=1 where DCBD=1 and DanhBo='" + dontu_ChiTiet.DanhBo + "' and Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and Dot=" + txtDot.Text.Trim());
                                        }
                                }
                                else
                                    if (radDCHD.Checked)
                                    {
                                        //kiểm tra có lập điều chỉnh hóa đơn
                                        if (_cDCBD.checkExist_HoaDon(dontu_ChiTiet.DanhBo, int.Parse(dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString()), int.Parse(dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString())) == false)
                                            if (_cDCBD.checkExist_HoaDon(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.DanhBo, int.Parse(dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString()).ToString("00") + "/" + int.Parse(dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString())) == false)
                                            {
                                                HOADON hd = _cThuTien.Get(dontu_ChiTiet.DanhBo, int.Parse(dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString()), int.Parse(dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString()));
                                                if (hd != null && hd.MaNV_DangNgan == null)
                                                {
                                                    DCBD_ChiTietHoaDon ctdchd = new DCBD_ChiTietHoaDon();
                                                    ctdchd.MaDCBD = _cDCBD.get(dontu_ChiTiet.MaDon.Value).MaDCBD;
                                                    ctdchd.STT = dontu_ChiTiet.STT.Value;

                                                    ctdchd.DanhBo = dontu_ChiTiet.DanhBo;
                                                    ctdchd.MLT = dontu_ChiTiet.MLT;
                                                    ctdchd.HoTen = dontu_ChiTiet.HoTen;
                                                    ctdchd.DiaChi = dontu_ChiTiet.DiaChi;

                                                    ctdchd.NgayKy = DateTime.Now;

                                                    ctdchd.KyHD = int.Parse(dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString()).ToString("00") + "/" + int.Parse(dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString());

                                                    DocSo ds = _cDocSo.get(dontu_ChiTiet.DanhBo, int.Parse(dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString()), int.Parse(dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString()));
                                                    if (hd != null)
                                                        ctdchd.Dot = hd.DOT;
                                                    else
                                                        if (ds != null)
                                                            ctdchd.Dot = int.Parse(ds.Dot);
                                                    ctdchd.Ky = dontu_ChiTiet.Ky.Value;
                                                    ctdchd.Nam = dontu_ChiTiet.Nam.Value;
                                                    if (hd != null)
                                                    {
                                                        ctdchd.MST = hd.MST;
                                                        ctdchd.SoHoaDon = hd.SOHOADON;
                                                        ctdchd.Phuong = hd.Phuong;
                                                        ctdchd.Quan = hd.Quan;
                                                    }
                                                    ctdchd.SoHD = hd.SOPHATHANH.ToString();
                                                    ///
                                                    ctdchd.GiaBieu = hd.GB;
                                                    if (hd.DinhMucHN == null)
                                                        ctdchd.DinhMucHN = 0;
                                                    else
                                                        ctdchd.DinhMucHN = hd.DinhMucHN;
                                                    ctdchd.DinhMuc = hd.DM;
                                                    ctdchd.TieuThu = hd.TIEUTHU;
                                                    ///
                                                    ctdchd.GiaBieu_BD = hd.GB;
                                                    if (hd.DinhMucHN == null)
                                                        ctdchd.DinhMucHN_BD = 0;
                                                    else
                                                        ctdchd.DinhMucHN_BD = hd.DinhMucHN;
                                                    ctdchd.DinhMuc_BD = hd.DM;
                                                    ctdchd.TieuThu_BD = 0;
                                                    ///
                                                    if ((hd.NAM < 2021) || (hd.NAM == 2021 && hd.KY <= 6))
                                                        ctdchd.BaoCaoThue = true;
                                                    ///
                                                    string ChiTietNamCuTruoc = "", ChiTietNamMoiTruoc = "", ChiTietNamCuSau = "", ChiTietNamMoiSau = "", ChiTietPhiBVMTNamCuTruoc = "", ChiTietPhiBVMTNamMoiTruoc = "", ChiTietPhiBVMTNamCuSau = "", ChiTietPhiBVMTNamMoiSau = "";
                                                    int Ky = 0, Nam = 0, TyleSH = 0, TyLeSX = 0, TyLeDV = 0, TyLeHCSN = 0, TienNuocNamCuTruoc = 0, TienNuocNamMoiTruoc = 0, TienNuocNamCuSau = 0, TienNuocNamMoiSau = 0, TieuThu_DieuChinhGia = 0
                                                        , PhiBVMTNamCuTruoc = 0, PhiBVMTNamMoiTruoc = 0, PhiBVMTNamCuSau = 0, PhiBVMTNamMoiSau = 0
                                                        , TienNuocTruoc = 0, ThueGTGTTruoc = 0, TDVTNTruoc = 0, ThueTDVTNTruoc = 0, TienNuocSau = 0, ThueGTGTSau = 0, TDVTNSau = 0, ThueTDVTNSau = 0, ThueTDVTN_VAT = 0;
                                                    DateTime TuNgay = new DateTime(), DenNgay = new DateTime();

                                                    if (hd != null)
                                                    {
                                                        Ky = hd.KY;
                                                        Nam = hd.NAM;
                                                        if (hd.TUNGAY != null)
                                                            TuNgay = hd.TUNGAY.Value;
                                                        else
                                                        {
                                                            TuNgay = ds.TuNgay.Value;
                                                        }
                                                        DenNgay = hd.DENNGAY.Value;
                                                        if (hd.TILESH != null && hd.TILESH.Value != 0)
                                                            TyleSH = hd.TILESH.Value;
                                                        if (hd.TILESX != null && hd.TILESX.Value != 0)
                                                            TyLeSX = hd.TILESX.Value;
                                                        if (hd.TILEDV != null && hd.TILEDV.Value != 0)
                                                            TyLeDV = hd.TILEDV.Value;
                                                        if (hd.TILEHCSN != null && hd.TILEHCSN.Value != 0)
                                                            TyLeHCSN = hd.TILEHCSN.Value;
                                                    }
                                                    else
                                                        if (ds != null)
                                                        {
                                                            Ky = int.Parse(ds.Ky);
                                                            Nam = ds.Nam.Value;
                                                            TuNgay = ds.TuNgay.Value;
                                                            DenNgay = ds.DenNgay.Value;
                                                            HOADON hoadon = new HOADON();
                                                            if (int.Parse(ds.Ky) == 1)
                                                                hoadon = _cThuTien.Get(ds.DanhBa, 12, ds.Nam.Value - 1);
                                                            else
                                                                hoadon = _cThuTien.Get(ds.DanhBa, int.Parse(ds.Ky) - 1, ds.Nam.Value);
                                                            if (hoadon.TILESH != null && hoadon.TILESH.Value != 0)
                                                                TyleSH = hoadon.TILESH.Value;
                                                            if (hoadon.TILESX != null && hoadon.TILESX.Value != 0)
                                                                TyLeSX = hoadon.TILESX.Value;
                                                            if (hoadon.TILEDV != null && hoadon.TILEDV.Value != 0)
                                                                TyLeDV = hoadon.TILEDV.Value;
                                                            if (hoadon.TILEHCSN != null && hoadon.TILEHCSN.Value != 0)
                                                                TyLeHCSN = hoadon.TILEHCSN.Value;
                                                        }

                                                    _cGiaNuoc.TinhTienNuoc(false, false, false, 0, hd.DANHBA, Ky, Nam, TuNgay, DenNgay, ctdchd.GiaBieu.Value, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, ctdchd.DinhMuc.Value, ctdchd.DinhMucHN.Value, ctdchd.TieuThu.Value, out TienNuocNamCuTruoc, out ChiTietNamCuTruoc, out TienNuocNamMoiTruoc, out ChiTietNamMoiTruoc, out TieuThu_DieuChinhGia, out PhiBVMTNamCuTruoc, out ChiTietPhiBVMTNamCuTruoc, out PhiBVMTNamMoiTruoc, out ChiTietPhiBVMTNamMoiTruoc, out TienNuocTruoc, out ThueGTGTTruoc, out TDVTNTruoc, out ThueTDVTNTruoc, out ThueTDVTN_VAT);

                                                    _cGiaNuoc.TinhTienNuoc(false, false, false, 0, hd.DANHBA, Ky, Nam, TuNgay, DenNgay, ctdchd.GiaBieu_BD.Value, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, ctdchd.DinhMuc_BD.Value, ctdchd.DinhMucHN_BD.Value, ctdchd.TieuThu_BD.Value, out TienNuocNamCuSau, out ChiTietNamCuSau, out TienNuocNamMoiSau, out ChiTietNamMoiSau, out TieuThu_DieuChinhGia, out PhiBVMTNamCuSau, out ChiTietPhiBVMTNamCuSau, out PhiBVMTNamMoiSau, out ChiTietPhiBVMTNamMoiSau, out TienNuocSau, out ThueGTGTSau, out TDVTNSau, out ThueTDVTNSau, out ThueTDVTN_VAT);

                                                    ctdchd.ChiTietCu = ChiTietNamCuTruoc + "\r\n" + ChiTietNamMoiTruoc;
                                                    ctdchd.ChiTietMoi = ChiTietNamCuSau + "\r\n" + ChiTietNamMoiSau;
                                                    ctdchd.HoTen_BD = "";
                                                    ctdchd.DiaChi_BD = "";
                                                    ctdchd.MST_BD = "";

                                                    ///Tiền Nước
                                                    if (hd.GIABAN.Value != 0)
                                                        ctdchd.TienNuoc_Start = (int)hd.GIABAN.Value;
                                                    else
                                                        ctdchd.TienNuoc_Start = 0;

                                                    if (TienNuocSau - (int)hd.GIABAN.Value != 0)
                                                        ctdchd.TienNuoc_BD = TienNuocSau - (int)hd.GIABAN.Value;
                                                    else
                                                        ctdchd.TienNuoc_BD = 0;

                                                    if (TienNuocSau != 0)
                                                        ctdchd.TienNuoc_End = TienNuocSau;
                                                    else
                                                        ctdchd.TienNuoc_End = 0;

                                                    ///Thuế GTGT
                                                    if ((int)hd.GIABAN.Value != 0)
                                                        ctdchd.ThueGTGT_Start = (int)hd.THUE.Value;
                                                    else
                                                        ctdchd.ThueGTGT_Start = 0;

                                                    if (TienNuocSau - (int)hd.GIABAN.Value != 0)
                                                        ctdchd.ThueGTGT_BD = (ThueGTGTSau - (int)hd.THUE.Value);
                                                    else
                                                        ctdchd.ThueGTGT_BD = 0;

                                                    if (TienNuocSau != 0)
                                                        ctdchd.ThueGTGT_End = (int)ThueGTGTSau;
                                                    else
                                                        ctdchd.ThueGTGT_End = 0;

                                                    ///Phí BVMT
                                                    if ((int)hd.GIABAN.Value != 0)
                                                        ctdchd.PhiBVMT_Start = (int)hd.PHI.Value;
                                                    else
                                                        ctdchd.PhiBVMT_Start = 0;

                                                    if (TienNuocSau - (int)hd.GIABAN.Value != 0)
                                                        //ctdchd.PhiBVMT_BD = (int)(Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero) - (int)hd.PHI.Value);
                                                        ctdchd.PhiBVMT_BD = TDVTNSau - (int)hd.PHI.Value;
                                                    else
                                                        ctdchd.PhiBVMT_BD = 0;

                                                    if (TienNuocSau != 0)
                                                        //ctdchd.PhiBVMT_End = (int)Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero);
                                                        ctdchd.PhiBVMT_End = TDVTNSau;
                                                    else
                                                        ctdchd.PhiBVMT_End = 0;

                                                    ///Phí BVMT Thuế
                                                    if ((int)hd.GIABAN.Value != 0)
                                                        ctdchd.PhiBVMT_Thue_Start = (int)hd.ThueGTGT_TDVTN.Value;
                                                    else
                                                        ctdchd.PhiBVMT_Thue_Start = 0;

                                                    if (TienNuocSau - (int)hd.GIABAN.Value != 0)
                                                        //ctdchd.PhiBVMT_BD = (int)(Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero) - (int)hd.PHI.Value);
                                                        ctdchd.PhiBVMT_Thue_BD = ThueTDVTNSau - (int)hd.ThueGTGT_TDVTN.Value;
                                                    else
                                                        ctdchd.PhiBVMT_Thue_BD = 0;

                                                    if (TienNuocSau != 0)
                                                        //ctdchd.PhiBVMT_End = (int)Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero);
                                                        ctdchd.PhiBVMT_Thue_End = ThueTDVTNSau;
                                                    else
                                                        ctdchd.PhiBVMT_Thue_End = 0;

                                                    ///Tổng Cộng
                                                    if ((int)hd.GIABAN.Value != 0)
                                                        ctdchd.TongCong_Start = (int)hd.TONGCONG.Value;
                                                    else
                                                        ctdchd.TongCong_Start = 0;

                                                    if (TienNuocSau - (int)hd.GIABAN.Value != 0)
                                                        //ctdchd.TongCong_BD = ((TienNuocSau + (int)Math.Round((double)TienNuocSau * 5 / 100, 0, MidpointRounding.AwayFromZero) + (int)Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero)) - (int)hd.TONGCONG.Value);
                                                        ctdchd.TongCong_BD = ((TienNuocSau + ThueGTGTSau + TDVTNSau) - (int)hd.TONGCONG.Value);
                                                    else
                                                        ctdchd.TongCong_BD = 0;

                                                    if (TienNuocSau != 0)
                                                        //ctdchd.TongCong_End = (TienNuocSau + (int)Math.Round((double)TienNuocSau * 5 / 100, 0, MidpointRounding.AwayFromZero) + (int)Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero));
                                                        ctdchd.TongCong_End = (TienNuocSau + ThueGTGTSau + TDVTNSau);
                                                    else
                                                        ctdchd.TongCong_End = 0;

                                                    ctdchd.ThongTin = "Tiêu Thụ";

                                                    if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start == 0)
                                                        ctdchd.TangGiam = "";
                                                    else
                                                        if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start > 0)
                                                            ctdchd.TangGiam = "Tăng";
                                                        else
                                                            ctdchd.TangGiam = "Giảm";

                                                    ctdchd.PhieuDuocKy = true;
                                                    _cDCBD.ThemDCHD(ctdchd);
                                                    _cDCBD.ExecuteNonQuery("update DieuChinhHangLoat set DaXuLy=1 where DCHD=1 and DanhBo='" + dontu_ChiTiet.DanhBo + "' and Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and Dot=" + txtDot.Text.Trim());
                                                }
                                            }
                                    }
                            }
                        }
                        _db = new dbKinhDoanhDataContext();
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnTVCapNhatQLDHN_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.Admin == true && CTaiKhoan.CheckQuyen("mnuDCHD", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
                        {
                            if (bool.Parse(dgvDanhSach.Rows[i].Cells["DaXuLy"].Value.ToString()) == true && bool.Parse(dgvDanhSach.Rows[i].Cells["UpdatedDHN"].Value.ToString()) == false)
                            {
                                DieuChinhHangLoat en = _db.DieuChinhHangLoats.SingleOrDefault(item => item.DanhBo == dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString() && item.Nam == Convert.ToInt32(dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString()) && item.Ky == Convert.ToInt32(dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString()));
                                if (en != null)
                                    if (en.Code == "5K")
                                    {
                                        string Nam = dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString();
                                        string Ky = int.Parse(dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString()).ToString("00");
                                        string NamSau = "";
                                        string KySau = "";
                                        if (Ky == "12")
                                        {
                                            NamSau = (int.Parse(dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString()) + 1).ToString();
                                            KySau = "01";
                                        }
                                        else
                                        {
                                            NamSau = Nam;
                                            KySau = (int.Parse(dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString()) + 1).ToString("00");
                                        }
                                        string sql = " update DocSo set CodeMoi='K' where DocSoID=" + Nam + Ky + dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString()
                                              + " update DocSo set CodeCu='K' where DocSoID=" + NamSau + KySau + dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString();
                                        if (_cDocSo.ExecuteNonQuery(sql))
                                        {
                                            string sql2 = "update DieuChinhHangLoat set UpdatedDHN=1,UpdatedDHN_Ngay=getdate() where DanhBo=" + dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString() + " and Nam=" + Nam + " and Ky=" + Ky;
                                            _cDCBD.ExecuteNonQuery(sql2);
                                        }
                                    }
                                    else
                                        if (en.Code == "44" && en.TieuThu == 1)
                                        {
                                            string Nam = dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString();
                                            string Ky = dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString();
                                            string NamSau = "";
                                            string KySau = "";
                                            if (Ky == "12")
                                            {
                                                NamSau = (int.Parse(dgvDanhSach.Rows[i].Cells["Nam"].Value.ToString()) + 1).ToString();
                                                KySau = "01";
                                            }
                                            else
                                            {
                                                NamSau = Nam;
                                                KySau = (int.Parse(dgvDanhSach.Rows[i].Cells["Ky"].Value.ToString()) + 1).ToString("00");
                                            }
                                            string sql = " update DocSo set CSMoi=" + en.CSC + " where DocSoID=" + Nam + Ky + dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString()
                                                  + " update DocSo set CSCu=" + en.CSC + " where DocSoID=" + NamSau + KySau + dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString();
                                            if (_cDocSo.ExecuteNonQuery(sql))
                                            {
                                                string sql2 = "update DieuChinhHangLoat set UpdatedDHN=1,UpdatedDHN_Ngay=getdate() where DanhBo=" + dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString() + " and Nam=" + Nam + " and Ky=" + Ky;
                                                _cDCBD.ExecuteNonQuery(sql2);
                                            }
                                        }
                            }

                        }
                        _cDCBD.Refresh();
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
