using GlobalErrorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalErrorApp
{
    public class applicationDbContext:DbContext
    {
        public applicationDbContext(DbContextOptions<applicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Driver> Drivers { get; set; }
    }
}
