using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hognogi_Daniela_Taisia_Laborator2.Models;

namespace Hognogi_Daniela_Taisia_Laborator2.Data
{
    public class Hognogi_Daniela_Taisia_Laborator2Context : DbContext
    {
        public Hognogi_Daniela_Taisia_Laborator2Context(DbContextOptions<Hognogi_Daniela_Taisia_Laborator2Context> options)
            : base(options)
        {
        }

        public DbSet<Hognogi_Daniela_Taisia_Laborator2.Models.Book> Book { get; set; } = default!;
        public DbSet<Hognogi_Daniela_Taisia_Laborator2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Hognogi_Daniela_Taisia_Laborator2.Models.Author> Author { get; set; } = default!;
    }
    
}
