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
    public class SubCategoriaController : Controller
    {
        private BD_P3IMAGEContext db = new BD_P3IMAGEContext();

        //
        // GET: /SubCategoria/

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
            var tab = db.Tab_Subcategoria.AsQueryable();
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
                    tab = tab.OrderBy(s => s.idsubcategoria);
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
            var tab = db.Tab_Subcategoria.AsQueryable();
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
                    tab = tab.OrderBy(s => s.idsubcategoria);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /SubCategoria/Details/5

        public ActionResult Details(int id = 0)
        {
            Tab_Subcategoria tab_subcategoria = db.Tab_Subcategoria.Find(id);
            if (tab_subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(tab_subcategoria);
        }

        //
        // GET: /SubCategoria/Create

        public ActionResult Create()
        {
            ViewBag.idcategoria = new SelectList(db.Tab_Categoria, "idcategoria", "descricao");
            return View();
        }

        //
        // POST: /SubCategoria/Create

        [HttpPost]
        public ActionResult Create(Tab_Subcategoria tab_subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.Tab_Subcategoria.Add(tab_subcategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategoria = new SelectList(db.Tab_Categoria, "idcategoria", "descricao", tab_subcategoria.idcategoria);
            return View(tab_subcategoria);
        }

        //
        // GET: /SubCategoria/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tab_Subcategoria tab_subcategoria = db.Tab_Subcategoria.Find(id);
            if (tab_subcategoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategoria = new SelectList(db.Tab_Categoria, "idcategoria", "descricao", tab_subcategoria.idcategoria);
            return View(tab_subcategoria);
        }

        //
        // POST: /SubCategoria/Edit/5

        [HttpPost]
        public ActionResult Edit(Tab_Subcategoria tab_subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_subcategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategoria = new SelectList(db.Tab_Categoria, "idcategoria", "descricao", tab_subcategoria.idcategoria);
            return View(tab_subcategoria);
        }

        //
        // GET: /SubCategoria/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tab_Subcategoria tab_subcategoria = db.Tab_Subcategoria.Find(id);
            if (tab_subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(tab_subcategoria);
        }

        //
        // POST: /SubCategoria/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tab_Subcategoria tab_subcategoria = db.Tab_Subcategoria.Find(id);
            db.Tab_Subcategoria.Remove(tab_subcategoria);
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