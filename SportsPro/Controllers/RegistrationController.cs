using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class RegistrationController : Controller
    {
        private ManagerContext context {  get; set; }

        public RegistrationController(ManagerContext ctx)
        {
            context = ctx;
        }

        public ViewResult Select()
        {
            ViewBag.Customers = context.Customers.OrderBy(c => c.CustomerModelId).ToList();
            return View();
        }

        [Route("registrations")]
        public ViewResult List(int CustomerModelId)
        {
            if(CustomerModelId != 0)
            {
                HttpContext.Session.SetInt32("CurrentCustomer", CustomerModelId);
            }
            int? customerId = HttpContext.Session.GetInt32("CurrentCustomer");
            var model = new RegListViewModel();
            model.AllProducts = context.Products.ToList();
            model.Customer = context.Customers.Include("Products").Where(c => c.CustomerModelId == customerId).ToList();
            return View(model);
        }

        [Route("registrations/register")]
        [HttpPost]
        public IActionResult Register(int productId)
        {
            int? customerId = HttpContext.Session.GetInt32("CurrentCustomer");
            CustomerModel customer = context.Customers.Find(customerId);
            ProductModel product = context.Products.Find(productId);

            var customerProducts = context.Customers.Include(c => c.Products);
            foreach(CustomerModel c in customerProducts)
            {
                if(c.CustomerModelId == customerId)
                {
                    if(customer.Products.Where(c => c.ProductModelId == productId).Contains(product))
                    {
                        TempData["message"] = "This product is already registered to this customer.";
                        return RedirectToAction("List");
                    }
                    else
                    {
                        if(product != null)
                        {
                            customer.Products.Add(product);
                        }                     
                    }
                }
            }
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            int? customerId = HttpContext.Session.GetInt32("CurrentCustomer");
            CustomerModel customer = context.Customers.Find(customerId);
            ProductModel product = context.Products.Find(id);

            var customerProducts = context.Customers.Include(c => c.Products);
            foreach(CustomerModel c in customerProducts)
            {
                if(c.CustomerModelId == customerId && c.Products.Contains(product))
                {
                    if(product != null)
                    {
                        c.Products.Remove(product);
                    }
                }
            }
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
