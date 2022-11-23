using BJJ9B1_HFT_2022231.Models;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Logic
{
    public interface ITeam
    {
        IEnumerable<Teams> ReadAllTeam();
        void UpdateTeam(Teams item);
        void CreateTeam(Teams item);
        void DeleteTeam(int id);
        Teams ReadTeam(int id);
        IEnumerable<Teams> GetBestTeam();
        IEnumerable<Teams> GetWorstTeam();
        IEnumerable<TeamPrincipals> GetBestTeamPrincipal();
        IEnumerable<Teams> TeamsDebutIn20thCentury();

    }
}
