using Microsoft.EntityFrameworkCore;

namespace SportsPro.Models
{
    public class ManagerContext :DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; } = null!;
        public DbSet<TechnicianModel> Technicians { get; set; } = null!;
        public DbSet<CustomerModel> Customers { get; set; } = null!;
        public DbSet<CountryModel> Countries { get; set; } = null!;
        public DbSet<IncidentModel> Incidents { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial Products
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel
                {
                    ProductModelId = 1,
                    Code = "TRNY10",
                    Name = "Tournament Master 1.0",
                    Price = 4.99m,
                    Date = "12/1/2018"
                },
                new ProductModel
                {
                    ProductModelId = 2,
                    Code = "LEAG10",
                    Name = "League Scheduler 1.0",
                    Price = 4.99m,
                    Date = "5/1/2019"
                }
                );
            // Seed initial Technicians
            modelBuilder.Entity<TechnicianModel>().HasData(
                new TechnicianModel
                {
                    Id = 1,
                    Name = "Alison Diaz",
                    Email = "alison@sportsprosoftware.com",
                    PhoneNumber = "8005550443"
                },
                new TechnicianModel
                {
                    Id = 2,
                    Name = "Andrew Willson",
                    Email = "awilson@sportsprosoftware.com",
                    PhoneNumber = "8005550449"
                },
                new TechnicianModel
                {
                    Id = 3,
                    Name = "Gina Fiori",
                    Email = "gfiori@sportsprosoftware.com",
                    PhoneNumber = "8005550459"
                });
            // Seed initial Customers
            modelBuilder.Entity<CustomerModel>().HasData(
                new CustomerModel
                {
                    CustomerModelId = 1,
                    FirstName = "Ania",
                    LastName = "Irvin",
                    Address = "1234 Example Street",
                    City = "Seattle",
                    State = "Washington",
                    ZipCode = "98765",
                    Country = "United States",
                    Email = "ania@mma.nidc.com",
                    Phone = "3604582743"
                });
            // Seed the list of countries for Customers to choose from
            modelBuilder.Entity<CountryModel>().HasData(
                new CountryModel { Id = 1, Name = "United States" },
                new CountryModel { Id = 2, Name = "Canada" },
                new CountryModel { Id = 3, Name = "Mexico" }
                );
        }
    }
}
