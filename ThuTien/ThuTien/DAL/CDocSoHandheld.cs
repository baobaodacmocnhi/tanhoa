using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using ThuTien.LinQ;

namespace ThuTien.DAL
{
    class CDocSoHandheld
    {
        dbDocSoHandheldDataContext _db = new dbDocSoHandheldDataContext();

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public DocSo Get(string DanhBo)
        {
            return _db.DocSos.Where(item=>item.DanhBa==DanhBo).OrderByDescending(item=>item.DocSoID).FirstOrDefault();
        }

        public DocSo get(string DanhBo, int Ky, int Nam)
        {
            return _db.DocSos.SingleOrDefault(item => item.DanhBa == DanhBo && Convert.ToInt32(item.Ky) == Ky && item.Nam == Nam);
        }
    }
}
