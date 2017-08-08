using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.TongHop
{
    class CDangKyKiemTra:CDAL
    {
        public bool Them(TT_DangKyKiemTra entity)
        {
            try
            {
                if (_db.TT_DangKyKiemTras.Count() > 0)
                {
                    string ID = "MaDKKT";
                    string Table = "TT_DangKyKiemTra";
                    decimal MaDKKT = _db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    entity.MaDKKT = getMaxNextIDTable(MaDKKT);
                }
                else
                    entity.MaDKKT = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CNguoiDung.MaND;
                _db.TT_DangKyKiemTras.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_DangKyKiemTra entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TT_DangKyKiemTra entity)
        {
            try
            {
                _db.TT_DangKyKiemTras.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetDS()
        {
            return LINQToDataTable(_db.TT_DangKyKiemTras.OrderByDescending(item => item.CreateDate).ToList());
        }

        public TT_DangKyKiemTra Get(decimal MaDKKT)
        {
            return _db.TT_DangKyKiemTras.SingleOrDefault(item => item.MaDKKT == MaDKKT);
        }

        ///

        public bool ThemCT(TT_CTDangKyKiemTra entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CNguoiDung.MaND;
                _db.TT_CTDangKyKiemTras.InsertOnSubmit(entity);
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

        public bool XoaCT(TT_CTDangKyKiemTra entity)
        {
            try
            {
                _db.TT_CTDangKyKiemTras.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaCT(TT_CTDangKyKiemTra entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string DanhBo)
        {
            return _db.TT_CTDangKyKiemTras.Any(item => item.DanhBo == DanhBo);
        }

        public string GetHoTen(string DanhBo)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.MaND == _db.TT_CTDangKyKiemTras.SingleOrDefault(item2 => item2.DanhBo == DanhBo).MaNV_HanhThu).HoTen;
        }

        public TT_CTDangKyKiemTra GetCT(string DanhBo)
        {
            return _db.TT_CTDangKyKiemTras.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public DataTable GetDSCT(int MaNV)
        {
            var query = from itemDK in _db.TT_CTDangKyKiemTras
                        join itemND in _db.TT_NguoiDungs on itemDK.MaNV_HanhThu equals itemND.MaND
                        where itemDK.MaNV_HanhThu == MaNV
                        select new
                        {
                            itemND.HoTen,
                            itemDK.DanhBo,
                            itemDK.MLT,
                            itemDK.DiaChi,
                            itemDK.GB_DM_Cu,
                            itemDK.NoiDung,
                            itemDK.CreateDate,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSCT(decimal MaDKKT)
        {
            return LINQToDataTable(_db.TT_CTDangKyKiemTras.Where(item => item.MaDKKT == MaDKKT).ToList());
        }

        public int CountCT(decimal MaDKKT)
        {
            return _db.TT_CTDangKyKiemTras.Count(item => item.MaDKKT == MaDKKT);
        }

        public decimal GetMaDKKT(string DanhDo)
        {
            return _db.TT_CTDangKyKiemTras.SingleOrDefault(item => item.DanhBo == DanhDo).MaDKKT.Value;
        }
    }
}
