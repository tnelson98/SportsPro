using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class TechIncidentEditViewModel
    {
        public int Id { get; set; }

        public string Customer { get; set; } = string.Empty;

        public string Product { get; set; } = string.Empty;

        public string Technician { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "A description is required.")]
        public string Description { get; set; } = string.Empty;

        public DateTime OpenDate { get; set; }

        public DateTime? CloseDate { get; set; }
    }
}
