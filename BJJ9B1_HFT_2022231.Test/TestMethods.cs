﻿using System;
using Moq;
using NUnit.Framework;
using BJJ9B1_HFT_2022231.Models;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;
using BJJ9B1_HFT_2022231.Repository.DbRepository;
using BJJ9B1_HFT_2022231.Logic.Logic;

namespace BJJ9B1_HFT_2022231.Test
{
    [TestFixture]
    public class TestMethods
    {
        DriverLogic Dlogic;
        Mock<IRepository<Drivers>> mockDrivers;
        TeamLogic Tlogic;
        Mock<IRepository<Teams>> mockTeams;
        TeamPrincipalLogic TPlogic;
        Mock<IRepository<TeamPrincipals>> mockTeamPrincipals;

        [SetUp]
        public void Init()
        {

            mockDrivers = new Mock<IRepository<Drivers>>();
            mockDrivers.Setup(m => m.ReadAll()).Returns(new List<Drivers>()
            {
                new Drivers("1/Max Verstappen/1/1/Red Bull Racing/1997.9.30/Netherlands"),
                new Drivers("2/Sergio Perez/11/1/Red Bull Racing/1990.1.26/Mexico"),
                new Drivers("3/Charles Leclerc/16/2/Ferrari/1997.10.16/Monaco"),
                new Drivers("4/Carlos Sainz/55/2/Ferrari/1994.9.1/Spain"),
                new Drivers("5/Lando Norris/4/4/McLaren/1999.11.13/United Kingdom"),
                new Drivers("6/Daniel Ricciardo/3/4/McLaren/1989.07.1/Australia"),
                new Drivers("7/Lewis Hamilton/44/3/Mercedes-AMG Petronas Formula One Team/1985.01.7/United Kingdom"),

            }.AsQueryable());
            Dlogic = new DriverLogic(mockDrivers.Object);

            mockTeams = new Mock<IRepository<Teams>>();
            mockTeams.Setup(m => m.ReadAll()).Returns(new List<Teams>()
            {
                new Teams("1/Red Bull Racing/2005.1.1/1/576/343"),
                new Teams("2/Scuderia Ferrari/1950.1.1/2/439/1048"),
                new Teams("3/Mercedes-AMG Petronas Formula One Team/1954.1.1/3/373/264"),
                new Teams("4/McLaren F1 Team/1966.1.1/4/129/923"),
                new Teams("10/Williams Racing/1977.1.1/10/6/786"),
            }.AsQueryable());
            Tlogic = new TeamLogic(mockTeams.Object);

            mockTeamPrincipals = new Mock<IRepository<TeamPrincipals>>();
            mockTeamPrincipals.Setup(m => m.ReadAll()).Returns(new List<TeamPrincipals>()
            {
                new TeamPrincipals("3/Toto Wolff/2013.1.1/1972.1.12./7/2013.5.26/3"),
                new TeamPrincipals("2/Mattia Binotto/2019.1.1/1969.11.3/0/2019.9.1/2"),
                new TeamPrincipals("4/Andreas Seidl/2019.1.1/1976.1.6/0/2021.9.12/4"),
                new TeamPrincipals("1/Christian Horner/2005.1.1/1973.11.16/6/2009.4.19/1"),
            }.AsQueryable());
            TPlogic = new TeamPrincipalLogic(mockTeamPrincipals.Object);
        }

        #region Driver tests
        [Test]
        public void DriverCreateTest()
        {
            Assert.That(() => Dlogic.CreateDriver(new Drivers("8/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom")), Throws.Nothing);
        }

        [Test]
        public void DriverReadAllTest()
        {
            Assert.That(() => Dlogic.ReadAllDriver(), Throws.Nothing);
        }
        [Test]
        public void DriverUpdateTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            Assert.That(() => Dlogic.UpdateDriver(GR), Throws.Nothing);
        }
        [Test]
        public void DriverDeleteTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            Dlogic.DeleteDriver(GR.Id);
            var D = Dlogic.ReadAllDriver().ToList();
            Assert.IsFalse(D.Contains(GR));
        }

        [Test]
        public void CreateNameTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            GR.DriverName = "";
            Assert.That(() => Dlogic.CreateDriver(GR), Throws.Exception);
        }

        [Test]
        public void CreateAgeTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            GR.Born = DateTime.Now;
            Assert.That(() => Dlogic.CreateDriver(GR), Throws.Exception);
        }

        [Test]
        public void CreateNullTest()
        {
            Assert.That(() => Dlogic.CreateDriver(null), Throws.Exception);
        }
        [Test]
        public void GetBritishDriversTest()
        {
            Assert.That(() => Dlogic.GetBritishDrivers(), Throws.Nothing);
        }
        [Test]
        public void GetOldestDriverTest()
        {
            Assert.That(() => Dlogic.GetOldestDriver(), Throws.Nothing);
        }
        [Test]
        public void GetYoungestDriverTest()
        {
            Assert.That(() => Dlogic.GetYoungestDriver(), Throws.Nothing);
        }
        #endregion
        #region Team tests

        [Test]
        public void TeamReadAllTest()
        {
            Assert.That(() => Tlogic.ReadAllTeam(), Throws.Nothing);
        }
        [Test]
        public void TeamUpdateTest()
        {
            Teams teams = new Teams("4/McLaren F1 Team xd/1966.1.1/4/129/923");
            Assert.That(() => Tlogic.UpdateTeam(teams), Throws.Nothing);
        }
        [Test]
        public void TeamCreateTest()
        {
            Assert.That(() => Tlogic.CreateTeam(new Teams("5/BWT Alpine F1 Team/2021.1.1/5/125/39")), Throws.Nothing);
        }
        [Test]
        public void TeamDeleteTest()
        {
            Assert.That(() => Tlogic.DeleteTeam(2), Throws.Nothing);
        }
        [Test]
        public void GetBestTeamTest()
        {
            Assert.That(() => Tlogic.GetBestTeam(),Throws.Nothing);
        }
        [Test]
        public void GetWorstTeamTest()
        {
            Assert.That(() => Tlogic.GetWorstTeam(), Throws.Nothing);
        }
        [Test]
        public void TeamsDebutIn20thCenturyTest()
        {
            Assert.That(() => Tlogic.TeamsDebutIn20thCentury(), Throws.Nothing);
        }
        #endregion
        #region Team Principal tests

        [Test]
        public void TeamPrincipalReadAllTest()
        {
            Assert.That(() => TPlogic.ReadAllTeamPrincipal(), Throws.Nothing);
        }
        [Test]
        public void TeamPrincipalUpdateTest()
        {
            TeamPrincipals Tp = new TeamPrincipals("3/Toto Wolffie/2013.1.1/1972.1.12./7/2013.5.26/3");
            Assert.That(() => TPlogic.UpdateTeamPrincipal(Tp), Throws.Nothing);
        }
        [Test]
        public void TeamPrincipalDelete()
        {
            Assert.That(() => TPlogic.DeleteTeamPrincipal(4), Throws.Nothing);
        }
        [Test]
        public void GetMostChampionshipWinTeamPrincipal()
        {
            Assert.That(() => TPlogic.GetMostChampionshipWinTeamPrincipal(), Throws.Nothing);
        }
        [Test]
        public void GetPrincipalsWithWinTest()
        {
            Assert.That(() => TPlogic.GetPrincipalsWithWin(), Throws.Nothing);
        }
        [Test]
        public void GetPrincipalWhoDebutedIn20thCentury()
        {
            Assert.That(() => TPlogic.GetPrincipalsWhoDebutedIn20thCentury(), Throws.Nothing);
        }
        #endregion
    }
}
