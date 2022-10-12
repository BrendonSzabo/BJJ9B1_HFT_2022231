using BJJ9B1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Logic
{
    public interface ITeam
    {
        IEnumerable<Drivers> ReadAll();
        void Update(Drivers item);
        void Create(Drivers item);
        void Delete(int id);
        Drivers Read(int id);
        
    }
}
