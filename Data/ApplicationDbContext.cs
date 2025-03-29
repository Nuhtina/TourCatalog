using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TourCatalog.Models;

namespace TourCatalog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Town> Town { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<TripCatalog> TripCatalog { get; set; }
        public DbSet<TourCatalog.Models.Type_tour> Type_tour { get; set; } = default!;
    }
}
