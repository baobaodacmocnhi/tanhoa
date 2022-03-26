﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL.MaHoa
{
    class CKTXM : CDAL
    {
        public DataTable getDS_HienTrang()
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_KTXM_HienTrangs.OrderBy(item => item.Name).ToList());
        }

        public bool Them(MaHoa_KTXM ctktxm)
        {
            try
            {
                if (_db.MaHoa_KTXMs.Any(item => item.ID.ToString().Substring(0, 4) == DateTime.Now.ToString("yyMM")) == true)
                {
                    object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),5,4))+1 from MaHoa_KTXM where ID like '" + DateTime.Now.ToString("yyMM") + "%'");
                    if (stt != null)
                        ctktxm.ID = int.Parse(DateTime.Now.ToString("yyMM") + ((int)stt).ToString("0000"));
                }
                else
                {
                    ctktxm.ID = int.Parse(DateTime.Now.ToString("yyMM") + 1.ToString("0000"));
                }
                ctktxm.CreateDate = DateTime.Now;
                ctktxm.CreateBy = CNguoiDung.MaND;
                _db.MaHoa_KTXMs.InsertOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(MaHoa_KTXM ctktxm)
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

        public bool Xoa(MaHoa_KTXM ctktxm)
        {
            try
            {
                _db.MaHoa_DonTu_LichSus.DeleteOnSubmit(_db.MaHoa_DonTu_LichSus.SingleOrDefault(item => item.TableName == "KTXM" && item.IDCT == ctktxm.ID));
                _db.MaHoa_KTXM_Hinhs.DeleteAllOnSubmit(ctktxm.MaHoa_KTXM_Hinhs.ToList());
                _db.MaHoa_KTXMs.DeleteOnSubmit(ctktxm);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_KTXM get(int ID)
        {
            return _db.MaHoa_KTXMs.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(int MaDon)
        {
            var query = from itemCTKTXM in _db.MaHoa_KTXMs
                        join itemUser in _db.NguoiDungs on itemCTKTXM.CreateBy equals itemUser.MaND
                        where itemCTKTXM.IDMaDon == MaDon
                        select new
                        {
                            MaDon = itemCTKTXM.IDMaDon,
                            TenLD = itemCTKTXM.MaHoa_DonTu.NoiDung,
                            MaCTKTXM = itemCTKTXM.ID,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                            itemCTKTXM.BanChinh,
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public bool checkExist(int CreateBy, int MaDon,  string DanhBo, DateTime NgayKTXM, string HienTrangKiemTra)
        {
            return _db.MaHoa_KTXMs.Any(item => item.CreateBy == CreateBy && item.IDMaDon == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM && item.HienTrangKiemTra == HienTrangKiemTra);
        }

        #region Hình

        public bool Them_Hinh(MaHoa_KTXM_Hinh en)
        {
            try
            {
                if (_db.MaHoa_KTXM_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.MaHoa_KTXM_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.MaHoa_KTXM_Hinhs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(MaHoa_KTXM_Hinh en)
        {
            try
            {
                _db.MaHoa_KTXM_Hinhs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_KTXM_Hinh get_Hinh(int ID)
        {
            return _db.MaHoa_KTXM_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}