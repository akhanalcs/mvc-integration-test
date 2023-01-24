using Microsoft.EntityFrameworkCore;
using MyCoolApp.Models.Entities;

namespace MyCoolApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
