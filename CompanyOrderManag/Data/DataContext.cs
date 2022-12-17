using CompanyOrderManag.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyOrderManag.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        // Acesess to Database Tables
        public DbSet<Company> Companies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
