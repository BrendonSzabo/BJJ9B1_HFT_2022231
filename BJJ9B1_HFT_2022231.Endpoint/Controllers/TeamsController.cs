using BJJ9B1_HFT_2022231.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        ITeam logic;

        public TeamsController(ITeam logic)
        {
            this.logic = logic;
        }
        // GET: api/<TeamsController>
        [HttpGet]
        public IEnumerable<Teams> ReadAll()
        {
            return logic.ReadAllTeam();
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public Teams Read(int id)
        {
            return logic.ReadTeam(id);
        }

        // POST api/<TeamsController>
        [HttpPost]
        public void Create([FromBody] Teams value)
        {
            logic.CreateTeam(value);
        }

        // PUT api/<TeamsController>/5
        [HttpPut]
        public void Update([FromBody] Teams value)
        {
            logic.UpdateTeam(value);
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.DeleteTeam(id);
        }
    }
}
