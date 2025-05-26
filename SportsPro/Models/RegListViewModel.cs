namespace SportsPro.Models
{
    public class RegListViewModel
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        // Need a whole list of customers to query for them with their products attatched?
        // Can't find any other solution at least, so this should always be a single Customer in the list
        public List<CustomerModel> Customer { get; set; } = new List<CustomerModel>();

        public List<ProductModel> AllProducts { get; set; } = new List<ProductModel>();
    }
}
