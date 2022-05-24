using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Lab01.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWord/
        //public String Index()
        //{
        //    return "This is my <b> default </b> action...<br>Hồ Đăng Dũng";
        //}

        //// GET: /HelloWord/Wellcome
        //public String Wellcome()
        //{
        //    return "this is the wellcome to action method...<br>Hồ Đăng Dũng";
        //}

        // GET: /HelloWord/Wellcome?name=HoDangDung&numtimes=2389
        //public String Wellcome(String name, int numtimes)
        //{
        //    return HttpUtility.HtmlEncode("Hello " + name + " numtimes " + numtimes);
        //}

        // GET: /HelloWord/Wellcome?name=HoDangDung
        /*public String Wellcome(String name, int id = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", ID: " + id);
        }*/

        // GET: /HelloWord/Wellcome/3?name=HoDangDung
        //public string Wellcome(String name, int id)
        //{
        //    return HttpUtility.HtmlEncode("Hello " + name + ", ID: " + id);
        //}

        public ActionResult Index()
        {
            return View();
        }
    }
}