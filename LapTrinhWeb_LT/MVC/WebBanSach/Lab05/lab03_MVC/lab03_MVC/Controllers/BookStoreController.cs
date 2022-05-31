using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab03_MVC.Models;

namespace lab03_MVC.Controllers
{
    public class BookStoreController : Controller
    {
        DataClassesDataContext data = new DataClassesDataContext();
        private List<SACH> Laysachmoi(int count)
        {
            return data.SACHes.OrderByDescending(a=>a.Ngaycapnhat).Take(count).ToList();
        }
        // GET: BookStore
        public ActionResult Index()
        {
            var sachmoi = Laysachmoi(5);
            return View(sachmoi);
        }
        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult Nhaxuatban()
        {
            var chude = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(chude);
        }
        public ActionResult SPTheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }
        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes
                       where s.Masach == id
                       select s;
            return View(sach.Single());
        }
    }
}