using System;
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
                if (DateTime.Now.Year == 2023)
                {
                    if (_db.MaHoa_DonTus.Any(item => item.ID.ToString().Substring(0, 2) == DateTime.Now.ToString("yy")) == true)
                    {
                        object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),3,5))+1 from MaHoa_DonTu where ID like '" + DateTime.Now.ToString("yy") + "%'");
                        if (stt != null)
                            entity.ID = int.Parse(DateTime.Now.ToString("yy") + ((int)stt).ToString("00000"));
                    }
                    else
                    {
                        entity.ID = int.Parse(DateTime.Now.ToString("yy") + 1.ToString("00000"));
                    }
                }
                //else
                //{
                //    if (_db.MaHoa_DonTus.Any(item => item.ID.ToString().Substring(0, 4) == DateTime.Now.ToString("yyMM")) == true)
                //    {
                //        object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),5,4))+1 from MaHoa_DonTu where ID like '" + DateTime.Now.ToString("yyMM") + "%'");
                //        if (stt != null)
                //            entity.ID = int.Parse(DateTime.Now.ToString("yyMM") + ((int)stt).ToString("0000"));
                //    }
                //    else
                //    {
                //        entity.ID = int.Parse(DateTime.Now.ToString("yyMM") + 1.ToString("0000"));
                //    }
                //}
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

        public bool checkExists(string DanhBo, DateTime CreateDate)
        {
            return _db.MaHoa_DonTus.Any(item => item.DanhBo == DanhBo && item.CreateDate.Date == CreateDate.Date);
        }

        public MaHoa_DonTu get(int ID)
        {
            return _db.MaHoa_DonTus.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(string MaTo, string NoiDung, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            if (MaTo == "0")
                return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && NoiDung.IndexOf(item.NoiDung) >= 0));
            else
                return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && NoiDung.IndexOf(item.NoiDung) >= 0 && Convert.ToInt32(item.MLT.Substring(2, 2)) >= _db.Tos.SingleOrDefault(t => t.MaTo == Convert.ToInt32(MaTo)).TuMay && Convert.ToInt32(item.MLT.Substring(2, 2)) <= _db.Tos.SingleOrDefault(t => t.MaTo == Convert.ToInt32(MaTo)).DenMay));
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date).ToList());
        }

        public DataTable getDS(int MaDon)
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.ID == MaDon));
        }

        public DataTable getDS_DanhBo(string DanhBo)
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.DanhBo == DanhBo));
        }

        public DataTable getDS_Ton(string MaTo, string NoiDung)
        {
            if (MaTo == "0")
                return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.TinhTrang.Contains("Tồn") && NoiDung.IndexOf(item.NoiDung) >= 0));
            else
                return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.TinhTrang.Contains("Tồn") && NoiDung.IndexOf(item.NoiDung) >= 0 && Convert.ToInt32(item.MLT.Substring(2, 2)) >= _db.Tos.SingleOrDefault(t => t.MaTo == Convert.ToInt32(MaTo)).TuMay && Convert.ToInt32(item.MLT.Substring(2, 2)) <= _db.Tos.SingleOrDefault(t => t.MaTo == Convert.ToInt32(MaTo)).DenMay));
        }

        public DataTable getDS_Ton(string MaTo, string NoiDung, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            if (MaTo == "0")
                return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.TinhTrang.Contains("Tồn") && item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && NoiDung.IndexOf(item.NoiDung) >= 0));
            else
                return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.TinhTrang.Contains("Tồn") && item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && NoiDung.IndexOf(item.NoiDung) >= 0 && Convert.ToInt32(item.MLT.Substring(2, 2)) >= _db.Tos.SingleOrDefault(t => t.MaTo == Convert.ToInt32(MaTo)).TuMay && Convert.ToInt32(item.MLT.Substring(2, 2)) <= _db.Tos.SingleOrDefault(t => t.MaTo == Convert.ToInt32(MaTo)).DenMay));
        }

        public DataTable getDS_Ton(string MaTo, string NoiDung, int Nam, int Ky, int Dot)
        {
            if (MaTo == "0")
                return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.TinhTrang.Contains("Tồn") && NoiDung.IndexOf(item.NoiDung) >= 0 && item.Nam == Nam && item.Ky == Ky && item.Dot == Dot));
            else
                return _cDAL.LINQToDataTable(_db.MaHoa_DonTus.Where(item => item.TinhTrang.Contains("Tồn") && NoiDung.IndexOf(item.NoiDung) >= 0 && item.Nam == Nam && item.Ky == Ky && item.Dot == Dot && Convert.ToInt32(item.MLT.Substring(2, 2)) >= _db.Tos.SingleOrDefault(t => t.MaTo == Convert.ToInt32(MaTo)).TuMay && Convert.ToInt32(item.MLT.Substring(2, 2)) <= _db.Tos.SingleOrDefault(t => t.MaTo == Convert.ToInt32(MaTo)).DenMay));
        }

        public DataTable getDS_ChuyenDCBD(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in _db.MaHoa_DonTus
                        where item.CreateDate.Date >= FromCreateDate.Date && item.CreateDate.Date <= ToCreateDate.Date && item.TinhTrang == "Tồn (Điều Chỉnh)"
                        select new
                        {
                            item.ID,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.GhiChu,
                            item.Dot,
                            //GiaBieuCu = _db.MaHoa_PhieuChuyens.Any(itemC => itemC.Name == item.NoiDung) ? _db.MaHoa_PhieuChuyens.SingleOrDefault(itemC => itemC.Name == item.NoiDung).FromValue : "",
                            GiaBieuMoi = _db.MaHoa_PhieuChuyens.Any(itemC => itemC.Name == item.NoiDung) ? _db.MaHoa_PhieuChuyens.SingleOrDefault(itemC => itemC.Name == item.NoiDung).ToValue : "",
                        };
            return _cDAL.LINQToDataTable(query);
        }

        public DataTable getDS_PhieuChuyenApp()
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_PhieuChuyens.Where(item => item.App == true).ToList());
        }

        public DataTable getDS_PhieuChuyenApp_KhongLapDon()
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_PhieuChuyens.Where(item => item.App == true && item.KhongLapDon == true).ToList());
        }

        public DataTable getDS_PhieuChuyenPC()
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_PhieuChuyens.Where(item => item.PC == true).ToList());
        }

        public DataTable getDS_PhieuChuyenAll()
        {
            return _cDAL.LINQToDataTable(_db.MaHoa_PhieuChuyens.ToList());
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

        public DataTable getDS_ChuyenKTXM(DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "select MaDon=dt.ID,dt.DanhBo,dt.HoTen,dt.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,dt.NoiDung,"
                        + " KTXM=case when exists(select ID from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) then 'true' else case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end end,"
                        + " NgayKTXM=case when exists(select ID from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) then (select top 1 NgayChuyen from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) else case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 NgayKTXM from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date))) else null end end,"
                        + " NoiDungKTXM=case when exists(select ID from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) then (select top 1 NoiNhan from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) else case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 NoiDungKiemTra from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date))) else null end end,"
                        + " NguoiKTXM=(select HoTen from NguoiDung where MaND=dtls.ID_KTXM)"
                        + " from MaHoa_DonTu_LichSu dtls,MaHoa_DonTu dt"
                        + " where dtls.IDMaDon=dt.ID and ID_NoiNhan=2 and dtls.Huy=0"
                        + " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'"
                        + " order by dt.ID";
            //string sql = "select MaDon=dt.ID,dt.DanhBo,dt.HoTen,dt.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,dt.NoiDung,"
            //            + " KTXM=case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
            //            + " NgayKTXM=case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 NgayKTXM from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date))) else null end,"
            //            + " NoiDungKTXM=case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 NoiDungKiemTra from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date))) else null end,"
            //            + " NguoiKTXM=(select HoTen from NguoiDung where MaND=dtls.ID_KTXM)"
            //            + " from MaHoa_DonTu_LichSu dtls,MaHoa_DonTu dt"
            //            + " where dtls.IDMaDon=dt.ID and ID_NoiNhan=2 and dtls.Huy=0"
            //            + " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'"
            //            + " order by dt.ID";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(int MaNV_KTXM, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "select MaDon=dt.ID,dt.DanhBo,dt.HoTen,dt.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,dt.NoiDung,"
                        + " KTXM=case when exists(select ID from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) then 'true' else case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end end,"
                        + " NgayKTXM=case when exists(select ID from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) then (select top 1 NgayChuyen from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) else case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 NgayKTXM from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date))) else null end end,"
                        + " NoiDungKTXM=case when exists(select ID from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) then (select top 1 NoiNhan from MaHoa_DonTu_LichSu where ID_NoiNhan=6 and IDMaDon=dt.ID) else case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 NoiDungKiemTra from MaHoa_KTXM where IDMaDon=dt.ID and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date))) else null end end,"
                        + " NguoiKTXM=(select HoTen from NguoiDung where MaND=dtls.ID_KTXM)"
                        + " from MaHoa_DonTu_LichSu dtls,MaHoa_DonTu dt"
                        + " where dtls.IDMaDon=dt.ID and ID_NoiNhan=2 and dtls.Huy=0 and ID_KTXM=" + MaNV_KTXM
                        + " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'"
                        + " order by dt.ID";
            //string sql = "select MaDon=dt.ID,dt.DanhBo,dt.HoTen,dt.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,dt.NoiDung,"
            //            + " KTXM=case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
            //            + " NgayKTXM=case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 NgayKTXM from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date))) else null end,"
            //            + " NoiDungKTXM=case when exists(select ID from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 NoiDungKiemTra from MaHoa_KTXM where IDMaDon=dt.ID and CreateBy=dtls.ID_KTXM and (NgayKTXM_Truoc_NgayGiao=1 or cast(NgayKTXM as date)>=cast(dtls.NgayChuyen as date))) else null end,"
            //            + " NguoiKTXM=(select HoTen from NguoiDung where MaND=dtls.ID_KTXM)"
            //            + " from MaHoa_DonTu_LichSu dtls,MaHoa_DonTu dt"
            //            + " where dtls.IDMaDon=dt.ID and ID_NoiNhan=2 and dtls.Huy=0 and ID_KTXM=" + MaNV_KTXM
            //            + " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'"
            //            + " order by dt.ID";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenPhongDoi(DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            return _cDAL.ExecuteQuery_DataTable("select MaDon=dt.ID,ls.NgayChuyen,dt.DanhBo,dt.DiaChi,ls.NoiNhan,ls.NoiDung from MaHoa_DonTu dt,MaHoa_DonTu_LichSu ls,MaHoa_NoiChuyen nc"
                    + " where dt.ID=ls.IDMaDon and ls.ID_NoiNhan=nc.ID and nc.PhongDoi=1"
                    + " and ls.NgayChuyen>='" + FromNgayChuyen.ToString("yyyyMMdd HH:mm") + ":00' and ls.NgayChuyen<='" + ToNgayChuyen.ToString("yyyyMMdd HH:mm") + ":00'");
        }

        #endregion


        #region Hình

        public bool Them_Hinh(MaHoa_DonTu_Hinh en)
        {
            try
            {
                if (_db.MaHoa_DonTu_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = _db.MaHoa_DonTu_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.MaHoa_DonTu_Hinhs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(MaHoa_DonTu_Hinh en)
        {
            try
            {
                _db.MaHoa_DonTu_Hinhs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_DonTu_Hinh get_Hinh(int ID)
        {
            return _db.MaHoa_DonTu_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion

        public DataTable getDS_AmSau(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Âm Sâu',CREATEDATE=AmSau_Ngay,Folder='AmSau',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Âm Sâu' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_AmSau(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Âm Sâu',CREATEDATE=AmSau_Ngay,Folder='AmSau',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Âm Sâu' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_AmSau(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Âm Sâu',CREATEDATE=AmSau_Ngay,Folder='AmSau',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Âm Sâu' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XayDung(string DanhBo)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Xây Dựng',CREATEDATE=XayDung_Ngay,Folder='XayDung',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Xây Dựng' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XayDung(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Xây Dựng',CREATEDATE=XayDung_Ngay,Folder='XayDung',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Xây Dựng' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XayDung(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Xây Dựng',CREATEDATE=XayDung_Ngay,Folder='XayDung',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Xây Dựng' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiGoc(string DanhBo)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc',CREATEDATE=DutChi_Goc_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Góc' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiGoc(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc',CREATEDATE=DutChi_Goc_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Góc' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiGoc(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc',CREATEDATE=DutChi_Goc_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Góc' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiThan(string DanhBo)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Thân' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiThan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Thân' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiThan(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Thân' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NgapNuoc(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Ngập Nước',CREATEDATE=NgapNuoc_Ngay,Folder='NgapNuoc',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Ngập Nước' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NgapNuoc(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Ngập Nước',CREATEDATE=NgapNuoc_Ngay,Folder='NgapNuoc',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Ngập Nước' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NgapNuoc(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Ngập Nước',CREATEDATE=NgapNuoc_Ngay,Folder='NgapNuoc',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Ngập Nước' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KetTuong(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Kẹt Tường',CREATEDATE=KetTuong_Ngay,Folder='KetTuong',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Kẹt Tường' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KetTuong(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Kẹt Tường',CREATEDATE=KetTuong_Ngay,Folder='KetTuong',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Kẹt Tường' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KetTuong(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Kẹt Tường',CREATEDATE=KetTuong_Ngay,Folder='KetTuong',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Kẹt Tường' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_LapKhoaGoc(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Lấp Khóa Góc',CREATEDATE=LapKhoaGoc_Ngay,Folder='LapKhoaGoc',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Lấp Khóa Góc' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_LapKhoaGoc(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Lấp Khóa Góc',CREATEDATE=LapKhoaGoc_Ngay,Folder='LapKhoaGoc',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Lấp Khóa Góc' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_LapKhoaGoc(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Lấp Khóa Góc',CREATEDATE=LapKhoaGoc_Ngay,Folder='LapKhoaGoc',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Lấp Khóa Góc' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeHBV(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể HBV',CREATEDATE=BeHBV_Ngay,Folder='BeHBV',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể HBV' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeHBV(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể HBV',CREATEDATE=BeHBV_Ngay,Folder='BeHBV',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể HBV' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeHBV(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể HBV',CREATEDATE=BeHBV_Ngay,Folder='BeHBV',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể HBV' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeNapMatNapHBV(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể Nấp, Mất Nấp HBV',CREATEDATE=BeNapMatNapHBV_Ngay,Folder='BeNapMatNapHBV',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể Nấp, Mất Nấp HBV' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeNapMatNapHBV(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể Nấp, Mất Nấp HBV',CREATEDATE=BeNapMatNapHBV_Ngay,Folder='BeNapMatNapHBV',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể Nấp, Mất Nấp HBV' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeNapMatNapHBV(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể Nấp, Mất Nấp HBV',CREATEDATE=BeNapMatNapHBV_Ngay,Folder='BeNapMatNapHBV',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể Nấp, Mất Nấp HBV' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GayTayVan(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Gãy Tay Van',CREATEDATE=GayTayVan_Ngay,Folder='GayTayVan',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Gãy Tay Van' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GayTayVan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Gãy Tay Van',CREATEDATE=GayTayVan_Ngay,Folder='GayTayVan',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Gãy Tay Van' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GayTayVan(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Gãy Tay Van',CREATEDATE=GayTayVan_Ngay,Folder='GayTayVan',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Gãy Tay Van' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_TroNgaiThay(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Trở Ngại Thay',CREATEDATE=TroNgaiThay_Ngay,Folder='TroNgaiThay',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Trở Ngại Thay' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_TroNgaiThay(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Trở Ngại Thay',CREATEDATE=TroNgaiThay_Ngay,Folder='TroNgaiThay',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Trở Ngại Thay' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_TroNgaiThay(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Trở Ngại Thay',CREATEDATE=TroNgaiThay_Ngay,Folder='TroNgaiThay',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Trở Ngại Thay' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DauChungMayBom(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đấu Chung Máy Bơm',CREATEDATE=DauChungMayBom_Ngay,Folder='DauChungMayBom',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đấu Chung Máy Bơm' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DauChungMayBom(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đấu Chung Máy Bơm',CREATEDATE=DauChungMayBom_Ngay,Folder='DauChungMayBom',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đấu Chung Máy Bơm' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DauChungMayBom(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đấu Chung Máy Bơm',CREATEDATE=DauChungMayBom_Ngay,Folder='DauChungMayBom',a.ID,a.GhiChu,a.TinhTrang"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đấu Chung Máy Bơm' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

    }
}
