using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Logic
{
    public interface IDriver
    {
        IEnumerable<Drivers> ReadAll();
        void Create(Drivers item);
        void Delete(int id);
        void Update(Drivers item);
        Drivers Read(int id);

    }
}
