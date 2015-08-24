using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.TongHop
{
    class CChamCong:CDAL
    {
        public bool Them(TT_ChamCong chamcong)
        {
            try
            {
                if (_db.TT_ChamCongs.Count() > 0)
                    chamcong.MaCC = _db.TT_ChamCongs.Max(item => item.MaCC) + 1;
                else
                    chamcong.MaCC = 1;
                chamcong.CreateDate = DateTime.Now;
                chamcong.CreateBy = CNguoiDung.MaND;
                _db.TT_ChamCongs.InsertOnSubmit(chamcong);
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

        public bool Xoa(TT_ChamCong chamcong)
        {
            try
            {
                _db.TT_ChamCongs.DeleteOnSubmit(chamcong);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(int Thang, int Nam)
        {
            return _db.TT_ChamCongs.Any(item => item.Thang == Thang && item.Nam == Nam);
        }

        public DataTable GetDS(int Thang, int Nam)
        {
            var query = from item in _db.TT_CTChamCongs
                        where item.TT_ChamCong.Thang == Thang && item.TT_ChamCong.Nam == Nam
                        select new
                        {
                            item.MaCC,
                            MaNV=item.MaND,
                            item.TT_NguoiDung.HoTen,
                            item.N1,
                            item.N2,
                            item.N3,
                            item.N4,
                            item.N5,
                            item.N6,
                            item.N7,
                            item.N8,
                            item.N9,
                            item.N10,
                            item.N11,
                            item.N12,
                            item.N13,
                            item.N14,
                            item.N15,
                            item.N16,
                            item.N17,
                            item.N18,
                            item.N19,
                            item.N20,
                            item.N21,
                            item.N22,
                            item.N23,
                            item.N24,
                            item.N25,
                            item.N26,
                            item.N27,
                            item.N28,
                            item.N29,
                            item.N30,
                            item.N31,
                        };
            return LINQToDataTable(query);
        }
    }
}
