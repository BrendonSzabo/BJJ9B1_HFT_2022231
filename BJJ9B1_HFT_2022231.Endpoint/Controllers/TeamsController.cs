using BJJ9B1_HFT_2022231.Endpoint.Services;
using BJJ9B1_HFT_2022231.Logic.Interface;
using BJJ9B1_HFT_2022231.Logic.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        ITeam logic;
        IHubContext<SignalRHub> hub;

        public TeamsController(ITeam logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Teams> ReadAll()
        {
            return this.logic.ReadAllTeam();
        }

        [HttpGet("{id}")]
        public Teams Read(int id)
        {
            return this.logic.ReadTeam(id);
        }

        [HttpPost]
        public void Create([FromBody] Teams value)
        {
            this.logic.CreateTeam(value);
            this.hub.Clients.All.SendAsync("TeamsCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Teams value)
        {
            this.logic.UpdateTeam(value);
            this.hub.Clients.All.SendAsync("TeamsUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teamToDelete = this.logic.ReadTeam(id);
            this.logic.DeleteTeam(id);
            this.hub.Clients.All.SendAsync("TeamsDeleted", teamToDelete);
        }
    }
}
