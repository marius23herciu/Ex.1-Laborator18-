using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._1_Laborator18_.Models
{
    public class AutoDbContext: DbContext
    {
        public DbSet<Automobile> Automobiles { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<Producer> Producers{ get; set; }
        public DbSet<TechnicalBook> TechnicalBooks { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NCBKPTR\SQLEXPRESS;Initial Catalog=Lab18Ex1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
