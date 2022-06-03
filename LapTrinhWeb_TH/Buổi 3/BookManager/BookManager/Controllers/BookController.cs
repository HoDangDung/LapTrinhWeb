using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Book.ToList();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int? id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            BookManagerContext context = new BookManagerContext();
            var book = context.Book.FirstOrDefault(s => s.ID == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book rb)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BookManagerContext context = new BookManagerContext();
                    Book dbUpdate = context.Book.FirstOrDefault(p => p.ID == rb.ID);
                    if (dbUpdate != null)
                    {
                        context.Book.AddOrUpdate(rb);
                        context.SaveChanges();
                    }
                    return RedirectToAction("ListBook");
                }
                catch (Exception)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ModelState.AddModelError("", "input Model not Valid");
                return View(rb);
            }
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            BookManagerContext context = new BookManagerContext();
            context.Book.AddOrUpdate(b);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }

        //Delete
        public ActionResult Delete(Book b)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == b.ID);
            if (b != null)
            {
                context.Book.Remove(book);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }

        //Detail
        public ActionResult Details(int? id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
    }
}