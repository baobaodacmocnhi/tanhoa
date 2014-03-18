using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_ChungCu.LinQ;
using System.Windows.Forms;
using System.Data;
using KTKS_ChungCu.Function;

namespace KTKS_ChungCu.DAL
{
    class CChungCu : CDAL
    {
        /// <summary>
        /// Thêm Khách Hàng vào Chung Cư
        /// </summary>
        /// <param name="chungcu"></param>
        /// <returns></returns>
        public bool ThemKHChungCu(ChungCu chungcu)
        {
            try
            {
                chungcu.CreateDate = DateTime.Now;
                chungcu.CreateBy = -1;
                db.ChungCus.InsertOnSubmit(chungcu);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        /// <summary>
        /// Sửa Khách Hàng của Chung Cư
        /// </summary>
        /// <param name="chungcu"></param>
        /// <returns></returns>
        public bool SuaKHChungCu(ChungCu chungcu)
        {
            try
            {
                chungcu.ModifyDate = DateTime.Now;
                chungcu.ModifyBy = -1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public List<ChungCu> LoadDSKHChungCu(string DanhBo)
        {
            try
            {
                return db.ChungCus.Where(itemCC => itemCC.DanhBo == DanhBo).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Danh Bộ đã đăng ký với Số Chứng Từ & khác Danh Bộ truyền vào
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="MaCT"></param>
        /// <returns></returns>
        public DataTable LoadDSKHChungCu(string DanhBo, string MaCT)
        {
            try
            {
                return CLinQToDataTable.LINQToDataTable(db.ChungCus.Where(itemCC => itemCC.MaCT == MaCT && itemCC.DanhBo != DanhBo).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public ChungCu getKHChungCuByID(string DanhBo,string MaCT)
        {
            try
            {
                return db.ChungCus.SingleOrDefault(itemCC => itemCC.DanhBo == DanhBo && itemCC.MaCT == MaCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool CheckKHChungCu(string DanhBo, string MaCT)
        {
            try
            {
                return db.ChungCus.Any(itemCC => itemCC.DanhBo == DanhBo && itemCC.MaCT == MaCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        
    }
}
