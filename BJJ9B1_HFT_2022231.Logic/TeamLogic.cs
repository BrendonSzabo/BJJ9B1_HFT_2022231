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
        #region Crud
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
                throw new Exception("Repository is null");
            }
            var Team = Repo
                .ReadAll()
                .Where(t => t.Id == id)
                .Single();
            if (Team == null)
            {
                throw new Exception("Team not found");
            }
            return Team;
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
        #endregion
        #region non-Crud
        public IEnumerable<Teams> GetBeastTeam()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Ranking == 1);
        }
        public IEnumerable<Teams> GetWorstTeam()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Ranking == 10);
        }
        public IEnumerable<Teams> GetTeamWithMostWin()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Wins != 0)
                .OrderBy(t => t.Wins)
                .Take(1);
        }
        public IEnumerable<string> GetBeastTeamPrincipal()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Ranking == 1)
                .Select(t => t.Princ.PrincipalName);
        }
        public IEnumerable<Teams> TeamsDebutIn20thCentury()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo
                .ReadAll()
                .Where(t => 2000 > t.FirstEntry.Year && t.FirstEntry.Year > 1900)
                .OrderBy(t => t.FirstEntry.Year);
        }
        #endregion
    }
}
