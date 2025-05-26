using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class CustomerModel
    {
        public CustomerModel()
        {
            Products = new HashSet<ProductModel>();
        }

        [ForeignKey("CustomerModelId")]
        public ICollection<ProductModel> Products { get; set; }

        public int CustomerModelId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(50)]
        public string Address {  get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50)]
        public string State {  get; set; } = string.Empty;

        [Required(ErrorMessage = "ZIP code is required.")]
        [StringLength(20)]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [StringLength(50)]
        public string? Email { get; set; } = string.Empty;

        [StringLength(20)]
        [RegularExpression("^\\(?\\d{3}\\)?[-\\s]?\\d{3}-\\d{4}$", 
            ErrorMessage = "Please enter a valid phone number.")]
        public string? Phone { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
