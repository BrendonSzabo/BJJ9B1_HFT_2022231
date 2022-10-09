using BJJ9B1_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Repository
{
    public class F1DbContext : DbContext
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
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lordn\Desktop\BJJ9B1_HFT_2022231\BJJ9B1_HFT_2022231.Repository\F1Db.mdf;Integrated Security=True";
                builder
                    .UseSqlServer(conn);
            }

        }
    }
}
