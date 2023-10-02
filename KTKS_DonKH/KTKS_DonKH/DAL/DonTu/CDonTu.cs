using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.DonTu
{
    class CDonTu : CDAL
    {
        public bool Them(LinQ.DonTu entity)
        {
            try
            {
                if (db.DonTus.Any(item => item.NamThang == DateTime.Now.ToString("yyMM")) == true)
                {
                    entity.STT = (int.Parse(db.DonTus.Where(item => item.NamThang == DateTime.Now.ToString("yyMM")).Max(item => item.STT)) + 1).ToString("0000");
                }
                else
                {
                    entity.STT = 1.ToString("0000");
                }
                entity.NamThang = DateTime.Now.ToString("yyMM");
                entity.MaDon = int.Parse(entity.NamThang + entity.STT);
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.DonTus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(LinQ.DonTu entity)
        {
            try
            {
                entity.ModifyBy = CTaiKhoan.MaUser;
                entity.ModifyDate = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(LinQ.DonTu entity)
        {
            try
            {
                db.DonTu_LichSus.DeleteAllOnSubmit(entity.DonTu_LichSus.ToList());
                db.DonTu_ChiTiets.DeleteAllOnSubmit(entity.DonTu_ChiTiets.ToList());
                db.DonTus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(int MaDon)
        {
            return db.DonTus.Any(item => item.MaDon == MaDon);
        }

        public bool checkPhong(int MaDon, int MaPhong)
        {
            return db.DonTus.Any(item => item.MaDon == MaDon && db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy.Value).MaPhong == MaPhong);
        }

        public LinQ.DonTu get(int MaDon)
        {
            return db.DonTus.SingleOrDefault(item => item.MaDon == MaDon);
        }

        public DataTable getDS(int MaDon)
        {
            //switch (Loai)
            //{
            //    case"Quầy":
            //        var query = from item in db.DonTus
            //                    where item.MaDon == MaDon && item.VanPhong==false
            //                    select new
            //                    {
            //                        item.MaDon,
            //                        item.SoCongVan,
            //                        item.CreateDate,
            //                        DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
            //                        HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
            //                        DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
            //                        NoiDung = item.Name_NhomDon,
            //                        CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
            //                    };
            //        return LINQToDataTable(query);
            //    case "Văn Phòng":
            //        var query1 = from item in db.DonTus
            //                where item.MaDon == MaDon && item.VanPhong == true
            //                    select new
            //                    {
            //                        item.MaDon,
            //                        item.SoCongVan,
            //                        item.CreateDate,
            //                        DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
            //                        HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
            //                        DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
            //                        NoiDung = item.Name_NhomDon,
            //                        CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
            //                    };
            //        return LINQToDataTable(query1);
            //    default:
            var query2 = from item in db.DonTus
                         where item.MaDon == MaDon
                         select new
                         {
                             item.MaDon,
                             item.SoCongVan,
                             item.CreateDate,
                             DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                             HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                             DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
                             NoiDung = item.Name_NhomDon,
                             CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                         };
            return LINQToDataTable(query2);
            //}

        }

        public DataTable getDS(int FromMaDon, int ToMaDon)
        {
            var query = from item in db.DonTus
                        where item.MaDon >= FromMaDon && item.MaDon <= ToMaDon
                        select new
                        {
                            item.MaDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_Phong(int MaDon, int MaPhong)
        {
            //switch (Loai)
            //{
            //    case "Quầy":
            //        var query = from item in db.DonTus
            //                    where item.MaDon == MaDon && db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).MaPhong == MaPhong&&item.VanPhong==false
            //                    select new
            //                    {
            //                        item.MaDon,
            //                        item.SoCongVan,
            //                        item.CreateDate,
            //                        DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
            //                        HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
            //                        DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
            //                        NoiDung = item.Name_NhomDon,
            //                        CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
            //                    };
            //        return LINQToDataTable(query);
            //    case "Văn Phòng":
            //        var query1 = from item in db.DonTus
            //                where item.MaDon == MaDon && db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).MaPhong == MaPhong && item.VanPhong == true
            //                    select new
            //                    {
            //                        item.MaDon,
            //                        item.SoCongVan,
            //                        item.CreateDate,
            //                        DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
            //                        HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
            //                        DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
            //                        NoiDung = item.Name_NhomDon,
            //                        CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
            //                    };
            //        return LINQToDataTable(query1);
            //    default:
            var query2 = from item in db.DonTus
                         where item.MaDon == MaDon && db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).MaPhong == MaPhong
                         select new
                         {
                             item.MaDon,
                             item.SoCongVan,
                             item.CreateDate,
                             DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                             HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                             DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
                             NoiDung = item.Name_NhomDon,
                             CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                         };
            return LINQToDataTable(query2);
            //}

        }

        public DataSet getDS_Phong_GridControl(int MaDon)
        {
            List<LinQ.DonTu> lst = db.DonTus.Where(item => item.MaDon == MaDon).ToList();
            return EntityToDataset(lst);
        }

        public DataSet getDS_Phong_GridControl(int MaDon, int MaPhong)
        {
            List<LinQ.DonTu> lst = db.DonTus.Where(item => item.MaDon == MaDon && item.MaPhong == MaPhong).ToList();
            return EntityToDataset(lst);
        }

        //public DataTable getDS(int FromMaDon, int ToMaDon)
        //{
        //    var query = from item in db.DonTus
        //                where item.MaDon >= FromMaDon && item.MaDon <= ToMaDon
        //                select new
        //                {
        //                    item.MaDon,
        //                    item.SoCongVan,
        //                    item.CreateDate,
        //                    DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
        //                    HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
        //                    DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
        //                    NoiDung = item.Name_NhomDon,
        //                    CreateBy=db.Users.SingleOrDefault(itemA=>itemA.MaU==item.CreateBy).HoTen,
        //                };
        //    return LINQToDataTable(query);
        //}

        public DataTable getDSBySoCongVan(string SoCongVan)
        {
            var query = from item in db.DonTus
                        where item.SoCongVan == SoCongVan
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
                            NoiDung = item.Name_NhomDon,
                            CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSBySoCongVan(string SoCongVan, int MaPhong)
        {
            var query = from item in db.DonTus
                        where item.SoCongVan == SoCongVan && item.MaPhong == MaPhong
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
                            NoiDung = item.Name_NhomDon,
                            CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataSet getDSBySoCongVan_GridControl(string SoCongVan)
        {
            List<LinQ.DonTu> lst = db.DonTus.Where(item => item.SoCongVan.Contains(SoCongVan)).ToList();
            return EntityToDataset(lst);
        }

        public DataSet getDSBySoCongVan_GridControl(string SoCongVan, int MaPhong)
        {
            List<LinQ.DonTu> lst = db.DonTus.Where(item => item.SoCongVan.Contains(SoCongVan) && item.MaPhong == MaPhong).ToList();
            return EntityToDataset(lst);
        }

        public DataTable getDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.DonTus
                        where item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
                            NoiDung = item.Name_NhomDon,
                            CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(string Loai, DateTime FromCreateDate, DateTime ToCreateDate, int MaPhong)
        {
            switch (Loai)
            {
                case "Quầy":
                    var query = from item in db.DonTus
                                where item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.MaPhong == MaPhong && item.VanPhong == false
                                select new
                                {
                                    item.MaDon,
                                    item.SoCongVan,
                                    item.CreateDate,
                                    DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                                    HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                                    DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
                                    NoiDung = item.VanDeKhac == null ? item.Name_NhomDon : item.Name_NhomDon + " " + item.VanDeKhac,
                                    CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                                };
                    return LINQToDataTable(query);
                case "Văn Phòng":
                    var query1 = from item in db.DonTus
                                 where item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.MaPhong == MaPhong && item.VanPhong == true
                                 select new
                                 {
                                     item.MaDon,
                                     item.SoCongVan,
                                     item.CreateDate,
                                     DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                                     HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                                     DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
                                     NoiDung = item.VanDeKhac == null ? item.Name_NhomDon : item.Name_NhomDon + " " + item.VanDeKhac,
                                     CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                                 };
                    return LINQToDataTable(query1);
                default:
                    var query2 = from item in db.DonTus
                                 where item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.MaPhong == MaPhong
                                 select new
                                 {
                                     item.MaDon,
                                     item.SoCongVan,
                                     item.CreateDate,
                                     DanhBo = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                                     HoTen = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                                     DiaChi = item.DonTu_ChiTiets.Count == 1 ? item.DonTu_ChiTiets.SingleOrDefault().DiaChi : "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ",
                                     NoiDung = item.VanDeKhac == null ? item.Name_NhomDon : item.Name_NhomDon + " " + item.VanDeKhac,
                                     CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                                 };
                    return LINQToDataTable(query2);
            }

        }

        public List<LinQ.DonTu> getDS_GridControl_Ton(string Loai, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            List<LinQ.DonTu> lst = new List<LinQ.DonTu>();
            switch (Loai)
            {
                case "Quầy":
                    lst = db.DonTus.Where(item => item.TinhTrang != "Hoàn Thành" && item.CreateDate.Value <= ToCreateDate && item.VanPhong == false).OrderBy(item => item.MaDon).ToList();
                    break;
                case "Văn Phòng":
                    lst = db.DonTus.Where(item => item.TinhTrang != "Hoàn Thành" && item.CreateDate.Value <= ToCreateDate && item.VanPhong == true).OrderBy(item => item.MaDon).ToList();
                    break;
                default:
                    lst = db.DonTus.Where(item => item.TinhTrang != "Hoàn Thành" && item.CreateDate.Value <= ToCreateDate).OrderBy(item => item.MaDon).ToList();
                    break;
            }
            return lst;
        }

        public DataSet getDS_GridControl(string Loai, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            //List<LinQ.DonTu> lst = new List<LinQ.DonTu>();
            //switch (Loai)
            //{
            //    case "Quầy":
            //        lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.VanPhong == false).OrderBy(item => item.MaDon).ToList();
            //        break;
            //    case "Văn Phòng":
            //        lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.VanPhong == true).OrderBy(item => item.MaDon).ToList();
            //        break;
            //    default:
            //        lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate).OrderBy(item => item.MaDon).ToList();
            //        break;
            //}
            //return EntityToDataset(lst);
            try
            {
                DataSet ds = new DataSet();

                string sqlDonTu = "select MaDon,SoCongVan,CreateDate=CONVERT(varchar(10),CreateDate,103)+' '+CONVERT(varchar(10),CreateDate,108)"
                            + " ,DanhBo=case when (select COUNT(ID) from DonTu_ChiTiet where MaDon=DonTu.MaDon)=1 then (select DanhBo from DonTu_ChiTiet where MaDon=DonTu.MaDon) else '' end"
                            + " ,HoTen=case when (select COUNT(ID) from DonTu_ChiTiet where MaDon=DonTu.MaDon)=1 then (select HoTen from DonTu_ChiTiet where MaDon=DonTu.MaDon) else '' end"
                            + " ,DiaChi=case when (select COUNT(ID) from DonTu_ChiTiet where MaDon=DonTu.MaDon)=1 then (select DiaChi from DonTu_ChiTiet where MaDon=DonTu.MaDon) else N'Số: ' + SoCongVan + N' gồm ' + CAST(TongDB as varchar(3)) + N' địa chỉ' end"
                            + " ,NoiDungPKHB=Name_NhomDon_PKH"
                            + " ,NoiDungPKH=case when VanDeKhac not like '' then case when Name_NhomDon_PKH not like '' then Name_NhomDon_PKH+'; '+VanDeKhac else VanDeKhac end else Name_NhomDon_PKH end"
                            + " ,NoiDungPTV=case when VanDeKhac not like '' then case when Name_NhomDon not like '' then Name_NhomDon+'; '+VanDeKhac else VanDeKhac end else Name_NhomDon end"
                            + " ,CreateBy=(select HoTen from Users where MaU=DonTu.CreateBy),TinhTrang"
                            + " from DonTu where CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm") + "' and CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm") + "'";

                string sqlDonTuChiTiet = "select dtct.STT,dtct.MaDon,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtct.TinhTrang"
                    + " from DonTu dt,DonTu_ChiTiet dtct where (select COUNT(ID) from DonTu_ChiTiet where MaDon=dt.MaDon)>1"
                    + " and dt.MaDon=dtct.MaDon and dt.CreateDate>='" + FromCreateDate.ToString("yyyyMMdd HH:mm") + "' and dt.CreateDate<='" + ToCreateDate.ToString("yyyyMMdd HH:mm") + "'";

                switch (Loai)
                {
                    case "Quầy":
                        sqlDonTu += " and VanPhong=0";
                        sqlDonTuChiTiet += " and dt.VanPhong=0";
                        break;
                    case "Văn Phòng":
                        sqlDonTu += " and VanPhong=1";
                        sqlDonTuChiTiet += " and dt.VanPhong=1";
                        break;
                    default:
                        break;
                }

                DataTable dtDonTu = new DataTable();
                dtDonTu = ExecuteQuery_DataTable(sqlDonTu);
                dtDonTu.TableName = "DonTu";
                dtDonTu.DefaultView.Sort = "MaDon ASC";
                ds.Tables.Add(dtDonTu.DefaultView.ToTable());

                DataTable dtDonTuChiTiet = new DataTable();
                dtDonTuChiTiet = ExecuteQuery_DataTable(sqlDonTuChiTiet);
                dtDonTuChiTiet.TableName = "DonTuChiTiet";
                ds.Tables.Add(dtDonTuChiTiet);

                if (dtDonTu.Rows.Count > 0 && dtDonTuChiTiet.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Đơn", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DonTuChiTiet"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getDS_GridControl(string Loai, DateTime FromCreateDate, DateTime ToCreateDate, int MaPhong)
        {
            List<LinQ.DonTu> lst = new List<LinQ.DonTu>();
            switch (Loai)
            {
                case "Quầy":
                    lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.MaPhong == MaPhong && item.VanPhong == false).OrderBy(item => item.MaDon).ToList();
                    break;
                case "Văn Phòng":
                    lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.MaPhong == MaPhong && item.VanPhong == true).OrderBy(item => item.MaDon).ToList();
                    break;
                default:
                    lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.MaPhong == MaPhong).OrderBy(item => item.MaDon).ToList();
                    break;
            }
            return EntityToDataset(lst);
        }

        public DataSet getDS_GridControl_Quan(string Loai, DateTime FromCreateDate, DateTime ToCreateDate, int Quan)
        {
            List<LinQ.DonTu> lst = new List<LinQ.DonTu>();
            switch (Loai)
            {
                case "Quầy":
                    lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.VanPhong == false && item.DonTu_ChiTiets.Any(itemA => Convert.ToInt32(itemA.Quan) == Quan) == true).OrderBy(item => item.MaDon).ToList();
                    break;
                case "Văn Phòng":
                    lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.VanPhong == true && item.DonTu_ChiTiets.Any(itemA => Convert.ToInt32(itemA.Quan) == Quan) == true).OrderBy(item => item.MaDon).ToList();
                    break;
                default:
                    lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.DonTu_ChiTiets.Any(itemA => Convert.ToInt32(itemA.Quan) == Quan) == true).OrderBy(item => item.MaDon).ToList();
                    break;
            }
            return EntityToDataset(lst);
        }

        public DataSet getDS_GridControl_QuanPhuong(string Loai, DateTime FromCreateDate, DateTime ToCreateDate, int Quan, int Phuong)
        {
            List<LinQ.DonTu> lst = new List<LinQ.DonTu>();
            switch (Loai)
            {
                case "Quầy":
                    lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.VanPhong == false && item.DonTu_ChiTiets.Any(itemA => Convert.ToInt32(itemA.Quan) == Quan && Convert.ToInt32(itemA.Phuong) == Phuong) == true).OrderBy(item => item.MaDon).ToList();
                    break;
                case "Văn Phòng":
                    lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.VanPhong == true && item.DonTu_ChiTiets.Any(itemA => Convert.ToInt32(itemA.Quan) == Quan && Convert.ToInt32(itemA.Phuong) == Phuong) == true).OrderBy(item => item.MaDon).ToList();
                    break;
                default:
                    lst = db.DonTus.Where(item => item.CreateDate.Value >= FromCreateDate && item.CreateDate.Value <= ToCreateDate && item.DonTu_ChiTiets.Any(itemA => Convert.ToInt32(itemA.Quan) == Quan && Convert.ToInt32(itemA.Phuong) == Phuong) == true).OrderBy(item => item.MaDon).ToList();
                    break;
            }
            return EntityToDataset(lst);
        }

        public DataSet EntityToDataset(List<LinQ.DonTu> lst)
        {
            DataTable dtDonTu = new DataTable();
            dtDonTu.Columns.Add("MaDon", typeof(string));
            dtDonTu.Columns.Add("SoCongVan", typeof(string));
            dtDonTu.Columns.Add("CreateDate", typeof(string));
            dtDonTu.Columns.Add("DanhBo", typeof(string));
            dtDonTu.Columns.Add("HoTen", typeof(string));
            dtDonTu.Columns.Add("DiaChi", typeof(string));
            dtDonTu.Columns.Add("NoiDungPKH", typeof(string));
            dtDonTu.Columns.Add("NoiDungPTV", typeof(string));
            dtDonTu.Columns.Add("CreateBy", typeof(string));
            dtDonTu.Columns.Add("TinhTrang", typeof(string));
            dtDonTu.TableName = "DonTu";

            DataTable dtDonTuChiTiet = new DataTable();
            dtDonTuChiTiet.Columns.Add("STT", typeof(string));
            dtDonTuChiTiet.Columns.Add("MaDon", typeof(string));
            dtDonTuChiTiet.Columns.Add("DanhBo", typeof(string));
            dtDonTuChiTiet.Columns.Add("HoTen", typeof(string));
            dtDonTuChiTiet.Columns.Add("DiaChi", typeof(string));
            dtDonTuChiTiet.Columns.Add("TinhTrang", typeof(string));
            dtDonTuChiTiet.TableName = "DonTuChiTiet";

            foreach (LinQ.DonTu item in lst)
            {
                if (dtDonTu.Select("MaDon = '" + item.MaDon + "'").Count() <= 0)
                {
                    DataRow dr = dtDonTu.NewRow();
                    dr["MaDon"] = item.MaDon;
                    dr["SoCongVan"] = item.SoCongVan;
                    dr["CreateDate"] = item.CreateDate.Value.ToString("dd/MM/yyyy HH:mm");
                    if (item.DonTu_ChiTiets.Count == 1)
                    {
                        dr["DanhBo"] = item.DonTu_ChiTiets.SingleOrDefault().DanhBo;
                        dr["HoTen"] = item.DonTu_ChiTiets.SingleOrDefault().HoTen;
                        dr["DiaChi"] = item.DonTu_ChiTiets.SingleOrDefault().DiaChi;
                        //dr["TinhTrang"] = item.DonTu_ChiTiets.SingleOrDefault().TinhTrang;
                    }
                    else
                    {
                        dr["DanhBo"] = "";
                        dr["HoTen"] = "";
                        dr["DiaChi"] = "Số: " + item.SoCongVan + " gồm " + item.TongDB.ToString() + " địa chỉ";
                        foreach (DonTu_ChiTiet itemCT in item.DonTu_ChiTiets)
                        {
                            DataRow drCT = dtDonTuChiTiet.NewRow();
                            drCT["STT"] = itemCT.STT;
                            drCT["MaDon"] = itemCT.MaDon;
                            drCT["DanhBo"] = itemCT.DanhBo;
                            drCT["HoTen"] = itemCT.HoTen;
                            drCT["DiaChi"] = itemCT.DiaChi;
                            drCT["TinhTrang"] = itemCT.TinhTrang;
                            dtDonTuChiTiet.Rows.Add(drCT);
                        }
                        //if (item.DonTu_ChiTiets.Count == int.Parse(dtDonTuChiTiet.Compute("count(DanhBo)", "MaDon=" + item.MaDon + " and TinhTrang like '%Hoàn Thành%'").ToString()))
                        //    dr["TinhTrang"] = "Hoàn Thành";
                        //else
                        //    dr["TinhTrang"] = "Tồn";
                    }
                    dr["TinhTrang"] = item.TinhTrang;
                    dr["NoiDungPKH"] = item.Name_NhomDon_PKH;
                    if (item.VanDeKhac != "")
                        if (item.Name_NhomDon != "")
                            dr["NoiDungPTV"] = item.Name_NhomDon + "; " + item.VanDeKhac;
                        else
                            dr["NoiDungPTV"] = item.VanDeKhac;
                    else
                        dr["NoiDungPTV"] = item.Name_NhomDon;
                    dr["CreateBy"] = db.Users.SingleOrDefault(itemR => itemR.MaU == item.CreateBy).HoTen;

                    dtDonTu.Rows.Add(dr);
                }
            }

            //dtDon.DefaultView.Sort = "CreateDate ASC";
            //ds.Tables.Add(dtDon.DefaultView.ToTable());

            DataSet ds = new DataSet();
            ds.Tables.Add(dtDonTu);
            ds.Tables.Add(dtDonTuChiTiet);
            ds.Relations.Add("Chi Tiết Đơn", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DonTuChiTiet"].Columns["MaDon"]);
            return ds;
        }

        // chi tiết

        public bool Them_ChiTiet(DonTu_ChiTiet en)
        {
            try
            {
                if (db.DonTu_ChiTiets.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.DonTu_ChiTiets.Max(item => item.ID) + 1;
                en.STT = db.DonTu_ChiTiets.Where(item => item.MaDon == en.MaDon).Max(item => item.STT) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.DonTu_ChiTiets.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_ChiTiet(DonTu_ChiTiet en)
        {
            try
            {
                db.DonTu_ChiTiets.DeleteOnSubmit(en);
                db.SubmitChanges();
                if (db.DonTu_ChiTiets.Count(o => o.MaDon == en.MaDon) > 1)
                {
                    int STT = 1;
                    foreach (DonTu_ChiTiet item in db.DonTu_ChiTiets.Where(o => o.MaDon == en.MaDon).ToList())
                    {
                        item.STT = STT++;
                        item.ModifyBy = CTaiKhoan.MaUser;
                        item.ModifyDate = DateTime.Now;
                        db.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public int getMaxID_ChiTiet()
        {
            if (db.DonTu_ChiTiets.Count() == 0)
                return 0;
            else
                return db.DonTu_ChiTiets.Max(item => item.ID);
        }

        public bool checkExist_ChiTiet(int MaDon, int STT)
        {
            return db.DonTu_ChiTiets.Any(item => item.MaDon == MaDon && item.STT == STT);
        }

        public bool checkExist_ChiTiet(string DanhBo, string HoTen, string DiaChi, DateTime CreateDate)
        {
            return db.DonTu_ChiTiets.Any(item => item.DanhBo == DanhBo && item.HoTen == HoTen && item.DiaChi == DiaChi && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public bool checkExist_ChuyenDeDinhMuc_ChuaKTXM(string DanhBo, out string TinhTrang)
        {
            if (db.DonTu_ChiTiets.Any(item => item.DanhBo == DanhBo && item.DonTu.ID_NhomDon.Contains("22") == true && db.KTXM_ChiTiets.Any(itemA => itemA.KTXM.MaDonMoi == item.MaDon && itemA.STT == item.STT) == false))
            {
                DonTu_ChiTiet en = db.DonTu_ChiTiets.FirstOrDefault(item => item.DanhBo == DanhBo && item.DonTu.ID_NhomDon.Contains("22") == true && db.KTXM_ChiTiets.Any(itemA => itemA.KTXM.MaDonMoi == item.MaDon && itemA.STT == item.STT) == false);
                TinhTrang = "có Chuyên Đề (" + en.MaDon.Value.ToString() + ")";
                return true;
            }
            else
            {
                TinhTrang = "";
                return false;
            }
        }

        public bool checkExist_TonCu(string DanhBo, int MaDon, int STT)
        {
            if (DanhBo != "")
                if (db.DonTu_ChiTiets.Count(item => item.DanhBo == DanhBo && item.TinhTrang.Contains("Tồn")) >= 2)
                    return true;
                else
                    if (db.KTXM_ChiTiets.Any(item => item.DanhBo == DanhBo && db.DonTu_ChiTiets.Any(itemA => itemA.MaDon == MaDon && itemA.STT == STT && itemA.TinhTrang.Contains("Tồn")) == true) == true
                        && db.DonTu_ChiTiets.Any(item => item.DanhBo == DanhBo && item.TinhTrang.Contains("Tồn") && item.MaDon != MaDon && item.STT != STT) == true)
                        return true;
                    else
                        return false;
            else
                return false;
        }

        public bool checkExists_14ngay(string DanhBo)
        {
            return db.DonTu_ChiTiets.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date >= DateTime.Now.Date.AddDays(-14));
        }

        public DonTu_ChiTiet get_ChiTiet(int ID)
        {
            return db.DonTu_ChiTiets.SingleOrDefault(item => item.ID == ID);
        }

        public DonTu_ChiTiet get_ChiTiet(int MaDon, int STT)
        {
            return db.DonTu_ChiTiets.SingleOrDefault(item => item.MaDon == MaDon && item.STT == STT);
        }

        public DonTu_ChiTiet get_ChiTiet(int MaDon, string DanhBo)
        {
            return db.DonTu_ChiTiets.SingleOrDefault(item => item.MaDon == MaDon && item.DanhBo == DanhBo);
        }

        public DataTable getDS_ChiTiet_ByDanhBo(string DanhBo)
        {
            var query = from item in db.DonTu_ChiTiets
                        where item.DanhBo == DanhBo
                        orderby item.CreateDate descending
                        select new
                        {
                            item.MaDon,
                            item.DonTu.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.DonTu.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.DonTu.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.DonTu.DonTu_ChiTiets.SingleOrDefault().DiaChi : "",
                            NoiDung = item.DonTu.Name_NhomDon,
                            CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                            item.TinhTrang,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_ByDanhBo(string DanhBo, int MaPhong)
        {
            var query = from item in db.DonTu_ChiTiets
                        where item.DanhBo == DanhBo && item.DonTu.MaPhong == MaPhong
                        select new
                        {
                            item.MaDon,
                            item.DonTu.SoCongVan,
                            item.CreateDate,
                            DanhBo = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.DonTu.DonTu_ChiTiets.SingleOrDefault().DanhBo : "",
                            HoTen = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.DonTu.DonTu_ChiTiets.SingleOrDefault().HoTen : "",
                            DiaChi = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.DonTu.DonTu_ChiTiets.SingleOrDefault().DiaChi : "",
                            NoiDung = item.DonTu.Name_NhomDon,
                            CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataSet getDS_ChiTiet_ByDanhBo_GridControl(string DanhBo)
        {
            List<LinQ.DonTu> lst = db.DonTus.Where(item => item.DonTu_ChiTiets.Any(itemA => itemA.DanhBo == DanhBo) == true).ToList();
            return EntityToDataset(lst);
        }

        public DataSet getDS_ChiTiet_ByDanhBo_GridControl(string DanhBo, int MaPhong)
        {
            List<LinQ.DonTu> lst = db.DonTus.Where(item => item.DonTu_ChiTiets.Any(itemA => itemA.DanhBo == DanhBo) == true && item.MaPhong == MaPhong).ToList();
            return EntityToDataset(lst);
        }

        public DataTable getDS_ThongKeNhomDon(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select dt.MaDon,dt.TongDB,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,"
                        + " NhomDon=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " MaDonChiTiet=case when dt.TongDB=0 then CONVERT(varchar(8),dtct.MaDon)"
                        + " when dt.TongDB=1 then CONVERT(varchar(8),dtct.MaDon)"
                        + " when dt.TongDB>=2 then CONVERT(varchar(8),dtct.MaDon)+'.'+CONVERT(varchar(3),dtct.STT) end,"
                        + " DaKTXM=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtct.MaDon and dtls.STT=dtct.STT and ID_NoiNhan=6) then 'true'"
                        + " else case when exists(select ktxm.MaKTXM from KTXM ktxm, KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT) then 'true'"
                        + " else case when exists(select bc.MaBC from BamChi bc, BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT) then 'true' else 'false' end end end"
                        + " from DonTu dt,DonTu_ChiTiet dtct where CAST(dt.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(dt.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and dt.MaDon=dtct.MaDon"
                        + " order by dtct.MaDon,dtct.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ThongKeNhomDon_DCMS_TroNgayThayDHN(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select dt.MaDon,dt.TongDB,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,"
                        + " NhomDon=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " MaDonChiTiet=case when dt.TongDB=0 then CONVERT(varchar(8),dtct.MaDon)"
                        + " when dt.TongDB=1 then CONVERT(varchar(8),dtct.MaDon)"
                        + " when dt.TongDB>=2 then CONVERT(varchar(8),dtct.MaDon)+'.'+CONVERT(varchar(3),dtct.STT) end,"
                        + " DaKTXM=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtct.MaDon and dtls.STT=dtct.STT and ID_NoiNhan=6) then 'true'"
                        + " else case when exists(select ktxm.MaKTXM from KTXM ktxm, KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT) then 'true'"
                        + " else case when exists(select bc.MaBC from BamChi bc, BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT) then 'true' else 'false' end end end"
                        + " from DonTu dt,DonTu_ChiTiet dtct where CAST(dt.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(dt.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and dt.MaDon=dtct.MaDon"
                        + " and (dt.Name_NhomDon like N'%đứt chì mặt số%'"
                        + " or dt.Name_NhomDon like N'%trở ngại thay ĐHN%')"
                        + " order by dtct.MaDon,dtct.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ThongKeNhomDon(string KyHieuTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            if (KyHieuTo == "")
            {
                string sql = ";WITH dtls_temp AS"
                            + " ("
                            + " SELECT dtls.*,ROW_NUMBER() OVER (PARTITION BY dtls.MaDon,dtls.STT ORDER BY dtls.NgayChuyen asc,dtls.ID asc) AS rn"
                            + " FROM DonTu_ChiTiet dtct, DonTu_LichSu dtls"
                            + " where cast(dtct.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(dtct.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and dtct.MaDon=dtls.MaDon and dtct.STT=dtls.STT"
                            + " )"
                            + " select dt.MaDon,dt.TongDB,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,"
                            + " NhomDon=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                            + " MaDonChiTiet=case when dt.TongDB=0 then CONVERT(varchar(8),dtct.MaDon)"
                            + "            when dt.TongDB=1 then CONVERT(varchar(8),dtct.MaDon)"
                            + "            when dt.TongDB>=2 then CONVERT(varchar(8),dtct.MaDon)+'.'+CONVERT(varchar(3),dtct.STT) end,"
                            + " ChuyenToGD=case when exists(select ID from dtls_temp where rn=1 and dtls_temp.MaDon=dtct.MaDon and dtls_temp.STT=dtct.STT and ID_NoiNhan=1) then 'true' else 'false' end,"
                            + " ChuyenToTB=case when exists(select ID from dtls_temp where rn=1 and dtls_temp.MaDon=dtct.MaDon and dtls_temp.STT=dtct.STT and ID_NoiNhan=2) then 'true' else 'false' end,"
                            + " ChuyenToTP=case when exists(select ID from dtls_temp where rn=1 and dtls_temp.MaDon=dtct.MaDon and dtls_temp.STT=dtct.STT and ID_NoiNhan=3) then 'true' else 'false' end,"
                            + " ChuyenToBC=case when exists(select ID from dtls_temp where rn=1 and dtls_temp.MaDon=dtct.MaDon and dtls_temp.STT=dtct.STT and ID_NoiNhan=4) then 'true' else 'false' end,"
                            + " ChuyenKhac=case when exists(select ID from dtls_temp where rn=1 and dtls_temp.MaDon=dtct.MaDon and dtls_temp.STT=dtct.STT and ID_NoiNhan!=1 and ID_NoiNhan!=2 and ID_NoiNhan!=3 and ID_NoiNhan!=4) then 'true' else 'false' end"
                            + " from DonTu dt,DonTu_ChiTiet dtct where CAST(dt.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(dt.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and dt.MaDon=dtct.MaDon"
                            + " order by dtct.MaDon,dtct.STT asc";
                return ExecuteQuery_DataTable(sql);
            }
            else
            {
                string sql = ";WITH dtls_temp AS"
                            + " ("
                            + " SELECT dtls.*,ROW_NUMBER() OVER (PARTITION BY dtls.MaDon,dtls.STT ORDER BY dtls.NgayChuyen asc,dtls.ID asc) AS rn"
                            + " FROM DonTu_ChiTiet dtct, DonTu_LichSu dtls"
                            + " where cast(dtct.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and cast(dtct.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and dtct.MaDon=dtls.MaDon and dtct.STT=dtls.STT"
                            + " )"
                            + " select dt.MaDon,dt.TongDB,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,"
                            + " NhomDon=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                            + " MaDonChiTiet=case when dt.TongDB=0 then CONVERT(varchar(8),dtls_temp.MaDon)"
                            + " 		   when dt.TongDB=1 then CONVERT(varchar(8),dtls_temp.MaDon)"
                            + " 		   when dt.TongDB>=2 then CONVERT(varchar(8),dtls_temp.MaDon)+'.'+CONVERT(varchar(3),dtls_temp.STT) end,"
                            + " ChuyenTrucTiep=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtls_temp.MaDon and dtls.STT=dtls_temp.STT and ID_NoiNhan=6) then 'false' else 'true' end,"
                            + " ChuyenKTXM=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtls_temp.MaDon and dtls.STT=dtls_temp.STT and ID_NoiNhan=5) then 'true' else 'false' end,";
                switch (KyHieuTo)
                {
                    case "ToGD":
                    case "ToTB":
                    case "ToTP":
                        sql += " DaKTXM=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtls_temp.MaDon and dtls.STT=dtls_temp.STT and ID_NoiNhan=5) then"
                            + " case when exists(select ktxm.MaKTXM from KTXM ktxm, KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtls_temp.MaDon and ktxmct.STT=dtls_temp.STT) then 'true' else 'false' end else 'false' end";
                        break;
                    case "ToBC":
                        sql += " DaKTXM=case when exists(select ID from DonTu_LichSu dtls where dtls.MaDon=dtls_temp.MaDon and dtls.STT=dtls_temp.STT and ID_NoiNhan=5) then"
                            + " case when exists(select bc.MaBC from BamChi bc, BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtls_temp.MaDon and bcct.STT=dtls_temp.STT) then 'true'"
                            + " else case when exists(select ktxm.MaKTXM from KTXM ktxm, KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtls_temp.MaDon and ktxmct.STT=dtls_temp.STT) then 'true' else 'false' end end else 'false' end";
                        break;
                }
                sql += " from DonTu dt,DonTu_ChiTiet dtct,dtls_temp where dtls_temp.rn=1 and dt.MaDon=dtct.MaDon and dtct.MaDon=dtls_temp.MaDon and dtct.STT=dtls_temp.STT";
                switch (KyHieuTo)
                {
                    case "ToGD":
                        sql += " and ID_NoiNhan=1";
                        break;
                    case "ToTB":
                        sql += " and ID_NoiNhan=2";
                        break;
                    case "ToTP":
                        sql += " and ID_NoiNhan=3";
                        break;
                    case "ToBC":
                        sql += " and ID_NoiNhan=4";
                        break;
                }
                sql += " order by dtct.MaDon,dtct.STT asc";
                return ExecuteQuery_DataTable(sql);
            }
        }

        public DataTable getDS_ThongKeDonTu_Ton(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select dtct.MaDon,TinhTrang,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,"
                         + " MaDonChiTiet=case when (select COUNT(*) from DonTu_ChiTiet where MaDon=dtct.MaDon)=0 then CONVERT(varchar(8),dtct.MaDon)"
                         + " when (select COUNT(*) from DonTu_ChiTiet where MaDon=dtct.MaDon)=1 then CONVERT(varchar(8),dtct.MaDon)"
                         + " when (select COUNT(*) from DonTu_ChiTiet where MaDon=dtct.MaDon)>=2 then CONVERT(varchar(8),dtct.MaDon)+'.'+CONVERT(varchar(3),dtct.STT) end"
                         + " from DonTu_ChiTiet dtct where CAST(dtct.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(dtct.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'"
                         + " and dtct.TinhTrang like N'Tồn%'"
                         + " order by dtct.MaDon,dtct.STT asc";
            return ExecuteQuery_DataTable(sql);
        }

        // lịch sử chuyển đơn

        public bool Them_LichSu(DonTu_LichSu entity)
        {
            try
            {
                if (db.DonTu_LichSus.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = db.DonTu_LichSus.Max(item => item.ID) + 1;
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.DonTu_LichSus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Them_LichSu(DateTime NgayChuyen, string NoiChuyen, string NoiDung, int IDCT, int MaDon, int STT)
        {
            try
            {
                DonTu_LichSu entity = new DonTu_LichSu();
                entity.NgayChuyen = NgayChuyen;
                switch (NoiChuyen)
                {
                    case "KTXM":
                        entity.ID_NoiChuyen = 5;
                        entity.NoiChuyen = "Kiểm Tra";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "KTXM_ChiTiet";
                        entity.IDCT = IDCT;
                        //entity.NgayChuyen = db.KTXM_ChiTiets.SingleOrDefault(item => item.MaCTKTXM == IDCT).NgayKTXM;
                        break;
                    case "BamChi":
                        entity.ID_NoiChuyen = 5;
                        entity.NoiChuyen = "Kiểm Tra";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "BamChi_ChiTiet";
                        entity.IDCT = IDCT;
                        //entity.NgayChuyen = db.BamChi_ChiTiets.SingleOrDefault(item => item.MaCTBC == IDCT).NgayBC;
                        break;
                    case "DCBD":
                        entity.ID_NoiChuyen = 6;
                        entity.NoiChuyen = "Điều Chỉnh";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "DCBD_ChiTietBienDong";
                        entity.IDCT = IDCT;
                        break;
                    case "DCHD":
                        entity.ID_NoiChuyen = 6;
                        entity.NoiChuyen = "Điều Chỉnh";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "DCBD_ChiTietHoaDon";
                        entity.IDCT = IDCT;
                        break;
                    case "CTDB":
                        entity.ID_NoiChuyen = 37;
                        entity.NoiChuyen = "TB Đóng Nước";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "CHDB_ChiTietCatTam";
                        entity.IDCT = IDCT;
                        break;
                    case "CHDB":
                        entity.ID_NoiChuyen = 7;
                        entity.NoiChuyen = "Cắt Hủy";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "CHDB_ChiTietCatHuy";
                        entity.IDCT = IDCT;
                        break;
                    case "PhieuCHDB":
                        entity.ID_NoiChuyen = 7;
                        entity.NoiChuyen = "Cắt Hủy";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "CHDB_Phieu";
                        entity.IDCT = IDCT;
                        break;
                    case "TruyThu":
                        entity.ID_NoiChuyen = 8;
                        entity.NoiChuyen = "Truy Thu";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "TruyThuTienNuoc_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    case "TruyThuThuMoi":
                        entity.ID_NoiChuyen = 8;
                        entity.NoiChuyen = "Truy Thu";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "TruyThuTienNuoc_ThuMoi";
                        entity.IDCT = IDCT;
                        break;
                    case "GianLan":
                        entity.ID_NoiChuyen = 8;
                        entity.NoiChuyen = "Truy Thu";
                        entity.NoiDung = "Đã Lập Gian Lận, " + NoiDung;
                        entity.TableName = "GianLan_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    case "TTTL":
                        entity.ID_NoiChuyen = 9;
                        entity.NoiChuyen = "Thư Trả Lời";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "TTTL_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    case "ThuMoi":
                        entity.ID_NoiChuyen = 10;
                        entity.NoiChuyen = "Thư Mời";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "ThuMoi_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    case "ToTrinh":
                        entity.ID_NoiChuyen = 11;
                        entity.NoiChuyen = "Tờ Trình";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "ToTrinh_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    case "VanBan":
                        entity.ID_NoiChuyen = 38;
                        entity.NoiChuyen = "Văn Bản";
                        entity.NoiDung = NoiDung;
                        entity.TableName = "VanBan_ChiTiet";
                        entity.IDCT = IDCT;
                        break;
                    default:
                        break;
                }

                entity.MaDon = MaDon;
                entity.STT = STT;
                if (db.DonTu_LichSus.Count() == 0)
                    entity.ID = 1;
                else
                    entity.ID = db.DonTu_LichSus.Max(item => item.ID) + 1;
                entity.CreateBy = CTaiKhoan.MaUser;
                entity.CreateDate = DateTime.Now;
                db.DonTu_LichSus.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_LichSu(DonTu_LichSu entity, bool refresh)
        {
            try
            {
                db.DonTu_LichSus.DeleteOnSubmit(entity);
                if (refresh == true)
                    db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_LichSu(DonTu_LichSu entity, int CreateBy)
        {
            try
            {
                if (entity.CreateBy != CreateBy)
                    return false;
                db.DonTu_LichSus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_LichSu(string TableName, int IDCT, int MaDon, int STT)
        {
            try
            {
                DonTu_LichSu en = db.DonTu_LichSus.SingleOrDefault(item => item.TableName == TableName && item.IDCT == IDCT && item.MaDon == MaDon && item.STT == STT);
                if (en != null)
                {
                    db.DonTu_LichSus.DeleteOnSubmit(en);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_LichSu(string TableName, int IDCT)
        {
            try
            {
                DonTu_LichSu en = db.DonTu_LichSus.SingleOrDefault(item => item.TableName == TableName && item.IDCT == IDCT);
                if (en != null)
                {
                    db.DonTu_LichSus.DeleteOnSubmit(en);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_LichSus(string TableName, int IDCT)
        {
            try
            {
                List<DonTu_LichSu> lsten = db.DonTu_LichSus.Where(item => item.TableName == TableName && item.IDCT == IDCT).ToList();
                if (lsten != null && lsten.Count > 0)
                {
                    db.DonTu_LichSus.DeleteAllOnSubmit(lsten);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public string getTinhTrangDon(int MaDon, int STT)
        {
            //7 - cắt hủy
            //8 - truy thu
            List<DonTu_LichSu> lst = db.DonTu_LichSus.Where(item => item.MaDon == MaDon && item.STT == STT).OrderBy(item => item.NgayChuyen).ThenBy(item => item.ID).ToList();
            string flag = "Tồn";
            for (int i = 0; i < lst.Count - 1; i++)
            {
                if (lst[i].ID_NoiNhan != null && db.NoiChuyens.SingleOrDefault(item => item.ID == lst[i].ID_NoiNhan).KiemTra == true)
                {
                    flag = "Tồn";
                    for (int j = i + 1; j < lst.Count; j++)
                    {
                        if (lst[j].ID_NoiChuyen == 7 && lst[j].ID_NoiChuyen == lst[i].ID_NoiNhan && lst[j].TableName != null)
                        {
                            string result = ExecuteQuery_ReturnOneValue("select dbo.fnCheckTinhTrangCatHuy_Ton('" + lst[j].TableName + "'," + lst[j].IDCT + ")").ToString();
                            if (result == "")
                                flag = "Hoàn Thành";
                            else
                                flag = "Hoàn Thành (KH)";
                        }
                        else
                            if (lst[j].ID_NoiChuyen == 8 && lst[j].ID_NoiChuyen == lst[i].ID_NoiNhan && lst[j].TableName != null)
                            {
                                string result = ExecuteQuery_ReturnOneValue("select dbo.fnCheckTinhTrangTruyThu_Ton_IDCT(" + lst[j].IDCT + ")").ToString();
                                if (result == "")
                                    flag = "Hoàn Thành";
                                else
                                    flag = "Hoàn Thành (KH)";
                            }
                            else
                                if (lst[j].ID_NoiChuyen == lst[i].ID_NoiNhan && lst[j].TableName != null)
                                {
                                    flag = "Hoàn Thành";
                                }
                    }
                }
            }

            return flag;
        }

        public void runUpdateTinhTrang(int MaDon, int STT)
        {
            ExecuteNonQuery("exec spUpdateTinhTrang " + MaDon + "," + STT);
        }

        public DonTu_LichSu get_LichSu(int ID)
        {
            return db.DonTu_LichSus.SingleOrDefault(item => item.ID == ID);
        }

        public DonTu_LichSu get_LichSu(string TableName, int IDCT, int CreateBy)
        {
            return db.DonTu_LichSus.SingleOrDefault(item => item.TableName == TableName && item.IDCT == IDCT && item.CreateBy == CreateBy);
        }

        public DataTable getDS_LichSu(int MaDon)
        {
            var query = from item in db.DonTu_LichSus
                        join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                        where item.MaDon == MaDon
                        orderby item.NgayChuyen descending, item.ID descending
                        select new
                        {
                            item.ID,
                            item.NgayChuyen,
                            item.NoiChuyen,
                            item.NoiNhan,
                            item.KTXM,
                            item.NoiDung,
                            CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                            itemDon.MaDon,
                            itemDon.DanhBo,
                            itemDon.DiaChi,
                            NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_LichSu(int MaDon, int? STT)
        {
            var query = from item in db.DonTu_LichSus
                        join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                        where item.MaDon == MaDon && item.STT == STT
                        orderby item.NgayChuyen descending, item.ID descending
                        select new
                        {
                            item.ID,
                            item.NgayChuyen,
                            item.NoiChuyen,
                            item.NoiNhan,
                            item.KTXM,
                            item.NoiDung,
                            CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                            itemDon.MaDon,
                            itemDon.DanhBo,
                            itemDon.DiaChi,
                            NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            item.Nhan,
                            item.NgayNhan,
                            item.Huy,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_LichSu(string KyHieuTo, string SoCongVan)
        {
            switch (KyHieuTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.DonTu.SoCongVan.Contains(SoCongVan)
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.MaDon,
                                    MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.DonTu.SoCongVan.Contains(SoCongVan)
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.DonTu.SoCongVan.Contains(SoCongVan)
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.DonTu.SoCongVan.Contains(SoCongVan)
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.DonTu.SoCongVan.Contains(SoCongVan)
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string KyHieuTo, int CreateBy, string SoCongVan)
        {
            switch (KyHieuTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.MaDon,
                                    MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.DonTu.SoCongVan.Contains(SoCongVan) && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string KyHieuTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            switch (KyHieuTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.MaDon,
                                    MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string KyHieuTo, int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            switch (KyHieuTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where (item.ID_NoiChuyen == 1 || item.CreateBy == CreateBy) && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.MaDon,
                                    MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where (item.ID_NoiChuyen == 2 || item.CreateBy == CreateBy) && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where (item.ID_NoiChuyen == 3 || item.CreateBy == CreateBy) && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where (item.ID_NoiChuyen == 4 || item.CreateBy == CreateBy) && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(DateTime FromCreateDate, DateTime ToCreateDate, string NoiChuyen, string NoiNhan)
        {
            var query = from item in db.DonTu_LichSus
                        join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                        where item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiChuyen == Convert.ToInt32(NoiChuyen) && item.ID_NoiNhan == Convert.ToInt32(NoiNhan)
                        orderby item.NgayChuyen descending, item.ID descending
                        select new
                        {
                            item.ID,
                            item.NgayChuyen,
                            item.NoiChuyen,
                            item.NoiNhan,
                            item.KTXM,
                            item.NoiDung,
                            CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                            MaDon = itemDon.MaDon,
                            MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                            itemDon.DanhBo,
                            itemDon.DiaChi,
                            NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_LichSu(int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate, string NoiChuyen, string NoiNhan)
        {
            var query = from item in db.DonTu_LichSus
                        join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                        where item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.CreateBy == CreateBy && item.ID_NoiChuyen == Convert.ToInt32(NoiChuyen) && item.ID_NoiNhan == Convert.ToInt32(NoiNhan)
                        orderby item.NgayChuyen descending, item.ID descending
                        select new
                        {
                            item.ID,
                            item.NgayChuyen,
                            item.NoiChuyen,
                            item.NoiNhan,
                            item.KTXM,
                            item.NoiDung,
                            CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                            MaDon = itemDon.MaDon,
                            MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                            itemDon.DanhBo,
                            itemDon.DiaChi,
                            NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_LichSu(string KyHieuTo, string SoCongVan, int ID_NoiNhan)
        {
            switch (KyHieuTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.MaDon,
                                    MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string KyHieuTo, int CreateBy, string SoCongVan, int ID_NoiNhan)
        {
            switch (KyHieuTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.MaDon,
                                    MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.DonTu.SoCongVan.Contains(SoCongVan) && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string KyHieuTo, DateTime FromCreateDate, DateTime ToCreateDate, int ID_NoiNhan)
        {
            switch (KyHieuTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.MaDon,
                                    MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(string KyHieuTo, int CreateBy, DateTime FromCreateDate, DateTime ToCreateDate, int ID_NoiNhan)
        {
            switch (KyHieuTo)
            {
                case "ToGD":
                    var query = from item in db.DonTu_LichSus
                                join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                                where item.ID_NoiChuyen == 1 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                                orderby item.NgayChuyen descending, item.ID descending
                                select new
                                {
                                    item.ID,
                                    item.NgayChuyen,
                                    item.NoiChuyen,
                                    item.NoiNhan,
                                    item.KTXM,
                                    item.NoiDung,
                                    CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                    MaDon = itemDon.MaDon,
                                    MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                    itemDon.DanhBo,
                                    itemDon.DiaChi,
                                    NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                                };
                    return LINQToDataTable(query);
                case "ToTB":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 2 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 3 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.ID_NoiChuyen == 4 && item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from item in db.DonTu_LichSus
                            join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                            where item.NgayChuyen.Value >= FromCreateDate && item.NgayChuyen.Value <= ToCreateDate && item.ID_NoiNhan == ID_NoiNhan && item.CreateBy == CreateBy
                            orderby item.NgayChuyen descending, item.ID descending
                            select new
                            {
                                item.ID,
                                item.NgayChuyen,
                                item.NoiChuyen,
                                item.NoiNhan,
                                item.KTXM,
                                item.NoiDung,
                                CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                                MaDon = itemDon.MaDon,
                                MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                                itemDon.DanhBo,
                                itemDon.DiaChi,
                                NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_LichSu(DateTime FromCreateDate, DateTime ToCreateDate, int ID_NoiNhan)
        {
            var query = from item in db.DonTu_LichSus
                        join itemDon in db.DonTu_ChiTiets on new { item.MaDon, item.STT } equals new { itemDon.MaDon, itemDon.STT }
                        where item.NgayChuyen.Value.Date >= FromCreateDate.Date && item.NgayChuyen.Value.Date <= ToCreateDate.Date && item.ID_NoiNhan == ID_NoiNhan
                        orderby item.NgayChuyen descending, item.ID descending
                        select new
                        {
                            item.ID,
                            item.NgayChuyen,
                            item.NoiChuyen,
                            item.NoiNhan,
                            item.KTXM,
                            item.NoiDung,
                            CreateBy = db.Users.SingleOrDefault(itemU => itemU.MaU == item.CreateBy).HoTen,
                            MaDon = itemDon.MaDon,
                            MaDonChiTiet = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.ToString() : itemDon.MaDon + "." + itemDon.STT,
                            itemDon.DanhBo,
                            itemDon.DiaChi,
                            NoiDungDon = itemDon.DonTu.Name_NhomDon != "" ? itemDon.DonTu.Name_NhomDon : itemDon.DonTu.VanDeKhac,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1";
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2";
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3";
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4";
                    break;
            }
            sql += " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, string NoiDungThuongVu, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1";
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2";
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3";
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4";
                    break;
            }
            sql += " and dt.Name_NhomDon like N'%" + NoiDungThuongVu + "%'";
            sql += " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, int MaNV_KTXM, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4 and ID_KTXM=" + MaNV_KTXM;
                    break;
            }
            sql += " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, int MaNV_KTXM, string NoiDungThuongVu, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4 and ID_KTXM=" + MaNV_KTXM;
                    break;
            }
            sql += " and dt.Name_NhomDon like N'%" + NoiDungThuongVu + "%'";
            sql += " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, string SoCongVan)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1";
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2";
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3";
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4";
                    break;
            }
            sql += " and dt.SoCongVan like N'%" + SoCongVan + "%'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, string NoiDungThuongVu, string SoCongVan)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1";
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2";
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3";
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4";
                    break;
            }
            sql += " and dt.Name_NhomDon like N'%" + NoiDungThuongVu + "%'";
            sql += " and dt.SoCongVan like N'%" + SoCongVan + "%'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, int MaNV_KTXM, string SoCongVan)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4 and ID_KTXM=" + MaNV_KTXM;
                    break;
            }
            sql += " and dt.SoCongVan like N'%" + SoCongVan + "%'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, int MaNV_KTXM, string NoiDungThuongVu, string SoCongVan)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4 and ID_KTXM=" + MaNV_KTXM;
                    break;
            }
            sql += " and dt.Name_NhomDon like N'%" + NoiDungThuongVu + "%'";
            sql += " and dt.SoCongVan like N'%" + SoCongVan + "%'";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, int MaDon)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1";
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2";
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3";
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4";
                    break;
            }
            sql += " and dt.MaDon=" + MaDon + "";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, string NoiDungThuongVu, int MaDon)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1";
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2";
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3";
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4";
                    break;
            }
            sql += " and dt.Name_NhomDon like N'%" + NoiDungThuongVu + "%'";
            sql += " and dt.MaDon=" + MaDon + "";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, int MaNV_KTXM, int MaDon)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4 and ID_KTXM=" + MaNV_KTXM;
                    break;
            }
            sql += " and dt.MaDon=" + MaDon + "";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM(string KyHieuTo, int MaNV_KTXM, string NoiDungThuongVu, int MaDon)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " GiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then 'true'"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then 'true' else 'false' end,"
                        + " NgayGiaiQuyet=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NgayKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.NgayBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NoiDungKTXM=case when exists(select ktxm.MaKTXM from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 ktxmct.NoiDungKiemTra from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM and ktxm.MaDonMoi=dtct.MaDon and ktxmct.STT=dtct.STT and ktxmct.CreateBy=dtls.ID_KTXM and (ktxmct.NgayKTXM_Truoc_NgayGiao=1 or cast(ktxmct.NgayKTXM as date)>=cast(dtls.NgayChuyen as date)))"
                        + " when exists(select bc.MaBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date)))then (select top 1 bcct.TrangThaiBC from BamChi bc,BamChi_ChiTiet bcct where bc.MaBC=bcct.MaBC and bc.MaDonMoi=dtct.MaDon and bcct.STT=dtct.STT and bcct.CreateBy=dtls.ID_KTXM and (bcct.NgayBC_Truoc_NgayGiao=1 or cast(bcct.NgayBC as date)>=cast(dtls.NgayChuyen as date))) else null end,"
                        + " NguoiDi=(select HoTen from Users where MaU=dtls.ID_KTXM)"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5 and dtls.Huy=0";
            switch (KyHieuTo)
            {
                case "ToGD":
                    sql += " and ID_NoiChuyen=1 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTB":
                    sql += " and ID_NoiChuyen=2 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToTP":
                    sql += " and ID_NoiChuyen=3 and ID_KTXM=" + MaNV_KTXM;
                    break;
                case "ToBC":
                    sql += " and ID_NoiChuyen=4 and ID_KTXM=" + MaNV_KTXM;
                    break;
            }
            sql += " and dt.Name_NhomDon like N'%" + NoiDungThuongVu + "%'";
            sql += " and dt.MaDon=" + MaDon + "";
            sql += " order by dtct.MaDon,dtct.STT";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM_KyNhan_Phong(DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " CreateBy=(select HoTen from Users where MaU=dtls.ID_KTXM),Nhan,NgayNhan,dtls.ID"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5"
                        + " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'"
                        + " order by dtct.MaDon,dtct.STT";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM_KyNhan_To(int MaTo, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " CreateBy=(select HoTen from Users where MaU=dtls.ID_KTXM),Nhan,NgayNhan,dtls.ID"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5"
                        + " and dtls.ID_KTXM in (select MaU from Users where MaTo=" + MaTo + ")"
                        + " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'"
                        + " order by dtct.MaDon,dtct.STT";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_ChuyenKTXM_KyNhan_NV(int MaNV, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "select MaDon=case when (select COUNT(MaDon) from DonTu_ChiTiet where MaDon=dt.MaDon)=1 then convert(char(8),dtct.MaDon) else convert(char(8),dtct.MaDon)+'.'+convert(varchar(3),dtct.STT) end,"
                        + " dt.SoCongVan,dtct.DanhBo,dtct.HoTen,dtct.DiaChi,dtls.NgayChuyen,dtls.NgayNhan,GhiChu=dtls.NoiDung,"
                        + " NoiDung=case when dt.Name_NhomDon != '' then dt.Name_NhomDon else dt.VanDeKhac end,"
                        + " CreateBy=(select HoTen from Users where MaU=dtls.ID_KTXM),Nhan,NgayNhan,dtls.ID"
                        + " from DonTu_LichSu dtls,DonTu_ChiTiet dtct,DonTu dt"
                        + " where dt.MaDon=dtct.MaDon and dtls.STT=dtct.STT and dtls.MaDon=dtct.MaDon and ID_NoiNhan=5"
                        + " and dtls.ID_KTXM=" + MaNV
                        + " and CAST(dtls.NgayChuyen as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and CAST(dtls.NgayChuyen as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'"
                        + " order by dtct.MaDon,dtct.STT";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDSDonChuyenDe(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select dtct.MaDon,dtct.STT,t1.CanKhachHangLienHe,t1.DinhMuc,t1.DinhMucMoi,t1.LapTruyThu from DonTu dt,DonTu_ChiTiet dtct"
                    + " left join (select MaDonMoi,STT,CanKhachHangLienHe,DinhMuc,DinhMucMoi,LapTruyThu from KTXM ktxm,KTXM_ChiTiet ktxmct where ktxm.MaKTXM=ktxmct.MaKTXM) t1 on t1.MaDonMoi=dtct.MaDon and t1.STT=dtct.STT"
                    + " where dt.MaDon=dtct.MaDon and CAST(dt.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(dt.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and Name_NhomDon like N'%chuyên đề%'";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KTXM_Ton(int MaNV_KTXM)
        {
            return ExecuteQuery_DataTable("select MaDonChiTiet=case when dt.TongDB=0 then CONVERT(varchar(8),dtct.MaDon)"
                                       + " when dt.TongDB=1 then CONVERT(varchar(8),dtct.MaDon)"
                                       + " when dt.TongDB>=2 then CONVERT(varchar(8),dtct.MaDon)+'.'+CONVERT(varchar(3),dtct.STT) end"
                                       + " ,dtct.DanhBo,dtct.HoTen,dtct.DiaChi"
                                       + " from DonTu dt,DonTu_ChiTiet dtct,DonTu_LichSu dtls where dtct.TinhTrang like N'Tồn (Kiểm Tra)' and ID_KTXM=" + MaNV_KTXM + " and dt.MaDon=dtct.MaDon and dtct.MaDon=dtls.MaDon and dtct.STT=dtls.STT");
        }

        public DataTable getDS_LichSu_CVD(string KyHieuTo, DateTime FromNgayChuyen, DateTime ToNgayChuyen, string ID_NoiChuyen, string ID_NoiNhan)
        {
            string sql = "select MaDon=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=DonTu_LichSu.MaDon)=1) then CONVERT(varchar(10),DonTu_LichSu.MaDon) else CONVERT(varchar(10),DonTu_LichSu.MaDon)+'.'+CONVERT(varchar(10),DonTu_LichSu.STT) end"
            + ",LoaiVanBan=NoiChuyen,Ma=case when ((select COUNT(*) from DonTu_ChiTiet where MaDon=DonTu_LichSu.MaDon)=1) then CONVERT(varchar(10),DonTu_LichSu.MaDon) else CONVERT(varchar(10),DonTu_LichSu.MaDon)+'.'+CONVERT(varchar(10),DonTu_LichSu.STT) end"
            + ",CreateDate=CONVERT(char(10),NgayChuyen,103)+' '+CONVERT(char(5),NgayChuyen,108),NoiChuyen=NoiNhan,ID,CVD_Ngay"
                + ",TableName,IDCT,NgayChuyen=CONVERT(char(10),NgayChuyen,103)+' '+CONVERT(char(5),NgayChuyen,108),NoiNhan from DonTu_LichSu where NgayChuyen >='" + FromNgayChuyen.ToString("yyyy-MM-dd HH:mm") + "' and NgayChuyen <='" + ToNgayChuyen.ToString("yyyy-MM-dd HH:mm") + "' and ID_NoiNhan is not null and ID_NoiChuyen=" + ID_NoiChuyen + " and ID_NoiNhan=" + ID_NoiNhan;
            sql += " and '" + KyHieuTo + "'=(select KyHieu from [To] where MaTo=(select MaTo from Users where MaU=DonTu_LichSu.CreateBy))";
            sql += " order by NgayChuyen asc,ID asc";
            return ExecuteQuery_DataTable(sql);
        }

    }
}
