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
        IEnumerable<Teams> ReadAll();
        void Update(Teams item);
        void Create(Teams item);
        void Delete(int id);
        Teams Read(int id);
        
    }
}
