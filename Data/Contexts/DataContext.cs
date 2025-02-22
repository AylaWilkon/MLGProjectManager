using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
    //Används för att hantera kund- och projektdata i en databas via Entity Framework Core.
{
    public class DataContext : DbContext
    {        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
    }
}
