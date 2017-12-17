using Antonino.Classes;
using Antonino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antonino.Controllers
{
    [Authorize]
    public class ToysController : Controller
    {

        private IDataBase db;

        public ToysController(IDataBase dbArg)
        {
            db = dbArg ?? throw new ArgumentNullException();
        }
        // GET: Toy
        public ActionResult Index()
        {
            var toys = db.GetAllToys();
            Toys model = new Toys();
            model.EntityList.AddRange(toys.ToList());
            return View(model);
        }
    }
}