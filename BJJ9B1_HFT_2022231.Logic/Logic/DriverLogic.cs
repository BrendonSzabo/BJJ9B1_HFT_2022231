﻿using BJJ9B1_HFT_2022231.Logic.Interface;
using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BJJ9B1_HFT_2022231.Logic.Logic
{
    public class DriverLogic : IDriver
    {
        IRepository<Drivers> Repo;
        public DriverLogic(IRepository<Drivers> repo)
        {
            Repo = repo;
        }
        #region Crud
        public IQueryable<Drivers> ReadAllDriver()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo.ReadAll();
        }

        public void CreateDriver(Drivers item)
        {
            if (18 > DateTime.Now.Year - item.Born.Year)
            {
                throw new Exception("Driver ineligible due to young age.");
            }
            else if (item.DriverName == "")
            {
                throw new Exception("Driver needs to have a name.");
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

        public void DeleteDriver(int id)
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

        public void UpdateDriver(Drivers item)
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

        public Drivers ReadDriver(int id)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            var driver = Repo
                .Read(id);
            if (driver == null)
            {
                throw new Exception("Driver does not exist");
            }
            return driver;
        }
        #endregion
        #region non-Crud
        public IEnumerable<Drivers> GetBritishDrivers()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Nationality == "United Kingdom")
                .OrderBy(t => t.Number);
        }
        public IEnumerable<Drivers> GetOldestDriver()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return new List<Drivers>(){Repo
                .ReadAll()
                .OrderBy(t => DateTime.Now.Year - t.Born.Year)
                .Reverse()
                .First()
            };

        }
        public IEnumerable<Drivers> GetYoungestDriver()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return new List<Drivers>(){Repo
                .ReadAll()
                .OrderBy(t => DateTime.Now.Year - t.Born.Year)
                .First()
            };
        }
        #endregion
    }
}
