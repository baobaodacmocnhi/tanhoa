﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CGiaNuoc : CDAL
    {
        public List<GiaNuoc> LoadDSGiaNuoc()
        {
            try
            {
                    return db.GiaNuocs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách Giá Nước, hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="inheritance"></param>
        /// <returns></returns>
        public List<GiaNuoc> LoadDSGiaNuoc(bool inheritance)
        {
            try
            {
                if (inheritance)
                {
                    return db.GiaNuocs.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemGiaNuoc(GiaNuoc gianuoc)
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
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaGiaNuoc(GiaNuoc gianuoc)
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
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public GiaNuoc getGiaNuocbyID(int MaGN)
        {
            try
            {
                return db.GiaNuocs.SingleOrDefault(itemGN => itemGN.MaGN == MaGN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
        public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int GiaBieu, int DinhMuc, int TieuThu, out string ChiTiet,out int TieuThu_DieuChinhGia)
        {
            try
            {
                string _chiTiet = "";
                TieuThu_DieuChinhGia = 0;
                TTKhachHang ttkhachhang = null;
                CTTKH _cTTKH = new CTTKH();
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.SH.Trim() == "" && ttkhachhang.SX.Trim() == "")
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
                            //if (ttkhachhang.SH.Trim() != "" && ttkhachhang.SX.Trim() != "")
                            {
                                int _SH = 0, _SX = 0;
                                if (ttkhachhang.SH.Trim() != "")
                                    _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.SH.Trim() == "" && ttkhachhang.DV.Trim() == "")
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
                            //if (ttkhachhang.SH.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = 0, _DV = 0;
                                if (ttkhachhang.SH.Trim() != "")
                                    _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
                            if (ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "" && ttkhachhang.SH.Trim() == "")
                            {
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = TieuThu - _SX;
                                TongTien = (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                            else
                            ///Nếu có đủ 3 tỉ lệ SH + SX + DV
                            //if (ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "" && ttkhachhang.SH.Trim() != "")
                            {
                                int _SH = 0, _SX = 0, _DV = 0;
                                if (ttkhachhang.SH.Trim() != "")
                                    _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                if (ttkhachhang.SX.Trim() != "")
                                    _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.SH.Trim() == "" && ttkhachhang.HCSN.Trim() == "")
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
                            //if (ttkhachhang.SH.Trim() != "" && ttkhachhang.HCSN.Trim() != "")
                            {
                                int _SH = 0, _HCSN = 0;
                                if (ttkhachhang.SH.Trim() != "")
                                    _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        //if (ttkhachhang.SH.Trim() != "" && ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                        {
                            int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                            if (ttkhachhang.SH.Trim() != "")
                                _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                            if (ttkhachhang.HCSN.Trim() != "")
                                _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                            if (ttkhachhang.SX.Trim() != "")
                                _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
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
                    //    ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                    //    if (ttkhachhang != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (ttkhachhang.SH.Trim() == "" && ttkhachhang.SX.Trim() == "")
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.HCSN.Trim() == "" && ttkhachhang.SX.Trim() == "")
                            {
                                TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value;
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                            }
                            else
                            ///Nếu có tỉ lệ
                            //if (ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "")
                            {
                                int _HCSN = 0, _SX = 0;
                                if (ttkhachhang.HCSN.Trim() != "")
                                    _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                _SX = TieuThu - _HCSN;

                                TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                            }
                        break;
                    case 35:///HCSN + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.HCSN.Trim() == "" && ttkhachhang.SX.Trim() == "")
                            {
                                TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value;
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                            else
                            ///Nếu có tỉ lệ
                            //if (ttkhachhang.HCSN.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _HCSN = 0, _DV = 0;
                                if (ttkhachhang.HCSN.Trim() != "")
                                    _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                _DV = TieuThu - _HCSN;

                                TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    case 36:///HCSN + SX + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        //if (ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                        {
                            int _HCSN = 0, _SX = 0, _DV = 0;
                            if (ttkhachhang.HCSN.Trim() != "")
                                _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                            if (ttkhachhang.SX.Trim() != "")
                                _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        //if (ttkhachhang.SH.Trim() != "" && ttkhachhang.SX.Trim() != "")
                        {
                            int _SH = 0, _SX = 0;
                            if (ttkhachhang.SH.Trim() != "")
                                _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                            _SX = TieuThu - _SH;

                            TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                        + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                        }
                        break;
                    case 45:///SH + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        //if (ttkhachhang.SH.Trim() != "" && ttkhachhang.DV.Trim() != "")
                        {
                            int _SH = 0, _DV = 0;
                            if (ttkhachhang.SH.Trim() != "")
                                _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                            _DV = TieuThu - _SH;

                            TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                            _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                        + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                        }
                        break;
                    case 46:///SH + SX + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        //if (ttkhachhang.SH.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                        {
                            int _SH = 0, _SX = 0, _DV = 0;
                            if (ttkhachhang.SH.Trim() != "")
                                _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                            if (ttkhachhang.SX.Trim() != "")
                                _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
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
                            TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                }
                            else
                            {
                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                if (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)
                                    TieuThu_DieuChinhGia = TieuThu;
                                else
                                    TieuThu_DieuChinhGia = TieuThu - DinhMuc;
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                            TieuThu_DieuChinhGia = TieuThu;
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 59:///sỉ phức tạp
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        //if (ttkhachhang.SH.Trim() != "" && ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                        {
                            int _SH = 0, _HCSN = 0, _SX = 0, _DV = 0;
                            if (ttkhachhang.SH.Trim() != "")
                                _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                            if (ttkhachhang.HCSN.Trim() != "")
                                _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                            if (ttkhachhang.SX.Trim() != "")
                                _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                            _DV = TieuThu - _SH - _HCSN - _SX;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    if (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)
                                        TieuThu_DieuChinhGia = _SH;
                                    else
                                        TieuThu_DieuChinhGia = _SH - DinhMuc;
                                }
                            TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + +(_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                         + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                         + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                            //TongTien -= TongTien * 10 / 100;
                        }
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        //if (ttkhachhang.SH.Trim() != "" && ttkhachhang.DV.Trim() != "")
                        {
                            int _SH = 0, _DV = 0;
                            if (ttkhachhang.SH.Trim() != "")
                                _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                            _DV = TieuThu - _SH;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100))) + "\r\n"
                                             + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                         + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    if (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100 == GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)
                                        TieuThu_DieuChinhGia = _SH;
                                    else
                                        TieuThu_DieuChinhGia = _SH - DinhMuc;
                                }
                            TongTien += _DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
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
                TTKhachHang ttkhachhang = null;
                CTTKH _cTTKH = new CTTKH();
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.SH.Trim() == "" && ttkhachhang.SX.Trim() == "")
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
                                if (ttkhachhang.SH.Trim() != "" && ttkhachhang.SX.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.SH.Trim() == "" && ttkhachhang.DV.Trim() == "")
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
                                if (ttkhachhang.SH.Trim() != "" && ttkhachhang.DV.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
                            if (ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "" && ttkhachhang.SH.Trim() == "")
                            {
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                TongTien = (_SX * lstGiaNuoc[3].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                            else
                                ///Nếu có đủ 3 tỉ lệ SH + SX + DV
                                if (ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "" && ttkhachhang.SH.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.SH.Trim() == "" && ttkhachhang.HCSN.Trim() == "")
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
                                if (ttkhachhang.SH.Trim() != "" && ttkhachhang.HCSN.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                    int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
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
                    //    ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                    //    if (ttkhachhang != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (ttkhachhang.SH.Trim() == "" && ttkhachhang.SX.Trim() == "")
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.HCSN.Trim() == "" && ttkhachhang.SX.Trim() == "")
                            {
                                TongTien = TieuThu * lstGiaNuoc[3].DonGia.Value
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value) + "\r\n"
                                            + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            }
                            else
                                ///Nếu có tỉ lệ
                                if (ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "")
                                {
                                    int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                    TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                                }
                        break;
                    case 35:///HCSN + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.HCSN.Trim() == "" && ttkhachhang.SX.Trim() == "")
                            {
                                TongTien = TieuThu * lstGiaNuoc[5].DonGia.Value
                                            + TieuThu_GiaDieuChinh2 * GiaTien_GiaDieuChinh2;
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value) + "\r\n"
                                            + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaTien_GiaDieuChinh2);
                            }
                            else
                                ///Nếu có tỉ lệ
                                if (ttkhachhang.HCSN.Trim() != "" && ttkhachhang.DV.Trim() != "")
                                {
                                    int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                    TongTien = (_HCSN * lstGiaNuoc[4].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4].DonGia.Value) + "\r\n"
                                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                                }
                        break;
                    case 36:///HCSN + SX + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.SX.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_SX * lstGiaNuoc[3].DonGia.Value);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3].DonGia.Value);
                            }
                        break;
                    case 45:///SH + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                TongTien = (_SH * lstGiaNuoc[2].DonGia.Value) + (_DV * lstGiaNuoc[5].DonGia.Value);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2].DonGia.Value) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5].DonGia.Value);
                            }
                        break;
                    case 46:///SH + SX + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
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
                            TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100))
                                                + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100))
                                                + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                                }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100))
                                                + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100))
                                                + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100))
                                                + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                                }
                            else
                            {
                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100))
                                            + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100))
                                            + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                            + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)
                                        + TieuThu_GiaDieuChinh2 * (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                        + TieuThu_GiaDieuChinh2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaTien_GiaDieuChinh2 - GiaTien_GiaDieuChinh2 * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 59:///sỉ phức tạp
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + +(_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                //TongTien -= TongTien * 10 / 100;
                            }
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                 + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                            _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100))) + "\r\n"
                                                 + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                 + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                TongTien += _DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                                _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
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
                TTKhachHang ttkhachhang = null;
                CTTKH _cTTKH = new CTTKH();
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        ///Nếu không có tỉ lệ
                        //if (ttkhachhang.SH.Trim() == "" && ttkhachhang.SX.Trim() == "")
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        ///Nếu không có tỉ lệ
                        //if (ttkhachhang.SH.Trim() == "" && ttkhachhang.DV.Trim() == "")
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        ///Nếu không có tỉ lệ
                        //if (ttkhachhang.SH.Trim() == "" && ttkhachhang.HCSN.Trim() == "")
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
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
                    //    ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                    //    if (ttkhachhang != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (ttkhachhang.SH.Trim() == "" && ttkhachhang.SX.Trim() == "")
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        ///Nếu không có tỉ lệ
                        //if (ttkhachhang.HCSN.Trim() == "" && ttkhachhang.SX.Trim() == "")
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        ///Nếu không có tỉ lệ
                        //if (ttkhachhang.HCSN.Trim() == "" && ttkhachhang.SX.Trim() == "")
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
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
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
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
                            TongTien = TieuThu * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                }
                            else
                            {
                                TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 59:///sỉ phức tạp
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        //if (SH != 0 && HCSN !=0 && SX != 0 && DV != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _HCSN = (int)Math.Round((double)TieuThu * HCSN / 100);
                            int _SX = (int)Math.Round((double)TieuThu * SX / 100);
                            int _DV = TieuThu - _SH - _HCSN - _SX;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                    + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                }
                            TongTien += (_HCSN * (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + +(_DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                            _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4].DonGia.Value - lstGiaNuoc[4].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                         + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3].DonGia.Value - lstGiaNuoc[3].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                         + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                            //TongTien -= TongTien * 10 / 100;
                        }
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                        //if (SH != 0 && DV != 0)
                        {
                            int _SH = (int)Math.Round((double)TieuThu * SH / 100);
                            int _DV = TieuThu - _SH;

                            if (_SH <= DinhMuc)
                            {
                                TongTien = _SH * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                            }
                            else
                                if (!DieuChinhGia)
                                    if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100))) + "\r\n"
                                             + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1].DonGia.Value - lstGiaNuoc[1].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2].DonGia.Value - lstGiaNuoc[2].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0].DonGia.Value - lstGiaNuoc[0].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                         + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                }
                            TongTien += _DV * (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5].DonGia.Value - lstGiaNuoc[5].DonGia.Value * CTaiKhoan.GiamTienNuoc / 100));
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

        List<int> lst2010 = new List<int> { 4000, 7500, 10000, 7100, 6700, 12000 };
        List<int> lst2011 = new List<int> { 4400, 8300, 10500, 8100, 7400, 13500 };
        List<int> lst2012 = new List<int> { 4800, 9200, 11000, 9300, 8200, 15200 };

        public int TinhTienNuoc(bool DieuChinhGia, int GiaDieuChinh, string DanhBo, int Nam, int GiaBieu, int DinhMuc, int TieuThu, out string ChiTiet)
        {
            try
            {
                string _chiTiet = "";
                TTKhachHang ttkhachhang = null;
                CTTKH _cTTKH = new CTTKH();
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
                            TongTien = TieuThu * lstGiaNuoc[0];
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[1]);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
                                }
                                else
                                {
                                    TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                                }
                            else
                            {
                                TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
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
                        }
                        break;
                    case 14:
                    case 24:///SH + SX
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.SH.Trim() == "" && ttkhachhang.SX.Trim() == "")
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0];
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[3]);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                   + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                   + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                            }
                            else
                                ///Nếu có tỉ lệ SH + SX
                                if (ttkhachhang.SH.Trim() != "" && ttkhachhang.SX.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0];
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += _SX * lstGiaNuoc[3];
                                    _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                                }
                        break;
                    case 15:
                    case 25:///SH + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.SH.Trim() == "" && ttkhachhang.DV.Trim() == "")
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0];
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[5]);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                            }
                            else
                                ///Nếu có tỉ lệ SH + DV
                                if (ttkhachhang.SH.Trim() != "" && ttkhachhang.DV.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0];
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += _DV * lstGiaNuoc[5];
                                    _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                                }
                        break;
                    case 16:
                    case 26:///SH + SX + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu chỉ có tỉ lệ SX + DV mà không có tỉ lệ SH, không xét Định Mức
                            if (ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "" && ttkhachhang.SH.Trim() == "")
                            {
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                TongTien = (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                                _chiTiet = _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                            }
                            else
                                ///Nếu có đủ 3 tỉ lệ SH + SX + DV
                                if (ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "" && ttkhachhang.SH.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0];
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                                    _chiTiet += "\r\n" + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
                                                 + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
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
                        }
                        break;
                    case 18:
                    case 28:
                    case 38:///SH + HCSN
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.SH.Trim() == "" && ttkhachhang.HCSN.Trim() == "")
                            {
                                if (TieuThu <= DinhMuc)
                                {
                                    TongTien = TieuThu * lstGiaNuoc[0];
                                    _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                }
                                else
                                    if (!DieuChinhGia)
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * lstGiaNuoc[4]);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                                    }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0]) + ((TieuThu - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                    + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                            }
                            else
                                ///Nếu có tỉ lệ SH + HCSN
                                if (ttkhachhang.SH.Trim() != "" && ttkhachhang.HCSN.Trim() != "")
                                {
                                    int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                    int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                    if (_SH <= DinhMuc)
                                    {
                                        TongTien = _SH * lstGiaNuoc[0];
                                        _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                    }
                                    else
                                        if (!DieuChinhGia)
                                            if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                            + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
                                            }
                                            else
                                            {
                                                TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
                                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                            + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
                                                            + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                                            }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                        }
                                    TongTien += _HCSN * lstGiaNuoc[4];
                                    _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]);
                                }
                        break;
                    case 19:
                    case 29:
                    case 39:///SH + HCSN + SX + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * lstGiaNuoc[0];
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]);
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * lstGiaNuoc[1]);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]);
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * lstGiaNuoc[0]) + ((int)Math.Round((double)DinhMuc / 2) * lstGiaNuoc[1]) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * lstGiaNuoc[2]);
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[1]) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]);
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * lstGiaNuoc[0]) + ((_SH - DinhMuc) * GiaDieuChinh);
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[0]) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaDieuChinh);
                                    }
                                TongTien += (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                                _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
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
                    //    ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                    //    if (ttkhachhang != null)
                    //        ///Nếu không có tỉ lệ
                    //        if (ttkhachhang.SH.Trim() == "" && ttkhachhang.SX.Trim() == "")
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
                        }
                        break;
                    //case 32:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 33:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    case 34:///HCSN + SX
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.HCSN.Trim() == "" && ttkhachhang.SX.Trim() == "")
                            {
                                TongTien = TieuThu * lstGiaNuoc[3];
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                            }
                            else
                                ///Nếu có tỉ lệ
                                if (ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "")
                                {
                                    int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                    int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                    TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]);
                                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
                                                + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                                }
                        break;
                    case 35:///HCSN + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            ///Nếu không có tỉ lệ
                            if (ttkhachhang.HCSN.Trim() == "" && ttkhachhang.SX.Trim() == "")
                            {
                                TongTien = TieuThu * lstGiaNuoc[5];
                                _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                            }
                            else
                                ///Nếu có tỉ lệ
                                if (ttkhachhang.HCSN.Trim() != "" && ttkhachhang.DV.Trim() != "")
                                {
                                    int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                    int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                    TongTien = (_HCSN * lstGiaNuoc[4]) + (_DV * lstGiaNuoc[5]);
                                    _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
                                                + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                                }
                        break;
                    case 36:///HCSN + SX + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                TongTien = (_HCSN * lstGiaNuoc[4]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                                _chiTiet = _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[4]) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
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
                        }
                        break;
                    //case 42:///SX
                    //    TongTien = TieuThu * lstGiaNuoc[3];
                    //    break;
                    //case 43:///DV
                    //    TongTien = TieuThu * lstGiaNuoc[5];
                    //    break;
                    case 44:///SH + SX
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.SX.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]);
                            }
                        break;
                    case 45:///SH + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                TongTien = (_SH * lstGiaNuoc[2]) + (_DV * lstGiaNuoc[5]);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
                            }
                        break;
                    case 46:///SH + SX + DV
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                TongTien = (_SH * lstGiaNuoc[2]) + (_SX * lstGiaNuoc[3]) + (_DV * lstGiaNuoc[5]);
                                _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[2]) + "\r\n"
                                            + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[3]) + "\r\n"
                                            + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", lstGiaNuoc[5]);
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
                        if (TieuThu <= DinhMuc)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                            if (!DieuChinhGia)
                                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100));
                                }
                                else
                                {
                                    TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100)) + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * CTaiKhoan.GiamTienNuoc / 100));
                                    _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * CTaiKhoan.GiamTienNuoc / 100));
                                }
                            else
                            {
                                TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + ((TieuThu - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                            + (TieuThu - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                            }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 52:///sỉ khu công nghiệp
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[3] - lstGiaNuoc[3] * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 53:///sỉ KD - TM
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[5] - lstGiaNuoc[5] * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 54:///sỉ HCSN
                        if (!DieuChinhGia)
                        {
                            TongTien = TieuThu * (lstGiaNuoc[4] - lstGiaNuoc[4] * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        else
                        {
                            TongTien = TieuThu * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100);
                            _chiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                        }
                        //TongTien -= TongTien * 10 / 100;
                        break;
                    case 59:///sỉ phức tạp
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.HCSN.Trim() != "" && ttkhachhang.SX.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _HCSN = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.HCSN.Trim()) / 100);
                                int _SX = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SX.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100);
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100));
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                        + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100));
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * CTaiKhoan.GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                        + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                        + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * CTaiKhoan.GiamTienNuoc / 100));
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                    + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                TongTien += (_HCSN * (lstGiaNuoc[4] - lstGiaNuoc[4] * CTaiKhoan.GiamTienNuoc / 100)) + (_SX * (lstGiaNuoc[3] - lstGiaNuoc[3] * CTaiKhoan.GiamTienNuoc / 100)) + +(_DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * CTaiKhoan.GiamTienNuoc / 100));
                                _chiTiet += "\r\n" + _HCSN + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[4] - lstGiaNuoc[4] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + _SX + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[3] - lstGiaNuoc[3] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * CTaiKhoan.GiamTienNuoc / 100));
                                //TongTien -= TongTien * 10 / 100;
                            }
                        break;
                    case 68:///SH giá sỉ - KD giá lẻ
                        ttkhachhang = _cTTKH.getTTKHbyID(DanhBo);
                        if (ttkhachhang != null)
                            if (ttkhachhang.SH.Trim() != "" && ttkhachhang.DV.Trim() != "")
                            {
                                int _SH = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.SH.Trim()) / 100);
                                int _DV = (int)Math.Round((double)TieuThu * int.Parse(ttkhachhang.DV.Trim()) / 100);
                                if (_SH <= DinhMuc)
                                {
                                    TongTien = _SH * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100);
                                    _chiTiet = _SH + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100));
                                }
                                else
                                    if (!DieuChinhGia)
                                        if (_SH - DinhMuc <= Math.Round((double)DinhMuc / 2))
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100));
                                            _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                 + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100));
                                        }
                                        else
                                        {
                                            TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + ((int)Math.Round((double)DinhMuc / 2) * (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (lstGiaNuoc[2] - lstGiaNuoc[2] * CTaiKhoan.GiamTienNuoc / 100));
                                            _chiTiet = (DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100))) + "\r\n"
                                                 + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[1] - lstGiaNuoc[1] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                                 + (_SH - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[2] - lstGiaNuoc[2] * CTaiKhoan.GiamTienNuoc / 100));
                                        }
                                    else
                                    {
                                        TongTien = (DinhMuc * (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + ((_SH - DinhMuc) * (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                        _chiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[0] - lstGiaNuoc[0] * CTaiKhoan.GiamTienNuoc / 100)) + "\r\n"
                                             + (_SH - DinhMuc) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (GiaDieuChinh - GiaDieuChinh * CTaiKhoan.GiamTienNuoc / 100));
                                    }
                                TongTien += _DV * (lstGiaNuoc[5] - lstGiaNuoc[5] * CTaiKhoan.GiamTienNuoc / 100);
                                _chiTiet += "\r\n" + _DV + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (lstGiaNuoc[5] - lstGiaNuoc[5] * CTaiKhoan.GiamTienNuoc / 100));
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

        List<int> lstBVMT2010 = new List<int> { 400, 800, 900, 2000, 800 };

        public int TinhPhiBMVT(int Nam, int GiaBieu, int DinhMuc, int TieuThu)
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

    }
}
