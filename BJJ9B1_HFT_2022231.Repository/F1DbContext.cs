using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Repository
{
    class F1DbContext : DbContext
    {
        public DbSet<Teams> Teams { get; set; }
        public DbSet<TeamPrincipals> Principals { get; set; }
        public DbSet<Drivers> Drivers { get; set; }

        public F1DbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tamás Szabó\Desktop\hft_beadando\hft_beadando\F1DbMdf.mdf;Integrated Security=True";
                builder
                    .UseSqlServer(conn);
            }

        }
    }
}
