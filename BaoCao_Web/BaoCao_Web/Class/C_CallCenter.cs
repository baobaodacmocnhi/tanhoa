using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaoCao_Web.DataBase;
using System.Data;
using System.Data.SqlClient;

namespace BaoCao_Web.Class
{
    public class C_CallCenter
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("File");
        static CallCenterDataContext db = new CallCenterDataContext();

        public static KT_DongNuoc finById(int id)
        {
            try
            {
                var query = from q in db.KT_DongNuocs where q.ID == id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public static void Insert(KT_DongNuoc tb)
        {
            try
            {
                db.KT_DongNuocs.InsertOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void Delete(KT_DongNuoc tb)
        {
            try
            {
                db.KT_DongNuocs.DeleteOnSubmit(tb);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static bool Update()
        {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

       
    }
}