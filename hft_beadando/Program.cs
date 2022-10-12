using BJJ9B1_HFT_2022231.Repository;
using System;
using System.Linq;

namespace BJJ9B1_HFT_2022231.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            F1DbContext db = new();
            //var vmi2 = db.Principals.ToList();
            //var vmi1 = db.Teams.ToList();
            //var vmi = db.Drivers.ToList();
            
            foreach (var item in db.Principals.ToList())
            {
                Console.WriteLine($"Team name: \n{item.Tm.TeamName}");
                Console.WriteLine($"Teamprincipal name: {item.PrincipalName}");
                Console.WriteLine("Drivers: ");
                foreach (var dv in item.Tm.Drv)
                {
                    Console.WriteLine($"{dv.DriverName}- #{dv.Number}");
                }
                Console.WriteLine();
            }
            
            ;
        }
    }
}
