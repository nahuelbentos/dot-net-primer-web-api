using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi_M3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerWebApi_M3.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Autor> Autores{ get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
