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
                if (_db.MaHoa_ToTrinhs.Any(item => item.ID.ToString().Substring(0, 4) == DateTime.Now.ToString("yyMM")) == true)
                {
                    object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),5,4))+1 from MaHoa_ToTrinh where ID like '" + DateTime.Now.ToString("yyMM") + "%'");
                    if (stt != null)
                        ctktxm.ID = int.Parse(DateTime.Now.ToString("yyMM") + ((int)stt).ToString("0000"));
                }
                else
                {
                    ctktxm.ID = int.Parse(DateTime.Now.ToString("yyMM") + 1.ToString("0000"));
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

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.MaHoa_ToTrinhs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
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
                            CreateBy = itemtableND.HoTen,
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