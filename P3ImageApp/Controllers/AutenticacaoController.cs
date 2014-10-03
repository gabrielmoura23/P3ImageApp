using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace P3ImageApp.Controllers
{
    public class AutenticacaoController : Controller
    {
        //
        // GET: /Autenticacao/

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(FormCollection form)
        {
            if (!String.IsNullOrEmpty(form["userName"]) && !String.IsNullOrEmpty(form["pwd"]))
            {
                if (form["userName"].ToUpper().Equals("ADMIN") && form["pwd"].Equals("admin"))
                {
                    Session["CurrentUser"] = "ADMIN";
                    Session["nomeUsuarioLogado"] = "Gabriel Moura";

                    FormsAuthentication.SetAuthCookie("admin", false);

                    return RedirectToAction("Index", "Interno");
                }

                //usuário e/ou senha inválidos
                TempData["Message"] = "Usuário e/ou senha inválido(s).";
                return View(TempData["Message"]);
            }
            else
            {
                TempData["Message"] = "Preencha com um usuário e senha.";
                return View(TempData["Message"]);
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

    }
}
