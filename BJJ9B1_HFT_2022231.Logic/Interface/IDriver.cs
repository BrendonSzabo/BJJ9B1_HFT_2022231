using BJJ9B1_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace BJJ9B1_HFT_2022231.Logic.Interface
{
    public interface IDriver
    {
        IQueryable<Drivers> ReadAllDriver();
        void CreateDriver(Drivers item);
        void DeleteDriver(int id);
        void UpdateDriver(Drivers item);
        Drivers ReadDriver(int id);
        IEnumerable<Drivers> GetBritishDrivers();
        IEnumerable<Drivers> GetOldestDriver();
        IEnumerable<Drivers> GetYoungestDriver();
    }
}
