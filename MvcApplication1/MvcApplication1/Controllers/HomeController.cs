using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        FridayShoppingCartEntities db = new FridayShoppingCartEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Search(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                word = word.ToLower();

                var products = db.Products.Where(w => w.Name.ToLower().Contains(word));

                return PartialView(products);
            }
            else
            {
                var products = db.Products.ToList();

                return PartialView(products);
            }
             
        }
    }
}
