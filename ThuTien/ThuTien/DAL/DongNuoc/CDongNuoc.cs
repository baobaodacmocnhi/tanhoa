using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;
using System.Globalization;

namespace ThuTien.DAL.DongNuoc
{
    class CDongNuoc : CDAL
    {
        public bool ThemDN(TT_DongNuoc dongnuoc)
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

        public bool SuaDN(TT_DongNuoc dongnuoc)
        {
            try
            {
                dongnuoc.ModifyDate = DateTime.Now;
                dongnuoc.ModifyBy = CNguoiDung.MaND;
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

        public bool ThemKQ(TT_KQDongNuoc kqdongnuoc)
        {
            try
            {
                if (_db.TT_KQDongNuocs.Count() > 0)
                    kqdongnuoc.MaCTDN = _db.TT_KQDongNuocs.Max(item => item.MaCTDN) + 1;
                else
                    kqdongnuoc.MaCTDN = 1;
                kqdongnuoc.CreateDate = DateTime.Now;
                kqdongnuoc.CreateBy = CNguoiDung.MaND;
                _db.TT_KQDongNuocs.InsertOnSubmit(kqdongnuoc);
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

        public bool SuaKQ(TT_KQDongNuoc kqdongnuoc)
        {
            try
            {
                kqdongnuoc.ModifyDate = DateTime.Now;
                kqdongnuoc.ModifyBy = CNguoiDung.MaND;
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

        public bool GiaoDongNuoc(decimal MaDN,int MaNV_DongNuoc)
        {
            try
            {
                string sql = "update TT_DongNuoc set MaNV_DongNuoc=" + MaNV_DongNuoc + ",NgayGiao='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "',ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' where MaDN=" + MaDN;
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaGiaoDongNuoc(decimal MaDN)
        {
            try
            {
                string sql = "update TT_DongNuoc set MaNV_DongNuoc=null,NgayGiao=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture) + "' where MaDN=" + MaDN;
                return ExecuteNonQuery_Transaction(sql);
            }
            catch (Exception ex)
            {
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

        public bool XoaKQ(TT_KQDongNuoc kqdongnuoc)
        {
            try
            {
                _db.TT_KQDongNuocs.DeleteOnSubmit(kqdongnuoc);
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

        /// <summary>
        /// Lấy Danh Sách Thông Báo Đóng Nước chưa bị Hủy
        /// </summary>
        /// <param name="MaNV"></param>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataSet GetDSByMaNVCreateDates(int MaNV,DateTime TuNgay, DateTime DenNgay)
        {
            DataSet ds = new DataSet();

            var queryDN = from itemDN in _db.TT_DongNuocs
                            where itemDN.Huy==false && itemDN.CreateBy==MaNV && itemDN.CreateDate.Value.Date >= TuNgay.Date && itemDN.CreateDate.Value.Date <= DenNgay.Date
                            select new
                            {
                                In=false,
                                itemDN.MaDN,
                                itemDN.DanhBo,
                                itemDN.HoTen,
                                itemDN.DiaChi,
                                itemDN.MLT,
                                itemDN.CreateBy,
                                itemDN.MaNV_DongNuoc,
                                itemDN.CreateDate,
                                TinhTrang="",///Phải thêm để GridView lấy cột để edit lại sau
                            };
            DataTable dtDongNuoc = new DataTable();
            dtDongNuoc = LINQToDataTable(queryDN);
            dtDongNuoc.TableName = "DongNuoc";
            ds.Tables.Add(dtDongNuoc);

            var queryCTDN = from itemCTDN in _db.TT_CTDongNuocs
                            join itemDN in _db.TT_DongNuocs on itemCTDN.MaDN equals itemDN.MaDN
                            join itemHD in _db.HOADONs on itemCTDN.SoHoaDon equals itemHD.SOHOADON into tableHD
                            from itemtableHD in tableHD.DefaultIfEmpty()
                            where itemDN.Huy == false && itemDN.CreateBy == MaNV && itemDN.CreateDate.Value.Date >= TuNgay.Date && itemDN.CreateDate.Value.Date <= DenNgay.Date
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
                                itemtableHD.NGAYGIAITRACH,
                            };
            DataTable dtCTDongNuoc = new DataTable();
            dtCTDongNuoc = LINQToDataTable(queryCTDN);
            dtCTDongNuoc.TableName = "CTDongNuoc";
            ds.Tables.Add(dtCTDongNuoc);

            if (dtDongNuoc.Rows.Count > 0 && dtCTDongNuoc.Rows.Count > 0)
                ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DongNuoc"].Columns["MaDN"], ds.Tables["CTDongNuoc"].Columns["MaDN"]);

            return ds;
        }

        public DataTable GetDSKQDongNuocByDates(int MaNV, DateTime TuNgay, DateTime DenNgay)
        {
            return LINQToDataTable(_db.TT_KQDongNuocs.Where(item => item.CreateBy == MaNV && item.CreateDate.Value.Date >= TuNgay.Date && item.CreateDate.Value.Date <= DenNgay.Date).ToList());
        }

        public bool CheckKQDongNuocByMaDN(decimal MaDN)
        {
            return _db.TT_KQDongNuocs.Any(item => item.MaDN == MaDN);
        }

        public bool CheckKQDongNuocByMaDNNgayDN(decimal MaDN, DateTime NgayDN)
        {
            return _db.TT_KQDongNuocs.Any(item => item.MaDN == MaDN && item.CreateDate.Value.Date == NgayDN.Date);
        }

        /// <summary>
        /// Kiểm tra thông báo đóng nước có được giao cho nhân viên hay không
        /// </summary>
        /// <param name="MaDN"></param>
        /// <param name="MaNV_DongNuoc"></param>
        /// <returns></returns>
        public bool CheckDongNuocByMaDNMaNV_DongNuoc(decimal MaDN, int MaNV_DongNuoc)
        {
            return _db.TT_DongNuocs.Any(item => item.MaDN == MaDN && item.MaNV_DongNuoc == MaNV_DongNuoc);
        }

        /// <summary>
        /// Kiểm tra nhân viên có đi đóng nước thông báo được giao hay chưa
        /// </summary>
        /// <param name="MaDN"></param>
        /// <param name="MaNV_DongNuoc"></param>
        /// <returns></returns>
        public bool CheckKQDongNuocByMaDNCreateBy(decimal MaDN, int MaNV_DongNuoc)
        {
            return _db.TT_KQDongNuocs.Any(item => item.MaDN == MaDN && item.CreateBy == MaNV_DongNuoc);
        }

        /// <summary>
        /// Kiểm tra Số Hóa Đơn có lập Thông Báo chưa. Nếu Thông Báo trước đó bị hủy thì vẫn được lập cái mới
        /// </summary>
        /// <param name="SoHoaDon"></param>
        /// <returns></returns>
        public bool CheckCTDongNuocBySoHoaDon(string SoHoaDon)
        {
            return _db.TT_CTDongNuocs.Any(item => item.SoHoaDon == SoHoaDon && item.TT_DongNuoc.Huy == false);
        }

        public TT_DongNuoc GetDongNuocByMaDN(decimal MaDN)
        {
            return _db.TT_DongNuocs.SingleOrDefault(item => item.MaDN == MaDN);
        }

        public TT_KQDongNuoc GetKQDongNuocByMaCTDN(decimal MaCTDN)
        {
            return _db.TT_KQDongNuocs.SingleOrDefault(item => item.MaCTDN == MaCTDN);
        }

        public string GetNgayDNByMaHD(int MaHD)
        {
            var query = from itemDN in _db.TT_DongNuocs
                        join itemCTDN in _db.TT_CTDongNuocs on itemDN.MaDN equals itemCTDN.MaDN
                        join itemKQDN in _db.TT_KQDongNuocs on itemDN.MaDN equals itemKQDN.MaDN
                        where itemCTDN.MaHD == MaHD
                        select new
                        {
                            NgayDN=itemKQDN.NgayDN.Value.ToString("dd/MM/yyyy")
                        };
            if (query.Count() > 0)
                return query.Take(1).ToList()[0].NgayDN;
            else
                return "";
        }

        /// <summary>
        /// Kiểm tra Tồn Tại & Lấy Tên Nhân Viên, Tên Tổ theo Số Hóa Đơn. Phục vụ cho Tạm Thu
        /// </summary>
        /// <param name="SoHoaDon"></param>
        /// <param name="HoTen"></param>
        /// <param name="TenTo"></param>
        /// <returns></returns>
        public bool CheckExistBySoHoaDon(string SoHoaDon, out string HoTen, out string TenTo)
        {
            HoTen = "";
            TenTo = "";
            var query = from itemDN in _db.TT_DongNuocs
                        join itemND in _db.TT_NguoiDungs on itemDN.MaNV_DongNuoc equals itemND.MaND
                        join itemCTDN in _db.TT_CTDongNuocs on itemDN.MaDN equals itemCTDN.MaDN
                        where itemCTDN.SoHoaDon == SoHoaDon
                        select new
                        {
                            itemND.HoTen,
                            itemND.TT_To.TenTo,
                        };
            if (query.Count() > 0)
            {
                HoTen = query.Take(1).ToList()[0].HoTen;
                TenTo = query.Take(1).ToList()[0].TenTo;
                return true;
            }
            else
                return false;
            
        }
    }
}
