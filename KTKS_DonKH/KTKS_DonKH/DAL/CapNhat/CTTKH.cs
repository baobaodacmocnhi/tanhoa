using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using System.IO;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CTTKH : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng TTKhachHang & TTKhachHangDate
        
        #region TTKhachHang

        /// <summary>
        /// Cập Nhật Thông Tin Khách Hàng theo từng đợt
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool CapNhatTTKH(string pathFile)
        {
            try
            {
                    string[] lines = File.ReadAllLines(pathFile);
                    string[] ContentsLineDate = lines[0].Replace("\",\"", "$").Replace("\"", "").Split('$');
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    db.TTKhachHangs.DeleteAllOnSubmit(db.TTKhachHangs.Where(itemTTKH => itemTTKH.Dot == ContentsLineDate[1].Substring(1, ContentsLineDate[1].Length - 2)));
                    foreach (string line in lines)
                    {
                        string lineR = line.Replace("\",\"", "$").Replace("\"", "");
                        string[] ContentsLine = lineR.Split('$');
                        TTKhachHang ttkhachhang = new TTKhachHang();
                        ttkhachhang.Khu = ContentsLine[0];
                        ttkhachhang.Dot = ContentsLine[1];
                        ttkhachhang.DanhBo = ContentsLine[2];
                        ttkhachhang.CD = ContentsLine[3];
                        ttkhachhang.CuLy = ContentsLine[4];
                        ttkhachhang.MSTLK = ContentsLine[5];
                        ttkhachhang.GiaoUoc = ContentsLine[6];
                        ttkhachhang.HoTen = ContentsLine[7];
                        ttkhachhang.DC1 = ContentsLine[8];
                        ttkhachhang.DC2 = ContentsLine[9];
                        ttkhachhang.MSKH = ContentsLine[10];
                        ttkhachhang.MSCQ = ContentsLine[11];
                        ttkhachhang.GB = ContentsLine[12];
                        ttkhachhang.SH = ContentsLine[13];
                        ttkhachhang.HCSN = ContentsLine[14];
                        ttkhachhang.SX = ContentsLine[15];
                        ttkhachhang.DV = ContentsLine[16];
                        ttkhachhang.TGDM = ContentsLine[17];
                        ttkhachhang.Ky = ContentsLine[18];
                        ttkhachhang.Nam = ContentsLine[19];
                        ttkhachhang.Code = ContentsLine[20];
                        ttkhachhang.CodeFu = ContentsLine[21];
                        ttkhachhang.CSCu = ContentsLine[22];
                        ttkhachhang.CSMoi = ContentsLine[23];
                        ttkhachhang.RT = ContentsLine[24];
                        ttkhachhang.NgayDSKT = ContentsLine[25];
                        ttkhachhang.NgayDSKN = ContentsLine[26];
                        ttkhachhang.ChuKyDS = ContentsLine[27];
                        ttkhachhang.LNCC = ContentsLine[28];
                        ttkhachhang.LNCT = ContentsLine[29];
                        ttkhachhang.LNBuToiThieu = ContentsLine[30];
                        ttkhachhang.LNSH = ContentsLine[31];
                        ttkhachhang.LNHCSN = ContentsLine[32];
                        ttkhachhang.LNSX = ContentsLine[33];
                        ttkhachhang.LNDV = ContentsLine[34];
                        ttkhachhang.CuonGCS = ContentsLine[35];
                        ttkhachhang.CuonSTT = ContentsLine[36];
                        ttkhachhang.GiaBan = ContentsLine[37];
                        ttkhachhang.ThueGTGT = ContentsLine[38];
                        ttkhachhang.PhiBVMT = ContentsLine[39];
                        ttkhachhang.TongCong = ContentsLine[40];
                        ttkhachhang.GiaBanBuToiThieu = ContentsLine[41];
                        ttkhachhang.ThueGTGTBuToiThieu = ContentsLine[42];
                        ttkhachhang.PhiBVMTBuToiThieu = ContentsLine[43];
                        ttkhachhang.TongCongBuToiThieu = ContentsLine[44];
                        ttkhachhang.SoPhatHanh = ContentsLine[45];
                        ttkhachhang.SoHoaDon = ContentsLine[46];
                        ttkhachhang.NgayPhatHanh = ContentsLine[47];
                        ttkhachhang.Quan = ContentsLine[48];
                        ttkhachhang.Phuong = ContentsLine[49];
                        ttkhachhang.SoDHN = ContentsLine[50];
                        ttkhachhang.MSThue = ContentsLine[51];
                        ttkhachhang.TileTieuThu = ContentsLine[52];
                        ttkhachhang.NgayGanDHN = ContentsLine[53];
                        ttkhachhang.SoHo = ContentsLine[54];

                        ///Kiểm Tra có thay đổi Phiên Lộ Trình không
                        if (CheckTTKHbyID(ttkhachhang.DanhBo))
                        {
                            //db.TTKhachHangs.DeleteOnSubmit(getTTKHbyID(ttkhachhang.DanhBo));
                        }

                        db.TTKhachHangs.InsertOnSubmit(ttkhachhang);
                    }
                    ///Cập nhật TTKhachHangDate

                    TTKhachHangDate ttkhdate = getTTKHDatebyID(int.Parse(ContentsLineDate[1]));
                    ttkhdate.Nam = int.Parse(ContentsLineDate[19]);
                    ttkhdate.Ky = int.Parse(ContentsLineDate[18]);
                    SuaTTKhachHangDate(ttkhdate);

                    db.SubmitChanges();
                    db.Transaction.Commit();
                    MessageBox.Show("Thành công Cập Nhật TTKhachHang", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.Transaction.Rollback();
                db = new dbKinhDoanhDataContext();
                return false;
            }
            finally
            {
                if (db.Connection.State == System.Data.ConnectionState.Open)
                    db.Connection.Close();
            }
        }

        /// <summary>
        /// Cập Nhật Thông Tin Khách Hàng theo kỳ(20 đợt)
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool CapNhatTTKHs(string pathFile)
        {
            try
            {
                    string[] lines = File.ReadAllLines(pathFile);
                    string[] ContentsLineDate = lines[0].Replace("\",\"", "$").Replace("\"", "").Split('$');
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    db.TTKhachHangs.DeleteAllOnSubmit(db.TTKhachHangs);
                    foreach (string line in lines)
                    {
                        string lineR = line.Replace("\",\"", "$").Replace("\"", "");
                        string[] ContentsLine = lineR.Split('$');
                        TTKhachHang ttkhachhang = new TTKhachHang();
                        ttkhachhang.Khu = ContentsLine[0];
                        ttkhachhang.Dot = ContentsLine[1];
                        ttkhachhang.DanhBo = ContentsLine[2];
                        ttkhachhang.CD = ContentsLine[3];
                        ttkhachhang.CuLy = ContentsLine[4];
                        ttkhachhang.MSTLK = ContentsLine[5];
                        ttkhachhang.GiaoUoc = ContentsLine[6];
                        ttkhachhang.HoTen = ContentsLine[7];
                        ttkhachhang.DC1 = ContentsLine[8];
                        ttkhachhang.DC2 = ContentsLine[9];
                        ttkhachhang.MSKH = ContentsLine[10];
                        ttkhachhang.MSCQ = ContentsLine[11];
                        ttkhachhang.GB = ContentsLine[12];
                        ttkhachhang.SH = ContentsLine[13];
                        ttkhachhang.HCSN = ContentsLine[14];
                        ttkhachhang.SX = ContentsLine[15];
                        ttkhachhang.DV = ContentsLine[16];
                        ttkhachhang.TGDM = ContentsLine[17];
                        ttkhachhang.Ky = ContentsLine[18];
                        ttkhachhang.Nam = ContentsLine[19];
                        ttkhachhang.Code = ContentsLine[20];
                        ttkhachhang.CodeFu = ContentsLine[21];
                        ttkhachhang.CSCu = ContentsLine[22];
                        ttkhachhang.CSMoi = ContentsLine[23];
                        ttkhachhang.RT = ContentsLine[24];
                        ttkhachhang.NgayDSKT = ContentsLine[25];
                        ttkhachhang.NgayDSKN = ContentsLine[26];
                        ttkhachhang.ChuKyDS = ContentsLine[27];
                        ttkhachhang.LNCC = ContentsLine[28];
                        ttkhachhang.LNCT = ContentsLine[29];
                        ttkhachhang.LNBuToiThieu = ContentsLine[30];
                        ttkhachhang.LNSH = ContentsLine[31];
                        ttkhachhang.LNHCSN = ContentsLine[32];
                        ttkhachhang.LNSX = ContentsLine[33];
                        ttkhachhang.LNDV = ContentsLine[34];
                        ttkhachhang.CuonGCS = ContentsLine[35];
                        ttkhachhang.CuonSTT = ContentsLine[36];
                        ttkhachhang.GiaBan = ContentsLine[37];
                        ttkhachhang.ThueGTGT = ContentsLine[38];
                        ttkhachhang.PhiBVMT = ContentsLine[39];
                        ttkhachhang.TongCong = ContentsLine[40];
                        ttkhachhang.GiaBanBuToiThieu = ContentsLine[41];
                        ttkhachhang.ThueGTGTBuToiThieu = ContentsLine[42];
                        ttkhachhang.PhiBVMTBuToiThieu = ContentsLine[43];
                        ttkhachhang.TongCongBuToiThieu = ContentsLine[44];
                        ttkhachhang.SoPhatHanh = ContentsLine[45];
                        ttkhachhang.SoHoaDon = ContentsLine[46];
                        ttkhachhang.NgayPhatHanh = ContentsLine[47];
                        ttkhachhang.Quan = ContentsLine[48];
                        ttkhachhang.Phuong = ContentsLine[49];
                        ttkhachhang.SoDHN = ContentsLine[50];
                        ttkhachhang.MSThue = ContentsLine[51];
                        ttkhachhang.TileTieuThu = ContentsLine[52];
                        ttkhachhang.NgayGanDHN = ContentsLine[53];
                        ttkhachhang.SoHo = ContentsLine[54];

                        db.TTKhachHangs.InsertOnSubmit(ttkhachhang);
                    }
                    ///Cập nhật TTKhachHangDate
                    foreach (TTKhachHangDate ttkhdate in db.TTKhachHangDates)
                    {
                        ttkhdate.Nam = int.Parse(ContentsLineDate[19]);
                        ttkhdate.Ky = int.Parse(ContentsLineDate[18]);
                        SuaTTKhachHangDate(ttkhdate);
                    }

                    db.SubmitChanges();
                    db.Transaction.Commit();
                    MessageBox.Show("Thành công Cập Nhật TTKhachHang", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.Transaction.Rollback();
                db = new dbKinhDoanhDataContext();
                return false;
            }
            finally
            {
                if (db.Connection.State == System.Data.ConnectionState.Open)
                    db.Connection.Close();
            }
        }

        //public TTKhachHang getTTKHbyID(string DanhBo)
        //{
        //    try
        //    {
        //        return db.TTKhachHangs.SingleOrDefault(itemTTKH => itemTTKH.DanhBo == DanhBo);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        public bool CheckTTKHbyID(string DanhBo)
        {
            try
            {
                return db.TTKhachHangs.Any(itemTTKH => itemTTKH.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region TTKhachHangDate

        public List<TTKhachHangDate> LoadDSTTKhachHangDate()
        {
            try
            {
                    return db.TTKhachHangDates.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool SuaTTKhachHangDate(TTKhachHangDate ttkhdate)
        {
            try
            {
                    ttkhdate.ModifyDate = DateTime.Now;
                    ttkhdate.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public TTKhachHangDate getTTKHDatebyID(int id)
        {
            try
            {
                return db.TTKhachHangDates.SingleOrDefault(itemCT => itemCT.Dot == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

    }
}