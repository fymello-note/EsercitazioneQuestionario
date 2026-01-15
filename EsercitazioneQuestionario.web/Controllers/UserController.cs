using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EsercitazioneQuestionario.web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            FormsAuthentication.SetAuthCookie("johnny", false);

            return RedirectToAction(nameof(User));
        }

        [HttpPost]
        public ActionResult Login(UserController lsakjfd)
        {
            FormsAuthentication.SetAuthCookie("johnny", false);

            return RedirectToAction(nameof(User));
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public void UserProfile()
        {
            Response.Write(User.Identity.Name);
        }
    }
}