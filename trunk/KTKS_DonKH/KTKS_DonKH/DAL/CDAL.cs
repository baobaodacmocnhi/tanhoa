using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL
{
    class CDAL
    {
        protected static DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

        /// <summary>
        /// Lấy mã tiếp theo, theo định dạng năm-stt (2013-1)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public string getMaxNextIDTable(string id)
        //{
        //    string[] id_Sub = id.Split('-');
        //    string nam = "";
        //    string stt = "";
        //    if (id_Sub[0] == DateTime.Now.Year.ToString())
        //    {
        //        nam = id_Sub[0];
        //        stt = (int.Parse(id_Sub[1]) + 1).ToString();
        //    }
        //    else
        //    {
        //        nam = DateTime.Now.Year.ToString();
        //        stt = "1";
        //    }
        //    return nam + "-" + stt;
        //}

        /// <summary>
        /// Lấy mã tiếp theo, theo định dạng sttnăm 113(12013)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal getMaxNextIDTable(decimal id)
        {
            string nam = id.ToString().Substring(id.ToString().Length - 2, 2);
            string stt = id.ToString().Substring(0, id.ToString().Length - 2);
            if (decimal.Parse(nam) == decimal.Parse(DateTime.Now.ToString("yy")))
            {
                stt = (decimal.Parse(stt) + 1).ToString();
            }
            else
            {
                stt = "1";
                nam = DateTime.Now.ToString("yy");
            }
            return decimal.Parse(stt + nam);
        }

        /// <summary>
        /// Chuyển đổi dữ liệu từ LichSuChungTu sang CatChuyenDM
        /// </summary>
        /// <param name="lichsuchungtu"></param>
        /// <param name="catchuyendm"></param>
        public void LSCTtoCCDM(LichSuChungTu lichsuchungtu,ref CatChuyenDM catchuyendm)
        {
            catchuyendm.SoPhieu = lichsuchungtu.SoPhieu.Value;
            catchuyendm.DanhBo = lichsuchungtu.DanhBo;
            catchuyendm.MaCT = lichsuchungtu.MaCT;
            catchuyendm.SoNKTong = lichsuchungtu.SoNKTong;
            catchuyendm.SoNKDangKy = lichsuchungtu.SoNKDangKy;
            catchuyendm.SoNKConLai = lichsuchungtu.SoNKConLai;
            catchuyendm.ThoiHan = lichsuchungtu.ThoiHan;
            catchuyendm.NgayHetHan = lichsuchungtu.NgayHetHan;
            catchuyendm.CatDM = lichsuchungtu.CatDM;
            catchuyendm.SoNKCat = lichsuchungtu.SoNKCat;
            catchuyendm.NhanNK_MaCN = lichsuchungtu.NhanNK_MaCN;
            catchuyendm.NhanNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
            catchuyendm.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
            catchuyendm.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
            catchuyendm.NhanDM = lichsuchungtu.NhanDM;
            catchuyendm.YeuCauCat = lichsuchungtu.YeuCauCat;
            catchuyendm.SoNKNhan = lichsuchungtu.SoNKNhan;
            catchuyendm.CatNK_MaCN = lichsuchungtu.CatNK_MaCN;
            catchuyendm.CatNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
            catchuyendm.CatNK_HoTen = lichsuchungtu.CatNK_HoTen;
            catchuyendm.CatNK_DiaChi = lichsuchungtu.CatNK_DiaChi;
            catchuyendm.GhiChu = lichsuchungtu.GhiChu;
            catchuyendm.MaDon = lichsuchungtu.MaDon;
            catchuyendm.ToXuLy = lichsuchungtu.ToXuLy;
            catchuyendm.MaDonTXL = lichsuchungtu.MaDonTXL;
            catchuyendm.NguoiKy = lichsuchungtu.NguoiKy;
            catchuyendm.ChucVu = lichsuchungtu.ChucVu;
            //catchuyendm.PhieuDuocKy = lichsuchungtu.PhieuDuocKy;
        }

        public void beginTransaction()
        {
            if (db.Connection.State == System.Data.ConnectionState.Closed)
                db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
        }

        public void commitTransaction()
        {
            db.Transaction.Commit();
        }

        public void rollback()
        {
            db.Transaction.Rollback();
        }
    }
}
