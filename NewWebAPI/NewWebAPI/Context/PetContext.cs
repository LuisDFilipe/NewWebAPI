using Microsoft.EntityFrameworkCore;
using NewWebAPI.Entitys;

namespace NewWebAPI.Context
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
            PetContextSeed.SeedDatabase(this);
        }

        public DbSet<PetEntity> Pets { get; set; } = null!;
    }
}
