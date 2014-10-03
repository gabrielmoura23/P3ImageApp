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
    public class CampoController : Controller
    {
        private BD_P3IMAGEContext db = new BD_P3IMAGEContext();

        //
        // GET: /Campo/

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
            var tab = db.Tab_Campo.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                tab = tab.Where(s => s.descricao.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Descrição":
                    tab = tab.OrderBy(s => s.descricao);
                    break;
                case "Tipo":
                    tab = tab.OrderBy(s => s.tipo);
                    break;
                default:
                    tab = tab.OrderBy(s => s.idcampo);
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
            var tab = db.Tab_Campo.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                tab = tab.Where(s => s.descricao.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Descrição":
                    tab = tab.OrderBy(s => s.descricao);
                    break;
                case "Tipo":
                    tab = tab.OrderBy(s => s.tipo);
                    break;
                default:
                    tab = tab.OrderBy(s => s.idcampo);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Campo/Details/5

        public ActionResult Details(int id = 0)
        {
            Tab_Campo tab_campo = db.Tab_Campo.Find(id);
            if (tab_campo == null)
            {
                return HttpNotFound();
            }
            return View(tab_campo);
        }

        //
        // GET: /Campo/Create

        public ActionResult Create()
        {
            ViewBag.idsubcategoria = new SelectList(db.Tab_Subcategoria, "idsubcategoria", "descricao");
            return View();
        }

        //
        // POST: /Campo/Create

        [HttpPost]
        public ActionResult Create(Tab_Campo tab_campo)
        {
            if (ModelState.IsValid)
            {
                db.Tab_Campo.Add(tab_campo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idsubcategoria = new SelectList(db.Tab_Subcategoria, "idsubcategoria", "descricao", tab_campo.idsubcategoria);
            return View(tab_campo);
        }

        //
        // GET: /Campo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tab_Campo tab_campo = db.Tab_Campo.Find(id);
            if (tab_campo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsubcategoria = new SelectList(db.Tab_Subcategoria, "idsubcategoria", "descricao", tab_campo.idsubcategoria);
            return View(tab_campo);
        }

        //
        // POST: /Campo/Edit/5

        [HttpPost]
        public ActionResult Edit(Tab_Campo tab_campo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_campo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idsubcategoria = new SelectList(db.Tab_Subcategoria, "idsubcategoria", "descricao", tab_campo.idsubcategoria);
            return View(tab_campo);
        }

        //
        // GET: /Campo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tab_Campo tab_campo = db.Tab_Campo.Find(id);
            if (tab_campo == null)
            {
                return HttpNotFound();
            }
            return View(tab_campo);
        }

        //
        // POST: /Campo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tab_Campo tab_campo = db.Tab_Campo.Find(id);
            db.Tab_Campo.Remove(tab_campo);
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