using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechIncidentController : Controller
    {
        private ManagerContext context {  get; set; }

        public TechIncidentController(ManagerContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult Select()
        {
            TechIncidentViewModel model = new TechIncidentViewModel();
            model.Technicians = context.Technicians.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Select(int id)
        {
            HttpContext.Session.SetInt32("id", id);
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            TechIncidentListViewModel model = new TechIncidentListViewModel();
            int? TechId = HttpContext.Session.GetInt32("id");
            model.Technician = context.Technicians.Find(TechId);

            IQueryable<IncidentModel> query = context.Incidents.OrderBy(q => q.Id);
            query = query.Where(q => q.Technician == model.Technician.Name);
            query = query.Where(q => q.CloseDate == null);
            model.Incidents = query.ToList();

            if(model.Incidents.Count == 0)
            {
                TempData["message"] = "Technician does not have any open incidents.";
                return RedirectToAction("Select");
            }
            else
                return View(model);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            // Identical to an IncidentModel, except only the description is required,
            // as only it and the close date (still optional) can be edited
            TechIncidentEditViewModel model = new TechIncidentEditViewModel();
            var incident = context.Incidents.Find(id);

            // Set the new model equal to the IncidentModel that is being edited
            model.Technician = incident.Technician;
            model.Product = incident.Product;
            model.Customer = incident.Customer;
            model.Title = incident.Title;
            model.OpenDate = incident.OpenDate;
            model.Description = incident.Description;
            model.CloseDate = incident.CloseDate;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TechIncidentEditViewModel incident)
        {
            if(ModelState.IsValid)
            {
                // Update the correct IncidentModel with the new description
                // and close date, then save the changes
                IncidentModel model = context.Incidents.Find(incident.Id);
                model.Description = incident.Description;
                model.CloseDate = incident.CloseDate;
                context.Update(model);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return View(incident);
            }
        }
    }
}