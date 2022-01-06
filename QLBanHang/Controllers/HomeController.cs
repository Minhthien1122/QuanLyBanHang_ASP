using QLBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBanHang.Controllers
{
    public class HomeController : Controller
    {
        private QLBanHangEntities db = new QLBanHangEntities();

        // GET: SanPhams
        public ActionResult Index(int MaLoaiSP=0,string SearchString="")
        {
            if (SearchString != "")
            {
                var sanPhams = db.SanPhams.Where(x => x.TenSP.ToUpper().Contains(SearchString.ToUpper()));
                return View(sanPhams.ToList());
            }
            else if(MaLoaiSP == 0)
            {
                 var sanPhams = db.SanPhams;
                 return View(sanPhams.ToList());
            }
            else
            {
                var sanPhams = db.SanPhams.Where(x=>x.MaLoaiSP==MaLoaiSP);
                return View(sanPhams.ToList());
            }
           
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}