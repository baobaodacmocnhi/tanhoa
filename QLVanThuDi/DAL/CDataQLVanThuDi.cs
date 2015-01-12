using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLVanThuDi.LinQ;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLVanThu.DAL
{
    class CDataQLVanThuDi
    {
        DBVanThuDataContext db = new DBVanThuDataContext();
        public DataTable LoadDSVanThuDi()
        {
            //var vanthus = from itemDoc in db.WF_Incoming_Docs
            //              join itemBook in db.WF_Books on itemDoc.BookID equals itemBook.BookID
            //              orderby itemDoc.CreatedDate descending
            //              select new
            //              {
            //                  ID = itemDoc.DocumentID,
            //                  //NgayDen = itemDoc.CreatedDate.Value.Day + "/" + itemDoc.CreatedDate.Value.Month + "/" + itemDoc.CreatedDate.Value.Year,
            //                  NgayDen=itemDoc.CreatedDate.Value,
            //                  LoaiVBID = itemDoc.BookID,
            //                  LoaiVBName = itemBook.Name,
            //                  SoDen=itemDoc.DocumentOrderNo,
            //                  TacGiaVB=itemDoc.IssuedOrganizationName2,
            //                  SoKyHieuVB=itemDoc.DocumentNo,
            //                  NgayThangVB=itemDoc.IssuedDate,
            //                  LoaiTrichYeuNoiDung=itemDoc.DocumentSummary,
            //                  NguoiNhan=itemDoc.ReviewContent,
            //              };
            //return CLinQToDataTable.LINQToDataTable(vanthus);

            DataTable table = new DataTable();
            string sql = "select convert(varchar(10),IssuedDate,103) as NgayThangVB,DocumentOrderNo as SoDi,OrganizationReceivers2 as NoiNhan,DocumentNo as SoKyHieuVB,";
            sql += "convert(varchar(10),CreatedDate,103) as NgayNhap,t.Notation as LoaiVB,t.TypeID,DocumentSummary as LoaiTrichYeuNoiDung,DocumentID as ID,d.BookID as LoaiVBGID,b.Name as LoaiVBGName ";
            sql += "from WF_Books b,WF_Outgoing_Docs d,WF_Doc_Types t where b.BookID=d.BookID and d.TypeID=t.TypeID order by IssuedDate desc,DocumentOrderNo desc";
            try 
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, "Data Source=192.168.90.7,8819;Initial Catalog=CAPNUOCTANHOAOFFICESE2009;User ID=sa;Password=sa");
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }

        public DataTable LoadDSVanThuDiDateToDate(string tungay,string denngay)
        {
            DataTable table = new DataTable();
            string sql = "select convert(varchar(10),IssuedDate,103) as NgayThangVB,DocumentOrderNo as SoDi,OrganizationReceivers2 as NoiNhan,DocumentNo as SoKyHieuVB,";
            sql += "convert(varchar(10),CreatedDate,103) as NgayNhap,t.Notation as LoaiVB,DocumentSummary as LoaiTrichYeuNoiDung,DocumentID as ID,d.BookID as LoaiVBGID,b.Name as LoaiVBGName ";
            sql += "from WF_Books b,WF_Outgoing_Docs d,WF_Doc_Types t where IssuedDate between '" + tungay + "' and '" + denngay + "' and b.BookID=d.BookID and d.TypeID=t.TypeID order by IssuedDate desc,DocumentOrderNo desc";
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, "Data Source=192.168.90.7,8819;Initial Catalog=CAPNUOCTANHOAOFFICESE2009;User ID=sa;Password=sa");
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }
    }
}
