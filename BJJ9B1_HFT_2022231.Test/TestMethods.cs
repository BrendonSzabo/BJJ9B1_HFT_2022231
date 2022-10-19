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
                new Teams("1/Red Bull Racing/2005.1.1/1/576/id.christianhorner/343"),
                new Teams("2/Scuderia Ferrari/1950.1.1/2/439/id.binotto/1048"),
                new Teams("3/Mercedes-AMG Petronas Formula One Team/1954.1.1/3/373/id.totowolff/264"),
                new Teams("4/McLaren F1 Team/1966.1.1/4/129/id.andreasseidl/923"),
            }.AsQueryable());
            Tlogic = new TeamLogic(mockTeams.Object);

            mockTeamPrincipals = new Mock<IRepository<TeamPrincipals>>();
            mockTeamPrincipals.Setup(m => m.ReadAll()).Returns(new List<TeamPrincipals>()
            {
                new TeamPrincipals("3/Toto Wolff/id.merc/2013.1.1/1972.1.12./7/2013.5.26/3"),
                new TeamPrincipals("2/Mattia Binotto/id.ferrari/2019.1.1/1969.11.3/0/2019.9.1/2"),
                new TeamPrincipals("4/Andreas Seidl/id.mclaren/2019.1.1/1976.1.6/0/2021.9.12/4"),
                new TeamPrincipals("1/Christian Horner/id.rb/2005.1.1/1973.11.16/6/2009.4.19/1"),
            }.AsQueryable());
            TPlogic = new TeamPrincipalLogic(mockTeamPrincipals.Object);
        }

        [Test]
        public void DriverCreateTest()
        {
            Drivers GR = new Drivers("8/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            Dlogic.Create(GR);
            Assert.Contains(GR, Dlogic.ReadAll().ToList());
        }
        [Test]
        public void DriverReadTest()
        {
            Drivers GR = new Drivers("8/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            Assert.That(Dlogic.Read(8), Is.EqualTo(GR));
        }
        [Test]
        public void DriverReadAllTest()
        {
            List<Drivers> D = new List<Drivers>
            {
                new Drivers("1/Max Verstappen/1/1/Red Bull Racing/1997.9.30/Netherlands"),
                new Drivers("2/Sergio Perez/11/1/Red Bull Racing/1990.1.26/Mexico"),
                new Drivers("3/Charles Leclerc/16/2/Ferrari/1997.10.16/Monaco"),
                new Drivers("4/Carlos Sainz/55/2/Ferrari/1994.9.1/Spain"),
                new Drivers("5/Lando Norris/4/4/McLaren/1999.11.13/United Kingdom"),
                new Drivers("6/Daniel Ricciardo/3/4/McLaren/1989.07.1/Australia"),
                new Drivers("7/Lewis Hamilton/44/3/Mercedes-AMG Petronas Formula One Team/1985.01.7/United Kingdom"),
                new Drivers("8/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom")
            };
            Assert.That(Dlogic.ReadAll().ToList().OrderBy(t=>t.Id), Is.EqualTo(D.OrderBy(t => t.Id)));
        }
        [Test]
        public void DriverUpdateTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            Dlogic.Update(GR);
            var D = Dlogic.ReadAll().ToList();
            Assert.Contains(GR, D);
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
            try
            {
                Dlogic.Create(GR);
            }
            catch (Exception e)
            {
                Assert.That(e.Message, Is.EqualTo("Driver needs to have a name."));
            }
        }
        [Test]
        public void CreateAgeTest()
        {
            Drivers GR = new Drivers("22/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom");
            GR.Born = DateTime.Now;
            try
            {
                Dlogic.Create(GR);
            }
            catch (Exception e)
            {
                Assert.That(e.Message, Is.EqualTo("Driver ineligible due to young age."));
            }
        }

        [Test]
        public void CreateNullTest()
        {
            try
            {
                Dlogic.Create(null);
            }
            catch (Exception e)
            {

                Assert.That(e.Message, Is.EqualTo("Null value detected."));
            }
        }
        [Test]
        public void BestDriverTest()
        {
            var d = Dlogic.GetBestDriver();
            Assert.That(d, Is.EqualTo("Max Verstappen"));
        }
        [Test]
        public void GetBritishDriversTest()
        {
            var Brits = new List<Drivers>
            {
                new Drivers("7/Lewis Hamilton/44/3/Mercedes-AMG Petronas Formula One Team/1985.01.7/United Kingdom"),
                new Drivers("8/Geroge Russell/63/3/Mercedes-AMG Petronas Formula One Team/1998.02.15/United Kingdom"),
                new Drivers("5/Lando Norris/4/4/McLaren/1999.11.13/United Kingdom")
            }.OrderBy(t => t.DriverName);
            Assert.That(Dlogic.GetBritishDrivers().ToList(), Is.EqualTo(Brits));
        }
    }
}
