using Antonino.Classes;
using Antonino.Infrastructure.Abstract;
using Antonino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Antonino.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        private IDataBase db;

        public AccountController(IAuthProvider auth, IDataBase dbParam)
       {
           authProvider = auth;
           db = dbParam;
       }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login (LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Email, model.Password) != null)
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect email or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}