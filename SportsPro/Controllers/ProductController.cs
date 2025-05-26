using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private ManagerContext context {  get; set; }

        public ProductController(ManagerContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        [Route("Products")]
        public ViewResult List()
        {
            ViewBag.Name = "Product Manager";
            var products = context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new ProductModel());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductModelId == 0)
                {
                    TempData["message"] = $"{product.Name} has been added.";
                    context.Products.Add(product);
                }
                else
                {
                    TempData["message"] = $"{product.Name} has been updated.";
                    context.Products.Update(product);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = (product.ProductModelId == 0) ? "Add" : "Edit";
                return View(product);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Delete(ProductModel product)
        {
            TempData["message"] = $"{product.Name} has been deleted.";
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
