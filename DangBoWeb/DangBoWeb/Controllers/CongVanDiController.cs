using DangBoWeb.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DangBoWeb.Controllers
{
    public class CongVanDiController : Controller
    {
        private dbDangBo _db = new dbDangBo();
        // GET: CongVanDi
        public async Task<ActionResult> Index()
        {
            return View(await _db.CongVanDis.OrderBy(item => item.ID).ToListAsync());
        }
    }
}