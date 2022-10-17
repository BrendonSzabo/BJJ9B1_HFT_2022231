using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Logic
{
    internal class TeamPrincipalLogic : ITeamPrincipal
    {
        IRepository<TeamPrincipals> Repo;
        public TeamPrincipalLogic(IRepository<TeamPrincipals> repository)
        {
            this.Repo = repository;
        }

        public void Create(TeamPrincipals item)
        {

            if (18 > DateTime.Now.Year - item.Born.Year || DateTime.Now.Year - item.Born.Year > 60)
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
            throw new NotImplementedException();
        }

        public Drivers Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamPrincipals> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TeamPrincipals item)
        {
            throw new NotImplementedException();
        }
    }
}
