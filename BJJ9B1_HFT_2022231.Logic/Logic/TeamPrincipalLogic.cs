using BJJ9B1_HFT_2022231.Logic.Interface;
using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BJJ9B1_HFT_2022231.Logic.Logic
{
    public class TeamPrincipalLogic : ITeamPrincipal
    {
        IRepository<TeamPrincipals> Repo;
        public TeamPrincipalLogic(IRepository<TeamPrincipals> repository)
        {
            Repo = repository;
        }
        #region Crud
        public void CreateTeamPrincipal(TeamPrincipals item)
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

        public void DeleteTeamPrincipal(int id)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            Repo.Delete(id);
        }

        public TeamPrincipals ReadTeamPrincipal(int id)
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            var tp = Repo
                .Read(id);
            if (tp == null)
            {
                throw new Exception("This principal does not exist.");
            }
            return tp;
        }

        public IQueryable<TeamPrincipals> ReadAllTeamPrincipal()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return Repo.ReadAll();
        }

        public void UpdateTeamPrincipal(TeamPrincipals item)
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
        public IEnumerable<TeamPrincipals> GetMostChampionshipWinTeamPrincipal()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return new List<TeamPrincipals>() {Repo
                .ReadAll()
                .OrderBy(t => t.ChampionshipWins)
                .Reverse()
                .First() };

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
        public IEnumerable<TeamPrincipals> GetPrincipalsWhoDebutedIn20thCentury()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return Repo
                .ReadAll()
                .Where(t => 2000 > t.DebutDate.Year && t.DebutDate.Year > 1900)
                .OrderBy(t => t.Birth.Year);
        }
        public IEnumerable<TeamPrincipals> GetPrincipalOfBestTeam()
        {
            if (Repo == null)
            {
                throw new Exception("Repository is null");
            }
            return new List<TeamPrincipals>(){Repo
                .ReadAll()
                .OrderBy(t => t.Team.Ranking)
                .First()
            };
        }
        #endregion
    }
}
