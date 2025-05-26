using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class IncidentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A customer is required.")]
        public string Customer { get; set; } = string.Empty;

        [Required(ErrorMessage = "A product is required.")]
        public string Product { get; set; } = string.Empty;

        [Required(ErrorMessage = "A technician is required.")]
        public string Technician { get; set; } = string.Empty;

        [Required(ErrorMessage = "A title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "A description is required.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "An open date is required.")]
        public DateTime OpenDate { get; set; }

        public DateTime? CloseDate { get; set; }
    }
}
