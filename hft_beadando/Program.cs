using BJJ9B1_HFT_2022231.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace BJJ9B1_HFT_2022231.Client
{
    public class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Drivers")
            {
                Console.Write("Enter Driver Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Driver Id: ");
                string id = Console.ReadLine();
                Console.Write("Enter Driver TeamId: ");
                string teamid = Console.ReadLine();
                rest.Post(new Drivers() { DriverName = name, Id = int.Parse(id), TeamId = int.Parse(teamid) }, "drivers");
            }
            else if(entity == "TeamPrincipals")
            {
                Console.Write("Enter Team Principal Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Team Principal Date Of Birth: ");
                string birth = Console.ReadLine();
                rest.Post(new TeamPrincipals() { PrincipalName = name, Birth = Convert.ToDateTime(birth) }, "teamprincipals");
            }
            else if (entity == "Teams")
            {
                Console.Write("Enter Team Name: ");
                string name = Console.ReadLine();
                rest.Post(new Teams() { TeamName = name }, "teams");
            }
        }
        static void List(string entity)
        {
            if (entity == "Drivers")
            {
                List<Drivers> Drivers = rest.Get<Drivers>("drivers");
                foreach (var item in Drivers)
                {
                    Console.WriteLine(item.Id + ": " + item.DriverName);
                }
            }
            else if (entity == "TeamPrincipals")
            {
                List<TeamPrincipals> TeamPrincipals = rest.Get<TeamPrincipals>("teamprincipals");
                foreach (var item in TeamPrincipals)
                {
                    Console.WriteLine(item.Id + ": " + item.PrincipalName);
                }
            }
            else if (entity == "Teams")
            {
                List<Teams> Teams = rest.Get<Teams>("teams");
                foreach (var item in Teams)
                {
                    Console.WriteLine(item.Id + ": " + item.TeamName);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Drivers")
            {
                Console.Write("Enter Driver's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Drivers one = rest.Get<Drivers>(id, "drivers");
                Console.Write($"New name [old: {one.DriverName}]: ");
                string name = Console.ReadLine();
                one.DriverName = name;
                rest.Put(one, "drivers");
            }
            else if (entity == "TeamPrincipals")
            {
                Console.Write("Enter TeamPrincipal's id to update: ");
                int id = int.Parse(Console.ReadLine());
                TeamPrincipals one = rest.Get<TeamPrincipals>(id, "teamprincipals");
                Console.Write($"New name [old: {one.PrincipalName}]: ");
                string name = Console.ReadLine();
                one.PrincipalName = name;
                rest.Put(one, "teamprincipals");
            }
            else if (entity == "Teams")
            {
                Console.Write("Enter Teams's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Teams one = rest.Get<Teams>(id, "teams");
                Console.Write($"New name [old: {one.TeamName}]: ");
                string name = Console.ReadLine();
                one.TeamName = name;
                rest.Put(one, "teams");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Drivers")
            {
                Console.Write("Enter Drivers's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "drivers");
            }
            else if (entity == "TeamPrincipals")
            {
                Console.Write("Enter TeamPrincipal's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "teamprincipals");
            }
            else if (entity == "Teams")
            {
                Console.Write("Enter Teams's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "teams");
            }
        }
        //Statistics
        static void GetBritishDrivers()
        {
            Console.WriteLine("The British Drivers On The Grid Are: ");
            var r = rest.Get<Drivers>("statistics/GetBritishDrivers");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.DriverName}: #{item.Number}");
            }
            Console.ReadLine();
        }
        static void GetOldestDrivers()
        {
            Console.WriteLine("The Oldest Driver Is: ");
            var r = rest.Get<Drivers>("statistics/GetOldestDriver");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.DriverName}: #{item.Number}");
            }
            Console.ReadLine();
        }
        static void GetYoungestDrivers()
        {
            Console.WriteLine("The Youngest Driver Is: ");
            var r = rest.Get<Drivers>("statistics/GetYoungestDriver");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.DriverName}: #{item.Number}");
            }
            Console.ReadLine();
        }
        static void GetBestTeam()
        {
            Console.WriteLine("The Best Team Is:");
            var r = rest.Get<Teams>("statistics/GetBestTeam");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.TeamName}: #{item.Id}");
            }
            Console.ReadLine();
        }
        static void GetWorstTeam()
        {
            Console.WriteLine("The Worst Team Is:");
            var r = rest.Get<Teams>("statistics/GetWorstTeam");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.TeamName}: #{item.Id}");
            }
            Console.ReadLine();
        }
        static void GetBestTeamPrincipal()
        {
            Console.WriteLine("The Best Teams' Principal Is:");
            var r = rest.Get<TeamPrincipals>("statistics/GetBestTeamPrincipal");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.PrincipalName}: #{item.Id}");
            }
            Console.ReadLine();
        }
        static void TeamsDebutIn20thCentury()
        {
            Console.WriteLine("Teams Who Debuted In The 20th Century Is:");
            var r = rest.Get<Teams>("statistics/TeamsDebutIn20thCentury");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.TeamName}: #{item.Id}");
            }
            Console.ReadLine();
        }
        static void GetMostChampionshipWinTeamPrincipal()
        {
            Console.WriteLine("The Principal who won the most");
            var r = rest.Get<TeamPrincipals>("statistics/TeamsDebutIn20thCentury");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.PrincipalName}: #{item.Id}");
            }
            Console.ReadLine();
        }
        static void GetPrincipalsWithWin()
        {
            Console.WriteLine("Principals who won before");
            var r = rest.Get<TeamPrincipals>("statistics/GetPrincipalsWithWin");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.PrincipalName}: #{item.Id}");
            }
            Console.ReadLine();
        }
        static void GetPrincipalsWhoDebutedIn20thCentury()
        {
            Console.WriteLine("Principals who debuted int the 20th century");
            var r = rest.Get<TeamPrincipals>("statistics/GetPrincipalWhoDebutedIn20thCentury");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.PrincipalName}: #{item.Id}");
            }
            Console.ReadLine();
        }
        static void GetPrincipalOfBestTeam()
        {
            Console.WriteLine("Principals of the best team");
            var r = rest.Get<TeamPrincipals>("statistics/GetPrincipalOfBestTeam");
            foreach (var item in r)
            {
                Console.WriteLine($"{item.PrincipalName}: #{item.Id}");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            #region xxx
            //Console.WriteLine("Anz#d");
            //F1DbContext db = new();
            ////var vmi2 = db.Principals.ToList();
            ////var vmi1 = db.Teams.ToList();
            ////var vmi = db.Drivers.ToList();

            //foreach (var item in db.Principals.ToList())
            //{
            //    Console.WriteLine($"Team name: \n{item.Tm.TeamName}");
            //    Console.WriteLine($"Teamprincipal name: {item.PrincipalName}");
            //    Console.WriteLine("Drivers: ");
            //    foreach (var dv in item.Tm.Drv)
            //    {
            //        Console.WriteLine($"{dv.DriverName}- #{dv.Number}");
            //    }
            //    Console.WriteLine();
            //}

            //;
            #endregion
            rest = new RestService("http://localhost:12023/", "teams");

            var driverSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Drivers"))
                .Add("Create", () => Create("Drivers"))
                .Add("Delete", () => Delete("Drivers"))
                .Add("Update", () => Update("Drivers"))
                .Add("Exit", ConsoleMenu.Close);

            var teamprincipalSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("TeamPrincipals"))
                .Add("Create", () => Create("TeamPrincipals"))
                .Add("Delete", () => Delete("TeamPrincipals"))
                .Add("Update", () => Update("TeamPrincipals"))
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Teams"))
                .Add("Create", () => Create("Teams"))
                .Add("Delete", () => Delete("Teams"))
                .Add("Update", () => Update("Teams"))
                .Add("Exit", ConsoleMenu.Close);

            var statisticsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("British Drivers", () => GetBritishDrivers())
                .Add("Oldest driver", () => GetOldestDrivers())
                .Add("Youngest driver", () => GetYoungestDrivers())
                .Add("Best team", () => GetBestTeam())
                .Add("Worst team", () => GetWorstTeam())
                .Add("Best team principal", () => GetBestTeamPrincipal())
                .Add("Team Who debuted int the 20th century", () => TeamsDebutIn20thCentury())
                .Add("Principal with the most championships", () => GetMostChampionshipWinTeamPrincipal())
                .Add("Principals with wins", () => GetPrincipalsWithWin())
                .Add("Principals who debuted in the 20th century", () => GetPrincipalsWhoDebutedIn20thCentury())
                .Add("Principal of the best team", () => GetPrincipalOfBestTeam())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Drivers", () => driverSubMenu.Show())
                .Add("TeamPrincipals", () => teamprincipalSubMenu.Show())
                .Add("Teams", () => teamSubMenu.Show())
                .Add("Statistics",()=> statisticsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
