using BJJ9B1_HFT_2022231.Models;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Logic
{
    public interface IDriver
    {
        IEnumerable<Drivers> ReadAllDriver();
        void CreateDriver(Drivers item);
        void DeleteDriver(int id);
        void UpdateDriver(Drivers item);
        Drivers ReadDriver(int id);
        IEnumerable<Drivers> GetBestDrivers();
        IEnumerable<Drivers> GetWorstDrivers();
        IEnumerable<Drivers> GetBritishDrivers();
        Drivers GetOldestDriver();
        Drivers GetYoungestDriver();
    }
}
