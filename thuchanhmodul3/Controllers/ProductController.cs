using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thuchanhmodul3.Models;
using thuchanhmodul3.Storage;

namespace thuchanhmodul3.Controllers
{
    public class ProductController : Controller
    {

        

        public static List<Product> products { get; } = new List<Product>
        {
                new Product(1, "iphone1", 1f),
                new Product(2, "iphone2", 2f),
                new Product(3, "iphone3", 3f),
                new Product(4, "iphone4", 4f),
        };

        FileProduct fileProduct = new FileProduct();
       

        public ActionResult Edit(int id)
        {
            Product editProduct = new Product();
            foreach (var p in products)
            {
                if (p.Id == id)
                {
                    editProduct = p;
                }
            }
            return View(editProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            foreach (var p in products)
            {
                if (p.Id == product.Id)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                }
            }
            return RedirectToAction("List", "Product");
        }

        public ActionResult Create()
        {
            return View();   
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            products.Add(product);
            return RedirectToAction("List", "Product");
        }

        public ActionResult Delete(int id)
        {
            Product pdel = new Product();
            foreach (var p in products)
            {
                if (id == p.Id)
                {
                    pdel = p;
                }
            }
            products.Remove(pdel);
            ViewBag.products = products;
            return RedirectToAction("List","Product");
        }
        public ActionResult Detail(int id)
        {
            Product pDetial = new Product();
            foreach (var p in products)
            {
                if (id == p.Id)
                {
                    pDetial = p;
                }
            }

            return View(pDetial);
        }

        // GET: Product
        public ActionResult List()
        {
            var userLogined = Session["USER"];
            if (userLogined != null)
            {
                ViewBag.userLogined = userLogined;
               
                ViewBag.products = products;

                fileProduct.Write(products);
                fileProduct.Read();

                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}