﻿using BJJ9B1_HFT_2022231.Models;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Logic
{
    public interface IDriver
    {
        IEnumerable<Drivers> ReadAll();
        void Create(Drivers item);
        void Delete(int id);
        void Update(Drivers item);
        Drivers Read(int id);
        IEnumerable<Drivers> GetBestDriver();
        IEnumerable<Drivers> GetWorstDriver();
        IEnumerable<Drivers> GetBritishDrivers();
        Drivers GetOldestDriver();
        IEnumerable<Drivers> GetYoungestDriver();
    }
}
