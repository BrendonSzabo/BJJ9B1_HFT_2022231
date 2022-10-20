using BJJ9B1_HFT_2022231.Models;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Logic
{
    public interface ITeamPrincipal
    {
        IEnumerable<TeamPrincipals> ReadAll();
        void Create(TeamPrincipals item);
        void Update(TeamPrincipals item);
        void Delete(int id);
        TeamPrincipals Read(int id);
        TeamPrincipals GetMostChampionshipWinTeamPrincipal();
        IEnumerable<TeamPrincipals> GetPrincipalsWithWin();
        IEnumerable<TeamPrincipals> GetPrincipalWhoDebutedIn20thCentury();
        IEnumerable<TeamPrincipals> GetPrincipalWithChampionship();
        TeamPrincipals GetPrincipalOfBestTeam();
    }
}
