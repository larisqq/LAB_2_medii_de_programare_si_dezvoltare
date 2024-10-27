using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LAB_2.Models;

namespace LAB_2.Data
{
    public class LAB_2Context : DbContext
    {
        public LAB_2Context (DbContextOptions<LAB_2Context> options)
            : base(options)
        {
        }

        public DbSet<LAB_2.Models.Book> Book { get; set; } = default!; 
        public DbSet<LAB_2.Models.Author> Author { get; set; } = default;
        public DbSet<LAB_2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
