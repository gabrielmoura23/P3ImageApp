using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P3ImageApp.Controllers
{
    public class ErroController : Controller
    {
        //
        // GET: /Erro/Error
        public ActionResult Error()
        {
            return View();
        }

        //
        // GET: /Erro/PaginaNaoEncontrada
        public ActionResult PaginaNaoEncontrada()
        {
            return View();
        }
    }
}
