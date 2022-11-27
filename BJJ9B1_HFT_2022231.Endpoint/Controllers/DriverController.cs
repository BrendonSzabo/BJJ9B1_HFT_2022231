using BJJ9B1_HFT_2022231.Logic.Interface;
using BJJ9B1_HFT_2022231.Logic.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        IDriver logic;

        public DriversController(IDriver logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Drivers value)
        {
            this.logic.UpdateDriver(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeleteDriver(id);
        }
    }
}
