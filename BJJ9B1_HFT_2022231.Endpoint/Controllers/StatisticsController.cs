using BJJ9B1_HFT_2022231.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        readonly IDriver driverLogic;
        readonly ITeam teamsLogic;
        readonly ITeamPrincipal teamprincipalsLogic;

        public StatisticsController(IDriver driverLogic, ITeam teamsLogic, ITeamPrincipal principalsLogic)
        {
            this.driverLogic = driverLogic;
            this.teamsLogic = teamsLogic;
            this.teamprincipalsLogic = principalsLogic;
        }
        #region driver httpget
        [HttpGet]
        public IEnumerable<Drivers> GetBestDrivers()
        {
            return this.driverLogic.GetBestDrivers();
        }

        [HttpGet]
        public IEnumerable<Drivers> GetWorstDrivers()
        {
            return this.driverLogic.GetWorstDrivers();
        }

        [HttpGet]
        public IEnumerable<Drivers> GetBritishDrivers()
        {
            return this.driverLogic.GetBritishDrivers();
        }

        [HttpGet]
        public Drivers GetOldestDriver()
        {
            return this.driverLogic.GetOldestDriver();
        }

        [HttpGet]
        public Drivers GetYoungestDriver()
        {
            return this.driverLogic.GetYoungestDriver();
        }
        #endregion
        #region teams httpget
        [HttpGet]
        public Teams GetBestTeam()
        {
            return this.teamsLogic.GetBestTeam();
        }
        [HttpGet]
        public Teams GetWorstTeam()
        {
            return this.teamsLogic.GetWorstTeam();
        }
        [HttpGet]
        public Teams GetTeamWithMostWin()
        {
            return this.teamsLogic.GetTeamWithMostWin();
        }
        [HttpGet]
        public TeamPrincipals GetBestTeamPrincipal()
        {
            return this.teamsLogic.GetBestTeamPrincipal();
        }
        [HttpGet]
        public IEnumerable<Teams> TeamsDebutIn20thCentury()
        {
            return this.teamsLogic.TeamsDebutIn20thCentury();
        }
        #endregion
        #region team principal httpget
        [HttpGet]
        public TeamPrincipals GetMostChampionshipWinTeamPrincipal()
        {
            return this.teamprincipalsLogic.GetMostChampionshipWinTeamPrincipal();
        }
        [HttpGet]
        public IEnumerable<TeamPrincipals> GetPrincipalsWithWin()
        {
            return this.teamprincipalsLogic.GetPrincipalsWithWin();
        }
        [HttpGet]
        public IEnumerable<TeamPrincipals> GetPrincipalWhoDebutedIn20thCentury()
        {
            return this.teamprincipalsLogic.GetPrincipalsWhoDebutedIn20thCentury();
        }
        [HttpGet]
        public IEnumerable<TeamPrincipals> GetPrincipalWithChampionship()
        {
            return this.teamprincipalsLogic.GetPrincipalsWithChampionship();
        }
        [HttpGet]
        public TeamPrincipals GetPrincipalOfBestTeam()
        {
            return this.teamprincipalsLogic.GetPrincipalOfBestTeam();
        }
        #endregion
    }
}
