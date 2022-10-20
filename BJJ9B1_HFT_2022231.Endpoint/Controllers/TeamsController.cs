using BJJ9B1_HFT_2022231.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        ITeam logic;

        public TeamsController(ITeam logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Teams> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Teams Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Teams value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Teams value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
