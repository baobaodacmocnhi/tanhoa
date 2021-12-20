using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DocSo_PC.DAL.TraCuuThongTin
{
    class CTraCuuThongTin : CDHN
    {
        public DataTable Search(string danhbo, string diachi, string lotrinh, string hopdong, string sothan, string may, string dot)
        {
            DataTable tb = new DataTable();

            string sql = "SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPHUONG ,LOTRINH, HOTEN,HOPDONG,HIEUDH,CODH,SOTHANDH,(CONVERT(VARCHAR,KY)+'/'+CONVERT(VARCHAR,NAM) ) AS N'HL', YEAR(NGAYTHAY) AS N'NĂM GẮN'  FROM TB_DULIEUKHACHHANG  ";

            if (!"".Equals(danhbo))
            {
                sql += " WHERE DANHBO = '" + danhbo + "' ORDER BY LOTRINH ASC ";
                tb = _cDAL.ExecuteQuery_DataTable(sql);

                sql = " SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPUONG ,LOTRINH, HOTEN,HOPDONG,HIEUDH,CODH,SOTHANDH, N'Hủy ' +HIEULUCHUY AS N'HL'  FROM TB_DULIEUKHACHHANG_HUYDB  WHERE DANHBO = '" + danhbo + "' ORDER BY LOTRINH ASC ";
                tb.Merge(_cDAL.ExecuteQuery_DataTable(sql));
                return tb;
            }


            if (!"".Equals(diachi))
            {
                sql += " WHERE (SONHA+' '+ TENDUONG) LIKE '" + diachi.Replace("*", "%") + "' ORDER BY LOTRINH ASC ";
                tb = _cDAL.ExecuteQuery_DataTable(sql);

                sql = " SELECT DANHBO, (SONHA+' '+ TENDUONG) as DIACHI, (QUAN+PHUONG) AS QUANPUONG ,LOTRINH, HOTEN,HOPDONG,HIEUDH,CODH,SOTHANDH, N'Hủy ' +HIEULUCHUY AS N'HL'   FROM TB_DULIEUKHACHHANG_HUYDB  WHERE (SONHA+' '+ TENDUONG) LIKE '" + diachi.Replace("*", "%") + "' ORDER BY LOTRINH ASC ";
                tb.Merge(_cDAL.ExecuteQuery_DataTable(sql));
                return tb;
            }


            if (!"".Equals(lotrinh))
            {
                sql += " WHERE LOTRINH LIKE  '" + lotrinh.Replace("*", "%") + "' ORDER BY LOTRINH ASC ";
                tb = _cDAL.ExecuteQuery_DataTable(sql);
                return tb;
            }

            if (!"".Equals(hopdong))
            {
                sql += " WHERE HOPDONG LIKE  '" + hopdong.Replace("*", "%") + "' ORDER BY LOTRINH ASC ";
                tb = _cDAL.ExecuteQuery_DataTable(sql);
                return tb;
            }

            if (!"".Equals(sothan))
            {
                sql += " WHERE SOTHANDH LIKE  '%" + sothan.Replace("*", "%") + "' ORDER BY LOTRINH ASC ";
                tb = _cDAL.ExecuteQuery_DataTable(sql);
                return tb;
            }

            if (!"".Equals(may))
            {
                sql += " WHERE LEFT(LOTRINH,4)='" + dot + "" + may + "' ORDER BY LOTRINH ASC ";
                tb = _cDAL.ExecuteQuery_DataTable(sql);
                return tb;
            }

            return tb;

        }
    }
}