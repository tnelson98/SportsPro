using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class ProductModel
    {
        public ProductModel() 
        {
            Customers = new HashSet<CustomerModel>();
        }

        [ForeignKey("ProductModelId")]
        public ICollection<CustomerModel> Customers { get; set; }

        public int ProductModelId { get; set; }

        [Required(ErrorMessage = "Please enter a product code.")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a price.")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Please enter a date.")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        //public DateTime Date { get; set; }
        public string Date { get; set; } = string.Empty;
    }
}
