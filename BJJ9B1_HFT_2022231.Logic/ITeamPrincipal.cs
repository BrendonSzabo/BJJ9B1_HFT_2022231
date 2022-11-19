﻿using BJJ9B1_HFT_2022231.Models;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Logic
{
    public interface ITeamPrincipal
    {
        IEnumerable<TeamPrincipals> ReadAllTeamPrincipal();
        void CreateTeamPrincipal(TeamPrincipals item);
        void UpdateTeamPrincipal(TeamPrincipals item);
        void DeleteTeamPrincipal(int id);
        TeamPrincipals ReadTeamPrincipal(int id);
        TeamPrincipals GetMostChampionshipWinTeamPrincipal();
        IEnumerable<TeamPrincipals> GetPrincipalsWithWin();
        IEnumerable<TeamPrincipals> GetPrincipalsWhoDebutedIn20thCentury();
        IEnumerable<TeamPrincipals> GetPrincipalsWithChampionship();
        TeamPrincipals GetPrincipalOfBestTeam();
    }
}
