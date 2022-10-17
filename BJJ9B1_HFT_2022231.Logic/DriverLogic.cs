using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BJJ9B1_HFT_2022231.Logic
{
    internal class DriverLogic : IDriver
    {
        IRepository<Drivers> Repo;
        public DriverLogic(IRepository<Drivers> repo)
        {
            this.Repo = repo;
        }
        #region Crud
        void IDriver.Create(Drivers item)
        {
            if (18 > DateTime.Now.Year - item.Born.Year)
            {
                throw new Exception("Driver ineligible due to young age.");
            }
            else if (item == null)
            {
                throw new Exception("Null value detected.");
            }
            else
            {
                Repo.Create(item);
            }
        }

        void IDriver.Delete(int id)
        {
            if (Repo != null)
            {
                Repo.Delete(id);
            }
            else
            {
                throw new Exception("Repository is null.");
            }
        }

        Drivers IDriver.Read(int id)
        {
            var driver = Repo.Read(id);
            if (driver == null)
            {
                throw new Exception("Driver does not exist");
            }
            return driver;
        }

        IEnumerable<Drivers> IDriver.ReadAll()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo.ReadAll();
        }

        void IDriver.Update(Drivers item)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            else
            {
                Repo.Update(item);
            }
        }
        #endregion
        #region non-Crud
        public IEnumerable<Drivers> GetBestTeamDriver()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Tm.Ranking == 1)
                .OrderBy(t => t.DriverName);
        }
        public IEnumerable<Drivers> GetWorstTeamDriver()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Tm.Ranking == 10)
                .OrderBy(t => t.DriverName);
        }
        public IEnumerable<Drivers> GetDutchDrivers()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Nationality == "Netherlands")
                .OrderBy(t => t.DriverName);
        }
        public IEnumerable<Drivers> GetBritishDrivers()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Nationality == "United Kingdom")
                .OrderBy(t => t.DriverName);
        }
        public IEnumerable<Drivers> GetOldestDriver()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            var d = Repo.ReadAll().ToList();
            int t = 0;
            foreach (var item in d)
            {
               t = Math.Max(DateTime.Now.Year - item.Born.Year, t);
            }
            int o = d.Where(i => DateTime.Now.Year - i.Born.Year == t).Select(i => i.Id).First();
            return Repo
                .ReadAll()
                .Where(t => t.Id == o);
                
        }
        public IEnumerable<Drivers> GetYoungestDriver()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            var d = Repo.ReadAll().ToList();
            int t = 600;
            foreach (var item in d)
            {
                t = Math.Min(DateTime.Now.Year - item.Born.Year, t);
            }
            int o = d.Where(i => DateTime.Now.Year - i.Born.Year == t).Select(i => i.Id).First();
            return Repo
                .ReadAll()
                .Where(t => t.Id == o);

        }
        #endregion
    }
}
