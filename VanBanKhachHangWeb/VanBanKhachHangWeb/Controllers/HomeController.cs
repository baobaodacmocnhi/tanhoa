using CaptchaMvc.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VanBanKhachHangWeb.DAL;
using VanBanKhachHangWeb.Models;
using static VanBanKhachHangWeb.Models.VanBanKhachHangModel;

namespace VanBanKhachHangWeb.Controllers
{
    public class HomeController : Controller
    {
        cKinhDoanh _cKinhDoanh = new cKinhDoanh();

        public ActionResult Index()
        {
            VanBanKhachHangModel model = new VanBanKhachHangModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Index(VanBanKhachHangModel model)
        {
            // Code for validating the Captcha  
            if (this.IsCaptchaValid("Sai mã xác nhận")==true)
            {
                if (model.ttkh.DanhBo == null || model.ttkh.DanhBo.Replace(" ", "").Length < 11)
                {
                    ModelState.AddModelError("m.ttkh.DanhBo", "Danh Bộ không đúng");
                    return View(model);
                }
                DataTable dt = _cKinhDoanh.getDS_File(model.ttkh.DanhBo.Replace(" ", ""));
                if (dt.Rows.Count == 0)
                {
                    ModelState.AddModelError("m.ttkh.DanhBo", "Danh Bộ không đúng hoặc Không có Văn Bản");
                }
                foreach (DataRow item in dt.Rows)
                {
                    model.ttkh.DanhBo = item["DanhBo"].ToString();
                    model.ttkh.HoTen = item["HoTen"].ToString();
                    model.ttkh.DiaChi = item["DiaChi"].ToString();
                    VanBan en = new VanBan();
                    en.LoaiVanBan = item["LoaiVanBan"].ToString();
                    en.TableName = item["TableName"].ToString();
                    en.IDFileContent = item["IDFileContent"].ToString();
                    model.lstVanBan.Add(en);
                }
                return View(model);
            }
            return View(model);
        }

        public ActionResult viewFile(string TableName, string IDFileContent)
        {
            if (TableName != "" && IDFileContent != "")
            {
                byte[] FileContent = _cKinhDoanh.getFile(TableName, IDFileContent);
                if (FileContent != null)
                    return new FileStreamResult(new MemoryStream(FileContent), "image/jpeg");
                else
                    return null;
            }
            else
                return null;
        }
    }
}