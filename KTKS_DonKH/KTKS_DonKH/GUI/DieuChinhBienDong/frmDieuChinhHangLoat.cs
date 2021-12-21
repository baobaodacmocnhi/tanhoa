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
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                                        en.STT2 = int.Parse(item[0].ToString().Trim());
                                        en.DanhBo = DanhBo;
                                        en.CSC = item[2].ToString().Trim();
                                        en.CSM = item[3].ToString().Trim();
                                        en.Code = item[5].ToString().Trim();
                                        en.TieuThu = int.Parse(item[4].ToString().Trim());
                                        en.Nam = int.Parse(txtNam.Text.Trim());
                                        en.Ky = int.Parse(txtKy.Text.Trim());
                                        en.Dot = int.Parse(txtDot.Text.Trim());
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
            dgvDanhSach.DataSource = _cDCBD.LINQToDataTable(_db.DieuChinhHangLoats.Where(item => item.Nam == int.Parse(txtNam.Text.Trim()) && item.Ky == int.Parse(txtKy.Text.Trim()) && item.Dot == int.Parse(txtDot.Text.Trim())).OrderBy(item => item.STT2).ToList());
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                            HOADON hd = _cThuTien.Get(dgvDanhSach.Rows[i].Cells["DanhBo"].Value.ToString(), int.Parse(dgvDanhSach.Rows[0].Cells["Ky"].Value.ToString()), int.Parse(dgvDanhSach.Rows[0].Cells["Nam"].Value.ToString()));
                            if (hd != null && hd.MaNV_DangNgan == null)
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
                                //entityCT.TinhTrang = "Tồn";

                                entity.DonTu_ChiTiets.Add(entityCT);
                            }
                        }
                        entity.SoCongVan_PhongBanDoi = "Đ. QLĐHN";
                        entity.TongDB = entity.DonTu_ChiTiets.Count;
                        //entity.ID_NhomDon_PKH = "7";
                        //entity.Name_NhomDon_PKH = "Chỉ số nước";
                        entity.VanPhong = true;
                        entity.MaPhong = 1;
                        if (_cDonTu.Them(entity))
                        {
                            foreach (DonTu_ChiTiet itemDonChiTiet in entity.DonTu_ChiTiets)
                            {
                                _cDCBD.ExecuteNonQuery("update DieuChinhHangLoat set MaDon=" + itemDonChiTiet.MaDon + ",STT=" + itemDonChiTiet.STT + " where DanhBo='" + itemDonChiTiet.DanhBo + "' and Nam=" + itemDonChiTiet.Nam + " and Ky=" + itemDonChiTiet.Ky + " and Dot=" + itemDonChiTiet.Dot);
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
                        if (_db.DieuChinhHangLoats.Any(item => item.Nam == int.Parse(dgvDanhSach.Rows[0].Cells["Nam"].Value.ToString()) && item.Ky == int.Parse(dgvDanhSach.Rows[0].Cells["Ky"].Value.ToString()) && item.Dot == int.Parse(dgvDanhSach.Rows[0].Cells["Dot"].Value.ToString()) && item.DCHD == true) == true)
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
                                            string ChiTietCuA = "", ChiTietCuB = "", ChiTietMoiA = "", ChiTietMoiB = "", ChiTietPhiBVMTCuA = "", ChiTietPhiBVMTCuB = "", ChiTietPhiBVMTMoiA = "", ChiTietPhiBVMTMoiB = "";
                                            int Ky = 0, Nam = 0, TyleSH = 0, TyLeSX = 0, TyLeDV = 0, TyLeHCSN = 0, TongTienCuA = 0, TongTienCuB = 0, TongTienMoiA = 0, TongTienMoiB = 0, TieuThu_DieuChinhGia = 0, TongTienPhiBVMTCuA = 0, TongTienPhiBVMTCuB = 0, TongTienPhiBVMTMoiA = 0, TongTienPhiBVMTMoiB = 0;
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

                                            _cGiaNuoc.TinhTienNuoc(false, false, false, 0, hd.DANHBA, Ky, Nam, TuNgay, DenNgay, ctdchd.GiaBieu.Value, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, ctdchd.DinhMuc.Value, ctdchd.DinhMucHN.Value, ctdchd.TieuThu.Value, out TongTienCuA, out ChiTietCuA, out TongTienCuB, out ChiTietCuB, out TieuThu_DieuChinhGia, out TongTienPhiBVMTCuA, out ChiTietPhiBVMTCuA, out TongTienPhiBVMTCuB, out ChiTietPhiBVMTCuB);

                                            _cGiaNuoc.TinhTienNuoc(false, false, false, 0, hd.DANHBA, Ky, Nam, TuNgay, DenNgay, ctdchd.GiaBieu_BD.Value, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, ctdchd.DinhMuc_BD.Value, ctdchd.DinhMucHN_BD.Value, ctdchd.TieuThu_BD.Value, out TongTienMoiA, out ChiTietMoiA, out TongTienMoiB, out ChiTietMoiB, out TieuThu_DieuChinhGia, out TongTienPhiBVMTMoiA, out ChiTietPhiBVMTMoiA, out TongTienPhiBVMTMoiB, out ChiTietPhiBVMTMoiB);

                                            ctdchd.ChiTietCu = ChiTietCuA + "\r\n" + ChiTietCuB;
                                            ctdchd.ChiTietMoi = ChiTietMoiA + "\r\n" + ChiTietMoiB;
                                            ctdchd.HoTen_BD = "";
                                            ctdchd.DiaChi_BD = "";
                                            ctdchd.MST_BD = "";

                                            ///Tiền Nước
                                            if (hd.GIABAN.Value != 0)
                                                ctdchd.TienNuoc_Start = (int)hd.GIABAN.Value;
                                            else
                                                ctdchd.TienNuoc_Start = 0;

                                            if ((TongTienMoiA + TongTienMoiB) - (int)hd.GIABAN.Value != 0)
                                                ctdchd.TienNuoc_BD = (TongTienMoiA + TongTienMoiB) - (int)hd.GIABAN.Value;
                                            else
                                                ctdchd.TienNuoc_BD = 0;

                                            if ((TongTienMoiA + TongTienMoiB) != 0)
                                                ctdchd.TienNuoc_End = (TongTienMoiA + TongTienMoiB);
                                            else
                                                ctdchd.TienNuoc_End = 0;

                                            ///Thuế GTGT
                                            if ((int)hd.GIABAN.Value != 0)
                                                ctdchd.ThueGTGT_Start = (int)hd.THUE.Value;
                                            else
                                                ctdchd.ThueGTGT_Start = 0;

                                            if ((TongTienMoiA + TongTienMoiB) - (int)hd.GIABAN.Value != 0)
                                                ctdchd.ThueGTGT_BD = (int)(Math.Round((double)(TongTienMoiA + TongTienMoiB) * 5 / 100, 0, MidpointRounding.AwayFromZero) - (int)hd.THUE.Value);
                                            else
                                                ctdchd.ThueGTGT_BD = 0;

                                            if ((TongTienMoiA + TongTienMoiB) != 0)
                                                ctdchd.ThueGTGT_End = (int)Math.Round((double)(TongTienMoiA + TongTienMoiB) * 5 / 100, 0, MidpointRounding.AwayFromZero);
                                            else
                                                ctdchd.ThueGTGT_End = 0;

                                            ///Phí BVMT
                                            if ((int)hd.GIABAN.Value != 0)
                                                ctdchd.PhiBVMT_Start = (int)hd.PHI.Value;
                                            else
                                                ctdchd.PhiBVMT_Start = 0;

                                            if ((TongTienMoiA + TongTienMoiB) - (int)hd.GIABAN.Value != 0)
                                                //ctdchd.PhiBVMT_BD = (int)(Math.Round((double)(TongTienMoiA + TongTienMoiB) * 10 / 100, 0, MidpointRounding.AwayFromZero) - (int)hd.PHI.Value);
                                                ctdchd.PhiBVMT_BD = (TongTienPhiBVMTMoiA + TongTienPhiBVMTMoiB) - (int)hd.PHI.Value;
                                            else
                                                ctdchd.PhiBVMT_BD = 0;

                                            if ((TongTienMoiA + TongTienMoiB) != 0)
                                                //ctdchd.PhiBVMT_End = (int)Math.Round((double)(TongTienMoiA + TongTienMoiB) * 10 / 100, 0, MidpointRounding.AwayFromZero);
                                                ctdchd.PhiBVMT_End = (TongTienPhiBVMTMoiA + TongTienPhiBVMTMoiB);
                                            else
                                                ctdchd.PhiBVMT_End = 0;

                                            ///Tổng Cộng
                                            if ((int)hd.GIABAN.Value != 0)
                                                ctdchd.TongCong_Start = (int)hd.TONGCONG.Value;
                                            else
                                                ctdchd.TongCong_Start = 0;

                                            if ((TongTienMoiA + TongTienMoiB) - (int)hd.GIABAN.Value != 0)
                                                //ctdchd.TongCong_BD = (((TongTienMoiA + TongTienMoiB) + (int)Math.Round((double)(TongTienMoiA + TongTienMoiB) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (int)Math.Round((double)(TongTienMoiA + TongTienMoiB) * 10 / 100, 0, MidpointRounding.AwayFromZero)) - (int)hd.TONGCONG.Value);
                                                ctdchd.TongCong_BD = (((TongTienMoiA + TongTienMoiB) + (int)Math.Round((double)(TongTienMoiA + TongTienMoiB) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (TongTienPhiBVMTMoiA + TongTienPhiBVMTMoiB)) - (int)hd.TONGCONG.Value);
                                            else
                                                ctdchd.TongCong_BD = 0;

                                            if ((TongTienMoiA + TongTienMoiB) != 0)
                                                //ctdchd.TongCong_End = ((TongTienMoiA + TongTienMoiB) + (int)Math.Round((double)(TongTienMoiA + TongTienMoiB) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (int)Math.Round((double)(TongTienMoiA + TongTienMoiB) * 10 / 100, 0, MidpointRounding.AwayFromZero));
                                                ctdchd.TongCong_End = ((TongTienMoiA + TongTienMoiB) + (int)Math.Round((double)(TongTienMoiA + TongTienMoiB) * 5 / 100, 0, MidpointRounding.AwayFromZero) + (TongTienPhiBVMTMoiA + TongTienPhiBVMTMoiB));
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

                                            ///Ký Tên
                                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                                ctdchd.ChucVu = "GIÁM ĐỐC";
                                            else
                                                ctdchd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                            ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                            ctdchd.PhieuDuocKy = true;
                                            _cDCBD.ThemDCHD(ctdchd);
                                            _cDCBD.ExecuteNonQuery("update DieuChinhHangLoat set DCHD=1 where DanhBo='" + dontu_ChiTiet.DanhBo + "' and Nam=" + dontu_ChiTiet.Nam + " and Ky=" + dontu_ChiTiet.Ky + " and Dot=" + dontu_ChiTiet.Dot);
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
                            if (bool.Parse(dgvDanhSach.Rows[i].Cells["DCHD"].Value.ToString()) == true && bool.Parse(dgvDanhSach.Rows[i].Cells["UpdatedDHN"].Value.ToString()) == false)
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
