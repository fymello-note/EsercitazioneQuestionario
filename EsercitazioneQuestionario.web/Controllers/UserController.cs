using EsercitazioneQuestionario.web.Models.User;
using EsercitazioneQuestionario.web.Services;
using EsercitazioneQuestionario.web.Services.Constracts;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EsercitazioneQuestionario.web.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService userService;

        public UserController()
        {

            userService = new UserService();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Register(UserCreationModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await userService.CreateUser(user);

                    FormsAuthentication.SetAuthCookie(user.UserName, false);

                    return RedirectToAction("Index", "Home");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("UserName", "Questio username è già in uso");
                }

            }
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel user)
        {

            if (ModelState.IsValid)
            {
                if (await userService.CheckUserPassword(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Password", "Credenziali non valide");
            }

            return View(user);
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