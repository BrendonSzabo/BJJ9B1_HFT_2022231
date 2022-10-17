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

        public void Create(Drivers item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Drivers Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drivers> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Drivers item)
        {
            throw new NotImplementedException();
        }
    }
}
