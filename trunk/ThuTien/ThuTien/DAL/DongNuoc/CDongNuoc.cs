﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.DongNuoc
{
    class CDongNuoc : CDAL
    {
        public bool Them(TT_DongNuoc dongnuoc)
        {
            try
            {
                if (_db.TT_DongNuocs.Count() > 0)
                {
                    string ID = "MaDN";
                    string Table = "TT_DongNuoc";
                    decimal MaDN = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                    dongnuoc.MaDN = getMaxNextIDTable(MaDN);
                }
                else
                    dongnuoc.MaDN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                dongnuoc.CreateDate = DateTime.Now;
                dongnuoc.CreateBy = CNguoiDung.MaND;
                _db.TT_DongNuocs.InsertOnSubmit(dongnuoc);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(decimal MaDN)
        {
            try
            {
                string sql = "";
                sql = "delete TT_CTDongNuoc where MaDN=" + MaDN;
                sql += " delete TT_DongNuoc where MaDN=" + MaDN;
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public DataSet GetDSByDates(int MaNV,DateTime TuNgay, DateTime DenNgay)
        {
            DataSet ds = new DataSet();

            var queryDN = from itemDN in _db.TT_DongNuocs
                            where itemDN.CreateBy==MaNV && itemDN.CreateDate.Value.Date >= TuNgay.Date && itemDN.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                In=false,
                                itemDN.MaDN,
                                itemDN.DanhBo,
                                itemDN.HoTen,
                                itemDN.DiaChi,
                                itemDN.MLT,
                            };
            DataTable dtDongNuoc = new DataTable();
            dtDongNuoc = LINQToDataTable(queryDN);
            dtDongNuoc.TableName = "DongNuoc";
            ds.Tables.Add(dtDongNuoc);

            var queryCTDN = from itemCTDN in _db.TT_CTDongNuocs
                            join itemDN in _db.TT_DongNuocs on itemCTDN.MaDN equals itemDN.MaDN
                            where itemDN.CreateDate.Value.Date >= TuNgay.Date && itemDN.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                itemCTDN.MaDN,
                                itemCTDN.SoHoaDon,
                                itemCTDN.Ky,
                                itemCTDN.TieuThu,
                                itemCTDN.GiaBan,
                                itemCTDN.ThueGTGT,
                                itemCTDN.PhiBVMT,
                                itemCTDN.TongCong,
                            };
            DataTable dtCTDongNuoc = new DataTable();
            dtCTDongNuoc = LINQToDataTable(queryCTDN);
            dtCTDongNuoc.TableName = "CTDongNuoc";
            ds.Tables.Add(dtCTDongNuoc);

            if (dtDongNuoc.Rows.Count > 0 && dtCTDongNuoc.Rows.Count > 0)
                ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DongNuoc"].Columns["MaDN"], ds.Tables["CTDongNuoc"].Columns["MaDN"]);

            return ds;
        }

        public bool CheckKQDongNuocByMaDN(decimal MaDN)
        {
            return _db.TT_KQDongNuocs.Any(item => item.MaDN == MaDN);
        }
    }
}
