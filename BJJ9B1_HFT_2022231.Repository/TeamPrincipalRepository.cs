using BJJ9B1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Repository
{
    public class TeamPrincipalRepository : Repository<TeamPrincipals>, IRepository<TeamPrincipals>
    {
        public TeamPrincipalRepository(F1DbContext DbCont) : base(DbCont)
        {
        }

        public override TeamPrincipals Read(int id)
        {
            return DbCont.Principals.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(TeamPrincipals item)
        {
            var o = Read(item.Id);
            foreach (var tmp in o.GetType().GetProperties())
            {
                tmp.SetValue(o, tmp.GetValue(item));
            }
        }
    }
}
