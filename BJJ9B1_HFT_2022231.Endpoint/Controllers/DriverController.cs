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
    public class DriversController : ControllerBase
    {
        IDriver logic;
        IHubContext<SignalRHub> hub;

        public DriversController(IDriver logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Drivers> ReadAll()
        {
            return this.logic.ReadAllDriver();
        }

        [HttpGet("{id}")]
        public Drivers Read(int id)
        {
            return this.logic.ReadDriver(id);
        }

        [HttpPost]
        public void Create([FromBody] Drivers value)
        {
            this.logic.CreateDriver(value);
            this.hub.Clients.All.SendAsync("DriversCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Drivers value)
        {
            this.logic.UpdateDriver(value);
            this.hub.Clients.All.SendAsync("DriversUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var driverToDelete = this.logic.ReadDriver(id);
            this.logic.DeleteDriver(id);
            this.hub.Clients.All.SendAsync("DriversDeleted", driverToDelete);
        }
    }
}
