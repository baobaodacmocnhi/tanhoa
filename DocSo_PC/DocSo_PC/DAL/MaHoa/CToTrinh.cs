﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL.MaHoa
{
    class CToTrinh : CDAL
    {
        public bool Them(MaHoa_ToTrinh ctktxm)
        {
            try
            {
                if (_db.MaHoa_ToTrinhs.Any(item => item.ID.ToString().Substring(0, 2) == DateTime.Now.ToString("yy")) == true)
                {
                    object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),3,5))+1 from MaHoa_ToTrinh where ID like '" + DateTime.Now.ToString("yy") + "%'");
                    if (stt != null)
                        ctktxm.ID = int.Parse(DateTime.Now.ToString("yy") + ((int)stt).ToString("00000"));
                }
                else
                {
                    ctktxm.ID = int.Parse(DateTime.Now.ToString("yy") + 1.ToString("00000"));
                }
                ctktxm.CreateDate = DateTime.Now;
                ctktxm.CreateBy = CNguoiDung.MaND;
                _db.MaHoa_ToTrinhs.InsertOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(MaHoa_ToTrinh ctktxm)
        {
            try
            {
                ctktxm.ModifyDate = DateTime.Now;
                ctktxm.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(MaHoa_ToTrinh ctktxm)
        {
            try
            {
                if (_db.MaHoa_DonTu_LichSus.SingleOrDefault(item => item.TableName == "ToTrinh" && item.IDCT == ctktxm.ID) != null)
                    _db.MaHoa_DonTu_LichSus.DeleteOnSubmit(_db.MaHoa_DonTu_LichSus.SingleOrDefault(item => item.TableName == "ToTrinh" && item.IDCT == ctktxm.ID));
                _db.MaHoa_ToTrinh_Hinhs.DeleteAllOnSubmit(ctktxm.MaHoa_ToTrinh_Hinhs.ToList());
                _db.MaHoa_ToTrinhs.DeleteOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_ToTrinh get(int ID)
        {
            return _db.MaHoa_ToTrinhs.SingleOrDefault(item => item.ID == ID);
        }

        public MaHoa_ToTrinh get_MaDon(int MaDon)
        {
            return _db.MaHoa_ToTrinhs.SingleOrDefault(item => item.IDMaDon == MaDon);
        }

        public DataTable getDS(int FromDot, int ToDot, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.MaHoa_ToTrinhs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.Dot >= FromDot && item.Dot <= ToDot && item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.VeViec,
                            CreateBy = itemtableND.HoTen,
                            item.ThuDuocKy,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_MaDon(int MaDon)
        {
            var query = from item in _db.MaHoa_ToTrinhs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.IDMaDon == MaDon
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.VeViec,
                            CreateBy = itemtableND.HoTen,
                            item.ThuDuocKy,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_MaDon(int FromMaDon, int ToMaDon)
        {
            var query = from item in _db.MaHoa_ToTrinhs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.IDMaDon >= FromMaDon && item.IDMaDon <= ToMaDon
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.VeViec,
                            CreateBy = itemtableND.HoTen,
                            item.ThuDuocKy,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_SoPhieu(int SoPhieu)
        {
            var query = from item in _db.MaHoa_ToTrinhs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.ID == SoPhieu
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.VeViec,
                            CreateBy = itemtableND.HoTen,
                            item.ThuDuocKy,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_SoPhieu(int FromSoPhieu, int ToSoPhieu)
        {
            var query = from item in _db.MaHoa_ToTrinhs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.ID >= FromSoPhieu && item.ID <= ToSoPhieu
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.VeViec,
                            CreateBy = itemtableND.HoTen,
                            item.ThuDuocKy,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_DanhBo(string DanhBo)
        {
            var query = from item in _db.MaHoa_ToTrinhs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.DanhBo == DanhBo
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.VeViec,
                            CreateBy = itemtableND.HoTen,
                            item.ThuDuocKy,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public bool checkExist(int MaDon, string DanhBo, DateTime CreateDate)
        {
            return _db.MaHoa_ToTrinhs.Any(item => item.IDMaDon == MaDon && item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        #region Hình

        public bool Them_Hinh(MaHoa_ToTrinh_Hinh en)
        {
            try
            {
                if (_db.MaHoa_ToTrinh_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.MaHoa_ToTrinh_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.MaHoa_ToTrinh_Hinhs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(MaHoa_ToTrinh_Hinh en)
        {
            try
            {
                _db.MaHoa_ToTrinh_Hinhs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_ToTrinh_Hinh get_Hinh(int ID)
        {
            return _db.MaHoa_ToTrinh_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion

        #region Về Việc

        public bool Them(MaHoa_ToTrinh_VeViec ctktxm)
        {
            try
            {
                if (_db.MaHoa_ToTrinh_VeViecs.Count() > 0)
                {
                    ctktxm.ID = _db.MaHoa_ToTrinh_VeViecs.Max(item => item.ID) + 1;
                }
                else
                {
                    ctktxm.ID = 1;
                }
                ctktxm.CreateDate = DateTime.Now;
                ctktxm.CreateBy = CNguoiDung.MaND;
                _db.MaHoa_ToTrinh_VeViecs.InsertOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(MaHoa_ToTrinh_VeViec ctktxm)
        {
            try
            {
                ctktxm.ModifyDate = DateTime.Now;
                ctktxm.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(MaHoa_ToTrinh_VeViec ctktxm)
        {
            try
            {
                _db.MaHoa_ToTrinh_VeViecs.DeleteOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_ToTrinh_VeViec get_VeViec(int ID)
        {
            return _db.MaHoa_ToTrinh_VeViecs.SingleOrDefault(item => item.ID == ID);
        }

        public List<MaHoa_ToTrinh_VeViec> getDS_VeViec()
        {
            return _db.MaHoa_ToTrinh_VeViecs.OrderBy(item => item.STT).ToList();
        }

        #endregion

    }
}
