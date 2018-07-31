using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;
using System.Windows.Forms;

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
                    entity.STT = (int.Parse(db.DonTus.Where(item => item.NamThang == DateTime.Now.ToString("yyMM")).Max(item => item.STT)) + 1).ToString("000");
                }
                else
                {
                    entity.STT = 1.ToString("000");
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
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public bool Xoa(LinQ.DonTu entity)
        {
            try
            {
                db.DonTus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(int MaDon)
        {
            return db.DonTus.Any(item => item.MaDon == MaDon);
        }

        public bool CheckExist(string DanhBo,DateTime CreateDate)
        {
            if (db.DonTus.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date) == true)
                return true;
            else
                return db.DonTu_ChiTiets.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public int getMaxID_ChiTiet()
        {
            if (db.DonTu_ChiTiets.Count() == 0)
                return 0;
            else
                return db.DonTu_ChiTiets.Max(item => item.ID);
        }

        public LinQ.DonTu Get(int MaDon)
        {
            return db.DonTus.SingleOrDefault(item => item.MaDon == MaDon);
        }

        public DataTable GetDS(int MaDon)
        {
            var query = from item in db.DonTus
                        where item.MaDon == MaDon
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int FromMaDon, int ToMaDon)
        {
            var query = from item in db.DonTus
                        where item.MaDon >=FromMaDon && item.MaDon <= ToMaDon
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByDanhBo(string DanhBo)
        {
            var query = from item in db.DonTus
                        where item.DanhBo==DanhBo
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSBySoCongVan(string SoCongVan)
        {
            var query = from item in db.DonTus
                        where item.SoCongVan==SoCongVan
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate,DateTime ToCreateDate)
        {
            var query = from item in db.DonTus
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            item.MaDon,
                            item.SoCongVan,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            NoiDung = item.Name_NhomDon,
                        };
            return LINQToDataTable(query);
        }


    }
}
