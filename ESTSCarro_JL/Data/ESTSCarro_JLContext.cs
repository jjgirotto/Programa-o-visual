using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ESTSCarro_JL.Models;

    public class ESTSCarro_JLContext : DbContext
    {
        public ESTSCarro_JLContext (DbContextOptions<ESTSCarro_JLContext> options)
            : base(options)
        {
        }

        public DbSet<ESTSCarro_JL.Models.Carro_JL> Carro_JL { get; set; } = default!;
    }
