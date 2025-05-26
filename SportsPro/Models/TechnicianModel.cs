using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class TechnicianModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide an email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
