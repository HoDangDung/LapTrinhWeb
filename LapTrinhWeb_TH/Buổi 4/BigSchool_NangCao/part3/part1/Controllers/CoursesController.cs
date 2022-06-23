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
    public class CoursesController : Controller
    {

        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            BigSchoolContext context = new BigSchoolContext();
            Course objCourse = new Course();
            objCourse.listCategory = context.Categories.ToList();
            return View(objCourse);
        }
        [Authorize]
        [HttpPost]

        public ActionResult Create(Course objCourse)
        {
            BigSchoolContext context = new BigSchoolContext();

            ModelState.Remove("LecturerId");
            if(!ModelState.IsValid)
            {
                objCourse.listCategory = context.Categories.ToList();
                return View("Create", objCourse);
            }    

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objCourse.LecturerId = user.Id;

            context.Courses.Add(objCourse);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Attending()
        {
            BigSchoolContext context = new BigSchoolContext();
            var userID = User.Identity.GetUserId(); //get login user
            //lấy danh sách khóa học mà userlogin đó tham dự (ở đây mới chỉ lấy được id)
            var listAttdances = context.Attendances.Where(p => p.Attendee == userID).ToList();
            var courses = new List<Course>();
            //Tìm chi tiết khóa học từ listAttendances (mã khóa học, tên GV phải truy cập từ AspnetUser.Name)
            foreach(Attendance temp in listAttdances)
            {
                Course objCourse = temp.Course;
                objCourse.Name = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(objCourse.LecturerId).Name;
                courses.Add(objCourse);
            }
            return View(courses);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var loginUser = User.Identity.GetUserId(); //get login user
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(loginUser);
            BigSchoolContext context = new BigSchoolContext();
            var courses = context.Courses.Where(c => c.LecturerId == loginUser && c.IsCanceled != true).ToList();
            foreach(Course i in courses)
            {
                i.Name = user.Name; //lấy thông tin Nam từ AspNetUsers
            }
            return View(courses);
        }


        public ActionResult Delete(int id)
        {
            BigSchoolContext context = new BigSchoolContext();
            var userID = User.Identity.GetUserId(); //get login user
            var findCourse = context.Courses.FirstOrDefault(p => p.Id == id);
            findCourse.IsCanceled = true;
            context.SaveChanges();
            return RedirectToAction("Mine");
        }


        [Authorize]
        public ActionResult Edit(int id)
        {
            BigSchoolContext context = new BigSchoolContext();
            var loginUser = User.Identity.GetUserId(); // get login user
            var course = context.Courses.FirstOrDefault(c => c.LecturerId == loginUser && c.Id == id);
            if(course == null)
            {
                return HttpNotFound("Không tìm thấy khóa học");
            }
            course.listCategory = context.Categories.ToList(); //lấy danh sách loại khóa học
            return View("Create", course);
        }
    }
}