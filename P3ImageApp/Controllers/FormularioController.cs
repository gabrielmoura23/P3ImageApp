using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P3ImageApp.Models;
using PagedList;
using System.Web.Mvc;

namespace P3ImageApp.Controllers
{
    public class FormularioController : Controller
    {
        private BD_P3IMAGEContext db = new BD_P3IMAGEContext();

        //
        // GET: /Home/

        public ActionResult Index(int? page)
        {
            var tab = db.Tab_Categoria.OrderBy(s => s.idcategoria).AsQueryable();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Index_SubCat(int id, int? page)
        {
            var tab = db.Tab_Subcategoria.Where(s => s.idcategoria == id).OrderBy(s => s.idsubcategoria).AsQueryable();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Index_Campo(int id, int idCategoria, int? page)
        {
            var tab = db.Tab_Campo.Where(s => s.idsubcategoria == id).OrderBy(s => s.ordem).AsQueryable();

            ViewBag.IdCategoria = idCategoria;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Teste(String slugcategoria, String slugsubcategoria)
        {
            var tab = db.Tab_Campo.Where(s => s.Tab_Subcategoria.Tab_Categoria.slug == slugcategoria
                                                        && s.Tab_Subcategoria.slug == slugsubcategoria)
                                                        .OrderBy(s => s.ordem).AsQueryable();

            int? page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }
    }
}
