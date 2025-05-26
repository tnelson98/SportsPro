using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private ManagerContext context {  get; set; }

        public TechnicianController(ManagerContext ctx)
        {
            context = ctx;
        }

        [Route("Technicians")]
        public IActionResult List()
        {
            ViewBag.Name = "Technician Manager";
            var technicians = context.Technicians.ToList();
            return View(technicians);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new TechnicianModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Technicians.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(TechnicianModel technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.Id == 0)
                    context.Technicians.Add(technician);
                else
                    context.Technicians.Update(technician);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = (technician.Id == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Technicians.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(TechnicianModel technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
