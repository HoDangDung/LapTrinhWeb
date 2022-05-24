using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab01.Models;

namespace Lab01.Controllers
{
    public class TheloaitinController : Controller
    {
        // GET: Theloaitin
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            var All_Loaitin = from tt in data.Theloaitins select tt;
            return View();
        }
    }
}