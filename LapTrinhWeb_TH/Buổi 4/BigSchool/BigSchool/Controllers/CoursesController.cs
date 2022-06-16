using BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Create()
        {
            BigSchoolContent content = new BigSchoolContent();
            Course objCourse = new Course();
            objCourse.ListCatergory = content.Category.ToList();
            return View(objCourse);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course objCourse)
        {
            BigSchoolContent content = new BigSchoolContent();

            //Không xét vaild LectureId vì bằng user đăng nhập
            ModelState.Remove("LecturerId");
            if (!ModelState.IsValid)
            {
                objCourse.ListCatergory = content.Category.ToList();
                return View("Create", objCourse);
            }

            //lấy Login User ID
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objCourse.LecturerId = user.Id;

            //add vào CSDL
            content.Course.Add(objCourse);
            content.SaveChanges();

            //Trở về Home, Action Index
            return RedirectToAction("Index", "Home");
        }
    }
}