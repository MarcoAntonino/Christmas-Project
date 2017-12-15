using Antonino.Classes;
using Antonino.Infrastructure.Abstract;
using Antonino.Models;
using System.Web.Mvc;

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
                User loggedUser = authProvider.Authenticate(model.Email, model.Password);
                if (loggedUser != null)
                {
                    Session["ScreenName"] = loggedUser.ScreenName;
                    Session["isAdmin"] = loggedUser.IsAdmin;
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
        public ActionResult Logout(string returnUrl)
        {
            Session.Clear();
            authProvider.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}