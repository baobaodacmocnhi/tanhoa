﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;
using System.Data;

namespace DocSo_PC.DAL.MaHoa
{
    class CDonTu : CDAL
    {
        public bool Them(MaHoa_DonTu entity)
        {
            try
            {
                if (_db.MaHoa_DonTus.Any(item => item.ID.ToString().Substring(0, 4) == DateTime.Now.ToString("yyMM")) == true)
                {
                    object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),5,4))+1 from MaHoa_DonTu where ID like '" + DateTime.Now.ToString("yyMM") + "%'");
                    if (stt != null)
                        entity.ID = int.Parse(DateTime.Now.ToString("yyMM") + ((int)stt).ToString("0000"));
                }
                else
                {
                    entity.ID = int.Parse(DateTime.Now.ToString("yyMM") + 1.ToString("0000"));
                }
                entity.CreateBy = CNguoiDung.MaND;
                entity.CreateDate = DateTime.Now;
                _db.MaHoa_DonTus.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(MaHoa_DonTu entity)
        {
            try
            {
                entity.ModifyBy = CNguoiDung.MaND;
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(MaHoa_DonTu entity)
        {
            try
            {
                _db.MaHoa_DonTu_LichSus.DeleteAllOnSubmit(entity.MaHoa_DonTu_LichSus.ToList());
                _db.MaHoa_DonTu_Hinhs.DeleteAllOnSubmit(entity.MaHoa_DonTu_Hinhs.ToList());
                _db.MaHoa_DonTus.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_DonTu get(int ID)
        {
            return _db.MaHoa_DonTus.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date).ToList());
        }

        public DataTable getDS_ChuyenDCBD(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.TinhTrang == "Tồn (Điều Chỉnh)").ToList());
        }

        #region Nơi Chuyển

        public DataTable getDS_NoiChuyen()
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_NoiChuyens.Where(item => item.DonTuChuyen == true).OrderBy(item => item.STT).ToList());
        }

        public DataTable getDS_NoiNhan()
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_NoiChuyens.Where(item => item.DonTuNhan == true).OrderBy(item => item.STT).ToList());
        }

        #endregion


        #region Đơn Từ Lịch Sử

        public bool Them_LichSu(MaHoa_DonTu_LichSu entity)
        {
            try
            {
                if (_db.MaHoa_DonTu_LichSus.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = _db.MaHoa_DonTu_LichSus.Max(item => item.ID) + 1;
                entity.CreateBy = CNguoiDung.MaND;
                entity.CreateDate = DateTime.Now;
                _db.MaHoa_DonTu_LichSus.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Them_LichSu(DateTime NgayChuyen, string NoiChuyen, string NoiDung, int IDCT, int MaDon)
        {
            try
            {
                MaHoa_DonTu_LichSu entity = new MaHoa_DonTu_LichSu();
                entity.NgayChuyen = NgayChuyen;
                switch (NoiChuyen)
                {
                    case "KTXM":
                        entity.ID_NoiChuyen = 2;
                        entity.NoiChuyen = "Kiểm Tra";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "KTXM";
                        entity.IDCT = IDCT;
                        //entity.NgayChuyen = db.KTXM_ChiTiets.SingleOrDefault(item => item.MaCTKTXM == IDCT).NgayKTXM;
                        break;
                    case "DCBD":
                        entity.ID_NoiChuyen = 3;
                        entity.NoiChuyen = "Điều Chỉnh";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "DCBD";
                        entity.IDCT = IDCT;
                        break;
                    default:
                        break;
                }
                entity.IDMaDon = MaDon;
                if (_db.MaHoa_DonTu_LichSus.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = _db.MaHoa_DonTu_LichSus.Max(item => item.ID) + 1;
                entity.CreateBy = CNguoiDung.MaND;
                entity.CreateDate = DateTime.Now;
                _db.MaHoa_DonTu_LichSus.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_LichSu(MaHoa_DonTu_LichSu entity)
        {
            try
            {
                _db.MaHoa_DonTu_LichSus.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_DonTu_LichSu get_LicSu(int ID)
        {
            return _db.MaHoa_DonTu_LichSus.SingleOrDefault(item => item.ID == ID);
        }

        public MaHoa_DonTu_LichSu get_LichSu(string TableName, int IDCT)
        {
            return _db.MaHoa_DonTu_LichSus.SingleOrDefault(item => item.TableName == TableName && item.IDCT == IDCT);
        }

        public DataTable getDS_LichSu(int MaDon)
        {
            var query = from itemLS in _db.MaHoa_DonTu_LichSus
                        join itemDon in _db.MaHoa_DonTus on itemLS.IDMaDon equals itemDon.ID
                        where itemDon.ID == MaDon
                        orderby itemLS.NgayChuyen descending, itemLS.ID descending
                        select new
                        {
                            itemLS.ID,
                            itemLS.NgayChuyen,
                            itemLS.NoiChuyen,
                            itemLS.NoiNhan,
                            itemLS.KTXM,
                            itemLS.NoiDung,
                            CreateBy = _db.NguoiDungs.SingleOrDefault(itemU => itemU.MaND == itemLS.CreateBy).HoTen,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        #endregion
    }
}