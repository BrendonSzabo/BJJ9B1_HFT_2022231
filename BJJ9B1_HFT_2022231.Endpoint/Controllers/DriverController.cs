using BJJ9B1_HFT_2022231.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        IDriver logic;

        public DriverController(IDriver logic)
        {
            this.logic = logic;
        }
        // GET: api/<DriverController>
        [HttpGet]
        public IEnumerable<Drivers> ReadAll()
        {
            return this.logic.ReadAllDriver();
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public Drivers Read(int id)
        {
            return logic.ReadDriver(id);
        }

        // POST api/<DriverController>
        [HttpPost]
        public void Create([FromBody] Drivers value)
        {
            logic.CreateDriver(value);
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Drivers value)
        {
            logic.UpdateDriver(value);
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.DeleteDriver(id);
        }
    }
}
