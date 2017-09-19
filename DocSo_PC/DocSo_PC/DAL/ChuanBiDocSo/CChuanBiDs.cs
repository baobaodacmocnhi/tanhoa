using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;
using System.Data;
using System.Data.SqlClient;

namespace DocSo_PC.DAL.ChuanBiDocSo
{
    class CChuanBiDS : CDALTest
    {
        static DocSoTestDataContext db = new DocSoTestDataContext();
        public bool CheckExist(string DanhBo, int Nam, string Ky, string Dot)
        {
            return _db.HoaDons.Any(item => item.DanhBa == DanhBo && item.Nam == Nam && item.Ky == Ky && item.Dot == Dot);
        }

        public HoaDon Get(string DanhBo, int Nam, string Ky, string Dot)
        {
            return _db.HoaDons.SingleOrDefault(item => item.DanhBa == DanhBo && item.Nam == Nam && item.Ky == Ky && item.Dot == Dot);
        }

        public bool Insert(HoaDon hoadon)
        {
            try
            {
                _db.HoaDons.InsertOnSubmit(hoadon);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Update(HoaDon hoadon)
        {
            try
            {
                hoadon.NVCapNhat = CNguoiDung.TaiKhoan;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetTongByNamKy(int Nam, string Ky)
        {
            var query = from item in _db.HoaDons
                        where item.Nam == Nam && item.Ky == Ky
                        //orderby item.DOT ascending
                        group item by item.Dot into itemGroup
                        select new
                        {
                            Dot = itemGroup.Key,
                            TongHD = itemGroup.Count(),
                            TongTieuThu = itemGroup.Sum(groupItem => groupItem.TieuThu),
                            itemGroup.FirstOrDefault().NgayCapNhat,
                        };
            return LINQToDataTable(query.OrderBy(item => item.Dot));
            //string sql = "select DOT,count(ID_HoaDon) as TongHD,sum(TIEUTHU) as TongLNCC,sum(GIABAN) as TongGiaBan,sum(THUE) as TongThueGTGT,sum(PHI) as TongPhiBVMT,sum(TONGCONG) as TongCong "
            //    + "from HOADON where NAM='" + nam + "' and KY='" + ky + "' group by DOT order by DOT asc";
            //return ExecuteQuery_SqlDataReader_DataTable(sql);
        }

        /// <summary>
        /// Cập Nhật Biến Động
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="Nam"></param>
        /// <param name="Ky"></param>
        /// <param name="Dot"></param>
        /// <returns></returns>

        public bool CheckExistBienDong(string DanhBo, int Nam, string Ky, string Dot)
        {
            return _db.BienDongs.Any(item => item.DanhBa == DanhBo && item.Nam == Nam && item.Ky == Ky && item.Dot == Dot);
        }

        public BienDong GetBienDong(string DanhBo, int Nam, string Ky, string Dot)
        {
            return _db.BienDongs.SingleOrDefault(item => item.DanhBa == DanhBo && item.Nam == Nam && item.Ky == Ky && item.Dot == Dot);
        }

        public bool InsertBienDong(BienDong hoadon)
        {
            try
            {
                _db.BienDongs.InsertOnSubmit(hoadon);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateBienDong(BienDong hoadon)
        {
            try
            {
                hoadon.NVCapNhat = CNguoiDung.TaiKhoan;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public static void UpdateTTBienDong(string storedNam, int nam, string ky, string dot)
        {

            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
            try
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(storedNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter _nam = cmd.Parameters.Add("@NAM", SqlDbType.Int);
                _nam.Direction = ParameterDirection.Input;
                _nam.Value = nam;

                SqlParameter _ky = cmd.Parameters.Add("@KY", SqlDbType.VarChar);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = ky;

                SqlParameter _dot = cmd.Parameters.Add("@DOT", SqlDbType.VarChar);
                _dot.Direction = ParameterDirection.Input;
                _dot.Value = dot;


                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataTable GetSoDocSo(string storedNam, int nam, string ky, string dot, int tu, int den)
        {
            DataTable tb = new DataTable();
            SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
           
            try
            {

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(storedNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                

                SqlParameter _nam = cmd.Parameters.Add("@NAM", SqlDbType.Int);
                _nam.Direction = ParameterDirection.Input;
                _nam.Value = nam;

                SqlParameter _ky = cmd.Parameters.Add("@KY", SqlDbType.VarChar);
                _ky.Direction = ParameterDirection.Input;
                _ky.Value = ky;

                SqlParameter _dot = cmd.Parameters.Add("@DOT", SqlDbType.VarChar);
                _dot.Direction = ParameterDirection.Input;
                _dot.Value = dot;

                SqlParameter _tu = cmd.Parameters.Add("@TUMAY", SqlDbType.Int);
                _tu.Direction = ParameterDirection.Input;
                _tu.Value = tu;

                SqlParameter _den = cmd.Parameters.Add("@DENMAY", SqlDbType.Int);
                _den.Direction = ParameterDirection.Input;
                _den.Value = den;


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                //cmd.ExecuteNonQuery();
                adapter.Fill(tb);
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            return tb;
        }

        public static BillState GetBillState(int Nam, string Ky, string Dot)
        {
            return _db.BillStates.SingleOrDefault(item => item.BillID == ("" + Nam+Ky+Dot));
        }
    }
}
