using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using part1.Models;

namespace part1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            BigSchoolContext context = new BigSchoolContext();
            var upcommingCourse = context.Courses.Where(p => p.DateTime >
            DateTime.Now).OrderBy(p => p.DateTime).ToList();
            //Lấy user login hiện tại đưa vào ViewBag -> để truyền qua view
            //Nếu giá trị = null -> nghĩa là chưa đăng nhập
            var loginUser = User.Identity.GetUserId();
            ViewBag.LoginUser = User.Identity.GetUserId();
            foreach (Course i in upcommingCourse)
            {
                ApplicationUser user =
                System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(i.LecturerId);
                i.Name = user.Name;
                //Ktra user do chua tham gia khoa hoc
                Attendance find = context.Attendances.FirstOrDefault(p => p.CourseId == i.Id && p.Attendee == loginUser);
                if(find == null)
                {
                    i.isShowGoing = true;
                }
            }
            return View(upcommingCourse);
            
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