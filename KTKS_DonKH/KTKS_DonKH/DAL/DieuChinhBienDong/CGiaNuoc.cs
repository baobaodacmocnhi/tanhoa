using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CGiaNuoc : CDAL
    {
        /// <summary>
        /// Giảm Tiền Nước bao nhiêu %
        /// </summary>
        private const int _GiamTienNuoc = 10;
        public int GiamTienNuoc
        {
            get { return _GiamTienNuoc; }
        }

        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        CKhuCongNghiep _cKCN = new CKhuCongNghiep();

        List<int> lst2010 = new List<int> { 4000, 7500, 10000, 6700, 7100, 12000, 0 };
        List<int> lst2011 = new List<int> { 4400, 8300, 10500, 7400, 8100, 13500, 0 };
        List<int> lst2012 = new List<int> { 4800, 9200, 11000, 8200, 9300, 15200, 0 };
        List<int> lst2013 = new List<int> { 5300, 10200, 11400, 9600, 10300, 16900, 0 };

        List<int> lst2019 = new List<int> { 5600, 10800, 12100, 10200, 10900, 17900, 5300 };
        //List<int> lst2020 = new List<int> { 6000, 11500, 12800, 10800, 11600, 19000, 5600 };
        //List<int> lst2021 = new List<int> { 6300, 12100, 13600, 11400, 12300, 20100, 6000 };
        //List<int> lst2022 = new List<int> { 6700, 12900, 14400, 12100, 13000, 21300, 6300 };

        public List<GiaNuoc> LoadDSGiaNuoc()
        {
            return db.GiaNuocs.ToList();
        }

        public List<GiaNuoc2> getDS()
        {
            Refresh();
            return db.GiaNuoc2s.ToList();
        }

        public GiaNuoc2 getGiaNuoc(DateTime TuNgay, DateTime DenNgay)
        {
            List<GiaNuoc2> lst = getDS();
            int index = -1;
            for (int i = 0; i < lst.Count; i++)
                if (TuNgay.Date < lst[i].NgayTangGia.Value.Date && lst[i].NgayTangGia.Value.Date < DenNgay.Date)
                {
                    index = i;
                }
                else
                    if (TuNgay.Date >= lst[i].NgayTangGia.Value.Date)
                    {
                        index = i;
                    }
            return lst[index];
        }

        public GiaNuoc2 getGiaNuoc(int Nam)
        {
            return db.GiaNuoc2s.SingleOrDefault(item => item.Name == Nam);
        }

        public bool Them(GiaNuoc gianuoc)
        {
            try
            {
                if (db.GiaNuocs.Count() > 0)
                    gianuoc.MaGN = db.GiaNuocs.Max(itemGN => itemGN.MaGN) + 1;
                else
                    gianuoc.MaGN = 1;
                gianuoc.CreateDate = DateTime.Now;
                gianuoc.CreateBy = CTaiKhoan.MaUser;
                db.GiaNuocs.InsertOnSubmit(gianuoc);
                db.SubmitChanges();
                MessageBox.Show("Thành công Thêm GiaNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Sua(GiaNuoc gianuoc)
        {
            try
            {
                gianuoc.ModifyDate = DateTime.Now;
                gianuoc.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                MessageBox.Show("Thành công Sửa GiaNuoc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public GiaNuoc Get(int MaGN)
        {
            return db.GiaNuocs.SingleOrDefault(itemGN => itemGN.MaGN == MaGN);
        }

        /// <summary>
        /// Công thức tính tiền nước theo giá biểu
        /// </summary>
        /// <param name="DieuChinhGia">true là điều chỉnh giá/ false là không</param>
        /// <param name="GiaDieuChinh"></param>
        /// <param name="DanhBo">Danh Bộ được dùng để lấy SH,SX,DV,HCSN</param>
        /// <param name="GiaBieu"></param>
        /// <param name="DinhMuc"></param>
        /// <param name="TieuThu"></param>
        /// <param name="ChiTiet"></param>
        /// <returns></returns>
        public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int GiaBieu, int DinhMuc, int TieuThu, out string ChiTiet, out int TieuThu_DieuChinhGia)
        {
            try
            {
                string _chiTiet = "";
                TieuThu_DieuChinhGia = 0;
                HOADON hoadon = _cThuTien.GetMoiNhat(DanhBo);
                List<GiaNuoc> lstGiaNuoc = db.GiaNuocs.ToList();
                ///Table GiaNuoc được thiết lập theo bảng giá nước
                ///1. Đến 4m3/người/tháng
                ///2. Trên 4m3 đến 6m3/người/tháng
                ///3. Trên 6m3/người/tháng
                ///4. Đơn vị sản xuất
                ///5. Cơ quan, đoàn thể HCSN
                ///6. Đơn vị kinh doanh, dịch vụ
                ///List bắt đầu từ phần tử thứ 0
                int TongTien = 0;
                switch (GiaBieu)
                {
                    ///TƯ GIA
                    case 11:
                    case 21:///SH thuần túy
                        if (TieuThu <= DinhMuc)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                }
                            else
                            {
                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                if (lstGiaNuoc[0].DonGia.Value == GiaDieuChinh)
                                    TieuThu_DieuChinhGia = TieuThu;
                                else
                                    TieuThu_DieuChinhGia = TieuThu - DinhMuc;
                            }
                        break;
                    case 12:
                    case 22:
                    case 32:
                    case 42:///SX thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    case 13:
                    case 23:
                    case 33:
                    case 43:///DV thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    case 14:
                    case 24:///SH + SX
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILESH == null && hoadon.TILESX == null) || (hoadon.TILESH == 0 && hoadon.TILESX == 0))
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[3].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                   + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                   + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        if (lstGiaNuoc[0].DonGia.Value == GiaDieuChinh)
                                            TieuThu_DieuChinhGia = TieuThu;
                                        else
                                            TieuThu_DieuChinhGia = TieuThu - DinhMuc;
                                    }
                            }
                            else
                            ///Nếu có tỉ lệ SH + SX
                            //if (hoadon.TILESH!=null && hoadon.TILESX!=null)
                            {
                                int _SH = 0, _SX = 0;
                                if (hoadon.TILESH != null)
                                    _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                _SX = TieuThu - _SH;

                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        if (lstGiaNuoc[0].DonGia.Value == GiaDieuChinh)
                                            TieuThu_DieuChinhGia = _SH;
                                        else
                                            TieuThu_DieuChinhGia = _SH - DinhMuc;
                                    }
                                TongTien += _SX * lstGiaNuoc[3].DonGia.Value;
                                _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                            }
                        break;
                    case 15:
                    case 25:///SH + DV
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILESH == null && hoadon.TILEDV == null) || (hoadon.TILESH == 0 && hoadon.TILEDV == 0))
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[5].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        if (lstGiaNuoc[0].DonGia.Value == GiaDieuChinh)
                                            TieuThu_DieuChinhGia = TieuThu;
                                        else
                                            TieuThu_DieuChinhGia = TieuThu - DinhMuc;
                                    }
                            }
                            else
                            ///Nếu có tỉ lệ SH + DV
                            //if (hoadon.TILESH!=null && hoadon.TILEDV!=null)
                            {
                                int _SH = 0, _DV = 0;
                                if (hoadon.TILESH != null)
                                    _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                _DV = TieuThu - _SH;

                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        if (lstGiaNuoc[0].DonGia.Value == GiaDieuChinh)
                                            TieuThu_DieuChinhGia = _SH;
                                        else
                                            TieuThu_DieuChinhGia = _SH - DinhMuc;
                                    }
                                TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
                                _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    case 16:
                    case 26:///SH + SX + DV
                        if (hoadon != null)
                            ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
                            if ((hoadon.TILESX != null && hoadon.TILEDV != null && hoadon.TILESH == null) || (hoadon.TILESX != 0 && hoadon.TILEDV != 0 && hoadon.TILESH == 0))
                            {
                                int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                int _DV = TieuThu - _SX;
                                TongTien = (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                            else
                            ///Nếu có đủ 3 tỉ lệ SH + SX + DV
                            //if (hoadon.TILESX!=null && hoadon.TILEDV!=null && hoadon.TILESH!=null)
                            {
                                int _SH = 0, _SX = 0, _DV = 0;
                                if (hoadon.TILESH != null)
                                    _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                if (hoadon.TILESX != null)
                                    _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                _DV = TieuThu - _SH - _SX;

                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        if (lstGiaNuoc[0].DonGia.Value == GiaDieuChinh)
                                            TieuThu_DieuChinhGia = _SH;
                                        else
                                            TieuThu_DieuChinhGia = _SH - DinhMuc;
                                    }
                                TongTien += (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                             + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    case 17:
                    case 27:///SH ĐB
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    case 18:
                    case 28:
                    case 38:///SH + HCSN
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILESH == null && hoadon.TILEHCSN == null) || (hoadon.TILESH == 0 && hoadon.TILEHCSN == 0))
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[4].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        if (lstGiaNuoc[0].DonGia.Value == GiaDieuChinh)
                                            TieuThu_DieuChinhGia = TieuThu;
                                        else
                                            TieuThu_DieuChinhGia = TieuThu - DinhMuc;
                                    }
                            }
                            else
                            ///Nếu có tỉ lệ SH + HCSN
                            //if (hoadon.TILESH!=null && hoadon.TILEHCSN!=null)
                            {
                                int _SH = 0, _HCSN = 0;
                                if (hoadon.TILESH != null)
                                    _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                _HCSN = TieuThu - _SH;

                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        if (lstGiaNuoc[0].DonGia.Value == GiaDieuChinh)
                                            TieuThu_DieuChinhGia = _SH;
                                        else
                                            TieuThu_DieuChinhGia = _SH - DinhMuc;
                                    }
                                TongTien += _HCSN * lstGiaNuoc[4].DonGia.Value;
                                _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                            }
                        break;
                    case 19:
                    case 29:
                    case 39:///SH + HCSN + SX + DV
                        if (hoadon != null)
                        //if (hoadon.TILESH!=null && hoadon.TILEHCSN!=null && hoadon.TILESX!=null && hoadon.TILEDV!=null)
                        {
                            int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                            if (hoadon.TILESH != null)
                                _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                            if (hoadon.TILEHCSN != null)
                                _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                            if (hoadon.TILESX != null)
                                _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                            _DV = TieuThu - _SH - _HCSN - _SX;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    if (lstGiaNuoc[0].DonGia.Value == GiaDieuChinh)
                                        TieuThu_DieuChinhGia = _SH;
                                    else
                                        TieuThu_DieuChinhGia = _SH - DinhMuc;
                                }
                            TongTien += (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    ///TẬP THỂ
                    //case 21:///SH thuần túy
                    //    if (TieuThu <= DinhMuc)
                    //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                    //    else
                    //        if (TieuThu - DinhMuc <= DinhMuc / 2)
                    //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                    //        else
                    //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + (DinhMuc / 2 * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2].DonGia.Value);
                    //    break;
                    //case 22:///SX thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 23:///DV thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    //case 24:///SH + SX
                    //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
                    //    if (hoadon != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (hoadon.TILESH==null && hoadon.TILESX==null)
                    //        {

                    //        }
                    //    break;
                    //case 25:///SH + DV

                    //    break;
                    //case 26:///SH + SX + DV

                    //    break;
                    //case 27:///SH ĐB
                    //    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                    //    break;
                    //case 28:///SH + HCSN

                    //    break;
                    //case 29:///SH + HCSN + SX + DV

                    //    break;
                    ///CƠ QUAN
                    case 31:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[4].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    //case 32:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 33:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    case 34:///HCSN + SX
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILEHCSN == null && hoadon.TILESX == null) || (hoadon.TILEHCSN == 0 && hoadon.TILESX == 0))
                            {
                                TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                            }
                            else
                            ///Nếu có tỉ lệ
                            //if (hoadon.TILEHCSN!=null && hoadon.TILESX!=null)
                            {
                                int _HCSN = 0, _SX = 0;
                                if (hoadon.TILEHCSN != null)
                                    _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                                _SX = TieuThu - _HCSN;

                                TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                            }
                        break;
                    case 35:///HCSN + DV
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILEHCSN == null && hoadon.TILESX == null) || (hoadon.TILEHCSN == 0 && hoadon.TILESX == 0))
                            {
                                TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                            else
                            ///Nếu có tỉ lệ
                            //if (hoadon.TILEHCSN!=null && hoadon.TILEDV!=null)
                            {
                                int _HCSN = 0, _DV = 0;
                                if (hoadon.TILEHCSN != null)
                                    _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                                _DV = TieuThu - _HCSN;

                                TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    case 36:///HCSN + SX + DV
                        if (hoadon != null)
                        //if (hoadon.TILEHCSN!=null && hoadon.TILESX!=null && hoadon.TILEDV!=null)
                        {
                            int _HCSN = 0, _SX = 0, _DV = 0;
                            if (hoadon.TILEHCSN != null)
                                _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                            if (hoadon.TILESX != null)
                                _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                            _DV = TieuThu - _HCSN - _SX;

                            TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    //case 38:///SH + HCSN

                    //    break;
                    //case 39:///SH + HCSN + SX + DV

                    //    break;
                    ///NƯỚC NGOÀI
                    case 41:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[2].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    //case 42:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 43:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    case 44:///SH + SX
                        if (hoadon != null)
                        //if (hoadon.TILESH!=null && hoadon.TILESX!=null)
                        {
                            int _SH = 0, _SX = 0;
                            if (hoadon.TILESH != null)
                                _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                            _SX = TieuThu - _SH;

                            TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        }
                        break;
                    case 45:///SH + DV
                        if (hoadon != null)
                        //if (hoadon.TILESH!=null && hoadon.TILEDV!=null)
                        {
                            int _SH = 0, _DV = 0;
                            if (hoadon.TILESH != null)
                                _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                            _DV = TieuThu - _SH;

                            TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    case 46:///SH + SX + DV
                        if (hoadon != null)
                        //if (hoadon.TILESH!=null && hoadon.TILESX!=null && hoadon.TILEDV!=null)
                        {
                            int _SH = 0, _SX = 0, _DV = 0;
                            if (hoadon.TILESH != null)
                                _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                            if (hoadon.TILESX != null)
                                _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                            _DV = TieuThu - _SH - _SX;

                            TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    ///BÁN SỈ
                    case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
                        //if (TieuThu <= DinhMuc)
                        //    TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100));
                        //else
                        //    if (TieuThu - DinhMuc <= DinhMuc / 2)
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100)));
                        //    else
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2].DonGia.Value - (lstGiaNuoc[2].DonGia.Value * 10 / 100)));
                        if (TieuThu <= DinhMuc)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                }
                            else
                            {
                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                if (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                    TieuThu_DieuChinhGia = TieuThu;
                                else
                                    TieuThu_DieuChinhGia = TieuThu - DinhMuc;
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 59:///sỉ phức tạp
                        if (hoadon != null)
                        //if (hoadon.TILESH!=null && hoadon.TILEHCSN!=null && hoadon.TILESX!=null && hoadon.TILEDV!=null)
                        {
                            int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                            if (hoadon.TILESH != null)
                                _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                            if (hoadon.TILEHCSN != null)
                                _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                            if (hoadon.TILESX != null)
                                _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                            _DV = TieuThu - _SH - _HCSN - _SX;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                    if (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                        TieuThu_DieuChinhGia = _SH;
                                    else
                                        TieuThu_DieuChinhGia = _SH - DinhMuc;
                                }
                            TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                         + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                         + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                            //TongTien -= TongTien * 10 / 100;
                        }
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        if (hoadon != null)
                        //if (hoadon.TILESH!=null && hoadon.TILEDV!=null)
                        {
                            int _SH = 0, _DV = 0;
                            if (hoadon.TILESH != null)
                                _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                            _DV = TieuThu - _SH;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                        _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))) + "\r\n"
                                             + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                         + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                    if (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                        TieuThu_DieuChinhGia = _SH;
                                    else
                                        TieuThu_DieuChinhGia = _SH - DinhMuc;
                                }
                            TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
                            _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            //TongTien -= TongTien * 10 / 100;
                        }
                        break;
                    default:
                        _chiTiet = "";
                        TongTien = 0;
                        break;
                }
                ChiTiet = _chiTiet;
                return TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                TieuThu_DieuChinhGia = 0;
                return 0;
            }
        }

        public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int GiaBieu, int DinhMuc, int TieuThu, int TieuThu_GiaDieuChinh2, int GiaTien_GiaDieuChinh2, out string ChiTiet)
        {
            try
            {
                string _chiTiet = "";
                HOADON hoadon = _cThuTien.GetMoiNhat(DanhBo);
                List<GiaNuoc> lstGiaNuoc = db.GiaNuocs.ToList();
                ///Table GiaNuoc được thiết lập theo bảng giá nước
                ///1. Đến 4m3/người/tháng
                ///2. Trên 4m3 đến 6m3/người/tháng
                ///3. Trên 6m3/người/tháng
                ///4. Đơn vị sản xuất
                ///5. Cơ quan, đoàn thể HCSN
                ///6. Đơn vị kinh doanh, dịch vụ
                ///List bắt đầu từ phần tử thứ 0
                int TongTien = 0;
                switch (GiaBieu)
                {
                    ///TƯ GIA
                    case 11:
                    case 21:///SH thuần túy
                        if (TieuThu <= DinhMuc)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value)
                                                + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value)
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value)
                                                + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value)
                                                + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value)
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                }
                            else
                            {
                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value)
                                            + ((TieuThu - DinhMuc) * GiaDieuChinh)
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                            + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            }
                        break;
                    case 12:
                    case 22:
                    case 32:
                    case 42:///SX thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        break;
                    case 13:
                    case 23:
                    case 33:
                    case 43:///DV thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        break;
                    case 14:
                    case 24:///SH + SX
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILESH == null && hoadon.TILESX == null) || (hoadon.TILESH == 0 && hoadon.TILESX == 0))
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[3].DonGia.Value)
                                                    + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh)
                                                    + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                    }
                            }
                            else
                                ///Nếu có tỉ lệ SH + SX
                                if (hoadon.TILESH != null && hoadon.TILESX != null)
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += _SX * lstGiaNuoc[3].DonGia.Value;
                                    _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                                }
                        break;
                    case 15:
                    case 25:///SH + DV
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILESH == null && hoadon.TILEDV == null) || (hoadon.TILESH == 0 && hoadon.TILEDV == 0))
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value)
                                                    + ((TieuThu - DinhMuc) * lstGiaNuoc[5].DonGia.Value)
                                                    + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value) + "\r\n"
                                                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value)
                                                    + ((TieuThu - DinhMuc) * GiaDieuChinh)
                                                    + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                    }
                            }
                            else
                                ///Nếu có tỉ lệ SH + DV
                                if (hoadon.TILESH != null && hoadon.TILEDV != null)
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
                                    _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                                }
                        break;
                    case 16:
                    case 26:///SH + SX + DV
                        if (hoadon != null)
                            ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
                            if ((hoadon.TILESX != null && hoadon.TILEDV != null && hoadon.TILESH == null) || (hoadon.TILESX != 0 && hoadon.TILEDV != 0 && hoadon.TILESH == 0))
                            {
                                int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                TongTien = (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                            else
                                ///Nếu có đủ 3 tỉ lệ SH + SX + DV
                                if (hoadon.TILESX != null && hoadon.TILEDV != null && hoadon.TILESH != null)
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                    _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                                 + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                                }
                        break;
                    case 17:
                    case 27:///SH ĐB
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        break;
                    case 18:
                    case 28:
                    case 38:///SH + HCSN
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILESH == null && hoadon.TILEHCSN == null) || (hoadon.TILESH == 0 && hoadon.TILEHCSN == 0))
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value)
                                                    + ((TieuThu - DinhMuc) * lstGiaNuoc[4].DonGia.Value)
                                                    + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value)
                                                    + ((TieuThu - DinhMuc) * GiaDieuChinh)
                                                    + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                                    }
                            }
                            else
                                ///Nếu có tỉ lệ SH + HCSN
                                if (hoadon.TILESH != null && hoadon.TILEHCSN != null)
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                    int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += _HCSN * lstGiaNuoc[4].DonGia.Value;
                                    _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                                }
                        break;
                    case 19:
                    case 29:
                    case 39:///SH + HCSN + SX + DV
                        if (hoadon != null)
                            if (hoadon.TILESH != null && hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
                            {
                                int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                                int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                                TongTien += (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    ///TẬP THỂ
                    //case 21:///SH thuần túy
                    //    if (TieuThu <= DinhMuc)
                    //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                    //    else
                    //        if (TieuThu - DinhMuc <= DinhMuc / 2)
                    //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                    //        else
                    //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + (DinhMuc / 2 * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2].DonGia.Value);
                    //    break;
                    //case 22:///SX thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 23:///DV thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    //case 24:///SH + SX
                    //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
                    //    if (hoadon != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (hoadon.TILESH==null && hoadon.TILESX==null)
                    //        {

                    //        }
                    //    break;
                    //case 25:///SH + DV

                    //    break;
                    //case 26:///SH + SX + DV

                    //    break;
                    //case 27:///SH ĐB
                    //    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                    //    break;
                    //case 28:///SH + HCSN

                    //    break;
                    //case 29:///SH + HCSN + SX + DV

                    //    break;
                    ///CƠ QUAN
                    case 31:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[4].DonGia.Value
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        break;
                    //case 32:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 33:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    case 34:///HCSN + SX
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILEHCSN == null && hoadon.TILESX == null) || (hoadon.TILEHCSN == 0 && hoadon.TILESX == 0))
                            {
                                TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            }
                            else
                                ///Nếu có tỉ lệ
                                if (hoadon.TILEHCSN != null && hoadon.TILESX != null)
                                {
                                    int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                    TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                                }
                        break;
                    case 35:///HCSN + DV
                        if (hoadon != null)
                            ///Nếu không có tỉ lệ
                            if ((hoadon.TILEHCSN == null && hoadon.TILESX == null) || (hoadon.TILEHCSN == 0 && hoadon.TILESX == 0))
                            {
                                TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value) + "\r\n"
                                            + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            }
                            else
                                ///Nếu có tỉ lệ
                                if (hoadon.TILEHCSN != null && hoadon.TILEDV != null)
                                {
                                    int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                    TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                                }
                        break;
                    case 36:///HCSN + SX + DV
                        if (hoadon != null)
                            if (hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
                            {
                                int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                                int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    //case 38:///SH + HCSN

                    //    break;
                    //case 39:///SH + HCSN + SX + DV

                    //    break;
                    ///NƯỚC NGOÀI
                    case 41:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[2].DonGia.Value
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        break;
                    //case 42:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 43:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    case 44:///SH + SX
                        if (hoadon != null)
                            if (hoadon.TILESH != null && hoadon.TILESX != null)
                            {
                                int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                            }
                        break;
                    case 45:///SH + DV
                        if (hoadon != null)
                            if (hoadon.TILESH != null && hoadon.TILEDV != null)
                            {
                                int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    case 46:///SH + SX + DV

                        if (hoadon != null)
                            if (hoadon.TILESH != null && hoadon.TILESX != null && hoadon.TILEDV != null)
                            {
                                int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    ///BÁN SỈ
                    case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
                        //if (TieuThu <= DinhMuc)
                        //    TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100));
                        //else
                        //    if (TieuThu - DinhMuc <= DinhMuc / 2)
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100)));
                        //    else
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2].DonGia.Value - (lstGiaNuoc[2].DonGia.Value * 10 / 100)));
                        if (TieuThu <= DinhMuc)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))
                                                + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100))
                                                + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))
                                                + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100))
                                                + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100))
                                                + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                }
                            else
                            {
                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))
                                            + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100))
                                            + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)) + "\r\n"
                                            + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 59:///sỉ phức tạp
                        if (hoadon != null)
                            if (hoadon.TILESH != null && hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
                            {
                                int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                                int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                                int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                    }
                                TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                                _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                             + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                             + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                                //TongTien -= TongTien * 10 / 100;
                            }
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        if (hoadon != null)
                            if (hoadon.TILESH != null && hoadon.TILEDV != null)
                            {
                                int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                                int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                 + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                            _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))) + "\r\n"
                                                 + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                 + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                    }
                                TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
                                _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                                //TongTien -= TongTien * 10 / 100;
                            }
                        break;
                    default:
                        _chiTiet = "";
                        TongTien = 0;
                        break;
                }
                ChiTiet = _chiTiet;
                return TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                return 0;
            }
        }

        public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int GiaBieu, int DinhMuc, int TieuThu, int SH, int SX, int DV, int HCSN, out string ChiTiet)
        {
            try
            {
                string _chiTiet = "";
                HOADON hoadon = _cThuTien.GetMoiNhat(DanhBo);
                List<GiaNuoc> lstGiaNuoc = db.GiaNuocs.ToList();
                ///Table GiaNuoc được thiết lập theo bảng giá nước
                ///1. Đến 4m3/người/tháng
                ///2. Trên 4m3 đến 6m3/người/tháng
                ///3. Trên 6m3/người/tháng
                ///4. Đơn vị sản xuất
                ///5. Cơ quan, đoàn thể HCSN
                ///6. Đơn vị kinh doanh, dịch vụ
                ///List bắt đầu từ phần tử thứ 0
                int TongTien = 0;
                switch (GiaBieu)
                {
                    ///TƯ GIA
                    case 11:
                    case 21:///SH thuần túy
                        if (TieuThu <= DinhMuc)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                }
                            else
                            {
                                TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            }
                        break;
                    case 12:
                    case 22:
                    case 32:
                    case 42:///SX thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    case 13:
                    case 23:
                    case 33:
                    case 43:///DV thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    case 14:
                    case 24:///SH + SX
                        if (hoadon != null)
                        ///Nếu không có tỉ lệ
                        //if (hoadon.TILESH==null && hoadon.TILESX==null)
                        //{
                        //    if (TieuThu <= DinhMuc)
                        //    {
                        //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                        //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                        //    }
                        //    else
                        //        if (!DieuChinhGia)
                        //        {
                        //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[3].DonGia.Value);
                        //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                        //                       + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        //        }
                        //        else
                        //        {
                        //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                        //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                        //                       + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        //        }
                        //}
                        //else
                        ///Nếu có tỉ lệ SH + SX
                        //if (SH != 0 && SX != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _SX = TieuThu - _SH;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                }
                            ///tránh trường hợp chia dự 0.5 cả 2 cái sẽ bị đôn lên 1
                            TongTien += _SX * lstGiaNuoc[3].DonGia.Value;
                            _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        }
                        break;
                    case 15:
                    case 25:///SH + DV
                        if (hoadon != null)
                        ///Nếu không có tỉ lệ
                        //if (hoadon.TILESH==null && hoadon.TILEDV==null)
                        //{
                        //    if (TieuThu <= DinhMuc)
                        //    {
                        //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                        //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                        //    }
                        //    else
                        //        if (!DieuChinhGia)
                        //        {
                        //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[5].DonGia.Value);
                        //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                        //                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        //        }
                        //        else
                        //        {
                        //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                        //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                        //                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        //        }
                        //}
                        //else
                        ///Nếu có tỉ lệ SH + DV
                        //if (SH != 0 && DV != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _DV = TieuThu - _SH;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                }
                            TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
                            _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    case 16:
                    case 26:///SH + SX + DV
                        if (hoadon != null)
                            ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
                            if (SX != 0 && DV != 0 && SH == 0)
                            {
                                int _SX = (int)Math.Round((double)TieuThu * SX / 100);
                                int _DV = TieuThu - _SX;

                                TongTien = (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                            else
                            ///Nếu có đủ 3 tỉ lệ SH + SX + DV
                            //if (SX != 0 && DV != 0 && SH != 0)
                            {
                                int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                                int _SX = (int)Math.Round((double)TieuThu * SX / 100);
                                int _DV = TieuThu - _SH - _SX;

                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                                TongTien += (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                             + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    case 17:
                    case 27:///SH ĐB
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    case 18:
                    case 28:
                    case 38:///SH + HCSN
                        if (hoadon != null)
                        ///Nếu không có tỉ lệ
                        //if (hoadon.TILESH==null && hoadon.TILEHCSN==null)
                        //{
                        //    if (TieuThu <= DinhMuc)
                        //    {
                        //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                        //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                        //    }
                        //    else
                        //        if (!DieuChinhGia)
                        //        {
                        //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[4].DonGia.Value);
                        //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                        //                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                        //        }
                        //        else
                        //        {
                        //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                        //            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                        //                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        //        }
                        //}
                        //else
                        ///Nếu có tỉ lệ SH + HCSN
                        //if (SH != 0 && HCSN != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _HCSN = TieuThu - _SH;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                }
                            TongTien += _HCSN * lstGiaNuoc[4].DonGia.Value;
                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                        }
                        break;
                    case 19:
                    case 29:
                    case 39:///SH + HCSN + SX + DV
                        if (hoadon != null)
                        //if (SH != 0 && HCSN != 0 && SX != 0 && DV != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
                            int _SX = (int)Math.Round((double)TieuThu * SX / 100);
                            int _DV = TieuThu - _SH - _HCSN - _SX;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * lstGiaNuoc[0].DonGia.Value;
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value);
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1].DonGia.Value) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2].DonGia.Value);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1].DonGia.Value) + "\r\n"
                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((_SH - DinhMuc) * GiaDieuChinh);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0].DonGia.Value) + "\r\n"
                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                }
                            TongTien += (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    ///TẬP THỂ
                    //case 21:///SH thuần túy
                    //    if (TieuThu <= DinhMuc)
                    //        TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                    //    else
                    //        if (TieuThu - DinhMuc <= DinhMuc / 2)
                    //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + ((TieuThu - DinhMuc) * lstGiaNuoc[1].DonGia.Value);
                    //        else
                    //            TongTien = (DinhMuc * lstGiaNuoc[0].DonGia.Value) + (DinhMuc / 2 * lstGiaNuoc[1].DonGia.Value) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2].DonGia.Value);
                    //    break;
                    //case 22:///SX thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 23:///DV thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    //case 24:///SH + SX
                    //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
                    //    if (hoadon != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (hoadon.TILESH==null && hoadon.TILESX==null)
                    //        {

                    //        }
                    //    break;
                    //case 25:///SH + DV

                    //    break;
                    //case 26:///SH + SX + DV

                    //    break;
                    //case 27:///SH ĐB
                    //    TongTien = TieuThu * lstGiaNuoc[0].DonGia.Value;
                    //    break;
                    //case 28:///SH + HCSN

                    //    break;
                    //case 29:///SH + HCSN + SX + DV

                    //    break;
                    ///CƠ QUAN
                    case 31:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[4].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    //case 32:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 33:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    case 34:///HCSN + SX
                        if (hoadon != null)
                        ///Nếu không có tỉ lệ
                        //if (hoadon.TILEHCSN==null && hoadon.TILESX==null)
                        //{
                        //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                        //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        //}
                        //else
                        ///Nếu có tỉ lệ
                        //if (HCSN != 0 && SX != 0)
                        {
                            int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
                            int _SX = TieuThu - _HCSN;

                            TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        }
                        break;
                    case 35:///HCSN + DV
                        if (hoadon != null)
                        ///Nếu không có tỉ lệ
                        //if (hoadon.TILEHCSN==null && hoadon.TILESX==null)
                        //{
                        //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                        //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        //}
                        //else
                        ///Nếu có tỉ lệ
                        //if (HCSN != 0 && DV != 0)
                        {
                            int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
                            int _DV = TieuThu - _HCSN;

                            TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    case 36:///HCSN + SX + DV
                        if (hoadon != null)
                        //if (HCSN != 0 && SX != 0 && DV != 0)
                        {
                            int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
                            int _SX = (int)Math.Round((double)TieuThu * SX / 100);
                            int _DV = TieuThu - _HCSN - _SX;

                            TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    //case 38:///SH + HCSN

                    //    break;
                    //case 39:///SH + HCSN + SX + DV

                    //    break;
                    ///NƯỚC NGOÀI
                    case 41:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[2].DonGia.Value;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                        }
                        break;
                    //case 42:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                    //    break;
                    //case 43:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                    //    break;
                    case 44:///SH + SX
                        if (hoadon != null)
                        //if (SH != 0 && SX !=0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _SX = TieuThu - _SH;

                            TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        }
                        break;
                    case 45:///SH + DV

                        if (hoadon != null)
                        //if (SH != 0 && DV != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _DV = TieuThu - _SH;

                            TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    case 46:///SH + SX + DV
                        if (hoadon != null)
                        //if (SH!= 0 && SX != 0 && DV != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _SX = (int)Math.Round((double)TieuThu * SX / 100);
                            int _DV = TieuThu - _SH - _SX;

                            TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    ///BÁN SỈ
                    case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
                        //if (TieuThu <= DinhMuc)
                        //    TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100));
                        //else
                        //    if (TieuThu - DinhMuc <= DinhMuc / 2)
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100)));
                        //    else
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - (lstGiaNuoc[0].DonGia.Value * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1].DonGia.Value - (lstGiaNuoc[1].DonGia.Value * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2].DonGia.Value - (lstGiaNuoc[2].DonGia.Value * 10 / 100)));
                        if (TieuThu <= DinhMuc)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                }
                            else
                            {
                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 59:///sỉ phức tạp
                        if (hoadon != null)
                        //if (SH != 0 && HCSN !=0 && SX != 0 && DV != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
                            int _SX = (int)Math.Round((double)TieuThu * SX / 100);
                            int _DV = TieuThu - _SH - _HCSN - _SX;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                }
                            TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                         + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                         + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                            //TongTien -= TongTien * 10 / 100;
                        }
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        if (hoadon != null)
                        //if (SH != 0 && DV != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _DV = TieuThu - _SH;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                        _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))) + "\r\n"
                                             + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                                         + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                }
                            TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
                            _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            //TongTien -= TongTien * 10 / 100;
                        }
                        break;
                    default:
                        _chiTiet = "";
                        TongTien = 0;
                        break;
                }
                ChiTiet = _chiTiet;
                return TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                return 0;
            }
        }

        //khu công nghiệp
        public int TinhTienNuoc_KhuCongNghiep(string DanhBo, int GiaBieu, int DinhMuc, int TieuThu, out string ChiTiet, out float TyLe)
        {
            try
            {
                string _chiTiet = "";
                TyLe = 0.0f;
                HOADON hoadon = _cThuTien.GetMoiNhat(DanhBo);
                List<GiaNuoc> lstGiaNuoc = db.GiaNuocs.ToList();
                KhuCongNghiep kcn = _cKCN.get(DanhBo);
                ///Table GiaNuoc được thiết lập theo bảng giá nước
                ///1. Đến 4m3/người/tháng
                ///2. Trên 4m3 đến 6m3/người/tháng
                ///3. Trên 6m3/người/tháng
                ///4. Đơn vị sản xuất
                ///5. Cơ quan, đoàn thể HCSN
                ///6. Đơn vị kinh doanh, dịch vụ
                ///List bắt đầu từ phần tử thứ 0
                int TongTien = 0;
                int GiaBan = lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100;
                switch (GiaBieu)
                {
                    ///BÁN SỈ
                    //case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
                    //    if (TieuThu <= DinhMuc)
                    //    {
                    //        TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                    //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                    //    }
                    //    else
                    //            if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                    //            {
                    //                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //            }
                    //            else
                    //            {
                    //                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                            + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //            }

                    //    break;
                    case 52:///sỉ khu công nghiệp
                        if (TieuThu <= kcn.DinhMuc.Value)
                        {
                            TongTien = TieuThu * GiaBan;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
                        }
                        else
                        {
                            TyLe = (float)(TieuThu - kcn.DinhMuc.Value) / kcn.DinhMuc.Value * 100;
                            int TyLe2 = (int)TyLe;
                            TongTien = kcn.DinhMuc.Value * GiaBan;
                            _chiTiet = kcn.DinhMuc.Value + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
                            if (0 < TyLe2 && TyLe2 <= 19)
                            {
                                TongTien += (TieuThu - kcn.DinhMuc.Value) * (GiaBan - GiaBan * 10 / 100);
                                _chiTiet += "\n" + (TieuThu - kcn.DinhMuc.Value) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 10 / 100));
                            }
                            else if (20 <= TyLe2 && TyLe2 <= 29)
                            {
                                TongTien += (TieuThu - kcn.DinhMuc.Value) * (GiaBan - GiaBan * 20 / 100);
                                _chiTiet += "\n" + (TieuThu - kcn.DinhMuc.Value) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 20 / 100));
                            }
                            else if (30 <= TyLe2 && TyLe2 <= 39)
                            {
                                TongTien += (TieuThu - kcn.DinhMuc.Value) * (GiaBan - GiaBan * 30 / 100);
                                _chiTiet += "\n" + (TieuThu - kcn.DinhMuc.Value) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 30 / 100));
                            }
                            else if (40 <= TyLe2 && TyLe2 <= 49)
                            {
                                TongTien += (TieuThu - kcn.DinhMuc.Value) * (GiaBan - GiaBan * 40 / 100);
                                _chiTiet += "\n" + (TieuThu - kcn.DinhMuc.Value) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 40 / 100));
                            }
                            else if (50 <= TyLe2)
                            {
                                TongTien += (TieuThu - kcn.DinhMuc.Value) * (GiaBan - GiaBan * 50 / 100);
                                _chiTiet += "\n" + (TieuThu - kcn.DinhMuc.Value) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 50 / 100));
                            }
                        }
                        break;
                    //case 53:///sỉ KD - TM
                    //        TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100);
                    //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                    //    break;
                    //case 54:///sỉ HCSN
                    //        TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100);
                    //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100));
                    //    break;
                    //case 59:///sỉ phức tạp
                    //    if (hoadon != null)
                    //    {
                    //        int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                    //        if (hoadon.TILESH != null)
                    //            _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                    //        if (hoadon.TILEHCSN != null)
                    //            _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                    //        if (hoadon.TILESX != null)
                    //            _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                    //        _DV = TieuThu - _SH - _HCSN - _SX;

                    //        if (_SH <= DinhMuc)
                    //        {
                    //            TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                    //            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                    //        }
                    //        else
                    //                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                    //                {
                    //                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                }
                    //                else
                    //                {
                    //                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                                + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                }

                    //        TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                    //        _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                     + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                     + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                    //    }
                    //    break;
                    //case 68:///SH giá sỉ - KD giá lẻ
                    //    if (hoadon != null)
                    //    {
                    //        int _SH = 0, _DV = 0;
                    //        if (hoadon.TILESH != null)
                    //            _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                    //        _DV = TieuThu - _SH;

                    //        if (_SH <= DinhMuc)
                    //        {
                    //            TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                    //            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                    //        }
                    //        else
                    //                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                    //                {
                    //                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                         + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                }
                    //                else
                    //                {
                    //                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                    _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))) + "\r\n"
                    //                         + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                         + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                }

                    //        TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
                    //        _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                    //    }
                    //    break;
                    default:
                        _chiTiet = "";
                        TongTien = 0;
                        break;
                }
                ChiTiet = _chiTiet;
                return TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                TyLe = 0.0f;
                return 0;
            }
        }

        //tính giá nước 15/11/2019
        public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, List<int> lstGiaNuoc, int GiaBieu, int TyLeSH, int TyLeSX, int TyLeDV, int TyLeHCSN, int TongDinhMuc, int DinhMucHN, int TieuThu, out string ChiTiet, out int TieuThu_DieuChinhGia)
        {
            try
            {
                string _chiTiet = "";
                int DinhMuc = TongDinhMuc - DinhMucHN, _SH = 0, _SX = 0, _DV = 0, _HCSN = 0;
                TieuThu_DieuChinhGia = 0;
                //HOADON hoadon = _cThuTien.Get(DanhBo, Ky, Nam);
                //List<GiaNuoc> lstGiaNuoc = db.GiaNuocs.ToList();
                ///Table GiaNuoc được thiết lập theo bảng giá nước
                ///1. Đến 4m3/người/tháng
                ///2. Trên 4m3 đến 6m3/người/tháng
                ///3. Trên 6m3/người/tháng
                ///4. Đơn vị sản xuất
                ///5. Cơ quan, đoàn thể HCSN
                ///6. Đơn vị kinh doanh, dịch vụ
                ///7. Hộ nghèo, cận nghèo
                ///List bắt đầu từ phần tử thứ 0
                int TongTien = 0;
                switch (GiaBieu)
                {
                    ///TƯ GIA
                    case 10:
                        DinhMucHN = TongDinhMuc;
                        if (TieuThu <= DinhMucHN)
                        {
                            TongTien = TieuThu * lstGiaNuoc[6];
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMucHN <= Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + ((TieuThu - DinhMucHN) * lstGiaNuoc[1]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if ((TieuThu - DinhMucHN) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1])
                                                + ((TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if ((int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                        updateChiTiet(ref _chiTiet, (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    if ((TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6])
                                            + ((TieuThu - DinhMucHN) * GiaDieuChinh);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if ((TieuThu - DinhMucHN) > 0)
                                    updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                if (lstGiaNuoc[6] == GiaDieuChinh)
                                    TieuThu_DieuChinhGia = TieuThu;
                                else
                                    TieuThu_DieuChinhGia = TieuThu - DinhMucHN;
                            }
                        break;
                    case 11:
                    case 21:///SH thuần túy
                        //if (TieuThu <= DinhMucHN)
                        //{
                        //    TongTien = TieuThu * lstGiaNuoc[6];
                        //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                        //}
                        //else
                        //    if (TieuThu - DinhMucHN <= DinhMuc)
                        //    {
                        //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                        //                    + ((TieuThu - DinhMucHN) * lstGiaNuoc[0]);
                        //        _chiTiet = (DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                        //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                        //    }
                        if (TieuThu <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0, TieuThuDC = 0;
                            TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                            TieuThuDC = TieuThu - TieuThuHN;
                            TongTien = (TieuThuHN * lstGiaNuoc[6])
                                        + (TieuThuDC * lstGiaNuoc[0]);
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            if (TieuThuDC > 0)
                                updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                + ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                        updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    if ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0])
                                            + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (DinhMuc > 0)
                                    updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                    updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                if (lstGiaNuoc[0] == GiaDieuChinh)
                                    TieuThu_DieuChinhGia = TieuThu;
                                else
                                    TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
                            }
                        break;
                    case 12:
                    case 22:
                    case 32:
                    case 42:///SX thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    case 13:
                    case 23:
                    case 33:
                    case 43:///DV thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    case 14:
                    case 24:///SH + SX
                        ///Nếu không có tỉ lệ
                        if (TyLeSH == 0 && TyLeSX == 0)
                        {
                            //if (TieuThu <= DinhMucHN)
                            //{
                            //    TongTien = TieuThu * lstGiaNuoc[6];
                            //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            //}
                            //else
                            //    if (TieuThu - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + ((TieuThu - DinhMucHN) * lstGiaNuoc[0]);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                            //    }
                            if (TieuThu <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = TieuThu - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0]);
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                            }
                            else
                                if (!DieuChinhGia)
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[3]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                    if (lstGiaNuoc[0] == GiaDieuChinh)
                                        TieuThu_DieuChinhGia = TieuThu;
                                    else
                                        TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
                                }
                        }
                        else
                        ///Nếu có tỉ lệ SH + SX
                        {
                            //int _SH = 0, _SX = 0;
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _SX = TieuThu - _SH;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = _SH * lstGiaNuoc[6];
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (_SH - DinhMucHN * lstGiaNuoc[0]);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0]);
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                    if (lstGiaNuoc[0] == GiaDieuChinh)
                                        TieuThu_DieuChinhGia = _SH;
                                    else
                                        TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
                                }
                            TongTien += _SX * lstGiaNuoc[3];
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                        }
                        break;
                    case 15:
                    case 25:///SH + DV
                        ///Nếu không có tỉ lệ
                        if (TyLeSH == 0 && TyLeDV == 0)
                        {
                            //if (TieuThu <= DinhMucHN)
                            //{
                            //    TongTien = TieuThu * lstGiaNuoc[6];
                            //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            //}
                            //else
                            //    if (TieuThu - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (TieuThu * lstGiaNuoc[0]);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                            //    }
                            if (TieuThu <= DinhMucHN + DinhMuc)
                            {
                                //double TyLe = Math.Round((double)DinhMucHN / (DinhMucHN + DinhMuc), 2);
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = TieuThu - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0]);
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                            }
                            else
                                if (!DieuChinhGia)
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[5]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN - DinhMuc) * GiaDieuChinh);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                    if (lstGiaNuoc[0] == GiaDieuChinh)
                                        TieuThu_DieuChinhGia = TieuThu;
                                    else
                                        TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
                                }
                        }
                        else
                        ///Nếu có tỉ lệ SH + DV
                        {
                            //int _SH = 0, _DV = 0;
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = _SH * lstGiaNuoc[6];
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (_SH - DinhMucHN * lstGiaNuoc[0]);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0]);
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                    if (lstGiaNuoc[0] == GiaDieuChinh)
                                        TieuThu_DieuChinhGia = _SH;
                                    else
                                        TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
                                }
                            TongTien += _DV * lstGiaNuoc[5];
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    case 16:
                    case 26:///SH + SX + DV
                        ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
                        if (TyLeSX != 0 && TyLeDV != 0 && TyLeSH == 0)
                        {
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SX;
                            TongTien = (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_SX > 0)
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        else
                        ///Nếu có đủ 3 tỉ lệ SH + SX + DV
                        {
                            //int _SH = 0, _SX = 0, _DV = 0;
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH - _SX;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = _SH * lstGiaNuoc[6];
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (_SH * lstGiaNuoc[0]);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0]);
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                    if (lstGiaNuoc[0] == GiaDieuChinh)
                                        TieuThu_DieuChinhGia = _SH;
                                    else
                                        TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
                                }
                            TongTien += (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    case 17:
                    case 27:///SH ĐB
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    case 18:
                    case 28:
                    case 38:///SH + HCSN
                        ///Nếu không có tỉ lệ
                        if (TyLeSH == 0 && TyLeHCSN == 0)
                        {
                            //if (TieuThu <= DinhMucHN)
                            //{
                            //    TongTien = TieuThu * lstGiaNuoc[6];
                            //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            //}
                            //else
                            //    if (TieuThu - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN) * lstGiaNuoc[0]);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
                            //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                            //    }
                            if (TieuThu <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = TieuThu - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0]);
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                            }
                            else
                                if (!DieuChinhGia)
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[4]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMucHN - DinhMuc) * GiaDieuChinh);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                    if (lstGiaNuoc[0] == GiaDieuChinh)
                                        TieuThu_DieuChinhGia = TieuThu;
                                    else
                                        TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
                                }
                        }
                        else
                        ///Nếu có tỉ lệ SH + HCSN
                        {
                            //int _SH = 0, _HCSN = 0;
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _HCSN = TieuThu - _SH;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = _SH * lstGiaNuoc[6];
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + ((_SH - DinhMucHN) * lstGiaNuoc[0]);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0]);
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[0]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                    if (lstGiaNuoc[0] == GiaDieuChinh)
                                        TieuThu_DieuChinhGia = _SH;
                                    else
                                        TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
                                }
                            TongTien += _HCSN * lstGiaNuoc[4];
                            if (_HCSN > 0)
                                updateChiTiet(ref _chiTiet, _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]));
                        }
                        break;
                    case 19:
                    case 29:
                    case 39:///SH + HCSN + SX + DV
                        //int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeHCSN != 0)
                            _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeSX != 0)
                            _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH - _HCSN - _SX;

                        //if (_SH <= DinhMucHN)
                        //{
                        //    TongTien = _SH * lstGiaNuoc[6];
                        //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                        //}
                        //else
                        //    if (_SH - DinhMucHN <= DinhMuc)
                        //    {
                        //        TongTien = (DinhMucHN * lstGiaNuoc[6]) + ((_SH - DinhMucHN) * lstGiaNuoc[0]);
                        //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                        //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                        //    }
                        if (_SH <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0, TieuThuDC = 0;
                            TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                            TieuThuDC = _SH - TieuThuHN;
                            TongTien = (TieuThuHN * lstGiaNuoc[6])
                                        + (TieuThuDC * lstGiaNuoc[0]);
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            if (TieuThuDC > 0)
                                updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                        }
                        else
                            if (!DieuChinhGia)
                                if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                        updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6]) + (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (DinhMuc > 0)
                                    updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if ((_SH - DinhMucHN - DinhMuc) > 0)
                                    updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));

                                if (lstGiaNuoc[0] == GiaDieuChinh)
                                    TieuThu_DieuChinhGia = _SH;
                                else
                                    TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
                            }
                        TongTien += (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                        if (_HCSN > 0)
                            updateChiTiet(ref _chiTiet, _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]));
                        if (_SX > 0)
                            updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                        if (_DV > 0)
                            updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        break;
                    ///TẬP THỂ
                    //case 21:///SH thuần túy
                    //    if (TieuThu <= DinhMuc)
                    //        TongTien = TieuThu * lstGiaNuoc[0];
                    //    else
                    //        if (TieuThu - DinhMuc <= DinhMuc / 2)
                    //            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[1]);
                    //        else
                    //            TongTien = (DinhMuc * lstGiaNuoc[0]) + (DinhMuc / 2 * lstGiaNuoc[1]) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2]);
                    //    break;
                    //case 22:///SX thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 23:///DV thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    //case 24:///SH + SX
                    //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
                    //    if (hoadon != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (hoadon.TILESH==null && hoadon.TILESX==null)
                    //        {

                    //        }
                    //    break;
                    //case 25:///SH + DV

                    //    break;
                    //case 26:///SH + SX + DV

                    //    break;
                    //case 27:///SH ĐB
                    //    TongTien = TieuThu * lstGiaNuoc[0];
                    //    break;
                    //case 28:///SH + HCSN

                    //    break;
                    //case 29:///SH + HCSN + SX + DV

                    //    break;
                    ///CƠ QUAN
                    case 31:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[4];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    //case 32:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 33:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    case 34:///HCSN + SX
                        ///Nếu không có tỉ lệ
                        if (TyLeHCSN == 0 && TyLeSX == 0)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                        }
                        else
                        ///Nếu có tỉ lệ
                        {
                            //int _HCSN = 0, _SX = 0;
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            _SX = TieuThu - _HCSN;

                            TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]);
                            if (_HCSN > 0)
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                        }
                        break;
                    case 35:///HCSN + DV
                        ///Nếu không có tỉ lệ
                        if (TyLeHCSN == 0 && TyLeDV == 0)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                        }
                        else
                        ///Nếu có tỉ lệ
                        {
                            //int _HCSN = 0, _DV = 0;
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _HCSN;

                            TongTien = (_HCSN * lstGiaNuoc[4]) + (_DV * lstGiaNuoc[5]);
                            if (_HCSN > 0)
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    case 36:///HCSN + SX + DV
                        {
                            //int _HCSN = 0, _SX = 0, _DV = 0;
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _HCSN - _SX;

                            TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_HCSN > 0)
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    //case 38:///SH + HCSN

                    //    break;
                    //case 39:///SH + HCSN + SX + DV

                    //    break;
                    ///NƯỚC NGOÀI
                    case 41:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[2];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    //case 42:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 43:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    case 44:///SH + SX
                        {
                            //int _SH = 0, _SX = 0;
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _SX = TieuThu - _SH;

                            TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]);
                            if (_SH > 0)
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                        }
                        break;
                    case 45:///SH + DV
                        //int _SH = 0, _DV = 0;
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH;

                        TongTien = (_SH * lstGiaNuoc[2]) + (_DV * lstGiaNuoc[5]);
                        if (_SH > 0)
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                        if (_DV > 0)
                            updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        break;
                    case 46:///SH + SX + DV
                        {
                            //int _SH = 0, _SX = 0, _DV = 0;
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH - _SX;

                            TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_SH > 0)
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    ///BÁN SỈ
                    case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
                        //if (TieuThu <= DinhMuc)
                        //    TongTien = TieuThu * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100));
                        //else
                        //    if (TieuThu - DinhMuc <= DinhMuc / 2)
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100)));
                        //    else
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2] - (lstGiaNuoc[2] * 10 / 100)));
                        //if (TieuThu <= DinhMucHN)
                        //{
                        //    TongTien = TieuThu * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
                        //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                        //}
                        //else
                        //    if (TieuThu - DinhMucHN <= DinhMuc)
                        //    {
                        //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (TieuThu - DinhMucHN * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                        //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //    }
                        if (TieuThu <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0, TieuThuDC = 0;
                            TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                            TieuThuDC = TieuThu - TieuThuHN;
                            TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                        + (TieuThuDC * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            if (TieuThuDC > 0)
                                updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
                                                + ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                        updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                    if ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100)));
                                }
                            else
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                            + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                            + ((TieuThu - DinhMucHN - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                if (DinhMucHN > 0)
                                    _chiTiet = +DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                if (DinhMuc > 0)
                                    updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                    updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)));

                                if (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                    TieuThu_DieuChinhGia = TieuThu;
                                else
                                    TieuThu_DieuChinhGia = TieuThu - DinhMucHN - DinhMuc;
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 58:
                        //int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeHCSN != 0)
                            _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeSX != 0)
                            _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH - _HCSN - _SX;

                        TongTien += (_SH * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                    + (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100))
                                    + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100))
                                    + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
                        if (_SH > 0)
                            _chiTiet += _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        if (_HCSN > 0)
                            updateChiTiet(ref _chiTiet, _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)));
                        if (_SX > 0)
                            updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)));
                        if (_DV > 0)
                            updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100)));
                        break;
                    case 59:///sỉ phức tạp
                        //int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeHCSN != 0)
                            _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeSX != 0)
                            _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH - _HCSN - _SX;

                        //if (_SH <= DinhMucHN)
                        //{
                        //    TongTien = _SH * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
                        //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                        //}
                        //else
                        //    if (_SH - DinhMucHN <= DinhMuc)
                        //    {
                        //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (_SH - DinhMucHN * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
                        //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //    }
                        if (_SH <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0, TieuThuDC = 0;
                            TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                            TieuThuDC = _SH - TieuThuHN;
                            TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                        + (TieuThuDC * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            if (TieuThuDC > 0)
                                updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                        }
                        else
                            if (!DieuChinhGia)
                                if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                + ((_SH - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
                                                + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                        updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                    if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100)));
                                }
                            else
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                            + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                            + ((_SH - DinhMucHN - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                if (DinhMuc > 0)
                                    updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                if ((_SH - DinhMucHN - DinhMuc) > 0)
                                    updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)));

                                if (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                    TieuThu_DieuChinhGia = _SH;
                                else
                                    TieuThu_DieuChinhGia = _SH - DinhMucHN - DinhMuc;
                            }
                        TongTien += (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
                        if (_HCSN > 0)
                            updateChiTiet(ref _chiTiet, _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)));
                        if (_SX > 0)
                            updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)));
                        if (_DV > 0)
                            updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100)));
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        //int _SH = 0, _DV = 0;
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH;

                        //if (_SH <= DinhMucHN)
                        //{
                        //    TongTien = _SH * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
                        //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                        //}
                        //else
                        //    if (_SH - DinhMucHN <= DinhMuc)
                        //    {
                        //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + ((_SH - DinhMucHN) * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                        //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //    }
                        if (_SH <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0, TieuThuDC = 0;
                            TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                            TieuThuDC = _SH - TieuThuHN;
                            TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                        + (TieuThuDC * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            if (TieuThuDC > 0)
                                updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                        }
                        else
                            if (!DieuChinhGia)
                                if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                + ((_SH - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
                                                + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                        updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                    if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100)));
                                }
                            else
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                            + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                            + ((_SH - DinhMucHN - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                if (DinhMuc > 0)
                                    updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                if ((_SH - DinhMucHN - DinhMuc) > 0)
                                    updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)));

                                if (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                    TieuThu_DieuChinhGia = _SH;
                                else
                                    TieuThu_DieuChinhGia = _SH - DinhMuc;
                            }
                        TongTien += _DV * lstGiaNuoc[5];
                        if (_DV > 0)
                            updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    default:
                        _chiTiet = "";
                        TongTien = 0;
                        break;
                }
                ChiTiet = _chiTiet;
                return TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                TieuThu_DieuChinhGia = 0;
                return 0;
            }
        }

        public int TinhTienNuoc2(bool DieuChinhGia, int GiaDieuChinh, List<int> lstGiaNuoc, int GiaBieu, int TyLeSH, int TyLeSX, int TyLeDV, int TyLeHCSN, int TongDinhMuc, int DinhMucHN, int TieuThu, int TieuThu_GiaDieuChinh2, int GiaTien_GiaDieuChinh2, out string ChiTiet)
        {
            try
            {
                string _chiTiet = "";
                int DinhMuc = TongDinhMuc - DinhMucHN, _SH = 0, _SX = 0, _DV = 0, _HCSN = 0;
                //HOADON hoadon = _cThuTien.Get(DanhBo, Ky, Nam);
                //List<GiaNuoc> lstGiaNuoc = db.GiaNuocs.ToList();
                ///Table GiaNuoc được thiết lập theo bảng giá nước
                ///1. Đến 4m3/người/tháng
                ///2. Trên 4m3 đến 6m3/người/tháng
                ///3. Trên 6m3/người/tháng
                ///4. Đơn vị sản xuất
                ///5. Cơ quan, đoàn thể HCSN
                ///6. Đơn vị kinh doanh, dịch vụ
                ///7. Hộ nghèo, cận nghèo
                ///List bắt đầu từ phần tử thứ 0
                int TongTien = 0;
                switch (GiaBieu)
                {
                    ///TƯ GIA
                    case 10:
                        DinhMucHN = TongDinhMuc;
                        if (TieuThu <= DinhMucHN)
                        {
                            TongTien = (TieuThu * lstGiaNuoc[6])
                                        + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMucHN <= Math.Round((double)(DinhMucHN) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + ((TieuThu - DinhMucHN) * lstGiaNuoc[1])
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if ((TieuThu - DinhMucHN) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + ((int)Math.Round((double)(DinhMucHN) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                + ((TieuThu - DinhMucHN - (int)Math.Round((double)(DinhMucHN) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2])
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if ((int)Math.Round((double)(DinhMucHN) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                        updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    if ((TieuThu - DinhMucHN - (int)Math.Round((double)(DinhMucHN) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - (int)Math.Round((double)(DinhMucHN) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6])
                                            + ((TieuThu - DinhMucHN) * GiaDieuChinh)
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if ((TieuThu - DinhMucHN) > 0)
                                    updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                        break;
                    case 11:
                    case 21:///SH thuần túy
                        //if (TieuThu <= DinhMucHN)
                        //{
                        //    TongTien = TieuThu * lstGiaNuoc[6]
                        //                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                        //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                        //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        //}
                        //else
                        //    if (TieuThu - DinhMucHN <= DinhMuc)
                        //    {
                        //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                        //                    + ((TieuThu - DinhMucHN) * lstGiaNuoc[0])
                        //                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                        //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                        //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                        //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        //    }
                        if (TieuThu <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0, TieuThuDC = 0;
                            TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                            TieuThuDC = TieuThu - TieuThuHN;
                            TongTien = (TieuThuHN * lstGiaNuoc[6])
                                        + (TieuThuDC * lstGiaNuoc[0])
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            if (DinhMucHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            if (TieuThuDC > 0)
                                updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((TieuThu - DinhMuc) * lstGiaNuoc[1])
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                + ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2])
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                        updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    if ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6])
                                            + (DinhMuc * lstGiaNuoc[0])
                                            + ((TieuThu - DinhMucHN - DinhMuc) * GiaDieuChinh)
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (DinhMuc > 0)
                                    updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                    updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                        break;
                    case 12:
                    case 22:
                    case 32:
                    case 42:///SX thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3]
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        break;
                    case 13:
                    case 23:
                    case 33:
                    case 43:///DV thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5]
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        break;
                    case 14:
                    case 24:///SH + SX
                        ///Nếu không có tỉ lệ
                        if (TyLeSH == 0 && TyLeSX == 0)
                        {
                            //if (TieuThu <= DinhMucHN)
                            //{
                            //    TongTien = TieuThu * lstGiaNuoc[6]
                            //                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //}
                            //else
                            //    if (TieuThu - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                            //                    + (TieuThu - DinhMucHN * lstGiaNuoc[0])
                            //                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                            //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //    }
                            if (TieuThu <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = TieuThu - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0])
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[3])
                                                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((TieuThu - DinhMucHN - DinhMuc) * GiaDieuChinh)
                                                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                        }
                        else
                        ///Nếu có tỉ lệ SH + SX
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _SX = TieuThu - _SH;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = _SH * lstGiaNuoc[6];
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                            //                    + (_SH * lstGiaNuoc[0]);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0])
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                }
                            TongTien += _SX * lstGiaNuoc[3];
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                        }
                        break;
                    case 15:
                    case 25:///SH + DV
                        ///Nếu không có tỉ lệ
                        if (TyLeSH == 0 && TyLeDV == 0)
                        {
                            //if (TieuThu <= DinhMucHN)
                            //{
                            //    TongTien = TieuThu * lstGiaNuoc[6]
                            //                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //}
                            //else
                            //    if (TieuThu - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                            //                    + ((TieuThu - DinhMucHN) * lstGiaNuoc[0])
                            //                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                            //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //    }
                            if (TieuThu <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = TieuThu - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0])
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[5])
                                                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((TieuThu - DinhMucHN - DinhMuc) * GiaDieuChinh)
                                                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                        }
                        else
                        ///Nếu có tỉ lệ SH + DV
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH;
                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = (_SH * lstGiaNuoc[6])
                            //                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                            //                    + (_SH - DinhMucHN * lstGiaNuoc[0])
                            //                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                            //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0])
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1])
                                                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2])
                                                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh)
                                                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                            TongTien += _DV * lstGiaNuoc[5];
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    case 16:
                    case 26:///SH + SX + DV
                        ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
                        if (TyLeSX != 0 && TyLeDV != 0 && TyLeSH == 0)
                        {
                            _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SX;
                            TongTien = (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_SX > 0)
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        else
                        ///Nếu có đủ 3 tỉ lệ SH + SX + DV
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH - _SX;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = (_SH * lstGiaNuoc[6])
                            //                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                            //                    + ((_SH - DinhMucHN) * lstGiaNuoc[0])
                            //                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                            //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0])
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1])
                                                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2])
                                                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2); ;
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh)
                                                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2); ;
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                            TongTien += (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    case 17:
                    case 27:///SH ĐB
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0]
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                        }
                        break;
                    case 18:
                    case 28:
                    case 38:///SH + HCSN
                        ///Nếu không có tỉ lệ
                        if (TyLeSH == 0 && TyLeHCSN == 0)
                        {
                            //if (TieuThu <= DinhMucHN)
                            //{
                            //    TongTien = (TieuThu * lstGiaNuoc[6])
                            //                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //}
                            //else
                            //    if (TieuThu - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                            //                    + ((TieuThu - DinhMucHN) * lstGiaNuoc[0])
                            //                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                            //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //    }
                            if (TieuThu <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = TieuThu - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0])
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[4])
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((TieuThu - DinhMucHN - DinhMuc) * GiaDieuChinh)
                                                + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                        }
                        else
                        ///Nếu có tỉ lệ SH + HCSN
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _HCSN = TieuThu - _SH;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = (_SH * lstGiaNuoc[6])
                            //                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                            //                    + ((_SH - DinhMucHN) * lstGiaNuoc[0])
                            //                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                            //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0])
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1])
                                                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[0])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2])
                                                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh)
                                                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                            TongTien += _HCSN * lstGiaNuoc[4];
                            if (_HCSN > 0)
                                updateChiTiet(ref _chiTiet, _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]));
                        }
                        break;
                    case 19:
                    case 29:
                    case 39:///SH + HCSN + SX + DV
                        if (TyLeSH != 0 && TyLeHCSN != 0 && TyLeSX != 0 && TyLeDV != 0)
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH - _HCSN - _SX;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = (_SH * lstGiaNuoc[6])
                            //                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * lstGiaNuoc[6])
                            //                    + ((_SH - DinhMucHN) * lstGiaNuoc[0])
                            //                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                            //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            + (TieuThuDC * lstGiaNuoc[0])
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1])
                                                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                    + (DinhMuc * lstGiaNuoc[0])
                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * lstGiaNuoc[1])
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2])
                                                    + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6])
                                                + (DinhMuc * lstGiaNuoc[0])
                                                + ((_SH - DinhMucHN - DinhMuc) * GiaDieuChinh)
                                                + (TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                                }
                            TongTien += (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_HCSN > 0)
                                updateChiTiet(ref _chiTiet, _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]));
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    ///TẬP THỂ
                    //case 21:///SH thuần túy
                    //    if (TieuThu <= DinhMuc)
                    //        TongTien = TieuThu * lstGiaNuoc[0];
                    //    else
                    //        if (TieuThu - DinhMuc <= DinhMuc / 2)
                    //            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[1]);
                    //        else
                    //            TongTien = (DinhMuc * lstGiaNuoc[0]) + (DinhMuc / 2 * lstGiaNuoc[1]) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2]);
                    //    break;
                    //case 22:///SX thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 23:///DV thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    //case 24:///SH + SX
                    //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
                    //    if (hoadon != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (hoadon.TILESH==null && hoadon.TILESX==null)
                    //        {

                    //        }
                    //    break;
                    //case 25:///SH + DV

                    //    break;
                    //case 26:///SH + SX + DV

                    //    break;
                    //case 27:///SH ĐB
                    //    TongTien = TieuThu * lstGiaNuoc[0];
                    //    break;
                    //case 28:///SH + HCSN

                    //    break;
                    //case 29:///SH + HCSN + SX + DV

                    //    break;
                    ///CƠ QUAN
                    case 31:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[4]
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                        }
                        break;
                    //case 32:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 33:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    case 34:///HCSN + SX
                        ///Nếu không có tỉ lệ
                        if (TyLeHCSN == 0 && TyLeSX == 0)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3]
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                        }
                        else
                        ///Nếu có tỉ lệ
                        {
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            _SX = TieuThu - _HCSN;
                            TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]);
                            if (_HCSN > 0)
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                        }
                        break;
                    case 35:///HCSN + DV
                        ///Nếu không có tỉ lệ
                        if (TyLeHCSN == 0 && TyLeSX == 0)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5]
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                        }
                        else
                        ///Nếu có tỉ lệ
                        {
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _HCSN;
                            TongTien = (_HCSN * lstGiaNuoc[4]) + (_DV * lstGiaNuoc[5]);
                            if (_HCSN > 0)
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    case 36:///HCSN + SX + DV
                        if (TyLeHCSN != 0 && TyLeSX != 0 && TyLeDV != 0)
                        {
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _HCSN - _SX;
                            TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_HCSN > 0)
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    //case 38:///SH + HCSN

                    //    break;
                    //case 39:///SH + HCSN + SX + DV

                    //    break;
                    ///NƯỚC NGOÀI
                    case 41:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[2]
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                        }
                        break;
                    //case 42:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 43:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    case 44:///SH + SX
                        if (TyLeSH != 0 && TyLeSX != 0)
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _SX = TieuThu - _SH;
                            TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]);
                            if (_SH > 0)
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                        }
                        break;
                    case 45:///SH + DV
                        if (TyLeSH != 0 && TyLeDV != 0)
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH;
                            TongTien = (_SH * lstGiaNuoc[2]) + (_DV * lstGiaNuoc[5]);
                            if (_SH > 0)
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    case 46:///SH + SX + DV
                        if (TyLeSH != 0 && TyLeSX != 0 && TyLeDV != 0)
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH - _SX;
                            TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_SH > 0)
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    ///BÁN SỈ
                    case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
                        //if (TieuThu <= DinhMuc)
                        //    TongTien = TieuThu * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100));
                        //else

                        //    if (TieuThu - DinhMuc <= DinhMuc / 2)
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100)));
                        //    else
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2] - (lstGiaNuoc[2] * 10 / 100)));
                        //if (TieuThu <= DinhMucHN)
                        //{
                        //    TongTien = (TieuThu * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                        //                + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
                        //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        //}
                        //else
                        //    if (TieuThu - DinhMucHN <= DinhMuc)
                        //    {
                        //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                        //                    + ((TieuThu - DinhMucHN) * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                        //                    + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
                        //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
                        //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                        //    }
                        if (TieuThu <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0, TieuThuDC = 0;
                            TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                            TieuThuDC = TieuThu - TieuThuHN;
                            TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                        + (TieuThuDC * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                        + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            if (TieuThuDC > 0)
                                updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                + ((TieuThu - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
                                                + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
                                                + ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100))
                                                + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                        updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                    if ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                        updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100)));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                                }
                            else
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                            + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                            + ((TieuThu - DinhMucHN - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100))
                                            + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                if (DinhMuc > 0)
                                    updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                if ((TieuThu - DinhMucHN - DinhMuc) > 0)
                                    updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100));
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100));
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100);
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            if (TieuThu_GiaDieuChinh2 > 0)
                                updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 58:
                        if (TyLeSH != 0 && TyLeHCSN != 0 && TyLeSX != 0 && TyLeDV != 0)
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH - _HCSN - _SX;

                            TongTien += (_SH * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                        + (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100))
                                        + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100))
                                        + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
                            if (_SH > 0)
                                _chiTiet += _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                            if (_HCSN > 0)
                                updateChiTiet(ref _chiTiet, _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)));
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100)));
                        }
                        break;
                    case 59:///sỉ phức tạp
                        if (TyLeSH != 0 && TyLeHCSN != 0 && TyLeSX != 0 && TyLeDV != 0)
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH - _HCSN - _SX;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = (_SH * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                            //                + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
                            //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                            //                    + ((_SH - DinhMucHN) * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                            //                    + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
                            //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                            + (TieuThuDC * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                    + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                    + ((_SH - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
                                                    + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                    + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100))
                                                    + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100)));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                + ((_SH - DinhMucHN - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100))
                                                + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                                }
                            TongTien += (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
                            if (_HCSN > 0)
                                updateChiTiet(ref _chiTiet, _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)));
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100)));
                            //TongTien -= TongTien * 10 / 100;
                        }
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        if (TyLeSH != 0 && TyLeDV != 0)
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH;

                            //if (_SH <= DinhMucHN)
                            //{
                            //    TongTien = _SH * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)
                            //                + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                            //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
                            //                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                            //}
                            //else
                            //    if (_SH - DinhMucHN <= DinhMuc)
                            //    {
                            //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                            //                    + ((_SH - DinhMucHN) * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                            //                    + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                            //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
                            //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
                            //                    + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                            //    }
                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0, TieuThuDC = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TieuThuDC = _SH - TieuThuHN;
                                TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                            + (TieuThuDC * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                if (TieuThuDC > 0)
                                    updateChiTiet(ref _chiTiet, TieuThuDC + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                if (TieuThu_GiaDieuChinh2 > 0)
                                    updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                    {
                                        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                    + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                    + ((_SH - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
                                                    + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                        if (DinhMucHN > 0)
                                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                        if ((_SH - DinhMucHN - DinhMuc) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                    + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100))
                                                    + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                        if (DinhMucHN > 0)
                                            _chiTiet = (DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)));
                                        if (DinhMuc > 0)
                                            updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                        if ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                            updateChiTiet(ref _chiTiet, (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)));
                                        if ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                            updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100)));
                                        if (TieuThu_GiaDieuChinh2 > 0)
                                            updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                                    }
                                else
                                {
                                    TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                                + ((_SH - DinhMucHN - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100))
                                                + (TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100));
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                    if (DinhMuc > 0)
                                        updateChiTiet(ref _chiTiet, DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)));
                                    if ((_SH - DinhMucHN - DinhMuc) > 0)
                                        updateChiTiet(ref _chiTiet, (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100)));
                                    if (TieuThu_GiaDieuChinh2 > 0)
                                        updateChiTiet(ref _chiTiet, TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * _GiamTienNuoc / 100)));
                                }
                            TongTien += _DV * lstGiaNuoc[5];
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                            //TongTien -= TongTien * 10 / 100;
                        }
                        break;
                    default:
                        _chiTiet = "";
                        TongTien = 0;
                        break;
                }
                ChiTiet = _chiTiet;
                return TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                return 0;
            }
        }

        public int TinhTienNuoc_KhuCongNghiep(List<int> lstGiaNuoc, int GiaBieu, int TongDinhMuc, int DinhMucHN, int TieuThu, out string ChiTiet, out float TyLe)
        {
            try
            {
                string _chiTiet = "";
                TyLe = 0.0f;
                //HOADON hoadon = _cThuTien.GetMoiNhat(DanhBo);
                //List<GiaNuoc> lstGiaNuoc = db.GiaNuocs.ToList();
                //KhuCongNghiep kcn = _cKCN.get(DanhBo);
                ///Table GiaNuoc được thiết lập theo bảng giá nước
                ///1. Đến 4m3/người/tháng
                ///2. Trên 4m3 đến 6m3/người/tháng
                ///3. Trên 6m3/người/tháng
                ///4. Đơn vị sản xuất
                ///5. Cơ quan, đoàn thể HCSN
                ///6. Đơn vị kinh doanh, dịch vụ
                ///List bắt đầu từ phần tử thứ 0
                int TongTien = 0;
                int GiaBan = lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100;
                switch (GiaBieu)
                {
                    ///BÁN SỈ
                    //case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
                    //    if (TieuThu <= DinhMuc)
                    //    {
                    //        TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                    //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                    //    }
                    //    else
                    //            if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                    //            {
                    //                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //            }
                    //            else
                    //            {
                    //                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                            + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //            }

                    //    break;
                    case 52:///sỉ khu công nghiệp
                        if (TieuThu <= TongDinhMuc)
                        {
                            TongTien = TieuThu * GiaBan;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
                        }
                        else
                        {
                            TyLe = (float)(TieuThu - TongDinhMuc) / TongDinhMuc * 100;
                            int TyLe2 = (int)TyLe;
                            TongTien = TongDinhMuc * GiaBan;
                            _chiTiet = TongDinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBan);
                            if (0 < TyLe2 && TyLe2 <= 19)
                            {
                                TongTien += (TieuThu - TongDinhMuc) * (GiaBan - GiaBan * 10 / 100);
                                _chiTiet += "\n" + (TieuThu - TongDinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 10 / 100));
                            }
                            else if (20 <= TyLe2 && TyLe2 <= 29)
                            {
                                TongTien += (TieuThu - TongDinhMuc) * (GiaBan - GiaBan * 20 / 100);
                                _chiTiet += "\n" + (TieuThu - TongDinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 20 / 100));
                            }
                            else if (30 <= TyLe2 && TyLe2 <= 39)
                            {
                                TongTien += (TieuThu - TongDinhMuc) * (GiaBan - GiaBan * 30 / 100);
                                _chiTiet += "\n" + (TieuThu - TongDinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 30 / 100));
                            }
                            else if (40 <= TyLe2 && TyLe2 <= 49)
                            {
                                TongTien += (TieuThu - TongDinhMuc) * (GiaBan - GiaBan * 40 / 100);
                                _chiTiet += "\n" + (TieuThu - TongDinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 40 / 100));
                            }
                            else if (50 <= TyLe2)
                            {
                                TongTien += (TieuThu - TongDinhMuc) * (GiaBan - GiaBan * 50 / 100);
                                _chiTiet += "\n" + (TieuThu - TongDinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaBan - GiaBan * 50 / 100));
                            }
                        }
                        break;
                    //case 53:///sỉ KD - TM
                    //        TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100);
                    //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                    //    break;
                    //case 54:///sỉ HCSN
                    //        TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100);
                    //        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100));
                    //    break;
                    //case 59:///sỉ phức tạp
                    //    if (hoadon != null)
                    //    {
                    //        int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                    //        if (hoadon.TILESH != null)
                    //            _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                    //        if (hoadon.TILEHCSN != null)
                    //            _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
                    //        if (hoadon.TILESX != null)
                    //            _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
                    //        _DV = TieuThu - _SH - _HCSN - _SX;

                    //        if (_SH <= DinhMuc)
                    //        {
                    //            TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                    //            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                    //        }
                    //        else
                    //                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                    //                {
                    //                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                }
                    //                else
                    //                {
                    //                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                                + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                }

                    //        TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                    //        _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                     + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                     + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * _GiamTienNuoc / 100));
                    //    }
                    //    break;
                    //case 68:///SH giá sỉ - KD giá lẻ
                    //    if (hoadon != null)
                    //    {
                    //        int _SH = 0, _DV = 0;
                    //        if (hoadon.TILESH != null)
                    //            _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
                    //        _DV = TieuThu - _SH;

                    //        if (_SH <= DinhMuc)
                    //        {
                    //            TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100);
                    //            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100));
                    //        }
                    //        else
                    //                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                    //                {
                    //                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                         + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100));
                    //                }
                    //                else
                    //                {
                    //                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                    _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * _GiamTienNuoc / 100))) + "\r\n"
                    //                         + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * _GiamTienNuoc / 100)) + "\r\n"
                    //                         + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * _GiamTienNuoc / 100));
                    //                }

                    //        TongTien += _DV * lstGiaNuoc[5].DonGia.Value;
                    //        _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                    //    }
                    //    break;
                    default:
                        _chiTiet = "";
                        TongTien = 0;
                        break;
                }
                ChiTiet = _chiTiet;
                return TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                TyLe = 0.0f;
                return 0;
            }
        }

        public int TinhTienNuoc_HoNgheo(bool DieuChinhGia, int GiaDieuChinh, List<int> lstGiaNuoc, int GiaBieu, int TyLeSH, int TyLeSX, int TyLeDV, int TyLeHCSN, int TongDinhMuc, int DinhMucHN, int TieuThu, out string ChiTiet, out int TieuThu_DieuChinhGia)
        {
            try
            {
                string _chiTiet = "";
                int DinhMuc = TongDinhMuc - DinhMucHN, _SH = 0, _SX = 0, _DV = 0, _HCSN = 0;
                TieuThu_DieuChinhGia = 0;
                int TongTien = 0;
                switch (GiaBieu)
                {
                    ///TƯ GIA
                    case 10:
                        DinhMucHN = TongDinhMuc;
                        if (TieuThu <= DinhMucHN)
                        {
                            TongTien = TieuThu * lstGiaNuoc[6];
                            if (TieuThu > 0)
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                        }
                        else
                            if (TieuThu - DinhMucHN <= Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero))
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6])
                                            + ((TieuThu - DinhMucHN) * lstGiaNuoc[1]);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if ((TieuThu - DinhMucHN) > 0)
                                    updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                            }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6])
                                            + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1])
                                            + ((TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero)) * lstGiaNuoc[2]);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                if ((int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero) > 0)
                                    updateChiTiet(ref _chiTiet, (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]));
                                if ((TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero)) > 0)
                                    updateChiTiet(ref _chiTiet, (TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2, 0, MidpointRounding.AwayFromZero)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]));
                            }
                        break;
                    case 11:
                    case 21:///SH thuần túy
                        if (TieuThu <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0;
                            TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                            TongTien = (TieuThuHN * lstGiaNuoc[6]);
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                        }
                        else
                            if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                        break;
                    case 12:
                    case 22:
                    case 32:
                    case 42:///SX thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    case 13:
                    case 23:
                    case 33:
                    case 43:///DV thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    case 14:
                    case 24:///SH + SX
                        ///Nếu không có tỉ lệ
                        if (TyLeSH == 0 && TyLeSX == 0)
                        {
                            if (TieuThu <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0;
                                TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            ;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                        }
                        else
                        ///Nếu có tỉ lệ SH + SX
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _SX = TieuThu - _SH;

                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            ;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                            else
                                if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                }
                        }
                        break;
                    case 15:
                    case 25:///SH + DV
                        ///Nếu không có tỉ lệ
                        if (TyLeSH == 0 && TyLeDV == 0)
                        {
                            if (TieuThu <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0;
                                TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                                TongTien = (TieuThuHN * lstGiaNuoc[6]);
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                        }
                        else
                        ///Nếu có tỉ lệ SH + DV
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH;

                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                           ;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                            else
                                if (_SH - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                }

                        }
                        break;
                    case 16:
                    case 26:///SH + SX + DV
                        ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
                        if (TyLeSX != 0 && TyLeDV != 0 && TyLeSH == 0)
                        {
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SX;
                            TongTien = (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_SX > 0)
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        else
                        ///Nếu có đủ 3 tỉ lệ SH + SX + DV
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH - _SX;

                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                           ;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                            else
                                if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                }
                        }
                        break;
                    case 17:
                    case 27:///SH ĐB
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[0];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    case 18:
                    case 28:
                    case 38:///SH + HCSN
                        ///Nếu không có tỉ lệ
                        if (TyLeSH == 0 && TyLeHCSN == 0)
                        {
                            if (TieuThu <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0;
                                TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            ;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                        }
                        else
                        ///Nếu có tỉ lệ SH + HCSN
                        {
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _HCSN = TieuThu - _SH;

                            if (_SH <= DinhMucHN + DinhMuc)
                            {
                                double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                                int TieuThuHN = 0;
                                TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                                TongTien = (TieuThuHN * lstGiaNuoc[6])
                                            ;
                                if (TieuThuHN > 0)
                                    _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                            else
                                if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[0]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                }
                                else
                                {
                                    TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                    if (DinhMucHN > 0)
                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                                }
                        }
                        break;
                    case 19:
                    case 29:
                    case 39:///SH + HCSN + SX + DV
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeHCSN != 0)
                            _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeSX != 0)
                            _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH - _HCSN - _SX;

                        if (_SH <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0;
                            TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                            TongTien = (TieuThuHN * lstGiaNuoc[6])
                                        ;
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                        }
                        else
                            if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                            else
                            {
                                TongTien = (DinhMucHN * lstGiaNuoc[6]);
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
                            }
                        break;
                    ///TẬP THỂ
                    //case 21:///SH thuần túy
                    //    if (TieuThu <= DinhMuc)
                    //        TongTien = TieuThu * lstGiaNuoc[0];
                    //    else
                    //        if (TieuThu - DinhMuc <= DinhMuc / 2)
                    //            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[1]);
                    //        else
                    //            TongTien = (DinhMuc * lstGiaNuoc[0]) + (DinhMuc / 2 * lstGiaNuoc[1]) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2]);
                    //    break;
                    //case 22:///SX thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 23:///DV thuần túy
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    //case 24:///SH + SX
                    //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
                    //    if (hoadon != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (hoadon.TILESH==null && hoadon.TILESX==null)
                    //        {

                    //        }
                    //    break;
                    //case 25:///SH + DV

                    //    break;
                    //case 26:///SH + SX + DV

                    //    break;
                    //case 27:///SH ĐB
                    //    TongTien = TieuThu * lstGiaNuoc[0];
                    //    break;
                    //case 28:///SH + HCSN

                    //    break;
                    //case 29:///SH + HCSN + SX + DV

                    //    break;
                    ///CƠ QUAN
                    case 31:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[4];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    //case 32:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 33:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    case 34:///HCSN + SX
                        ///Nếu không có tỉ lệ
                        if (TyLeHCSN == 0 && TyLeSX == 0)
                        {
                            TongTien = TieuThu * lstGiaNuoc[3];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                        }
                        else
                        ///Nếu có tỉ lệ
                        {
                            //int _HCSN = 0, _SX = 0;
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            _SX = TieuThu - _HCSN;

                            TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]);
                            if (_HCSN > 0)
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                        }
                        break;
                    case 35:///HCSN + DV
                        ///Nếu không có tỉ lệ
                        if (TyLeHCSN == 0 && TyLeDV == 0)
                        {
                            TongTien = TieuThu * lstGiaNuoc[5];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                        }
                        else
                        ///Nếu có tỉ lệ
                        {
                            //int _HCSN = 0, _DV = 0;
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _HCSN;

                            TongTien = (_HCSN * lstGiaNuoc[4]) + (_DV * lstGiaNuoc[5]);
                            if (_HCSN > 0)
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    case 36:///HCSN + SX + DV
                        {
                            //int _HCSN = 0, _SX = 0, _DV = 0;
                            if (TyLeHCSN != 0)
                                _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _HCSN - _SX;

                            TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_HCSN > 0)
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    //case 38:///SH + HCSN

                    //    break;
                    //case 39:///SH + HCSN + SX + DV

                    //    break;
                    ///NƯỚC NGOÀI
                    case 41:///SHVM thuần túy
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * lstGiaNuoc[2];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                        }
                        else
                        {
                            TongTien = TieuThu * GiaDieuChinh;
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        break;
                    //case 42:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 43:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    case 44:///SH + SX
                        {
                            //int _SH = 0, _SX = 0;
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            _SX = TieuThu - _SH;

                            TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]);
                            if (_SH > 0)
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                        }
                        break;
                    case 45:///SH + DV
                        //int _SH = 0, _DV = 0;
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH;

                        TongTien = (_SH * lstGiaNuoc[2]) + (_DV * lstGiaNuoc[5]);
                        if (_SH > 0)
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                        if (_DV > 0)
                            updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        break;
                    case 46:///SH + SX + DV
                        {
                            //int _SH = 0, _SX = 0, _DV = 0;
                            if (TyLeSH != 0)
                                _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                            if (TyLeSX != 0)
                                _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                            _DV = TieuThu - _SH - _SX;

                            TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                            if (_SH > 0)
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                            if (_SX > 0)
                                updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]));
                            if (_DV > 0)
                                updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]));
                        }
                        break;
                    ///BÁN SỈ
                    case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
                        //if (TieuThu <= DinhMuc)
                        //    TongTien = TieuThu * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100));
                        //else
                        //    if (TieuThu - DinhMuc <= DinhMuc / 2)
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100)));
                        //    else
                        //        TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2] - (lstGiaNuoc[2] * 10 / 100)));
                        //if (TieuThu <= DinhMucHN)
                        //{
                        //    TongTien = TieuThu * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
                        //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                        //}
                        //else
                        //    if (TieuThu - DinhMucHN <= DinhMuc)
                        //    {
                        //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (TieuThu - DinhMucHN * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                        //                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //    }
                        if (TieuThu <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0;
                            TieuThuHN = (int)Math.Round(TieuThu * TyLe, 0, MidpointRounding.AwayFromZero);
                            TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                       ;
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                        }
                        else
                            if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            }
                            else
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            }
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 58:
                        //int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeHCSN != 0)
                            _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeSX != 0)
                            _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH - _HCSN - _SX;

                        TongTien += (_SH * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
                                    + (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100))
                                    + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100))
                                    + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
                        if (_SH > 0)
                            _chiTiet += _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        if (_HCSN > 0)
                            updateChiTiet(ref _chiTiet, _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)));
                        if (_SX > 0)
                            updateChiTiet(ref _chiTiet, _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)));
                        if (_DV > 0)
                            updateChiTiet(ref _chiTiet, _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100)));
                        break;
                    case 59:///sỉ phức tạp
                        //int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeHCSN != 0)
                            _HCSN = (int)Math.Round((double)TieuThu * TyLeHCSN / 100, 0, MidpointRounding.AwayFromZero);
                        if (TyLeSX != 0)
                            _SX = (int)Math.Round((double)TieuThu * TyLeSX / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH - _HCSN - _SX;

                        //if (_SH <= DinhMucHN)
                        //{
                        //    TongTien = _SH * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
                        //    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                        //}
                        //else
                        //    if (_SH - DinhMucHN <= DinhMuc)
                        //    {
                        //        TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + (_SH - DinhMucHN * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
                        //                    + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
                        //    }
                        if (_SH <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0;
                            TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                            TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                        ;
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                        }
                        else
                            if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                           ;
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            }
                            else
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                           ;
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            }
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        if (TyLeSH != 0)
                            _SH = (int)Math.Round((double)TieuThu * TyLeSH / 100, 0, MidpointRounding.AwayFromZero);
                        _DV = TieuThu - _SH;

                        if (_SH <= DinhMucHN + DinhMuc)
                        {
                            double TyLe = (double)DinhMucHN / (DinhMucHN + DinhMuc);
                            int TieuThuHN = 0;
                            TieuThuHN = (int)Math.Round(_SH * TyLe, 0, MidpointRounding.AwayFromZero);
                            TongTien = (TieuThuHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                       ;
                            if (TieuThuHN > 0)
                                _chiTiet = TieuThuHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                        }
                        else
                            if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2, 0, MidpointRounding.AwayFromZero))
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                           ;
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            }
                            else
                            {
                                TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
                                           ;
                                if (DinhMucHN > 0)
                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
                            }
                        break;
                    default:
                        _chiTiet = "";
                        TongTien = 0;
                        break;
                }
                ChiTiet = _chiTiet;
                return TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                TieuThu_DieuChinhGia = 0;
                return 0;
            }
        }

        //công thức mới 2020
        public void TinhTienNuoc(bool ApGiaNuocCu, bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int Ky, int Nam, DateTime TuNgay, DateTime DenNgay, int GiaBieu, int TyLeSH, int TyLeSX, int TyLeDV, int TyLeHCSN, int TongDinhMuc, int DinhMucHN, int TieuThu, out int TienNuocCu, out string ChiTietCu, out int TienNuocMoi, out string ChiTietMoi, out int TieuThu_DieuChinhGia)
        {
            List<GiaNuoc2> lst = getDS();
            //check giảm giá
            checkExists_GiamGiaNuoc(Nam, Ky, GiaBieu, ref lst);

            int index = -1;
            TienNuocCu = TienNuocMoi = 0;
            ChiTietCu = ChiTietMoi = "";
            TieuThu_DieuChinhGia = 0;
            for (int i = 0; i < lst.Count; i++)
                if (TuNgay.Date < lst[i].NgayTangGia.Value.Date && lst[i].NgayTangGia.Value.Date < DenNgay.Date)
                {
                    index = i;
                }
                else
                    if (TuNgay.Date >= lst[i].NgayTangGia.Value.Date)
                    {
                        index = i;
                    }
            if (index != -1)
            {
                if (DenNgay.Date < new DateTime(2019, 11, 15))
                {
                    //int TieuThu_DieuChinhGia;
                    List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                    TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, 0, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
                }
                else
                    if (TuNgay.Date < lst[index].NgayTangGia.Value.Date && lst[index].NgayTangGia.Value.Date < DenNgay.Date)
                    {
                        if (ApGiaNuocCu == false)
                        {
                            //int TieuThu_DieuChinhGia;
                            int TongSoNgay = (int)((DenNgay.Date - TuNgay.Date).TotalDays);

                            int SoNgayCu = (int)((lst[index].NgayTangGia.Value.Date - TuNgay.Date).TotalDays);
                            int TieuThuCu = (int)Math.Round((double)TieuThu * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TieuThuMoi = TieuThu - TieuThuCu;
                            int TongDinhMucCu = (int)Math.Round((double)TongDinhMuc * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TongDinhMucMoi = TongDinhMuc - TongDinhMucCu;
                            int DinhMucHN_Cu = 0, DinhMucHN_Moi = 0;
                            if (TuNgay.Date > new DateTime(2019, 11, 15))
                                if (TongDinhMucCu != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                    DinhMucHN_Cu = (int)Math.Round((double)TongDinhMucCu * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            if (TongDinhMucMoi != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                DinhMucHN_Moi = (int)Math.Round((double)TongDinhMucMoi * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            List<int> lstGiaNuocMoi = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                            //lần đầu áp dụng giá biểu 10, tổng áp giá mới luôn
                            if (TuNgay.Date < new DateTime(2019, 11, 15) && new DateTime(2019, 11, 15) < DenNgay.Date && GiaBieu == 10)
                                TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocMoi, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, out ChiTietCu, out TieuThu_DieuChinhGia);
                            else
                                TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocCu, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, out ChiTietCu, out TieuThu_DieuChinhGia);
                            TienNuocMoi = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocMoi, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucMoi, DinhMucHN_Moi, TieuThuMoi, out ChiTietMoi, out TieuThu_DieuChinhGia);
                        }
                        else
                        {
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocCu, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
                        }
                    }
                    else
                    {
                        //int TieuThu_DieuChinhGia;
                        List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                        TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
                    }
            }
            else
            {

            }
        }

        public void TinhTienNuoc2(bool ApGiaNuocCu, bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int Ky, int Nam, DateTime TuNgay, DateTime DenNgay, int GiaBieu, int TyLeSH, int TyLeSX, int TyLeDV, int TyLeHCSN, int TongDinhMuc, int DinhMucHN, int TieuThu, int TieuThu_GiaDieuChinh2, int GiaTien_GiaDieuChinh2, out int TienNuocCu, out string ChiTietCu, out int TienNuocMoi, out string ChiTietMoi)
        {
            List<GiaNuoc2> lst = getDS();
            //check giảm giá
            checkExists_GiamGiaNuoc(Nam, Ky, GiaBieu, ref lst);

            int index = -1;
            TienNuocCu = TienNuocMoi = 0;
            ChiTietCu = ChiTietMoi = "";
            for (int i = 0; i < lst.Count; i++)
                if (TuNgay.Date < lst[i].NgayTangGia.Value.Date && lst[i].NgayTangGia.Value.Date < DenNgay.Date)
                {
                    index = i;
                }
                else
                    if (TuNgay.Date >= lst[i].NgayTangGia.Value.Date)
                    {
                        index = i;
                    }
            if (index != -1)
            {
                if (DenNgay.Date < new DateTime(2019, 11, 15))
                {
                    List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                    TienNuocCu = TinhTienNuoc2(DieuChinhGia, GiaDieuChinh, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, 0, TieuThu, TieuThu_GiaDieuChinh2, GiaTien_GiaDieuChinh2, out ChiTietCu);
                }
                else
                    if (TuNgay.Date < lst[index].NgayTangGia.Value.Date && lst[index].NgayTangGia.Value.Date < DenNgay.Date)
                    {
                        if (ApGiaNuocCu == false)
                        {
                            int TongSoNgay = (int)((DenNgay.Date - TuNgay.Date).TotalDays);

                            int SoNgayCu = (int)((lst[index].NgayTangGia.Value.Date - TuNgay.Date).TotalDays);
                            int TieuThuCu = (int)Math.Round((double)TieuThu * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TieuThuMoi = TieuThu - TieuThuCu;
                            int TongDinhMucCu = (int)Math.Round((double)TongDinhMuc * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TongDinhMucMoi = TongDinhMuc - TongDinhMucCu;
                            int DinhMucHN_Cu = 0, DinhMucHN_Moi = 0;
                            if (TuNgay.Date > new DateTime(2019, 11, 15))
                                if (TongDinhMucCu != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                    DinhMucHN_Cu = (int)Math.Round((double)TongDinhMucCu * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            if (TongDinhMucMoi != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                DinhMucHN_Moi = (int)Math.Round((double)TongDinhMucMoi * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            List<int> lstGiaNuocMoi = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                            TienNuocCu = TinhTienNuoc2(DieuChinhGia, GiaDieuChinh, lstGiaNuocCu, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, TieuThu_GiaDieuChinh2, GiaTien_GiaDieuChinh2, out ChiTietCu);
                            TienNuocMoi = TinhTienNuoc2(DieuChinhGia, GiaDieuChinh, lstGiaNuocMoi, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucMoi, DinhMucHN_Moi, TieuThuMoi, TieuThu_GiaDieuChinh2, GiaTien_GiaDieuChinh2, out ChiTietMoi);
                        }
                        else
                        {
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            TienNuocCu = TinhTienNuoc2(DieuChinhGia, GiaDieuChinh, lstGiaNuocCu, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, DinhMucHN, TieuThu, TieuThu_GiaDieuChinh2, GiaTien_GiaDieuChinh2, out ChiTietCu);
                        }
                    }
                    else
                    {
                        List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                        TienNuocCu = TinhTienNuoc2(DieuChinhGia, GiaDieuChinh, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, DinhMucHN, TieuThu, TieuThu_GiaDieuChinh2, GiaTien_GiaDieuChinh2, out ChiTietCu);
                    }
            }
            else
            {

            }
        }

        public void TinhTienNuoc_KhuCongNghiep(bool ApGiaNuocCu, string DanhBo, int Ky, int Nam, DateTime TuNgay, DateTime DenNgay, int GiaBieu, int TongDinhMuc, int DinhMucHN, int TieuThu, out int TienNuocCu, out string ChiTietCu, out int TienNuocMoi, out string ChiTietMoi, out float TyLe)
        {
            List<GiaNuoc2> lst = getDS();
            //check giảm giá
            checkExists_GiamGiaNuoc(Nam, Ky, GiaBieu, ref lst);

            int index = -1;
            TienNuocCu = TienNuocMoi = 0;
            ChiTietCu = ChiTietMoi = "";
            TyLe = 0.0f;
            KhuCongNghiep kcn = _cKCN.get(DanhBo);
            TongDinhMuc = kcn.DinhMuc.Value;
            for (int i = 0; i < lst.Count; i++)
                if (TuNgay.Date < lst[i].NgayTangGia.Value.Date && lst[i].NgayTangGia.Value.Date < DenNgay.Date)
                {
                    index = i;
                }
                else
                    if (TuNgay.Date >= lst[i].NgayTangGia.Value.Date)
                    {
                        index = i;
                    }
            if (index != -1)
            {
                if (DenNgay.Date < new DateTime(2019, 11, 15))
                {
                    List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                    TienNuocCu = TinhTienNuoc_KhuCongNghiep(lstGiaNuoc, GiaBieu, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TyLe);
                }
                else
                    if (TuNgay.Date < lst[index].NgayTangGia.Value.Date && lst[index].NgayTangGia.Value.Date < DenNgay.Date)
                    {
                        if (ApGiaNuocCu == false)
                        {
                            int TongSoNgay = (int)((DenNgay.Date - TuNgay.Date).TotalDays);

                            int SoNgayCu = (int)((lst[index].NgayTangGia.Value.Date - TuNgay.Date).TotalDays);
                            int TieuThuCu = (int)Math.Round((double)TieuThu * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TieuThuMoi = TieuThu - TieuThuCu;
                            int TongDinhMucCu = (int)Math.Round((double)TongDinhMuc * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TongDinhMucMoi = TongDinhMuc - TongDinhMucCu;
                            int DinhMucHN_Cu = 0, DinhMucHN_Moi = 0;
                            if (TuNgay.Date > new DateTime(2019, 11, 15))
                                if (TongDinhMucCu != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                    DinhMucHN_Cu = (int)Math.Round((double)TongDinhMucCu * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            if (TongDinhMucMoi != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                DinhMucHN_Moi = (int)Math.Round((double)TongDinhMucMoi * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            List<int> lstGiaNuocMoi = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                            TienNuocCu = TinhTienNuoc_KhuCongNghiep(lstGiaNuocCu, GiaBieu, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, out ChiTietCu, out TyLe);
                            TienNuocMoi = TinhTienNuoc_KhuCongNghiep(lstGiaNuocMoi, GiaBieu, TongDinhMucMoi, DinhMucHN_Moi, TieuThuMoi, out ChiTietMoi, out TyLe);
                        }
                        else
                        {
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            TienNuocCu = TinhTienNuoc_KhuCongNghiep(lstGiaNuocCu, GiaBieu, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TyLe);
                        }
                    }
                    else
                    {
                        List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                        TienNuocCu = TinhTienNuoc_KhuCongNghiep(lstGiaNuoc, GiaBieu, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TyLe);
                    }
            }
            else
            {
            }
        }

        public void TinhTienNuoc_HoNgheo(bool ApGiaNuocCu, bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int Ky, int Nam, DateTime TuNgay, DateTime DenNgay, int GiaBieu, int TyLeSH, int TyLeSX, int TyLeDV, int TyLeHCSN, int TongDinhMuc, int DinhMucHN, int TieuThu, out int TienNuocCu, out string ChiTietCu, out int TienNuocMoi, out string ChiTietMoi, out int TieuThu_DieuChinhGia)
        {
            List<GiaNuoc2> lst = getDS();
            //check giảm giá
            checkExists_GiamGiaNuoc(Nam, Ky, GiaBieu, ref lst);

            int index = -1;
            TienNuocCu = TienNuocMoi = 0;
            ChiTietCu = ChiTietMoi = "";
            TieuThu_DieuChinhGia = 0;
            for (int i = 0; i < lst.Count; i++)
                if (TuNgay.Date < lst[i].NgayTangGia.Value.Date && lst[i].NgayTangGia.Value.Date < DenNgay.Date)
                {
                    index = i;
                }
                else
                    if (TuNgay.Date >= lst[i].NgayTangGia.Value.Date)
                    {
                        index = i;
                    }
            if (index != -1)
            {
                if (DenNgay.Date < new DateTime(2019, 11, 15))
                {
                    //int TieuThu_DieuChinhGia;
                    List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                    TienNuocCu = TinhTienNuoc_HoNgheo(DieuChinhGia, GiaDieuChinh, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, 0, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
                }
                else
                    if (TuNgay.Date < lst[index].NgayTangGia.Value.Date && lst[index].NgayTangGia.Value.Date < DenNgay.Date)
                    {
                        if (ApGiaNuocCu == false)
                        {
                            //int TieuThu_DieuChinhGia;
                            int TongSoNgay = (int)((DenNgay.Date - TuNgay.Date).TotalDays);

                            int SoNgayCu = (int)((lst[index].NgayTangGia.Value.Date - TuNgay.Date).TotalDays);
                            int TieuThuCu = (int)Math.Round((double)TieuThu * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TieuThuMoi = TieuThu - TieuThuCu;
                            int TongDinhMucCu = (int)Math.Round((double)TongDinhMuc * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TongDinhMucMoi = TongDinhMuc - TongDinhMucCu;
                            int DinhMucHN_Cu = 0, DinhMucHN_Moi = 0;
                            if (TuNgay.Date > new DateTime(2019, 11, 15))
                                if (TongDinhMucCu != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                    DinhMucHN_Cu = (int)Math.Round((double)TongDinhMucCu * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            if (TongDinhMucMoi != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                DinhMucHN_Moi = (int)Math.Round((double)TongDinhMucMoi * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            List<int> lstGiaNuocMoi = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                            //lần đầu áp dụng giá biểu 10, tổng áp giá mới luôn
                            if (TuNgay.Date < new DateTime(2019, 11, 15) && new DateTime(2019, 11, 15) < DenNgay.Date && GiaBieu == 10)
                                TienNuocCu = TinhTienNuoc_HoNgheo(DieuChinhGia, GiaDieuChinh, lstGiaNuocMoi, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, out ChiTietCu, out TieuThu_DieuChinhGia);
                            else
                                TienNuocCu = TinhTienNuoc_HoNgheo(DieuChinhGia, GiaDieuChinh, lstGiaNuocCu, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, out ChiTietCu, out TieuThu_DieuChinhGia);
                            TienNuocMoi = TinhTienNuoc_HoNgheo(DieuChinhGia, GiaDieuChinh, lstGiaNuocMoi, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucMoi, DinhMucHN_Moi, TieuThuMoi, out ChiTietMoi, out TieuThu_DieuChinhGia);
                        }
                        else
                        {
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            TienNuocCu = TinhTienNuoc_HoNgheo(DieuChinhGia, GiaDieuChinh, lstGiaNuocCu, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
                        }
                    }
                    else
                    {
                        //int TieuThu_DieuChinhGia;
                        List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                        TienNuocCu = TinhTienNuoc_HoNgheo(DieuChinhGia, GiaDieuChinh, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
                    }
            }
            else
            {

            }
        }

        public void TinhTienNuoc_TheoSoNgay(bool ApGiaNuocCu, bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int Ky, int Nam, DateTime TuNgay, DateTime DenNgay, int SoNgayCu, int GiaBieu, int TyLeSH, int TyLeSX, int TyLeDV, int TyLeHCSN, int TongDinhMuc, int DinhMucHN, int TieuThu, out int TienNuocCu, out string ChiTietCu, out int TienNuocMoi, out string ChiTietMoi, out int TieuThu_DieuChinhGia)
        {
            List<GiaNuoc2> lst=getDS();
            //check giảm giá
            checkExists_GiamGiaNuoc(Nam, Ky, GiaBieu, ref lst);

            int index = -1;
            TienNuocCu = TienNuocMoi = 0;
            ChiTietCu = ChiTietMoi = "";
            TieuThu_DieuChinhGia = 0;
            for (int i = 0; i < lst.Count; i++)
                if (TuNgay.Date < lst[i].NgayTangGia.Value.Date && lst[i].NgayTangGia.Value.Date < DenNgay.Date)
                {
                    index = i;
                }
                else
                    if (TuNgay.Date >= lst[i].NgayTangGia.Value.Date)
                    {
                        index = i;
                    }
            if (index != -1)
            {
                if (DenNgay.Date < new DateTime(2019, 11, 15))
                {
                    //int TieuThu_DieuChinhGia;
                    List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                    TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, 0, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
                }
                else
                    if (TuNgay.Date < lst[index].NgayTangGia.Value.Date && lst[index].NgayTangGia.Value.Date < DenNgay.Date)
                    {
                        if (ApGiaNuocCu == false)
                        {
                            //int TieuThu_DieuChinhGia;
                            int TongSoNgay = (int)((DenNgay.Date - TuNgay.Date).TotalDays);

                            int TieuThuCu = (int)Math.Round((double)TieuThu * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TieuThuMoi = TieuThu - TieuThuCu;
                            int TongDinhMucCu = (int)Math.Round((double)TongDinhMuc * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                            int TongDinhMucMoi = TongDinhMuc - TongDinhMucCu;
                            int DinhMucHN_Cu = 0, DinhMucHN_Moi = 0;
                            if (TuNgay.Date > new DateTime(2019, 11, 15))
                                if (TongDinhMucCu != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                    DinhMucHN_Cu = (int)Math.Round((double)TongDinhMucCu * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            if (TongDinhMucMoi != 0 && DinhMucHN != 0 && TongDinhMuc != 0)
                                DinhMucHN_Moi = (int)Math.Round((double)TongDinhMucMoi * DinhMucHN / TongDinhMuc, 0, MidpointRounding.AwayFromZero);
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            List<int> lstGiaNuocMoi = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                            //lần đầu áp dụng giá biểu 10, tổng áp giá mới luôn
                            if (TuNgay.Date < new DateTime(2019, 11, 15) && new DateTime(2019, 11, 15) < DenNgay.Date && GiaBieu == 10)
                                TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocMoi, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, out ChiTietCu, out TieuThu_DieuChinhGia);
                            else
                                TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocCu, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucCu, DinhMucHN_Cu, TieuThuCu, out ChiTietCu, out TieuThu_DieuChinhGia);
                            TienNuocMoi = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocMoi, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMucMoi, DinhMucHN_Moi, TieuThuMoi, out ChiTietMoi, out TieuThu_DieuChinhGia);
                        }
                        else
                        {
                            List<int> lstGiaNuocCu = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                            TienNuocCu = TinhTienNuoc(DieuChinhGia, GiaDieuChinh, lstGiaNuocCu, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
                        }
                    }
                    else
                    {
                        //int TieuThu_DieuChinhGia;
                        List<int> lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                        TienNuocCu = TinhTienNuoc(DieuChinhGia, 0, lstGiaNuoc, GiaBieu, TyLeSH, TyLeSX, TyLeDV, TyLeHCSN, TongDinhMuc, DinhMucHN, TieuThu, out ChiTietCu, out TieuThu_DieuChinhGia);
                    }
            }
            else
            {

            }
        }

        //truy thu

        public int TruyThu(string DanhBo, int Ky, int Nam, int GiaBieu, int SH, int SX, int DV, int HCSN, int DinhMuc, int TieuThu, out string ChiTiet)
        {
            try
            {
                string _chiTiet = "";
                int _tieuthu = 0;
                int _TongTien = 0;
                List<int> lstGiaNuoc = new List<int>();
                switch (Nam)
                {
                    case 2010:
                        lstGiaNuoc = lst2010;
                        break;
                    case 2011:
                        lstGiaNuoc = lst2011;
                        break;
                    case 2012:
                        lstGiaNuoc = lst2012;
                        break;
                    default:
                        foreach (GiaNuoc item in db.GiaNuocs.ToList())
                        {
                            lstGiaNuoc.Add(item.DonGia.Value);
                        }
                        break;
                }

                _TongTien = TinhTienNuoc(false, 0, lstGiaNuoc, GiaBieu, SH, SX, DV, HCSN, 0, DinhMuc, TieuThu, out _chiTiet, out _tieuthu);

                ChiTiet = _chiTiet;
                return _TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                return 0;
            }

        }

        //public int TruyThu(string DanhBo, int Ky, int Nam, int GiaBieu, int DinhMuc, int TieuThu, out string ChiTiet)
        //{
        //    try
        //    {
        //        string _chiTiet = "";
        //        int _TongTien = 0;
        //        HOADON hoadon = _cThuTien.Get(DanhBo, Ky, Nam);
        //        List<int> lstGiaNuoc = new List<int>();
        //        switch (Nam)
        //        {
        //            case 2010:
        //                lstGiaNuoc = lst2010;
        //                break;
        //            case 2011:
        //                lstGiaNuoc = lst2011;
        //                break;
        //            case 2012:
        //                lstGiaNuoc = lst2012;
        //                break;
        //            default:
        //                foreach (GiaNuoc item in db.GiaNuocs.ToList())
        //                {
        //                    lstGiaNuoc.Add(item.DonGia.Value);
        //                }
        //                break;
        //        }
        //        ///Table GiaNuoc được thiết lập theo bảng giá nước
        //        ///1. Đến 4m3/người/tháng
        //        ///2. Trên 4m3 đến 6m3/người/tháng
        //        ///3. Trên 6m3/người/tháng
        //        ///4. Đơn vị sản xuất
        //        ///5. Cơ quan, đoàn thể HCSN
        //        ///6. Đơn vị kinh doanh, dịch vụ
        //        ///List bắt đầu từ phần tử thứ 0

        //        switch (GiaBieu)
        //        {
        //            ///TƯ GIA
        //            case 11:
        //            case 21:///SH thuần túy
        //                if (TieuThu <= DinhMuc)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[0];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                }
        //                else
        //                    //if (!DieuChinhGia)
        //                    if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                    {
        //                        _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[1]);
        //                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                    }
        //                    else
        //                    {
        //                        _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
        //                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                    + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                    }
        //                //else
        //                //{
        //                //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                //                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            case 12:
        //            case 22:
        //            case 32:
        //            case 42:///SX thuần túy
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[3];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            case 13:
        //            case 23:
        //            case 33:
        //            case 43:///DV thuần túy
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[5];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            case 14:
        //            case 24:///SH + SX
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILESH == null && hoadon.TILESX == null)||(hoadon.TILESH == 0 && hoadon.TILESX == 0))
        //                    {
        //                        if (TieuThu <= DinhMuc)
        //                        {
        //                            _TongTien = TieuThu * lstGiaNuoc[0];
        //                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                        }
        //                        else
        //                        //if (!DieuChinhGia)
        //                        {
        //                            _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[3]);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                       + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                        }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                        //               + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        //}
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ SH + SX
        //                        if (hoadon.TILESH != null && hoadon.TILESX != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                            if (_SH <= DinhMuc)
        //                            {
        //                                _TongTien = _SH * lstGiaNuoc[0];
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                            }
        //                            else
        //                                //if (!DieuChinhGia)
        //                                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                                }
        //                                else
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                                + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                                }
        //                            //else
        //                            //{
        //                            //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                            //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            //}
        //                            _TongTien += _SX * lstGiaNuoc[3];
        //                            _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                        }
        //                break;
        //            case 15:
        //            case 25:///SH + DV
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILESH == null && hoadon.TILEDV == null)||(hoadon.TILESH == 0 && hoadon.TILEDV == 0))
        //                    {
        //                        if (TieuThu <= DinhMuc)
        //                        {
        //                            _TongTien = TieuThu * lstGiaNuoc[0];
        //                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                        }
        //                        else
        //                        //if (!DieuChinhGia)
        //                        {
        //                            _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[5]);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                        //                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        //}
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ SH + DV
        //                        if (hoadon.TILESH != null && hoadon.TILEDV != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                            if (_SH <= DinhMuc)
        //                            {
        //                                _TongTien = _SH * lstGiaNuoc[0];
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                            }
        //                            else
        //                                //if (!DieuChinhGia)
        //                                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                                }
        //                                else
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                                + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                                }
        //                            //else
        //                            //{
        //                            //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                            //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            //}
        //                            _TongTien += _DV * lstGiaNuoc[5];
        //                            _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        }
        //                break;
        //            case 16:
        //            case 26:///SH + SX + DV
        //                if (hoadon != null)
        //                    ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
        //                    if ((hoadon.TILESX != null && hoadon.TILEDV != null && hoadon.TILESH == null)||(hoadon.TILESX != 0 && hoadon.TILEDV != 0 && hoadon.TILESH == 0))
        //                    {
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        _TongTien = (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                    else
        //                        ///Nếu có đủ 3 tỉ lệ SH + SX + DV
        //                        if (hoadon.TILESX != null && hoadon.TILEDV != null && hoadon.TILESH != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                            int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                            if (_SH <= DinhMuc)
        //                            {
        //                                _TongTien = _SH * lstGiaNuoc[0];
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                            }
        //                            else
        //                                //if (!DieuChinhGia)
        //                                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                                }
        //                                else
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                                + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                                }
        //                            //else
        //                            //{
        //                            //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                            //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            //}
        //                            _TongTien += (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                            _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                         + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        }
        //                break;
        //            case 17:
        //            case 27:///SH ĐB
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[0];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            case 18:
        //            case 28:
        //            case 38:///SH + HCSN
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILESH == null && hoadon.TILEHCSN == null)||(hoadon.TILESH == 0&& hoadon.TILEHCSN ==0))
        //                    {
        //                        if (TieuThu <= DinhMuc)
        //                        {
        //                            _TongTien = TieuThu * lstGiaNuoc[0];
        //                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                        }
        //                        else
        //                        //if (!DieuChinhGia)
        //                        {
        //                            _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[4]);
        //                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
        //                        }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                        //                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        //}
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ SH + HCSN
        //                        if (hoadon.TILESH != null && hoadon.TILEHCSN != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                            if (_SH <= DinhMuc)
        //                            {
        //                                _TongTien = _SH * lstGiaNuoc[0];
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                            }
        //                            else
        //                                //if (!DieuChinhGia)
        //                                if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                                }
        //                                else
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
        //                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                                + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                                }
        //                            //else
        //                            //{
        //                            //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                            //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            //}
        //                            _TongTien += _HCSN * lstGiaNuoc[4];
        //                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
        //                        }
        //                break;
        //            case 19:
        //            case 29:
        //            case 39:///SH + HCSN + SX + DV
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        if (_SH <= DinhMuc)
        //                        {
        //                            _TongTien = _SH * lstGiaNuoc[0];
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                        }
        //                        else
        //                            //if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                            {
        //                                _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                            }
        //                            else
        //                            {
        //                                _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                            }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                        //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        //}
        //                        _TongTien += (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                break;
        //            ///TẬP THỂ
        //            //case 21:///SH thuần túy
        //            //    if (TieuThu <= DinhMuc)
        //            //        _TongTien = TieuThu * lstGiaNuoc[0];
        //            //    else
        //            //        if (TieuThu - DinhMuc <= DinhMuc / 2)
        //            //            _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[1]);
        //            //        else
        //            //            _TongTien = (DinhMuc * lstGiaNuoc[0]) + (DinhMuc / 2 * lstGiaNuoc[1]) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2]);
        //            //    break;
        //            //case 22:///SX thuần túy
        //            //    _TongTien = TieuThu * lstGiaNuoc[3];
        //            //    break;
        //            //case 23:///DV thuần túy
        //            //    _TongTien = TieuThu * lstGiaNuoc[5];
        //            //    break;
        //            //case 24:///SH + SX
        //            //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
        //            //    if (hoadon != null)
        //            //        ///Nếu không có tỉ lệ
        //            //        if (hoadon.TILESH==null && hoadon.TILESX==null)
        //            //        {

        //            //        }
        //            //    break;
        //            //case 25:///SH + DV

        //            //    break;
        //            //case 26:///SH + SX + DV

        //            //    break;
        //            //case 27:///SH ĐB
        //            //    _TongTien = TieuThu * lstGiaNuoc[0];
        //            //    break;
        //            //case 28:///SH + HCSN

        //            //    break;
        //            //case 29:///SH + HCSN + SX + DV

        //            //    break;
        //            ///CƠ QUAN
        //            case 31:///SHVM thuần túy
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[4];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            //case 32:///SX
        //            //    _TongTien = TieuThu * lstGiaNuoc[3];
        //            //    break;
        //            //case 33:///DV
        //            //    _TongTien = TieuThu * lstGiaNuoc[5];
        //            //    break;
        //            case 34:///HCSN + SX
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILEHCSN == null && hoadon.TILESX == null)||(hoadon.TILEHCSN == 0 && hoadon.TILESX == 0))
        //                    {
        //                        _TongTien = TieuThu * lstGiaNuoc[3];
        //                        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ
        //                        if (hoadon.TILEHCSN != null && hoadon.TILESX != null)
        //                        {
        //                            int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                            int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                            _TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]);
        //                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                        }
        //                break;
        //            case 35:///HCSN + DV

        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILEHCSN == null && hoadon.TILESX == null)||(hoadon.TILEHCSN == 0 && hoadon.TILESX == 0))
        //                    {
        //                        _TongTien = TieuThu * lstGiaNuoc[5];
        //                        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ
        //                        if (hoadon.TILEHCSN != null && hoadon.TILEDV != null)
        //                        {
        //                            int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                            int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                            _TongTien = (_HCSN * lstGiaNuoc[4]) + (_DV * lstGiaNuoc[5]);
        //                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        }
        //                break;
        //            case 36:///HCSN + SX + DV

        //                if (hoadon != null)
        //                    if (hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        _TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                break;
        //            //case 38:///SH + HCSN

        //            //    break;
        //            //case 39:///SH + HCSN + SX + DV

        //            //    break;
        //            ///NƯỚC NGOÀI
        //            case 41:///SHVM thuần túy
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[2];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            //case 42:///SX
        //            //    _TongTien = TieuThu * lstGiaNuoc[3];
        //            //    break;
        //            //case 43:///DV
        //            //    _TongTien = TieuThu * lstGiaNuoc[5];
        //            //    break;
        //            case 44:///SH + SX
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILESX != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        _TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                    }
        //                break;
        //            case 45:///SH + DV
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        _TongTien = (_SH * lstGiaNuoc[2]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                break;
        //            case 46:///SH + SX + DV

        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        _TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                break;
        //            ///BÁN SỈ
        //            case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
        //                //if (TieuThu <= DinhMuc)
        //                //    _TongTien = TieuThu * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100));
        //                //else
        //                //    if (TieuThu - DinhMuc <= DinhMuc / 2)
        //                //        _TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100)));
        //                //    else
        //                //        _TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2] - (lstGiaNuoc[2] * 10 / 100)));
        //                if (TieuThu <= DinhMuc)
        //                {
        //                    _TongTien = TieuThu * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                }
        //                else
        //                    //if (!DieuChinhGia)
        //                    if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                    {
        //                        _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                    }
        //                    else
        //                    {
        //                        _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                    }
        //                //else
        //                //{
        //                //    _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                //                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //}
        //                //_TongTien -= _TongTien * 10 / 100;
        //                break;
        //            case 52:///sỉ khu công nghiệp
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100));
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //}
        //                //_TongTien -= _TongTien * 10 / 100;
        //                break;
        //            case 53:///sỉ KD - TM
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //}
        //                //_TongTien -= _TongTien * 10 / 100;
        //                break;
        //            case 54:///sỉ HCSN
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100));
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //}
        //                //_TongTien -= _TongTien * 10 / 100;
        //                break;
        //            case 59:///sỉ phức tạp
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        if (_SH <= DinhMuc)
        //                        {
        //                            _TongTien = _SH * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100);
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                            //if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                            {
        //                                _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                            }
        //                            else
        //                            {
        //                                _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + "\r\n"
        //                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                            }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                        //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        //}
        //                        _TongTien += (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                        _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                        //_TongTien -= _TongTien * 10 / 100;
        //                    }
        //                break;
        //            case 68:///SH giá sỉ - KD giá lẻ
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        if (_SH <= DinhMuc)
        //                        {
        //                            _TongTien = _SH * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100);
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                            //if (!DieuChinhGia)
        //                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                            {
        //                                _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                            }
        //                            else
        //                            {
        //                                _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                                _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))) + "\r\n"
        //                                     + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                            }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                        //         + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        //}
        //                        _TongTien += _DV * lstGiaNuoc[5];
        //                        _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        //_TongTien -= _TongTien * 10 / 100;
        //                    }
        //                break;
        //            default:
        //                _chiTiet = "";
        //                _TongTien = 0;
        //                break;
        //        }

        //        ChiTiet = _chiTiet;
        //        return _TongTien;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        ChiTiet = "";
        //        return 0;
        //    }

        //}

        public int TruyThu(string DanhBo, int Ky, int Nam, int GiaBieu, int SH, int SX, int DV, int HCSN, int DinhMucHN, int DinhMuc, int TieuThu, out string ChiTiet)
        {
            try
            {
                string _chiTiet = "";
                int _tieuthu = 0;
                int _TongTien = 0;
                HOADON hoadon = _cThuTien.Get(DanhBo, Ky, Nam);
                List<int> lstGiaNuoc = new List<int>();
                switch (Nam)
                {
                    case 2010:
                        lstGiaNuoc = lst2010;
                        break;
                    case 2011:
                        lstGiaNuoc = lst2011;
                        break;
                    case 2012:
                        lstGiaNuoc = lst2012;
                        break;
                    case 2019:
                        if (Ky <= 11)
                            lstGiaNuoc = lst2013;
                        else
                            lstGiaNuoc = lst2019;
                        //foreach (GiaNuoc item in db.GiaNuocs.ToList())
                        //{
                        //    lstGiaNuoc.Add(item.DonGia.Value);
                        //}
                        break;
                }

                _TongTien = TinhTienNuoc(false, 0, lstGiaNuoc, GiaBieu, SH, SX, DV, HCSN, DinhMucHN, DinhMuc, TieuThu, out _chiTiet, out _tieuthu);

                ChiTiet = _chiTiet;
                return _TongTien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChiTiet = "";
                return 0;
            }

        }

        //public int TruyThu(string DanhBo, int Ky, int Nam, int GiaBieu, int DinhMucHN, int DinhMuc, int TieuThu, out string ChiTiet)
        //{
        //    try
        //    {
        //        string _chiTiet = "";
        //        int _TongTien = 0;
        //        HOADON hoadon = _cThuTien.Get(DanhBo, Ky, Nam);
        //        List<int> lstGiaNuoc = new List<int>();
        //        switch (Nam)
        //        {
        //            case 2010:
        //                lstGiaNuoc = lst2010;
        //                break;
        //            case 2011:
        //                lstGiaNuoc = lst2011;
        //                break;
        //            case 2012:
        //                lstGiaNuoc = lst2012;
        //                break;
        //            case 2019:
        //                if (Ky <= 11)
        //                    lstGiaNuoc = lst2013;
        //                else
        //                    lstGiaNuoc = lst2019;
        //                //foreach (GiaNuoc item in db.GiaNuocs.ToList())
        //                //{
        //                //    lstGiaNuoc.Add(item.DonGia.Value);
        //                //}
        //                break;
        //        }
        //        ///Table GiaNuoc được thiết lập theo bảng giá nước
        //        ///1. Đến 4m3/người/tháng
        //        ///2. Trên 4m3 đến 6m3/người/tháng
        //        ///3. Trên 6m3/người/tháng
        //        ///4. Đơn vị sản xuất
        //        ///5. Cơ quan, đoàn thể HCSN
        //        ///6. Đơn vị kinh doanh, dịch vụ
        //        ///7. Hộ nghèo, cận nghèo
        //        ///List bắt đầu từ phần tử thứ 0

        //        switch (GiaBieu)
        //        {
        //            //hộ nghèo
        //            case 10:
        //                if (TieuThu <= DinhMucHN)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[6];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                }
        //                else
        //                    //if (!DieuChinhGia)
        //                    if (TieuThu - DinhMucHN <= Math.Round((double)DinhMucHN / 2))
        //                    {
        //                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                    + ((TieuThu - DinhMucHN) * lstGiaNuoc[1]);
        //                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                    }
        //                    else
        //                    {
        //                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) * lstGiaNuoc[1])
        //                                    + ((TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2)) * lstGiaNuoc[2]);
        //                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + (int)Math.Round((double)DinhMucHN / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                    + (TieuThu - DinhMucHN - (int)Math.Round((double)DinhMucHN / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                    }
        //                break;
        //            ///TƯ GIA
        //            case 11:
        //            case 21:///SH thuần túy
        //                if (TieuThu <= DinhMucHN)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[6];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                }
        //                else
        //                    if (TieuThu - DinhMucHN <= DinhMuc)
        //                    {
        //                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                    + (TieuThu * lstGiaNuoc[0]);
        //                        _chiTiet = (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                    + TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                    }
        //                    else
        //                        //if (!DieuChinhGia)
        //                        if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2))
        //                        {
        //                            _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                        + (DinhMuc * lstGiaNuoc[0])
        //                                        + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                        }
        //                        else
        //                        {
        //                            _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                        + (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) * lstGiaNuoc[1])
        //                                        + ((TieuThu - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) * lstGiaNuoc[2]);
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                        + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                        }
        //                //else
        //                //{
        //                //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                //                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            case 12:
        //            case 22:
        //            case 32:
        //            case 42:///SX thuần túy
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[3];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            case 13:
        //            case 23:
        //            case 33:
        //            case 43:///DV thuần túy
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[5];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            case 14:
        //            case 24:///SH + SX
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILESH == null && hoadon.TILESX == null)||(hoadon.TILESH == 0 && hoadon.TILESX == 0))
        //                    {
        //                        if (TieuThu <= DinhMucHN)
        //                        {
        //                            _TongTien = TieuThu * lstGiaNuoc[6];
        //                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                        }
        //                        else
        //                            if (TieuThu - DinhMucHN <= DinhMuc)
        //                            {
        //                                _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                            + ((TieuThu - DinhMucHN) * lstGiaNuoc[0]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                            }
        //                            else
        //                            //if (!DieuChinhGia)
        //                            {
        //                                _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                            + (DinhMuc * lstGiaNuoc[0])
        //                                            + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[3]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                           + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                            }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                        //               + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        //}
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ SH + SX
        //                        if (hoadon.TILESH != null && hoadon.TILESX != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);

        //                            if (_SH <= DinhMucHN)
        //                            {
        //                                _TongTien = _SH * lstGiaNuoc[6];
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                            }
        //                            else
        //                                if (_SH - DinhMucHN <= DinhMuc)
        //                                {
        //                                    _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                + ((_SH - DinhMucHN) * lstGiaNuoc[0]);
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                                }
        //                                else
        //                                    //if (!DieuChinhGia)
        //                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2))
        //                                    {
        //                                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                    + (DinhMuc * lstGiaNuoc[0])
        //                                                    + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                    + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                                    }
        //                                    else
        //                                    {
        //                                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                    + (DinhMuc * lstGiaNuoc[0])
        //                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) * lstGiaNuoc[1])
        //                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) * lstGiaNuoc[2]);
        //                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                    + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                                    + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                                    }
        //                            //else
        //                            //{
        //                            //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                            //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            //}
        //                            _TongTien += _SX * lstGiaNuoc[3];
        //                            _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                        }
        //                break;
        //            case 15:
        //            case 25:///SH + DV
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILESH == null && hoadon.TILEDV == null)||(hoadon.TILESH == 0 && hoadon.TILEDV == 0))
        //                    {
        //                        if (TieuThu <= DinhMucHN)
        //                        {
        //                            _TongTien = TieuThu * lstGiaNuoc[6];
        //                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                        }
        //                        else
        //                            if (TieuThu - DinhMucHN <= DinhMuc)
        //                            {
        //                                _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                            + ((TieuThu - DinhMucHN) * lstGiaNuoc[0]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                            }
        //                            else
        //                            //if (!DieuChinhGia)
        //                            {
        //                                _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                            + (DinhMuc * lstGiaNuoc[0])
        //                                            + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[5]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                            }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                        //                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        //}
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ SH + DV
        //                        if (hoadon.TILESH != null && hoadon.TILEDV != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);

        //                            if (_SH <= DinhMucHN)
        //                            {
        //                                _TongTien = _SH * lstGiaNuoc[6];
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                            }
        //                            else
        //                                if (_SH - DinhMucHN <= DinhMuc)
        //                                {
        //                                    _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                + ((_SH - DinhMucHN) * lstGiaNuoc[0]);
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                                }
        //                                else
        //                                    //if (!DieuChinhGia)
        //                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2))
        //                                    {
        //                                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                    + (DinhMuc * lstGiaNuoc[0])
        //                                                    + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                    + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                                    }
        //                                    else
        //                                    {
        //                                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                    + (DinhMuc * lstGiaNuoc[0])
        //                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) * lstGiaNuoc[1])
        //                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) * lstGiaNuoc[2]);
        //                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                    + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                                    + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                                    }
        //                            //else
        //                            //{
        //                            //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                            //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            //}
        //                            _TongTien += _DV * lstGiaNuoc[5];
        //                            _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        }
        //                break;
        //            case 16:
        //            case 26:///SH + SX + DV
        //                if (hoadon != null)
        //                    ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
        //                    if ((hoadon.TILESX != null && hoadon.TILEDV != null && hoadon.TILESH == null)||(hoadon.TILESX != 0 && hoadon.TILEDV != 0 && hoadon.TILESH == 0))
        //                    {
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        _TongTien = (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                    else
        //                        ///Nếu có đủ 3 tỉ lệ SH + SX + DV
        //                        if (hoadon.TILESX != null && hoadon.TILEDV != null && hoadon.TILESH != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                            int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);

        //                            if (_SH <= DinhMucHN)
        //                            {
        //                                _TongTien = _SH * lstGiaNuoc[6];
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                            }
        //                            else
        //                                if (_SH - DinhMucHN <= DinhMuc)
        //                                {
        //                                    _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                + ((_SH - DinhMucHN) * lstGiaNuoc[0]);
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                                }
        //                                else
        //                                    //if (!DieuChinhGia)
        //                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2))
        //                                    {
        //                                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                    + (DinhMuc * lstGiaNuoc[0])
        //                                                    + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
        //                                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                    + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                                    }
        //                                    else
        //                                    {
        //                                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                    + (DinhMuc * lstGiaNuoc[0])
        //                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) * lstGiaNuoc[1])
        //                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) * lstGiaNuoc[2]);
        //                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
        //                                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                    + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                                    + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                                    }
        //                            //else
        //                            //{
        //                            //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                            //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            //}
        //                            _TongTien += (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                            _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                         + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        }
        //                break;
        //            case 17:
        //            case 27:///SH ĐB
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[0];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            case 18:
        //            case 28:
        //            case 38:///SH + HCSN
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILESH == null && hoadon.TILEHCSN == null)||(hoadon.TILESH == 0&& hoadon.TILEHCSN ==0))
        //                    {
        //                        if (TieuThu <= DinhMucHN)
        //                        {
        //                            _TongTien = TieuThu * lstGiaNuoc[6];
        //                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                        }
        //                        else
        //                            if (TieuThu - DinhMucHN <= DinhMuc)
        //                            {
        //                                _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                            + ((TieuThu - DinhMucHN) * lstGiaNuoc[0]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                            }
        //                            else
        //                            //if (!DieuChinhGia)
        //                            {
        //                                _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                            + (DinhMuc * lstGiaNuoc[0])
        //                                            + ((TieuThu - DinhMucHN - DinhMuc) * lstGiaNuoc[4]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6])
        //                                            + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                            + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
        //                            }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                        //                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        //}
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ SH + HCSN
        //                        if (hoadon.TILESH != null && hoadon.TILEHCSN != null)
        //                        {
        //                            int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                            int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);

        //                            if (_SH <= DinhMucHN)
        //                            {
        //                                _TongTien = _SH * lstGiaNuoc[6];
        //                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                            }
        //                            else
        //                                if (_SH - DinhMucHN <= DinhMuc)
        //                                {
        //                                    _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                + ((_SH - DinhMucHN) * lstGiaNuoc[0]);
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                                }
        //                                else
        //                                    //if (!DieuChinhGia)
        //                                    if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2))
        //                                    {
        //                                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                    + (DinhMuc * lstGiaNuoc[0])
        //                                                    + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                    + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                                    }
        //                                    else
        //                                    {
        //                                        _TongTien = (DinhMucHN * lstGiaNuoc[6])
        //                                                    + (DinhMuc * lstGiaNuoc[0])
        //                                                    + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) * lstGiaNuoc[1])
        //                                                    + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) * lstGiaNuoc[2]);
        //                                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                    + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                    + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                                    + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                                    }
        //                            //else
        //                            //{
        //                            //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                            //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                            //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                            //}
        //                            _TongTien += _HCSN * lstGiaNuoc[4];
        //                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
        //                        }
        //                break;
        //            case 19:
        //            case 29:
        //            case 39:///SH + HCSN + SX + DV
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);

        //                        if (_SH <= DinhMucHN)
        //                        {
        //                            _TongTien = _SH * lstGiaNuoc[6];
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]);
        //                        }
        //                        else
        //                            if (_SH - DinhMucHN <= DinhMuc)
        //                            {
        //                                _TongTien = (DinhMucHN * lstGiaNuoc[6]) + ((_SH - DinhMucHN) * lstGiaNuoc[0]);
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                            + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
        //                            }
        //                            else
        //                                //if (!DieuChinhGia)
        //                                if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2))
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0])
        //                                                + ((_SH - DinhMucHN - DinhMuc) * lstGiaNuoc[1]);
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
        //                                }
        //                                else
        //                                {
        //                                    _TongTien = (DinhMuc * lstGiaNuoc[0])
        //                                                + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) * lstGiaNuoc[1])
        //                                                + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) * lstGiaNuoc[2]);
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[6]) + "\r\n"
        //                                                + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                                                + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
        //                                                + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                                }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
        //                        //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                        //}
        //                        _TongTien += (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                break;
        //            ///TẬP THỂ
        //            //case 21:///SH thuần túy
        //            //    if (TieuThu <= DinhMuc)
        //            //        _TongTien = TieuThu * lstGiaNuoc[0];
        //            //    else
        //            //        if (TieuThu - DinhMuc <= DinhMuc / 2)
        //            //            _TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[1]);
        //            //        else
        //            //            _TongTien = (DinhMuc * lstGiaNuoc[0]) + (DinhMuc / 2 * lstGiaNuoc[1]) + ((TieuThu - DinhMuc - DinhMuc / 2) * lstGiaNuoc[2]);
        //            //    break;
        //            //case 22:///SX thuần túy
        //            //    _TongTien = TieuThu * lstGiaNuoc[3];
        //            //    break;
        //            //case 23:///DV thuần túy
        //            //    _TongTien = TieuThu * lstGiaNuoc[5];
        //            //    break;
        //            //case 24:///SH + SX
        //            //    hoadon = _cThuTien.GetMoiNhat(DanhBo);
        //            //    if (hoadon != null)
        //            //        ///Nếu không có tỉ lệ
        //            //        if (hoadon.TILESH==null && hoadon.TILESX==null)
        //            //        {

        //            //        }
        //            //    break;
        //            //case 25:///SH + DV

        //            //    break;
        //            //case 26:///SH + SX + DV

        //            //    break;
        //            //case 27:///SH ĐB
        //            //    _TongTien = TieuThu * lstGiaNuoc[0];
        //            //    break;
        //            //case 28:///SH + HCSN

        //            //    break;
        //            //case 29:///SH + HCSN + SX + DV

        //            //    break;
        //            ///CƠ QUAN
        //            case 31:///SHVM thuần túy
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[4];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            //case 32:///SX
        //            //    _TongTien = TieuThu * lstGiaNuoc[3];
        //            //    break;
        //            //case 33:///DV
        //            //    _TongTien = TieuThu * lstGiaNuoc[5];
        //            //    break;
        //            case 34:///HCSN + SX
        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILEHCSN == null && hoadon.TILESX == null)||(hoadon.TILEHCSN == 0 && hoadon.TILESX == 0))
        //                    {
        //                        _TongTien = TieuThu * lstGiaNuoc[3];
        //                        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ
        //                        if (hoadon.TILEHCSN != null && hoadon.TILESX != null)
        //                        {
        //                            int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                            int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                            _TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]);
        //                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                        }
        //                break;
        //            case 35:///HCSN + DV

        //                if (hoadon != null)
        //                    ///Nếu không có tỉ lệ
        //                    if ((hoadon.TILEHCSN == null && hoadon.TILESX == null)||(hoadon.TILEHCSN == 0 && hoadon.TILESX == 0))
        //                    {
        //                        _TongTien = TieuThu * lstGiaNuoc[5];
        //                        _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                    else
        //                        ///Nếu có tỉ lệ
        //                        if (hoadon.TILEHCSN != null && hoadon.TILEDV != null)
        //                        {
        //                            int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                            int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                            _TongTien = (_HCSN * lstGiaNuoc[4]) + (_DV * lstGiaNuoc[5]);
        //                            _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        }
        //                break;
        //            case 36:///HCSN + SX + DV

        //                if (hoadon != null)
        //                    if (hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        _TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                break;
        //            //case 38:///SH + HCSN

        //            //    break;
        //            //case 39:///SH + HCSN + SX + DV

        //            //    break;
        //            ///NƯỚC NGOÀI
        //            case 41:///SHVM thuần túy
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * lstGiaNuoc[2];
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * GiaDieuChinh;
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
        //                //}
        //                break;
        //            //case 42:///SX
        //            //    _TongTien = TieuThu * lstGiaNuoc[3];
        //            //    break;
        //            //case 43:///DV
        //            //    _TongTien = TieuThu * lstGiaNuoc[5];
        //            //    break;
        //            case 44:///SH + SX
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILESX != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        _TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
        //                    }
        //                break;
        //            case 45:///SH + DV
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        _TongTien = (_SH * lstGiaNuoc[2]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                break;
        //            case 46:///SH + SX + DV

        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);
        //                        _TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
        //                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
        //                                    + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
        //                                    + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                    }
        //                break;
        //            ///BÁN SỈ
        //            case 51:///sỉ khu dân cư - Giảm % tiền nước cho ban quản lý chung cư
        //                //if (TieuThu <= DinhMuc)
        //                //    _TongTien = TieuThu * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100));
        //                //else
        //                //    if (TieuThu - DinhMuc <= DinhMuc / 2)
        //                //        _TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100)));
        //                //    else
        //                //        _TongTien = (DinhMuc * (lstGiaNuoc[0] - (lstGiaNuoc[0] * 10 / 100))) + (DinhMuc / 2 * (lstGiaNuoc[1] - (lstGiaNuoc[1] * 10 / 100))) + ((TieuThu - DinhMuc - DinhMuc / 2) * (lstGiaNuoc[2] - (lstGiaNuoc[2] * 10 / 100)));
        //                if (TieuThu <= DinhMucHN)
        //                {
        //                    _TongTien = TieuThu * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
        //                }
        //                else
        //                    if (TieuThu - DinhMucHN <= DinhMuc)
        //                    {
        //                        _TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                                    + ((TieuThu - DinhMucHN) * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                        _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                    + (TieuThu - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                    }
        //                    else
        //                        //if (!DieuChinhGia)
        //                        if (TieuThu - DinhMucHN - DinhMuc <= Math.Round((double)(DinhMucHN + DinhMuc) / 2))
        //                        {
        //                            _TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                                        + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                        + ((TieuThu - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                        {
        //                            _TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                                        + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                        + ((int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
        //                                        + ((TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                            _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + "\r\n"
        //                                        + (TieuThu - DinhMucHN - DinhMuc - (int)Math.Round((double)(DinhMucHN + DinhMuc) / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                        }
        //                //else
        //                //{
        //                //    _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                //                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //}
        //                //_TongTien -= _TongTien * 10 / 100;
        //                break;
        //            case 52:///sỉ khu công nghiệp
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100));
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //}
        //                //_TongTien -= _TongTien * 10 / 100;
        //                break;
        //            case 53:///sỉ KD - TM
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //}
        //                //_TongTien -= _TongTien * 10 / 100;
        //                break;
        //            case 54:///sỉ HCSN
        //                //if (!DieuChinhGia)
        //                {
        //                    _TongTien = TieuThu * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100);
        //                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100));
        //                }
        //                //else
        //                //{
        //                //    _TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100);
        //                //    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                //}
        //                //_TongTien -= _TongTien * 10 / 100;
        //                break;
        //            case 58:
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);

        //                        _TongTien += (_SH * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                    + (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100))
        //                                    + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100))
        //                                    + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                        _chiTiet += _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                    }
        //                break;
        //            case 59:///sỉ phức tạp
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEHCSN != null && hoadon.TILESX != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _HCSN = (int)Math.Round((double)TieuThu * hoadon.TILEHCSN.Value / 100);
        //                        int _SX = (int)Math.Round((double)TieuThu * hoadon.TILESX.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);

        //                        if (_SH <= DinhMucHN)
        //                        {
        //                            _TongTien = _SH * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                            if (_SH - DinhMucHN <= DinhMuc)
        //                            {
        //                                _TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                                            + ((_SH - DinhMucHN) * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                            + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                            }
        //                            else
        //                                //if (!DieuChinhGia)
        //                                if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    _TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                                + ((_SH - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                                }
        //                                else
        //                                {
        //                                    _TongTien = (DinhMucHN * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100))
        //                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                                + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
        //                                                + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                                }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                        //                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        //}
        //                        _TongTien += (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + (_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                        _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * _GiamTienNuoc / 100)) + "\r\n"
        //                                     + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * _GiamTienNuoc / 100));
        //                        //_TongTien -= _TongTien * 10 / 100;
        //                    }
        //                break;
        //            case 68:///SH giá sỉ - KD giá lẻ
        //                if (hoadon != null)
        //                    if (hoadon.TILESH != null && hoadon.TILEDV != null)
        //                    {
        //                        int _SH = (int)Math.Round((double)TieuThu * hoadon.TILESH.Value / 100);
        //                        int _DV = (int)Math.Round((double)TieuThu * hoadon.TILEDV.Value / 100);

        //                        if (_SH <= DinhMucHN)
        //                        {
        //                            _TongTien = _SH * (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100);
        //                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100));
        //                        }
        //                        else
        //                            if (_SH - DinhMucHN <= DinhMuc)
        //                            {
        //                                _TongTien = (DinhMucHN * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                            + ((_SH - DinhMucHN) * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                                _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                            + (_SH - DinhMucHN) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100));
        //                            }
        //                            else
        //                                //if (!DieuChinhGia)
        //                                if (_SH - DinhMucHN - DinhMuc <= Math.Round((double)DinhMuc / 2))
        //                                {
        //                                    _TongTien = (DinhMucHN * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                                + ((_SH - DinhMucHN - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + (_SH - DinhMucHN - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100));
        //                                }
        //                                else
        //                                {
        //                                    _TongTien = (DinhMucHN * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                                + (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100))
        //                                                + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100))
        //                                                + ((_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                                    _chiTiet = DinhMucHN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[6] - lstGiaNuoc[6] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * _GiamTienNuoc / 100)) + "\r\n"
        //                                                + (_SH - DinhMucHN - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * _GiamTienNuoc / 100));
        //                                }
        //                        //else
        //                        //{
        //                        //    _TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        //    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * _GiamTienNuoc / 100)) + "\r\n"
        //                        //         + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * _GiamTienNuoc / 100));
        //                        //}
        //                        _TongTien += _DV * lstGiaNuoc[5];
        //                        _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
        //                        //_TongTien -= _TongTien * 10 / 100;
        //                    }
        //                break;
        //            default:
        //                _chiTiet = "";
        //                _TongTien = 0;
        //                break;
        //        }

        //        ChiTiet = _chiTiet;
        //        return _TongTien;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        ChiTiet = "";
        //        return 0;
        //    }

        //}

        List<int> lstBVMT2010 = new List<int> { 400, 800, 900, 2000, 800 };

        public int TinhPhiBMVT2010(int Nam, int GiaBieu, int DinhMuc, int TieuThu)
        {
            List<int> lstPhiBVMT = new List<int>();
            switch (Nam)
            {
                case 2010:
                    lstPhiBVMT = lstBVMT2010;
                    break;
            }

            int PhiBVMT = 0;

            if (lstPhiBVMT.Count > 0)
                switch (GiaBieu)
                {
                    case 11:
                        if (TieuThu <= DinhMuc)
                        {
                            PhiBVMT = TieuThu * lstPhiBVMT[0];
                        }
                        else
                        {
                            PhiBVMT = (DinhMuc * lstPhiBVMT[0]) + ((TieuThu - DinhMuc) * lstPhiBVMT[1]);
                        }
                        break;
                    case 12:
                    case 14:
                        PhiBVMT = TieuThu * lstPhiBVMT[2];
                        break;
                    case 13:
                    case 15:
                        PhiBVMT = TieuThu * lstPhiBVMT[3];
                        break;
                    case 31:
                        PhiBVMT = TieuThu * lstPhiBVMT[4];
                        break;
                };
            return PhiBVMT;
        }

        public void updateChiTiet(ref string main_value, string update_value)
        {
            if (main_value == "")
                main_value = update_value;
            else
                main_value += "\r\n" + update_value;
        }

        public int getDonGiaCaoNhat(List<int> lstGiaNuoc, int GiaBieu)
        {
            try
            {
                switch (GiaBieu)
                {
                    case 10:
                    case 11:
                        return lstGiaNuoc[2];
                    case 12:
                    case 14:
                    case 32:
                        return lstGiaNuoc[3];
                    case 15:
                        return lstGiaNuoc[5];
                    default:
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int getDonGiaCaoNhat(int Ky, int Nam, int GiaBieu)
        {
            List<GiaNuoc2> lst = getDS();
            int index = -1;
            for (int i = 0; i < lst.Count; i++)
                if (Nam == 2019)
                {
                    if (Ky == 12)
                        index = i;
                    else
                        index = i - 1;
                }
                else
                    if (Nam == lst[i].Name)
                    {
                        index = i;
                    }

            if (index != -1)
            {
                List<int> lstGiaNuoc = new List<int>();
                lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                return getDonGiaCaoNhat(lstGiaNuoc, GiaBieu);
            }
            else
            {
                return 0;
            }
        }

        public int getDonGiaCaoNhat(DateTime TuNgay, DateTime DenNgay, int GiaBieu)
        {
            List<GiaNuoc2> lst = getDS();
            int index = -1;
            for (int i = 0; i < lst.Count; i++)
                if (TuNgay.Date < lst[i].NgayTangGia.Value.Date && lst[i].NgayTangGia.Value.Date < DenNgay.Date)
                {
                    index = i;
                }
                else
                    if (TuNgay.Date >= lst[i].NgayTangGia.Value.Date)
                    {
                        index = i;
                    }
            if (index != -1)
            {
                List<int> lstGiaNuoc = new List<int>();
                if (DenNgay.Date < new DateTime(2019, 11, 15))
                {
                    lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                }
                else
                    if (TuNgay.Date < lst[index].NgayTangGia.Value.Date && lst[index].NgayTangGia.Value.Date < DenNgay.Date)
                    {
                        lstGiaNuoc = new List<int> { lst[index - 1].SHTM.Value, lst[index - 1].SHVM1.Value, lst[index - 1].SHVM2.Value, lst[index - 1].SX.Value, lst[index - 1].HCSN.Value, lst[index - 1].KDDV.Value, lst[index - 1].SHN.Value };
                    }
                    else
                    {
                        lstGiaNuoc = new List<int> { lst[index].SHTM.Value, lst[index].SHVM1.Value, lst[index].SHVM2.Value, lst[index].SX.Value, lst[index].HCSN.Value, lst[index].KDDV.Value, lst[index].SHN.Value };
                    }
                return getDonGiaCaoNhat(lstGiaNuoc, GiaBieu);
            }
            else
            {
                return 0;
            }
        }

        //giảm giá nước

        public bool checkExists_GiamGiaNuoc(int Nam, int Ky, int GiaBieu, ref List<GiaNuoc2> lst)
        {
            if (db.GiaNuoc_Giams.Any(item => item.Nam.Contains(Nam.ToString()) && item.Ky.Contains(Ky.ToString()) && item.GiaBieu.Contains(GiaBieu.ToString())) == true)
            {
                double TyLeGiam = db.GiaNuoc_Giams.SingleOrDefault(item => item.Nam.Contains(Nam.ToString()) && item.Ky.Contains(Ky.ToString()) && item.GiaBieu.Contains(GiaBieu.ToString())).TyLeGiam.Value;
                foreach (GiaNuoc2 item in lst)
                {
                    item.SHN -= (int)(item.SHN.Value * TyLeGiam / 100);
                    item.SHTM -= (int)(item.SHTM.Value * TyLeGiam / 100);
                    item.SHVM1 -= (int)(item.SHVM1.Value * TyLeGiam / 100);
                    item.SHVM2 -= (int)(item.SHVM2.Value * TyLeGiam / 100);
                    item.SX -= (int)(item.SX.Value * TyLeGiam / 100);
                    item.HCSN -= (int)(item.HCSN.Value * TyLeGiam / 100);
                    item.KDDV -= (int)(item.KDDV.Value * TyLeGiam / 100);
                }
                return true;
            }
            else
                return false;

        }

    }
}
