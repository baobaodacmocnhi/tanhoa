using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL.MaHoa
{
    class CDonTu : CDAL
    {
        public bool Them(MaHoa_DonTu entity)
        {
            try
            {
                if (_db.MaHoa_DonTus.Any(item => item.ID.ToString().Substring(0, 4) == DateTime.Now.ToString("yyMM")) == true)
                {
                    object stt = _cDAL.ExecuteQuery_ReturnOneValue("select MAX(SUBSTRING(CAST(ID as varchar(8)),5,4))+1 from MaHoa_DonTu where ID like '" + DateTime.Now.ToString("yyMM") + "%'");
                    if (stt != null)
                        entity.ID = int.Parse(DateTime.Now.ToString("yyMM") + ((int)stt).ToString("0000"));
                }
                else
                {
                    entity.ID = int.Parse(DateTime.Now.ToString("yyMM") + 1.ToString("0000"));
                }
                entity.CreateBy = CNguoiDung.MaND;
                entity.CreateDate = DateTime.Now;
                _db.MaHoa_DonTus.InsertOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(MaHoa_DonTu entity)
        {
            try
            {
                entity.ModifyBy = CNguoiDung.MaND;
                entity.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa(MaHoa_DonTu entity)
        {
            try
            {
                _db.MaHoa_DonTu_LichSus.DeleteAllOnSubmit(entity.MaHoa_DonTu_LichSus.ToList());
                _db.MaHoa_DonTus.DeleteOnSubmit(entity);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public MaHoa_DonTu get(int ID)
        {
            return _db.MaHoa_DonTus.SingleOrDefault(item => item.ID == ID);
        }


    }
}
