﻿using BJJ9B1_HFT_2022231.Models;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Logic
{
    internal interface ITeamPrincipal
    {
        IEnumerable<TeamPrincipals> ReadAll();
        void Create(TeamPrincipals item);
        void Update(TeamPrincipals item);
        void Delete(int id);
        TeamPrincipals Read(int id);
    }
}
