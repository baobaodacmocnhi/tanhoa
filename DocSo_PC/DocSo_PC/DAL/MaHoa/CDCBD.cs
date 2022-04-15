using System;
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
                if (_db.MaHoa_DCBDs.Any(item => item.ID.ToString().Substring(0, 4) == DateTime.Now.ToString("yyMM")) == true)
                {
                    object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),5,4))+1 from MaHoa_DCBD where ID like '" + DateTime.Now.ToString("yyMM") + "%'");
                    if (stt != null)
                        ctktxm.ID = int.Parse(DateTime.Now.ToString("yyMM") + ((int)stt).ToString("0000"));
                }
                else
                {
                    ctktxm.ID = int.Parse(DateTime.Now.ToString("yyMM") + 1.ToString("0000"));
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

        public MaHoa_DCBD get(int ID)
        {
            return _db.MaHoa_DCBDs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.MaHoa_DCBDs
                        join itemND in _db.NguoiDungs on item.CreateBy equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
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
                            item.Dot,
                            item.GiaBieu,
                            item.GiaBieu_BD,
                            item.CongDung,
                            item.PhieuDuocKy,
                            item.HieuLucKy,
                            CreateBy = itemtableND.HoTen,
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
