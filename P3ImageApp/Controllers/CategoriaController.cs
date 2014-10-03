using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P3ImageApp.Models;
using PagedList;

namespace P3ImageApp.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private BD_P3IMAGEContext db = new BD_P3IMAGEContext();

        //
        // GET: /Categoria/

        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult Busca(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Código" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var tab = db.Tab_Categoria.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                tab = tab.Where(s => s.descricao.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Descrição":
                    tab = tab.OrderBy(s => s.descricao);
                    break;
                case "Slug":
                    tab = tab.OrderBy(s => s.slug);
                    break;
                default:
                    tab = tab.OrderBy(s => s.idcategoria);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return PartialView("IndexGrid", tab.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Código" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var tab = db.Tab_Categoria.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                tab = tab.Where(s => s.descricao.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Descrição":
                    tab = tab.OrderBy(s => s.descricao);
                    break;
                case "Slug":
                    tab = tab.OrderBy(s => s.slug);
                    break;
                default:
                    tab = tab.OrderBy(s => s.idcategoria);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Categoria/Details/5

        public ActionResult Details(int id = 0)
        {
            Tab_Categoria tab_categoria = db.Tab_Categoria.Find(id);
            if (tab_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tab_categoria);
        }

        //
        // GET: /Categoria/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categoria/Create

        [HttpPost]
        public ActionResult Create(Tab_Categoria tab_categoria)
        {
            if (ModelState.IsValid)
            {
                db.Tab_Categoria.Add(tab_categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tab_categoria);
        }

        //
        // GET: /Categoria/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tab_Categoria tab_categoria = db.Tab_Categoria.Find(id);
            if (tab_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tab_categoria);
        }

        //
        // POST: /Categoria/Edit/5

        [HttpPost]
        public ActionResult Edit(Tab_Categoria tab_categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tab_categoria);
        }

        //
        // GET: /Categoria/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tab_Categoria tab_categoria = db.Tab_Categoria.Find(id);
            if (tab_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tab_categoria);
        }

        //
        // POST: /Categoria/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tab_Categoria tab_categoria = db.Tab_Categoria.Find(id);
            db.Tab_Categoria.Remove(tab_categoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}