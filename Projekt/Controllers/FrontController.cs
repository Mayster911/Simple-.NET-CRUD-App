using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projekt.ViewModels;
using Projekt.BL;

namespace Projekt.Controllers
{
    public class FrontController : Controller
    {
        // GET: Front
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CredentialError", errorMessage: "Wrong username or password");
                return View(vm);
            }

            UserBL userBL = new UserBL();

            if (userBL.isUniqueName(vm.UserName))
                userBL.AddUser(vm);
            else
            {
                ModelState.AddModelError("CredentialError",errorMessage: "Username is taken, choose another");
                return View(vm);
            }

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CredentialError", errorMessage: "Wrong username or password");
                return View(vm);
            }

            UserBL userBL = new UserBL();

            if (userBL.isValidUser(vm.UserName, vm.Password))
            {
                FormsAuthentication.SetAuthCookie(vm.UserName, false);
                Session["LoggedUser"] = vm.UserName;
            }
            else
            {
                ModelState.AddModelError("CredentialError", errorMessage: "Wrong username or password");
                return View(vm);
            }
            
            return RedirectToAction("List","List");
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["LoggedUser"] = null;
            return RedirectToAction("Index", "Front");
        }
    }
}