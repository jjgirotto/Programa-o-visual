using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ESTBooks_B.Models;

namespace ESTBooks_B.Data
{
    public class ApplicationDbContext : IdentityDbContext<BookUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ESTBooks_B.Models.Book_B> Book_B { get; set; } = default!;
        public DbSet<ESTBooks_B.Models.BookStore_B> BookStore_B { get; set; } = default!;


    }
}
