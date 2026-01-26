using ESTSCarro_JL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ESTSCarro_JL.Data
{
    public class ApplicationDbContext : IdentityDbContext<Cliente_JL>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
