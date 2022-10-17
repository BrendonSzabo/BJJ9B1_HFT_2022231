using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Logic
{
    public class TeamLogic : ITeam
    {
        public IRepository<Teams> Repo;
        public TeamLogic(IRepository<Teams> repository)
        {
            this.Repo = repository;
        }

        public void Create(Teams item)
        {
            if (Repo.ReadAll().Count() >= 10)
            {
                throw new Exception("Can't add any more teams.");
            }
            Repo.Create(item);
        }

        public void Delete(int id)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            if (Repo.Read(id) == null)
            {
                throw new Exception("Team not found");
            }
            Repo.Delete(id);
        }

        public Teams Read(int id)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            var t = Repo.Read(id);
            if (t == null)
            {
                throw new Exception("Team not found");
            }
            return t;
        }

        public IEnumerable<Teams> ReadAll()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo.ReadAll();
        }

        public void Update(Teams item)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            if (Repo.Read(item.Id) == null)
            {
                throw new Exception("Team not found.");
            }
            Repo.Update(item);
        }
    }
}
