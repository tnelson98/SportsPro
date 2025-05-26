using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private ManagerContext context {  get; set; }

        public IncidentController(ManagerContext ctx) 
        { 
            context = ctx;
        }

        [Route("Incidents")]
        public IActionResult List(string Filter)
        {
            ViewBag.Name = "Incident Manager";
            IncidentViewModel model = new IncidentViewModel();

            IQueryable<IncidentModel> query = context.Incidents.OrderBy(q => q.Id);
            if(Filter == "unassigned")
            {
                model.Filter = "unassigned";
                query = query.Where(q => q.Technician == null);
            }
            else if(Filter == "open")
            {
                model.Filter = "open";
                query = query.Where(q => q.CloseDate == null);
            }
            model.Incidents = query.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            IncidentEditViewModel model = new IncidentEditViewModel();
            model.Customers = context.Customers.ToList();
            model.Products = context.Products.ToList();
            model.Technicians = context.Technicians.ToList();
            model.Operation = "Add";
            return View("Edit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            IncidentEditViewModel model = new IncidentEditViewModel();
            model.Customers = context.Customers.ToList();
            model.Products = context.Products.ToList();
            model.Technicians = context.Technicians.ToList();
            model.CurrentInc = context.Incidents.Find(id);
            model.Operation = "Edit";
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(IncidentEditViewModel incident)
        {
            if(ModelState.IsValid)
            {
                if(incident.CurrentInc.Id == 0)
                    context.Incidents.Add(incident.CurrentInc);
                else
                    context.Incidents.Update(incident.CurrentInc);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                incident.Operation = (incident.CurrentInc.Id == 0) ? "Add" : "Edit";
                incident.Products = context.Products.ToList();
                incident.Technicians = context.Technicians.ToList();
                incident.Customers = context.Customers.ToList();
                return View(incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(IncidentModel incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
