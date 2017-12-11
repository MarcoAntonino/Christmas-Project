using Antonino.Classes;
using Antonino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antonino.Controllers
{
    public class ProductsController : Controller
    {
        private IDataBase db;

        public ProductsController(IDataBase dbParam)
        {
            db = dbParam;
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = db.GetAllProducts();
            Products model = new Products();
            model.EntityList = products.ToList();
            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            var product = db.GetProduct(id);
            Product model = new Product();
            model.ID = product.ID;
            model.Name = product.Name;
            model.Category = product.Category;
            return View(model);
        }

        // GET: Product/Create
        public ActionResult Add()
        {
            var products = db.GetAllProducts();
            Products model = new Products();
            model.EntityList = products.ToList();
            ViewBag.products = model;
            return View();
        }

        
        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            var product = db.GetProduct(id);
            Product model = new Product();
            model.ID = product.ID;
            model.Name = product.Name;
            model.Category = product.Category;
            return View(model);
        }       

        // GET: Product/Delete/5
        public ActionResult Delete(string id, string name)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                throw new MissingFieldException("invalid parameters");
            }
            bool result = db.RemoveProduct(id);
            return RedirectToAction("Index", new { result = result });
        }
        
        public ActionResult Save(string name, string id, string category)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new MissingFieldException("name cannot be null");
            }
            bool result;
            if (string.IsNullOrWhiteSpace(id))
            {
                Product product = db.GetProduct(id);
                if (product != null)
                {
                    throw new Exception($"Product {name} already exists");
                }
                result = db.InsertProduct(new Product { Name = name, Category = category });
                return RedirectToAction("Index", new { result = result });
            }
            result = db.UpdateProduct(new Product
            {
                ID = id,
                Name = name,
                Category = category
            });
            return RedirectToAction("Index", new { result = result });
        }
    }
}
