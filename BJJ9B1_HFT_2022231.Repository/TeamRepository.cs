using BJJ9B1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Repository
{
    public class TeamRepository : Repository<Teams>, IRepository<Teams>
    {
        public TeamRepository(F1DbContext DbCont) : base(DbCont)
        {
        }

        public override Teams Read(int id)
        {
            return DbCont.Teams.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Teams item)
        {
            var o = Read(item.Id);
            foreach (var tmp in o.GetType().GetProperties())
            {
                tmp.SetValue(o, tmp.GetValue(item));
            }
        }
    }
}
