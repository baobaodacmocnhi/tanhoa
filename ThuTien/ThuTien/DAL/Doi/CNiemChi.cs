using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CNiemChi : CDAL
    {
        public bool Them(TT_NiemChi en)
        {
            try
            {
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaND;
                _db.TT_NiemChis.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(TT_NiemChi en)
        {
            try
            {
                _db.TT_NiemChis.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(List<TT_NiemChi> lsten)
        {
            try
            {
                _db.TT_NiemChis.DeleteAllOnSubmit(lsten);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_NiemChi en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(string ID)
        {
            return _db.TT_NiemChis.Any(item => item.ID == ID);
        }

        public bool checkSuDung(DateTime CreateDate)
        {
            return _db.TT_NiemChis.Any(item => item.CreateDate.Value.Date == CreateDate.Date && item.SuDung == true);
        }

        public bool checkSuDung(string ID)
        {
            return _db.TT_NiemChis.Any(item => item.ID == ID && item.SuDung == true);
        }

        public bool checkSuDung(string KyHieu, int FromID, int ToID)
        {
            return _db.TT_NiemChis.Any(item => item.KyHieu == KyHieu && Convert.ToInt32(item.STT) >= FromID && Convert.ToInt32(item.STT) <= ToID && item.SuDung == true);
        }

        public bool checkGiao(string KyHieu, int FromID, int ToID)
        {
            return _db.TT_NiemChis.Any(item => item.KyHieu == KyHieu && Convert.ToInt32(item.STT) >= FromID && Convert.ToInt32(item.STT) <= ToID && item.MaNV != null);
        }

        public bool checkGiao(DateTime CreateDate)
        {
            return _db.TT_NiemChis.Any(item => item.CreateDate.Value.Date == CreateDate.Date && item.MaNV != null);
        }

        public bool suDung(string ID)
        {
            try
            {
                TT_NiemChi en = _db.TT_NiemChis.SingleOrDefault(item => item.ID == ID);
                en.SuDung = true;
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool traSuDung(string ID)
        {
            try
            {
                TT_NiemChi en = _db.TT_NiemChis.SingleOrDefault(item => item.ID == ID);
                en.SuDung = false;
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public TT_NiemChi get(string ID)
        {
            return _db.TT_NiemChis.SingleOrDefault(item => item.ID == ID);
        }

        public List<TT_NiemChi> getDS(DateTime CreateDate)
        {
            return _db.TT_NiemChis.Where(item => item.CreateDate.Value.Date == CreateDate.Date).ToList();
        }

        public DataTable getDSNhap_Group()
        {
            var query = from item in _db.TT_NiemChis
                        group item by item.CreateDate.Value.Date into itemGroup
                        select new
                        {
                            CreateDate = itemGroup.Key,
                            KyHieu = itemGroup.FirstOrDefault().KyHieu,
                            TuSo = itemGroup.Min(groupItem => groupItem.STT),
                            DenSo = itemGroup.Max(groupItem => groupItem.STT),
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.SuDung == true),
                            SLHuHong = itemGroup.Count(groupItem => groupItem.HuHong == true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.SuDung == true) - itemGroup.Count(groupItem => groupItem.HuHong == true),
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSGiao_Group(DateTime CreateDate)
        {
            var query = from item in _db.TT_NiemChis
                        where item.CreateDate.Value.Date == CreateDate.Date
                        group item by new { item.CreateDate.Value.Date, item.MaTo, item.MaNV } into itemGroup
                        select new
                        {
                            itemGroup.Key.MaTo,
                            TenTo = _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == itemGroup.Key.MaTo).TenTo,
                            itemGroup.Key.MaNV,
                            NhanVien = _db.TT_NguoiDungs.SingleOrDefault(itemT => itemT.MaND == itemGroup.Key.MaNV).HoTen,
                            CreateDate = itemGroup.Key,
                            KyHieu = itemGroup.FirstOrDefault().KyHieu,
                            TuSo = itemGroup.Min(groupItem => groupItem.STT),
                            DenSo = itemGroup.Max(groupItem => groupItem.STT),
                            SLNhap = itemGroup.Count(),
                            SLSuDung = itemGroup.Count(groupItem => groupItem.SuDung == true),
                            SLHuHong = itemGroup.Count(groupItem => groupItem.HuHong == true),
                            SLTon = itemGroup.Count() - itemGroup.Count(groupItem => groupItem.SuDung == true) - itemGroup.Count(groupItem => groupItem.HuHong == true),
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSHuHong()
        {
            var query = from item in _db.TT_NiemChis
                        where item.HuHong == true
                        select new
                        {
                            item.MaTo,
                            TenTo = _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == item.MaTo).TenTo,
                            item.MaNV,
                            HoTen = _db.TT_NguoiDungs.SingleOrDefault(itemT => itemT.MaND == item.MaNV).HoTen,
                            item.ID,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSHuHong_ChuaQyetToan()
        {
            var query = from item in _db.TT_NiemChis
                        where item.HuHong == true && item.QuyetToan == false
                        select new
                        {
                            item.MaTo,
                            TenTo = _db.TT_Tos.SingleOrDefault(itemT => itemT.MaTo == item.MaTo).TenTo,
                            item.MaNV,
                            HoTen = _db.TT_NguoiDungs.SingleOrDefault(itemT => itemT.MaND == item.MaNV).HoTen,
                            item.ID,
                        };
            return LINQToDataTable(query);
        }

        public string getDSNiemChiTon(int MaNV)
        {
            DataTable dt = LINQToDataTable(_db.TT_NiemChis.Where(item => item.MaNV == MaNV && item.SuDung == false && item.HuHong == false).ToList());
            string str = "";
            foreach (DataRow item in dt.Rows)
            {
                str += item["ID"].ToString() + "\r\n";
            }
            return str;
        }

        public int countHuHong_ChuQuyetToan()
        {
            return _db.TT_NiemChis.Count(item => item.HuHong == true && item.QuyetToan == false);
        }

        public int countHuHong_ChuQuyetToan(string MauSac)
        {
            return _db.TT_NiemChis.Count(item => item.HuHong == true && item.QuyetToan == false && item.MauSac == MauSac);
        }
    }
}
