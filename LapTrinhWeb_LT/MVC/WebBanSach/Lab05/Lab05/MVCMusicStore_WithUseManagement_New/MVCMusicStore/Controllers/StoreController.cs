using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore.Models;

namespace MVCMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreDB db =new MusicStoreDB();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var model = db.Genres;
            return View(model);
        }
        public ActionResult Browse(string genre)
        {
            var model = db.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = db.Albums.Single(a => a.AlbumID == id);
            return View(model);
        }
	}
}