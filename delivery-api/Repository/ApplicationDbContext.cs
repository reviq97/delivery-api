using delivery_api.Enitty;
using Microsoft.EntityFrameworkCore;

namespace delivery_api.Repository
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        

        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Person> Persons { get; set; }


    }
}