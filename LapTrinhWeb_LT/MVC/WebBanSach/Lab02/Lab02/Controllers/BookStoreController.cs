using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class BookStoreController : Controller
    {
        // GET: BookStore
        public ActionResult Index()
        {
            return View();
        }
    }
}