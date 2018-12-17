using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace QLVanThu.DAL
{
    class CLinQToDataTable
    {
        /// <summary>
        /// var vrCountry = from country in objEmpDataContext.CountryMaster
        ///                select new {country.CountryID,country.CountryName};
        /// DataTable dt = LINQToDataTable(vrCountry);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist"></param>
        /// <returns></returns>
        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
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

        /// <summary>
        /// var vrCountry = from country in objEmpDataContext.CountryMaster
        ///                select new {country.CountryID,country.CountryName};
        /// DataTable dt = LINQToDataTable(objEmpDataContext,vrCountry);
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(System.Data.Linq.DataContext ctx, object query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            IDbCommand cmd = ctx.GetCommand(query as IQueryable);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)cmd;
            DataTable dt = new DataTable("sd");

            try
            {
                cmd.Connection.Open();
                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }
    }
}
