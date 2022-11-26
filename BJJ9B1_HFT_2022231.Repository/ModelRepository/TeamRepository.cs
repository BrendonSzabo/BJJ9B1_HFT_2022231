using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Repository.ModelRepository
{
    public class TeamRepository : Repository<Teams>, IRepository<Teams>
    {
        public TeamRepository(F1DbContext DbCont) : base(DbCont)
        {
        }

        public override Teams Read(int id)
        {
            return DbCont.Teams.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Teams item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                    prop.SetValue(old, prop.GetValue(item));
            }
            DbCont.SaveChanges();
        }
    }
}
