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

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            var tab = db.Tab_Categoria.OrderBy(s => s.idcategoria).AsQueryable();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Index_SubCat
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index_SubCat(int id, int? page)
        {
            var tab = db.Tab_Subcategoria.Where(s => s.idcategoria == id).OrderBy(s => s.idsubcategoria).AsQueryable();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Index_Campo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idCategoria"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index_Campo(int id, int idCategoria, int? page)
        {
            var tab = db.Tab_Campo.Where(s => s.idsubcategoria == id).OrderBy(s => s.ordem).AsQueryable();

            ViewBag.IdCategoria = idCategoria;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tab.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Categoria
        /// </summary>
        /// <param name="slugcategoria"></param>
        /// <returns></returns>
        public ActionResult Categoria(String slugcategoria)
        {
            var tab = db.Tab_Categoria.Where(s => s.slug == slugcategoria)
                                                        .OrderBy(s => s.idcategoria).AsQueryable();

            int? page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View("Index", tab.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// SubCategoria
        /// </summary>
        /// <param name="slugcategoria"></param>
        /// <param name="slugsubcategoria"></param>
        /// <returns></returns>
        public ActionResult SubCategoria(String slugcategoria, String slugsubcategoria)
        {
            var tab = db.Tab_Subcategoria.Where(s => s.Tab_Categoria.slug == slugcategoria
                                                        && s.slug == slugsubcategoria)
                                                        .OrderBy(s => s.Tab_Categoria.idcategoria)
                                                        .OrderBy(s => s.idsubcategoria).AsQueryable();

            if (tab != null)
                ViewBag.IdCategoria = tab.Select(s => s.Tab_Categoria.idcategoria).FirstOrDefault();

            int? page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View("Index_SubCat", tab.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Campo
        /// </summary>
        /// <param name="slugcategoria"></param>
        /// <param name="slugsubcategoria"></param>
        /// <param name="desccampo"></param>
        /// <returns></returns>
        public ActionResult Campo(String slugcategoria, String slugsubcategoria, String desccampo)
        {
            var tab = db.Tab_Campo.Where(s => s.descricao == desccampo
                                            && s.Tab_Subcategoria.Tab_Categoria.slug == slugcategoria
                                            && s.Tab_Subcategoria.slug == slugsubcategoria)
                                            .OrderBy(s => s.ordem)
                                            .OrderBy(s => s.Tab_Subcategoria.Tab_Categoria.idcategoria)
                                            .OrderBy(s => s.Tab_Subcategoria.idsubcategoria).AsQueryable();

            if (tab != null)
                ViewBag.IdCategoria = tab.Select(s => s.Tab_Subcategoria.Tab_Categoria.idcategoria).FirstOrDefault();

            int? page = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View("Index_Campo", tab.ToPagedList(pageNumber, pageSize));
        }

    }
}
