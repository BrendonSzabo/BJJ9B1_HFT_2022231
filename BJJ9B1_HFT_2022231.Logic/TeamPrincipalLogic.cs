using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Logic
{
    public class TeamPrincipalLogic : ITeamPrincipal
    {
        IRepository<TeamPrincipals> Repo;
        public TeamPrincipalLogic(IRepository<TeamPrincipals> repository)
        {
            this.Repo = repository;
        }
        #region Crud
        public void Create(TeamPrincipals item)
        {

            if (18 > DateTime.Now.Year - item.Birth.Year || DateTime.Now.Year - item.Birth.Year > 60)
            {
                throw new Exception("Person ineligible for team principal position due to age.");
            }
            else
            {
                Repo.Create(item);
            }
        }

        public void Delete(int id)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            Repo.Delete(id);
        }

        public TeamPrincipals Read(int id)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            var tp = Repo.Read(id);
            if (tp == null)
            {
                throw new Exception("This principal does not exist.");
            }
            return tp;
        }

        public IEnumerable<TeamPrincipals> ReadAll()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return Repo.ReadAll();
        }

        public void Update(TeamPrincipals item)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            if (Repo.Read(item.Id) != null)
            {
                Repo.Update(item);
            }
        }
        #endregion
        #region non-Crud
        public IEnumerable<string> GetMostChampionshipWinTeamPrincipal()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return this.Repo
                .ReadAll()
                .OrderBy(t => t.ChampionshipWins)
                .Select(p => p.PrincipalName)
                .Take(1);
        }
        public IEnumerable<TeamPrincipals> GetPrincipalsWithWin()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return Repo
                .ReadAll()
                .Where(t => t.FirstWin != null)
                .OrderBy(t => t.PrincipalName);
        }
        public IEnumerable<TeamPrincipals> GetPrincipalWhoDebutedIn20thCentury()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Birth.Year > 1900 && 2000>t.Birth.Year)
                .OrderBy(t => t.Birth.Year);
        }
        public IEnumerable<TeamPrincipals> GetPrincipalWithChampionship()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return Repo
                .ReadAll()
                .Where(t => t.ChampionshipWins != null)
                .OrderBy(t => t.PrincipalName);
        }
        public IEnumerable<TeamPrincipals> GetPrincipalOfBestTeam()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return Repo
                .ReadAll()
                .Where(t => t.Tm.Ranking == 1);
        }
        #endregion
    }
}
