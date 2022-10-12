using BJJ9B1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Repository
{
    public class DriverRepository : Repository<Drivers>, IRepository<Drivers>
    {
        public DriverRepository(F1DbContext DbCont) : base(DbCont)
        {
        }

        public override Drivers Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Drivers item)
        {
            throw new NotImplementedException();
        }
    }
}
