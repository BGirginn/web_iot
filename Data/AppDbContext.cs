using Microsoft.EntityFrameworkCore;
using Web_IoT.Models;

namespace Web_IoT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
    }
}
