using BJJ9B1_HFT_2022231.Logic;
using System;
using System.Linq;

namespace BJJ9B1_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            F1DbContext db = new F1DbContext();
            var vmi = db.Teams.ToList();
            ;
        }
    }
}
