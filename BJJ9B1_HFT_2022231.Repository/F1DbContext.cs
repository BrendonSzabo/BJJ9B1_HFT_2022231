
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
            this.Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseInMemoryDatabase("F1Db")
                    .UseLazyLoadingProxies();
            }

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Drivers>(driver => driver
            .HasOne(driver => driver.Tm)
            .WithMany(teams => teams.Drv)
            .HasForeignKey(driver => driver.TeamId)
            .OnDelete(DeleteBehavior.SetNull));

            modelBuilder.Entity<TeamPrincipals>(principal => principal
                .HasOne(principal => principal.Tm)
                .WithOne(team => team.Princ)
                .HasForeignKey<TeamPrincipals>(principal => principal.TeamID)
                .OnDelete(DeleteBehavior.SetNull));


            modelBuilder.Entity<TeamPrincipals>().HasData(new TeamPrincipals[]
            {
                //id/name/debutdate/birth/wins/firstwin/teamid
                new TeamPrincipals("5/Otmar Szafnauer/1998.1.1/1964.8.13/0/2020.12.6/5"),
                new TeamPrincipals("2/Mattia Binotto/2019.1.1/1969.11.3/0/2019.9.1/2"),
                new TeamPrincipals("4/Andreas Seidl/2019.1.1/1976.1.6/0/2021.9.12/4"),
                new TeamPrincipals("1/Christian Horner/2005.1.1/1973.11.16/6/2009.4.19/1"),
                new TeamPrincipals("7/Mike Krack/1998.1.1/1972.3.18/0/null/7"),
                new TeamPrincipals("9/Guenther Steiner/1986.1.1/1965.4.7/0/null/9"),
                new TeamPrincipals("8/Franz Tost/2006.1.1/1956.1.20/0/2008.9.14/8"),
                new TeamPrincipals("6/Frédéric Vasseur/2016.1.1/1968.1.1/0/null/6"),
                new TeamPrincipals("10/Jost Capito/2021.1.1/1958.9.29/0/null/10"),
                new TeamPrincipals("3/Toto Wolff/2013.1.1/1972.1.12./7/2013.5.26/3")
            });

            modelBuilder.Entity<Teams>().HasData(new Teams[]
            {
                //id/name/firstentry/rank/championshippoints/racestarts
                new Teams("1/Red Bull Racing/2005.1.1/1/576/343"),
                new Teams("2/Scuderia Ferrari/1950.1.1/2/439/1048"),
                new Teams("3/Mercedes-AMG Petronas Formula One Team/1954.1.1/3/373/264"),
                new Teams("4/McLaren F1 Team/1966.1.1/4/129/923"),
                new Teams("5/BWT Alpine F1 Team/2021.1.1/5/125/39"),
                new Teams("6/Alfa Romeo F1 Team Orlen/1950.1.1/6/52/481"),
                new Teams("7/Aston Martin Aramco Cognizant Formula One Team/1959.1.1/7/37/45"),
                new Teams("8/Haas F1 Team/2016.1.1/8/34/138"),
                new Teams("9/Scuderia AlphaTauri/2020.1.1/9/34/56"),
                new Teams("10/Williams Racing/1977.1.1/10/6/786")
            });

            modelBuilder.Entity<Drivers>().HasData(new Drivers[]
            {
                //id/name/number/rank/teamname/birthdate/nationality
                new Drivers("1/Max Verstappen/1/1/Red Bull Racing/1997.9.30/Netherlands"),
                new Drivers("2/Sergio Perez/11/1/Red Bull Racing/1990.1.26/Mexico"),
                new Drivers("3/Charles Leclerc/16/2/Ferrari/1997.10.16/Monaco"),
                new Drivers("4/Carlos Sainz/55/2/Ferrari/1994.9.1/Spain"),
                new Drivers("5/Lando Norris/4/4/McLaren/1999.11.13/United Kingdom"),
                new Drivers("6/Daniel Ricciardo/3/4/McLaren/1989.07.1/Australia"),
                new Drivers("7/Lewis Hamilton/44/3/Mercedes-AMG Petronas Formula One Team/1985.01.7/United Kingdom"),
                new Drivers("8/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom"),
                new Drivers("9/Sebastian Vettel/5/7/Aston Martin Aramco Cognizant Formula One Team/1987.7.3/Germany"),
                new Drivers("10/Nicholas Latifi/6/10/Williams Racing/1995.6.29/Canada"),
                new Drivers("11/Pierre Gasly/10/9/Scuderia AlphaTauri/1996.2.7/France"),
                new Drivers("12/Fernando Alonso/14/5/BWT Alpine F1 Team/1981.7.29/Spain"),
                new Drivers("13/Lance Stroll/18/7/Aston Martin Aramco Cognizant Formula One Team/1998.10.29/Canada"),
                new Drivers("14/Kevin Magnussen/20/8/Haas F1 Team/1992.10.5/Denamrk"),
                new Drivers("15/Yuki Tsunoda/22/9/Scuderia AlphaTauri/2000.5.11/Japan"),
                new Drivers("16/Alex Albon/23/10/Williams Racing/1996.3.23/Thailand"),
                new Drivers("17/Zhou Guanyu/24/6/Alfa Romeo F1 Team Orlen/1999.5.30/China"),
                new Drivers("18/Esteban Ocon/31/5/BWT Alpine F1 Team/1996.9.17/France"),
                new Drivers("19/Mick Schumacher/47/8/Haas F1 Team/1999.3.22/Germany"),
                new Drivers("20/Valtteri Bottas/77/6/Alfa Romeo F1 Team Orlen/1989.8.28/Finland")
            });
        }

        
    }
}
