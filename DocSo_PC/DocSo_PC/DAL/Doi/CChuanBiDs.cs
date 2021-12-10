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
    class CChuanBiDS : CDAL
    {
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

        public void UpdateStoredProcedure(string storedNam, int nam, string ky, string dot)
        {

            SqlConnection conn = new SqlConnection(_db.Connection.ConnectionString);
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

        public DataTable GetSoDocSo(string storedNam, int nam, string ky, string dot, int tu, int den)
        {
            DataTable tb = new DataTable();
            SqlConnection conn = new SqlConnection(_db.Connection.ConnectionString);

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

        public BillState GetBillState(int Nam, string Ky, string Dot)
        {
            return _db.BillStates.SingleOrDefault(item => item.BillID == ("" + Nam + Ky + Dot));
        }

        public List<BienDong> getListBienFong(int nam, string ky, string dot, int tumay, int denmay)
        {
            var query = from q in _db.BienDongs where q.Nam == nam && q.Ky == ky && q.Dot == dot && Convert.ToInt32(q.May) >= tumay && Convert.ToInt32(q.May) <= denmay select q;
            return query.ToList();
        }
        public int getTTTB3ky(string danhba)
        {
            try
            {
                string sql = " select AVG(TieuThu) from ( ";
                sql += " SELECT  TOP(3) TieuThu FROM HoaDon  ";
                sql += " WHERE DanhBa='"+danhba+"'  ";
                sql += " ORDER   BY  NAM DESC,KY DESC   ";
                sql += "  as t1";
                return int.Parse(ExecuteQuery_ReturnOneValue(sql).ToString());

            }
            catch (Exception)
            {

            }
            return 0;
        }

        public DateTime getDocTuNgay(int nam, string ky, string dot)
        {
            DateTime d = DateTime.Now.Date;
            try
            {
                string sql = " SELECT  TOP(1) DenNgay FROM HoaDon  ";
                sql += " WHERE Nam=" + nam + " AND Ky=" + (int.Parse(ky)-1) + " AND Dot='" + dot + "'  ";
               
                d= DateTime.Parse(ExecuteQuery_ReturnOneValue(sql).ToString());

            }
            catch (Exception)
            {

            }
            return d;
        }

        public int getTangCuong(int nam, string ky, string dot, string may)
        {
            try
            {
                string sql = " select COUNT(*)  from DocSo where Nam=" + nam + " AND Ky='" + ky + "' AND Dot='" + dot + "'   AND May='" + may + "'  and CAST( May as int)  != CAST(SUBSTRING(MLT1,3,2) as int) ";
                return int.Parse(ExecuteQuery_ReturnOneValue(sql).ToString());

            }
            catch (Exception)
            {

            }
            return 0;
        }
    }
}
