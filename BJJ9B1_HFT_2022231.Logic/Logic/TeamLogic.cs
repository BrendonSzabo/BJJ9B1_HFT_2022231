using BJJ9B1_HFT_2022231.Logic.Interface;
using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Logic.Logic
{
    public class TeamLogic : ITeam
    {
        public IRepository<Teams> Repo;
        public TeamLogic(IRepository<Teams> repository)
        {
            Repo = repository;
        }
        #region Crud
        public void CreateTeam(Teams item)
        {
            if (Repo.ReadAll().Count() >= 10)
            {
                throw new Exception("Can't add any more teams.");
            }
            Repo.Create(item);
        }



        public Teams ReadTeam(int id)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            var Team = Repo
                .Read(id);
            if (Team == null)
            {
                throw new Exception("Team not found");
            }
            return Team;
        }
        public void DeleteTeam(int id)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            if (Repo.ReadAll().Where(t => t.Id == id).Single() == null)
            {
                throw new Exception("Team not found");
            }
            Repo.Delete(id);
        }

        public IEnumerable<Teams> ReadAllTeam()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return Repo.ReadAll();
        }

        public void UpdateTeam(Teams item)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            if (Repo.ReadAll().Where(t => t.Id == item.Id).Single() == null)
            {
                throw new Exception("Team not found.");
            }
            Repo.Update(item);
        }
        #endregion
        #region non-Crud
        public IEnumerable<Teams> GetBestTeam()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return new List<Teams>(){Repo
                .ReadAll()
                .OrderBy(t => t.Ranking)
                .Reverse()
                .First()
            };
        }
        public IEnumerable<Teams> GetWorstTeam()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return new List<Teams>(){Repo
                .ReadAll()
                .OrderBy(t => t.Ranking)
                .First()
            };
        }
        public IEnumerable<TeamPrincipals> GetBestTeamPrincipal()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null.");
            }
            return new List<TeamPrincipals>(){Repo
                .ReadAll()
                .OrderBy(t => t.Ranking)
                .Reverse()
                .Select(t => t.Princ)
                .First()
            };
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
