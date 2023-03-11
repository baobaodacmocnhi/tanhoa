using System;
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
                if (_db.MaHoa_KTXMs.Any(item => item.ID.ToString().Substring(0, 2) == DateTime.Now.ToString("yy")) == true)
                {
                    object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),3,5))+1 from MaHoa_KTXM where ID like '" + DateTime.Now.ToString("yy") + "%'");
                    if (stt != null)
                        ctktxm.ID = int.Parse(DateTime.Now.ToString("yy") + ((int)stt).ToString("00000"));
                }
                else
                {
                    ctktxm.ID = int.Parse(DateTime.Now.ToString("yy") + 1.ToString("00000"));
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
                if (_db.MaHoa_DonTu_LichSus.Any(item => item.TableName == "KTXM" && item.IDCT == ctktxm.ID))
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

        public MaHoa_KTXM get_MaDon(int MaDon)
        {
            return _db.MaHoa_KTXMs.SingleOrDefault(item => item.IDMaDon == MaDon);
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

        public DataTable getDS(int MaNV_KTXM, DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            var query = from itemCTKTXM in _db.MaHoa_KTXMs
                        join itemUser in _db.NguoiDungs on itemCTKTXM.CreateBy equals itemUser.MaND
                        where itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                        && itemCTKTXM.CreateBy == MaNV_KTXM
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

        public bool checkExist(int CreateBy, int MaDon, string DanhBo, DateTime NgayKTXM, string HienTrangKiemTra)
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

        public byte[] get_Hinh_ByteArray(string DanhBo, int Nam, int Ky)
        {
            wrDHN.wsDHN wsDHN = new wrDHN.wsDHN();
            if (_db.MaHoa_KTXMs.Any(item => item.DanhBo == DanhBo && item.Nam == Nam && item.Ky == Ky && item.MaHoa_KTXM_Hinhs.Count > 0))
            {
                MaHoa_KTXM_Hinh hinh = _db.MaHoa_KTXMs.SingleOrDefault(item => item.DanhBo == DanhBo && item.Nam == Nam && item.Ky == Ky).MaHoa_KTXM_Hinhs.FirstOrDefault();
                byte[] hinhbyte = wsDHN.get_Hinh_MaHoa("KTXM", hinh.IDParent.Value.ToString(), hinh.Name + hinh.Loai);
                return hinhbyte;
            }
            else
                return null;
        }

        public DataTable getDS_Hinh(string DanhBo, int Nam, int Ky)
        {
            string sql = "select Ky=convert(char(2),a.Ky)+'/'+convert(char(4),a.Nam),a.ID,b.Name,b.Loai,a.NoiDungKiemTra from MaHoa_KTXM a,MaHoa_KTXM_Hinh b"
                        + " where a.DanhBo='" + DanhBo + "' and (a.Nam*12+a.Ky)>=(" + Nam + "*12+" + (Ky - 3) + ") and a.ID=b.IDParent";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        #endregion
    }
}
