using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarea2.Frontend;

namespace Tarea2.Frontend.Data
{
    public class Tarea2FrontendContext : DbContext
    {
        public Tarea2FrontendContext (DbContextOptions<Tarea2FrontendContext> options)
            : base(options)
        {
        }

        public DbSet<Tarea2.Frontend.Dato> Dato { get; set; } = default!;
    }
}
