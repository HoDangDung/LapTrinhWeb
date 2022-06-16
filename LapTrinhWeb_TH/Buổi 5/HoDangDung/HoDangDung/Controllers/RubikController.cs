﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoDangDung.Models;

namespace HoDangDung.Controllers
{
    public class RubikController : Controller
    {
        // GET: Rubik
        dbRubikStoreDataContext data = new dbRubikStoreDataContext();
        public ActionResult Index()
        {
            var all_rubik = from s in data.Rubiks select s;
            return View(all_rubik);
        }
    }
}