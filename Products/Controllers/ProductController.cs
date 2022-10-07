using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Products.Models;

namespace Products.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
       public static List<Product> prod = new List<Product>();
        static ProductController()
        {
            prod.Add(new Product { prodId = 1, productname = "Masala", quantity = 2, Mfgdate =new DateTime(2015, 2, 3) });
            prod.Add(new Product { prodId = 2, productname = "Soaps", quantity = 2, Mfgdate = new DateTime(2017, 2, 3) });
            prod.Add(new Product { prodId = 3, productname = "Shampoo", quantity = 2, Mfgdate = new DateTime(2019, 2, 3) });

        }
        public ActionResult Index()
        {
            return View(prod);
        }
      
        public ActionResult SearchProduct()
        {
            return View();

        }
        [HttpPost]
       public ActionResult SearchProduct(string i)
        {
            prod = prod.Where(p => p.productname == i).ToList();
            return View(prod);
        }
       
        public ActionResult Addfordetails(int id)
        {
            Product gh = prod.Find(p=>p.prodId==id);
            return RedirectToAction("EditDetails",new { id = gh.prodId });
        }
        public ActionResult EditDetails(int id)
        {
            Product gh=prod.Find(p=>p.prodId==id);

            return View(gh);
        }
        [HttpPost]
        public ActionResult EditDetails(int id,Product n1)
        {
            Product gh = prod.Find(p => p.prodId == id);
            prod.Remove(gh);
            prod.Add(n1);
            return RedirectToAction("Index");
        }
        public ActionResult Showdetails(int id)
        {
            Product gh = prod.Find(p => p.prodId == id);
            return View(gh);
        }
        public ActionResult Deletedetails(int id)
        {
            Product gh = prod.Find(p => p.prodId == id);
            prod.Remove(gh);
            return RedirectToAction("Index");
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            prod.Add(p);
            return RedirectToAction("Index");
        }
        
       
    }
}