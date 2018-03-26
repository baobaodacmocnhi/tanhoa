using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;
using System.Data.SqlClient;

namespace KTKS_DonKH.DAL
{
    class CDocSo
    {
        private dbDocSoDataContext db = new dbDocSoDataContext();

        protected static string _connectionString;
        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;

        public CDocSo()
        {
            try
            {
                _connectionString = KTKS_DonKH.Properties.Settings.Default.CAPNUOCTANHOAConnectionString;
                connection = new SqlConnection(_connectionString);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Refresh()
        {
            db = new dbDocSoDataContext();
        }

        public void Connect()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public bool LinQ_ExecuteNonQuery(string sql)
        {
            if (db.ExecuteCommand(sql) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Thực thi câu truy vấn SQL trả về một đối tượng DataSet chứa kết quả trả về
        /// </summary>
        /// <param name="strSelect">Câu truy vấn cần thực thi lấy dữ liệu</param>
        /// <returns>Đối tượng dataset chứa dữ liệu kết quả câu truy vấn</returns>
        public DataSet ExecuteQuery_SqlDataAdapter_DataSet(string sql)
        {
            try
            {
                Connect();
                DataSet dataset = new DataSet();
                command = new SqlCommand();
                command.Connection = this.connection;
                adapter = new SqlDataAdapter(sql, connection);
                try
                {
                    adapter.Fill(dataset);
                }
                catch (SqlException e)
                {
                    throw e;
                }
                Disconnect();
                return dataset;
            }
            catch (Exception)
            {
                Disconnect();
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thực thi câu truy vấn SQL trả về một đối tượng DataTable chứa kết quả trả về
        /// </summary>
        /// <param name="strSelect">Câu truy vấn cần thực thi lấy dữ liệu</param>
        /// <returns>Đối tượng datatable chứa dữ liệu kết quả câu truy vấn</returns>
        public DataTable ExecuteQuery_SqlDataAdapter_DataTable(string sql)
        {
            try
            {
                return ExecuteQuery_SqlDataAdapter_DataSet(sql).Tables[0];
            }
            catch (Exception)
            {
                Disconnect();
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public TB_DULIEUKHACHHANG GetTTKH(string DanhBo)
        {
            //if (db.TB_DULIEUKHACHHANGs.Any(item => item.DANHBO == DanhBo) == true)
                return db.TB_DULIEUKHACHHANGs.SingleOrDefault(itemDLKH => itemDLKH.DANHBO == DanhBo);
            //else
            //{
            //    TB_DULIEUKHACHHANG entity = new TB_DULIEUKHACHHANG();
            //    TB_DULIEUKHACHHANG_HUYDB entity_huy = new TB_DULIEUKHACHHANG_HUYDB();

            //    entity_huy = db.TB_DULIEUKHACHHANG_HUYDBs.SingleOrDefault(itemDLKH => itemDLKH.DANHBO == DanhBo);

            //    entity.KHU = entity_huy.KHU;
            //    entity.DOT = entity_huy.DOT;
            //    entity.CUON_GCS = entity_huy.CUON_GCS;
            //    entity.CUON_STT = entity_huy.CUON_STT;
            //    entity.LOTRINH = entity_huy.LOTRINH;
            //    entity.DANHBO = entity_huy.DANHBO;
            //    entity.NGAYGANDH = entity_huy.NGAYGANDH;
            //    entity.HOPDONG = entity_huy.HOPDONG;
            //    entity.HOTEN = entity_huy.HOTEN;
            //    entity.SONHA = entity_huy.SONHA;
            //    entity.TENDUONG = entity_huy.TENDUONG;
            //    entity.PHUONG = entity_huy.PHUONG;
            //    entity.QUAN = entity_huy.QUAN;
            //    entity.CHUKY = entity_huy.CHUKY;
            //    entity.CODE = entity_huy.CODE;
            //    entity.CODEFU = entity_huy.CODEFU;
            //    entity.GIABIEU = entity_huy.GIABIEU;
            //    entity.DINHMUC = entity_huy.DINHMUC;
            //    entity.SH = entity_huy.SH;
            //    entity.HCSN = entity_huy.HCSN;
            //    entity.SX = entity_huy.SX;
            //    entity.DV = entity_huy.DV;
            //    entity.CODH = entity_huy.CODH;
            //    entity.HIEUDH = entity_huy.HIEUDH;
            //    entity.SOTHANDH = entity_huy.SOTHANDH;
            //    entity.CAP = entity_huy.CAP;
            //    entity.CHITHAN = entity_huy.CHITHAN;
            //    entity.CHIGOC = entity_huy.CHIGOC;
            //    entity.VITRIDHN = entity_huy.VITRIDHN;
            //    entity.SODHN = entity_huy.SODHN;
            //    entity.NGAYTHAY = entity_huy.NGAYTHAY;
            //    entity.NGAYKIEMDINH = entity_huy.NGAYKIEMDINH;
            //    entity.MSTHUE = entity_huy.MSTHUE;
            //    entity.SOHO = entity_huy.SOHO;
            //    entity.CHISOKYTRUOC = entity_huy.CHISOKYTRUOC;
            //    entity.CREATEDATE = entity_huy.CREATEDATE;
            //    entity.CREATEBY = entity_huy.CREATEBY;
            //    entity.MODIFYDATE = entity_huy.MODIFYDATE;
            //    entity.MODIFYBY = entity_huy.MODIFYBY;
            //    entity.MADMA = entity_huy.MADMA;
            //    entity.CHUKYDS = entity_huy.CHUKYDS;

            //    return entity;
            //}
        }

        public bool CheckExist(string DanhBo)
        {
            try
            {
                return db.TB_DULIEUKHACHHANGs.Any(itemDLKH => itemDLKH.DANHBO == DanhBo);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaDLKH(TB_DULIEUKHACHHANG dulieukhachhang)
        {
            try
            {
                dulieukhachhang.MODIFYDATE = DateTime.Now;
                dulieukhachhang.MODIFYBY = CTaiKhoan.HoTen;
                db.SubmitChanges();
                //db = new DB_CAPNUOCTANHOADataContext();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ThemGhiChu(TB_GHICHU ghichu)
        {
            try
            {
                ghichu.CREATEDATE = DateTime.Now;
                ghichu.CREATEBY = CTaiKhoan.HoTen;
                db.TB_GHICHUs.InsertOnSubmit(ghichu);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string GetDinhMuc(string DanhBo)
        {
            if (db.TB_DULIEUKHACHHANGs.Any(item => item.DANHBO == DanhBo) == true)
                return db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo).DINHMUC;
            else
                return db.TB_DULIEUKHACHHANG_HUYDBs.SingleOrDefault(item => item.DANHBO == DanhBo).DINHMUC;
        }

        /// <summary>
        /// Lấy Tên Phường & Quận của Danh Bộ
        /// </summary>
        /// <param name="MaQuan"></param>
        /// <param name="MaPhuong"></param>
        /// <returns></returns>
        public string GetPhuongQuan(string MaQuan, string MaPhuong)
        {
            try
            {
                string Phuong = ", P." + db.PHUONGs.Single(itemPhuong => itemPhuong.MAQUAN == int.Parse(MaQuan) && itemPhuong.MAPHUONG == MaPhuong).TENPHUONG;
                string Quan = ", Q." + db.QUANs.Single(itemQuan => itemQuan.MAQUAN == int.Parse(MaQuan)).TENQUAN;
                return Phuong + Quan;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void GetDHN(string DanhBo, out string Hieu, out string Co, out string SoThan)
        {
            try
            {
                TB_DULIEUKHACHHANG ttkhachhang = db.TB_DULIEUKHACHHANGs.SingleOrDefault(itemttkhachhang => itemttkhachhang.DANHBO == DanhBo);
                Hieu = ttkhachhang.HIEUDH;
                Co = ttkhachhang.CODH;
                SoThan = ttkhachhang.SOTHANDH;
            }
            catch (Exception)
            {
                Hieu = "";
                Co = "";
                SoThan = "";
            }

        }

        public List<QUAN> GetDSQuan()
        {
            return db.QUANs.ToList();
        }

        public List<PHUONG> GetDSPhuong(int MaQuan)
        {
            return db.PHUONGs.Where(item => item.MAQUAN == MaQuan).ToList();
        }

        public string GetTenQuan(int MaQuan)
        {
            return db.QUANs.SingleOrDefault(item => item.MAQUAN == MaQuan).TENQUAN;
        }

        public string GetTenPhuong(int MaQuan, string MaPhuong)
        {
            return db.PHUONGs.SingleOrDefault(item => item.MAQUAN == MaQuan && item.MAPHUONG == MaPhuong).TENPHUONG;
        }

        public List<TB_DULIEUKHACHHANG> GetDS(string SoThanDHN)
        {
            return db.TB_DULIEUKHACHHANGs.Where(item => item.SOTHANDH.ToUpper().Contains(SoThanDHN.ToUpper())).ToList();
        }

        public string GetDot(string DanhBo)
        {
            return db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo).LOTRINH.Substring(0, 2);
        }

        public DataTable GetDSChungCu()
        {
            var sql = "select DanhBo,HoTen,DiaChi=SONHA+' '+TENDUONG,GiaBieu,DinhMuc,Quan=b.TENQUAN,PHUONG=c.TENPHUONG from TB_DULIEUKHACHHANG a"
                        + " left join QUAN b on a.QUAN=b.MAQUAN"
                        + " left join PHUONG c on a.QUAN=c.MAQUAN and a.PHUONG=c.MAPHUONG"
                        + " where GIABIEU=51 or GIABIEU=59 or GIABIEU=68";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

    }
}
