using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using T2_JulianaLeite.Models;

namespace T2_JulianaLeite.Data
{
    public class ApplicationDbContext : IdentityDbContext<Autocaravanista_JL>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<T2_JulianaLeite.Models.ParqueAutocaravanismo_JL> ParqueAutocaravanismo_JL { get; set; } = default!;
        public DbSet<T2_JulianaLeite.Models.Autocaravana_JL> Autocaravana_JL { get; set; } = default!;
    }
}
