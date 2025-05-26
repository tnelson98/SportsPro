using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private ManagerContext context {  get; set; }

        public CustomerController(ManagerContext ctx)
        {
            context = ctx;
        }

        [Route("Customers")]
        public IActionResult List()
        {
            ViewBag.Name = "Customer Manager";
            var customers = context.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.ToList();
            return View("Edit", new CustomerModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.ToList();
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(CustomerModel customer)
        {
            // Validation for unique email
            if(!string.IsNullOrEmpty(customer.Email))
            {
                string msg = string.Empty;
                var compare = context.Customers.FirstOrDefault(c => c.Email.ToLower() == customer.Email.ToLower());
                if (compare != null)
                    msg = "Email address already in use.";

                if (!string.IsNullOrEmpty(msg))
                    ModelState.AddModelError(nameof(CustomerModel.Email), msg);
            }

            if (ModelState.IsValid)
            {
                if (customer.CustomerModelId == 0)
                    context.Customers.Add(customer);
                else
                    context.Customers.Update(customer);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = (customer.CustomerModelId == 0) ? "Add" : "Edit";
                ViewBag.Countries = context.Countries.ToList();
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(CustomerModel customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
