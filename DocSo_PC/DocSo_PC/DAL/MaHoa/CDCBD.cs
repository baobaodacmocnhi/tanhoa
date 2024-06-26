﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;
using System.Data;

namespace DocSo_PC.DAL.MaHoa
{
    class CDCBD : CDAL
    {
        public bool Them(MaHoa_DCBD ctktxm)
        {
            try
            {
                if (_db.MaHoa_DCBDs.Any(item => item.ID.ToString().Substring(0, 2) == DateTime.Now.ToString("yy")) == true)
                {
                    object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),3,5))+1 from MaHoa_DCBD where ID like '" + DateTime.Now.ToString("yy") + "%'");
                    if (stt != null)
                        ctktxm.ID = int.Parse(DateTime.Now.ToString("yy") + ((int)stt).ToString("00000"));
                }
                else
                {
                    ctktxm.ID = int.Parse(DateTime.Now.ToString("yy") + 1.ToString("00000"));
                }
                ctktxm.CreateDate = DateTime.Now;
                ctktxm.CreateBy = CNguoiDung.MaND;
                _db.MaHoa_DCBDs.InsertOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(MaHoa_DCBD ctktxm)
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

        public bool Xoa(MaHoa_DCBD ctktxm)
        {
            try
            {
                if (_db.MaHoa_DonTu_LichSus.Any(item => item.TableName == "DCBD" && item.IDCT == ctktxm.ID))
                    _db.MaHoa_DonTu_LichSus.DeleteOnSubmit(_db.MaHoa_DonTu_LichSus.SingleOrDefault(item => item.TableName == "DCBD" && item.IDCT == ctktxm.ID));
                _db.MaHoa_DCBD_Hinhs.DeleteAllOnSubmit(ctktxm.MaHoa_DCBD_Hinhs.ToList());
                _db.MaHoa_DCBDs.DeleteOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(int MaDon, string DanhBo)
        {
            return _db.MaHoa_DCBDs.Any(item => item.IDMaDon == MaDon && item.DanhBo == DanhBo);
        }

        public bool checkExist(string DanhBo, int SoNgay)
        {
            return _db.MaHoa_DCBDs.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.AddDays(SoNgay) >= DateTime.Now);
        }

        public MaHoa_DCBD get(int ID)
        {
            return _db.MaHoa_DCBDs.SingleOrDefault(item => item.ID == ID);
        }

        public MaHoa_DCBD get_MaDon(int MaDon)
        {
            return _db.MaHoa_DCBDs.SingleOrDefault(item => item.IDMaDon == MaDon);
        }

        public DataTable getDS(int FromDot, int ToDot, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.MaHoa_DCBDs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.Dot >= FromDot && item.Dot <= ToDot && item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.ThongTin,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.DiaChi_BD,
                            item.Dot,
                            item.GiaBieu,
                            item.GiaBieu_BD,
                            item.CongDung,
                            item.PhieuDuocKy,
                            item.HieuLucKy,
                            CreateBy = itemtableND.HoTen,
                            item.ChuyenDocSo,
                            item.IDMaDon,
                            item.MaHoa_DonTu.MLT,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_MaDon(int MaDon)
        {
            var query = from item in _db.MaHoa_DCBDs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.IDMaDon == MaDon
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.ThongTin,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.DiaChi_BD,
                            item.Dot,
                            item.GiaBieu,
                            item.GiaBieu_BD,
                            item.CongDung,
                            item.PhieuDuocKy,
                            item.HieuLucKy,
                            CreateBy = itemtableND.HoTen,
                            item.ChuyenDocSo,
                            item.IDMaDon,
                            item.MaHoa_DonTu.MLT,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_MaDon(int FromMaDon, int ToMaDon)
        {
            var query = from item in _db.MaHoa_DCBDs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.IDMaDon.Value >= FromMaDon && item.IDMaDon.Value <= ToMaDon
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.ThongTin,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.DiaChi_BD,
                            item.Dot,
                            item.GiaBieu,
                            item.GiaBieu_BD,
                            item.CongDung,
                            item.PhieuDuocKy,
                            item.HieuLucKy,
                            CreateBy = itemtableND.HoTen,
                            item.ChuyenDocSo,
                            item.IDMaDon,
                            item.MaHoa_DonTu.MLT,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_SoPhieu(int SoPhieu)
        {
            var query = from item in _db.MaHoa_DCBDs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.ID == SoPhieu
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.ThongTin,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.DiaChi_BD,
                            item.Dot,
                            item.GiaBieu,
                            item.GiaBieu_BD,
                            item.CongDung,
                            item.PhieuDuocKy,
                            item.HieuLucKy,
                            CreateBy = itemtableND.HoTen,
                            item.ChuyenDocSo,
                            item.IDMaDon,
                            item.MaHoa_DonTu.MLT,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_SoPhieu(int FromSoPhieu, int ToSoPhieu)
        {
            var query = from item in _db.MaHoa_DCBDs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.ID >= FromSoPhieu && item.ID <= ToSoPhieu
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.ThongTin,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.DiaChi_BD,
                            item.Dot,
                            item.GiaBieu,
                            item.GiaBieu_BD,
                            item.CongDung,
                            item.PhieuDuocKy,
                            item.HieuLucKy,
                            CreateBy = itemtableND.HoTen,
                            item.ChuyenDocSo,
                            item.IDMaDon,
                            item.MaHoa_DonTu.MLT,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_DanhBo(string DanhBo)
        {
            var query = from item in _db.MaHoa_DCBDs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.DanhBo == DanhBo
                        orderby item.CreateDate descending
                        select new
                        {
                            Chon = true,
                            item.ID,
                            item.ThongTin,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.DiaChi_BD,
                            item.Dot,
                            item.GiaBieu,
                            item.GiaBieu_BD,
                            item.CongDung,
                            item.PhieuDuocKy,
                            item.HieuLucKy,
                            CreateBy = itemtableND.HoTen,
                            item.ChuyenDocSo,
                            item.IDMaDon,
                            item.MaHoa_DonTu.MLT,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        #region Hình

        public bool Them_Hinh(MaHoa_DCBD_Hinh en)
        {
            try
            {
                if (_db.MaHoa_DCBD_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.MaHoa_DCBD_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.MaHoa_DCBD_Hinhs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(MaHoa_DCBD_Hinh en)
        {
            try
            {
                _db.MaHoa_DCBD_Hinhs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_DCBD_Hinh get_Hinh(int ID)
        {
            return _db.MaHoa_DCBD_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}
