﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using System.IO;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CTTKH : CDAL
    {
        //DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();
        CTTKHDate _cTTKHDate = new CTTKHDate();

        public bool CapNhatTTKH(string pathFile)
        {
            try
            {
                if (CTaiKhoan.RoleCapNhat)
                {
                    string[] lines = File.ReadAllLines(pathFile);
                    string[] ContentsLineDate = lines[0].Split(',');
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    db.TTKhachHangs.DeleteAllOnSubmit(db.TTKhachHangs.Where(itemTTKH => itemTTKH.Dot == ContentsLineDate[1].Substring(1, ContentsLineDate[1].Length - 2)));
                    foreach (string line in lines)
                    {
                        string[] ContentsLine = line.Split(',');
                        TTKhachHang ttkhachhang = new TTKhachHang();
                        ttkhachhang.Khu = ContentsLine[0].Replace("\"", "");
                        ttkhachhang.Dot = ContentsLine[1].Replace("\"", "");
                        ttkhachhang.DanhBo = ContentsLine[2].Replace("\"", "");
                        ttkhachhang.CD = ContentsLine[3].Replace("\"", "");
                        ttkhachhang.CuLy = ContentsLine[4].Replace("\"", "");
                        ttkhachhang.MSTLK = ContentsLine[5].Replace("\"", "");
                        ttkhachhang.GiaoUoc = ContentsLine[6].Replace("\"", "");
                        ttkhachhang.HoTen = ContentsLine[7].Replace("\"", "");
                        ttkhachhang.DC1 = ContentsLine[8].Replace("\"", "");
                        ttkhachhang.DC2 = ContentsLine[9].Replace("\"", "");
                        ttkhachhang.MSKH = ContentsLine[10].Replace("\"", "");
                        ttkhachhang.MSCQ = ContentsLine[11].Replace("\"", "");
                        ttkhachhang.GB = ContentsLine[12].Replace("\"", "");
                        ttkhachhang.SH = ContentsLine[13].Replace("\"", "");
                        ttkhachhang.HCSN = ContentsLine[14].Replace("\"", "");
                        ttkhachhang.SX = ContentsLine[15].Replace("\"", "");
                        ttkhachhang.DV = ContentsLine[16].Replace("\"", "");
                        ttkhachhang.TGDM = ContentsLine[17].Replace("\"", "");
                        ttkhachhang.Ky = ContentsLine[18].Replace("\"", "");
                        ttkhachhang.Nam = ContentsLine[19].Replace("\"", "");
                        ttkhachhang.Code = ContentsLine[20].Replace("\"", "");
                        ttkhachhang.CodeFu = ContentsLine[21].Replace("\"", "");
                        ttkhachhang.CSCu = ContentsLine[22].Replace("\"", "");
                        ttkhachhang.CSMoi = ContentsLine[23].Replace("\"", "");
                        ttkhachhang.RT = ContentsLine[24].Replace("\"", "");
                        ttkhachhang.NgayDSKT = ContentsLine[25].Replace("\"", "");
                        ttkhachhang.NgayDSKN = ContentsLine[26].Replace("\"", "");
                        ttkhachhang.ChuKyDS = ContentsLine[27].Replace("\"", "");
                        ttkhachhang.LNCC = ContentsLine[28].Replace("\"", "");
                        ttkhachhang.LNCT = ContentsLine[29].Replace("\"", "");
                        ttkhachhang.LNBuToiThieu = ContentsLine[30].Replace("\"", "");
                        ttkhachhang.LNSH = ContentsLine[31].Replace("\"", "");
                        ttkhachhang.LNHCSN = ContentsLine[32].Replace("\"", "");
                        ttkhachhang.LNSX = ContentsLine[33].Replace("\"", "");
                        ttkhachhang.LNDV = ContentsLine[34].Replace("\"", "");
                        ttkhachhang.CuonGCS = ContentsLine[35].Replace("\"", "");
                        ttkhachhang.CuonSTT = ContentsLine[36].Replace("\"", "");
                        ttkhachhang.GiaBan = ContentsLine[37].Replace("\"", "");
                        ttkhachhang.ThueGTGT = ContentsLine[38].Replace("\"", "");
                        ttkhachhang.PhiBVMT = ContentsLine[39].Replace("\"", "");
                        ttkhachhang.TongCong = ContentsLine[40].Replace("\"", "");
                        ttkhachhang.GiaBanBuToiThieu = ContentsLine[41].Replace("\"", "");
                        ttkhachhang.ThueGTGTBuToiThieu = ContentsLine[42].Replace("\"", "");
                        ttkhachhang.PhiBVMTBuToiThieu = ContentsLine[43].Replace("\"", "");
                        ttkhachhang.TongCongBuToiThieu = ContentsLine[44].Replace("\"", "");
                        ttkhachhang.SoPhatHanh = ContentsLine[45].Replace("\"", "");
                        ttkhachhang.SoHoaDon = ContentsLine[46].Replace("\"", "");
                        ttkhachhang.NgayPhatHanh = ContentsLine[47].Replace("\"", "");
                        ttkhachhang.Quan = ContentsLine[48].Replace("\"", "");
                        ttkhachhang.Phuong = ContentsLine[49].Replace("\"", "");
                        ttkhachhang.SoDHN = ContentsLine[50].Replace("\"", "");
                        ttkhachhang.MSThue = ContentsLine[51].Replace("\"", "");
                        ttkhachhang.TileTieuThu = ContentsLine[52].Replace("\"", "");
                        ttkhachhang.NgayGanDHN = ContentsLine[53].Replace("\"", "");
                        ttkhachhang.SoHo = ContentsLine[54].Replace("\"", "");

                        db.TTKhachHangs.InsertOnSubmit(ttkhachhang);
                    }
                    ///Cập nhật TTKhachHangDate

                    TTKhachHangDate ttkhdate = _cTTKHDate.getTTKHDatebyID(int.Parse(ContentsLineDate[1].Replace("\"", "")));
                    ttkhdate.Nam = int.Parse(ContentsLineDate[19].Replace("\"", ""));
                    ttkhdate.Ky = int.Parse(ContentsLineDate[18].Replace("\"", ""));
                    _cTTKHDate.SuaTTKhachHangDate(ttkhdate);

                    db.SubmitChanges();
                    db.Transaction.Commit();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.Transaction.Rollback();
                return false;
            }
            finally
            {
                if (db.Connection.State == System.Data.ConnectionState.Open)
                    db.Connection.Close();
            }
        }

        public TTKhachHang getTTKHbyID(string DanhBo)
        {
            try
            {
                return db.TTKhachHangs.Single(itemTTKH => itemTTKH.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}