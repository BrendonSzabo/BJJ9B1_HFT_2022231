using BJJ9B1_HFT_2022231.Models;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Logic
{
    public interface ITeam
    {
        IEnumerable<Teams> ReadAll();
        void Update(Teams item);
        void Create(Teams item);
        void Delete(int id);
        Teams Read(int id);
        Teams GetBeastTeam();
        Teams GetWorstTeam();
        IEnumerable<Teams> GetTeamWithMostWin();
        string GetBestTeamPrincipal();
        IEnumerable<Teams> TeamsDebutIn20thCentury();

    }
}
