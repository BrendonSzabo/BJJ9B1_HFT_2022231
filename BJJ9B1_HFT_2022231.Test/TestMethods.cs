using System;
using Moq;
using NUnit.Framework;
using BJJ9B1_HFT_2022231.Logic;
using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;

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
                new Teams("2/Scuderia Ferrari/1950.1.1/2/439/id.binotto/1048"),
                new Teams("3/Mercedes-AMG Petronas Formula One Team/1954.1.1/3/373/264"),
                new Teams("4/McLaren F1 Team/1966.1.1/4/129/923"),
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
        Assert.That(() => Dlogic.Create(new Drivers("8/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom")), Throws.Nothing);
        }

        [Test]
        public void DriverReadTest()
        { 
            Assert.That(() => Dlogic.Read(4).ToString(), Is.EqualTo(new Drivers("4/Carlos Sainz/55/2/Ferrari/1994.9.1/Spain").ToString()));
        }
        
        [Test]
        public void DriverReadAllTest()
        {
            Assert.That(() => Dlogic.ReadAll(), Throws.Nothing);
        }
        [Test]
        public void DriverUpdateTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            Dlogic.Update(GR);
            Assert.That(() => Dlogic.Update(GR), Throws.Nothing);
        }
        [Test]
        public void DriverDeleteTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            Dlogic.Delete(GR.Id);
            var D = Dlogic.ReadAll().ToList();
            Assert.IsFalse(D.Contains(GR));
        }

        [Test]
        public void CreateNameTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            GR.DriverName = "";
            Assert.That(() => Dlogic.Create(GR), Throws.Exception);
        }

        [Test]
        public void CreateAgeTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            GR.Born = DateTime.Now;
            Assert.That(() => Dlogic.Create(GR), Throws.Exception);
        }

        [Test]
        public void CreateNullTest()
        {
            Assert.That(() => Dlogic.Create(null), Throws.Exception);
        }

        [Test]
        public void BestDriverTest()
        {
            Assert.That(() => Dlogic.GetBestDriver(),Throws.Nothing);
        }

        [Test]
        public void GetBritishDriversTest()
        {
            Assert.That(() => Dlogic.GetBritishDrivers(), Throws.Nothing);
        }
        #endregion
        #region Team tests
        [Test]
        public void TeamReadTest()
        {
            Assert.That(() => Tlogic.Read(4).ToString(), Is.EqualTo(new Teams("4/McLaren F1 Team/1966.1.1/4/129/id.andreasseidl/923").ToString()));
        }
        [Test]
        public void TeamReadAllTest()
        {
            Assert.That(() => Tlogic.ReadAll(), Throws.Nothing);
        }
        [Test]
        public void TeamUpdateTest()
        {
            Assert.That(() => Tlogic.Update(new Teams("4/McLaren F1 Team xd/1966.1.1/4/129/id.andreasseidl/923")), Throws.Nothing);
        }
        [Test]
        public void TeamCreateTest()
        {
            Assert.That(() => Tlogic.Create(new Teams("5/BWT Alpine F1 Team/2021.1.1/5/125/id.otmarszafnauer/39")), Throws.Nothing);
        }
        [Test]
        public void TeamDeleteTest()
        {
            Assert.That(() => Tlogic.Delete(4), Throws.Nothing);
        }
        [Test]
        public void GetBestTeamTest()
        {
            Assert.That(() => Tlogic.GetBeastTeam().ToString(), Is.EqualTo(new Teams("1/Red Bull Racing/2005.1.1/1/576/343").ToString()));
        }
        [Test]
        public void GetWorstTeamTest()
        {
            Assert.That(() => Tlogic.GetWorstTeam().ToString(), Is.EqualTo(new Teams("4/McLaren F1 Team/1966.1.1/4/129/923").ToString()));
        }
        [Test]
        public void GetTeamWithMostPointsTest()
        {
            Assert.That(() => Tlogic.GetTeamWithMostWin(), Throws.Nothing);
        }
        [Test]
        public void GetBestTeamPrincipalTest()
        {
            Assert.That(() => Tlogic.GetBestTeamPrincipal(), Is.EqualTo("Christian Horner"));
        }
        [Test]
        public void TeamsDebutIn20thCenturyTest()
        {
            Assert.That(() => Tlogic.TeamsDebutIn20thCentury(), Throws.Nothing);
        }
        #endregion
        #region Team Principal tests
        [Test]
        public void TeamPrincipalReadTest()
        {
            Assert.That(() => TPlogic.Read(4).ToString(), Is.EqualTo(new TeamPrincipals("4/Andreas Seidl/id.mclaren/2019.1.1/1976.1.6/0/2021.9.12/4").ToString()));
        }
        #endregion
    }
}
