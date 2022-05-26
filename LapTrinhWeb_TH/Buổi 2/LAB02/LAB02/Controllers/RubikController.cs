using LAB02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB02.Controllers
{
    public class RubikController : Controller
    {
        private List<Rubik> listRubik;
        public RubikController()
        {
            listRubik = new List<Rubik>();
            listRubik.Add(new Rubik()
            {
                Id = 1,
                Ten = "Rubik 1",
                Loai = "3x3",
                MoTa = "Best Saler",
                Hang = "Rubik VN",
                Gia = 3000,
                Hinh = "Content/images/rubik1.jpg",
                SoLgTon = 20,
            });
            listRubik.Add(new Rubik()
            {
                Id = 2,
                Ten = "Rubik 3",
                Loai = "6x6",
                MoTa = "Best Saler",
                Hang = "Rubik UK",
                Gia = 6000,
                Hinh = "Content/images/rubik2.jpg",
                SoLgTon = 10,
            });
            listRubik.Add(new Rubik()
            {
                Id = 3,
                Ten = "Rubik 3",
                Loai = "12x12",
                MoTa = "Best Saler",
                Hang = "Rubik US",
                Gia = 12000,
                Hinh = "Content/images/rubik3.jpg",
                SoLgTon = 15,
            });
        }
        // GET: Rubik
        public ActionResult Index()
        {
            ViewBag.TitlePageName = "Rubik view page";
            return View(listRubik);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Rubik rubik = listRubik.Find(s => s.Id == id);
            if (rubik == null)
            {
                return HttpNotFound();
            }
            return View(rubik);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Rubik rubik = listRubik.Find(s => s.Id == id);
            if (rubik == null)
            {
                return HttpNotFound();
            }
            return View(rubik);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rubik rubik)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editRubik = listRubik.Find(b => b.Id == rubik.Id);
                    editRubik.Ten = rubik.Ten;
                    editRubik.Loai = rubik.Loai;
                    editRubik.MoTa = rubik.MoTa;
                    editRubik.Hang = rubik.Hang;
                    editRubik.Gia = rubik.Gia;
                    editRubik.Hinh = rubik.Hinh;
                    editRubik.SoLgTon = rubik.SoLgTon;
                    return View("Index", listRubik);
                }
                catch(Exception)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ModelState.AddModelError("", "Input Model Not Valide!");
                return View(rubik);
            }
        }

        public ActionResult Delete(int? id)
        {
            var deleteRubik = listRubik.Find(b => b.Id == id);
            listRubik.Remove(deleteRubik);
            return View("Index", listRubik);
        }
    }
}