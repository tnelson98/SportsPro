using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class IncidentEditViewModel
    {
        public string Operation {  get; set; } = string.Empty;

        public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public List<TechnicianModel> Technicians { get; set;} = new List<TechnicianModel>();

        [Required]
        public IncidentModel CurrentInc {  get; set; } = new IncidentModel();
    }
}
